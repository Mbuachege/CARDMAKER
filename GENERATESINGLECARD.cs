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
using iText.Kernel.Geom;
using System.IO;
using iText.Layout;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout.Element;
using iText.Kernel.Colors;
using iText.Layout.Properties;

namespace CARDMAKER
{
    public partial class GENERATESINGLECARD : Form
    {
        public GENERATESINGLECARD()
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
        string RegNo;
       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            using(SqlConnection connection = CONNECTION.CONN())
            {
                var bindingSource = new BindingSource();
                string fetachSlidesRecentSQL = "select * FROM [dbo].[ImportData] where [RegNo] = '" + TxtRegNo.Text + "'";

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(fetachSlidesRecentSQL, connection))
                {
                    try
                    {
                        SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                        DataTable table = new DataTable();
                        dataAdapter.Fill(table);
                        bindingSource.DataSource = table;
                        dataGridView1.ReadOnly = true;
                        dataGridView1.DataSource = bindingSource;
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "ERROR Loading");
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Nothing to generate");
                }
                else
                {
                    using (SqlConnection sqlConnection = CONNECTION.CONN())
                    {
                        string SQL = "SELECT * FROM [dbo].[ImportData] where [RegNo] = '" + TxtRegNo.Text.ToString() + "'";
                        SqlCommand cmd = new SqlCommand(SQL, sqlConnection);
                        SqlDataReader dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            string Name = dataReader["Name"].ToString();
                            RegNo = dataReader["RegNo"].ToString();
                            string form = dataReader["Form"].ToString();
                            string PhoneNo = dataReader["PhoneNo"].ToString();
                            string ExpiryDate = dataReader["ExpiryDate"].ToString();
                            string Imagepath = dataReader["ImagePath"].ToString();
                            string qrcodepath = dataReader["QrCodePath"].ToString();

                            PrintID(Name, RegNo, form, PhoneNo, ExpiryDate, Imagepath, qrcodepath);

                        }

                    }

                    System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"E:\IDS\");
                    int count = dir.GetFiles().Length;
                    MessageBox.Show("WAZI JOH" + count);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        private void PrintID(string Name, string RegNo, string form, string PhoneNo, string ExpiryDate, string ImagePath,string qrcodepath)
        {
            //string filepather = textBox1.Text;
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

            var Texto = "JOSEPH MBUA CHEGE";
            var idNo = "97654567899";
            var Form = "FORM 4";
            var Signature = "--------------------";

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
                Paragraph paragraph1 = new Paragraph(Institution).SetFirstLineIndent(42).SetFont(NewRoman).SetFontSize(13).SetMarginLeft(0).SetMarginTop(0).SetBackgroundColor(bgColour1).SetWidth(myWidth).SetPaddingLeft(0).SetHeight(27f).SetPadding(0);
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
                P1.SetFont(NewRoman);
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
                para6.SetFont(NewRoman);
                para6.SetWidth(myWidth).SetHeight(24f);
                para6.SetFontSize(12).SetPaddingTop(0).SetMarginBottom(0).SetMarginTop(19);
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

        private void GENERATESINGLECARD_Load(object sender, EventArgs e)
        {
            ChooseDesign();
        }
    }
}
