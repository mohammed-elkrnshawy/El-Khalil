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
    public partial class Add_Supplier : Form
    {
        DataSet dataSet;
        public Add_Supplier()
        {
            InitializeComponent();
        }

        private void Add_Supplier_Load(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("selectAllSupplier", "X"))
            {
                combo_name.DataSource = dataSet.Tables["X"];
                combo_name.DisplayMember = "Supplier_Name";
                combo_name.ValueMember = "Supplier_ID";
                combo_name.Text = "";
                combo_name.SelectedText = "اختار مورد موجود";
            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            combo_name.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            combo_name.Enabled = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            if(tb_name.Text!=""&&tb_address.Text!=""&&tb_company.Text!="")
            {
                if (radioButton1.Checked)
                {
                    Add_Person();
                }
                else
                {
                    EditPerson();
                }
            }
            else{
                MessageBox.Show("من فضلك راجع البيانات");
            }
        }

        private void EditPerson()
        {
            Ezzat.ExecutedNoneQuery("updateSupplier",
                new SqlParameter("@Supplier_ID", (int)combo_name.SelectedValue),
                new SqlParameter("@Supplier_Name", tb_name.Text),
                new SqlParameter("@Supplier_Phone", tb_phone.Text),
                new SqlParameter("@Supplier_Phone2", tb_phone2.Text),
                new SqlParameter("@Supplier_Address", tb_address.Text),
                new SqlParameter("@Supplier_Company", tb_company.Text)
                );

            tb_company.Text = tb_address.Text = tb_name.Text = tb_phone.Text = tb_phone2.Text = "";
            combo_name.Text = "";
            combo_name.SelectedText = "اختار مورد موجود";
        }

        private void Add_Person()
        {
            Ezzat.ExecutedNoneQuery("insertSupplier",
                new SqlParameter("@Supplier_Name", tb_name.Text),
                new SqlParameter("@Supplier_Phone", tb_phone.Text),
                new SqlParameter("@Supplier_Phone2", tb_phone2.Text),
                new SqlParameter("@Supplier_Address", tb_address.Text),
                new SqlParameter("@Supplier_Company", tb_company.Text)
                );

            tb_company.Text = tb_address.Text = tb_name.Text = tb_phone.Text = tb_phone2.Text = "";
        }

        private void combo_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con;

            if (combo_name.SelectedIndex >= 0 && combo_name.Focused == true)
            {
               
     
                tb_name.Focus();

                SqlDataReader dataReader = Ezzat.GetDataReader("selectSpasific_Supplier", out con, new SqlParameter("@Supplier_ID", (int)combo_name.SelectedValue));


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        tb_name.Text = dataReader["Supplier_Name"].ToString();
                        tb_address.Text = dataReader["Supplier_Address"].ToString();
                        tb_company.Text = dataReader["Supplier_Company"].ToString();
                        tb_phone.Text=dataReader["Supplier_Phone"].ToString();
                        tb_phone2.Text=dataReader["Supplier_Phone2"].ToString();
                    }
                }
                con.Close();
            }
        }
    }
}
