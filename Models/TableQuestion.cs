using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire2.Models
{
    public class TableQuestion
    {

        public string label = "TableLabel"; 
        public Dictionary<int, string> options;
        public string val { get; set; } = "TableVal"; 
        public List<TableQuestionRow> rows { get; set; } 
    }
    public class TableQuestionRow
    {
        public string val { get; set; } = "";
        public string detail { get; set; } = ""; 
        public string label { get; set; } = "";
        public Dictionary<int, string> options; 
    }
}
