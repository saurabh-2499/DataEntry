using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.Common;
using Npgsql;
using System.Security.Cryptography;
using System.Text;
namespace NIC.WebLMISLibrary
{
    public class clsFingerData
    {
        clsCommonFunc func = new clsCommonFunc();
        #region " [ Tahsil Define Function ]"

        public DataSet funGetDistrictMasterData()
        {
            string strCommand = " SELECT district_name,(cast(district_code as text)|| '#' || cast(db_name as text)) as dbcodename FROM rcis_uni.m_district_census";
            DataBaseHandler dbHandler = new DataBaseHandler("Linkage Connection String1");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);
            DataSet dsDistrict = dbHandler.FillDataset(dbCmd);
            return dsDistrict;
        }

        public DataSet funGetRedirectPageMasterData()
        {
            string strCommand = " SELECT id,redirectpage FROM rcis_uni.tblredirectentry";
            DataBaseHandler dbHandler = new DataBaseHandler("Linkage Connection String1");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);
            DataSet dsPage = dbHandler.FillDataset(dbCmd);
            return dsPage;
        }

        public DataSet funGetTahsilMasterData(string databasename)
        {
            string strCommand = " SELECT taluka_name,(taluka_code || '#' || sch_name) AS taluka_code FROM rcis_uni.m_taluka_census";
            DataBaseHandler dbHandler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);
            DataSet dsTahsil = (DataSet)dbHandler.FillDataset(dbCmd);
            return dsTahsil;
        }

        public DataSet funFillTalathiCombo(string databasename, string schemaname, string TalukaCode)
        {//*
            string strCommand = " select distinct username,user_type from " + schemaname + ".fpusers1 where taluka_code=@para_taluka_code  and user_status<>'S' and user_status<>'T' order by username";
            DataBaseHandler dbHandler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);
            dbHandler.SetInParameter(dbCmd, "@para_taluka_code", DbType.String, TalukaCode);
            DataSet dsTahsil = (DataSet)dbHandler.FillDataset(dbCmd);
            return dsTahsil;
        }

        public DataSet funGetTahsilMasterDataSelectUser(string databasename, string schemaname, string taluka_code)
        {
            string strCommand = " SELECT username,fullname,photodata,fingerdata FROM " + schemaname + ".sysadmin WHERE taluka_code=@para_taluka_code";
            DataBaseHandler dbHandler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);
            dbHandler.SetInParameter(dbCmd, "@para_taluka_code", DbType.String, taluka_code);
            DataSet dsTahsil = (DataSet)dbHandler.FillDataset(dbCmd);
            return dsTahsil;
        }

        public byte[] fungetSysAdminUserData(string databasename, string schemaname, string UserName, string TalukaCode, ref string fullname)
        {
            byte[] m_RegMin_DB = new byte[401];
            string strCommand = " SELECT fingerdata,fullname FROM " + schemaname + ".sysadmin WHERE flag='Y' AND username=@para_username and taluka_code=@para_taluka_code";
            DataBaseHandler dbHandler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);
            dbHandler.SetInParameter(dbCmd, "@para_username", DbType.String, UserName);
            dbHandler.SetInParameter(dbCmd, "@para_taluka_code", DbType.String, TalukaCode);
            NpgsqlDataReader rd = (NpgsqlDataReader)dbHandler.GetDataReader(dbCmd);
            while (rd.Read())
            {
                m_RegMin_DB = (byte[])rd[0];
                fullname = (string)rd[1];
                break; // TODO: might not be correct. Was : Exit While
            }
            return m_RegMin_DB;
        }

        public byte[] funGetTalathiMinutia(string databasename, string schemaname, string username, string TalukaCode)
        {

            byte[] m_RegMin_DB = new byte[401];
            string strCommand = " SELECT fingerdata FROM " + schemaname + ".fpusers WHERE username=@para_username";

            DataBaseHandler dbHandler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);
            dbHandler.SetInParameter(dbCmd, "@para_username", DbType.String, username.Trim());
            dbHandler.SetInParameter(dbCmd, "@para_taluka_code", DbType.String, TalukaCode);
            NpgsqlDataReader rd = (NpgsqlDataReader)dbHandler.GetDataReader(dbCmd);
            while (rd.Read())
            {
                m_RegMin_DB = (byte[])rd[0];
                break; // TODO: might not be correct. Was : Exit While
            }
            return m_RegMin_DB;
        }


        public void funSysTahsilInsertData(string databasename, string schemaname, string LoginName, string FullName, string taluka_code, byte[] byThumbData)
        {
            string strCommand = " INSERT INTO " + schemaname + ".sysadmin ";
            strCommand += "(username,fullname,taluka_code,fingerdata,createdate,flag) VALUES ";
            strCommand += "(@para_username,@para_fullname,@para_taluka_code,@para_fingerdata,@para_createdate,'Y')";

            DataBaseHandler dbHandler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);
            dbHandler.SetInParameter(dbCmd, "@para_username", DbType.String, LoginName);
            dbHandler.SetInParameter(dbCmd, "@para_fullname", DbType.String, FullName);
            dbHandler.SetInParameter(dbCmd, "@para_taluka_code", DbType.String, taluka_code);
            //dbHandler.SetInParameter(dbCmd, "@para_photodata", DbType.Binary, byPhotoData);
            dbHandler.SetInParameter(dbCmd, "@para_fingerdata", DbType.Binary, byThumbData);
            //dbHandler.SetInParameter(dbCmd, "@para_minutia", DbType.Binary, thumbMinutia);
            dbHandler.SetInParameter(dbCmd, "@para_createdate", DbType.DateTime, func.ConvertDateToMMddyyyyFormat( System.DateTime.Now.ToShortDateString()));

            dbHandler.ExecuteNonQuery(dbCmd);
        }


        public void funUpdateSysTahsilData(string databasename, string schemaname, string LoginName, string FullName, string taluka_code, byte[] byThumbData)
        {
            string strCommand = " UPDATE " + schemaname + ".sysadmin ";
            strCommand += " SET fullname=@para_fullname ,fingerdata=@para_fingerdata , createdate=@para_createdate , flag='Y' ";
            strCommand += " WHERE username=@para_username AND taluka_code=@para_taluka_code ";

            DataBaseHandler dbHandler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);

            dbHandler.SetInParameter(dbCmd, "@para_fullname", DbType.String, FullName);
            //dbHandler.SetInParameter(dbCmd, "@para_photodata", DbType.Binary, byPhotoData);
            dbHandler.SetInParameter(dbCmd, "@para_fingerdata", DbType.Binary, byThumbData);

            dbHandler.SetInParameter(dbCmd, "@para_createdate", DbType.DateTime, System.DateTime.Now);
            dbHandler.SetInParameter(dbCmd, "@para_username", DbType.String, LoginName);
            dbHandler.SetInParameter(dbCmd, "@para_taluka_code", DbType.String, taluka_code);

            dbHandler.ExecuteNonQuery(dbCmd);
        }

        public void funInsertTalathiDataInTable(string databasename, string schemaname, string LoginName, string taluka_code, byte[] byThumbData)
        {
            string strCommand = " INSERT INTO " + schemaname + ".fpusers ";
            strCommand += "(username,taluka_code,fingerdata,createdate,flag,approvedate) VALUES ";
            strCommand += "(@para_username,@para_taluka_code,@para_fingerdata,@para_createdate,'Y',@para_approvedate)";

            DataBaseHandler dbHandler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);

            dbHandler.SetInParameter(dbCmd, "@para_username", DbType.String, LoginName.Trim());
            dbHandler.SetInParameter(dbCmd, "@para_taluka_code", DbType.String, taluka_code);
            // dbHandler.SetInParameter(dbCmd, "@para_photodata", DbType.Binary, byPhotoData);
            dbHandler.SetInParameter(dbCmd, "@para_fingerdata", DbType.Binary, byThumbData);
            //dbHandler.SetInParameter(dbCmd, "@para_minutia", DbType.Binary, thumbMinutia);
            dbHandler.SetInParameter(dbCmd, "@para_createdate", DbType.DateTime, System.DateTime.Now);
            dbHandler.SetInParameter(dbCmd, "@para_approvedate", DbType.DateTime, System.DateTime.Now);

            dbHandler.ExecuteNonQuery(dbCmd);
        }


        public void funUpdateTalathiDataInTable(string databasename, string schemaname, string LoginName, string taluka_code, byte[] byThumbData)
        {
            string strCommand = " UPDATE " + schemaname + ".fpusers ";
            strCommand += " SET fingerdata=@para_fingerdata,createdate=@para_createdate,approvedate=@para_approvedate ";
            strCommand += " WHERE username=@para_username AND taluka_code=@para_taluka_code";

            DataBaseHandler dbHandler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);

            // dbHandler.SetInParameter(dbCmd, "@para_photodata", DbType.Binary, byPhotoData);
            dbHandler.SetInParameter(dbCmd, "@para_fingerdata", DbType.Binary, byThumbData);
            //dbHandler.SetInParameter(dbCmd, "@para_minutia", DbType.Binary, thumbMinutia);
            dbHandler.SetInParameter(dbCmd, "@para_createdate", DbType.DateTime, System.DateTime.Now);
            dbHandler.SetInParameter(dbCmd, "@para_approvedate", DbType.DateTime, System.DateTime.Now);
            dbHandler.SetInParameter(dbCmd, "@para_username", DbType.String, LoginName.Trim());
            dbHandler.SetInParameter(dbCmd, "@para_taluka_code", DbType.String, taluka_code);

            dbHandler.ExecuteNonQuery(dbCmd);
        }


        public DataSet funGetTalathiUserPhotoThumbData(string databasename, string schemaname, string username, string TalukaCode)
        {
            string strCommand = " SELECT photodata,fingerdata FROM " + schemaname + ".fpusers WHERE username=@para_username and taluka_code=@para_taluka_code";
            DataBaseHandler dbHandler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand dbCmd = (NpgsqlCommand)dbHandler.SetCommandText(strCommand, CommandType.Text);
            dbHandler.SetInParameter(dbCmd, "@para_username", DbType.String, username);
            dbHandler.SetInParameter(dbCmd, "@para_taluka_code", DbType.String, TalukaCode);
            DataSet dsTahsil = (DataSet)dbHandler.FillDataset(dbCmd);
            return dsTahsil;

        }

        #endregion
    }
}
