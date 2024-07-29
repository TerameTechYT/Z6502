using Z6502.Core.Bases;
using Z6502.Core.Enums;
using Z6502.Core.Logging;

namespace Z6502.Core.Processing
{
    public class ProcessorInstruction : Instruction
    {
        public ProcessorInstruction(Processor parent, InstructionType instructionType) : base(parent, instructionType)
        {
        }

        public override void Execute()
        {
            base.Execute();

            string? instructionName = Enum.GetName(typeof(InstructionType), InstructionType);
            Logger.LogDebug("Executing Instruction", $"Instruction - {instructionName}");

            switch (InstructionType)
            {
                case InstructionType.LDA_IMMEDIATE:
                    {
                        dynamic data = Parent.Memory.Fetch(FetchType.FetchByte);
                        Parent.Memory.Accumulator.SetRegister(data);
                    }
                    break;
                case InstructionType.LDA_ZEROPAGE:
                    {
                        int address = (int)Parent.Memory.Fetch(FetchType.FetchByte);
                        Logger.LogDebug($"Jump Address 0x{address:X2} ({address})", $"Instruction - {instructionName}");
                        dynamic data = Parent.Memory.Read(ReadType.ReadByte, address);
                        Parent.Memory.Accumulator.SetRegister(data);
                    }
                    break;
                case InstructionType.LDA_ZEROPAGEX:
                    break;
                case InstructionType.LDA_ABSOLUTE:
                    break;
                case InstructionType.LDA_ABSOLUTEX:
                    break;
                case InstructionType.LDA_ABSOLUTEY:
                    break;
                case InstructionType.LDA_INDIRECTX:
                    break;
                case InstructionType.LDA_INDIRECTY:
                    break;
                case InstructionType.INVALID:
                default:
                    {

                        Logger.LogError($"Invalid or Unhandled Instruction: {InstructionType}", "Instruction");
                    }
                    break;
            }
            Logger.LogDebug("Executed Instruction", $"Instruction - {instructionName}");

            SetFlags();
        }

        private void SetFlags()
        {
            Parent.Memory.SetFlags();
        }
    }
}
