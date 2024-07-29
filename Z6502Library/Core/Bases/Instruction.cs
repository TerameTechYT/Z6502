using Z6502.Core.Enums;
using Z6502.Core.Interfaces;
using Z6502.Core.Processing;

namespace Z6502.Core.Bases;

public class Instruction : IInstruction {
    public InstructionType InstructionType { get; set; } = InstructionType.INVALID;

    public Processor Parent {
        get; set;
    }

    public ProcessorMemory Memory {
        get; set;
    }

    public Instruction(Processor parent, InstructionType instructionType) {
        this.Parent = parent;
        this.Memory = this.Parent.Memory;
        this.InstructionType = instructionType;
    }

    public virtual void Execute() {
    }
}
