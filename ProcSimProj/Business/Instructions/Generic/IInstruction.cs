using ProcSimProj.Architecture.CPU;

namespace ProcSimProj.Business.Instructions.Generic
{
    public interface IInstruction
    {
        string CodeText { get; set; }
        InstructionCodeBo CodeBo { get; set; }
        void Execute(Processor processor);
    }
}