using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARDMAKER
{
    public partial class iMPORTEDFilesNames : Form
    {
        public iMPORTEDFilesNames()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = CONNECTION.CONN())
            {
                SqlCommand cmd = new SqlCommand("SELECT Id, FileName FROM [dbo].[Imported Tables]", conn)
                {
                    CommandType = CommandType.Text
                };
                DataTable dt = new DataTable();
                using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                {
                    adt.Fill(dt);
                }
                dataGridView1.DataSource = dt;

            }
        }
    }
}
