using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProcSimProj.Architecture.CPU;
using ProcSimProj.Architecture.Shared;
using ProcSimProj.Business.Constants;
using ProcSimProj.Business.Instructions;
using ProcSimProj.Business.Instructions.Generic;

namespace ProcSimProj.Architecture.MicroInstructions
{
    public class Microinstruction
    {
        public string Binary { get; set; }
        public string Text { get; set; }
        public MicrointstructionType MicroType { get; set; }
        public short Value { get; set; }
        public bool SignChanged { get; set; }
        public int SpecificType { get; set; }
        public int AdditionalSpecificType { get; set; }
        public string Token { get; set; }
        public IList<MicroOperation> Operations { get; set; }

        public void Execute(Processor processor, InstructionFactory factory)
        {
            switch (MicroType)
            {
                case MicrointstructionType.Sbus:
                    ExecuteSbus(processor, factory);
                    break;
                case MicrointstructionType.Dbus:
                    ExecuteDbus(processor, factory);
                    break;
                case MicrointstructionType.Alu:
                    ExecuteAlu(processor);
                    break;
                case MicrointstructionType.Rbus:
                    ExecuteRbus(processor);
                    break;
                case MicrointstructionType.Other:
                    ExecuteOther(processor);
                    break;
                case MicrointstructionType.Memory:
                    ExecuteMemory(processor);
                    break;
                case MicrointstructionType.Conclusion:
                    ExecuteStep(processor);
                    break;
                case MicrointstructionType.Jump:
                    ExecuteJump(processor);
                    break;
                case MicrointstructionType.Succesor:
                    ExecuteSuccesor(processor, factory);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ExecuteStep(Processor processor)
        {
            switch (SpecificType)
            {
                case 1:
                    {
                        processor.Mar = ((short)(Value + 1)).ToBinary(8);
                    }
                    break;
                default:
                    break;
            }
        }

        private short GetJumpAddress(Processor processor)
        {
            switch ((IndexType)AdditionalSpecificType)
            {
                case IndexType.Index0:
                {
                    processor.StepState = true;
                        return (short)(Value + 0);
                    }
                case IndexType.Index1:
                    {
                        var binary = processor.InstructionRegister.Binary.Substring(8, 6);
                        var offsetValue = binary.ToByte() * 2;
                        return (short)(Value + offsetValue);
                    }
                case IndexType.Index2:
                    {
                        var binary = processor.InstructionRegister.Binary.Substring(4, 2);
                        var offsetValue = binary.ToByte() * 2;
                        return (short)(Value + offsetValue);
                    }
                case IndexType.Index3:
                    {
                        var binary = processor.InstructionRegister.Binary.Substring(10, 2);
                        var offsetValue = binary.ToByte() * 2;
                        return (short)(Value + offsetValue);
                    }
                case IndexType.Index4:
                    {
                        var binary = processor.InstructionRegister.Binary.Substring(6, 8);
                        var offsetValue = binary.ToByte() * 2;
                        return (short)(Value + offsetValue);
                    }
                case IndexType.Index5:
                    {
                        var binary = processor.InstructionRegister.Binary.Substring(12, 3);
                        var offsetValue = binary.ToByte() * 2;
                        return (short)(Value + offsetValue);
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void CreateJumpAddress(Processor processor)
        {
            processor.Mar = GetJumpAddress(processor).ToBinary(8);
        }

        private void ExecuteJump(Processor processor)
        {
            if (processor.JumpState)
            {
                CreateJumpAddress(processor);
            }
        }

        private void ExecuteSuccesor(Processor processor, InstructionFactory factory)
        {
            switch ((SuccesorType)SpecificType)
            {
                case SuccesorType.None:
                    processor.JumpState = true;
                    break;
                case SuccesorType.BTwo:
                    {
                        var instruction = factory.Create(processor.InstructionRegister.Binary);
                        if (instruction.CodeBo.InstructionType == InstructionType.Unary && !SignChanged)
                        {
                            processor.JumpState = true;
                        }
                    }
                    break;
                case SuccesorType.Int:
                    break;
                case SuccesorType.BOne:
                    break;
                case SuccesorType.Nz:
                    break;
                case SuccesorType.Z:
                    break;
                case SuccesorType.Ns:
                    break;
                case SuccesorType.Nc:
                    break;
                case SuccesorType.V:
                    break;
                case SuccesorType.Nv:
                    break;
                case SuccesorType.Spcode:
                    {
                        var instruction = factory.Create(processor.InstructionRegister.Binary);
                        if (instruction.CodeBo.InstructionType == InstructionType.Jump && !SignChanged)
                        {
                            processor.JumpState = true;
                        }
                    }
                    break;
                case SuccesorType.Rd:
                    break;
                case SuccesorType.NotRd:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ExecuteMemory(Processor processor)
        {
            switch ((MemoryType)SpecificType)
            {
                case MemoryType.None:
                    break;
                case MemoryType.Ifch:
                    processor.FetchInstruction(false);
                    break;
                case MemoryType.Write:
                    break;
                case MemoryType.Read:
                    processor.Mdr.Value = processor.Memory.ReadSigned(processor.Adr.Value);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ExecuteOther(Processor processor)
        {
            switch ((OtherType)SpecificType)
            {
                case OtherType.None:
                    break;
                case OtherType.Plus2Pc:
                    processor.ProgramCounter.Value = (ushort)(processor.ProgramCounter.Value + 2);
                    break;
                case OtherType.Plus2Sp:
                    processor.StackPointer.Value = (ushort)(processor.StackPointer.Value + 2);
                    break;
                case OtherType.Minus2Sp:
                    processor.StackPointer.Value = (ushort)(processor.StackPointer.Value - 2);
                    break;
                case OtherType.PdCond:
                    break;
                case OtherType.CinPdCond:
                    break;
                case OtherType.AZeroC:
                    processor.SetCarryFlag(false);
                    break;
                case OtherType.AZeroV:
                    processor.SetOverflowFlag(false);
                    break;
                case OtherType.AZeroZ:
                    processor.SetZeroFlag(false);
                    break;
                case OtherType.AZeroS:
                    processor.SetSignFlag(false);
                    break;
                case OtherType.AOneC:
                    processor.SetCarryFlag(true);
                    break;
                case OtherType.AOneV:
                    processor.SetOverflowFlag(true);
                    break;
                case OtherType.AOneZ:
                    processor.SetZeroFlag(true);
                    break;
                case OtherType.AOneS:
                    processor.SetSignFlag(true);
                    break;
                case OtherType.AOneCvzs:
                    {
                        processor.SetCarryFlag(true);
                        processor.SetOverflowFlag(true);
                        processor.SetZeroFlag(true);
                        processor.SetSignFlag(true);
                    }
                    break;
                case OtherType.AZeroCvzs:
                    {
                        processor.SetCarryFlag(false);
                        processor.SetOverflowFlag(false);
                        processor.SetZeroFlag(false);
                        processor.SetSignFlag(false);
                    }
                    break;
                case OtherType.AOneBvi:
                    break;
                case OtherType.AZeroBvi:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ExecuteRbus(Processor processor)
        {
            switch ((RbusType)SpecificType)
            {
                case RbusType.None:
                    break;
                case RbusType.PmAdr:
                    processor.Adr.Value = (ushort)processor.Rbus;
                    break;
                case RbusType.PmT:
                    processor.Temp.Value = processor.Rbus;
                    break;
                case RbusType.PmMdr:
                    processor.Mdr.Value = processor.Rbus;
                    break;
                case RbusType.PmGpr:
                    break;
                case RbusType.PmPc:
                    processor.ProgramCounter.Value = (ushort)processor.Rbus;
                    break;
                case RbusType.PmFlag:
                    processor.Flags.Value = (ushort)processor.Rbus;
                    break;
                case RbusType.PmIvr:
                    break;
                case RbusType.PmSp:
                    processor.StackPointer.Value = (ushort)processor.Rbus;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ExecuteAlu(Processor processor)
        {
            switch ((AluType)SpecificType)
            {
                case AluType.None:
                    break;
                case AluType.Sbus:
                    processor.Rbus = (short)(processor.Sbus);
                    break;
                case AluType.Dbus:
                    processor.Rbus = (short)(processor.Dbus);
                    break;
                case AluType.NotSbus:
                    processor.Rbus = (short)-(processor.Sbus);
                    break;
                case AluType.NotDbus:
                    processor.Rbus = (short)-(processor.Dbus);
                    break;
                case AluType.Sum:
                    processor.Rbus = (short)(processor.Dbus + processor.Sbus);
                    break;
                case AluType.And:
                    processor.Rbus = (short)(processor.Dbus & processor.Sbus);
                    break;
                case AluType.Or:
                    processor.Rbus = (short)(processor.Dbus | processor.Sbus);
                    break;
                case AluType.Xor:
                    break;
                case AluType.Neg:
                    processor.Rbus = (short)(processor.Dbus | processor.Sbus);
                    break;
                case AluType.Clr:
                    processor.Rbus = 0;
                    break;
                case AluType.Inc:
                    processor.Rbus = (short)(processor.Dbus++);
                    break;
                case AluType.Dec:
                    processor.Rbus = (short)(processor.Dbus--);
                    break;
                case AluType.Asl:
                    break;
                case AluType.Asr:
                    break;
                case AluType.Lsr:
                    break;
                case AluType.Rol:
                    break;
                case AluType.Ror:
                    break;
                case AluType.Rlc:
                    break;
                case AluType.Rrc:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ExecuteDbus(Processor processor, InstructionFactory factory)
        {
            switch ((DbusType)SpecificType)
            {
                case DbusType.None:
                    break;
                case DbusType.Pd0:
                    processor.Dbus = 0;
                    break;
                case DbusType.PdGpr:
                    processor.Dbus = processor.GetRegisterValueFromInstructionRegister(MicrointstructionType.Dbus, factory);
                    break;
                case DbusType.PdMdr:
                    processor.Dbus = processor.Mdr.Value;
                    break;
                case DbusType.PdT:
                    processor.Dbus = processor.Temp.Value;
                    break;
                case DbusType.PdNt:
                    break;
                case DbusType.PdSp:
                    processor.Dbus = (short)processor.StackPointer.Value;
                    break;
                case DbusType.PdFlag:
                    processor.Dbus = (short)processor.Flags.Value;
                    break;
                case DbusType.PdIvr:
                    break;
                case DbusType.PdPc:
                    processor.Dbus = (short)processor.ProgramCounter.Value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ExecuteSbus(Processor processor, InstructionFactory factory)
        {
            switch ((SbusType)SpecificType)
            {
                case SbusType.None:
                    break;
                case SbusType.Pd0:
                    processor.Sbus = 0;
                    break;
                case SbusType.PdGpr:
                    processor.Dbus = processor.GetRegisterValueFromInstructionRegister(MicrointstructionType.Dbus, factory);
                    break;
                case SbusType.PdMdr:
                    break;
                case SbusType.PdMinus1:
                    processor.Sbus = -1;
                    break;
                case SbusType.PdPlus1:
                    processor.Sbus = 1;
                    break;
                case SbusType.PdIr:
                    processor.Sbus = (short)processor.InstructionRegister.Value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
