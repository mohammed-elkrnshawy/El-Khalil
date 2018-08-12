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
    public partial class The_Safe : Form
    {
        DataSet dataSet;
        public The_Safe()
        {
            InitializeComponent();
        }

        private void The_Safe_Load(object sender, EventArgs e)
        {
            ReturnData();

            object o = Ezzat.ExecutedScalar("select_SafeMoney");
            tb_AfterDiscount.Text = String.Format("{0:0.00}", o);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void ReturnData()
        {
            if(radioButton6.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Safe_AllTransaction_Day", "X", new SqlParameter("@Day", DateTime.Parse(DateTime.Now.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else if(radioButton5.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Safe_OutTransaction_Day", "X", new SqlParameter("@Day", DateTime.Parse(DateTime.Now.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else
            {
                using (dataSet = Ezzat.GetDataSet("_Safe_InTransaction_Day", "X", new SqlParameter("@Day", DateTime.Parse(DateTime.Now.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ReturnData();
        }
    }
}
