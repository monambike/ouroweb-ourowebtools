using Microsoft.Toolkit.Uwp.Notifications;
using System.Windows;

namespace Common.Models
{
    public static class OuroWeb
    {

        public static readonly string access2000Path = "Settings.Paths.Default.Access2000Path";

        public static readonly string ouroWebPath = @"C:\DvpLocal\WorkSpaceTFS\Medicamento\Desktop\Vba\Producao\OuroWeb.MDB";

        public static readonly string access2000AndOuroWebWithDecompilePath = $@"""{access2000Path}"" ""{ouroWebPath}"" /decompile";
        
        public static void CopyFullPathToClipboard() => Utilities.Functions.CopyToClipboard("Caminho",
            "caminho do OuroWeb", contentToCopy:access2000AndOuroWebWithDecompilePath);
    }
}
