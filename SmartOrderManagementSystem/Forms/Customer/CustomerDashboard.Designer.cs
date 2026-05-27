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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.All = new System.Windows.Forms.TabPage();
            this.Coffee = new System.Windows.Forms.TabPage();
            this.Tea = new System.Windows.Forms.TabPage();
            this.Drink = new System.Windows.Forms.TabPage();
            this.Dessert = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1429, 68);
            this.panel1.TabIndex = 0;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Romnea", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(390, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 55);
            this.label2.TabIndex = 0;
            this.label2.Text = "Category:";
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
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(945, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(209, 39);
            this.textBox1.TabIndex = 2;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.All);
            this.tabControl1.Controls.Add(this.Coffee);
            this.tabControl1.Controls.Add(this.Tea);
            this.tabControl1.Controls.Add(this.Drink);
            this.tabControl1.Controls.Add(this.Dessert);
            this.tabControl1.Location = new System.Drawing.Point(13, 108);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(591, 417);
            this.tabControl1.TabIndex = 1;
            // 
            // All
            // 
            this.All.Location = new System.Drawing.Point(4, 25);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(583, 388);
            this.All.TabIndex = 0;
            this.All.Text = "All";
            this.All.UseVisualStyleBackColor = true;
            // 
            // Coffee
            // 
            this.Coffee.Location = new System.Drawing.Point(4, 25);
            this.Coffee.Name = "Coffee";
            this.Coffee.Size = new System.Drawing.Size(583, 388);
            this.Coffee.TabIndex = 1;
            this.Coffee.Text = "Coffee";
            this.Coffee.UseVisualStyleBackColor = true;
            // 
            // Tea
            // 
            this.Tea.Location = new System.Drawing.Point(4, 25);
            this.Tea.Name = "Tea";
            this.Tea.Size = new System.Drawing.Size(583, 388);
            this.Tea.TabIndex = 2;
            this.Tea.Text = "Tea";
            this.Tea.UseVisualStyleBackColor = true;
            // 
            // Drink
            // 
            this.Drink.Location = new System.Drawing.Point(4, 25);
            this.Drink.Name = "Drink";
            this.Drink.Size = new System.Drawing.Size(583, 388);
            this.Drink.TabIndex = 3;
            this.Drink.Text = "Drink";
            this.Drink.UseVisualStyleBackColor = true;
            // 
            // Dessert
            // 
            this.Dessert.Location = new System.Drawing.Point(4, 25);
            this.Dessert.Name = "Dessert";
            this.Dessert.Size = new System.Drawing.Size(583, 388);
            this.Dessert.TabIndex = 4;
            this.Dessert.Text = "Dessert";
            this.Dessert.UseVisualStyleBackColor = true;
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1453, 853);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerDashboard";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}