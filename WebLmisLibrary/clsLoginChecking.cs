using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;
using System.Web;
namespace NIC.WebLMISLibrary
{

    public class clsLoginChecking
    {
        clsCommonFunc func = new clsCommonFunc();

        #region " [ Constants ] "
        const string SP_LOGIN_CHECKING = "sploginvalidation";
        const string SP_INSERT_AUDIT_STATUS = "spinsertaudittrailinfo";
        const string passphrase = "nlrmp";
        #endregion

        #region " [ User Define Function ] "

        

       

        public DataSet LoginChecking(string LoginId)
        {
            DataBaseHandler dbHandler = new DataBaseHandler("Linkage Connection String");
            DbCommand dbCmd = dbHandler.SetCommandText(SP_LOGIN_CHECKING, CommandType.StoredProcedure);
            dbHandler.SetInParameter(dbCmd, "@LoginId", DbType.String, LoginId);
            DataSet dslogin = dbHandler.FillDataset(dbCmd);
            return dslogin;
        }

        public Int32 InsertLoginDetailStatus(string LoginID, string SourceIP, System.DateTime LoginTime, string applicationame)
        {
            DataBaseHandler dbHandler = new DataBaseHandler("Linkage Connection String");
            DbCommand dbCmd = dbHandler.SetCommandText(SP_INSERT_AUDIT_STATUS,CommandType.StoredProcedure );
            dbHandler.SetInParameter(dbCmd, "@para_sourceip", DbType.String, SourceIP);
            dbHandler.SetInParameter(dbCmd, "@para_loginid", DbType.String, LoginID);
            dbHandler.SetInParameter(dbCmd, "@para_logintime", DbType.DateTime,  Convert.ToDateTime(func.ConvertDateToMMddyyyyFormat(LoginTime.ToShortDateString())));
            dbHandler.SetInParameter(dbCmd, "@para_applicationame", DbType.String, applicationame);
            dbHandler.SetOutParameter(dbCmd, "@para_id", DbType.Int32, 16);
            dbHandler.ExecuteNonQuery(dbCmd);
            Int32 cnt = default(Int32);
            cnt = Convert.ToInt32(dbHandler.GetOutParameterValue(dbCmd, "@para_id"));
            return cnt;
        }

        public bool UpdateLogOutDetailStatus(System.DateTime Logouttime, Int32 SRNO)
        {
            DataBaseHandler dbHandler = new DataBaseHandler("Linkage Connection String1");
            string sqlCommand = "Update tblaudittrail SET logouttime=@LogoutTime WHERE id=@SRNO";
            DbCommand dbCmd = dbHandler.SetCommandText(sqlCommand, CommandType.Text);
            dbHandler.SetInParameter(dbCmd, "@LogoutTime", DbType.DateTime, Convert.ToDateTime(func.ConvertDateToMMddyyyyFormat(Logouttime.ToShortDateString())));
            dbHandler.SetInParameter(dbCmd, "@SRNO", DbType.String, SRNO);
            dbHandler.ExecuteNonQuery(dbCmd);
            return true;
        }

        public int getCount(string DataBasename, string schemaname, string username)
        {
            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText("rcis_uni.sp_count", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_schema_name", DbType.String, schemaname);
            handler.SetInParameter(command, "@para_user_id", DbType.String, username);
            handler.SetInParameter(command, "@para_db_name", DbType.String, DataBasename);
            return handler.ExecuteScalar(command);
        }


       

        public void LoginInsert(string DataBasename, string schemaname, string NewID, string ipAddress, string loginTime, string userId, string district, string taluka, string distictcode, string talukacode, string usertype, string salt)
        {
            int i = 0;

            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            string str4 = "session_id,user_id,db_name,sch_name,login_time,ip_address,district_name,taluka_name,talukacode,distcode,usretype,app_name,pageurl";
            string str5 = "'" + NewID + "','" + userId + "','" + DataBasename + "','" + schemaname + "',now(),'" + ipAddress + "','" + district + "','" + taluka + "','" + talukacode + "','" + distictcode + "','" + usertype + "','reEdit','" + salt + "'";
            string str6 = "login_details";
            DbCommand command = handler.SetCommandText("rcis_uni.spinsertlogin", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_schema_name", DbType.String, schemaname);
            handler.SetInParameter(command, "@para_table_name", DbType.String, str6);
            handler.SetInParameter(command, "@para_column_name", DbType.String, str4);
            handler.SetInParameter(command, "@para_column_value", DbType.String, str5);
            handler.SetInParameter(command, "@para_column_value", DbType.String, userId);
            i = handler.ExecuteNonQuery(command);

        }

        public void LoginUpdate(string DataBasename, string schemaname, string NewID, string ipAddress, string loginTime, string userId,string usertype, string salt)
        {
            int i = 0;

            string strSet = "session_id='" + NewID + "',ip_address='" + ipAddress + "', login_time=now(),sch_name='" + schemaname + "', usretype='" + usertype + "', app_name='reEdit', pageurl='" + salt + "'";
                string strCondition = "user_id='" + userId + "'";
                string strtbl = "login";
                DataBaseHandler handler3 = new DataBaseHandler("Linkage Connection String1");
                DbCommand command3 = handler3.SetCommandText("rcis_uni.spmutidupdate", CommandType.StoredProcedure);
                handler3.SetInParameter(command3, "@para_schema_name", DbType.String, schemaname);
                handler3.SetInParameter(command3, "@para_table_name", DbType.String, strtbl);
                handler3.SetInParameter(command3, "@para_set", DbType.String, strSet);
                handler3.SetInParameter(command3, "@para_condition", DbType.String, strCondition);
                i = handler3.ExecuteNonQuery(command3);
           
        }
        public DataSet getLoginDetails(string newSessionID)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //DbCommand command1 = handler.SetCommandText("rcis_uni.sp_get_login", CommandType.StoredProcedure);
            //handler.SetInParameter(command1, "@session_id", DbType.String, newSessionID);
            //return handler.FillDataset(command1);

            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DataSet set = new DataSet();
            string cmdText = "SELECT * FROM rcis_uni.login_details WHERE session_id='" + newSessionID + "' order by session_id desc"; ;

            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            return handler.FillDataset(command);

        }


       
        public string getNewSessionID(string username)
        {
            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText("rcis_uni.sp_get_newSessionid", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_userid", DbType.String, username);
            return handler.ExecuteScalarstring(command);
        }


        public string EncryptData(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(Message);
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }


        public string DecryptString(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(passphrase));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(Message);
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }
        public DataSet getPass(string DataBasename, string SchemaName, string UserId)
        {
            DataBaseHandler dbHandler = new DataBaseHandler(DataBasename, "Tahsil Connection String");
            DbCommand dbCmd = dbHandler.SetCommandText(SchemaName+".sp_get_pass", CommandType.StoredProcedure);
            dbHandler.SetInParameter(dbCmd, "@SchemaName", DbType.String, SchemaName);
            dbHandler.SetInParameter(dbCmd, "@LoginId", DbType.String, UserId);
            DataSet dslogin = dbHandler.FillDataset(dbCmd);
            return dslogin;
        }
        public void sp_login_audit(string DataBasename, string schemaname, string userName, string password, string IPaddress)
        {
            DataBaseHandler handler = new DataBaseHandler(DataBasename, "Tahsil Connection String");
            DbCommand command = handler.SetCommandText(schemaname + ".sp_login_audit", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_schema_name", DbType.String, schemaname);
            handler.SetInParameter(command, "@para_UserId", DbType.String, userName);
            handler.SetInParameter(command, "@para_ip_address", DbType.String, IPaddress);
            handler.SetInParameter(command, "@para_login_status", DbType.String, 'N');
            handler.SetInParameter(command, "@para_operation", DbType.String, 'U');
            handler.SetInParameter(command, "@para_User_activity", DbType.String, "");
                 handler.ExecuteNonQuery(command);
        }

        public void sp_login_audit1(string DataBasename, string schemaname, string userName, string IPaddress, bool flag, string activity)
        {

            DataBaseHandler handler = new DataBaseHandler(DataBasename, "Tahsil Connection String");

            if (flag == true)
            {

                DbCommand command = handler.SetCommandText(schemaname + ".sp_login_audit", CommandType.StoredProcedure);
                handler.SetInParameter(command, "@para_schema_name", DbType.String, schemaname);
                handler.SetInParameter(command, "@para_UserId", DbType.String,  userName );
                handler.SetInParameter(command, "@para_ip_address", DbType.String, IPaddress);
                handler.SetInParameter(command, "@para_login_status", DbType.String, 'Y');
                handler.SetInParameter(command, "@para_operation", DbType.String, 'N');
                handler.SetInParameter(command, "@para_User_activity", DbType.String, activity);

                 handler.ExecuteNonQuery(command);
            }
            else
            {

                DbCommand command = handler.SetCommandText(schemaname + ".sp_login_audit", CommandType.StoredProcedure);
                handler.SetInParameter(command, "@para_schema_name", DbType.String, schemaname);
                handler.SetInParameter(command, "@para_UserId", DbType.String,  userName );
                handler.SetInParameter(command, "@para_ip_address", DbType.String, IPaddress);
                handler.SetInParameter(command, "@para_login_status", DbType.String, 'N');
                handler.SetInParameter(command, "@para_operation", DbType.String, 'N');
                handler.SetInParameter(command, "@para_User_activity", DbType.String, activity);
                 handler.ExecuteNonQuery(command);


            }




        }

        public int updatePass(string DataBasename, string SchemaName, string TableName, string SetCol, string Condition)
        {
            DataBaseHandler handler = new DataBaseHandler(DataBasename, "database Connection String");
            DbCommand command = handler.SetCommandText(SchemaName + ".sp_update", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_set_column", DbType.String, SetCol);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, Condition);
            handler.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            int k = handler.ExecuteNonQuery(command);
            return k;
        }
       
        #endregion

    }
}
