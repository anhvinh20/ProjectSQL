namespace WindowsFormsApp1
{
    partial class FormMain
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
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TrangChuLabel = new System.Windows.Forms.Label();
            this.ResButton = new System.Windows.Forms.Button();
            this.MiniMaxButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelMenuStrip = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.trangChủToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemDichVu = new System.Windows.Forms.ToolStripMenuItem();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátĐăngNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelMssv = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.DangNhapButton = new System.Windows.Forms.Button();
            this.LogopictureBox = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelMenuStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 40);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(8, 960);
            this.panelLeft.TabIndex = 1;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(8, 992);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1384, 8);
            this.panelBottom.TabIndex = 1;
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1392, 40);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(8, 960);
            this.panelRight.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.AccessibleName = "";
            this.panelTop.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelTop.Controls.Add(this.pictureBox1);
            this.panelTop.Controls.Add(this.TrangChuLabel);
            this.panelTop.Controls.Add(this.ResButton);
            this.panelTop.Controls.Add(this.MiniMaxButton);
            this.panelTop.Controls.Add(this.ExitButton);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1400, 40);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(23, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // TrangChuLabel
            // 
            this.TrangChuLabel.AutoSize = true;
            this.TrangChuLabel.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrangChuLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.TrangChuLabel.Location = new System.Drawing.Point(84, 6);
            this.TrangChuLabel.Name = "TrangChuLabel";
            this.TrangChuLabel.Size = new System.Drawing.Size(102, 28);
            this.TrangChuLabel.TabIndex = 6;
            this.TrangChuLabel.Text = "Trang chủ";
            // 
            // ResButton
            // 
            this.ResButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ResButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ResButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ResButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ResButton.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.ResButton.FlatAppearance.BorderSize = 0;
            this.ResButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ResButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite;
            this.ResButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ResButton.Location = new System.Drawing.Point(1228, 0);
            this.ResButton.Name = "ResButton";
            this.ResButton.Size = new System.Drawing.Size(56, 40);
            this.ResButton.TabIndex = 5;
            this.ResButton.UseVisualStyleBackColor = false;
            this.ResButton.Click += new System.EventHandler(this.ResButton_Click);
            // 
            // MiniMaxButton
            // 
            this.MiniMaxButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MiniMaxButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MiniMaxButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MiniMaxButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MiniMaxButton.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.MiniMaxButton.FlatAppearance.BorderSize = 0;
            this.MiniMaxButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MiniMaxButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite;
            this.MiniMaxButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MiniMaxButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.MiniMaxButton.Location = new System.Drawing.Point(1284, 0);
            this.MiniMaxButton.Name = "MiniMaxButton";
            this.MiniMaxButton.Size = new System.Drawing.Size(56, 40);
            this.MiniMaxButton.TabIndex = 4;
            this.MiniMaxButton.UseVisualStyleBackColor = false;
            this.MiniMaxButton.Click += new System.EventHandler(this.MiniMaxButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.GhostWhite;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ExitButton.Location = new System.Drawing.Point(1340, 0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(60, 40);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panelContent);
            this.panel1.Controls.Add(this.panelMenuStrip);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1384, 952);
            this.panel1.TabIndex = 2;
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContent.Location = new System.Drawing.Point(0, 207);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1363, 2000);
            this.panelContent.TabIndex = 10;
            // 
            // panelMenuStrip
            // 
            this.panelMenuStrip.Controls.Add(this.menuStrip1);
            this.panelMenuStrip.Controls.Add(this.panel5);
            this.panelMenuStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenuStrip.Location = new System.Drawing.Point(0, 157);
            this.panelMenuStrip.Name = "panelMenuStrip";
            this.panelMenuStrip.Size = new System.Drawing.Size(1363, 50);
            this.panelMenuStrip.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Navy;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trangChủToolStripMenuItem,
            this.ToolStripMenuItemDichVu});
            this.menuStrip1.Location = new System.Drawing.Point(585, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(778, 50);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // trangChủToolStripMenuItem
            // 
            this.trangChủToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trangChủToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.trangChủToolStripMenuItem.Name = "trangChủToolStripMenuItem";
            this.trangChủToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trangChủToolStripMenuItem.Size = new System.Drawing.Size(128, 46);
            this.trangChủToolStripMenuItem.Text = "Trang chủ";
            this.trangChủToolStripMenuItem.Click += new System.EventHandler(this.trangChủToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemDichVu
            // 
            this.ToolStripMenuItemDichVu.ForeColor = System.Drawing.Color.White;
            this.ToolStripMenuItemDichVu.Name = "ToolStripMenuItemDichVu";
            this.ToolStripMenuItemDichVu.Size = new System.Drawing.Size(104, 46);
            this.ToolStripMenuItemDichVu.Text = "Dịch vụ";
            this.ToolStripMenuItemDichVu.Click += new System.EventHandler(this.ToolStripMenuItemDichVu_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Navy;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(585, 50);
            this.panel5.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.DangNhapButton);
            this.panel2.Controls.Add(this.LogopictureBox);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1363, 157);
            this.panel2.TabIndex = 8;
            // 
            // panel6
            // 
            this.panel6.ContextMenuStrip = this.contextMenuStrip1;
            this.panel6.Controls.Add(this.labelMssv);
            this.panel6.Controls.Add(this.labelName);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(1047, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(316, 157);
            this.panel6.TabIndex = 0;
            this.panel6.VisibleChanged += new System.EventHandler(this.panel6_VisibleChanged);
            this.panel6.MouseEnter += new System.EventHandler(this.panel6_MouseEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đổiMậtKhẩuToolStripMenuItem,
            this.thoátĐăngNhậpToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(218, 64);
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(217, 30);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // thoátĐăngNhậpToolStripMenuItem
            // 
            this.thoátĐăngNhậpToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thoátĐăngNhậpToolStripMenuItem.Name = "thoátĐăngNhậpToolStripMenuItem";
            this.thoátĐăngNhậpToolStripMenuItem.Size = new System.Drawing.Size(217, 30);
            this.thoátĐăngNhậpToolStripMenuItem.Text = "Thoát đăng nhập";
            this.thoátĐăngNhậpToolStripMenuItem.Click += new System.EventHandler(this.thoátĐăngNhậpToolStripMenuItem_Click);
            // 
            // labelMssv
            // 
            this.labelMssv.AutoSize = true;
            this.labelMssv.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMssv.Location = new System.Drawing.Point(24, 107);
            this.labelMssv.Name = "labelMssv";
            this.labelMssv.Size = new System.Drawing.Size(0, 28);
            this.labelMssv.TabIndex = 2;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(24, 66);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 28);
            this.labelName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(21, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Xin chào,";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(182, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(874, 126);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(866, 54);
            this.label1.TabIndex = 6;
            this.label1.Text = "Husky University of Internationnal Language";
            // 
            // DangNhapButton
            // 
            this.DangNhapButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DangNhapButton.BackColor = System.Drawing.Color.Navy;
            this.DangNhapButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DangNhapButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.DangNhapButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SteelBlue;
            this.DangNhapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DangNhapButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DangNhapButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DangNhapButton.Location = new System.Drawing.Point(1062, 32);
            this.DangNhapButton.Name = "DangNhapButton";
            this.DangNhapButton.Size = new System.Drawing.Size(222, 31);
            this.DangNhapButton.TabIndex = 4;
            this.DangNhapButton.Text = "Đăng nhập";
            this.DangNhapButton.UseVisualStyleBackColor = false;
            this.DangNhapButton.Click += new System.EventHandler(this.DangNhapButton_Click);
            // 
            // LogopictureBox
            // 
            this.LogopictureBox.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Logo;
            this.LogopictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LogopictureBox.Location = new System.Drawing.Point(21, 0);
            this.LogopictureBox.Name = "LogopictureBox";
            this.LogopictureBox.Size = new System.Drawing.Size(155, 155);
            this.LogopictureBox.TabIndex = 6;
            this.LogopictureBox.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 1000);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trang chủ";
            this.Load += new System.EventHandler(this.F_Trangchu_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panelMenuStrip.ResumeLayout(false);
            this.panelMenuStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogopictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ResButton;
        private System.Windows.Forms.Button MiniMaxButton;
        private System.Windows.Forms.Label TrangChuLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox LogopictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panelMenuStrip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem trangChủToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemDichVu;
        public System.Windows.Forms.Button DangNhapButton;
        public System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label labelMssv;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátĐăngNhậpToolStripMenuItem;
    }
}