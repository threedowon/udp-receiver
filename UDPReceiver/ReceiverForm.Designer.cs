namespace UDPReceiver
{
    partial class ReceiverForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopyIP = new System.Windows.Forms.Button();
            this.lblLocalIP = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAverageSize = new System.Windows.Forms.Label();
            this.lblTotalBytes = new System.Windows.Forms.Label();
            this.lblReceivedCount = new System.Windows.Forms.Label();
            this.btnClearStats = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCopyIP);
            this.groupBox1.Controls.Add(this.lblLocalIP);
            this.groupBox1.Controls.Add(this.btnStartStop);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UDP 수신 설정";
            // 
            // btnCopyIP
            // 
            this.btnCopyIP.Location = new System.Drawing.Point(200, 80);
            this.btnCopyIP.Name = "btnCopyIP";
            this.btnCopyIP.Size = new System.Drawing.Size(80, 30);
            this.btnCopyIP.TabIndex = 4;
            this.btnCopyIP.Text = "IP 복사";
            this.btnCopyIP.UseVisualStyleBackColor = true;
            this.btnCopyIP.Click += new System.EventHandler(this.btnCopyIP_Click);
            // 
            // lblLocalIP
            // 
            this.lblLocalIP.AutoSize = true;
            this.lblLocalIP.Location = new System.Drawing.Point(80, 50);
            this.lblLocalIP.Name = "lblLocalIP";
            this.lblLocalIP.Size = new System.Drawing.Size(100, 15);
            this.lblLocalIP.TabIndex = 3;
            this.lblLocalIP.Text = "로컬 IP 주소";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(110, 80);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(80, 30);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "수신 시작";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(80, 20);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 23);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "7777";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "포트:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAverageSize);
            this.groupBox2.Controls.Add(this.lblTotalBytes);
            this.groupBox2.Controls.Add(this.lblReceivedCount);
            this.groupBox2.Controls.Add(this.btnClearStats);
            this.groupBox2.Location = new System.Drawing.Point(12, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(300, 120);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "수신 통계";
            // 
            // lblAverageSize
            // 
            this.lblAverageSize.AutoSize = true;
            this.lblAverageSize.Location = new System.Drawing.Point(20, 80);
            this.lblAverageSize.Name = "lblAverageSize";
            this.lblAverageSize.Size = new System.Drawing.Size(100, 15);
            this.lblAverageSize.TabIndex = 3;
            this.lblAverageSize.Text = "평균 크기: 0 bytes";
            // 
            // lblTotalBytes
            // 
            this.lblTotalBytes.AutoSize = true;
            this.lblTotalBytes.Location = new System.Drawing.Point(20, 50);
            this.lblTotalBytes.Name = "lblTotalBytes";
            this.lblTotalBytes.Size = new System.Drawing.Size(100, 15);
            this.lblTotalBytes.TabIndex = 2;
            this.lblTotalBytes.Text = "총 바이트: 0";
            // 
            // lblReceivedCount
            // 
            this.lblReceivedCount.AutoSize = true;
            this.lblReceivedCount.Location = new System.Drawing.Point(20, 20);
            this.lblReceivedCount.Name = "lblReceivedCount";
            this.lblReceivedCount.Size = new System.Drawing.Size(100, 15);
            this.lblReceivedCount.TabIndex = 1;
            this.lblReceivedCount.Text = "수신 패킷: 0";
            // 
            // btnClearStats
            // 
            this.btnClearStats.Location = new System.Drawing.Point(200, 80);
            this.btnClearStats.Name = "btnClearStats";
            this.btnClearStats.Size = new System.Drawing.Size(80, 30);
            this.btnClearStats.TabIndex = 0;
            this.btnClearStats.Text = "통계 초기화";
            this.btnClearStats.UseVisualStyleBackColor = true;
            this.btnClearStats.Click += new System.EventHandler(this.btnClearStats_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClearLog);
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Location = new System.Drawing.Point(330, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 400);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "수신 로그";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(360, 360);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(80, 30);
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.Text = "로그 지우기";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(20, 20);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(410, 330);
            this.txtLog.TabIndex = 0;
            // 
            // ReceiverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReceiverForm";
            this.Text = "UDP Receiver";
            this.Icon = new System.Drawing.Icon("app.ico");
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCopyIP;
        private System.Windows.Forms.Label lblLocalIP;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblAverageSize;
        private System.Windows.Forms.Label lblTotalBytes;
        private System.Windows.Forms.Label lblReceivedCount;
        private System.Windows.Forms.Button btnClearStats;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.TextBox txtLog;
    }
}
