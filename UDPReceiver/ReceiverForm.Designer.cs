namespace UDPReceiver
{
    partial class ReceiverForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewPort = new System.Windows.Forms.TextBox();
            this.btnAddPort = new System.Windows.Forms.Button();
            this.dgvPorts = new System.Windows.Forms.DataGridView();
            this.btnRemovePort = new System.Windows.Forms.Button();
            this.btnStartAll = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLocalIP = new System.Windows.Forms.Label();
            this.btnCopyIP = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslPorts = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsslActive = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsslPackets = new System.Windows.Forms.ToolStripStatusLabel();

            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorts)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();

            // ── groupBox1 : 포트 관리 ──────────────────────────────────────
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNewPort);
            this.groupBox1.Controls.Add(this.btnAddPort);
            this.groupBox1.Controls.Add(this.dgvPorts);
            this.groupBox1.Controls.Add(this.btnRemovePort);
            this.groupBox1.Controls.Add(this.btnStartAll);
            this.groupBox1.Controls.Add(this.btnStopAll);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Size = new System.Drawing.Size(386, 408);
            this.groupBox1.Text = "포트 관리";
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
                                  | System.Windows.Forms.AnchorStyles.Left
                                  | System.Windows.Forms.AnchorStyles.Bottom;

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Text = "새 포트:";
            this.label1.TabIndex = 0;

            // txtNewPort
            this.txtNewPort.Location = new System.Drawing.Point(76, 27);
            this.txtNewPort.Size = new System.Drawing.Size(100, 23);
            this.txtNewPort.MaxLength = 5;
            this.txtNewPort.TabIndex = 1;

            // btnAddPort
            this.btnAddPort.Location = new System.Drawing.Point(186, 26);
            this.btnAddPort.Size = new System.Drawing.Size(70, 25);
            this.btnAddPort.Text = "추가";
            this.btnAddPort.TabIndex = 2;
            this.btnAddPort.UseVisualStyleBackColor = true;
            this.btnAddPort.Click += new System.EventHandler(this.btnAddPort_Click);

            // dgvPorts
            this.dgvPorts.Location = new System.Drawing.Point(14, 62);
            this.dgvPorts.Size = new System.Drawing.Size(358, 294);
            this.dgvPorts.TabIndex = 3;
            this.dgvPorts.Anchor = System.Windows.Forms.AnchorStyles.Top
                                 | System.Windows.Forms.AnchorStyles.Left
                                 | System.Windows.Forms.AnchorStyles.Bottom;

            // btnRemovePort
            this.btnRemovePort.Location = new System.Drawing.Point(14, 368);
            this.btnRemovePort.Size = new System.Drawing.Size(80, 28);
            this.btnRemovePort.Text = "제거";
            this.btnRemovePort.TabIndex = 4;
            this.btnRemovePort.Enabled = false;
            this.btnRemovePort.UseVisualStyleBackColor = true;
            this.btnRemovePort.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                      | System.Windows.Forms.AnchorStyles.Left;
            this.btnRemovePort.Click += new System.EventHandler(this.btnRemovePort_Click);

            // btnStartAll
            this.btnStartAll.Location = new System.Drawing.Point(106, 368);
            this.btnStartAll.Size = new System.Drawing.Size(110, 28);
            this.btnStartAll.Text = "전체 시작";
            this.btnStartAll.TabIndex = 5;
            this.btnStartAll.BackColor = System.Drawing.Color.LightGreen;
            this.btnStartAll.UseVisualStyleBackColor = false;
            this.btnStartAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                    | System.Windows.Forms.AnchorStyles.Left;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);

            // btnStopAll
            this.btnStopAll.Location = new System.Drawing.Point(226, 368);
            this.btnStopAll.Size = new System.Drawing.Size(110, 28);
            this.btnStopAll.Text = "전체 중지";
            this.btnStopAll.TabIndex = 6;
            this.btnStopAll.BackColor = System.Drawing.Color.LightCoral;
            this.btnStopAll.UseVisualStyleBackColor = false;
            this.btnStopAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                   | System.Windows.Forms.AnchorStyles.Left;
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);

            // ── groupBox2 : 로컬 정보 ──────────────────────────────────────
            this.groupBox2.Controls.Add(this.lblLocalIP);
            this.groupBox2.Controls.Add(this.btnCopyIP);
            this.groupBox2.Location = new System.Drawing.Point(12, 428);
            this.groupBox2.Size = new System.Drawing.Size(386, 60);
            this.groupBox2.Text = "로컬 정보";
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                  | System.Windows.Forms.AnchorStyles.Left;

            // lblLocalIP
            this.lblLocalIP.AutoSize = true;
            this.lblLocalIP.Location = new System.Drawing.Point(14, 28);
            this.lblLocalIP.Text = "로컬 IP: -";
            this.lblLocalIP.TabIndex = 0;

            // btnCopyIP
            this.btnCopyIP.Location = new System.Drawing.Point(292, 24);
            this.btnCopyIP.Size = new System.Drawing.Size(80, 25);
            this.btnCopyIP.Text = "IP 복사";
            this.btnCopyIP.TabIndex = 1;
            this.btnCopyIP.UseVisualStyleBackColor = true;
            this.btnCopyIP.Click += new System.EventHandler(this.btnCopyIP_Click);

            // ── groupBox3 : 수신 로그 ──────────────────────────────────────
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Controls.Add(this.btnClearLog);
            this.groupBox3.Location = new System.Drawing.Point(410, 12);
            this.groupBox3.Size = new System.Drawing.Size(550, 476);
            this.groupBox3.Text = "수신 로그";
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top
                                  | System.Windows.Forms.AnchorStyles.Left
                                  | System.Windows.Forms.AnchorStyles.Bottom
                                  | System.Windows.Forms.AnchorStyles.Right;

            // txtLog
            this.txtLog.Location = new System.Drawing.Point(10, 22);
            this.txtLog.Size = new System.Drawing.Size(530, 418);
            this.txtLog.Multiline = true;
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.TabIndex = 0;
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            this.txtLog.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9f);
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Anchor = System.Windows.Forms.AnchorStyles.Top
                               | System.Windows.Forms.AnchorStyles.Left
                               | System.Windows.Forms.AnchorStyles.Bottom
                               | System.Windows.Forms.AnchorStyles.Right;

            // btnClearLog
            this.btnClearLog.Location = new System.Drawing.Point(450, 448);
            this.btnClearLog.Size = new System.Drawing.Size(90, 26);
            this.btnClearLog.Text = "로그 지우기";
            this.btnClearLog.TabIndex = 1;
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                    | System.Windows.Forms.AnchorStyles.Right;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);

            // ── statusStrip1 ───────────────────────────────────────────────
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsslPorts,
                this.tsslSep1,
                this.tsslActive,
                this.tsslSep2,
                this.tsslPackets
            });
            this.statusStrip1.TabIndex = 3;

            // tsslPorts
            this.tsslPorts.Text = "포트: 0개";
            this.tsslPorts.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;

            // tsslActive
            this.tsslActive.Text = "활성: 0개";
            this.tsslActive.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;

            // tsslPackets
            this.tsslPackets.Text = "전체 패킷: 0";
            this.tsslPackets.Spring = true;
            this.tsslPackets.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // ── ReceiverForm ───────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 520);
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.statusStrip1);
            this.Name = "ReceiverForm";
            this.Text = "UDP Receiver";
            this.Icon = new System.Drawing.Icon("app.ico");

            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPorts)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewPort;
        private System.Windows.Forms.Button btnAddPort;
        private System.Windows.Forms.DataGridView dgvPorts;
        private System.Windows.Forms.Button btnRemovePort;
        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLocalIP;
        private System.Windows.Forms.Button btnCopyIP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslPorts;
        private System.Windows.Forms.ToolStripSeparator tsslSep1;
        private System.Windows.Forms.ToolStripStatusLabel tsslActive;
        private System.Windows.Forms.ToolStripSeparator tsslSep2;
        private System.Windows.Forms.ToolStripStatusLabel tsslPackets;
    }
}
