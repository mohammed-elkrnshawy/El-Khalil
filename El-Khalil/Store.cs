using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Khalil
{
    public partial class Store : Form
    {
        DataSet dataSet;
        public Store()
        {
            InitializeComponent();
        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void Store_Load(object sender, EventArgs e)
        {
            radioButton1_CheckedChanged(sender, e);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("store_select_AllProduct", "X"))
            {
                dataGridView1.DataSource = dataSet.Tables["X"];
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("store_select_AllMaterial", "X"))
            {
                dataGridView1.DataSource = dataSet.Tables["X"];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                Store_Print print = new Store_Print(true);
                print.ShowDialog();
            }
            else
            {
                Store_Print print = new Store_Print(false);
                print.ShowDialog();
            }
        }
    }
}
