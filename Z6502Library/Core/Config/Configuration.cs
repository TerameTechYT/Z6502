using Newtonsoft.Json;
using Z6502.Core.Logging;

namespace Z6502.Core.Config;

public sealed class Configuration {
    public const string ConfigurationFile = "Configuration.json";

    public const string LogFolder = "Logs";
    public const string LogFile = $"{LogFolder}/log.log";
    public const string LogFormat = "[{2} - {1}]: {0}";

    public static Configuration? Instance {
        get; private set;
    }

    [JsonProperty("consoleColors")]
    public required Colors CustomColors {
        get; set;
    }

    public override string ToString() => $"TConsoleColors: {this.CustomColors}";

    public override int GetHashCode() => HashCode.Combine(this.CustomColors);

    public override bool Equals(object? obj) => obj is Configuration
            && this.CustomColors.Equals(this.CustomColors);

    public static async Task ReadConfiguration() => Instance = await GetConfiguration();

    public static async Task<Configuration> GetConfiguration() {
        using StreamReader streamReader = new(ConfigurationFile);
        Configuration? configuration = JsonConvert.DeserializeObject<Configuration>(await streamReader.ReadToEndAsync());
        Logger.AssertFatal(configuration == null, $"Configuration file `{ConfigurationFile}` is not a valid json!", "Configuration");

        return configuration!;
    }
}

public sealed class Colors {
    [JsonProperty("foreground")]
    public required string ForegroundColor {
        get; set;
    }

    [JsonProperty("background")]
    public required string BackgroundColor {
        get; set;
    }

    [JsonProperty("fatal")]
    public required Color FatalColor {
        get; set;
    }

    [JsonProperty("error")]
    public required Color ErrorColor {
        get; set;
    }

    [JsonProperty("warn")]
    public required Color WarnColor {
        get; set;
    }

    [JsonProperty("info")]
    public required Color InfoColor {
        get; set;
    }

    [JsonProperty("debug")]
    public required Color DebugColor {
        get; set;
    }

    public Color GetColor(Severity severity) => severity switch {
        Severity.Fatal => this.FatalColor,
        Severity.Error => this.ErrorColor,
        Severity.Warn => this.WarnColor,
        Severity.Info => this.InfoColor,
        Severity.Debug => this.DebugColor,
        _ => throw new ArgumentOutOfRangeException()
    };


    public override string ToString() => $"{Environment.NewLine}Default Foreground: {this.ForegroundColor}{Environment.NewLine}Default Background: {this.BackgroundColor}{Environment.NewLine}Fatal: {this.FatalColor}{Environment.NewLine}Error: {this.ErrorColor}{Environment.NewLine}Warning: {this.WarnColor}{Environment.NewLine}Info: {this.InfoColor}{Environment.NewLine}Debug: {this.DebugColor}";

    public override int GetHashCode() => HashCode.Combine(this.ForegroundColor,
            this.BackgroundColor,
            this.FatalColor,
            this.ErrorColor, this.WarnColor,
            this.InfoColor,
            this.DebugColor);

    public override bool Equals(object? obj) => obj is Colors other
            && this.ForegroundColor == other.ForegroundColor
            && this.BackgroundColor == other.BackgroundColor
            && this.FatalColor.Equals(other.FatalColor)
            && this.ErrorColor.Equals(other.ErrorColor)
            && this.WarnColor.Equals(other.WarnColor)
            && this.InfoColor.Equals(other.InfoColor)
            && this.DebugColor.Equals(other.DebugColor);
}

public sealed class Color {
    [JsonProperty("foreground")]
    public required string ForegroundColor {
        get; set;
    }

    [JsonProperty("background")]
    public required string BackgroundColor {
        get; set;
    }

    public override string ToString() => $"{Environment.NewLine}Foreground: {this.ForegroundColor}{Environment.NewLine}Backgroud: {this.BackgroundColor}{Environment.NewLine}";

    public override int GetHashCode() => HashCode.Combine(this.ForegroundColor, this.BackgroundColor);

    public override bool Equals(object? obj) => obj is Color other
                && this.ForegroundColor == other.ForegroundColor
                && this.BackgroundColor == other.BackgroundColor;
}