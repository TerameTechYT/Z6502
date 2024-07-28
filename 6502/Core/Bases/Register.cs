using Z6502.Core.Enums;
using Z6502.Core.Interfaces;
using Z6502.Core.Logging;

namespace Z6502.Core.Bases
{
    internal class Register : IRegister
    {
        public RegisterType RegisterType { get; set; }

        public int RegisterValue { get; set; }

        public int ResetValue { get; set; }

        protected string _registerName { get; set; }

        public Register(string registerName, RegisterType registerType, int registerValue, int resetValue)
        {
            _registerName = registerName;
            RegisterType = registerType;
            RegisterValue = registerValue;
            ResetValue = resetValue;

            Logger.LogInfo($"Register {registerName} Initialized", "Register");
        }

        public virtual void Increment()
        {
            RegisterValue++;

            Logger.LogDebug($"Incremented {_registerName}", "Register");
        }

        public virtual void Decrement()
        {
            RegisterValue--;

            Logger.LogDebug($"Decremented {_registerName}", "Register");
        }

        public virtual void SetRegister(dynamic value)
        {
            RegisterValue = (int)value;

            Logger.LogDebug($"Set {_registerName} to 0x{RegisterValue:X2} ({RegisterValue})", "Register");
        }

        public virtual dynamic GetRegister()
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

        public virtual void Reset()
        {
            RegisterValue = ResetValue;
            Logger.LogDebug($"Reset {_registerName}", "Register");
        }
    }
}
