using Z6502.Core.Interfaces.Registers;
using Z6502.Core.Logging;

namespace Z6502.Core.Processing.Registers;
public class Register16 : IRegister16 {
    public ushort Value {
        get; set;
    }
    public ushort ResetValue {
        get; set;
    }

    public string Name {
        get; set;
    }

    public static ushort operator +(Register16 register, ushort value) => register.Value += value;
    public static ushort operator -(Register16 register, ushort value) => register.Value -= value;
    public static ushort operator *(Register16 register, ushort value) => register.Value *= value;
    public static ushort operator /(Register16 register, ushort value) => register.Value /= value;

    public static implicit operator ushort(Register16 register) => register.Value;

    public Register16(ushort value, ushort resetValue, string name) {
        this.Value = value;
        this.ResetValue = resetValue;
        this.Name = name;
    }

    public void Decrement() {
        this.Value--;
        Logger.LogDebug($"Decremented Register (16 bit) {this.Name}, value is now {this.Value:X2} ({this.Value})", "Register");
    }

    public void Increment() {
        this.Value--;
        Logger.LogDebug($"Incremented Register (16 bit) {this.Name}, value is now {this.Value:X2} ({this.Value})", "Register");
    }

    public void SetRegister(ushort value) {
        this.Value = value;
        Logger.LogDebug($"Set Register (16 bit) {this.Name}, value is now {this.Value:X2} ({this.Value})", "Register");
    }

    public ushort GetRegister() => this.Value;

    public void Reset() {
        this.Value = this.ResetValue;
        Logger.LogDebug($"Resetting Register (16 bit) {this.Name} to {this.ResetValue:X2} ({this.ResetValue})", "Register");
    }
}
