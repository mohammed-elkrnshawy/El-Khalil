﻿using System;
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

       
        private void ReturnData()
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

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ReturnData();
            CalcolateTotal();
        }

        private void CalcolateTotal()
        {

            double Total = 0, debit = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                Total += double.Parse(item.Cells[1].Value.ToString());
                debit += double.Parse(item.Cells[2].Value.ToString());
            }

            label8.Text = Total + "";
            label9.Text = debit + "";
            label10.Text = (Total - debit) + "";


            label11.Text = Ezzat.ExecutedScalar("Safe_Start",new SqlParameter("@Day",dateTimePicker1.Value))+"";
            label6.Text = Ezzat.ExecutedScalar("Safe_End", new SqlParameter("@Day", dateTimePicker2.Value)) + "";
            label5.Text = Ezzat.ExecutedScalar("select_SafeMoney") + "";


        }

        private void bt_Print_Click(object sender, EventArgs e)
        {
            TheSafe_Account_Print print = new TheSafe_Account_Print(dateTimePicker1.Value, dateTimePicker2.Value
                ,double.Parse(label6.Text)
                ,double.Parse(label11.Text)
                ,double.Parse(label5.Text)
                );
            print.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell == dataGridView1.CurrentRow.Cells[7])
            {
                if (dataGridView1.CurrentRow.Cells[6].Value.ToString().Contains("ايراد من عميل"))
                {
                    Show_Details_Purchasing_Customer showDetails = new Show_Details_Purchasing_Customer(dataGridView1.CurrentRow.Cells[0].Value, false);
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "تسديد من عميل")
                {
                    ShowDetails_Payback_Customer showDetails = new ShowDetails_Payback_Customer(dataGridView1.CurrentRow.Cells[0].Value, "تسديد نقدى");
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[6].Value.ToString().Contains("صرف الى مورد"))
                {
                    ShowDetails_Purchasing_Supplier showDetails = new ShowDetails_Purchasing_Supplier(dataGridView1.CurrentRow.Cells[0].Value, true);
                    showDetails.ShowDialog();
                }
                else if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "تسديد الى مورد")
                {
                    ShowDetails_Payback_Supplier showDetails = new ShowDetails_Payback_Supplier(dataGridView1.CurrentRow.Cells[0].Value, "تسديد نقدى");
                    showDetails.ShowDialog();
                }
              
            }
        }
    }
}
