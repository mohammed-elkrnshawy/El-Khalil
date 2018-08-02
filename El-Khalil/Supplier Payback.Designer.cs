namespace El_Khalil
{
    partial class Supplier_Payback
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tb_AfterPayment = new System.Windows.Forms.TextBox();
            this.bt_Print = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.bt_Save = new System.Windows.Forms.Button();
            this.tb_payment = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.combo_Supliers = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_OldMoney = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.tb_AfterPayment);
            this.panel1.Controls.Add(this.bt_Print);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.bt_Save);
            this.panel1.Controls.Add(this.tb_payment);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tb_OldMoney);
            this.panel1.Location = new System.Drawing.Point(278, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 593);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(127, 285);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(471, 197);
            this.richTextBox1.TabIndex = 55;
            this.richTextBox1.Text = "لا يوجد ملاحظات";
            // 
            // tb_AfterPayment
            // 
            this.tb_AfterPayment.Enabled = false;
            this.tb_AfterPayment.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_AfterPayment.Location = new System.Drawing.Point(127, 219);
            this.tb_AfterPayment.Name = "tb_AfterPayment";
            this.tb_AfterPayment.Size = new System.Drawing.Size(295, 24);
            this.tb_AfterPayment.TabIndex = 53;
            this.tb_AfterPayment.Text = "0.00";
            this.tb_AfterPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.bt_Print.Location = new System.Drawing.Point(169, 548);
            this.bt_Print.Name = "bt_Print";
            this.bt_Print.Size = new System.Drawing.Size(182, 28);
            this.bt_Print.TabIndex = 40;
            this.bt_Print.Text = "حفظ و طباعة";
            this.bt_Print.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(451, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 27);
            this.label11.TabIndex = 54;
            this.label11.Text = "الباقي بعد الدفع";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.bt_Save.Location = new System.Drawing.Point(67, 548);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(75, 28);
            this.bt_Save.TabIndex = 39;
            this.bt_Save.Text = "حفظ";
            this.bt_Save.UseVisualStyleBackColor = false;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // tb_payment
            // 
            this.tb_payment.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_payment.Location = new System.Drawing.Point(127, 173);
            this.tb_payment.Name = "tb_payment";
            this.tb_payment.Size = new System.Drawing.Size(295, 24);
            this.tb_payment.TabIndex = 51;
            this.tb_payment.Text = "0.00";
            this.tb_payment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_payment.TextChanged += new System.EventHandler(this.tb_payment_TextChanged);
            this.tb_payment.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_payment_KeyPress);
            this.tb_payment.Leave += new System.EventHandler(this.tb_payment_Leave);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.combo_Supliers);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(3, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(717, 45);
            this.panel3.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(239, 8);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(182, 29);
            this.label12.TabIndex = 55;
            this.label12.Text = "14 / 10 / 1995 20:04:42 ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // combo_Supliers
            // 
            this.combo_Supliers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combo_Supliers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_Supliers.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Supliers.FormattingEnabled = true;
            this.combo_Supliers.Location = new System.Drawing.Point(26, 11);
            this.combo_Supliers.Name = "combo_Supliers";
            this.combo_Supliers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_Supliers.Size = new System.Drawing.Size(191, 24);
            this.combo_Supliers.TabIndex = 53;
            this.combo_Supliers.Tag = "";
            this.combo_Supliers.Text = "اختار اسم المورد";
            this.combo_Supliers.SelectedIndexChanged += new System.EventHandler(this.combo_Supliers_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(427, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 29);
            this.label13.TabIndex = 54;
            this.label13.Text = "تاريج البيان";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(526, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 29);
            this.label2.TabIndex = 39;
            this.label2.Text = "000000000";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(617, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 22;
            this.label1.Text = "رقم البيان";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(451, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 27);
            this.label10.TabIndex = 52;
            this.label10.Text = "المدفوع";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(451, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 27);
            this.label8.TabIndex = 50;
            this.label8.Text = "اجمالى حساب قديم";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_OldMoney
            // 
            this.tb_OldMoney.Enabled = false;
            this.tb_OldMoney.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_OldMoney.Location = new System.Drawing.Point(127, 129);
            this.tb_OldMoney.Name = "tb_OldMoney";
            this.tb_OldMoney.Size = new System.Drawing.Size(295, 24);
            this.tb_OldMoney.TabIndex = 49;
            this.tb_OldMoney.Text = "0.00";
            this.tb_OldMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(770, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 27);
            this.label4.TabIndex = 20;
            this.label4.Text = "بيان تسديد الى مورد";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Supplier_Payback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1279, 671);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Supplier_Payback";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Supplier_Payback";
            this.Load += new System.EventHandler(this.Supplier_Payback_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox combo_Supliers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_Print;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.TextBox tb_AfterPayment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_payment;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_OldMoney;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}