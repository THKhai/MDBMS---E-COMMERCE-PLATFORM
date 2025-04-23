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
            this.label1 = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(82, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa chỉ giao hàng:";
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(262, 233);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(428, 22);
            this.textBox1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(82, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "Phương thức thanh toán:";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(262, 89);
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
            this.radioButton2.Location = new System.Drawing.Point(483, 89);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(150, 26);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Thẻ ngân hàng";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(262, 123);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(200, 26);
            this.radioButton3.TabIndex = 12;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Ví điện tử\r\n";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.Location = new System.Drawing.Point(483, 121);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(200, 26);
            this.radioButton4.TabIndex = 13;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Trả góp";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(262, 155);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(428, 22);
            this.textBox2.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(82, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Cardnumber\r\n";
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(266, 270);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(424, 124);
            this.richTextBox1.TabIndex = 19;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(82, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 26);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ghi chú cho shipper:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(499, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 26);
            this.label5.TabIndex = 21;
            this.label5.Text = "leabel";
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.header);
            this.Controls.Add(this.label7);
            this.Name = "Order";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.Order_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.RadioButton radioButton4;

        private System.Windows.Forms.RadioButton radioButton3;

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