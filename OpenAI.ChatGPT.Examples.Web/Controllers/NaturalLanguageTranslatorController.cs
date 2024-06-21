using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API.Chat;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class NaturalLanguageTranslatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
