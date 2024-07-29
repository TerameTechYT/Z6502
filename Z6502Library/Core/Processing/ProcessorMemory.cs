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

    public void WriteByte(int address, byte value) {
        this.Data[address] = value;
        this.Parent.DecrementCycles();
    }
    public void WriteByte(byte value) {
        this.Data[this.ProgramCounter] = value;
        this.ProgramCounter.Increment();

        this.Parent.DecrementCycles();
    }

    // TODO: Handle Endianness
    public ushort FetchShort() {
        ushort leastSignificant = this.FetchByte();
        ushort mostSignificant = this.FetchByte();

        return leastSignificant |= (byte) (mostSignificant << 8);
    }

    // TODO: Handle Endianness
    public ushort GetShort() {
        ushort leastSignificant = this.GetByte();
        ushort mostSignificant = this.GetByte();

        return leastSignificant |= (byte) (mostSignificant << 8);
    }

    // TODO: Handle Endianness
    public ushort ReadShort(int address) {
        ushort leastSignificant = this.ReadByte(address);
        ushort mostSignificant = this.ReadByte(address + 1);

        return leastSignificant |= (byte) (mostSignificant << 8);
    }

    // TODO: Handle Endianness
    public void WriteShort(int address, ushort value) {
        this.WriteByte(address, (byte) (value & 0xFF));
        this.WriteByte(address + 1, (byte) (value >> 8));
    }

    public void WriteShort(ushort value) {
        this.WriteByte(this.ProgramCounter, (byte) (value & 0xFF));
        this.WriteByte(this.ProgramCounter + 1, (byte) (value >> 8));
    }

    // TODO: Handle Endianness
    public uint FetchInt() {
        uint leastSignificant = this.FetchShort();
        uint mostSignificant = this.FetchShort();

        return leastSignificant |= (ushort) (mostSignificant >> 16);
    }

    // TODO: Handle Endianness
    public uint GetInt() {
        uint leastSignificant = this.GetShort();
        uint mostSignificant = this.GetShort();

        return leastSignificant |= (ushort) (mostSignificant >> 16);
    }

    // TODO: Handle Endianness
    public uint ReadInt(int address) {
        uint leastSignificant = this.ReadShort(address);
        uint mostSignificant = this.ReadShort(address + 2);

        return leastSignificant |= (ushort) (mostSignificant >> 16);
    }

    // TODO: Handle Endianness
    public void WriteInt(int address, uint value) {

    }

    // TODO: Handle Endianness
    public void WriteInt(uint value) {

    }

    // TODO: Handle Endianness
    public ulong FetchLong() {
        ulong leastSignificant = this.FetchInt();
        ulong mostSignificant = this.FetchInt();

        return leastSignificant |= (uint) (mostSignificant >> 32);
    }

    // TODO: Handle Endianness
    public ulong GetLong() {
        ulong leastSignificant = this.GetInt();
        ulong mostSignificant = this.GetInt();

        return leastSignificant |= (uint) (mostSignificant >> 32);
    }

    // TODO: Handle Endianness
    public ulong ReadLong(int address) {
        ulong leastSignificant = this.ReadInt(address);
        ulong mostSignificant = this.ReadInt((byte) (address + 4));

        return leastSignificant |= (uint) (mostSignificant >> 32);
    }

    // TODO: Handle Endianness
    public void WriteLong(int address, ulong value) {

    }

    // TODO: Handle Endianness
    public void WriteLong(ulong value) {

    }

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