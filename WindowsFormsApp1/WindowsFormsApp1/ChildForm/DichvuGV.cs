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
using WindowsFormsApp1.GVChildForm;

namespace WindowsFormsApp1.ChildForm
{
    public partial class DichvuGV : Form
    {

        private bool isCollapsed;
        public DichvuGV()
        {
            InitializeComponent();
        }
        #region
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                buttonHSGV.Image = Resources.CollapseArrow;
                HSSVPanel.Height += 10;
                if (HSSVPanel.Size == HSSVPanel.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                buttonHSGV.Image = Resources.ExpandArrow;
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
                buttonTKB.Image = Resources.CollapseArrow;
                panelDKHT.Height += 10;
                if (panelDKHT.Size == panelDKHT.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                buttonTKB.Image = Resources.ExpandArrow;
                panelDKHT.Height -= 10;
                if (panelDKHT.Size == panelDKHT.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void buttonTKB_Click_1(object sender, EventArgs e)
        {
            timer2.Start();
        }

        #endregion
        private void AddForm(Form f)
        {
            this.panelContent.Controls.Clear();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            this.Text = f.Text;
            this.panelContent.Controls.Add(f);
            f.Show();
        }
        #region
        private void HSSVbutton1_Click(object sender, EventArgs e)
        {
            var f = new HosoGv();
            AddForm(f);
        }
        private void mởCửaSổMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.Show();
        }

        private void buttonLopPT_Click(object sender, EventArgs e)
        {
            var f = new DSLopPT();
            AddForm(f);
        }

        private void buttonTKB2_Click(object sender, EventArgs e)
        {
            var f = new DSLopGD();
            AddForm(f);
        }

        private void buttonND_Click(object sender, EventArgs e)
        {
            var f = new NhapDiem();
            AddForm(f);
        }
        #endregion

        private void buttonLGD_Click(object sender, EventArgs e)
        {
            var f = new TKB();
            AddForm(f);
        }
    }
}
