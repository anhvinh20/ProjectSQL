namespace WindowsFormsApp1.ChildForm
{
    partial class DichvuAD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DichvuGV));
            this.ClickChuotPhai = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mởCửaSổMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.HSSVPanel = new System.Windows.Forms.Panel();
            this.buttonLopPT = new System.Windows.Forms.Button();
            this.buttonHSGV1 = new System.Windows.Forms.Button();
            this.buttonHSGV = new System.Windows.Forms.Button();
            this.panelDKHT = new System.Windows.Forms.Panel();
            this.buttonTKB2 = new System.Windows.Forms.Button();
            this.buttonLGD = new System.Windows.Forms.Button();
            this.buttonTKB = new System.Windows.Forms.Button();
            this.buttonND = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.ClickChuotPhai.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.HSSVPanel.SuspendLayout();
            this.panelDKHT.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClickChuotPhai
            // 
            this.ClickChuotPhai.BackColor = System.Drawing.SystemColors.Control;
            this.ClickChuotPhai.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ClickChuotPhai.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mởCửaSổMớiToolStripMenuItem});
            this.ClickChuotPhai.Name = "ClickChuotPhai";
            this.ClickChuotPhai.Size = new System.Drawing.Size(178, 28);
            // 
            // mởCửaSổMớiToolStripMenuItem
            // 
            this.mởCửaSổMớiToolStripMenuItem.Name = "mởCửaSổMớiToolStripMenuItem";
            this.mởCửaSổMớiToolStripMenuItem.Size = new System.Drawing.Size(177, 24);
            this.mởCửaSổMớiToolStripMenuItem.Text = "Mở cửa sổ mới";
            this.mởCửaSổMớiToolStripMenuItem.Click += new System.EventHandler(this.mởCửaSổMớiToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 15;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 15;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(20, 1000);
            this.panel5.TabIndex = 8;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.HSSVPanel);
            this.flowLayoutPanel1.Controls.Add(this.panelDKHT);
            this.flowLayoutPanel1.Controls.Add(this.buttonND);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(20, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(266, 1000);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(263, 20);
            this.panel6.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(266, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 586);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // HSSVPanel
            // 
            this.HSSVPanel.Controls.Add(this.buttonLopPT);
            this.HSSVPanel.Controls.Add(this.buttonHSGV1);
            this.HSSVPanel.Controls.Add(this.buttonHSGV);
            this.HSSVPanel.Location = new System.Drawing.Point(3, 29);
            this.HSSVPanel.MaximumSize = new System.Drawing.Size(260, 188);
            this.HSSVPanel.MinimumSize = new System.Drawing.Size(260, 75);
            this.HSSVPanel.Name = "HSSVPanel";
            this.HSSVPanel.Size = new System.Drawing.Size(260, 77);
            this.HSSVPanel.TabIndex = 16;
            // 
            // buttonLopPT
            // 
            this.buttonLopPT.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonLopPT.ContextMenuStrip = this.ClickChuotPhai;
            this.buttonLopPT.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLopPT.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonLopPT.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonLopPT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.buttonLopPT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLopPT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonLopPT.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLopPT.Location = new System.Drawing.Point(0, 131);
            this.buttonLopPT.Name = "buttonLopPT";
            this.buttonLopPT.Size = new System.Drawing.Size(260, 56);
            this.buttonLopPT.TabIndex = 16;
            this.buttonLopPT.Text = "Thông tin lớp giảng viên phụ trách";
            this.buttonLopPT.UseVisualStyleBackColor = false;
            this.buttonLopPT.Click += new System.EventHandler(this.buttonLopPT_Click);
            // 
            // buttonHSGV1
            // 
            this.buttonHSGV1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonHSGV1.ContextMenuStrip = this.ClickChuotPhai;
            this.buttonHSGV1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHSGV1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonHSGV1.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonHSGV1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.buttonHSGV1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHSGV1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonHSGV1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonHSGV1.Location = new System.Drawing.Point(0, 75);
            this.buttonHSGV1.Name = "buttonHSGV1";
            this.buttonHSGV1.Size = new System.Drawing.Size(260, 56);
            this.buttonHSGV1.TabIndex = 15;
            this.buttonHSGV1.Text = "Hồ sơ giảng viên";
            this.buttonHSGV1.UseVisualStyleBackColor = false;
            this.buttonHSGV1.Click += new System.EventHandler(this.HSSVbutton1_Click);
            // 
            // buttonHSGV
            // 
            this.buttonHSGV.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonHSGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonHSGV.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonHSGV.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonHSGV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.buttonHSGV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHSGV.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonHSGV.ForeColor = System.Drawing.Color.Black;
            this.buttonHSGV.Image = global::WindowsFormsApp1.Properties.Resources.ExpandArrow;
            this.buttonHSGV.Location = new System.Drawing.Point(0, 0);
            this.buttonHSGV.Name = "buttonHSGV";
            this.buttonHSGV.Size = new System.Drawing.Size(260, 75);
            this.buttonHSGV.TabIndex = 2;
            this.buttonHSGV.Text = "Hồ sơ giảng viên";
            this.buttonHSGV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonHSGV.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonHSGV.UseCompatibleTextRendering = true;
            this.buttonHSGV.UseVisualStyleBackColor = false;
            this.buttonHSGV.Click += new System.EventHandler(this.HSSVButton_Click);
            // 
            // panelDKHT
            // 
            this.panelDKHT.Controls.Add(this.buttonTKB2);
            this.panelDKHT.Controls.Add(this.buttonLGD);
            this.panelDKHT.Controls.Add(this.buttonTKB);
            this.panelDKHT.Location = new System.Drawing.Point(3, 112);
            this.panelDKHT.MaximumSize = new System.Drawing.Size(260, 188);
            this.panelDKHT.MinimumSize = new System.Drawing.Size(260, 75);
            this.panelDKHT.Name = "panelDKHT";
            this.panelDKHT.Size = new System.Drawing.Size(260, 75);
            this.panelDKHT.TabIndex = 19;
            // 
            // buttonTKB2
            // 
            this.buttonTKB2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonTKB2.ContextMenuStrip = this.ClickChuotPhai;
            this.buttonTKB2.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTKB2.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonTKB2.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonTKB2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.buttonTKB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTKB2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonTKB2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonTKB2.Location = new System.Drawing.Point(0, 131);
            this.buttonTKB2.Name = "buttonTKB2";
            this.buttonTKB2.Size = new System.Drawing.Size(260, 56);
            this.buttonTKB2.TabIndex = 16;
            this.buttonTKB2.Text = "Tra cứu thông tin lớp";
            this.buttonTKB2.UseVisualStyleBackColor = false;
            this.buttonTKB2.Click += new System.EventHandler(this.buttonTKB2_Click);
            // 
            // buttonLGD
            // 
            this.buttonLGD.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonLGD.ContextMenuStrip = this.ClickChuotPhai;
            this.buttonLGD.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonLGD.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonLGD.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonLGD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.buttonLGD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLGD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonLGD.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonLGD.Location = new System.Drawing.Point(0, 75);
            this.buttonLGD.Name = "buttonLGD";
            this.buttonLGD.Size = new System.Drawing.Size(260, 56);
            this.buttonLGD.TabIndex = 15;
            this.buttonLGD.Text = "Lịch giảng dạy";
            this.buttonLGD.UseVisualStyleBackColor = false;
            // 
            // buttonTKB
            // 
            this.buttonTKB.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonTKB.ContextMenuStrip = this.ClickChuotPhai;
            this.buttonTKB.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonTKB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonTKB.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.buttonTKB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.buttonTKB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTKB.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonTKB.ForeColor = System.Drawing.Color.Black;
            this.buttonTKB.Image = global::WindowsFormsApp1.Properties.Resources.ExpandArrow;
            this.buttonTKB.Location = new System.Drawing.Point(0, 0);
            this.buttonTKB.Name = "buttonTKB";
            this.buttonTKB.Size = new System.Drawing.Size(260, 75);
            this.buttonTKB.TabIndex = 2;
            this.buttonTKB.Text = "Thời khóa biểu";
            this.buttonTKB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonTKB.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.buttonTKB.UseCompatibleTextRendering = true;
            this.buttonTKB.UseVisualStyleBackColor = false;
            this.buttonTKB.Click += new System.EventHandler(this.buttonTKB_Click_1);
            // 
            // buttonND
            // 
            this.buttonND.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonND.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonND.ContextMenuStrip = this.ClickChuotPhai;
            this.buttonND.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonND.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonND.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.buttonND.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonND.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.buttonND.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonND.Location = new System.Drawing.Point(3, 193);
            this.buttonND.Name = "buttonND";
            this.buttonND.Size = new System.Drawing.Size(260, 75);
            this.buttonND.TabIndex = 12;
            this.buttonND.Text = "Nhập điểm";
            this.buttonND.UseVisualStyleBackColor = false;
            this.buttonND.Click += new System.EventHandler(this.buttonND_Click);
            // 
            // panelContent
            // 
            this.panelContent.AutoSize = true;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(286, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1656, 1000);
            this.panelContent.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panelContent);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1942, 1000);
            this.panel2.TabIndex = 8;
            // 
            // DichvuGV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1942, 1000);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DichvuGV";
            this.Text = "Trang chủ";
            this.ClickChuotPhai.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.HSSVPanel.ResumeLayout(false);
            this.panelDKHT.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip ClickChuotPhai;
        private System.Windows.Forms.ToolStripMenuItem mởCửaSổMớiToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel HSSVPanel;
        private System.Windows.Forms.Button buttonLopPT;
        private System.Windows.Forms.Button buttonHSGV1;
        private System.Windows.Forms.Button buttonHSGV;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonND;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Panel panelDKHT;
        private System.Windows.Forms.Button buttonTKB2;
        private System.Windows.Forms.Button buttonLGD;
        private System.Windows.Forms.Button buttonTKB;
    }
}