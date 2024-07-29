namespace Z6502.Core.Enums
{
    public enum InstructionType : byte
    {
        INVALID = 0x0,
        LDA_IMMEDIATE = 0xA9,
        LDA_ZEROPAGE = 0xA5,
        LDA_ZEROPAGEX = 0xB5,
        LDA_ABSOLUTE = 0xAD,
        LDA_ABSOLUTEX = 0xBD,
        LDA_ABSOLUTEY = 0xB9,
        LDA_INDIRECTX = 0xA1,
        LDA_INDIRECTY = 0xB1,
    }
}
