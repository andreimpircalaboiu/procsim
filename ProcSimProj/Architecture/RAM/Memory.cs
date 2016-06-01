using System;
using System.Collections.Generic;
using System.Linq;
using ProcSimProj.Architecture.Shared;

namespace ProcSimProj.Architecture.RAM
{
    public class Memory
    {
        public Memory()
        {
            Locations = ArchitectureHelper.InitLocations(4096);
        }

        public IList<Location> Locations { get; set; }

        public ushort ReadUnsigned(int index)
        {
            var locations = Locations.Where(i => i.Index == index || i.Index == (index + 1)).ToList();
            var first = locations.First().Data;
            var last = locations.Last().Data;
            if (first != null && last != null)
            {
                return (ushort)(first.Value + last.Value * Math.Pow(2, 8));
            }
            else
            {
                return 0;
            }
        }

        public short ReadSigned(int index)
        {
            var locations = Locations.Where(i => i.Index == index || i.Index == (index + 1)).ToList();
            var first = locations.First().Data;
            var last = locations.Last().Data;
            if (first != null && last != null)
            {
                return (short)(first.Value + last.Value * Math.Pow(2, 8));
            }
            else
            {
                return 0;
            }
        }

        public void WriteUnsigned(int index, ushort value)
        {
            var locations = Locations.Where(i => i.Index == index || i.Index == (index + 1)).ToList();
            locations.First().Data = (byte)(value & (short)Math.Pow(2, 8)-1);
            locations.Last().Data = (byte)(value / (short)Math.Pow(2, 8));
        }

        public void WriteSigned(int index, short value)
        {
            var locations = Locations.Where(i => i.Index == index || i.Index == (index + 1)).ToList();
            locations.First().Data = (byte)(value & (short)Math.Pow(2, 8) - 1);
            locations.Last().Data = (byte)(value / (short)Math.Pow(2, 8));
        }

        public void WriteUnsigned(ushort value)
        {
            var emptyLocations = Locations.Where(i => i.Data == null).OrderBy(i => i.Index).ToList();
            for (var counter = 0; counter < emptyLocations.Count(); counter++)
            {
                if ((counter + 1) < emptyLocations.Count() && (emptyLocations[counter].Index + 1) == (emptyLocations[counter + 1].Index))
                {
                    emptyLocations[counter].Data = (byte)(value & (short)Math.Pow(2, 8) - 1);
                    emptyLocations[counter + 1].Data = (byte)(value / (short)Math.Pow(2, 8));
                    return;
                }
            }
        }

        public void WriteSigned(ushort value)
        {
            var emptyLocations = Locations.Where(i => i.Data == null).OrderBy(i=>i.Index).ToList();
            for (var counter = 0; counter < emptyLocations.Count(); counter++)
            {
                if ((counter + 1) < emptyLocations.Count() && (emptyLocations[counter].Index + 1) == (emptyLocations[counter + 1].Index))
                {
                    emptyLocations[counter].Data = (byte)(value & (short)Math.Pow(2, 8)-1);
                    emptyLocations[counter+1].Data = (byte)(value / (short)Math.Pow(2, 8));
                    return;
                }
            }
        }

        public override string ToString()
        {
            var result = string.Empty;
            for (int index = 0; index < Locations.Count; index++)
            {
                if (index%2 == 0)
                {
                    result += String.Format("{0}:\t {1}", index, Locations[index].Binary);
                }
                else
                {
                    result += String.Format(" {0}{1}", Locations[index].Binary ,Environment.NewLine);
                }
            }
            return result;
        }
    }
}