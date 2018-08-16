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

        private void Purchasing_Load(object sender, EventArgs e)
        {
            

            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);



            using (dataSet = Ezzat.GetDataSet("selectMaterials", "X"))
            {
                combo_Materials.DataSource = dataSet.Tables["X"];
                combo_Materials.DisplayMember = "Material_Name";
                combo_Materials.ValueMember = "Material_ID";
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

            object o = Ezzat.ExecutedScalar("selectPurchasing_Bill_ID");
           
            if (o == null)
                label2.Text = "1";
            else
                label2.Text=(((int)o) + 1) + "";
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
            if(tb_quantity.Text!=""&&int.Parse(tb_quantity.Text)>0 && combo_Materials.SelectedIndex >= 0)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, dataGridView1.Rows.Count - 1].Value = combo_Materials.SelectedValue;
                dataGridView1[1, dataGridView1.Rows.Count - 1].Value = combo_Materials.Text;
                dataGridView1[2, dataGridView1.Rows.Count - 1].Value = MaterialPrice + "/" + MaterialUnit;
                dataGridView1[3, dataGridView1.Rows.Count - 1].Value = tb_quantity.Text;
                dataGridView1[4, dataGridView1.Rows.Count - 1].Value = checkUnit();
                dataGridView1[5, dataGridView1.Rows.Count - 1].Value = String.Format("{0:0.00}", Math.Round(ConvertUnits(MaterialPrice, tb_quantity.Text), 2));

                Bill_Total += Math.Round(ConvertUnits(MaterialPrice, tb_quantity.Text), 2);
                Calcolate();
            }
            else
                MessageBox.Show("من فضلك راجع البيانات");
        }


        //بترجع السعر عشان الفاتورة
        private double ConvertUnits(double MaterialPrice,string tb_quantity)
        {
            if(MaterialUnit.Contains("كجم"))
            {
                if(checkUnit().Equals("طن"))
                {
                    return (double.Parse(tb_quantity) * 1000 * MaterialPrice);
                }
                else if (checkUnit().Equals("كجم"))
                {
                    return (double.Parse(tb_quantity) * MaterialPrice);
                }
                else
                {
                    return (double.Parse(tb_quantity) / 1000 * MaterialPrice);
                }
            }
            else
            {
                if(checkUnit().Equals("طن"))
                {
                    return (double.Parse(tb_quantity) * 1000 * 1000 * MaterialPrice);
                }
                else if (checkUnit().Equals("كجم"))
                {
                    return (double.Parse(tb_quantity) * 1000 * MaterialPrice);
                }
                else
                {
                    return (double.Parse(tb_quantity) * MaterialPrice);
                }
            }
        }


        private void combo_Materials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo_Materials.Focused)
            {
                object o = Ezzat.ExecutedScalar("selectMaterial_price_unit", new SqlParameter("@Material_ID", (int)combo_Materials.SelectedValue));
                String[] ar = o.ToString().Split('_');
                MaterialPrice = double.Parse(ar[0]);
                MaterialUnit = ar[1];
            }
        }


        private string checkUnit()
        {
            if (radioButton4.Checked)
                return radioButton4.Text;
            else if (radioButton1.Checked)
                return radioButton1.Text;
            else
                return radioButton2.Text;
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
            tb_BillTotal.Text = String.Format("{0:0.00}", Bill_Total);
            tb_AfterDiscount.Text = String.Format("{0:0.00}", (double.Parse(tb_BillTotal.Text) - double.Parse(tb_Discount.Text)));
            tb_Total.Text= String.Format("{0:0.00}", (double.Parse(tb_AfterDiscount.Text) + double.Parse(tb_OldMoney.Text)));
            tb_render.Text= String.Format("{0:0.00}", (double.Parse(tb_Total.Text) - double.Parse(tb_payment.Text)));
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

        private void tb_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tb_Discount.Text.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
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

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            string [] a= dataGridView1.CurrentRow.Cells[2].Value.ToString().Split('/');

            dataGridView1.CurrentRow.Cells[5].Value = String.Format("{0:0.00}", ConvertUnits(
                double.Parse(a[0]), dataGridView1.CurrentRow.Cells[3].Value.ToString()
                ));



            Bill_Total += double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            Calcolate();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Bill_Total -= double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Bill_Total -= double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            Calcolate();
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if(combo_Supliers.SelectedIndex>=0&&dataGridView1.Rows.Count>0)
            {
                if (rb_cash.Checked)
                {
                    SaveCash();
                }
                else
                {
                    Supplier_Purchasing_Bank supplier = new Supplier_Purchasing_Bank(
                        label2.Text,
                        tb_BillTotal.Text,
                        tb_Discount.Text,
                        tb_AfterDiscount.Text,
                        tb_OldMoney.Text,
                        tb_Total.Text,
                        combo_Supliers.Text,
                        combo_Supliers.SelectedValue
                        );
                    supplier.ShowDialog();

                    // اضافة تفاصيل فاتورة الشراء 
                    AddIMBill_Details(int.Parse(label2.Text));


                    // المخازن
                    EditStore();
                }


                Clear();

            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }



        private void SaveCash()
        {
            //Suppliers

            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue), new SqlParameter("@Total_Money", float.Parse(tb_render.Text)));

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
                 new SqlParameter("@Bill_Details","")
                );

            //Add IMBill_Details
            // اضافة تفاصيل فاتورة الشراء 
            AddIMBill_Details(int.Parse(label2.Text));


            // المخازن
            EditStore();


            //الخزنة
            EditSafe();

        }

        private void EditStore()
        {

            // تعديل الكميات ف المخازن
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("updateMaterialQuantity_Increase"
                    , new SqlParameter("@Material_ID", int.Parse(item.Cells[0].Value.ToString()))
                    , new SqlParameter("@Material_Quantity",
                    CalcolateQuantity(float.Parse(item.Cells[3].Value + ""), item.Cells[2].Value.ToString(), item.Cells[4].Value.ToString()))
                    );
            }

            // اضافة تعاملات ف المخازن
            Ezzat.ExecutedNoneQuery("insertStoreTransaction",
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Report_Date", DateTime.Now.ToString()),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "شراء من مورد"),
                new SqlParameter("@Report_Notes", combo_Supliers.Text)
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
                new SqlParameter("@Report_Notes", "مبلغ من حساب توريد بضاعة")
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
                    );
            }
        }
        

        private float CalcolateQuantity(float MaterialQuantity,String MaterialUnit,String PurchasingUint)
        {
            if (MaterialUnit.Contains("كجم"))
            {
                if (PurchasingUint.Equals("طن"))
                {
                    return  MaterialQuantity*1000;
                }
                else if (checkUnit().Equals("كجم"))
                {
                    return MaterialQuantity ;
                }
                else
                {
                    return MaterialQuantity / 1000;
                }
            }
            else
            {
                if (checkUnit().Equals("طن"))
                {
                    return MaterialQuantity * 1000*1000;
                }
                else if (checkUnit().Equals("كجم"))
                {
                    return MaterialQuantity * 1000;
                }
                else
                {
                    return MaterialQuantity;
                }
            }
        }

        private void tb_Discount_Leave(object sender, EventArgs e)
        {
            tb_Discount.Text = String.Format("{0:0.00}", (double.Parse(tb_Discount.Text)));
            tb_payment.Text = String.Format("{0:0.00}", (double.Parse(tb_payment.Text)));
        }

        private void rb_cash_CheckedChanged(object sender, EventArgs e)
        {
                tb_payment.Enabled = rb_cash.Checked;
        }



        private void Clear()
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);
            label2.Text = (int.Parse(label2.Text)+1)+"";

            combo_Materials.Text = "";
            combo_Materials.SelectedText = "اختار مادة خام";

            combo_Supliers.Text = "";
            combo_Supliers.SelectedText = "اختار اسم المورد";

            dataGridView1.Rows.Clear();

            tb_quantity.Text = "0";
            tb_payment.Text = tb_OldMoney.Text = tb_Discount.Text = tb_BillTotal.Text = tb_AfterDiscount.Text = tb_render.Text = tb_Total.Text = "0.00";
        }
    }
}
