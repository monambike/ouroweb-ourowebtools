using System;
using System.IO;

namespace Common.Utilities
{
    public static class Directory
    {
        public static void CopyDirectoryAndFiles(string sourcePath, string targetPath)
        {
            try
            {
                var directories = System.IO.Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories);
                foreach (var directory in directories)
                    System.IO.Directory.CreateDirectory(directory.Replace(sourcePath, targetPath));

                var files = System.IO.Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);
                foreach (var file in files)
                    System.IO.File.Copy(file, file.Replace(sourcePath, targetPath), true);
            }
            catch (Exception)
            {
                Message.Custom.Error("Ocorreu um erro desconhecido ao tentar realizar a cópia de uma pasta para outra.");
            }
        }
    }
}
