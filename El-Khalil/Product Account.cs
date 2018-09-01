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
    public partial class Product_Account : Form
    {
        DataSet ds;
        public Product_Account()
        {
            InitializeComponent();
        }

        private void RefrshForm()
        {
            using (ds=Ezzat.GetDataSet("Select_All", "X"))
            {
                comboProduct.DataSource = ds.Tables["X"];
                comboProduct.DisplayMember = "اسم الصنف";
                comboProduct.ValueMember = "رفم الصنف";
                comboProduct.Text = "";
                comboProduct.SelectedText = "اختار اسم الصنف";
            }
        }

        private void Product_Account_Load(object sender, EventArgs e)
        {
            RefrshForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboProduct.SelectedIndex>=0)
            {
                getAllTransactions();
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }

        private void getAllTransactions()
        {
            
            using (ds = Ezzat.GetDataSet("_ProductTransaction_DUring", "X"
                , new SqlParameter("@Day", dateTimePicker1.Value)
                , new SqlParameter("@Day2", dateTimePicker2.Value)
                , new SqlParameter("@product_ID", comboProduct.SelectedValue)))
            {
                dataGridView1.DataSource = ds.Tables["X"];
                dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}
