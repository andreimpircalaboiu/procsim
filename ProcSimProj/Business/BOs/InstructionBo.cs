using ProcSimProj.Business.Constants;

namespace ProcSimProj.Business.BOs
{
    public class InstructionBo : IInstruction
    {
        public string CodeText { get; set; }
        public InstructionCodeBo CodeBo { get; set; }
        public InstructionType Type { get; set; }
    }
}
