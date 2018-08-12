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
    public partial class The_OutSafe : Form
    {
        DataSet dataSet;
        public The_OutSafe()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReturnData();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
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

        private void ReturnData()
        {
            if (radioButton1.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Safe_OutTransaction_Day", "X", new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Safe_OutTransaction_During", "X", 
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
                    new SqlParameter("@Day2",DateTime.Parse(dateTimePicker2.Value.ToString()))
                    ))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("_Safe_OutTransaction_All", "X"))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
        }
    }
}
