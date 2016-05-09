using ProcSimProj.Business.Constants;

namespace ProcSimProj.Business.Instructions.Generic
{
    public class InstructionCodeBo
    {
        public InstructionCodeBo(string binary, int hex, string text, InstructionType instructionType,
            InstructionCodeType instructionCodeType)
        {
            Binary = binary;
            Hex = hex;
            Text = text;
            InstructionType = instructionType;
            InstructionCodeType = instructionCodeType;
        }

        public string Binary { get; private set; }
        public int Hex { get; private set; }
        public string Text { get; private set; }
        public InstructionType InstructionType { get; private set; }
        public InstructionCodeType InstructionCodeType { get; private set; }
    }
}