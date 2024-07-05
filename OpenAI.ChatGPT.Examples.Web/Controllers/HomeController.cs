using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Models;
using System.Diagnostics;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API.Chat;
using OpenAI.ChatGPT.Examples.Web.Interfaces;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("[controller]/GetPromptResponse")]
        public IActionResult GetPromptResponse([FromBody] List<string> prompts)
        {
            OpenAIHelper openAIHelper = new OpenAIHelper();
            string systemPrompt = prompts[0];
            string userPrompt = prompts[1];

            var systemMessage = new ChatMessage(ChatMessageRole.System, systemPrompt);
            var userMessages = new List<ChatMessage> { new ChatMessage(ChatMessageRole.User, userPrompt) };

            var textResponse = openAIHelper.GetReponseFromPrompts(systemMessage, userMessages);

            return Json(textResponse);
        }
    }
}
