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

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton6.Checked)
            {
                pn_All.Visible = true;
                pn_Purchasing.Visible = false;
                pn_Payback.Visible = false;
                pn_Return.Visible = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                pn_All.Visible = false;
                pn_Purchasing.Visible = true;
                pn_Payback.Visible = false;
                pn_Return.Visible = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                pn_All.Visible = false;
                pn_Purchasing.Visible = false;
                pn_Payback.Visible = true;
                pn_Return.Visible = false;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked)
            {
                pn_All.Visible = false;
                pn_Purchasing.Visible = false;
                pn_Payback.Visible = false;
                pn_Return.Visible = true;
            }
        }



        private void Purchasing_Transaction()
        {
            if(radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Supplier_PurchasingTransaction_Day", "X",
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())), new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue)))
                {
                    gv_Purchasing.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Supplier_PurchasingTransaction_During", "X",
               new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
               new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())),
               new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue)))
                {
                    gv_Purchasing.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("_Supplier_PurchasingTransaction_All", "X",
              new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue)))
                {
                    gv_Purchasing.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void Payback_Transaction()
        {
            if (radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Supplier_PaybackTransaction_Day", "X",
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())), new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue)))
                {
                    gv_Payback.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Supplier_PaybackTransaction_During", "X",
               new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
               new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())),
               new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue)))
                {
                    gv_Payback.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("_Supplier_PaybackTransaction_All", "X",
              new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue)))
                {
                    gv_Payback.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void Returning_Transaction()
        {
            if (radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Supplier_ReturningTransaction_Day", "X",
                new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())), new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue)))
                {
                    gv_Returning.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Supplier_ReturningTransaction_During", "X",
               new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
               new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())),
               new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue)))
                {
                    gv_Returning.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("_Supplier_RetutningTransaction_All", "X",
              new SqlParameter("@Supplier_ID", combo_Supliers.SelectedValue)))
                {
                    gv_Returning.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void combo_Supliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_Supliers.Focused)
            {
                if (radioButton5.Checked)
                    Purchasing_Transaction();
                else if (radioButton4.Checked)
                    Payback_Transaction();
                if (radioButton7.Checked)
                    Returning_Transaction();

            }
        }
    }
}
