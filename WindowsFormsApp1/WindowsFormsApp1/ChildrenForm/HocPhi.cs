using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.ChildrenForm
{
    public partial class HocPhi : Form
    {
        public HocPhi()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@kyhoc",
                value = comboBox1.Text
            });

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new Connection().SelectData("[dbo].[ProcHPCN]", lstPara);
            DataTable dt = new Connection().SelectData("[dbo].[ProcHPCN]", lstPara);
                dataGridView1.DataSource = dt;
                labelCount.Text = dt.Rows.Count.ToString();
                DataRow dr = new Connection().SelectRow("[dbo].[ProcTTHP]", lstPara);
                labelSum.Text = dr.ItemArray[0].ToString();
                label7.Text = dr.ItemArray[2].ToString();
                label8.Text = dr.ItemArray[1].ToString();
                label11.Text = dr.ItemArray[3].ToString();
                 label10.Text = dr.ItemArray[4].ToString();
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void HocPhi_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            DataTable dt = new Connection().SelectData("[dbo].[ProcHPCN]");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
        }
    }
}
