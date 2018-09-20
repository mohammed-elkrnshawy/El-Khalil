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
    public partial class Bank : Form
    {
        public Bank()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            All_Transaction();
            CalcolateTotal();
            FillCustomerAccount();
        }

        private void All_Transaction()
        {
            SqlConnection con;

            SqlDataReader dataReader = Ezzat.GetDataReader("_AllBankTransaction_During", out con,
            new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
            new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())));


            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[0].ToString();
                    dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[6].ToString();
                    dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader[1].ToString();
                    dataGridView1[3, dataGridView1.Rows.Count - 1].Value = dataReader[2].ToString();
                    dataGridView1[4, dataGridView1.Rows.Count - 1].Value = (double.Parse(dataReader[1].ToString()) - double.Parse(dataReader[2].ToString()));
                    dataGridView1[5, dataGridView1.Rows.Count - 1].Value = dataReader[3].ToString();
                    dataGridView1[6, dataGridView1.Rows.Count - 1].Value = dataReader[5].ToString();
                    dataGridView1[7, dataGridView1.Rows.Count - 1].Value = dataReader[4].ToString();
                }
            }

            con.Close();
        }
        private void CalcolateTotal()
        {
            double Total = 0, debit = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Total += double.Parse(item.Cells[2].Value.ToString());
                debit += double.Parse(item.Cells[3].Value.ToString());
            }

            label8.Text = Total + "";
            label9.Text = debit + "";
            label10.Text = (Total - debit) + "";
        }
        private void FillCustomerAccount()
        {
            dataGridView2.Rows.Clear();
            SqlConnection con;
            SqlDataReader dr, dr1;
            dr = Ezzat.GetDataReader("select_Banks", out con);


            if (dr.HasRows)
            {
                object o;
                while (dr.Read())
                {


                    dr1 = Ezzat.GetDataReader("sum_BankDuring", out con
                                  , new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString()))
                                  , new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString()))
                                  , new SqlParameter("@Customer_ID", dr[0].ToString())
                                  , new SqlParameter("@Customer_Name", dr[1].ToString())
                                  );

                    if (dr1.HasRows)
                    {
                        while (dr1.Read())
                        {
                            dataGridView2.Rows.Add();
                            dataGridView2[0, dataGridView2.Rows.Count - 1].Value = dr1[0].ToString();
                            dataGridView2[1, dataGridView2.Rows.Count - 1].Value = dr1[1].ToString();
                            o = Ezzat.ExecutedScalar("sum_BankDuring_Mayen"
                                  , new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString()))
                                  , new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString()))
                                  , new SqlParameter("@Customer_ID", dr1[0].ToString())
                                  , new SqlParameter("@Customer_Name", dr1[1].ToString())
                                  );
                            if (o == null) o = 0.0000;
                            dataGridView2[2, dataGridView2.Rows.Count - 1].Value = o;
                            o= Ezzat.ExecutedScalar("sum_BankDuring_Dayen"
                                  , new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString()))
                                  , new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString()))
                                  , new SqlParameter("@Customer_ID", dr1[0].ToString())
                                  , new SqlParameter("@Customer_Name", dr1[1].ToString())
                                  );
                            if (o == null) o = 0.0000;
                            dataGridView2[3, dataGridView2.Rows.Count - 1].Value = o; 
                            dataGridView2[4, dataGridView2.Rows.Count - 1].Value = (double.Parse(dr1[3].ToString()) - double.Parse(dr1[2].ToString()));


                            o = Ezzat.ExecutedScalar("Bank_Start", new SqlParameter("@Customer_ID", (int)dr1[0]), new SqlParameter("@Day", dateTimePicker1.Value));
                            if ((o + "").Length == 0) o = 0;
                            dataGridView2[6, dataGridView2.Rows.Count - 1].Value = String.Format("{0:0.00}", o);
                            o = Ezzat.ExecutedScalar("Bank_END", new SqlParameter("@Customer_ID", (int)dr1[0]), new SqlParameter("@Day", dateTimePicker2.Value));
                            if ((o + "").Length == 0) o = 0;
                            dataGridView2[7, dataGridView2.Rows.Count - 1].Value = String.Format("{0:0.00}", o);
                        }
                    }



                }
            }

            con.Close();

        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            Bank_Print print = new Bank_Print(dateTimePicker1.Value,dateTimePicker2.Value);
            print.ShowDialog();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell==dataGridView1.CurrentRow.Cells[8])
            {
                if(dataGridView1.CurrentRow.Cells[7].Value.ToString()=="تسديد الى مورد")
                {
                    ShowDetails_Bank_Supplier showDetails = new ShowDetails_Bank_Supplier(dataGridView1.CurrentRow.Cells[0].Value);
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[7].Value.ToString() == "تسديد من عميل")
                {
                    ShowDetails_Bank_Customer showDetails = new ShowDetails_Bank_Customer(dataGridView1.CurrentRow.Cells[0].Value);
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[7].Value.ToString() == "ايراد من بيع")
                {
                    Show_Details_Purchasing_Customer showDetails = new Show_Details_Purchasing_Customer(dataGridView1.CurrentRow.Cells[0].Value,false);
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[7].Value.ToString() == "دفع من شراء")
                {
                    ShowDetails_Purchasing_Supplier showDetails = new ShowDetails_Purchasing_Supplier(dataGridView1.CurrentRow.Cells[0].Value, true);
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[7].Value.ToString() == "ايراد")
                {
                  
                }
            }
        }

        private void Bank_Load(object sender, EventArgs e)
        {

        }
    }
}
