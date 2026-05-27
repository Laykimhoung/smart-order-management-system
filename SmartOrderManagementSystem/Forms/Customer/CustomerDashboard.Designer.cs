namespace SmartOrderManagementSystem.Forms.Customer
{
    partial class CustomerDashboard
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.All = new System.Windows.Forms.TabPage();
            this.Coffee = new System.Windows.Forms.TabPage();
            this.Tea = new System.Windows.Forms.TabPage();
            this.Drink = new System.Windows.Forms.TabPage();
            this.Dessert = new System.Windows.Forms.TabPage();
            this.txtSelectProduct = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numQty = new System.Windows.Forms.NumericUpDown();
            this.btnAddToOrder = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvOrderItems = new System.Windows.Forms.ListView();
            this.Product = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnPlaceOrder = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCartCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLoggedIn = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1360, 68);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Romnea", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(1188, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(133, 47);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(945, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 39);
            this.textBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(545, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(272, 39);
            this.comboBox1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Romnea", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(826, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 55);
            this.label3.TabIndex = 0;
            this.label3.Text = "Search:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Romnea", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 642);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "Product Selected:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Romnea", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wellcome,[username]";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.All);
            this.tabControl1.Controls.Add(this.Coffee);
            this.tabControl1.Controls.Add(this.Tea);
            this.tabControl1.Controls.Add(this.Drink);
            this.tabControl1.Controls.Add(this.Dessert);
            this.tabControl1.Font = new System.Drawing.Font("Romnea", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(25, 115);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(681, 509);
            this.tabControl1.TabIndex = 1;
            // 
            // All
            // 
            this.All.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.All.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.All.Location = new System.Drawing.Point(4, 45);
            this.All.Name = "All";
            this.All.Padding = new System.Windows.Forms.Padding(3);
            this.All.Size = new System.Drawing.Size(673, 460);
            this.All.TabIndex = 0;
            this.All.Text = "All";
            this.All.UseVisualStyleBackColor = true;
            // 
            // Coffee
            // 
            this.Coffee.Font = new System.Drawing.Font("Cooper Black", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Coffee.Location = new System.Drawing.Point(4, 45);
            this.Coffee.Name = "Coffee";
            this.Coffee.Padding = new System.Windows.Forms.Padding(3);
            this.Coffee.Size = new System.Drawing.Size(673, 460);
            this.Coffee.TabIndex = 1;
            this.Coffee.Text = "Coffee";
            this.Coffee.UseVisualStyleBackColor = true;
            // 
            // Tea
            // 
            this.Tea.Font = new System.Drawing.Font("Cooper Black", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tea.Location = new System.Drawing.Point(4, 45);
            this.Tea.Name = "Tea";
            this.Tea.Padding = new System.Windows.Forms.Padding(3);
            this.Tea.Size = new System.Drawing.Size(673, 460);
            this.Tea.TabIndex = 2;
            this.Tea.Text = "Tea";
            this.Tea.UseVisualStyleBackColor = true;
            // 
            // Drink
            // 
            this.Drink.Font = new System.Drawing.Font("Cooper Black", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Drink.Location = new System.Drawing.Point(4, 45);
            this.Drink.Name = "Drink";
            this.Drink.Padding = new System.Windows.Forms.Padding(3);
            this.Drink.Size = new System.Drawing.Size(673, 460);
            this.Drink.TabIndex = 3;
            this.Drink.Text = "Drink";
            this.Drink.UseVisualStyleBackColor = true;
            // 
            // Dessert
            // 
            this.Dessert.Location = new System.Drawing.Point(4, 45);
            this.Dessert.Name = "Dessert";
            this.Dessert.Padding = new System.Windows.Forms.Padding(3);
            this.Dessert.Size = new System.Drawing.Size(673, 460);
            this.Dessert.TabIndex = 4;
            this.Dessert.Text = "Dessert";
            this.Dessert.UseVisualStyleBackColor = true;
            // 
            // txtSelectProduct
            // 
            this.txtSelectProduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectProduct.Location = new System.Drawing.Point(191, 642);
            this.txtSelectProduct.Name = "txtSelectProduct";
            this.txtSelectProduct.ReadOnly = true;
            this.txtSelectProduct.Size = new System.Drawing.Size(187, 30);
            this.txtSelectProduct.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Romnea", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(384, 642);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 33);
            this.label4.TabIndex = 0;
            this.label4.Text = "Qty:";
            // 
            // numQty
            // 
            this.numQty.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQty.Location = new System.Drawing.Point(440, 645);
            this.numQty.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQty.Name = "numQty";
            this.numQty.Size = new System.Drawing.Size(90, 30);
            this.numQty.TabIndex = 3;
            this.numQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddToOrder
            // 
            this.btnAddToOrder.Font = new System.Drawing.Font("Romnea", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToOrder.Location = new System.Drawing.Point(584, 636);
            this.btnAddToOrder.Name = "btnAddToOrder";
            this.btnAddToOrder.Size = new System.Drawing.Size(118, 44);
            this.btnAddToOrder.TabIndex = 4;
            this.btnAddToOrder.Text = "Order";
            this.btnAddToOrder.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Romnea", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(379, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 55);
            this.label5.TabIndex = 0;
            this.label5.Text = "Category:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.btnPlaceOrder);
            this.groupBox1.Controls.Add(this.btnClearAll);
            this.groupBox1.Controls.Add(this.btnRemoveItem);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lvOrderItems);
            this.groupBox1.Font = new System.Drawing.Font("Romnea", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(787, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(567, 460);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Order:";
            // 
            // lvOrderItems
            // 
            this.lvOrderItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Product,
            this.Qty,
            this.Price});
            this.lvOrderItems.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvOrderItems.FullRowSelect = true;
            this.lvOrderItems.GridLines = true;
            this.lvOrderItems.HideSelection = false;
            this.lvOrderItems.Location = new System.Drawing.Point(27, 49);
            this.lvOrderItems.Name = "lvOrderItems";
            this.lvOrderItems.Size = new System.Drawing.Size(519, 194);
            this.lvOrderItems.TabIndex = 0;
            this.lvOrderItems.UseCompatibleStateImageBehavior = false;
            this.lvOrderItems.View = System.Windows.Forms.View.Details;
            // 
            // Product
            // 
            this.Product.Text = "Product";
            this.Product.Width = 205;
            // 
            // Qty
            // 
            this.Qty.Text = "Qty";
            this.Qty.Width = 136;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 177;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 41);
            this.label6.TabIndex = 1;
            this.label6.Text = "Total:";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(368, 265);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(165, 34);
            this.textBox2.TabIndex = 2;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Font = new System.Drawing.Font("Romnea", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveItem.ForeColor = System.Drawing.Color.Red;
            this.btnRemoveItem.Location = new System.Drawing.Point(61, 321);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(169, 62);
            this.btnRemoveItem.TabIndex = 4;
            this.btnRemoveItem.Text = "Remove";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            this.btnClearAll.Font = new System.Drawing.Font("Romnea", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.Location = new System.Drawing.Point(323, 321);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(169, 62);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            // 
            // btnPlaceOrder
            // 
            this.btnPlaceOrder.BackColor = System.Drawing.Color.Blue;
            this.btnPlaceOrder.Font = new System.Drawing.Font("Romnea", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlaceOrder.Location = new System.Drawing.Point(164, 389);
            this.btnPlaceOrder.Name = "btnPlaceOrder";
            this.btnPlaceOrder.Size = new System.Drawing.Size(259, 62);
            this.btnPlaceOrder.TabIndex = 4;
            this.btnPlaceOrder.Text = "Place Order";
            this.btnPlaceOrder.UseVisualStyleBackColor = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblCartCount,
            this.lblLoggedIn});
            this.statusStrip1.Location = new System.Drawing.Point(0, 827);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1379, 26);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 20);
            this.lblStatus.Text = "Ready";
            // 
            // lblCartCount
            // 
            this.lblCartCount.Name = "lblCartCount";
            this.lblCartCount.Size = new System.Drawing.Size(105, 20);
            this.lblCartCount.Text = "Items in cart: 0";
            // 
            // lblLoggedIn
            // 
            this.lblLoggedIn.Name = "lblLoggedIn";
            this.lblLoggedIn.Size = new System.Drawing.Size(175, 20);
            this.lblLoggedIn.Text = "Logged in as: [username]";
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1379, 853);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddToOrder);
            this.Controls.Add(this.numQty);
            this.Controls.Add(this.txtSelectProduct);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "CustomerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numQty)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage All;
        private System.Windows.Forms.TabPage Coffee;
        private System.Windows.Forms.TabPage Tea;
        private System.Windows.Forms.TabPage Drink;
        private System.Windows.Forms.TabPage Dessert;
        private System.Windows.Forms.TextBox txtSelectProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numQty;
        private System.Windows.Forms.Button btnAddToOrder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvOrderItems;
        private System.Windows.Forms.ColumnHeader Product;
        private System.Windows.Forms.ColumnHeader Qty;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnPlaceOrder;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblCartCount;
        private System.Windows.Forms.ToolStripStatusLabel lblLoggedIn;
    }
}