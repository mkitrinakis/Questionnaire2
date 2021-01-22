using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        private int questionnaireID = 1 ;
        private string userName = "UserName1"; 

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _appSettings = appSettings; 
        }

        public IActionResult Index()
        {
            // ViewBag.Login = HttpContext.Session.GetString("LoginName") ?? "N/A"; 
            MySQLContext mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContext)) as MySQLContext;
            ViewBag.UserStatus = mySQLContext.getUserStatus(questionnaireID, userName); 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.SetString("LoginName", null);
            ViewBag.LoginName = null; 
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
            ViewBag.LoginName = loginName ;
            return RedirectToAction("Index");
        }


        public ActionResult Questionnaire()
        {
            // InMemory.UserToken userToken = InMemory.getUserToken(HttpContext);
            InMemory.UserToken userToken = new InMemory.UserToken()  { isAuthenticated = true, userName = userName };
           // ViewBag.TempVar = "TempVal";
            if (!userToken.isAuthenticated) { return RedirectToAction("LogIn");  }
            MySQLContext mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContext)) as MySQLContext;
            // QuestionnaireModel questionnaire = InMemory.GetQuestionnaire(); 
            QuestionnaireModel questionnaire = mySQLContext.getAnswers(1, userToken.userName);
            questionnaire.InfoMessage = questionnaire.InfoMessage ?? "";
            questionnaire.ErrorMessage = questionnaire.ErrorMessage ?? ""; 
            questionnaire.UserName = userToken.userName;
            questionnaire.UserStatus = mySQLContext.getUserStatus(questionnaireID, userName);
            return View(questionnaire);
        }

        [HttpPost]
        public ActionResult Questionnaire(QuestionnaireModel questionnaire)
        {
            string result = "";
            MySQLContext mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContext)) as MySQLContext;
            questionnaire.clearMessages(); 
            string userName = questionnaire.UserName;
            if (!userName.Trim().Equals(""))
            {
                if (!mySQLContext.postAnswers(1, userName , questionnaire)) { questionnaire.ErrorMessage += "... CHECK THE INPUT !"; }
            }
            else
            {
                { questionnaire.ErrorMessage += "... IT SEEMS YOU LOST THE SESSION !"; }
            }
         
            return View(questionnaire);
        }


        [HttpPost]
        public ActionResult QSave(QuestionnaireModel questionnaire)
        {
            string result = "";
            MySQLContext mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContext)) as MySQLContext;
            
            questionnaire.clearMessages(); 
            if (!userName.Trim().Equals(""))
            {
                if (!mySQLContext.postAnswers(questionnaireID, userName, questionnaire)) { questionnaire.ErrorMessage += "... CHECK THE INPUT !"; }
                else
                {
                    questionnaire.InfoMessage = "H Προσωρινή Αποθήκευση έγινε επιτυχώς. Μπορείτε να συνεχίσετε με την συμπλήρωση του ερωτηματολογίου.";
                }
            }
            else
            {
                { questionnaire.ErrorMessage += "... IT SEEMS YOU LOST THE SESSION !"; }
            }
            return View("Questionnaire", questionnaire);
        }

        public ActionResult QSubmit(QuestionnaireModel questionnaire)
        {
            string result = "";

            List<string> errors = questionnaire.validateNotFilled();
            bool passed = errors.Count.Equals(0);

            if (passed)
            {
                
                if (!userName.Trim().Equals(""))
                {
                    MySQLContext mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContext)) as MySQLContext;
                    questionnaire.clearMessages(); 
                    if (!mySQLContext.postAnswers(questionnaireID, userName, questionnaire))  // save failed 
                    { questionnaire.ErrorMessage += "... CHECK THE INPUT !"; }
                    else
                    {
                        if (!mySQLContext.submitQuestionnaire(questionnaireID, userName, questionnaire))  // update of submit table failed 
                        {
                            return View("Questionnaire", questionnaire);
                            
                        }
                        else { questionnaire.InfoMessage = "H υποβολή του Ερωτηματολογίου έγινε Επιτυχώς"; }   // 
                    }
                   
                }
                else  // userName lost
                {
                    { questionnaire.ErrorMessage += "H υποβολή δεν έγινε επιτυχώς. Κάποιο πρόβλημα υπάρχει με το Session. Πρέπει να ξανακάνετε login.!"; }
                }

                return View("Questionnaire", questionnaire); // EVERYTHING OK !!
            }
            else // validation failed 
            {
                questionnaire.ErrorMessage = String.Join("<br/>", errors);
                return View("Questionnaire", questionnaire);
            }
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
