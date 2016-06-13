using System;
using ProcSimProj.Architecture.Shared;
using ProcSimProj.Business.Constants;

namespace ProcSimProj.Architecture.CPU
{
    public class UnsignedRegister
    {
        public RegisterType Type { get; set; }
        public ushort Value { get; set; }
        public string Binary { get { return Value.ToBinary(16); } }
        public int Index { get; set; }
    }
}