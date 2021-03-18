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

        private readonly AppSettings _appSettings;

        private int questionnaireID = 1 ;
        

        public HomeController(ILogger<HomeController> logger, IOptions<AppSettings> settings)
        {
            _logger = logger;
            _appSettings = settings.Value; 
        }

        public IActionResult IndexA()
        {
            // ViewBag.Login = HttpContext.Session.GetString("LoginName") ?? "N/A"; 
            MySQLContextA mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContextA)) as MySQLContextA;
            //  ViewBag.UserStatus = mySQLContext.getUserStatus(questionnaireID, userName); 
            InMemory.UserToken userToken = InMemory.getUserToken(HttpContext);
            ViewBag.IsAuthenticated = (userToken.isAuthenticated) ? "YES" : "NO"; 
            ViewBag.UserStatus =   mySQLContext.getUserStatus(questionnaireID, userToken.userName);

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
            return RedirectToAction("IndexA");
        }

        public IActionResult LogIn()
        {
            ViewBag.ErrorMessage = "";
            ViewBag.DisabledPropery = "";
            if (InMemory.exceededAuthFailures(HttpContext))
            {
                ViewBag.ErrorMessage = "Πολλές Φορές Λάθος 'Ονομα Χρήστη' ή Password, Βγείτε από την εφαρμογή, κλείστε τον broswer και ξαναπροσπαθήστε";
                ViewBag.DisabledPropery = "Disabled = \"Disabled\"";
            }
            return View(); 
        }

        [HttpPost]
        public IActionResult LogIn(string loginName, string password)
        {
            ViewBag.ErrorMessage = "";
            ViewBag.DisabledPropery = "";
            MySQLContextA mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContextA)) as MySQLContextA;
            if (InMemory.exceededAuthFailures(HttpContext))
            {
                ViewBag.ErrorMessage = "Πολλές Φορές Λάθος 'Ονομα Χρήστη' ή Password, Βγείτε από την εφαρμογή, κλείστε τον broswer και ξαναπροσπαθήστε";
                ViewBag.DisabledPropery = "Disabled = \"Disabled\"";
            }
            else
            {
                string userName = mySQLContext.getUserToken(loginName, password);
                if (!userName.Trim().Equals(""))
                {
                    InMemory.resetAuthFailures(HttpContext);
                    HttpContext.Session.SetString("LoginName", loginName);
                    ViewBag.LoginName = loginName;
                    return RedirectToAction("IndexA");
                }
                else
                {
                    InMemory.increaseAuthFailures(HttpContext);
                    ViewBag.ErrorMessage = "Λάθος Ονομα Χρήστη ή Password";

                }
            }

            return View();
        }

        public ActionResult QuestionnaireA()
        {
             InMemory.UserToken userToken = InMemory.getUserToken(HttpContext);
            // InMemory.UserToken userToken = new InMemory.UserToken(UserToken()  { isAuthenticated = true, userName = userName };
           
            if (!userToken.isAuthenticated) { return RedirectToAction("LogIn");  }
            MySQLContextA mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContextA)) as MySQLContextA;
            // QuestionnaireModel questionnaire = InMemory.GetQuestionnaire(); 
            QuestionnaireModel questionnaire = mySQLContext.getAnswers(1, userToken.userName);
            questionnaire.InfoMessage = questionnaire.InfoMessage ?? "";
            questionnaire.ErrorMessage = questionnaire.ErrorMessage ?? ""; 
            questionnaire.UserName = userToken.userName;
            questionnaire.UserStatus = mySQLContext.getUserStatus(questionnaireID, userToken.userName);
            return View(questionnaire);
        }

        [HttpPost]
        public ActionResult QuestionnaireA(QuestionnaireModelA questionnaire)
        {
            
            MySQLContextA mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContextA)) as MySQLContextA;
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
            InMemory.UserToken userToken = InMemory.getUserToken(HttpContext);
            questionnaire = mySQLContext.getAnswers(1, userToken.userName);
            return View(questionnaire);
        }


        [HttpPost]
        public ActionResult QSave(QuestionnaireModelA questionnaire)
        {
            
            MySQLContextA mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContextA)) as MySQLContextA;
            
            questionnaire.clearMessages();
            string userName = InMemory.getUserToken(HttpContext).userName;
            if (!userName.Trim().Equals(""))
            {
                if (!mySQLContext.postAnswers(questionnaireID, userName, questionnaire)) { questionnaire.ErrorMessage += "... CHECK THE INPUT !"; }
                else
                {
                    questionnaire = mySQLContext.getAnswers(1, userName);
                    questionnaire.InfoMessage = "H Προσωρινή Αποθήκευση έγινε επιτυχώς. Μπορείτε να συνεχίσετε με την συμπλήρωση του ερωτηματολογίου.";
                }
            }
            else
            {
                {
                    questionnaire = mySQLContext.getAnswers(1, userName);
                    questionnaire.ErrorMessage += "... IT SEEMS YOU LOST THE SESSION !";
                }
            }
            return View("QuestionnaireA", questionnaire);
        }

        public ActionResult QSubmit(QuestionnaireModelA questionnaire)
        {
            

            List<string> errors = questionnaire.validateNotFilled(_appSettings);
            bool passed = errors.Count.Equals(0);

            if (passed)
            {
                string userName = InMemory.getUserToken(HttpContext).userName; 
                if (!userName.Trim().Equals(""))
                {
                    MySQLContextA mySQLContext = HttpContext.RequestServices.GetService(typeof(Questionnaire2.Models.MySQLContextA)) as MySQLContextA;
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
