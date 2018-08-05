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
    public partial class StoreTransaction : Form
    {
        DataSet dataSet;
        public StoreTransaction()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
                StoreAllTransactions();
        }

        private void StoreAllTransactions()
        {
            if (radioButton3.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Store_AllTransaction_All", "X"))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Store_AllTransaction_DUring", "X",
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
                    new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }

            }
            else if (radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Store_AllTransaction_Day", "X",
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
                StoreIncreaseTransactions();
        }

        private void StoreIncreaseTransactions()
        {
            if (radioButton3.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Store_IncreaseTransaction_All", "X"))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Store_IncreaseTransaction_DUring", "X",
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
                    new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }

            }
            else if (radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Store_IncreaseTransaction_Day", "X",
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                StoreDecreaseTransactions();
        }

        private void StoreDecreaseTransactions()
        {
            if (radioButton3.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Store_DecreaseTransaction_All", "X"))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Store_DecreaseTransaction_DUring", "X",
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
                    new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }

            }
            else if (radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Store_DecreaseTransaction_Day", "X",
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
        }
    }
}
