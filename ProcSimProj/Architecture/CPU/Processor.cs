using System;
using System.Collections.Generic;
using System.Linq;
using ProcSimProj.Architecture.RAM;
using ProcSimProj.Architecture.Shared;
using ProcSimProj.Business.Constants;
using ProcSimProj.Business.Instructions;
using ProcSimProj.Business.Instructions.Generic;

namespace ProcSimProj.Architecture.CPU
{
    public class Processor
    {
        #region Constructor
        public Processor()
        {
            Memory = new Memory();
            GeneralRegisters = ArchitectureHelper.InitGeneralRegisters();
            Flags = new UnsignedRegister()
                    {
                        Index = 0,
                        Value = 0,
                        Type = RegisterType.Flags
                    };
            ProgramCounter = new UnsignedRegister()
                             {
                                 Index = 0,
                                 Value = 0,
                                 Type = RegisterType.ProgramCounter
                             };
            StackPointer = new UnsignedRegister()
                           {
                               Index = 0,
                               Value = 0,
                               Type = RegisterType.StackPointer
                           };
            Adr = new UnsignedRegister()
                  {
                      Index = 0,
                      Value = 0,
                      Type = RegisterType.Adr
                  };
            Mdr = new Register()
                  {
                      Index = 0,
                      Value = 0,
                      Type = RegisterType.Mdr
                  };
            InstructionRegister = new UnsignedRegister()
                                  {
                                      Index = 0,
                                      Value = 0,
                                      Type = RegisterType.InstructionRegister
                                  };
            Temp = new Register()
                   {
                       Index = 0,
                       Value = 0,
                       Type = RegisterType.Temp
                   };
        }
        #endregion

        #region Public Attributes

        public Memory Memory { get; set; }
        public IList<Register> GeneralRegisters { get; set; }
        public UnsignedRegister Flags { get; set; }
        public UnsignedRegister ProgramCounter { get; set; }
        public UnsignedRegister Adr { get; set; }
        public Register Mdr { get; set; }
        public Register Temp { get; set; }
        public UnsignedRegister StackPointer { get; set; }
        public UnsignedRegister InstructionRegister { get; set; }
        public short Dbus { get; set; }
        public short Sbus { get; set; }
        public short Rbus { get; set; }
        public bool JumpState { get; set; }
        public string Mar { get; set; }
        public bool StepState { get; set; }

        #endregion

        #region Public Methods

        public short GetRegisterValueFromInstructionRegister(MicrointstructionType type, InstructionFactory factory)
        {
            switch (type)
            {
                case MicrointstructionType.Sbus:
                    {
                        var instruction = factory.Create(InstructionRegister.Binary);
                        if (instruction.CodeBo.InstructionType == InstructionType.Binary)
                        {
                            return ((BinaryInstructionBo)instruction).SourceValue;
                        }
                        else if (instruction.CodeBo.InstructionType == InstructionType.Unary)
                        {
                            return ((UnaryInstructionBo)instruction).DestinationValue;
                        }
                        return 0;
                    }
                    break;
                case MicrointstructionType.Dbus:
                    {
                        var instruction = factory.Create(InstructionRegister.Binary);
                        if (instruction.CodeBo.InstructionType == InstructionType.Binary)
                        {
                            return ((BinaryInstructionBo)instruction).DestinationValue;
                        }
                        else if (instruction.CodeBo.InstructionType == InstructionType.Unary)
                        {
                            return ((UnaryInstructionBo)instruction).DestinationValue;
                        }
                        return 0;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public IList<int> LoadInstructionsInMemory(IList<string> instructions, int index)
        {
            var result = new List<int>();
            ProgramCounter.Value = (ushort)(index - 2);
            foreach (var instruction in instructions)
            {
                Memory.WriteUnsigned(index, Convert.ToUInt16(instruction, 2));
                result.Add(index);
                index += 2;
            }
            return result;
        }

        public void FetchInstruction(bool withoutMicroinstructions)
        {
            if (withoutMicroinstructions)
            {
                Adr.Value = ProgramCounter.Value;
            }
            var value = Memory.ReadUnsigned(ProgramCounter.Value);
            if (withoutMicroinstructions)
            {
                ProgramCounter.Value += 2;
            }
            InstructionRegister.Value = value;
        }

        public short FetchOperand(AdressingType type, short index)
        {
            switch (type)
            {
                case AdressingType.Direct:
                    return index;
                case AdressingType.Indirect:
                    return ReadGeneralRegister(index);
                case AdressingType.Indexed:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        private short ReadGeneralRegister(int index)
        {
            return GeneralRegisters.First(i => i.Index == index).Value;
        }

        public void WriteGeneralRegister(int index, short value)
        {
            GeneralRegisters.First(i => i.Index == index).Value = value;
        }

        public void PushStack(short value)
        {
            StackPointer.Value += 2;
            Memory.WriteSigned(StackPointer.Value, value);
        }

        public short PopStack()
        {
            var result = Memory.ReadSigned(StackPointer.Value);
            StackPointer.Value -= 2;
            return result;
        }

        public void SetZeroFlag(bool value)
        {
            Flags.Value = (ushort)(value
                ? Flags.Value | (ushort)1
                : Flags.Value & (ushort)(Math.Pow(2, 16) - 2));
        }

        public void SetSignFlag(bool value)
        {
            Flags.Value = (ushort)(value
                ? Flags.Value | (ushort)2
                : Flags.Value & (ushort)(Math.Pow(2, 16) - 3));
        }

        public void SetOverflowFlag(bool value)
        {
            Flags.Value = (ushort)(value
                ? Flags.Value | (ushort)4
                : Flags.Value & (ushort)(Math.Pow(2, 16) - 5));
        }

        public void SetCarryFlag(bool value)
        {
            Flags.Value = (ushort)(value
                ? Flags.Value | (ushort)8
                : Flags.Value & (ushort)(Math.Pow(2, 16) - 9));
        }

        public bool GetZeroFlag()
        {
            var flag = Flags.Value & 1;
            return flag == 1;
        }

        public bool GetSignFlag()
        {
            var flag = Flags.Value & 2;
            return flag == 1;
        }

        public bool GetOverflowFlag()
        {
            var flag = Flags.Value & 4;
            return flag == 1;
        }

        public bool GetCarryFlag()
        {
            var flag = Flags.Value & 8;
            return flag == 1;
        }

        public override string ToString()
        {
            var init = string.Format("IR:\t {0}" + Environment.NewLine + "PC:\t {1}" + Environment.NewLine + "ADR:\t {2}" + Environment.NewLine + "MDR:\t {3}" + Environment.NewLine + "SP:\t {4}" + Environment.NewLine + "FLAGS:\t {5}" + Environment.NewLine + "DBUS:\t {6}" + Environment.NewLine + "SBUS:\t {7}" + Environment.NewLine + "RBUS:\t {8}" + Environment.NewLine, InstructionRegister.Binary, ProgramCounter.Binary, Adr.Binary, Mdr.Binary, StackPointer.Binary, Flags.Binary, Dbus.ToBinary(16), Sbus.ToBinary(16), Rbus.ToBinary(16));
            return GeneralRegisters.Aggregate(init, (current, reg) => current + string.Format("R{0}:\t {1}" + Environment.NewLine, reg.Index, reg.Binary));
        }

        #endregion
    }
}