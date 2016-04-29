using ProcSimProj.Business.Constants;

namespace ProcSimProj.Business.BOs
{
    public class UnaryInstructionBo : InstructionBo
    {
        public AdressingType DestinationAddressing { get; set; }
        public string Destination { get; set; }
    }
}