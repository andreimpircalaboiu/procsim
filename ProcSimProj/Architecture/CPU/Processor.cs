using System;
using System.Collections.Generic;
using System.Linq;
using ProcSimProj.Architecture.RAM;

namespace ProcSimProj.Architecture.CPU
{
    public class Processor
    {
        #region Constructor
        public Processor()
        {
            Memory = new Memory();
            GeneralRegisters = ArchitectureHelper.InitGeneralRegisters();
            Flags = new Register()
                    {
                        Index = 0,
                        Value = 0,
                        Type = RegisterType.Flags
                    };
            ProgramCounter = new Register()
                             {
                                 Index = 0,
                                 Value = 0,
                                 Type = RegisterType.ProgramCounter
                             };
            StackPointer = new Register()
                           {
                               Index = 0,
                               Value = 0,
                               Type = RegisterType.StackPointer
                           };
            Adr = new Register()
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
            InstructionRegister = new Register()
                                  {
                                      Index = 0,
                                      Value = 0,
                                      Type = RegisterType.InstructionRegister
                                  };
        }
        #endregion

        #region Public Attributes

        public Memory Memory { get; set; }
        public IList<Register> GeneralRegisters { get; set; }
        public Register Flags { get; set; }
        public Register ProgramCounter { get; set; }
        public Register Adr { get; set; }
        public Register Mdr { get; set; }
        public Register StackPointer { get; set; }
        public Register InstructionRegister { get; set; }

        #endregion

        #region Public Methods

        public IList<int> LoadInstructionsInMemory(IList<string> instructions, int index)
        {
            var result = new List<int>();
            ProgramCounter.Value = (short)index;
            foreach (var instruction in instructions)
            {
                Memory.Write(index, Convert.ToInt16(instruction, 2));
                result.Add(index);
                index += 2;
            }
            return result;
        }

        public void FetchInstruction(int index)
        {
            Adr.Value = (short)index;
            var value = Memory.Read(index);
            Mdr.Value = value;
            ProgramCounter.Value += 2;
            InstructionRegister.Value = value;
        }

        public short ReadGeneralRegister(int index)
        {
            return GeneralRegisters.First(i=>i.Index == index).Value;
        }

        public void WriteGeneralRegister(int index, short value)
        {
            GeneralRegisters.First(i => i.Index == index).Value = value;
        }

        public void PushStack(short value)
        {
            StackPointer.Value += 2;
            Memory.Write(StackPointer.Value, value);
        }

        public short PopStack()
        {
            var result = Memory.Read(StackPointer.Value);
            StackPointer.Value -= 2;
            return result;
        }

        public void SetNegativeFlag(bool value)
        {
            Flags.Value = (short)(value
                ? Flags.Value | (short)1
                : Flags.Value & (short)(Math.Pow(2, 16) - 2));
        }

        public void SetSignFlag(bool value)
        {
            Flags.Value = (short)(value
                ? Flags.Value | (short)2
                : Flags.Value & (short)(Math.Pow(2, 16) - 3));
        }

        public void SetVFlag(bool value)
        {
            Flags.Value = (short)(value
                ? Flags.Value | (short)4
                : Flags.Value & (short)(Math.Pow(2, 16) - 5));
        }

        public void SetCarryFlag(bool value)
        {
            Flags.Value = (short)(value
                ? Flags.Value | (short)8
                : Flags.Value & (short)(Math.Pow(2, 16) - 9));
        }

        public bool GetNegativeFlag()
        {
            var flag = Flags.Value & 1;
            return flag == 1;
        }

        public bool GetSignFlag()
        {
            var flag = Flags.Value & 2;
            return flag == 1;
        }
        public bool GetVFlag()
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
            var init =
                string.Format("IR: {0}" + Environment.NewLine +
                              "PC: {1}" + Environment.NewLine +
                              "ADR: {2}" + Environment.NewLine +
                              "MDR: {3}" + Environment.NewLine +
                              "SP: {4}" + Environment.NewLine +
                              "FLAGS: {5}" + Environment.NewLine, InstructionRegister.Binary, ProgramCounter.Binary, Adr.Binary, Mdr.Binary, StackPointer.Binary, Flags.Binary);
            return GeneralRegisters.Aggregate(init, (current, reg) => current + string.Format("R{0}: {1}" + Environment.NewLine, reg.Index, reg.Binary));
        }

        #endregion


    }
}