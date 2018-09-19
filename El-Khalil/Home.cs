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
    public partial class Home : Form
    {
        string name;
        bool flag;
        Image closeImage, closeImageAct;
        public Home(string name,bool flag)
        {
            InitializeComponent();
            this.name = name;
            this.flag = flag;
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

            toolStripStatusLabel1.Text = "اسم المستخدم : " + name;
            if (flag)
                toolStripStatusLabel3.Text = "الحالة : ادمن للنظام";
            else
                toolStripStatusLabel3.Text = "الحالة : مستخدم للنظام";

            StartQuantity();
            StartBankMoney();
            StartSafeMoney();

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

            ReturnCriditLimit();
        }

        private void ReturnCriditLimit()
        {
            object o= Ezzat.ExecutedScalar("select_IfCreditLimit", new SqlParameter("@Day", DateTime.Now));
            if(o!=null)
            {
                MessageBox.Show("يوجد فواتير للتحصيل");
            }
        }

        private void StartSafeMoney()
        {
            object o = Ezzat.ExecutedScalar("select_StartSafe_ID", new SqlParameter("@Day", DateTime.Parse(DateTime.Now.ToString())));
            if(o==null)
            {
                Ezzat.ExecutedNoneQuery("insert_StartSafe", new SqlParameter("@Day", DateTime.Parse(DateTime.Now.ToString())));
            }
        }

        private void StartBankMoney()
        {
            object o = Ezzat.ExecutedScalar("select_DayNumber_Bank", new SqlParameter("@DayDate", DateTime.Parse(DateTime.Now.ToString())));
            if (o == null)
            {
                o = Ezzat.ExecutedScalar("select_DayNumber_ID_Bank");
                if (o == null)
                    o = "1";
                else
                {
                    int i = int.Parse(o.ToString());
                    i++;
                    o = i;
                }



                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("Select_All2_Bank", out con);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Ezzat.ExecutedNoneQuery("insert_StartQuantity_Bank",
                            new SqlParameter("@Day_Number", o),
                            new SqlParameter("@Bank_ID", dataReader[0].ToString()),
                            new SqlParameter("@StartDate", DateTime.Parse(DateTime.Now.ToString())),
                            new SqlParameter("@StartMoney", dataReader[1].ToString()),
                            new SqlParameter("@Bank_Name", dataReader[2].ToString())
                            );
                    }
                }

                con.Close();
            }
        }

        private void StartQuantity()
        {

            object o = Ezzat.ExecutedScalar("select_DayNumber", new SqlParameter("@DayDate",DateTime.Parse(DateTime.Now.ToString())));
            if (o == null)
            {
                o = Ezzat.ExecutedScalar("select_DayNumber_ID");
                if (o == null)
                    o = "1";
                else
                {
                    int i = int.Parse(o.ToString());
                    i++;
                    o = i;
                }
                    


                SqlConnection con;

                SqlDataReader dataReader = Ezzat.GetDataReader("Select_All2", out con);

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Ezzat.ExecutedNoneQuery("insert_StartQuantity",
                            new SqlParameter("@Day_Number",o),
                            new SqlParameter("@Product_ID", dataReader[0].ToString()),
                            new SqlParameter("@StartDate", DateTime.Parse(DateTime.Now.ToString())),
                            new SqlParameter("@StartQuantity", dataReader[1].ToString()),
                            new SqlParameter("@Product_Type", dataReader[2].ToString()),
                            new SqlParameter("@Product_Name", dataReader[3].ToString()),
                            new SqlParameter("@Product_Unit", dataReader[4].ToString())
                            );
                    }
                }

                con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

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
           
        }

        private void اضافةتركيبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button26_Click(object sender, EventArgs e)
        {
           
        }

        private void تعديلتركيبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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

        private void button21_Click(object sender, EventArgs e)
        {
            Add_Tab("ضافة / تعديل موظف", new Add_Employee());
        }

        private void اضافةموظفتعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("ضافة / تعديل موظف", new Add_Employee());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة رواتب شهرية جديدة", new Employee_Salaries());
        }

        private void رواتبالشهرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة رواتب شهرية جديدة", new Employee_Salaries());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Add_Tab("جزاءات الموظفين", new Employee_Sanctions());
        }

        private void جزاءاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("جزاءات الموظفين", new Employee_Sanctions());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Add_Tab("حسابات الموظفين", new Employee_Account());
        }

        private void بيانحسابموظفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("حسابات الموظفين", new Employee_Account());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة مصاريف", new Outlay());
        }

        private void دفعمنرصيدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة مصاريف", new Outlay());
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Add_Tab("تعاملات الخزنة اليوم", new The_InSafe());
        }

        private void button30_Click(object sender, EventArgs e)
        {
            
        }

        private void button29_Click(object sender, EventArgs e)
        {
           
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة بنك", new Add_bank());
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Add_Tab("ايداع ف حساباتى", new Bank_InAccount());
        }

        private void button13_Click(object sender, EventArgs e)
        {
           
        }

        private void button11_Click(object sender, EventArgs e)
        {
           
        }

        private void اضافةبندمصروفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Band add_Band = new Add_Band();
            add_Band.ShowDialog();
        }

        private void خصمموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void خصمعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void اضافةمسميوظيفيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_JobTitle add = new Add_JobTitle();
            add.ShowDialog();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Add_Tab("تحويل من عميل الى مورد", new Bank_Cus_To_Sup());
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Add_Tab("تعاملات البنك", new Bank_Account());
        }

        private void حسابالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("حساب العملاء", new Customer());
        }

        private void حسابالموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("حساب الموردين", new Supplier());
        }

        private void حسابالمصروفاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("حساب المصروفات", new Outlay_Account());
        }

        private void حساباتالبنوكToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("حساب البنوك", new Bank());
        }

        private void button29_Click_1(object sender, EventArgs e)
        {
            Add_Tab("حساب الصنف", new Product_Account());
        }

        private void اجمالىالربحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("اجمالى الربح", new Total_Profit());
        }

        private void اضافةمستخدمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("اضافة مستخدمين", new Add_Users());
        }

        private void حساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            Add_Tab("حساب العملاء", new Customer());
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            Add_Tab("حساب الموردين", new Supplier());
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Add_Tab("حساب المصروفات", new Outlay_Account());
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            Add_Tab("اجمالى الربح", new Total_Profit());
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            Add_Tab("حساب البنوك", new Bank());
        }

        private void عرضالطلباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrder show = new ShowOrder();
            show.ShowDialog();
        }

        private void اضافةطلبToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Order add_ = new Add_Order();
            add_.ShowDialog();
        }

        private void نسحاحتياطىToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Backup backup = new Backup();
            backup.ShowDialog();
        }

        private void استعادةالنسخToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restore restore = new Restore();
            restore.ShowDialog();
        }

        private void ايداعميلغفالخزنةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Owner_IMMoney _IMMoney = new Owner_IMMoney();
            _IMMoney.ShowDialog();
        }

        private void حدائتمانالعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Limit show = new Show_Limit(false);
            show.ShowDialog();
        }

        private void حدائتمانالموردToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Limit show = new Show_Limit(true);
            show.ShowDialog();
        }

        private void بياناسعاربيعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Tab("جزاءات الموظفين", new Employee_Sanctions());
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
