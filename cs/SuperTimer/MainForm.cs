using Microsoft.WindowsAPICodePack.Taskbar;
using SuperTimer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperTimer
{
    public partial class MainForm : Form
    {
        #region Const

        private static readonly int TOTAL_WORK = 25 * 60;
        private static readonly int TOTAL_REST = 5 * 60;

        private static readonly string FILE_PATH_WORK = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            @"data\work1.wav");
        private static readonly string FILE_PATH_REST = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            @"data\rest1.wav");

        #endregion

        #region Fields

        private bool m_bIsWorkTimer;
        private int m_iSecondeLeft4Work;
        private int m_iSecondeLeft4Rest;

        #endregion

        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            FormUtils.showRightBottom(this);
        }

        #endregion

        #region work

        private void m_timerWork_Tick(object sender, EventArgs e)
        {
            //update m_iSecondeLeft4Work
            this.m_iSecondeLeft4Work--;

            //if finish
            if (this.m_iSecondeLeft4Work < 0)
            {
                this._stopTimer4Work();
                this._initTimer4Rest();
                return;
            }

            //update view
            var oTimerVo = TimerVo.parse(this.m_iSecondeLeft4Work);
            this.m_labelWork.Text = oTimerVo.toStr();
            this.m_progressBarWork.Value = TimeUtils.toPercent(this.m_iSecondeLeft4Work, TOTAL_WORK);
            TaskbarManager.Instance.SetProgressValue(this.m_progressBarWork.Value, this.m_progressBarWork.Maximum);
        }
        private void _initTimer4Work()
        {
            this.m_bIsWorkTimer = true;
            this.m_iSecondeLeft4Work = TOTAL_WORK;
            this.m_timerWork.Start();
        }
        private void _stopTimer4Work()
        {
            this.WindowState = FormWindowState.Normal;
            this.m_timerWork.Stop();
            Task.Run(() => {
                PlayerUtils.PlayMusic(FILE_PATH_WORK);
            });
        }

        #endregion

        #region rest

        private void m_timerRest_Tick(object sender, EventArgs e)
        {
            //update m_iSecondeLeft4Rest
            this.m_iSecondeLeft4Rest--;

            //if finish
            if (this.m_iSecondeLeft4Rest < 0)
            {
                this._stopTimer4Rest();
                this._initTimer4Work();
                return;
            }

            //update view
            var oTimerVo = TimerVo.parse(this.m_iSecondeLeft4Rest);
            this.m_labelRest.Text = oTimerVo.toStr();
            this.m_progressBarRest.Value = TimeUtils.toPercent(this.m_iSecondeLeft4Rest, TOTAL_REST);
            TaskbarManager.Instance.SetProgressValue(this.m_progressBarRest.Value, this.m_progressBarRest.Maximum);
        }
        private void _initTimer4Rest()
        {
            this.m_bIsWorkTimer = false;
            this.m_iSecondeLeft4Rest = TOTAL_REST;
            this.m_timerRest.Start();
        }
        private void _stopTimer4Rest()
        {
            this.WindowState = FormWindowState.Normal;
            this.m_timerRest.Stop();
            Task.Run(()=> {
                PlayerUtils.PlayMusic(FILE_PATH_REST);
            });
        }

        #endregion

        #region start/stop

        private void m_buttonStart_Click(object sender, EventArgs e)
        {
            this._initTimer4Work();
        }

        private void m_buttonStop_Click(object sender, EventArgs e)
        {
            if (this.m_bIsWorkTimer)
            {
                this.m_timerWork.Stop();
            }
            else
            {
                this.m_timerRest.Stop();
            }
        }

        #endregion
    }

    class TimerVo
    {
        #region Fields

        public int minute { set; get; }
        public int second { set; get; }

        #endregion

        #region parse

        public static TimerVo parse(int iSeconds)
        {
            TimerVo oOutVo = new TimerVo();

            oOutVo.minute = iSeconds / 60;
            oOutVo.second = iSeconds - oOutVo.minute * 60;

            return oOutVo;
        }

        #endregion

        #region toStr

        public string toStr()
        {
            return string.Format("{0} minitues {1} seconds", this.minute, this.second);
        }

        #endregion
    }

    class TimeUtils
    {
        #region toPercent

        public static int toPercent(int iSecond, int iTotalSecond)
        {
            return (int)(Math.Round((double)(iTotalSecond - iSecond) / (double)iTotalSecond, 2) * 100);
        }

        #endregion
    }

    class FormUtils
    {
        #region showRightBottom

        public static void showRightBottom(Form oForm)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Right - oForm.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - oForm.Height;
            oForm.Location = new Point(x, y);
        }

        #endregion
    }

    class PlayerUtils
    {
        #region Const

        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;

        #endregion

        #region Fields

        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, string lpstrReturnString, uint uReturnLength,
            uint hWndCallback);

        #endregion

        #region wmv

        public static void playWmv(Stream oStream)
        {
            System.Media.SoundPlayer sp = new SoundPlayer();
            sp.Stream = oStream;
            //sp.SoundLocation = Resources.work1;
            sp.PlayLooping();
        }

        #endregion

        #region play

        public static void playSystemMusic1()
        {
            SystemSounds.Beep.Play();
        }

        public static void PlayNmusinc(string path)
        {
            mciSendString(@"close temp_alias", null, 0, 0);
            mciSendString(@"open """ + path + @""" alias temp_alias", null, 0, 0);
            mciSendString("play temp_alias repeat", null, 0, 0);
        }

        /// <summary>
        /// 播放音乐文件(重复)
        /// </summary>
        /// <param name="p_FileName">音乐文件名称</param>
        public static void PlayMusic_Repeat(string p_FileName)
        {
            try
            {
                mciSendString(@"close temp_music", " ", 0, 0);
                mciSendString(@"open " + p_FileName + " alias temp_music", " ", 0, 0);
                mciSendString(@"play temp_music repeat", " ", 0, 0);
            }
            catch
            { }
        }

        /// <summary>
        /// 播放音乐文件
        /// </summary>
        /// <param name="p_FileName">音乐文件名称</param>
        public static void PlayMusic(string p_FileName)
        {
            try
            {
                mciSendString(@"close temp_music", " ", 0, 0);
                //mciSendString(@"open " + p_FileName + " alias temp_music", " ", 0, 0);
                mciSendString(@"open """ + p_FileName + @""" alias temp_music", null, 0, 0);
                mciSendString(@"play temp_music", " ", 0, 0);
            }
            catch
            { }
        }

        #endregion

        #region stop

        /// <summary>
        /// 停止当前音乐播放
        /// </summary>
        /// <param name="p_FileName">音乐文件名称</param>
        public static void StopMusic(string p_FileName)
        {
            try
            {
                mciSendString(@"close " + p_FileName, " ", 0, 0);
            }
            catch { }
        }

        #endregion
    }
}
