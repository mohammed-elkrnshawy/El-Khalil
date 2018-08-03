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
    public partial class Form1 : Form
    {
        DataSet dataSet;
        private int Bill_ID;
        private object Bill_Type;

        public Form1(int Bill_ID,object Bill_Type)
        {
            InitializeComponent();
            this.Bill_ID = Bill_ID;
            if (Bill_Type.Equals("شراء"))
                this.Bill_Type = true;
            else
                this.Bill_Type = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("select_Supplier_BillDetails", "X",new SqlParameter("@Bill_ID", Bill_ID),new SqlParameter("@Bill_Type", Bill_Type)))
            {
                dataGridView1.DataSource = dataSet.Tables["X"];
            }
        }
    }
}
