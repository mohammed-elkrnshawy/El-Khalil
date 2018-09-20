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
    public partial class ShowDetails_Bank_Customer : Form
    {
        object id;
        public ShowDetails_Bank_Customer(object ID)
        {
            InitializeComponent();
            id = ID;
        }

        private void ShowDetails_Bank_Customer_Load(object sender, EventArgs e)
        {
            SqlConnection con;

            SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Bank", out con,
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
                    l_num.Text = dataReader[8].ToString();
                    l_name.Text = dataReader[10].ToString();
                    l_bank.Text = dataReader[11].ToString();
                }
            }

            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customrt_Payback_Print report = new Customrt_Payback_Print
                    (l_name.Text, richTextBox1.Text, double.Parse(tb_OldMoney.Text), double.Parse(tb_payment.Text), int.Parse(l_id.Text), l_type.Text);
            report.ShowDialog();
        }
    }
}
