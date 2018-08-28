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
        object o;
        bool EXISit;
        public Employee_Salaries()
        {
            InitializeComponent();
        }

        private void Employee_Salaries_Load(object sender, EventArgs e)
        {
            label12.Text = String.Format("{0:MM-yyyy}", DateTime.Now);


            SqlConnection con;
            //بيجيب كل الموطفين اللي لسه حساباتهم جارية 
            SqlDataReader dataReader2 = Ezzat.GetDataReader("select_EmployiesAndData_FromEmployee", out con);

            if (dataReader2.HasRows)
            {
                while (dataReader2.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader2[0].ToString();
                    dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader2[1].ToString();
                    dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader2[2].ToString();
                    dataGridView1[3, dataGridView1.Rows.Count - 1].Value = dataReader2[3].ToString();
                    dataGridView1[4, dataGridView1.Rows.Count - 1].Value = bool.Parse(dataReader2[4].ToString());
                }
            }
            con.Close();


            IsExsisted();
           

        }
        
      
        private void IsExsisted()
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                o = Ezzat.ExecutedScalar("select_EmployiesAndData",
                                new SqlParameter("@Month", String.Format("{0:MM}", DateTime.Now)),
                                new SqlParameter("@Year", String.Format("{0:yyyy}", DateTime.Now)),
                                new SqlParameter("@Employee_ID", item.Cells[0].Value)
                    );
                if (o == null)
                    EXISit = false;
                else
                    EXISit = (bool)o;

                item.Cells[4].Value = EXISit;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Cells[5]==dataGridView1.CurrentCell)
            {
                if (!(bool)dataGridView1.CurrentRow.Cells[4].Value)
                {
                    dataGridView1.CurrentRow.Cells[4].Value = true;
                    Add();
                }
                else if ((bool)dataGridView1.CurrentRow.Cells[4].Value)
                {
                    if(IsValid())
                    {
                        dataGridView1.CurrentRow.Cells[4].Value = false;
                        Delete();
                    }
                    else
                    {
                        dataGridView1.CurrentRow.Cells[4].Value = true;
                    }
                }
            }
        }

        private void Delete()
        {
            Ezzat.ExecutedNoneQuery("delete_EmployiesAndData",
                                new SqlParameter("@Month", String.Format("{0:MM}", DateTime.Now)),
                                new SqlParameter("@Year", String.Format("{0:yyyy}", DateTime.Now)),
                                new SqlParameter("@Employee_ID", dataGridView1.CurrentRow.Cells[0].Value)
                );
        }

        private bool IsValid()
        {
            bool Valid=true;
            SqlConnection con;

            //بيجيب لو فيه موطفين ف الشهر دا و يعدل عليهم
            SqlDataReader dr = Ezzat.GetDataReader("select_EmployiesAndDataAllData", out con,
                                new SqlParameter("@Month", String.Format("{0:MM}", DateTime.Now)),
                                new SqlParameter("@Year", String.Format("{0:yyyy}", DateTime.Now)),
                                new SqlParameter("@Employee_ID", dataGridView1.CurrentRow.Cells[0].Value)
                );

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (bool.Parse(dr[10].ToString())||double.Parse(dr[9].ToString())!=0 || double.Parse(dr[8].ToString()) != 0 || double.Parse(dr[7].ToString()) != 0)
                    {
                        Valid = false;
                    }
                }
            }
            con.Close();
            return Valid;
        }

        private void Add()
        {
            Ezzat.ExecutedNoneQuery("insertEmployee_Salary",
                       new SqlParameter("@Emplyee_ID", int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString())),
                       new SqlParameter("@Employee_Name", dataGridView1.CurrentRow.Cells[1].Value.ToString()),
                       new SqlParameter("@Employee_Salary", double.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString())),
                       new SqlParameter("@Month", String.Format("{0:MM}", DateTime.Now)),
                       new SqlParameter("@Year", String.Format("{0:yyyy}", DateTime.Now)),
                       new SqlParameter("@Status", false),
                       new SqlParameter("@InList", bool.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()))
                       );
        }

       
      
    }
}
