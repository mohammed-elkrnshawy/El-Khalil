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
    public partial class Productivity_Product : Form
    {

        private List<z_Product_Object> product_ObjectsList = new List<z_Product_Object>();

        private string Product_QuqntityPerUnit, Product_Unit;
        private DataSet ds;
        public Productivity_Product()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void Productivity_Product_Load(object sender, EventArgs e)
        {
            label5.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);

            object o = Ezzat.ExecutedScalar("selectProduction_Bill_ID");

            if (o == null)
                label6.Text = "1";
            else
                label6.Text = (((int)o) + 1) + "";

            using (ds=Ezzat.GetDataSet("selectAllProducts", "X"))
            {
                combo_Products.DataSource = ds.Tables["X"];
                combo_Products.DisplayMember = "Product_Name";
                combo_Products.ValueMember = "Product_ID";
                combo_Products.Text = "";
                combo_Products.SelectedText = "اختار منتج نهائى";
            }
        }

        private void combo_Products_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con;
            if (combo_Products.Focused)
            {
                using (ds = Ezzat.GetDataSet("selectComponent", "X", new SqlParameter("@Prpduct_ID", int.Parse(combo_Products.SelectedValue + ""))))
                {
                    dataGridView1.DataSource = ds.Tables["X"];
                }

                SqlDataReader dataReader = Ezzat.GetDataReader("selectSpasificProduct", out con, new SqlParameter("@Product_ID", (int)combo_Products.SelectedValue));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Product_Unit = dataReader["Product_Unit"].ToString();
                        Product_QuqntityPerUnit = dataReader["Product_QuqntityPerUnit"].ToString();
                    }
                }
                con.Close();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRow();
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
            if (tb_quantity.Text != "" && int.Parse(tb_quantity.Text) > 0 && combo_Products.SelectedIndex >= 0)
            {
                if (isValidItem()&& CalcolateReqireQuantitiy())
                {
                    dataGridView2.Rows.Add();
                    dataGridView2[0, dataGridView2.Rows.Count - 1].Value = combo_Products.SelectedValue;
                    dataGridView2[1, dataGridView2.Rows.Count - 1].Value = combo_Products.Text;
                    dataGridView2[2, dataGridView2.Rows.Count - 1].Value = Product_QuqntityPerUnit + "/" + Product_Unit;
                    dataGridView2[3, dataGridView2.Rows.Count - 1].Value = tb_quantity.Text;
                    dataGridView2[4, dataGridView2.Rows.Count - 1].Value = Product_Unit;
                }

            }
            else
                MessageBox.Show("من فضلك راجع البيانات");
        }



        private bool isValidItem()
        {
            bool Valid=true;

            foreach (DataGridViewRow item in dataGridView2.Rows)
            {

                if(item.Cells[0].Value.ToString()==combo_Products.SelectedValue.ToString())
                {
                    MessageBox.Show("هذا المنتج موجود مسبقا ف التقرير");
                    Valid = false;
                    break;
                }
               
            }
            return Valid;
        }

        private void dataGridView2_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteFromCalcolateReqireQuantitiy((int)dataGridView2.CurrentRow.Cells[0].Value);
        }

        private bool CalcolateReqireQuantitiy()
        {
            bool Valid = true;

            List<z_Product_Component> componentList = new List<z_Product_Component>();
            
            double p = double.Parse(tb_quantity.Text) / double.Parse(Product_QuqntityPerUnit);


            foreach (DataGridViewRow item in dataGridView1.Rows)
            {

                double RequireQuantity = p * double.Parse(item.Cells[2].Value.ToString());
                componentList.Add(new z_Product_Component(item.Cells[1].Value.ToString(), RequireQuantity));
            }

            product_ObjectsList.Add(new z_Product_Object((int)combo_Products.SelectedValue, componentList));



            List<z_Product_Component> zs= z_Product_Object.SumOfMaterial(product_ObjectsList);

            foreach(z_Product_Component item in zs)
            {
               double quantity=(double)Ezzat.ExecutedScalar("selectMaterialQuantity", new SqlParameter("@Material_Name", item.MatrialName));
                if (quantity >= item.Quantitiy)
                    Valid=true;
                else
                {
                    DeleteFromCalcolateReqireQuantitiy((int)combo_Products.SelectedValue);
                    MessageBox.Show(" لا يوجد كمية من المادة الخام "+item.MatrialName);
                    Valid=false;
                    break;
                }
            }

            return Valid;
        }

        private void DeleteFromCalcolateReqireQuantitiy(int product_ID)
        {
            foreach (z_Product_Object item in product_ObjectsList.ToArray())
            {
                if (item.Product_Id == product_ID)
                {
                    product_ObjectsList.Remove(item);
                }
            }
        }

        private void bt_Print_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            //اضافة تعاملات ف المخازن
            Add_ProductionTransaction();

            // تعديل كمية المواد الخام ف المخازن 
            editStore();
        }

        private void Add_ProductionTransaction()
        {
            Ezzat.ExecutedNoneQuery("insert_ProductionTransaction", new SqlParameter("@Report_date",DateTime.Parse(DateTime.Now.ToString())));
        }

        private void editStore()
        {
            // تعديل الكميات ف المخازن
            // تعديل كمية المواد الخام ف المخازن 
            foreach (z_Product_Component item in z_Product_Object.SumOfMaterial(product_ObjectsList))
            {
                Ezzat.ExecutedNoneQuery("updateMaterialQuantity_Decrease_BYNAME"
                    , new SqlParameter("@Material_Name", item.MatrialName)
                    , new SqlParameter("@Material_Quantity",item.Quantitiy));


                //اضافة تعاملات ف المخازن بصرف المواد الخام
                Ezzat.ExecutedNoneQuery("insert_ProductionMaterial"
                    ,new SqlParameter("@Production_ID",int.Parse(label6.Text))
                    ,new SqlParameter("@Material_Name",item.MatrialName)
                    ,new SqlParameter("@Material_Quantity",item.Quantitiy)
                    );


            }

            // اضافة كمية من المنتج النهائى
            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                Ezzat.ExecutedNoneQuery("updateProductQuantity_Increase"
                    , new SqlParameter("@Product_ID", int.Parse(item.Cells[0].Value.ToString()))
                    , new SqlParameter("@Product_Quantity", float.Parse(item.Cells[3].Value + ""))
                    );


                //اضافة تعاملات ف المخازن بابتاج منتح نهائى
                Ezzat.ExecutedNoneQuery("insert_ProductionProduct"
                    , new SqlParameter("@Production_ID", int.Parse(label6.Text))
                    , new SqlParameter("@Product_ID", int.Parse(item.Cells[0].Value + ""))
                    , new SqlParameter("@Product_Name", item.Cells[1].Value + "")
                    , new SqlParameter("@Product_Unit", item.Cells[4].Value + "")
                    , new SqlParameter("@Product_Quantity", float.Parse(item.Cells[3].Value+""))
                    );

            }

            //اضافة تعامل ف المخازن

            // صرف مواد خام
            Ezzat.ExecutedNoneQuery("insertStoreTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Report_Date", DateTime.Now.ToString()),
                new SqlParameter("@Bill_ID", int.Parse(label6.Text)),
                new SqlParameter("@Bill_Type", "صرف مواد خام"),
                new SqlParameter("@Report_Notes", "صرف مواد خام لانتاج منتج نهائى")
                );

            // اضافة منتج نهائى
            Ezzat.ExecutedNoneQuery("insertStoreTransaction",
                new SqlParameter("@Report_Type", true),
                new SqlParameter("@Report_Date", DateTime.Now.ToString()),
                new SqlParameter("@Bill_ID", int.Parse(label6.Text)),
                new SqlParameter("@Bill_Type", "زيادة منتج نهائى"),
                new SqlParameter("@Report_Notes", "انتاج منتج نهائى")
                );

        }

        


    }
}
