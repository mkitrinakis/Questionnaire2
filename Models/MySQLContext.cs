using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Questionnaire2.Models
{
    public class MySQLContext
    {
        private string connectionString { get; set; }

        public MySQLContext(string _connectionString)
        {
            this.connectionString = _connectionString;
        }

        //private MySqlConnection GetConnection()
        //{
        //    return new MySqlConnection(connectionString);
        //}

        public QuestionnaireModel getAnswers(int questionnaireID, int userID)
        {

            QuestionnaireModel rs = new QuestionnaireModel();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from answers where questionnaire_id = " + questionnaireID + " AND user= " + userID, conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int questionID = Convert.ToInt32(reader["id"]);
                            string answer = (string)(reader["answer_text"] ?? "N/A");
                            typeof(QuestionnaireModel).GetProperty("Q" + questionID).SetValue(rs, answer);
                        }
                    }
                }
                rs.ErrorMessage = "OK";
                return rs;
            }
            catch (Exception e) { rs.ErrorMessage = e.Message; return rs; }
        }

        public bool postAnswers(int questionnaireID, int userID, QuestionnaireModel qModel)
        {
            bool success = true;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                for (int questionID = 1; questionID <= 7; questionID++)
                {
                    string sqry = "";
                    try
                    {
                        string val = (typeof(QuestionnaireModel).GetProperty("Q" + questionID).GetValue(qModel) ?? "").ToString();
                        sqry = "Replace Into answers (questionnaire_id, id, user, answer_text) ";
                        sqry += "Values (" + questionnaireID + "," + questionID + "," + userID + ",'" + val + "')";

                        MySqlCommand cmd = new MySqlCommand(sqry, conn);
                        int rs = cmd.ExecuteNonQuery();
                        if (rs.Equals(0))
                        {
                            success = false;
                            qModel.ErrorMessage += " erron on:" + sqry + " --> No update made";
                        }
                    }
                    catch (Exception e)
                    {
                        qModel.ErrorMessage += " erron on:" + sqry + " -->" + e.Message;
                        success = false;
                    }

                }
                return success;
            }
        }

    }
}
