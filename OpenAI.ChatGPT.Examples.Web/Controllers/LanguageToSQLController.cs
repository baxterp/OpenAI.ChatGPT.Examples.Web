using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Helpers;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class LanguageToSQLController : Controller
    {
        public IActionResult Index()
        {
            var sqlSnippet = FileHelper.GetSQLSnippet(Directory.GetCurrentDirectory());
            ViewBag.SQLSnippet = sqlSnippet;
            var instruction = "Write a SQL query which computes the average total order value for all orders on 2024-06-26.";
            ViewBag.Instruction = instruction;
            return View();
        }
    }
}