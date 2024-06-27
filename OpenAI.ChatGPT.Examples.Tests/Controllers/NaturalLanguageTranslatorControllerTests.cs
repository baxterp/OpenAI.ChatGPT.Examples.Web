using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using OpenAI.ChatGPT.Examples.Web.Controllers;

namespace OpenAI.ChatGPT.Examples.Web.Tests
{
    [TestFixture]
    public class NaturalLanguageTranslatorControllerTests
    {
        private NaturalLanguageTranslatorController _controller;

        [SetUp]
        public void Setup()
        {
            // Arrange
            _controller = new NaturalLanguageTranslatorController();
        }

        [Test]
        public void Index_ReturnsViewResult()
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [TearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }
    }
}