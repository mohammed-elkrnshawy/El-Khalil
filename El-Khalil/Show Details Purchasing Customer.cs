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
    public partial class Show_Details_Purchasing_Customer : Form
    {
        object id;
        bool Bill_Type;
        private DataSet dataSet;

        public Show_Details_Purchasing_Customer(object ID,bool bt)
        {
            InitializeComponent();
            id = ID;
            Bill_Type = bt;
        }

        private void Show_Details_Purchasing_Customer_Load(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("select_Customer_BillDetails2", "X",
                    new SqlParameter("@Bill_ID", id),
                    new SqlParameter("@Bill_Type", Bill_Type)))
            {
                dataGridView1.DataSource = dataSet.Tables["X"];
            }
            SqlConnection con;

            if (!Bill_Type)
            {

                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Purchasing", out con,
                new SqlParameter("@Bill_ID", id));

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
                        richTextBox1.Text = dataReader[14].ToString();
                    }
                }

                con.Close();
            }
            else if(Bill_Type)
            {
                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Returning", out con,
               new SqlParameter("@Bill_ID", id));

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
                        richTextBox1.Text = dataReader[12].ToString();
                    }
                }

                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Bill_Type==false)
            {
                Customer_Purcahsing_Print print = new Customer_Purcahsing_Print(int.Parse(label2.Text),
                                                                 tb_owner.Text,
                                                                 richTextBox1.Text,
                                                                 double.Parse(tb_BillTotal.Text),
                                                                 double.Parse(tb_Discount.Text),
                                                                 double.Parse(tb_OldMoney.Text),
                                                                 double.Parse(tb_payment.Text),
                                                                 false
                                                                 );
                print.ShowDialog();
            }
            else if (Bill_Type==true)
            {
                Customer_Purcahsing_Print print = new Customer_Purcahsing_Print(int.Parse(label2.Text),
                                                                 tb_owner.Text,
                                                                 richTextBox1.Text,
                                                                 double.Parse(tb_BillTotal.Text),
                                                                 double.Parse(tb_Discount.Text),
                                                                 double.Parse(tb_OldMoney.Text),
                                                                 double.Parse(tb_payment.Text),
                                                                 true
                                                                 );
                print.ShowDialog();
            }
        }
    }
}
