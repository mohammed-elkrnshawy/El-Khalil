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
    public partial class Customer_Account : Form
    {
        DataSet dataSet;
        public Customer_Account()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void Customer_Account_Load(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("select_AllCustomer", "X"))
            {
                combo_Customer.DataSource = dataSet.Tables["X"];
                combo_Customer.DisplayMember = "Customer_Name";
                combo_Customer.ValueMember = "Customer_ID";
                combo_Customer.Text = "";
                combo_Customer.SelectedText = "اختار اسم المشترى";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                pn_today.Visible = true;
                panel5.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                pn_today.Visible = false;
                panel5.Visible = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                pn_today.Visible = false;
                panel5.Visible = false;
            }
        }

        private void combo_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Customer.Focused)
            {
                if (radioButton5.Checked)
                    Purchasing_Transaction();
                else if (radioButton4.Checked)
                    Payback_Transaction();
                if (radioButton7.Checked)
                    Returning_Transaction();
                if (radioButton6.Checked)
                    All_Transaction();

            }
        }




        private void Purchasing_Transaction()
        {
            if (radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_PurchasingTransaction_Day", "X",
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())), new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_PurchasingTransaction_During", "X",
               new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
               new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())),
               new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_PurchasingTransaction_All", "X",
              new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void Payback_Transaction()
        {
            if (radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_PaybackTransaction_Day", "X",
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())), new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_PaybackTransaction_During", "X",
               new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
               new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())),
               new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_PaybackTransaction_All", "X",
              new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void Returning_Transaction()
        {
            if (radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_ReturningTransaction_Day", "X",
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())), new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_ReturningTransaction_During", "X",
               new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
               new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())),
               new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_RetutningTransaction_All", "X",
              new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void All_Transaction()
        {
            if (radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_SupplierTransaction_Day", "X",
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())), new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_SupplierTransaction_During", "X",
               new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
               new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())),
               new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("_Customer_SupplierTransaction_All", "X",
              new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
        }

    }
}
