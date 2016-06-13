using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcSimProj.Business.Constants;

namespace ProcSimProj.Architecture.MicroInstructions
{
    public class MicroManager
    {
        public IList<Microline> Microlines { get; set; }

        public MicroManager()
        {
            Microlines = new List<Microline>();
        }

        public void SetJumpAddresses()
        {
            foreach (var line in Microlines)
            {
                var jump = line.Microinstructions.First(i => i.MicroType == MicrointstructionType.Jump);
                if (jump.SpecificType != (int) BaseType.None)
                {
                    var jumpValue = Microlines.First(i => i.AddressText == jump.Token + "+0").Microinstructions.First(m => m.MicroType == MicrointstructionType.Address).Value;
                    jump.Binary = jumpValue.ToBinary(8) + " + " + InstructionHelper.GetStringForIndex(jump.AdditionalSpecificType);
                    jump.Value = jumpValue;
                }
            }
        }

        public void SetStepAddresses()
        {
            foreach (var line in Microlines)
            {
                var step = line.Microinstructions.First(i => i.MicroType == MicrointstructionType.Conclusion);
                var address = line.Microinstructions.First(i => i.MicroType == MicrointstructionType.Address);
                if (step.SpecificType == 1)
                {
                    step.Binary = address.Value.ToBinary(8) + " + " + ((short)1).ToBinary(8);
                    step.Value = address.Value;
                }
            }
        }
    }
}
