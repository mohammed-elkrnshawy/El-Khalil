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
        int Customer_ID;
        DataSet dataSet;
        public Add_Customer()
        {
            InitializeComponent();
        }
        private void RefForm()
        {
            tb_id.Enabled = true;

            dataGridView1.Rows.Clear();

            tb_address.Text = tb_bankName.Text = tb_Bank_number.Text = tb_company.Text = tb_day.Text = tb_name.Text
                = tb_phone.Text = tb_phone2.Text = textBox2.Text=tb_id.Text=tb_max.Text = "";

            bt_edit.Enabled =  false;
            bt_Save.Enabled = true;
            FillCombo();
            tb_day.Enabled = radioButton4.Checked;
        }
        private void tb_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private string PaymentMethod()
        {
            if (radioButton3.Checked)
                return "نقدى او شيك";
            else if (radioButton4.Checked)
                return "دفع اجل";
            else
                return "حد ائتمان";
        }
        private void PaymentMethod(string value)
        {
            if (value == "نقدى او شيك")
                radioButton3.Checked = true;
            else if (value == "دفع اجل")
                radioButton4.Checked = true;
            else if (value == "حد ائتمان")
                radioButton5.Checked = true;
            else
                radioButton3.Checked = radioButton4.Checked = radioButton5.Checked = false;
        }
        private bool IsValidText(TextBox textBox)
        {
            if (textBox.Text != "")
                return true;
            else
                return false;
        }
        private void FillCombo()
        {
            using (dataSet = Ezzat.GetDataSet("selectAllCustomer2", "X"))
            {
                dataGridView2.DataSource = dataSet.Tables["X"];
            }
        }
        private void Add_Customer_Load(object sender, EventArgs e)
        {
            RefForm();
        }
        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            tb_day.Enabled = radioButton5.Checked;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                FillCombo();
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("selectAllCustomer2_Search", "X", new SqlParameter("@Supplier_Name", textBox2.Text)))
                {
                    dataGridView2.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (IsValidText(tb_address) && IsValidText(tb_company) && IsValidText(tb_name) && IsValidText(tb_phone) && IsValidText(tb_id))
            {
                Add_Person();
                MessageBox.Show(Shared_Class.Add_Message);
                RefForm();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }

        private void Add_Person()
        {
            Ezzat.ExecutedNoneQuery("insertCusomer",
                new SqlParameter("@Customer_Name", tb_name.Text),
                new SqlParameter("@Customer_Phone", tb_phone.Text),
                new SqlParameter("@Customer_Phone2", tb_phone2.Text),
                new SqlParameter("@Customer_Address", tb_address.Text),
                new SqlParameter("@Customer_Company", tb_company.Text),
                new SqlParameter("@Customer_Max", float.Parse(tb_max.Text)),
                new SqlParameter("@Payment_Method", PaymentMethod()),
                new SqlParameter("@Day_Number", tb_day.Text),
                new SqlParameter("@ID", tb_id.Text)
                );


            Customer_ID = int.Parse(Ezzat.ExecutedScalar("select_CustomerID_BYNAME",new SqlParameter("@Customer_Name", tb_name.Text)).ToString());


            if (dataGridView1.Rows.Count > 0)
                Add_Account();

        }
        private void Add_Account()
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("insert_CustomerAccountsBank",
                    new SqlParameter("@Customer_ID", Customer_ID),
                    new SqlParameter("@Bank_Name", item.Cells[0].Value),
                    new SqlParameter("@Bank_Number", item.Cells[1].Value)
                    );
            }
        }
        private void AddRow()
        {
            if (IsValidText(tb_bankName) && IsValidText(tb_Bank_number))
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, dataGridView1.Rows.Count - 1].Value = tb_bankName.Text;
                dataGridView1[1, dataGridView1.Rows.Count - 1].Value = tb_Bank_number.Text;
                tb_bankName.Text = tb_Bank_number.Text = "";
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



        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Customer_ID = (int)dataGridView2.CurrentRow.Cells[0].Value;
            ShowDetails(Customer_ID);
        }
        private void ShowDetails(int value)
        {
            bt_edit.Enabled  = true;
            bt_Save.Enabled=tb_id.Enabled = false;

            SqlConnection con;
            SqlDataReader dataReader = Ezzat.GetDataReader("selectSpasific_Customer", out con, new SqlParameter("@Customer_Id", value));


            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    tb_name.Text = dataReader["Customer_Name"].ToString();
                    tb_address.Text = dataReader["Customer_Address"].ToString();
                    tb_company.Text = dataReader["Customer_Company"].ToString();
                    tb_phone.Text = dataReader["Customer_Phone"].ToString();
                    tb_phone2.Text = dataReader["Customer_Phone2"].ToString();
                    tb_day.Text = dataReader["Number_Day"].ToString();
                    tb_id.Text = dataReader["National_ID"].ToString();
                    tb_max.Text = dataReader["Customer_Max"].ToString();
                    PaymentMethod(dataReader["Payment_Method"].ToString());
                    
                }
            }
            con.Close();

            FillBankAccounts(value);

        }
        private void FillBankAccounts(int value)
        {
            dataGridView1.Rows.Clear();
            SqlConnection con;
            SqlDataReader dataReader = Ezzat.GetDataReader("select_CustomerBankAccounts", out con, new SqlParameter("@Customer_ID", value));


            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[2].ToString();
                    dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[3].ToString();
                }
            }
            con.Close();
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (IsValidText(tb_address) && IsValidText(tb_company) && IsValidText(tb_name) && IsValidText(tb_phone) && IsValidText(tb_id))
            {
                EditPerson();
                DeleteBankAccounts();
                Add_Account();
                MessageBox.Show(Shared_Class.Edit_Message);
                RefForm();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }
        private void DeleteBankAccounts()
        {
            Ezzat.ExecutedNoneQuery("deleteBankAccount_Customer", new SqlParameter("@Supplier_ID", Customer_ID));
        }
        private void EditPerson()
        {
            Ezzat.ExecutedNoneQuery("updateCusomer",
                new SqlParameter("@Customer_ID",Customer_ID),
                new SqlParameter("@Customer_Name", tb_name.Text),
                new SqlParameter("@Customer_Phone", tb_phone.Text),
                new SqlParameter("@Customer_Phone2", tb_phone2.Text),
                new SqlParameter("@Customer_Address", tb_address.Text),
                new SqlParameter("@Customer_Company", tb_company.Text),
                new SqlParameter("@Customer_Max", tb_max.Text),
                new SqlParameter("@Payment_Method", PaymentMethod()),
                new SqlParameter("@Number_Day", tb_day.Text)
                );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefForm();
        }

        private void tb_Bank_number_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
