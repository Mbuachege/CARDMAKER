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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openchildform(new ImportData());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openchildform(new MultipleCards());
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openchildform(new CardDesign());
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            openchildform(new Home());
        }
        public Form activeform = null;
        public void openchildform(Form childform)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel1.Controls.Add(childform);
            panel1.Tag = childform;
            childform.BringToFront();
            childform.Show();
            
        

        }

        private void cARDDESIGNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new CardDesign());
        }

        private void vIEWLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new MultipleCards());

        }

        private void iMPORTDATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new ImportData());
        }

        private void iNDIVIDUALCARDSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void iMPORTEDFILENAMESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new iMPORTEDFilesNames());
        }

        private void aDDNEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new Individual_card()); 
        }

        private void sELECTEXISITINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new GENERATESINGLECARD());
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            openchildform(new CardDesign());
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            openchildform(new ImportData());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            openchildform(new QRCodegenerator());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openchildform(new Home());
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void qRCODESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new QRCodegenerator());
        }

        private void dESIGNLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openchildform(new DesignList());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openchildform(new Individual_card());
            panel1.BackColor = Color.FromArgb(130, 0, 0, 0);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            openchildform(new MultipleCards());
        }
    }
}
