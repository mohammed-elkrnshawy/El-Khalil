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
    public partial class Home : Form
    {
        int i = 1;
        Image closeImage, closeImageAct;
        public Home()
        {
            InitializeComponent();
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

                if (imageRec.Contains(e.Location)&&i!=0)
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            }
        }

        private void اضافةموردتعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة مورد / تعديل", new Add_Supplier());
        }

        private void Home_Load(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Black, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            //Without rounded corners
            //e.Graphics.DrawRectangle(Pens.Blue, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);
            base.OnPaint(e);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
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

        private void addMaterial_Click(object sender, EventArgs e)
        {
            Add_Tab("أضافة مادة خام", new Add_Materials());
        }

        private void اضافةموادخامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("أضافة مادة خام", new Add_Materials());
        }

        private void button27_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة منتج نهائى", new Add_Product());
        }

        private void اضافةتركيبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة منتج نهائى", new Add_Product());
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Add_Tab("تعديل منتج نهائى", new Edit_Product());
        }

        private void تعديلتركيبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("تعديل منتج نهائى", new Edit_Product());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة مورد / تعديل", new Add_Supplier());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة عميل / تعديل", new Add_Customer());
        }

        private void اضافةعميلتعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة عميل / تعديل", new Add_Customer());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان شراء", new Supplier_Purchasing());
        }

        private void بياناسعارشراءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان شراء", new Supplier_Purchasing()); 
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان شراء", new Supplier_Purchasing());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان تسديد", new Supplier_Payback());
        }

        private void تسديدرصيدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان تسديد", new Supplier_Payback());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان مرتجع", new SupplierReturned());
        }

        private void مرتجعاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان مرتجع", new SupplierReturned());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Add_Tab("حساب مورد", new Supplier_Account());
        }

        private void حسابموردتقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("حساب مورد", new Supplier_Account());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Add_Tab("مخزون مواد خام / منتج نهائى", new Store());
        }

        private void مخزونموادخامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("مخزون مواد خام / منتج نهائى", new Store());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Add_Tab("تعاملات المخازن", new StoreTransaction());
        }

        private void مخزونتركيباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("تعاملات المخازن", new StoreTransaction());
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Add_Tab("انتاج منتج نهائى", new Productivity_Product());
        }

        private void انتاجمنتجنهائىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("انتاج منتج نهائى", new Productivity_Product());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان بيع", new Customer_Purchasing());
        }

        private void بياناسعاربيعToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان بيع", new Customer_Purchasing());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Tab("تسديد من رصيد", new Customer_Payback());
        }

        private void دفعمنرصيدToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Tab("تسديد من رصيد", new Customer_Payback());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان مرتجع من عميل", new Customer_Returned());
        }

        private void مرتجعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("بيان مرتجع من عميل", new Customer_Returned());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Add_Tab("حساب عميل", new Customer_Account());
        }

        private void حسابعميلالتقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("حساب عميل", new Customer_Account());
        }

        private void Add_Tab(string Name,Form form)
        {
            TabPage tp = new TabPage(Name);


            form.TopLevel = false;
            tp.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.Show();

            tabControl1.TabPages.Add(tp);
            tabControl1.SelectedIndex = tabControl1.Controls.Count - 1;
        }

    }
}
