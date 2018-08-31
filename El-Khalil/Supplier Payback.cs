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
    public partial class Supplier_Payback : Form
    {
        private DataSet dataSet;
        public Supplier_Payback()
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


            using (dataSet = Ezzat.GetDataSet("selectAllSupplier", "X"))
            {
                combo_Supliers.DataSource = dataSet.Tables["X"];
                combo_Supliers.DisplayMember = "Supplier_Name";
                combo_Supliers.ValueMember = "Supplier_ID";
                combo_Supliers.Text = "";
                combo_Supliers.SelectedText = "اختار اسم المورد";
            }

            panel3.Visible=panel6.Visible = false;
            textBox1.Text = tb_Number.Text=richTextBox1.Text = "";

            tb_AfterPayment.Text = tb_OldMoney.Text = tb_payment.Text = "0.00";

            radioButton2.Checked = true;

        }

        private void Supplier_Payback_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void LoadPayback()
        {
            object o = Ezzat.ExecutedScalar("selectBayback_Bill_ID");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";
            panel3.Visible = false;
            panel6.Visible = true;
        }

        private void LoadDiscount()
        {
            panel6.Visible = false;
            panel3.Visible = false;
            object o = Ezzat.ExecutedScalar("selectDiscount_Bill_ID");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";
        }

        private void LoadBank()
        {
            panel6.Visible = true;
            object o = Ezzat.ExecutedScalar("selectBayback_Bill_ID");

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
                object o = Ezzat.ExecutedScalar("selectTotalMoney", new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue));
                tb_OldMoney.Text = String.Format("{0:0.00}", o);
                Calcolate();
            }
        }

        private void Calcolate()
        {
            tb_AfterPayment.Text = String.Format("{0:0.00}", (double.Parse(tb_OldMoney.Text)-double.Parse(tb_payment.Text)));
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

        private void SavePaypack()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID",
                (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_AfterPayment.Text)));


            // اضافة بيان تسديد الى مورد 
            // اضافة تعامل ف التعاملات مع الموردين .... نوعه تسديد

            Ezzat.ExecutedNoneQuery("insertIMPayback_Bill",
                new SqlParameter("@Report_ID", label2.Text),
                new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Payment_Method", "نقدى"),
                new SqlParameter("@Total_Money", float.Parse(tb_OldMoney.Text)),
                new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@After_Payment", float.Parse(tb_AfterPayment.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text),
                new SqlParameter("@BillNumber_Supplier", int.Parse(textBox1.Text))
                );

            EditSafe();

            MessageBox.Show(Shared_Class.Successful_Message);
        }

        private void EditSafe()
        {
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_payment.Text)));

            // عمل بيان صرف من الخزنة للعميل
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "تسديد الى مورد"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );
        }


        private void SaveDiscount()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID",
                (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_AfterPayment.Text)));


            // اضافة بيان خصم
            // اضافة تعامل ف التعاملات مع الموردين .... نوعه خصم

            Ezzat.ExecutedNoneQuery("insertIMDiscout_Bill",
                new SqlParameter("@Report_ID", label2.Text),
                new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Total_Money", float.Parse(tb_OldMoney.Text)),
                new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@After_Payment", float.Parse(tb_AfterPayment.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text),
                new SqlParameter("@BillNumber_Supplier", int.Parse(textBox1.Text))
                );

            MessageBox.Show(Shared_Class.Successful_Message);
        }

        private void SaveBank()
        {
            Edit_BankAccount();

            Edit_CustomerAccount();

            MessageBox.Show(Shared_Class.Successful_Message);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Focused)
            {
                if(comboBox1.SelectedIndex==1)
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

            if (radioButton1.Checked)
            {
                if (textBox2.Text != "")
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
                    ChangeCreditLimit();
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("اختار فاتورة حد ائتمان");
                }
            }
            else
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
        }

        private void ChangeCreditLimit()
        {
            int row = Ezzat.ExecutedNoneQuery("update_CreditLimit", new SqlParameter("@Bill_ID", textBox2.Text), new SqlParameter("@Type", false), new SqlParameter("@ownerID", combo_Supliers.SelectedValue));
            if (row == 0)
                MessageBox.Show("كان لا يوجد فاتورة حد ائتمان بهذا الرقم تستحق التسديد");
        }

        private void Edit_CustomerAccount()
        {

            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID",
                (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_AfterPayment.Text)));


            // اضافة بيان تسديد الى مورد 
            // اضافة تعامل ف التعاملات مع الموردين .... نوعه تسديد

            Ezzat.ExecutedNoneQuery("insertIMBankPayback_Bill",
                new SqlParameter("@Report_ID", label2.Text),
                new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Payment_Method", "تحويل بنكى"),
                new SqlParameter("@Total_Money", float.Parse(tb_OldMoney.Text)),
                new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@After_Payment", float.Parse(tb_AfterPayment.Text)),
                new SqlParameter("@Report_Notes",richTextBox1.Text ),
                new SqlParameter("@BillNumber_Supplier", int.Parse(textBox1.Text)),
                new SqlParameter("@Report_number", tb_Number.Text)
                );



        }

        private void Edit_BankAccount()
        {

            //تعديل حساب البنك
            Ezzat.ExecutedNoneQuery("updateBankAccount_Decrease",
                new SqlParameter("@Bank_ID", combo_Bank.SelectedValue),
                new SqlParameter("@Money", double.Parse(tb_payment.Text))
                );

            // اضافة تعاملات للبنك
            Ezzat.ExecutedNoneQuery("insert_BankTransaction",
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Bank_ID", combo_Bank.SelectedValue),
                new SqlParameter("@MoneyQuantity", double.Parse(tb_payment.Text)),
                new SqlParameter("@Notes", richTextBox1.Text),
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Report_Details", "تسديد الى مورد"),
                new SqlParameter("@ID",label2.Text),
                new SqlParameter("@Check_Number", tb_Number.Text)
                );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                if (combo_Supliers.SelectedIndex >= 0)
                {

                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    MessageBox.Show("اختر العميل اولا");
                }

            }
            else
            {
                textBox2.ReadOnly = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                panel7.Visible = !radioButton2.Checked;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel7.Visible = true;
                using (dataSet = Ezzat.GetDataSet("select_SpasificCreditLimit", "X", new SqlParameter("@ownerID", combo_Supliers.SelectedValue), new SqlParameter("@Type", false)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                MessageBox.Show("افتح خيار سداد من فاتورة حد ائتمان");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value + "";
            panel7.Visible = false;
        }
    }
}
