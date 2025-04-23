using System.ComponentModel;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    partial class Order
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.header = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.Location = new System.Drawing.Point(347, 11);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(89, 23);
            this.header.TabIndex = 6;
            this.header.Text = "header";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkTurquoise;
            this.label7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label7.Location = new System.Drawing.Point(-6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(815, 47);
            this.label7.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "Số thẻ:\r\n";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 34);
            this.button2.TabIndex = 18;
            this.button2.Text = "Quay về";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(673, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 34);
            this.button1.TabIndex = 17;
            this.button1.Text = "Thanh toán";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(536, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 26);
            this.label5.TabIndex = 21;
            this.label5.Text = "leabel";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(182, 87);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(428, 124);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ghi chú cho shipper:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(428, 22);
            this.textBox1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa chỉ giao hàng:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Phương thức thanh toán:";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(199, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(200, 26);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Thanh toán khi nhận hàng\r\n";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(420, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(150, 26);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Thẻ ngân hàng";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(182, 3);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(428, 22);
            this.textBox2.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(69, 212);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(641, 29);
            this.panel2.TabIndex = 23;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(30, 404);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(641, 226);
            this.panel1.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(15, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 26);
            this.label8.TabIndex = 23;
            this.label8.Text = "Số điện thoại:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(182, 31);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(428, 22);
            this.textBox4.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(15, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 26);
            this.label6.TabIndex = 21;
            this.label6.Text = "Họ và tên:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(182, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(428, 22);
            this.textBox3.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.textBox2);
            this.panel3.Location = new System.Drawing.Point(69, 246);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(641, 35);
            this.panel3.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(346, -92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 23);
            this.label16.TabIndex = 26;
            this.label16.Text = "header";
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.DarkTurquoise;
            this.label17.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label17.Location = new System.Drawing.Point(-7, -103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(815, 47);
            this.label17.TabIndex = 27;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.header);
            this.Controls.Add(this.label7);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;

        private System.Windows.Forms.Panel panel3;

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.RadioButton radioButton2;

        private System.Windows.Forms.RadioButton radioButton1;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}