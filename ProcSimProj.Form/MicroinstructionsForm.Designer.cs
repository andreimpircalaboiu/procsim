namespace ProcSimProj.Form
{
    partial class MicroinstructionsForm
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
            this.ImportButton = new System.Windows.Forms.Button();
            this.InstructionListBox = new System.Windows.Forms.ListView();
            this.AddressTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddressBinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SbusTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SbusBinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DbusTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DbusBinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AluTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AluBinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RbusTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RbusBinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OtherTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OtherBinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemoryTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MemoryBinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuccesorTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuccesorBinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JumpTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.JumpBinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConclusionTextColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ConclusionBinaryColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InputTextbox = new System.Windows.Forms.TextBox();
            this.LoadButton = new System.Windows.Forms.Button();
            this.ImportFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AssemblyTextbox = new System.Windows.Forms.TextBox();
            this.BinaryTextbox = new System.Windows.Forms.TextBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.InstructionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(12, 12);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(615, 41);
            this.ImportButton.TabIndex = 4;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // InstructionListBox
            // 
            this.InstructionListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstructionListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AddressTextColumn,
            this.AddressBinaryColumn,
            this.SbusTextColumn,
            this.SbusBinaryColumn,
            this.DbusTextColumn,
            this.DbusBinaryColumn,
            this.AluTextColumn,
            this.AluBinaryColumn,
            this.RbusTextColumn,
            this.RbusBinaryColumn,
            this.OtherTextColumn,
            this.OtherBinaryColumn,
            this.MemoryTextColumn,
            this.MemoryBinaryColumn,
            this.SuccesorTextColumn,
            this.SuccesorBinaryColumn,
            this.JumpTextColumn,
            this.JumpBinaryColumn,
            this.ConclusionTextColumn,
            this.ConclusionBinaryColumn});
            this.InstructionListBox.FullRowSelect = true;
            this.InstructionListBox.HideSelection = false;
            this.InstructionListBox.Location = new System.Drawing.Point(633, 59);
            this.InstructionListBox.Name = "InstructionListBox";
            this.InstructionListBox.Size = new System.Drawing.Size(870, 549);
            this.InstructionListBox.TabIndex = 9;
            this.InstructionListBox.UseCompatibleStateImageBehavior = false;
            this.InstructionListBox.View = System.Windows.Forms.View.Details;
            // 
            // AddressTextColumn
            // 
            this.AddressTextColumn.Text = "ADR";
            this.AddressTextColumn.Width = 53;
            // 
            // AddressBinaryColumn
            // 
            this.AddressBinaryColumn.Text = "ADR";
            this.AddressBinaryColumn.Width = 59;
            // 
            // SbusTextColumn
            // 
            this.SbusTextColumn.Text = "SBUS";
            // 
            // SbusBinaryColumn
            // 
            this.SbusBinaryColumn.Text = "SBUS";
            // 
            // DbusTextColumn
            // 
            this.DbusTextColumn.Text = "DBUS";
            // 
            // DbusBinaryColumn
            // 
            this.DbusBinaryColumn.Text = "DBUS";
            // 
            // AluTextColumn
            // 
            this.AluTextColumn.Text = "ALU";
            // 
            // AluBinaryColumn
            // 
            this.AluBinaryColumn.Text = "ALU";
            // 
            // RbusTextColumn
            // 
            this.RbusTextColumn.Text = "RBUS";
            // 
            // RbusBinaryColumn
            // 
            this.RbusBinaryColumn.Text = "RBUS";
            // 
            // OtherTextColumn
            // 
            this.OtherTextColumn.Text = "OTHER";
            // 
            // OtherBinaryColumn
            // 
            this.OtherBinaryColumn.Text = "OTHER";
            // 
            // MemoryTextColumn
            // 
            this.MemoryTextColumn.Text = "MEM";
            // 
            // MemoryBinaryColumn
            // 
            this.MemoryBinaryColumn.Text = "MEM";
            // 
            // SuccesorTextColumn
            // 
            this.SuccesorTextColumn.Text = "SUCC";
            // 
            // SuccesorBinaryColumn
            // 
            this.SuccesorBinaryColumn.Text = "SUCC";
            // 
            // JumpTextColumn
            // 
            this.JumpTextColumn.Text = "JMP";
            // 
            // JumpBinaryColumn
            // 
            this.JumpBinaryColumn.Text = "JMP";
            // 
            // ConclusionTextColumn
            // 
            this.ConclusionTextColumn.Text = "NXT";
            // 
            // ConclusionBinaryColumn
            // 
            this.ConclusionBinaryColumn.Text = "NXT";
            // 
            // InputTextbox
            // 
            this.InputTextbox.Location = new System.Drawing.Point(12, 59);
            this.InputTextbox.Multiline = true;
            this.InputTextbox.Name = "InputTextbox";
            this.InputTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InputTextbox.Size = new System.Drawing.Size(615, 234);
            this.InputTextbox.TabIndex = 10;
            // 
            // LoadButton
            // 
            this.LoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadButton.Enabled = false;
            this.LoadButton.Location = new System.Drawing.Point(633, 12);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(870, 41);
            this.LoadButton.TabIndex = 11;
            this.LoadButton.Text = "Load to application";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // ImportFileDialog
            // 
            this.ImportFileDialog.Filter = "Text Files (*.TXT)|*.txt|Assembly Files (*.ASM)|*.asm|All Files (*.*)|*.*";
            // 
            // AssemblyTextbox
            // 
            this.AssemblyTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AssemblyTextbox.Location = new System.Drawing.Point(12, 299);
            this.AssemblyTextbox.Multiline = true;
            this.AssemblyTextbox.Name = "AssemblyTextbox";
            this.AssemblyTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AssemblyTextbox.Size = new System.Drawing.Size(615, 179);
            this.AssemblyTextbox.TabIndex = 14;
            // 
            // BinaryTextbox
            // 
            this.BinaryTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BinaryTextbox.Location = new System.Drawing.Point(12, 484);
            this.BinaryTextbox.Multiline = true;
            this.BinaryTextbox.Name = "BinaryTextbox";
            this.BinaryTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.BinaryTextbox.Size = new System.Drawing.Size(615, 179);
            this.BinaryTextbox.TabIndex = 15;
            // 
            // NextButton
            // 
            this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NextButton.Location = new System.Drawing.Point(633, 622);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(870, 41);
            this.NextButton.TabIndex = 16;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // InstructionsBindingSource
            // 
            this.InstructionsBindingSource.DataSource = typeof(ProcSimProj.Architecture.MicroInstructions.Microinstruction);
            // 
            // MicroinstructionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 675);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.BinaryTextbox);
            this.Controls.Add(this.AssemblyTextbox);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.InputTextbox);
            this.Controls.Add(this.InstructionListBox);
            this.Controls.Add(this.ImportButton);
            this.Name = "MicroinstructionsForm";
            this.Text = "MicroinstructionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.InstructionsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.BindingSource InstructionsBindingSource;
        private System.Windows.Forms.ListView InstructionListBox;
        private System.Windows.Forms.ColumnHeader AddressTextColumn;
        private System.Windows.Forms.ColumnHeader AddressBinaryColumn;
        private System.Windows.Forms.TextBox InputTextbox;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.OpenFileDialog ImportFileDialog;
        private System.Windows.Forms.ColumnHeader SbusTextColumn;
        private System.Windows.Forms.ColumnHeader SbusBinaryColumn;
        private System.Windows.Forms.ColumnHeader DbusTextColumn;
        private System.Windows.Forms.ColumnHeader DbusBinaryColumn;
        private System.Windows.Forms.ColumnHeader AluTextColumn;
        private System.Windows.Forms.ColumnHeader AluBinaryColumn;
        private System.Windows.Forms.ColumnHeader RbusTextColumn;
        private System.Windows.Forms.ColumnHeader RbusBinaryColumn;
        private System.Windows.Forms.ColumnHeader OtherTextColumn;
        private System.Windows.Forms.ColumnHeader OtherBinaryColumn;
        private System.Windows.Forms.ColumnHeader MemoryTextColumn;
        private System.Windows.Forms.ColumnHeader MemoryBinaryColumn;
        private System.Windows.Forms.TextBox AssemblyTextbox;
        private System.Windows.Forms.TextBox BinaryTextbox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.ColumnHeader SuccesorTextColumn;
        private System.Windows.Forms.ColumnHeader SuccesorBinaryColumn;
        private System.Windows.Forms.ColumnHeader JumpTextColumn;
        private System.Windows.Forms.ColumnHeader JumpBinaryColumn;
        private System.Windows.Forms.ColumnHeader ConclusionTextColumn;
        private System.Windows.Forms.ColumnHeader ConclusionBinaryColumn;

    }
}