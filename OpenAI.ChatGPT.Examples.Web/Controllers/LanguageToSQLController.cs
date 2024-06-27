using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI.ChatGPT.Examples.Web.Interfaces;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class LanguageToSQLController : Controller
    {
        IFileHelper _fileHelper;

        public LanguageToSQLController(IFileHelper fileHelper) 
        { 
            _fileHelper = fileHelper;   
        }

        public IActionResult Index()
        {
            var sqlSnippet = _fileHelper.GetSQLSnippet(Directory.GetCurrentDirectory());
            ViewBag.SQLSnippet = sqlSnippet;
            var instruction = "Write a SQL query which computes the average total order value for all orders on 2024-06-26.";
            ViewBag.Instruction = instruction;
            return View();
        }
    }
}