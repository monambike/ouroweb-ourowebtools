using System.Diagnostics;
using System.IO;

namespace Common.Models
{
    public static class OpenExternalApplication
    {
        public static void OpenApplication(Application application)
        {
            var applicationShortcutName = $"{application}.lnk";
            var folderPath = @"c:\dvplocal\github\ouroweb_ourowebtools_desktop\applications\";

            var applicationPath = folderPath + applicationShortcutName;

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = applicationPath,
                WorkingDirectory = Path.GetDirectoryName(folderPath),
                WindowStyle = ProcessWindowStyle.Normal
            };

            Process.Start(processStartInfo);
        }


        public enum Application
        {
            CryptFast,
            FollowWeb,
            ObjectsWeb,
            ScriptPackage,
            SetupTransference,
            SqlExecutor,
            WorkTimeRegister
        };
    }
}
