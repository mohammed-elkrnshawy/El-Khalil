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
    public partial class ShowDetails_Payback_Supplier : Form
    {
        object id,type;
        public ShowDetails_Payback_Supplier(object ID,object TYPE)
        {
            InitializeComponent();
            id = ID;
            type = TYPE;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier_Payback_Print report = new Supplier_Payback_Print
                     (l_name.Text, richTextBox1.Text, double.Parse(tb_OldMoney.Text), double.Parse(tb_payment.Text), int.Parse(l_id.Text),type.ToString());
            report.ShowDialog();
        }

        private void ShowDetails_Payback_Supplier_Load(object sender, EventArgs e)
        {
            l_type.Text = type.ToString();
            if (type.ToString().Contains("تسديد"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Payback", out con,
                new SqlParameter("@Bill_ID", id));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        l_id.Text = dataReader[0].ToString();
                        l_date.Text = dataReader[2].ToString();
                        tb_OldMoney.Text = dataReader[4].ToString();
                        tb_payment.Text = dataReader[5].ToString();
                        tb_AfterPayment.Text = dataReader[6].ToString();
                        richTextBox1.Text = dataReader[7].ToString();
                        label2.Text = dataReader[8].ToString();
                        l_name.Text = dataReader[11].ToString();
                    }
                }

                con.Close();

            }
            else if (type.ToString().Contains("خصم"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Discount", out con,
                new SqlParameter("@Bill_ID", id));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        l_id.Text = dataReader[0].ToString();
                        l_date.Text = dataReader[2].ToString();
                        tb_OldMoney.Text = dataReader[3].ToString();
                        tb_payment.Text = dataReader[4].ToString();
                        tb_AfterPayment.Text = dataReader[5].ToString();
                        richTextBox1.Text = dataReader[6].ToString();
                        label2.Text = dataReader[7].ToString();
                        l_name.Text = dataReader[8].ToString();
                    }
                }

                con.Close();

            }
        }
    }
}
