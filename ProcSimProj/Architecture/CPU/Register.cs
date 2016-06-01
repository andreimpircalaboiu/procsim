using System;
using ProcSimProj.Architecture.Shared;
using ProcSimProj.Business.Constants;

namespace ProcSimProj.Architecture.CPU
{
    public class Register
    {
        public RegisterType Type { get; set; }
        public short Value { get; set; }
        public string Binary { get { return Value.ToBinary(16); } }
        public int Index { get; set; }
    }
}
