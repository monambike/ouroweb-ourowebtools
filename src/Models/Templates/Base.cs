using Common.Utilities;
using System;
using System.Threading.Tasks;

namespace Common.Models
{
    public static partial class Template
    {
        public abstract class Base
        {
            public virtual string TemplateName => GetType().Name;

            protected Base()
            {
                File.CheckForValidFileName(TemplateName);
            }

            public new string ToString() => GetTemplate();

            public abstract string GetTemplate();

            public void CopyToClipboard() => Functions.CopyToClipboard("Template", $@"template de ""{TemplateName}""", GetTemplate());

            public async Task MakeReadmeFileAsync() => await MakeFileAsync(FileExtension.md);

            public async Task MakeTextFileAsync() => await MakeFileAsync(FileExtension.txt);

            private async Task MakeFileAsync(FileExtension fileExtension)
            {
                var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var dateTimeNow = DateTime.Now;
                var fileName = $"{dateTimeNow.Hour} {TemplateName}.{fileExtension}";

                await File.AskToOverriteAsync(fileName, folderPath, ToString());
            }

            private enum FileExtension { md, txt }
        }
    }
}
