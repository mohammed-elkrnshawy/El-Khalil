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
    public partial class Add_bank : Form
    {
        public Add_bank()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void cb_kilo_Click(object sender, EventArgs e)
        {
            Ezzat.ExecutedNoneQuery("insertBank",
                new SqlParameter("@Bank_Name",tb_name.Text),
                new SqlParameter("@Bank_Account",tb_company.Text),
                new SqlParameter("@Bank_Address",tb_address.Text),
                new SqlParameter("@Bank_Phone",tb_phone.Text),
                new SqlParameter("@Bank_Phone2",tb_phone2.Text)
                );
        }
    }
}
