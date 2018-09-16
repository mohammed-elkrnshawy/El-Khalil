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
    public partial class Owner_IMMoney : Form
    {
        public Owner_IMMoney()
        {
            InitializeComponent();
        }

        private void RefForm()
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);


            object o = Ezzat.ExecutedScalar("select_OwnerReportId");
            label2.Text = o.ToString() ;

            tb_money.Text = "0.00";
            richTextBox1.Text = "اكتب البيان";
        }

        private void Owner_IMMoney_Load(object sender, EventArgs e)
        {
            RefForm();
        }

        private void Edit_TheSafe_Decrease()
        {
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_money.Text)));

            // عمل بيان صرف من الخزنة للعميل
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", radioButton2.Text),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_money.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );
        }

        private void EditSafe_Increase()
        {
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Increase", new SqlParameter("@Money_Quantity", float.Parse(tb_money.Text)));

            // عمل بيان ايراد من الخزنة للعميل
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", radioButton1.Text),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_money.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (tb_money.Text != "")
            {
                if (radioButton1.Checked)
                {
                    IM();
                    MessageBox.Show(Shared_Class.Successful_Message);
                }
                else if (radioButton2.Checked)
                {
                    EX();
                    MessageBox.Show(Shared_Class.Successful_Message);
                }
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }
        private void EX()
        {
            OwnerTransacton(radioButton2.Text,false);
            Edit_TheSafe_Decrease();
            RefForm();
        }

        private void IM()
        {
            OwnerTransacton(radioButton1.Text, true);
            EditSafe_Increase();
            RefForm();
        }

        private void OwnerTransacton(string report_type,bool transaction_type)
        {
            Ezzat.ExecutedNoneQuery("insert_OwnerTransaction",
                new SqlParameter("@report_id",label2.Text),
                new SqlParameter("@report_type", report_type),
                new SqlParameter("@report_date",DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@reportdetails",richTextBox1.Text),
                new SqlParameter("@totalmoney",double.Parse(tb_money.Text)),
                new SqlParameter("@transaction_type", transaction_type)
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
