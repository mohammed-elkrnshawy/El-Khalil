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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            Shared_Class.DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isValidData();
        }

        private void OpenHome()
        {
            Home home = new Home();
            home.ShowDialog();
            this.Close();
        }
         
        private void isValidData()
        {
            int o = (int)Ezzat.ExecutedScalar("select_CountUsers");
            if(o==0)
            {
                Add_Users users = new Add_Users();
                users.Show();
            }
            else
            {
               object q = Ezzat.ExecutedScalar("select_isValid"
                    , new SqlParameter("@Username",textBox1.Text)
                    , new SqlParameter("@Password",textBox2.Text)
                    , new SqlParameter("@isAdmin",radioButton1.Checked)
                    );

                if(q!=null)
                {
                    OpenHome();
                }
                else
                {
                    MessageBox.Show(Shared_Class.Check_Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Enter)
            {
                isValidData();
            } 
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
           
        }
    }
}
