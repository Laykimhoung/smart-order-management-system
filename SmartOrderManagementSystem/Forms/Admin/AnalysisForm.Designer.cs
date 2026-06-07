namespace SmartOrderManagementSystem.Forms.Admin
{
    partial class AnalysisForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPeriod = new ReaLTaiizor.Controls.DungeonComboBox();
            this.btnApply = new ReaLTaiizor.Controls.CyberButton();
            this.panelOrders = new System.Windows.Forms.Panel();
            this.panelRevenue = new System.Windows.Forms.Panel();
            this.panelCustomers = new System.Windows.Forms.Panel();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grpRevenueTrend = new System.Windows.Forms.GroupBox();
            this.chartRevenueTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpTopSelling = new System.Windows.Forms.GroupBox();
            this.grpLeastSelling = new System.Windows.Forms.GroupBox();
            this.panelOrders.SuspendLayout();
            this.panelRevenue.SuspendLayout();
            this.panelCustomers.SuspendLayout();
            this.panelProducts.SuspendLayout();
            this.grpRevenueTrend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueTrend)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Analysis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(51, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Business Performance Overview  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(50, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Period";
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.cmbPeriod.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(132)))), ((int)(((byte)(85)))));
            this.cmbPeriod.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(108)))), ((int)(((byte)(57)))));
            this.cmbPeriod.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.cmbPeriod.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.cmbPeriod.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(237)))), ((int)(((byte)(236)))));
            this.cmbPeriod.ColorF = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.cmbPeriod.ColorG = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(118)))));
            this.cmbPeriod.ColorH = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(222)))), ((int)(((byte)(220)))));
            this.cmbPeriod.ColorI = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(249)))));
            this.cmbPeriod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPeriod.DropDownHeight = 100;
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(97)))));
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.HoverSelectionColor = System.Drawing.Color.Empty;
            this.cmbPeriod.IntegralHeight = false;
            this.cmbPeriod.ItemHeight = 20;
            this.cmbPeriod.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly",
            "Yearly"});
            this.cmbPeriod.Location = new System.Drawing.Point(161, 128);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(167, 26);
            this.cmbPeriod.StartIndex = 0;
            this.cmbPeriod.TabIndex = 3;
            // 
            // btnApply
            // 
            this.btnApply.Alpha = 20;
            this.btnApply.BackColor = System.Drawing.Color.Transparent;
            this.btnApply.Background = true;
            this.btnApply.Background_WidthPen = 4F;
            this.btnApply.BackgroundPen = true;
            this.btnApply.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnApply.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnApply.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnApply.ColorBackground_Pen = System.Drawing.Color.Red;
            this.btnApply.ColorLighting = System.Drawing.Color.Red;
            this.btnApply.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnApply.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnApply.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnApply.Effect_1 = true;
            this.btnApply.Effect_1_ColorBackground = System.Drawing.Color.Red;
            this.btnApply.Effect_1_Transparency = 25;
            this.btnApply.Effect_2 = true;
            this.btnApply.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnApply.Effect_2_Transparency = 20;
            this.btnApply.Font = new System.Drawing.Font("Arial", 11F);
            this.btnApply.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnApply.Lighting = false;
            this.btnApply.LinearGradient_Background = false;
            this.btnApply.LinearGradientPen = false;
            this.btnApply.Location = new System.Drawing.Point(419, 109);
            this.btnApply.Name = "btnApply";
            this.btnApply.PenWidth = 15;
            this.btnApply.Rounding = true;
            this.btnApply.RoundingInt = 70;
            this.btnApply.Size = new System.Drawing.Size(203, 45);
            this.btnApply.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnApply.TabIndex = 4;
            this.btnApply.Tag = "Cyber";
            this.btnApply.TextButton = "Apply";
            this.btnApply.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnApply.Timer_Effect_1 = 5;
            this.btnApply.Timer_RGB = 300;
            // 
            // panelOrders
            // 
            this.panelOrders.AccessibleDescription = "";
            this.panelOrders.BackColor = System.Drawing.Color.MistyRose;
            this.panelOrders.Controls.Add(this.label8);
            this.panelOrders.Controls.Add(this.label4);
            this.panelOrders.Location = new System.Drawing.Point(53, 166);
            this.panelOrders.Name = "panelOrders";
            this.panelOrders.Size = new System.Drawing.Size(250, 95);
            this.panelOrders.TabIndex = 5;
            // 
            // panelRevenue
            // 
            this.panelRevenue.AccessibleDescription = "";
            this.panelRevenue.BackColor = System.Drawing.Color.MistyRose;
            this.panelRevenue.Controls.Add(this.label9);
            this.panelRevenue.Controls.Add(this.label5);
            this.panelRevenue.Location = new System.Drawing.Point(372, 166);
            this.panelRevenue.Name = "panelRevenue";
            this.panelRevenue.Size = new System.Drawing.Size(250, 95);
            this.panelRevenue.TabIndex = 6;
            // 
            // panelCustomers
            // 
            this.panelCustomers.AccessibleDescription = "";
            this.panelCustomers.BackColor = System.Drawing.Color.MistyRose;
            this.panelCustomers.Controls.Add(this.label10);
            this.panelCustomers.Controls.Add(this.label6);
            this.panelCustomers.Location = new System.Drawing.Point(682, 166);
            this.panelCustomers.Name = "panelCustomers";
            this.panelCustomers.Size = new System.Drawing.Size(250, 95);
            this.panelCustomers.TabIndex = 6;
            // 
            // panelProducts
            // 
            this.panelProducts.AccessibleDescription = "";
            this.panelProducts.BackColor = System.Drawing.Color.MistyRose;
            this.panelProducts.Controls.Add(this.label11);
            this.panelProducts.Controls.Add(this.label7);
            this.panelProducts.Location = new System.Drawing.Point(995, 166);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(250, 95);
            this.panelProducts.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(63, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Orders";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(59, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Revenue";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(52, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total Customers";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(65, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 23);
            this.label7.TabIndex = 3;
            this.label7.Text = "Total Products";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(91, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 38);
            this.label8.TabIndex = 1;
            this.label8.Text = "67";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.Location = new System.Drawing.Point(80, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 38);
            this.label9.TabIndex = 2;
            this.label9.Text = "$1,250";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(105, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 38);
            this.label10.TabIndex = 3;
            this.label10.Text = "67";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.Location = new System.Drawing.Point(118, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 38);
            this.label11.TabIndex = 4;
            this.label11.Text = "67";
            // 
            // grpRevenueTrend
            // 
            this.grpRevenueTrend.Controls.Add(this.chartRevenueTrend);
            this.grpRevenueTrend.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRevenueTrend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grpRevenueTrend.Location = new System.Drawing.Point(55, 278);
            this.grpRevenueTrend.Name = "grpRevenueTrend";
            this.grpRevenueTrend.Size = new System.Drawing.Size(1190, 218);
            this.grpRevenueTrend.TabIndex = 7;
            this.grpRevenueTrend.TabStop = false;
            this.grpRevenueTrend.Text = "Revenue Trend";
            // 
            // chartRevenueTrend
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRevenueTrend.ChartAreas.Add(chartArea1);
            this.chartRevenueTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartRevenueTrend.Legends.Add(legend1);
            this.chartRevenueTrend.Location = new System.Drawing.Point(3, 23);
            this.chartRevenueTrend.Name = "chartRevenueTrend";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 6;
            this.chartRevenueTrend.Series.Add(series1);
            this.chartRevenueTrend.Size = new System.Drawing.Size(1184, 192);
            this.chartRevenueTrend.TabIndex = 0;
            this.chartRevenueTrend.Text = "chart1";
            // 
            // grpTopSelling
            // 
            this.grpTopSelling.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.grpTopSelling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.grpTopSelling.Location = new System.Drawing.Point(58, 502);
            this.grpTopSelling.Name = "grpTopSelling";
            this.grpTopSelling.Size = new System.Drawing.Size(580, 224);
            this.grpTopSelling.TabIndex = 8;
            this.grpTopSelling.TabStop = false;
            this.grpTopSelling.Text = "Top Selling Products";
            // 
            // grpLeastSelling
            // 
            this.grpLeastSelling.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.grpLeastSelling.ForeColor = System.Drawing.Color.Red;
            this.grpLeastSelling.Location = new System.Drawing.Point(662, 502);
            this.grpLeastSelling.Name = "grpLeastSelling";
            this.grpLeastSelling.Size = new System.Drawing.Size(580, 224);
            this.grpLeastSelling.TabIndex = 9;
            this.grpLeastSelling.TabStop = false;
            this.grpLeastSelling.Text = "Least Selling Products";
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 725);
            this.Controls.Add(this.grpLeastSelling);
            this.Controls.Add(this.grpTopSelling);
            this.Controls.Add(this.grpRevenueTrend);
            this.Controls.Add(this.panelProducts);
            this.Controls.Add(this.panelCustomers);
            this.Controls.Add(this.panelRevenue);
            this.Controls.Add(this.panelOrders);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.cmbPeriod);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AnalysisForm";
            this.Text = "AnalysisForm";
            this.panelOrders.ResumeLayout(false);
            this.panelOrders.PerformLayout();
            this.panelRevenue.ResumeLayout(false);
            this.panelRevenue.PerformLayout();
            this.panelCustomers.ResumeLayout(false);
            this.panelCustomers.PerformLayout();
            this.panelProducts.ResumeLayout(false);
            this.panelProducts.PerformLayout();
            this.grpRevenueTrend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenueTrend)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private ReaLTaiizor.Controls.DungeonComboBox cmbPeriod;
        private ReaLTaiizor.Controls.CyberButton btnApply;
        private System.Windows.Forms.Panel panelOrders;
        private System.Windows.Forms.Panel panelRevenue;
        private System.Windows.Forms.Panel panelCustomers;
        private System.Windows.Forms.Panel panelProducts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpRevenueTrend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenueTrend;
        private System.Windows.Forms.GroupBox grpTopSelling;
        private System.Windows.Forms.GroupBox grpLeastSelling;
    }
}