using System;
using ProcSimProj.Business.Constants;

namespace ProcSimProj.Business.Instructions.Generic
{
    public class UnaryInstructionBo : InstructionBo
    {
        public AdressingType DestinationAddressing { get; set; }
        public string Destination { get; set; }
        public short DestinationValue { get; set; }

        public override string GetInstructionText()
        {
            return CodeText.PadLeft(10, '0') + Convert.ToString((int)DestinationAddressing).PadLeft(2,'0') + Destination.PadLeft(4,'0');
        }
    }
}