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
    public partial class Emloyee_Bro : Form
    {
        DataSet dataSet;
        public Emloyee_Bro()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void RefreshForm()
        {
            richTextBox1.Text = "لا يوجد ملاحظات";
            tb_total.Text=tb_pay.Text=tb_render.Text=tb_totalPay.Text = "0.00";


            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);


            using (dataSet = Ezzat.GetDataSet("select_emphasSolva", "X"))
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

        private void Emloyee_Bro_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void combo_Employee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(combo_Employee.Focused)
            {
                SqlConnection con;
                SqlDataReader dataReader = Ezzat.GetDataReader("select_emphasSolva_Detail", out con, new SqlParameter("@Employee_ID", combo_Employee.SelectedValue));


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        tb_total.Text = dataReader["Total_Money"].ToString();
                        tb_totalPay.Text = dataReader["Total_Sadade"].ToString();
                    }
                }
                con.Close();
                Calcolate();
            }
        }

        private void Calcolate()
        {
            tb_render.Text = (double.Parse(tb_total.Text) - double.Parse(tb_totalPay.Text) - double.Parse(tb_pay.Text))+"";
        }

        private void tb_pay_KeyPress(object sender, KeyPressEventArgs e)
        {
            Shared_Class.KeyPress(tb_pay, e);
        }

        private void tb_pay_TextChanged(object sender, EventArgs e)
        {
            if (tb_pay.Text == "")
                tb_pay.Text = "0";
            Calcolate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (double.Parse(tb_render.Text) >= 0)
            {
                if(double.Parse(tb_render.Text) > 0)
                {
                    Ezzat.ExecutedNoneQuery("update_EmployeeBro"
                                        , new SqlParameter("@Employee_ID",combo_Employee.SelectedValue)
                                        , new SqlParameter("@Pay",double.Parse(tb_pay.Text))
                                        , new SqlParameter("@Status",true)
                        );
                }
                else if(double.Parse(tb_render.Text) == 0)
                {
                    Ezzat.ExecutedNoneQuery("update_EmployeeBro"
                                       , new SqlParameter("@Employee_ID", combo_Employee.SelectedValue)
                                       , new SqlParameter("@Pay", double.Parse(tb_pay.Text))
                                       , new SqlParameter("@Status", false)
                       );
                }

                Ezzat.ExecutedNoneQuery("insertEmployee_Transaction",
                new SqlParameter("@Employee_ID", combo_Employee.SelectedValue),
                new SqlParameter("@Month", String.Format("{0:MM/yyyy}", DateTime.Now)),
                new SqlParameter("@Money", double.Parse(tb_pay.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text),
                new SqlParameter("@Report_Date", DateTime.Now),
                new SqlParameter("@Report_Type", "تسديد مبلغ من سلفة")
                );

                Ezzat.ExecutedNoneQuery("insert_Sadad",
                               new SqlParameter("@Month", String.Format("{0:MM}", DateTime.Now)),
                               new SqlParameter("@Year", String.Format("{0:yyyy}", DateTime.Now)),
                               new SqlParameter("@Employee_ID", combo_Employee.SelectedValue),
                               new SqlParameter("@Money", tb_pay.Text)
                   );

                MessageBox.Show(Shared_Class.Successful_Message);

                RefreshForm();
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }

        private void Save()
        {

        }
    }
}
