using Microsoft.AspNetCore.Mvc;
using Moq;
using OpenAI.ChatGPT.Examples.Web.Controllers;
using OpenAI.ChatGPT.Examples.Web.Interfaces;
using OpenAI_API.Chat;

namespace OpenAI.ChatGPT.Examples.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private Mock<IOpenAIHelper> _mockOpenAIHelper;
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _mockOpenAIHelper = new Mock<IOpenAIHelper>();
            _controller = new HomeController(_mockOpenAIHelper.Object);
        }

        [Test]
        public void GetPromptResponse_ReturnsJsonResult_WithExpectedResponse()
        {
            // Arrange
            var prompts = new List<string> { "System Prompt", "User Prompt" };
            var expectedResponse = "Expected Response";
            _mockOpenAIHelper.Setup(x => x.GetReponseFromPrompts(It.IsAny<ChatMessage>(), It.IsAny<List<ChatMessage>>()))
                             .Returns(expectedResponse);

            // Act
            var result = _controller.GetPromptResponse(prompts);
            var jsonResult = result as JsonResult;

            // Assert
            Assert.That(result, Is.InstanceOf<JsonResult>());
            Assert.That(jsonResult, Is.Not.Null);
            Assert.That(expectedResponse, Is.EqualTo(jsonResult.Value));
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }
    }
}