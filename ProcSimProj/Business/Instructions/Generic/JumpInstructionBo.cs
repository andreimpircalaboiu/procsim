namespace ProcSimProj.Business.Instructions.Generic
{
    public class JumpInstructionBo : InstructionBo
    {
        public string Offset { get; set; }

        public override string GetInstructionText()
        {
            return CodeText.PadLeft(8,'0') + Offset.PadLeft(8, '0');
        }
    }
}