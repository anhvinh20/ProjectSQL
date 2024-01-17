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
    public partial class DSLopGD : Form
    {
        public DSLopGD()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@malopbt",
                value = comboBox1.Text
            });
            lstPara.Add(new CustomParameter()
            {
                key = "@kyhoc",
                value = comboBox2.Text
            });
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = new Connection().SelectData("[dbo].[ProCSelectTTLopGD]", lstPara);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DSLopGD_Load(object sender, EventArgs e)
        {
            DataTable dt = new Connection().SelectData("[dbo].[ProCKyGD]");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox2.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
           List<CustomParameter> lstPara = new List<CustomParameter>();
            lstPara.Add(new CustomParameter()
            {
                key = "@kyhoc",
                value = comboBox2.Text
            });
            DataTable dt = new Connection().SelectData("[dbo].[ProCDSMaLopGD]", lstPara);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
        }
    }
}
