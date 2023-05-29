using System.Collections.Generic;

namespace Common.Models.ScriptPackage
{
    public partial class ScriptPackage
    {
        private string Target => $@"\\vm-srvfile01\fontes\application\ouronet\{Versao.Sob}\teste\script executor";

        public List<string> Paths { get; set; }

        public string Path => "";

        public static class Versao
        {
            public static string Sob => "10.1";

            private static string Sub => "1";

            private static string Whole => $"{Sob}.{Sub}";
        }

        public void Add() => Paths.Add(Path);

        public void Remove() => Paths.Remove(Path);

        public void Edit()
        {
            Remove();
            Add();
        }
    }
}
