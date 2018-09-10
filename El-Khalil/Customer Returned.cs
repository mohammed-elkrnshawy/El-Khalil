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
    public partial class Customer_Returned : Form
    {
        private double MaterialPrice,Bill_Total,Total;
        private string MaterialUnit;
        private int Product_PerUnit;

        private DataSet dataSet;
        public Customer_Returned()
        {
            InitializeComponent();
        }
 
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }
        private void RefreshForm()
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);



            using (dataSet = Ezzat.GetDataSet("Select_All", "X"))
            {
                combo_Materials.DataSource = dataSet.Tables["X"];
                combo_Materials.DisplayMember = "اسم الصنف";
                combo_Materials.ValueMember = "رفم الصنف";
                combo_Materials.Text = "";
                combo_Materials.SelectedText = "اختار مادة خام";
            }

            using (dataSet = Ezzat.GetDataSet("select_AllCustomer", "X"))
            {
                combo_Customer.DataSource = dataSet.Tables["X"];
                combo_Customer.DisplayMember = "Customer_Name";
                combo_Customer.ValueMember = "Customer_ID";
                combo_Customer.Text = "";
                combo_Customer.SelectedText = "اختار اسم المشترى";
            }

            object o = Ezzat.ExecutedScalar("selectReturning_Bill_ID_Customer");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";

            panel7.Visible=panel5.Visible= tb_payment.Visible = label10.Visible = false;
            dataGridView1.Rows.Clear();
            richTextBox1.Text = "اكتب بيان الفااتورة";
            tb_details.Text = "اكتب بيان الصنف";
            tb_quantity.Text = "0";
            tb_AfterDiscount.Text = tb_BillTotal.Text = tb_Discount.Text = tb_OldMoney.Text = tb_price.Text = tb_Total.Text = "0.00";
            Bill_Total = 0;


        }
        private void Customer_Returned_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }
        private void combo_Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Customer.Focused)
            {
                ShowDetails_Customer((int)combo_Customer.SelectedValue);
                //if (tb_PaymentMethod.Text.Contains("نقدى او شيك"))
                //    panel7.Visible = true;
                //else
                //    panel7.Visible = false;

            }
        }
        private void ShowDetails_Customer(int ID)
        {

            SqlConnection con;
            SqlDataReader dr = Ezzat.GetDataReader("selectSpasific_Customer", out con, new SqlParameter("@Customer_Id", ID));

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    tb_OldMoney.Text = dr["Total_Money"].ToString();
                    Calcolate();
                }
            }
            con.Close();
        }
        private void ShowDetails_Material(int ID)
        {

            SqlConnection con;
            SqlDataReader dr = Ezzat.GetDataReader("selectSpasificProduct", out con, new SqlParameter("@Product_ID", ID));

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    MaterialPrice = double.Parse(dr[7].ToString());
                    Product_PerUnit = int.Parse(dr[5].ToString());
                    MaterialUnit = dr[4].ToString();
                    tb_price.Text = String.Format("{0:0.00}", MaterialPrice);
                    if (dr[4].ToString() == "كجم")
                        rb_Kilo.Checked = true;
                    else if (dr[4].ToString() == "جم")
                        rb_Gram.Checked = true;
                }
            }
            con.Close();
        }
        private void combo_Materials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Materials.Focused)
            {
                ShowDetails_Material((int)combo_Materials.SelectedValue);
            }
        }
        private void Calcolate()
        {
            tb_BillTotal.Text = String.Format("{0:0.00}", Bill_Total);

            tb_AfterDiscount.Text = String.Format("{0:0.00}", (double.Parse(tb_BillTotal.Text) - double.Parse(tb_Discount.Text)));

            tb_Total.Text = String.Format("{0:0.00}", (double.Parse(tb_OldMoney.Text) - double.Parse(tb_AfterDiscount.Text)));

            Total = double.Parse(tb_Total.Text);
            //tb_render.Text = String.Format("{0:0.00}", (double.Parse(tb_AfterDiscount.Text) - double.Parse(tb_OldMoney.Text)));

            if (double.Parse(tb_AfterDiscount.Text) > double.Parse(tb_OldMoney.Text))
            {
                panel7.Visible = true;
                tb_payment.Text = "0.00";
            }
            else
            {
                panel7.Visible = false;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (FoundBefore())
                AddRow();
        }
        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Bill_Total -= double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            Calcolate();
        }
        private void AddRow()
        {
            if (IsValidText(tb_price) && IsValidText(tb_quantity) && combo_Materials.SelectedIndex >= 0)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, dataGridView1.Rows.Count - 1].Value = combo_Materials.SelectedValue;
                dataGridView1[1, dataGridView1.Rows.Count - 1].Value = combo_Materials.Text;
                dataGridView1[2, dataGridView1.Rows.Count - 1].Value = tb_price.Text + "/ " + Product_PerUnit + " " + MaterialUnit;
                dataGridView1[3, dataGridView1.Rows.Count - 1].Value = tb_quantity.Text;
                dataGridView1[4, dataGridView1.Rows.Count - 1].Value = MaterialUnit;
                dataGridView1[5, dataGridView1.Rows.Count - 1].Value = String.Format("{0:0.00}", Math.Round(((double.Parse(tb_quantity.Text) / Product_PerUnit) * double.Parse(tb_price.Text)), 2));
                dataGridView1[6, dataGridView1.Rows.Count - 1].Value = tb_details.Text;
                Bill_Total += double.Parse(dataGridView1[5, dataGridView1.Rows.Count - 1].Value.ToString());
                Calcolate();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }
        private bool FoundBefore()
        {

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (item.Cells[0].Value.Equals(combo_Materials.SelectedValue))
                {
                    MessageBox.Show(Shared_Class.Exsisting_Message);
                    return false;
                }
            }

            return true;
        }
        private bool IsValidText(TextBox textBox)
        {
            if (textBox.Text == "")
                return false;
            else
                return true;
        }
        private void tb_payment_TextChanged(object sender, EventArgs e)
        {
            if (tb_payment.Text == "")
                tb_payment.Text = "0.00";
            tb_Total.Text = String.Format("{0:0.00}", (Total + double.Parse(tb_payment.Text)));
        }

        private void tb_Discount_TextChanged(object sender, EventArgs e)
        {
            if (tb_Discount.Text == ".")
                tb_Discount.Text = "0.";
            if (tb_Discount.Text == "")
                tb_Discount.Text = "0";
            Calcolate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (combo_Customer.SelectedIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                if(double.Parse(tb_OldMoney.Text)>=double.Parse(tb_AfterDiscount.Text))
                {
                    SaveNormal();
                }
                else
                {
                    if(radioButton3.Checked)
                    {
                        SaveNormal();
                    }
                    else if(radioButton1.Checked)
                    {
                        SaveCash();
                    }
                    else if(radioButton2.Checked)
                    {
                        SaveCheck();
                    }
                }
                MessageBox.Show(Shared_Class.Successful_Message);
                RefreshForm();
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }

        private void SaveCheck()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney_Customer"
                , new SqlParameter("@Supplier_ID", (int)combo_Customer.SelectedValue)
                , new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)));

            // اضافة فاتورة مرتجع الى المورد
            // اضافة تعامل ف حساب تعاملات المورد
            Ezzat.ExecutedNoneQuery("insertEXReturning_Bill",
                 new SqlParameter("@Purchasing_ID", int.Parse(label2.Text)),
                 new SqlParameter("@Customer_ID", (int)combo_Customer.SelectedValue),
                 new SqlParameter("@Bill_Date", DateTime.Parse(DateTime.Now.ToString())),
                 new SqlParameter("@Payment_Method", "شيك"),
                 new SqlParameter("@Material_Money", float.Parse(tb_BillTotal.Text)),
                 new SqlParameter("@Discount_Money", float.Parse(tb_Discount.Text)),
                 new SqlParameter("@After_Discount", float.Parse(tb_AfterDiscount.Text)),
                 new SqlParameter("@Total_oldMoney", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)),
                 new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                 new SqlParameter("@Bill_Details", richTextBox1.Text),
                 new SqlParameter("@Sheck_Number", tb_number.Text)
                );

            // اضافة تفاصيل فاتورة الشراء 
            AddIMBill_Details(int.Parse(label2.Text));

            EditStore();

            Edit_BankAccount();

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
                new SqlParameter("@Report_Details", "صرف من مرتجع عميل"),
                new SqlParameter("@ID", label2.Text),
                new SqlParameter("@Check_Number", tb_number.Text)
                );
        }

        private void SaveCash()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney_Customer"
                , new SqlParameter("@Supplier_ID", (int)combo_Customer.SelectedValue)
                , new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)));

            // اضافة فاتورة مرتجع الى المورد
            // اضافة تعامل ف حساب تعاملات المورد
            Ezzat.ExecutedNoneQuery("insertEXReturning_Bill",
                 new SqlParameter("@Purchasing_ID", int.Parse(label2.Text)),
                 new SqlParameter("@Customer_ID", (int)combo_Customer.SelectedValue),
                 new SqlParameter("@Bill_Date", DateTime.Parse(DateTime.Now.ToString())),
                 new SqlParameter("@Payment_Method", "نقدى"),
                 new SqlParameter("@Material_Money", float.Parse(tb_BillTotal.Text)),
                 new SqlParameter("@Discount_Money", float.Parse(tb_Discount.Text)),
                 new SqlParameter("@After_Discount", float.Parse(tb_AfterDiscount.Text)),
                 new SqlParameter("@Total_oldMoney", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)),
                 new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                 new SqlParameter("@Bill_Details", richTextBox1.Text),
                 new SqlParameter("@Sheck_Number", "")
                );

            // اضافة تفاصيل فاتورة الشراء 
            AddIMBill_Details(int.Parse(label2.Text));

            EditStore();

            EditSafe();
        }

        private void SaveNormal()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney_Customer"
                , new SqlParameter("@Supplier_ID", (int)combo_Customer.SelectedValue)
                , new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)));

            // اضافة فاتورة مرتجع الى المورد
            // اضافة تعامل ف حساب تعاملات المورد
            Ezzat.ExecutedNoneQuery("insertEXReturning_Bill",
                 new SqlParameter("@Purchasing_ID", int.Parse(label2.Text)),
                 new SqlParameter("@Customer_ID", (int)combo_Customer.SelectedValue),
                 new SqlParameter("@Bill_Date", DateTime.Parse(DateTime.Now.ToString())),
                 new SqlParameter("@Payment_Method", ""),
                 new SqlParameter("@Material_Money", float.Parse(tb_BillTotal.Text)),
                 new SqlParameter("@Discount_Money", float.Parse(tb_Discount.Text)),
                 new SqlParameter("@After_Discount", float.Parse(tb_AfterDiscount.Text)),
                 new SqlParameter("@Total_oldMoney", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)),
                 new SqlParameter("@Payment_Money", float.Parse("0.00")),
                 new SqlParameter("@Bill_Details", richTextBox1.Text),
                 new SqlParameter("@Sheck_Number", "")
                );

            // اضافة تفاصيل فاتورة الشراء 
            AddIMBill_Details(int.Parse(label2.Text));
            EditStore();

        }

        private void AddIMBill_Details(int iD)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("insertEXBill_Details"
                    , new SqlParameter("@Bill_ID", iD)
                    , new SqlParameter("@Material_ID", int.Parse(item.Cells[0].Value.ToString()))
                    , new SqlParameter("@Material_Name", item.Cells[1].Value.ToString())
                    , new SqlParameter("@Material_PricePerUnit", item.Cells[2].Value.ToString())
                    , new SqlParameter("@Material_Quantity", float.Parse(item.Cells[3].Value + ""))
                    , new SqlParameter("@Unit", item.Cells[4].Value.ToString())
                    , new SqlParameter("@Total", float.Parse(item.Cells[5].Value + ""))
                    , new SqlParameter("@Bill_Type", true)
                    , new SqlParameter("@Material_Details", item.Cells[6].Value.ToString())
                    );
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            tb_payment.Text = "0.00";
            tb_payment.Visible=label10.Visible = !radioButton3.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel5.Visible = radioButton2.Checked;
            if(radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("select_Banks", "X"))
                {
                    combo_Bank.DataSource = dataSet.Tables["X"];
                    combo_Bank.DisplayMember = "Bank_Name";
                    combo_Bank.ValueMember = "Bank_ID";
                    combo_Bank.Text = "";
                    combo_Bank.SelectedText = "اختار بنك للايداع";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combo_Customer.SelectedIndex >= 0 && dataGridView1.Rows.Count > 0)
            {
                if (double.Parse(tb_OldMoney.Text) >= double.Parse(tb_AfterDiscount.Text))
                {
                    SaveNormal();
                }
                else
                {
                    if (radioButton3.Checked)
                    {
                        SaveNormal();
                    }
                    else if (radioButton1.Checked)
                    {
                        SaveCash();
                    }
                    else if (radioButton2.Checked)
                    {
                        SaveCheck();
                    }
                }
                MessageBox.Show(Shared_Class.Successful_Message);

                Customer_Print print = new Customer_Print(int.Parse(label2.Text),
                                                          combo_Customer.Text,
                                                          richTextBox1.Text,
                                                          double.Parse(tb_BillTotal.Text),
                                                          double.Parse(tb_Discount.Text),
                                                          double.Parse(tb_OldMoney.Text),
                                                          double.Parse(tb_payment.Text),
                                                          true
                                                          );
                print.ShowDialog();
                RefreshForm();
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }

        private void EditStore()
        {
            //تعديل الكميات ف المخازن
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("updateMaterialQuantity_Increase"
                    , new SqlParameter("@Material_ID", int.Parse(item.Cells[0].Value.ToString()))
                    , new SqlParameter("@Material_Quantity", item.Cells[3].Value.ToString())
                    );
            }

            // اضافة تعاملات ف المخازن
            Ezzat.ExecutedNoneQuery("insertStoreTransaction",
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Report_Date", DateTime.Now.ToString()),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "مرتجع من عميل"),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );

        }

        private void EditSafe()
        {
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_payment.Text)));
            
            // عمل بيان توريد من المورد للخزنة
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "باقى مبلغ مرتجع من عميل"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@Report_Notes", "مبلغ من حساب بيع بضاعة " + richTextBox1.Text)
                );
        }

    }
}
