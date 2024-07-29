namespace Z6502.Core.Interfaces.Registers;

public interface IRegister8 {
    byte Value {
        get; protected set;
    }
    byte ResetValue {
        get; protected set;
    }

    string Name {
        get; protected set;
    }

    void Increment();

    void Decrement();

    void SetRegister(byte value);

    byte GetRegister();

    void Reset();
}
