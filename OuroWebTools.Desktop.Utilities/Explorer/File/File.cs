using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Common.Utilities
{
    public static partial class File
    {
        private static List<char> InvalidCharactersAtFileName => new List<char> { '^', '<', '>', ';', '|', '\'', '/', ',', '\\', ':', '=', '?', '*' };

        private static Regex ValidCharacters => new Regex($"^[^{string.Join("", InvalidCharactersAtFileName)}]*$");

        private static int MaxFileNameLengthAllowed => 256;


        public static async Task OverriteFileAsync(string filePath, string content) => await TextToFileAsync(filePath, content, FileType.MakeFile);

        public static async Task AskToOverriteAsync(string fileName, string folderPath, string content)
        {
            var filePath = CombineFolderPathWithFileName(folderPath, fileName);

            if (!System.IO.Directory.Exists(folderPath))
                if (Utilities.Message.Directory.NotFound(folderPath) == MessageBoxResult.OK)
                    return;

            if (System.IO.File.Exists(filePath))
                if (Message.FileAlreadyExistsAskToOverrite(fileName, filePath) == MessageBoxResult.No)
                    return;

            await TextToFileAsync(filePath, content, FileType.AppendToFile).ContinueWith(task => Message.SuccessCreateFileAtPath(filePath));
        }

        public static async Task AppendFileAsync(string filePath, string content) => await TextToFileAsync(filePath, content, FileType.AppendToFile);

        public static void ShowFileOnWindowsExplorer(string filePath)
        {
            string argument = "/select, \"" + filePath + "\"";

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }


        public static void CheckForValidFileName(string fileName)
        {
            if (!ValidCharacters.IsMatch(fileName))
                throw new InvalidFileNameException(
                    $@"O nome ""{fileName}"" não é um nome de arquivo válido. Não são "
                    + $@"permitidos os caracteres: {string.Join(@", ", InvalidCharactersAtFileName)}.");

            if (fileName.Length > MaxFileNameLengthAllowed)
                throw new InvalidFileNameException($"O nome do arquivo não pode ultrapassar {MaxFileNameLengthAllowed} caracteres.");
        }

        private static bool IsValidFileName(string fileName) => ValidCharacters.IsMatch(fileName) && fileName.Length <= MaxFileNameLengthAllowed;

        public static bool IsValidFolderPath(string folderPath)
        {
            var folderPathAttributes = System.IO.File.GetAttributes(folderPath);

            var isFolderPath = (folderPathAttributes & FileAttributes.Directory) == FileAttributes.Directory;
            return isFolderPath;
        }


        private static string CombineFolderPathWithFileName(string folderPath, string fileName)
        {
            if (!IsValidFolderPath(folderPath))
                throw new Exception($@"O caminho de diretório ""{folderPath}"" não é um caminho válido."); ;

            if (!IsValidFileName(fileName))
                throw new Exception($@"O nome de arquivo ""{fileName}"" possui caracteres inválidos para nome de arquivo."); ;

            var filePath = Path.Combine(folderPath, fileName);
            return filePath;
        }

        private static List<string> GetInvalidCharactersAtFileName(string fileName)
        {
            var invalidCharacters = new List<string>();

            foreach (var invalidCharacter in InvalidCharactersAtFileName)
                if (fileName.Contains(invalidCharacter.ToString()))
                    if (!invalidCharacters.Contains(invalidCharacter.ToString()))
                        invalidCharacters.Add(invalidCharacter.ToString());

            return invalidCharacters;
        }


        private static async Task TextToFileAsync(string filePath, string content, FileType fileType) => await TextToFileAsync(filePath, content, fileType, true);

        private enum FileType { MakeFile, AppendToFile }
        private static async Task TextToFileAsync(string filePath, string content, FileType fileType, bool removeReadonlyFromFile)
        {
            try
            {
                await AddContentToFileAsync(filePath, content, fileType);
            }
            catch (UnauthorizedAccessException)
            {
                var fileInfo = new FileInfo(filePath);
                if (fileInfo.IsReadOnly)
                {
                    if (removeReadonlyFromFile)
                    {
                        // Removes the "ReadOnly" attribute from the file
                        System.IO.File.SetAttributes(filePath, System.IO.File.GetAttributes(filePath) & ~FileAttributes.ReadOnly);

                        // Tries again to make the file again
                        await AddContentToFileAsync(filePath, content, fileType);
                    }
                    else throw new Exception("Não é possível sobrescrever o arquivo pois o mesmo está marcado como somente leitura.");
                }
                else throw new Exception("Ocorreu um erro.");
            }
            catch (NotSupportedException)
            {
                throw new Exception(
                    $@"Ocorreu um erro durante a tentativa de sobrescrever o arquivo ""{filePath}"". Por favor,"
                    + "tente alterar o nome ou o caminho do arquivo um formato incorreto.");
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro desconhecido durante a tentativa de sobrescrever um arquivo.");
            }
        }

        private static async Task AddContentToFileAsync(string filePath, string content, FileType fileType)
        {
            using (var file = new StreamWriter(filePath, false))
            {
                switch (fileType)
                {
                    case FileType.MakeFile: await file.WriteLineAsync(content); break;
                    case FileType.AppendToFile: System.IO.File.AppendAllText(filePath, content); break;
                    default: throw new NotImplementedException();
                }
            }
        }

        private class InvalidFileNameException : Exception
        {
            public InvalidFileNameException(string message)
                : base(message)
            { }
        }
    }
}
