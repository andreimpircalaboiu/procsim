using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ProcSimProj.Architecture.MicroInstructions;
using ProcSimProj.Business.Constants;

namespace ProcSimProj.Form
{
    public partial class MicroinstructionsForm : System.Windows.Forms.Form
    {
        private readonly IList<string> _binary;
        private readonly IList<string> _assembly;
        private MicroManager _manager;

        public MicroinstructionsForm(IList<string> binary, IList<string> assembly)
        {
            _manager = new MicroManager();
            _binary = binary.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            _assembly = assembly.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            InitializeComponent();
            foreach (var line in _binary)
            {
                BinaryTextbox.Text += line + Environment.NewLine;
            }
            foreach (var line in _assembly)
            {
                AssemblyTextbox.Text += line + Environment.NewLine;
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (ImportFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (TextReader textReader = File.OpenText(ImportFileDialog.FileName))
                {
                    InputTextbox.Text += textReader.ReadToEnd();
                }
                LoadButton.Enabled = true;
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {   

            var allOperations = InstructionHelper.GetTokens();
            foreach (var line in InputTextbox.Lines)
            {
                if (string.IsNullOrEmpty(line)) continue;

                var micro = new Microline(line, allOperations);
                _manager.Microlines.Add(micro);
            }
            _manager.SetJumpAddresses();
            _manager.SetStepAddresses();
            foreach (var micro in _manager.Microlines)
            {
                this.InstructionListBox.Items.Add(new ListViewItem(new string[] { micro.AddressText, micro.AddressBinary,
                                                                                  micro.SbusText, micro.SbusBinary,
                                                                                  micro.DbusText, micro.DbusBinary,
                                                                                  micro.AluText, micro.AluBinary,
                                                                                  micro.RbusText, micro.RbusBinary,
                                                                                  micro.OtherText, micro.OtherBinary,
                                                                                  micro.MemoryText, micro.MemoryBinary,
                                                                                  micro.SuccesorText, micro.SuccesorBinary,
                                                                                  micro.JumpText, micro.JumpBinary,
                                                                                  micro.ConclusionText, micro.ConclusionBinary
                }, micro.Id.ToString()));
            }
            LoadButton.Enabled = false;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            var binary = BinaryTextbox.Lines.ToList();
            var assembly = AssemblyTextbox.Lines.ToList();
            var form = new ProcessorWForm(binary, assembly, _manager);
            form.Show();
        }
    }
}
