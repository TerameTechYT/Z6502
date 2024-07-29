using Z6502.Core.Processing;

namespace Z6502.Core.Interfaces
{
    public interface IProcessor
    {
        ProcessorMemory Memory { get; protected set; }

        virtual void Execute() { }
        virtual void Reset() { }
    }
}
