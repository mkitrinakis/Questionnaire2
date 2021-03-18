using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Questionnaire2.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace Questionnaire2.Models
{
   public  interface QuestionnaireModel
    {

        public int QuestionnerID { get; set; }

        public string InfoMessage { get; set; }
        public string ErrorMessage { get; set; }

        public string UserName { get; set; }

        public UserHelper.UserStatus UserStatus { get; set; }

        public void clearMessages();

        public List<string> validateNotFilled(AppSettings appSettings); 
    }
}
