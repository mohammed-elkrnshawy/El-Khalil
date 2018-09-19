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
    public partial class Form1 : Form
    {
        DataSet dataSet;
        private int Bill_ID;
        private object Bill_Type;

        public Form1(int Bill_ID,object Bill_Type)
        {
            InitializeComponent();
            this.Bill_ID = Bill_ID;
            this.Bill_Type = Bill_Type;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if(Bill_Type.ToString().Contains("شراء"))
            {
                panel4.Visible = false;
                using (dataSet = Ezzat.GetDataSet("select_Supplier_BillDetails", "X",
                    new SqlParameter("@Bill_ID", Bill_ID), 
                    new SqlParameter("@Bill_Type",true)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }


                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Purchasing", out con,
                new SqlParameter("@Bill_ID",Bill_ID));

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
                        textBox2.Text = dataReader[11].ToString();
                        tb_number.Text= dataReader[12].ToString();
                        tb_owner.Text= dataReader[13].ToString();
                    }
                }

                con.Close();


            }
            else if (Bill_Type.ToString().Contains("مرتجع"))
            {
                label10.Visible = label11.Visible = label14.Visible=label3.Visible = tb_payment.Visible = tb_render.Visible = textBox1.Visible = textBox2.Visible = false;
                panel4.Visible = false;
                using (dataSet = Ezzat.GetDataSet("select_Supplier_BillDetails", "X",
                     new SqlParameter("@Bill_ID", Bill_ID),
                     new SqlParameter("@Bill_Type", false)))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Returning", out con,
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
                        tb_number.Text = dataReader[10].ToString();
                        tb_owner.Text = dataReader[11].ToString();
                    }
                }

                con.Close();

            }
            else if (Bill_Type.ToString().Contains("تحويل بنكى"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Bank", out con,
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
                        richTextBox1.Text = dataReader[7].ToString();
                        textBox5.Text = dataReader[8].ToString();
                        textBox4.Text = dataReader[9].ToString();
                        textBox3.Text = dataReader[11].ToString();
                    }
                }

                con.Close();

            }
            else if (Bill_Type.ToString().Contains("تسديد"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Payback", out con,
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
                        richTextBox1.Text = dataReader[7].ToString();
                        textBox5.Text = dataReader[8].ToString();
                        textBox4.Visible = label24.Visible = false;
                        textBox3.Text = dataReader[11].ToString();
                    }
                }

                con.Close();

            }
            else if (Bill_Type.ToString().Contains("خصم"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Discount", out con,
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
                        richTextBox1.Text = dataReader[6].ToString();
                        textBox5.Text = dataReader[7].ToString();
                        textBox4.Visible = label24.Visible = false;
                        textBox3.Text = dataReader[8].ToString();
                    }
                }

                con.Close();

            }
            else if (Bill_Type.ToString().Contains("تحويل من عميل"))
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("select_IMBillDeteils_Trans", out con,
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
                        richTextBox1.Text = dataReader[7].ToString();
                        textBox5.Text = dataReader[8].ToString();
                        textBox4.Text = dataReader[9].ToString();
                        textBox3.Text = dataReader[10].ToString();
                    }
                }

                con.Close();

            }


        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            if (Bill_Type.ToString().Contains("تحويل بنكى") || (Bill_Type.ToString().Contains("تسديد") || Bill_Type.ToString().Contains("خصم")))
            {
                Supplier_Payback_Print report = new Supplier_Payback_Print
                    (textBox3.Text, richTextBox1.Text, double.Parse(tb_old.Text), double.Parse(tb_pay.Text), int.Parse(label21.Text), Bill_Type.ToString());
                report.ShowDialog();
            }
        }

        private void bt_Print_Click(object sender, EventArgs e)
        {
            if (Bill_Type.ToString().Contains("شراء"))
            {
                Supplier_Purchasing_Print print = new Supplier_Purchasing_Print(int.Parse(label2.Text),
                                                                 tb_owner.Text,
                                                                 richTextBox1.Text,
                                                                 double.Parse(tb_BillTotal.Text),
                                                                 double.Parse(tb_Discount.Text),
                                                                 double.Parse(tb_OldMoney.Text),
                                                                 double.Parse(tb_payment.Text),
                                                                 true
                                                                 );
                print.ShowDialog();
            }
            else if (Bill_Type.ToString().Contains("مرتجع"))
            {
                Supplier_Purchasing_Print print = new Supplier_Purchasing_Print(int.Parse(label2.Text),
                                                                 tb_owner.Text,
                                                                 richTextBox1.Text,
                                                                 double.Parse(tb_BillTotal.Text),
                                                                 double.Parse(tb_Discount.Text),
                                                                 double.Parse(tb_OldMoney.Text),
                                                                 double.Parse(tb_payment.Text),
                                                                 false
                                                                 );
                print.ShowDialog();
            }
        }
    }
}
