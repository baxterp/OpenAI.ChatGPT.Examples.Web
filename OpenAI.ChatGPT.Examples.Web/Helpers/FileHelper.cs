using Microsoft.AspNetCore.Hosting.Server;

namespace OpenAI.ChatGPT.Examples.Web.Helpers
{
    public static class FileHelper
    {

        public static string GetSQLSnippet(string currentDriectory)
        {
            try
            {
                string sqlSnippetFilePath = currentDriectory + @"\TextFiles\SQLSnippet.txt";
                var result = File.ReadAllText(sqlSnippetFilePath);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

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

        public static string GetJobSpec(string currentDriectory)
        {
            try
            {
                string codeSnippetFilePath = currentDriectory + @"\TextFiles\JobSpecification.txt";
                var result = File.ReadAllText(codeSnippetFilePath);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string GetCV(string currentDriectory)
        {
            try
            {
                string codeSnippetFilePath = currentDriectory + @"\TextFiles\CV.txt";
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
