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
    public partial class Bank_InAccount : Form
    {
        DataSet dataSet;
        public Bank_InAccount()
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

        private void Bank_InAccount_Load(object sender, EventArgs e)
        {


            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);


            object o = Ezzat.ExecutedScalar("selectBankTransaction_Bill_ID");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";



            using (dataSet=Ezzat.GetDataSet("select_Banks","X"))
            {
                combo_Bank.DataSource = dataSet.Tables["X"];
                combo_Bank.DisplayMember = "Bank_Name";
                combo_Bank.ValueMember = "Bank_ID";
                combo_Bank.Text = "";
                combo_Bank.SelectedText = "اختار بنك للايداع";
            }
        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            Edit_BankAccount();

            Edit_TheSafe();
        }

        private void Edit_BankAccount()
        {
            //تعديل حساب البنك
            Ezzat.ExecutedNoneQuery("updateBankAccount_Increase",
                new SqlParameter("@Bank_ID",combo_Bank.SelectedValue),
                new SqlParameter("@Money",double.Parse(tb_phone.Text))
                );

            // اضافة تعاملات للبنك
            Ezzat.ExecutedNoneQuery("insert_BankTransaction",
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Bank_ID", combo_Bank.SelectedValue),
                new SqlParameter("@MoneyQuantity", double.Parse(tb_phone.Text)),
                new SqlParameter("@Notes", "ايداع الى البنك"),
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Report_From", "الخزنة"),
                new SqlParameter("@Report_To", combo_Bank.Text)
                );
        }

        private void Edit_TheSafe()
        {
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_phone.Text)));

            // عمل بيان صرف من الخزنة للعميل
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "توريد الى حساب بنك"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_phone.Text)),
                new SqlParameter("@Report_Notes", "توريد الى حساب بنك")
                );
        }

    }
}
