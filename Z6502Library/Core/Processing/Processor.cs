using Z6502.Core.Enums;
using Z6502.Core.Interfaces;
using Z6502.Core.Logging;

namespace Z6502.Core.Processing
{
    public class Processor : IProcessor
    {
        public ProcessorMemory Memory { get; set; }

        public int _cycleCount;

        public Processor(int memoryCapacity)
        {
            Memory = new(memoryCapacity, this);
        }

        public virtual ProcessorInstruction Process()
        {
            InstructionType type = (InstructionType)Memory.Fetch(FetchType.FetchByte);

            return new ProcessorInstruction(this, type);
        }

        public virtual void DecrementCycles()
        {
            _cycleCount--;

            Logger.LogDebug("Decremented Cycles", "Processor");
        }

        public virtual void Execute(int cycles)
        {
            _cycleCount = cycles;

            Logger.LogInfo("Starting Execution Loop", "Processor");
            while (_cycleCount > 0)
            {
                ProcessorInstruction instruction = Process();
                instruction.Execute();
            }
            Logger.LogInfo("Ended Loop", "Processor");
        }

        public virtual void Reset()
        {
            Memory.Reset();
            Logger.LogDebug("Reset", "Processor");
        }
    }
}
