namespace OpenAI.ChatGPT.Examples.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using NUnit.Framework;
    using OpenAI.ChatGPT.Examples.Web.Controllers;
    using OpenAI.ChatGPT.Examples.Web.Interfaces;
    using OpenAI_API.Chat;

    [TestFixture]
    public class JobCoverLetterControllerTests
    {
        private readonly Mock<IFileHelper> _fileHelperMock;
        private readonly Mock<IOpenAIHelper> _openAIHelperMock;
        private readonly JobCoverLetterController _controller;

        public JobCoverLetterControllerTests()
        {
            _fileHelperMock = new Mock<IFileHelper>();
            _openAIHelperMock = new Mock<IOpenAIHelper>();
            _controller = new JobCoverLetterController(_fileHelperMock.Object, _openAIHelperMock.Object);
        }

        [Test]
        public void GetJobCoverLetter_ReturnsJsonResult_WithTextResponse()
        {
            // Arrange
            var prompts = new List<string> { "System Prompt", "Job Spec Prompt" };
            var expectedResponse = "Expected Response";
            _fileHelperMock.Setup(f => f.GetCV(It.IsAny<string>())).Returns("CV Content");
            _openAIHelperMock.Setup(o => o.GetReponseFromPrompts(It.IsAny<ChatMessage>(), It.IsAny<List<ChatMessage>>()))
                             .Returns(expectedResponse);

            // Act
            var jsonResult = _controller.GetJobCoverLetter(prompts) as JsonResult;

            // Assert
            Assert.That(jsonResult, Is.Not.Null);
            Assert.That(jsonResult, Is.InstanceOf<JsonResult>());
            Assert.That(expectedResponse, Is.EqualTo(jsonResult.Value));
        }

        [Test]
        public void Index_ReturnsViewResult_WithJobSpec()
        {
            // Arrange
            var expectedJobSpec = "Expected Job Spec";
            _fileHelperMock.Setup(f => f.GetJobSpec(It.IsAny<string>())).Returns(expectedJobSpec);

            // Act
            var viewResult = _controller.Index() as ViewResult;
            string? JobSpec = viewResult?.ViewData["JobSpec"] as string ?? string.Empty;

            // Assert
            Assert.That(viewResult, Is.Not.Null);
            Assert.That(expectedJobSpec, Is.EqualTo(JobSpec));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _controller.Dispose();
        }

    }

}