using ProcSimProj.Architecture.CPU;

namespace ProcSimProj.Architecture.MicroInstructions
{
    public interface IMicroinstruction
    {

        void Execute(Processor processor);
    }
}