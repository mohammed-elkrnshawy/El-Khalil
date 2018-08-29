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
    public partial class Bank_BillDetaails : Form
    {
        DataSet ds;
        private int Bill_ID;
        private object Bill_Type, Bill_Details;

        public Bank_BillDetaails(int Bill_ID, object Bill_Type, object Bill_Details)
        {
            InitializeComponent();
            this.Bill_ID = Bill_ID;
            this.Bill_Type = Bill_Type;
            this.Bill_Details = Bill_Details;
        }

        private void Bank_BillDetaails_Load(object sender, EventArgs e)
        {

            if (Bill_Type.ToString().Contains("بيع"))
            {
                panel4.Visible =panel5.Visible= false;
                using (ds = Ezzat.GetDataSet("select_Customer_BillDetails", "X",
                    new SqlParameter("@Bill_ID", Bill_ID),
                    new SqlParameter("@Bill_Type", false)))
                {
                    dataGridView1.DataSource = ds.Tables["X"];
                }


                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Purchasing", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label2.Text = dataReader[0].ToString();
                        label12.Text = dataReader[2].ToString();
                        tb_BillTotal.Text = dataReader[4].ToString();
                        tb_Discount.Text = dataReader[5].ToString();
                        tb_AfterDiscount.Text = dataReader[6].ToString();
                        tb_OldMoney.Text = dataReader[7].ToString();
                        tb_Total.Text = dataReader[8].ToString();
                        tb_payment.Text = dataReader[9].ToString();
                        tb_render.Text = dataReader[10].ToString();
                        textBox1.Text = dataReader[3].ToString();
                        textBox2.Text = dataReader[12].ToString();
                        tb_owner.Text = dataReader[13].ToString();
                        richTextBox1.Text = Bill_Details.ToString();
                    }
                }

                con.Close();


            }
            else if (Bill_Type.ToString().Contains("صرف من مرتجع عميل"))
            {
                label11.Visible = label3.Visible = tb_render.Visible = textBox2.Visible = false;
                panel5.Visible = false;
                using (ds = Ezzat.GetDataSet("select_Customer_BillDetails", "X",
                     new SqlParameter("@Bill_ID", Bill_ID),
                     new SqlParameter("@Bill_Type", true)))
                {
                    dataGridView1.DataSource = ds.Tables["X"];
                }

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Returning", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label2.Text = dataReader[0].ToString();
                        label12.Text = dataReader[2].ToString();
                        tb_BillTotal.Text = dataReader[4].ToString();
                        tb_Discount.Text = dataReader[5].ToString();
                        tb_AfterDiscount.Text = dataReader[6].ToString();
                        tb_OldMoney.Text = dataReader[7].ToString();
                        tb_Total.Text = dataReader[8].ToString();
                        tb_payment.Text = dataReader[9].ToString();
                        textBox1.Text = dataReader[3].ToString();
                        tb_owner.Text = dataReader[11].ToString();
                        richTextBox1.Text = Bill_Details.ToString();
                    }
                }

                con.Close();

            }
            else if (Bill_Type.ToString().Contains("تسديد من عميل"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Bank", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label21.Text = dataReader[0].ToString();
                        label16.Text = dataReader[2].ToString();
                        tb_old.Text = dataReader[4].ToString();
                        tb_pay.Text = dataReader[5].ToString();
                        tb_after.Text = dataReader[6].ToString();
                        richTextBox2.Text = dataReader[7].ToString();
                        textBox4.Text = dataReader[8].ToString();
                        textBox3.Text = dataReader[9].ToString();
                    }
                }

                con.Close();

            }
            else if (Bill_Type.ToString().Contains("شراء"))
            {
                panel5.Visible = false;
                using (ds = Ezzat.GetDataSet("select_Supplier_BillDetails", "X",
                    new SqlParameter("@Bill_ID", Bill_ID),
                    new SqlParameter("@Bill_Type", true)))
                {
                    dataGridView1.DataSource = ds.Tables["X"];
                }


                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Purchasing", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label2.Text = dataReader[0].ToString();
                        label12.Text = dataReader[2].ToString();
                        tb_BillTotal.Text = dataReader[4].ToString();
                        tb_Discount.Text = dataReader[5].ToString();
                        tb_AfterDiscount.Text = dataReader[6].ToString();
                        tb_OldMoney.Text = dataReader[7].ToString();
                        tb_Total.Text = dataReader[8].ToString();
                        tb_payment.Text = dataReader[9].ToString();
                        tb_render.Text = dataReader[10].ToString();
                        textBox1.Text = dataReader[3].ToString();
                        textBox2.Text = dataReader[11].ToString();
                        tb_number.Text = dataReader[12].ToString();
                        tb_owner.Text = dataReader[13].ToString();
                    }
                }

                con.Close();


            }
            else if (Bill_Type.ToString().Contains("تسديد الى مورد"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Bank", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label21.Text = dataReader[0].ToString();
                        label16.Text = dataReader[2].ToString();
                        tb_old.Text = dataReader[4].ToString();
                        tb_pay.Text = dataReader[5].ToString();
                        tb_after.Text = dataReader[6].ToString();
                        richTextBox1.Text = dataReader[7].ToString();
                        tb_number.Text = dataReader[8].ToString();
                        textBox4.Text = dataReader[9].ToString();
                        textBox3.Text = dataReader[10].ToString();
                    }
                }

                con.Close();

            }

        }
    }
}
