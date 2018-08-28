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
    public partial class Employee_Account : Form
    {
        DataSet dataSet;
        public Employee_Account()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void Employee_Account_Load(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("select_AllEmployee", "X"))
            {
                combo_Employee.DataSource = dataSet.Tables["X"];
                combo_Employee.DisplayMember = "Emp_Name";
                combo_Employee.ValueMember = "Emp_ID";
                combo_Employee.Text = "";
                combo_Employee.SelectedText = "اختار موظف موجود";
            }
        }

        private void combo_Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo_Employee.Focused)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("selectEmployee_Month_Salary", out con,new SqlParameter("@Employer_ID", combo_Employee.SelectedValue));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[1].ToString()+"-"+dataReader[2].ToString();
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[6].ToString();
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader[8].ToString();
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = dataReader[7].ToString();
                        dataGridView1[4, dataGridView1.Rows.Count - 1].Value = dataReader[9].ToString();
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value =
                            ((double.Parse(dataReader[6].ToString()) +double.Parse(dataReader[8].ToString()))
                            -(double.Parse(dataReader[7].ToString()) +double.Parse(dataReader[9].ToString())));
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = dataReader[10].ToString();
                    }
                }
                con.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell==dataGridView1.CurrentRow.Cells[7])
            {
                Employee_AccountDetails k = new Employee_AccountDetails(
                    bool.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString())
                 , dataGridView1.CurrentRow.Cells[0].Value.ToString()
                 , (int)combo_Employee.SelectedValue, combo_Employee.Text
                 , double.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString())
                 , double.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString())
                 , double.Parse(dataGridView1.CurrentRow.Cells[3].Value.ToString())
                 , double.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString())
                 , double.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString())
                 );
                k.ShowDialog();
            } 
        }
    }
}
