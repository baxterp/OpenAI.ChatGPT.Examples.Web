using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Interfaces;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class JSONToCSharpModelController : Controller
    {
        IFileHelper _fileHelper;

        public JSONToCSharpModelController(IFileHelper fileHelper) // DI
        {
            _fileHelper = fileHelper;
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
