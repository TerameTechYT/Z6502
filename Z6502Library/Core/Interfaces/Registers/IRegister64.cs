namespace Z6502.Core.Interfaces.Registers;

public interface IRegister64 {
    ulong Value {
        get; protected set;
    }
    ulong ResetValue {
        get; protected set;
    }

    string Name {
        get; protected set;
    }

    void Increment();

    void Decrement();

    void SetRegister(ulong value);

    ulong GetRegister();

    void Reset();
}
