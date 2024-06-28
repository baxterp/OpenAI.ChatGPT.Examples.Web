using OpenAI_API;
using OpenAI_API.Chat;

namespace OpenAI.ChatGPT.Examples.Web.Interfaces
{
    public interface IOpenAIHelper
    {
        string GetReponseFromPrompts(ChatMessage systemPrompt, List<ChatMessage> userPrompts);
    }
}
