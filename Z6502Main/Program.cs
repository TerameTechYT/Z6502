using Z6502.Core.Enums;
using Z6502.Core.Logging;
using Z6502.Core.Processing;

namespace Z6502Main
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await Logger.InitalizeLog();

            Processor processor = new(64 * 1024);
            processor.Reset();


            int programCounter = (int)processor.Memory.ProgramCounter.GetRegister();
            processor.Memory.Data[programCounter] = (byte)InstructionType.LDA_IMMEDIATE;
            processor.Memory.Data[programCounter + 1] = 0x42;

            processor.Memory.Data[programCounter + 2] = (byte)InstructionType.LDA_ZEROPAGE;
            processor.Memory.Data[programCounter + 3] = 0x84;
            processor.Memory.Data[0x0084] = 0x42;

            processor.Execute(5);
        }
    }
}
