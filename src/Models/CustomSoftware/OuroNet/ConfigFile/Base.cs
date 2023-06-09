using Common.Utilities;
using System.Threading.Tasks;
using System.Windows;

namespace Common.Models
{
    public partial class OuroNet
    {
        public partial class ConfigFile
        {
            public abstract class Base
            {
                public abstract string FileNameWithExtension { get; }

                public new string ToString() => ConfigFileContentToString();

                public void CopyToClipboard() => Clipboard.SetText(ToString());

                public async Task MakeFileAsync(string folderPath)
                {
                    var fileName = FileNameWithExtension;
                    var content = ToString();

                    await File.OverriteFileAsync($@"{folderPath}\{fileName}", content);
                }

                protected abstract string ConfigFileContentToString();
            }
        }
    }
}
