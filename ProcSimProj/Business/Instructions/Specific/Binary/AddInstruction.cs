using System;
using ProcSimProj.Architecture.CPU;
using ProcSimProj.Business.Instructions.Generic;

namespace ProcSimProj.Business.Instructions.Specific.Binary
{
    public class AddInstruction : BinaryInstructionBo
    {
        public override void Execute(Processor processor)
        {
            processor.Dbus = processor.FetchOperand(this.DestinationAddressing, this.DestinationValue);
            processor.Sbus = processor.FetchOperand(this.SourceAddressing, this.SourceValue);
            var result = (short)(processor.Dbus + processor.Sbus);
            processor.WriteGeneralRegister(this.DestinationValue,result);
        }
    }
}