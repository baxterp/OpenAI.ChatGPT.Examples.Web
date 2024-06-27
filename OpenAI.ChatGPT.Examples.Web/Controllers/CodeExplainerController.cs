using Microsoft.AspNetCore.Mvc;
using OpenAI.ChatGPT.Examples.Web.Helpers;
using OpenAI_API.Chat;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net.Http;
using OpenAI.ChatGPT.Examples.Web.Interfaces;

namespace OpenAI.ChatGPT.Examples.Web.Controllers
{
    public class CodeExplainerController : Controller
    {
        IFileHelper _fileHelper;
        public CodeExplainerController(IFileHelper fileHelper)
        {
            _fileHelper = fileHelper;
        }

        public IActionResult Index()
        {
            try
            {
                string siteRootDirectory = Directory.GetCurrentDirectory();
                var codeText = _fileHelper.GetCodeSnippet(siteRootDirectory);
                ViewBag.CodeSnippet = codeText;
                return View();
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText("CodeExplainerController.log", ex.Message);
                return View();
            }
        }
    }
}
