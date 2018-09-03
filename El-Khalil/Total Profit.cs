using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Khalil
{
    public partial class Total_Profit : Form
    {
        DataSet ds;
        public Total_Profit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Total_Sup();
            Total_Cus();
            Total_Out();
        }

        private void Total_Sup()
        {
            using (ds=Ezzat.GetDataSet("_TotalSup","X",new SqlParameter("@Day",dateTimePicker1.Value), new SqlParameter("@Day2", dateTimePicker2.Value)))
            {
                dgw_Supplier.DataSource = ds.Tables["X"];
            }
        }
        private void Total_Cus()
        {
            using (ds = Ezzat.GetDataSet("_TotalCus", "X", new SqlParameter("@Day", dateTimePicker1.Value), new SqlParameter("@Day2", dateTimePicker2.Value)))
            {
                dgv_Cus.DataSource = ds.Tables["X"];
            }
        }
        private void Total_Out()
        {
            using (ds = Ezzat.GetDataSet("_TotalOut", "X", new SqlParameter("@Day", dateTimePicker1.Value), new SqlParameter("@Day2", dateTimePicker2.Value)))
            {
                dgv_Out.DataSource = ds.Tables["X"];
            }
        }
    }
}
