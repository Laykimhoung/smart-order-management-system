namespace SmartOrderManagementSystem.Forms.Admin
{
    partial class AdminDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboard));
            this.AdminForm = new ReaLTaiizor.Forms.ParrotForm();
            this.panelTopbar = new ReaLTaiizor.Controls.ParrotGradientPanel();
            this.lbWelcome = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            this.bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.labelAdmin = new ReaLTaiizor.Controls.BigLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new ReaLTaiizor.Controls.CyberButton();
            this.btnAnalysis = new ReaLTaiizor.Controls.ParrotButton();
            this.btnHistory = new ReaLTaiizor.Controls.ParrotButton();
            this.btnHome = new ReaLTaiizor.Controls.ParrotButton();
            this.btnReport = new ReaLTaiizor.Controls.ParrotButton();
            this.btnUser = new ReaLTaiizor.Controls.ParrotButton();
            this.separator1 = new ReaLTaiizor.Controls.Separator();
            this.separator2 = new ReaLTaiizor.Controls.Separator();
            this.AdminForm.WorkingArea.SuspendLayout();
            this.AdminForm.SuspendLayout();
            this.panelTopbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // AdminForm
            // 
            this.AdminForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.AdminForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminForm.ExitApplication = true;
            this.AdminForm.Font = new System.Drawing.Font("Modern No. 20", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdminForm.FormStyle = ReaLTaiizor.Forms.ParrotForm.Style.MacOS;
            this.AdminForm.Location = new System.Drawing.Point(0, 0);
            this.AdminForm.MacOSForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.AdminForm.MacOSLeftBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.AdminForm.MacOSRightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.AdminForm.MacOSSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.AdminForm.MaterialBackColor = System.Drawing.Color.DodgerBlue;
            this.AdminForm.MaterialForeColor = System.Drawing.Color.White;
            this.AdminForm.Name = "AdminForm";
            this.AdminForm.ShowMaximize = true;
            this.AdminForm.ShowMinimize = true;
            this.AdminForm.Size = new System.Drawing.Size(1600, 900);
            this.AdminForm.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.AdminForm.TabIndex = 0;
            this.AdminForm.TitleText = "Smart Order Management System";
            this.AdminForm.UbuntuForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.AdminForm.UbuntuLeftBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(85)))), ((int)(((byte)(80)))));
            this.AdminForm.UbuntuRightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            // 
            // AdminForm.WorkingArea
            // 
            this.AdminForm.WorkingArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.AdminForm.WorkingArea.Controls.Add(this.panelTopbar);
            this.AdminForm.WorkingArea.Controls.Add(this.panelMain);
            this.AdminForm.WorkingArea.Controls.Add(this.panelSidebar);
            this.AdminForm.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AdminForm.WorkingArea.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AdminForm.WorkingArea.Location = new System.Drawing.Point(0, 39);
            this.AdminForm.WorkingArea.Name = "WorkingArea";
            this.AdminForm.WorkingArea.Size = new System.Drawing.Size(1600, 861);
            this.AdminForm.WorkingArea.TabIndex = 0;
            // 
            // panelTopbar
            // 
            this.panelTopbar.BottomLeft = System.Drawing.Color.Black;
            this.panelTopbar.BottomRight = System.Drawing.Color.Black;
            this.panelTopbar.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.panelTopbar.Controls.Add(this.lbWelcome);
            this.panelTopbar.Controls.Add(this.bigLabel2);
            this.panelTopbar.Controls.Add(this.bigLabel1);
            this.panelTopbar.Controls.Add(this.pictureBox1);
            this.panelTopbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopbar.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.panelTopbar.Location = new System.Drawing.Point(250, 0);
            this.panelTopbar.Name = "panelTopbar";
            this.panelTopbar.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.panelTopbar.PrimerColor = System.Drawing.Color.White;
            this.panelTopbar.Size = new System.Drawing.Size(1350, 83);
            this.panelTopbar.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.panelTopbar.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            this.panelTopbar.TabIndex = 4;
            this.panelTopbar.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.panelTopbar.TopLeft = System.Drawing.Color.Crimson;
            this.panelTopbar.TopRight = System.Drawing.Color.Black;
            // 
            // lbWelcome
            // 
            this.lbWelcome.AutoSize = true;
            this.lbWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lbWelcome.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWelcome.ForeColor = System.Drawing.Color.Gold;
            this.lbWelcome.Location = new System.Drawing.Point(562, 27);
            this.lbWelcome.Name = "lbWelcome";
            this.lbWelcome.Size = new System.Drawing.Size(96, 33);
            this.lbWelcome.TabIndex = 18;
            this.lbWelcome.Text = "Home";
            this.lbWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bigLabel2
            // 
            this.bigLabel2.AutoSize = true;
            this.bigLabel2.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel2.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel2.ForeColor = System.Drawing.Color.White;
            this.bigLabel2.Location = new System.Drawing.Point(1101, 27);
            this.bigLabel2.Name = "bigLabel2";
            this.bigLabel2.Size = new System.Drawing.Size(107, 33);
            this.bigLabel2.TabIndex = 17;
            this.bigLabel2.Text = "Admin";
            // 
            // bigLabel1
            // 
            this.bigLabel1.AutoSize = true;
            this.bigLabel1.BackColor = System.Drawing.Color.Transparent;
            this.bigLabel1.Font = new System.Drawing.Font("Stencil", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bigLabel1.ForeColor = System.Drawing.Color.White;
            this.bigLabel1.Location = new System.Drawing.Point(35, 27);
            this.bigLabel1.Name = "bigLabel1";
            this.bigLabel1.Size = new System.Drawing.Size(288, 33);
            this.bigLabel1.TabIndex = 16;
            this.bigLabel1.Text = "Admin DashBoard";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1214, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMain.Location = new System.Drawing.Point(250, 89);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1350, 772);
            this.panelMain.TabIndex = 3;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.Crimson;
            this.panelSidebar.Controls.Add(this.separator2);
            this.panelSidebar.Controls.Add(this.separator1);
            this.panelSidebar.Controls.Add(this.labelAdmin);
            this.panelSidebar.Controls.Add(this.pictureBox2);
            this.panelSidebar.Controls.Add(this.btnLogOut);
            this.panelSidebar.Controls.Add(this.btnAnalysis);
            this.panelSidebar.Controls.Add(this.btnHistory);
            this.panelSidebar.Controls.Add(this.btnHome);
            this.panelSidebar.Controls.Add(this.btnReport);
            this.panelSidebar.Controls.Add(this.btnUser);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 861);
            this.panelSidebar.TabIndex = 2;
            // 
            // labelAdmin
            // 
            this.labelAdmin.AutoSize = true;
            this.labelAdmin.BackColor = System.Drawing.Color.Transparent;
            this.labelAdmin.Font = new System.Drawing.Font("Stencil", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdmin.ForeColor = System.Drawing.Color.Black;
            this.labelAdmin.Location = new System.Drawing.Point(3, 172);
            this.labelAdmin.Name = "labelAdmin";
            this.labelAdmin.Size = new System.Drawing.Size(217, 42);
            this.labelAdmin.TabIndex = 15;
            this.labelAdmin.Text = "Smart Order\r\nManagement System\r\n";
            this.labelAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(47, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(173, 154);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Alpha = 20;
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.Background = true;
            this.btnLogOut.Background_WidthPen = 4F;
            this.btnLogOut.BackgroundPen = true;
            this.btnLogOut.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLogOut.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLogOut.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnLogOut.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLogOut.ColorLighting = System.Drawing.Color.Yellow;
            this.btnLogOut.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.btnLogOut.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.btnLogOut.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.btnLogOut.Effect_1 = true;
            this.btnLogOut.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.btnLogOut.Effect_1_Transparency = 25;
            this.btnLogOut.Effect_2 = true;
            this.btnLogOut.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.btnLogOut.Effect_2_Transparency = 20;
            this.btnLogOut.Font = new System.Drawing.Font("Arial", 11F);
            this.btnLogOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.btnLogOut.Lighting = false;
            this.btnLogOut.LinearGradient_Background = false;
            this.btnLogOut.LinearGradientPen = false;
            this.btnLogOut.Location = new System.Drawing.Point(24, 776);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.PenWidth = 15;
            this.btnLogOut.RGB = true;
            this.btnLogOut.Rounding = true;
            this.btnLogOut.RoundingInt = 70;
            this.btnLogOut.Size = new System.Drawing.Size(195, 50);
            this.btnLogOut.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnLogOut.TabIndex = 12;
            this.btnLogOut.Tag = "Cyber";
            this.btnLogOut.TextButton = "Log out";
            this.btnLogOut.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnLogOut.Timer_Effect_1 = 5;
            this.btnLogOut.Timer_RGB = 100;
            // 
            // btnAnalysis
            // 
            this.btnAnalysis.BackgroundColor = System.Drawing.Color.Crimson;
            this.btnAnalysis.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnAnalysis.ButtonImage")));
            this.btnAnalysis.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.btnAnalysis.ButtonText = "Analysis";
            this.btnAnalysis.ClickBackColor = System.Drawing.Color.LimeGreen;
            this.btnAnalysis.ClickTextColor = System.Drawing.Color.White;
            this.btnAnalysis.CornerRadius = 10;
            this.btnAnalysis.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnalysis.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalysis.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAnalysis.HoverBackgroundColor = System.Drawing.Color.Gold;
            this.btnAnalysis.HoverTextColor = System.Drawing.Color.Black;
            this.btnAnalysis.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.btnAnalysis.Location = new System.Drawing.Point(12, 596);
            this.btnAnalysis.Name = "btnAnalysis";
            this.btnAnalysis.Size = new System.Drawing.Size(225, 48);
            this.btnAnalysis.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnAnalysis.TabIndex = 10;
            this.btnAnalysis.TextColor = System.Drawing.Color.Black;
            this.btnAnalysis.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnAnalysis.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAnalysis.Click += new System.EventHandler(this.btnAnalysis_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackgroundColor = System.Drawing.Color.Crimson;
            this.btnHistory.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnHistory.ButtonImage")));
            this.btnHistory.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.btnHistory.ButtonText = "Order History";
            this.btnHistory.ClickBackColor = System.Drawing.Color.LimeGreen;
            this.btnHistory.ClickTextColor = System.Drawing.Color.White;
            this.btnHistory.CornerRadius = 15;
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnHistory.HoverBackgroundColor = System.Drawing.Color.Gold;
            this.btnHistory.HoverTextColor = System.Drawing.Color.Black;
            this.btnHistory.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.btnHistory.Location = new System.Drawing.Point(12, 504);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(225, 48);
            this.btnHistory.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnHistory.TabIndex = 10;
            this.btnHistory.TextColor = System.Drawing.Color.Black;
            this.btnHistory.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnHistory.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackgroundColor = System.Drawing.Color.Crimson;
            this.btnHome.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnHome.ButtonImage")));
            this.btnHome.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.btnHome.ButtonText = "Home";
            this.btnHome.ClickBackColor = System.Drawing.Color.LimeGreen;
            this.btnHome.ClickTextColor = System.Drawing.Color.White;
            this.btnHome.CornerRadius = 15;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnHome.HoverBackgroundColor = System.Drawing.Color.Gold;
            this.btnHome.HoverTextColor = System.Drawing.Color.Black;
            this.btnHome.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.btnHome.Location = new System.Drawing.Point(12, 246);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(225, 48);
            this.btnHome.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnHome.TabIndex = 11;
            this.btnHome.TextColor = System.Drawing.Color.Black;
            this.btnHome.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnHome.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackgroundColor = System.Drawing.Color.Crimson;
            this.btnReport.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnReport.ButtonImage")));
            this.btnReport.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.btnReport.ButtonText = "Reports";
            this.btnReport.ClickBackColor = System.Drawing.Color.LimeGreen;
            this.btnReport.ClickTextColor = System.Drawing.Color.White;
            this.btnReport.CornerRadius = 10;
            this.btnReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReport.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnReport.HoverBackgroundColor = System.Drawing.Color.Gold;
            this.btnReport.HoverTextColor = System.Drawing.Color.Black;
            this.btnReport.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.btnReport.Location = new System.Drawing.Point(12, 416);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(225, 48);
            this.btnReport.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnReport.TabIndex = 10;
            this.btnReport.TextColor = System.Drawing.Color.Black;
            this.btnReport.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnReport.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnUser
            // 
            this.btnUser.BackgroundColor = System.Drawing.Color.Crimson;
            this.btnUser.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnUser.ButtonImage")));
            this.btnUser.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            this.btnUser.ButtonText = "Manage Users";
            this.btnUser.ClickBackColor = System.Drawing.Color.LimeGreen;
            this.btnUser.ClickTextColor = System.Drawing.Color.White;
            this.btnUser.CornerRadius = 15;
            this.btnUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUser.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnUser.HoverBackgroundColor = System.Drawing.Color.Gold;
            this.btnUser.HoverTextColor = System.Drawing.Color.Black;
            this.btnUser.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            this.btnUser.Location = new System.Drawing.Point(12, 331);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(225, 48);
            this.btnUser.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.btnUser.TabIndex = 9;
            this.btnUser.TextColor = System.Drawing.Color.Black;
            this.btnUser.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.btnUser.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // separator1
            // 
            this.separator1.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.separator1.LineColor = System.Drawing.Color.Black;
            this.separator1.Location = new System.Drawing.Point(1, 230);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(251, 10);
            this.separator1.TabIndex = 16;
            this.separator1.Text = "separator1";
            // 
            // separator2
            // 
            this.separator2.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.separator2.LineColor = System.Drawing.Color.Black;
            this.separator2.Location = new System.Drawing.Point(0, 760);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(251, 10);
            this.separator2.TabIndex = 17;
            this.separator2.Text = "separator2";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.AdminForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.AdminDashboard_Load);
            this.AdminForm.WorkingArea.ResumeLayout(false);
            this.AdminForm.ResumeLayout(false);
            this.panelTopbar.ResumeLayout(false);
            this.panelTopbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.ParrotForm AdminForm;
        private System.Windows.Forms.Panel panelSidebar;
        private ReaLTaiizor.Controls.ParrotButton btnUser;
        private ReaLTaiizor.Controls.ParrotButton btnReport;
        private ReaLTaiizor.Controls.ParrotButton btnHome;
        private ReaLTaiizor.Controls.CyberButton btnLogOut;
        private ReaLTaiizor.Controls.ParrotButton btnAnalysis;
        private ReaLTaiizor.Controls.ParrotButton btnHistory;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ReaLTaiizor.Controls.ParrotGradientPanel panelTopbar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ReaLTaiizor.Controls.BigLabel labelAdmin;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private ReaLTaiizor.Controls.BigLabel lbWelcome;
        private ReaLTaiizor.Controls.Separator separator1;
        private ReaLTaiizor.Controls.Separator separator2;
    }
}