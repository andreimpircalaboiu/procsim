using System;
using System.Net.Http.Headers;

namespace ProcSimProj.Business.Constants
{
    public static class InstructionExtensions
    {
        public static string ToBinary(this ushort value, int totalBits)
        {
            return Convert.ToString(value, 2).PadLeft(totalBits, '0');
        }

        public static string ToBinary(this short value, int totalBits)
        {
            return Convert.ToString(value, 2).PadLeft(totalBits, '0');
        }

        public static string ToBinary(this byte value, int totalBits)
        {
            return Convert.ToString(value, 2).PadLeft(totalBits, '0');
        }

        public static byte ToByte(this string value)
        {
            return Convert.ToByte(value,2);
        }
    }
}
