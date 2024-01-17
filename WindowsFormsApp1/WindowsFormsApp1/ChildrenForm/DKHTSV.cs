using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.ChildrenForm
{
    public partial class DKHTSV : Form
    {
        public DKHTSV()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@kyhoc",
                value = label4.Text
            });

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new Connection().SelectData("[dbo].[ProcDKHT_Se]", lstPara);
        }

        private void LoadData2()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@kyhoc",
                value = label4.Text
            });

            dataGridView2.DataSource = null;
            dataGridView2.DataSource = new Connection().SelectData("[dbo].[ProcDKHT_SeTKB]", lstPara);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@kyhoc",
                value = label4.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@malopbt",
                value = textBox1.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@sql",
                value = "insert"
            });
            var rs = new Connection().Execute("[dbo].[ProcDKHT_InDe]", lstPara);
            if(rs == 3)
            {
                MessageBox.Show("Thêm thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Lớp đã đầy hoặc bạn đã đăng ký lớp");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@kyhoc",
                value = label4.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@malopbt",
                value = textBox1.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@sql",
                value = "delete"
            });
            var rs = new Connection().Execute("[dbo].[ProcDKHT_InDe]", lstPara);
            if (rs == 2)
            {
                MessageBox.Show("Xóa thành công");
                LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void DKHTSV_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadData2();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData2();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["MaLopBT"].Value.ToString();
        }
    }
}
