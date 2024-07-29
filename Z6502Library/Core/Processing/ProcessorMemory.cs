using Z6502.Core.Bases;
using Z6502.Core.Enums;
using Z6502.Core.Extensions;
using Z6502.Core.Logging;
using Z6502.Core.Processing.Registers;

namespace Z6502.Core.Processing;

public class ProcessorMemory : Memory {
    public Register8 ProgramCounter = new("ProgramCounter", RegisterType.SixteenBit, 0, 0xFFFC);
    public Register8 StackPointer = new("StackPointer", RegisterType.EightBit, 0, 0x0100);

    public Register8 Accumulator = new("Accumulator", RegisterType.EightBit, 0, 0);
    public Register8 IndexRegisterX = new("IndexRegisterX", RegisterType.EightBit, 0, 0);
    public Register8 IndexRegisterY = new("IndexRegisterY", RegisterType.EightBit, 0, 0);

    public Register8 CarryFlag = new("CarryFlag", RegisterType.EightBit, 0, 0);
    public Register8 ZeroFlag = new("ZeroFlag", RegisterType.EightBit, 0, 0);
    public Register8 NegativeFlag = new("NegativeFlag", RegisterType.EightBit, 0, 0);
    public Register8 OverflowFlag = new("OverflowFlag", RegisterType.EightBit, 0, 0);
    public Register8 InterruptDisable = new("InterruptDisable", RegisterType.EightBit, 0, 0);
    public Register8 DecimalMode = new("DecimalMode", RegisterType.EightBit, 0, 0);

    public ProcessorMemory(int memoryCapacity, Processor parent) : base(memoryCapacity, parent) => Logger.LogInfo($"Memory Initialized with capacity of {((long) memoryCapacity).SizeSuffix(2)}", "Memory");

    public dynamic Fetch(FetchType fetchType) => fetchType switch {
        FetchType.FetchByte => this.FetchByte(),
        FetchType.GetByte => this.GetByte(),

        FetchType.FetchShort => this.FetchShort(),
        FetchType.GetShort => this.GetShort(),

        FetchType.FetchInt => this.FetchInt(),
        FetchType.GetInt => this.GetInt(),

        FetchType.FetchLong => this.FetchLong(),
        FetchType.GetLong => this.GetLong(),

        _ => throw new NotImplementedException(),
    };

    public dynamic Read(ReadType fetchType, int address) => fetchType switch {
        ReadType.ReadByte => this.ReadByte(address),
        ReadType.ReadShort => this.ReadShort(address),
        ReadType.ReadInt => this.ReadInt(address),
        ReadType.ReadLong => this.ReadLong(address),

        _ => throw new NotImplementedException(),
    };

    private byte FetchByte() {
        byte data = this.Data[this.ProgramCounter.RegisterValue];
        this.ProgramCounter.Increment();
        this.Parent.DecrementCycles();

        return data;
    }

    private byte GetByte() {
        byte data = this.Data[this.ProgramCounter.RegisterValue];
        this.Parent.DecrementCycles();

        return data;
    }

    private byte ReadByte(int address) {
        byte data = this.Data[address];
        this.Parent.DecrementCycles();

        return data;
    }

    private ushort FetchShort() => 0;

    private ushort GetShort() => 0;

    private byte ReadShort(int address) => 0;

    private uint FetchInt() => 0;

    private uint GetInt() => 0;

    private byte ReadInt(int address) => 0;

    private ulong FetchLong() => 0;

    private ulong GetLong() => 0;

    private byte ReadLong(int address) => 0;

    public void SetFlags() {
        Logger.LogDebug("Setting Memory Flags", "Memory");
        bool isZero = this.Accumulator.GetRegister() == 0;
        this.ZeroFlag.SetRegister(isZero ? 1 : 0);

        bool isNegative = (this.Accumulator.GetRegister() & 0b10000000) > 0;
        this.NegativeFlag.SetRegister(isNegative ? 1 : 0);
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
