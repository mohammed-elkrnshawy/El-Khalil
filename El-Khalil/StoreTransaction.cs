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

        private void button1_Click(object sender, EventArgs e)
        {
            StoreAllTransactions();
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
        private void StoreAllTransactions()
        {
            if (radioButton3.Checked)
            {
                FillGrid_ALL();
                using (dataSet = Ezzat.GetDataSet("_Store_AllTransaction_All", "X"))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }
            }
            else if (radioButton2.Checked)
            {
                dataGridView2.Rows.Clear();
                FillGrid_During(dateTimePicker1.Value, dateTimePicker2.Value);
                using (dataSet = Ezzat.GetDataSet("_Store_AllTransaction_DUring", "X",
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
                    new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                }

            }
            else if (radioButton1.Checked)
            {
                
                dataGridView2.Rows.Clear();
                dataGridView1.Rows.Clear();
                FillGrid_During(dateTimePicker3.Value, dateTimePicker3.Value);

                SqlConnection con;
                SqlDataReader dataReader = Ezzat.GetDataReader("_Store_AllTransaction_Day", out con,
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString())));
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1[0, dataGridView1.Rows.Count - 1].Value = dataReader[0].ToString();
                        dataGridView1[1, dataGridView1.Rows.Count - 1].Value = dataReader[1].ToString();
                        dataGridView1[2, dataGridView1.Rows.Count - 1].Value = dataReader[2].ToString();
                        dataGridView1[3, dataGridView1.Rows.Count - 1].Value = dataReader[3].ToString();
                    }
                        
                }
                con.Close();
            }
        }
        //private void FillGrid_Day()
        //{
        //    SqlConnection con;
        //    SqlDataReader dataReader = Ezzat.GetDataReader("fillGrid_Quantity", out con, new SqlParameter("@StartDate", StartDateTime));

        //    if (dataReader.HasRows)
        //    {
        //        while (dataReader.Read())
        //        {
        //            dataGridView2.Rows.Add();
        //            dataGridView2[0, dataGridView2.Rows.Count - 1].Value = dataReader[1].ToString();
        //            dataGridView2[1, dataGridView2.Rows.Count - 1].Value = dataReader[6].ToString();
        //            dataGridView2[2, dataGridView2.Rows.Count - 1].Value = dataReader[3].ToString()+"  "+ dataReader[7].ToString();
        //            if (dataReader[4].ToString()=="")
        //                dataGridView2[3, dataGridView2.Rows.Count - 1].Value ="؟   "+ dataReader[7].ToString();
        //            else
        //                dataGridView2[3, dataGridView2.Rows.Count - 1].Value = dataReader[4].ToString() + "  " + dataReader[7].ToString();

        //        }
        //    }

        //    con.Close();

        //}

        private void FillGrid_During(DateTime StartDateTime,DateTime EndDateTime)
        {
            object ob;
            SqlConnection con;

            SqlDataReader dataReader = Ezzat.GetDataReader("Select_All", out con);
           

            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    dataGridView2.Rows.Add();
                    dataGridView2[0, dataGridView2.Rows.Count - 1].Value = dataReader[0].ToString();
                    dataGridView2[1, dataGridView2.Rows.Count - 1].Value = dataReader[1].ToString();
                    

                    ob = Ezzat.ExecutedScalar("select_StartQuantity",
                        new SqlParameter("@startDate", StartDateTime),
                        new SqlParameter("@Product_ID", dataReader[0].ToString()),
                        new SqlParameter("@Product_type", dataReader[3].ToString())
                        );
                    if (ob == null)
                        dataGridView2[2, dataGridView2.Rows.Count - 1].Value = "؟   " + dataReader[4].ToString();
                    else
                        dataGridView2[2, dataGridView2.Rows.Count - 1].Value = ob + "  " + dataReader[4].ToString();


                    ob = Ezzat.ExecutedScalar("select_EndQuantity",
                        new SqlParameter("@EndDate", EndDateTime),
                        new SqlParameter("@Product_ID", dataReader[0].ToString()),
                        new SqlParameter("@Product_type", dataReader[3].ToString())
                        );
                    if (ob == null)
                        dataGridView2[3, dataGridView2.Rows.Count - 1].Value = "؟   " + dataReader[4].ToString();
                    else
                        dataGridView2[3, dataGridView2.Rows.Count - 1].Value = ob + "  " + dataReader[4].ToString();

                }
            }

            

            con.Close();

        }

        private void FillGrid_ALL()
        {
            object ob;
            SqlConnection con;

            SqlDataReader dataReader = Ezzat.GetDataReader("Select_All", out con);


            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    dataGridView2.Rows.Add();
                    dataGridView2[0, dataGridView2.Rows.Count - 1].Value = dataReader[0].ToString();
                    dataGridView2[1, dataGridView2.Rows.Count - 1].Value = dataReader[1].ToString();
                    dataGridView2[2, dataGridView2.Rows.Count - 1].Value = "0  " + dataReader[4].ToString();
                    if(dataReader[3].ToString()== "مادة خام")
                    {
                        ob = Ezzat.ExecutedScalar("selectMaterialQuantity",
                        new SqlParameter("@Material_Name", dataReader[1].ToString())
                        );
                        dataGridView2[3, dataGridView2.Rows.Count - 1].Value = ob + "  " + dataReader[4].ToString();
                    }
                    else if(dataReader[3].ToString() == "منتج نهائى")
                    {
                        ob = Ezzat.ExecutedScalar("selectProductQuantity",
                        new SqlParameter("@Material_Name", dataReader[1].ToString())
                        );
                        dataGridView2[3, dataGridView2.Rows.Count - 1].Value = ob + "  " + dataReader[4].ToString();
                    }
                }
            }



            con.Close();

        }
    }
}
