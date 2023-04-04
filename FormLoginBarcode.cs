using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace CARDMAKER
{
    public partial class FormLoginBarcode : Form
    {
        public FormLoginBarcode()
        {
            InitializeComponent();
        }
        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice VideoCaptureDevice;
        private void FormLoginBarcode_Load(object sender, EventArgs e)
        {
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in FilterInfoCollection)
                comboBox1.Items.Add(filterInfo.Name);

            comboBox1.SelectedIndex = 0;
            timer1.Start();
        }

        private void FormLoginBarcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (VideoCaptureDevice.IsRunning == true)
            {
                VideoCaptureDevice.Stop();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)pictureBox1.Image);
                if(result !=null)
                {
                    textBox1.Text = result.ToString();
                    timer1.Stop();
                    if (VideoCaptureDevice.IsRunning == true)
                    {
                        VideoCaptureDevice.Stop();
                    }
                }
            }
        }
        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            VideoCaptureDevice = new VideoCaptureDevice(FilterInfoCollection[comboBox1.SelectedIndex].MonikerString);
            VideoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            VideoCaptureDevice.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            for (int j = 0; j < 4; j++)
            {
                textBox2.Text = rnd.Next().ToString();
            }
        }
        //public string RandomPassword()
       // {
            //var passwordBuilder = new StringBuilder();

            //// 4-Letters lower case
            //passwordBuilder.Append(RandomString(4, true));

            //// 4-Digits between 1000 and 9999
            //passwordBuilder.Append(RandomNumber(1000, 9999));

            //// 2-Letters upper case
            //passwordBuilder.Append(RandomString(2));
            //return passwordBuilder.ToString();
       // }

    }
}
