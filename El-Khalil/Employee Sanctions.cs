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
    public partial class Employee_Sanctions : Form
    {
        bool Exsist, Finished;
        private double Rewords, San, Render, Salary;
        private DataSet dataSet;
        public Employee_Sanctions()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void RefreshForm()
        {
            richTextBox1.Text = "لا يوجد ملاحظات";
            tb_Money.Text = "0.00";
            radioButton1.Checked = true;

            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);


            using (dataSet = Ezzat.GetDataSet("select_AllEmployee", "X"))
            {
                combo_Employee.DataSource = dataSet.Tables["X"];
                combo_Employee.DisplayMember = "Emp_Name";
                combo_Employee.ValueMember = "Emp_ID";
                combo_Employee.Text = "";
                combo_Employee.SelectedText = "اختار موظف موجود";
            }

            object o = Ezzat.ExecutedScalar("selectEmployeeTransaction_Bill_ID");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";
        }

        private void Employee_Sanctions_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (combo_Employee.SelectedIndex >= 0 && tb_Money.Text != "")
            {
                if (IsExsisted())
                {
                    if(IsFinish()&& IsValid())
                    {
                        Save();
                    }
                }
                else
                {
                    MessageBox.Show("هذا الموظف غير موجود ف السجلات هذا الشهر");
                }
            }
            else
                MessageBox.Show("من فضلك راجع البيانات");
        }






        private void Edit_Safe()
        {
            
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_Money.Text)));

            

            // عمل بيان صرف مبلغ من الخزنة للخزنة
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "صرف نقدى ليد موظف"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_Money.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );
        }

        private void Save()
        {
            // اضافة تعامل موظف
            Ezzat.ExecutedNoneQuery("insertEmployee_Transaction",
                new SqlParameter("@Employee_ID", combo_Employee.SelectedValue),
                new SqlParameter("@Month", String.Format("{0:MM/yyyy}", DateTime.Now)),
                new SqlParameter("@Money", double.Parse(tb_Money.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text),
                new SqlParameter("@Report_Date", DateTime.Now),
                new SqlParameter("@Report_Type", checkType())
                );

            if(radioButton1.Checked)
            {
                Ezzat.ExecutedNoneQuery("insert_Sanctions",
                                new SqlParameter("@Month", String.Format("{0:MM}", DateTime.Now)),
                                new SqlParameter("@Year", String.Format("{0:yyyy}", DateTime.Now)),
                                new SqlParameter("@Employee_ID", combo_Employee.SelectedValue),
                                new SqlParameter("@Money", tb_Money.Text)
                    );
            }
            else if (radioButton2.Checked)
            {
                Ezzat.ExecutedNoneQuery("insert_Seizure",
                                new SqlParameter("@Month", String.Format("{0:MM}", DateTime.Now)),
                                new SqlParameter("@Year", String.Format("{0:yyyy}", DateTime.Now)),
                                new SqlParameter("@Employee_ID", combo_Employee.SelectedValue),
                                new SqlParameter("@Money", tb_Money.Text)
                    );
            }
            else if (radioButton3.Checked)
            {
                Ezzat.ExecutedNoneQuery("insert_Render",
                                new SqlParameter("@Month",String.Format("{0:MM}", DateTime.Now)),
                                new SqlParameter("@Year", String.Format("{0:yyyy}", DateTime.Now)),
                                new SqlParameter("@Employee_ID", combo_Employee.SelectedValue),
                                new SqlParameter("@Money", tb_Money.Text)
                    );
                Edit_Safe();
            }

            MessageBox.Show(Shared_Class.Successful_Message);
            RefreshForm();
        }

        private string checkType()
        {
            if (radioButton1.Checked)
                return "جزاءات مالية";
            else if (radioButton2.Checked)
                return "مكافأت مالية";
            else
                return "مصروفات نفدية";
        }

        private void combo_Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Employee.Focused)
            {
                ReadData();
            }
        }

        private bool IsExsisted()
        {
            object o = Ezzat.ExecutedScalar("select_EmployiesAndData",
                               new SqlParameter("@Month", String.Format("{0:MM}", DateTime.Now)),
                               new SqlParameter("@Year", String.Format("{0:yyyy}", DateTime.Now)),
                               new SqlParameter("@Employee_ID", combo_Employee.SelectedValue)
                   );
            if (o == null)
                return false;
            else
                return (bool)o;
        }

        private void ReadData()
        {

            SqlConnection con;

            //بيجيب لو فيه موطفين ف الشهر دا و يعدل عليهم
            SqlDataReader dr = Ezzat.GetDataReader("select_EmployiesAndDataAllData", out con,
                                new SqlParameter("@Month", String.Format("{0:MM}", DateTime.Now)),
                                new SqlParameter("@Year", String.Format("{0:yyyy}", DateTime.Now)),
                                new SqlParameter("@Employee_ID", combo_Employee.SelectedValue)
                );

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Finished = !bool.Parse(dr[10].ToString());
                    Salary = double.Parse(dr[6].ToString());
                    San = double.Parse(dr[7].ToString());
                    Rewords = double.Parse(dr[8].ToString());
                    Render = double.Parse(dr[9].ToString());
                }
            }
            con.Close();
        }

        private bool IsFinish()
        {
            if (Finished)
                return Finished;
            else
            {
                MessageBox.Show("حساب هذا الموظف خالص هذا الشهر");
                return Finished;
            }
        }

        private bool IsValid()
        {
            if (radioButton1.Checked || radioButton3.Checked)
            {
                if ((Salary + Rewords) >= (San + Render + double.Parse(tb_Money.Text)))
                    return true;
                else
                {
                    MessageBox.Show("حساب هذا الموظف لا يسمح يالعملية");
                    return false;
                }
            }
            else
                return true;
        }
    }
}
