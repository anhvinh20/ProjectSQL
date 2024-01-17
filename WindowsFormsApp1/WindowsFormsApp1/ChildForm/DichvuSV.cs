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
using WindowsFormsApp1.ChildrenForm;

namespace WindowsFormsApp1.ChildForm
{
    public partial class DichvuSV : Form
    {

        private bool isCollapsed;
        public DichvuSV()
        {
            InitializeComponent();
        }
        #region
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                HSSVButton.Image = Resources.CollapseArrow;
                HSSVPanel.Height += 10;
                if (HSSVPanel.Size == HSSVPanel.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                HSSVButton.Image = Resources.ExpandArrow;
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
                KQHTButton.Image = Resources.CollapseArrow;
                KQHTPanel.Height += 10;
                if (KQHTPanel.Size == KQHTPanel.MaximumSize)
                {
                    timer2.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                KQHTButton.Image = Resources.ExpandArrow;
                KQHTPanel.Height -= 10;
                if (KQHTPanel.Size == KQHTPanel.MinimumSize)
                {
                    timer2.Stop();
                    isCollapsed = true;
                }
            }
        }
        private void KQHTButton_Click(object sender, EventArgs e)
        {
              timer2.Start();
        }    
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                CTDTButton.Image = Resources.CollapseArrow;
                CTDTPanel.Height += 10;
                if (CTDTPanel.Size == CTDTPanel.MaximumSize)
                {
                    timer3.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                CTDTButton.Image = Resources.ExpandArrow;
                CTDTPanel.Height -= 10;
                if (CTDTPanel.Size == CTDTPanel.MinimumSize)
                {
                    timer3.Stop();
                    isCollapsed = true;
                }
            }
        }  
        
        private void CTDTButton_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                buttonDKHT.Image = Resources.CollapseArrow;
                panelDKHT.Height += 10;
                if (panelDKHT.Size == CTDTPanel.MaximumSize)
                {
                    timer4.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                buttonDKHT.Image = Resources.ExpandArrow;
                panelDKHT.Height -= 10;
                if (panelDKHT.Size == CTDTPanel.MinimumSize)
                {
                    timer4.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void buttonDKHT_Click(object sender, EventArgs e)
        {
            timer4.Start();
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
            var f = new HosoSv();
            AddForm(f);
        }

        private void HSSVbutton2_Click(object sender, EventArgs e)
        {
            var f = new LopSV();
            AddForm(f);
        }

        private void ButtonTKB_Click(object sender, EventArgs e)
        {
            var f = new TKB();
            AddForm(f);
        }

        private void KQHTbutton1_Click(object sender, EventArgs e)
        {
            var f = new BDHP();
            AddForm(f);
        }

        private void KQHTbutton2_Click(object sender, EventArgs e)
        {
            var f = new BDMoi();
            AddForm(f);
        }

        private void HPButton_Click(object sender, EventArgs e)
        {
            var f = new HocPhi();
            AddForm(f);
        }

        private void CTDTbutton1_Click(object sender, EventArgs e)
        {
            var f = new CTDTSV();
            AddForm(f);
        }

        private void CTDTbutton2_Click(object sender, EventArgs e)
        {
            var f = new CTDTTT();
            AddForm(f);
        }

        private void buttonDSLM_Click(object sender, EventArgs e)
        {
            var f = new DSLopMo();
            AddForm(f);
        }

        private void buttonSVDKHT_Click(object sender, EventArgs e)
        {
            var f = new DKHTSV();
            AddForm(f);
        }
        #endregion

        private void mởCửaSổMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMain f = new FormMain();
            f.Show();
        }
    }
}
