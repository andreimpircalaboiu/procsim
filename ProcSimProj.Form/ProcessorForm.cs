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
using ProcSimProj.Form.Models;

namespace ProcSimProj.Form
{
    public partial class ProcessorForm : System.Windows.Forms.Form
    {
        private readonly IList<string> _binary;
        private readonly IList<string> _assembly;
        private IList<int> _indexes;
        private IList<InstructionViewModel> _instructions;
        private Processor _processor;

        public ProcessorForm(IList<string> binary, IList<string> assembly)
        {
            _binary = binary.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            _assembly = assembly.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            _processor = new Processor();
            _instructions = new List<InstructionViewModel>();
            InitializeComponent();
        }

        private void ProcessorForm_Load(object sender, EventArgs e)
        {
            _indexes = _processor.LoadInstructionsInMemory(_binary, 4);
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
        }

        private void FillListBox()
        {
            foreach (var item in _instructions)
            {
                this.InstructionListBox.Items.Add(new ListViewItem(new string[] { item.Index.ToString(), item.Binary, item.Assembly }));

            }
        }

        private void Print(Processor processor)
        {
            ProcessorTextbox.Text = processor.ToString();
            MemoryTextbox.Text = processor.Memory.ToString();
        }


    }
}
