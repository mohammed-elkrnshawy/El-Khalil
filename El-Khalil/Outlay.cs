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
    public partial class Outlay : Form
    {
        DataSet dataSet;
        public Outlay()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            if (tb_OldMoney.Text != "0.00" && comboBox1.SelectedIndex >= 0)
            {
                Save();
                EditSafe();
                Clear();
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }

        private void Clear()
        {
            MessageBox.Show(Shared_Class.Successful_Message);
            int i = int.Parse(label2.Text);
            label2.Text = (i + 1) + "";
            comboBox1.Text = "";
            comboBox1.SelectedText = "اختار بند مصروفات";

            tb_OldMoney.Text = "0.00";
            richTextBox1.Text = Shared_Class.No_Message;

        }

        private void EditSafe()
        {
            // تعديل المبلغ الموجود ف الخزنة
            Ezzat.ExecutedNoneQuery("updateSafe_Decrease", new SqlParameter("@Money_Quantity", float.Parse(tb_OldMoney.Text)));

            // عمل بيان صرف من الخزنة للعميل
            Ezzat.ExecutedNoneQuery("insert_TheSaveTransaction",
                new SqlParameter("@Report_Type", false),
                new SqlParameter("@Bill_ID", int.Parse(label2.Text)),
                new SqlParameter("@Bill_Type", "مصاريف"),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Money", float.Parse(tb_OldMoney.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text)
                );
        }

        private void Save()
        {
           
            // اضافة تعامل مصاريف
            Ezzat.ExecutedNoneQuery("insert_OutlayTransaction",
                new SqlParameter("@Report_Total", float.Parse(tb_OldMoney.Text)),
                new SqlParameter("@Report_Notes", richTextBox1.Text),
                new SqlParameter("@Report_Date", DateTime.Parse(DateTime.Now.ToString())),
                new SqlParameter("@Report_Band",comboBox1.SelectedValue)
                );
        }

        private void Outlay_Load(object sender, EventArgs e)
        {
            label12.Text = String.Format("{0:HH:mm:ss  dd/MM/yyyy}", DateTime.Now);

            object o = Ezzat.ExecutedScalar("selectOutlay_Bill_ID");

            if (o == null)
                label2.Text = "1";
            else
                label2.Text = (((int)o) + 1) + "";

            using (dataSet=Ezzat.GetDataSet("select_AllBand", "X"))
            {
                comboBox1.DataSource = dataSet.Tables["X"];
                comboBox1.DisplayMember = "Band_Name";
                comboBox1.ValueMember = "Band_ID";
                comboBox1.Text = "";
                comboBox1.SelectedText = "اختار بند مصروفات";
            }

        }

        private void tb_OldMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void tb_OldMoney_TextChanged(object sender, EventArgs e)
        {
            if(tb_OldMoney.Text=="")
            {
                tb_OldMoney.Text = "0.00";
            }
        }

        private void bt_Print_Click(object sender, EventArgs e)
        {
            if (tb_OldMoney.Text != "0.00" && comboBox1.SelectedIndex >= 0)
            {
                Save();
                EditSafe();
                Print();
                Clear();
            }
            else
            {
                MessageBox.Show(Shared_Class.Check_Message);
            }
        }
        private void Print()
        {
            Outlay_Print print = new Outlay_Print(
                int.Parse(label2.Text),
                DateTime.Parse(DateTime.Now.ToString()),
                comboBox1.Text,
                richTextBox1.Text,
                double.Parse(tb_OldMoney.Text)
                );
            print.ShowDialog();
        }
    }
}
