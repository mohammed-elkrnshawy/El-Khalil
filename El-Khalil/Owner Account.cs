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
    public partial class Owner_Account : Form
    {
        DataSet dataSet;
        public Owner_Account()
        {
            InitializeComponent();
        }

        private void Owner_Account_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("Select_OwnerTransaction", "X", new SqlParameter("Day", dateTimePicker1.Value), new SqlParameter("Day2", dateTimePicker2.Value)))
            {
                dataGridView1.DataSource = dataSet.Tables["X"];
                dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            }

            label5.Text = Ezzat.ExecutedScalar("Select_TotalOwnerTransaction", new SqlParameter("Day", dateTimePicker1.Value), new SqlParameter("Day2", dateTimePicker2.Value),new SqlParameter("@f",true)).ToString();
            label6.Text = Ezzat.ExecutedScalar("Select_TotalOwnerTransaction", new SqlParameter("Day", dateTimePicker1.Value), new SqlParameter("Day2", dateTimePicker2.Value),new SqlParameter("@f",false)).ToString();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
