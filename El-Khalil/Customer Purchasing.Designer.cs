namespace El_Khalil
{
    partial class Customer_Purchasing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.combo_Materials = new System.Windows.Forms.ComboBox();
            this.tb_quantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.bt_Print = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.combo_Customer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Save = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_render = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_payment = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_Total = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_OldMoney = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_AfterDiscount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_Discount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_BillTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.الكمية = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel7 = new System.Windows.Forms.Panel();
            this.rb_check = new System.Windows.Forms.RadioButton();
            this.rb_cash = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(938, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "رقم البيان";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.combo_Materials);
            this.panel1.Controls.Add(this.tb_quantity);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(3, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1097, 45);
            this.panel1.TabIndex = 39;
            // 
            // combo_Materials
            // 
            this.combo_Materials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_Materials.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combo_Materials.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_Materials.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Materials.FormattingEnabled = true;
            this.combo_Materials.Location = new System.Drawing.Point(585, 9);
            this.combo_Materials.Name = "combo_Materials";
            this.combo_Materials.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_Materials.Size = new System.Drawing.Size(316, 24);
            this.combo_Materials.TabIndex = 32;
            this.combo_Materials.Tag = "";
            this.combo_Materials.Text = "اختار المنتج";
            this.combo_Materials.SelectedIndexChanged += new System.EventHandler(this.combo_Materials_SelectedIndexChanged);
            // 
            // tb_quantity
            // 
            this.tb_quantity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tb_quantity.Location = new System.Drawing.Point(413, 9);
            this.tb_quantity.Name = "tb_quantity";
            this.tb_quantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_quantity.Size = new System.Drawing.Size(55, 23);
            this.tb_quantity.TabIndex = 33;
            this.tb_quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_quantity_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(457, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 27);
            this.label3.TabIndex = 34;
            this.label3.Text = "الكمية";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radioButton1);
            this.panel4.Controls.Add(this.radioButton2);
            this.panel4.Controls.Add(this.radioButton4);
            this.panel4.Location = new System.Drawing.Point(154, 9);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(199, 27);
            this.panel4.TabIndex = 35;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radioButton1.Location = new System.Drawing.Point(131, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 21);
            this.radioButton1.TabIndex = 31;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "طن";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radioButton2.Location = new System.Drawing.Point(72, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 21);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.Text = "كجم";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radioButton4.Location = new System.Drawing.Point(21, 3);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(45, 21);
            this.radioButton4.TabIndex = 30;
            this.radioButton4.Text = "جم";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // bt_Print
            // 
            this.bt_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.bt_Print.FlatAppearance.BorderSize = 0;
            this.bt_Print.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(84)))), ((int)(((byte)(102)))));
            this.bt_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Print.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_Print.ForeColor = System.Drawing.Color.White;
            this.bt_Print.Location = new System.Drawing.Point(148, 563);
            this.bt_Print.Name = "bt_Print";
            this.bt_Print.Size = new System.Drawing.Size(182, 28);
            this.bt_Print.TabIndex = 38;
            this.bt_Print.Text = "حفظ و طباعة";
            this.bt_Print.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.combo_Customer);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1097, 45);
            this.panel3.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(367, 8);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(212, 29);
            this.label12.TabIndex = 55;
            this.label12.Text = "14 / 10 / 1995 20:04:42 ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(598, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(112, 29);
            this.label13.TabIndex = 54;
            this.label13.Text = "تاريج البيان";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Customer
            // 
            this.combo_Customer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combo_Customer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_Customer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Customer.FormattingEnabled = true;
            this.combo_Customer.Location = new System.Drawing.Point(68, 11);
            this.combo_Customer.Name = "combo_Customer";
            this.combo_Customer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_Customer.Size = new System.Drawing.Size(214, 24);
            this.combo_Customer.TabIndex = 53;
            this.combo_Customer.Tag = "";
            this.combo_Customer.Text = "اختار اسم المشترى";
            this.combo_Customer.SelectedIndexChanged += new System.EventHandler(this.combo_Supliers_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(786, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 29);
            this.label2.TabIndex = 39;
            this.label2.Text = "000000000";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_Save
            // 
            this.bt_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bt_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.bt_Save.FlatAppearance.BorderSize = 0;
            this.bt_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(84)))), ((int)(((byte)(102)))));
            this.bt_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Save.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.bt_Save.ForeColor = System.Drawing.Color.White;
            this.bt_Save.Location = new System.Drawing.Point(46, 563);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 28);
            this.bt_Save.TabIndex = 6;
            this.bt_Save.Text = "حفظ";
            this.bt_Save.UseVisualStyleBackColor = false;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(923, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 27);
            this.label4.TabIndex = 21;
            this.label4.Text = "بيان اسعار / بيع";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.bt_Print);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.bt_Save);
            this.panel2.Location = new System.Drawing.Point(117, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1103, 607);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.tb_render);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.tb_payment);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.tb_Total);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.tb_OldMoney);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.tb_AfterDiscount);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.tb_Discount);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.tb_BillTotal);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(3, 448);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1097, 109);
            this.panel6.TabIndex = 41;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(46, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(256, 27);
            this.label14.TabIndex = 49;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_render
            // 
            this.tb_render.Enabled = false;
            this.tb_render.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_render.Location = new System.Drawing.Point(338, 60);
            this.tb_render.Name = "tb_render";
            this.tb_render.Size = new System.Drawing.Size(101, 24);
            this.tb_render.TabIndex = 47;
            this.tb_render.Text = "0.00";
            this.tb_render.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(445, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 27);
            this.label11.TabIndex = 48;
            this.label11.Text = "الباقي بعد الدفع";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_payment
            // 
            this.tb_payment.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_payment.Location = new System.Drawing.Point(630, 60);
            this.tb_payment.Name = "tb_payment";
            this.tb_payment.Size = new System.Drawing.Size(101, 24);
            this.tb_payment.TabIndex = 45;
            this.tb_payment.Text = "0.00";
            this.tb_payment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_payment.TextChanged += new System.EventHandler(this.tb_payment_TextChanged);
            this.tb_payment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_payment_KeyPress);
            this.tb_payment.Leave += new System.EventHandler(this.tb_Discount_Leave);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(740, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 27);
            this.label10.TabIndex = 46;
            this.label10.Text = "المدفوع";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Total
            // 
            this.tb_Total.Enabled = false;
            this.tb_Total.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_Total.Location = new System.Drawing.Point(878, 60);
            this.tb_Total.Name = "tb_Total";
            this.tb_Total.Size = new System.Drawing.Size(101, 24);
            this.tb_Total.TabIndex = 43;
            this.tb_Total.Text = "0.00";
            this.tb_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(988, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 27);
            this.label9.TabIndex = 44;
            this.label9.Text = "اجمالى الحساب";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_OldMoney
            // 
            this.tb_OldMoney.Enabled = false;
            this.tb_OldMoney.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_OldMoney.Location = new System.Drawing.Point(45, 8);
            this.tb_OldMoney.Name = "tb_OldMoney";
            this.tb_OldMoney.Size = new System.Drawing.Size(101, 24);
            this.tb_OldMoney.TabIndex = 41;
            this.tb_OldMoney.Text = "0.00";
            this.tb_OldMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(152, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 27);
            this.label8.TabIndex = 42;
            this.label8.Text = "اجمالى حساب قديم";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_AfterDiscount
            // 
            this.tb_AfterDiscount.Enabled = false;
            this.tb_AfterDiscount.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_AfterDiscount.Location = new System.Drawing.Point(338, 10);
            this.tb_AfterDiscount.Name = "tb_AfterDiscount";
            this.tb_AfterDiscount.Size = new System.Drawing.Size(101, 24);
            this.tb_AfterDiscount.TabIndex = 39;
            this.tb_AfterDiscount.Text = "0.00";
            this.tb_AfterDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(445, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 27);
            this.label7.TabIndex = 40;
            this.label7.Text = "اجمالى بعد الخصم";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Discount
            // 
            this.tb_Discount.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_Discount.Location = new System.Drawing.Point(630, 10);
            this.tb_Discount.Name = "tb_Discount";
            this.tb_Discount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_Discount.Size = new System.Drawing.Size(101, 24);
            this.tb_Discount.TabIndex = 37;
            this.tb_Discount.Text = "0.00";
            this.tb_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_Discount.TextChanged += new System.EventHandler(this.tb_Discount_TextChanged);
            this.tb_Discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_Discount_KeyPress);
            this.tb_Discount.Leave += new System.EventHandler(this.tb_Discount_Leave);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(737, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 27);
            this.label6.TabIndex = 38;
            this.label6.Text = "اجمالى الخصم";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_BillTotal
            // 
            this.tb_BillTotal.Enabled = false;
            this.tb_BillTotal.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_BillTotal.Location = new System.Drawing.Point(878, 10);
            this.tb_BillTotal.Name = "tb_BillTotal";
            this.tb_BillTotal.Size = new System.Drawing.Size(101, 24);
            this.tb_BillTotal.TabIndex = 35;
            this.tb_BillTotal.Text = "0.00";
            this.tb_BillTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(985, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 27);
            this.label5.TabIndex = 36;
            this.label5.Text = "اجمالى الفاتورة";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Location = new System.Drawing.Point(3, 112);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1097, 330);
            this.panel5.TabIndex = 40;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.الكمية,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(1097, 330);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "رقم المنتج";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "اسم المنتج";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "سعر المنتج ";
            this.Column3.Name = "Column3";
            // 
            // الكمية
            // 
            this.الكمية.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.الكمية.HeaderText = "الكمية";
            this.الكمية.Name = "الكمية";
            this.الكمية.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "الوحدة";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "الاجمالى";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "النوع";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.rb_check);
            this.panel7.Controls.Add(this.rb_cash);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Location = new System.Drawing.Point(45, 79);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(257, 27);
            this.panel7.TabIndex = 50;
            // 
            // rb_check
            // 
            this.rb_check.AutoSize = true;
            this.rb_check.Location = new System.Drawing.Point(9, 5);
            this.rb_check.Name = "rb_check";
            this.rb_check.Size = new System.Drawing.Size(49, 17);
            this.rb_check.TabIndex = 44;
            this.rb_check.Text = "بنكى";
            this.rb_check.UseVisualStyleBackColor = true;
            // 
            // rb_cash
            // 
            this.rb_cash.AutoSize = true;
            this.rb_cash.Checked = true;
            this.rb_cash.Location = new System.Drawing.Point(71, 5);
            this.rb_cash.Name = "rb_cash";
            this.rb_cash.Size = new System.Drawing.Size(50, 17);
            this.rb_cash.TabIndex = 1;
            this.rb_cash.TabStop = true;
            this.rb_cash.Text = "نقدى";
            this.rb_cash.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(135, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 27);
            this.label15.TabIndex = 43;
            this.label15.Text = "طريقة الدفع";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Customer_Purchasing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1336, 671);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Customer_Purchasing";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Customer_Purchasing";
            this.Load += new System.EventHandler(this.Customer_Purchasing_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox combo_Materials;
        private System.Windows.Forms.TextBox tb_quantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button bt_Print;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox combo_Customer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox tb_render;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_payment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_Total;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_OldMoney;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_AfterDiscount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_Discount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_BillTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn الكمية;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.RadioButton rb_check;
        private System.Windows.Forms.RadioButton rb_cash;
        private System.Windows.Forms.Label label15;
    }
}