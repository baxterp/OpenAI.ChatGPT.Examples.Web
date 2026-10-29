using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI.ChatGPT.Examples.Web.Interfaces;

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
