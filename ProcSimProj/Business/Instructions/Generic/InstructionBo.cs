using ProcSimProj.Architecture.CPU;

namespace ProcSimProj.Business.Instructions.Generic
{
    public class InstructionBo : IInstruction
    {
        public string CodeText { get; set; }
        public InstructionCodeBo CodeBo { get; set; }
        public virtual string GetInstructionText()
        {
            return CodeText;
        }
        public virtual void Execute(Processor processor)
        {
            throw new System.NotImplementedException();
        }
    }
}
