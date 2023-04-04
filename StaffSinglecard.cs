using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;



namespace CARDMAKER
{
    public partial class StaffSinglecard : Form
    {
        Rectangle rectangle; //INSTANCE OF A RECTANGLE
        Point LocationXY;
        Point LocationX1Y1;

        bool IsMouseDown = false;

         // import the System.Defaults namespace

        // Declare an instance of the SystemDefaults class
      
 

        public StaffSinglecard()
        {
            InitializeComponent();
        }
     

        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice VideoCaptureDevice;

        public string currentDirectory { get; private set; }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StaffSinglecard_Load(object sender, EventArgs e)
        {

            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in FilterInfoCollection)
                comboBox1.Items.Add(filterInfo.Name);

            comboBox1.SelectedIndex = 0;
            VideoCaptureDevice = new VideoCaptureDevice();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.BackColor = Color.Transparent;
        }

      
        private void button5_Click_1(object sender, EventArgs e)
        {
            try
            {
                VideoCaptureDevice = new VideoCaptureDevice(FilterInfoCollection[comboBox1.SelectedIndex].MonikerString);
                VideoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
                VideoCaptureDevice.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StaffSinglecard_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (VideoCaptureDevice.IsRunning == true)
                {
                    VideoCaptureDevice.Stop();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;

            LocationXY = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;

                Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if(IsMouseDown == true)
            {
                LocationX1Y1 = e.Location;
                IsMouseDown = false;

                if (rectangle != null)
                {
                    Bitmap bitmap = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);
                    bitmap.MakeTransparent();

                    Bitmap cropping = new Bitmap(rectangle.Width, rectangle.Height);
                    cropping.MakeTransparent();
                    byte[] img = null;

                    Graphics g = Graphics.FromImage(cropping);
                    g.DrawImage(bitmap, 0, 0, rectangle, GraphicsUnit.Pixel);
                    pictureBox2.Image = cropping;

                    using (MemoryStream ms = new MemoryStream())
                    {

                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        System.Drawing.Color backColor = bitmap.GetPixel(0, 0);
                        bitmap.MakeTransparent();

                        img = new byte[ms.ToArray().Length];
                        img = ms.ToArray();

                        string directoryPath = "\\IDS";
                        string fileName = Path.GetRandomFileName() + ".jpg"; // add the file extension
                        string filePath = Path.Combine(directoryPath, fileName);
                      

                        string outputFileName = filePath;

                        FileStream fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite);
                        bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        // memory.ToStream(fs) // I think the same
                        byte[] bytes = ms.ToArray();
                        fs.Write(bytes, 0, bytes.Length);

                        TxtImagepath.Text = outputFileName;
                    }
                }
            }
           
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(rectangle !=null)
            {
                e.Graphics.DrawRectangle(Pens.Green, GetRect());
            }
        }
        private Rectangle GetRect()
        {
            rectangle = new Rectangle();

            rectangle.X = Math.Min(LocationXY.X, LocationX1Y1.X);
            rectangle.Y = Math.Min(LocationXY.Y, LocationX1Y1.Y);
            rectangle.Width = Math.Abs(LocationXY.X - LocationX1Y1.X);
            rectangle.Height = Math.Abs(LocationXY.Y - LocationX1Y1.Y);

            return rectangle;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == false)
            {
                comboBox1.Enabled = false;
                
            }
            else
            {
                comboBox1.Enabled = true;
                pictureBox1.Enabled = true;
                pictureBox2.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
