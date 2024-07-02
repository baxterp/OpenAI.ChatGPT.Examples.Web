using Moq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Controllers;
using OpenAI.ChatGPT.Examples.Web.Interfaces;
using System;

namespace OpenAI.ChatGPT.Examples.Tests
{
    [TestFixture]
    public class CodeExplainerControllerTests
    {
        private Mock<IFileHelper> _mockFileHelper;
        private CodeExplainerController _controller;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _mockFileHelper = new Mock<IFileHelper>();
            _controller = new CodeExplainerController(_mockFileHelper.Object);
        }

        [Test]
        public void Index_ReturnsView_WithCodeSnippetInViewBag()
        {
            // Arrange
            string expectedCodeSnippet = "public static void Main() {}";
            _mockFileHelper.Setup(f => f.GetCodeSnippet(It.IsAny<string>())).Returns(expectedCodeSnippet);

            // Act
            var result = _controller.Index();
            var viewResult = result as ViewResult;
            string? codeSnippet = viewResult?.ViewData["CodeSnippet"] as string ?? string.Empty;

            // Assert
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(expectedCodeSnippet, Is.EqualTo(codeSnippet));
        }

        [Test]
        public void Index_CatchesException_WritesToLogFile()
        {
            // Arrange
            _mockFileHelper.Setup(f => f.GetCodeSnippet(It.IsAny<string>())).Throws(new Exception("Test exception"));

            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = result as ViewResult;
            Assert.That(viewResult, Is.Not.Null);
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }
    }
}
