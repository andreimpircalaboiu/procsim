﻿namespace ProcSimProj.Form
{
    partial class MainForm
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
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.ParsedInputTextbox = new System.Windows.Forms.TextBox();
            this.InputButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.LaunchWOButton = new System.Windows.Forms.Button();
            this.ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.LaunchWButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InputTextBox
            // 
            this.InputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputTextBox.Location = new System.Drawing.Point(9, 12);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(418, 122);
            this.InputTextBox.TabIndex = 0;
            // 
            // ParsedInputTextbox
            // 
            this.ParsedInputTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ParsedInputTextbox.Location = new System.Drawing.Point(9, 236);
            this.ParsedInputTextbox.Multiline = true;
            this.ParsedInputTextbox.Name = "ParsedInputTextbox";
            this.ParsedInputTextbox.Size = new System.Drawing.Size(418, 122);
            this.ParsedInputTextbox.TabIndex = 2;
            // 
            // InputButton
            // 
            this.InputButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InputButton.Location = new System.Drawing.Point(9, 189);
            this.InputButton.Name = "InputButton";
            this.InputButton.Size = new System.Drawing.Size(418, 41);
            this.InputButton.TabIndex = 1;
            this.InputButton.Text = "Parse";
            this.InputButton.UseVisualStyleBackColor = true;
            this.InputButton.Click += new System.EventHandler(this.InputButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportButton.Location = new System.Drawing.Point(9, 142);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(202, 41);
            this.ImportButton.TabIndex = 3;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExportButton.Location = new System.Drawing.Point(225, 142);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(202, 41);
            this.ExportButton.TabIndex = 4;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // LaunchWOButton
            // 
            this.LaunchWOButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LaunchWOButton.Location = new System.Drawing.Point(9, 364);
            this.LaunchWOButton.Name = "LaunchWOButton";
            this.LaunchWOButton.Size = new System.Drawing.Size(202, 41);
            this.LaunchWOButton.TabIndex = 5;
            this.LaunchWOButton.Text = "W/O Microinstructions";
            this.LaunchWOButton.UseVisualStyleBackColor = true;
            this.LaunchWOButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // ImportFileDialog
            // 
            this.ImportFileDialog.Filter = "Text Files (*.TXT)|*.txt|Assembly Files (*.ASM)|*.asm|All Files (*.*)|*.*";
            // 
            // LaunchWButton
            // 
            this.LaunchWButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LaunchWButton.Location = new System.Drawing.Point(225, 364);
            this.LaunchWButton.Name = "LaunchWButton";
            this.LaunchWButton.Size = new System.Drawing.Size(202, 41);
            this.LaunchWButton.TabIndex = 6;
            this.LaunchWButton.Text = "W/ Microinstructions";
            this.LaunchWButton.UseVisualStyleBackColor = true;
            this.LaunchWButton.Click += new System.EventHandler(this.LaunchWButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 411);
            this.Controls.Add(this.LaunchWButton);
            this.Controls.Add(this.LaunchWOButton);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.ParsedInputTextbox);
            this.Controls.Add(this.InputButton);
            this.Controls.Add(this.InputTextBox);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.TextBox ParsedInputTextbox;
        private System.Windows.Forms.Button InputButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button ExportButton;
        private System.Windows.Forms.Button LaunchWOButton;
        private System.Windows.Forms.OpenFileDialog ImportFileDialog;
        private System.Windows.Forms.Button LaunchWButton;
    }
}

