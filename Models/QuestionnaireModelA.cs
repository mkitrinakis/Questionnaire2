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
    public class QuestionnaireModelA : QuestionnaireModel
    {
        public int QuestionnerID { get; set; }

        public string InfoMessage { get; set; }
        public string ErrorMessage { get; set; }

        public string UserName { get; set; }

       

        public TableQuestion Q101 { get; set; }
        public TableQuestion Q102 { get; set; }
        public TableQuestion Q103 { get; set; }
        public TableQuestion Q104 { get; set; }
        public TableQuestion Q105 { get; set; }
        public TableQuestion Q106 { get; set; }
        public TableQuestion Q107 { get; set; }
        public TableQuestion Q108 { get; set; }
        


        public UserHelper.UserStatus UserStatus { get; set; } = UserHelper.UserStatus.New;



        public string Q2 { get; set; } = "";
        public string Q2Label = "2. Ποιες πλατφόρμες ασύγχρονης τηλεκπαίδευσης χρησιμοποιήθηκαν στην τηλεκπαίδευση το χειμερινό εξάμηνο 2020 στο ΙΕΚ σας";
        public Dictionary<int, string> Q2Options = InMemory.getPlatformsAsync();
        public string Q2OptionsOther { get; set; } = "";

        public string Q3 { get; set; } = "";
        public string Q3Label = "3.	Ποιες πλατφόρμες ασύγχρονης τηλεκπαίδευσης χρησιμοποιήθηκαν στην τηλεκπαίδευση το περασμένο έτος (Μάρτιος – Ιούνιος 2020) στο ΙΕΚ σας";
        public Dictionary<int, string> Q3Options = InMemory.getPlatformsAsync();
        public string Q3OptionsOther { get; set; } = "";


        public string Q4 { get; set; } = "";
        public string Q4Label = "4.	Ποια ήταν η συμμετοχή των εκπαιδευόμενων στην ασύγχρονη τηλεκπαίδευση";
        public Dictionary<int, string> Q4Options = InMemory.getParticipantRates(); 
        public string Q5 { get; set; } = "";
        public string Q5Label = "5. Πώς θα χαρακτηρίζατε γενικά την ανταπόκριση των εκπαιδευόμενων που συμμετείχαν στην ασύγχρονη τηλεκπαίδευση";
        public Dictionary<int, string> Q5Options = InMemory.getQualityScale();
        public string Q6 { get; set; } = "";
        public string Q6Label = "6. Ποιο/α εκπαιδευτικό υλικό χρησιμοποιήθηκε στην  ασύγχρονη τηλεκπαίδευση";
        public Dictionary<int, string> Q6Options = InMemory.getChoices(new string[] { "Κατασκεύασαν εκ νέου οι εκπαιδευτές", "Χρησιμοποίησαν υλικό που είχαν ήδη οι εκπαιδευτές", "Υλικό συναδέρφων τους ή από άλλες πηγές" , "Δε γνωρίζω", "Άλλο"});
        public string Q6OptionsOther { get; set; } = "";
        public string Q7 { get; set; } = "";
        public string Q7Label = "7. Θεωρείτε ότι πρέπει η ασύγχρονη τηλεκπαίδευση να λειτουργεί συμπληρωματικά με την παραδοσιακή διδασκαλία στα ΙΕΚ";
        public Dictionary<int, string> Q7Options = InMemory.getChoices(new string[] { "Ναι", "Δεν είμαι σίγουρος", "Μόνο σε εξαιρετικές περιπτώσεις (π.χχ σε περιπτώσεις κλεισίματος της μονάδας)", "Όχι" }); 

        public string Q8 { get; set; } = "";
        public string Q8Label = "8. Ποιες πλατφόρμες σύγχρονης τηλεκπαίδευσης χρησιμοποιήθηκαν στην τηλεκπαίδευση το χειμερινό εξάμηνο 2020 στο ΙΕΚ σας";
        public Dictionary<int, string> Q8Options = InMemory.getPlatformsSync();
        public string Q8OptionsOther { get; set; } = ""; 



        public string Q9 { get; set; } = "";
        public string Q9Label = "9.	Ποιες πλατφόρμες ασύγχρονης τηλεκπαίδευσης χρησιμοποιήθηκαν στην τηλεκπαίδευση το περασμένο έτος (Μάρτιος – Ιούνιος 2020) στο ΙΕΚ σας";
        public Dictionary<int, string> Q9Options = InMemory.getPlatformsSync();
        public string Q9OptionsOther { get; set; } = ""; 

        public string Q10 { get; set; } = "";
        public string Q10Label = "10. Ποια ήταν η συμμετοχή των εκπαιδευόμενων στην σύγχρονη τηλεκπαίδευση";
        public Dictionary<int, string> Q10Options = InMemory.getParticipantRates(); 


        public string Q11 { get; set; } = "";
        public string Q11Label = "11. Πώς θα χαρακτηρίζατε την ανταπόκριση των εκπαιδευόμενων που συμμετείχαν στην σύγχρονη τηλεκπαίδευση";
        public Dictionary<int, string> Q11Options = InMemory.getQualityScale(); 

        public string Q12 { get; set; } = "";
        public string Q12Label = "12. Ποια θεωρείτε ότι ήταν τα σημαντικότερα θέματα που αντιμετώπισαν οι εκπαιδευόμενοι στη χρήση της σύγχρονης και ασύγχρονης τηλεκπαίδευσης (συμπληρώσατε τα 2-3 πιο σημαντικά) ";
        public Dictionary<int, string> Q12Options = InMemory.getChoices(new string[] { "Έλλειψη σύνδεσης στο διαδίκτυο", "Έλλειψη προσωπικού υπολογιστή ή tablet", "Έλλεψη βασικών γνώσεων σρήσης υπολογιστών", "Τεχνικά προβλήματα των επιμέρους πλατφορμών", "Λειτουργικότητα των επιμέρους πλατφορμών", "Ταυτόχρονη τηλεκπαίδευση ή τηλεργασία άλλων μελών της οικογένειας", "Ελλιπής ενθάρρυνση από καθηγητές", "Περισσότερες εργασίες και εξετάσεις μέσω τηλεκπαίδευσης", "Άλλο (συμπληρώστε)" }); 

        public string Q13 { get; set; } = "";
        public string Q13Label = "Ποια θεωρείτε ότι ήταν τα σημαντικότερα θέματα που αντιμετώπισαν οι εκπαιδευτές στη χρήση της της σύγχρονης και ασύγχρονης (συμπληρώστε τα 2-3 πιο σημαντικά)";
        public Dictionary<int, string> Q13Options = InMemory.getChoices(new string[] { "Έλλειψη κατάλληλων οδηγιών", "Έλλειψη βασικών γνώσεων χρήσης υπολογιστών", "Τεχνικά θέματα των επιμέρους πλατφορμών" , "Λειτουργικότητα των επιμέρους πλατφορμών", "Είδος μαθήματος (πχ εργαστηριακό)", "Απουσία ενδιαφέροντος από εκπαιδευόμενους" , "Έλλειψη κινήτρου/παρότρυνσης", "Δυσκολία εργασίας από το σπίτι (λόγω οικογενειακών υποχρεώσεων, κα)", "Άλλο (συμπληρώστε)" }); 
       
        HERE 
        
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

        


        public QuestionnaireModelA()
        {
            Q101 = new TableQuestion();   
            Q101.label = "ΒΟΗΘΟΣ ΒΡΕΦΟΝΗΠΙΟΚΟΜΩΝ (Γ Εξάμηνο)";
            Q101.options = InMemory.getEduTypes();
            List<TableQuestionRow> Q101Rows = new List<TableQuestionRow>();
            Q101Rows.Add(new TableQuestionRow() { label = "ΕΙΚΑΣΤΙΚΑ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() }) ;
            Q101Rows.Add(new TableQuestionRow() { label = "ΚΟΥΚΛΟΘΕΑΤΡΟ-ΘΕΑΤΡΟ ΣΚΙΩΝ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q101Rows.Add(new TableQuestionRow() { label = "ΜΟΥΣΙΚΟΚΙΝΗΤΙΚΗ ΑΓΩΓΗ#ΜΙΚΤΟ", options = InMemory.getEduTypes() });
            Q101Rows.Add(new TableQuestionRow() { label = "ΠΑΙΧΝΙΔΙ-ΘΕΑΤΡΙΚΟ ΠΑΙΧΝΙΔΙ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q101Rows.Add(new TableQuestionRow() { label = "ΠΡΑΚΤΙΚΗ ΑΣΚΗΣΗ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q101Rows.Add(new TableQuestionRow() { label = "ΣΤΟΙΧΕΙΑ ΔΙΑΙΤΗΤΙΚΗΣ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q101Rows.Add(new TableQuestionRow() { label = "ΣΤΟΙΧΕΙΑ ΕΙΔΙΚΗΣ ΑΓΩΓΗΣ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q101Rows.Add(new TableQuestionRow() { label = "ΣΤΟΙΧΕΙΑ ΟΡΓΑΝΩΣΗΣ ΒΡΕΦΟΝΗΠΙΑΚΟΥ ΣΤΑΘΜΟΥ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q101Rows.Add(new TableQuestionRow() { label = "ΨΥΧΟΠΑΘΟΛΟΓΙΑ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q101.rows = Q101Rows;

            Q102 = new TableQuestion();
                Q102.label = "ΒΟΗΘΟΣ ΝΟΣΗΛΕΥΤΙΚΗΣ ΓΕΝΙΚΗΣ ΝΟΣΗΛΕΙΑΣ (Γ Εξάμηνο)";
            Q102.options = InMemory.getEduTypes();
            List<TableQuestionRow> Q102Rows = new List<TableQuestionRow>();
            Q102Rows.Add(new TableQuestionRow() { label = "ΑΙΜΟΔΟΣΙΑ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q102Rows.Add(new TableQuestionRow() { label = "ΑΠΟΣΤΕΙΡΩΣΗ-ΑΠΟΛΥΜΑΝΣΗ#ΜΙΚΤΟ", options = InMemory.getEduTypes() });
            Q102Rows.Add(new TableQuestionRow() { label = "ΝΟΣΗΛΕΥΤΙΚΗ (ΠΡΑΚΤΙΚΗ ΣΤΟ ΝΟΣΟΚΟΜΕΙΟ)ΙΙ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q102Rows.Add(new TableQuestionRow() { label = "ΧΕΙΡΟΥΡΓΙΚΗ ΙΙ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q102.rows = Q102Rows;


            Q103 = new TableQuestion();
                Q103.label = "ΒΟΗΘΟΣ ΦΑΡΜΑΚΕΙΟΥ (Α Εξάμηνο)";
            Q103.options = InMemory.getEduTypes();
            List<TableQuestionRow> Q103Rows = new List<TableQuestionRow>();
            Q103Rows.Add(new TableQuestionRow() { label = "ΚΟΣΜΕΤΟΛΟΓΙΑ Ι#ΜΙΚΤΟ", options = InMemory.getEduTypes() });
            Q103Rows.Add(new TableQuestionRow() { label = "ΜΕΘΟΔΟΙ ΕΛΕΓΧΟΥ ΦΑΡΜΑΚΟΥ#ΜΙΚΤΟ", options = InMemory.getEduTypes() });
            Q103Rows.Add(new TableQuestionRow() { label = "ΠΡΑΚΤΙΚΗ ΕΦΑΡΜΟΓΗ ΣΤΗΝ ΕΙΔΙΚΟΤΗΤΑ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q103Rows.Add(new TableQuestionRow() { label = "ΦΑΡΜΑΚΕΥΤΙΚΗ ΤΕΧΝΟΛΟΓΙΑ Ι#ΜΙΚΤΟ", options = InMemory.getEduTypes() });
            Q103Rows.Add(new TableQuestionRow() { label = "ΦΑΡΜΑΚΕΥΤΙΚΗ ΦΥΣΙΚΗ#ΜΙΚΤΟ", options = InMemory.getEduTypes() });
            Q103Rows.Add(new TableQuestionRow() { label = "ΦΑΡΜΑΚΟΛΟΓΙΑ-ΤΟΞΙΚΟΛΟΓΙΑ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q103.rows = Q103Rows;

            Q104 = new TableQuestion();
            Q104.label = "ΣΤΕΛΕΧΟΣ ΜΗΧΑΝΟΓΡΑΦΗΜΕΝΟΥ ΛΟΓΙΣΤΗΡΙΟΥ - ΦΟΡΟΤΕΧΝΙΚΟΥ ΓΡΑΦΕΙΟΥ (Γ Εξάμηνο)";
            Q104.options = InMemory.getEduTypes();
            List<TableQuestionRow> Q104Rows = new List<TableQuestionRow>();
            Q104Rows.Add(new TableQuestionRow() { label = "ΕΠΕΞΕΡΓΑΣΙΑ ΚΕΙΜΕΝΟΥ (H/Y)#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q104Rows.Add(new TableQuestionRow() { label = "ΛΟΓΙΣΤΙΚΕΣ ΕΦΑΡΜΟΓΕΣ Ι#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q104Rows.Add(new TableQuestionRow() { label = "ΛΟΓΙΣΤΙΚΗ ΕΤΑΙΡΕΙΩΝ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q104Rows.Add(new TableQuestionRow() { label = "ΛΟΓΙΣΤΙΚΗ ΚΟΣΤΟΥΣ Ι#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q104Rows.Add(new TableQuestionRow() { label = "ΜΗΧΑΝΟΓΡΑΦΗΜΕΝΗ ΛΟΓΙΣΤΙΚΗ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q104Rows.Add(new TableQuestionRow() { label = "ΠΡΑΚΤΙΚΗ ΕΦΑΡΜΟΓΗ ΣΤΗΝ ΕΙΔΙΚΟΤΗΤΑ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q104Rows.Add(new TableQuestionRow() { label = "ΦΟΡΟΛΟΓΙΚΗ ΛΟΓΙΣΤΙΚΗ ΚΑΙ ΕΦΑΡΜΟΓΕΣ Ι#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q104Rows.Add(new TableQuestionRow() { label = "ΦΟΡΟΛΟΓΙΚΗ ΠΡΑΚΤΙΚΗ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q104.rows = Q104Rows;

            Q105 = new TableQuestion();
            Q105.label = "ΤΕΧΝΙΚΟΣ ΕΦΑΡΜΟΓΩΝ ΠΛΗΡΟΦΟΡΙΚΗΣ (ΠΟΛΥΜΕΣΑ/WEB DESIGNER-DEVELOPER/VIDEO GAMES)	(Γ εξάμηνο)";
            Q105.options = InMemory.getEduTypes();
            List<TableQuestionRow> Q105Rows = new List<TableQuestionRow>();
            Q105Rows.Add(new TableQuestionRow() { label = "ΒΑΣΕΙΣ ΔΕΔΟΜΕΝΩΝ ΙΙ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q105Rows.Add(new TableQuestionRow() { label = "ΓΛΩΣΣΑ ΠΡΟΓΡΑΜΜΑΤΙΣΜΟΥ IV (OPENGL)#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q105Rows.Add(new TableQuestionRow() { label = "ΓΛΩΣΣΑ ΠΡΟΓΡΑΜΜΑΤΙΣΜΟΥ V (PHP)#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q105Rows.Add(new TableQuestionRow() { label = "ΓΛΩΣΣΑ ΠΡΟΓΡΑΜΜΑΤΙΣΜΟΥ ΙΙΙ (ΑΝΤΙΚΕΙΜΕΝΟΣΤΡΑΦΗΣ ΠΡΟΓΡΑΜΜΑΤΙΣΜΟΣ C++)#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q105Rows.Add(new TableQuestionRow() { label = "ΕΡΓΑΛΕΙΑ ΔΗΜΙΟΥΡΓΙΑΣ ΤΡΙΣΔΙΑΣΤΑΤΩΝ ΓΡΑΦΙΚΩΝ Ι (3DS MAX)#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q105Rows.Add(new TableQuestionRow() { label = "ΕΡΓΑΛΕΙΑ ΚΑΤΑΣΚΕΥΗΣ ΠΑΙΧΝΙΔΙΩΝ (UNREAL EDITOR, HALF LIFE, DOOM EDITOR)#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q105.rows = Q105Rows;

            Q106 = new TableQuestion();
            Q106.label = "ΤΕΧΝΙΚΟΣ ΚΟΜΜΩΤΙΚΗΣ ΤΕΧΝΗΣ (Α εξάμηνο)";
            Q106.options = InMemory.getEduTypes();
            List<TableQuestionRow> Q106Rows = new List<TableQuestionRow>();
            Q106Rows.Add(new TableQuestionRow() { label = "ΓΕΝΙΚΗ & ΕΦΑΡΜΟΣΜΕΝΗ ΑΝΑΤΟΜΙΑ- ΦΥΣΙΟΛΟΓΙΑ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q106Rows.Add(new TableQuestionRow() { label = "ΔΕΡΜΑΤΟΛΟΓΙΑ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q106Rows.Add(new TableQuestionRow() { label = "ΠΡΑΚΤΙΚΕΣ ΑΣΚΗΣΕΙΣ ΚΟΜΜΩΤΙΚΗΣ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q106Rows.Add(new TableQuestionRow() { label = "ΠΡΑΚΤΙΚΗ ΕΦΑΡΜΟΓΗ ΣΤΗΝ ΕΙΔΙΚΟΤΗΤΑ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q106Rows.Add(new TableQuestionRow() { label = "ΣΧΕΔΙΟ ΕΙΔΙΚΟΤΗΤΑΣ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q106Rows.Add(new TableQuestionRow() { label = "ΤΕΧΝΟΛΟΓΙΑ ΚΟΜΜΩΤΙΚΗΣ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q106Rows.Add(new TableQuestionRow() { label = "ΥΓΙΕΙΝΗ- ΠΡΟΛΗΨΗ ΑΤΥΧΗΜΑΤΩΝ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q106.rows = Q106Rows;

            Q107 = new TableQuestion();
            Q107.label = "ΤΕΧΝΙΚΟΣ ΜΗΧΑΝΟΤΡΟΝΙΚΗΣ (Α εξάμηνο)";
            Q107.options = InMemory.getEduTypes();
            List<TableQuestionRow> Q107Rows = new List<TableQuestionRow>();
            Q107Rows.Add(new TableQuestionRow() { label = "ΕΦΑΡΜΟΣΜΕΝΗ ΜΗΧΑΝΟΛΟΓΙΑ#ΜΙΚΤΟ", options = InMemory.getEduTypes() });
            Q107Rows.Add(new TableQuestionRow() { label = "ΜΗΧΑΝΟΛΟΓΙΚΟ ΣΧΕΔΙΟ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q107Rows.Add(new TableQuestionRow() { label = "ΟΡΓΑΝΩΣΗ, ΛΕΙΤΟΥΡΓΙΑ ΚΑΙ ΑΣΦΑΛΕΙΑ ΣΥΝΕΡΓΕΙΟΥ - ΠΕΡΙΒΑΛΛΟΝ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q107Rows.Add(new TableQuestionRow() { label = "ΠΡΑΚΤΙΚΗ ΕΦΑΡΜΟΓΗ ΣΤΗΝ ΕΙΔΙΚΟΤΗΤΑ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q107Rows.Add(new TableQuestionRow() { label = "ΣΤΟΙΧΕΙΑ ΗΛΕΚΤΡΟΤΕΧΝΙΑΣ ΚΑΙ ΗΛΕΚΤΡΟΝΙΚΑ ΣΥΣΤΗΜΑΤΑ ΑΥΤΟΚΙΝΗΤΩΝ- ΜΟΤΟΣΙΚΛΕΤΩΝ#ΜΙΚΤΟ", options = InMemory.getEduTypes() });
            Q107.rows = Q107Rows;

            Q108 = new TableQuestion();
            Q108.label = "ΤΕΧΝΙΚΟΣ ΤΟΥΡΙΣΤΙΚΩΝ ΜΟΝΑΔΩΝ ΚΑΙ ΕΠΙΧΕΙΡΗΣΕΩΝ ΦΙΛΟΞΕΝΙΑΣ (ΥΠΗΡΕΣΙΑ ΥΠΟΔΟΧΗΣ - ΥΠΗΡΕΣΙΑ ΟΡΟΦΩΝ - ΕΜΠΟΡΕΥΜΑΤΟΓΝΩΣΙΑ) (Α εξάμηνο)";
            Q108.options = InMemory.getEduTypes();
            List<TableQuestionRow> Q108Rows = new List<TableQuestionRow>();
            Q108Rows.Add(new TableQuestionRow() { label = "MARKETING#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q108Rows.Add(new TableQuestionRow() { label = "ΑΓΓΛΙΚΑ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q108Rows.Add(new TableQuestionRow() { label = "ΑΡΧΕΣ ΟΙΚΟΝΟΜΙΚΗΣ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q108Rows.Add(new TableQuestionRow() { label = "ΓΕΡΜΑΝΙΚΑ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q108Rows.Add(new TableQuestionRow() { label = "ΔΙΟΙΚΗΣΗ ΕΠΙΧΕΙΡΗΣΕΩΝ Ι#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q108Rows.Add(new TableQuestionRow() { label = "ΟΡΓΑΝΩΣΗ, ΛΕΙΤΟΥΡΓΙΑ ΞΕΝΟΔΟΧΕΙΩΝ Ι#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q108Rows.Add(new TableQuestionRow() { label = "ΠΡΑΚΤΙΚΗ ΕΦΑΡΜΟΓΗ ΣΤΗΝ ΕΙΔΙΚΟΤΗΤΑ#ΕΡΓΑΣΤΗΡΙΑΚΟ", options = InMemory.getEduTypes() });
            Q108Rows.Add(new TableQuestionRow() { label = "ΤΟΥΡΙΣΜΟΣ#ΘΕΩΡΗΤΙΚΟ", options = InMemory.getEduTypes() });
            Q108.rows = Q108Rows;
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
               string val = (string) typeof(QuestionnaireModelA).GetProperty("Q" + q).GetValue(this);
                vals.Add(q, val);
                if (q.Equals("8") && !vals["7"].Equals("1")) continue; 
                if ((val ?? "").Trim().Equals("")) { rs.Add("Η ερώτηση (" + q + ") δεν έχει συμπληρωθεί"); }
                if (q.Equals("8") || q.Equals("9"))
                {
                    if (val.Equals("5") )
                    {
                        string other = (string)typeof(QuestionnaireModelA).GetProperty("Q" + q + "OptionsOther").GetValue(this);
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



