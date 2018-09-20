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
    public partial class Bank_Cus_To_Sup : Form
    {
        DataSet dataSet;
        public Bank_Cus_To_Sup()
        {
            InitializeComponent();
        }

        private void RefreshForm()
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);


            using (dataSet = Ezzat.GetDataSet("selectAllCustomer", "X"))
            {
                combo_Cus.DataSource = dataSet.Tables["X"];
                combo_Cus.DisplayMember = "Customer_Name";
                combo_Cus.ValueMember = "Customer_ID";
                combo_Cus.Text = "";
                combo_Cus.SelectedText = "اختار اسم العميل";
            }

            using (dataSet = Ezzat.GetDataSet("selectAllSupplier", "X"))
            {
                combo_Supliers.DataSource = dataSet.Tables["X"];
                combo_Supliers.DisplayMember = "Supplier_Name";
                combo_Supliers.ValueMember = "Supplier_ID";
                combo_Supliers.Text = "";
                combo_Supliers.SelectedText = "اختار اسم المورد";
            }

            object o = Ezzat.ExecutedScalar("selectBankTransaction_Bill_ID");

            label2.Text = o + "";

          


        }

        private void Bank_Cus_To_Sup_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void combo_Cus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo_Cus.Focused)
            {
                FillBankAccounts((int)combo_Cus.SelectedValue);

                object o = Ezzat.ExecutedScalar("selectTotalMoney_Customer", new SqlParameter("@Supplier_ID", (int)combo_Cus.SelectedValue));
                tb_OldMoney_Cus.Text = String.Format("{0:0.00}", o);
                Calcolate();
            }
        }

        private void FillBankAccounts(int value)
        {
            using (dataSet = Ezzat.GetDataSet("select_CustomerBankAccounts","X" ,new SqlParameter("@Customer_ID", value)))
            {
                comb_Bank_Cus.DataSource = dataSet.Tables["X"];
                comb_Bank_Cus.DisplayMember = "Bank_Name";
                comb_Bank_Cus.ValueMember = "Bank_Number";
                comb_Bank_Cus.Text = "";
                comb_Bank_Cus.SelectedText = "اختار اسم البنك";
            }
        }

        private void FillBankAccounts_Supplier(int value)
        {
            using (dataSet = Ezzat.GetDataSet("select_SupplierBankAccounts", "X", new SqlParameter("@Supplier_ID", value)))
            {
                combo_Bank_Sup.DataSource = dataSet.Tables["X"];
                combo_Bank_Sup.DisplayMember = "Bank_Name";
                combo_Bank_Sup.ValueMember = "Bank_Number";
                combo_Bank_Sup.Text = "";
                combo_Bank_Sup.SelectedText = "اختار اسم البنك";
            }
        }

        private void combo_Supliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo_Supliers.Focused)
            {
                FillBankAccounts_Supplier((int)combo_Supliers.SelectedValue);
                object o = Ezzat.ExecutedScalar("selectTotalMoney", new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue));
                tb_OldMoney_Sup.Text = String.Format("{0:0.00}", o);
                Calcolate();
            }
        }

        private void Calcolate()
        {
            tb_AfterPayment_Cus.Text = String.Format("{0:0.00}", (double.Parse(tb_OldMoney_Cus.Text) - double.Parse(tb_payment.Text)));

            tb_AfterPayment_Sup.Text = String.Format("{0:0.00}", (double.Parse(tb_OldMoney_Sup.Text) - double.Parse(tb_payment.Text)));
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

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if(combo_Bank_Sup.SelectedIndex>=0&&combo_Cus.SelectedIndex>=0&&combo_Supliers.SelectedIndex>=0&&comb_Bank_Cus.SelectedIndex>=0)
            {
                SaveSupplier();
                SaveCustomer();
                Edit_BankAccount();

                MessageBox.Show(Shared_Class.Successful_Message);
                RefreshForm();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }

        private void SaveSupplier()
        {
            Edit_SupplierAccount();
        }

        private void Edit_SupplierAccount()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID",
                (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_AfterPayment_Sup.Text)));


            // اضافة بيان تسديد الى مورد 
            // اضافة تعامل ف التعاملات مع الموردين .... نوعه تسديد

            Ezzat.ExecutedNoneQuery("insertIMBankTranslate_Bill",
                new SqlParameter("@Report_ID", label2.Text),
                new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Payment_Method", "تحويل من عميل الى مورد"),
                new SqlParameter("@Total_Money", float.Parse(tb_OldMoney_Sup.Text)),
                new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@After_Payment", float.Parse(tb_AfterPayment_Sup.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text),
                new SqlParameter("@BillNumber_Supplier", int.Parse(tb_Bill.Text)),
                new SqlParameter("@Report_number", tb_Number_Sup.Text)
                );
        }

        private void SaveCustomer()
        {
            Edit_CustomerAccount();
        }

        private void Edit_CustomerAccount()
        {

            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney_Customer", new SqlParameter("@Supplier_ID",
                (int)combo_Cus.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_AfterPayment_Cus.Text)));


            // اضافة بيان تسديد الى مورد 
            // اضافة تعامل ف التعاملات مع الموردين .... نوعه تسديد

            Ezzat.ExecutedNoneQuery("insertEXBankTranslate_Bill",
                new SqlParameter("@Report_ID", label2.Text),
                new SqlParameter("@Supplier_ID", combo_Cus.SelectedValue),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Payment_Method", "تحويل من عميل الى مورد"),
                new SqlParameter("@Total_Money", float.Parse(tb_OldMoney_Cus.Text)),
                new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@After_Payment", float.Parse(tb_AfterPayment_Cus.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text),
                new SqlParameter("@Report_number", tb_Number_Cus.Text)
                );
        }

        private void Edit_BankAccount()
        {
            // اضافة تعاملات للبنك
            Ezzat.ExecutedNoneQuery("insert_BankTransaction",
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Bank_ID",int.Parse("0")),
                new SqlParameter("@MoneyQuantity", double.Parse(tb_payment.Text)),
                new SqlParameter("@Notes", richTextBox1.Text),
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Report_Details", "تحويل من عميل الى مورد"),
                new SqlParameter("@ID", label2.Text),
                new SqlParameter("@Check_Number", tb_Number_Cus.Text)
                );
        }

        private void tb_Number_Cus_TextChanged(object sender, EventArgs e)
        {
            tb_Number_Sup.Text = tb_Number_Cus.Text;
        }

        private void tb_Number_Sup_TextChanged(object sender, EventArgs e)
        {
            tb_Number_Cus.Text = tb_Number_Sup.Text;
        }
    }
}
