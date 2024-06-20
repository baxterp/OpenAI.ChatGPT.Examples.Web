using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API.Chat;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net.Http;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class CodeExplainerController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                string siteRootDirectory = Directory.GetCurrentDirectory();
                var codeText = FileHelper.GetCodeSnippet(siteRootDirectory);
                ViewBag.CodeSnippet = codeText;
                return View();
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("log.txt", ex.Message);
                return View();
            }
        }

        [HttpPost]
        [Route("NaturalLanguageTranslator/GetExplanation")]
        public IActionResult GetExplanation([FromBody] List<string> prompts)
        {
            string systemPrompt = prompts[0];
            string userPrompt = prompts[1];

            var systemMessage = new ChatMessage(ChatMessageRole.System, systemPrompt);
            var userMessages = new List<ChatMessage> { new ChatMessage(ChatMessageRole.User, userPrompt) };

            var textResponse = OpenAIHelper.GetReponseFromPrompts(systemMessage, userMessages);

            return Json(textResponse);
        }
    }
}
