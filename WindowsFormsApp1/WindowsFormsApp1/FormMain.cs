using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.ChildForm;

namespace WindowsFormsApp1
{
    public partial class FormMain : Form
    {
        #region
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion
        public FormMain()
        {
            InitializeComponent();
        }

        #region
        private void F_Trangchu_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(F_Dangnhap.mssv) && string.IsNullOrEmpty(F_Dangnhap.matkhau))
            {
                ToolStripMenuItemDichVu.Visible = false;
                panel6.Visible = false;
            }
            ExitButton.Image = Properties.Resources.exit;
            ResButton.Image = Properties.Resources.res;
            MiniMaxButton.Image = Properties.Resources.maxi;
        }
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MiniMaxButton_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
                MiniMaxButton.Image = Properties.Resources.mini;
                panel5.Size = new Size(575, 50);
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                MiniMaxButton.Image = Properties.Resources.maxi;
            }    
        }

        private void ResButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private void AddForm(Form f)
        {
            this.panelContent.Controls.Clear();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.panelContent.Controls.Add(f);
            f.Show();    
        }

        #region
        private void DangNhapButton_Click(object sender, EventArgs e)
        {
            F_Dangnhap f = new F_Dangnhap();
            f.ShowDialog();
            if (string.IsNullOrEmpty(F_Dangnhap.mssv) && string.IsNullOrEmpty(F_Dangnhap.matkhau))
            {
                ToolStripMenuItemDichVu.Visible = false;
                panel6.Visible = false;
            }
            else
            {
                ToolStripMenuItemDichVu.Visible = true;
                panel6.Visible= true;
            }    
            this.Show();
        }
        private void trangChủToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Trangchu();
            AddForm(f);
        }
        private void Nhap_hoc_ToolStrip_Click(object sender, EventArgs e)
        {
            var f = new Nhaphoc();
            AddForm(f);
        }
        private void ToolStripMenuItemDichVu_Click(object sender, EventArgs e)
        {
            if(F_Dangnhap.mssv.StartsWith("GV"))
            {
                var f = new DichvuGV();
                AddForm(f);
            }else if (F_Dangnhap.mssv.StartsWith("AD"))
            {
                var f = new DichvuAD();
                AddForm(f);
            }else
            {
                var f = new DichvuSV();
                AddForm(f);
            }    

        }
        private void liênHệToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new Lienhe();
            AddForm(f);
        }
        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_DoiMK f = new F_DoiMK();
            f.ShowDialog();
            if (string.IsNullOrEmpty(F_Dangnhap.mssv) && string.IsNullOrEmpty(F_Dangnhap.matkhau))
            {
                ToolStripMenuItemDichVu.Visible = false;
                panel6.Visible = false;
            }
            else
            {
                ToolStripMenuItemDichVu.Visible = true;
                panel6.Visible = true;
            }
            this.Show();

            }

        private void thoátĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Dangnhap.mssv = string.Empty;
            F_Dangnhap.matkhau = string.Empty;
            this.Hide();
            FormMain f = new FormMain();
            f.ShowDialog();
            this.Close();
        }

        #endregion

        private void panel6_VisibleChanged(object sender, EventArgs e)
        {
            if(this.panel6.Visible)
            {
                string sql;
                if (F_Dangnhap.mssv.StartsWith("GV"))
                {
                    sql = "[dbo].[ProCGiangVienSelect]";
                }
                else 
                {
                    sql = "[dbo].[ProCSinhVienSelect]";
                }
                DataRow dr = new Connection().SelectRow(sql);
                labelName.Text = dr.ItemArray[9].ToString() + " " + dr.ItemArray[10].ToString() + " " + dr.ItemArray[11].ToString();
                labelMssv.Text = F_Dangnhap.mssv;
            }
        }
        
        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }
    }
}
