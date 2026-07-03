using System;
using System.Diagnostics;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.Common;
using Npgsql;

namespace NIC.WebLMISLibrary
{
    public class clscommonfunedit
    {
        clsCommonFunc func = new clsCommonFunc();
        # region[-- Static Function --]

        public bool IsValidInput(string type, string input)
        {
            switch (type)
            {
                case "UTF":
                    if (!input.Contains("<") && !input.Contains(">") && !input.Contains("'") && !input.Contains("&") && !input.Contains("\""))
                        return true;
                    else
                        return false;
                    break;
                default:
                    return false;
            }
        }

        public void funDeleteDBRecord_audit(string TableName, string Condition, ref DbCommand dbCommand)
        {
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_delete_dum";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            //this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            //this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "DBATOOL");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
        }

        public string funReturnIfExistValue(string databaseName, string schema, string table)
        {
            DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            DataSet set = new DataSet();
            string cmdText = "SELECT EXISTS (SELECT 1 FROM   pg_catalog.pg_class c  JOIN   pg_catalog.pg_namespace n ON n.oid = c.relnamespace WHERE  n.nspname = '" + schema + "' AND c.relname = '" + table + "' AND c.relkind = 'r');";
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            return handler.ExecuteScalarString(command);
        }

        public void funDeleteRecord(string TableName, string Condition, ref DbCommand dbCommand)
        {
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_delete";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            //this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            //this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "DBATOOL");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
        }


        public string funReturnSingleValueLink(string databaseName, string TableName, string ColValue, string Condition, string Orderby)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //DataSet set = new DataSet();
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //return handler.ExecuteScalarstring(command);

            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText("rcis_uni.sp_select", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            handler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            return handler.ExecuteScalarstring(command);
        }

        public string funReturnSingleValue(string databaseName, string TableName, string ColValue, string Condition, string Orderby)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            //DataSet set = new DataSet();
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //return handler.ExecuteScalarstring(command);
            DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_select", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            handler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            return handler.ExecuteScalarstring(command);
        }

        public int funReturnSingleValueInt(string databaseName, string TableName, string ColValue, string Condition, string Orderby)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            //DataSet set = new DataSet();
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //return handler.ExecuteScalar(command);
            DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_select", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            handler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            return handler.ExecuteScalar(command);
        }

        public int funReturnSingleValueInt(string TableName, string ColValue, string Condition, string Orderby)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //DataSet set = new DataSet();
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //return handler.ExecuteScalar(command);
            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText("rcis_uni.sp_select", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            handler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            return handler.ExecuteScalar(command);
        }

        public string funReturnSingleValue(string TableName, string ColValue, string Condition, string Orderby)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //DataSet set = new DataSet();
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //return handler.ExecuteScalarstring(command);
            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText("rcis_uni.sp_select", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            handler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            return handler.ExecuteScalarstring(command);
        }

        public void funSetDropDownList1(string databaseName, ref DropDownList ddl, string TableName, string ColValue, string Condition, string Orderby)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //DataSet set = new DataSet();
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //set = handler.FillDataset(command);
            //ddl.DataSource = set.Tables[0].DefaultView;
            //ddl.DataValueField = set.Tables[0].Columns[0].ColumnName;
            //ddl.DataTextField = set.Tables[0].Columns[1].ColumnName;
            //ddl.DataBind();
            //ddl.Items.Insert(0, "-------Select Item------");
            //ddl.SelectedIndex = 0;
            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText("rcis_uni.sp_select", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            handler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            DataSet set = handler.FillDataset(command);
            ddl.DataSource = set.Tables[0].DefaultView;
            ddl.DataValueField = set.Tables[0].Columns[0].ColumnName;
            ddl.DataTextField = set.Tables[0].Columns[1].ColumnName;
            ddl.DataBind();
            ddl.Items.Insert(0, "--निवडा--");
            ddl.SelectedIndex = 0;
        }

        public DataSet funSetDropDownList(string databaseName, ref DropDownList ddl, string TableName, string ColValue, string Condition, string Orderby, string str)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            //DataSet set = new DataSet();
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //set = handler.FillDataset(command);
            //ddl.DataSource = set.Tables[0].DefaultView;
            //ddl.DataValueField = set.Tables[0].Columns[0].ColumnName;
            //ddl.DataTextField = set.Tables[0].Columns[1].ColumnName;
            //ddl.DataBind();
            //ddl.Items.Insert(0, "-------Select Item------");
            //ddl.SelectedIndex = 0;
            //return set;

            DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_select", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            handler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            DataSet set = handler.FillDataset(command);
            ddl.DataSource = set.Tables[0].DefaultView;
            ddl.DataValueField = set.Tables[0].Columns[0].ColumnName;
            ddl.DataTextField = set.Tables[0].Columns[1].ColumnName;
            ddl.DataBind();
            ddl.Items.Insert(0, "--निवडा--");
            ddl.SelectedIndex = 0;
            return set;
        }

        public void funSetDropDownList(string databaseName, ref DropDownList ddl, string TableName, string ColValue, string Condition, string Orderby)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //DataSet set = handler.FillDataset(command);
            //ddl.DataSource = set.Tables[0].DefaultView;
            //ddl.DataValueField = set.Tables[0].Columns[0].ColumnName;
            //ddl.DataTextField = set.Tables[0].Columns[1].ColumnName;
            //ddl.DataBind();
            //ddl.Items.Insert(0, "-------Select Item------");
            //ddl.SelectedIndex = 0;

            DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_select", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            handler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            DataSet set = handler.FillDataset(command);
            ddl.DataSource = set.Tables[0].DefaultView;
            ddl.DataValueField = set.Tables[0].Columns[0].ColumnName;
            ddl.DataTextField = set.Tables[0].Columns[1].ColumnName;
            ddl.DataBind();
            ddl.Items.Insert(0, "--निवडा--");
            ddl.SelectedIndex = 0;
        }

        public DataSet funReturnDataSet(string databaseName, string TableName, string ColValue, string Condition, string Orderby)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            //DataSet set = new DataSet();
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //return handler.FillDataset(command);
            DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_select", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            handler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            return handler.FillDataset(command);
        }

        public DataSet funReturnds(string TableName, string ColValue, string Condition, string Orderby)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //DataSet set = new DataSet();
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //return handler.FillDataset(command);

            DataBaseHandler dbHandler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = dbHandler.SetCommandText("rcis_uni.sp_select", CommandType.StoredProcedure);
            dbHandler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            dbHandler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            dbHandler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            dbHandler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            return dbHandler.FillDataset(command);
        }

        public DataSet funReturnDataSet(string databaseName, string querystr)
        {
            DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            DataSet set = new DataSet();
            DbCommand command = handler.SetCommandText(querystr, CommandType.Text);
            return handler.FillDataset(command);
        }





        public DataSet FillGridViewCircle(string databasname, string schemaname, ref GridView grv, string sevarth_id, string ccode, DataSet ds)
        {
            string command = "select DISTINCT m.isobjection,to_char(m.notice_issue_date,'DD/MM/YYYY')as notice_issue_date, m.notice_issue_date as notice_issue_date_order, m.mut_status_code,mk.ccode,mk.mut_no,v.village_name,mk.ccode,mk.mut_no,m.mut_name,m.mut_type,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')AS pincase,mk.or_code4,m.notice_code"

                                + " from  " + schemaname + ".mut_kharedi mk "
                                + " join " + schemaname + ".mutregister m on mk.ccode=m.ccode and mk.mut_no=m.mut_no"
                                + " join " + schemaname + ".m_village_census v on mk.ccode=v.ccode"
                                + " join " + schemaname + ".m_officermast o on v.ccode=o.ccode"
                                + " join " + schemaname + ".mutregister_audit ma on ma.ccode=m.ccode and ma.mut_no=m.mut_no"
                                + " where m.ccode='" + ccode + "' and (m.mut_status_code = 2 or m.mut_status_code = 1) and (or_code4 = 0 or or_code4 = 1 or or_code4 = 2) and  "
                               + " o.username=@sevarthid and ma.app_name='reEdit' and m.mut_type<>9"
                               + " order by pincase, mk.or_code4,m.notice_code desc,m.isobjection NULLS LAST,notice_issue_date_order desc NULLS LAST; ";
            //+ " order by mk.or_code4 asc,m.mut_status_code asc,notice_issue_date_order NULLS LAST, m.isobjection; ";
            DataBaseHandler dbHandler = new DataBaseHandler(databasname, "LRSRO Connection StringMutation");
            DbCommand dbCmd = dbHandler.SetCommandText(command, CommandType.Text);
            dbHandler.SetInParameter(dbCmd, "@sevarthid", DbType.String, sevarth_id);

            DataSet dsMaster = dbHandler.FillDataset(dbCmd);
            if (ds != null)
            { dsMaster.Merge(ds); }
            grv.DataSource = dsMaster.Tables[0].DefaultView;
            grv.DataBind();
            return dsMaster;

        }


        public DataSet FillGridViewTalathi(string databasname, string schemaname, ref GridView grv, string sevarth_id, string ccode)
        {
            string command = "select DISTINCT m.isobjection,to_char(m.notice_issue_date,'DD/MM/YYYY')as notice_issue_date, m.notice_issue_date as notice_issue_date_order, m.mut_status_code,mk.ccode,mk.mut_no,v.village_name,mk.ccode,mk.mut_no,m.mut_name,m.mut_type,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')AS pincase,m.notice_code,m.table_name"

                                + " from  " + schemaname + ".mut_kharedi mk "
                                + " join " + schemaname + ".mutregister m on mk.ccode=m.ccode and mk.mut_no=m.mut_no"
                                + " join " + schemaname + ".m_village_census v on mk.ccode=v.ccode"
                                + " join " + schemaname + ".m_officermast o on v.ccode=o.ccode"
                                + " join " + schemaname + ".mutregister_audit ma on ma.ccode=m.ccode and ma.mut_no=m.mut_no"
                                + " where m.ccode='" + ccode + "' and m.mut_status_code = 1 and (mk.or_code4=0 or mk.or_code4=1) and  "
                               + " o.username=@sevarthid and ma.app_name='reEdit'"
                               + " order by m.notice_code,m.notice_issue_date NULLS FIRST,mk.mut_no ; ";
            DataBaseHandler dbHandler = new DataBaseHandler(databasname, "LRSRO Connection StringMutation");
            DbCommand dbCmd = dbHandler.SetCommandText(command, CommandType.Text);
            dbHandler.SetInParameter(dbCmd, "@sevarthid", DbType.String, sevarth_id);

            DataSet dsMaster = dbHandler.FillDataset(dbCmd);
            grv.DataSource = dsMaster.Tables[0].DefaultView;
            grv.DataBind();
            return dsMaster;

        }

        public DataSet funSetGridList(string databaseName, ref GridView gdv, string TableName, string ColValue, string Condition, string Orderby)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            //DataSet set = new DataSet();
            //DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            //set = handler.FillDataset(command);
            //if (set.Tables[0] != null && set.Tables[0].Rows.Count > 0)
            //{
            //    gdv.DataSource = set.Tables[0].DefaultView;
            //    gdv.DataBind();
            //}
            //return set;

            DataBaseHandler dbHandler = new DataBaseHandler(databaseName, "database Connection String");
            DbCommand command = dbHandler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_select", CommandType.StoredProcedure);
            dbHandler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            dbHandler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            dbHandler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            dbHandler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            DataSet set = dbHandler.FillDataset(command);
            gdv.DataSource = set.Tables[0].DefaultView;
            gdv.DataBind();
            return set;
        }

        public DataSet get712DS(string databaseName, string schemaName, string sessionid, string surveyno)
        {
            DataBaseHandler dbHandler = new DataBaseHandler(databaseName, "Database Connection String");
            DbCommand dbCmd = dbHandler.SetCommandText(schemaName + ".spget712ds1", CommandType.StoredProcedure);
            dbHandler.SetInParameter(dbCmd, "@sessionid", DbType.String, sessionid);
            dbHandler.SetInParameter(dbCmd, "@serveno", DbType.String, surveyno);
            DataSet ds712 = dbHandler.FillDataset(dbCmd);
            return ds712;
        }

        public void SetInParameter(DbCommand Cmd, string Name, DbType type, object value)
        {
            NpgsqlParameter para = new NpgsqlParameter();
            para.ParameterName = Name;
            para.Direction = ParameterDirection.Input;
            para.DbType = type;
            para.Value = value;
            Cmd.Parameters.Add(para);
        }

        public void SetOutParameter(DbCommand Cmd, string Name, DbType type, int size)
        {
            NpgsqlParameter para = new NpgsqlParameter();
            para.ParameterName = Name;
            para.Direction = ParameterDirection.Output;
            para.DbType = type;
            para.Size = size;
            Cmd.Parameters.Add(para);
        }

        # endregion

        #region [--- Dynamic Function ---]

        public void funUpdatePassword(string databaseName, string tableName, string oldPass, string newPass, string userId, ref Label lblerror)
        {
            //DataBaseHandler dbHandler = new DataBaseHandler(databaseName, "Database Connection String");
            //string CommandText3 = "update " + tableName + " set password='" + newPass + "' where username='" + userId + "' and password='" + oldPass + "';";
            //DbCommand dbCmd3 = dbHandler.SetCommandText(CommandText3, CommandType.Text);
            //int x = dbHandler.ExecuteNonQuery(dbCmd3);
            string SetCol = "password='" + newPass + "'";
            string Condition = "username='" + userId + "' and password='" + oldPass + "'";
            DataBaseHandler dbHandler = new DataBaseHandler(databaseName, "database Connection String");
            DbCommand dbCmd3 = dbHandler.SetCommandText(tableName.Split('.')[0].ToString() + ".sp_update", CommandType.StoredProcedure);
            dbHandler.SetInParameter(dbCmd3, "@para_table_name", DbType.String, tableName);
            dbHandler.SetInParameter(dbCmd3, "@para_set_column", DbType.String, SetCol);
            dbHandler.SetInParameter(dbCmd3, "@para_condition_column", DbType.String, Condition);
            dbHandler.SetOutParameter(dbCmd3, "@para_id", DbType.Int32, 0);
            int x = dbHandler.ExecuteNonQuery(dbCmd3);

            if (x > 0)
                lblerror.Text = "Paswword Updated";
            else
                lblerror.Text = "Password Not Changed";
        }

        public void funUpdateValue(string TableName, string SetCol, string Condition)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //string query = "Update " + TableName + " set " + SetCol + " where " + Condition + ";";
            //DbCommand command = handler.SetCommandText(query, CommandType.Text);
            //int k = handler.ExecuteNonQuery(command);
            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText("rcis_uni.sp_update", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_set_column", DbType.String, SetCol);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, Condition);
            this.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            int k = handler.ExecuteNonQuery(command);
        }

        public int funUpdateValue1(string databaseName, string TableName, string SetCol, string Condition)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //string query = "Update " + TableName + " set " + SetCol + " where " + Condition + ";";
            //DbCommand command = handler.SetCommandText(query, CommandType.Text);
            //int k = handler.ExecuteNonQuery(command);
            DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_update", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_set_column", DbType.String, SetCol);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, Condition);
            this.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            return handler.ExecuteNonQuery(command);
        }
        public int funUpdateValue(string databaseName, string TableName, string SetCol, string Condition, ref DbCommand dbCommand)
        {
            ////string query = "Update " + TableName + " set " + SetCol + " where " + Condition + ";";
            ////dbCommand.CommandText = query;
            ////return dbCommand.ExecuteNonQuery();
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_update";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_set_column", DbType.String, SetCol);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funUpdateValue(string databaseName, string schema_name, string TableName, string SetCol, string Condition, ref DbCommand dbCommand)
        {
            ////string query = "Update " + TableName + " set " + SetCol + " where " + Condition + ";";
            ////dbCommand.CommandText = query;
            ////return dbCommand.ExecuteNonQuery();
            dbCommand.CommandText = schema_name + ".sp_update";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_set_column", DbType.String, SetCol);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funUpdateValueSevarthID(string databaseName, string TableName, string SetCol, string Condition, string loginid, ref DbCommand dbCommand)
        {
            ////string query = "Update " + TableName + " set " + SetCol + " where " + Condition + ";";
            ////dbCommand.CommandText = query;
            ////return dbCommand.ExecuteNonQuery();
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_update_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_set_column", DbType.String, SetCol);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }


        public int funUpdateValue(string databaseName, string schema_name, string TableName, string SetCol, string Condition)
        {
            DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            DbCommand dbCommand = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_update", CommandType.StoredProcedure);

            dbCommand.CommandText = schema_name + ".sp_update";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_set_column", DbType.String, SetCol);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = handler.ExecuteNonQuery(dbCommand);
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funUpdateValueSevarthID(string databaseName, string TableName, string SetCol, string Condition, string loginid)
        {
            DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            DbCommand dbCommand = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_update_em", CommandType.StoredProcedure);

            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_update_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_set_column", DbType.String, SetCol);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = handler.ExecuteNonQuery(dbCommand);
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funUpdateValue_verify(string databaseName, string TableName, string SetCol, string Condition, ref DbCommand dbCommand)
        {
            ////string query = "Update " + TableName + " set " + SetCol + " where " + Condition + ";";
            ////dbCommand.CommandText = query;
            ////return dbCommand.ExecuteNonQuery();
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_update";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_set_column", DbType.String, SetCol);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }



        public int funUpdateValueNewCondSevarthID(string databaseName, string TableName, string SetCol, string Condition, string newCondition, string loginid, ref DbCommand dbCommand)
        {
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_update_em_wnew_cond";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_set_column", DbType.String, SetCol);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetInParameter(dbCommand, "@para_new_cond", DbType.String, newCondition);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funInserSingleValueSevarthID(string databaseName, string TableName, string ColName, string ColValue, string loginid, ref DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_insert_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            if (ColName != "")
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, ColName);
            else
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, "");

            this.SetInParameter(dbCommand, "@para_column_value", DbType.String, ColValue);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }


        public int funInserSingleValueSevarthID_verify(string databaseName, string TableName, string ColName, string ColValue, string loginid, ref DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_insert";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            if (ColName != "")
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, ColName);
            else
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, "");

            this.SetInParameter(dbCommand, "@para_column_value", DbType.String, ColValue);

            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funPopulateValue(string Sch_name, string To_TableName, string To_ColName, string From_ColName, string CondValue, string From_TableName, ref DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = Sch_name + ".sp_populate";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_to_table_name", DbType.String, To_TableName);
            if (To_ColName != "")
                this.SetInParameter(dbCommand, "@para_to_column_name", DbType.String, To_ColName);
            else
                this.SetInParameter(dbCommand, "@para_to_column_name", DbType.String, "");
            if (From_ColName != "")
                this.SetInParameter(dbCommand, "@para_from_column_name", DbType.String, From_ColName);
            else
                this.SetInParameter(dbCommand, "@para_from_column_name", DbType.String, "");
            if (CondValue != "")
                this.SetInParameter(dbCommand, "@para_cond_value", DbType.String, CondValue);
            else
                this.SetInParameter(dbCommand, "@para_cond_value", DbType.String, "");
            this.SetInParameter(dbCommand, "@para_from_table_name", DbType.String, From_TableName);
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funPopulateValueSevarthID(string Sch_name, string To_TableName, string To_ColName, string From_ColName, string CondValue, string From_TableName, string loginid, ref DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = Sch_name + ".sp_populate_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_to_table_name", DbType.String, To_TableName);
            if (To_ColName != "")
                this.SetInParameter(dbCommand, "@para_to_column_name", DbType.String, To_ColName);
            else
                this.SetInParameter(dbCommand, "@para_to_column_name", DbType.String, "");
            if (From_ColName != "")
                this.SetInParameter(dbCommand, "@para_from_column_name", DbType.String, From_ColName);
            else
                this.SetInParameter(dbCommand, "@para_from_column_name", DbType.String, "");
            if (CondValue != "")
                this.SetInParameter(dbCommand, "@para_cond_value", DbType.String, CondValue);
            else
                this.SetInParameter(dbCommand, "@para_cond_value", DbType.String, "");
            this.SetInParameter(dbCommand, "@para_from_table_name", DbType.String, From_TableName);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funInserSingleRecord(string TableName, string ColName, string ColValue)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //string query = "Insert into " + TableName + "(" + ColName + ") values(" + ColValue + ");";
            //DbCommand command = handler.SetCommandText(query, CommandType.Text);
            //return handler.ExecuteNonQuery(command);
            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText("rcis_uni.sp_insert", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColName);
            handler.SetInParameter(command, "@para_column_value", DbType.String, ColValue);
            this.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            return handler.ExecuteNonQuery(command);
        }

        public int funInserSingleValue(string databaseName, string TableName, string ColName, string ColValue, ref DbCommand dbCommand)
        {
            //string query = "";
            //if(ColName!="")
            // query = "Insert into " + TableName + "(" + ColName + ") values(" + ColValue + ");";
            //else
            // query = "Insert into " + TableName + "(" + ColValue + ");";

            //dbCommand.CommandText = query;
            //return dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_insert";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            if (ColName != "")
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, ColName);
            else
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, "");

            this.SetInParameter(dbCommand, "@para_column_value", DbType.String, ColValue);
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }


        public int funInserSingleValue1(string databaseName, string schema, string TableName, string ColName, string ColValue, ref DbCommand dbCommand)
        {
            //string query = "";
            //if(ColName!="")
            // query = "Insert into " + TableName + "(" + ColName + ") values(" + ColValue + ");";
            //else
            // query = "Insert into " + TableName + "(" + ColValue + ");";

            //dbCommand.CommandText = query;
            //return dbCommand.ExecuteNonQuery();

            dbCommand.CommandText = schema + ".sp_insertror";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            if (ColName != "")
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, ColName);
            else
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, "");

            this.SetInParameter(dbCommand, "@para_column_value", DbType.String, ColValue);
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funInserSingleRecord(string databaseName, string TableName, string ColName, string ColValue)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            //string query = "Insert into " + TableName + "(" + ColName + ") values(" + ColValue + ");";
            //DbCommand command = handler.SetCommandText(query, CommandType.Text);
            //return handler.ExecuteNonQuery(command);
            DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");

            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_insert", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_set_column", DbType.String, ColName);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, ColValue);
            handler.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            return handler.ExecuteNonQuery(command);
        }

        public int funInsertError(string databaseName, string schema, string login_id, string form_name, string timestamp, string error_code, string error_dtls)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            //string query = "insert into rcis_uni.error_details (login_id,form_name,date_time,error_code,error_dtls) values('" + login_id + "','" + form_name + "','" + timestamp + "','" + error_code + "','" + error_dtls + "');";
            //DbCommand command = handler.SetCommandText(query, CommandType.Text);
            //return handler.ExecuteNonQuery(command);

            DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            string ColName = "login_id,form_name,date_time,error_code,error_dtls";
            string ColValue = "'" + login_id + "','" + form_name + "','" + timestamp + "','" + error_code + "','" + error_dtls + "'";
            DbCommand command = handler.SetCommandText(schema + ".sp_insert", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, "rcis_uni.error_details");
            handler.SetInParameter(command, "@para_set_column", DbType.String, ColName);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, ColValue);
            handler.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            return handler.ExecuteNonQuery(command);
        }

        public string funInsertErrorstr(string databaseName, string schema, string login_id, string form_name, string timestamp, string error_code, string error_dtls)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            //string query = "insert into rcis_uni.error_details (login_id,form_name,date_time,error_code,error_dtls) values('" + login_id + "','" + form_name + "','" + timestamp + "','" + error_code + "','" + error_dtls + "');select error_mar from rcis_uni.error_master where error_code='" + error_code + "'";
            //DbCommand command = handler.SetCommandText(query, CommandType.Text);
            //return handler.ExecuteScalarstring(command);

            DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            string ColName = "login_id,form_name,date_time,error_code,error_dtls";
            string ColValue = "'" + login_id + "','" + form_name + "','" + timestamp + "','" + error_code + "','" + error_dtls + "');select error_mar from rcis_uni.error_master where error_code='" + error_code + "'";
            DbCommand command = handler.SetCommandText(schema + ".sp_insert", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, "rcis_uni.error_details");
            handler.SetInParameter(command, "@para_set_column", DbType.String, ColName);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, ColValue);
            handler.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            string str = Convert.ToString(handler.ExecuteNonQuery(command));
            return str;
        }

        public int funDeleteRecord(string databaseName, string TableName, string Condition, ref DbCommand dbCommand)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            //string query = "Delete from " + TableName + " where " + Condition + ";";
            //dbCommand.CommandText = query;
            //return dbCommand.ExecuteNonQuery();

            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_delete";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funDeleteRecordSevarthID(string databaseName, string TableName, string Condition, string loginid, ref DbCommand dbCommand)
        {
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_delete_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funDeleteRecord(string databaseName, string TableName, string Condition)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            //string query = "Delete from " + TableName + " where " + Condition + ";";
            //DbCommand command = handler.SetCommandText(query, CommandType.Text);
            //return handler.ExecuteNonQuery(command);

            DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_delete", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, Condition);
            handler.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            return handler.ExecuteNonQuery(command);
        }

        #endregion

        public DataSet funReturnDataSet(string databaseName, string schema, string TableName, string ColValue, string Condition, string Orderby)
        {
            DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            DbCommand command = handler.SetCommandText(schema + ".sp_select", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_column_name", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_condition_value", DbType.String, Condition);
            handler.SetInParameter(command, "@para_order", DbType.String, Orderby);
            return handler.FillDataset(command);
        }

        public int funSelectInsertSingleValue(string databaseName, string TableName, string InsertColName, string SelectColName, string Condition, ref DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_select_insert";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_insert_column_name", DbType.String, InsertColName);
            this.SetInParameter(dbCommand, "@para_select_column_name", DbType.String, SelectColName);
            if (Condition != "")
                this.SetInParameter(dbCommand, "@para_condition_value", DbType.String, Condition);
            else
                this.SetInParameter(dbCommand, "@para_condition_value", DbType.String, "");

            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }

        public int funSelectInsertSingleValueSevarthID(string databaseName, string TableName, string InsertColName, string SelectColName, string Condition, string loginid, ref DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_select_insert_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_insert_column_name", DbType.String, InsertColName);
            this.SetInParameter(dbCommand, "@para_select_column_name", DbType.String, SelectColName);
            if (Condition != "")
                this.SetInParameter(dbCommand, "@para_condition_value", DbType.String, Condition);
            else
                this.SetInParameter(dbCommand, "@para_condition_value", DbType.String, "");
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");

            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }


        public int funUpdateValue1SevarthID(string databaseName, string TableName, string SetCol, string loginid, string Condition)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //string query = "Update " + TableName + " set " + SetCol + " where " + Condition + ";";
            //DbCommand command = handler.SetCommandText(query, CommandType.Text);
            //int k = handler.ExecuteNonQuery(command);
            DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_update_em", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_set_column", DbType.String, SetCol);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, Condition);
            handler.SetInParameter(command, "@para_login_id", DbType.String, loginid);
            handler.SetInParameter(command, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            int k = handler.ExecuteNonQuery(command);
            return k;
            command.Parameters.Clear();
        }

        public int InsertFormzpgp(string DataBasename, string schemaname, decimal zp_rate, decimal vp_rate)
        {

            string cmdText1 = "update " + schemaname + ".m_village_census set zp_rate=" + zp_rate + ", vp_rate=" + vp_rate;
            DataBaseHandler handler1 = new DataBaseHandler(DataBasename, "database Connection String");
            DbCommand command1 = handler1.SetCommandText(cmdText1, CommandType.Text);
            int i = handler1.ExecuteNonQuery(command1);
            return i;


        }

        public void funUpdateNewHolderName(string database, string tablename, string setCol, string setCond, string CondNew, string ccode)
        {

            string login_id = this.funReturnSingleValue(database, tablename.Split('.')[0].ToString() + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");

            DataBaseHandler handler = new DataBaseHandler(database, "LRSRO Connection StringMutation");
            DbCommand command = handler.SetCommandText(tablename.Split('.')[0].ToString() + ".sp_update_em_wnew_cond", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, tablename);
            handler.SetInParameter(command, "@para_set_column", DbType.String, setCol);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, setCond);
            handler.SetInParameter(command, "@para_new_cond", DbType.String, CondNew);
            handler.SetInParameter(command, "@para_login_id", DbType.String, login_id);
            handler.SetInParameter(command, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            handler.ExecuteNonQuery(command);

        }


        public int FillGridViewCircle(string databasname, string schemaname, ref GridView grv, string ccode, int mut_no, int pageIndex, int pageSize)
        {

            string command = "select *,count(*) OVER() AS full_count from(select DISTINCT  m.mut_no,m.mut_name,m.mut_type,k.pin,k.pin1,k.pin2,k.pin3,k.pin4,k.pin5,k.pin6,k.pin7,k.pin8,or_code4,rtrim(((CASE WHEN k.pin<>'' THEN cast(k.pin as text)|| '/' WHEN k.pin='' THEN '' END)  ||(CASE WHEN k.pin1<>'' THEN cast(k.pin1 as text)|| '/' WHEN k.pin1='' THEN '' END)  ||(CASE WHEN k.pin2<>'' THEN cast(k.pin2 as text)|| '/' WHEN k.pin2='' THEN '' END)  ||(CASE WHEN k.pin3<>'' THEN cast(k.pin3 as text)|| '/' WHEN k.pin3='' THEN '' END)  ||(CASE WHEN k.pin4<>'' THEN cast(k.pin4 as text)|| '/' WHEN k.pin4='' THEN '' END)  ||(CASE WHEN k.pin5<>'' THEN cast(k.pin5 as text)|| '/' WHEN k.pin5='' THEN '' END)  ||(CASE WHEN k.pin6<>'' THEN cast(k.pin6 as text)|| '/' WHEN k.pin6='' THEN '' END)  ||(CASE WHEN k.pin7<>'' THEN cast(k.pin7 as text)|| '/' WHEN k.pin7='' THEN '' END)  ||(CASE WHEN k.pin8<>'' THEN cast(k.pin8 as text)|| '/' WHEN k.pin8='' THEN '' END)),'/')AS pincase"

                                + " from  " + schemaname + ".mutregister m, "
                                + schemaname + ".mut_kharedi k"
                                + " where m.ccode = '" + ccode + "' and m.mut_no='" + mut_no + "' and  m.ccode=k.ccode  and or_code4 in (0,1,2 ) and  m.mut_type='101'  and m.mut_no=k.mut_no and  m.mut_status_code <> 0  and trim(k.pin) <>'' "
                                + " order by m.mut_no ,or_code4 ) as temp offset " + (pageIndex * pageSize) + " limit " + pageSize;
            //+ " order by mk.or_code4 asc,m.mut_status_code asc,notice_issue_date_order NULLS LAST, m.isobjection; ";
            DataBaseHandler dbHandler = new DataBaseHandler(databasname, "LRSRO Connection StringMutation");
            DbCommand dbCmd = dbHandler.SetCommandText(command, CommandType.Text);

            DataSet dsMaster = dbHandler.FillDataset(dbCmd);


            //return dsMaster;
            grv.DataSource = dsMaster;
            grv.DataBind();

            if (dsMaster.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(dsMaster.Tables[0].Rows[0]["full_count"]);
            }
            else
            {
                return 0;
            }

        }


        # region[--New functions  for  Auditing(LinkageDB DataBase)---]
        public int funUpdateValue1SevarthID_LNK(string TableName, string SetCol, string Condition, string loginid)
        {
            //DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            //string query = "Update " + TableName + " set " + SetCol + " where " + Condition + ";";
            //DbCommand command = handler.SetCommandText(query, CommandType.Text);
            //int k = handler.ExecuteNonQuery(command);
            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_update_em", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_set_column", DbType.String, SetCol);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, Condition);
            handler.SetInParameter(command, "@para_login_id", DbType.String, loginid);
            handler.SetInParameter(command, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            int k = handler.ExecuteNonQuery(command);
            return k;
            command.Parameters.Clear();
        }
        public int funUpdateValueNewCondSevarthID_LNK(string TableName, string SetCol, string Condition, string newCondition, string loginid, ref DbCommand dbCommand)
        {
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_update_em_wnew_cond";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_set_column", DbType.String, SetCol);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetInParameter(dbCommand, "@para_new_cond", DbType.String, newCondition);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }
        public int funUpdateValueSevarthID_Tr_LNK(string TableName, string SetCol, string Condition, string loginid, ref DbCommand dbCommand)
        {
            ////string query = "Update " + TableName + " set " + SetCol + " where " + Condition + ";";
            ////dbCommand.CommandText = query;
            ////return dbCommand.ExecuteNonQuery();
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_update_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_set_column", DbType.String, SetCol);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }
        public int funInserSingleValueSevarthID_LNK(string TableName, string ColName, string ColValue, string loginid, ref DbCommand dbCommand)
        {
            dbCommand.Parameters.Clear();
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_insert_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            if (ColName != "")
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, ColName);
            else
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, "");

            this.SetInParameter(dbCommand, "@para_column_value", DbType.String, ColValue);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }
        public int funInsertValueSevarthID_LNK(string TableName, string ColName, string ColValue, string loginid)
        {
            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_insert_em", CommandType.StoredProcedure);
            //dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_insert";
            //dbCommand.CommandType = CommandType.StoredProcedure;
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            if (ColName != "")
                handler.SetInParameter(command, "@para_column_name", DbType.String, ColName);
            else
                handler.SetInParameter(command, "@para_column_name", DbType.String, "");

            handler.SetInParameter(command, "@para_column_value", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_login_id", DbType.String, loginid);
            handler.SetInParameter(command, "@para_app_name", DbType.String, "reEdit");
            handler.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            int k = handler.ExecuteNonQuery(command);
            command.Parameters.Clear();
            return k;
        }
        public int funInserSingleValueSevarthID_Tr_LNK(string TableName, string ColName, string ColValue, string loginid, ref DbCommand dbCommand)
        {

            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_insert_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            if (ColName != "")
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, ColName);
            else
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, "");

            this.SetInParameter(dbCommand, "@para_column_value", DbType.String, ColValue);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }
        public int funDeleteRecordSevarthID_Tr_LNK(string TableName, string Condition, string loginid, ref DbCommand dbCommand)
        {
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_delete_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }
        public int funDeleteRecordSevarthID_LNK(string TableName, string Condition, string loginid, ref DbCommand dbCommand)
        {
            dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_delete_em";
            dbCommand.CommandType = CommandType.StoredProcedure;
            this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName);
            this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
            this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
            this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
            this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
            int k = dbCommand.ExecuteNonQuery();
            dbCommand.Parameters.Clear();
            return k;
        }
        public int funDeleteRecord_Audit_LNK(string TableName, string Condition, string loginid)
        {
            //DataBaseHandler handler = new DataBaseHandler(databaseName, "database Connection String");
            //string query = "Delete from " + TableName + " where " + Condition + ";";
            //DbCommand command = handler.SetCommandText(query, CommandType.Text);
            //return handler.ExecuteNonQuery(command);

            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sp_delete_em", CommandType.StoredProcedure);
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            handler.SetInParameter(command, "@para_login_id", DbType.String, loginid);
            handler.SetInParameter(command, "@para_condition_column", DbType.String, Condition);
            handler.SetInParameter(command, "@para_app_name", DbType.String, "reEdit");
            handler.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            return handler.ExecuteNonQuery(command);
        }
        //spinsertall
        public int funInserSingleValueSevarthID_Tr_LNK1(string TableName, string ColName, string ColValue, string loginid)
        {

            DataBaseHandler handler = new DataBaseHandler("Linkage Connection String1");
            DbCommand command = handler.SetCommandText(TableName.Split('.')[0].ToString() + ".sptinsert_all_em", CommandType.StoredProcedure);
            //dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_insert";
            //dbCommand.CommandType = CommandType.StoredProcedure;
            handler.SetInParameter(command, "@para_schema_name", DbType.String, "rcis_uni");
            handler.SetInParameter(command, "@para_table_name", DbType.String, TableName);
            if (ColName != "")
                handler.SetInParameter(command, "@para_column_name", DbType.String, ColName);
            else
                handler.SetInParameter(command, "@para_column_name", DbType.String, "");
            handler.SetInParameter(command, "@para_column_value", DbType.String, ColValue);
            handler.SetInParameter(command, "@para_login_id", DbType.String, loginid);
            handler.SetInParameter(command, "@para_app_name", DbType.String, "reEdit");
            handler.SetOutParameter(command, "@para_id", DbType.Int32, 0);
            int k = handler.ExecuteNonQuery(command);
            command.Parameters.Clear();
            return k;
        }

        # endregion

        public string funCheckEWC_status(string databasname, string schemaname, string ccode)
        {
            int chek1_rpt9 = 0; int check2_tenure = 0; int check5_ZeroArea = 0; int check6_rep56 = 0; int check7_blank712 = 0;
            int check9_ahwal1 = 0; int check10_anwari = 0; int check11_unit = 0; int check17_emptykhatano = 0; int check18_1in1c = 0; int check20_crop = 0; int check21_extracrop = 0; int check8_0100 = 0; int check4_WrongKhataType = 0;
            string blocks_ewc = string.Empty;
            string Out_value = string.Empty;
            DataSet dsEWCCheks = new DataSet();
            string pincase1 = "rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as pins";

            string pincase12 = "rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  ||";
            pincase12 += "(CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  ||";
            pincase12 += "(CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  ||";
            pincase12 += "(CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  ||";
            pincase12 += "(CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  ||";
            pincase12 += "(CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  ||";
            pincase12 += "(CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  ||";
            pincase12 += "(CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  ||";
            pincase12 += "(CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/') as pins";

            dsEWCCheks = this.funReturnDataSet(databasname, schemaname + ".m_ewc_checks", "*", "check_type='S'", "wc_code");
            #region [---Report 9---]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=1"))
            {
                if (drewc["wc_code"].ToString() == "1")
                {
                    // DataSet wrong_pin = this.funReturnDataSet(databasname, "select  numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7 where  ccode='" + ccode + "'  and (pin like '%\\+%' or pin1 like '%\\+%' or pin2 like '%\\+%' or pin3 like '%\\+%' or pin4 like '%\\+%'  or pin5 like '%\\+%' or pin6 like '%\\+%' or pin7 like '%\\+%'  or pin8 like '%\\+%'  or pin like '%\\-%' or pin1 like '%\\-%' or pin2 like '%\\-%' or pin3 like '%\\-%'  or pin4 like '%\\-%'  or pin5 like '%\\-%' or pin6 like '%\\-%' or pin7 like '%\\-%'  or pin8 like '%\\-%' or pin like '%\\*%' or pin1 like '%\\*%' or pin2 like '%\\*%' or pin3 like '%\\*%'  or pin4 like '%\\*%'  or pin5 like '%\\*%' or pin6 like '%\\*%' or pin7 like '%\\*%'  or pin8 like '%\\*%' or pin like '%\\/%' or pin1 like '%\\/%' or pin2 like '%\\/%'  or pin3 like '%\\/%'  or pin4 like '%\\/%'  or pin5 like '%\\/%' or pin6 like '%\\/%' or pin7 like '%\\/%'  or pin8 like '%\\/%'  ) order by numeric_pin");
                    DataSet wrong_pin = this.funReturnDataSet(databasname, "select  numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase1 + " from " + schemaname + ".form7 where  ccode='" + ccode + "' and (pin like '%\\+%' or pin1 like '%\\+%' or pin2 like '%\\+%' or pin3 like '%\\+%' or pin4 like '%\\+%'  or pin5 like '%\\+%' or pin6 like '%\\+%' or pin7 like '%\\+%'  or pin8 like '%\\+%'  or pin like '%\\-%' or pin1 like '%\\-%' or pin2 like '%\\-%' or pin3 like '%\\-%'  or pin4 like '%\\-%'  or pin5 like '%\\-%' or pin6 like '%\\-%' or pin7 like '%\\-%'  or pin8 like '%\\-%' or pin like '%\\*%' or pin1 like '%\\*%' or pin2 like '%\\*%' or pin3 like '%\\*%'  or pin4 like '%\\*%'  or pin5 like '%\\*%' or pin6 like '%\\*%' or pin7 like '%\\*%'  or pin8 like '%\\*%' or pin like '%\\/%' or pin1 like '%\\/%' or pin2 like '%\\/%'  or pin3 like '%\\/%'  or pin4 like '%\\/%'  or pin5 like '%\\/%' or pin6 like '%\\/%' or pin7 like '%\\/%'  or pin like '%\\ '  or pin1 like '%\\ '  or pin2 like '%\\ ' or pin3 like '%\\ ' or pin4 like '%\\ ' or pin5 like '%\\ '  or pin6 like '%\\ '  or pin7 like '%\\ ' or pin8 like '%\\ '  or pin  like '%़%'   or pin1 like '%़%' or pin2 like '%़%' or pin3 like '%़%' or pin4 like '%़%' or pin5 like '%़%' or pin6 like '%़%' or pin7 like '%़%' or pin8 like '%़%'  ) and (ccode ,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  not  in ( select  ccode ,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + schemaname + ".form7_khata where  ccode='" + ccode + "' and   khata_no='500001')  order by numeric_pin");
                    if (wrong_pin.Tables[0].Rows.Count >= 1)
                    {
                        chek1_rpt9 = 1;
                        blocks_ewc += "1,";
                    }
                }
            }
            #endregion

            #region [---tenure--]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=2"))
            {
                if (drewc["wc_code"].ToString() == "2")
                {
                    int f7count = this.funReturnSingleValueInt(databasname, schemaname + ".form7", "count(*)", "ccode='" + ccode + "'", "");
                    DataSet ds_tenure = this.funReturnDataSet(databasname, " select((select count(*) from " + schemaname + ".form7  where  ccode  ='" + ccode + "' and tenure_code not in  (1,2,3,4)  and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001'))||'#'|| ((select  count(*) from " + schemaname + ".form7  where  ccode  ='" + ccode + "' and tenure_code=2  and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') ) ||'#'||(select  count(*) from " + schemaname + ".form7   where  ccode  ='" + ccode + "'  and tenure_code=2  and ( pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8)  in (select  pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8 from " + schemaname + ".form1c  where  ccode  ='" + ccode + "')  and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') ))) as tenure");
                    string[] s = (ds_tenure.Tables[0].Rows[0]["tenure"]).ToString().Split('#');
                    if (s[0] == "0")
                    {
                        if (Convert.ToInt32(s[1].ToString()) > 0)
                        {
                            if (Convert.ToInt32(s[1]) != Convert.ToInt32(s[2]))
                            {
                                check2_tenure = 1;
                                blocks_ewc += "2,";
                            }
                        }
                    }
                    else
                    {
                        check2_tenure = 1;
                        blocks_ewc += "2,";
                    }

                }
            }
            #endregion

            #region [---blank 712--]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=7"))
            {
                if (drewc["wc_code"].ToString() == "7")
                {
                    int count_blank712 = this.funReturnSingleValueInt(databasname, schemaname + ".form7", " count(*)", "ccode  ='" + ccode + "' and   (  pin, pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  ) not  in  ( select    pin, pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8    from  " + schemaname + ".form7_khata where     ccode  ='" + ccode + "') group  by pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8", "pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8");
                    if (count_blank712 > 0)
                    {
                        check7_blank712 = 1;
                        blocks_ewc += "7,";
                    }
                }
            }
            #endregion

            #region [---Report 5 and 6--]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=6"))
            {
                if (drewc["wc_code"].ToString() == "6")
                {
                    //Report 5
                    DataSet holder_detail = this.funReturnDataSet(databasname, "SELECT distinct ccode,khata_no,fname||' '||mname||' '||lname||' '||topan_name as full_name,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  FROM " + schemaname + ".form7_khata  WHERE ccode='" + ccode + "' AND KHATA_NO<>'500001'  AND (khata_no,fname,mname,lname,topan_name) Not IN (select khata_no,fname,mname,lname,topan_name   from " + schemaname + ".holder_detail where ccode='" + ccode + "'  ) order by numeric_pin");
                    if (holder_detail.Tables[0].Rows.Count > 0)
                    {
                        check6_rep56 = 1;
                        blocks_ewc += "6,";
                    }
                }
            }
            #endregion

            #region [---Zero  Area--]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=5"))
            {
                if (drewc["wc_code"].ToString() == "5")
                {
                    string colvalue1 = "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  ||(CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END) ||(CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  ||(CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END) ||(CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  ||(CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  ||(CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  ||(CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)    ||(CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/')AS pincase,khata_no::int, sum(total_area_h+potkharaba) as area,ccode";
                    DataSet ds_zeroArea = this.funReturnDataSet(databasname, schemaname + ".form7_khata as  a ", colvalue1, "a.ccode  ='" + ccode + "' and  khata_no<>'500001' and  marked<>'Y'   and   (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)   not  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata  where  ccode  ='" + ccode + "' and  khata_no='500001')  group  by pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,ccode  having sum(total_area_h+potkharaba)=0", "khata_no::int");

                    if (ds_zeroArea.Tables[0].Rows.Count > 0)
                    {
                        check5_ZeroArea = 1;
                        blocks_ewc += "5,";
                    }
                }
            }
            #endregion

            #region [---Ahwal 1--]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=9"))
            {
                if (drewc["wc_code"].ToString() == "9")
                {
                    DataTable dt_report = new DataTable();
                    DataSet f7area_f7khata_mismatch = new DataSet();
                    DataSet f7_area = new DataSet();
                    DataSet f7_khata = new DataSet();
                    double temp = 0;
                    int count1 = 0;
                    f7_area = this.funReturnDataSet(databasname, schemaname + ".form7_area a," + schemaname + ".form7 b", "distinct a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8,(a.net_culti_area_h+a.na_area_h) as form7_area,(a.potkharaba_a_h+a.potkharaba_b_h) as potkharaba_a_h," + pincase12, "a.ccode='" + ccode + "'  and a.ccode=b.ccode  and a.pin=b.pin and a.pin1=b.pin1 and a.pin2=b.pin2 and a.pin3=b.pin3 and a.pin4=b.pin4 and a.pin5=b.pin5 and a.pin6=b.pin6 and a.pin7=b.pin7 and a.pin8=b.pin8  and    (a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8)  not  in ( select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + schemaname + ".form7_khata where  ccode='" + ccode + "' and   khata_no='500001')", "a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8");
                    f7_khata = this.funReturnDataSet(databasname, schemaname + ".form7_khata a", "a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8,sum(a.total_area_h) as form7_khata_area,sum(a.potkharaba) form7_khata_potkharaba," + pincase12, "a.ccode='" + ccode + "' and a.marked<>'Y' and  a.mut_no<100000 and    (a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8)  not  in ( select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + schemaname + ".form7_khata where  ccode='" + ccode + "' and   khata_no='500001') group by a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8", " a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8");

                    dt_report.Columns.Add("pins");
                    dt_report.Columns.Add("form7_area");
                    dt_report.Columns.Add("form7_area_potk");
                    dt_report.Columns.Add("form7_khata_area");
                    dt_report.Columns.Add("form7_khata_potk");
                    //if (f7_area.Tables[0].Rows.Count > f7_khata.Tables[0].Rows.Count)
                    //{
                    for (int i = 0; i < f7_area.Tables[0].Rows.Count; i++)
                    {
                        {
                            foreach (DataRow dr in f7_khata.Tables[0].Select("pins='" + Convert.ToString(f7_area.Tables[0].Rows[i]["pins"]) + "'"))
                            {
                                #region [---CASE 1 : Potkharaba is 0.00 in form7_khata but non zero in form7_area---]
                                if (Convert.ToString(dr["form7_khata_potkharaba"]) == "0.0000")
                                {
                                    if ((Convert.ToString(f7_area.Tables[0].Rows[i]["form7_area"]) != Convert.ToString(dr["form7_khata_area"])) && ((Convert.ToDecimal(f7_area.Tables[0].Rows[i]["form7_area"]) + Convert.ToDecimal(f7_area.Tables[0].Rows[i]["potkharaba_a_h"])) != (Convert.ToDecimal(dr["form7_khata_area"]))))
                                    {
                                        DataRow drNew = dt_report.NewRow();
                                        drNew["pins"] = Convert.ToString(f7_area.Tables[0].Rows[i]["pins"]);
                                        drNew["form7_area"] = Convert.ToString(f7_area.Tables[0].Rows[i]["form7_area"]);
                                        drNew["form7_area_potk"] = Convert.ToDecimal(f7_area.Tables[0].Rows[i]["potkharaba_a_h"]);
                                        drNew["form7_khata_area"] = Convert.ToString(dr["form7_khata_area"]);
                                        drNew["form7_khata_potk"] = Convert.ToString(dr["form7_khata_potkharaba"]);
                                        dt_report.Rows.Add(drNew);
                                    }
                                }

                                #endregion

                                #region [---CASE 2 : Potkharaba is non zero in form7_khata and non zero in form7_area]
                                if (Convert.ToString(dr["form7_khata_potkharaba"]) != "0.0000")
                                {
                                    if ((Convert.ToDecimal(f7_area.Tables[0].Rows[i]["form7_area"]) + Convert.ToDecimal(f7_area.Tables[0].Rows[i]["potkharaba_a_h"])) != (Convert.ToDecimal(dr["form7_khata_area"]) + Convert.ToDecimal(dr["form7_khata_potkharaba"])))
                                    {
                                        DataRow drNew = dt_report.NewRow();
                                        drNew["pins"] = Convert.ToString(f7_area.Tables[0].Rows[i]["pins"]);
                                        drNew["form7_area"] = Convert.ToString(f7_area.Tables[0].Rows[i]["form7_area"]);
                                        drNew["form7_area_potk"] = Convert.ToDecimal(f7_area.Tables[0].Rows[i]["potkharaba_a_h"]);
                                        drNew["form7_khata_area"] = Convert.ToString(dr["form7_khata_area"]);
                                        drNew["form7_khata_potk"] = Convert.ToString(dr["form7_khata_potkharaba"]);
                                        dt_report.Rows.Add(drNew);
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                    //}

                    if (dt_report.Rows.Count > 0)
                    {
                        check9_ahwal1 = 1;
                        blocks_ewc += "9,";
                    }
                }
            }
            #endregion

            #region [---Anewari---]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=10"))
            {
                if (drewc["wc_code"].ToString() == "10")
                {
                    DataSet anne_pai = this.funReturnDataSet(databasname, "select ccode,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no" + ",sum(anne)as anne ,sum(pai) as pai,(sum(anne)+(sum(pai)/12)::int) as calculated_anne,(sum(pai)%12)::int as remaining_pai,total_area_h FROM " + schemaname + ".form7_khata WHERE ccode='" + ccode + "'  and  total_area_h=0 and potkharaba=0  and marked<>'Y'   and   (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)   not  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata  where  ccode  ='" + ccode + "' and  khata_no='500001') group by ccode,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,total_area_h having (sum(anne)+(sum(pai)/12)::int)>0 order by numeric_pin");
                    if (anne_pai.Tables[0].Rows.Count > 0)
                    {
                        check10_anwari = 1;
                        blocks_ewc += "10,";
                    }
                }
            }
            #endregion

            #region [---Unit Missmatch---]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=11"))
            {
                if (drewc["wc_code"].ToString() == "11")
                {
                    int nacount = 0;
                    DataSet ds = new DataSet();
                    nacount = this.funReturnSingleValueInt(databasname, schemaname + ".form7_area", "count(*)", "ccode='" + ccode + "' and na_area_h>0", "");
                    if (nacount > 0)
                    {
                        string colvalue = "a.ccode,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  ||(CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END) ||(CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  ||(CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END) ||(CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  ||(CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  ||(CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  ||(CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)    ||(CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/')AS pincase,'हे.आर.चौ.मी' as unit, b.na_area_h as area";
                        ds = this.funReturnDataSet(databasname, schemaname + ".form7 as  a ," + schemaname + ".form7_area b", colvalue, "a.ccode  ='" + ccode + "' and   a.ccode =b.ccode   and  a.pin=b.pin and  a.pin1=b.pin1 and  a.pin2=b.pin2 and  a.pin3=b.pin3 and  a.pin4=b.pin4 and  a.pin5=b.pin5 and  a.pin6=b.pin6 and  a.pin7=b.pin7 and  a.pin8=b.pin8 and a.khand_no<>'2'  and  b.na_area_h>0 and  ( a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not  in (select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001')  group by a.ccode, a.pin, a.pin1, a.pin2, a.pin3, a.pin4, a.pin5, a.pin6, a.pin7, a.pin8 ,b.na_area_h", " a.pin, a.pin1, a.pin2, a.pin3, a.pin4, a.pin5, a.pin6, a.pin7, a.pin8");
                    }
                    string colvalue12 = "a.ccode,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  ||(CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END) ||(CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  ||(CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END) ||(CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  ||(CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  ||(CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  ||(CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)    ||(CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/')AS pincase,'आर.चौ.मी' as unit, b.net_culti_area_h as area";
                    DataSet ds1 = this.funReturnDataSet(databasname, schemaname + ".form7 as  a ," + schemaname + ".form7_area b", colvalue12, "a.ccode  ='" + ccode + "' and  a.ccode =b.ccode and  a.pin=b.pin and  a.pin1=b.pin1 and  a.pin2=b.pin2 and  a.pin3=b.pin3 and  a.pin4=b.pin4 and  a.pin5=b.pin5 and  a.pin6=b.pin6 and  a.pin7=b.pin7 and  a.pin8=b.pin8 and a.khand_no='2' and  b.net_culti_area_h>0  and b.na_area_h=0 and  ( a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not  in (select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') group by a.ccode, a.pin, a.pin1, a.pin2, a.pin3, a.pin4, a.pin5, a.pin6, a.pin7, a.pin8 ,b.net_culti_area_h", " a.pin, a.pin1, a.pin2, a.pin3, a.pin4, a.pin5, a.pin6, a.pin7, a.pin8");

                    if (nacount > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0 || ds1.Tables[0].Rows.Count > 0)
                        {
                            check11_unit = 1;
                            blocks_ewc += "11,";
                        }
                    }
                    else
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            check11_unit = 1;
                            blocks_ewc += "11,";
                        }
                    }
                }
            }
            #endregion

            #region [---Dangling khata---]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=17"))
            {
                if (drewc["wc_code"].ToString() == "17")
                {
                    // DataSet ds_khataNo = this.funReturnDataSet(databasname, schemaname + ".holder_detail", "ccode, khata_no, '' as operation", "ccode  ='" + ccode + "' and  ( ccode  ,  khata_no )  not  in (  select distinct    ccode  ,  khata_no from  " + schemaname + ".form7_khata   where ccode  ='" + ccode + "' ) and khata_no not in ( select  khata_no  from  (select distinct  a.khata_no from   " + schemaname + ".mut_kharedi_buyer a  ," + schemaname + ".mut_kharedi b  where  a.ccode='" + ccode + "' and a.ccode =b.ccode  and b.or_code4 in (1,0) union select distinct  a.khata_no from   " + schemaname + ".mut_kharedi_buyer_khata a  ," + schemaname + ".mut_kharedi b  where  a.ccode='" + ccode + "' and a.ccode =b.ccode  and b.or_code4 in (1,0)union select   distinct  a.khata_no from  " + schemaname + ".edit_form7_khata  a  ," + schemaname + ".edit_mut b where  a.ccode='" + ccode + "' and a.ccode =b.ccode  and  a.ccode=b.ccode and  a.pin=b.pin and   a.pin1=b.pin1 and   a.pin2=b.pin2 and   a.pin3=b.pin3 and   a.pin4=b.pin4 and   a.pin5=b.pin5 and   a.pin6=b.pin6 and   a.pin7=b.pin7 and   a.pin8=b.pin8 and   b.marked_flag='Edit' and  b.confirm_flag=''  and  b.approve_flag='' union select distinct  khata_no from " + schemaname + ".tblpartydetails a  left  join  " + schemaname + ".tblinputentry  b   on a.documentnumber=b.documentnumber and  a.docyear=b.docyear where b.censuscode='" + ccode + "' and   b.mutationno is  null and  a.partytype='P') as z)", "");
                    DataSet ds_khataNo = this.funReturnDataSet(databasname, schemaname + ".holder_detail", "ccode, khata_no, '' as operation", "ccode  ='" + ccode + "' and  ( ccode  ,  khata_no )  not  in (  select distinct    ccode  ,  khata_no from  " + schemaname + ".form7_khata   where ccode  ='" + ccode + "' ) and khata_no not in ( select  khata_no  from  ( select distinct  a.buyer_khata_no as khata_no from   " + schemaname + ".mut_kharedi_buyer a  ," + schemaname + ".mut_kharedi b  where  a.ccode='" + ccode + "' and a.ccode =b.ccode and a.mut_no=b.mut_no   and b.or_code4 in (1,0) union select distinct  a.khata_no from   " + schemaname + ".mut_kharedi_buyer a  ," + schemaname + ".mut_kharedi b  where  a.ccode='" + ccode + "' and a.ccode =b.ccode  and a.mut_no=b.mut_no   and b.or_code4 in (1,0) union select distinct  a.khata_no from   " + schemaname + ".mut_kharedi_buyer_khata a  ," + schemaname + ".mut_kharedi b  where  a.ccode='" + ccode + "' and a.ccode =b.ccode  and a.mut_no=b.mut_no   and b.or_code4 in (1,0)union select   distinct  a.khata_no from  " + schemaname + ".edit_form7_khata  a  ," + schemaname + ".edit_mut b where  a.ccode='" + ccode + "' and a.ccode =b.ccode  and  a.ccode=b.ccode and  a.pin=b.pin and   a.pin1=b.pin1 and   a.pin2=b.pin2 and   a.pin3=b.pin3 and   a.pin4=b.pin4 and   a.pin5=b.pin5 and   a.pin6=b.pin6 and   a.pin7=b.pin7 and   a.pin8=b.pin8 and   b.marked_flag='Edit' and  b.confirm_flag=''  and  b.approve_flag='' union select distinct  khata_no from " + schemaname + ".tblpartydetails a  left  join  " + schemaname + ".tblinputentry  b   on a.documentnumber=b.documentnumber and  a.docyear=b.docyear where b.censuscode='" + ccode + "' and   b.mutationno is  null and  a.partytype='P') as z)", "");
                    if (ds_khataNo.Tables[0].Rows.Count > 0 || ds_khataNo.Tables[0].Rows.Count > 0)
                    {
                        check17_emptykhatano = 1;
                        blocks_ewc += "17,";
                    }

                }
            }
            #endregion

            #region [---tenure 1  in 1c---]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=18"))
            {
                if (drewc["wc_code"].ToString() == "18")
                {
                    DataSet dsbhudharna = new DataSet();
                    string form7count = "pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,rtrim(((CASE WHEN k.pin<>'' THEN cast(k.pin as text)|| '/' WHEN k.pin='' THEN '' END)  ||(CASE WHEN k.pin1<>'' THEN cast(k.pin1 as text)|| '/' WHEN k.pin1='' THEN '' END)  ||(CASE WHEN k.pin2<>'' THEN cast(k.pin2 as text)|| '/' WHEN k.pin2='' THEN '' END)  ||(CASE WHEN k.pin3<>'' THEN cast(k.pin3 as text)|| '/' WHEN k.pin3='' THEN '' END)  ||(CASE WHEN k.pin4<>'' THEN cast(k.pin4 as text)|| '/' WHEN k.pin4='' THEN '' END)  ||(CASE WHEN k.pin5<>'' THEN cast(k.pin5 as text)|| '/' WHEN k.pin5='' THEN '' END)  ||(CASE WHEN k.pin6<>'' THEN cast(k.pin6 as text)|| '/' WHEN k.pin6='' THEN '' END)  ||(CASE WHEN k.pin7<>'' THEN cast(k.pin7 as text)|| '/' WHEN k.pin7='' THEN '' END)  ||(CASE WHEN k.pin8<>'' THEN cast(k.pin8 as text)|| '/' WHEN k.pin8='' THEN '' END)),'/')AS pincase";
                    dsbhudharna = this.funReturnDataSet(databasname, schemaname + ".form7 as k", form7count, "k.ccode='" + ccode + "'and tenure_code=1 and ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form1c where ccode ='" + ccode + "') and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001')", "numeric_pin::int ");
                    if (dsbhudharna.Tables[0].Rows.Count > 0)
                    {
                        check18_1in1c = 1;
                        blocks_ewc += "18,";
                    }
                }
            }
            #endregion

            #region [---last 3  years crop---]
            //foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=20"))
            //{
            //    if (drewc["wc_code"].ToString() == "20")
            //    {

            //        int year_uptp = 0;
            //        if (System.DateTime.Now.Month > 7)
            //        {
            //            //year_uptp = System.DateTime.Now.Year; this  is  ok  for  revenue  year but to clear  report we are cosidering  current year-1
            //            year_uptp = System.DateTime.Now.Year - 1;
            //        }
            //        else if (System.DateTime.Now.Month <= 7)
            //        {
            //            year_uptp = System.DateTime.Now.Year - 1;
            //        }
            //        //DataSet dsincorct_cnt = this.funReturnDataSet(databasname, "select distinct   pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  ( (select a.ccode ,a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8  from " + schemaname + ".form7 a , " + schemaname + ".form7_area b where a.ccode='" + ccode + "' and b.na_area_h<=0.0000 and a.marked<>'Y' and a.ccode=b.ccode and a.pin=b.pin and a.pin1=b.pin1 and a.pin2=b.pin2 and a.pin3=b.pin3 and a.pin4=b.pin4 and a.pin5=b.pin5 and a.pin6=b.pin6 and a.pin7=b.pin7 and a.pin8=b.pin8 and (a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + schemaname + ".form12_main where ccode='" + ccode + "' and  year_culti=" + (year_Upto - 2) + ") order by numeric_pin) union ( select a.ccode, a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8  from  " + schemaname + ".form7 a, " + schemaname + ".form7_area b where a.ccode='" + ccode + "' and b.na_area_h<=0.0000 and a.marked<>'Y' and a.ccode=b.ccode and a.pin=b.pin and a.pin1=b.pin1 and a.pin2=b.pin2 and a.pin3=b.pin3 and a.pin4=b.pin4 and a.pin5=b.pin5 and a.pin6=b.pin6 and a.pin7=b.pin7 and a.pin8=b.pin8 and (a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + schemaname + ".form12_main where ccode='" + ccode + "' and  year_culti=" + (year_Upto - 1) + ") order by numeric_pin ) union ( select a.ccode, a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8  from  " + schemaname + ".form7 a, " + schemaname + ".form7_area b where a.ccode='" + ccode + "' and b.na_area_h<=0.0000 and a.marked<>'Y' and a.ccode=b.ccode and a.pin=b.pin and a.pin1=b.pin1 and a.pin2=b.pin2 and a.pin3=b.pin3 and a.pin4=b.pin4 and a.pin5=b.pin5 and a.pin6=b.pin6 and a.pin7=b.pin7 and a.pin8=b.pin8 and (a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + schemaname + ".form12_main where ccode='" + ccode + "' and  year_culti=" + (year_Upto) + ") order by numeric_pin ) ) as x");
            //        DataSet dsincorct_cnt = this.funReturnDataSet(databasname, "select distinct   pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  ( (select a.ccode ,a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8  from " + schemaname + ".form7 a , " + schemaname + ".form7_area b where a.ccode='" + ccode + "' and b.na_area_h<=0.0000   and a.ccode=b.ccode and a.pin=b.pin and a.pin1=b.pin1 and a.pin2=b.pin2 and a.pin3=b.pin3 and a.pin4=b.pin4 and a.pin5=b.pin5 and a.pin6=b.pin6 and a.pin7=b.pin7 and a.pin8=b.pin8 and (a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + schemaname + ".form12_main where ccode='" + ccode + "' and  year_culti=" + (year_uptp - 2) + ") and   ( a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not  in (select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') order by numeric_pin) union ( select a.ccode, a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8  from  " + schemaname + ".form7 a, " + schemaname + ".form7_area b where a.ccode='" + ccode + "' and b.na_area_h<=0.0000 and   a.ccode=b.ccode and a.pin=b.pin and a.pin1=b.pin1 and a.pin2=b.pin2 and a.pin3=b.pin3 and a.pin4=b.pin4 and a.pin5=b.pin5 and a.pin6=b.pin6 and a.pin7=b.pin7 and a.pin8=b.pin8 and (a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + schemaname + ".form12_main where ccode='" + ccode + "' and  year_culti=" + (year_uptp - 1) + ") and   ( a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not  in (select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') order by numeric_pin ) union ( select a.ccode, a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8  from  " + schemaname + ".form7 a, " + schemaname + ".form7_area b where a.ccode='" + ccode + "' and b.na_area_h<=0.0000  and   a.ccode=b.ccode and a.pin=b.pin and a.pin1=b.pin1 and a.pin2=b.pin2 and a.pin3=b.pin3 and a.pin4=b.pin4 and a.pin5=b.pin5 and a.pin6=b.pin6 and a.pin7=b.pin7 and a.pin8=b.pin8 and (a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + schemaname + ".form12_main where ccode='" + ccode + "' and  year_culti=" + (year_uptp) + ") and   ( a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not  in (select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') order by numeric_pin ) ) as x");
            //        if (dsincorct_cnt.Tables[0].Rows.Count > 0)
            //        {
            //            check20_crop = 1;
            //            blocks_ewc += "20,";
            //        }
            //    }
            //}
            #endregion

            #region [---exrta years  crop---]
            //foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=21"))
            //{
            //    if (drewc["wc_code"].ToString() == "21")
            //    {
            //        DataSet ds_exyr = new DataSet();
            //        string colvalue_exyr = "rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  ||(CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END) ||(CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  ||(CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END) ||(CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  ||(CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  ||(CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  ||(CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)    ||(CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/')AS pincase,ccode,year_culti";
            //        if (System.DateTime.Now.Month > 7)
            //            ds_exyr = this.funReturnDataSet(databasname, schemaname + ".form12_main as  a ", " distinct " + colvalue_exyr, "a.ccode  ='" + ccode + "'and  year_culti>" + System.DateTime.Now.Year + "", "year_culti");
            //        else if (System.DateTime.Now.Month <= 7)
            //            ds_exyr = this.funReturnDataSet(databasname, schemaname + ".form12_main as  a ", " distinct " + colvalue_exyr, "a.ccode  ='" + ccode + "'and  year_culti>=" + System.DateTime.Now.Year + "", "year_culti");
            //        if (ds_exyr.Tables[0].Rows.Count > 0)
            //        {
            //            check21_extracrop = 1;
            //            blocks_ewc += "21,";
            //        }
            //    }
            //}

            #endregion

            #region [---0% -100%---]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=8"))
            {
                if (drewc["wc_code"].ToString() == "8")
                {
                    DataSet ds_khata = new DataSet();
                    DataSet ds_f7k = new DataSet();
                    DataTable dt_report1 = new DataTable();
                    DataTable dt_f7k_distinct = new DataTable();
                    int total_count = 0; int count = 0;

                    dt_report1.Columns.Add("khata_no");
                    dt_report1.Columns.Add("pins");

                    ds_khata = this.funReturnDataSet(databasname, schemaname + ".holder_detail", "distinct khata_no::int", "ccode='" + ccode + "' and khata_no<>''", "khata_no::int");
                    ds_f7k = this.funReturnDataSet(databasname, schemaname + ".form7_khata", "*,khata_no::int," + pincase1, "ccode='" + ccode + "' and khata_no<>'' and marked<>'Y' and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001')", "khata_no::int,numeric_pin");

                    dt_f7k_distinct = ds_f7k.Tables[0].DefaultView.ToTable(true, "khata_no", "pin", "pin1", "pin2", "pin3", "pin4", "pin5", "pin6", "pin7", "pin8", "pins");

                    if (ds_khata.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds_khata.Tables[0].Rows)
                        {
                            foreach (DataRow r1 in dt_f7k_distinct.Select("khata_no='" + Convert.ToString(dr["khata_no"]) + "'"))
                            {
                                total_count = Convert.ToInt32(ds_f7k.Tables[0].Compute("count(usrno)", "khata_no='" + Convert.ToString(dr["khata_no"]) + "' and pins='" + Convert.ToString(r1["pins"]) + "'"));
                                count = Convert.ToInt32(ds_f7k.Tables[0].Compute("count(usrno)", "(total_area_h>0 or potkharaba>0) and khata_no='" + Convert.ToString(dr["khata_no"]) + "' and pins='" + Convert.ToString(r1["pins"]) + "'"));
                                if (count > 1 && total_count > count)
                                {
                                    DataRow drow = dt_report1.NewRow();
                                    drow["khata_no"] = Convert.ToString(dr["khata_no"]);
                                    drow["pins"] = Convert.ToString(r1["pins"]);
                                    dt_report1.Rows.Add(drow);
                                    dt_report1.AcceptChanges();
                                    count = 0;
                                    total_count = 0;
                                }
                            }
                        }
                    }

                    if (dt_report1.Rows.Count > 0)
                    {
                        check8_0100 = 1;
                        blocks_ewc += "8,";
                    }
                }
            }
            #endregion

            #region [---Wrong  khata  Type---]
            foreach (DataRow drewc in dsEWCCheks.Tables[0].Select("wc_code=4"))
            {
                if (drewc["wc_code"].ToString() == "4")
                {
                    DataTable dt_wrongkhatatype = new DataTable();
                    DataTable dt_wrongkhatatype_new = new DataTable();
                    DataTable dt_twisekhatatype = new DataTable();
                    DataSet holder_khata_type_mismatch = this.funReturnDataSet(databasname, "(select a.khata_no::int,a.khata_type,b.khata_description,count(a.*) as cnt from " + schemaname + ".holder_detail a," + schemaname + ".m_khata_type b where ccode='" + ccode + "' and a.khata_type=b.khata_type and (a.khata_type='2' or a.khata_type='3'  or a.khata_type='0') and   a.khata_no<>'500001'   AND  a.khata_no not like  '%TKN%' and  a.marked<>'Y' AND  a.khata_no<>''    and  a.old_mut_no<=100000 group by a.khata_no,a.khata_type,b.khata_description  having count(a.khata_no::int)=1 order by (a.khata_no::int))  union (select a.khata_no::int,a.khata_type,b.khata_description,count(a.*) from " + schemaname + ".holder_detail a," + schemaname + ".m_khata_type b where ccode='" + ccode + "' and a.khata_type=b.khata_type and (a.khata_type='1') and   a.khata_no<>'500001'   and  a.khata_no not like  '%TKN%' and  a.marked<>'Y'  and  a.khata_no <>'' and   a.old_mut_no<=100000  group by a.khata_no,a.khata_type,b.khata_description having count(a.khata_no::int)>1 order by (a.khata_no::int))  union (select a.khata_no::int,a.khata_type,b.khata_description,count(a.*) from " + schemaname + ".holder_detail a," + schemaname + ".m_khata_type b where ccode='" + ccode + "' and a.khata_type=b.khata_type and (a.khata_type='0') and   a.khata_no<>'500001'    and   a.khata_no not like  '%TKN%' and  a.marked<>'Y'  and   a.khata_no<>'' and  a.old_mut_no<=100000  group by a.khata_no,a.khata_type,b.khata_description having count(a.khata_no::int)>1 order by (a.khata_no::int))");
                    DataSet ds12 = this.funReturnDataSet(databasname, schemaname + ".holder_detail a , " + schemaname + ".m_khata_type b", " a.khata_no,a.khata_type ,b.khata_description , 0 as   cnt", "a.khata_type=b.khata_type and  ccode='" + ccode + "' and a.khata_type<>0 and   a.khata_no<>'500001'   and  a.marked<>'Y'  AND  a.khata_no not like  '%TKN%' group by  a.khata_no,a.khata_type,b.khata_description", "a.khata_no");
                    foreach (DataRow dr1 in ds12.Tables[0].Rows)
                    {
                        DataSet ds2 = this.funReturnDataSet(databasname, schemaname + ".holder_detail a , " + schemaname + ".m_khata_type b", " a.khata_no::int,a.khata_type ,b.khata_description , count(a.*) as cnt", "a.khata_type=b.khata_type and  a.ccode='" + ccode + "' and a.khata_no='" + dr1["khata_no"] + "'   and   a.khata_no<>'500001'   AND  a.khata_no not like  '%TKN%' AND  a.khata_no<>'' and  a.marked<>'Y'  and  a.old_mut_no<=100000   group by  a.khata_no,a.khata_type,b.khata_description", "a.khata_no");
                        if (ds2.Tables[0].Rows.Count > 1)
                        {
                            //dt_twisekhatatype.NewRow();
                            holder_khata_type_mismatch.Tables[0].Merge(ds2.Tables[0]);
                            //dt_twisekhatatype.Merge(ds2.Tables[0]);
                            //dt_twisekhatatype.AcceptChanges();
                        }
                    }
                    //holder_khata_type_mismatch.Merge(dt_twisekhatatype);
                    holder_khata_type_mismatch.AcceptChanges();
                    dt_wrongkhatatype_new = holder_khata_type_mismatch.Tables[0].DefaultView.ToTable(true, "khata_no", "khata_type", "khata_description", "cnt");
                    holder_khata_type_mismatch.AcceptChanges();
                    DataView dv = dt_wrongkhatatype_new.DefaultView;
                    dv.Sort = "khata_no asc";
                    dt_wrongkhatatype = dv.ToTable();

                    if (dt_wrongkhatatype.Rows.Count > 0)
                    {
                        check4_WrongKhataType = 0;
                        blocks_ewc += "4,";
                    }
                }
            }
            #endregion

            #region [---same name group with  different khata on same survey---]
            DataSet ds_samenames = new DataSet();
            // DataSet ds_samenames= this.funReturnDataSet(databasname, "select ccode ,survey , names , count(*) as khata_no_count,string_agg(khata_no, ', ') as khata_nos from (select ccode, string_agg(trim(fname)||' '||trim(mname)||' '||trim(lname)||' '||trim(topan_name), ', ') as names ,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey  from " + schemaname + ".form7_khata  where ccode  ='" + ccode + "'    group by ccode, khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ) as a  where ccode  ='" + ccode + "'    group by ccode , survey , names  having count(*) > 1 ");
            int cont_img_check_set = this.funReturnSingleValueInt(databasname, schemaname + ".m_village_census_check", "count(*)", "ccode='" + ccode + "'  and imaginary_mut_no_check = false", "");
            if (cont_img_check_set == 0)
            {
                ds_samenames = this.funReturnDataSet(databasname, "select distinct  ccode ,survey,names,string_agg(distinct z.khata_nos, ', ') as khata_nos ,count(khata_nos) as khata_no_count from ((select distinct x.*, string_agg(distinct y.khata_no, ', ') as khata_nos from (select ccode,survey,names,count(names) from (select ccode, string_agg(distinct trim( replace (replace(replace(fname,' ','') ,' %','') , '% ','') )||' '||trim(replace (replace(replace(mname,' ','') ,' %','') , '% ','') )||' '||trim(replace (replace(replace(lname,' ','') ,' %','') , '% ',''))||' '||trim(replace (replace(replace(topan_name,' ','') ,' %','') , '% ','') ), ', ') as names ,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey  from " + schemaname + ".form7_khata where ccode='" + ccode + "' and  mut_no<100000  and marked<>'Y'  and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and  mut_no<100000   and khata_no='500001') group by ccode,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ) as a group by ccode,survey,names having count(names)>1) as x ,(select  khata_no,string_agg(distinct trim( fname)||' '||trim( mname)||' '||trim( lname)||' '||trim( topan_name), ', ') as names1,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey1 from  " + schemaname + ".form7_khata   where  ccode='" + ccode + "'  and  mut_no<100000  and    khata_no<>'500001'  group by  khata_no,survey1 ) as y where x.names=y.names1 group by y.khata_no,ccode,survey,names,count)  order by survey )as z group by ccode ,survey,names  order by survey");
            }
            else
            {
                ds_samenames = this.funReturnDataSet(databasname, "select distinct  ccode ,survey,names,string_agg(distinct z.khata_nos, ', ') as khata_nos ,count(khata_nos) as khata_no_count from ((select distinct x.*, string_agg(distinct y.khata_no, ', ') as khata_nos from (select ccode,survey,names,count(names) from (select ccode, string_agg(distinct trim( replace (replace(replace(fname,' ','') ,' %','') , '% ','') )||' '||trim(replace (replace(replace(mname,' ','') ,' %','') , '% ','') )||' '||trim(replace (replace(replace(lname,' ','') ,' %','') , '% ',''))||' '||trim(replace (replace(replace(topan_name,' ','') ,' %','') , '% ','') ), ', ') as names ,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey  from " + schemaname + ".form7_khata where ccode='" + ccode + "'  and marked<>'Y'   and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') group by ccode,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ) as a group by ccode,survey,names having count(names)>1) as x ,(select  khata_no,string_agg(distinct trim( fname)||' '||trim( mname)||' '||trim( lname)||' '||trim( topan_name), ', ') as names1,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey1 from  " + schemaname + ".form7_khata   where  ccode='" + ccode + "'  and    khata_no<>'500001'  group by  khata_no,survey1 ) as y where x.names=y.names1 group by y.khata_no,ccode,survey,names,count)  order by survey )as z group by ccode ,survey,names  order by survey");
            }
            // ds_samenames = this.funReturnDataSet(databasname, "select distinct  ccode ,survey,names,string_agg(distinct z.khata_nos, ', ') as khata_nos ,count(khata_nos) as khata_no_count from ((select distinct x.*, string_agg(distinct y.khata_no, ', ') as khata_nos from (select ccode,survey,names,count(names) from (select ccode, string_agg(distinct trim(fname)||' '||trim(mname)||' '||trim(lname)||' '||trim(topan_name), ', ') as names ,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey  from " + schemaname + ".form7_khata where ccode='" + ccode + "'  and marked<>'Y'  and   ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') group by ccode,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ) as a group by ccode,survey,names having count(names)>1) as x ,(select  khata_no,string_agg(distinct trim( fname)||' '||trim( mname)||' '||trim( lname)||' '||trim( topan_name), ', ') as names1,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey1 from  " + schemaname + ".form7_khata   where  ccode='" + ccode + "'  and    khata_no<>'500001'  group by  khata_no,survey1 ) as y where x.names=y.names1 group by y.khata_no,ccode,survey,names,count)  order by survey )as z group by ccode ,survey,names  order by survey");

            if (ds_samenames.Tables[0].Rows.Count > 0)
            {
                blocks_ewc += "25,";
            }
            #endregion

            #region [---Blank Names on  Survey-Khata ---]
            DataSet ds_Blank_names = this.funReturnDataSet(databasname, "select distinct  a.* , count(b.*) as total_blank_names from (select  count (*) as total_names, ccode, khata_no  ,  rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey  from    " + schemaname + ".form7_khata  where  ccode ='" + ccode + "'  and  (ccode, khata_no  ,  pin, pin1,pin2,pin3,pin4 , pin5, pin6,pin7,pin8  )  in (select distinct  ccode, khata_no  ,  pin, pin1,pin2,pin3,pin4 , pin5, pin6,pin7,pin8    from  " + schemaname + ".form7_khata  where  ccode ='" + ccode + "'   and trim(replace (replace(replace(fname || mname  ||lname||topan_name,'	','') ,' %','') , '% ',''))='' )   group  by ccode, khata_no  , survey  ) as a, " + schemaname + ".form7_khata  b where  a.ccode ='" + ccode + "' and a.ccode =b.ccode and  trim(replace (replace(replace(b.fname || b.mname  ||b.lname||b.topan_name,'	','') ,' %','') , '% ',''))='' group  by a.total_names, a.ccode, a.khata_no  ,  a.survey,  b.ccode, b.khata_no  ,  b.pin, b.pin1,b.pin2,b.pin3,b.pin4 , b.pin5, b.pin6,b.pin7,b.pin8  order by   a.survey, a.khata_no");
            if (ds_Blank_names.Tables[0].Rows.Count > 0)
            {
                blocks_ewc += "26,";
            }
            #endregion

            #region[----Check  For NameSpaceDuplicate----]
            DataSet ds_SpaceDup = this.funReturnDataSet(databasname, "select rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey, pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no, trim( replace (replace(replace(fname,'	','') ,' %','') , '% ','') )as tfname,trim(replace (replace(replace(mname,'	','') ,' %','') , '% ','') )as tmname,trim(replace (replace(replace(lname,'	','') ,' %','') , '% ','')) as tlname,trim(replace (replace(replace(topan_name,'	','') ,' %','') , '% ','') )as ttopan_name  from  " + schemaname + ".form7_khata   where ccode ='" + ccode + "' group by survey, pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no, trim( replace (replace(replace(fname,'	','') ,' %','') , '% ','') ) ,trim(replace (replace(replace(mname,'	','') ,' %','') , '% ','') ) ,trim(replace (replace(replace(lname,'	','') ,' %','') , '% ',''))  ,trim(replace (replace(replace(topan_name,'	','') ,' %','') , '% ','') )   having count(*)>1");
            if (ds_SpaceDup.Tables[0].Rows.Count > 0)
            {
                blocks_ewc += "27,";
            }
            #endregion

            #region[----Check  For Invalid Apk ,Ekume name  khatas----]
            DataSet ds_wrong_akp_akm = this.funReturnDataSet(databasname, schemaname + ".form7_khata", "ccode, khata_no, string_agg(distinct rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ,',') as survey, string_agg(fname||' '||mname||' '||lname||' '||topan_name,',') as names", "ccode  ='" + ccode + "' and  (ccode , khata_no) in (select ccode , khata_no  from  " + schemaname + ".holder_detail where  ccode  ='" + ccode + "' and   replace(fname||mname||lname||topan_name,' ','') ='एकुक'  or replace(fname||mname||lname||topan_name,'.','') ='एकुक'  or replace(fname||mname||lname||topan_name,'.','') ='अपाक'  or replace(fname||mname||lname||topan_name,' ','') ='अपाक' or replace(fname||mname||lname||topan_name,'.','') ='एकुमॅ'  or replace(fname||mname||lname||topan_name,' ','') ='एकुमॅ' )group by  ccode , khata_no ", "");
            if (ds_wrong_akp_akm.Tables[0].Rows.Count > 0)
            {
                blocks_ewc += "28,";
            }
            #endregion

            #region [---Check  For ODC Report 4 (गाव नमुना ७ वरील एकुण क्षेत्र व जिरायत,बागायत,इत्यादी क्षेत्र यांचा मेळ न बसलेले सर्व्हे क्र)---]
            DataSet ds_report4 = new DataSet();
            ds_report4 = this.funReturnDataSet(databasname, "select numeric_pin,jirayat_area_h,bagayat_area_h,tari_area_h,varkas_area_h,itar_area_h,potkharaba_a_h,potkharaba_b_h,(jirayat_area_h+bagayat_area_h+tari_area_h+varkas_area_h+itar_area_h+potkharaba_a_h+potkharaba_b_h+na_area_h) as sum,total_area_h,na_area_h,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase1 + "  from " + schemaname + ".form7_area  where total_area_h<>na_area_h and ccode='" + ccode + "' and total_area_h>0 and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') group by  jirayat_area_h,bagayat_area_h,tari_area_h,varkas_area_h,itar_area_h,potkharaba_a_h,potkharaba_b_h,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,total_area_h,na_area_h,numeric_pin having sum(jirayat_area_h+bagayat_area_h+tari_area_h+varkas_area_h+itar_area_h+potkharaba_a_h+potkharaba_b_h+na_area_h)<>total_area_h  order by numeric_pin");
            if (ds_report4.Tables.Count > 0)
            {
                if (ds_report4.Tables[0].Rows.Count > 0)
                {
                    blocks_ewc += "29,";
                }
            }
            #endregion

            #region [---Check  For ODC Report 8 (फ़ेरफ़ार क्र. नसलेल्या कब्जेदारांची नावे)---]
            DataSet f7k_mut_blank = new DataSet();
            f7k_mut_blank = this.funReturnDataSet(databasname, "select khata_no,pin,pin,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase1 + " ,fname||' '||mname||' '||lname||' '||topan_name as full_name from " + schemaname + ".form7_khata where mut_no='0' and ccode='" + ccode + "' and marked<>'Y' and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') order by (khata_no::int)");
            if (f7k_mut_blank.Tables.Count > 0)
            {
                if (f7k_mut_blank.Tables[0].Rows.Count > 0)
                {
                    blocks_ewc += "30,";
                }
            }
            #endregion

            #region [---Check  For ODC Report 11 (इतर आधिकारात नोंदीचा प्रकार निवडलेला नाही)---]
            DataSet other_right_code_zero = new DataSet();
            other_right_code_zero = this.funReturnDataSet(databasname, schemaname + ".form7 a left join " + schemaname + ".form7_orights b on a.ccode=b.ccode and a.pin=b.pin and a.pin1=b.pin1 and a.pin2=b.pin2 and a.pin3=b.pin3 and a.pin4=b.pin4 and a.pin5=b.pin5 and a.pin6=b.pin6 and a.pin7=b.pin7 and a.pin8=b.pin8", "b.mut_no,b.khata_no,b.tenant_name,b.numeric_pin,b.pin,b.pin1,b.pin2,b.pin3,b.pin4,b.pin5,b.pin6,b.pin7,b.pin8", " b.ccode='" + ccode + "' and  b.tenant_name<>''  and b.other_rights_code=0 and b.marked<>'Y' and  (b.pin,b.pin1,b.pin2,b.pin3,b.pin4,b.pin5,b.pin6,b.pin7,b.pin8) not  in (select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where  ccode  ='" + ccode + "' and  khata_no ='500001') ", "numeric_pin");
            if (other_right_code_zero.Tables.Count > 0)
            {
                if (other_right_code_zero.Tables[0].Rows.Count > 0)
                {
                    blocks_ewc += "31,";
                }
            }
            #endregion

            #region [---Check  For ODC Report 12 (फ़ेरफ़ार क्र.नसलेल्या इतर अधिकारांच्या नोंदी)---]
            DataSet f7or_mut_blank = new DataSet();
            f7or_mut_blank = this.funReturnDataSet(databasname, "select khata_no,numeric_pin,pin,pin,pin2,pin3,pin4,pin5,pin6,pin7,pin8,tenant_name from " + schemaname + ".form7_orights where mut_no='0' and marked<>'Y' and ccode='" + ccode + "' and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where ccode ='" + ccode + "'  and khata_no='500001') order by numeric_pin");
            if (f7or_mut_blank.Tables.Count > 0)
            {
                if (f7or_mut_blank.Tables[0].Rows.Count > 0)
                {
                    blocks_ewc += "32,";
                }
            }
            #endregion

            #region [---Check  For ODC Extra  Report 9 (गाव नमुना ७ वरील एकुण आकारणी व ७/१२ वरील खात्यांच्या एकुण आकारणीचा फ़रक.)---]
            //DataSet ds_AssessmentMismatch = new DataSet();
            //Removed this check on 09042018
            //ds_AssessmentMismatch = this.funReturnDataSet(databasname, schemaname + ".form7_area as  a ," + schemaname + ".form7_khata  b", "a.ccode,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  || (CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  || (CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  || (CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  || (CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  || (CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  || (CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  || (CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/') as survey, (case when  a.na_area_h<>0 then a.na_assessment else a.assessment  end )  as f7a_ass , sum(b.assessment) as f7k_ass , string_agg(distinct b.khata_no ,',') as khata_nos", " a.ccode  ='" + ccode + "'  and   a.ccode=b.ccode    and a.pin=b.pin and a.pin1=b.pin1 and a.pin2=b.pin2 and a.pin3=b.pin3 and a.pin4=b.pin4 and a.pin5=b.pin5 and a.pin6=b.pin6 and a.pin7=b.pin7 and a.pin8=b.pin8 and  b.marked<>'Y'  and  (a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8) not  in (select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + schemaname + ".form7_khata where  ccode  ='" + ccode + "' and  khata_no ='500001')   group  by  a.assessment ,a.ccode, survey ,a.na_area_h,a.na_assessment having    (case when  a.na_area_h<>0 then a.na_assessment else a.assessment  end ) <>   sum(b.assessment)", "");
            //if (ds_AssessmentMismatch.Tables.Count > 0)
            //{
            //    if (ds_AssessmentMismatch.Tables[0].Rows.Count > 0)
            //    {
            //        blocks_ewc += "33,";
            //    }
            //}
            #endregion

            #region [---Check  For ODC Extra  Report 11 (खातामास्टर मध्ये अतिरिक्त नावे  असलेल्या खात्यांची सर्व्हे क्रमांकनिहाय यादी.)---]
            DataSet ds_hdExtraNames = new DataSet();
            ds_hdExtraNames = this.funReturnDataSet(databasname, "select distinct  x.khata_no::int  as kht_no_order , x.ccode ,x.khata_no,x.hdnames, (((CHAR_LENGTH(x.hdnames) - CHAR_LENGTH(REPLACE(x.hdnames, ',', '')))  / CHAR_LENGTH(','))+1) as total_hdnames ,y.f7knames, (((CHAR_LENGTH(y.f7knames) - CHAR_LENGTH(REPLACE(y.f7knames, ',', '')))  / CHAR_LENGTH(','))+1) as total_f7knames, y.survey_numbers  from (select  ccode , khata_no, string_agg ( distinct fname||' '||mname||' '||lname||' '||topan_name,', ') as hdnames  from  " + schemaname + ".holder_detail where  (ccode ,khata_no) in    (select distinct  ccode ,khata_no from  " + schemaname + ".holder_detail where ccode ='" + ccode + "' and (ccode , khata_no,fname,mname,lname,topan_name) not  in ( select  ccode , khata_no,fname,mname,lname,topan_name from " + schemaname + ".form7_khata where ccode  ='" + ccode + "')  and khata_no  in ( select distinct  khata_no from " + schemaname + ".form7_khata where ccode  ='" + ccode + "')) group by  ccode , khata_no) as x,( select  ccode , khata_no, string_agg ( distinct fname||' '||mname||' '||lname||' '||topan_name,', ') as f7knames,  string_agg ( distinct rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ,',')as survey_numbers  from  " + schemaname + ".form7_khata where  (ccode ,khata_no) in    (select distinct  ccode ,khata_no from  " + schemaname + ".holder_detail where ccode ='" + ccode + "' and (ccode , khata_no,fname,mname,lname,topan_name) not  in ( select  ccode , khata_no,fname,mname,lname,topan_name from " + schemaname + ".form7_khata where ccode  ='" + ccode + "')  and khata_no  in ( select distinct  khata_no from " + schemaname + ".form7_khata where ccode  ='" + ccode + "')) group by  ccode , khata_no) as y where  x.ccode=y.ccode and  x.khata_no=y.khata_no order by kht_no_order");
            if (ds_hdExtraNames.Tables.Count > 0)
            {
                if (ds_hdExtraNames.Tables[0].Rows.Count > 0)
                {
                    blocks_ewc += "34,";
                }
            }
            #endregion

            #region [---Check  For ODC  Report 15 (निरंक अथवा '-' अथवा '0' अथवा 'TKN' असलेले खाते.)---]
            DataSet ds_Blank = new DataSet();
            ds_Blank = this.funReturnDataSet(databasname, schemaname + ".form7_khata", "" + pincase1 + ",khata_no, (fname ||' '||  mname ||' '||   lname ||' '||  topan_name) as fullname", "ccode ='" + ccode + "'  and   (khata_no  like '%-%' or  khata_no= '0' or khata_no='' or  khata_no=  ' ' or khata_no='-' or khata_no  like '%TKN%' or khata_no  like '% ' or khata_no  like ' %' or khata_no  like '0%' or khata_no  like '% %' or khata_no  like '%	%')", "pins");
            if (ds_Blank.Tables.Count > 0)
            {
                if (ds_Blank.Tables[0].Rows.Count > 0)
                {
                    blocks_ewc += "35,";
                }
            }
            #endregion

            #region [---Check  For ODC  Report 5-EXTRA (अहवाल 5- अतिरिक्त.)---]
            //DataSet ds_Extrarpt5 = new DataSet();
            ////ds_Extrarpt5 = this.funReturnDataSet(databasname, "select distinct ccode,khata_no::int,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,name from (select ccode,khata_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,string_agg( distinct fname||' '||mname||' '||lname||' '||topan_name,',' order by fname||' '||mname||' '||lname||' '||topan_name) as name from  " + schemaname + ".form7_khata where ccode='" + ccode + "'  and khata_no<>'500001'   group by ccode,khata_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) as tbl where  (ccode,khata_no,name) not in (select ccode,khata_no,string_agg(fname||' '||mname||' '||lname||' '||topan_name ,','order by fname||' '||mname||' '||lname||' '||topan_name)  from " + schemaname + ".holder_detail where ccode='" + ccode + "' and khata_no<>'500001' group by ccode,khata_no)  order by khata_no::int  ");
            //exlude khata no which is present in transaction
            //ds_Extrarpt5 = this.funReturnDataSet(databasname, "select  x.* from (select distinct ccode,khata_no::int,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,name from (select ccode,khata_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,string_agg( distinct fname||' '||mname||' '||lname||' '||topan_name,',' order by fname||' '||mname||' '||lname||' '||topan_name) as name from  " + schemaname + ".form7_khata where ccode='" + ccode + "'  and khata_no<>'500001'   group by ccode,khata_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) as tbl where  (ccode,khata_no,name) not in (select ccode,khata_no,string_agg(fname||' '||mname||' '||lname||' '||topan_name ,','order by fname||' '||mname||' '||lname||' '||topan_name)  from " + schemaname + ".holder_detail where ccode='" + ccode + "' and khata_no<>'500001' group by ccode,khata_no)  order by khata_no::int ) as x where x.khata_no::text not in  ( select distinct ( case when  a.buyer_khata_no='' then khata_no else  buyer_khata_no end ) as khata_no from   " + schemaname + ".mut_kharedi_buyer a  ," + schemaname + ".mut_kharedi b  where  a.ccode='" + ccode + "' and a.ccode =b.ccode and a.mut_no=b.mut_no   and b.or_code4 in (1,0)   union  select distinct  a.khata_no from   " + schemaname + ".mut_kharedi_buyer_khata a  ," + schemaname + ".mut_kharedi b  where  a.ccode='" + ccode + "' and a.ccode =b.ccode  and a.mut_no=b.mut_no   and b.or_code4 in (1,0)  union   select distinct  khata_no from " + schemaname + ".tblpartydetails a  left  join  " + schemaname + ".tblinputentry  b   on a.documentnumber=b.documentnumber and  a.docyear=b.docyear where b.censuscode='" + ccode + "' and   b.mutationno is  null and  a.partytype='P')");
            //if (ds_Extrarpt5.Tables.Count > 0)
            //{
            //    if (ds_Extrarpt5.Tables[0].Rows.Count > 0)
            //    {
            //        blocks_ewc += "36,";
            //    }
            //}
            #endregion

            if (blocks_ewc == string.Empty)
            {
                Out_value = "Yes";
            }
            else
            {
                Out_value = blocks_ewc;
                Out_value = Out_value.Remove(Out_value.Length - 1);
                //   Out_value = Out_value.Remove(Out_value.Length - 1);
            }
            return Out_value;
        }

    }
}
