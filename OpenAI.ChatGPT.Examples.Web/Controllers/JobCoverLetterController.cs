using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI.ChatGPT.Examples.Web.Interfaces;
using OpenAI_API.Chat;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class JobCoverLetterController : Controller
    {
        IFileHelper _fileHelper;

        public JobCoverLetterController(IFileHelper fileHelper) // DI
        {
            _fileHelper = fileHelper;
        }

        [Route("~/[controller]/")]
        public IActionResult Index()
        {
            var jobSpec = _fileHelper.GetJobSpec(Directory.GetCurrentDirectory());
            ViewBag.JobSpec = jobSpec;
            return View();
        }

        [HttpPost]
        [Route("[controller]/GetJobCoverLetter")]
        public IActionResult GetJobCoverLetter([FromBody] List<string> prompts)
        {
            OpenAIHelper openAIHelper = new OpenAIHelper();
            string systemPrompt = prompts[0];
            string jobSpecPrompt = prompts[1];
            string cvPrompt = _fileHelper.GetCV(Directory.GetCurrentDirectory()) ?? string.Empty;

            var systemMessage = new ChatMessage(ChatMessageRole.System, systemPrompt);
            var userMessages = new List<ChatMessage> { 
                                    new (ChatMessageRole.User, jobSpecPrompt),
                                    new (ChatMessageRole.User, cvPrompt)
            };

            var textResponse = openAIHelper.GetReponseFromPrompts(systemMessage, userMessages);

            return Json(textResponse);
        }
    }
}
