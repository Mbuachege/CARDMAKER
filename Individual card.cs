using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.Layout;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Layout.Properties;
using System.IO;
using iText.Kernel.Geom;
using QRCoder;


namespace CARDMAKER
{
    public partial class Individual_card : Form
    {
        public Individual_card()
        {
            InitializeComponent();
        }
        string frontimage;
        string Institution;
        string Email;
        string BOX;
        string Locationale;
        string MOTTO;
        string LogoPath;
        string SignaturePath;
        string BackgroundFrontPath;
        string BackgroundBackPath;
        string TitleColor;
        string FooterColor;
        string BackNote;
        string QrCodepath;
        string outputFileName;
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                TxtImagepath.Text = open.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(TxtName.Text == ""|TxtPhoneNo.Text == ""| TxtRegNo.Text == ""|TxtForm.Text == ""| TxtExpiryDate.Text == ""| TxtImagepath.Text == "" )
                {
                    MessageBox.Show("Please Fill all the Fields");
                    return;
                }
                else
                { 
                savedata();

                    using (SqlConnection sqlConnection = CONNECTION.CONN())
                    {
                        string SQL = "SELECT * FROM [dbo].[ImportData] where [RegNo] = '" + TxtRegNo.Text.ToString() + "'";
                        SqlCommand cmd = new SqlCommand(SQL, sqlConnection);
                        SqlDataReader dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            string Name = dataReader["Name"].ToString();
                            string RegNo = dataReader["RegNo"].ToString();
                            string form = dataReader["Form"].ToString();
                            string PhoneNo = dataReader["PhoneNo"].ToString();
                            string ExpiryDate = dataReader["ExpiryDate"].ToString();
                            string Imagepath = dataReader["ImagePath"].ToString();
                            string qrcodepath = dataReader["QrCodePath"].ToString();

                            PrintID(Name, RegNo, form, PhoneNo, ExpiryDate, Imagepath, qrcodepath);

                        }
                    }

                }

                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"E:\IDS\");
                int count = dir.GetFiles().Length;
                MessageBox.Show("WAZI JOH" + count);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void PrintID(string Name, string RegNo, string form, string PhoneNo, string ExpiryDate, string ImagePath, string qrcodepath)
        {
            using (SqlConnection sqlConnection = CONNECTION.CONN())
            {
                string SQL1 = "SELECT * FROM [dbo].[CARDSETTINGS] where [DesignName] = '" + CmbDesign.Text.ToString() + "'";
                SqlCommand cmd1 = new SqlCommand(SQL1, sqlConnection);
                SqlDataReader dataReader1 = cmd1.ExecuteReader();

                while (dataReader1.Read())
                {
                    Institution = dataReader1["Institution"].ToString();
                    Email = dataReader1["Email"].ToString();
                    BOX = dataReader1["BOX"].ToString();
                    Locationale = dataReader1["Location"].ToString();
                    MOTTO = dataReader1["MOTTO"].ToString();
                    LogoPath = dataReader1["LogoPath"].ToString();
                    SignaturePath = dataReader1["SignaturePath"].ToString();
                    frontimage = dataReader1["BackgroundFrontPath"].ToString(); ;
                    BackgroundBackPath = dataReader1["BackgroundBackPath"].ToString();
                    TitleColor = dataReader1["TitleColor"].ToString();
                    FooterColor = dataReader1["FooterColor"].ToString();
                    BackNote = dataReader1["BackNote"].ToString();
                    //DesignName = dataReader1["DesignName"].ToString();

                }

            }

            float myWidth = 242.64f;

            var Strfile = @"E:\IDS\" + RegNo.ToString() + ".pdf";


            using (PdfWriter writer = new PdfWriter(new FileStream(Strfile, FileMode.Create), new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                PageSize pageSize = new PageSize(242.64f, 153.36f);


                var PDFdOCUMENT = new PdfDocument(writer);
                PDFdOCUMENT.SetDefaultPageSize(pageSize);


                var document = new Document(PDFdOCUMENT);

                document.SetMargins(0f, 0f, 0f, 0f);


                var NewRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_BOLD);
                var fontnormal = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);

                float opacity = 50;
                //string imageFilePath = frontimage;
                Image jpg = new Image(iText.IO.Image.ImageDataFactory.Create(frontimage));
                //iText.Layout.Element.Image jpg = new iText.Layout.Element.Image(iText.IO.Image.ImageDataFactory.Create(imageFilePath));
                jpg.ScaleToFit(242.64f, 153.36f).SetPadding(0);
                jpg.SetFixedPosition(0, 0);
                jpg.SetUnderline(242.64f, 153.36f).SetPadding(0);
                jpg.ScaleAbsolute(242.64f, 153.36f).SetPadding(0);
                jpg.SetOpacity(opacity);
                document.Add(jpg);

                Color bgColour1 = new DeviceRgb(System.Drawing.Color.FromName(TitleColor));
                Paragraph paragraph1 = new Paragraph("MURANGAUNIVERSITYKENYA").SetFirstLineIndent(42).SetFont(NewRoman).SetFontSize(14).SetMarginLeft(0).SetMarginTop(0).SetBackgroundColor(bgColour1).SetWidth(myWidth).SetPaddingLeft(0).SetHeight(27f).SetPadding(0);
                document.Add(paragraph1);


                //var logo = @"C:\Users\ADMIN\Downloads\logo.png";
                Image image = new Image(iText.IO.Image.ImageDataFactory.Create(LogoPath));
                image.ScaleAbsolute(43f, 28f).SetPadding(0);
                image.SetFixedPosition(1f, 126f).SetPadding(0);
                document.Add(image);


                Paragraph paragraph2 = new Paragraph(Email + " " + "P.O BOX:" + BOX + " " + Locationale).SetFont(NewRoman).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetMarginTop(0).SetWidth(myWidth).SetFixedPosition(2f, 115f, 243.5f).SetPadding(0);
                paragraph2.SetFirstLineIndent(24);
                document.Add(paragraph2);

                Image img = new Image(iText.IO.Image.ImageDataFactory.Create(ImagePath));
                img.ScaleAbsolute(90f, 72f);
                //img.SetBorderRadius(new BorderRadius(4));
                img.SetFixedPosition(1f, 33f);
                document.Add(img);
                //document.Add(new Paragraph("\n"));
                Paragraph paragraph3 = new Paragraph(Name).SetFirstLineIndent(70).SetFont(NewRoman);
                paragraph3.SetFontSize(12);
                paragraph3.SetHeight(16f);
                paragraph3.SetPaddingTop(8).SetPaddingBottom(0).SetMarginBottom(0);
                document.Add(paragraph3);
                Paragraph paragraph4 = new Paragraph("REG NO:   " + RegNo).SetFirstLineIndent(100).SetFont(NewRoman);
                paragraph4.SetFontSize(8).SetPaddingTop(0).SetMarginTop(4).SetMarginBottom(0).SetHeight(12f);
                document.Add(paragraph4);
                Paragraph paragraph5 = new Paragraph("PHONE NO:   " + PhoneNo).SetFirstLineIndent(100).SetFont(NewRoman);
                paragraph5.SetFontSize(8).SetMarginBottom(0).SetMarginTop(4).SetHeight(12f);
                document.Add(paragraph5);
                Paragraph paragraph6 = new Paragraph("Form:   " + form).SetFirstLineIndent(100).SetFont(NewRoman);
                paragraph6.SetFontSize(8).SetMarginBottom(0).SetMarginTop(3).SetHeight(12f);
                document.Add(paragraph6);
                Paragraph paragraph7 = new Paragraph("EXP.DATE:   " + ExpiryDate.ToString()).SetFirstLineIndent(100).SetFont(NewRoman);
                paragraph7.SetFontSize(8).SetPaddingTop(0).SetPaddingBottom(0).SetMarginBottom(0).SetMarginTop(2).SetHeight(12f);
                document.Add(paragraph7);
                //Paragraph paragraph8 = new Paragraph(Signature).SetFirstLineIndent(90).SetFont(fontnormal);
                //paragraph8.SetFontSize(8).SetPaddingTop(1);
                //document.Add(paragraph8);

                var timesNewRoman = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                var P1 = new Paragraph();
                P1.SetFont(timesNewRoman);
                P1.SetWidth(myWidth);
                P1.SetFontSize(11).SetPaddingTop(0).SetMarginBottom(0).SetMarginTop(18);
                P1.SetTextAlignment(TextAlignment.JUSTIFIED_ALL);
                Color bgColour = new DeviceRgb(System.Drawing.Color.FromName(FooterColor));
                P1.SetFontColor(ColorConstants.BLACK);
                P1.SetBackgroundColor(bgColour);
                P1.Add(MOTTO);
                document.Add(P1);

                AreaBreak ab = new AreaBreak();
                document.Add(ab);

                //string imageFilePath2 = fro;
                Image jpg2 = new Image(iText.IO.Image.ImageDataFactory.Create(frontimage));
                jpg2.ScaleToFit(242.64f, 153.36f).SetPadding(0);
                jpg2.SetFixedPosition(0, 0);
                jpg2.SetUnderline(242.64f, 153.36f).SetPadding(0);
                jpg2.ScaleAbsolute(242.64f, 153.36f).SetPadding(0);
                jpg2.SetOpacity(opacity);
                document.Add(jpg2);

                Paragraph para2 = new Paragraph(BackNote);
                para2.SetFont(NewRoman).SetFirstLineIndent(10);
                para2.SetFontSize(14).SetTextAlignment(TextAlignment.CENTER).SetHeight(26f);
                document.Add(para2);

                Paragraph para3 = new Paragraph(Email + " P.O-BOX:" + BOX + Locationale).SetFont(NewRoman).SetFontSize(9).SetTextAlignment(TextAlignment.LEFT).SetMarginTop(0).SetWidth(myWidth).SetFixedPosition(2f, 115f, 243.5f).SetPadding(0);
                para3.SetFirstLineIndent(24);
                document.Add(para3);

                Image imgcode = new Image(iText.IO.Image.ImageDataFactory.Create(qrcodepath));
                imgcode.ScaleAbsolute(84f, 57f);
                imgcode.SetFixedPosition(1.5f, 39f);
                document.Add(imgcode);
                document.Add(new Paragraph("\n\n"));
                Paragraph para4 = new Paragraph("REG NO:").SetFirstLineIndent(100).SetFont(NewRoman);
                para4.SetFontSize(8).SetPaddingTop(0).SetMarginTop(4).SetMarginBottom(0);
                document.Add(para4);

                Paragraph para5 = new Paragraph("PHONE NO:").SetFirstLineIndent(100).SetFont(NewRoman);
                para5.SetFontSize(8).SetMarginBottom(0).SetMarginTop(4);
                document.Add(para5);

                var signature = @"C:\Users\ADMIN\Downloads\sig.png";
                Image signa = new Image(iText.IO.Image.ImageDataFactory.Create(SignaturePath));
                signa.ScaleAbsolute(84f, 61f);
                signa.SetFixedPosition(150f, 39f);
                document.Add(signa);

                var timesNewRoman1 = PdfFontFactory.CreateFont(StandardFonts.TIMES_ROMAN);
                var para6 = new Paragraph();
                para6.SetFont(timesNewRoman1);
                para6.SetWidth(myWidth).SetHeight(24f);
                para6.SetFontSize(11).SetPaddingTop(0).SetMarginBottom(0).SetMarginTop(19);
                para6.SetTextAlignment(TextAlignment.JUSTIFIED_ALL);
                Color bgColour2 = new DeviceRgb(System.Drawing.Color.FromName(TitleColor));
                para6.SetFontColor(ColorConstants.BLACK);
                para6.SetBackgroundColor(bgColour2);
                para6.Add(MOTTO);
                document.Add(para6);

                document.Close();

                PDFdOCUMENT.Close();

            }

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
        private void savedata()
        {
            string Namee = TxtName.Text;
            string RegNo = TxtRegNo.Text;
            QRCodeGenerator qr = new QRCodeGenerator();
            byte[] img = null;

            QRCodeData qRCodeData = qr.CreateQrCode(Namee + RegNo, QRCodeGenerator.ECCLevel.Q);

            QRCode Qcode = new QRCode(qRCodeData);
            using (System.Drawing.Bitmap bitmap = Qcode.GetGraphic(15))
            {
                using (MemoryStream ms = new MemoryStream())
                {

                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    System.Drawing.Color backColor = bitmap.GetPixel(0, 0);
                    bitmap.MakeTransparent();

                    img = new byte[ms.ToArray().Length];
                    img = ms.ToArray();

                    outputFileName = @"C:\Users\ADMIN\Downloads\" + Namee + ".png";

                    FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite);
                    bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    // memory.ToStream(fs) // I think the same
                    byte[] bytes = ms.ToArray();
                    fs.Write(bytes, 0, bytes.Length);

                   
                }
            }

        
            using (SqlConnection sql = CONNECTION.CONN())
            {
                string query = "INSERT INTO [dbo].[ImportData] ([Name],[RegNo],[Form],[PhoneNo],[ExpiryDate],[ImagePath],QrCodePath)" +
                    " Values(@Name, @RegNo,@Form,@PhoneNo, @ExpiryDate, @ImagePath,@QrCodePath)";
                SqlCommand sqlCommand = new SqlCommand(query, sql);

                sqlCommand.Parameters.AddWithValue("@Name", TxtName.Text.ToString());
                sqlCommand.Parameters.AddWithValue("@RegNo", TxtRegNo.Text.ToString());
                sqlCommand.Parameters.AddWithValue("@Form", TxtForm.Text.ToString());
                sqlCommand.Parameters.AddWithValue("@PhoneNo", TxtPhoneNo.Text.ToString());
                sqlCommand.Parameters.AddWithValue("@ExpiryDate", TxtExpiryDate.Text.ToString());
                sqlCommand.Parameters.AddWithValue("@ImagePath", TxtImagepath.Text.ToString());
                sqlCommand.Parameters.AddWithValue("@QrCodePath", outputFileName);

                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Successful Saved");
            }
        }

        private void Individual_card_Load(object sender, EventArgs e)
        {
            ChooseDesign();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = CONNECTION.CONN())
            {
                string SQL = "SELECT * FROM [dbo].[ImportData] where [RegNo] = '" + TxtRegNo.Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand(SQL, sqlConnection);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    string Name = dataReader["Name"].ToString();
                    string RegNo = dataReader["RegNo"].ToString();
                    string form = dataReader["Form"].ToString();
                    string PhoneNo = dataReader["PhoneNo"].ToString();
                    string ExpiryDate = dataReader["ExpiryDate"].ToString();
                    string Imagepath = dataReader["ImagePath"].ToString();
                    string qrcodepath = dataReader["QrCodePath"].ToString();

                    PrintID(Name, RegNo, form, PhoneNo, ExpiryDate, Imagepath, qrcodepath);

                }

            }
        }

        private void TxtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
