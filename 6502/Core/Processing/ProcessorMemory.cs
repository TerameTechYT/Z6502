using Z6502.Core.Bases;
using Z6502.Core.Enums;
using Z6502.Core.Extensions;
using Z6502.Core.Logging;

namespace Z6502.Core.Processing
{
    internal class ProcessorMemory : Memory
    {
        public ProcessorRegister ProgramCounter = new("ProgramCounter", RegisterType.SixteenBit, 0, 0xFFFC);
        public ProcessorRegister StackPointer = new("StackPointer", RegisterType.EightBit, 0, 0x0100);

        public ProcessorRegister Accumulator = new("Accumulator", RegisterType.EightBit, 0, 0);
        public ProcessorRegister IndexRegisterX = new("IndexRegisterX", RegisterType.EightBit, 0, 0);
        public ProcessorRegister IndexRegisterY = new("IndexRegisterY", RegisterType.EightBit, 0, 0);

        public ProcessorRegister CarryFlag = new("CarryFlag", RegisterType.EightBit, 0, 0);
        public ProcessorRegister ZeroFlag = new("ZeroFlag", RegisterType.EightBit, 0, 0);
        public ProcessorRegister NegativeFlag = new("NegativeFlag", RegisterType.EightBit, 0, 0);
        public ProcessorRegister OverflowFlag = new("OverflowFlag", RegisterType.EightBit, 0, 0);
        public ProcessorRegister InterruptDisable = new("InterruptDisable", RegisterType.EightBit, 0, 0);
        public ProcessorRegister DecimalMode = new("DecimalMode", RegisterType.EightBit, 0, 0);

        public ProcessorMemory(int memoryCapacity, Processor parent) : base(memoryCapacity, parent)
        {
            Logger.LogInfo($"Memory Initialized with capacity of {((long)memoryCapacity).SizeSuffix(2)}", "Memory");
        }

        public dynamic Fetch(FetchType fetchType)
        {
            return fetchType switch
            {
                FetchType.FetchByte => FetchByte(),
                FetchType.GetByte => GetByte(),

                FetchType.FetchShort => FetchShort(),
                FetchType.GetShort => GetShort(),

                FetchType.FetchInt => FetchInt(),
                FetchType.GetInt => GetInt(),

                FetchType.FetchLong => FetchLong(),
                FetchType.GetLong => GetLong(),

                _ => throw new NotImplementedException(),
            };
        }

        public dynamic Read(ReadType fetchType, int address)
        {
            return fetchType switch
            {
                ReadType.ReadByte => ReadByte(address),
                ReadType.ReadShort => ReadShort(address),
                ReadType.ReadInt => ReadInt(address),
                ReadType.ReadLong => ReadLong(address),

                _ => throw new NotImplementedException(),
            };
        }

        private byte FetchByte()
        {
            byte data = Data[ProgramCounter.RegisterValue];
            ProgramCounter.Increment();
            Parent.DecrementCycles();

            return data;
        }

        private byte GetByte()
        {
            byte data = Data[ProgramCounter.RegisterValue];
            Parent.DecrementCycles();

            return data;
        }

        private byte ReadByte(int address)
        {
            byte data = Data[address];
            Parent.DecrementCycles();

            return data;
        }

        private ushort FetchShort()
        {

            return 0;
        }

        private ushort GetShort()
        {

            return 0;
        }

        private byte ReadShort(int address)
        {

            return 0;
        }

        private uint FetchInt()
        {
            return 0;
        }

        private uint GetInt()
        {
            return 0;
        }

        private byte ReadInt(int address)
        {

            return 0;
        }

        private ulong FetchLong()
        {
            return 0;
        }

        private ulong GetLong()
        {
            return 0;
        }

        private byte ReadLong(int address)
        {

            return 0;
        }

        public void SetFlags()
        {
            Logger.LogDebug("Setting Memory Flags", "Memory");
            bool isZero = Accumulator.GetRegister() == 0;
            ZeroFlag.SetRegister(isZero ? 1 : 0);

            bool isNegative = (Accumulator.GetRegister() & 0b10000000) > 0;
            NegativeFlag.SetRegister(isNegative ? 1 : 0);
            Logger.LogDebug("Set Memory Flags", "Memory");
        }

        public override void Reset()
        {
            base.Reset();

            ProgramCounter.Reset();
            StackPointer.Reset();

            Accumulator.Reset();
            IndexRegisterX.Reset();
            IndexRegisterY.Reset();

            CarryFlag.Reset();
            ZeroFlag.Reset();
            NegativeFlag.Reset();
            OverflowFlag.Reset();
            InterruptDisable.Reset();
            DecimalMode.Reset();
        }
    }
}
