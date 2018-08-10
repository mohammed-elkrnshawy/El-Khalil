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

        private void Employee_Sanctions_Load(object sender, EventArgs e)
        {
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

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if(combo_Employee.SelectedIndex>=0&&tb_Money.Text!="")
            {
                Save();
                if (radioButton3.Checked||radioButton2.Checked)
                    Edit_Safe();
            }
            else
                MessageBox.Show("من فضلك راجع البيانات");
        }

        private void Edit_Safe()
        {
            string Message = "";
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_Money.Text)));

            if (radioButton2.Checked)
                Message = "مكافأه نقدية";
            else
                Message = "صرف نقدى ليد موظف";

            // عمل بيان صرف مبلغ من الخزنة للخزنة
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", Message),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_Money.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );
        }

        private void Save()
        {
            // اضافة تعامل موظف
            Ezzat.ExecutedNoneQuery("insertEmployee_Transaction",
                new SqlParameter("@Employee_ID",combo_Employee.SelectedValue),
                new SqlParameter("@Month", String.Format("{0: MM/yyyy}", DateTime.Now)),
                new SqlParameter("@Money",double.Parse(tb_Money.Text)),
                new SqlParameter("@Report_Notes",richTextBox1.Text),
                new SqlParameter("@Report_Date",label12.Text),
                new SqlParameter("@Report_Type",checkType())
                );

        }

        private string checkType()
        {
            if (radioButton1.Checked)
                return "جزاءات و خصومات مالية";
            else if (radioButton2.Checked)
                return "مكافأت نقدية";
            else
                return "مصروفات نفدية";
        }


    }
}
