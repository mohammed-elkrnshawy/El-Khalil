﻿using System;
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

            panel3.Visible=panel6.Visible = false;
            tb_Number.Text = "";

            richTextBox1.Text = "لا يوجد ملاحظات";

            tb_AfterPayment.Text = tb_OldMoney.Text = tb_payment.Text = "0.00";



        }

        private void Customer_Payback_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void LoadPayback()
        {
            object o = Ezzat.ExecutedScalar("selectBayback_Bill_ID_Customer");

            label2.Text = o + "";

            panel3.Visible = false;
            panel6.Visible = true;
            radioButton2.Checked = true;
        }

        private void LoadDiscount()
        {
            object o = Ezzat.ExecutedScalar("selectEXDiscount_Bill_ID");


            label2.Text = o + "";

            radioButton2.Checked = true;
            panel6.Visible = false;
        }

        private void LoadBank()
        {
            object o = Ezzat.ExecutedScalar("selectBayback_Bill_ID_Customer");

            
                label2.Text = o+"";
           

            panel3.Visible = true;
            using (dataSet = Ezzat.GetDataSet("select_Banks", "X"))
            {
                combo_Bank.DataSource = dataSet.Tables["X"];
                combo_Bank.DisplayMember = "Bank_Name";
                combo_Bank.ValueMember = "Bank_ID";
                combo_Bank.Text = "";
                combo_Bank.SelectedText = "اختار بنك للايداع";
            }

            panel6.Visible = true;
            radioButton2.Checked = true;
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
            Shared_Class.Change(tb_payment);
            Calcolate();
        }

        private void tb_payment_KeyPress(object sender, KeyPressEventArgs e)
        {
            Shared_Class.KeyPress(tb_payment, e);
        }

        private void tb_payment_Leave(object sender, EventArgs e)
        {
            Shared_Class.Leave(tb_payment);
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
            if(comboBox1.SelectedIndex>=0&&combo_Supliers.SelectedIndex>=0)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    SaveDiscount();
                    RefreshForm();
                }
                else if(comboBox1.SelectedIndex == 1)
                {
                    if(radioButton1.Checked&&textBox1.Text!="")
                    {
                        SavePaypack();
                        ChangeCreditLimit();
                        RefreshForm();
                    }
                    else if(radioButton2.Checked)
                    {
                        SavePaypack();
                        RefreshForm();
                    }
                    else
                    {
                        MessageBox.Show(Shared_Class.Check_Message);
                    }
                }
                else if(comboBox1.SelectedIndex == 2)
                {
                    if (radioButton1.Checked && textBox1.Text != ""&&combo_Bank.SelectedIndex>=0&&tb_Number.Text!="")
                    {
                        SaveBank();
                        ChangeCreditLimit();
                        RefreshForm();
                    }
                    else if (radioButton2.Checked && combo_Bank.SelectedIndex >= 0 && tb_Number.Text != "")
                    {
                        SaveBank();
                        RefreshForm();
                    }
                    else
                    {
                        MessageBox.Show(Shared_Class.Check_Message);
                    }
                }
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
   
        }

        private void ChangeCreditLimit()
        {
                int row = Ezzat.ExecutedNoneQuery("update_CreditLimit",new SqlParameter("@Bill_ID", textBox1.Text),new SqlParameter("@Type", true),new SqlParameter("@ownerID",combo_Supliers.SelectedValue));
                if(row==0)
                    MessageBox.Show("كان لا يوجد فاتورة حد ائتمان بهذا الرقم تستحق التسديد");
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           

            if(radioButton1.Checked)
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
                textBox1.ReadOnly = true;
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                panel7.Visible = true;
                using (dataSet = Ezzat.GetDataSet("select_SpasificCreditLimit", "X", new SqlParameter("@ownerID", combo_Supliers.SelectedValue), new SqlParameter("@Type", true)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                MessageBox.Show("افتح خيار سداد من فاتورة حد ائتمان");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value + "";
            panel7.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            panel7.Visible = !radioButton2.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 && combo_Supliers.SelectedIndex >= 0)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    SaveDiscount();
                    openPrinter();
                    RefreshForm();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (radioButton1.Checked && textBox1.Text != "")
                    {
                        SavePaypack();
                        ChangeCreditLimit();
                        openPrinter();
                        RefreshForm();
                    }
                    else if (radioButton2.Checked)
                    {
                        SavePaypack();
                        openPrinter();
                        RefreshForm();
                    }
                    else
                    {
                        MessageBox.Show(Shared_Class.Check_Message);
                    }
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    if (radioButton1.Checked && textBox1.Text != "" && combo_Bank.SelectedIndex >= 0 && tb_Number.Text != "")
                    {
                        SaveBank();
                        ChangeCreditLimit();
                        openPrinter();
                        RefreshForm();
                    }
                    else if (radioButton2.Checked && combo_Bank.SelectedIndex >= 0 && tb_Number.Text != "")
                    {
                        SaveBank();
                        openPrinter();
                        RefreshForm();
                    }
                    else
                    {
                        MessageBox.Show(Shared_Class.Check_Message);
                    }
                }
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }

        private void openPrinter()
        {
            Customrt_Payback_Print report = new Customrt_Payback_Print(combo_Supliers.Text,richTextBox1.Text,double.Parse(tb_OldMoney.Text),double.Parse(tb_payment.Text),int.Parse(label2.Text),comboBox1.Text);
            report.ShowDialog();
        }
    }
}
