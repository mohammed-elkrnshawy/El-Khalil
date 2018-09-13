namespace El_Khalil
{
    partial class Bank_InAccount
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
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_money = new System.Windows.Forms.TextBox();
            this.tb_number = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_account = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.combo_Bank = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_kilo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(737, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 27);
            this.label4.TabIndex = 21;
            this.label4.Text = "ايداع في حسابى";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tb_money);
            this.panel2.Controls.Add(this.tb_number);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.tb_account);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.combo_Bank);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.cb_kilo);
            this.panel2.Location = new System.Drawing.Point(346, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 426);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // tb_money
            // 
            this.tb_money.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_money.Location = new System.Drawing.Point(126, 167);
            this.tb_money.Name = "tb_money";
            this.tb_money.Size = new System.Drawing.Size(212, 24);
            this.tb_money.TabIndex = 55;
            this.tb_money.Text = "0.00";
            this.tb_money.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_money.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_money_KeyPress);
            // 
            // tb_number
            // 
            this.tb_number.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_number.Location = new System.Drawing.Point(126, 213);
            this.tb_number.Name = "tb_number";
            this.tb_number.Size = new System.Drawing.Size(212, 24);
            this.tb_number.TabIndex = 61;
            this.tb_number.Text = "0";
            this.tb_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(344, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 27);
            this.label6.TabIndex = 62;
            this.label6.Text = "المبلغ المراد ايداعه";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_account
            // 
            this.tb_account.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_account.Location = new System.Drawing.Point(126, 124);
            this.tb_account.Name = "tb_account";
            this.tb_account.ReadOnly = true;
            this.tb_account.Size = new System.Drawing.Size(212, 24);
            this.tb_account.TabIndex = 59;
            this.tb_account.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(344, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 27);
            this.label5.TabIndex = 60;
            this.label5.Text = "رقم الحساب";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(126, 262);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.richTextBox1.Size = new System.Drawing.Size(399, 96);
            this.richTextBox1.TabIndex = 58;
            this.richTextBox1.Text = "بيان الايداع";
            // 
            // combo_Bank
            // 
            this.combo_Bank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combo_Bank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_Bank.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Bank.FormattingEnabled = true;
            this.combo_Bank.Location = new System.Drawing.Point(126, 82);
            this.combo_Bank.Name = "combo_Bank";
            this.combo_Bank.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_Bank.Size = new System.Drawing.Size(399, 24);
            this.combo_Bank.TabIndex = 57;
            this.combo_Bank.Tag = "";
            this.combo_Bank.Text = "اختار بنك للايداع";
            this.combo_Bank.SelectedIndexChanged += new System.EventHandler(this.combo_Bank_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(3, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(645, 45);
            this.panel3.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(3, 8);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(213, 29);
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
            this.label13.Location = new System.Drawing.Point(222, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 29);
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
            this.label2.Location = new System.Drawing.Point(423, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 29);
            this.label2.TabIndex = 39;
            this.label2.Text = "000000000";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(523, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 29);
            this.label3.TabIndex = 22;
            this.label3.Text = "رقم البيان";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_kilo
            // 
            this.cb_kilo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.cb_kilo.FlatAppearance.BorderSize = 0;
            this.cb_kilo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(84)))), ((int)(((byte)(102)))));
            this.cb_kilo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_kilo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cb_kilo.ForeColor = System.Drawing.Color.White;
            this.cb_kilo.Location = new System.Drawing.Point(6, 377);
            this.cb_kilo.Name = "cb_kilo";
            this.cb_kilo.Size = new System.Drawing.Size(75, 28);
            this.cb_kilo.TabIndex = 6;
            this.cb_kilo.Text = "حفظ";
            this.cb_kilo.UseVisualStyleBackColor = false;
            this.cb_kilo.Click += new System.EventHandler(this.cb_kilo_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(690, 346);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(181, 27);
            this.label1.TabIndex = 56;
            this.label1.Text = "رقم الايصال";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Bank_InAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1342, 669);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bank_InAccount";
            this.Text = "Bank_InAccount";
            this.Load += new System.EventHandler(this.Bank_InAccount_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cb_kilo;
        private System.Windows.Forms.ComboBox combo_Bank;
        private System.Windows.Forms.TextBox tb_money;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_number;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_account;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}