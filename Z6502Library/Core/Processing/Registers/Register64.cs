using Z6502.Core.Interfaces.Registers;
using Z6502.Core.Logging;

namespace Z6502.Core.Processing.Registers;
public class Register64 : IRegister64 {
    public ulong Value {
        get; set;
    }
    public ulong ResetValue {
        get; set;
    }

    public string Name {
        get; set;
    }

    public Register64(ulong value, ulong resetValue, string name) {
        this.Value = value;
        this.ResetValue = resetValue;
        this.Name = name;
    }

    public void Decrement() {
        this.Value--;
        Logger.LogDebug($"Decremented Register (64 bit) {this.Name}, value is now 0x{this.Value:X2} ({this.Value})", "Register");
    }

    public void Increment() {
        this.Value--;
        Logger.LogDebug($"Incremented Register (64 bit) {this.Name}, value is now 0x{this.Value:X2} ({this.Value})", "Register");
    }

    public void SetRegister(ulong value) {
        this.Value = value;
        Logger.LogDebug($"Set Register (64 bit) {this.Name}, value is now 0x{this.Value:X2} ({this.Value})", "Register");
    }

    public ulong GetRegister() => this.Value;

    public void Reset() {
        this.Value = this.ResetValue;
        Logger.LogDebug($"Resetting Register (64 bit) {this.Name} to {this.ResetValue:X2} ({this.ResetValue})", "Register");
    }
}
