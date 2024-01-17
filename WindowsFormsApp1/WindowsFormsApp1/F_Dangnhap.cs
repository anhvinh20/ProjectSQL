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
    public partial class F_Dangnhap : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public static string mssv;
        public static string matkhau;

        [DllImportAttribute("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public F_Dangnhap()
        {
            InitializeComponent();
        }
        private void F_Dangnhap_Load(object sender, EventArgs e)
        {
            ExitButton.Image = Properties.Resources.exit;
            ResButton.Image = Properties.Resources.res;
            MiniMaxButton.Image = Properties.Resources.maxi;
            panelDangnhapTK.Visible = true;
            panelDangnhapMK.Visible = false;
            panelQuenMK.Visible = false;
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

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text.Trim().EndsWith("@sis.huil.edu.vn"))
            {
                panelDangnhapTK.Visible = false;
                panelDangnhapMK.Visible = true;
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@email",
                    value = textBoxEmail.Text
                });
                DataRow dr = new Connection().SelectRow("dbo.ProcLayMSSV", lstPara);
                mssv = dr.ItemArray[0].ToString();
                if (mssv.StartsWith("GV"))
                {
                    
                }
                else
                {
                    mssv = "20"+dr.ItemArray[0].ToString();
                }
                labelEmail.Text = textBoxEmail.Text;
                matkhau = textBoxMK.Text;
            }    
            else
            {
                labelErrorTK.Text = "Tài khoản phải theo cú pháp user@sis.huil.edu.vn.";
            }    
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            matkhau = textBoxMK.Text;

            if (new Connection().CheckConnection())
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelDangnhapTK.Visible = true;
            panelDangnhapMK.Visible = false;
            labelErrorMK.Text = string.Empty;
            textBoxEmail.Select();
        }

        private void linkLabelQuenMK2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelDangnhapTK.Visible = false;
            panelDangnhapMK.Visible = false;
            panelQuenMK.Visible = true;
        }

        private void linkLabelQuenMK1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelQuenMK.Visible = true;
            panelDangnhapTK.Visible = false;
            panelDangnhapMK.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@mssv",
                value = textBox1.Text,
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@input1",
                value = comboBox1.Text
            }) ;
            lstPara.Add(new CustomParameter()
            {
                key = "@input2",
                value = textBoxAns.Text
            });
            DataRow dr = new Connection().SelectRow("dbo.ProcCheckQuenMK", lstPara);
            if (! dr.ItemArray[0].Equals("0"))
            {
                MessageBox.Show("Mật khẩu mới của bạn là:"+ dr.ItemArray[0].ToString(), "", MessageBoxButtons.OK);
            }    
            else
            {
                MessageBox.Show("Thông tin không chính xác. Vui lòng kiểm tra lại.", "", MessageBoxButtons.OK);
            }    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelQuenMK.Visible = false;
            panelDangnhapTK.Visible = true;
            panelDangnhapMK.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBoxMK.UseSystemPasswordChar)
            {
                button5.Image = Properties.Resources._5493985;
                textBoxMK.UseSystemPasswordChar = false;
            }
            else
            {
                button5.Image = Properties.Resources._7048539;
                textBoxMK.UseSystemPasswordChar = true;
            }
            
        }
    }
}
