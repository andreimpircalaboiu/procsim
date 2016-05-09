using System;

namespace ProcSimProj.Architecture.CPU
{
    public class Register
    {
        public RegisterType Type { get; set; }
        public short Value { get; set; }
        public string Binary { get { return Convert.ToString(Value, 2).PadLeft(16, '0'); } }
        public int Index { get; set; }
    }

    public enum RegisterType
    {
        General,
        Negative,
        Flags,
        ProgramCounter,
        Mdr,
        Adr,
        StackPointer,
        InstructionRegister
    }
}
