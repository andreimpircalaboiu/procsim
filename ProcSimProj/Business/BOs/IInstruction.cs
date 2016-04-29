using System.Security.Cryptography.X509Certificates;
using ProcSimProj.Business.Constants;

namespace ProcSimProj.Business.BOs
{
    public interface IInstruction
    {
        string CodeText { get; set; }
        InstructionCodeBo CodeBo { get; set; }

        InstructionType Type { get; set; }
    }
}