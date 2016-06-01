namespace ProcSimProj.Form
{
    partial class ProcessorWOForm
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
            this.ProcessorTextbox = new System.Windows.Forms.TextBox();
            this.MemoryTextbox = new System.Windows.Forms.TextBox();
            this.ProcessorLabel = new System.Windows.Forms.Label();
            this.MemoryLabel = new System.Windows.Forms.Label();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.InstructionListBox = new System.Windows.Forms.ListView();
            this.IndexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AssemblyColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InstructionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ExecuteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ProcessorTextbox
            // 
            this.ProcessorTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessorTextbox.Location = new System.Drawing.Point(281, 27);
            this.ProcessorTextbox.Multiline = true;
            this.ProcessorTextbox.Name = "ProcessorTextbox";
            this.ProcessorTextbox.Size = new System.Drawing.Size(412, 498);
            this.ProcessorTextbox.TabIndex = 1;
            // 
            // MemoryTextbox
            // 
            this.MemoryTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MemoryTextbox.Location = new System.Drawing.Point(699, 27);
            this.MemoryTextbox.Multiline = true;
            this.MemoryTextbox.Name = "MemoryTextbox";
            this.MemoryTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MemoryTextbox.Size = new System.Drawing.Size(416, 498);
            this.MemoryTextbox.TabIndex = 2;
            // 
            // ProcessorLabel
            // 
            this.ProcessorLabel.AutoSize = true;
            this.ProcessorLabel.Location = new System.Drawing.Point(278, 11);
            this.ProcessorLabel.Name = "ProcessorLabel";
            this.ProcessorLabel.Size = new System.Drawing.Size(54, 13);
            this.ProcessorLabel.TabIndex = 3;
            this.ProcessorLabel.Text = "Processor";
            // 
            // MemoryLabel
            // 
            this.MemoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MemoryLabel.AutoSize = true;
            this.MemoryLabel.Location = new System.Drawing.Point(699, 11);
            this.MemoryLabel.Name = "MemoryLabel";
            this.MemoryLabel.Size = new System.Drawing.Size(44, 13);
            this.MemoryLabel.TabIndex = 4;
            this.MemoryLabel.Text = "Memory";
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Location = new System.Drawing.Point(12, 11);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(61, 13);
            this.InstructionLabel.TabIndex = 6;
            this.InstructionLabel.Text = "Instructions";
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.Location = new System.Drawing.Point(982, 531);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(133, 34);
            this.NextButton.TabIndex = 7;
            this.NextButton.Text = "Next instruction";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // InstructionListBox
            // 
            this.InstructionListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IndexColumn,
            this.BinaryColumn,
            this.AssemblyColumn});
            this.InstructionListBox.Enabled = false;
            this.InstructionListBox.FullRowSelect = true;
            this.InstructionListBox.HideSelection = false;
            this.InstructionListBox.Location = new System.Drawing.Point(12, 27);
            this.InstructionListBox.Name = "InstructionListBox";
            this.InstructionListBox.Size = new System.Drawing.Size(263, 498);
            this.InstructionListBox.TabIndex = 8;
            this.InstructionListBox.UseCompatibleStateImageBehavior = false;
            this.InstructionListBox.View = System.Windows.Forms.View.Details;
            // 
            // IndexColumn
            // 
            this.IndexColumn.Text = "Index";
            // 
            // BinaryColumn
            // 
            this.BinaryColumn.Text = "Binary";
            this.BinaryColumn.Width = 120;
            // 
            // AssemblyColumn
            // 
            this.AssemblyColumn.Text = "Assembly";
            this.AssemblyColumn.Width = 80;
            // 
            // InstructionsBindingSource
            // 
            this.InstructionsBindingSource.DataSource = typeof(ProcSimProj.Form.Models.InstructionViewModel);
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteButton.Location = new System.Drawing.Point(843, 531);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(133, 34);
            this.ExecuteButton.TabIndex = 9;
            this.ExecuteButton.Text = "Execute";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // ProcessorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 572);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.InstructionListBox);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.MemoryLabel);
            this.Controls.Add(this.ProcessorLabel);
            this.Controls.Add(this.MemoryTextbox);
            this.Controls.Add(this.ProcessorTextbox);
            this.MaximizeBox = false;
            this.Name = "ProcessorForm";
            this.Text = "ProcessorForm";
            this.Load += new System.EventHandler(this.ProcessorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProcessorTextbox;
        private System.Windows.Forms.TextBox MemoryTextbox;
        private System.Windows.Forms.Label ProcessorLabel;
        private System.Windows.Forms.Label MemoryLabel;
        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.BindingSource InstructionsBindingSource;
        private System.Windows.Forms.ListView InstructionListBox;
        private System.Windows.Forms.ColumnHeader IndexColumn;
        private System.Windows.Forms.ColumnHeader BinaryColumn;
        private System.Windows.Forms.ColumnHeader AssemblyColumn;
        private System.Windows.Forms.Button ExecuteButton;
    }
}