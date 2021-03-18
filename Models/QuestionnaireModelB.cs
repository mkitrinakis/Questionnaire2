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
    public class QuestionnaireModelB : QuestionnaireModel 
    {
    
        public int QuestionnerID { get; set; }

        public string InfoMessage { get; set; }
        public string  ErrorMessage { get; set; } 

        public string UserName { get; set; }

        public UserHelper.UserStatus UserStatus { get; set; } = UserHelper.UserStatus.New; 
                        public string Q1 { get; set; } = ""; 
        public string Q1Label = "1.	Σημειώστε το είδος τηλεκπαίδευσης που πραγματοποιήθηκε σε κάθε μάθημα στο ΙΕΚ σας (ασύγχρονη τηλεκπαίδευση, σύγχρονη τηλεκπαίδευση, σύγχρονη και ασύγχρονη, δεν υπήρξε τηλεκπαίδευση, δε γνωρίζω, άλλο – ελεύθερο κείμενο))";
         public Dictionary<int, string> Q1Options = InMemory.getGender();



        public string Q2 { get; set; } = "";
        public string Q2Label = "2. Ποια είναι η ειδικότητά σας";
        public Dictionary<int, string> Q2Options = InMemory.getGender();

        public string Q3 { get; set; } = "";
        public string Q3Label = "3. Ποια είναι η ηλικία σας";
        public Dictionary<int, string> Q3Options = InMemory.getChoices(new string[] { "<35", "35-44", "45-54", ">55" });


        public string Q4 { get; set; } = "";
        public string Q4Label = "4. Πόσα χρόνια εργάζεστε στη δημόσια εκπαίδευση (σε σχολικές μονάδες)";
        public Dictionary<int, string> Q4Options = InMemory.getChoices(new string[] { "<10", "10-20", "21-30", "21>30" });
        public string Q5 { get; set; } = "";
        public string Q5Label = "5. Τύπος σχολείου στον οποίο υπηρετήσατε την προηγούμενη σχολική χρονιά";
        public Dictionary<int, string> Q5Options = InMemory.getGrades();
        public string Q6 { get; set; } = "";
        public string Q6Label = "6. Πόσα τμήματα είχε το σχολείο σας την περισυνή χρονιά;";
        public Dictionary<int, string> Q6Options = InMemory.getChoices(new string[] { "<6", "6-12", ">12" }); 

        public string Q7 { get; set; } = "";
        public string Q7Label = "7. Είχατε χρησιμοποιήσει κάποια πλατφόρμα ασύγχρονης τηλεκπαίδευσης πριν το κλείσιμο των σχολείων το Μάρτιο, λόγω του covid-19;";
        public Dictionary<int, string> Q7Options = InMemory.getYesNo();

        public string Q8 { get; set; } = "";
        public string Q8Label = "8. Αν η απάντηση στην προηγούμενη ερώτηση είναι ‘Ναι’, ποιες πλατφόρμες είχατε δοκιμάσει;";
        public Dictionary<int, string> Q8Options = InMemory.getPlatformsAsync();
        public string Q8OptionsOther { get; set; } = ""; 



        public string Q9 { get; set; } = "";
        public string Q9Label = "9.	Ποια πλατφόρμα ασύγχρονης τηλεκπαίδευσης χρησιμοποιήσατε στο διάστημα που τα σχολεία ήταν κλειστά (Μάρτιος-Μάιος);";
        public Dictionary<int, string> Q9Options = InMemory.getPlatformsAsync();
        public string Q9OptionsOther { get; set; } = ""; 

        public string Q10 { get; set; } = "";
        public string Q10Label = "10. Πόσο συχνά εφαρμόσατε ασύγχρονη τηλεκπαίδευση με τους μαθητές σας το διάστημα που τα σχολεία ήταν κλειστά (Μάρτιος-Μάιος);";
        public Dictionary<int, string> Q10Options = InMemory.getChoices(new string[] { "4-5 φορές τη βδομάδα", "2-4 φορές τη βδομάδα", "1 φορά τη βδομάδα", "Λιγότερο από μια φορά τη βδομάδα", "Καθόλου" }); 


        public string Q11 { get; set; } = "";
        public string Q11Label = "11. Υπήρχαν τεχνικά προβλήματα στην πλατφόρμα ασύγχρονης τηλεκπαίδευσης που χρησιμοποιήσατε;";
        public Dictionary<int, string> Q11Options = InMemory.getProblemsScale(); 

        public string Q12 { get; set; } = "";
        public string Q12Label = "12. Πώς θα χαρακτηρίζατε την υποστήριξη που είχατε στη χρήση της πλατφόρμας ασύγχρονης τηλεκπαίδευσης και σε τυχόν προβλήματα(απαντήστε μόνο αν ήσαστε μέλος της ομάδας υποστήριξης)";
        public Dictionary<int, string> Q12Options = InMemory.getChoices(new string[] { "Άριστη", "Πολύ ικανοποιητική", "Επαρκής", "Περιορισμένη", "Ανύπαρκτη" }); 

        public string Q13 { get; set; } = "";
        public string Q13Label = "13. Πόσο χρησιμοποιήσατε τις δυνατότητες της πλατφόρμας ασύγχρονης τηλεκπαίδευσης που χρησιμοποιήσατε;";
        public Dictionary<int, string> Q13Options = InMemory.getQuantityScale2();
        public string Q131 { get; set; } = "";
        public string Q131Label = "Αποστολή αρχείων στους μαθητές";
        public Dictionary<int, string> Q131Options = InMemory.getQuantityScale2(); 
        public string Q132 { get; set; } = "";
        public string Q132Label = "Ανάθεση εργασιών με καταληκτική ημερομηνία παράδοσης";
        public Dictionary<int, string> Q132Options = InMemory.getQuantityScale2();
        public string Q133 { get; set; } = "";
        public string Q133Label = "Βαθμολόγηση των εργασιών των μαθητών και ανατροφοδότηση";
        public Dictionary<int, string> Q133Options = InMemory.getQuantityScale2();

        public string Q134 { get; set; } = "";
        public string Q134Label = "Δημιουργίας δομημένου μαθήματος";
        public Dictionary<int, string> Q134Options = InMemory.getQuantityScale2();
        public string Q135 { get; set; } = "";
        public string Q135Label = "Άμεση επικοινωνία με μαθητές (Forum-chat-μηνύματα-τοίχος)";
        public Dictionary<int, string> Q135Options = InMemory.getQuantityScale2();
        public string Q136 { get; set; } = "";
        public string Q136Label = "Δημιουργία ασκήσεων αυτοαξιολόγησης (πχ κουίζ)";
        public Dictionary<int, string> Q136Options = InMemory.getQuantityScale2();

        
        public string Q14 { get; set; } = "";
        public string Q14Label = "14. Ποια ήταν η συμμετοχή των μαθητών σας στην ασύγχρονη τηλεκπαίδευση;";
        public Dictionary<int, string> Q14Options = InMemory.getChoices(new string[] { "80-100% των μαθητών κάθε τμήματος", "60-79% των μαθητών κάθε τμήματος", "40-59% των μαθητών κάθε τμήματος", "<40% των μαθητών κάθε τμήματος" });
        public string Q15 { get; set; } = "";
        public string Q15Label = "15. Πώς θα χαρακτηρίζατε την ανταπόκριση των μαθητών σας που συμμετείχαν στην ασύγχρονη τηλεκπαίδευση;";
        public Dictionary<int, string> Q15Options = InMemory.getQualityScale();
        public string Q16 { get; set; } = "";
        public string Q16Label = "16. Ποιο/α εκπαιδευτικό υλικό χρησιμοποιήσατε στην ασύγχρονη τηλεκπαίδευση;";
        public Dictionary<int, string> Q16Options = InMemory.getChoices(new string[] { "Κατασκεύασα εκ νέου", "Χρησιμοποίησα υλικό που είχα ήδη", "Υλικό συναδέρφων ή από άλλες πηγές", "Υλικό από το φωτόδεντρο(https://dschool.edu.gr/)", "Υλικό από το Πανελλήνιο Σχολικό Δίκτυο", "Υλικό από την πλατφόρμα «Αίσωπος» (http://aesop.iep.edu.gr/)", "Άλλο (συμπληρώστε)" }); 
        public string Q17 { get; set; } = "";
        public string Q17Label = "17. Αν χρησιμοποιήσατε το φωτόδεντρο για άντληση υλικού, ποιο/α συγκεκριμένα φωτόδεντρα χρησιμοποιήσατε;";
        public Dictionary<int, string> Q17Options = InMemory.getChoices(new string[] { "Το φωτόδεντρο «μαθησιακά αντικείμενα»", "Το φωτόδεντρο «εκπαιδευτικά βίντεο»", "Το φωτόδεντρο «Εκπαιδευτικό Λογισμικό»", "Το φωτόδεντρο  «e - yliko χρηστών»", "Το φωτόδεντρο «ανοιχτές εκπαιδευτικές πρακτικές»", "Τα διαδραστικά σχολικά βιβλία" }); 
        public string Q18 { get; set; } = "";
        public string Q18Label = "18. Θεωρείτε ότι πρέπει η ασύγχρονη τηλεκπαίδευση να λειτουργεί συμπληρωματικά με την παραδοσιακή διδασκαλία;"; 
        public Dictionary<int, string> Q18Options = InMemory.getYesNo();

        public string Q19 { get; set; } = "";
        public string Q19Label = "19. Χρησιμοποιήσατε κάποια πλατφόρμα σύγχρονης τηλεκπαίδευσης το διάστημα που τα σχολεία ήταν κλειστά (Μάρτιος έως Μάιος);";
        public Dictionary<int, string> Q19Options = InMemory.getYesNo();

        public string Q20 { get; set; } = "";
        public string Q20Label = "20.	Πόσο συχνά εφαρμόσατε σύγχρονη τηλεκπαίδευση με τους μαθητές σας;";
        public Dictionary<int, string> Q20Options = InMemory.getChoices(new string[] { "4-5 φορές τη βδομάδα","2-4 φορές τη βδομάδα","1 φορά τη βδομάδα","Λιγότερο από 1 φορά την εβδομάδα","Καθόλου" });


        public string Q21 { get; set; } = "";
        public string Q21Label = "21.	Ποια ήταν η συμμετοχή των μαθητών σας στην σύγχρονη τηλεκπαίδευση;";
        public Dictionary<int, string> Q21Options = InMemory.getChoices(new string[] { "80-100% των μαθητών κάθε τμήματος","60-79% των μαθητών κάθε τμήματος","40-59% των μαθητών κάθε τμήματος","<40% των μαθητών κάθε τμήματος" });


        public string Q22 { get; set; } = "";
        public string Q22Label = "22. Πώς θα χαρακτηρίζατε την ανταπόκριση των μαθητών σας που συμμετείχαν στην σύγχρονη τηλεκπαίδευση;";
        public Dictionary<int, string> Q22Options = InMemory.getQualityScale(); 

        


        public QuestionnaireModelB()
        {
        
        }

        public void clearMessages()
        {
            this.ErrorMessage = "";
            this.InfoMessage = ""; 
        }


        public List<string> validateNotFilled(AppSettings appSettings)
        {
            List<string> rs = new List<string>();
            Dictionary<string, string> vals = new Dictionary<string, string>();
            string test = appSettings.SQLDataSource; 
            string[] questionsMax = appSettings.QuestionsMax; 
            foreach(string q in questionsMax)
          //  for (int i=1; i<=22; i++)
            {
               string val = (string) typeof(QuestionnaireModelB).GetProperty("Q" + q).GetValue(this);
                vals.Add(q, val);
                if (q.Equals("8") && !vals["7"].Equals("1")) continue; 
                if ((val ?? "").Trim().Equals("")) { rs.Add("Η ερώτηση (" + q + ") δεν έχει συμπληρωθεί"); }
                if (q.Equals("8") || q.Equals("9"))
                {
                    if (val.Equals("5") )
                    {
                        string other = (string)typeof(QuestionnaireModelB).GetProperty("Q" + q + "OptionsOther").GetValue(this);
                        if ((other ?? "").Trim().Equals("")) { { rs.Add("Η ερώτηση (" + q + ") πρέπει να συμπληρωθεί η επιλογή 'Αλλο' "); } }
                    }
                }
            }
            if (this.Q8.Trim().Equals("5") && (this.Q8OptionsOther ?? "").Trim().Equals(""))
            {
                rs.Add("Στην ερώτηση (8) πρέπει να συμπληρωθεί η επιλογή 'Αλλο' "); 
            }
            if (this.Q9.Trim().Equals("5") && (this.Q9OptionsOther ?? "").Trim().Equals(""))
            {
                rs.Add("Στην ερώτηση (9) πρέπει να συμπληρωθεί η επιλογή 'Αλλο' ");
            }
            return rs; 
        }
    }
}



