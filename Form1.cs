﻿using System;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill the Fields");
            }
            else if (textBox1.Text == "Admin" || textBox2.Text == "Admin")
            {
                //MessageBox.Show("Login successfully!!!");
                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong Password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          // panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}