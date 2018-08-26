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
                pn_during.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                pn_today.Visible = false;
                pn_during.Visible = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                pn_today.Visible = false;
                pn_during.Visible = false;
            }
        }

       

        private void All_Transaction()
        {


            if (radioButton1.Checked)
            {
                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("_Customer_SupplierTransaction_Day", out con,
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())), new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[0].ToString();
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[1].ToString();
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader[2].ToString();
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = (double.Parse(dataReader[2].ToString()) - double.Parse(dataReader[1].ToString()));
                        dataGridView1[4, dataGridView1.Rows.Count - 1].Value = dataReader[3].ToString();
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value = dataReader[5].ToString();
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = dataReader[4].ToString();
                    }
                }

                con.Close();


            }
            else if (radioButton2.Checked)
            {
                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("_Customer_SupplierTransaction_During", out con,
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
                new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())),
                new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue));


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[0].ToString();
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[1].ToString();
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader[2].ToString();
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = (double.Parse(dataReader[2].ToString()) - double.Parse(dataReader[1].ToString()));
                        dataGridView1[4, dataGridView1.Rows.Count - 1].Value = dataReader[3].ToString();
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value = dataReader[5].ToString();
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = dataReader[4].ToString();
                    }
                }

                con.Close();


            }
            else
            {
                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("_Customer_SupplierTransaction_All", out con,
              new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[0].ToString();
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[1].ToString();
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader[2].ToString();
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = (double.Parse(dataReader[2].ToString()) - double.Parse(dataReader[1].ToString()));
                        dataGridView1[4, dataGridView1.Rows.Count - 1].Value = dataReader[3].ToString();
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value = dataReader[5].ToString();
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = dataReader[4].ToString();
                    }
                }

                con.Close();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combo_Customer.SelectedIndex >= 0)
            {
                dataGridView1.Rows.Clear();
                All_Transaction();
                CalcolateTotal();
                object o = Ezzat.ExecutedScalar("selectTotalMoney_Customer", new SqlParameter("@Supplier_ID", (int)combo_Customer.SelectedValue));
                label11.Text = String.Format("{0:0.00}", o);
            }
        }

        private void CalcolateTotal()
        {
            double Total = 0, debit = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Total += double.Parse(item.Cells[1].Value.ToString());
                debit += double.Parse(item.Cells[2].Value.ToString());
            }

            label8.Text = Total + "";
            label9.Text = debit + "";
            label10.Text = (Total - debit) + "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell==dataGridView1.CurrentRow.Cells[7])
            {
                Customer_BillDetails BillDetails = new Customer_BillDetails(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())
                                                                             , dataGridView1.CurrentRow.Cells[6].Value
                                                                             ,dataGridView1.CurrentRow.Cells[5].Value
                                                                             );
                BillDetails.ShowDialog();
            }
        }
    }
}
