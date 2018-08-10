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
    public partial class Add_Employee : Form
    {
        DataSet dataSet;
        public Add_Employee()
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
            label4.Text = "اضافة موظف جديد";
            tb_address.Text = tb_name.Text = tb_phone.Text = tb_phone2.Text = tb_salary.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            combo_name.Enabled = true;
            label4.Text = "تعديل موظف موجود";
        }

        private void tb_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Add_Employee_Load(object sender, EventArgs e)
        {
            using (dataSet=Ezzat.GetDataSet("select_AllEmployee", "X"))
            {
                combo_name.DataSource = dataSet.Tables["X"];
                combo_name.DisplayMember = "Emp_Name";
                combo_name.ValueMember = "Emp_ID";
                combo_name.Text = "";
                combo_name.SelectedText = "اختار موظف موجود";
            }
        }

        private void AddEmployee()
        {
            Ezzat.ExecutedNoneQuery("insert_Employee",
                new SqlParameter("@Emp_Name",tb_name.Text),
                new SqlParameter("@Emp_Address",tb_address.Text),
                new SqlParameter("@Emp_Phone1",tb_phone.Text),
                new SqlParameter("@Emp_Phone2",tb_phone2.Text),
                new SqlParameter("@Emp_Salary",tb_salary.Text),
                new SqlParameter("@Begin_Salary", checkBox1.Checked)
                );
        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                AddEmployee();
            else
                EditEmployee();
        }

        private void EditEmployee()
        {
            Ezzat.ExecutedNoneQuery("update_Employee",
                new SqlParameter("@Emp_Name", tb_name.Text),
                new SqlParameter("@Emp_Address", tb_address.Text),
                new SqlParameter("@Emp_Phone1", tb_phone.Text),
                new SqlParameter("@Emp_Phone2", tb_phone2.Text),
                new SqlParameter("@Emp_Salary", tb_salary.Text),
                new SqlParameter("@Em_ID", combo_name.SelectedValue),
                new SqlParameter("@Begin_Salary", checkBox1.Checked)
                );
        }

        private void combo_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con;

            if (combo_name.Focused == true)
            {
                
                tb_name.Focus();

                SqlDataReader dataReader = Ezzat.GetDataReader("selectSpasific_Employee",
                    out con, new SqlParameter("@Supplier_ID", (int)combo_name.SelectedValue));


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        tb_name.Text = dataReader["Emp_Name"].ToString();
                        tb_address.Text = dataReader["Emp_Address"].ToString();
                        tb_salary.Text = dataReader["Emp_Salary"].ToString();
                        tb_phone.Text = dataReader["Emp_Phone1"].ToString();
                        tb_phone2.Text = dataReader["Emp_Phone2"].ToString();
                        checkBox1.Checked = bool.Parse(dataReader["Begin_Salary"].ToString());
                    }
                }
                con.Close();
            }
        }
    }
}
