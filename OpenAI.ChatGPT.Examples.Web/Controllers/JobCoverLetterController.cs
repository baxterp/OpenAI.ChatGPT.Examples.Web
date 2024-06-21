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

        [HttpGet]
        [Route("JobCoverLetter/GetJobCoverLetter")]
        public IActionResult GetJobCoverLetter()
        {
            string systemPrompt = "Given the follwoing CV and job description provide a cover letter";
            string jobSpecPrompt = FileHelper.GetJobSpec(Directory.GetCurrentDirectory()) ?? string.Empty;
            string cvPrompt = FileHelper.GetCV(Directory.GetCurrentDirectory()) ?? string.Empty;

            var systemMessage = new ChatMessage(ChatMessageRole.System, systemPrompt);
            var userMessages = new List<ChatMessage> { 
                                    new ChatMessage(ChatMessageRole.User, jobSpecPrompt),
                                    new ChatMessage(ChatMessageRole.User, cvPrompt)
            };

            var textResponse = OpenAIHelper.GetReponseFromPrompts(systemMessage, userMessages);

            return Json(textResponse);
        }
    }
}
