using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARDMAKER
{
    public partial class progressbar : Form
    {
        public progressbar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 2;

            if (panel2.Width >= 636)
            {
                timer1.Stop();
                MASTERPAGE mASTERPAGE = new MASTERPAGE();
                mASTERPAGE.Show();
                this.Hide();
               
            }
        }

        private void progressbar_Load(object sender, EventArgs e)
        {
        }
    }
}
