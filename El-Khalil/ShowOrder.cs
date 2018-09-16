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
    public partial class ShowOrder : Form
    {
        DataSet dataSet;
        public ShowOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showOrder();
        }

        private void showOrder()
        {
            using (dataSet = Ezzat.GetDataSet("select_Orders_Day", "X", new SqlParameter("Day",dateTimePicker1.Value)))
            {
                dataGridView1.DataSource = dataSet.Tables["X"];
                dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
    }
}
