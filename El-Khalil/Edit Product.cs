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
    public partial class Edit_Product : Form
    {
        DataSet dataSet;
        public Edit_Product()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.Black, 1);
                var point1 = new Point(0, 0);
                var point2 = new Point(5000, 0);
                g.DrawLine(p, point1, point2);
            }
        }

        private void Edit_Product_Load(object sender, EventArgs e)
        {
            panel2.Enabled = false;

            using (dataSet = Ezzat.GetDataSet("selectAllProducts", "x"))
            {
                comboBox1.DataSource = dataSet.Tables["x"];
                comboBox1.DisplayMember = "Product_Name";
                comboBox1.ValueMember = "Product_ID";
                comboBox1.Text = "";
                comboBox1.SelectedText = "اختار منتج نهائى";

            }


            using (dataSet = Ezzat.GetDataSet("selectMaterials", "x"))
            {
                combo_name.DataSource = dataSet.Tables["x"];
                combo_name.DisplayMember = "Material_Name";
                combo_name.ValueMember = "Material_ID";
                combo_name.Text = "";
                combo_name.SelectedText = "اختار مادة خام";

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con;

            if (comboBox1.SelectedIndex>=0&&comboBox1.Focused==true)
            {
                panel2.Enabled = true;

                tb_name.Focus();

                SqlDataReader dataReader = Ezzat.GetDataReader("selectSpasificProduct", out con, new SqlParameter("@Product_ID",(int)comboBox1.SelectedValue));


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        tb_name.Text = dataReader["Product_Name"].ToString();
                        tb_sell.Text = dataReader["Product_Price"].ToString();
                        tb_per.Text = dataReader["Product_QuqntityPerUnit"].ToString();
                        selectCheck_Unit(dataReader["Product_Unit"].ToString());
                    }
                }
                con.Close();


                using (dataSet=Ezzat.GetDataSet("selectComponent","X",new SqlParameter("@Prpduct_ID", int.Parse(comboBox1.SelectedValue+""))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }

            }
        }

        private void selectCheck_Unit(string v)
        {
            if (v.Contains("كجم"))
            {
                radioButton1.Checked = true;
            }
            else
                radioButton3.Checked = true;
        }

        private void tb_per_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tb_quantity.Text.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tb_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tb_quantity.Text.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter && combo_name.SelectedIndex >= 0 && tb_quantity.Text != "")
            {
                AddRow();
            }
        }
        private void AddRow()
        {

            DataTable dataTable = (DataTable)dataGridView1.DataSource;
            DataRow drToAdd = dataTable.NewRow();

            drToAdd[0] = combo_name.SelectedValue;
            drToAdd[1] = combo_name.Text;
            drToAdd[2] = tb_quantity.Text;
            drToAdd[3] = checkUnit(radioButton2);

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();
        }
        private string checkUnit(RadioButton Kilo)
        {
            if (Kilo.Checked)
            {
                return "كجم";
            }
            else
            {
                return "جم";
            }
        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {

            if (tb_name.Text != "" && tb_sell.Text != "" && tb_per.Text != "" && dataGridView1.Rows.Count > 0)
            {
                Ezzat.ExecutedNoneQuery("updateProduct"
               , new SqlParameter("@Product_ID", (int)comboBox1.SelectedValue)
               , new SqlParameter("@Product_Name", tb_name.Text)
               , new SqlParameter("@Product_Unit", checkUnit(radioButton1))
               , new SqlParameter("@Product_Price", float.Parse(tb_sell.Text))
               , new SqlParameter("@Product_per", int.Parse(tb_per.Text))
               );

                Ezzat.ExecutedNoneQuery("deleteComponent"
                   , new SqlParameter("@Product_ID", (int)comboBox1.SelectedValue)
                   );

                AddComponents(comboBox1.SelectedValue);
            }
            else
            {
                MessageBox.Show("من فضلك راجع البيانات");
            }
        }

        private void AddComponents(object iD)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("insertComponent"
                    , new SqlParameter("@Product_ID", iD)
                    , new SqlParameter("@Material_ID", item.Cells[0].Value.ToString())
                    , new SqlParameter("@Component_Unit", item.Cells[3].Value.ToString())
                    , new SqlParameter("@Component_Name", item.Cells[1].Value.ToString())
                    , new SqlParameter("@Component_Quantity", float.Parse(item.Cells[2].Value + ""))
                    );
            }
            CleanData();
        }

        private void CleanData()
        {
            MessageBox.Show("تم الحفظ بنجاح");
            tb_sell.Text = tb_quantity.Text = tb_per.Text = tb_name.Text = "";
            panel2.Enabled = false;
            comboBox1.Text = "";
            comboBox1.SelectedText = "اختار منتج نهائى";
            combo_name.Text = "";
            combo_name.SelectedText = "اختار مادة خام";
            dataGridView1.DataSource = null;
        }
    }
}
