using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace El_Khalil
{
    public partial class The_InSafe : Form
    {
        SqlDataReader dataReader;
        public The_InSafe()
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

       
        private void ReturnData()
        {
            if (radioButton1.Checked)
            {
                SqlConnection con;

                dataReader = Ezzat.GetDataReader("_Safe_AllTransaction_During", out con,
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())),
                    new SqlParameter("@Day2", DateTime.Parse(dateTimePicker3.Value.ToString())));


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[0].ToString();
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[1].ToString();
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader[2].ToString();
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = (double.Parse(dataReader[1].ToString()) - double.Parse(dataReader[2].ToString()));
                        dataGridView1[4, dataGridView1.Rows.Count - 1].Value = dataReader[3].ToString();
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value = dataReader[5].ToString();
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = dataReader[4].ToString();
                    }
                }

                con.Close();


            }
            else if (radioButton2.Checked)
            {
               
                SqlConnection con;

                dataReader = Ezzat.GetDataReader("_Safe_AllTransaction_During", out con,
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
                    new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString())));


                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[0].ToString();
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[1].ToString();
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader[2].ToString();
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = (double.Parse(dataReader[1].ToString()) - double.Parse(dataReader[2].ToString()));
                        dataGridView1[4, dataGridView1.Rows.Count - 1].Value = dataReader[3].ToString();
                        dataGridView1[5, dataGridView1.Rows.Count - 1].Value = dataReader[5].ToString();
                        dataGridView1[6, dataGridView1.Rows.Count - 1].Value = dataReader[4].ToString();
                    }
                }

                con.Close();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReturnData();
        }
    }
}
