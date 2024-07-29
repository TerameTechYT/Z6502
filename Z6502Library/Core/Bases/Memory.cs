using Z6502.Core.Extensions;
using Z6502.Core.Interfaces;
using Z6502.Core.Processing;

namespace Z6502.Core.Bases;

public class Memory : IMemory {
    public int MemoryCapacity {
        get; set;
    }

    public Processor Parent {
        get; set;
    }

    public List<byte> Data {
        get; set;
    }

    public Memory(int memoryCapacity, Processor parent) {
        this.MemoryCapacity = memoryCapacity;
        this.Parent = parent;

        this.Data = new(this.MemoryCapacity);
    }

    public virtual void Reset() {
        this.Data.Clear();
        this.Data.FillRange<byte>(0);
    }
}
