using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web; 
using System.ComponentModel.DataAnnotations;
using Questionnaire2.Helpers;

namespace Questionnaire2.Models
{
    public class QuestionnaireModel
    {
        //[Display(Name = "Serial Number Εκτυπωτή")]
        //public string SNoPrinter { get; set; }
        //public bool OKPrinter { get; set; }

        //[Display(Name = "Serial Number Υπολογιστή")]
        //public string SNoPC { get; set; }

        //public bool OKPC { get; set; }

        //[Display(Name = "Serial Number Modem")]
        //public string SNoModem { get; set; }
        //public bool OKModem { get; set; }

        //[Display(Name = "Serial Number USB")]
        //public string SNoUSB { get; set; }
        //public bool OKUSB { get; set; }

        //[Display(Name = "Κωδικός Σχολείου")]

        //public string SchoolCode { get; set; }


        //[Display(Name = "Σχολείο (Περιγραφή)")]

        //public string SchoolDescription { get; set; }

        //[Display(Name = "Χρήστης")]
        //public string UserCode { get; set; }


        //[Display(Name = "Ιστορικό")]
        //public string History { get; set; }


        public int QuestionnerID; 


        public string Q1 { get; set; }
        public string Q1Label = "1) Ποιο είναι το φύλο σας";
        public Dictionary<int, string> Q1Options = InMemory.getGender();

        public string Q2 { get; set; }
        public string Q2Label = "2)	Ποια είναι η ειδικότητά σας"; 
        public Dictionary<int, string> Q2Options = InMemory.getGender();

        public string Q3 { get; set; }
        public string Q3Label = "Ερώτηση Ελεύθερου Κειμένου";

        public string Q4 { get; set; }
        public string Q4Label = "Er 4";
        public Dictionary<int, string> Q4Options = InMemory.getYesNoNA();
        public string Q5 { get; set; }
        public string Q5Label = "Question 5";
        public Dictionary<int, string> Q5Options = InMemory.getYesNoNA();
        public string Q6 { get; set; }
        public string Q6Label = "Question 6";
        public Dictionary<int, string> Q6Options = InMemory.getYesNoNA();

        public string Q7 { get; set; }
        public string ErrorMessage { get; set; }


        public QuestionnaireModel()
        {
            Q1 = "";
            Q2 = "";
            Q3 = "";
            Q4 = "";
            Q5 = "";
            Q6 = "";
            Q7 = ""; 
        }
    }
}
