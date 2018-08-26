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
    public partial class Store_BillDetails : Form
    {
        DataSet dataSet;
        string Bill_ID, Bill_State, Bill_Type,Bill_Details;
        public Store_BillDetails(string Bill_ID, string Bill_State, string Bill_Type,string Bill_Details)
        {
            InitializeComponent();
            this.Bill_ID = Bill_ID;
            this.Bill_State = Bill_State;
            this.Bill_Type = Bill_Type;
            this.Bill_Details = Bill_Details;
        }

        private void Store_BillDetails_Load(object sender, EventArgs e)
        {
            if (Bill_State.Contains("توريد"))
            {
                if (Bill_Type.ToString().Contains("شراء"))
                {

                    using (dataSet = Ezzat.GetDataSet("select_Supplier_BillDetails", "X",
                        new SqlParameter("@Bill_ID", Bill_ID),
                        new SqlParameter("@Bill_Type", true)))
                    {
                        dataGridView1.DataSource = dataSet.Tables["X"];
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
                else if (Bill_Type.ToString().Contains("مرتجع"))
                {
                    label11.Visible = label3.Visible = tb_render.Visible = textBox2.Visible=tb_number.Visible=label15.Visible = false;
                    using (dataSet = Ezzat.GetDataSet("select_Customer_BillDetails", "X",
                         new SqlParameter("@Bill_ID", Bill_ID),
                         new SqlParameter("@Bill_Type", true)))
                    {
                        dataGridView1.DataSource = dataSet.Tables["X"];
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
                            richTextBox1.Text = Bill_Details+"";
                        }
                    }

                    con.Close();

                }
            }
            else if (Bill_State.Contains("صادر"))
            {
                if (Bill_Type.ToString().Contains("بيع"))
                {
                    tb_number.Visible = label15.Visible = false;
                    using (dataSet = Ezzat.GetDataSet("select_Customer_BillDetails", "X",
                        new SqlParameter("@Bill_ID", Bill_ID),
                        new SqlParameter("@Bill_Type", false)))
                    {
                        dataGridView1.DataSource = dataSet.Tables["X"];
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
                            richTextBox1.Text = Bill_Details+"";
                        }
                    }

                    con.Close();


                }
                else if (Bill_Type.ToString().Contains("مرتجع"))
                {
                    label10.Visible = label11.Visible = label14.Visible = label3.Visible = tb_payment.Visible = tb_render.Visible = textBox1.Visible = textBox2.Visible = false;

                    using (dataSet = Ezzat.GetDataSet("select_Supplier_BillDetails", "X",
                         new SqlParameter("@Bill_ID", Bill_ID),
                         new SqlParameter("@Bill_Type", false)))
                    {
                        dataGridView1.DataSource = dataSet.Tables["X"];
                    }

                    SqlConnection con;

                    SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Returning", out con,
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
                            tb_number.Text = dataReader[10].ToString();
                            tb_owner.Text = dataReader[11].ToString();
                        }
                    }

                    con.Close();

                }
            }
        }
    }
}
