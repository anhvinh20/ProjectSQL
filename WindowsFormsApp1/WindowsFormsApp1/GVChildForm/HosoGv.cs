using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.GVChildForm
{
    public partial class HosoGv : Form
    {
        public HosoGv()
        {
            InitializeComponent();
        }

        #region
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
        private void HosoSv_Load(object sender, EventArgs e)
        {
            SelectGV();
            labelMSSV.Text = F_Dangnhap.mssv;
        }
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            DateTime ngaysinh;
            try
            {
                ngaysinh = DateTime.ParseExact(textBoxNgS.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Ngày sinh không hợp lệ");
                labelNgS.Select();
                return;
            }
            if (string.IsNullOrEmpty(comboBoxGT.Text) || string.IsNullOrEmpty(comboBoxQT.Text) || string.IsNullOrEmpty(comboBoxDT.Text) || string.IsNullOrEmpty(comboBoxNoiS.Text)
                || string.IsNullOrEmpty(textBoxSDT.Text) || string.IsNullOrEmpty(textBoxSTBH.Text) || string.IsNullOrEmpty(textBoxEmailTD.Text) ||
                string.IsNullOrEmpty(textBoxDiaChi.Text) || string.IsNullOrEmpty(comboBoxQues.Text) || string.IsNullOrEmpty(textBoxAns.Text))
            {
                MessageBox.Show("Thông tin không hợp lệ.");
                return;
            }
            else
            {
                List<CustomParameter> lstPara = new List<CustomParameter>();
                #region
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
                    key = "@ques",
                    value = comboBoxQues.Text
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@ans",
                    value = textBoxAns.Text
                });
                var rs = new Connection().Execute("[dbo].[ProcGiangVienUpdate]", lstPara);
                if (rs == 1)
                {
                    MessageBox.Show("Lưu thanh cong");
                    SelectGV();
                    SetVisiable(true, false);
                }
                else
                {
                    MessageBox.Show("Something error");
                }
            }
            #endregion         
        } 
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            SetVisiable(false, true);
            DataRow dr = new Connection().SelectRow("[dbo].[ProCSinhVienSelect]");
            textBoxNgS.Text = dr.ItemArray[0].ToString();
            comboBoxGT.Text = dr.ItemArray[1].ToString();
            comboBoxQT.Text = dr.ItemArray[2].ToString();
            comboBoxDT.Text = dr.ItemArray[3].ToString();
            comboBoxNoiS.Text = dr.ItemArray[4].ToString();
            textBoxSDT.Text = dr.ItemArray[5].ToString();
            textBoxSTBH.Text = dr.ItemArray[6].ToString();
            textBoxEmailTD.Text = dr.ItemArray[7].ToString();
            textBoxDiaChi.Text = dr.ItemArray[8].ToString();
            labelName.Text = dr.ItemArray[9].ToString() + " " + dr.ItemArray[10].ToString() + " " + dr.ItemArray[11].ToString();

            if (dr != null)
            {

            }
            else
            {
                MessageBox.Show("Something error");
            }
        }
        private void SelectGV()
        {
            DataRow dr = new Connection().SelectRow("[dbo].[ProCGiangVienSelect]");
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
        #endregion

    }
}
