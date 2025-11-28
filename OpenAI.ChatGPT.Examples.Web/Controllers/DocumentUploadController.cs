using Microsoft.AspNetCore.Mvc;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class DocumentUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
