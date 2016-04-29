using System;
using System.Linq;
using System.Text.RegularExpressions;
using ProcSimProj.Business.BOs;
using ProcSimProj.Business.Constants;
using ProcSimProj.Business.Requests;
using ProcSimProj.Business.Responses;

namespace ProcSimProj.Converter
{
    public class BinaryConverter
    {
        public static ItemResponseBo<IInstruction> ConvertFromAssembly(string line)
        {
            var response = new ItemResponseBo<IInstruction>() { Result = new InstructionBo() };
            try
            {
                if (string.IsNullOrEmpty(line)) return response;

                var instructions = InstructionHelper.GetInstructionCode();

                var items = line.Split(' ', ',');

                if (items[0] == null) return response;

                var opcodeText = items[0].ToUpper();

                var opcode = instructions.FirstOrDefault(i => i.Text == opcodeText);

                if (opcode == null)
                {
                    response.AddError(new ErrorBo()
                    {
                        ErrorType = ErrorType.UnrecognizedOpcode,
                        ObjectType = typeof(InstructionBo),
                        Text = $"The operation code {opcodeText} cannot be parsed by this application"
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
                        Type = InstructionType.Binary,
                        CodeBo = opcode,
                        CodeText = opcode.Text
                    };
                    return GetInstructionForBinary(opcode, items, instruction, response, line);
                }

                case InstructionType.Unary:
                {
                    var instruction = new UnaryInstructionBo
                    {
                        Type = InstructionType.Unary,
                        CodeBo = opcode,
                        CodeText = opcode.Text
                    };
                    return GetInstructionForUnary(opcode, items, instruction, response, line);
                }

                case InstructionType.Jump:
                {
                    var instruction = new JumpInstructionBo
                    {
                        Type = InstructionType.Jump,
                        CodeBo = opcode,
                        CodeText = opcode.Text
                    };
                    return GetInstructionForJump(opcode, items, instruction, response, line);
                }

                case InstructionType.Diverse:
                {
                    var instruction = new DiverseInstructionBo()
                    {
                        Type = InstructionType.Diverse,
                        CodeBo = opcode,
                        CodeText = opcode.Text
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
                    Text = $"Diverse instructions must be formed from one elementy only. Faulty expression: {line}"
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
                    Text = $"Jump instructions must be two from two elements only: Opcode and Offset. Faulty expression: {line}"
                });

                return response;
            }
            var destinationText = items[1];

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
                    Text = $"Unary instructions must be formed from two elements only: Opcode and Destination. Faulty expression: {line}"
                });

                return response;
            }

            var destinationText = items[1].ToUpper();

            if (InstructionHelper.RegexIndexed.IsMatch(destinationText))
            {
                instruction.DestinationAddressing = AdressingType.Indexed;
            }
            else if (InstructionHelper.RegexIndirect.IsMatch(destinationText))
            {
                instruction.DestinationAddressing = AdressingType.Indirect;
            }
            else
            {
                response.AddError(new ErrorBo()
                {
                    ErrorType = ErrorType.UnknownDestination,
                    ObjectType = typeof(InstructionBo),
                    Text = $"This is not a valid destination {destinationText} in expression: {line}"
                });
                return response;
            }
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
                    Text = $"Binary instructions must be formed from three elements only: Opcode, Source and Destination. Faulty expression: {line}"
                });

                return response;
            }

            var sourceText = items[1];

            if (InstructionHelper.RegexIndexed.IsMatch(sourceText))
            {
                instruction.DestinationAddressing = AdressingType.Indexed;
            }
            else if (InstructionHelper.RegexIndirect.IsMatch(sourceText))
            {
                instruction.DestinationAddressing = AdressingType.Indirect;
            }
            else
            {
                response.AddError(new ErrorBo()
                {
                    ErrorType = ErrorType.UnknownSource,
                    ObjectType = typeof(InstructionBo),
                    Text = $"This is not a valid source {sourceText} in expression: {line}"
                });
                return response;
            }

            var destinationText = items[2];

            if (InstructionHelper.RegexIndexed.IsMatch(destinationText))
            {
                instruction.DestinationAddressing = AdressingType.Indexed;
            }
            else if (InstructionHelper.RegexIndirect.IsMatch(destinationText))
            {
                instruction.DestinationAddressing = AdressingType.Indirect;
            }
            else
            {
                response.AddError(new ErrorBo()
                {
                    ErrorType = ErrorType.UnknownDestination,
                    ObjectType = typeof(InstructionBo),
                    Text = $"This is not a valid destination {destinationText} in expression: {line}"
                });
                return response;
            }

            return response;
        }
    }
}
