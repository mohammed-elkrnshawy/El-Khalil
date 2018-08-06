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
    public partial class Customer_Returned : Form
    {
        private double PPrice, PQuantityPerUnit;
        private string Punit;

        private bool IsMAterial;
        private double Bill_Total, MaxLimit = 0;
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

        private void Customer_Returned_Load(object sender, EventArgs e)
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);



            using (dataSet = Ezzat.GetDataSet("Select_All", "X"))
            {
                combo_Materials.DataSource = dataSet.Tables["X"];
                combo_Materials.DisplayMember = "Material_Name";
                combo_Materials.ValueMember = "Material_ID";
                combo_Materials.Text = "";
                combo_Materials.SelectedText = "اختار منتج";
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
        }

        private void combo_Supliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Customer.Focused)
            {
                object o = Ezzat.ExecutedScalar("selectTotalMoney_Customer", new SqlParameter("@Supplier_ID", (int)combo_Customer.SelectedValue));
                tb_OldMoney.Text = String.Format("{0:0.00}", o);
   
                MaxLimit = (double)Ezzat.ExecutedScalar("selectMaxMoney_Customer", new SqlParameter("@Supplier_ID", (int)combo_Customer.SelectedValue));
                Calcolate();
            }
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

        private void combo_Materials_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] ar = new string[] { };
            if (combo_Materials.Focused)
            {
                object o = Ezzat.ExecutedScalar("selectMaterial_price_unit2", new SqlParameter("@Material_ID", (int)combo_Materials.SelectedValue)
                    , new SqlParameter("@Material_Name", combo_Materials.Text));
                if (o == null)
                {
                    IsMAterial = false;
                    o = Ezzat.ExecutedScalar("selectProduct_price_unit2", new SqlParameter("@Material_ID", (int)combo_Materials.SelectedValue)
                   , new SqlParameter("@Material_Name", combo_Materials.Text));
                    ar = o.ToString().Split('_');

                    PPrice = double.Parse(ar[0]);
                    Punit = ar[1];
                    PQuantityPerUnit = double.Parse(ar[2]);
                }
                else
                {
                    ar = o.ToString().Split('_');
                    PPrice = double.Parse(ar[0]);
                    Punit = ar[1];
                    PQuantityPerUnit = 1;
                    IsMAterial = true;
                }
            }
        }
        private void Calcolate()
        {
            tb_BillTotal.Text = String.Format("{0:0.00}", Bill_Total);

            tb_AfterDiscount.Text = String.Format("{0:0.00}", (double.Parse(tb_BillTotal.Text) - double.Parse(tb_Discount.Text)));

            tb_Total.Text = String.Format("{0:0.00}", (double.Parse(tb_OldMoney.Text) - double.Parse(tb_AfterDiscount.Text)));

            if (double.Parse(tb_AfterDiscount.Text) > double.Parse(tb_OldMoney.Text))
            {
                tb_Total.Text = "0.00";
                tb_render.Text = String.Format("{0:0.00}", (double.Parse(tb_AfterDiscount.Text) - double.Parse(tb_OldMoney.Text)));
            }
            else
                tb_render.Text = "0.00";
        }



        private void AddRow()
        {
            if (tb_quantity.Text != "" && int.Parse(tb_quantity.Text) > 0 && combo_Materials.SelectedIndex >= 0)
            {
                if (isValidItem())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, dataGridView1.Rows.Count - 1].Value = combo_Materials.SelectedValue;
                    dataGridView1[1, dataGridView1.Rows.Count - 1].Value = combo_Materials.Text;
                    dataGridView1[2, dataGridView1.Rows.Count - 1].Value = PQuantityPerUnit + " " + Punit + "/" + PPrice;
                    dataGridView1[3, dataGridView1.Rows.Count - 1].Value = MaterialConvertUnits(tb_quantity.Text, Punit);
                    dataGridView1[4, dataGridView1.Rows.Count - 1].Value = Punit;
                    if (IsMAterial)
                    {
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value = MaterialConvertUnits(tb_quantity.Text, Punit) * PPrice;
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = true;
                    }
                    else
                    {
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value = (MaterialConvertUnits(tb_quantity.Text, Punit) / PQuantityPerUnit) * PPrice;
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = false;
                    }

                    Bill_Total += (double)dataGridView1[5, dataGridView1.Rows.Count - 1].Value;
                    Calcolate();
                }
            }
        }


        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Bill_Total -= double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            Calcolate();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            Bill_Total -= double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            string[] ar = dataGridView1.CurrentRow.Cells[2].Value.ToString().Split('/');

            double CellPrice = double.Parse(ar[1]);

            ar = ar[0].Split(' ');
            double CellPerUnit = double.Parse(ar[0]);

            dataGridView1.CurrentRow.Cells[5].Value = String.Format("{0:0.00}", ((double.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString()) / CellPerUnit) * CellPrice));


            Bill_Total += double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            Calcolate();
        }

        private void tb_Discount_TextChanged(object sender, EventArgs e)
        {
            if (tb_Discount.Text == ".")
                tb_Discount.Text = "0.";
            if (tb_Discount.Text == "")
                tb_Discount.Text = "0";
            Calcolate();
        }


        //بترجع الكمية عشان الفاتورة
        private double MaterialConvertUnits(string tb_quantity, string MaterialUnit)
        {
            if (MaterialUnit.Contains("كجم"))
            {
                if (radioButton1.Checked)
                {
                    return (double.Parse(tb_quantity) * 1000);
                }
                else if (radioButton2.Checked)
                {
                    return double.Parse(tb_quantity);
                }
                else
                {
                    return (double.Parse(tb_quantity) / 1000);
                }
            }
            else
            {
                if (radioButton1.Checked)
                {
                    return (double.Parse(tb_quantity) * 1000 * 1000);
                }
                else if (radioButton2.Checked)
                {
                    return (double.Parse(tb_quantity) * 1000);
                }
                else
                {
                    return double.Parse(tb_quantity);
                }
            }
        }

        private bool isValidItem()
        {
            bool Valid = true;

            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                if (item.Cells[1].Value.ToString() == combo_Materials.Text)
                {
                    MessageBox.Show("هذا المنتج موجود مسبقا ف التقرير");
                    Valid = false;
                    break;
                }

            }
            return Valid;
        }


        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (combo_Customer.SelectedIndex >= 0 && dataGridView1.Rows.Count > 0)
                Save();
            else
                MessageBox.Show("من فضلك راجع البيانات");
        }



        private void Save()
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
                 new SqlParameter("@Payment_Method", "نقدي"),
                 new SqlParameter("@Material_Money", float.Parse(tb_BillTotal.Text)),
                 new SqlParameter("@Discount_Money", float.Parse(tb_Discount.Text)),
                 new SqlParameter("@After_Discount", float.Parse(tb_AfterDiscount.Text)),
                 new SqlParameter("@Total_oldMoney", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)),
                 new SqlParameter("@Payment_Money", float.Parse(tb_render.Text))
                );


            // اضافة تفاصيل فاتورة الشراء 
            AddIMBill_Details(int.Parse(label2.Text));


            // المخازن
            EditStore();


            //الخزنة
            // لو اجمالى المرتجع اكبر من حساب المورد
            if (double.Parse(tb_render.Text) > 0)
                EditSafe();

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


        private void EditStore()
        {
            //تعديل الكميات ف المخازن
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if ((bool)item.Cells[6].Value)
                {
                    Ezzat.ExecutedNoneQuery("updateMaterialQuantity_Increase"
                   , new SqlParameter("@Material_ID", int.Parse(item.Cells[0].Value.ToString()))
                   , new SqlParameter("@Material_Quantity", float.Parse(item.Cells[3].Value + ""))
                   );
                }
                else
                {
                    Ezzat.ExecutedNoneQuery("updateProductQuantity_Increase"
                  , new SqlParameter("@Material_ID", int.Parse(item.Cells[0].Value.ToString()))
                  , new SqlParameter("@Material_Quantity", float.Parse(item.Cells[3].Value + ""))
                  );
                }
            }

          

            // اضافة تعاملات ف المخازن
            Ezzat.ExecutedNoneQuery("insertStoreTransaction",
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Report_Date", DateTime.Now.ToString()),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "مرتجع من عميل"),
                new SqlParameter("@Report_Notes", combo_Customer.Text)
                );
        }

        

        private void EditSafe()
        {
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_render.Text)));

            // عمل بيان توريد من المورد للخزنة
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "باقى مبلغ مرتجع من عميل"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_render.Text)),
                new SqlParameter("@Report_Notes", "مبلغ من مرتجع عميل")
                );
        }

    }
}
