namespace El_Khalil
{
    partial class Add_bank
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
            this.tb_phone2 = new System.Windows.Forms.TextBox();
            this.tb_phone = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_kilo = new System.Windows.Forms.Button();
            this.tb_address = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_company = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
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
            this.label4.TabIndex = 19;
            this.label4.Text = "اضافة بنك جديد";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tb_phone2);
            this.panel2.Controls.Add(this.tb_phone);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cb_kilo);
            this.panel2.Controls.Add(this.tb_address);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tb_company);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.tb_name);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(346, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 426);
            this.panel2.TabIndex = 18;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // tb_phone2
            // 
            this.tb_phone2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_phone2.Location = new System.Drawing.Point(42, 231);
            this.tb_phone2.Name = "tb_phone2";
            this.tb_phone2.Size = new System.Drawing.Size(166, 24);
            this.tb_phone2.TabIndex = 5;
            this.tb_phone2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_phone
            // 
            this.tb_phone.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_phone.Location = new System.Drawing.Point(249, 231);
            this.tb_phone.Name = "tb_phone";
            this.tb_phone.Size = new System.Drawing.Size(164, 24);
            this.tb_phone.TabIndex = 4;
            this.tb_phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(427, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 27);
            this.label1.TabIndex = 22;
            this.label1.Text = "ارقام التليفون";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_kilo
            // 
            this.cb_kilo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.cb_kilo.FlatAppearance.BorderSize = 0;
            this.cb_kilo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(84)))), ((int)(((byte)(102)))));
            this.cb_kilo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_kilo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cb_kilo.ForeColor = System.Drawing.Color.White;
            this.cb_kilo.Location = new System.Drawing.Point(46, 324);
            this.cb_kilo.Name = "cb_kilo";
            this.cb_kilo.Size = new System.Drawing.Size(75, 28);
            this.cb_kilo.TabIndex = 6;
            this.cb_kilo.Text = "حفظ";
            this.cb_kilo.UseVisualStyleBackColor = false;
            this.cb_kilo.Click += new System.EventHandler(this.cb_kilo_Click);
            // 
            // tb_address
            // 
            this.tb_address.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_address.Location = new System.Drawing.Point(42, 183);
            this.tb_address.Name = "tb_address";
            this.tb_address.Size = new System.Drawing.Size(371, 24);
            this.tb_address.TabIndex = 3;
            this.tb_address.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(427, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(207, 27);
            this.label3.TabIndex = 20;
            this.label3.Text = "عنوان الشركة";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_company
            // 
            this.tb_company.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_company.Location = new System.Drawing.Point(42, 133);
            this.tb_company.Name = "tb_company";
            this.tb_company.Size = new System.Drawing.Size(371, 24);
            this.tb_company.TabIndex = 2;
            this.tb_company.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(427, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 27);
            this.label6.TabIndex = 18;
            this.label6.Text = "رقم حساب البنك";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_name.Location = new System.Drawing.Point(42, 84);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(371, 24);
            this.tb_name.TabIndex = 1;
            this.tb_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(427, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 27);
            this.label7.TabIndex = 16;
            this.label7.Text = "اسم البنك كامل";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Add_bank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1342, 669);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_bank";
            this.Text = "Add_bank";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_phone2;
        private System.Windows.Forms.TextBox tb_phone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cb_kilo;
        private System.Windows.Forms.TextBox tb_address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_company;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label7;
    }
}