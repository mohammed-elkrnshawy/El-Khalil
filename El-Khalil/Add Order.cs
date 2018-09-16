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
    public partial class Add_Order : Form
    {
        DataSet dataSet;
        public Add_Order()
        {
            InitializeComponent();
        }

        private void RefreshForm()
        {
            
            using (dataSet = Ezzat.GetDataSet("selectAllCustomer", "X"))
            {
                combo_Supliers.DataSource = dataSet.Tables["X"];
                combo_Supliers.DisplayMember = "Customer_Name";
                combo_Supliers.ValueMember = "Customer_ID";
                combo_Supliers.Text = "";
                combo_Supliers.SelectedText = "اختار اسم العميل";
            }

           

            richTextBox1.Text = "تفاصيل الفاتورة";
          

        }

        private void Add_Order_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ezzat.ExecutedNoneQuery("insert_Order",
                                    new SqlParameter("@Customer_id",combo_Supliers.SelectedValue),
                                    new SqlParameter("@Customer_Name",combo_Supliers.Text),
                                    new SqlParameter("@OrderDate",dateTimePicker1.Value),
                                    new SqlParameter("@Details",richTextBox1.Text)
                                    );
            MessageBox.Show(Shared_Class.Successful_Message);
            RefreshForm();
        }
    }
}
