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
    public partial class Employee_Add_Solva : Form
    {
        bool Exsist, Finished;
        DataSet dataSet;
        public Employee_Add_Solva()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RefreshForm()
        {
            richTextBox1.Text = "لا يوجد ملاحظات";
            tb_Money.Text = "0.00";


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


            label2.Text = o + "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void Employee_Add_Solva_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void tb_Money_KeyPress(object sender, KeyPressEventArgs e)
        {
            Shared_Class.KeyPress(tb_Money, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (combo_Employee.SelectedIndex >= 0 && tb_Money.Text != "")
            {
                if (IsExsisted())
                {
                    Save();
                    RefreshForm();
                }
                else
                {
                    MessageBox.Show("هذا الموظف عليه سلفة قديمة");
                }
            }
            else
                MessageBox.Show("من فضلك راجع البيانات");
        }

        private bool IsExsisted()
        {
            object o = Ezzat.ExecutedScalar("select_ifExsistSolva",
                               new SqlParameter("@ID", combo_Employee.SelectedValue)
                   );
            if (int.Parse(o.ToString())!=0)
                return false;
            else
                return true;
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
                new SqlParameter("@Report_Type", "صرف سلفة جديدة")
                );

            
             Ezzat.ExecutedNoneQuery("insert_Solva",
                                new SqlParameter("@Emoloyee_ID", combo_Employee.SelectedValue),
                                new SqlParameter("@Total_Money", tb_Money.Text),
                                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString()))
                    );

            Edit_Safe();
            

            MessageBox.Show(Shared_Class.Successful_Message);

        }
        private void Edit_Safe()
        {

            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_Money.Text)));



            // عمل بيان صرف مبلغ من الخزنة للخزنة
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "صرف سلفة جديدة"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_Money.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );
        }

    }
}
