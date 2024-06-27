using Microsoft.AspNetCore.Http.HttpResults;
using OpenAI.ChatGPT.Examples.Web.Interfaces;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using System;

namespace OpenAI.ChatGPT.Examples.Web.Helpers
{
    public class OpenAIHelper : IOpenAIHelper
    {
        private IOpenAIAPI _openAiApi;

        public OpenAIHelper(IOpenAIAPI openAiApi)
        {
            _openAiApi = openAiApi;
        }

        private OpenAIAPI CreateChatClient()
        {
            try
            {
                var openAiApiKey = Environment.GetEnvironmentVariable("OpenAIKey", EnvironmentVariableTarget.User);

                APIAuthentication aPIAuthentication = new APIAuthentication(openAiApiKey);
                _openAiApi = new OpenAIAPI(aPIAuthentication);

                return _openAiApi as OpenAIAPI;
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("CreateChatClient.txt", ex.Message);
                throw;
            }
        }

        public string GetReponseFromPrompts(ChatMessage systemPrompt, List<ChatMessage> userPrompts)
        {
            try
            {
                var openAiApi = CreateChatClient();
                var maxTokens = 500;
                var combinedMessages = new List<ChatMessage> { systemPrompt };
                foreach (var item in userPrompts) combinedMessages.Add(item);

                var completionRequest = new ChatRequest()
                {
                    Model = Model.ChatGPTTurbo,
                    Temperature = 0.0,
                    MaxTokens = maxTokens,
                    Messages = combinedMessages.ToArray()
                };

                var completionResult = Task.Run(() => openAiApi.Chat.CreateChatCompletionAsync(completionRequest)).Result;
                var generatedText = completionResult.Choices[0].Message.TextContent;

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
