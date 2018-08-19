using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Khalil
{
    public partial class Add_Materials : Form
    {
        object Product_ID;
        DataSet dataSet;
        public Add_Materials()
        {
            InitializeComponent();
        }

        private void Add_Materials_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void getAllProducts()
        {

            using (dataSet = Ezzat.GetDataSet("Select_All", "X"))
            {
                dataGridView2.DataSource = dataSet.Tables["X"];
            }

           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private string checkUnit()
        {
            if(radioButton2.Checked)
            {
                return radioButton2.Text;
            }
            else
            {
                return cb_gram.Text;
            }
        }
        private string checkUnit2()
        {
            if (radioButton1.Checked)
            {
                return radioButton1.Text;
            }
            else
            {
                return radioButton4.Text;
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
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

        private void getAllMaterial()
        {
            using (dataSet = Ezzat.GetDataSet("selectMaterials", "x"))
            {
                combo_name.DataSource = dataSet.Tables["x"];
                combo_name.DisplayMember = "Product_Name";
                combo_name.ValueMember = "Product_ID";
                combo_name.Text = "";
                combo_name.SelectedText = "اختار مادة خام";

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Focused)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    panel6.Enabled = false;
                }
                else
                {
                    panel6.Enabled = true;
                    getAllMaterial();
                }
            }
        }

        private void Add()
        {
            Ezzat.ExecutedScalar("insertProduct",
                       new SqlParameter("@Product_Name", tb_name.Text),
                       new SqlParameter("@product_Unit", checkUnit()),
                       new SqlParameter("@Product_Price", float.Parse(tb_price.Text)),
                       new SqlParameter("@Product_Sell", float.Parse(tb_sell.Text)),
                       new SqlParameter("@Product_PerUnit", float.Parse(tb_per.Text)),
                       new SqlParameter("@Product_Type", comboBox1.SelectedIndex)
                       );
        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if(tb_name.Text != "" && tb_per.Text != ""&& tb_price.Text != ""&&tb_sell.Text !="")
                {
                    Add();
                    MessageBox.Show(Shared_Class.Add_Message);
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show(Shared_Class.Check_Message);
                }
            }
            else if(comboBox1.SelectedIndex==1)
            {
                if (tb_name.Text != "" && tb_per.Text != "" && tb_price.Text != "" && tb_sell.Text != ""&&dataGridView1.Rows.Count>0)
                {
                    Add();
                    AddComponents(Product_ID);
                    MessageBox.Show(Shared_Class.Add_Message);
                }
                else
                    MessageBox.Show(Shared_Class.Check_Message);
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);

        }

        private void AddComponents(object product_ID)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("insertComponent"
                    , new SqlParameter("@Product_ID", product_ID)
                    , new SqlParameter("@Material_ID", item.Cells[0].Value.ToString())
                    , new SqlParameter("@Component_Unit", item.Cells[3].Value.ToString())
                    , new SqlParameter("@Component_Name", item.Cells[1].Value.ToString())
                    , new SqlParameter("@Component_Quantity", float.Parse(item.Cells[2].Value + ""))
                    );
            }
            RefreshForm();
        }

        private void AddRow()
        {
            if (combo_name.SelectedIndex >= 0)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, dataGridView1.Rows.Count - 1].Value = combo_name.SelectedValue;
                dataGridView1[1, dataGridView1.Rows.Count - 1].Value = combo_name.Text;
                dataGridView1[2, dataGridView1.Rows.Count - 1].Value = tb_quantity.Text;
                dataGridView1[3, dataGridView1.Rows.Count - 1].Value = checkUnit2();
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        private void combo_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo_name.Focused)
            {
                object o = Ezzat.ExecutedScalar("select_Unit", new SqlParameter("@Product_Id", combo_name.SelectedValue));
                if (o.ToString().Contains("كجم"))
                    radioButton1.Checked = true;
                else
                    radioButton4.Checked = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                getAllProducts();
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("Select_All_Search", "X",new SqlParameter("@Product_Name",textBox1.Text)))
                {
                    dataGridView2.DataSource = dataSet.Tables["X"];
                }
            }

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bt_edit.Enabled =button1.Enabled= true;
            comboBox1.Enabled = false;
            bt_Save.Enabled = false;
            panel9.Enabled = false;


            Product_ID = dataGridView2.CurrentRow.Cells[0].Value;
            ShowDetails((int)Product_ID);
        }

        private void ShowDetails(int ID)
        {
           
            SqlConnection con;
            SqlDataReader dr = Ezzat.GetDataReader("selectSpasificProduct", out con, new SqlParameter("@Product_ID", ID));

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    comboBox1.SelectedIndex = int.Parse(dr[2].ToString());
                    tb_name.Text = dr[1].ToString();
                    tb_price.Text = dr[6].ToString();
                    tb_sell.Text = dr[7].ToString();
                    tb_per.Text = dr[5].ToString();
                }
            }
            SelectComponents(comboBox1.SelectedIndex);
            con.Close();
        }

        private void SelectComponents(int Type)
        {
            dataGridView1.Rows.Clear();
            if(Type==0)
            {
                panel6.Enabled = false;
                
            }
            else
            {
                getAllMaterial();
                SqlConnection con;
                panel6.Enabled = true;


                SqlDataReader dr = Ezzat.GetDataReader("selectComponent", out con, new SqlParameter("@Prpduct_ID", Product_ID));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dr[0].ToString();
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dr[1].ToString();
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dr[2].ToString();
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = dr[3].ToString();
                    }
                }
                con.Close();

            }
        }

        private void Edit()
        {
            Ezzat.ExecutedNoneQuery("updateProduct"
               , new SqlParameter("@Product_ID",Product_ID)
               , new SqlParameter("@Product_Name", tb_name.Text)
               , new SqlParameter("@Product_Price", float.Parse(tb_price.Text))
               , new SqlParameter("@Product_Sell", float.Parse(tb_sell.Text))
               );
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (tb_name.Text != "")
            {
                Edit();
                if (comboBox1.SelectedIndex == 1)
                {
                    Ezzat.ExecutedNoneQuery("deleteComponent"
                       , new SqlParameter("@Product_ID", Product_ID)
                       );
                    AddComponents(Product_ID);
                }
                MessageBox.Show(Shared_Class.Edit_Message);
                RefreshForm();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }

        private void Delete()
        {
            Ezzat.ExecutedNoneQuery("deleteProduct", new SqlParameter("@Product_ID", Product_ID));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tb_name.Text != "")
            {
                Delete();
                if (comboBox1.SelectedIndex == 1)
                {
                    Ezzat.ExecutedNoneQuery("deleteComponent"
                       , new SqlParameter("@Product_ID", Product_ID)
                       );
                }
                MessageBox.Show(Shared_Class.Delete_Message);
                RefreshForm();
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }


        private void RefreshForm()
        {
            getAllProducts();
            comboBox1.Text = "اختار نوع الصنف";
            combo_name.Text = "اختار المادة الخام";
            tb_name.Text = textBox1.Text = "";
            tb_per.Text = tb_quantity.Text = "1";
            tb_sell.Text = tb_price.Text = "0";


            bt_Save.Enabled =comboBox1.Enabled=panel9.Enabled = true;
            bt_edit.Enabled = button1.Enabled = false;
            panel6.Enabled = false;

            dataGridView1.Rows.Clear();
        }

        private void tb_price_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(tb_price.Text);
            }
            catch
            {
                tb_price.Text = "0";
            }
        }

        private void tb_sell_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(tb_sell.Text);
            }
            catch
            {
                tb_sell.Text = "0";
            }
        }

        private void tb_per_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(tb_per.Text);
            }
            catch
            {
                tb_per.Text = "1";
            }
        }

        private void tb_quantity_Leave(object sender, EventArgs e)
        {
            try
            {
                double.Parse(tb_quantity.Text);
            }
            catch
            {
                tb_quantity.Text = "1";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }
    }
}
    
