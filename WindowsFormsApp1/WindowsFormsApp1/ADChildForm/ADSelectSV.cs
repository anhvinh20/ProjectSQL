using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1.ADChildForm
{
    public partial class ADSelectSV : Form
    {
        public ADSelectSV()
        {
            InitializeComponent();
        }

        private void ADSelectSV_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Connection().AddmintData("dbo.ProSelectSV");
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@CMTND",
                value = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@Ho",
                value = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@Dem",
                value = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@Ten",
                value = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@Manganh",
                value = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@MaLopSV",
                value = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()
            });
            var rs = new Connection().Execute("[dbo].[ProcDKHT_InDe]", lstPara);
            if (rs == 2)
            {
                MessageBox.Show("Xóa thành công");
                //LoadData();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            ADSelectSV f = new ADSelectSV();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
