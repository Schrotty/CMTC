using System.IO;

namespace CMTC.Utilities
{
    public static class FileUtilities
    {
        public static string ReadFile(string file)
        {
            if (File.Exists(file))
            {
                return File.ReadAllText(file);
            }

            throw new FileNotFoundException(TemplateManager.GetTemplate("FILE_NOT_FOUND").Render(), file);
        }

        public static void WriteFile(string file, string content)
        {
            File.CreateText(file).WriteLine(content);
        }
    }
}
