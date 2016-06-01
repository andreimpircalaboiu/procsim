using System;
using ProcSimProj.Business.Constants;

namespace ProcSimProj.Business.Instructions.Generic
{
    public class BinaryInstructionBo : InstructionBo
    {
        public AdressingType SourceAddressing { get; set; }
        public string Source { get; set; }
        public short SourceValue { get; set; }
        public AdressingType DestinationAddressing { get; set; }
        public string Destination { get; set; }
        public short DestinationValue { get; set; }
        public override string GetInstructionText()
        {
            return CodeText.PadLeft(4, '0') + Convert.ToString((int)SourceAddressing, 2).PadLeft(2, '0') + Source.PadLeft(4, '0') + Convert.ToString((int)DestinationAddressing, 2).PadLeft(2, '0') + Destination.PadLeft(4, '0');
        }

    }
}
