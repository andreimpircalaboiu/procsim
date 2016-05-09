using System.Collections.Generic;
using ProcSimProj.Architecture.CPU;
using ProcSimProj.Architecture.RAM;

namespace ProcSimProj.Architecture
{
    public static class ArchitectureHelper
    {
        public static IList<Register> InitGeneralRegisters()
        {
            var result = new List<Register>();
            for (int counter = 0; counter < 15; counter++)
            {
                var item = new Register()
                           {
                               Index = counter,
                               Type = RegisterType.General,
                               Value = 0
                           };
                result.Add(item);
            }
            return result;
        }

        public static IList<Location> InitLocations(int numberOfLocations)
        {
            var result = new List<Location>();
            for (int counter = 0; counter < numberOfLocations; counter++)
            {
                var item = new Location()
                           {
                               Index = counter,
                               Data = 0
                           };
                result.Add(item);
            }
            return result;
        }
    }
}