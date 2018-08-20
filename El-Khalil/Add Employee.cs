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
        int Customer_ID;
        DataSet dataSet;
        public Add_Employee()
        {
            InitializeComponent();
        }

        private void Add_Employee_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private bool IsValidText(TextBox textBox)
        {
            if (textBox.Text != "")
                return true;
            else
                return false;
        }
        
        private void tb_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if(IsValidText(tb_address)&& IsValidText(tb_ID) && IsValidText(tb_job) && IsValidText(tb_name) && IsValidText(tb_phone)
                && IsValidText(tb_salary))
            {
                AddEmployee();
                MessageBox.Show(Shared_Class.Add_Message);
                RefreshForm();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }

        private void AddEmployee()
        {
            Ezzat.ExecutedNoneQuery("insert_Employee",
                new SqlParameter("@Emp_Name", tb_name.Text),
                new SqlParameter("@Emp_Address", tb_address.Text),
                new SqlParameter("@Emp_Phone1", tb_phone.Text),
                new SqlParameter("@Emp_Phone2", tb_phone2.Text),
                new SqlParameter("@Emp_Salary", tb_salary.Text),
                new SqlParameter("@Begin_Salary", true),
                new SqlParameter("@National_ID", tb_ID.Text),
                new SqlParameter("@Job_Name", tb_job.Text)
                );
        }

        private void RefreshForm()
        {
            tb_address.Text = tb_ID.Text = tb_job.Text = tb_name.Text = tb_phone.Text = tb_phone2.Text = tb_salary.Text = textBox2.Text = "";
            tb_ID.Enabled=bt_Save.Enabled = true;

            bt_edit.Enabled = button1.Enabled = false;

            FillCombo();
        }

        private void FillCombo()
        {
            using (dataSet = Ezzat.GetDataSet("select_AllEmployee2", "X"))
            {
                dataGridView2.DataSource = dataSet.Tables["X"];
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_ID.Enabled=bt_Save.Enabled = false;

            bt_edit.Enabled = button1.Enabled = true;

            Customer_ID = (int)dataGridView2.CurrentRow.Cells[0].Value;
            ShowDetails(Customer_ID);
        }

        private void ShowDetails(int customer_ID)
        {
            SqlConnection con;
            SqlDataReader dataReader = Ezzat.GetDataReader("selectSpasific_Employee",
                    out con, new SqlParameter("@Supplier_ID", Customer_ID));
            
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        tb_name.Text = dataReader["Emp_Name"].ToString();
                        tb_address.Text = dataReader["Emp_Address"].ToString();
                        tb_salary.Text = dataReader["Emp_Salary"].ToString();
                        tb_phone.Text = dataReader["Emp_Phone1"].ToString();
                        tb_phone2.Text = dataReader["Emp_Phone2"].ToString();
                        tb_job.Text = dataReader["Job_Name"].ToString();
                        tb_ID.Text = dataReader["National_ID"].ToString();
                        radioButton3.Checked = bool.Parse(dataReader["Account"].ToString());
                    }
                }
                con.Close();
            }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == false)
                radioButton4.Checked = true;
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (IsValidText(tb_address) && IsValidText(tb_ID) && IsValidText(tb_job) && IsValidText(tb_name) && IsValidText(tb_phone)
                && IsValidText(tb_salary))
            {
                EditEmployee();
                MessageBox.Show(Shared_Class.Add_Message);
                RefreshForm();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }

        private void EditEmployee()
        {
            Ezzat.ExecutedNoneQuery("update_Employee",
                new SqlParameter("@Emp_Name", tb_name.Text),
                new SqlParameter("@Emp_Address", tb_address.Text),
                new SqlParameter("@Emp_Phone1", tb_phone.Text),
                new SqlParameter("@Emp_Phone2", tb_phone2.Text),
                new SqlParameter("@Emp_Salary", tb_salary.Text),
                new SqlParameter("@Em_ID", Customer_ID),
                new SqlParameter("@Begin_Salary", radioButton3.Checked),
                new SqlParameter("@Job", tb_job.Text)
                );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                FillCombo();
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("select_AllEmployee2_Search", "X", new SqlParameter("@Supplier_Name", textBox2.Text)))
                {
                    dataGridView2.DataSource = dataSet.Tables["X"];
                }
            }
        }
    }
}
