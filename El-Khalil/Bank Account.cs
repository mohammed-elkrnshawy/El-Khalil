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
    public partial class Bank_Account : Form
    {
        DataSet dataSet;
        public Bank_Account()
        {
            InitializeComponent();
        }

        private void RefreshForm()
        {
            using (dataSet = Ezzat.GetDataSet("select_Banks", "X"))
            {
                combo_Bank.DataSource = dataSet.Tables["X"];
                combo_Bank.DisplayMember = "Bank_Name";
                combo_Bank.ValueMember = "Bank_ID";
                combo_Bank.Text = "";
                combo_Bank.SelectedText = "اختار اسم بنك";
            }
        }

        private void Bank_Transaction_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            if(combo_Bank.SelectedIndex>=0)
            {
                dataGridView1.Rows.Clear();
                All_Transaction();
                CalcolateTotal();
                object o = Ezzat.ExecutedScalar("selectTotalMoney_Bank", new SqlParameter("@Supplier_ID", (int)combo_Bank.SelectedValue));
                label11.Text = String.Format("{0:0.00}", o);
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void All_Transaction()
        {
                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("_BankTransaction_During", out con,
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
                new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())),
                new SqlParameter("@BankID", combo_Bank.SelectedValue));


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[0].ToString();
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[1].ToString();
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader[2].ToString();
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = (double.Parse(dataReader[1].ToString()) - double.Parse(dataReader[2].ToString()));
                        dataGridView1[4, dataGridView1.Rows.Count - 1].Value = dataReader[3].ToString();
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value = dataReader[5].ToString();
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = dataReader[4].ToString();
                    }
                }

                con.Close();

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[7] == dataGridView1.CurrentCell)
            {
                if (dataGridView1.CurrentRow.Cells[6].Value.ToString() != "ايداع الى البنك")
                {
                    Bank_BillDetaails BillDetails = new Bank_BillDetaails(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())
                                                                                 , dataGridView1.CurrentRow.Cells[6].Value
                                                                                 , dataGridView1.CurrentRow.Cells[5].Value
                                                                                 );
                    BillDetails.ShowDialog();
                }
            }
        }

        private void bt_Print_Click(object sender, EventArgs e)
        {
            if(combo_Bank.SelectedIndex>=0)
            {
                Bank_Account_Printcs print = new Bank_Account_Printcs(
                dateTimePicker1.Value,
                dateTimePicker2.Value,
                (int)combo_Bank.SelectedValue,
            combo_Bank.Text
                );
                print.ShowDialog();
            }
        }
    }
}
