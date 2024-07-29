using Z6502.Core.Enums;
using Z6502.Core.Interfaces;
using Z6502.Core.Logging;

namespace Z6502.Core.Processing;

public class Processor : IProcessor {
    public ProcessorMemory Memory {
        get; set;
    }

    public int _cycleCount;

    public Processor(int memoryCapacity) => this.Memory = new(memoryCapacity, this);

    public virtual ProcessorInstruction Process() {
        InstructionType type = (InstructionType) this.Memory.FetchByte();

        return new ProcessorInstruction(this, type);
    }

    public virtual void DecrementCycles() {
        this._cycleCount--;

        Logger.LogDebug("Decremented Cycles", "Processor");
    }

    public virtual void Execute(int cycles) {
        this._cycleCount = cycles;

        Logger.LogInfo("Starting Execution Loop", "Processor");
        while (this._cycleCount > 0) {
            ProcessorInstruction instruction = this.Process();

            instruction.Execute();
        }
        Logger.LogInfo("Ended Loop", "Processor");
    }

    public virtual void Reset() {
        this.Memory.Reset();
        Logger.LogDebug("Reset", "Processor");
    }
}
