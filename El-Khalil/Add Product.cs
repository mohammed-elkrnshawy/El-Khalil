using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Khalil
{
    public partial class Add_Product : Form
    {
        DataSet dataSet;
        public Add_Product()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }
        private void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }

        private void Add_Product_Load(object sender, EventArgs e)
        {
            using (dataSet = Ezzat.GetDataSet("selectMaterials", "x"))
            {
                combo_name.DataSource = dataSet.Tables["x"];
                combo_name.DisplayMember = "Material_Name";
                combo_name.ValueMember = "Material_ID";
                combo_name.Text = "";
                combo_name.SelectedText = "اختار مادة خام";
                
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tb_quantity.Text.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter && combo_name.SelectedIndex>=0)
            {
                AddRow();
            }
        }

        private void combo_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_name.Focused == true)
            {
                
            }
        }

        private void AddRow()
        {
            dataGridView1.Rows.Add();
            dataGridView1[0, dataGridView1.Rows.Count - 1].Value = combo_name.SelectedValue;
            dataGridView1[1, dataGridView1.Rows.Count - 1].Value = combo_name.Text;
            dataGridView1[2, dataGridView1.Rows.Count - 1].Value = tb_quantity.Text;
            dataGridView1[3, dataGridView1.Rows.Count - 1].Value = checkUnit(radioButton2);
        }
        private string checkUnit(RadioButton Kilo)
        {
            if(Kilo.Checked)
            {
                return "كجم";
            }
            else
            {
                return "جم";
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                var p = new Pen(Color.Black, 1);
                var point1 = new Point(0, 0);
                var point2 = new Point(5000, 0);
                g.DrawLine(p, point1, point2);
            }
        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            if(tb_name.Text!=""&&tb_sell.Text!=""&&tb_per.Text!=""&&dataGridView1.Rows.Count>0)
            {
                object ID = Ezzat.ExecutedScalar("insertProduct"
               , new SqlParameter("@Material_Name", tb_name.Text)
               , new SqlParameter("@Material_Unit", checkUnit(radioButton1))
               , new SqlParameter("@Material_Price", float.Parse(tb_sell.Text))
               , new SqlParameter("@Material_per", int.Parse(tb_per.Text)));

                AddComponents(ID);
            }
            else
            {
                MessageBox.Show("من فضلك راجع البيانات");
            }
        }

        private void AddComponents(object iD)
        {
            foreach(DataGridViewRow item in dataGridView1.Rows)
            {
                Ezzat.ExecutedNoneQuery("insertComponent"
                    , new SqlParameter("@Product_ID",iD)
                    , new SqlParameter("@Material_ID", item.Cells[0].Value.ToString())
                    , new SqlParameter("@Component_Unit", item.Cells[3].Value.ToString())
                    , new SqlParameter("@Component_Name", item.Cells[1].Value.ToString())
                    , new SqlParameter("@Component_Quantity", float.Parse(item.Cells[2].Value+""))
                    );
            }
        }

        private void tb_per_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (tb_quantity.Text.Contains('.') && e.KeyChar == '.')
            {
                e.Handled = true;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
