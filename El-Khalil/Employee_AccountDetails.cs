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
        double Employee_Salary;
        string Employee_Name;
        string date;
        int Employee_ID;
        public Employee_AccountDetails(string Date, int EmployeeId,string EmployeeName,double salary)
        {
            InitializeComponent();
            this.date = Date;
            this.Employee_ID = EmployeeId;
            this.Employee_Name = EmployeeName;
            this.Employee_Salary = salary;
        }

        private void Employee_AccountDetails_Load(object sender, EventArgs e)
        {
            label12.Text = date;
            tb_name.Text = Employee_Name;
            tb_month.Text = String.Format("{0:0.00}", Employee_Salary);

            //اجمالى القبض التقدى ف الشهر دا
            object o = Ezzat.ExecutedScalar("select_Sumofmoney",
                new SqlParameter("@Emp_id",Employee_ID),
                new SqlParameter("@details_month",date)
                );

            tb_money.Text = String.Format("{0:0.00}", o);


            //اجمالى الخصومات ف الشهر دا
             o = Ezzat.ExecutedScalar("select_Sumofsnach",
                new SqlParameter("@Emp_id", Employee_ID),
                new SqlParameter("@details_month", date)
                );

            tb_sna.Text = String.Format("{0:0.00}", o);

            if (tb_sna.Text == "")
                tb_sna.Text = "0.00";
            if (tb_money.Text == "")
                tb_money.Text = "0.00";



            tb_render.Text= String.Format("{0:0.00}", (double.Parse(tb_month.Text))-(double.Parse(tb_sna.Text)+double.Parse(tb_money.Text)));
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            

            // اضافة تعامل موظف
            Ezzat.ExecutedNoneQuery("insertEmployee_Transaction",
                new SqlParameter("@Employee_ID",Employee_ID),
                new SqlParameter("@Month", label12.Text),
                new SqlParameter("@Money", double.Parse(tb_render.Text)),
                new SqlParameter("@Report_Notes", ""),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Type","قبض الشهر")
                );
            Edit_Safe();


            //تعديل حساب موظف ف شهر معين
            Edit_Account();


        }

        private void Edit_Account()
        {
            string[] ar = label12.Text.Split('-');
            Ezzat.ExecutedNoneQuery("update_EmployeeAccount",
                new SqlParameter("@Employee_ID",Employee_ID),
                new SqlParameter("@DateMonth",ar[0]),
                new SqlParameter("@DateYear",ar[1]),
                new SqlParameter("@Month_Sanctions",double.Parse(tb_sna.Text)),
                new SqlParameter("@Month_Seizure",double.Parse(tb_money.Text))
                );
        }

        private void Edit_Safe()
        {
  
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_render.Text)));

            

            // عمل بيان صرف مبلغ من الخزنة للخزنة
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", "0"),
                new SqlParameter("@Bill_Type", "قبض شهرية موظف"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_render.Text)),
                new SqlParameter("@Report_Notes","")
                );
        }
    }
}
