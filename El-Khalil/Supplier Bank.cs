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
    public partial class Supplier_Bank : Form
    {
        DataSet dataSet;
        public Supplier_Bank()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void Supplier_Bank_Load(object sender, EventArgs e)
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);


            object o = Ezzat.ExecutedScalar("selectBankTransaction_Bill_ID");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";



            using (dataSet = Ezzat.GetDataSet("select_Banks", "X"))
            {
                combo_Bank.DataSource = dataSet.Tables["X"];
                combo_Bank.DisplayMember = "Bank_Name";
                combo_Bank.ValueMember = "Bank_ID";
                combo_Bank.Text = "";
                combo_Bank.SelectedText = "اختار بنك للايداع";
            }

            using (dataSet = Ezzat.GetDataSet("selectAllSupplier", "X"))
            {
                combo_Supplier.DataSource = dataSet.Tables["X"];
                combo_Supplier.DisplayMember = "Supplier_Name";
                combo_Supplier.ValueMember = "Supplier_ID";
                combo_Supplier.Text = "";
                combo_Supplier.SelectedText = "اختار اسم المورد";
            }
        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            Save();
        }


        private void Save()
        {
            Edit_BankAccount();

            Edit_CustomerAccount();
        }

        private void Edit_CustomerAccount()
        {

            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID",
                (int)combo_Supplier.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_after.Text)));


            // اضافة بيان تسديد الى مورد 
            // اضافة تعامل ف التعاملات مع الموردين .... نوعه تسديد

            Ezzat.ExecutedNoneQuery("insertIMBankPayback_Bill",
                new SqlParameter("@Report_ID", label2.Text),
                new SqlParameter("@Supplier_ID", combo_Supplier.SelectedValue),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Payment_Method", "تحويل بنكى"),
                new SqlParameter("@Total_Money", float.Parse(tb_old.Text)),
                new SqlParameter("@Payment_Money", float.Parse(tb_pay.Text)),
                new SqlParameter("@After_Payment", float.Parse(tb_after.Text)),
                new SqlParameter("@Report_Notes", "تحويل بنكى الى بنك " + combo_Bank.Text)
                );


          
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
                new SqlParameter("@Notes", "تحويل من البنك"),
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Report_From", combo_Bank.Text),
                new SqlParameter("@Report_To", "مورد " + combo_Supplier.Text)
                );
        }

        private void combo_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Supplier.Focused)
            {
                object o = Ezzat.ExecutedScalar("selectTotalMoney", new SqlParameter("@Supplier_ID", (int)combo_Supplier.SelectedValue));
                tb_old.Text = String.Format("{0:0.00}", o);
                Calcolate();
            }
        }

        private void Calcolate()
        {
            tb_after.Text = String.Format("{0:0.00}", (double.Parse(tb_old.Text) - double.Parse(tb_pay.Text)));
        }

        private void tb_pay_TextChanged(object sender, EventArgs e)
        {
            Calcolate();
        }

    }
}
