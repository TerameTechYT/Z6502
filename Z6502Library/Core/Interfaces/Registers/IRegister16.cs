namespace Z6502.Core.Interfaces.Registers;

public interface IRegister16 {
    ushort Value {
        get; protected set;
    }
    ushort ResetValue {
        get; protected set;
    }

    string Name {
        get; protected set;
    }

    void Increment();

    void Decrement();

    void SetRegister(ushort value);

    ushort GetRegister();

    void Reset();
}
