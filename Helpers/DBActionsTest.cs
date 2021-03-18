using System;
using System.Collections;
using System.Collections.Generic;
using System.Web; 
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Questionnaire2.Models; 

namespace Questionnaire2.Helpers
{
    public class DBActionsTest
    {

        AppSettings _appSettings; 
        public DBActionsTest(AppSettings appSettings)
        {
            _appSettings = appSettings; 
        }

     

        string connectionError = "";

        public List<QuestionnaireModelA> GetRegistryEntries(string userName, int id)
        {
            

            List<QuestionnaireModelA> m = new List<QuestionnaireModelA>();
            Log.write("SQLIntegratedSecurity:" + _appSettings.SQLIntegratedSecurity);
            try
            {
                using (SqlConnection con = getConnection())
                {
                    if (con != null)
                    {
                        SqlDataReader rdr = null;
                        try
                        {


                            
                            // SqlCommand cmd = new SqlCommand("dal.STSCenter");
                            
                                SqlCommand cmd = new SqlCommand("SELECT * FROM inventory.Equipment", con);
                                rdr = cmd.ExecuteReader();
                                if (!rdr.HasRows)
                                {
                                    string errorMessage = "ERROR: NO RESULTS";
                                    Log.write(errorMessage);
                                    return getError(errorMessage);
                                }

                                int counter = 0;
                                while (rdr.Read())
                                {
                                    QuestionnaireModelA reg = new QuestionnaireModelA();
                                    counter++;

                                   
                                   
                                    if (rdr["Q3"] != null && !(rdr["Q3"] == DBNull.Value))
                                    { reg.Q3 = (string)rdr["Q3"]; }
                                    if (rdr["Q4"] != null && !(rdr["Q4"] == DBNull.Value))
                                    { reg.Q4 = (string)rdr["Q4"]; }
                                    if (rdr["Q5"] != null && !(rdr["Q5"] == DBNull.Value))
                                    { reg.Q5 = (string)rdr["Q5"]; }
                                    if (rdr["Q6"] != null && !(rdr["Q6"] == DBNull.Value))
                                    { reg.Q6 = (string)rdr["Q6"]; }
                                    if (rdr["Q7"] != null && !(rdr["Q7"] == DBNull.Value))
                                    { reg.Q7 = (string)rdr["Q7"]; }

                                    m.Add(reg);
                                }
                                return m;
                          
                        }
                        catch (Exception e)
                        {
                            //   errorMessage = "ERROR: ΔΕΝ ΜΠΟΡΕΣΕ ΝΑ ΒΡΕΘΕΙ Ο ΕΞΟΠΛΙΣΜΟΣ ΓΙΑ ΤΟ ΣΧΟΛΕΙΟ ΜΕ ΚΩΔΙΚΟ: " + schoolCode + "-->" + e.Message + "--> " + e.StackTrace;
                            Log.write(e.Message);
                            QuestionnaireModelA errorModel = new QuestionnaireModelA() { ErrorMessage = e.Message };
                            m.Add(errorModel);
                            //     m.ErrorMessage = errorMessage;
                            return m;
                        }
                        finally { rdr.Close(); }
                    }
                    else { return (getError(connectionError)); }
                }
            }
            catch (Exception e)
            {
                // m.ErrorMessage = "GetRegistryEntryBySchoolCode:" + e.Message;
                string msg = "GetRegistryEntryBySchoolCode:" + e.Message;
                Log.write(msg);
                return getError(msg);
            }

        }



        public List<QuestionnaireModelA> getError(string msg)
        {
            QuestionnaireModelA reg = new QuestionnaireModelA { ErrorMessage = msg };
            List<QuestionnaireModelA> l = new List<QuestionnaireModelA>();
            l.Add(reg);
            return l;
        }






        public string InsertRecord(QuestionnaireModelA m, int id)
        {
            try
            {

                using (SqlConnection con = getConnection())
                {
                    if (con != null)
                    {
                        //if (impersonate(con))   // TO CHANGE 
                        //{

                        SqlCommand cmd = new SqlCommand("inventory.SetEquipmentAcceptance");
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter ID = new SqlParameter("@Id", SqlDbType.Int);
                        SqlParameter Q1 = new SqlParameter("@Q1", SqlDbType.Int);
                        SqlParameter Q2 = new SqlParameter("@Q2", SqlDbType.Int);
                        SqlParameter Q3 = new SqlParameter("@Q3", SqlDbType.VarChar);
                        SqlParameter Q4 = new SqlParameter("@Q4", SqlDbType.Int);
                        SqlParameter Q5 = new SqlParameter("@Q5", SqlDbType.Int);
                        SqlParameter Q6 = new SqlParameter("@Q6", SqlDbType.Int);
                        SqlParameter Q7 = new SqlParameter("@Q7", SqlDbType.VarChar);

                        ID.Value = id;
                        
                    
                        Q3.Value = m.Q3;
                        Q4.Value = m.Q4;
                        Q5.Value = m.Q5;
                        Q6.Value = m.Q6;
                        Q7.Value = m.Q7;
                        cmd.Parameters.Add(ID);
                        cmd.Parameters.Add(Q1);
                        cmd.Parameters.Add(Q2);
                        cmd.Parameters.Add(Q3);
                        cmd.Parameters.Add(Q4);
                        cmd.Parameters.Add(Q5);
                        cmd.Parameters.Add(Q6);
                        cmd.Parameters.Add(Q7);
                        cmd.ExecuteNonQuery();
                        return ""; 
                    }
                    else { return connectionError; }
                }
            }
            catch (Exception e)
            {
                Log.write("SetRegistryEntry: " + e.Message);
                return e.Message;
            }
        }


        //private string impersonate(SqlConnection con, string userName)
        //{
        //    // return true; 
        //    try
        //    {

        //        if (needsImpersonation)
        //        {
        //            //  SqlCommand cmdImpersonate = new SqlCommand("EXECUTE AS USER = 'STSServerTest\\mkitrinakis'"); // TO_CHANGE 
        //            //    string qry = ImpersonationDebugAccount.Equals("") ?  "EXECUTE AS USER = '" + System.Security.Principal.WindowsIdentity.GetCurrent().Name + "'" : "EXECUTE AS USER = '" + ImpersonationDebugAccount + "'";
        //            string qry = ImpersonationDebugAccount.Equals("") ? "EXECUTE AS USER = '" + userName + "'" : "EXECUTE AS USER = '" + ImpersonationDebugAccount + "'";
        //            Log.write("Impersonate:" + qry);
        //            SqlCommand cmdImpersonate = new SqlCommand(qry); // TO_CHANGE 
        //            cmdImpersonate.Connection = con;
        //            cmdImpersonate.ExecuteNonQuery();
        //        }
        //        return ("");
        //    }
        //    catch (Exception e)
        //    {
        //        return e.Message;
        //    }
        //}



        //private bool impersonateRevert(SqlConnection con)
        //{
        //    try
        //    {
        //        if (needsImpersonation)
        //        {
        //            Log.write("impersonate revert");
        //            string qry = "revert";
        //            SqlCommand cmdImpersonate = new SqlCommand(qry); // TO_CHANGE 
        //            cmdImpersonate.Connection = con;
        //            cmdImpersonate.ExecuteNonQuery();
        //        }
        //        return (true);
        //    }
        //    catch (Exception e)
        //    {
        //        Log.write("impersonaterevert:" + e.Message);
        //        return false;
        //    }
        //}

        private bool isNewEntry(SqlConnection con, int DeviceID)
        {
            string sCommand = "SELECT Count(*) FROM  [inventory].[DeviceAccepted] WHERE DeviceId =" + DeviceID;
            try
            {

                SqlCommand cmd = new SqlCommand(sCommand, con);
                int count = (int)cmd.ExecuteScalar();
                return count <= 0;
            }
            catch (Exception e)
            {
                Log.write("ERROR: isNewEntry on: " + sCommand + " -->" + e.Message);
                return true;
            }
        }

        //private void SetRegistryEntryInsert(SqlConnection con, Models.Registry m)
        //{
        //    bool Accepted = m.Accepted;
        //    //  int AcceptedByID = 11111; // TO_CHANGE 
        //    string dateFormat = "yyyy-MM-dd HH:mm:ss";
        //    string AcceptedDate = System.DateTime.Now.ToString(dateFormat);
        //    // AcceptedDate = "TO_DATE('" + AcceptedDate + "','" + dateFormat + "')";
        //    AcceptedDate = "'" + AcceptedDate + "'";
        //    string Comments = m.Comments ?? "";
        //    int DeviceID = m.DeviceID;
        //    string History = m.History ?? "";
        //    History = System.DateTime.Now + ":  Μαρκαρίστηκε ως " + (Accepted ? "ΠΑΡΑΔΟΘΗΚΕ" : "ΔΕΝ ΕΧΕΙ ΠΑΡΑΔΟΘΕΙ") + (Comments.Trim().Equals("") ? "" : " με σχόλια:" + Comments) + "\n" + History;
        //    if (History.Length >= 1000) { History = History.Substring(996) + "..."; }
        //    string insertCommand = "INSERT INTO [inventory].[DeviceAccepted] ([DeviceId],[Comments],[History],[AcceptedDate]) VALUES(" + DeviceID + ",'" + Comments + "','" + History + "'," + AcceptedDate + ")";
        //    SqlCommand cmd = new SqlCommand(insertCommand, con);
        //    Log.write(insertCommand);
        //    cmd.ExecuteNonQuery();

        //}


        private string SetRegistryEntryUpdate(SqlConnection con, Models.QuestionnaireModelA m, int id)
        {
            
           
            string? Q3 = m.Q3;
            string? Q4 = m.Q4;
            string? Q5 = m.Q5;
            string? Q6 = m.Q6;
            string? Q7 = m.Q7;
            string updateCommand = "Update [Questionnaire].[Records] set Q3= '" + Q3 + "where Id = " + id;
            SqlCommand cmd = new SqlCommand(updateCommand, con);
            Log.write(updateCommand);
            cmd.ExecuteNonQuery();
            return "";
        }




        //public string SetRegistryEntryBySchoolCode(RegistryEntryModel m)
        //{
        //    m.ErrorMessage = "Under Construction";
        //    return m.ErrorMessage;
        //    SqlConnection con = null;

        //    string rs = "";
        //    try
        //    {
        //        con = getConnection();
        //        SqlDataReader rdr = null;
        //        try
        //        {
        //            errorMessage = "";
        //            SqlCommand cmd = new SqlCommand("dbo.SetCheckedbySchoolCode");
        //            cmd.Connection = con;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            SqlParameter SchoolCodeParam = new SqlParameter("@SchoolCodeParam", SqlDbType.NVarChar);
        //            //SqlParameter SNoPrinterParam = new SqlParameter("@SNoPrinterParam", SqlDbType.NVarChar);
        //            SqlParameter OKPrinterParam = new SqlParameter("@OKPrinterParam", SqlDbType.Bit);
        //            //SqlParameter SNoPCParam = new SqlParameter("@SNoPCParam", SqlDbType.NVarChar);
        //            SqlParameter OKPCParam = new SqlParameter("@OKPCParam", SqlDbType.Bit);
        //            //SqlParameter SNoModemParam = new SqlParameter("@SNoModemParam", SqlDbType.NVarChar);
        //            SqlParameter OKModemParam = new SqlParameter("@OKModemParam", SqlDbType.Bit);
        //            //SqlParameter SNoUSBParam = new SqlParameter("@SNoUSBParam", SqlDbType.NVarChar);
        //            SqlParameter OKUSBParam = new SqlParameter("@OKUSBParam", SqlDbType.Bit);

        //            SchoolCodeParam.Value = m.SchoolCode;
        //            //SNoPrinterParam.Value = m.SNoPrinter;
        //            //SNoPCParam.Value = m.SNoModem;
        //            //SNoModemParam.Value = m.SNoModem;
        //            //SNoUSBParam.Value = m.SNoUSB;
        //            OKPrinterParam.Value = m.OKPrinter;
        //            OKPCParam.Value = m.OKModem;
        //            OKModemParam.Value = m.OKModem;
        //            OKUSBParam.Value = m.OKUSB;

        //            cmd.Parameters.Add(SchoolCodeParam);
        //            //cmd.Parameters.Add(SNoPrinterParam);
        //            //cmd.Parameters.Add(SNoPCParam);
        //            //cmd.Parameters.Add(SNoModemParam);
        //            //cmd.Parameters.Add(SNoUSBParam);
        //            cmd.Parameters.Add(OKPrinterParam);
        //            cmd.Parameters.Add(OKPCParam);
        //            cmd.Parameters.Add(OKModemParam);
        //            cmd.Parameters.Add(OKUSBParam);
        //            cmd.ExecuteNonQuery();
        //            m.ErrorMessage = "";
        //            return "";
        //        }
        //        catch (Exception e)
        //        {
        //            errorMessage = "ERROR: SetRegistryEntryBySchoolCode -->" + e.Message + "--> " + e.StackTrace;
        //            Log.write(errorMessage);
        //            m.ErrorMessage = errorMessage;
        //            return errorMessage;

        //        }
        //        finally { rdr.Close(); }
        //    }
        //    catch (Exception e)
        //    {
        //        errorMessage = "SetRegistryEntryBySchoolCode:" + e.Message;
        //        Log.write(errorMessage);
        //        m.ErrorMessage = errorMessage;
        //        return errorMessage;
        //    }
        //}



        private SqlConnection getConnection()
        {
            try
            {

                connectionError = "";
                //string connectionString = System.Web.Configuration.WebConfigurationManager.AppSettings["SQLConnectionString"];  // connectionString = "Data Source=" + oracle_datasource + ";User ID=" + oracle_userid + ";Password=" + oracle_password + "";
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = _appSettings.SQLDataSource; 

                // if (needsImpersonation)
                
                    builder.UserID = _appSettings.SQLUserID;
                    builder.Password = _appSettings.SQLUserPassword; 
                    builder.IntegratedSecurity = false;

                

                builder.InitialCatalog = "STSMain";   // ATTENTION : Production DB 

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = builder.ConnectionString;

                Log.write(conn.ConnectionString);
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                connectionError = "getSQLAdapter:" + e.Message;
                Log.write(connectionError);

                return null;
            }
        }
    }
}
