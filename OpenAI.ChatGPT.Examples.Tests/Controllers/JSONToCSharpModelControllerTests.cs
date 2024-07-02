using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using OpenAI.ChatGPT.Examples.Web.Controllers;
using OpenAI.ChatGPT.Examples.Web.Interfaces;

namespace OpenAI.ChatGPT.Examples.Tests
{
    [TestFixture]
    public class JSONToCSharpModelControllerTests
    {
        private Mock<IFileHelper> _mockFileHelper;
        private Mock<IOpenAIHelper> _mockOpenAIHelper;
        private JSONToCSharpModelController _controller;

        [SetUp]
        public void SetUp()
        {
            // Initialize mocks
            _mockFileHelper = new Mock<IFileHelper>();
            _mockOpenAIHelper = new Mock<IOpenAIHelper>();

            // Create an instance of the controller, injecting the mocks
            _controller = new JSONToCSharpModelController(_mockFileHelper.Object, _mockOpenAIHelper.Object);
        }

        [Test]
        public void Index_ReturnsViewResult_WithExpectedJsonData()
        {
            // Arrange
            var expectedJsonData = "{\"key\":\"value\"}";
            _mockFileHelper.Setup(fh => fh.GetJSONData(It.IsAny<string>())).Returns(expectedJsonData);

            // Act
            var result = _controller.Index();
            var viewResult = result as ViewResult;
            string? jsonData = viewResult?.ViewData["jsonData"] as string ?? string.Empty;

            // Assert
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(expectedJsonData, Is.EqualTo(jsonData));
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }
    }
}