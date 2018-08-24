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
    public partial class Supplier_Account : Form
    {
        private DataSet dataSet;
        public Supplier_Account()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                pn_today.Visible = true;
                pn_during.Visible = false;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                pn_today.Visible = false;
                pn_during.Visible = true;
            }
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                pn_today.Visible = false;
                pn_during.Visible = false;
            }
        }

        private void Supplier_Account_Load(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("selectAllSupplier", "X"))
            {
                combo_Supliers.DataSource = dataSet.Tables["X"];
                combo_Supliers.DisplayMember = "Supplier_Name";
                combo_Supliers.ValueMember = "Supplier_ID";
                combo_Supliers.Text = "";
                combo_Supliers.SelectedText = "اختار اسم المورد";
            }
        }

        private void All_Transaction()
        {
            if (radioButton1.Checked)
            {
                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("_Supplier_SupplierTransaction_Day", out con,
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())), new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        gv.Rows.Add();
                        gv[0, gv.Rows.Count - 1].Value = dataReader[0].ToString();
                        gv[1, gv.Rows.Count - 1].Value = dataReader[2].ToString();
                        gv[2, gv.Rows.Count - 1].Value = dataReader[1].ToString();
                        gv[3, gv.Rows.Count - 1].Value = (double.Parse(dataReader[2].ToString()) - double.Parse(dataReader[1].ToString()));
                        gv[4, gv.Rows.Count - 1].Value = dataReader[3].ToString();
                        gv[5, gv.Rows.Count - 1].Value = dataReader[5].ToString();
                        gv[6, gv.Rows.Count - 1].Value = dataReader[4].ToString();
                    }
                }

                con.Close();

            }
            else if (radioButton2.Checked)
            {

                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("_Supplier_SupplierTransaction_During", out con,
               new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
               new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())),
               new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue));

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        gv.Rows.Add();
                        gv[0, gv.Rows.Count - 1].Value = dataReader[0].ToString();
                        gv[1, gv.Rows.Count - 1].Value = dataReader[2].ToString();
                        gv[2, gv.Rows.Count - 1].Value = dataReader[1].ToString();
                        gv[3, gv.Rows.Count - 1].Value = (double.Parse(dataReader[2].ToString()) - double.Parse(dataReader[1].ToString()));
                        gv[4, gv.Rows.Count - 1].Value = dataReader[3].ToString();
                        gv[5, gv.Rows.Count - 1].Value = dataReader[5].ToString();
                        gv[6, gv.Rows.Count - 1].Value = dataReader[4].ToString();
                    }
                }

                con.Close();

            }
            else
            {
                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("_Supplier_SupplierTransaction_All", out con,
              new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue));


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        gv.Rows.Add();
                        gv[0, gv.Rows.Count - 1].Value = dataReader[0].ToString();
                        gv[1, gv.Rows.Count - 1].Value = dataReader[2].ToString();
                        gv[2, gv.Rows.Count - 1].Value = dataReader[1].ToString();
                        gv[3, gv.Rows.Count - 1].Value = (double.Parse(dataReader[2].ToString()) - double.Parse(dataReader[1].ToString()));
                        gv[4, gv.Rows.Count - 1].Value = dataReader[3].ToString();
                        gv[5, gv.Rows.Count - 1].Value = dataReader[5].ToString();
                        gv[6, gv.Rows.Count - 1].Value = dataReader[4].ToString();
                    }
                }

                con.Close();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (combo_Supliers.SelectedIndex >= 0)
            {
                gv.Rows.Clear();
                All_Transaction();
                CalcolateTotal();
                object o = Ezzat.ExecutedScalar("selectTotalMoney", new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue));
                label11.Text = String.Format("{0:0.00}", o);
            }
        }

        private void CalcolateTotal()
        {
            double Total = 0, debit = 0;
            foreach (DataGridViewRow item in gv.Rows)
            {
                Total += double.Parse(item.Cells[1].Value.ToString());
                debit += double.Parse(item.Cells[2].Value.ToString());
            }

            label9.Text = Total + "";
            label8.Text = debit + "";
            label10.Text = (Total - debit) + "";
        }

        private void gv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(gv.CurrentCell==gv.CurrentRow.Cells[7])
            {
                Form1 BillDetails=new Form1(int.Parse(gv.CurrentRow.Cells[0].Value.ToString()), gv.CurrentRow.Cells[6].Value);
                BillDetails.ShowDialog();
            }
        }
    }
}
