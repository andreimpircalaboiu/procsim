namespace ProcSimProj.Business.Instructions.Generic
{
    public class DiverseInstructionBo : InstructionBo
    {
        public override string GetInstructionText()
        {
            return CodeText.PadLeft(16, '0');
        }
    }
}