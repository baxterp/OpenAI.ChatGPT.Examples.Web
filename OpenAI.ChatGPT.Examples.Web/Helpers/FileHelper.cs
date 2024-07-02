using Microsoft.AspNetCore.Hosting.Server;
using OpenAI.ChatGPT.Examples.Web.Interfaces;

namespace OpenAI.ChatGPT.Examples.Web.Helpers
{
    public class FileHelper : IFileHelper
    {

        public string GetSQLSnippet(string currentDriectory)
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

        public string GetCodeSnippet(string currentDriectory)
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

        public string GetJobSpec(string currentDriectory)
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

        public string GetCV(string currentDriectory)
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

        public string GetJSONData(string currentDriectory)
        {
            try
            {
                string jsonDataFilePath = currentDriectory + @"\TextFiles\JSONData.txt";
                var result = File.ReadAllText(jsonDataFilePath);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
