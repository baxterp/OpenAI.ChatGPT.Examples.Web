using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Helpers;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class NaturalLanguageTranslatorController : Controller
    {
        [Route("~/[controller]/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
