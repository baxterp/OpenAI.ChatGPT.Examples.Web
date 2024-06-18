using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API.Chat;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class CodeExplainerController : Controller
    {
        public IActionResult Index()
        {
            var codeText = FileHelper.GetCodeSnippet();
            ViewBag.CodeSnippet = codeText;
            return View();
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
