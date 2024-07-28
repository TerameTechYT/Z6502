using Z6502.Core.Enums;
using Z6502.Core.Processing;

namespace Z6502.Core.Interfaces
{
    internal interface IInstruction
    {
        InstructionType InstructionType { get; protected set; }

        Processor Parent { get; protected set; }

        virtual void Execute() { }
    }
}
