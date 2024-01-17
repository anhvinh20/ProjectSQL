using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.ChildForm
{
    public partial class Lienhe : Form
    {
        public Lienhe()
        {
            InitializeComponent();
        }

        private void Lienhe_Load(object sender, EventArgs e)
        {
            //labelMSSV.Text = dr.ItemArray[3].ToString();
            //labelMSSV.Text = dt.Rows[0].ItemArray[1].ToString();
            //dataGridView1.DataSource = dt;
            //dataGridView1.Columns[0].Width = 100;
            //dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridView1.Columns[0].HeaderText = "Mã số sinh viên";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            labelMSSV.Text = dataGridView1.Rows[e.RowIndex].Cells["MSSV"].Value.ToString();
        }
    }
}
