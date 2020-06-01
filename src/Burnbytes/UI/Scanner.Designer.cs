namespace Comet.UI
{
    partial class Scanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scanner));
            this.LblIntro = new System.Windows.Forms.Label();
            this.LblCalc = new System.Windows.Forms.Label();
            this.PrgScan = new System.Windows.Forms.ProgressBar();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblScan = new System.Windows.Forms.Label();
            this.LblHandler = new System.Windows.Forms.Label();
            this.PtbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PtbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // LblIntro
            // 
            this.LblIntro.Location = new System.Drawing.Point(47, 11);
            this.LblIntro.Name = "LblIntro";
            this.LblIntro.Size = new System.Drawing.Size(276, 41);
            this.LblIntro.TabIndex = 0;
            this.LblIntro.Text = "Burnbytes is calculating how much space you will be able to free on {0}. This may" +
    " take a few minutes to complete.";
            // 
            // LblCalc
            // 
            this.LblCalc.AutoSize = true;
            this.LblCalc.Location = new System.Drawing.Point(8, 60);
            this.LblCalc.Name = "LblCalc";
            this.LblCalc.Size = new System.Drawing.Size(68, 13);
            this.LblCalc.TabIndex = 1;
            this.LblCalc.Text = "Calculating...";
            // 
            // PrgScan
            // 
            this.PrgScan.Location = new System.Drawing.Point(11, 78);
            this.PrgScan.Name = "PrgScan";
            this.PrgScan.Size = new System.Drawing.Size(227, 13);
            this.PrgScan.TabIndex = 2;
            // 
            // BtnCancel
            // 
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnCancel.Location = new System.Drawing.Point(249, 70);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblScan
            // 
            this.LblScan.AutoSize = true;
            this.LblScan.Location = new System.Drawing.Point(8, 96);
            this.LblScan.Name = "LblScan";
            this.LblScan.Size = new System.Drawing.Size(55, 13);
            this.LblScan.TabIndex = 4;
            this.LblScan.Text = "Scanning:";
            // 
            // LblHandler
            // 
            this.LblHandler.AutoSize = true;
            this.LblHandler.Location = new System.Drawing.Point(63, 96);
            this.LblHandler.Name = "LblHandler";
            this.LblHandler.Size = new System.Drawing.Size(0, 13);
            this.LblHandler.TabIndex = 5;
            // 
            // PtbLogo
            // 
            this.PtbLogo.Image = ((System.Drawing.Image)(resources.GetObject("PtbLogo.Image")));
            this.PtbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("PtbLogo.InitialImage")));
            this.PtbLogo.Location = new System.Drawing.Point(11, 11);
            this.PtbLogo.Name = "PtbLogo";
            this.PtbLogo.Size = new System.Drawing.Size(32, 32);
            this.PtbLogo.TabIndex = 6;
            this.PtbLogo.TabStop = false;
            // 
            // Scanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(335, 114);
            this.Controls.Add(this.PtbLogo);
            this.Controls.Add(this.LblHandler);
            this.Controls.Add(this.LblScan);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.PrgScan);
            this.Controls.Add(this.LblCalc);
            this.Controls.Add(this.LblIntro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scanner";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Burnbytes";
            ((System.ComponentModel.ISupportInitialize)(this.PtbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblIntro;
        private System.Windows.Forms.Label LblCalc;
        private System.Windows.Forms.ProgressBar PrgScan;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblScan;
        private System.Windows.Forms.Label LblHandler;
        private System.Windows.Forms.PictureBox PtbLogo;
    }
}