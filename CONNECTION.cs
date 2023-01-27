using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CARDMAKER
{
    class CONNECTION
    {

        public static SqlConnection CONN()
        {
            SqlConnection sql = new SqlConnection(Properties.Settings.Default.CONN);
            sql.Open();

            return sql;
        }
        public Form activeform = null;
        //public void openchildform(Form childform)
        //{
        //    Dashboard dashboard = new Dashboard();

        //    if (activeform != null)
        //        activeform.Close();
        //    activeform = childform;
        //    childform.TopLevel = false;
        //    childform.FormBorderStyle = FormBorderStyle.None;
        //    childform.Dock = DockStyle.Fill;
        //    dashboard.panel1.Controls.Add(childform);
        //    dashboard.panel1.Tag = childform;
        //    childform.BringToFront();
        //    childform.Show();
        //}



    }

}
