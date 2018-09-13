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

        private void RefForm()
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
        }

        private void Bank_InAccount_Load(object sender, EventArgs e)
        {
            RefForm();
        }

        private void combo_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo_Bank.Focused)
            {
                ShowDetails((int)combo_Bank.SelectedValue);
            }
        }

        private void ShowDetails(int value)
        {
            SqlConnection con;
            SqlDataReader dataReader = Ezzat.GetDataReader("selectSpasific_Bank", out con, new SqlParameter("@Customer_Id", value));


            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    tb_account.Text = dataReader["Bank_Account"].ToString();
                }
            }
            con.Close();

        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            if (combo_Bank.SelectedIndex >= 0)
            {
                Save();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }

        private void Save()
        {
            Edit_BankAccount();

            Edit_TheSafe();
            MessageBox.Show(Shared_Class.Successful_Message);
            RefForm();
        }

        private void Edit_BankAccount()
        {
            //تعديل حساب البنك
            Ezzat.ExecutedNoneQuery("updateBankAccount_Increase",
                new SqlParameter("@Bank_ID",combo_Bank.SelectedValue),
                new SqlParameter("@Money",double.Parse(tb_money.Text))
                );

            // اضافة تعاملات للبنك
            Ezzat.ExecutedNoneQuery("insert_BankTransaction",
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Bank_ID", combo_Bank.SelectedValue),
                new SqlParameter("@MoneyQuantity", double.Parse(tb_money.Text)),
                new SqlParameter("@Notes", richTextBox1.Text),
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Report_Details", "ايداع الى البنك"),
                new SqlParameter("@ID", label2.Text),
                new SqlParameter("@Check_Number", tb_number.Text)
                );
        }

        private void Edit_TheSafe()
        {
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_money.Text)));

            // عمل بيان صرف من الخزنة للعميل
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "ايداع فى حساب بنك"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_money.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );
        }

        private void tb_money_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
