namespace SmartOrderManagementSystem.Forms.Admin
{
    partial class AdminHomeForm
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
            this.cyberButton1 = new ReaLTaiizor.Controls.CyberButton();
            this.SuspendLayout();
            // 
            // cyberButton1
            // 
            this.cyberButton1.Alpha = 20;
            this.cyberButton1.BackColor = System.Drawing.Color.Transparent;
            this.cyberButton1.Background = true;
            this.cyberButton1.Background_WidthPen = 4F;
            this.cyberButton1.BackgroundPen = true;
            this.cyberButton1.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberButton1.ColorBackground_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberButton1.ColorBackground_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.cyberButton1.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberButton1.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberButton1.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberButton1.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.cyberButton1.CyberButtonStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cyberButton1.Effect_1 = true;
            this.cyberButton1.Effect_1_ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberButton1.Effect_1_Transparency = 25;
            this.cyberButton1.Effect_2 = true;
            this.cyberButton1.Effect_2_ColorBackground = System.Drawing.Color.White;
            this.cyberButton1.Effect_2_Transparency = 20;
            this.cyberButton1.Font = new System.Drawing.Font("Arial", 11F);
            this.cyberButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cyberButton1.Lighting = false;
            this.cyberButton1.LinearGradient_Background = false;
            this.cyberButton1.LinearGradientPen = false;
            this.cyberButton1.Location = new System.Drawing.Point(12, 12);
            this.cyberButton1.Name = "cyberButton1";
            this.cyberButton1.PenWidth = 15;
            this.cyberButton1.Rounding = true;
            this.cyberButton1.RoundingInt = 70;
            this.cyberButton1.Size = new System.Drawing.Size(210, 50);
            this.cyberButton1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.cyberButton1.TabIndex = 0;
            this.cyberButton1.Tag = "Cyber";
            this.cyberButton1.TextButton = "Home";
            this.cyberButton1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.cyberButton1.Timer_Effect_1 = 5;
            this.cyberButton1.Timer_RGB = 300;
            // 
            // AdminHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1332, 732);
            this.Controls.Add(this.cyberButton1);
            this.Name = "AdminHomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminHomeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ReaLTaiizor.Controls.CyberButton cyberButton1;
    }
}