using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Questionnaire2.Helpers; 

namespace Questionnaire2.Models
{
    public class MySQLContextA
    {
        private string connectionString { get; set; }
        private string[] questionsMax { get; set; }

        private string[] questionsTableMax { get; set; }



        public MySQLContextA(string _connectionString, string[] _questionsMax, string[] _questionsTableMax)
        {
            this.connectionString = _connectionString;
            this.questionsMax = _questionsMax;
            this.questionsTableMax = _questionsTableMax;
        }

        //private MySqlConnection GetConnection()
        //{
        //    return new MySqlConnection(connectionString);
        //}

        public string getUserToken(string userName, string password)
        {    
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from users  where user = '" + userName + "' AND password= '" + password + "'", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader["user"] as string;
                        }
                    }
                }
                return "";
            }
            catch (Exception e) { return e.Message;  }
        }



        public QuestionnaireModelA getAnswers(int questionnaireID, string userName)
        {

            QuestionnaireModelA rs = new QuestionnaireModelA();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from answers where questionnaire_id = " + questionnaireID + " AND user= '" + userName + "'", conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                string id = reader["id"].ToString();
                                if (!id.Contains("_"))
                                    {
                                    int questionID = Convert.ToInt32(reader["id"]);
                                    string answer = (reader["answer_option"] ?? "").ToString();
                                    System.Reflection.PropertyInfo prop = typeof(QuestionnaireModelA).GetProperty("Q" + questionID);
                                    if (prop != null) prop.SetValue(rs, answer);
                                    if (questionID.Equals(8)) rs.Q8OptionsOther = (reader["answer_text"] ?? "").ToString();
                                    if (questionID.Equals(9)) rs.Q9OptionsOther = (reader["answer_text"] ?? "").ToString();
                                }
                                else // oops it is a table (multiple) question 
                                {
                                    int questionID = Convert.ToInt32(id.Split('_')[0]);
                                    int optionID = Convert.ToInt32(id.Split('_')[1]);
                                    string answer = (reader["answer_option"] ?? "").ToString();
                                    string detail = (reader["answer_text"] ?? "").ToString();
                                    System.Reflection.PropertyInfo prop = typeof(QuestionnaireModelA).GetProperty("Q" + questionID);
                                    var valStructure = prop.GetValue(rs);
                                    if (valStructure != null)
                                    {
                                        ((TableQuestion)valStructure).rows[optionID].val = answer;
                                        ((TableQuestion)valStructure).rows[optionID].detail = detail; 
                                        prop.SetValue(rs, valStructure); 
                                    }
                                }
                            }
                            catch { }; 
                        }
                    }
                }

                return rs;
            }
            catch (Exception e) { rs.ErrorMessage = e.Message; return rs; }
        }

        public bool postAnswers(int questionnaireID, string userName, QuestionnaireModelA qModel)
        {
            bool success = true;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sqry = "";
                try
                {
                    foreach (string questionID in questionsMax)
                    // for (int questionID = 1; questionID <= questionsMax; questionID++)
                    {
                        sqry = "";
                        string option = (typeof(QuestionnaireModelA).GetProperty("Q" + questionID).GetValue(qModel) ?? "").ToString();
                        option = option ?? "";
                        string answer_text = "";
                        //if (questionID.Equals("8") && option.Equals("5")) answer_text = qModel.Q8OptionsOther ?? "";
                        //if (questionID.Equals("9") && option.Equals("5")) answer_text = qModel.Q9OptionsOther ?? "";
                        sqry = "Replace Into answers (questionnaire_id, id, user, answer_option, answer_text) ";
                        sqry += "Values (" + questionnaireID + ",'" + questionID + "','" + userName + "','" + option + "','" + answer_text + "')";
                        MySqlCommand cmd = new MySqlCommand(sqry, conn);
                        int rs = cmd.ExecuteNonQuery();
                        if (rs.Equals(0))
                        {
                            success = false;
                            qModel.ErrorMessage += " erron on:" + sqry + " --> No update made";
                        }
                    }
                    // table Questions 
                    foreach (string questionID in questionsTableMax)
                    // for (int questionID = 1; questionID <= questionsMax; questionID++)
                    {
                        sqry = "";
                        var valStructure = typeof(QuestionnaireModelA).GetProperty("Q" + questionID).GetValue(qModel);
                        if (valStructure != null)
                        {
                            int counter = -1; // zero based 
                            foreach (TableQuestionRow row in ((TableQuestion)valStructure).rows)
                            {
                                counter++;
                                string withPostfix = questionID + "_" + counter.ToString().PadLeft(2, '0');
                                string val = (row.val ?? "").ToString();
                                string detail = (row.detail ?? "").ToString();
                                sqry = "Replace Into answers (questionnaire_id, id, user, answer_option, answer_text) ";
                                sqry += "Values (" + questionnaireID + ",'" + withPostfix + "','" + userName + "','" + val + "','" + detail + "')";
                                MySqlCommand cmd = new MySqlCommand(sqry, conn);
                                int rs = cmd.ExecuteNonQuery();
                                if (rs.Equals(0))
                                {
                                    success = false;
                                    qModel.ErrorMessage += " erron on:" + sqry + " --> No update made";
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    qModel.ErrorMessage += " erron on:" + sqry + " -->" + e.Message;
                    success = false;
                }
                return success;
            }
        }


        public UserHelper.UserStatus getUserStatus(int questionnaireID, string userName)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd1 = new MySqlCommand("select * from submitted where questionnaire_id = " + questionnaireID + " AND user= '" + userName + "'", conn);
                using (MySqlDataReader reader = cmd1.ExecuteReader())
                {
                    if (reader.HasRows) { return UserHelper.UserStatus.Submitted; }
                }
                MySqlCommand cmd2 = new MySqlCommand("select * from answers where questionnaire_id = " + questionnaireID + " AND user= '" + userName + "'", conn);
                using (MySqlDataReader reader = cmd2.ExecuteReader())
                {
                    if (reader.HasRows) { return UserHelper.UserStatus.Draft; } else { return UserHelper.UserStatus.New; }
                }
            }
        }

        public bool submitQuestionnaire(int questionnaireID, string userName, QuestionnaireModelA qModel)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into submitted(questionnaire_id,user) Values ('" + questionnaireID + "','" + userName + "')", conn);
                int rs = cmd.ExecuteNonQuery();
                if (rs.Equals(0))
                {

                    qModel.ErrorMessage += " Η Προσωρινή Αποθήκευση έγινε αλλά παρουσιάστηκε πρόβλημα στην διάρκεια της Υποβολής. Παρακαλώ ξαναπροσπαθήστε";
                    return false;
                }
                else
                {
                    return true;
                }
            }

        }
    }
}
