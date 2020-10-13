namespace Burnbytes.Forms
{
    partial class HandlerChoice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HandlerChoice));
            this.lblDescriptionOfCurrentCleanupHandler = new System.Windows.Forms.Label();
            this.lblIntroduction = new System.Windows.Forms.Label();
            this.lvCleanupHandlers = new System.Windows.Forms.ListView();
            this.clhName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.btnShowMainMenu = new System.Windows.Forms.Button();
            this.lblSystem = new System.Windows.Forms.Label();
            this.lblInformation = new System.Windows.Forms.Label();
            this.lblSavingsNum = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblShoreMoreSettings = new System.Windows.Forms.LinkLabel();
            this.lblShowFilesInExplorer = new System.Windows.Forms.LinkLabel();
            this.lblAboutCurrentCleanupHandler = new System.Windows.Forms.Label();
            this.btnRunCleaning = new System.Windows.Forms.Button();
            this.lblStorage = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemShowWebsite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.chkSelectAllHandlers = new System.Windows.Forms.CheckBox();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDescriptionOfCurrentCleanupHandler
            // 
            this.lblDescriptionOfCurrentCleanupHandler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lblDescriptionOfCurrentCleanupHandler.BackColor = System.Drawing.Color.White;
            this.lblDescriptionOfCurrentCleanupHandler.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionOfCurrentCleanupHandler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDescriptionOfCurrentCleanupHandler.Location = new System.Drawing.Point(9, 120);
            this.lblDescriptionOfCurrentCleanupHandler.Name = "lblDescriptionOfCurrentCleanupHandler";
            this.lblDescriptionOfCurrentCleanupHandler.Size = new System.Drawing.Size(258, 348);
            this.lblDescriptionOfCurrentCleanupHandler.TabIndex = 2;
            // 
            // lblIntroduction
            // 
            this.lblIntroduction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIntroduction.BackColor = System.Drawing.Color.Transparent;
            this.lblIntroduction.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntroduction.ForeColor = System.Drawing.Color.Black;
            this.lblIntroduction.Location = new System.Drawing.Point(12, 71);
            this.lblIntroduction.Name = "lblIntroduction";
            this.lblIntroduction.Size = new System.Drawing.Size(466, 45);
            this.lblIntroduction.TabIndex = 4;
            this.lblIntroduction.Text = "You can use Disk Cleanup to free up to {0} of disk space on {1}.";
            // 
            // lvCleanupHandlers
            // 
            this.lvCleanupHandlers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvCleanupHandlers.BackColor = System.Drawing.Color.White;
            this.lvCleanupHandlers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvCleanupHandlers.CheckBoxes = true;
            this.lvCleanupHandlers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhName,
            this.clhSpace});
            this.lvCleanupHandlers.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCleanupHandlers.ForeColor = System.Drawing.Color.Black;
            this.lvCleanupHandlers.FullRowSelect = true;
            this.lvCleanupHandlers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvCleanupHandlers.HideSelection = false;
            this.lvCleanupHandlers.Location = new System.Drawing.Point(12, 146);
            this.lvCleanupHandlers.Name = "lvCleanupHandlers";
            this.lvCleanupHandlers.Scrollable = false;
            this.lvCleanupHandlers.Size = new System.Drawing.Size(466, 531);
            this.lvCleanupHandlers.TabIndex = 2;
            this.lvCleanupHandlers.UseCompatibleStateImageBehavior = false;
            this.lvCleanupHandlers.View = System.Windows.Forms.View.Details;
            this.lvCleanupHandlers.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LvwHandlers_ItemChecked);
            this.lvCleanupHandlers.SelectedIndexChanged += new System.EventHandler(this.LvwHandlers_SelectedIndexChanged);
            // 
            // clhName
            // 
            this.clhName.Text = "Name";
            this.clhName.Width = 350;
            // 
            // clhSpace
            // 
            this.clhSpace.Text = "Space";
            this.clhSpace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.clhSpace.Width = 500;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLeft.Controls.Add(this.btnShowMainMenu);
            this.pnlLeft.Controls.Add(this.lblSystem);
            this.pnlLeft.Controls.Add(this.lblInformation);
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(264, 689);
            this.pnlLeft.TabIndex = 1;
            // 
            // btnShowMainMenu
            // 
            this.btnShowMainMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnShowMainMenu.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btnShowMainMenu.FlatAppearance.BorderSize = 0;
            this.btnShowMainMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.HotPink;
            this.btnShowMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowMainMenu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowMainMenu.ForeColor = System.Drawing.Color.Black;
            this.btnShowMainMenu.Location = new System.Drawing.Point(0, 0);
            this.btnShowMainMenu.Name = "btnShowMainMenu";
            this.btnShowMainMenu.Size = new System.Drawing.Size(48, 51);
            this.btnShowMainMenu.TabIndex = 0;
            this.btnShowMainMenu.UseVisualStyleBackColor = false;
            this.btnShowMainMenu.Click += new System.EventHandler(this.BtnShowMainMenu_Click);
            // 
            // lblSystem
            // 
            this.lblSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystem.AutoEllipsis = true;
            this.lblSystem.AutoSize = true;
            this.lblSystem.BackColor = System.Drawing.Color.Transparent;
            this.lblSystem.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystem.ForeColor = System.Drawing.Color.Black;
            this.lblSystem.Location = new System.Drawing.Point(12, 71);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(63, 21);
            this.lblSystem.TabIndex = 1;
            this.lblSystem.Text = "System";
            // 
            // lblInformation
            // 
            this.lblInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInformation.AutoEllipsis = true;
            this.lblInformation.BackColor = System.Drawing.Color.Transparent;
            this.lblInformation.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInformation.ForeColor = System.Drawing.Color.Black;
            this.lblInformation.Location = new System.Drawing.Point(12, 119);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(249, 90);
            this.lblInformation.TabIndex = 2;
            this.lblInformation.Text = "If you\'re low on space, we can try \r\nto clean up files using \r\nthe settings on th" +
    "is page.\r\n";
            // 
            // lblSavingsNum
            // 
            this.lblSavingsNum.AutoEllipsis = true;
            this.lblSavingsNum.BackColor = System.Drawing.Color.Transparent;
            this.lblSavingsNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblSavingsNum.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavingsNum.ForeColor = System.Drawing.Color.Black;
            this.lblSavingsNum.Location = new System.Drawing.Point(314, 117);
            this.lblSavingsNum.Name = "lblSavingsNum";
            this.lblSavingsNum.Size = new System.Drawing.Size(164, 25);
            this.lblSavingsNum.TabIndex = 0;
            this.lblSavingsNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.lblShoreMoreSettings);
            this.pnlRight.Controls.Add(this.lblShowFilesInExplorer);
            this.pnlRight.Controls.Add(this.lblAboutCurrentCleanupHandler);
            this.pnlRight.Controls.Add(this.lblDescriptionOfCurrentCleanupHandler);
            this.pnlRight.Controls.Add(this.btnRunCleaning);
            this.pnlRight.Location = new System.Drawing.Point(757, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(279, 689);
            this.pnlRight.TabIndex = 0;
            // 
            // lblShoreMoreSettings
            // 
            this.lblShoreMoreSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShoreMoreSettings.AutoSize = true;
            this.lblShoreMoreSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShoreMoreSettings.Location = new System.Drawing.Point(8, 531);
            this.lblShoreMoreSettings.Name = "lblShoreMoreSettings";
            this.lblShoreMoreSettings.Size = new System.Drawing.Size(161, 21);
            this.lblShoreMoreSettings.TabIndex = 4;
            this.lblShoreMoreSettings.TabStop = true;
            this.lblShoreMoreSettings.Text = "More storage settings";
            this.lblShoreMoreSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblElevate_LinkClicked);
            // 
            // lblShowFilesInExplorer
            // 
            this.lblShowFilesInExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblShowFilesInExplorer.AutoSize = true;
            this.lblShowFilesInExplorer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowFilesInExplorer.Location = new System.Drawing.Point(8, 497);
            this.lblShowFilesInExplorer.Name = "lblShowFilesInExplorer";
            this.lblShowFilesInExplorer.Size = new System.Drawing.Size(76, 21);
            this.lblShowFilesInExplorer.TabIndex = 3;
            this.lblShowFilesInExplorer.TabStop = true;
            this.lblShowFilesInExplorer.Text = "View files";
            this.lblShowFilesInExplorer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblAdvanced_LinkClicked);
            // 
            // lblAboutCurrentCleanupHandler
            // 
            this.lblAboutCurrentCleanupHandler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAboutCurrentCleanupHandler.AutoEllipsis = true;
            this.lblAboutCurrentCleanupHandler.AutoSize = true;
            this.lblAboutCurrentCleanupHandler.BackColor = System.Drawing.Color.Transparent;
            this.lblAboutCurrentCleanupHandler.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblAboutCurrentCleanupHandler.ForeColor = System.Drawing.Color.Black;
            this.lblAboutCurrentCleanupHandler.Location = new System.Drawing.Point(8, 71);
            this.lblAboutCurrentCleanupHandler.Name = "lblAboutCurrentCleanupHandler";
            this.lblAboutCurrentCleanupHandler.Size = new System.Drawing.Size(153, 21);
            this.lblAboutCurrentCleanupHandler.TabIndex = 1;
            this.lblAboutCurrentCleanupHandler.Text = "About this clean-up";
            this.lblAboutCurrentCleanupHandler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRunCleaning
            // 
            this.btnRunCleaning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunCleaning.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRunCleaning.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRunCleaning.FlatAppearance.BorderSize = 2;
            this.btnRunCleaning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunCleaning.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunCleaning.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnRunCleaning.Location = new System.Drawing.Point(8, 569);
            this.btnRunCleaning.Name = "btnRunCleaning";
            this.btnRunCleaning.Size = new System.Drawing.Size(213, 37);
            this.btnRunCleaning.TabIndex = 0;
            this.btnRunCleaning.Text = "Clean selected items";
            this.btnRunCleaning.UseVisualStyleBackColor = false;
            this.btnRunCleaning.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // lblStorage
            // 
            this.lblStorage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStorage.AutoEllipsis = true;
            this.lblStorage.AutoSize = true;
            this.lblStorage.BackColor = System.Drawing.Color.Transparent;
            this.lblStorage.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStorage.ForeColor = System.Drawing.Color.Black;
            this.lblStorage.Location = new System.Drawing.Point(12, 12);
            this.lblStorage.Name = "lblStorage";
            this.lblStorage.Size = new System.Drawing.Size(99, 32);
            this.lblStorage.TabIndex = 3;
            this.lblStorage.Text = "Storage";
            this.lblStorage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemShowWebsite,
            this.tsMenuItemAbout});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.Size = new System.Drawing.Size(219, 56);
            // 
            // tsMenuItemShowWebsite
            // 
            this.tsMenuItemShowWebsite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsMenuItemShowWebsite.Image = ((System.Drawing.Image)(resources.GetObject("tsMenuItemShowWebsite.Image")));
            this.tsMenuItemShowWebsite.Name = "tsMenuItemShowWebsite";
            this.tsMenuItemShowWebsite.Size = new System.Drawing.Size(218, 26);
            this.tsMenuItemShowWebsite.Text = "@github/burnbytes";
            this.tsMenuItemShowWebsite.Click += new System.EventHandler(this.TsMenuItemShowWebsite_Click);
            // 
            // tsMenuItemAbout
            // 
            this.tsMenuItemAbout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsMenuItemAbout.Name = "tsMenuItemAbout";
            this.tsMenuItemAbout.Size = new System.Drawing.Size(218, 26);
            this.tsMenuItemAbout.Text = "Info";
            this.tsMenuItemAbout.Click += new System.EventHandler(this.TsMenuItemAbout_Click);
            // 
            // chkSelectAllHandlers
            // 
            this.chkSelectAllHandlers.BackColor = System.Drawing.Color.Transparent;
            this.chkSelectAllHandlers.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.chkSelectAllHandlers.FlatAppearance.BorderSize = 0;
            this.chkSelectAllHandlers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSelectAllHandlers.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.chkSelectAllHandlers.ForeColor = System.Drawing.Color.Black;
            this.chkSelectAllHandlers.Location = new System.Drawing.Point(16, 120);
            this.chkSelectAllHandlers.Margin = new System.Windows.Forms.Padding(2);
            this.chkSelectAllHandlers.Name = "chkSelectAllHandlers";
            this.chkSelectAllHandlers.Size = new System.Drawing.Size(296, 21);
            this.chkSelectAllHandlers.TabIndex = 1;
            this.chkSelectAllHandlers.Text = "Files to delete";
            this.chkSelectAllHandlers.UseVisualStyleBackColor = true;
            this.chkSelectAllHandlers.CheckedChanged += new System.EventHandler(this.ChkSelectAllHandlers_CheckedChanged);
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMiddle.Controls.Add(this.lblSavingsNum);
            this.pnlMiddle.Controls.Add(this.lvCleanupHandlers);
            this.pnlMiddle.Controls.Add(this.chkSelectAllHandlers);
            this.pnlMiddle.Controls.Add(this.lblIntroduction);
            this.pnlMiddle.Controls.Add(this.lblStorage);
            this.pnlMiddle.Location = new System.Drawing.Point(270, 0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(481, 689);
            this.pnlMiddle.TabIndex = 2;
            // 
            // HandlerChoice
            // 
            this.AcceptButton = this.btnRunCleaning;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1036, 689);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlMiddle);
            this.Name = "HandlerChoice";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Burnbytes";
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblDescriptionOfCurrentCleanupHandler;
        private System.Windows.Forms.Label lblIntroduction;
        private System.Windows.Forms.ListView lvCleanupHandlers;
        private System.Windows.Forms.ColumnHeader clhName;
        private System.Windows.Forms.ColumnHeader clhSpace;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblSavingsNum;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnRunCleaning;
        private System.Windows.Forms.Label lblStorage;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.Label lblAboutCurrentCleanupHandler;
        private System.Windows.Forms.LinkLabel lblShowFilesInExplorer;
        private System.Windows.Forms.LinkLabel lblShoreMoreSettings;
        private System.Windows.Forms.Label lblSystem;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemShowWebsite;
        private System.Windows.Forms.Button btnShowMainMenu;
        private System.Windows.Forms.CheckBox chkSelectAllHandlers;
        private System.Windows.Forms.Panel pnlMiddle;
    }
}

