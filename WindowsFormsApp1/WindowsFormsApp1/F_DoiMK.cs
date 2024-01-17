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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class F_DoiMK : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public static string mssv;
        public static string matkhau;

        [DllImportAttribute("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public F_DoiMK()
        {
            InitializeComponent();
        }
        private void F_Dangnhap_Load(object sender, EventArgs e)
        {
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
                this.WindowState = FormWindowState.Maximized;
                MiniMaxButton.Image = Properties.Resources.mini;
            }else
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(textBox3.Text))
            {
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@login",
                    value = F_Dangnhap.mssv,
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@matkhaucu",
                    value = textBox1.Text
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@matkhaumoi",
                    value = textBox2.Text
                });

                if (new Connection().ADDMIN("[dbo].[ProcDoiMK]", lstPara) == 1)
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    F_Dangnhap.mssv = string.Empty;
                    F_Dangnhap.matkhau = string.Empty;
                    this.Close();
                }
            }
            else 
            {
                MessageBox.Show("Xác nhận mật khẩu không dúng. Vui lòng kiểm tra lại");
            }         
        }
    }
}
