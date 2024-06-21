using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API.Chat;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class JobCoverLetterController : Controller
    {
        public IActionResult Index()
        {
            var jobSpec = FileHelper.GetJobSpec(Directory.GetCurrentDirectory());
            ViewBag.JobSpec = jobSpec;
            return View();
        }

        [HttpPost]
        [Route("JobCoverLetter/GetJobCoverLetter")]
        public IActionResult GetJobCoverLetter([FromBody] List<string> prompts)
        {
            string systemPrompt = prompts[0];
            string jobSpecPrompt = prompts[1];
            string cvPrompt = FileHelper.GetCV(Directory.GetCurrentDirectory()) ?? string.Empty;

            var systemMessage = new ChatMessage(ChatMessageRole.System, systemPrompt);
            var userMessages = new List<ChatMessage> { 
                                    new (ChatMessageRole.User, jobSpecPrompt),
                                    new (ChatMessageRole.User, cvPrompt)
            };

            var textResponse = OpenAIHelper.GetReponseFromPrompts(systemMessage, userMessages);

            return Json(textResponse);
        }
    }
}
