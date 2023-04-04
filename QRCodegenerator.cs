using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARDMAKER
{
    public partial class QRCodegenerator : Form
    {
        public QRCodegenerator()
        {
            InitializeComponent();
        }
        string outputFileName;
        string Namee;
        string RegNo;
        string qrnumber;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                generateQrCODES();
                fillQrgrid();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void ChoosefileName()
        {
            try
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
                    CmbImportedTable.DataSource = dt;
                    CmbImportedTable.ValueMember = "Id";
                    CmbImportedTable.DisplayMember = "FileName";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void generateQrCODES()
        {
            try
            {
                using (SqlConnection sqlConnection = CONNECTION.CONN())
                {
                    string SQL = "SELECT * FROM [dbo].[ImportData] where [ImportName] = '" + CmbImportedTable.Text.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(SQL, sqlConnection);
                    SqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Namee = dataReader["Name"].ToString();
                        RegNo = dataReader["RegNo"].ToString();
                        QRCodeGenerator qr = new QRCodeGenerator();
                        byte[] img = null;
                        Random rnd = new Random();

                        for (int j = 0; j < 1; j++)
                        {
                            qrnumber = rnd.Next().ToString();

                            QRCodeData qRCodeData = qr.CreateQrCode(qrnumber, QRCodeGenerator.ECCLevel.Q);
                            QRCode Qcode = new QRCode(qRCodeData);

                            using (Bitmap bitmap = Qcode.GetGraphic(15))
                            {
                                using (MemoryStream ms = new MemoryStream())
                                {

                                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    Color backColor = bitmap.GetPixel(0, 0);
                                    bitmap.MakeTransparent();

                                    img = new byte[ms.ToArray().Length];
                                    img = ms.ToArray();

                                    outputFileName = @"C:\Users\ADMIN\Downloads\" + qrnumber + ".png";

                                    FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite);
                                    bitmap.Save(ms, ImageFormat.Jpeg);
                                    // memory.ToStream(fs) // I think the same
                                    byte[] bytes = ms.ToArray();
                                    fs.Write(bytes, 0, bytes.Length);

                                    saveqrcodes();
                                }
                            }
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void fillQrgrid()
        {
            using (SqlConnection conn = CONNECTION.CONN())
            {
                SqlCommand cmd = new SqlCommand("SELECT [Name],[RegNo],[QrCodePath],[QrCode] FROM [dbo].[ImportData] WHERE [ImportName] = '" + CmbImportedTable.Text +"'", conn)
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
        private void saveqrcodes()
        {
            using (SqlConnection sqlConnection = CONNECTION.CONN())
            {

                string query = "UPDATE [dbo].[ImportData] SET [QrCodePath] = @QrPath, [QrCode] = @Qrcode WHERE [RegNo] = '" + RegNo +"'";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);

                cmd.Parameters.AddWithValue("@QrPath", outputFileName.ToString());
                cmd.Parameters.AddWithValue("@Qrcode", qrnumber);
                cmd.ExecuteNonQuery();
            }
        }
        private void QRCodegenerator_Load(object sender, EventArgs e)
        {
            ChoosefileName();
        }

        private void CmbImportedTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
