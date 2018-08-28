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
    public partial class Add_bank : Form
    {
        int BankId;
        DataSet dataSet;
        public Add_bank()
        {
            InitializeComponent();
        }

        private void RefForm()
        {
            tb_address.Text  = tb_number.Text =  tb_name.Text
                = tb_phone.Text = tb_phone2.Text = textBox2.Text = "";

            bt_edit.Enabled  = false;
            bt_Save.Enabled = true;
            FillCombo();
        }
        

        private void Add_bank_Load(object sender, EventArgs e)
        {
            RefForm();
        }

        private void FillCombo()
        {
            using (dataSet = Ezzat.GetDataSet("selectAllBank2", "X"))
            {
                dataGridView2.DataSource = dataSet.Tables["X"];
            }
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void Insert()
        {
            Ezzat.ExecutedNoneQuery("insertBank",
                new SqlParameter("@Bank_Name", tb_name.Text),
                new SqlParameter("@Bank_Account", tb_number.Text),
                new SqlParameter("@Bank_Address", tb_address.Text),
                new SqlParameter("@Bank_Phone", tb_phone.Text),
                new SqlParameter("@Bank_Phone2", tb_phone2.Text)
                );
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {

            if (IsValidText(tb_address) && IsValidText(tb_number) && IsValidText(tb_name) && IsValidText(tb_phone))
            {
                Insert();

                MessageBox.Show(Shared_Class.Add_Message);

                RefForm();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                FillCombo();
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("selectAllBank2_Search", "X", new SqlParameter("@Supplier_Name", textBox2.Text)))
                {
                    dataGridView2.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BankId = (int)dataGridView2.CurrentRow.Cells[0].Value;
            ShowDetails(BankId);
        }

        private void ShowDetails(int value)
        {
            bt_edit.Enabled = true;
            bt_Save.Enabled = false;

            SqlConnection con;
            SqlDataReader dataReader = Ezzat.GetDataReader("selectSpasific_Bank", out con, new SqlParameter("@Customer_Id", value));


            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    tb_name.Text = dataReader["Bank_Name"].ToString();
                    tb_address.Text = dataReader["Bank_Address"].ToString();
                    tb_number.Text = dataReader["Bank_Account"].ToString();
                    tb_phone.Text = dataReader["Bank_Phone"].ToString();
                    tb_phone2.Text = dataReader["Bank_Phone2"].ToString();
                }
            }
            con.Close();

        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (IsValidText(tb_address) && IsValidText(tb_number) && IsValidText(tb_name) && IsValidText(tb_phone))
            {
                EditBank();
                MessageBox.Show(Shared_Class.Edit_Message);
                RefForm();
            }
            else
                MessageBox.Show(Shared_Class.Check_Message);
        }
        private void EditBank()
        {
            Ezzat.ExecutedNoneQuery("updateBank",
                new SqlParameter("@Customer_ID", BankId),
                new SqlParameter("@Customer_Name", tb_name.Text),
                new SqlParameter("@Customer_Phone", tb_phone.Text),
                new SqlParameter("@Customer_Phone2", tb_phone2.Text),
                new SqlParameter("@Customer_Address", tb_address.Text),
                new SqlParameter("@Customer_Company", tb_number.Text)
                );
        }
        private bool IsValidText(TextBox textBox)
        {
            if (textBox.Text != "")
                return true;
            else
                return false;
        }
    }
}
