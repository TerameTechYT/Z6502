using Z6502.Core.Config;
using Z6502.Core.Extensions;

namespace Z6502.Core.Logging;

public enum Severity {
    Fatal,
    Error,
    Warn,
    Info,
    Debug
}

public class Logger {
    public static async Task InitalizeLog() {
        if (!Directory.Exists(Configuration.LogFolder)) {
            _ = Directory.CreateDirectory(Configuration.LogFolder);
        }

        if (File.Exists(Configuration.LogFile)) {
            File.Delete(Configuration.LogFile);
        }

        await Configuration.ReadConfiguration();

        AssertFatal(Configuration.Instance == null, "Configuration failed to be read!", "Logger");

        LogInfo("Initalized logging system.", "Logger");
    }

    private static void SetConsoleColors(Severity severity) {
        Color color = Configuration.Instance.CustomColors.GetColor(severity);

        Console.ForegroundColor = color.ForegroundColor.ToConsoleColor();
        Console.BackgroundColor = color.BackgroundColor.ToConsoleColor();
    }

    private static void ResetConsoleColors() {
        Console.ForegroundColor = Configuration.Instance.CustomColors.ForegroundColor.ToConsoleColor();
        Console.BackgroundColor = Configuration.Instance.CustomColors.BackgroundColor.ToConsoleColor();
    }

    private static void Log(string message, string source, Severity severity, bool isAssert = false) {
        if (Configuration.Instance == null)
            return;

        if (isAssert)
            Console.Write("[ASSERT]: ");

        string formattedMessage = string.Format(Configuration.LogFormat, message, source, severity);
        SetConsoleColors(severity);

        Console.WriteLine(formattedMessage);
        File.AppendAllText(Configuration.LogFile, formattedMessage);

        ResetConsoleColors();
    }

    public static void LogFatal(string message, string source) => Log(message, source, Severity.Fatal);

    public static void AssertFatal(bool statement, string message, string source) {
        if (statement) {
            Log(message, source, Severity.Fatal, true);
        }
    }

    public static void LogError(string message, string source) => Log(message, source, Severity.Error);

    public static void AssertError(bool statement, string message, string source) {
        if (statement) {
            Log(message, source, Severity.Error, true);
        }
    }

    public static void LogWarn(string message, string source) => Log(message, source, Severity.Warn);

    public static void AssertWarn(bool statement, string message, string source) {
        if (statement) {
            Log(message, source, Severity.Warn, true);
        }
    }

    public static void LogInfo(string message, string source) => Log(message, source, Severity.Info);

    public static void AssertInfo(bool statement, string message, string source) {
        if (statement) {
            Log(message, source, Severity.Info, true);
        }
    }

#if DEBUG
    public static void LogDebug(string message, string source) => Log(message, source, Severity.Debug);

    public static void AssertDebug(bool statement, string message, string source) {
        if (statement) {
            Log(message, source, Severity.Debug, true);
        }
    }
#elif RELEASE
    public static void LogDebug(string message, string source)
    {
    }

    public static void AssertDebug(bool statement, string message, string source)
    {
    }
#endif
}
