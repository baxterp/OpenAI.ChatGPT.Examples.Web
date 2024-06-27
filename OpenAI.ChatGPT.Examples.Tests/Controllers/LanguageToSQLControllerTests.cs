using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using OpenAI.ChatGPT.Examples.Web.Controllers;
using OpenAI.ChatGPT.Examples.Web.Interfaces;
using System.IO;

namespace OpenAI.ChatGPT.Examples.Web.Tests
{
    [TestFixture]
    public class LanguageToSQLControllerTests
    {
        private Mock<IFileHelper> _mockFileHelper;
        private LanguageToSQLController _controller;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _mockFileHelper = new Mock<IFileHelper>();
            _controller = new LanguageToSQLController(_mockFileHelper.Object);
        }

        [Test]
        public void Index_ReturnsView_WithSQLSnippetAndViewBagInstruction()
        {
            // Arrange
            string expectedSQLSnippet = "SELECT AVG(TotalOrderValue) FROM Orders WHERE OrderDate = '2024-06-26';";
            string expectedInstruction = "Write a SQL query which computes the average total order value for all orders on 2024-06-26.";
            _mockFileHelper.Setup(f => f.GetSQLSnippet(It.IsAny<string>())).Returns(expectedSQLSnippet);

            // Act
            var result = _controller.Index();
            var viewResult = _controller.Index() as ViewResult;
            string? sqlSnippet = viewResult?.ViewData["SQLSnippet"] as string ?? string.Empty;
            string? instruction = viewResult?.ViewData["Instruction"] as string ?? string.Empty;

            // Assert
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(expectedSQLSnippet, Is.EqualTo(sqlSnippet));
            Assert.That(expectedInstruction, Is.EqualTo(instruction));
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

    }
}