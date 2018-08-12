namespace El_Khalil
{
    partial class Employee_AccountDetails
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
            this.label12 = new System.Windows.Forms.Label();
            this.bt_Save = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pn_S = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pn_P = new System.Windows.Forms.Panel();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_render = new System.Windows.Forms.TextBox();
            this.tb_money = new System.Windows.Forms.TextBox();
            this.tb_sna = new System.Windows.Forms.TextBox();
            this.tb_month = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pn_S.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pn_P.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(247, 38);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(212, 29);
            this.label12.TabIndex = 57;
            this.label12.Text = "14 / 10 / 1995 20:04:42 ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.bt_Save.Location = new System.Drawing.Point(100, 445);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(139, 28);
            this.bt_Save.TabIndex = 62;
            this.bt_Save.Text = "تصفية الشهر";
            this.bt_Save.UseVisualStyleBackColor = false;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(84)))), ((int)(((byte)(102)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(100, 411);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 28);
            this.button1.TabIndex = 69;
            this.button1.Text = "تعاملات الشهر";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pn_S
            // 
            this.pn_S.Controls.Add(this.dataGridView1);
            this.pn_S.Location = new System.Drawing.Point(12, 78);
            this.pn_S.Name = "pn_S";
            this.pn_S.Size = new System.Drawing.Size(683, 327);
            this.pn_S.TabIndex = 70;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(189)))), ((int)(((byte)(212)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(683, 327);
            this.dataGridView1.TabIndex = 0;
            // 
            // pn_P
            // 
            this.pn_P.Controls.Add(this.tb_name);
            this.pn_P.Controls.Add(this.label5);
            this.pn_P.Controls.Add(this.tb_render);
            this.pn_P.Controls.Add(this.tb_money);
            this.pn_P.Controls.Add(this.tb_sna);
            this.pn_P.Controls.Add(this.tb_month);
            this.pn_P.Controls.Add(this.label4);
            this.pn_P.Controls.Add(this.label3);
            this.pn_P.Controls.Add(this.label2);
            this.pn_P.Controls.Add(this.label1);
            this.pn_P.Location = new System.Drawing.Point(12, 72);
            this.pn_P.Name = "pn_P";
            this.pn_P.Size = new System.Drawing.Size(683, 333);
            this.pn_P.TabIndex = 71;
            // 
            // tb_name
            // 
            this.tb_name.Enabled = false;
            this.tb_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_name.Location = new System.Drawing.Point(151, 37);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(199, 24);
            this.tb_name.TabIndex = 78;
            this.tb_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(371, 34);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(161, 29);
            this.label5.TabIndex = 77;
            this.label5.Text = "اسم الموظف";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_render
            // 
            this.tb_render.Enabled = false;
            this.tb_render.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_render.Location = new System.Drawing.Point(151, 273);
            this.tb_render.Name = "tb_render";
            this.tb_render.Size = new System.Drawing.Size(199, 24);
            this.tb_render.TabIndex = 76;
            this.tb_render.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_money
            // 
            this.tb_money.Enabled = false;
            this.tb_money.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_money.Location = new System.Drawing.Point(151, 214);
            this.tb_money.Name = "tb_money";
            this.tb_money.Size = new System.Drawing.Size(199, 24);
            this.tb_money.TabIndex = 75;
            this.tb_money.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_sna
            // 
            this.tb_sna.Enabled = false;
            this.tb_sna.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_sna.Location = new System.Drawing.Point(151, 152);
            this.tb_sna.Name = "tb_sna";
            this.tb_sna.Size = new System.Drawing.Size(199, 24);
            this.tb_sna.TabIndex = 74;
            this.tb_sna.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_month
            // 
            this.tb_month.Enabled = false;
            this.tb_month.Font = new System.Drawing.Font("Tahoma", 10F);
            this.tb_month.Location = new System.Drawing.Point(151, 95);
            this.tb_month.Name = "tb_month";
            this.tb_month.Size = new System.Drawing.Size(199, 24);
            this.tb_month.TabIndex = 73;
            this.tb_month.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(371, 270);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(161, 29);
            this.label4.TabIndex = 72;
            this.label4.Text = "الصافى ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(371, 211);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(161, 29);
            this.label3.TabIndex = 71;
            this.label3.Text = "اجمالى القبض النقدى";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(371, 149);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(161, 29);
            this.label2.TabIndex = 70;
            this.label2.Text = "اجمالى الجزءات";
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
            this.label1.Location = new System.Drawing.Point(371, 92);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(161, 29);
            this.label1.TabIndex = 69;
            this.label1.Text = "مبلغ الشهرية";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Employee_AccountDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(707, 555);
            this.Controls.Add(this.pn_P);
            this.Controls.Add(this.pn_S);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.label12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Employee_AccountDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Employee_AccountDetails_Load);
            this.pn_S.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pn_P.ResumeLayout(false);
            this.pn_P.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pn_S;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pn_P;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_render;
        private System.Windows.Forms.TextBox tb_money;
        private System.Windows.Forms.TextBox tb_sna;
        private System.Windows.Forms.TextBox tb_month;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}