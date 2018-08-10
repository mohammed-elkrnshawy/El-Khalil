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
    public partial class Employee_Salaries : Form
    {
        bool EXISit;
        public Employee_Salaries()
        {
            InitializeComponent();
        }

        private void Employee_Salaries_Load(object sender, EventArgs e)
        {
            label12.Text = String.Format("{0:MM/yyyy}", DateTime.Now);


            SqlConnection con;
            //بيجيب لو فيه موطفين ف الشهر دا و يعدل عليهم
            SqlDataReader dataReader = Ezzat.GetDataReader("select_EmployiesAndData", out con,
                new SqlParameter("@Month", int.Parse(String.Format("{0:MM}", DateTime.Now))),
                       new SqlParameter("@Year", int.Parse(String.Format("{0:yyyy}", DateTime.Now)))
                );

            if (dataReader.HasRows)
            {
                EXISit = true;
                while (dataReader.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[0].ToString();
                    dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[1].ToString();
                    dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader[2].ToString();
                    dataGridView1[3, dataGridView1.Rows.Count - 1].Value = bool.Parse(dataReader[3].ToString());
                }
            }
            else
            {
                EXISit = false;
                con.Close();
                //عشان لو الموظفين كانوا لسه مش مسجلين شهرية ف الشهر دا يجيب كله و هو يختار
                SqlDataReader dataReader2 = Ezzat.GetDataReader("select_EmployiesAndData_FromEmployee", out con);

                if (dataReader2.HasRows)
                {
                    while (dataReader2.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader2[0].ToString();
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader2[1].ToString();
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader2[2].ToString();
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = bool.Parse(dataReader2[3].ToString());
                    }
                }
            }
            con.Close();


            


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
           

            //لو موجود قبل كدة عدل
            //لو مش موجود ضيف
            if(EXISit)
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {

                    Ezzat.ExecutedNoneQuery("updateEmployee_Salary",
                       new SqlParameter("@Emplyee_ID", int.Parse(item.Cells[0].Value.ToString())),
                       new SqlParameter("@Employee_Salary", double.Parse(item.Cells[2].Value.ToString())),
                       new SqlParameter("@InList", bool.Parse(item.Cells[3].Value.ToString()))
                       );

                }
            }
            else
            {
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {

                    Ezzat.ExecutedNoneQuery("insertEmployee_Salary",
                       new SqlParameter("@Emplyee_ID", int.Parse(item.Cells[0].Value.ToString())),
                       new SqlParameter("@Employee_Name", item.Cells[1].Value.ToString()),
                       new SqlParameter("@Employee_Salary", double.Parse(item.Cells[2].Value.ToString())),
                       new SqlParameter("@Month", int.Parse(String.Format("{0:MM}", DateTime.Now))),
                       new SqlParameter("@Year", int.Parse(String.Format("{0:yyyy}", DateTime.Now))),
                       new SqlParameter("@Status", false),
                       new SqlParameter("@InList", bool.Parse(item.Cells[3].Value.ToString()))
                       );

                }
            }

           

        }
    }
}
