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
            this.parrotForm1 = new ReaLTaiizor.Forms.ParrotForm();
            this.panelSidebar = new ReaLTaiizor.Controls.ParrotGradientPanel();
            this.parrotForm1.WorkingArea.SuspendLayout();
            this.parrotForm1.SuspendLayout();
            this.SuspendLayout();
            // 
            // parrotForm1
            // 
            this.parrotForm1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.parrotForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parrotForm1.ExitApplication = true;
            this.parrotForm1.FormStyle = ReaLTaiizor.Forms.ParrotForm.Style.MacOS;
            this.parrotForm1.Location = new System.Drawing.Point(0, 0);
            this.parrotForm1.MacOSForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.parrotForm1.MacOSLeftBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.parrotForm1.MacOSRightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(210)))), ((int)(((byte)(210)))));
            this.parrotForm1.MacOSSeparatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(173)))), ((int)(((byte)(173)))));
            this.parrotForm1.MaterialBackColor = System.Drawing.Color.DodgerBlue;
            this.parrotForm1.MaterialForeColor = System.Drawing.Color.White;
            this.parrotForm1.Name = "parrotForm1";
            this.parrotForm1.ShowMaximize = true;
            this.parrotForm1.ShowMinimize = true;
            this.parrotForm1.Size = new System.Drawing.Size(1600, 900);
            this.parrotForm1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.parrotForm1.TabIndex = 0;
            this.parrotForm1.TitleText = "Smart Order Management System";
            this.parrotForm1.UbuntuForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.parrotForm1.UbuntuLeftBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(85)))), ((int)(((byte)(80)))));
            this.parrotForm1.UbuntuRightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(60)))));
            // 
            // parrotForm1.WorkingArea
            // 
            this.parrotForm1.WorkingArea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(236)))), ((int)(((byte)(236)))));
            this.parrotForm1.WorkingArea.Controls.Add(this.panelSidebar);
            this.parrotForm1.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parrotForm1.WorkingArea.Location = new System.Drawing.Point(0, 39);
            this.parrotForm1.WorkingArea.Name = "WorkingArea";
            this.parrotForm1.WorkingArea.Size = new System.Drawing.Size(1600, 861);
            this.parrotForm1.WorkingArea.TabIndex = 0;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BottomLeft = System.Drawing.Color.Black;
            this.panelSidebar.BottomRight = System.Drawing.Color.Crimson;
            this.panelSidebar.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.panelSidebar.PrimerColor = System.Drawing.Color.White;
            this.panelSidebar.Size = new System.Drawing.Size(200, 861);
            this.panelSidebar.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panelSidebar.Style = ReaLTaiizor.Controls.ParrotGradientPanel.GradientStyle.Corners;
            this.panelSidebar.TabIndex = 1;
            this.panelSidebar.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.panelSidebar.TopLeft = System.Drawing.Color.Black;
            this.panelSidebar.TopRight = System.Drawing.Color.Crimson;
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.parrotForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminDashboard";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.parrotForm1.WorkingArea.ResumeLayout(false);
            this.parrotForm1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Forms.ParrotForm parrotForm1;
        private ReaLTaiizor.Controls.ParrotGradientPanel panelSidebar;
    }
}