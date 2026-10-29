using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using Spire.Doc;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    [Route("~/[controller]/")]
    public class WordDocumentController : Controller
    {
        public IActionResult Index()
        { 
            return View();
        }

        [HttpPost]
        [Route("WordDocSummarize")]
        public IActionResult WordDocSummarize(IFormFile file)
        {
            if (file == null)
                return BadRequest("No files were uploaded");

            Document document = new Document();
            using (var stream = file.OpenReadStream())
            {
                document.LoadFromStream(stream, FileFormat.Docx);
            }

            if (document == null || document.Sections.Count == 0)
                return BadRequest("No content found in the document");

            var text = document.GetText();

            if (string.IsNullOrEmpty(text))
                return BadRequest("No content found in the document");

            OpenAIHelper openAIHelper = new OpenAIHelper();
            string systemPrompt = "You are required to summerise the following text, in no more 200 words";
            string userPrompt = text;

            var chatMessageList = new List<ChatMessage>();
            chatMessageList.Add(systemPrompt);
            chatMessageList.Add(userPrompt);

            var textResponse = openAIHelper.GetReponseFromPrompts(chatMessageList);

            return Ok(textResponse);
        }


    }
}
