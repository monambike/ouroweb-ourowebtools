using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.IO;

namespace Common.Utilities
{
    public static class Log
    {
        private static Core.Properties.Log LogSettings => Core.Properties.Log.Default;

        public static string LogFilePath => LogSettings.LogFilePath;

        public static bool ShowLogFile => LogSettings.ShowLogFile;

        public static void AppendToLogCustomText(LogType logType, string message)
        {
            if (!ShowLogFile) return;

            var longestStringLengthAtEnum = Collection.GetLongestStringLengthAtEnum(typeof(LogType));
            // Getting the longest string length at enum and using it as pad right, it will let the string with
            // fixed size
            // e.g.: If has "ERROR" and "INFO", you will get "ERROR" and "INFO " as the output.
            var logTypeAsStringWithFixedPadding = logType.ToString().PadRight(longestStringLengthAtEnum);

            var rowToAppendToLogFile = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss:fff}] [{logTypeAsStringWithFixedPadding}] {message}{Environment.NewLine}";
            _ = File.AppendFileAsync(LogFilePath, rowToAppendToLogFile);
        }

        public static void AppendToLogCustomTextInfo(string text) => AppendToLogCustomText(LogType.INFO, $"{text}");

        public static void AppendToLogUpdatedFile(string path) => AppendToLogCustomText(LogType.INFO, $@"Atualizado: ""{path}"".");

        public static void AppendToLogUpdatedFile(string path, string whatWasUpdated) => AppendToLogCustomText(LogType.INFO, $@"Atualizado ""{whatWasUpdated}"": ""{path}"".");

        public static void ShowNotificationClickHereToSeeLogFile(string notificationTitle, string notificationBody)
        {
            if (!ShowLogFile) new ToastContentBuilder().AddText(notificationTitle).AddText(notificationBody).Show();
            else
            {
                // When click on notification, it shows Log File. Subscribing event only once
                ToastNotificationManagerCompat.OnActivated -= ShowLogFileOnWindowsExplorer;
                ToastNotificationManagerCompat.OnActivated += ShowLogFileOnWindowsExplorer;

                new ToastContentBuilder()
                    .AddText(notificationTitle).AddText(notificationBody)
                    .AddText($@"Clique aqui para ver o arquivo de log do aplicativo presente em: ""{LogFilePath}"".")
                    .AddArgument("ShowLogFileOnWindowsExplorer")
                    .Show();
            }

        }

        private static void ShowLogFileOnWindowsExplorer(ToastNotificationActivatedEventArgsCompat e)
        {
            if (e.Argument == "ShowLogFileOnWindowsExplorer")
                File.ShowFileOnWindowsExplorer(LogFilePath);
        }

        public static bool IsLogFilePathFile()
        {
            var fileAttributes = System.IO.File.GetAttributes(LogFilePath);

            var isFile = !fileAttributes.HasFlag(FileAttributes.Directory);
            return isFile;
        }

        public enum LogType { FATAL, ERROR, WARN, INFO, DEBUG }
    }
}
