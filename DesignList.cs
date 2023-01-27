using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CARDMAKER
{
    public partial class DesignList : Form
    {
        public DesignList()
        {
            InitializeComponent();
        }

        private void DesignList_Load(object sender, EventArgs e)
        {
            fillgrid();
        }
        private void fillgrid()
        {
            using (SqlConnection con = CONNECTION.CONN())
            {
                SqlCommand CMD = new SqlCommand("SELECT *FROM [CARDGN].[dbo].[Designs]", con);
                SqlDataAdapter SDA = new SqlDataAdapter(CMD);
                DataTable Dt = new DataTable();
                SDA.Fill(Dt);

                dataGridView1.DataSource = Dt;

            }
        }

        private void DesignList_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cardDesigns.Designs' table. You can move, or remove it, as needed.
            this.designsTableAdapter.Fill(this.cardDesigns.Designs);

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                string column = dataGridView1.Columns[e.ColumnIndex].Name;
                string designname = Convert.ToString(dataGridView1[1, row].Value);
                if (column == "Edit")
                {
                    using (SqlConnection con = CONNECTION.CONN())
                    {
                        string SQL = "SELECT  *FROM [dbo].[CARDSETTINGS] WHERE [DesignName]= '" + designname + "' ";
                        SqlCommand cmd = new SqlCommand(SQL, con);
                        SqlDataReader dataReader1 = cmd.ExecuteReader();

                        while (dataReader1.Read())
                        {

                            CardDesign cardDesign = new CardDesign();

                            cardDesign.TxtInstitution.Text = dataReader1["Institution"].ToString();
                            cardDesign.TxtEmail.Text = dataReader1["Email"].ToString();
                            cardDesign.TxtBox.Text = dataReader1["BOX"].ToString();
                            cardDesign.TxtLocation.Text = dataReader1["Location"].ToString();
                            cardDesign.TxtMotto.Text = dataReader1["MOTTO"].ToString();
                            cardDesign.TxtLogoPath.Text = dataReader1["LogoPath"].ToString();
                            cardDesign.TxtSignaturePath.Text = dataReader1["SignaturePath"].ToString();
                            cardDesign.TxtFrontBackGroundImage.Text = dataReader1["BackgroundFrontPath"].ToString(); ;
                            cardDesign.TxtBackgroungImageback.Text = dataReader1["BackgroundBackPath"].ToString();
                            cardDesign.TxtTitleBackColor.Text = dataReader1["TitleColor"].ToString();
                            cardDesign.TxtFooterBackColor.Text = dataReader1["FooterColor"].ToString();
                            cardDesign.TxtBackNote.Text = dataReader1["BackNote"].ToString();
                            cardDesign.TxtDesignName.Text = dataReader1["DesignName"].ToString();
                            cardDesign.TxtDesignName.ReadOnly = true;

                            cardDesign.Show();
                        }
                    }

                }
                else if (column == "Delete")
                {
                    using (SqlConnection con = CONNECTION.CONN())
                    {

                        if (MessageBox.Show("Do you want to Remove this item??", "Delete Item", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {

                            SqlCommand cmd = new SqlCommand("DELETE FROM [dbo].[Designs] WHERE [Id] = '" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "'", con);
                            cmd.ExecuteNonQuery();

                            SqlCommand cmd1 = new SqlCommand("DELETE FROM [dbo].[CARDSETTINGS] WHERE [DesignName] = '" + Convert.ToString(dataGridView1[1, row].Value) + "'", con);
                            cmd1.ExecuteNonQuery();

                            MessageBox.Show("Deleted sucessful");
                            
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
