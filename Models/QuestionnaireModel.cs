using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web; 
using System.ComponentModel.DataAnnotations;
using Questionnaire2.Helpers;
using System.Collections;

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
        public string Q1Label = "Ποιο είναι το φύλο σας";
        public Dictionary<int, string> Q1Options = InMemory.getGender();

        public string Q2 { get; set; }
        public string Q2Label = "Ποια είναι η ειδικότητά σας";
        public Dictionary<int, string> Q2Options = InMemory.getGender();

        public string Q3 { get; set; }
        public string Q3Label = "Ποια είναι η ηλικία σας";
        public Dictionary<int, string> Q3Options = InMemory.getChoices(new string[] { "<35", "35-44", "45-54", ">55" });


        public string Q4 { get; set; }
        public string Q4Label = "Πόσα χρόνια εργάζεστε στη δημόσια εκπαίδευση (σε σχολικές μονάδες)";
        public Dictionary<int, string> Q4Options = InMemory.getChoices(new string[] { "<10", "10-20", "21-30", "21>30" });
        public string Q5 { get; set; }
        public string Q5Label = "Τύπος σχολείου στον οποίο υπηρετήσατε την προηγούμενη σχολική χρονιά";
        public Dictionary<int, string> Q5Options = InMemory.getGrades();
        public string Q6 { get; set; }
        public string Q6Label = "Πόσα τμήματα είχε το σχολείο σας την περσυνή χρονιά;";
        public Dictionary<int, string> Q6Options = InMemory.getChoices(new string[] { "<6", "6-12", ">12" }); 

        public string Q7 { get; set; }
        public string Q7Label = "Είχατε χρησιμοποιήσει κάποια πλατφόρμα ασύγχρονης τηλεκπαίδευσης πριν το κλείσιμο των σχολείων το Μάρτιο, λόγω του covid-19;";
        public Dictionary<int, string> Q7Options = InMemory.getYesNo();

        public string Q8 { get; set; }
        public string Q8Label = "Αν η απάντηση στην προηγούμενη ερώτηση είναι ‘Ναι’, ποιες πλατφόρμες είχατε δοκιμάσει;";
        public Dictionary<int, string> Q8Options = InMemory.getPlatforms();



        public string Q9 { get; set; }
        public string Q9Label = "9)	Ποια πλατφόρμα ασύγχρονης τηλεκπαίδευσης χρησιμοποιήσατε στο διάστημα που τα σχολεία ήταν κλειστά (Μάρτιος-Μάιος);";
        public Dictionary<int, string> Q9Options = InMemory.getPlatforms(); 

        public string Q10 { get; set; }
        public string Q10Label = "Πόσο συχνά εφαρμόσατε ασύγχρονη τηλεκπαίδευση με τους μαθητές σας το διάστημα που τα σχολεία ήταν κλειστά (Μάρτιος-Μάιος);";
        public Dictionary<int, string> Q10Options = InMemory.getChoices(new string[] { "4-5 φορές τη βδομάδα", "2-4 φορές τη βδομάδα", "1 φορά τη βδομάδα", "Λιγότερο από μια φορά τη βδομάδα", "Καθόλου" }); 


        public string Q11 { get; set; }
        public string Q11Label = "Υπήρχαν τεχνικά προβλήματα στην πλατφόρμα ασύγχρονης τηλεκπαίδευσης που χρησιμοποιήσατε;";
        public Dictionary<int, string> Q11Options = InMemory.getQuantityScale(); 

        public string Q12 { get; set; }
        public string Q12Label = "Πώς θα χαρακτηρίζατε την υποστήριξη που είχατε στη χρήση της πλατφόρμας ασύγχρονης τηλεκπαίδευσης και σε τυχόν προβλήματα(απαντήστε μόνο αν ήσαστε μέλος της ομάδας υποστήριξης)";
        public Dictionary<int, string> Q12Options = InMemory.getChoices(new string[] { "Άριστη", "Πολύ ικανοποιητική", "Επαρκής", "Περιορισμένη", "Ανύπαρκτη" }); 

        public string Q13 { get; set; }
        public string Q13Label = "Πόσο χρησιμοποιήσατε τις δυνατότητες της πλατφόρμας ασύγχρονης τηλεκπαίδευσης που χρησιμοποιήσατε;";
        public Dictionary<int, string> Q13Options = InMemory.getYesNo(); // TO CHANGE
        public string Q14 { get; set; }
        public string Q14Label = "Ποια ήταν η συμμετοχή των μαθητών σας στην ασύγχρονη τηλεκπαίδευση;";
        public Dictionary<int, string> Q14Options = InMemory.getChoices(new string[] { "80-100% των μαθητών κάθε τμήματος", "60-79% των μαθητών κάθε τμήματος", "40-59% των μαθητών κάθε τμήματος", "<40% των μαθητών κάθε τμήματος" });
        public string Q15 { get; set; }
        public string Q15Label = "15)	Πώς θα χαρακτηρίζατε την ανταπόκριση των μαθητών σας που συμμετείχαν στην ασύγχρονη τηλεκπαίδευση;";
        public Dictionary<int, string> Q15Options = InMemory.getGoodScale();
        public string Q16 { get; set; }
        public string Q16Label = "Ποιο/α εκπαιδευτικό υλικό χρησιμοποιήσατε στην ασύγχρονη τηλεκπαίδευση;";
        public Dictionary<int, string> Q16Options = InMemory.getChoices(new string[] { "Κατασκεύασα εκ νέου", "Χρησιμοποίησα υλικό που είχα ήδη", "Υλικό συναδέρφων ή από άλλες πηγές", "Υλικό από το φωτόδεντρο(https://dschool.edu.gr/)", "Υλικό από το Πανελλήνιο Σχολικό Δίκτυο", "Υλικό από την πλατφόρμα «Αίσωπος» (http://aesop.iep.edu.gr/)", "Άλλο (συμπληρώστε)" }); 
        public string Q17 { get; set; }
        public string Q17Label = "17)	Αν χρησιμοποιήσατε το φωτόδεντρο για άντληση υλικού, ποιο/α συγκεκριμένα φωτόδεντρα χρησιμοποιήσατε;";
        public Dictionary<int, string> Q17Options = InMemory.getChoices(new string[] { "Το φωτόδεντρο «μαθησιακά αντικείμενα»", "Το φωτόδεντρο «εκπαιδευτικά βίντεο»", "Το φωτόδεντρο «Εκπαιδευτικό Λογισμικό»", "Το φωτόδεντρο  «e - yliko χρηστών»", "Το φωτόδεντρο «ανοιχτές εκπαιδευτικές πρακτικές»", "Τα διαδραστικά σχολικά βιβλία" }); 



        public string Q18 { get; set; }
        public string Q18Label = "Θεωρείτε ότι πρέπει η ασύγχρονη τηλεκπαίδευση να λειτουργεί συμπληρωματικά με την παραδοσιακή διδασκαλία;"; 
        public Dictionary<int, string> Q18Options = InMemory.getYesNo();
        


        public string ErrorMessage { get; set; }


        public QuestionnaireModel()
        {
        
        }
    }
}



