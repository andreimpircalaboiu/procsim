using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcSimProj.Architecture.CPU;
using ProcSimProj.Business.Constants;
using ProcSimProj.Business.Instructions;
using ProcSimProj.Form.Models;

namespace ProcSimProj.Form
{
    public partial class ProcessorWOForm : System.Windows.Forms.Form
    {
        private readonly IList<string> _binary;
        private readonly IList<string> _assembly;
        private IList<int> _indexes;
        private IList<InstructionViewModel> _instructions;
        private Processor _processor;
        private int _initialIndex = 4;
        private InstructionFactory _factory;
        private string _currentSelected;

        public ProcessorWOForm(IList<string> binary, IList<string> assembly)
        {
            _binary = binary.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            _assembly = assembly.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            _processor = new Processor();
            _factory = new InstructionFactory();
            _instructions = new List<InstructionViewModel>();
            InitializeComponent();
        }

        private void ProcessorForm_Load(object sender, EventArgs e)
        {
            _indexes = _processor.LoadInstructionsInMemory(_binary, _initialIndex);
            for (var counter = 0; counter < _indexes.Count; counter++)
            {
                _instructions.Add(new InstructionViewModel
                                         {
                                             Assembly = _assembly[counter].Trim(' '),
                                             Binary = _binary[counter].Trim(' '),
                                             Index = _indexes[counter]
                                         });

            }
            FillListBox();
            Print(_processor);
            SelectInstruction(_initialIndex.ToString(),true);
            ExecuteButton.Enabled = true;
            NextButton.Enabled = false;
            
        }

        private bool SelectInstruction(string index, bool state)
        {

            var found = InstructionListBox.Items.Cast<ListViewItem>().FirstOrDefault(i => i.ImageKey == index);
            if (found == null)
            {
                return false;
            }
            InstructionListBox.Items[found.Index].Selected = state;
            _currentSelected = index;
            return true;
        }

        private void FillListBox()
        {
            foreach (var item in _instructions)
            {
                this.InstructionListBox.Items.Add(new ListViewItem(new string[] {item.Index.ToString(), item.Binary, item.Assembly},item.Index.ToString()));
            }
        }

        private void Print(Processor processor)
        {
            ProcessorTextbox.Text = processor.ToString();
            ProcessorTextbox.Select(0, 0);
            MemoryTextbox.Text = processor.Memory.ToString();
            MemoryTextbox.Select(0, 0);
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            SelectInstruction(_currentSelected, false);
            var isSelected = SelectInstruction(_processor.ProgramCounter.Value.ToString(),true);
            if (isSelected)
            {
                ExecuteButton.Enabled = true;
                NextButton.Enabled = false;
            }
            else
            {
                ExecuteButton.Enabled = false;
                NextButton.Enabled = false;
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            _processor.FetchInstruction(true);
            var binary = _processor.InstructionRegister.Value.ToBinary(16);
            var instruction = _factory.Create(binary);
            instruction.Execute(_processor);

            Print(_processor);
            ExecuteButton.Enabled = false;
            NextButton.Enabled = true;
        }


    }
}
