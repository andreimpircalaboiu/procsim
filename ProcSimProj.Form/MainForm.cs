using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcSimProj.Business.Constants;
using ProcSimProj.Business.Instructions.Generic;
using ProcSimProj.Business.Responses;
using ProcSimProj.Converter;

namespace ProcSimProj.Form
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static string InputText
        {
            get
            {
                return @"
                         CMP R0,(R1)
                         AND R2,R4 
                         OR R1,(R5) 
                         XOR R3,R0
                        ";
            }
        }


        private void InputButton_Click(object sender, EventArgs e)
        {
            foreach (var line in InputTextBox.Lines)
            {
                var response = BinaryConverter.ConvertFromAssembly(line);
                if (response.HasErrors)
                {
                    ParsedInputTextbox.Text += response.GetErrorText();
                    return;
                }
                var text = GetInstructionText(response);
                ParsedInputTextbox.Text += text + Environment.NewLine;
            }
        }

        private static string GetInstructionText(ItemResponseBo<IInstruction> response)
        {
            var result = string.Empty;
            switch (response.Result.CodeBo.InstructionType)
            {
                case InstructionType.Binary:
                    var binary = (BinaryInstructionBo)response.Result;
                    result = binary.GetInstructionText();
                    break;
                case InstructionType.Unary:
                    var unary = (UnaryInstructionBo)response.Result;
                    result = unary.GetInstructionText();
                    break;
                case InstructionType.Jump:
                    var jump = (JumpInstructionBo)response.Result;
                    result = jump.GetInstructionText();
                    break;
                case InstructionType.Diverse:
                    var diverse = (DiverseInstructionBo)response.Result;
                    result = diverse.GetInstructionText();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return result;
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            var binary = ParsedInputTextbox.Lines.ToList();
            var assembly = InputTextBox.Lines.ToList();
            var form = new ProcessorForm(binary, assembly);
            form.Show();
        }
    }
}
