using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API.Chat;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class NaturalLanguageTranslatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("NaturalLanguageTranslator/GetTranslation")]
        public IActionResult GetTranslation([FromBody] List<string> prompts)
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
