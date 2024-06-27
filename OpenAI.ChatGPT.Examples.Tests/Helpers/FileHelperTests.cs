using NUnit.Framework;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using System;
using System.IO;

namespace OpenAI.ChatGPT.Examples.Tests
{
    [TestFixture]
    public class FileHelperTests
    {
        private FileHelper _fileHelper;
        private string _testDirectoryPath;

        [SetUp]
        public void SetUp()
        {
            _fileHelper = new FileHelper();
            _testDirectoryPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(_testDirectoryPath);
            Directory.CreateDirectory(Path.Combine(_testDirectoryPath, "TextFiles"));
        }

        [Test]
        public void GetSQLSnippet_ReturnsCorrectContent()
        {
            // Arrange
            string expectedContent = "SELECT * FROM TestTable;";
            string filePath = Path.Combine(_testDirectoryPath, "TextFiles", "SQLSnippet.txt");
            File.WriteAllText(filePath, expectedContent);

            // Act
            string result = _fileHelper.GetSQLSnippet(_testDirectoryPath);

            // Assert
            Assert.That(expectedContent, Is.EqualTo(result));
        }

        [Test]
        public void GetCodeSnippet_ReturnsCorrectContent()
        {
            // Arrange
            string expectedContent = "Console.WriteLine(\"Hello, World!\");";
            string filePath = Path.Combine(_testDirectoryPath, "TextFiles", "CodeSnippet.txt");
            File.WriteAllText(filePath, expectedContent);

            // Act
            string result = _fileHelper.GetCodeSnippet(_testDirectoryPath);

            // Assert
            Assert.That(expectedContent, Is.EqualTo(result));
        }

        [Test]
        public void GetJobSpec_ReturnsCorrectContent()
        {
            // Arrange
            string expectedContent = "Job Specification Details Here";
            string filePath = Path.Combine(_testDirectoryPath, "TextFiles", "JobSpecification.txt");
            File.WriteAllText(filePath, expectedContent);

            // Act
            string result = _fileHelper.GetJobSpec(_testDirectoryPath);

            // Assert
            Assert.That(expectedContent, Is.EqualTo(result));
        }

        [Test]
        public void GetCV_ReturnsCorrectContent()
        {
            // Arrange
            string expectedContent = "Curriculum Vitae Details Here";
            string filePath = Path.Combine(_testDirectoryPath, "TextFiles", "CV.txt");
            File.WriteAllText(filePath, expectedContent);

            // Act
            string result = _fileHelper.GetCV(_testDirectoryPath);

            // Assert
            Assert.That(expectedContent, Is.EqualTo(result));
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_testDirectoryPath))
            {
                Directory.Delete(_testDirectoryPath, true);
            }
        }
    }
}