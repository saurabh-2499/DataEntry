using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Npgsql;
namespace NIC.WebLMISLibrary
{
    public class clscommonfunctionsfaq
    {
        public DataSet funReturnDataSet(string Tablename, string Colval, string Cond, string Orderby)
        {
            DataBaseHandler DataBaseHandler = new DataBaseHandler("FAQ Connection String");
            DbCommand cmd = DataBaseHandler.SelectCommandText(Tablename, Colval, Cond, Orderby);
            return DataBaseHandler.FillDataset(cmd);
        }
        public DataSet funReturnDataSet1(string Tablename, string Colval, string Cond, string Orderby)
        {
            DataBaseHandler DataBaseHandler = new DataBaseHandler("LinkageDB Connection String");
            DbCommand cmd = DataBaseHandler.SelectCommandText(Tablename, Colval, Cond, Orderby);
            return DataBaseHandler.FillDataset(cmd);
        }
        public DataSet funReturnDataSet(string database,string Tablename, string Colval, string Cond, string Orderby)
        {
            DataBaseHandler DataBaseHandler = new DataBaseHandler(database, "FAQ Connection String");
            DbCommand cmd = DataBaseHandler.SelectCommandText(Tablename, Colval, Cond, Orderby);
            return DataBaseHandler.FillDataset(cmd);
        }

        public int funReturnSingleValue(string TableName, string Colval, string Cond, string Orderby)
        {
            DataBaseHandler DataBaseHandler = new DataBaseHandler("LinkageDB Connection String");
            DbCommand cmd = DataBaseHandler.SelectCommandText(TableName, Colval, Cond, Orderby);
            return DataBaseHandler.ExecuteScalar(cmd);
        }

        public string funReturnSingleValueString(string TableName, string Colval, string Cond, string Orderby)
        {
            DataBaseHandler DataBaseHandler = new DataBaseHandler("FAQ Connection String");
            DbCommand cmd = DataBaseHandler.SelectCommandText(TableName, Colval, Cond, Orderby);
            return DataBaseHandler.ExecuteScalarString(cmd);
        }

        public void funInsertQuestion(string Tablename, string dist_code, string login_id, string ques_type, string remark, string question, string date, string usertype, string module)
        {
            DataBaseHandler DataBaseHandler = new DataBaseHandler("LinkageDB Connection String");
            string qry = "insert into " + Tablename + " (dist_code,login_id,qstn_type,remark,qstn_txt,qstn_date,usertype,module) values('" + dist_code + "','" + login_id + "','" + ques_type + "','','" + question + "','" + date + "','" + usertype + "','" + module + "')";
            DbCommand cmd = DataBaseHandler.SetCommandText(qry, CommandType.Text);
            int i = DataBaseHandler.ExecuteNonQuery(cmd);
        }
        public void funInsertQuestion1(string Tablename, string dist_code, string tq_code, string login_id, string ques_type, string remark, string question, string date, string usertype, string module)
        {
            DataBaseHandler DataBaseHandler = new DataBaseHandler("LinkageDB Connection String");
            string qry = "insert into " + Tablename + " (dist_code,tq_code,login_id,qstn_type,remark,qstn_txt,qstn_date,usertype,module) values('" + dist_code + "','" + tq_code + "','" + login_id + "','" + ques_type + "','','" + question + "','" + date + "','" + usertype + "','" + module + "')";
            DbCommand cmd = DataBaseHandler.SetCommandText(qry, CommandType.Text);
            int i = DataBaseHandler.ExecuteNonQuery(cmd);
        }

        public void funInsertAnswer(string TableName, string answer, string question, string module)
        {
            DataBaseHandler DataBaseHandler = new DataBaseHandler("FAQ Connection String");
            string qry = "update " + TableName + " set ans_txt='" + answer + "',ans_date='" + System.DateTime.Now.ToString() + "' where qstn_txt='" + question + "' and module='" + module + "'";
            DbCommand cmd = DataBaseHandler.SetCommandText(qry, CommandType.Text);
            int i = DataBaseHandler.ExecuteNonQuery(cmd);
        }

        public int funReturnSingleValueInt(string TableName, string ColValue, string Condition, string Orderby)
        {
            DataBaseHandler handler = new DataBaseHandler("FAQ Connection String");
            DataSet set = new DataSet();
            DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            return handler.ExecuteScalar(command);
        }

        #region [---Change Password---]
        public DataSet LoginChecking1(string LoginId)
        {

            DataBaseHandler DataBaseHandler = new DataBaseHandler("LinkageDB Connection String");
            DbCommand dbCmd = DataBaseHandler.SetCommandText("rcis_uni.sploginvalidation1", CommandType.StoredProcedure);
            DataBaseHandler.SetInParameter(dbCmd, "@LoginId", DbType.String, LoginId);
            DataSet dslogin = DataBaseHandler.FillDataset(dbCmd);
            return dslogin;
        }

        public bool funswappassword(string loginid, string currentpass, string distcode)
        {
            DataBaseHandler DataBaseHandler = new DataBaseHandler("LinkageDB Connection String");
            string sqlCommand = "Update rcis_uni.tblfaqlogin SET password=@currentpass WHERE userid=@loginid and district_code=@distcode";
            DbCommand dbCmd = DataBaseHandler.SetCommandText(sqlCommand, CommandType.Text);
            DataBaseHandler.SetInParameter(dbCmd, "@loginid", DbType.String, loginid);
            DataBaseHandler.SetInParameter(dbCmd, "@currentpass", DbType.String, currentpass);
            DataBaseHandler.SetInParameter(dbCmd, "@distcode", DbType.String, distcode);

            int i = DataBaseHandler.ExecuteNonQuery(dbCmd);
            if (i == 1)
                return true;
            else
                return false;
        }
        #endregion
    }
}
