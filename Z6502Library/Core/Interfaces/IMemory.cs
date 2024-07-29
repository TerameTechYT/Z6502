using Z6502.Core.Processing;

namespace Z6502.Core.Interfaces;

public interface IMemory {
    Processor Parent {
        get; protected set;
    }

    List<byte> Data {
        get; protected set;
    }

    int MemoryCapacity {
        get; protected set;
    }

    virtual void Reset() {
    }
}
