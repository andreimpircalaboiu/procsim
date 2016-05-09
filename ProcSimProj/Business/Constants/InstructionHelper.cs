using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProcSimProj.Business.Instructions.Generic;
using ProcSimProj.Business.Instructions.Specific;
using ProcSimProj.Business.Instructions.Specific.Binary;

namespace ProcSimProj.Business.Constants
{
    public static class InstructionHelper
    {
        public static Regex RegexIndexed
        {
            get { return new Regex("\\(R[0-9]*\\)"); }
        }

        public static Regex RegexIndirect
        {
            get { return new Regex("R[0-9]*"); }
        }

        public static AdressingType GetAdressing(string binaryCode)
        {
            switch (binaryCode)
            {
                case "00":
                    return AdressingType.Direct;
                case "01":
                    return AdressingType.Indirect;
                case "10":
                    return AdressingType.Indexed;
                default:
                    return 0; //TODO REFACTOR ERROR
            }
        }

        public static BinaryInstructionBo GetBinaryInstructionByCode(InstructionCodeBo instructionCode)
        {
            BinaryInstructionBo instruction;
            switch (instructionCode.InstructionCodeType)
            {
                case InstructionCodeType.Mov:
                    instruction = new MovInstruction();
                    break;
                case InstructionCodeType.Add:
                    instruction = new AddInstruction();
                    break;
                case InstructionCodeType.Sub:
                    instruction = new SubInstruction();
                    break;
                case InstructionCodeType.Cmp:
                    instruction = new CmpInstruction();
                    break;
                case InstructionCodeType.And:
                    instruction = new AndInstruction();
                    break;
                case InstructionCodeType.Or:
                    instruction = new OrInstruction();
                    break;
                case InstructionCodeType.Xor:
                    instruction = new XorInstruction();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            instruction.CodeBo = instructionCode;
            return instruction;
        }

        public static List<InstructionCodeBo> GetInstructionCodes()
        {
            return new List<InstructionCodeBo>
                   {
                       new InstructionCodeBo("0000", 0x0, "MOV", InstructionType.Binary, InstructionCodeType.Mov),
                       new InstructionCodeBo("0001", 0x1, "ADD", InstructionType.Binary, InstructionCodeType.Add),
                       new InstructionCodeBo("0010", 0x2, "SUB", InstructionType.Binary, InstructionCodeType.Sub),
                       new InstructionCodeBo("0011", 0x3, "CMP", InstructionType.Binary, InstructionCodeType.Cmp),
                       new InstructionCodeBo("0100", 0x4, "AND", InstructionType.Binary, InstructionCodeType.And),
                       new InstructionCodeBo("0101", 0x5, "OR", InstructionType.Binary, InstructionCodeType.Or),
                       new InstructionCodeBo("0110", 0x6, "XOR", InstructionType.Binary, InstructionCodeType.Xor),
                       new InstructionCodeBo("1000000000", 0x200, "CLR", InstructionType.Unary, InstructionCodeType.Clr),
                       new InstructionCodeBo("1000000001", 0x201, "NEG", InstructionType.Unary, InstructionCodeType.Neg),
                       new InstructionCodeBo("1000000010", 0x202, "INC", InstructionType.Unary, InstructionCodeType.Inc),
                       new InstructionCodeBo("1000000011", 0x204, "DEC", InstructionType.Unary, InstructionCodeType.Dec),
                       new InstructionCodeBo("1000000100", 0x205, "ASL", InstructionType.Unary, InstructionCodeType.Asl),
                       new InstructionCodeBo("1000000101", 0x206, "ASR", InstructionType.Unary, InstructionCodeType.Asr),
                       new InstructionCodeBo("1000000110", 0x207, "LSR", InstructionType.Unary, InstructionCodeType.Lsr),
                       new InstructionCodeBo("1000000111", 0x208, "ROL", InstructionType.Unary, InstructionCodeType.Rol),
                       new InstructionCodeBo("1000001000", 0x209, "ROR", InstructionType.Unary, InstructionCodeType.Ror),
                       new InstructionCodeBo("1000001001", 0x20A, "RLC", InstructionType.Unary, InstructionCodeType.Rlc),
                       new InstructionCodeBo("1000001011", 0x20B, "RRC", InstructionType.Unary, InstructionCodeType.Rrc),
                       new InstructionCodeBo("1000001100", 0x20C, "JMP", InstructionType.Unary, InstructionCodeType.Jmp),
                       new InstructionCodeBo("1000001101", 0x20D, "CALL", InstructionType.Unary, InstructionCodeType.Call),
                       new InstructionCodeBo("1000001110", 0x20E, "PUSH", InstructionType.Unary, InstructionCodeType.Push),
                       new InstructionCodeBo("1000001111", 0x20F, "POP", InstructionType.Unary, InstructionCodeType.Pop),
                       new InstructionCodeBo("10100000", 0xA0, "BR", InstructionType.Jump, InstructionCodeType.Br),
                       new InstructionCodeBo("10100001", 0xA1, "BNE", InstructionType.Jump, InstructionCodeType.Bne),
                       new InstructionCodeBo("10100010", 0xA2, "BEQ", InstructionType.Jump, InstructionCodeType.Beq),
                       new InstructionCodeBo("10100011", 0xA3, "BPL", InstructionType.Jump, InstructionCodeType.Bpl),
                       new InstructionCodeBo("10100100", 0xA4, "BMI", InstructionType.Jump, InstructionCodeType.Bmi),
                       new InstructionCodeBo("10100101", 0xA5, "BCS", InstructionType.Jump, InstructionCodeType.Bcs),
                       new InstructionCodeBo("10100110", 0xA6, "BCC", InstructionType.Jump, InstructionCodeType.Bcc),
                       new InstructionCodeBo("10100111", 0xA7, "BVS", InstructionType.Jump, InstructionCodeType.Bvs),
                       new InstructionCodeBo("10101000", 0xA8, "BVC", InstructionType.Jump, InstructionCodeType.Bvc),
                       new InstructionCodeBo("1100000000000000", 0xC000, "CLC", InstructionType.Diverse, InstructionCodeType.Clc),
                       new InstructionCodeBo("1100000000000001", 0xC001, "CLV", InstructionType.Diverse, InstructionCodeType.Clv),
                       new InstructionCodeBo("1100000000000010", 0xC002, "CLZ", InstructionType.Diverse, InstructionCodeType.Clz),
                       new InstructionCodeBo("1100000000000011", 0xC003, "CLS", InstructionType.Diverse, InstructionCodeType.Cls),
                       new InstructionCodeBo("1100000000000100", 0xC004, "CCC", InstructionType.Diverse, InstructionCodeType.Ccc),
                       new InstructionCodeBo("1100000000000101", 0xC005, "SEC", InstructionType.Diverse, InstructionCodeType.Sec),
                       new InstructionCodeBo("1100000000000110", 0xC006, "SEV", InstructionType.Diverse, InstructionCodeType.Sev),
                       new InstructionCodeBo("1100000000000111", 0xC007, "SEZ", InstructionType.Diverse, InstructionCodeType.Sez),
                       new InstructionCodeBo("1100000000001000", 0xC008, "SES", InstructionType.Diverse, InstructionCodeType.Ses),
                       new InstructionCodeBo("1100000000001001", 0xC009, "SCC", InstructionType.Diverse, InstructionCodeType.Scc),
                       new InstructionCodeBo("1100000000001010", 0xC00A, "NOP", InstructionType.Diverse, InstructionCodeType.Nop),
                       new InstructionCodeBo("1100000000001011", 0xC00B, "RET", InstructionType.Diverse, InstructionCodeType.Ret),
                       new InstructionCodeBo("1100000000001100", 0xC00C, "RETI", InstructionType.Diverse, InstructionCodeType.Reti),
                       new InstructionCodeBo("1100000000001101", 0xC00D, "HALT", InstructionType.Diverse, InstructionCodeType.Halt),
                       new InstructionCodeBo("1100000000001110", 0xC00E, "WAIT", InstructionType.Diverse, InstructionCodeType.Wait),
                       new InstructionCodeBo("1100000000001111", 0xC00F, "PUSH PC", InstructionType.Diverse, InstructionCodeType.PushPc),
                       new InstructionCodeBo("1100000000010000", 0xC010, "POP PC", InstructionType.Diverse, InstructionCodeType.PopPc),
                       new InstructionCodeBo("1100000000010001", 0xC011, "PUSH FLAG", InstructionType.Diverse, InstructionCodeType.PushFlag),
                       new InstructionCodeBo("1100000000010010", 0xC012, "POP FLAG", InstructionType.Diverse, InstructionCodeType.PopFlag),
                   };
        }
    }
}

