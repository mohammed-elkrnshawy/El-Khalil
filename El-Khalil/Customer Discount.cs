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
    public partial class Customer_Discount : Form
    {
        DataSet dataSet;

        public Customer_Discount()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void Customer_Discount_Load(object sender, EventArgs e)
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);


            using (dataSet = Ezzat.GetDataSet("select_AllCustomer", "X"))
            {
                combo_Customer.DataSource = dataSet.Tables["X"];
                combo_Customer.DisplayMember = "Customer_Name";
                combo_Customer.ValueMember = "Customer_ID";
                combo_Customer.Text = "";
                combo_Customer.SelectedText = "اختار اسم العميل";
            }

            object o = Ezzat.ExecutedScalar("selectEXDiscount_Bill_ID");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (combo_Customer.Text != "" && double.Parse(tb_payment.Text) > 0 && double.Parse(tb_AfterPayment.Text) >= 0)
            {
                Save();
            }
        }

        private void combo_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Customer.Focused)
            {
                object o = Ezzat.ExecutedScalar("selectTotalMoney_Customer", new SqlParameter("@Supplier_ID", (int)combo_Customer.SelectedValue));
                tb_OldMoney.Text = String.Format("{0:0.00}", o);
                Calcolate();
            }
        }
        private void Calcolate()
        {
            tb_AfterPayment.Text = String.Format("{0:0.00}", (double.Parse(tb_OldMoney.Text) - double.Parse(tb_payment.Text)));
        }

        private void tb_payment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tb_payment.Text.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tb_payment_TextChanged(object sender, EventArgs e)
        {
            if (tb_payment.Text == ".")
                tb_payment.Text = "0.";
            if (tb_payment.Text == "")
                tb_payment.Text = "0";
            Calcolate();
        }

        private void tb_payment_Leave(object sender, EventArgs e)
        {
            tb_payment.Text = String.Format("{0:0.00}", (double.Parse(tb_payment.Text)));
        }



        private void Save()
        {

            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney_Customer", new SqlParameter("@Supplier_ID",
                (int)combo_Customer.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_AfterPayment.Text)));


            // اضافة بيان خصم
            // اضافة تعامل ف التعاملات مع الموردين .... نوعه خصم

            Ezzat.ExecutedNoneQuery("insertEXDiscout_Bill",
                new SqlParameter("@Report_ID", label2.Text),
                new SqlParameter("@Supplier_ID", combo_Customer.SelectedValue),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Total_Money", float.Parse(tb_OldMoney.Text)),
                new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@After_Payment", float.Parse(tb_AfterPayment.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );



        }
    }
}
