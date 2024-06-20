using Microsoft.AspNetCore.Hosting.Server;

namespace OpenAI.ChatGPT.Examples.Web.Helpers
{
    public static class FileHelper
    {
        //class to be implemented reads the contents of a file in text, and returns the text
        public static string GetCodeSnippet(string currentDriectory)
        {
            try
            {
                string codeSnippetFilePath = currentDriectory + @"\TextFiles\CodeSnippet.txt";
                var result = File.ReadAllText(codeSnippetFilePath);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
