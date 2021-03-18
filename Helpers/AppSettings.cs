using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire2.Helpers
{
    public class AppSettings
    {
        public string SQLIntegratedSecurity { get; set; }
        public string SQLDataSource { get; set; }
        public string SQLUserID { get; set; }
        public string SQLUserPassword { get; set; }

        public string[] QuestionsMax { get; set;  } 

    }
}
