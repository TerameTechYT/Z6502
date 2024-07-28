using Z6502.Core.Processing;

namespace Z6502.Core.Interfaces
{
    internal interface IMemory
    {
        int MemoryCapacity { get; protected set; }

        Processor Parent { get; protected set; }

        List<byte> Data { get; protected set; }

        virtual void Reset() { }
    }
}
