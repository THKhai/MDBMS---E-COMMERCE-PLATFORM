using System.ComponentModel;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
{
    partial class Cart
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
            this.flowLayoutPanelCart = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelCart
            // 
            this.flowLayoutPanelCart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.flowLayoutPanelCart.Location = new System.Drawing.Point(0, 45);
            this.flowLayoutPanelCart.Name = "flowLayoutPanelCart";
            this.flowLayoutPanelCart.Size = new System.Drawing.Size(797, 315);
            this.flowLayoutPanelCart.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(353, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(688, 404);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Mua hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 404);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "Quay về";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(575, 375);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkTurquoise;
            this.label3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label3.Location = new System.Drawing.Point(-7, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(815, 47);
            this.label3.TabIndex = 5;
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanelCart);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Cart";
            this.Load += new System.EventHandler(this.Cart_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCart;

        #endregion
    }
}