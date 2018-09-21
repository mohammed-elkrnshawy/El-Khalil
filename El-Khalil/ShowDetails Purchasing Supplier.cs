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
    public partial class ShowDetails_Purchasing_Supplier : Form
    {
        private DataSet dataSet;
        private object id;
        private bool Ty;
        public ShowDetails_Purchasing_Supplier(object ID,bool ty)
        {
            InitializeComponent();
            id = ID;
            Ty = ty;
        }

        private void ShowDetails_Purchasing_Supplier_Load(object sender, EventArgs e)
        {
            SqlConnection con;
            using (dataSet = Ezzat.GetDataSet("select_Supplier_BillDetails", "X",
                 new SqlParameter("@Bill_ID", id),
                 new SqlParameter("@Bill_Type", Ty)))
            {
                dataGridView1.DataSource = dataSet.Tables["X"];
            }

            if (Ty)
            {
                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Purchasing", out con,
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
                        textBox2.Text = dataReader[11].ToString();
                        tb_number.Text = dataReader[12].ToString();
                        tb_owner.Text = dataReader[13].ToString();
                    }
                }

                con.Close();
            }
            else if(!Ty)
            {
                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Returning", out con,
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
                        tb_number.Text = dataReader[10].ToString();
                        tb_owner.Text = dataReader[11].ToString();
                    }
                }

                con.Close();
            }
         


            

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Ty)
            {
                Supplier_Purchasing_Print print = new Supplier_Purchasing_Print(int.Parse(label2.Text),
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
            else if (Ty==false)
            {
                Supplier_Purchasing_Print print = new Supplier_Purchasing_Print(int.Parse(label2.Text),
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
        }
    }
}
