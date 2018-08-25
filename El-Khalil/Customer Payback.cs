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
    public partial class Customer_Payback : Form
    {
        DataSet dataSet;
        public Customer_Payback()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void RefreshForm()
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);


            using (dataSet = Ezzat.GetDataSet("selectAllCustomer", "X"))
            {
                combo_Supliers.DataSource = dataSet.Tables["X"];
                combo_Supliers.DisplayMember = "Customer_Name";
                combo_Supliers.ValueMember = "Customer_ID";
                combo_Supliers.Text = "";
                combo_Supliers.SelectedText = "اختار اسم العميل";
            }

            panel3.Visible = false;
            tb_Number.Text = richTextBox1.Text = "";

            tb_AfterPayment.Text = tb_OldMoney.Text = tb_payment.Text = "0.00";



        }

        private void Customer_Payback_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void LoadPayback()
        {
            object o = Ezzat.ExecutedScalar("selectBayback_Bill_ID_Customer");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";
            panel3.Visible = false;

        }

        private void LoadDiscount()
        {
            object o = Ezzat.ExecutedScalar("selectEXDiscount_Bill_ID");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";
        }

        private void LoadBank()
        {
            object o = Ezzat.ExecutedScalar("selectBayback_Bill_ID_Customer");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";

            panel3.Visible = true;
            using (dataSet = Ezzat.GetDataSet("select_Banks", "X"))
            {
                combo_Bank.DataSource = dataSet.Tables["X"];
                combo_Bank.DisplayMember = "Bank_Name";
                combo_Bank.ValueMember = "Bank_ID";
                combo_Bank.Text = "";
                combo_Bank.SelectedText = "اختار بنك للايداع";
            }
        }

        private void combo_Supliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Supliers.Focused)
            {
                object o = Ezzat.ExecutedScalar("selectTotalMoney_Customer", new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue));
                tb_OldMoney.Text = String.Format("{0:0.00}", o);
                Calcolate();
            }
        }

        private void Calcolate()
        {
            tb_AfterPayment.Text = String.Format("{0:0.00}", (double.Parse(tb_OldMoney.Text) - double.Parse(tb_payment.Text)));
        }

        private void tb_payment_TextChanged(object sender, EventArgs e)
        {
            if (tb_payment.Text == ".")
                tb_payment.Text = "0.";
            if (tb_payment.Text == "")
                tb_payment.Text = "0";
            Calcolate();
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

        private void tb_payment_Leave(object sender, EventArgs e)
        {
            tb_payment.Text = String.Format("{0:0.00}", (double.Parse(tb_payment.Text)));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Focused)
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    LoadPayback();
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    LoadBank();
                }
                else if (comboBox1.SelectedIndex == 0)
                {
                    LoadDiscount();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 1)
            {
                SavePaypack();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                SaveBank();
            }
            else if (comboBox1.SelectedIndex == 0)
            {
                SaveDiscount();
            }
            RefreshForm();
        }

        private void SavePaypack()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney_Customer", new SqlParameter("@Supplier_ID",
                (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_AfterPayment.Text)));


            // اضافة بيان تسديد الى مورد 
            // اضافة تعامل ف التعاملات مع الموردين .... نوعه تسديد

            Ezzat.ExecutedNoneQuery("insertEXPayback_Bill",
                 new SqlParameter("@Report_ID", label2.Text),
                 new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue),
                 new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                 new SqlParameter("@Payment_Method", "نقدى"),
                 new SqlParameter("@Total_Money", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                 new SqlParameter("@After_Payment", float.Parse(tb_AfterPayment.Text)),
                 new SqlParameter("@Report_Notes", richTextBox1.Text)
                 );

            EditSafe();

            MessageBox.Show(Shared_Class.Successful_Message);
        }

        private void EditSafe()
        {
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Increase", new SqlParameter("@Money_Quantity", float.Parse(tb_payment.Text)));

            // عمل بيان ايراد من الخزنة للعميل
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "تسديد من عميل"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@Report_Notes", "مبلغ من تسديد عميل " + richTextBox1.Text)
                );
        }

        private void SaveDiscount()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney_Customer", new SqlParameter("@Supplier_ID",
                (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_AfterPayment.Text)));


            // اضافة بيان خصم
            // اضافة تعامل ف التعاملات مع الموردين .... نوعه خصم

            Ezzat.ExecutedNoneQuery("insertEXDiscout_Bill",
               new SqlParameter("@Report_ID", label2.Text),
               new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue),
               new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
               new SqlParameter("@Total_Money", float.Parse(tb_OldMoney.Text)),
               new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
               new SqlParameter("@After_Payment", float.Parse(tb_AfterPayment.Text)),
               new SqlParameter("@Report_Notes", richTextBox1.Text)
               );

            MessageBox.Show(Shared_Class.Successful_Message);
        }

        private void SaveBank()
        {
            Edit_BankAccount();

            Edit_CustomerAccount();

            MessageBox.Show(Shared_Class.Successful_Message);
        }

        private void Edit_CustomerAccount()
        {

            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney_Customer", new SqlParameter("@Supplier_ID",
                (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_AfterPayment.Text)));


            // اضافة بيان تسديد الى مورد 
            // اضافة تعامل ف التعاملات مع الموردين .... نوعه تسديد

            Ezzat.ExecutedNoneQuery("insertEXBankPayback_Bill",
                new SqlParameter("@Report_ID", label2.Text),
                new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Payment_Method", "تحويل بنكى"),
                new SqlParameter("@Total_Money", float.Parse(tb_OldMoney.Text)),
                new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@After_Payment", float.Parse(tb_AfterPayment.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text),
                new SqlParameter("@Report_number", tb_Number.Text)
                );
        }

        private void Edit_BankAccount()
        {
            //تعديل حساب البنك
            Ezzat.ExecutedNoneQuery("updateBankAccount_Increase",
                new SqlParameter("@Bank_ID", combo_Bank.SelectedValue),
                new SqlParameter("@Money", double.Parse(tb_payment.Text))
                );


            // اضافة تعاملات للبنك
            Ezzat.ExecutedNoneQuery("insert_BankTransaction",
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Bank_ID", combo_Bank.SelectedValue),
                new SqlParameter("@MoneyQuantity", double.Parse(tb_payment.Text)),
                new SqlParameter("@Notes", richTextBox1.Text),
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Report_Details", "تسديد من عميل"),
                new SqlParameter("@ID", label2.Text),
                new SqlParameter("@Check_Number", tb_Number.Text)
                );
        }

    }
}
