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
using System.IO;

namespace CARDMAKER
{
    public partial class CardDesign : Form
    {
        public CardDesign()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            ChooseDesign();
        }
        private void ChooseDesign()
        {
            using (SqlConnection conn = CONNECTION.CONN())
            {
                SqlCommand cmd = new SqlCommand("SELECT [Id], [DesignName] FROM [dbo].[Designs]", conn)
                {
                    CommandType = CommandType.Text
                };
                DataTable dt = new DataTable();
                using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                {
                    adt.Fill(dt);
                }
                CmbDesign.DataSource = dt;
                CmbDesign.ValueMember = "Id";
                CmbDesign.DisplayMember = "DesignName";



            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                //pictureBox1.Image = new Bitmap(open.FileName);
                // image file path  
                TxtLogoPath.Text = open.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            if (open.ShowDialog() == DialogResult.OK)
            { 
                TxtFrontBackGroundImage.Text = open.FileName;
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void ImportSignature_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;"; 
            if (open.ShowDialog() == DialogResult.OK)
            {
                TxtSignaturePath.Text = open.FileName;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                TxtBackgroungImageback.Text = open.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
        private void savedesign()
        {
            try
            {
                using (SqlConnection conn = CONNECTION.CONN())
                {
                    string query = "INSERT INTO [dbo].[Designs] ([DesignName]) values (@DesignName)";
                    SqlCommand cmd1 = new SqlCommand(query, conn);
                    cmd1.Parameters.AddWithValue("@DesignName", TxtDesignName.Text);
                    cmd1.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtInstitution.Text == "" | TxtEmail.Text == "" | TxtBox.Text == "" |
                    TxtLocation.Text == "" | TxtMotto.Text == "" | TxtLogoPath.Text == "" |
                    TxtSignaturePath.Text == "" | TxtFrontBackGroundImage.Text == "" | TxtBackgroungImageback.Text == "" |
                    TxtTitleBackColor.Text == "" | TxtFooterBackColor.Text == "" | TxtBackNote.Text == "" | TxtDesignName.Text == "")
                {
                    MessageBox.Show("Please fill all the fields");
                    return;
                }
                else
                {
                    using (SqlConnection con = CONNECTION.CONN())
                    {
                        string query = "INSERT INTO [dbo].[CARDSETTINGS] ([Institution],[Email],[BOX],[Location],[MOTTO],[LogoPath]," +
                            "[SignaturePath],[BackgroundFrontPath],[BackgroundBackPath]," +
                            "[TitleColor],[FooterColor],[BackNote],[DesignName]) VALUES(@Institution, @Email, @Box, @Location, @Motto," +
                            " @Logopath,@Signaturepath,@BackgroundFrontPath,@Backgroudimage, @Titlecolor, @FootColo,@BackNote, @DesignName)";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Institution", TxtInstitution.Text);
                        cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
                        cmd.Parameters.AddWithValue("@Box", TxtBox.Text);
                        cmd.Parameters.AddWithValue("@Location", TxtLocation.Text);
                        cmd.Parameters.AddWithValue("@Motto", TxtMotto.Text.ToString());
                        cmd.Parameters.AddWithValue("@Logopath", TxtLogoPath.Text.ToString());
                        cmd.Parameters.AddWithValue("@Signaturepath", TxtSignaturePath.Text.ToString());
                        cmd.Parameters.AddWithValue("@BackgroundFrontPath", TxtFrontBackGroundImage.Text.ToString());
                        cmd.Parameters.AddWithValue("@Backgroudimage", TxtBackgroungImageback.Text.ToString());
                        cmd.Parameters.AddWithValue("@Titlecolor", TxtTitleBackColor.Text);
                        cmd.Parameters.AddWithValue("@FootColo", TxtFooterBackColor.Text);
                        cmd.Parameters.AddWithValue("@BackNote", TxtBackNote.Text);
                        cmd.Parameters.AddWithValue("@DesignName", TxtDesignName.Text);

                        cmd.ExecuteNonQuery();

                        savedesign();
                        MessageBox.Show("Saved successfully");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void CmbDesign_DropDown(object sender, EventArgs e)
        {
            ChooseDesign();
        }

        private void CmbDesign_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = CONNECTION.CONN())
                {
                    string select = "SELECT * FROM [dbo].[CARDSETTINGS] WHERE [DesignName] = '" + CmbDesign.Text + "'";
                    SqlCommand cmd = new SqlCommand(select, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LblInstitution.Text = reader["Institution"].ToString();
                        string email = reader["Email"].ToString();
                        string box = reader["BOX"].ToString();
                        string location = reader["Location"].ToString();
                        LbLMotto.Text = reader["MOTTO"].ToString();
                        LbLBackTopNote.Text = reader["BackNote"].ToString();
                        LblBackNote.Text = reader["MOTTO"].ToString();
                        LblEmail.Text = email + " " + "P.O BOX: " + box + " " + location;
                        string titlecolor = reader["TitleColor"].ToString();
                        string footercolor = reader["FooterColor"].ToString();
                        panel2.BackColor = System.Drawing.Color.FromName(titlecolor);
                        panel3.BackColor = System.Drawing.Color.FromName(footercolor);
                        string BackgroundFrontPath = reader["BackgroundFrontPath"].ToString();
                        string Backgroudimage1 = reader["BackgroundBackPath"].ToString();
                        Image image = Image.FromFile(BackgroundFrontPath);

                        Image image1 = Image.FromFile(Backgroudimage1);

                        panel1.BackgroundImage = image;

                        panel4.BackgroundImage = image1;

                        panel5.BackColor = System.Drawing.Color.FromName(footercolor);

                        LblBox.Hide();
                        LblLocation.Hide();
                    }
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //return;
            }
        }

        private void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void TxtTitleBackColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (TxtInstitution.Text == "" | TxtEmail.Text == "" | TxtBox.Text == "" |
                    TxtLocation.Text == "" | TxtMotto.Text == "" | TxtLogoPath.Text == "" |
                    TxtSignaturePath.Text == "" | TxtFrontBackGroundImage.Text == "" | TxtBackgroungImageback.Text == "" |
                    TxtTitleBackColor.Text == "" | TxtFooterBackColor.Text == "" | TxtBackNote.Text == "" | TxtDesignName.Text == "")
                {
                    MessageBox.Show("Please fill all the fields");
                    return;
                }
                else
                {
                    using (SqlConnection con = CONNECTION.CONN())
                    {
                        string query = "UPDATE [dbo].[CARDSETTINGS] SET [Institution] = @Institution,[Email]=@Email, [BOX] =@Box,[Location] =@Location,[MOTTO] =@Motto," +
                            "[LogoPath] = @Logopath,[SignaturePath] = @Signaturepath,[BackgroundFrontPath] =@BackgroundFrontPath, [BackgroundBackPath] = @Backgroudimage,[TitleColor] =@Titlecolor,[FooterColor] = @FootColo, [BackNote] =@BackNote,[DesignName] = @DesignName WHERE [DesignName] = @DesignName";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Institution", TxtInstitution.Text);
                        cmd.Parameters.AddWithValue("@Email", TxtEmail.Text);
                        cmd.Parameters.AddWithValue("@Box", TxtBox.Text);
                        cmd.Parameters.AddWithValue("@Location", TxtLocation.Text);
                        cmd.Parameters.AddWithValue("@Motto", TxtMotto.Text.ToString());
                        cmd.Parameters.AddWithValue("@Logopath", TxtLogoPath.Text.ToString());
                        cmd.Parameters.AddWithValue("@Signaturepath", TxtSignaturePath.Text.ToString());
                        cmd.Parameters.AddWithValue("@BackgroundFrontPath", TxtFrontBackGroundImage.Text.ToString());
                        cmd.Parameters.AddWithValue("@Backgroudimage", TxtBackgroungImageback.Text.ToString());
                        cmd.Parameters.AddWithValue("@Titlecolor", TxtTitleBackColor.Text);
                        cmd.Parameters.AddWithValue("@FootColo", TxtFooterBackColor.Text);
                        cmd.Parameters.AddWithValue("@BackNote", TxtBackNote.Text);
                        cmd.Parameters.AddWithValue("@DesignName", TxtDesignName.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Updated successfully");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
