using System;
using System.Linq;
using System.Text.RegularExpressions;
using ProcSimProj.Business.Constants;
using ProcSimProj.Business.Generics;
using ProcSimProj.Business.Instructions.Generic;
using ProcSimProj.Business.Requests;
using ProcSimProj.Business.Responses;

namespace ProcSimProj.Converter
{
    public static class BinaryConverter
    {
        public static ItemResponseBo<IInstruction> ConvertFromAssembly(string line)
        {
            var response = new ItemResponseBo<IInstruction>();
            try
            {
                if (string.IsNullOrEmpty(line)) return response;

                line = line.Trim(' ');

                var instructions = InstructionHelper.GetInstructionCodes();

                var items = line.Split(' ', ',');

                if (items[0] == null) return response;

                var opcodeText = items[0].ToUpper();

                if (opcodeText == "PUSH" || opcodeText == "POP")
                {
                    var exception = items.ToArray();
                    exception[0] = exception[0] + " " + exception[1];
                    exception[1] = exception[2];
                    exception[2] = null;
                    items = exception;
                    opcodeText = items[0];
                }
                
                var opcode = instructions.FirstOrDefault(i => i.Text == opcodeText);

                if (opcode == null)
                {
                    response.AddError(new ErrorBo()
                    {
                        ErrorType = ErrorType.UnrecognizedOpcode,
                        ObjectType = typeof(InstructionBo),
                        Text = String.Format("The operation code {0} cannot be parsed by this application", opcodeText)
                    });

                    return response;
                }
                
                response = GetInstructionFromOpcode(opcode, items, response, line);
            }
            catch (Exception e)
            {
                response.AddError(new ErrorBo { ErrorType = ErrorType.TechnicalError, ObjectType = typeof(InstructionBo), Text = e.ToString() });
            }
            return response;
        }

        private static ItemResponseBo<IInstruction> GetInstructionFromOpcode(InstructionCodeBo opcode, string[] items, ItemResponseBo<IInstruction> response,string line)
        {
            switch (opcode.InstructionType)
            {
                case InstructionType.Binary:
                {
                    var instruction = new BinaryInstructionBo
                    {
                        CodeBo = opcode,
                        CodeText = opcode.Binary
                    };
                    return GetInstructionForBinary(opcode, items, instruction, response, line);
                }

                case InstructionType.Unary:
                {
                    var instruction = new UnaryInstructionBo
                    {
                        CodeBo = opcode,
                        CodeText = opcode.Binary
                    };
                    return GetInstructionForUnary(opcode, items, instruction, response, line);
                }

                case InstructionType.Jump:
                {
                    var instruction = new JumpInstructionBo
                    {
                        CodeBo = opcode,
                        CodeText = opcode.Binary
                    };
                    return GetInstructionForJump(opcode, items, instruction, response, line);
                }

                case InstructionType.Diverse:
                {
                    var instruction = new DiverseInstructionBo
                    {
                        CodeBo = opcode,
                        CodeText = opcode.Binary
                    };
                    return GetInstructionForDiverse(items, response, instruction, line);
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static ItemResponseBo<IInstruction> GetInstructionForDiverse(string[] items, ItemResponseBo<IInstruction> response,
            DiverseInstructionBo instruction, string line)
        {
            if (items.Length != 1)
            {
                response.AddError(new ErrorBo()
                {
                    ErrorType = ErrorType.DiverseInstructionMustBeFormedFromOneElementOnly,
                    ObjectType = typeof (InstructionBo),
                    Text = String.Format("Diverse instructions must be formed from one elementy only. Faulty expression: {0}", line)
                });

                return response;
            }
            response.Result = instruction;
            return response;
        }

        private static ItemResponseBo<IInstruction> GetInstructionForJump(InstructionCodeBo opcode, string[] items, JumpInstructionBo instruction, ItemResponseBo<IInstruction> response, string line)
        {
            if (items.Length != 2)
            {
                response.AddError(new ErrorBo()
                {
                    ErrorType = ErrorType.JumpInstructionMustBeFormedFromTwoElementsOnly,
                    ObjectType = typeof(InstructionBo),
                    Text = String.Format("Jump instructions must be two from two elements only: Opcode and Offset. Faulty expression: {0}", line)
                });

                return response;
            }
            instruction.Offset = Convert.ToString(Convert.ToInt32(items[1]), 2);
            response.Result = instruction;
            return response;
        }

        private static ItemResponseBo<IInstruction> GetInstructionForUnary(InstructionCodeBo opcode, string[] items, UnaryInstructionBo instruction, ItemResponseBo<IInstruction> response, string line)
        {
            if (items.Length != 2)
            {
                response.AddError(new ErrorBo()
                {
                    ErrorType = ErrorType.UnaryInstructionMustBeFormedFromTwoElementsOnly,
                    ObjectType = typeof(InstructionBo),
                    Text = String.Format("Unary instructions must be formed from two elements only: Opcode and Destination. Faulty expression: {0}", line)
                });

                return response;
            }

            var destinationText = items[1].ToUpper();

            if (InstructionHelper.RegexIndexed.IsMatch(destinationText))
            {
                instruction.DestinationAddressing = AdressingType.Indexed;
                var number = GetNumber(destinationText);
                instruction.Destination = Convert.ToString(number, 2);

            }
            else if (InstructionHelper.RegexIndirect.IsMatch(destinationText))
            {
                instruction.DestinationAddressing = AdressingType.Indirect;
                var number = GetNumber(destinationText);
                instruction.Destination = Convert.ToString(number, 2);
            }
            else
            {
                response.AddError(new ErrorBo()
                {
                    ErrorType = ErrorType.UnknownDestination,
                    ObjectType = typeof(InstructionBo),
                    Text = String.Format("This is not a valid destination {0} in expression: {1}", destinationText, line)
                });
                return response;
            }
            response.Result = instruction;
            return response;
        }

        private static ItemResponseBo<IInstruction>  GetInstructionForBinary(InstructionCodeBo opcode, string[] items, BinaryInstructionBo instruction, ItemResponseBo<IInstruction> response, string line)
        {
            if (items.Length != 3)
            {
                response.AddError(new ErrorBo()
                {
                    ErrorType = ErrorType.BinaryInstructionMustBeFormedFromThreeElementsOnly,
                    ObjectType = typeof(InstructionBo),
                    Text = String.Format("Binary instructions must be formed from three elements only: Opcode, Source and Destination. Faulty expression: {0}", line)
                });

                return response;
            }

            var sourceText = items[1];

            if (InstructionHelper.RegexIndexed.IsMatch(sourceText))
            {
                instruction.SourceAddressing = AdressingType.Indexed;
                var number = GetNumber(sourceText);
                instruction.Source = Convert.ToString(number, 2);
            }
            else if (InstructionHelper.RegexIndirect.IsMatch(sourceText))
            {
                instruction.SourceAddressing = AdressingType.Indirect;
                var number = GetNumber(sourceText);
                instruction.Source = Convert.ToString(number, 2);
            }
            else
            {
                response.AddError(new ErrorBo()
                {
                    ErrorType = ErrorType.UnknownSource,
                    ObjectType = typeof(InstructionBo),
                    Text = String.Format("This is not a valid source {0} in expression: {1}", sourceText, line)
                });
                return response;
            }

            var destinationText = items[2];

            if (InstructionHelper.RegexIndexed.IsMatch(destinationText))
            {
                instruction.DestinationAddressing = AdressingType.Indexed;
                var number = GetNumber(destinationText);
                instruction.Destination = Convert.ToString(number, 2);
            }
            else if (InstructionHelper.RegexIndirect.IsMatch(destinationText))
            {
                instruction.DestinationAddressing = AdressingType.Indirect;
                var number = GetNumber(destinationText);
                instruction.Destination = Convert.ToString(number, 2);
            }
            else
            {
                response.AddError(new ErrorBo()
                {
                    ErrorType = ErrorType.UnknownDestination,
                    ObjectType = typeof(InstructionBo),
                    Text = String.Format("This is not a valid destination {0} in expression: {1}", destinationText, line)
                });
                return response;
            }
            response.Result = instruction;
            return response;
        }

        public static int GetNumber(string text)
        {
            var exp = new Regex("(\\d+)");
            var matches = exp.Matches(text);

            if (matches.Count == 1)
            {
                int number =  int.Parse(matches[0].Value);
                return number;
            }
            else if (matches.Count > 1)
                throw new InvalidOperationException("only one number allowed");
            else
                return 0;
        }
    }
}
