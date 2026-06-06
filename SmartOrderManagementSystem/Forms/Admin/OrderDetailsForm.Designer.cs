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
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblWaitingNumber = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.separator1 = new ReaLTaiizor.Controls.Separator();
            this.separator2 = new ReaLTaiizor.Controls.Separator();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.separator3 = new ReaLTaiizor.Controls.Separator();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerateInvoice = new ReaLTaiizor.Controls.ParrotButton();
            this.grpOrderInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(48, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Order Details";
            // 
            // grpOrderInfo
            // 
            this.grpOrderInfo.Controls.Add(this.lblOrderDate);
            this.grpOrderInfo.Controls.Add(this.lblCustomerName);
            this.grpOrderInfo.Controls.Add(this.lblWaitingNumber);
            this.grpOrderInfo.Controls.Add(this.lblOrderID);
            this.grpOrderInfo.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOrderInfo.Location = new System.Drawing.Point(54, 86);
            this.grpOrderInfo.Name = "grpOrderInfo";
            this.grpOrderInfo.Size = new System.Drawing.Size(560, 216);
            this.grpOrderInfo.TabIndex = 1;
            this.grpOrderInfo.TabStop = false;
            this.grpOrderInfo.Text = "Order Information";
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
            // lblWaitingNumber
            // 
            this.lblWaitingNumber.AutoSize = true;
            this.lblWaitingNumber.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWaitingNumber.Location = new System.Drawing.Point(37, 83);
            this.lblWaitingNumber.Name = "lblWaitingNumber";
            this.lblWaitingNumber.Size = new System.Drawing.Size(170, 26);
            this.lblWaitingNumber.TabIndex = 3;
            this.lblWaitingNumber.Text = "Waiting Number:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(39, 124);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(168, 26);
            this.lblCustomerName.TabIndex = 4;
            this.lblCustomerName.Text = "Customer Name:";
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(39, 167);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(121, 26);
            this.lblOrderDate.TabIndex = 5;
            this.lblOrderDate.Text = "Order Date:";
            // 
            // separator1
            // 
            this.separator1.LineColor = System.Drawing.Color.Gray;
            this.separator1.Location = new System.Drawing.Point(-12, 61);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(700, 10);
            this.separator1.TabIndex = 2;
            this.separator1.Text = "separator1";
            // 
            // separator2
            // 
            this.separator2.LineColor = System.Drawing.Color.Gray;
            this.separator2.Location = new System.Drawing.Point(-12, 308);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(700, 10);
            this.separator2.TabIndex = 3;
            this.separator2.Text = "separator2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Items:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Latte x2 = $6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 467);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Espresso x1 = $3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(93, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 26);
            this.label4.TabIndex = 8;
            this.label4.Text = "Coke x1 = $2";
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
            this.label5.Location = new System.Drawing.Point(49, 592);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total Amount: $8.00";
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
            this.btnGenerateInvoice.Location = new System.Drawing.Point(61, 643);
            this.btnGenerateInvoice.Name = "btnGenerateInvoice";
            this.btnGenerateInvoice.Size = new System.Drawing.Size(200, 50);
            this.btnGenerateInvoice.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnGenerateInvoice.TabIndex = 13;
            this.btnGenerateInvoice.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGenerateInvoice.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnGenerateInvoice.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            // 
            // OrderDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(678, 717);
            this.Controls.Add(this.btnGenerateInvoice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.separator3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.separator2);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.grpOrderInfo);
            this.Controls.Add(this.lblTitle);
            this.Name = "OrderDetailsForm";
            this.Text = "OrderDetailsForm";
            this.grpOrderInfo.ResumeLayout(false);
            this.grpOrderInfo.PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ReaLTaiizor.Controls.Separator separator3;
        private System.Windows.Forms.Label label5;
        private ReaLTaiizor.Controls.ParrotButton btnGenerateInvoice;
    }
}