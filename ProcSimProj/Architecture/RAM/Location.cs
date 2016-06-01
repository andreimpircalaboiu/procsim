using System;
using ProcSimProj.Business.Constants;

namespace ProcSimProj.Architecture.RAM
{
    public class Location
    {
        public int Index { get; set; }
        public byte? Data { get; set; }

        public string Binary
        {
            get
            {
                return Data != null
                    ? Data.Value.ToBinary(8)
                    : ((byte)0).ToBinary(8);
            }
        }

    }
}