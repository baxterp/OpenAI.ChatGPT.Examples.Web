namespace OpenAI.ChatGPT.Examples.Web.Interfaces
{
    public interface IFileHelper
    {
        string GetSQLSnippet(string currentDirectory);
        string GetCodeSnippet(string currentDirectory);
        string GetJobSpec(string currentDirectory);
        string GetCV(string currentDirectory);
        string GetJSONData(string currentDriectory);
    }
}
