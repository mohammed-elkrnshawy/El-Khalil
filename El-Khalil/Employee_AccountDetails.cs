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
    public partial class Employee_AccountDetails : Form
    {
        DataSet dataSet;
        bool Pure;
        double Employee_Salary,Reword,San,Render,After;
        string Employee_Name,date;
        int Employee_ID;
        public Employee_AccountDetails(bool Pure,string Date, int EmployeeId,string EmployeeName,double salary,double Reword,double San, double Render, double After)
        {
            InitializeComponent();
            this.date = Date;
            this.Employee_ID = EmployeeId;
            this.Employee_Name = EmployeeName;
            this.Employee_Salary = salary;
            this.Pure = Pure;
            this.Reword = Reword;
            this.San = San;
            this.Render = Render;
            this.After = After;
        }

        private void Employee_AccountDetails_Load(object sender, EventArgs e)
        {
            if (Pure)
                button2.Enabled=richTextBox1.Enabled = false;


            label12.Text = date;
            tb_name.Text = Employee_Name;
            tb_salary.Text = String.Format("{0:0.00}", Employee_Salary);
            tb_reword.Text = String.Format("{0:0.00}", Reword);
            tb_san.Text = String.Format("{0:0.00}", San);
            tb_render.Text = String.Format("{0:0.00}", Render);
            tb_after.Text = String.Format("{0:0.00}", After);



            object o = Ezzat.ExecutedScalar("selectEmployeeTransaction_Bill_ID");


            label8.Text = o + "";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Save();
            Print();
        }

        private void Print()
        {
            Employee_AccountDetails_Print print = new Employee_AccountDetails_Print(
                int.Parse(label8.Text)
                , tb_name.Text
                , richTextBox1.Text
                , double.Parse(tb_salary.Text)
                , double.Parse(tb_reword.Text)
                , double.Parse(tb_san.Text)
                , double.Parse(tb_render.Text)
                );
            print.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Employee_Transaction_Print print = new Employee_Transaction_Print(label12.Text, Employee_ID.ToString());
            print.ShowDialog();
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            // اضافة تعامل موظف
            Ezzat.ExecutedNoneQuery("insertEmployee_Transaction",
                new SqlParameter("@Employee_ID", Employee_ID),
                new SqlParameter("@Month", label12.Text),
                new SqlParameter("@Money", double.Parse(tb_after.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Type", "قبض الشهر")
                );


            Edit_Safe();


            //تعديل حساب موظف ف شهر معين
            Edit_Account();

            MessageBox.Show(Shared_Class.Successful_Message);

            button2.Enabled = false;
        }

        private void Edit_Account()
        {
            string[] ar = label12.Text.Split('-');
            Ezzat.ExecutedNoneQuery("update_EmployeeAccount",
                new SqlParameter("@Employee_ID", Employee_ID),
                new SqlParameter("@DateMonth", ar[0]),
                new SqlParameter("@DateYear", ar[1])
                );
        }

        private void Edit_Safe()
        {
  
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_after.Text)));

            

            // عمل بيان صرف مبلغ من الخزنة للخزنة
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID",label8.Text),
                new SqlParameter("@Bill_Type", "قبض شهرية موظف"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_render.Text)),
                new SqlParameter("@Report_Notes",richTextBox1.Text)
                );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "اخفاء التفاصيل")
            {

                pn_P.Visible = true;
                button3.Visible=pn_S.Visible = false;
                button1.Text = "تعاملات الشهر";
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("select_EmployeeTransaction", "X",
                    new SqlParameter("@Employee_ID",Employee_ID),new SqlParameter("@Date_Month", label12.Text)
                    ))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
                pn_P.Visible = false;
                button3.Visible=pn_S.Visible = true;
                button1.Text = "اخفاء التفاصيل";
            }
        }
    }
}
