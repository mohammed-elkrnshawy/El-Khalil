using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Khalil
{
    public partial class Form1 : Form
    {
        int i = 1;
        Image closeImage, closeImageAct;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }



        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
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

        private void button1_Click(object sender, EventArgs e)
        {

            TabPage tp = new TabPage("Test "+i+"");
            
            

            Form2 tb = new Form2();
            tb.TopLevel = false;


            tp.Controls.Add(tb);
            tb.Dock = DockStyle.Fill;
            tb.Show();

            tabControl1.TabPages.Add(tp);

            tabControl1.SelectedIndex = tabControl1.Controls.Count - 1;



            i++;

            //    Form2 frm = new Form2();
            //    frm.TopLevel = false;
            //    //tabPage1.
            //    //tabPage1.Controls.Add(frm);
            //    //frm.Dock = DockStyle.Fill;
            //    //frm.Show();


            //    TabPage tabPage = new TabPage();
            //    //tabPage.Text = form.Text;
            //    tabPage.Controls.Add(frm);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Size mysize = new System.Drawing.Size(20, 20); // co anh chen vao
            Bitmap bt = new Bitmap(Properties.Resources.close);
            // anh nay ban dau minh da them vao
            Bitmap btm = new Bitmap(bt, mysize);
            closeImageAct = btm;
            //
            //
            Bitmap bt2 = new Bitmap(Properties.Resources.closeBlack);
            // anh nay ban dau minh da them vao
            Bitmap btm2 = new Bitmap(bt2, mysize);
            closeImage = btm2;
            tabControl1.Padding = new Point(30);

        }



        private int KTFormTonTai(Form frm)
        {
            for (int i = 0; i < tabControl1.TabCount; i++)
                if (tabControl1.TabPages[i].Text == frm.Text.Trim())
                    return i;
            return -1;
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // minh viet san, khoi mat thoi gian
            Rectangle rect = tabControl1.GetTabRect(e.Index);
            Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width,
                rect.Top + (rect.Height - closeImage.Height) / 2,
                closeImage.Width, closeImage.Height);
            // tang size rect
            rect.Size = new Size(rect.Width + 20, 38);

            Font f;
            Brush br = Brushes.Black;
            StringFormat strF = new StringFormat(StringFormat.GenericDefault);
            // neu tab dang duoc chon
            if (tabControl1.SelectedTab == tabControl1.TabPages[e.Index])
            {
                // hinh mau do, hinh nay them tu properti
                e.Graphics.DrawImage(closeImageAct, imageRec);
                f = new Font("Arial", 10, FontStyle.Bold);
                // Ten tabPage
                e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text,
                    f, br, rect, strF);
            }
            else
            {
                // Tap dang mo, nhung ko dc chon, hinh mau den
                e.Graphics.DrawImage(closeImage, imageRec);
                f = new Font("Arial", 9, FontStyle.Regular);
                // Ten tabPage
                e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text,
                    f, br, rect, strF);
            }
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            // Su kien click dong tabpage
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                // giong o DrawItem
                Rectangle rect = tabControl1.GetTabRect(i);
                Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width,
                    rect.Top + (rect.Height - closeImage.Height) / 2,
                    closeImage.Width, closeImage.Height);

                if (imageRec.Contains(e.Location))
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void AddTabPage(Form frm)
        {
            int t = KTFormTonTai(frm);
            if (t >= 0) // frm da dc mo
            {
                // neu tap da dc chon
                if (tabControl1.SelectedTab == tabControl1.TabPages[t])
                    MessageBox.Show("Tap \"" + frm.Text.Trim() + "\" dang mo!");
                else
                    tabControl1.SelectedTab = tabControl1.TabPages[t];
            }
            else // them 
            {
                TabPage newTab = new TabPage(frm.Text.Trim());
                tabControl1.TabPages.Add(newTab);
                frm.TopLevel = false;
                frm.Parent = newTab;
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabCount - 1];
                frm.Show();
                frm.Dock = DockStyle.Fill;

            }
        }

    }
}
