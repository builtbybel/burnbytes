namespace Comet.UI
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
            this.LblDesc = new System.Windows.Forms.Label();
            this.LblIntro = new System.Windows.Forms.Label();
            this.LvwHandlers = new System.Windows.Forms.ListView();
            this.ClnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ClnSpace = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblMainMenu = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblSavingsNum = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblElevate = new System.Windows.Forms.LinkLabel();
            this.LblAdvanced = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GitHub = new System.Windows.Forms.ToolStripMenuItem();
            this.Info = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCheckAll = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblDesc
            // 
            this.LblDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.LblDesc.BackColor = System.Drawing.Color.White;
            this.LblDesc.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LblDesc.Location = new System.Drawing.Point(3, 99);
            this.LblDesc.Name = "LblDesc";
            this.LblDesc.Size = new System.Drawing.Size(243, 312);
            this.LblDesc.TabIndex = 2;
            // 
            // LblIntro
            // 
            this.LblIntro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblIntro.AutoEllipsis = true;
            this.LblIntro.AutoSize = true;
            this.LblIntro.BackColor = System.Drawing.Color.White;
            this.LblIntro.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIntro.ForeColor = System.Drawing.Color.Black;
            this.LblIntro.Location = new System.Drawing.Point(272, 55);
            this.LblIntro.Name = "LblIntro";
            this.LblIntro.Size = new System.Drawing.Size(436, 21);
            this.LblIntro.TabIndex = 2;
            this.LblIntro.Text = "You can use Disk Cleanup to free up to {0} of disk space on {1}.";
            this.LblIntro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LvwHandlers
            // 
            this.LvwHandlers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LvwHandlers.BackColor = System.Drawing.Color.White;
            this.LvwHandlers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LvwHandlers.CheckBoxes = true;
            this.LvwHandlers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClnName,
            this.ClnSpace});
            this.LvwHandlers.Font = new System.Drawing.Font("Segoe UI Semilight", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvwHandlers.ForeColor = System.Drawing.Color.Black;
            this.LvwHandlers.FullRowSelect = true;
            this.LvwHandlers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LvwHandlers.HideSelection = false;
            this.LvwHandlers.Location = new System.Drawing.Point(278, 140);
            this.LvwHandlers.Name = "LvwHandlers";
            this.LvwHandlers.Scrollable = false;
            this.LvwHandlers.Size = new System.Drawing.Size(473, 412);
            this.LvwHandlers.TabIndex = 3;
            this.LvwHandlers.UseCompatibleStateImageBehavior = false;
            this.LvwHandlers.View = System.Windows.Forms.View.Details;
            this.LvwHandlers.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LvwHandlers_ItemChecked);
            this.LvwHandlers.SelectedIndexChanged += new System.EventHandler(this.LvwHandlers_SelectedIndexChanged);
            // 
            // ClnName
            // 
            this.ClnName.Text = "Name";
            this.ClnName.Width = 350;
            // 
            // ClnSpace
            // 
            this.ClnSpace.Text = "Space";
            this.ClnSpace.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ClnSpace.Width = 500;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.LblMainMenu);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 689);
            this.panel2.TabIndex = 13;
            // 
            // LblMainMenu
            // 
            this.LblMainMenu.BackColor = System.Drawing.Color.LightGray;
            this.LblMainMenu.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.LblMainMenu.FlatAppearance.BorderSize = 0;
            this.LblMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblMainMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMainMenu.ForeColor = System.Drawing.Color.Black;
            this.LblMainMenu.Image = ((System.Drawing.Image)(resources.GetObject("LblMainMenu.Image")));
            this.LblMainMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblMainMenu.Location = new System.Drawing.Point(0, 0);
            this.LblMainMenu.Name = "LblMainMenu";
            this.LblMainMenu.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.LblMainMenu.Size = new System.Drawing.Size(44, 51);
            this.LblMainMenu.TabIndex = 20;
            this.LblMainMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblMainMenu.UseVisualStyleBackColor = false;
            this.LblMainMenu.Click += new System.EventHandler(this.LblMainMenu_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoEllipsis = true;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(12, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 21);
            this.label5.TabIndex = 17;
            this.label5.Text = "System";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoEllipsis = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 117);
            this.label2.TabIndex = 16;
            this.label2.Text = "If you\'re low on space, we can try \r\nto clean up files using \r\nthe settings on th" +
    "is page.\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblSavingsNum
            // 
            this.LblSavingsNum.AutoEllipsis = true;
            this.LblSavingsNum.BackColor = System.Drawing.Color.White;
            this.LblSavingsNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LblSavingsNum.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSavingsNum.ForeColor = System.Drawing.Color.Black;
            this.LblSavingsNum.Location = new System.Drawing.Point(580, 110);
            this.LblSavingsNum.Name = "LblSavingsNum";
            this.LblSavingsNum.Size = new System.Drawing.Size(165, 25);
            this.LblSavingsNum.TabIndex = 14;
            this.LblSavingsNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LblElevate);
            this.panel1.Controls.Add(this.LblAdvanced);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.LblDesc);
            this.panel1.Controls.Add(this.BtnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(757, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 689);
            this.panel1.TabIndex = 14;
            // 
            // LblElevate
            // 
            this.LblElevate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblElevate.AutoSize = true;
            this.LblElevate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblElevate.Location = new System.Drawing.Point(8, 531);
            this.LblElevate.Name = "LblElevate";
            this.LblElevate.Size = new System.Drawing.Size(161, 21);
            this.LblElevate.TabIndex = 19;
            this.LblElevate.TabStop = true;
            this.LblElevate.Text = "More storage settings";
            this.LblElevate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblElevate_LinkClicked);
            // 
            // LblAdvanced
            // 
            this.LblAdvanced.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblAdvanced.AutoSize = true;
            this.LblAdvanced.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAdvanced.Location = new System.Drawing.Point(8, 497);
            this.LblAdvanced.Name = "LblAdvanced";
            this.LblAdvanced.Size = new System.Drawing.Size(76, 21);
            this.LblAdvanced.TabIndex = 18;
            this.LblAdvanced.TabStop = true;
            this.LblAdvanced.Text = "View files";
            this.LblAdvanced.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LblAdvanced_LinkClicked);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoEllipsis = true;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 30);
            this.label4.TabIndex = 17;
            this.label4.Text = "About this clean-up";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOk.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnOk.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.BtnOk.FlatAppearance.BorderSize = 2;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.BtnOk.Location = new System.Drawing.Point(8, 569);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(213, 37);
            this.BtnOk.TabIndex = 5;
            this.BtnOk.Text = "Clean selected items";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(270, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Storage";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // contextMenu
            // 
            this.contextMenu.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GitHub,
            this.Info});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenu.Size = new System.Drawing.Size(219, 56);
            // 
            // GitHub
            // 
            this.GitHub.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GitHub.Image = ((System.Drawing.Image)(resources.GetObject("GitHub.Image")));
            this.GitHub.Name = "GitHub";
            this.GitHub.Size = new System.Drawing.Size(218, 26);
            this.GitHub.Text = "@github/burnbytes";
            this.GitHub.Click += new System.EventHandler(this.GitHub_Click);
            // 
            // Info
            // 
            this.Info.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(218, 26);
            this.Info.Text = "Info";
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // BtnCheckAll
            // 
            this.BtnCheckAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.BtnCheckAll.AutoSize = true;
            this.BtnCheckAll.BackColor = System.Drawing.Color.Transparent;
            this.BtnCheckAll.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.BtnCheckAll.FlatAppearance.BorderSize = 0;
            this.BtnCheckAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCheckAll.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCheckAll.ForeColor = System.Drawing.Color.Black;
            this.BtnCheckAll.Location = new System.Drawing.Point(272, 108);
            this.BtnCheckAll.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCheckAll.Name = "BtnCheckAll";
            this.BtnCheckAll.Size = new System.Drawing.Size(26, 27);
            this.BtnCheckAll.TabIndex = 120;
            this.BtnCheckAll.Text = "X";
            this.BtnCheckAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.BtnCheckAll.UseVisualStyleBackColor = true;
            this.BtnCheckAll.CheckedChanged += new System.EventHandler(this.BtnCheckAll_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(307, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 21);
            this.label3.TabIndex = 16;
            this.label3.Text = "Files to delete";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HandlerChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1036, 689);
            this.Controls.Add(this.BtnCheckAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblSavingsNum);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LvwHandlers);
            this.Controls.Add(this.LblIntro);
            this.Name = "HandlerChoice";
            this.ShowIcon = false;
            this.Text = "Burnbytes";
            this.Load += new System.EventHandler(this.HandlerChoice_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblDesc;
        private System.Windows.Forms.Label LblIntro;
        private System.Windows.Forms.ListView LvwHandlers;
        private System.Windows.Forms.ColumnHeader ClnName;
        private System.Windows.Forms.ColumnHeader ClnSpace;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblSavingsNum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel LblAdvanced;
        private System.Windows.Forms.LinkLabel LblElevate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem Info;
        private System.Windows.Forms.ToolStripMenuItem GitHub;
        private System.Windows.Forms.Button LblMainMenu;
        private System.Windows.Forms.CheckBox BtnCheckAll;
        private System.Windows.Forms.Label label3;
    }
}

