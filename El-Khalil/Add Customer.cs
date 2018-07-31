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
    public partial class Add_Customer : Form
    {
        DataSet dataSet;
        public Add_Customer()
        {
            InitializeComponent();
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
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.Black, 1);
                var point1 = new Point(0, 0);
                var point2 = new Point(5000, 0);
                g.DrawLine(p, point1, point2);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            combo_name.Enabled = false;
            label4.Text = "اضافة عميل جديد";
            tb_address.Text = tb_company.Text = tb_name.Text = tb_phone.Text = tb_phone2.Text=tb_max.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            combo_name.Enabled = true;
            label4.Text = "تعديل عميل موجود";
        }

        private void tb_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            if (tb_name.Text != "" && tb_address.Text != "" && tb_company.Text != ""&&tb_max.Text!="")
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
            else
            {
                MessageBox.Show("من فضلك راجع البيانات");
            }
        }
        private void EditPerson()
        {
            Ezzat.ExecutedNoneQuery("updateCusomer",
                new SqlParameter("@Customer_ID", (int)combo_name.SelectedValue),
                new SqlParameter("@Customer_Name", tb_name.Text),
                new SqlParameter("@Customer_Phone", tb_phone.Text),
                new SqlParameter("@Customer_Phone2", tb_phone2.Text),
                new SqlParameter("@Customer_Address", tb_address.Text),
                new SqlParameter("@Customer_Company", tb_company.Text),
                new SqlParameter("@Customer_Max", tb_max.Text)
                );

            tb_company.Text = tb_address.Text = tb_name.Text = tb_phone.Text = tb_phone2.Text = tb_max.Text = "";
            combo_name.Text = "";
            combo_name.SelectedText = "اختار مورد موجود";
            FillCombo();
        }

        private void Add_Person()
        {
            Ezzat.ExecutedNoneQuery("insertCusomer",
                new SqlParameter("@Customer_Name", tb_name.Text),
                new SqlParameter("@Customer_Phone", tb_phone.Text),
                new SqlParameter("@Customer_Phone2", tb_phone2.Text),
                new SqlParameter("@Customer_Address", tb_address.Text),
                new SqlParameter("@Customer_Company", tb_company.Text),
                new SqlParameter("@Customer_Max", float.Parse(tb_max.Text))
                );

            tb_company.Text = tb_address.Text = tb_name.Text = tb_phone.Text = tb_phone2.Text=tb_max.Text = "";
            FillCombo();
        }

        private void Add_Customer_Load(object sender, EventArgs e)
        {
            FillCombo();
        }

        private void combo_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con;

            if (combo_name.SelectedIndex >= 0 && combo_name.Focused == true)
            {


                tb_name.Focus();

                SqlDataReader dataReader = Ezzat.GetDataReader("selectSpasific_Customer", out con, new SqlParameter("@Customer_Id", (int)combo_name.SelectedValue));


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        tb_name.Text = dataReader["Customer_Name"].ToString();
                        tb_address.Text = dataReader["Customer_Address"].ToString();
                        tb_company.Text = dataReader["Customer_Company"].ToString();
                        tb_phone.Text = dataReader["Customer_Phone"].ToString();
                        tb_phone2.Text = dataReader["Customer_Phone2"].ToString();
                        tb_max.Text = dataReader["Customer_Max"].ToString();
                    }
                }
                con.Close();
            }
        }
        private void FillCombo()
        {
            using (dataSet = Ezzat.GetDataSet("selectAllCustomer", "X"))
            {
                combo_name.DataSource = dataSet.Tables["X"];
                combo_name.DisplayMember = "Customer_Name";
                combo_name.ValueMember = "Customer_ID";
                combo_name.Text = "";
                combo_name.SelectedText = "اختار عميل موجود";
            }
        }
    }
}
