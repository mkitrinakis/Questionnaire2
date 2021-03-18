using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Questionnaire2.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Questionnaire2.Helpers
{
    public static class InMemory
    {
        public static QuestionnaireModelB GetQuestionnaire()
        {
            QuestionnaireModelB rs = new QuestionnaireModelB();
            rs.ErrorMessage = "Everything OK";

            //rs.History = "History";
            //rs.OKModem = false;
            //rs.OKPC = false;
            //rs.OKPrinter = false;
            //rs.OKUSB = true;
            //rs.SchoolCode = "school - Code";
            //rs.SchoolDescription = "description";
            //rs.SNoModem = "snoModem";
            //rs.SNoPC = "snoPC";
            //rs.SNoPrinter = "SNOPronter";
            //rs.SNoUSB = "SNOUSB";
            //rs.UserCode = "User XXX Code";

            return rs;
        }

        public static Dictionary<int, string> getSchoolDescriptions()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 0, "No Preference"},
                { 1, "I hate school"},
                { 2, "Over Easy"},
                { 3, "Sunny Side Up"},
                { 4, "Scrambled School"},
                { 5, "Hard Boiled Scool"}
            };
            return rs;
        }

        public static Dictionary<int, string> getYesNo()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1, "Ναι"},
                { 0, "Οχι"},
            };
            return rs;
        }
        public static Dictionary<int, string> getYesNoNA()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1, "Ναι"},
                { -1, "Δεν είμαι σίγουρος/η"},
                { 0, "Οχι"},
            };
            return rs;
        }

        public static Dictionary<int, string> getGender()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1, "Άνδρας"},
                { 0, "Γυναίκα"},
            };
            return rs;
        }

        public static Dictionary<int, string> getChoices(string[] options)
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string> { };
            int counter = 0;
            foreach (string option in options)
            {
                counter++;
                rs.Add(counter, option);
            }
            return rs;
        }

        public static Dictionary<int, string> getQualityScale()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1, "Εξαιρετική"},
                { 2, "Πολύ Καλή"},
                { 3, "Μέτρια"},
                { 4, "Αδιάφορη"},
            };
            return rs;
        }

        public static Dictionary<int, string> getQuantityScale2()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1, "Πάρα πολύ"},
                { 2, "Πολύ"},
                { 3, "Μέτρια"},
                { 4, "Λίγο"},
                { 5, "Καθόλου/Υπήρχε η δυνατότητα αλλά δεν κατάφερα να την χρησιμοποιήσω λόγω τεχνικών προβλημάτων"},
            };
            return rs;
        }

        public static Dictionary<int, string> getProblemsScale()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1, "Όχι, δεν υπήρχαν"},
                { 2, "Λίγα"},
                { 3, "Πολλά"},
                { 4, "Πάρα πολλά"},
            };
            return rs;
        }

        public static Dictionary<int, string> getEduTypes()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1, "ασύγχρονη τηλεκπαίδευση"},
                { 2, "σύγχρονη & ασύγχρονη"},
                { 3, "δεν υπήρχε τηλεκπαίδευση"},
                { 4, "δεν γνωρίζω"},
                { 5, "Άλλο" }
                };
            return rs;
        }


        public static Dictionary<int, string> getPlatformsAsync()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1,"E-class" }, {2,"E-me" }, {3, "Moodle" },  {4,"Edmodo" },{5,"Google classroom" },{6,"Άλλη(Συμπληρώστε)" }

            };
            return rs;
        }

        public static Dictionary<int, string> getPlatformsSync()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1,"Webex" }, {2,"Google Meet" }, {3, "Skype" },  {4,"Zoom" },{5,"Άλλη(Συμπληρώστε)" }
            };
            return rs;
        }

        public static Dictionary<int, string> getGrades()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1,"Νηπιαγωγείο" }, {2,"Δημοτικό" }, {3,"Γυμνάσιο" },{4,"Γενικό Λύκειο" },{5,"Επαγγελματικό Λύκειο" }

            };
            return rs;
        }

        public static Dictionary<int, string> getParticipantRates()
        {
            Dictionary<int, string> rs = new System.Collections.Generic.Dictionary<int, string>
            {
                { 1,"80-100% των εκπαιδευομένων" }, {2,"60-79% των εκπαιδευομένων" }, {3, "40-59% των εκπαιδευομένων" },  {4,"<40% των εκπαιδευομένων" }

            };
            return rs;
        }

        public struct UserToken
        {
            public bool isAuthenticated; 
            public string userName; 
        }

        public  static UserToken getUserToken(HttpContext httpContext)
        {
            return new UserToken() { isAuthenticated = true, userName = "username1" }; 
            string _userName = (httpContext.Session.GetString("LoginName") ?? "").ToString().Trim();
            return new UserToken { isAuthenticated = _userName.Equals("") ? false : true, userName = _userName }; 
        }

        public static int getAuthFailures(HttpContext httpContext)
        {
            try
            {
                int? temp = (httpContext.Session.GetInt32("AuthFailures")); 
                if (temp == null)
                {
                    return 0; 
                }
                else { return (int)temp; }
            }
            catch  { return 0; }
        }

        public static void increaseAuthFailures(HttpContext httpContext)
        {
            int tmp = getAuthFailures(httpContext);
            tmp++;
            httpContext.Session.SetInt32("AuthFailures", tmp); 
        }

        public static void resetAuthFailures(HttpContext httpContext)
        {
            
            httpContext.Session.SetInt32("AuthFailures", 0);
        }

        public static bool exceededAuthFailures(HttpContext httpContext)
        {
            return getAuthFailures(httpContext) >= 3; 
        }

    }
}
