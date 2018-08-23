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
    public partial class Supplier_Purchasing : Form
    {
        private int Days_Number;
        private double Bill_Total;
        private double MaterialPrice;
        private string MaterialUnit;
        private DataSet dataSet;
        public Supplier_Purchasing()
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
            tb_details.Text = "اكتب بيان الصنف";
            richTextBox1.Text = "اكتب بيان الفاتورة ";
            richTextBox2.Text = "لا يوجد ملاحظات";

            dataGridView1.Rows.Clear();
            panel7.Visible = false;
            textBox1.Text = "";
            tb_quantity.Text = tb_quantity2.Text=tb_number.Text = "0";

            tb_price.Text=tb_Discount.Text=tb_payment.Text = "0.00";
            Bill_Total = 0;
            Calcolate();

            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);

            object o = Ezzat.ExecutedScalar("selectPurchasing_Bill_ID");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";

            using (dataSet = Ezzat.GetDataSet("selectMaterials", "X"))
            {
                combo_Materials.DataSource = dataSet.Tables["X"];
                combo_Materials.DisplayMember = "Product_Name";
                combo_Materials.ValueMember = "Product_ID";
                combo_Materials.Text = "";
                combo_Materials.SelectedText = "اختار مادة خام";
            }

            using (dataSet = Ezzat.GetDataSet("selectAllSupplier", "X"))
            {
                combo_Supliers.DataSource = dataSet.Tables["X"];
                combo_Supliers.DisplayMember = "Supplier_Name";
                combo_Supliers.ValueMember = "Supplier_ID";
                combo_Supliers.Text = "";
                combo_Supliers.SelectedText = "اختار اسم المورد";
            }

            using (dataSet = Ezzat.GetDataSet("select_Banks", "X"))
            {
                combo_Bank.DataSource = dataSet.Tables["X"];
                combo_Bank.DisplayMember = "Bank_Name";
                combo_Bank.ValueMember = "Bank_ID";
                combo_Bank.Text = "";
                combo_Bank.SelectedText = "اختار بنك للايداع";
            }

        }

        private void Purchasing_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }
        private bool IsValidText(TextBox textBox)
        {
            if (textBox.Text == "")
                return false;
            else
                return true;
        }
        private void tb_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddRow();
            }
        }
        private void AddRow()
        {
            if (IsValidText(tb_price) && IsValidText(tb_quantity) && IsValidText(tb_quantity2) && combo_Materials.SelectedIndex >= 0)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, dataGridView1.Rows.Count - 1].Value = combo_Materials.SelectedValue;
                dataGridView1[1, dataGridView1.Rows.Count - 1].Value = combo_Materials.Text;
                dataGridView1[2, dataGridView1.Rows.Count - 1].Value = tb_price.Text + "/" + MaterialUnit;
                dataGridView1[3, dataGridView1.Rows.Count - 1].Value = tb_quantity.Text;
                dataGridView1[4, dataGridView1.Rows.Count - 1].Value = MaterialUnit;
                dataGridView1[5, dataGridView1.Rows.Count - 1].Value = String.Format("{0:0.00}", Math.Round((double.Parse(tb_quantity.Text) * double.Parse(tb_price.Text)), 2));
                dataGridView1[6, dataGridView1.Rows.Count - 1].Value = tb_quantity2.Text;
                dataGridView1[7, dataGridView1.Rows.Count - 1].Value = tb_details.Text;
                Bill_Total += double.Parse(dataGridView1[5, dataGridView1.Rows.Count - 1].Value.ToString());
                Calcolate();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }
        private void ShowDetails_Material(int ID)
        {

            SqlConnection con;
            SqlDataReader dr = Ezzat.GetDataReader("selectSpasificProduct", out con, new SqlParameter("@Product_ID", ID));

            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    MaterialPrice = double.Parse(dr[6].ToString());
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
        private void ShowDetails_Supplier(int ID)
        {

            SqlConnection con;
            SqlDataReader dr = Ezzat.GetDataReader("selectSpasific_Supplier", out con, new SqlParameter("@Supplier_ID", ID));

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Days_Number = int.Parse(dr["Number_Day"].ToString());
                    tb_PaymentMethod.Text = dr["Payment_Method"].ToString();
                    tb_OldMoney.Text = dr["Total_Money"].ToString();
                    Calcolate();
                }
            }
            con.Close();
        }
        private void Calcolate()
        {
            tb_BillTotal.Text = String.Format("{0:0.00}", Bill_Total);
            tb_AfterDiscount.Text = String.Format("{0:0.00}", (double.Parse(tb_BillTotal.Text) - double.Parse(tb_Discount.Text)));
            tb_Total.Text = String.Format("{0:0.00}", (double.Parse(tb_AfterDiscount.Text) + double.Parse(tb_OldMoney.Text)));
            tb_render.Text = String.Format("{0:0.00}", (double.Parse(tb_Total.Text) - double.Parse(tb_payment.Text)));
        }
        private void combo_Materials_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (combo_Materials.Focused)
            {
                ShowDetails_Material((int)combo_Materials.SelectedValue);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddRow();
        }
        private void combo_Supliers_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (combo_Supliers.Focused)
            {
                ShowDetails_Supplier((int)combo_Supliers.SelectedValue);
                if (tb_PaymentMethod.Text.Contains("نقدى او شيك"))
                    panel7.Visible = true;
                else
                    panel7.Visible = false;

            }
        }
        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (combo_Supliers.SelectedIndex >= 0 && dataGridView1.Rows.Count > 0)
            {


                if (tb_PaymentMethod.Text.Contains("نقدى او شيك"))
                {
                    if(radioButton1.Checked)
                    {
                        // دفع نقدى
                        SaveCash();
                    }
                    else if(radioButton2.Checked)
                    {
                        // دفع شيك
                        SaveCheck();
                    }
                }
                else if (tb_PaymentMethod.Text.Contains("حد ائتمان"))
                {
                    SaveCreditLimit();
                }
                else if (tb_PaymentMethod.Text.Contains("دفع اجل"))
                {
                    SaveLater();
                }
                RefreshForm();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }

        private void SaveCreditLimit()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_render.Text)));

            // اضافة فاتورة شراء من المورد
            // اضافة تعامل ف حساب تعاملات المورد
            Ezzat.ExecutedNoneQuery("insertPurchasingBill",
                 new SqlParameter("@Purchasing_ID", int.Parse(label2.Text)),
                 new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue),
                 new SqlParameter("@Bill_Date", DateTime.Parse(DateTime.Now.ToString())),
                 new SqlParameter("@Payment_Method", "حد ائتمان"),
                 new SqlParameter("@Material_Money", float.Parse(tb_BillTotal.Text)),
                 new SqlParameter("@Discount_Money", float.Parse(tb_Discount.Text)),
                 new SqlParameter("@After_Discount", float.Parse(tb_AfterDiscount.Text)),
                 new SqlParameter("@Total_oldMoney", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)),
                 new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                 new SqlParameter("@After_Payment", float.Parse(tb_render.Text)),
                 new SqlParameter("@Bill_Details", richTextBox1.Text),
                 new SqlParameter("@Sheck_Number", ""),
                 new SqlParameter("@Bill_Number_Supplier", textBox1.Text)
                );

            //Add IMBill_Details
            // اضافة تفاصيل فاتورة الشراء 
            AddIMBill_Details(int.Parse(label2.Text));


            // المخازن
            EditStore();

            Ezzat.ExecutedNoneQuery("insert_CreditLimit",
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Supplier_Customer",false),
                new SqlParameter("@Bill_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Days_Number",Days_Number),
                new SqlParameter("@Bill_Type",false),
                new SqlParameter("@Bill_Total",double.Parse(tb_AfterDiscount.Text)),
                new SqlParameter("@Owner_ID", (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Owner_Name",combo_Supliers.Text)
                );

            MessageBox.Show(Shared_Class.Successful_Message);
        }

        private void SaveLater()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_render.Text)));

            // اضافة فاتورة شراء من المورد
            // اضافة تعامل ف حساب تعاملات المورد
            Ezzat.ExecutedNoneQuery("insertPurchasingBill",
                 new SqlParameter("@Purchasing_ID", int.Parse(label2.Text)),
                 new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue),
                 new SqlParameter("@Bill_Date", DateTime.Parse(DateTime.Now.ToString())),
                 new SqlParameter("@Payment_Method", "أجل"),
                 new SqlParameter("@Material_Money", float.Parse(tb_BillTotal.Text)),
                 new SqlParameter("@Discount_Money", float.Parse(tb_Discount.Text)),
                 new SqlParameter("@After_Discount", float.Parse(tb_AfterDiscount.Text)),
                 new SqlParameter("@Total_oldMoney", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)),
                 new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                 new SqlParameter("@After_Payment", float.Parse(tb_render.Text)),
                 new SqlParameter("@Bill_Details", richTextBox1.Text),
                 new SqlParameter("@Sheck_Number", ""),
                 new SqlParameter("@Bill_Number_Supplier", textBox1.Text)
                );

            //Add IMBill_Details
            // اضافة تفاصيل فاتورة الشراء 
            AddIMBill_Details(int.Parse(label2.Text));


            // المخازن
            EditStore();
            MessageBox.Show(Shared_Class.Successful_Message);
        }

        private void SaveCash()
        {
            //Suppliers

            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_render.Text)));

            // اضافة فاتورة شراء من المورد
            // اضافة تعامل ف حساب تعاملات المورد
            Ezzat.ExecutedNoneQuery("insertPurchasingBill",
                 new SqlParameter("@Purchasing_ID", int.Parse(label2.Text)),
                 new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue),
                 new SqlParameter("@Bill_Date", DateTime.Parse(DateTime.Now.ToString())),
                 new SqlParameter("@Payment_Method", "نقدي"),
                 new SqlParameter("@Material_Money", float.Parse(tb_BillTotal.Text)),
                 new SqlParameter("@Discount_Money", float.Parse(tb_Discount.Text)),
                 new SqlParameter("@After_Discount", float.Parse(tb_AfterDiscount.Text)),
                 new SqlParameter("@Total_oldMoney", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)),
                 new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                 new SqlParameter("@After_Payment", float.Parse(tb_render.Text)),
                 new SqlParameter("@Bill_Details", richTextBox1.Text),
                 new SqlParameter("@Sheck_Number", ""),
                 new SqlParameter("@Bill_Number_Supplier", textBox1.Text)
                );

            //Add IMBill_Details
            // اضافة تفاصيل فاتورة الشراء 
            AddIMBill_Details(int.Parse(label2.Text));


            // المخازن
            EditStore();


            //الخزنة
            EditSafe();
            MessageBox.Show(Shared_Class.Successful_Message);
        }

        private void EditStore()
        {

            // تعديل الكميات ف المخازن
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("updateMaterialQuantity_Increase"
                    , new SqlParameter("@Material_ID", int.Parse(item.Cells[0].Value.ToString()))
                    , new SqlParameter("@Material_Quantity",tb_quantity2.Text)
                    );
            }

            // اضافة تعاملات ف المخازن
            Ezzat.ExecutedNoneQuery("insertStoreTransaction",
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Report_Date", DateTime.Now.ToString()),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "شراء من مورد"),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );




        }

        private void EditSafe()
        {
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_payment.Text)));

            // عمل بيان صرف من الخزنة للعميل
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "صرف الى مورد"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_payment.Text)),
                new SqlParameter("@Report_Notes", "مبلغ من حساب توريد بضاعة "+richTextBox1.Text)
                );
        }

        private void AddIMBill_Details(int iD)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("insertIMBill_Details"
                    , new SqlParameter("@Bill_ID", iD)
                    , new SqlParameter("@Material_ID", int.Parse(item.Cells[0].Value.ToString()))
                    , new SqlParameter("@Material_Name", item.Cells[1].Value.ToString())
                    , new SqlParameter("@Material_PricePerUnit", item.Cells[2].Value.ToString())
                    , new SqlParameter("@Material_Quantity", float.Parse(item.Cells[3].Value + ""))
                    , new SqlParameter("@Unit", item.Cells[4].Value.ToString())
                    , new SqlParameter("@Total", float.Parse(item.Cells[5].Value + ""))
                    , new SqlParameter("@Bill_Type", true)
                    , new SqlParameter("@Material_Details", item.Cells[7].Value.ToString())
                    );
            }
        }

        private void SaveCheck()
        {

            //Suppliers

            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_render.Text)));

            // اضافة فاتورة شراء من المورد
            // اضافة تعامل ف حساب تعاملات المورد
            Ezzat.ExecutedNoneQuery("insertPurchasingBill",
                 new SqlParameter("@Purchasing_ID", int.Parse(label2.Text)),
                 new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue),
                 new SqlParameter("@Bill_Date", DateTime.Parse(DateTime.Now.ToString())),
                 new SqlParameter("@Payment_Method", "شيك"),
                 new SqlParameter("@Material_Money", float.Parse(tb_BillTotal.Text)),
                 new SqlParameter("@Discount_Money", float.Parse(tb_Discount.Text)),
                 new SqlParameter("@After_Discount", float.Parse(tb_AfterDiscount.Text)),
                 new SqlParameter("@Total_oldMoney", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)),
                 new SqlParameter("@Payment_Money", float.Parse(tb_payment.Text)),
                 new SqlParameter("@After_Payment", float.Parse(tb_render.Text)),
                 new SqlParameter("@Bill_Details", richTextBox1.Text),
                 new SqlParameter("@Sheck_Number", tb_number.Text),
                 new SqlParameter("@Bill_Number_Supplier", textBox1.Text)
                );

            Edit_BankAccount();

            // اضافة تفاصيل فاتورة الشراء 
            AddIMBill_Details(int.Parse(label2.Text));


            // المخازن
            EditStore();
            MessageBox.Show(Shared_Class.Successful_Message);

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
                new SqlParameter("@Notes", "دفع من عمليه شراء "+richTextBox1.Text),
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Report_From", combo_Bank.Text),
                new SqlParameter("@Report_To", "مورد " + combo_Supliers.Text)
                );
        }



        private void tb_Discount_Leave(object sender, EventArgs e)
        {
            tb_Discount.Text = String.Format("{0:0.00}", (double.Parse(tb_Discount.Text)));
            tb_payment.Text = String.Format("{0:0.00}", (double.Parse(tb_payment.Text)));
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            combo_Bank.Enabled = richTextBox2.Enabled = tb_number.Enabled = radioButton2.Checked;
        }



        private void tb_payment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&

            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tb_Discount_TextChanged(object sender, EventArgs e)
        {
            if (tb_Discount.Text == ".")
                tb_Discount.Text = "0.";
            if (tb_Discount.Text == "")
                tb_Discount.Text = "0";
            Calcolate();
        }

        private void tb_payment_TextChanged(object sender, EventArgs e)
        {
            if (tb_payment.Text == ".")
                tb_payment.Text = "0.";
            if (tb_payment.Text == "")
                tb_payment.Text = "0";
            Calcolate();
        }



        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Bill_Total -= double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            Calcolate();
        }

       
        private void ConvertInt(TextBox textBox)
        {
            try
            {
                int.Parse(textBox.Text);
            }
            catch
            {
                textBox.Text = "0,00";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }
    }
}