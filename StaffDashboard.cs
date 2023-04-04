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
    public partial class StaffDashboard : Form
    {
        static StaffDashboard _obj;
        public static StaffDashboard Instance
        {
            get
            {
                if(_obj == null)
                {
                    _obj = new StaffDashboard();
                }
                return _obj;
            }
        }
        public Panel panelcontainer
        {
            get
            {
                return panel5;
            }
            set
            {
                panel5 = value;
            }
        }
        public Button buttonback
        {
            get
            {
                return button6;
            }
            set
            {
                button6 = value;
            }
        }
        public StaffDashboard()
        {
            InitializeComponent();
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
            panel5.Controls.Add(childform);
            panel5.Tag = childform;
            childform.BringToFront();
            childform.Show();

        }

        private void StaffDashboard_Load(object sender, EventArgs e)
        {
            //label3.Text = DateTime.Now.ToString();
            //button6.Visible = false;
            //_obj = this;

            //StaffHome staffHome = new StaffHome();
            //staffHome.Dock = DockStyle.Fill;
            //panelcontainer.Controls.Add(staffHome);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openchildform(new CardDesign());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openchildform(new StaffSinglecard());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openchildform(new capturepic());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openchildform(new StaffCardDesign());
        }
    }
}
