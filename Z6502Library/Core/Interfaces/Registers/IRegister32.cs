namespace Z6502.Core.Interfaces.Registers;

public interface IRegister32 {
    uint Value {
        get; protected set;
    }
    uint ResetValue {
        get; protected set;
    }

    string Name {
        get; protected set;
    }

    void Increment();

    void Decrement();

    void SetRegister(uint value);

    uint GetRegister();

    void Reset();
}
