using ProcSimProj.Business.Constants;

namespace ProcSimProj.Business.BOs
{
    public class BinaryInstructionBo : InstructionBo
    {
        public AdressingType SourceAddressing { get; set; }
        public string Source { get; set; }
        public AdressingType DestinationAddressing { get; set; }
        public string Destination { get; set; }
    }
}
