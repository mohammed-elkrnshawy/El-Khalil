namespace El_Khalil
{
    partial class Add_Materials
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_price = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_sell = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_gram = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.cb_kilo = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cb_kilo);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.cb_gram);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tb_sell);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tb_price);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tb_name);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(352, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 350);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(682, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 27);
            this.label4.TabIndex = 15;
            this.label4.Text = "اضافة مادة خام جديدة";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(436, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 27);
            this.label1.TabIndex = 16;
            this.label1.Text = "اسم الماد الخام";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_name.Location = new System.Drawing.Point(46, 61);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(371, 24);
            this.tb_name.TabIndex = 1;
            this.tb_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_price
            // 
            this.tb_price.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_price.Location = new System.Drawing.Point(46, 127);
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(371, 24);
            this.tb_price.TabIndex = 2;
            this.tb_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(431, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 27);
            this.label2.TabIndex = 18;
            this.label2.Text = "سعر الشراء اليوم";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_sell
            // 
            this.tb_sell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_sell.Location = new System.Drawing.Point(46, 187);
            this.tb_sell.Name = "tb_sell";
            this.tb_sell.Size = new System.Drawing.Size(371, 24);
            this.tb_sell.TabIndex = 3;
            this.tb_sell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_sell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(431, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 27);
            this.label3.TabIndex = 20;
            this.label3.Text = "سعر البيع اليوم";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(431, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 27);
            this.label5.TabIndex = 22;
            this.label5.Text = "وحدة التعامل";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_gram
            // 
            this.cb_gram.AutoSize = true;
            this.cb_gram.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cb_gram.Location = new System.Drawing.Point(169, 249);
            this.cb_gram.Name = "cb_gram";
            this.cb_gram.Size = new System.Drawing.Size(45, 21);
            this.cb_gram.TabIndex = 5;
            this.cb_gram.Text = "جم";
            this.cb_gram.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radioButton2.Location = new System.Drawing.Point(260, 249);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 21);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "كجم";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // cb_kilo
            // 
            this.cb_kilo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.cb_kilo.FlatAppearance.BorderSize = 0;
            this.cb_kilo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(84)))), ((int)(((byte)(102)))));
            this.cb_kilo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_kilo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cb_kilo.ForeColor = System.Drawing.Color.White;
            this.cb_kilo.Location = new System.Drawing.Point(46, 307);
            this.cb_kilo.Name = "cb_kilo";
            this.cb_kilo.Size = new System.Drawing.Size(75, 28);
            this.cb_kilo.TabIndex = 6;
            this.cb_kilo.Text = "حفظ";
            this.cb_kilo.UseVisualStyleBackColor = false;
            this.cb_kilo.Click += new System.EventHandler(this.button1_Click);
            // 
            // Add_Materials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1269, 552);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Add_Materials";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Add_Materials";
            this.Load += new System.EventHandler(this.Add_Materials_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_sell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton cb_gram;
        private System.Windows.Forms.Button cb_kilo;
    }
}