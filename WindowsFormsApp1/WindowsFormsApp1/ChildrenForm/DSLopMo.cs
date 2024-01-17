﻿using System;
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
    public partial class DSLopMo : Form
    {
        public DSLopMo()
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
            dataGridView1.DataSource = new Connection().SelectData("[dbo].[ProcTTLM]", lstPara);
        }
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DSLopMo_Load(object sender, EventArgs e)
        {
            DataTable dt = new Connection().SelectData("[dbo].[ProcTTLM]");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
            comboBox1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
        }
    }
}