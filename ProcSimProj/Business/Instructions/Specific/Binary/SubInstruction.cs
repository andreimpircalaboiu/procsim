using ProcSimProj.Architecture.CPU;
using ProcSimProj.Business.Instructions.Generic;

namespace ProcSimProj.Business.Instructions.Specific.Binary
{
    public class SubInstruction : BinaryInstructionBo
    {
        public override short Execute(Processor processor)
        {
            return 0;
        }
    }
}