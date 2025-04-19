using System.ComponentModel;

namespace MDBMS___E_COMMERCE_PLATFORM
{
    partial class Product
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClick1 = new System.Windows.Forms.Button();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.colProductName, this.colCategory, this.colPrice, this.colSize, this.colColor, this.colBrand, this.colMaterial, this.colWarranty });
            this.dgvProducts.Location = new System.Drawing.Point(34, 34);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.Size = new System.Drawing.Size(733, 199);
            this.dgvProducts.TabIndex = 0;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Tên sản phẩm";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 120;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Loại sản phẩm";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 120;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Giá tiền";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 80;
            // 
            // colSize
            // 
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            this.colSize.Width = 50;
            // 
            // colColor
            // 
            this.colColor.HeaderText = "Màu sắc";
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            this.colColor.Width = 80;
            // 
            // colBrand
            // 
            this.colBrand.HeaderText = "Tên hãng";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            this.colBrand.Width = 80;
            // 
            // colMaterial
            // 
            this.colMaterial.HeaderText = "Chất liệu";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.ReadOnly = true;
            this.colMaterial.Width = 80;
            // 
            // colWarranty
            // 
            this.colWarranty.HeaderText = "Thời hạn bảo hành";
            this.colWarranty.Name = "colWarranty";
            this.colWarranty.ReadOnly = true;
            this.colWarranty.Width = 80;
            // 
            // btnClick1
            // 
            this.btnClick1.Location = new System.Drawing.Point(653, 239);
            this.btnClick1.Name = "btnClick1";
            this.btnClick1.Size = new System.Drawing.Size(114, 49);
            this.btnClick1.TabIndex = 1;
            this.btnClick1.Text = "Thêm vào giỏ hàng";
            this.btnClick1.UseVisualStyleBackColor = true;
            this.btnClick1.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(34, 239);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(120, 20);
            this.nudQuantity.TabIndex = 2;
            // 
            // Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.btnClick1);
            this.Controls.Add(this.dgvProducts);
            this.Name = "Cart";
            this.Text = "Cart";
            this.Load += new System.EventHandler(this.FormAddToCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarranty;

        private System.Windows.Forms.Button btnClick1;
        private System.Windows.Forms.NumericUpDown nudQuantity;

        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;

        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;

        private System.Windows.Forms.DataGridView dgvProducts;

        #endregion
    }
}