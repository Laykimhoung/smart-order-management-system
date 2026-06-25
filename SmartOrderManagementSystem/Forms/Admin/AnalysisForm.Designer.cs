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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPeriod = new ReaLTaiizor.Controls.DungeonComboBox();
            this.btnApply = new ReaLTaiizor.Controls.CyberButton();
            this.panelOrders = new System.Windows.Forms.Panel();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelRevenue = new System.Windows.Forms.Panel();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelCustomers = new System.Windows.Forms.Panel();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelProducts = new System.Windows.Forms.Panel();
            this.lblProducts = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.grpRevenueTrend = new System.Windows.Forms.GroupBox();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpTopSelling = new System.Windows.Forms.GroupBox();
            this.chartTopProducts = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpLeastSelling = new System.Windows.Forms.GroupBox();
            this.chartLeastProducts = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timerChart = new System.Windows.Forms.Timer(this.components);
            this.panelOrders.SuspendLayout();
            this.panelRevenue.SuspendLayout();
            this.panelCustomers.SuspendLayout();
            this.panelProducts.SuspendLayout();
            this.grpRevenueTrend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.grpTopSelling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProducts)).BeginInit();
            this.grpLeastSelling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLeastProducts)).BeginInit();
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
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // panelOrders
            // 
            this.panelOrders.AccessibleDescription = "";
            this.panelOrders.BackColor = System.Drawing.Color.Crimson;
            this.panelOrders.Controls.Add(this.lblTotalOrders);
            this.panelOrders.Controls.Add(this.label4);
            this.panelOrders.Location = new System.Drawing.Point(53, 166);
            this.panelOrders.Name = "panelOrders";
            this.panelOrders.Size = new System.Drawing.Size(250, 95);
            this.panelOrders.TabIndex = 5;
            // 
            // lblTotalOrders
            // 
            this.lblTotalOrders.AutoSize = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOrders.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTotalOrders.Location = new System.Drawing.Point(69, 46);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(51, 37);
            this.lblTotalOrders.TabIndex = 1;
            this.lblTotalOrders.Text = "67";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(63, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Total Orders";
            // 
            // panelRevenue
            // 
            this.panelRevenue.AccessibleDescription = "";
            this.panelRevenue.BackColor = System.Drawing.Color.Crimson;
            this.panelRevenue.Controls.Add(this.lblRevenue);
            this.panelRevenue.Controls.Add(this.label5);
            this.panelRevenue.Location = new System.Drawing.Point(372, 166);
            this.panelRevenue.Name = "panelRevenue";
            this.panelRevenue.Size = new System.Drawing.Size(250, 95);
            this.panelRevenue.TabIndex = 6;
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevenue.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRevenue.Location = new System.Drawing.Point(40, 46);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(110, 37);
            this.lblRevenue.TabIndex = 2;
            this.lblRevenue.Text = "$1,250";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(59, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Total Revenue";
            // 
            // panelCustomers
            // 
            this.panelCustomers.AccessibleDescription = "";
            this.panelCustomers.BackColor = System.Drawing.Color.Crimson;
            this.panelCustomers.Controls.Add(this.lblCustomers);
            this.panelCustomers.Controls.Add(this.label6);
            this.panelCustomers.Location = new System.Drawing.Point(682, 166);
            this.panelCustomers.Name = "panelCustomers";
            this.panelCustomers.Size = new System.Drawing.Size(250, 95);
            this.panelCustomers.TabIndex = 6;
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCustomers.Location = new System.Drawing.Point(88, 46);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(51, 37);
            this.lblCustomers.TabIndex = 3;
            this.lblCustomers.Text = "67";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(52, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Total Customers";
            // 
            // panelProducts
            // 
            this.panelProducts.AccessibleDescription = "";
            this.panelProducts.BackColor = System.Drawing.Color.Crimson;
            this.panelProducts.Controls.Add(this.lblProducts);
            this.panelProducts.Controls.Add(this.label7);
            this.panelProducts.Location = new System.Drawing.Point(995, 166);
            this.panelProducts.Name = "panelProducts";
            this.panelProducts.Size = new System.Drawing.Size(250, 95);
            this.panelProducts.TabIndex = 6;
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblProducts.Location = new System.Drawing.Point(102, 46);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(51, 37);
            this.lblProducts.TabIndex = 4;
            this.lblProducts.Text = "67";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(65, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 23);
            this.label7.TabIndex = 3;
            this.label7.Text = "Total Products";
            // 
            // grpRevenueTrend
            // 
            this.grpRevenueTrend.Controls.Add(this.chartRevenue);
            this.grpRevenueTrend.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRevenueTrend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grpRevenueTrend.Location = new System.Drawing.Point(55, 267);
            this.grpRevenueTrend.Name = "grpRevenueTrend";
            this.grpRevenueTrend.Size = new System.Drawing.Size(1190, 229);
            this.grpRevenueTrend.TabIndex = 7;
            this.grpRevenueTrend.TabStop = false;
            this.grpRevenueTrend.Text = "Revenue Trend";
            // 
            // chartRevenue
            // 
            chartArea7.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea7);
            this.chartRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend7);
            this.chartRevenue.Location = new System.Drawing.Point(3, 23);
            this.chartRevenue.Name = "chartRevenue";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            series7.YValuesPerPoint = 6;
            this.chartRevenue.Series.Add(series7);
            this.chartRevenue.Size = new System.Drawing.Size(1184, 203);
            this.chartRevenue.TabIndex = 0;
            this.chartRevenue.Text = "chart1";
            // 
            // grpTopSelling
            // 
            this.grpTopSelling.Controls.Add(this.chartTopProducts);
            this.grpTopSelling.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.grpTopSelling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.grpTopSelling.Location = new System.Drawing.Point(58, 502);
            this.grpTopSelling.Name = "grpTopSelling";
            this.grpTopSelling.Size = new System.Drawing.Size(580, 260);
            this.grpTopSelling.TabIndex = 8;
            this.grpTopSelling.TabStop = false;
            this.grpTopSelling.Text = "Top Selling Products";
            // 
            // chartTopProducts
            // 
            chartArea8.Name = "ChartArea1";
            this.chartTopProducts.ChartAreas.Add(chartArea8);
            this.chartTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            legend8.Name = "Legend1";
            this.chartTopProducts.Legends.Add(legend8);
            this.chartTopProducts.Location = new System.Drawing.Point(3, 23);
            this.chartTopProducts.Name = "chartTopProducts";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartTopProducts.Series.Add(series8);
            this.chartTopProducts.Size = new System.Drawing.Size(574, 234);
            this.chartTopProducts.TabIndex = 0;
            this.chartTopProducts.Text = "chart1";
            // 
            // grpLeastSelling
            // 
            this.grpLeastSelling.Controls.Add(this.chartLeastProducts);
            this.grpLeastSelling.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold);
            this.grpLeastSelling.ForeColor = System.Drawing.Color.Red;
            this.grpLeastSelling.Location = new System.Drawing.Point(662, 502);
            this.grpLeastSelling.Name = "grpLeastSelling";
            this.grpLeastSelling.Size = new System.Drawing.Size(580, 257);
            this.grpLeastSelling.TabIndex = 9;
            this.grpLeastSelling.TabStop = false;
            this.grpLeastSelling.Text = "Least Selling Products";
            // 
            // chartLeastProducts
            // 
            chartArea9.Name = "ChartArea1";
            this.chartLeastProducts.ChartAreas.Add(chartArea9);
            this.chartLeastProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            legend9.Name = "Legend1";
            this.chartLeastProducts.Legends.Add(legend9);
            this.chartLeastProducts.Location = new System.Drawing.Point(3, 23);
            this.chartLeastProducts.Name = "chartLeastProducts";
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chartLeastProducts.Series.Add(series9);
            this.chartLeastProducts.Size = new System.Drawing.Size(574, 231);
            this.chartLeastProducts.TabIndex = 0;
            this.chartLeastProducts.Text = "chart1";
            // 
            // timerChart
            // 
            this.timerChart.Interval = 15;
            this.timerChart.Tick += new System.EventHandler(this.timerChart_Tick);
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
            this.Load += new System.EventHandler(this.AnalysisForm_Load);
            this.panelOrders.ResumeLayout(false);
            this.panelOrders.PerformLayout();
            this.panelRevenue.ResumeLayout(false);
            this.panelRevenue.PerformLayout();
            this.panelCustomers.ResumeLayout(false);
            this.panelCustomers.PerformLayout();
            this.panelProducts.ResumeLayout(false);
            this.panelProducts.PerformLayout();
            this.grpRevenueTrend.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.grpTopSelling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProducts)).EndInit();
            this.grpLeastSelling.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLeastProducts)).EndInit();
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
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblRevenue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox grpRevenueTrend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.GroupBox grpTopSelling;
        private System.Windows.Forms.GroupBox grpLeastSelling;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopProducts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLeastProducts;
        private System.Windows.Forms.Timer timerChart;
    }
}