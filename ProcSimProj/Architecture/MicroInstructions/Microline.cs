using System;
using System.Collections.Generic;
using System.Linq;
using ProcSimProj.Business.Constants;
using ProcSimProj.Business.Instructions.Generic;

namespace ProcSimProj.Architecture.MicroInstructions
{
    public class Microline
    {
        private readonly IList<MicroOperation> _allOperations;
        private string _code { get; set; }
        private readonly IList<string> _mits;
        private List<MicroOperation> _operations;
        private readonly IList<Microinstruction> _microinstructions;
        public IList<Microinstruction> Microinstructions { get { return _microinstructions; } }

        public int Id { get; set; }

        public Microline(string line, IList<MicroOperation> allOperations)
        {
            _allOperations = allOperations;
            _operations = new List<MicroOperation>();
            _microinstructions = new List<Microinstruction>();
            _mits = new List<string>();
            var temp = new List<string>();

            _code = line;
            temp = line.Split(',').ToList();

            foreach (var mit in temp)
            {
                _mits.Add(mit.Trim());
            }

            CreateAddress();
            CreateSbus();
            CreateDbus();
            CreateAlu();
            CreateRbus();
            CreateOther();
            CreateMemory();
            CreateSuccesor();
            CreateJump();
            CreateConclusion();


        }

        private void CreateJump()
        {
            var temp = new List<MicroOperation>();
            for (var counter = 10; counter <= 11; counter++)
            {
                temp.Add(_allOperations.First(i => string.Equals(i.Text, _mits[counter], StringComparison.CurrentCultureIgnoreCase) && i.MicroType == MicrointstructionType.Jump));
            }

            var offset = temp[0];
            var baseAddress = temp[1];
            _operations.AddRange(temp);
            _microinstructions.Add(new Microinstruction()
            {
                SpecificType = baseAddress.Value,
                MicroType = MicrointstructionType.Jump,
                Operations = temp,
                AdditionalSpecificType = offset.Value,
                Text = baseAddress.Text + " + " + offset.Text,
                Token = baseAddress.Text
            });
        }

        private void CreateConclusion()
        {
            var temp = new List<MicroOperation>();
            var item = _mits[12];
            temp.Add(_allOperations.First(i => string.Equals(i.Text, item, StringComparison.CurrentCultureIgnoreCase) && i.MicroType == MicrointstructionType.Conclusion));
            var conclusion = temp[0];
            _operations.AddRange(temp);
            _microinstructions.Add(new Microinstruction()
            {
                Binary = conclusion.Value.ToBinary(1),
                Value = conclusion.Value,
                SpecificType = conclusion.Value,
                MicroType = MicrointstructionType.Conclusion,
                Operations = temp,
                Text = item
            });
         
        }

        private void CreateSuccesor()
        {
            var temp = new List<MicroOperation>();
            for (var counter = 8; counter <= 9; counter++)
            {
                temp.Add(_allOperations.First(i => string.Equals(i.Text, _mits[counter], StringComparison.CurrentCultureIgnoreCase) && i.MicroType == MicrointstructionType.Succesor));
            }

            var succesor = temp[0];
            var signChanged = false;
            var sign = temp[1];
            byte signValue = 0;
            var signText = "";
            if (sign.Value == (int) SignType.F)
            {
                signValue = 16;
                signText = "!";
                signChanged = true;
            }
            _operations.AddRange(temp);
            _microinstructions.Add(new Microinstruction()
                                   {
                                       Binary = ((byte)(signValue + succesor.Value)).ToBinary(5),
                                       Value = (byte)(signValue + succesor.Value),
                                       SpecificType = temp[0].Value,
                                       MicroType = MicrointstructionType.Succesor,
                                       Operations = temp,
                                       SignChanged = signChanged,
                                       Text = signText + _mits[8]
                                   });
        }

        private void CreateMemory()
        {
            var temp = new List<MicroOperation>();
            var item = _mits[7];
            var operation = _allOperations.First(i => string.Equals(i.Text, item, StringComparison.CurrentCultureIgnoreCase) && i.MicroType == MicrointstructionType.Memory);
            temp.Add(operation);
            _operations.AddRange(temp);
            _microinstructions.Add(new Microinstruction()
                                   {
                                       Binary = operation.Value.ToBinary(2),
                                       Value = operation.Value,
                                       SpecificType = operation.Value,
                                       MicroType = MicrointstructionType.Memory,
                                       Operations = temp,
                                       Text = item
                                   });
        }

        private void CreateOther()
        {
            var temp = new List<MicroOperation>();
            var item = _mits[6];
            var operation = _allOperations.First(i => string.Equals(i.Text, item, StringComparison.CurrentCultureIgnoreCase) && i.MicroType == MicrointstructionType.Other);
            temp.Add(operation);
            _operations.AddRange(temp);
            _microinstructions.Add(new Microinstruction()
                                   {
                                       Binary = operation.Value.ToBinary(5),
                                       Value = operation.Value,
                                       SpecificType = operation.Value,
                                       MicroType = MicrointstructionType.Other,
                                       Operations = temp,
                                       Text = item
                                   });
        }

        private void CreateAddress()
        {
            var temp = new List<MicroOperation>();
            var label = _mits[0];
            var offset = _mits[1];
            var operation = _allOperations.First(i => string.Equals(i.Text, label, StringComparison.CurrentCultureIgnoreCase) && i.MicroType == MicrointstructionType.Address);
            var operationValue = (byte) (operation.Value + Convert.ToByte(offset));
            Id = operationValue;
            temp.Add(operation);
            _operations.AddRange(temp);
            _microinstructions.Add(new Microinstruction()
                                   {
                                       Binary = operationValue.ToBinary(8),
                                       Value = operationValue,
                                       SpecificType = operation.Value,
                                       MicroType = MicrointstructionType.Address,
                                       Operations = temp,
                                       Text = label + "+" + offset
                                   });

        }

        private void CreateSbus()
        {
            var temp = new List<MicroOperation>();
            var item = _mits[2];
            var operation = _allOperations.First(i => string.Equals(i.Text, item, StringComparison.InvariantCultureIgnoreCase) && i.MicroType == MicrointstructionType.Sbus);
            temp.Add(operation);
            _operations.AddRange(temp);
            _microinstructions.Add(new Microinstruction()
                                   {
                                       Binary = operation.Value.ToBinary(3),
                                       Value = operation.Value,
                                       SpecificType = operation.Value,
                                       MicroType = MicrointstructionType.Sbus,
                                       Operations = temp,
                                       Text = item
                                   });
        }

        private void CreateDbus()
        {
            var temp = new List<MicroOperation>();
            var item = _mits[3];
            var operation = _allOperations.First(i => string.Equals(i.Text, item, StringComparison.CurrentCultureIgnoreCase) && i.MicroType == MicrointstructionType.Dbus);
            temp.Add(operation);
            _operations.AddRange(temp);
            _microinstructions.Add(new Microinstruction()
                                   {
                                       Binary = operation.Value.ToBinary(4),
                                       Value = operation.Value,
                                       SpecificType = operation.Value,
                                       MicroType = MicrointstructionType.Dbus,
                                       Operations = temp,
                                       Text = item
                                   });
        }

        private void CreateAlu()
        {
            var temp = new List<MicroOperation>();
            var item = _mits[4];
            var operation = _allOperations.First(i => string.Equals(i.Text, item, StringComparison.CurrentCultureIgnoreCase) && i.MicroType == MicrointstructionType.Alu);
            temp.Add(operation);
            _operations.AddRange(temp);
            _microinstructions.Add(new Microinstruction()
                                   {
                                       Binary = operation.Value.ToBinary(5),
                                       Value = operation.Value,
                                       SpecificType = operation.Value,
                                       MicroType = MicrointstructionType.Alu,
                                       Operations = temp,
                                       Text = item
                                   });
        }

        private void CreateRbus()
        {
            var temp = new List<MicroOperation>();
            var item = _mits[5];
            var operation = _allOperations.First(i => string.Equals(i.Text, item, StringComparison.CurrentCultureIgnoreCase) && i.MicroType == MicrointstructionType.Rbus);
            temp.Add(operation);
            _operations.AddRange(temp);
            _microinstructions.Add(new Microinstruction()
                                   {
                                       Binary = operation.Value.ToBinary(4),
                                       Value = operation.Value,
                                       SpecificType = operation.Value,
                                       MicroType = MicrointstructionType.Rbus,
                                       Operations = temp,
                                       Text = item
                                   });
        }

        public string AddressBinary { get { return _microinstructions[0].Binary; } }
        public string AddressText { get { return _microinstructions[0].Text; } }

        public string SbusBinary { get { return _microinstructions[1].Binary; } }
        public string SbusText { get { return _microinstructions[1].Text; } }

        public string DbusBinary { get { return _microinstructions[2].Binary; } }
        public string DbusText { get { return _microinstructions[2].Text; } }

        public string AluBinary { get { return _microinstructions[3].Binary; } }
        public string AluText { get { return _microinstructions[3].Text; } }

        public string RbusBinary { get { return _microinstructions[4].Binary; } }
        public string RbusText { get { return _microinstructions[4].Text; } }

        public string OtherBinary { get { return _microinstructions[5].Binary; } }
        public string OtherText { get { return _microinstructions[5].Text; } }

        public string MemoryBinary { get { return _microinstructions[6].Binary; } }
        public string MemoryText { get { return _microinstructions[6].Text; } }

        public string SuccesorBinary { get { return _microinstructions[7].Binary; } }
        public string SuccesorText { get { return _microinstructions[7].Text; } }

        public string JumpBinary { get { return _microinstructions[8].Binary; } }
        public string JumpText { get { return _microinstructions[8].Text; } }

        public string ConclusionBinary { get { return _microinstructions[9].Binary; } }
        public string ConclusionText { get { return _microinstructions[9].Text; } }
    
    }
}