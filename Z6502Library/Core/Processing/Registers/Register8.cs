using Z6502.Core.Interfaces.Registers;
using Z6502.Core.Logging;

namespace Z6502.Core.Processing.Registers;
public class Register8 : IRegister8 {
    public byte Value {
        get; set;
    }
    public byte ResetValue {
        get; set;
    }

    public string Name {
        get; set;
    }

    public static byte operator +(Register8 register, byte value) => register.Value += value;
    public static byte operator -(Register8 register, byte value) => register.Value -= value;
    public static byte operator *(Register8 register, byte value) => register.Value *= value;
    public static byte operator /(Register8 register, byte value) => register.Value /= value;

    public static implicit operator byte(Register8 register) => register.Value;

    public Register8(byte value, byte resetValue, string name) {
        this.Value = value;
        this.ResetValue = resetValue;
        this.Name = name;
    }

    public void Decrement() {
        this.Value--;
        Logger.LogDebug($"Decremented Register (8 bit) {this.Name}, value is now 0x{this.Value:X2} ({this.Value})", "Register");
    }

    public void Increment() {
        this.Value++;
        Logger.LogDebug($"Incremented Register (8 bit) {this.Name}, value is now 0x{this.Value:X2} ({this.Value})", "Register");
    }

    public void SetRegister(byte value) {
        this.Value = value;
        Logger.LogDebug($"Set Register (8 bit) {this.Name}, value is now 0x{this.Value:X2} ({this.Value})", "Register");
    }

    public byte GetRegister() => this.Value;

    public void Reset() {
        this.Value = this.ResetValue;
        Logger.LogDebug($"Resetting Register (8 bit) {this.Name} to 0x{this.ResetValue:X2} ({this.ResetValue})", "Register");
    }
}
