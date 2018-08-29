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
    public partial class Customer_BillDetails : Form
    {
        DataSet dataSet;
        private int Bill_ID;
        private object Bill_Type,Bill_Details;
        public Customer_BillDetails(int Bill_ID, object Bill_Type,object Bill_Details)
        {
            InitializeComponent();
            this.Bill_ID = Bill_ID;
            this.Bill_Type = Bill_Type;
            this.Bill_Details =Bill_Details;
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void Customer_BillDetails_Load(object sender, EventArgs e)
        {
            if (Bill_Type.ToString().Contains("بيع"))
            {
                panel4.Visible = false;
                using (dataSet = Ezzat.GetDataSet("select_Customer_BillDetails", "X",
                    new SqlParameter("@Bill_ID", Bill_ID),
                    new SqlParameter("@Bill_Type", false)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }


                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Purchasing", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label2.Text = dataReader[0].ToString();
                        label12.Text = dataReader[2].ToString();
                        tb_BillTotal.Text = dataReader[4].ToString();
                        tb_Discount.Text = dataReader[5].ToString();
                        tb_AfterDiscount.Text = dataReader[6].ToString();
                        tb_OldMoney.Text = dataReader[7].ToString();
                        tb_Total.Text = dataReader[8].ToString();
                        tb_payment.Text = dataReader[9].ToString();
                        tb_render.Text = dataReader[10].ToString();
                        textBox1.Text = dataReader[3].ToString();
                        textBox2.Text = dataReader[12].ToString();
                        tb_owner.Text = dataReader[13].ToString();
                        richTextBox1.Text = Bill_Details.ToString();
                    }
                }

                con.Close();


            }
            else if (Bill_Type.ToString().Contains("مرتجع"))
            {
                label11.Visible = label3.Visible = tb_render.Visible =  textBox2.Visible = false;
                panel4.Visible = false;
                using (dataSet = Ezzat.GetDataSet("select_Customer_BillDetails", "X",
                     new SqlParameter("@Bill_ID", Bill_ID),
                     new SqlParameter("@Bill_Type", true)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Returning", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label2.Text = dataReader[0].ToString();
                        label12.Text = dataReader[2].ToString();
                        tb_BillTotal.Text = dataReader[4].ToString();
                        tb_Discount.Text = dataReader[5].ToString();
                        tb_AfterDiscount.Text = dataReader[6].ToString();
                        tb_OldMoney.Text = dataReader[7].ToString();
                        tb_Total.Text = dataReader[8].ToString();
                        tb_payment.Text = dataReader[9].ToString();
                        textBox1.Text = dataReader[3].ToString();
                        tb_owner.Text = dataReader[11].ToString();
                        richTextBox1.Text = Bill_Details.ToString();
                    }
                }

                con.Close();

            }
            else if (Bill_Type.ToString().Contains("تحويل بنكى"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Bank", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label21.Text = dataReader[0].ToString();
                        label16.Text = dataReader[2].ToString();
                        tb_old.Text = dataReader[4].ToString();
                        tb_pay.Text = dataReader[5].ToString();
                        tb_after.Text = dataReader[6].ToString();
                        richTextBox2.Text = dataReader[7].ToString();
                        textBox4.Text = dataReader[8].ToString();
                        textBox3.Text = dataReader[9].ToString();
                    }
                }

                con.Close();

            }
            else if (Bill_Type.ToString().Contains("تسديد"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Payback", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label21.Text = dataReader[0].ToString();
                        label16.Text = dataReader[2].ToString();
                        tb_old.Text = dataReader[4].ToString();
                        tb_pay.Text = dataReader[5].ToString();
                        tb_after.Text = dataReader[6].ToString();
                        richTextBox2.Text = dataReader[7].ToString();
                        textBox4.Visible = label24.Visible = false;
                        textBox3.Text = dataReader[9].ToString();
                    }
                }

                con.Close();

            }
            else if (Bill_Type.ToString().Contains("خصم"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Discount", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label21.Text = dataReader[0].ToString();
                        label16.Text = dataReader[2].ToString();
                        tb_old.Text = dataReader[3].ToString();
                        tb_pay.Text = dataReader[4].ToString();
                        tb_after.Text = dataReader[5].ToString();
                        richTextBox2.Text = dataReader[6].ToString();
                        textBox4.Visible = label24.Visible = false;
                        textBox3.Text = dataReader[7].ToString();
                    }
                }

                con.Close();

            }
            else if (Bill_Type.ToString().Contains("تحويل الى مورد"))
            {
                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_EXBillDeteils_Trans", out con,
                new SqlParameter("@Bill_ID", Bill_ID));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        label21.Text = dataReader[0].ToString();
                        label16.Text = dataReader[2].ToString();
                        tb_old.Text = dataReader[4].ToString();
                        tb_pay.Text = dataReader[5].ToString();
                        tb_after.Text = dataReader[6].ToString();
                        richTextBox2.Text = dataReader[7].ToString();
                        textBox4.Text = dataReader[8].ToString();
                        textBox3.Text = dataReader[9].ToString();
                    }
                }

                con.Close();
            }

        }
    }
}
