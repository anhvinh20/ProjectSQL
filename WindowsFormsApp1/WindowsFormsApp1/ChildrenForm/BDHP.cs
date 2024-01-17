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
    public partial class BDHP : Form
    {
        public BDHP()
        {
            InitializeComponent();
        }

        private void BDHP_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new Connection().SelectData("[dbo].[BangDiemCN]");
        }
    }
}
