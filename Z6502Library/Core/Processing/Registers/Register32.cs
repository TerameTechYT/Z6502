using Z6502.Core.Interfaces.Registers;
using Z6502.Core.Logging;

namespace Z6502.Core.Processing.Registers;
public class Register32 : IRegister32 {
    public uint Value {
        get; set;
    }
    public uint ResetValue {
        get; set;
    }

    public string Name {
        get; set;
    }

    public Register32(uint value, uint resetValue, string name) {
        this.Value = value;
        this.ResetValue = resetValue;
        this.Name = name;
    }

    public void Decrement() {
        this.Value--;
        Logger.LogDebug($"Decremented Register (32 bit) {this.Name}, value is now 0x{this.Value:X2} ({this.Value})", "Register");
    }

    public void Increment() {
        this.Value--;
        Logger.LogDebug($"Incremented Register (32 bit) {this.Name}, value is now 0x{this.Value:X2} ({this.Value})", "Register");
    }

    public void SetRegister(uint value) {
        this.Value = value;
        Logger.LogDebug($"Set Register (32 bit) {this.Name}, value is now 0x{this.Value:X2} ({this.Value})", "Register");
    }

    public uint GetRegister() => this.Value;

    public void Reset() {
        this.Value = this.ResetValue;
        Logger.LogDebug($"Resetting Register (32 bit) {this.Name} to {this.ResetValue:X2} ({this.ResetValue})", "Register");
    }
}
