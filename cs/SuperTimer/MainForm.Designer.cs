namespace SuperTimer
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_buttonStart = new System.Windows.Forms.Button();
            this.m_buttonStop = new System.Windows.Forms.Button();
            this.m_labelRest = new System.Windows.Forms.Label();
            this.m_progressBarWork = new System.Windows.Forms.ProgressBar();
            this.m_progressBarRest = new System.Windows.Forms.ProgressBar();
            this.m_timerWork = new System.Windows.Forms.Timer(this.components);
            this.m_timerRest = new System.Windows.Forms.Timer(this.components);
            this.m_labelWork = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_buttonStart
            // 
            this.m_buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonStart.Location = new System.Drawing.Point(301, 52);
            this.m_buttonStart.Name = "m_buttonStart";
            this.m_buttonStart.Size = new System.Drawing.Size(75, 23);
            this.m_buttonStart.TabIndex = 1;
            this.m_buttonStart.Text = "Start";
            this.m_buttonStart.UseVisualStyleBackColor = true;
            this.m_buttonStart.Click += new System.EventHandler(this.m_buttonStart_Click);
            // 
            // m_buttonStop
            // 
            this.m_buttonStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonStop.Location = new System.Drawing.Point(382, 52);
            this.m_buttonStop.Name = "m_buttonStop";
            this.m_buttonStop.Size = new System.Drawing.Size(75, 23);
            this.m_buttonStop.TabIndex = 1;
            this.m_buttonStop.Text = "Stop";
            this.m_buttonStop.UseVisualStyleBackColor = true;
            this.m_buttonStop.Click += new System.EventHandler(this.m_buttonStop_Click);
            // 
            // m_labelRest
            // 
            this.m_labelRest.AutoSize = true;
            this.m_labelRest.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_labelRest.Location = new System.Drawing.Point(328, 31);
            this.m_labelRest.Name = "m_labelRest";
            this.m_labelRest.Size = new System.Drawing.Size(131, 12);
            this.m_labelRest.TabIndex = 0;
            this.m_labelRest.Text = "05 minutes 00 seconds";
            // 
            // m_progressBarWork
            // 
            this.m_progressBarWork.Location = new System.Drawing.Point(12, 9);
            this.m_progressBarWork.Name = "m_progressBarWork";
            this.m_progressBarWork.Size = new System.Drawing.Size(310, 19);
            this.m_progressBarWork.TabIndex = 3;
            // 
            // m_progressBarRest
            // 
            this.m_progressBarRest.Location = new System.Drawing.Point(328, 9);
            this.m_progressBarRest.Name = "m_progressBarRest";
            this.m_progressBarRest.Size = new System.Drawing.Size(131, 19);
            this.m_progressBarRest.TabIndex = 3;
            // 
            // m_timerWork
            // 
            this.m_timerWork.Interval = 1000;
            this.m_timerWork.Tick += new System.EventHandler(this.m_timerWork_Tick);
            // 
            // m_timerRest
            // 
            this.m_timerRest.Interval = 1000;
            this.m_timerRest.Tick += new System.EventHandler(this.m_timerRest_Tick);
            // 
            // m_labelWork
            // 
            this.m_labelWork.AutoSize = true;
            this.m_labelWork.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_labelWork.Location = new System.Drawing.Point(13, 31);
            this.m_labelWork.Name = "m_labelWork";
            this.m_labelWork.Size = new System.Drawing.Size(131, 12);
            this.m_labelWork.TabIndex = 4;
            this.m_labelWork.Text = "25 minutes 00 seconds";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 85);
            this.Controls.Add(this.m_labelRest);
            this.Controls.Add(this.m_labelWork);
            this.Controls.Add(this.m_progressBarRest);
            this.Controls.Add(this.m_progressBarWork);
            this.Controls.Add(this.m_buttonStop);
            this.Controls.Add(this.m_buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "自律定时器";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button m_buttonStart;
        private System.Windows.Forms.Button m_buttonStop;
        private System.Windows.Forms.Label m_labelRest;
        private System.Windows.Forms.ProgressBar m_progressBarWork;
        private System.Windows.Forms.ProgressBar m_progressBarRest;
        private System.Windows.Forms.Timer m_timerWork;
        private System.Windows.Forms.Timer m_timerRest;
        private System.Windows.Forms.Label m_labelWork;
    }
}

