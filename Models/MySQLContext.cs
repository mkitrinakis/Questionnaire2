using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Questionnaire2.Helpers; 

namespace Questionnaire2.Models
{
    public class MySQLContext
    {
        private string connectionString { get; set; }
        private int questionsMax { get; set; }

        public MySQLContext(string _connectionString, int _questionsMax)
        {
            this.connectionString = _connectionString;
            this.questionsMax = _questionsMax;
        }

        //private MySqlConnection GetConnection()
        //{
        //    return new MySqlConnection(connectionString);
        //}

        public QuestionnaireModel getAnswers(int questionnaireID, string userName)
        {

            QuestionnaireModel rs = new QuestionnaireModel();
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
                            int questionID = Convert.ToInt32(reader["id"]);
                            string answer = (reader["answer_option"] ?? "").ToString();
                            typeof(QuestionnaireModel).GetProperty("Q" + questionID).SetValue(rs, answer);
                            if (questionID.Equals(8)) rs.Q8OptionsOther = (reader["answer_text"] ?? "").ToString();
                            if (questionID.Equals(9)) rs.Q9OptionsOther = (reader["answer_text"] ?? "").ToString();
                        }
                    }
                }

                return rs;
            }
            catch (Exception e) { rs.ErrorMessage = e.Message; return rs; }
        }

        public bool postAnswers(int questionnaireID, string userName, QuestionnaireModel qModel)
        {
            bool success = true;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string sqry = "";
                try
                {
                    for (int questionID = 1; questionID <= questionsMax; questionID++)
                    {
                        sqry = "";
                        string option = (typeof(QuestionnaireModel).GetProperty("Q" + questionID).GetValue(qModel) ?? "").ToString();
                        option = option ?? "";
                        string answer_text = "";
                        if (questionID.Equals(8) && option.Equals("5")) answer_text = qModel.Q8OptionsOther ?? "";
                        if (questionID.Equals(9) && option.Equals("5")) answer_text = qModel.Q9OptionsOther ?? "";
                        sqry = "Replace Into answers (questionnaire_id, id, user, answer_option, answer_text) ";
                        sqry += "Values (" + questionnaireID + "," + questionID + ",'" + userName + "','" + option + "','" + answer_text + "')";
                        MySqlCommand cmd = new MySqlCommand(sqry, conn);
                        int rs = cmd.ExecuteNonQuery();
                        if (rs.Equals(0))
                        {
                            success = false;
                            qModel.ErrorMessage += " erron on:" + sqry + " --> No update made";
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

        public bool submitQuestionnaire(int questionnaireID, string userName, QuestionnaireModel qModel)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into submitted(questionnaire_id,user) Values ('" + questionnaireID + "','" + userName + "')", conn);
                int rs = cmd.ExecuteNonQuery();
                if (rs.Equals(0))
                {

                    qModel.ErrorMessage += " Η Προσωρινή Αποθήκευση έγινε αλλά ποαρουσιάστηκε πρόβλημα στην διάρκεια της Υποβολής. Παρακαλώ ξαναπροσπαθήστε";
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
