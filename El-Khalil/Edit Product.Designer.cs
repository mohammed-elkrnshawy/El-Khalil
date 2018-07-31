namespace El_Khalil
{
    partial class Edit_Product
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.combo_name = new System.Windows.Forms.ComboBox();
            this.tb_per = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.tb_quantity = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_kilo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_sell = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(309, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(733, 551);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.combo_name);
            this.panel2.Controls.Add(this.tb_per);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.radioButton3);
            this.panel2.Controls.Add(this.tb_quantity);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cb_kilo);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.tb_sell);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tb_name);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 77);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(727, 467);
            this.panel2.TabIndex = 51;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.dataGridView1.Location = new System.Drawing.Point(96, 246);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(531, 180);
            this.dataGridView1.TabIndex = 64;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Location = new System.Drawing.Point(145, 177);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(426, 12);
            this.panel3.TabIndex = 63;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // combo_name
            // 
            this.combo_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.combo_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.combo_name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.combo_name.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_name.FormattingEnabled = true;
            this.combo_name.Location = new System.Drawing.Point(392, 199);
            this.combo_name.Name = "combo_name";
            this.combo_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.combo_name.Size = new System.Drawing.Size(214, 24);
            this.combo_name.TabIndex = 52;
            this.combo_name.Tag = "";
            this.combo_name.Text = "اختار مادة خام";
            // 
            // tb_per
            // 
            this.tb_per.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_per.Location = new System.Drawing.Point(357, 125);
            this.tb_per.Name = "tb_per";
            this.tb_per.Size = new System.Drawing.Size(109, 24);
            this.tb_per.TabIndex = 51;
            this.tb_per.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_per.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_per_KeyPress);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.radioButton2);
            this.panel5.Controls.Add(this.radioButton4);
            this.panel5.Location = new System.Drawing.Point(104, 199);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(128, 27);
            this.panel5.TabIndex = 62;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radioButton2.Location = new System.Drawing.Point(72, 3);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 21);
            this.radioButton2.TabIndex = 29;
            this.radioButton2.TabStop = true;
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
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radioButton1.Location = new System.Drawing.Point(265, 127);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 21);
            this.radioButton1.TabIndex = 60;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "كجم";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.radioButton3.Location = new System.Drawing.Point(177, 127);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(45, 21);
            this.radioButton3.TabIndex = 61;
            this.radioButton3.Text = "جم";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // tb_quantity
            // 
            this.tb_quantity.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_quantity.Location = new System.Drawing.Point(252, 199);
            this.tb_quantity.Name = "tb_quantity";
            this.tb_quantity.Size = new System.Drawing.Size(55, 24);
            this.tb_quantity.TabIndex = 53;
            this.tb_quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_quantity_KeyPress);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(296, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 27);
            this.label2.TabIndex = 59;
            this.label2.Text = "الكمية";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_kilo
            // 
            this.cb_kilo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.cb_kilo.FlatAppearance.BorderSize = 0;
            this.cb_kilo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(84)))), ((int)(((byte)(102)))));
            this.cb_kilo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_kilo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cb_kilo.ForeColor = System.Drawing.Color.White;
            this.cb_kilo.Location = new System.Drawing.Point(104, 435);
            this.cb_kilo.Name = "cb_kilo";
            this.cb_kilo.Size = new System.Drawing.Size(75, 28);
            this.cb_kilo.TabIndex = 54;
            this.cb_kilo.Text = "حفظ";
            this.cb_kilo.UseVisualStyleBackColor = false;
            this.cb_kilo.Click += new System.EventHandler(this.cb_kilo_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(485, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 27);
            this.label5.TabIndex = 57;
            this.label5.Text = "وحدة التعامل";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_sell
            // 
            this.tb_sell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_sell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_sell.Location = new System.Drawing.Point(95, 68);
            this.tb_sell.Name = "tb_sell";
            this.tb_sell.Size = new System.Drawing.Size(371, 24);
            this.tb_sell.TabIndex = 50;
            this.tb_sell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_sell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_per_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(485, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 27);
            this.label3.TabIndex = 56;
            this.label3.Text = "سعر البيع اليوم";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_name
            // 
            this.tb_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_name.Location = new System.Drawing.Point(95, 7);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(371, 24);
            this.tb_name.TabIndex = 49;
            this.tb_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(485, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 27);
            this.label1.TabIndex = 55;
            this.label1.Text = "اسم المنتج النهائى";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(179, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(353, 24);
            this.comboBox1.TabIndex = 50;
            this.comboBox1.Tag = "";
            this.comboBox1.Text = "اختار منتج نهائى";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Location = new System.Drawing.Point(148, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(426, 12);
            this.panel4.TabIndex = 49;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(746, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 27);
            this.label4.TabIndex = 16;
            this.label4.Text = "تعديل منتج نهائى";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Edit_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1281, 616);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Edit_Product";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Edit_Product";
            this.Load += new System.EventHandler(this.Edit_Product_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox combo_name;
        private System.Windows.Forms.TextBox tb_per;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox tb_quantity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cb_kilo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_sell;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}