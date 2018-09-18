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

        private void button1_Click(object sender, EventArgs e)
        {
            if (combo_Supliers.SelectedIndex >= 0)
            {
                gv.Rows.Clear();
                All_Transaction();
                CalcolateTotal();
                object o = Ezzat.ExecutedScalar("selectTotalMoney", new SqlParameter("@Supplier_ID", (int)combo_Supliers.SelectedValue));
                if ((o + "").Length == 0) o = 0;
                label11.Text = String.Format("{0:0.00}", o);
                o = Ezzat.ExecutedScalar("Supplier_Start", new SqlParameter("@Customer_ID", (int)combo_Supliers.SelectedValue), new SqlParameter("@Day", dateTimePicker1.Value));
                if ((o + "").Length == 0) o = 0;
                label14.Text = String.Format("{0:0.00}", o);
                o = Ezzat.ExecutedScalar("Supplier_End", new SqlParameter("@Customer_ID", (int)combo_Supliers.SelectedValue), new SqlParameter("@Day", dateTimePicker2.Value));
                if ((o+"").Length == 0) o = 0;
                label13.Text = String.Format("{0:0.00}", o);
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

        private void bt_Print_Click(object sender, EventArgs e)
        {
            Supplier_Account_Print print = new Supplier_Account_Print(dateTimePicker1.Value
                                                                     ,dateTimePicker2.Value
                                                                     ,(int)combo_Supliers.SelectedValue
                                                                     ,combo_Supliers.Text
                                                                     ,double.Parse(label13.Text)  
                                                                     ,double.Parse(label14.Text)  
                                                                     ,double.Parse(label11.Text)  
                                                                     );
            print.ShowDialog();
        }
    }
}
