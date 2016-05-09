using System;

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
                    ? Convert.ToString(Data.Value, 2).PadLeft(8, '0')
                    : "00000000";
            }
        }

    }
}