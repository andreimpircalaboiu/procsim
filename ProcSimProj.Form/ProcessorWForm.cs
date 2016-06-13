using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProcSimProj.Architecture.CPU;
using ProcSimProj.Architecture.MicroInstructions;
using ProcSimProj.Business.Constants;
using ProcSimProj.Business.Instructions;
using ProcSimProj.Form.Models;

namespace ProcSimProj.Form
{
    public partial class ProcessorWForm : System.Windows.Forms.Form
    {
        private readonly MicroManager _manager;
        private readonly IList<string> _binary;
        private readonly IList<string> _assembly;
        private IList<int> _indexes;
        private readonly IList<InstructionViewModel> _instructions;
        private IList<Microinstruction> _currentMicroinstructions;
        private readonly Processor _processor;
        private int _initialIndex = 4;
        private readonly InstructionFactory _factory;
        private string _instrCurrentSelected;
        private string _microCurrentSelected;
        private int _currentMicroType;

        public ProcessorWForm(IEnumerable<string> binary, IEnumerable<string> assembly, MicroManager manager)
        {
            _manager = manager;
            _binary = binary.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            _assembly = assembly.Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            _processor = new Processor();
            _factory = new InstructionFactory();
            _instructions = new List<InstructionViewModel>();
            _currentMicroType = 0;
            _currentMicroinstructions = new List<Microinstruction>();
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
            SelectInstructionList(_initialIndex.ToString(), true);
            InitMicroListBox(_manager);
            SelectMicroList(_microCurrentSelected, true);
        }

        private void InitMicroListBox(MicroManager manager)
        {
            var microline = manager.Microlines.First();
          
            _currentMicroinstructions = microline.Microinstructions;
            LabelLabel.Text = _currentMicroinstructions[0].Text;
            SetMicroListBox();
        }

        private void SetMicroListBox()
        {
            var counter = 1;
            MicroListBox.Items.Clear();
            foreach (var mit in _currentMicroinstructions.Where(i => i.MicroType != MicrointstructionType.Address))
            {
                this.MicroListBox.Items.Add(new ListViewItem(new string[] {mit.Text, mit.Binary}, (counter).ToString()));
                counter++;
               
            }
            SelectMicroList(_microCurrentSelected, false);
            _microCurrentSelected = 1.ToString();
            SelectMicroList(_microCurrentSelected, true);
        }

        private bool SelectInstructionList(string index, bool state)
        {

            var found = InstructionListBox.Items.Cast<ListViewItem>().FirstOrDefault(i => i.ImageKey == index);
            if (found == null)
            {
                return false;
            }
            InstructionListBox.Items[found.Index].Selected = state;
            _instrCurrentSelected = index;
            return true;
        }

        private bool SelectMicroList(string index, bool state)
        {

            var found = MicroListBox.Items.Cast<ListViewItem>().FirstOrDefault(i => i.ImageKey == index);
            if (found == null)
            {
                return false;
            }
            MicroListBox.Items[found.Index].Selected = state;
            _microCurrentSelected = index;
            return true;
        }

        private void FillListBox()
        {
            foreach (var item in _instructions)
            {
                this.InstructionListBox.Items.Add(new ListViewItem(new string[] { item.Index.ToString(), item.Binary, item.Assembly }, item.Index.ToString()));
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
            SelectInstructionList(_instrCurrentSelected, false);
            SelectInstructionList(_processor.ProgramCounter.Value.ToString(), true);
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            _processor.FetchInstruction(true);
            var binary = _processor.InstructionRegister.Value.ToBinary(16);
            var instruction = _factory.Create(binary);
            instruction.Execute(_processor);

            Print(_processor);
        }

        private void ExecuteMicroButton_Click(object sender, EventArgs e)
        {
            var value = Convert.ToInt32(_microCurrentSelected);
            var currentMicro = _currentMicroinstructions[value];
            currentMicro.Execute(_processor,_factory);
            if (_processor.JumpState == false && currentMicro.MicroType == MicrointstructionType.Succesor)
            {
                GoToStep(value);
            }
            else
            {
                if (currentMicro.MicroType == MicrointstructionType.Conclusion)
                {
                    Step();
                }
                else if (_processor.JumpState && currentMicro.MicroType == MicrointstructionType.Jump)
                {
                    if (_processor.StepState)
                    {
                        Next(value);
                        _processor.StepState = false;
                    }
                    else
                    {
                        Step();
                        _processor.JumpState = false;
                    }
                }
                else
                {
                    Next(value);
                }
            }
            Print(_processor);
          
            
        }

        private void Next(int value)
        {
            SelectMicroList(_microCurrentSelected, false);
            SelectMicroList((++value).ToString(), true);
        }

        private void GoToStep(int value)
        {
            SelectMicroList(_microCurrentSelected, false);
            value = value + 2;
            _microCurrentSelected = (value).ToString();
            SelectMicroList(_microCurrentSelected, true);
        }

        private void Step()
        {
            _currentMicroinstructions = _manager.Microlines.First(i => i.AddressBinary == _processor.Mar).Microinstructions;
            var micro = _currentMicroinstructions[0];
            if (micro.Value == 1)
            {
                var value = Convert.ToInt32(_instrCurrentSelected);
                SelectInstructionList(_instrCurrentSelected, false);
                SelectInstructionList((value++).ToString(), true);
            }
            LabelLabel.Text = micro.Text;
            SetMicroListBox();
        }



    }
}
