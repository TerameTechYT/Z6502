using Z6502.Core.Bases;
using Z6502.Core.Enums;

namespace Z6502.Core.Processing
{
    public class ProcessorRegister : Register
    {
        public ProcessorRegister(string registerName, RegisterType registerType, int registerValue, int resetValue) : base(registerName, registerType, registerValue, resetValue)
        {
        }

        public override void Reset()
        {
            base.Reset();
        }
    }
}
