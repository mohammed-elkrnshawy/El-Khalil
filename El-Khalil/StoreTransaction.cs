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
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }
        private void StoreAllTransactions()
        {
            if (radioButton2.Checked)
            {
                using (dataSet = Ezzat.GetDataSet("_Store_AllTransaction_DUring", "X",
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker1.Value.ToString())),
                    new SqlParameter("@Day2", DateTime.Parse(dateTimePicker2.Value.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                    Add_GridButtun();
                }

                FillGrid_During(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else if (radioButton1.Checked)
            {

                using (dataSet = Ezzat.GetDataSet("_Store_AllTransaction_Day", "X",
                    new SqlParameter("@Day", DateTime.Parse(dateTimePicker3.Value.ToString()))))
                {
                    dataGridView1.DataSource = dataSet.Tables["X"];
                    Add_GridButtun();
                }

                FillGrid_During(dateTimePicker3.Value, dateTimePicker3.Value);
            }
        }

        private void Add_GridButtun()
        {
            DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
            uninstallButtonColumn.Name = "عرض التفاصيل";
            uninstallButtonColumn.Text = "عرض التفاصيل";
            uninstallButtonColumn.ToolTipText = "عرض التفاصيل";
            uninstallButtonColumn.HeaderText = "عرض التفاصيل";
            uninstallButtonColumn.DataPropertyName = "عرض التفاصيل";
            uninstallButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndex = 5;
            if (dataGridView1.Columns["عرض التفاصيل"] == null)
            {
                dataGridView1.Columns.Insert(columnIndex, uninstallButtonColumn);
            }
        }

        private void FillGrid_During(DateTime StartDateTime, DateTime EndDateTime)
        {
            dataGridView2.Rows.Clear();
            SqlConnection con;

            SqlDataReader dataReader = Ezzat.GetDataReader("Select_All", out con);


            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    dataGridView2.Rows.Add();
                    dataGridView2[0, dataGridView2.Rows.Count - 1].Value = dataReader[0].ToString();
                    dataGridView2[1, dataGridView2.Rows.Count - 1].Value = dataReader[1].ToString();
                    dataGridView2[2, dataGridView2.Rows.Count - 1].Value = CalcolateEnd(dataReader[0].ToString(), EndDateTime);
                    dataGridView2[3, dataGridView2.Rows.Count - 1].Value = CalcolateStart(dataReader[0].ToString(), StartDateTime);
                    dataGridView2[4, dataGridView2.Rows.Count - 1].Value = double.Parse(dataGridView2[2, dataGridView2.Rows.Count - 1].Value+"") 
                                                                            - double.Parse(dataGridView2[3, dataGridView2.Rows.Count - 1].Value+"");
                }
            }
        }

        private string CalcolateStart(string v, DateTime startDateTime)
        {
            object o=Ezzat.ExecutedScalar("select_StartQuantity",
                new SqlParameter("@startDate",startDateTime),
                new SqlParameter("@Product_ID",int.Parse(v)));
            if (o == null)
                return "0";
            else
            return o+"";
        }

        private string CalcolateEnd(string v, DateTime endDateTime)
        {
            object Day_Num = Ezzat.ExecutedScalar("select_EndQuantity_Day_Number",
                new SqlParameter("@EndDate", endDateTime));
            if(Day_Num==null)
            {
                return "0";
            }
            else
            {
                int d = int.Parse(Day_Num.ToString());
                d++;
                Day_Num = d;

                object o = Ezzat.ExecutedScalar("select_EndQuantity",
                new SqlParameter("@Day_Number", Day_Num),
                new SqlParameter("@Product_ID", int.Parse(v))
                );

                if(o==null)
                {
                    object q = Ezzat.ExecutedScalar("select_EndQuantity_Today", new SqlParameter("@Product_ID", int.Parse(v)));
                    return q + "";
                }
                else
                {
                    return o + "";
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentCell==dataGridView1.CurrentRow.Cells[5])
            {
                Store_BillDetails store_ = new Store_BillDetails(dataGridView1.CurrentRow.Cells[0].Value.ToString(),
                                                                 dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                                                                 dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                                                                 dataGridView1.CurrentRow.Cells[4].Value.ToString()
                    );
                store_.ShowDialog();
            }
        }
        
    }
}
