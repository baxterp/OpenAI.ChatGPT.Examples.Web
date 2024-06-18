namespace OpenAI.ChatGPT.Examples.Web.Helpers
{
    public static class FileHelper
    {
        //class to be implemented reads the contents of a file in text, and returns the text
        public static string GetCodeSnippet()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory)?.Parent?.FullName ?? string.Empty;
            string codeSnippetFilePath = projectDirectory + @"\OpenAI.ChatGPT.Examples.Web\OpenAI.ChatGPT.Examples.Web\bin\Debug\net8.0\TextFiles\CodeSnippet.txt";
            var result = File.ReadAllText(codeSnippetFilePath);
            return result;
        }
    }
}
