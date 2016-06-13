namespace ProcSimProj.Form
{
    partial class ProcessorWForm
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
            this.ExecuteInstructionButton = new System.Windows.Forms.Button();
            this.InstructionListBox = new System.Windows.Forms.ListView();
            this.IndexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AssemblyColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NextInstructionButton = new System.Windows.Forms.Button();
            this.InstructionLabel = new System.Windows.Forms.Label();
            this.MemoryLabel = new System.Windows.Forms.Label();
            this.ProcessorLabel = new System.Windows.Forms.Label();
            this.MemoryTextbox = new System.Windows.Forms.TextBox();
            this.ProcessorTextbox = new System.Windows.Forms.TextBox();
            this.MicroListBox = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.ExecuteMicroButton = new System.Windows.Forms.Button();
            this.LabelLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExecuteInstructionButton
            // 
            this.ExecuteInstructionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteInstructionButton.Location = new System.Drawing.Point(1097, 527);
            this.ExecuteInstructionButton.Name = "ExecuteInstructionButton";
            this.ExecuteInstructionButton.Size = new System.Drawing.Size(133, 34);
            this.ExecuteInstructionButton.TabIndex = 17;
            this.ExecuteInstructionButton.Text = "Execute instruction";
            this.ExecuteInstructionButton.UseVisualStyleBackColor = true;
            this.ExecuteInstructionButton.Click += new System.EventHandler(this.ExecuteButton_Click);
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
            this.InstructionListBox.Location = new System.Drawing.Point(8, 23);
            this.InstructionListBox.Name = "InstructionListBox";
            this.InstructionListBox.Size = new System.Drawing.Size(263, 498);
            this.InstructionListBox.TabIndex = 16;
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
            // NextInstructionButton
            // 
            this.NextInstructionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NextInstructionButton.Location = new System.Drawing.Point(1236, 527);
            this.NextInstructionButton.Name = "NextInstructionButton";
            this.NextInstructionButton.Size = new System.Drawing.Size(133, 34);
            this.NextInstructionButton.TabIndex = 15;
            this.NextInstructionButton.Text = "Next instruction";
            this.NextInstructionButton.UseVisualStyleBackColor = true;
            this.NextInstructionButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // InstructionLabel
            // 
            this.InstructionLabel.AutoSize = true;
            this.InstructionLabel.Location = new System.Drawing.Point(8, 7);
            this.InstructionLabel.Name = "InstructionLabel";
            this.InstructionLabel.Size = new System.Drawing.Size(61, 13);
            this.InstructionLabel.TabIndex = 14;
            this.InstructionLabel.Text = "Instructions";
            // 
            // MemoryLabel
            // 
            this.MemoryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MemoryLabel.AutoSize = true;
            this.MemoryLabel.Location = new System.Drawing.Point(982, 7);
            this.MemoryLabel.Name = "MemoryLabel";
            this.MemoryLabel.Size = new System.Drawing.Size(44, 13);
            this.MemoryLabel.TabIndex = 13;
            this.MemoryLabel.Text = "Memory";
            // 
            // ProcessorLabel
            // 
            this.ProcessorLabel.AutoSize = true;
            this.ProcessorLabel.Location = new System.Drawing.Point(575, 7);
            this.ProcessorLabel.Name = "ProcessorLabel";
            this.ProcessorLabel.Size = new System.Drawing.Size(54, 13);
            this.ProcessorLabel.TabIndex = 12;
            this.ProcessorLabel.Text = "Processor";
            // 
            // MemoryTextbox
            // 
            this.MemoryTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MemoryTextbox.Location = new System.Drawing.Point(985, 23);
            this.MemoryTextbox.Multiline = true;
            this.MemoryTextbox.Name = "MemoryTextbox";
            this.MemoryTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MemoryTextbox.Size = new System.Drawing.Size(384, 498);
            this.MemoryTextbox.TabIndex = 11;
            // 
            // ProcessorTextbox
            // 
            this.ProcessorTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProcessorTextbox.Location = new System.Drawing.Point(578, 23);
            this.ProcessorTextbox.Multiline = true;
            this.ProcessorTextbox.Name = "ProcessorTextbox";
            this.ProcessorTextbox.Size = new System.Drawing.Size(401, 498);
            this.ProcessorTextbox.TabIndex = 10;
            // 
            // MicroListBox
            // 
            this.MicroListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MicroListBox.Enabled = false;
            this.MicroListBox.FullRowSelect = true;
            this.MicroListBox.HideSelection = false;
            this.MicroListBox.Location = new System.Drawing.Point(277, 23);
            this.MicroListBox.Name = "MicroListBox";
            this.MicroListBox.Size = new System.Drawing.Size(295, 498);
            this.MicroListBox.TabIndex = 19;
            this.MicroListBox.UseCompatibleStateImageBehavior = false;
            this.MicroListBox.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Text";
            this.columnHeader1.Width = 146;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Binary";
            this.columnHeader2.Width = 146;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Microinstructions";
            // 
            // ExecuteMicroButton
            // 
            this.ExecuteMicroButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecuteMicroButton.Location = new System.Drawing.Point(958, 526);
            this.ExecuteMicroButton.Name = "ExecuteMicroButton";
            this.ExecuteMicroButton.Size = new System.Drawing.Size(133, 34);
            this.ExecuteMicroButton.TabIndex = 20;
            this.ExecuteMicroButton.Text = "Execute micro";
            this.ExecuteMicroButton.UseVisualStyleBackColor = true;
            this.ExecuteMicroButton.Click += new System.EventHandler(this.ExecuteMicroButton_Click);
            // 
            // LabelLabel
            // 
            this.LabelLabel.AutoSize = true;
            this.LabelLabel.Location = new System.Drawing.Point(277, 9);
            this.LabelLabel.Name = "LabelLabel";
            this.LabelLabel.Size = new System.Drawing.Size(0, 13);
            this.LabelLabel.TabIndex = 21;
            // 
            // ProcessorWForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1381, 572);
            this.Controls.Add(this.LabelLabel);
            this.Controls.Add(this.ExecuteMicroButton);
            this.Controls.Add(this.MicroListBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExecuteInstructionButton);
            this.Controls.Add(this.InstructionListBox);
            this.Controls.Add(this.NextInstructionButton);
            this.Controls.Add(this.InstructionLabel);
            this.Controls.Add(this.MemoryLabel);
            this.Controls.Add(this.ProcessorLabel);
            this.Controls.Add(this.MemoryTextbox);
            this.Controls.Add(this.ProcessorTextbox);
            this.Name = "ProcessorWForm";
            this.Text = "ProcessorWForm";
            this.Load += new System.EventHandler(this.ProcessorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExecuteInstructionButton;
        private System.Windows.Forms.ListView InstructionListBox;
        private System.Windows.Forms.ColumnHeader IndexColumn;
        private System.Windows.Forms.ColumnHeader BinaryColumn;
        private System.Windows.Forms.ColumnHeader AssemblyColumn;
        private System.Windows.Forms.Button NextInstructionButton;
        private System.Windows.Forms.Label InstructionLabel;
        private System.Windows.Forms.Label MemoryLabel;
        private System.Windows.Forms.Label ProcessorLabel;
        private System.Windows.Forms.TextBox MemoryTextbox;
        private System.Windows.Forms.TextBox ProcessorTextbox;
        private System.Windows.Forms.ListView MicroListBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExecuteMicroButton;
        private System.Windows.Forms.Label LabelLabel;
    }
}