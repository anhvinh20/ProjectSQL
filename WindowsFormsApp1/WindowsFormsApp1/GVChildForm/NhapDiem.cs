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

namespace WindowsFormsApp1.GVChildForm
{
    public partial class NhapDiem : Form
    {
        public NhapDiem()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@malopbt",
                value = comboBox2.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@kyhoc",
                value = comboBox1.Text
            });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new Connection().SelectData("[dbo].[ProcNhapDiem]", lstPara);
        }

        private DataTable ToDataTable(DataGridView dataGridView)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns)
            {
                if (dataGridViewColumn.Visible)
                {
                    dt.Columns.Add();
                }
            }
            var cell = new object[dataGridView.Columns.Count];
            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows)
            {
                for (int i = 0; i < dataGridViewRow.Cells.Count; i++)
                {
                    cell[i] = dataGridViewRow.Cells[i].Value;
                }
                dt.Rows.Add(cell);
            }
            return dt;
        }
        private void button3_Click_1(object sender, EventArgs e)      
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@malopbt",
                value = comboBox2.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@kyhoc",
                value = comboBox1.Text
            });
            DataTable dt = ToDataTable(dataGridView1);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lstPara.Add(new CustomParameter()
                {
                    key = "@mssv",
                    value = dt.Rows[i].ItemArray[0].ToString()
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@diemqt",
                    value = dt.Rows[i].ItemArray[5].ToString()
                });
                lstPara.Add(new CustomParameter()
                {
                    key = "@diemthi",
                    value = dt.Rows[i].ItemArray[6].ToString()
                });
                var rs = new Connection().ExecuteS("[dbo].[ProcNhapDiem]", lstPara);
                if (rs == 1)
                {
                    MessageBox.Show("Upadate thành công");
                }
                else { MessageBox.Show("Lỗi"); }
            }
            LoadData();
    }

        private void NhapDiem_Load(object sender, EventArgs e)
        {
            DataTable dt = new Connection().SelectData("[dbo].[ProCKyGD]");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            if (string.IsNullOrEmpty(comboBox1.Text))
            {

            }
            else
            {
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@kyhoc",
                    value = comboBox1.Text
                });
                DataTable dt = new Connection().SelectData("[dbo].[ProCDSMaLopGD]", lstPara);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox2.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text))
            {

            }
            else
            {
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {      
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                List<CustomParameter> lstPara = new List<CustomParameter>();
                lstPara.Add(new CustomParameter()
                {
                    key = "@mssv",
                    value = dataGridView1.Rows[i].Cells["MSSV"].ToString()
                });
                var rs = new Connection().Execute("ProcUpdateDiemHP", lstPara); 
            }
            
        }
    }
}
