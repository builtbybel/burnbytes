namespace Burnbytes.Forms
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblCalculation = new System.Windows.Forms.Label();
            this.pgrScanning = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblScanning = new System.Windows.Forms.Label();
            this.lblCurrentHandler = new System.Windows.Forms.Label();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // LblIntro
            // 
            this.lblDescription.Location = new System.Drawing.Point(47, 11);
            this.lblDescription.Name = "LblIntro";
            this.lblDescription.Size = new System.Drawing.Size(276, 41);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Burnbytes is calculating how much space you will be able to free on {0}. This may" +
    " take a few minutes to complete.";
            // 
            // LblCalc
            // 
            this.lblCalculation.AutoSize = true;
            this.lblCalculation.Location = new System.Drawing.Point(8, 60);
            this.lblCalculation.Name = "LblCalc";
            this.lblCalculation.Size = new System.Drawing.Size(68, 13);
            this.lblCalculation.TabIndex = 1;
            this.lblCalculation.Text = "Calculating...";
            // 
            // PrgScan
            // 
            this.pgrScanning.Location = new System.Drawing.Point(11, 78);
            this.pgrScanning.Name = "PrgScan";
            this.pgrScanning.Size = new System.Drawing.Size(227, 13);
            this.pgrScanning.TabIndex = 2;
            // 
            // BtnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(249, 70);
            this.btnCancel.Name = "BtnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblScan
            // 
            this.lblScanning.AutoSize = true;
            this.lblScanning.Location = new System.Drawing.Point(8, 96);
            this.lblScanning.Name = "LblScan";
            this.lblScanning.Size = new System.Drawing.Size(55, 13);
            this.lblScanning.TabIndex = 4;
            this.lblScanning.Text = "Scanning:";
            // 
            // LblHandler
            // 
            this.lblCurrentHandler.AutoSize = true;
            this.lblCurrentHandler.Location = new System.Drawing.Point(63, 96);
            this.lblCurrentHandler.Name = "LblHandler";
            this.lblCurrentHandler.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentHandler.TabIndex = 5;
            // 
            // PtbLogo
            // 
            this.ptbLogo.Image = ((System.Drawing.Image)(resources.GetObject("PtbLogo.Image")));
            this.ptbLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("PtbLogo.InitialImage")));
            this.ptbLogo.Location = new System.Drawing.Point(11, 11);
            this.ptbLogo.Name = "PtbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(32, 32);
            this.ptbLogo.TabIndex = 6;
            this.ptbLogo.TabStop = false;
            // 
            // Scanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(335, 114);
            this.Controls.Add(this.ptbLogo);
            this.Controls.Add(this.lblCurrentHandler);
            this.Controls.Add(this.lblScanning);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pgrScanning);
            this.Controls.Add(this.lblCalculation);
            this.Controls.Add(this.lblDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scanner";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Burnbytes";
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblCalculation;
        private System.Windows.Forms.ProgressBar pgrScanning;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblScanning;
        private System.Windows.Forms.Label lblCurrentHandler;
        private System.Windows.Forms.PictureBox ptbLogo;
    }
}