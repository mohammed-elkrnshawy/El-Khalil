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
    public partial class Owner_IMProduct : Form
    {
        int Days_Number, Product_PerUnit;
        private double MaterialPrice;
        private string MaterialUnit;
        private double Bill_Total, MaxLimit = 0;
        private DataSet dataSet;

        public Owner_IMProduct()
        {
            InitializeComponent();
        }
        private void RefForm()
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);


            object o = Ezzat.ExecutedScalar("select_OwnerReportId");
            label2.Text = o.ToString();

            tb_details.Text = "اكتب بيان الصنف";
            richTextBox1.Text = "اكتب بيان الفاتورة ";


            dataGridView1.Rows.Clear();

            tb_quantity.Text = "0";

            tb_price.Text = "0.00";
            Bill_Total = 0;
            Calcolate();


            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);

            using (dataSet = Ezzat.GetDataSet("Select_All", "X"))
            {
                combo_Materials.DataSource = dataSet.Tables["X"];
                combo_Materials.DisplayMember = "اسم الصنف";
                combo_Materials.ValueMember = "رفم الصنف";
                combo_Materials.Text = "";
                combo_Materials.SelectedText = "اختار منتج";
            }

           

        }
        private void Owner_IMProduct_Load(object sender, EventArgs e)
        {
            RefForm();
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

        private void combo_Materials_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Materials.Focused)
            {
                ShowDetails_Material((int)combo_Materials.SelectedValue);
            }
        }

        private void ShowDetails_Material(int ID)
        {

            SqlConnection con;
            SqlDataReader dr = Ezzat.GetDataReader("selectSpasificProduct2", out con, new SqlParameter("@Product_ID", ID));

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

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Bill_Total -= double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            Calcolate();
        }

        private void button3_Click(object sender, EventArgs e)
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

        private bool IsValidText(TextBox textBox)
        {
            if (textBox.Text == "")
                return false;
            else
                return true;
        }
        private void Calcolate()
        {

            tb_BillTotal.Text = String.Format("{0:0.00}", Bill_Total);
           
        }


        private void EX()
        {
            OwnerTransacton(radioButton2.Text, false);
            EditEXStore();
            AddIMBill_Details(false);
            RefForm();
        }

        private void IM()
        {
            OwnerTransacton(radioButton1.Text, true);
            EditIMStore();
            AddIMBill_Details(true);
            RefForm();
        }

        private void AddIMBill_Details(bool type)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("insertOwnerBill_Details"
                    , new SqlParameter("@Bill_ID", int.Parse(label2.Text))
                    , new SqlParameter("@Material_ID", int.Parse(item.Cells[0].Value.ToString()))
                    , new SqlParameter("@Material_Name", item.Cells[1].Value.ToString())
                    , new SqlParameter("@Material_PricePerUnit", item.Cells[2].Value.ToString())
                    , new SqlParameter("@Material_Quantity", float.Parse(item.Cells[3].Value + ""))
                    , new SqlParameter("@Unit", item.Cells[4].Value.ToString())
                    , new SqlParameter("@Total", float.Parse(item.Cells[5].Value + ""))
                    , new SqlParameter("@Bill_Type", type)
                    , new SqlParameter("@Material_Details", item.Cells[6].Value.ToString())
                    );
            }
        }

        private void OwnerTransacton(string report_type, bool transaction_type)
        {
            Ezzat.ExecutedNoneQuery("insert_OwnerTransaction",
                new SqlParameter("@report_id", label2.Text),
                new SqlParameter("@report_type", report_type),
                new SqlParameter("@report_date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@reportdetails", richTextBox1.Text),
                new SqlParameter("@totalmoney", double.Parse(tb_BillTotal.Text)),
                new SqlParameter("@transaction_type", transaction_type)
                );
        }

        private void EditEXStore()
        {

            //تعديل الكميات ف المخازن
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
                new SqlParameter("@Bill_Type", radioButton2.Text),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );

        }

        private void EditIMStore()
        {

            // تعديل الكميات ف المخازن
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
                new SqlParameter("@Bill_Type", radioButton1.Text),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );




        }
    }
}
