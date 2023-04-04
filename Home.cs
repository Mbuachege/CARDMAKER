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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //show the colour dialog and check that user clicked ok
           
            
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cardDesigns.Designs' table. You can move, or remove it, as needed.
            this.designsTableAdapter.Fill(this.cardDesigns.Designs);
            // TODO: This line of code loads data into the 'importedData.ImportData' table. You can move, or remove it, as needed.
            this.importDataTableAdapter.Fill(this.importedData.ImportData);
            Totalcards();
            TotalcardDesigns();
            Totalimported();
        }
        private void Totalcards()
        {
            using (SqlConnection cn = CONNECTION.CONN())
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM [dbo].[ImportData]", cn);
                var count3 = cmd.ExecuteScalar();
                LblTotalCards.Text = count3.ToString();
            }
        }
        private void TotalcardDesigns()
        {
            using (SqlConnection cn = CONNECTION.CONN())
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM [dbo].[Designs]", cn);
                var count3 = cmd.ExecuteScalar();
                LblCardDesigns.Text = count3.ToString();
            }
        }
        private void Totalimported()
        {
            using (SqlConnection cn = CONNECTION.CONN())
            {
                SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM [dbo].[ImportData] WHERE [ImportName] = '"+ "NULL" + "'", cn);
                var count3 = cmd.ExecuteScalar();
                LblImported.Text = count3.ToString();
            }
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
