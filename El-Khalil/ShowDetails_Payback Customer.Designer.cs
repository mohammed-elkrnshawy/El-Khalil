﻿namespace El_Khalil
{
    partial class ShowDetails_Payback_Customer
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
            this.button2 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.l_name = new System.Windows.Forms.Label();
            this.l_type = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tb_OldMoney = new System.Windows.Forms.TextBox();
            this.tb_AfterPayment = new System.Windows.Forms.TextBox();
            this.tb_payment = new System.Windows.Forms.TextBox();
            this.l_date = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.l_id = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(84)))), ((int)(((byte)(102)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::El_Khalil.Properties.Resources.print_black_printer_tool_symbol;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(9, 503);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 37);
            this.button2.TabIndex = 145;
            this.button2.Text = "طباعة";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(469, 199);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(147, 27);
            this.label11.TabIndex = 143;
            this.label11.Text = "المدفوع";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(469, 245);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(147, 27);
            this.label14.TabIndex = 144;
            this.label14.Text = "الباقي بعد الدفع";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(466, 155);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(150, 27);
            this.label15.TabIndex = 142;
            this.label15.Text = "اجمالى حساب قديم";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_name
            // 
            this.l_name.BackColor = System.Drawing.Color.White;
            this.l_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.l_name.ForeColor = System.Drawing.Color.Black;
            this.l_name.Location = new System.Drawing.Point(471, 69);
            this.l_name.Name = "l_name";
            this.l_name.Size = new System.Drawing.Size(233, 27);
            this.l_name.TabIndex = 141;
            this.l_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_type
            // 
            this.l_type.BackColor = System.Drawing.Color.White;
            this.l_type.Font = new System.Drawing.Font("Tahoma", 10F);
            this.l_type.ForeColor = System.Drawing.Color.Black;
            this.l_type.Location = new System.Drawing.Point(14, 20);
            this.l_type.Name = "l_type";
            this.l_type.Size = new System.Drawing.Size(150, 27);
            this.l_type.TabIndex = 140;
            this.l_type.Text = "تحويل بنكى";
            this.l_type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(145, 309);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox1.Size = new System.Drawing.Size(471, 197);
            this.richTextBox1.TabIndex = 138;
            this.richTextBox1.Text = "لا يوجد ملاحظات";
            // 
            // tb_OldMoney
            // 
            this.tb_OldMoney.Enabled = false;
            this.tb_OldMoney.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_OldMoney.Location = new System.Drawing.Point(145, 157);
            this.tb_OldMoney.Name = "tb_OldMoney";
            this.tb_OldMoney.Size = new System.Drawing.Size(295, 24);
            this.tb_OldMoney.TabIndex = 136;
            this.tb_OldMoney.Text = "0.00";
            this.tb_OldMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_AfterPayment
            // 
            this.tb_AfterPayment.Enabled = false;
            this.tb_AfterPayment.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_AfterPayment.Location = new System.Drawing.Point(145, 247);
            this.tb_AfterPayment.Name = "tb_AfterPayment";
            this.tb_AfterPayment.Size = new System.Drawing.Size(295, 24);
            this.tb_AfterPayment.TabIndex = 139;
            this.tb_AfterPayment.Text = "0.00";
            this.tb_AfterPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_payment
            // 
            this.tb_payment.Enabled = false;
            this.tb_payment.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_payment.Location = new System.Drawing.Point(145, 201);
            this.tb_payment.Name = "tb_payment";
            this.tb_payment.Size = new System.Drawing.Size(295, 24);
            this.tb_payment.TabIndex = 137;
            this.tb_payment.Text = "0.00";
            this.tb_payment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // l_date
            // 
            this.l_date.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_date.BackColor = System.Drawing.Color.White;
            this.l_date.Font = new System.Drawing.Font("Tahoma", 10F);
            this.l_date.ForeColor = System.Drawing.Color.Black;
            this.l_date.Location = new System.Drawing.Point(285, 20);
            this.l_date.Name = "l_date";
            this.l_date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.l_date.Size = new System.Drawing.Size(187, 27);
            this.l_date.TabIndex = 135;
            this.l_date.Text = "14 / 10 / 1995 20:04:42 ";
            this.l_date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(710, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 27);
            this.label1.TabIndex = 132;
            this.label1.Text = "رقم البيان";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(471, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(94, 27);
            this.label13.TabIndex = 134;
            this.label13.Text = "تاريج البيان";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_id
            // 
            this.l_id.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_id.BackColor = System.Drawing.Color.White;
            this.l_id.Font = new System.Drawing.Font("Tahoma", 10F);
            this.l_id.ForeColor = System.Drawing.Color.Black;
            this.l_id.Location = new System.Drawing.Point(592, 20);
            this.l_id.Name = "l_id";
            this.l_id.Size = new System.Drawing.Size(107, 27);
            this.l_id.TabIndex = 133;
            this.l_id.Text = "000000000";
            this.l_id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(710, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 27);
            this.label5.TabIndex = 131;
            this.label5.Text = "اسم المورد";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(170, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 27);
            this.label3.TabIndex = 130;
            this.label3.Text = "نوع البيان";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShowDetails_Payback_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 561);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.l_name);
            this.Controls.Add(this.l_type);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tb_OldMoney);
            this.Controls.Add(this.tb_AfterPayment);
            this.Controls.Add(this.tb_payment);
            this.Controls.Add(this.l_date);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.l_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Name = "ShowDetails_Payback_Customer";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عرض بيان تسديد";
            this.Load += new System.EventHandler(this.ShowDetails_Payback_Customer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label l_name;
        private System.Windows.Forms.Label l_type;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox tb_OldMoney;
        private System.Windows.Forms.TextBox tb_AfterPayment;
        private System.Windows.Forms.TextBox tb_payment;
        private System.Windows.Forms.Label l_date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label l_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}