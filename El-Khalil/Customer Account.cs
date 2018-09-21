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

        private void All_Transaction()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (combo_Customer.SelectedIndex >= 0)
            {
                dataGridView1.Rows.Clear();
                All_Transaction();
                CalcolateTotal();
                object o = Ezzat.ExecutedScalar("selectTotalMoney_Customer", new SqlParameter("@Supplier_ID", (int)combo_Customer.SelectedValue));
                if ((o + "").Length == 0) o = 0;
                label11.Text = String.Format("{0:0.00}", o);
                o = Ezzat.ExecutedScalar("customer_Start", new SqlParameter("@Customer_ID", (int)combo_Customer.SelectedValue), new SqlParameter("@Day", dateTimePicker1.Value));
                if ((o + "").Length == 0) o = 0;
                label5.Text = String.Format("{0:0.00}", o);
                o = Ezzat.ExecutedScalar("customer_End", new SqlParameter("@Customer_ID", (int)combo_Customer.SelectedValue), new SqlParameter("@Day", dateTimePicker2.Value));
                if ((o + "").Length == 0) o = 0;
                label1.Text = String.Format("{0:0.00}", o);

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
            if (dataGridView1.CurrentCell == dataGridView1.CurrentRow.Cells[7])
            {
                if (dataGridView1.CurrentRow.Cells[6].Value.ToString().Contains("بيع"))
                {
                    Show_Details_Purchasing_Customer showDetails = new Show_Details_Purchasing_Customer(dataGridView1.CurrentRow.Cells[0].Value, false);
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[6].Value.ToString().Contains("مرتجع"))
                {
                    Show_Details_Purchasing_Customer showDetails = new Show_Details_Purchasing_Customer(dataGridView1.CurrentRow.Cells[0].Value, true);
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "تحويل بنكى")
                {
                    ShowDetails_Bank_Customer showDetails = new ShowDetails_Bank_Customer(dataGridView1.CurrentRow.Cells[0].Value);
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "تسديد نقدى")
                {
                    ShowDetails_Payback_Customer showDetails = new ShowDetails_Payback_Customer(dataGridView1.CurrentRow.Cells[0].Value, dataGridView1.CurrentRow.Cells[6].Value);
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "خصم")
                {
                    ShowDetails_Payback_Customer showDetails = new ShowDetails_Payback_Customer(dataGridView1.CurrentRow.Cells[0].Value, dataGridView1.CurrentRow.Cells[6].Value);
                    showDetails.ShowDialog();
                }
            }
        }

        private void bt_Print_Click(object sender, EventArgs e)
        {
            if (combo_Customer.SelectedIndex >= 0)
            {
                Customer_Account_Print print = new Customer_Account_Print(
                    dateTimePicker1.Value,
                    dateTimePicker2.Value,
                    (int)combo_Customer.SelectedValue,
                    double.Parse(label5.Text),
                    double.Parse(label1.Text),
                    double.Parse(label11.Text),
                    combo_Customer.Text
                    );
                print.ShowDialog();
            }
        }
    }
}