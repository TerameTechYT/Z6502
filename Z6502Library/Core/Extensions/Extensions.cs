namespace Z6502.Core.Extensions;

public static class Extensions {
    private static readonly string[] SizeSuffixes = { "bytes",
        "kilobytes",
        "megabytes",
        "gigabytes",
        "terabytes",
        "petabytes",
        "exabyte",
        "zetabytes",
        "yottabytes" };

    public static string SizeSuffix(this long value, int decimalPlaces = 1) {
        // https://stackoverflow.com/questions/14488796/does-net-provide-an-easy-way-convert-bytes-to-kb-mb-gb-etc

        if (decimalPlaces < 0) {
            throw new ArgumentOutOfRangeException("decimalPlaces");
        }
        if (value < 0) {
            return "-" + (-value).SizeSuffix(decimalPlaces);
        }
        if (value == 0) {
            return string.Format("{0:n" + decimalPlaces + "} bytes", 0);
        }

        // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
        int mag = (int) Math.Log(value, 1024);

        // 1L << (mag * 10) == 2 ^ (10 * mag) 
        // [i.e. the number of bytes in the unit corresponding to mag]
        decimal adjustedSize = (decimal) value / (1L << (mag * 10));

        // make adjustment when the value is large enough that
        // it would round up to 1000 or more
        if (Math.Round(adjustedSize, decimalPlaces) >= 1000) {
            mag += 1;
            adjustedSize /= 1024;
        }

        return string.Format("{0:n" + decimalPlaces + "} {1}",
            adjustedSize,
            SizeSuffixes[mag]);
    }

    public static ConsoleColor ToConsoleColor(this string text) => text?.ToLower() switch {
        "black" => ConsoleColor.Black,
        "white" => ConsoleColor.White,
        "darkblue" => ConsoleColor.DarkBlue,
        "blue" => ConsoleColor.Blue,
        "darkgreen" => ConsoleColor.DarkGreen,
        "green" => ConsoleColor.Green,
        "darkcyan" => ConsoleColor.DarkCyan,
        "cyan" => ConsoleColor.Cyan,
        "darkred" => ConsoleColor.DarkRed,
        "red" => ConsoleColor.Red,
        "darkyellow" => ConsoleColor.DarkYellow,
        "yellow" => ConsoleColor.Yellow,
        "darkmagenta" => ConsoleColor.DarkMagenta,
        "magenta" => ConsoleColor.Magenta,
        "gray" => ConsoleColor.Gray,
        "darkgray" => ConsoleColor.DarkGray,
        _ => throw new ArgumentOutOfRangeException($"String `{text}` is not a valid ConsoleColor"),
    };

    public static void FillRange<T>(this List<T> list, T fillValue) {
        for (int i = 0; i < list.Capacity; i++) {
            list.Add(fillValue);
        }
    }

    public static void FillRange<T>(this List<T> list, T fillValue, int count) {
        for (int i = 0; i < count; i++) {
            list.Add(fillValue);
        }
    }
}
