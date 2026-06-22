namespace SmartOrderManagementSystem.Forms.Admin
{
    partial class OrderDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailsForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpOrderInfo = new System.Windows.Forms.GroupBox();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblWaitingNumber = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.separator1 = new ReaLTaiizor.Controls.Separator();
            this.separator2 = new ReaLTaiizor.Controls.Separator();
            this.label1 = new System.Windows.Forms.Label();
            this.separator3 = new ReaLTaiizor.Controls.Separator();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerateInvoice = new ReaLTaiizor.Controls.ParrotButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblOrderIDValue = new System.Windows.Forms.Label();
            this.lblWaitingNoValue = new System.Windows.Forms.Label();
            this.lblCustomerNameValue = new System.Windows.Forms.Label();
            this.lblStaffNameValue = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.lblOrderDateValue = new System.Windows.Forms.Label();
            this.dgvOrderItems = new System.Windows.Forms.DataGridView();
            this.lblTotalItemsValue = new System.Windows.Forms.Label();
            this.lblTotalAmountValue = new System.Windows.Forms.Label();
            this.grpOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(245, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Order Details";
            // 
            // grpOrderInfo
            // 
            this.grpOrderInfo.Controls.Add(this.lblOrderDateValue);
            this.grpOrderInfo.Controls.Add(this.lblStatusValue);
            this.grpOrderInfo.Controls.Add(this.lblStaffNameValue);
            this.grpOrderInfo.Controls.Add(this.lblCustomerNameValue);
            this.grpOrderInfo.Controls.Add(this.lblWaitingNoValue);
            this.grpOrderInfo.Controls.Add(this.lblOrderIDValue);
            this.grpOrderInfo.Controls.Add(this.label8);
            this.grpOrderInfo.Controls.Add(this.label7);
            this.grpOrderInfo.Controls.Add(this.lblOrderDate);
            this.grpOrderInfo.Controls.Add(this.lblCustomerName);
            this.grpOrderInfo.Controls.Add(this.lblWaitingNumber);
            this.grpOrderInfo.Controls.Add(this.lblOrderID);
            this.grpOrderInfo.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOrderInfo.Location = new System.Drawing.Point(42, 61);
            this.grpOrderInfo.Name = "grpOrderInfo";
            this.grpOrderInfo.Size = new System.Drawing.Size(560, 270);
            this.grpOrderInfo.TabIndex = 1;
            this.grpOrderInfo.TabStop = false;
            this.grpOrderInfo.Text = "Order Information";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(39, 162);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(123, 26);
            this.lblOrderDate.TabIndex = 5;
            this.lblOrderDate.Text = "Staff Name:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(39, 121);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(168, 26);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "Customer Name:";
            // 
            // lblWaitingNumber
            // 
            this.lblWaitingNumber.AutoSize = true;
            this.lblWaitingNumber.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitingNumber.Location = new System.Drawing.Point(37, 83);
            this.lblWaitingNumber.Name = "lblWaitingNumber";
            this.lblWaitingNumber.Size = new System.Drawing.Size(122, 26);
            this.lblWaitingNumber.TabIndex = 3;
            this.lblWaitingNumber.Text = "Waiting No:";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderID.Location = new System.Drawing.Point(39, 44);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(103, 26);
            this.lblOrderID.TabIndex = 2;
            this.lblOrderID.Text = "Order ID:";
            // 
            // separator1
            // 
            this.separator1.LineColor = System.Drawing.Color.Gray;
            this.separator1.Location = new System.Drawing.Point(-12, 47);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(700, 10);
            this.separator1.TabIndex = 2;
            this.separator1.Text = "separator1";
            // 
            // separator2
            // 
            this.separator2.LineColor = System.Drawing.Color.Gray;
            this.separator2.Location = new System.Drawing.Point(-12, 337);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(700, 10);
            this.separator2.TabIndex = 3;
            this.separator2.Text = "separator2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ordered Items";
            // 
            // separator3
            // 
            this.separator3.LineColor = System.Drawing.Color.Gray;
            this.separator3.Location = new System.Drawing.Point(-12, 579);
            this.separator3.Name = "separator3";
            this.separator3.Size = new System.Drawing.Size(700, 10);
            this.separator3.TabIndex = 9;
            this.separator3.Text = "separator3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 618);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total Amount:";
            // 
            // btnGenerateInvoice
            // 
            this.btnGenerateInvoice.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnGenerateInvoice.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnGenerateInvoice.ButtonImage")));
            this.btnGenerateInvoice.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.btnGenerateInvoice.ButtonText = "Generate Invoice PDF";
            this.btnGenerateInvoice.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnGenerateInvoice.ClickTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenerateInvoice.CornerRadius = 5;
            this.btnGenerateInvoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateInvoice.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnGenerateInvoice.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnGenerateInvoice.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenerateInvoice.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.btnGenerateInvoice.Location = new System.Drawing.Point(53, 665);
            this.btnGenerateInvoice.Name = "btnGenerateInvoice";
            this.btnGenerateInvoice.Size = new System.Drawing.Size(200, 50);
            this.btnGenerateInvoice.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnGenerateInvoice.TabIndex = 13;
            this.btnGenerateInvoice.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenerateInvoice.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnGenerateInvoice.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnGenerateInvoice.Click += new System.EventHandler(this.btnGenerateInvoice_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 592);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 26);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total Items :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Status:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(39, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 26);
            this.label8.TabIndex = 7;
            this.label8.Text = "Order Date:";
            // 
            // lblOrderIDValue
            // 
            this.lblOrderIDValue.AutoSize = true;
            this.lblOrderIDValue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderIDValue.Location = new System.Drawing.Point(239, 44);
            this.lblOrderIDValue.Name = "lblOrderIDValue";
            this.lblOrderIDValue.Size = new System.Drawing.Size(56, 26);
            this.lblOrderIDValue.TabIndex = 8;
            this.lblOrderIDValue.Text = "1001";
            // 
            // lblWaitingNoValue
            // 
            this.lblWaitingNoValue.AutoSize = true;
            this.lblWaitingNoValue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitingNoValue.Location = new System.Drawing.Point(239, 83);
            this.lblWaitingNoValue.Name = "lblWaitingNoValue";
            this.lblWaitingNoValue.Size = new System.Drawing.Size(45, 26);
            this.lblWaitingNoValue.TabIndex = 9;
            this.lblWaitingNoValue.Text = "501";
            // 
            // lblCustomerNameValue
            // 
            this.lblCustomerNameValue.AutoSize = true;
            this.lblCustomerNameValue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerNameValue.Location = new System.Drawing.Point(239, 121);
            this.lblCustomerNameValue.Name = "lblCustomerNameValue";
            this.lblCustomerNameValue.Size = new System.Drawing.Size(114, 26);
            this.lblCustomerNameValue.TabIndex = 10;
            this.lblCustomerNameValue.Text = "John Weak";
            // 
            // lblStaffNameValue
            // 
            this.lblStaffNameValue.AutoSize = true;
            this.lblStaffNameValue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffNameValue.Location = new System.Drawing.Point(239, 162);
            this.lblStaffNameValue.Name = "lblStaffNameValue";
            this.lblStaffNameValue.Size = new System.Drawing.Size(152, 26);
            this.lblStaffNameValue.TabIndex = 11;
            this.lblStaffNameValue.Text = "Lay Kimhoung";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusValue.Location = new System.Drawing.Point(239, 201);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(113, 26);
            this.lblStatusValue.TabIndex = 12;
            this.lblStatusValue.Text = "Completed";
            // 
            // lblOrderDateValue
            // 
            this.lblOrderDateValue.AutoSize = true;
            this.lblOrderDateValue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDateValue.Location = new System.Drawing.Point(239, 243);
            this.lblOrderDateValue.Name = "lblOrderDateValue";
            this.lblOrderDateValue.Size = new System.Drawing.Size(206, 26);
            this.lblOrderDateValue.TabIndex = 13;
            this.lblOrderDateValue.Text = "22/06/2026 09:15 PM\n";
            // 
            // dgvOrderItems
            // 
            this.dgvOrderItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderItems.Location = new System.Drawing.Point(53, 378);
            this.dgvOrderItems.Name = "dgvOrderItems";
            this.dgvOrderItems.RowHeadersWidth = 51;
            this.dgvOrderItems.RowTemplate.Height = 24;
            this.dgvOrderItems.Size = new System.Drawing.Size(575, 195);
            this.dgvOrderItems.TabIndex = 15;
            // 
            // lblTotalItemsValue
            // 
            this.lblTotalItemsValue.AutoSize = true;
            this.lblTotalItemsValue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItemsValue.Location = new System.Drawing.Point(182, 592);
            this.lblTotalItemsValue.Name = "lblTotalItemsValue";
            this.lblTotalItemsValue.Size = new System.Drawing.Size(29, 26);
            this.lblTotalItemsValue.TabIndex = 16;
            this.lblTotalItemsValue.Text = " 3";
            // 
            // lblTotalAmountValue
            // 
            this.lblTotalAmountValue.AutoSize = true;
            this.lblTotalAmountValue.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountValue.Location = new System.Drawing.Point(202, 618);
            this.lblTotalAmountValue.Name = "lblTotalAmountValue";
            this.lblTotalAmountValue.Size = new System.Drawing.Size(62, 26);
            this.lblTotalAmountValue.TabIndex = 17;
            this.lblTotalAmountValue.Text = "$8.00";
            // 
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(678, 739);
            this.Controls.Add(this.lblTotalAmountValue);
            this.Controls.Add(this.lblTotalItemsValue);
            this.Controls.Add(this.dgvOrderItems);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnGenerateInvoice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.separator3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.separator2);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.grpOrderInfo);
            this.Controls.Add(this.lblTitle);
            this.Name = "OrderDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderDetailsForm";
            this.Load += new System.EventHandler(this.OrderDetailsForm_Load);
            this.grpOrderInfo.ResumeLayout(false);
            this.grpOrderInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpOrderInfo;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblWaitingNumber;
        private System.Windows.Forms.Label lblOrderID;
        private ReaLTaiizor.Controls.Separator separator1;
        private ReaLTaiizor.Controls.Separator separator2;
        private System.Windows.Forms.Label label1;
        private ReaLTaiizor.Controls.Separator separator3;
        private System.Windows.Forms.Label label5;
        private ReaLTaiizor.Controls.ParrotButton btnGenerateInvoice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOrderDateValue;
        private System.Windows.Forms.Label lblStatusValue;
        private System.Windows.Forms.Label lblStaffNameValue;
        private System.Windows.Forms.Label lblCustomerNameValue;
        private System.Windows.Forms.Label lblWaitingNoValue;
        private System.Windows.Forms.Label lblOrderIDValue;
        private System.Windows.Forms.DataGridView dgvOrderItems;
        private System.Windows.Forms.Label lblTotalItemsValue;
        private System.Windows.Forms.Label lblTotalAmountValue;
    }
}