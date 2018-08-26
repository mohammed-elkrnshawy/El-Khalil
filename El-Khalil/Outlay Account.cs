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
    public partial class Outlay_Account : Form
    {
        DataSet dataSet;
        public Outlay_Account()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search();
            SumOulay();
            SumBand();
        }

        private void SumBand()
        {
            dataGridView2.Rows.Clear();
            SqlConnection con;

            SqlDataReader dataReader = Ezzat.GetDataReader("select_AllBand", out con);

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {

                    dataGridView2.Rows.Add();
                    dataGridView2[0, dataGridView2.Rows.Count - 1].Value = dataReader[1].ToString();
                    dataGridView2[1, dataGridView2.Rows.Count - 1].Value = 
                        Ezzat.ExecutedScalar("_Outlay_During_Sum_Band",
                        new SqlParameter("@Day", dateTimePicker1.Value),
                        new SqlParameter("@Day2", dateTimePicker2.Value),
                        new SqlParameter("@Band_iD", dataReader[0].ToString())
                        );
                    if (dataGridView2[1, dataGridView2.Rows.Count - 1].Value.ToString().Length == 0)
                        dataGridView2[1, dataGridView2.Rows.Count - 1].Value = "0.0000";
                }
            }

            con.Close();

        }

        private void SumOulay()
        {
            object o=Ezzat.ExecutedScalar("_Outlay_During_Sum", new SqlParameter("@Day", dateTimePicker1.Value), new SqlParameter("@Day2", dateTimePicker2.Value));
            textBox1.Text = String.Format("{0:0.00}", o);
        }

        private void Search()
        {
            using (dataSet=Ezzat.GetDataSet("_Outlay_During", "X",new SqlParameter("@Day",dateTimePicker1.Value),new SqlParameter("@Day2",dateTimePicker2.Value)))
            {
                dataGridView1.DataSource = dataSet.Tables["x"];
            }
        }
    }
}
