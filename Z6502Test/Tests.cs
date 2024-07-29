using Z6502.Core.Enums;
using Z6502.Core.Processing;

namespace Z6502Test;

[TestClass]
[TestCategory("JSR")]
public class JSRTests {
    [TestMethod]
    public void JSR_ABSOLUTE() {
        Processor processor = new(64 * 1024);
        processor.Reset();

        processor.Memory.WriteByte((byte) InstructionType.JSR_ABSOLUTE);
        processor.Memory.WriteShort(0x4242);

        processor.Memory.WriteByte(0x4242, (byte) InstructionType.LDA_IMMEDIATE);
        processor.Memory.WriteByte(0x4243, 0x84);

        processor.Memory.ProgramCounter.Reset();
        processor.Execute(9);
    }
}

[TestClass]
[TestCategory("LDA")]
public class LDATests {

    [TestMethod]
    public void LDA_IMMEDIATE() {
        Processor processor = new(64 * 1024);
        processor.Reset();

        processor.Memory.WriteByte((byte) InstructionType.LDA_IMMEDIATE);
        processor.Memory.WriteByte(0x84);

        processor.Memory.ProgramCounter.Reset();
        processor.Execute(2);
    }

    [TestMethod]
    public void LDA_ZEROPAGE() {
        Processor processor = new(64 * 1024);
        processor.Reset();

        processor.Memory.WriteByte((byte) InstructionType.LDA_ZEROPAGE);
        processor.Memory.WriteByte(0x42);
        processor.Memory.WriteByte(0x42, 0x84);

        processor.Memory.ProgramCounter.Reset();
        processor.Execute(3);
    }

    [TestMethod]
    public void LDA_ZEROPAGEX() {
        Processor processor = new(64 * 1024);
        processor.Reset();

        processor.Memory.IndexRegisterX.SetRegister(2);

        processor.Memory.WriteByte((byte) InstructionType.LDA_ZEROPAGEX);
        processor.Memory.WriteByte(0x42);
        processor.Memory.WriteByte(0x44, 0x84);

        processor.Memory.ProgramCounter.Reset();
        processor.Execute(3);
    }
}