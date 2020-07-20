namespace Demo
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.statusConnected = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabStatuChangeReport = new System.Windows.Forms.TabPage();
            this.tabAlarmReport = new System.Windows.Forms.TabPage();
            this.txtCosoleLog = new System.Windows.Forms.TextBox();
            this.mainStatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainStatusStrip
            // 
            this.mainStatusStrip.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusConnected});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 389);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(608, 25);
            this.mainStatusStrip.TabIndex = 0;
            this.mainStatusStrip.Text = "mainStatusStrip";
            // 
            // statusConnected
            // 
            this.statusConnected.BackColor = System.Drawing.Color.Red;
            this.statusConnected.ForeColor = System.Drawing.Color.White;
            this.statusConnected.Name = "statusConnected";
            this.statusConnected.Size = new System.Drawing.Size(151, 20);
            this.statusConnected.Text = "Server not Connected";
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(507, 9);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(88, 26);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPAddress.Location = new System.Drawing.Point(92, 13);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(72, 22);
            this.txtIPAddress.TabIndex = 2;
            this.txtIPAddress.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(173, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.Location = new System.Drawing.Point(214, 13);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(49, 22);
            this.txtPort.TabIndex = 4;
            this.txtPort.Text = "8001";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtIPAddress);
            this.panel1.Controls.Add(this.btnConnect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPort);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 45);
            this.panel1.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabStatuChangeReport);
            this.tabControl1.Controls.Add(this.tabAlarmReport);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(608, 207);
            this.tabControl1.TabIndex = 7;
            // 
            // tabStatuChangeReport
            // 
            this.tabStatuChangeReport.Location = new System.Drawing.Point(4, 22);
            this.tabStatuChangeReport.Name = "tabStatuChangeReport";
            this.tabStatuChangeReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatuChangeReport.Size = new System.Drawing.Size(600, 181);
            this.tabStatuChangeReport.TabIndex = 0;
            this.tabStatuChangeReport.Text = "Status Change Report";
            this.tabStatuChangeReport.UseVisualStyleBackColor = true;
            // 
            // tabAlarmReport
            // 
            this.tabAlarmReport.Location = new System.Drawing.Point(4, 22);
            this.tabAlarmReport.Name = "tabAlarmReport";
            this.tabAlarmReport.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlarmReport.Size = new System.Drawing.Size(600, 181);
            this.tabAlarmReport.TabIndex = 1;
            this.tabAlarmReport.Text = "Alarm Report";
            this.tabAlarmReport.UseVisualStyleBackColor = true;
            // 
            // txtCosoleLog
            // 
            this.txtCosoleLog.BackColor = System.Drawing.Color.Black;
            this.txtCosoleLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCosoleLog.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCosoleLog.ForeColor = System.Drawing.Color.Lime;
            this.txtCosoleLog.Location = new System.Drawing.Point(0, 252);
            this.txtCosoleLog.Multiline = true;
            this.txtCosoleLog.Name = "txtCosoleLog";
            this.txtCosoleLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCosoleLog.Size = new System.Drawing.Size(608, 137);
            this.txtCosoleLog.TabIndex = 8;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 414);
            this.Controls.Add(this.txtCosoleLog);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainStatusStrip);
            this.Name = "Main";
            this.ShowIcon = false;
            this.Text = "Main";
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusConnected;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStatuChangeReport;
        private System.Windows.Forms.TabPage tabAlarmReport;
        private System.Windows.Forms.TextBox txtCosoleLog;
    }
}

