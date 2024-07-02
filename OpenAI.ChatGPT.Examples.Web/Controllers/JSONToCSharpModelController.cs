using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Interfaces;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class JSONToCSharpModelController : Controller
    {
        IFileHelper _fileHelper;
        IOpenAIHelper _openAIHelper;

        public JSONToCSharpModelController(IFileHelper fileHelper, IOpenAIHelper openAIHelper) // DI
        {
            _fileHelper = fileHelper;
            _openAIHelper = openAIHelper;
        }

        [Route("~/[controller]/")]
        public IActionResult Index()
        {
            var jsonData = _fileHelper.GetJSONData(Directory.GetCurrentDirectory());
            ViewBag.jsonData = jsonData;

            return View();
        }
    }
}
