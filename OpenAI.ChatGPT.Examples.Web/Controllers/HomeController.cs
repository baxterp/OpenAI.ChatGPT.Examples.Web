using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Models;
using System.Diagnostics;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI.Chat;
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

            var chatMessageList = new List<ChatMessage>();
            foreach (var prompt in prompts)
            {
                chatMessageList.Add(new UserChatMessage(prompt));
            }
            var textResponse = openAIHelper.GetReponseFromPrompts(chatMessageList);

            return Json(textResponse);
        }
    }
}
