using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Questionnaire2.Helpers;
using Questionnaire2.Models;


namespace Questionnaire2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IOptions<AppSettings> _appSettings;

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings; 
        }

        public IActionResult Index()
        {
            ViewBag.Login = HttpContext.Session.GetString("LoginName") ?? "N/A"; 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.SetString("LoginName", null);
            return RedirectToAction("Index");
        }

        public IActionResult LogIn()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult LogIn(string loginName)
        {
            HttpContext.Session.SetString("LoginName", loginName);
            return RedirectToAction("Index");
        }


        public ActionResult Questionnaire()
        {
            QuestionnaireModel questionnaire = InMemory.GetQuestionnaire(); 
            return View(questionnaire);
        }

        [HttpPost]
        public ActionResult Questionnaire(QuestionnaireModel questionnaire)
        {
            string result = "";
            if (questionnaire == null) questionnaire = InMemory.GetQuestionnaire();
            questionnaire.ErrorMessage = "OK"; 
            result = "Q1:" + (questionnaire.Q1 ?? "").ToString();
            result += "Q2:" + (questionnaire.Q2 ?? "").ToString();
            result += "Q3:" + (questionnaire.Q3 ?? "N/A").ToString();
            result += "Q4:" + (questionnaire.Q4 ?? "").ToString();
            result += "Q5:" + (questionnaire.Q5 ?? "").ToString();
            result += "Q6:" + (questionnaire.Q6 ??"").ToString();

            return View(questionnaire);
        }

        public IActionResult QuestionnaireRead()
        {
            QuestionnaireModel questionnaire = InMemory.GetQuestionnaire();
            return View();
        }

        

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
