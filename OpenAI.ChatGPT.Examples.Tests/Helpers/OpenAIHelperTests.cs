using Moq;
using NUnit.Framework;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API;
using OpenAI_API.Chat;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAI.ChatGPT.Examples.Tests
{
    [TestFixture]
    public class OpenAIHelperTests
    {
        private Mock<OpenAIAPI> _mockOpenAiApi;
        private OpenAIHelper _openAIHelper;

        [SetUp]
        public void SetUp()
        {
            // Assuming OpenAIHelper is modified to allow injecting OpenAIAPI or its abstraction
            _mockOpenAiApi = new Mock<OpenAIAPI>();
            _openAIHelper = new OpenAIHelper(_mockOpenAiApi.Object);
        }

        //[Test]
        //public void GetReponseFromPrompts_ReturnsExpectedText()
        //{
        //    // Arrange
        //    var systemPrompt = new ChatMessage { Role = "system", Content = "System prompt" };
        //    var userPrompts = new List<ChatMessage> { new ChatMessage { Role = "user", Content = "User prompt" } };
        //    var expectedResponse = "Expected response";

        //    var mockCompletionResult = new ChatCompletionResult
        //    {
        //        Choices = new List<ChatCompletionChoice>
        //        {
        //            new ChatCompletionChoice { Message = new ChatMessage { TextContent = expectedResponse } }
        //        }
        //    };

        //    _mockOpenAiApi.Setup(api => api.Chat.CreateChatCompletionAsync(It.IsAny<ChatRequest>()))
        //                  .ReturnsAsync(mockCompletionResult);

        //    // Act
        //    var result = _openAIHelper.GetReponseFromPrompts(systemPrompt, userPrompts);

        //    // Assert
        //    Assert.AreEqual(expectedResponse, result);
        //}
    }
}