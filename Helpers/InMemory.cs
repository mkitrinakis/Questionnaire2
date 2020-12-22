using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Questionnaire2.Models;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire2.Helpers
{
    public static class InMemory
    {
        public  static QuestionnaireModel  GetQuestionnaire()
        {
            QuestionnaireModel rs = new QuestionnaireModel();
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

        public static Dictionary<int,string> getYesNo()
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
                rs.Add(counter, option); 
            }
            return rs; 
        }


        
    }
}
