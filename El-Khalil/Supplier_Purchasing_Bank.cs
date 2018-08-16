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
    public partial class Supplier_Purchasing_Bank : Form
    {
        DataSet dataSet;

        string Report_ID,Bill_Total,Bill_Discount,Bill_AfterDiscount,OldAcount,Total,SupplierName;
        int SupplierID;

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (combo_Bank.SelectedIndex >= 0)
            {
                SaveCheck();
                Edit_BankAccount();
                MessageBox.Show(Shared_Class.Successful_Message);
                this.Close();
            }
        }

        private void SaveCheck()
        {
            //Suppliers

            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID", SupplierID), new SqlParameter("@Total_Money", float.Parse(tb_after.Text)));

            // اضافة فاتورة شراء من المورد
            // اضافة تعامل ف حساب تعاملات المورد
            Ezzat.ExecutedNoneQuery("insertPurchasingBill",
                 new SqlParameter("@Purchasing_ID", int.Parse(label2.Text)),
                 new SqlParameter("@Supplier_ID", SupplierID),
                 new SqlParameter("@Bill_Date", DateTime.Parse(DateTime.Now.ToString())),
                 new SqlParameter("@Payment_Method", "شيك"),
                 new SqlParameter("@Material_Money", float.Parse(tb_BillTotal.Text)),
                 new SqlParameter("@Discount_Money", float.Parse(tb_Discount.Text)),
                 new SqlParameter("@After_Discount", float.Parse(tb_AfterDiscount.Text)),
                 new SqlParameter("@Total_oldMoney", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Total_Money", float.Parse(tb_old.Text)),
                 new SqlParameter("@Payment_Money", float.Parse(tb_pay.Text)),
                 new SqlParameter("@After_Payment", float.Parse(tb_after.Text)),
                 new SqlParameter("@Bill_Details",richTextBox1.Text)
                );

           

        }

        private void tb_pay_TextChanged(object sender, EventArgs e)
        {

            Calcolate();
        }

        private void Supplier_Purchasing_Bank_Load(object sender, EventArgs e)
        {
            label2.Text = Report_ID;
            tb_BillTotal.Text = Bill_Total;
            tb_Discount.Text = Bill_Discount;
            tb_AfterDiscount.Text = Bill_AfterDiscount;
            tb_OldMoney.Text = OldAcount;
            tb_old.Text = Total;
            tb_name.Text = SupplierName;

            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);

            using (dataSet = Ezzat.GetDataSet("select_Banks", "X"))
            {
                combo_Bank.DataSource = dataSet.Tables["X"];
                combo_Bank.DisplayMember = "Bank_Name";
                combo_Bank.ValueMember = "Bank_ID";
                combo_Bank.Text = "";
                combo_Bank.SelectedText = "اختار بنك للايداع";
            }

        }

        public Supplier_Purchasing_Bank(string Report_id,string BillTotal,string Discount,string After, string Old,string Total,string Name,object ID)
        {
            InitializeComponent();
            this.Report_ID = Report_id;
            this.Bill_Total = BillTotal;
            this.Bill_Discount = Discount;
            this.Bill_AfterDiscount = After;
            this.OldAcount = Old;
            this.Total = Total;
            this.SupplierName = Name;
            this.SupplierID = (int)ID;
        }

        private void Calcolate()
        {
            tb_after.Text = String.Format("{0:0.00}", (double.Parse(tb_old.Text) - double.Parse(tb_pay.Text)));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void Edit_BankAccount()
        {

            //تعديل حساب البنك
            Ezzat.ExecutedNoneQuery("updateBankAccount_Decrease",
                new SqlParameter("@Bank_ID", combo_Bank.SelectedValue),
                new SqlParameter("@Money", double.Parse(tb_pay.Text))
                );

            // اضافة تعاملات للبنك
            Ezzat.ExecutedNoneQuery("insert_BankTransaction",
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Bank_ID", combo_Bank.SelectedValue),
                new SqlParameter("@MoneyQuantity", double.Parse(tb_pay.Text)),
                new SqlParameter("@Notes", "دفع من عمليه شراء"),
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Report_From", combo_Bank.Text),
                new SqlParameter("@Report_To", "مورد " + SupplierName)
                );
        }
    }
}
