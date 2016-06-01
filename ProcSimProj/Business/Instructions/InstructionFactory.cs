using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProcSimProj.Business.Constants;
using ProcSimProj.Business.Instructions.Generic;
using ProcSimProj.Business.Instructions.Specific;

namespace ProcSimProj.Business.Instructions
{
    public class InstructionFactory
    {
        private List<InstructionCodeBo> _instructionCodes;
        public List<InstructionCodeBo> InstructionCodes
        {
            get
            {
                return _instructionCodes ?? (_instructionCodes = InstructionHelper.GetInstructionCodes());
            }
        }

        public IInstruction Create(string binaryCode)
        {
            if (string.IsNullOrEmpty(binaryCode))
            {
                return null; //TODO REFACTOR ERROR
            }
            var firstPart = binaryCode.Substring(0, 3);
            var first = firstPart.First();
            switch (first)
            {
                case '0':
                    return GetBinaryInstruction(binaryCode);
                case '1':
                    var nextDigits = firstPart.Substring(1, 2);
                    switch (nextDigits)
                    {
                        case "00":
                            return GetUnaryInstruction(binaryCode);
                        case "01":
                            return GetJumpInstruction(binaryCode);
                        case "10":
                            return GetDiverseInstruction(binaryCode);
                        default:
                            return null; //TODO REFACTOR ERROR
                    }
                default:
                    return null; //TODO REFACTOR ERROR
            }
        }

        private IInstruction GetDiverseInstruction(string binaryCode)
        {
            throw new NotImplementedException();
        }

        private IInstruction GetJumpInstruction(string binaryCode)
        {
            throw new NotImplementedException();
        }

        private IInstruction GetUnaryInstruction(string binaryCode)
        {
            var opcode = binaryCode.Substring(0, 10);
            var instructionCode = InstructionCodes.First(i => i.Binary == opcode);
            UnaryInstructionBo bo = InstructionHelper.GetUnaryInstructionByCode(instructionCode);

            var dAdressing = binaryCode.Substring(10, 2);
            bo.DestinationAddressing = InstructionHelper.GetAdressing(dAdressing);

            var destination = binaryCode.Substring(12, 4);
            bo.Destination = destination;
            bo.DestinationValue = Convert.ToInt16(destination, 2);

            return bo;
        }

        private IInstruction GetBinaryInstruction(string binaryCode)
        {
            var opcode = binaryCode.Substring(0, 4);
            var instructionCode = InstructionCodes.First(i => i.Binary == opcode);
            BinaryInstructionBo bo = InstructionHelper.GetBinaryInstructionByCode(instructionCode);

            var dAdressing = binaryCode.Substring(10, 2);
            bo.DestinationAddressing = InstructionHelper.GetAdressing(dAdressing);

            var sAdressing = binaryCode.Substring(4, 2);
            bo.SourceAddressing = InstructionHelper.GetAdressing(sAdressing);

            var source = binaryCode.Substring(6, 4);
            bo.Source = source;
            bo.SourceValue = Convert.ToInt16(source, 2);

            var destination = binaryCode.Substring(12, 4);
            bo.Destination = destination;
            bo.DestinationValue = Convert.ToInt16(destination, 2);

            return bo;
        }

        
    }
}
