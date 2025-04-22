using System.ComponentModel;

namespace MDBMS___E_COMMERCE_PLATFORM.Form.Shop
{
    partial class Storage
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
            this.Save = new System.Windows.Forms.Button();
            this.ProductGridView = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ProductGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(797, 449);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(196, 57);
            this.Save.TabIndex = 0;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.BtnSaveClick);
            // 
            // ProductGridView
            // 
            this.ProductGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProductGridView.Location = new System.Drawing.Point(12, 44);
            this.ProductGridView.Name = "ProductGridView";
            this.ProductGridView.RowTemplate.Height = 24;
            this.ProductGridView.Size = new System.Drawing.Size(981, 357);
            this.ProductGridView.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 449);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 57);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Storage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 541);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ProductGridView);
            this.Controls.Add(this.Save);
            this.Name = "Storage";
            this.Text = "ShopStorage";
            this.Load += new System.EventHandler(this.Storage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProductGridView)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.DataGridView ProductGridView;

        private System.Windows.Forms.Button Save;

        #endregion
    }
}