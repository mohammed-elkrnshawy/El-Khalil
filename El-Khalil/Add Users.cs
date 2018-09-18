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
    public partial class Add_Users : Form
    {
        object Id;
        DataSet ds;

        public Add_Users()
        {
            InitializeComponent();
        }
        private void RefreshForm()
        {
            tb_name.Text = tb_pass.Text = tb_pass2.Text = "";
            bt_edit.Enabled = button1.Enabled = false;
            bt_Save.Enabled = true;

            using (ds=Ezzat.GetDataSet("select_allUsers", "X"))
            {
                dataGridView2.DataSource = ds.Tables["X"];
                dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private bool IsValid(TextBox textBox)
        {
            if(textBox.Text!="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if(IsValid(tb_name)&&IsValid(tb_pass)&&tb_pass.Text==tb_pass2.Text)
            {
                AddPerson();
                RefreshForm();
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }

        private void AddPerson()
        {
            Ezzat.ExecutedNoneQuery("insert_User"
                , new SqlParameter("@Username",tb_name.Text)
                , new SqlParameter("@Password",tb_pass.Text)
                , new SqlParameter("@isAdmin",radioButton1.Checked)
                );
            MessageBox.Show(Shared_Class.Add_Message);
        }

        private void Add_Users_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            using (ds = Ezzat.GetDataSet("select_allUsers_Search", "X",new SqlParameter("@username",textBox2.Text)))
            {
                dataGridView2.DataSource = ds.Tables["X"];
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_name.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            tb_pass.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            tb_pass2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            radioButton1.Checked = (bool)dataGridView2.CurrentRow.Cells[2].Value;
            Id = dataGridView2.CurrentRow.Cells[0].Value;

            bt_edit.Enabled = button1.Enabled = true;
            bt_Save.Enabled = false;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
                radioButton2.Checked = true;
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
            if (IsValid(tb_name) && IsValid(tb_pass) && tb_pass.Text == tb_pass2.Text)
            {
                EditPerson();
                RefreshForm();
            }
        }

        private void EditPerson()
        {
            Ezzat.ExecutedNoneQuery("update_User"
                , new SqlParameter("@Username",tb_name.Text)
                , new SqlParameter("@password",tb_pass.Text)
                , new SqlParameter("@isAdmin",radioButton1.Checked)
                , new SqlParameter("@id", Id)
                );
        }
    }
}
