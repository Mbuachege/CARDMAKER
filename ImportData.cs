using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace CARDMAKER
{
    public partial class ImportData : Form
    {
        public ImportData()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog fileDialog = new OpenFileDialog();
            //fileDialog.Title = "Select File";
            //fileDialog.FileName = textBox1.Text;
            //fileDialog.Filter = "Excel Sheet(*.xls)|*.xls|All files(*.*)|*.*";
            //fileDialog.FilterIndex = 1;
            //fileDialog.RestoreDirectory = true;
            //if(fileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    textBox1.Text = fileDialog.FileName;
            //}

           
        }
        private void SaveTablename()
        {
            using(SqlConnection sql =  CONNECTION.CONN())
            {
                string query = "INSERT INTO [dbo].[Imported Tables] ([FileName]) VALUES(@Filename)";
                SqlCommand command = new SqlCommand(query, sql);

                command.Parameters.AddWithValue("@Filename", textBox1.Text.ToString());

                command.ExecuteNonQuery();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            textBox1.Text = "";
        }
        //private void checkdatabase()
        //{
        //    using (SqlConnection CONN = CONNECTION.CONN())
        //    {
        //        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
        //        {
        //            SqlCommand cmd1 = new SqlCommand("Select * FROM [dbo].[ImportData] where [RegNo]= @RegNo", CONN);

        //            cmd1.Parameters.AddWithValue("@RegNo", dataGridView1.Rows[i].Cells[1].Value.ToString());


        //            SqlDataReader dr1 = cmd1.ExecuteReader();
                   
        //            while (dr1.Read())
        //            {

        //                if (dr1.HasRows == true)
        //                {
        //                    MessageBox.Show("Username = " + dr1["RegNo"].ToString() + " Already exist");
        //                    break;



        //                }
                    
        //            }
        //        }
        //    }
                        
        //}
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please fill the box");
            }
            else if(dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to save!!!!!");
            }
            else
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        using (SqlConnection CON = CONNECTION.CONN())
                    {
                        string name = textBox1.Text.ToString();
                        string query = "INSERT INTO [dbo].[ImportData] ([Name],[RegNo],[Form],[PhoneNo],[ExpiryDate],[ImagePath],[ImportName])" +
                        " VALUES (@Name, @RegNo,@Form,@PhoneNo,@ExpiryDate,@Imagepath, '" + name + "')";
                        SqlCommand cmd = new SqlCommand(query, CON);


                        cmd.Parameters.AddWithValue("@Name", dataGridView1.Rows[i].Cells[0].Value);
                        cmd.Parameters.AddWithValue("@RegNo", dataGridView1.Rows[i].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@Form", dataGridView1.Rows[i].Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@PhoneNo", dataGridView1.Rows[i].Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@ExpiryDate", dataGridView1.Rows[i].Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@Imagepath", dataGridView1.Rows[i].Cells[5].Value.ToString());

                        cmd.ExecuteNonQuery();
                    }

                }

                    SaveTablename();
                    MessageBox.Show("CHONJO");
                    

            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Application ImporttoDatagrid;
            _Workbook workbook;
            _Worksheet worksheet;
            Range importgridrange;

            try
            {
                ImporttoDatagrid = new Microsoft.Office.Interop.Excel.Application();
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                fileDialog.Title = "Import To Excel";
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook = ImporttoDatagrid.Workbooks.Open(fileDialog.FileName);
                    worksheet = workbook.Sheets.get_Item(1);
                    importgridrange = worksheet.UsedRange;

                    for (int rows = 2; rows <= importgridrange.Rows.Count; rows++)
                    {
                        if (importgridrange.Cells[rows, 1].Text != "")
                        {
                            dataGridView1.Rows.Add(importgridrange.Cells[rows, 1].value, importgridrange.Cells[rows, 2].value, importgridrange.Cells[rows, 3].value, importgridrange.Cells[rows, 4].value, importgridrange.Cells[rows, 5].value, importgridrange.Cells[rows, 6].value);

                        }
                    }
                    workbook.Close();
                    ImporttoDatagrid.Quit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
