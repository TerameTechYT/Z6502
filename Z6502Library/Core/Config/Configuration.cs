using Newtonsoft.Json;
using Z6502.Core.Logging;

namespace Z6502.Core.Config
{
    public sealed class Configuration
    {
        public const string ConfigurationFile = "Configuration.json";

        public const string LogFolder = "Logs";
        public const string LogFile = $"{LogFolder}/log.log";
        public const string LogFormat = "[{2} - {1}]: {0}";

        public static Configuration? Instance { get; private set; }

        [JsonProperty("consoleColors")]
        public required Colors CustomColors { get; set; }

        public override string ToString()
        {
            return $"TConsoleColors: {CustomColors}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CustomColors);
        }

        public override bool Equals(object? obj)
        {
            return obj is Configuration
                && CustomColors.Equals(CustomColors);
        }

        public static async Task ReadConfiguration()
        {
            Instance = await GetConfiguration();
        }

        public static async Task<Configuration> GetConfiguration()
        {
            using StreamReader streamReader = new(ConfigurationFile);
            Configuration? configuration = JsonConvert.DeserializeObject<Configuration>(await streamReader.ReadToEndAsync());
            Logger.AssertFatal(configuration == null, $"Configuration file `{ConfigurationFile}` is not a valid json!", "Configuration");

            return configuration!;
        }
    }

    public sealed class Colors
    {
        [JsonProperty("foreground")]
        public required string ForegroundColor { get; set; }

        [JsonProperty("background")]
        public required string BackgroundColor { get; set; }

        [JsonProperty("fatal")]
        public required Color FatalColor { get; set; }

        [JsonProperty("error")]
        public required Color ErrorColor { get; set; }

        [JsonProperty("warn")]
        public required Color WarnColor { get; set; }

        [JsonProperty("info")]
        public required Color InfoColor { get; set; }

        [JsonProperty("debug")]
        public required Color DebugColor { get; set; }

        public Color GetColor(Severity severity)
        {
            return severity switch
            {
                Severity.Fatal => FatalColor,
                Severity.Error => ErrorColor,
                Severity.Warn => WarnColor,
                Severity.Info => InfoColor,
                Severity.Debug => DebugColor,
                _ => throw new ArgumentOutOfRangeException()
            };
        }


        public override string ToString()
        {
            return $"{Environment.NewLine}Default Foreground: {ForegroundColor}{Environment.NewLine}Default Background: {BackgroundColor}{Environment.NewLine}Fatal: {FatalColor}{Environment.NewLine}Error: {ErrorColor}{Environment.NewLine}Warning: {WarnColor}{Environment.NewLine}Info: {InfoColor}{Environment.NewLine}Debug: {DebugColor}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ForegroundColor,
                BackgroundColor,
                FatalColor,
                ErrorColor, WarnColor,
                InfoColor,
                DebugColor);
        }

        public override bool Equals(object? obj)
        {
            return obj is Colors other
                && ForegroundColor == other.ForegroundColor
                && BackgroundColor == other.BackgroundColor
                && FatalColor.Equals(other.FatalColor)
                && ErrorColor.Equals(other.ErrorColor)
                && WarnColor.Equals(other.WarnColor)
                && InfoColor.Equals(other.InfoColor)
                && DebugColor.Equals(other.DebugColor);
        }
    }

    public sealed class Color
    {
        [JsonProperty("foreground")]
        public required string ForegroundColor { get; set; }

        [JsonProperty("background")]
        public required string BackgroundColor { get; set; }

        public override string ToString()
        {
            return $"{Environment.NewLine}Foreground: {ForegroundColor}{Environment.NewLine}Backgroud: {BackgroundColor}{Environment.NewLine}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ForegroundColor, BackgroundColor);
        }

        public override bool Equals(object? obj)
        {
            return obj is Color other
                    && ForegroundColor == other.ForegroundColor
                    && BackgroundColor == other.BackgroundColor;
        }
    }
}