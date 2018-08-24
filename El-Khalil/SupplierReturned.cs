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
    public partial class SupplierReturned : Form
    {
        private double Bill_Total;
        private double MaterialPrice;
        private string MaterialUnit;
        private DataSet dataSet;
        public SupplierReturned()
        {
            InitializeComponent();
        }

        private void RefreshForm()
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);



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

            object o = Ezzat.ExecutedScalar("selectReturning_Bill_ID");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";


            dataGridView1.Rows.Clear();
            richTextBox1.Text = "اكتب بيان الفااتورة";
            tb_details.Text = "اكتب بيان الصنف";
            textBox1.Text = "";
            tb_quantity.Text = "0";
            tb_AfterDiscount.Text=tb_BillTotal.Text=tb_Discount.Text=tb_OldMoney.Text=tb_price.Text=tb_Total.Text="0.00";
            Bill_Total = 0;


        }

        private void SupplierReturned_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void combo_Supliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Supliers.Focused)
            {
                ShowDetails_Supplier((int)combo_Supliers.SelectedValue);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
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
        }


        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Bill_Total -= double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            Calcolate();
        }

        private void Save()
        {
            // تعديل حساب المورد النهائى
            Ezzat.ExecutedNoneQuery("updateTotalMoney", new SqlParameter("@Supplier_ID",
                (int)combo_Supliers.SelectedValue),
                new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)));


            // اضافة فاتورة مرتجع الى المورد
            // اضافة تعامل ف حساب تعاملات المورد
            Ezzat.ExecutedNoneQuery("insertIMReturning_Bill",
                 new SqlParameter("@Purchasing_ID", int.Parse(label2.Text)),
                 new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue),
                 new SqlParameter("@Bill_Date", DateTime.Parse(DateTime.Now.ToString())),
                 new SqlParameter("@Payment_Method", "نقدي"),
                 new SqlParameter("@Material_Money", float.Parse(tb_BillTotal.Text)),
                 new SqlParameter("@Discount_Money", float.Parse(tb_Discount.Text)),
                 new SqlParameter("@After_Discount", float.Parse(tb_AfterDiscount.Text)),
                 new SqlParameter("@Total_oldMoney", float.Parse(tb_OldMoney.Text)),
                 new SqlParameter("@Total_Money", float.Parse(tb_Total.Text)),
                 new SqlParameter("@Payment_Money", double.Parse("0.00")),
                 new SqlParameter("@Bill_Details", richTextBox1.Text),
                 new SqlParameter("@Bill_Number_Supplier",textBox1.Text)
                );

            // اضافة تفاصيل فاتورة الشراء 
            AddIMBill_Details(int.Parse(label2.Text));


            // المخازن
            EditStore();
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
                    , new SqlParameter("@Bill_Type", false)
                    , new SqlParameter("@Material_Details", item.Cells[6].Value.ToString())
                    );
            }
        }


        private void EditStore()
        {

            // تعديل الكميات ف المخازن
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("updateMaterialQuantity_Decrease"
                    , new SqlParameter("@Material_ID", int.Parse(item.Cells[0].Value.ToString()))
                    , new SqlParameter("@Material_Quantity", item.Cells[3].Value.ToString())
                    );
            }

            // اضافة تعاملات ف المخازن
            Ezzat.ExecutedNoneQuery("insertStoreTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Report_Date", DateTime.Now.ToString()),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "مرتجع الى مورد"),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );
        }







        private void ShowDetails_Supplier(int ID)
        {

            SqlConnection con;
            SqlDataReader dr = Ezzat.GetDataReader("selectSpasific_Supplier", out con, new SqlParameter("@Supplier_ID", ID));

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //Days_Number = int.Parse(dr["Number_Day"].ToString());
                    //tb_PaymentMethod.Text = dr["Payment_Method"].ToString();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (FoundBefore())
                AddRow();
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

        private void AddRow()
        {
            if (IsValidText(tb_price) && IsValidText(tb_quantity) && combo_Materials.SelectedIndex >= 0)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, dataGridView1.Rows.Count - 1].Value = combo_Materials.SelectedValue;
                dataGridView1[1, dataGridView1.Rows.Count - 1].Value = combo_Materials.Text;
                dataGridView1[2, dataGridView1.Rows.Count - 1].Value = tb_price.Text + "/" + MaterialUnit;
                dataGridView1[3, dataGridView1.Rows.Count - 1].Value = tb_quantity.Text;
                dataGridView1[4, dataGridView1.Rows.Count - 1].Value = MaterialUnit;
                dataGridView1[5, dataGridView1.Rows.Count - 1].Value = String.Format("{0:0.00}", Math.Round((double.Parse(tb_quantity.Text) * double.Parse(tb_price.Text)), 2));
                dataGridView1[6, dataGridView1.Rows.Count - 1].Value = tb_details.Text;
                Bill_Total += double.Parse(dataGridView1[5, dataGridView1.Rows.Count - 1].Value.ToString());
                Calcolate();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }

        private bool IsValidText(TextBox textBox)
        {
            if (textBox.Text == "")
                return false;
            else
                return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(double.Parse(tb_Total.Text)>=0)
            {
                if (combo_Supliers.SelectedIndex >= 0 && dataGridView1.Rows.Count > 0)
                {
                    Save();
                }
                else
                    MessageBox.Show(Shared_Class.Check_Message);
            }
            else
            {
                MessageBox.Show("المرتجع اكبر من حساب المورد");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }
    }
}
