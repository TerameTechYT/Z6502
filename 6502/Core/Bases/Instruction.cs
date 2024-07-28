using Z6502.Core.Enums;
using Z6502.Core.Interfaces;
using Z6502.Core.Processing;

namespace Z6502.Core.Bases
{
    internal class Instruction : IInstruction
    {
        public InstructionType InstructionType { get; set; } = InstructionType.INVALID;

        public Processor Parent { get; set; }

        public Instruction(Processor parent, InstructionType instructionType)
        {
            Parent = parent;
            InstructionType = instructionType;
        }

        public virtual void Execute()
        {
        }
    }
}
