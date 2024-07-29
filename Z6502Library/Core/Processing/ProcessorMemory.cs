using Z6502.Core.Bases;
using Z6502.Core.Extensions;
using Z6502.Core.Logging;
using Z6502.Core.Processing.Registers;

namespace Z6502.Core.Processing;

public class ProcessorMemory : Memory {
    public Register16 ProgramCounter = new(0, 0xFFFC, "ProgramCounter");
    public Register8 StackPointer = new(0, 0b0100, "StackPointer");

    public Register8 Accumulator = new(0, 0, "Accumulator");
    public Register8 IndexRegisterX = new(0, 0, "IndexRegisterX");
    public Register8 IndexRegisterY = new(0, 0, "IndexRegisterY");

    public Register8 CarryFlag = new(0, 0, "CarryFlag");
    public Register8 ZeroFlag = new(0, 0, "ZeroFlag");
    public Register8 NegativeFlag = new(0, 0, "NegativeFlag");
    public Register8 OverflowFlag = new(0, 0, "OverflowFlag");
    public Register8 InterruptDisable = new(0, 0, "InterruptDisable");
    public Register8 DecimalMode = new(0, 0, "DecimalMode");

    public ProcessorMemory(int memoryCapacity, Processor parent) : base(memoryCapacity, parent) => Logger.LogInfo($"Memory Initialized with capacity of {((long) memoryCapacity).SizeSuffix(2)}", "Memory");

    public byte FetchByte() {
        byte data = this.Data[this.ProgramCounter];
        this.ProgramCounter.Increment();
        this.Parent.DecrementCycles();

        return data;
    }

    public byte GetByte() {
        byte data = this.Data[this.ProgramCounter];
        this.Parent.DecrementCycles();

        return data;
    }

    public byte ReadByte(int address) {
        byte data = this.Data[address];
        this.Parent.DecrementCycles();

        return data;
    }

    public ushort FetchShort() => 0;

    public ushort GetShort() => 0;

    public byte ReadShort(int address) => 0;

    public uint FetchInt() => 0;

    public uint GetInt() => 0;

    public byte ReadInt(int address) => 0;

    public ulong FetchLong() => 0;

    public ulong GetLong() => 0;

    public byte ReadLong(int address) => 0;

    public void SetFlags() {
        Logger.LogDebug("Setting Memory Flags", "Memory");

        if (this.Accumulator.GetRegister() == 0) {
            this.ZeroFlag.SetRegister(1);
        }
        else {
            this.ZeroFlag.SetRegister(0);
        }

        if ((this.Accumulator.GetRegister() & 0b10000000) > 0) {
            this.NegativeFlag.SetRegister(1);
        }
        else {
            this.NegativeFlag.SetRegister(0);
        }

        Logger.LogDebug("Set Memory Flags", "Memory");
    }

    public override void Reset() {
        base.Reset();

        this.ProgramCounter.Reset();
        this.StackPointer.Reset();

        this.Accumulator.Reset();
        this.IndexRegisterX.Reset();
        this.IndexRegisterY.Reset();

        this.CarryFlag.Reset();
        this.ZeroFlag.Reset();
        this.NegativeFlag.Reset();
        this.OverflowFlag.Reset();
        this.InterruptDisable.Reset();
        this.DecimalMode.Reset();
    }
}
