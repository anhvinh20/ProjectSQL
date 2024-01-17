using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.ChildForm
{
    public partial class HosoSvDemo : Form
    {

        private bool isCollapsed;
        public HosoSvDemo()
        {
            InitializeComponent();
        }
 
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                HSSVButton.Image = Resources.CollapseArrow;
                HSSVPanel.Height += 10;
                if (HSSVPanel.Size == HSSVPanel.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                HSSVButton.Image = Resources.ExpandArrow;
                HSSVPanel.Height -= 10;
                if (HSSVPanel.Size == HSSVPanel.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }
        private void HSSVButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                KQHTButton.Image = Resources.CollapseArrow;
                KQHTPanel.Height += 10;
                if (KQHTPanel.Size == KQHTPanel.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                KQHTButton.Image = Resources.ExpandArrow;
                KQHTPanel.Height -= 10;
                if (KQHTPanel.Size == KQHTPanel.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed = true;
                }
            }
        }
        private void KQHTButton_Click(object sender, EventArgs e)
        {
              timer2.Start();
        }    
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                CTDTButton.Image = Resources.CollapseArrow;
                CTDTPanel.Height += 10;
                if (CTDTPanel.Size == CTDTPanel.MaximumSize)
                {
                    timer3.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                CTDTButton.Image = Resources.ExpandArrow;
                CTDTPanel.Height -= 10;
                if (CTDTPanel.Size == CTDTPanel.MinimumSize)
                {
                    timer3.Stop();
                    isCollapsed = true;
                }
            }
        }  
        private void CTDTButton_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime ngaysinh;
            try
            {
                ngaysinh = DateTime.ParseExact(textBoxNgS.Text,"dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                labelNgS.Select();
                return;
            }
            List<CustomParameter> lstPara = new List<CustomParameter>();
            #region
            lstPara.Add(new CustomParameter()
            {
                key = "@mssv",
                value = F_Dangnhap.mssv
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@ngaysinh",
                value = ngaysinh.ToString("yyyy-MM-dd")
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@gioitinh",
                value = comboBoxGT.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@quoctich",
                value = comboBoxQT.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@dantoc",
                value = comboBoxDT.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@noisinh",
                value = comboBoxNoiS.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@sdt",
                value = textBoxSDT.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@stbh",
                value = textBoxSTBH.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@emailtd",
                value = textBoxEmailTD.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@diachi",
                value = textBoxDiaChi.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@noiodk",
                value = comboBoxNoiO.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@sothich",
                value = comboBoxST.Text
            });
            #endregion
            var rs = new Connection().Execute("[svien].[ProSinhVienUpdate]",lstPara);
            if (rs == 1)
            {
                MessageBox.Show("Lưu thanh cong");
                SelectSV();
                SetVisiable(true, false);
            }
            else
            {
                MessageBox.Show("Something error");
            }
        }
        private void SetVisiable(bool s, bool u)
        {
            panelSelectLeft.Enabled = s;
            panelSelectLeft.Visible = s;
            panelSelectRight.Enabled = s;
            panelSelectRight.Visible = s;
            labelDC.Enabled = s;
            labelDC.Visible = s;
            buttonUpdate.Visible = s;

            panelUpdateLeft.Visible = u;
            panelUpdateRight.Visible = u;
            textBoxDiaChi.Visible = u;
            panelTTthem.Visible = u;
            buttonLuu.Visible = u;
        }
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            SetVisiable(false, true);
        }

        private void SelectSV()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            #region
            lstPara.Add(new CustomParameter()
            {
                key = "@mssv",
                value = F_Dangnhap.mssv
            });
            #endregion
            DataRow dr = new Connection().SelectRow("[svien].[ProSinhVienSelect]", lstPara);
            labelNgS.Text = dr.ItemArray[0].ToString();
            labelGT.Text = dr.ItemArray[1].ToString();
            labelQT.Text = dr.ItemArray[2].ToString();
            labelDT.Text = dr.ItemArray[3].ToString();
            labelNoiS.Text = dr.ItemArray[4].ToString();
            labelSdt.Text = dr.ItemArray[5].ToString();
            labelSTBH.Text = dr.ItemArray[6].ToString();
            labelEmail.Text = dr.ItemArray[7].ToString();
            labelDC.Text = dr.ItemArray[8].ToString();
            labelName.Text = dr.ItemArray[9].ToString() + " " + dr.ItemArray[10].ToString() + " " + dr.ItemArray[11].ToString();

            if (dr != null)
            {

            }
            else
            {
                MessageBox.Show("Something error");
            }
        }
    }
}
