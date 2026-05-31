namespace SmartOrderManagementSystem.Forms.Staff
{
    partial class CustomerRecordForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.Customer_datagrideview = new System.Windows.Forms.DataGridView();
            this.panel1 = new ReaLTaiizor.Controls.Panel();
            this.filter_btn = new ReaLTaiizor.Controls.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.To_date = new System.Windows.Forms.DateTimePicker();
            this.From_date = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.Search_txt = new ReaLTaiizor.Controls.DungeonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_datagrideview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Romnea", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 55);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Record";
            // 
            // Customer_datagrideview
            // 
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Customer_datagrideview.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.Customer_datagrideview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Customer_datagrideview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Customer_datagrideview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(64)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(64)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Customer_datagrideview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.Customer_datagrideview.ColumnHeadersHeight = 40;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.NullValue = null;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Customer_datagrideview.DefaultCellStyle = dataGridViewCellStyle15;
            this.Customer_datagrideview.EnableHeadersVisualStyles = false;
            this.Customer_datagrideview.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.Customer_datagrideview.Location = new System.Drawing.Point(9, 186);
            this.Customer_datagrideview.Name = "Customer_datagrideview";
            this.Customer_datagrideview.RowHeadersVisible = false;
            this.Customer_datagrideview.RowHeadersWidth = 51;
            this.Customer_datagrideview.RowTemplate.Height = 35;
            this.Customer_datagrideview.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Customer_datagrideview.Size = new System.Drawing.Size(1276, 565);
            this.Customer_datagrideview.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(64)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.filter_btn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.To_date);
            this.panel1.Controls.Add(this.From_date);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Search_txt);
            this.panel1.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(9, 119);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1276, 61);
            this.panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panel1.TabIndex = 8;
            this.panel1.Text = "panel1";
            // 
            // filter_btn
            // 
            this.filter_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(64)))), ((int)(((byte)(79)))));
            this.filter_btn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.filter_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filter_btn.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.filter_btn.EnteredColor = System.Drawing.Color.White;
            this.filter_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.filter_btn.Image = null;
            this.filter_btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.filter_btn.InactiveColor = System.Drawing.Color.IndianRed;
            this.filter_btn.Location = new System.Drawing.Point(960, 17);
            this.filter_btn.Name = "filter_btn";
            this.filter_btn.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.filter_btn.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.filter_btn.Size = new System.Drawing.Size(105, 39);
            this.filter_btn.TabIndex = 13;
            this.filter_btn.Text = "Filter";
            this.filter_btn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.filter_btn.Click += new System.EventHandler(this.filter_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(685, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "To :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(434, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "From :";
            // 
            // To_date
            // 
            this.To_date.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.To_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.To_date.Location = new System.Drawing.Point(742, 17);
            this.To_date.Name = "To_date";
            this.To_date.Size = new System.Drawing.Size(157, 30);
            this.To_date.TabIndex = 10;
            // 
            // From_date
            // 
            this.From_date.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.From_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.From_date.Location = new System.Drawing.Point(522, 17);
            this.From_date.Name = "From_date";
            this.From_date.Size = new System.Drawing.Size(157, 30);
            this.From_date.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(7, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search :";
            // 
            // Search_txt
            // 
            this.Search_txt.BackColor = System.Drawing.Color.Transparent;
            this.Search_txt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.Search_txt.EdgeColor = System.Drawing.Color.White;
            this.Search_txt.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Search_txt.ForeColor = System.Drawing.Color.Black;
            this.Search_txt.Location = new System.Drawing.Point(109, 17);
            this.Search_txt.MaxLength = 32767;
            this.Search_txt.Multiline = false;
            this.Search_txt.Name = "Search_txt";
            this.Search_txt.ReadOnly = false;
            this.Search_txt.Size = new System.Drawing.Size(296, 33);
            this.Search_txt.TabIndex = 6;
            this.Search_txt.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.Search_txt.UseSystemPasswordChar = false;
            this.Search_txt.TextChanged += new System.EventHandler(this.Search_txt_TextChanged);
            // 
            // CustomerRecordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1300, 763);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Customer_datagrideview);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CustomerRecordForm";
            this.Text = "CustomerRecordForm";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.CustomerRecordForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Customer_datagrideview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Customer_datagrideview;
        private ReaLTaiizor.Controls.Panel panel1;
        private ReaLTaiizor.Controls.Button filter_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker To_date;
        private System.Windows.Forms.DateTimePicker From_date;
        private System.Windows.Forms.Label label2;
        private ReaLTaiizor.Controls.DungeonTextBox Search_txt;
    }
}