namespace ProcSimProj.Business.Constants
{
    public enum ErrorType
    {
        TechnicalError = 1,
        UnrecognizedOpcode,
        BinaryInstructionMustBeFormedFromThreeElementsOnly,
        UnaryInstructionMustBeFormedFromTwoElementsOnly,
        JumpInstructionMustBeFormedFromTwoElementsOnly,
        DiverseInstructionMustBeFormedFromOneElementOnly,
        UnknownDestination,
        UnknownSource
    }
}