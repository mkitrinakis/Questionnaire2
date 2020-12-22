using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Questionnaire2.Helpers
{
    public static class Log
    {
        static string path = "c:\\Questionnaire\\log2.txt";

        public static void write(string msg)
        {
            //  Console.WriteLine(msg); 
            Console.WriteLine(msg);
            using (StreamWriter w = File.AppendText(path))
            {
                w.WriteLine(DateTime.Now.ToString() + "   " + msg);
                w.Close();
            }
        }
    }
}

