using Z6502.Core.Enums;

namespace Z6502.Core.Interfaces
{
    public interface IRegister
    {
        RegisterType RegisterType { get; protected set; }

        int RegisterValue { get; protected set; }

        virtual void Increment()
        {
        }

        virtual void Decrement()
        {
        }

        virtual void SetRegister(int value)
        {
            RegisterValue = value;
        }

        virtual dynamic GetRegister()
        {
            return RegisterType switch
            {
                RegisterType.EightBit => (byte)RegisterValue,
                RegisterType.SixteenBit => (ushort)RegisterValue,
                RegisterType.ThirtyTwoBit => (uint)RegisterValue,
                RegisterType.SixtyFourBit => (ulong)RegisterValue,
                _ => (byte)RegisterValue,
            };
        }

        virtual void Reset()
        {
        }
    }
}
