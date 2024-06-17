using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Models;
using System.Diagnostics;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API.Chat;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("GetTranslation")]
        public IActionResult GetTranslation([FromBody] List<string> prompts)
        {
            string systemPrompt = prompts[0];
            string userPrompt = prompts[1];

            var systemMessage = new ChatMessage(ChatMessageRole.System, systemPrompt);
            var userMessages = new List<ChatMessage> { new ChatMessage(ChatMessageRole.User, userPrompt) };

            var textResponse = OpenAIHelper.GetReponseFromPrompts(systemMessage, userMessages);

            return Json(textResponse);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
