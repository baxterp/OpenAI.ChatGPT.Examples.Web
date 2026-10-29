using Microsoft.AspNetCore.Http.HttpResults;
using OpenAI.Chat;
using OpenAI.ChatGPT.Examples.Web.Interfaces;
using System;

namespace OpenAI.ChatGPT.Examples.Web.Helpers
{
    public class OpenAIHelper
    {
        private ChatClient CreateChatClient()
        {
            try
            {
                var openAiApiKey = Environment.GetEnvironmentVariable("OpenAIKey", EnvironmentVariableTarget.User);

                ChatClient client = new(model: "gpt-5.2", apiKey: openAiApiKey);

                return client;
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("CreateChatClient.txt", ex.Message);
                throw;
            }
        }

        public string GetReponseFromPrompts(List<ChatMessage> userPrompts)
        {
            try
            {
                var client = CreateChatClient();

                var chatMessageList = new List<ChatMessage>();
                chatMessageList.AddRange(userPrompts);
                var chatMessage = chatMessageList.ToArray();

                var response = client.CompleteChat(chatMessage);

                var generatedText = response.Value.Content[0].Text;

                return generatedText;
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("GetReponse.txt", ex.Message);
                throw;
            }
        }
    }
}
