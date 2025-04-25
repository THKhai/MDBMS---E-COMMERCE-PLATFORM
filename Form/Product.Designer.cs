using System.ComponentModel;

namespace MDBMS___E_COMMERCE_PLATFORM.Form
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
            this.btnClick1 = new System.Windows.Forms.Button();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWarranty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seller = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClick1
            // 
            this.btnClick1.Location = new System.Drawing.Point(992, 295);
            this.btnClick1.Margin = new System.Windows.Forms.Padding(4);
            this.btnClick1.Name = "btnClick1";
            this.btnClick1.Size = new System.Drawing.Size(152, 60);
            this.btnClick1.TabIndex = 1;
            this.btnClick1.Text = "Thêm vào giỏ hàng";
            this.btnClick1.UseVisualStyleBackColor = true;
            this.btnClick1.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(23, 315);
            this.nudQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(160, 22);
            this.nudQuantity.TabIndex = 2;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.ID, this.colProductName, this.colCategory, this.colPrice, this.colSize, this.colColor, this.colBrand, this.colMaterial, this.colWarranty, this.seller, this.sellerID });
            this.dgvProducts.Location = new System.Drawing.Point(23, 34);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 50;
            this.dgvProducts.Size = new System.Drawing.Size(1121, 253);
            this.dgvProducts.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Tên sản phẩm";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 140;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Loại sản phẩm";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 150;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Giá tiền";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colSize
            // 
            this.colSize.HeaderText = "Kho";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            this.colSize.Width = 80;
            // 
            // colColor
            // 
            this.colColor.HeaderText = "Mô tả";
            this.colColor.Name = "colColor";
            this.colColor.ReadOnly = true;
            // 
            // colBrand
            // 
            this.colBrand.HeaderText = "Giảm giá";
            this.colBrand.Name = "colBrand";
            this.colBrand.ReadOnly = true;
            // 
            // colMaterial
            // 
            this.colMaterial.HeaderText = "Ngày bắt đầu";
            this.colMaterial.Name = "colMaterial";
            this.colMaterial.ReadOnly = true;
            this.colMaterial.Width = 120;
            // 
            // colWarranty
            // 
            this.colWarranty.HeaderText = "Ngày kết thúc";
            this.colWarranty.Name = "colWarranty";
            this.colWarranty.ReadOnly = true;
            this.colWarranty.Width = 160;
            // 
            // seller
            // 
            this.seller.HeaderText = "Người bán";
            this.seller.Name = "seller";
            this.seller.ReadOnly = true;
            this.seller.Width = 120;
            // 
            // sellerID
            // 
            this.sellerID.HeaderText = "sellerID";
            this.sellerID.Name = "sellerID";
            this.sellerID.ReadOnly = true;
            this.sellerID.Visible = false;
            // 
            // Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1165, 554);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.btnClick1);
            this.Controls.Add(this.dgvProducts);
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Product";
            this.Load += new System.EventHandler(this.FormAddToCart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridViewTextBoxColumn seller;

        private System.Windows.Forms.DataGridViewTextBoxColumn sellerID;

        private System.Windows.Forms.DataGridViewTextBoxColumn ID;

        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWarranty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn colColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridView dgvProducts;

        private System.Windows.Forms.Button btnClick1;

        #endregion
    }
}