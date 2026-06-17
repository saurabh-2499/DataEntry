using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Web.UI.WebControls;
using Npgsql;
using NpgsqlTypes;
namespace NIC.WebLMISLibrary
{
    public class clsmutationprocess
    {
        clsCommonFunc func = new clsCommonFunc();
        clscommonfunedit objclscommonfunedit = new clscommonfunedit();
        DataBaseHandler handler2 = new DataBaseHandler();

        //Non registered Kharedi 28 Dec 2013
        public int funmutregister_nonregistered(string dbname, string SchemaName, string ccode, int mutno, DateTime mutdate1, int mutType, string mutName, string loginid, string docno, DateTime docdate, string prices, string nrFlag)
        {
            int num4 = 0;
           
                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str3 = "mutregister";
                string str4 = "";
                string str5 = "";

                str4 = "ccode,mut_no,mut_date,mut_type,mut_name,talathi_id,ref_no1,ref_no2,ref_date2,amount,mut_status_code,table_name";
                str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + func.ConvertDateToMMddyyyyFormat(mutdate1.ToShortDateString()) + "','" + Convert.ToInt32(mutType) + "','" + Convert.ToString(mutName) + "','" + Convert.ToString(loginid) + "',";
                str5 += "" + Convert.ToString("''") + ",'" + Convert.ToString(docno) + "','" + func.ConvertDateToMMddyyyyFormat(docdate.ToShortDateString()) + "'," + Convert.ToDecimal(prices) + ",1,'" + nrFlag.Trim() + "'";

                DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                handler2.SetInParameter(command2, "@para_table_name", DbType.String, str3);
                handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                num4 = handler2.ExecuteNonQuery(command2);

                return num4;
           
            return num4;
        }

        public int funmutkharedi1(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable)
        {
            int num = 0;
           
                DbCommand command2;
                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";

                int i = 0;
                foreach (DataRow row in PinTable.Rows)
                {
                    //if (i == 0)
                    //{
                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code3,remark";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                    str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToInt32(0x35) + ",'Itar-M'";
                    str6 = "mut_kharedi";
                    command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                    num = handler2.ExecuteNonQuery(command2);
                    //}
                    //else
                    //{
                    //    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code3";
                    //    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                    //    str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToInt32(0x35) + "";
                    //    str6 = "mut_kharedi";
                    //    command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    //    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    //    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
                    //    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                    //    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                    //    num = handler2.ExecuteNonQuery(command2);
                    //}

                }
                return num;
            

            return num;

        }

        //public int funmutregister(string dbname, string SchemaName, string ccode, int mutno, DateTime  mutdate1, int mutType, string mutName, string loginid, string docno, DateTime  docdate, string prices)
        //{
        //    int num4 = 0;
        //    
        //    {
        //        DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
        //        string str3 = "mutregister";
        //        string str4 = "";
        //        string str5 = "";

        //        str4 = "ccode,mut_no,mut_date,mut_type,mut_name,talathi_id,ref_no1,ref_no2,ref_date2,amount,mut_status_code";
        //        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" +   func.ConvertDateToMMddyyyyFormat(mutdate1.ToShortDateString())  + "','" + Convert.ToInt32(mutType) + "','" + Convert.ToString(mutName) + "','" + Convert.ToString(loginid) + "',";
        //        str5 += "" + Convert.ToString("''") + ",'" + Convert.ToString(docno) + "','" +  func.ConvertDateToMMddyyyyFormat(docdate.ToShortDateString())  + "'," + Convert.ToDecimal(prices) + ",1";

        //        DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
        //        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
        //        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str3);
        //        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
        //        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
        //        num4 = handler2.ExecuteNonQuery(command2);

        //        return num4;
        //    }
        //    catch (Exception ex)
        //    { }
        //    return num4;
        //}

        //Function for transaction
        public int funmutregister(string dbname, string SchemaName, string ccode, int mutno, DateTime mutdate1, int mutType, string mutName, string loginid, string docno, DateTime docdate, string prices,ref DbCommand dbCommand)
        {
            int num4 = 0;
           
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str3 = "mutregister";
                string str4 = "";
                string str5 = "";

                str4 = "ccode,mut_no,mut_date,mut_type,mut_name,talathi_id,table_name,ref_no1,ref_no2,ref_date2,amount,mut_status_code,mutcheck";
                str5 = "'" + Convert.ToString(ccode) + "','" + Convert.ToInt32(mutno) + "','" + func.ConvertDateToMMddyyyyFormat(mutdate1.ToShortDateString()) + "','" + Convert.ToInt32(mutType) + "','" + Convert.ToString(mutName) + "','" + Convert.ToString(loginid) + "','Talathi',";
                str5 += "'" + Convert.ToString("''") + "','" + Convert.ToString(docno) + "','" + func.ConvertDateToMMddyyyyFormat(docdate.ToShortDateString()) + "','" + Convert.ToDecimal(prices) + "','1','N'";

                //DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
                dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                dbCommand.CommandType = CommandType.StoredProcedure;
                this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str3);
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                num4 = dbCommand.ExecuteNonQuery();
                dbCommand.Parameters.Clear();
                return num4;
           
            return num4;
        }




        public int funmutregister_verify(string dbname, string SchemaName, string ccode, int mutno, DateTime mutdate1, int mutType, string mutName, string loginid, string docno, DateTime docdate, string prices, ref DbCommand dbCommand)
        {
            int num4 = 0;
           
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str3 = "verify_mutregister";
                string str4 = "";
                string str5 = "";

                str4 = "ccode,mut_no,mut_date,mut_type,mut_name,talathi_id,table_name,ref_no1,ref_no2,ref_date2,amount,mut_status_code,mutcheck";
                str5 = "'" + Convert.ToString(ccode) + "','" + Convert.ToInt32(mutno) + "','" + func.ConvertDateToMMddyyyyFormat(mutdate1.ToShortDateString()) + "','" + Convert.ToInt32(mutType) + "','" + Convert.ToString(mutName) + "','" + Convert.ToString(loginid) + "','Talathi',";
                str5 += "'" + Convert.ToString("''") + "','" + Convert.ToString(docno) + "','" + func.ConvertDateToMMddyyyyFormat(docdate.ToShortDateString()) + "','" + Convert.ToDecimal(prices) + "','1','N'";

                //DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
                dbCommand.CommandText = SchemaName + ".sptblmutregister_all";
                dbCommand.CommandType = CommandType.StoredProcedure;
                this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str3);
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                
                num4 = dbCommand.ExecuteNonQuery();
                dbCommand.Parameters.Clear();
                return num4;
          
            return num4;
        }

        public int funmutregister_linkage(string dbname, string SchemaName, string ccode, int mutno, DateTime mutdate1, int mutType, string mutName, string loginid, string docno, DateTime docdate, string prices,ref DbCommand dbCommand)
        {
            int num4 = 0;
           
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str3 = "mutregister";
                string str4 = "";
                string str5 = "";

                str4 = "ccode,mut_no,mut_date,mut_type,mut_name,talathi_id,table_name,ref_no1,ref_no2,ref_date2,amount,mut_status_code,mutcheck";
                str5 = "'" + Convert.ToString(ccode) + "','" + Convert.ToInt32(mutno) + "','" + func.ConvertDateToMMddyyyyFormat(mutdate1.ToShortDateString()) + "','" + Convert.ToInt32(mutType) + "','" + Convert.ToString(mutName) + "','" + Convert.ToString(loginid) + "','SRO',";
                str5 += "'" + Convert.ToString("''") + "','" + Convert.ToString(docno) + "','" + func.ConvertDateToMMddyyyyFormat(docdate.ToShortDateString()) + "','" + Convert.ToDecimal(prices) + "','1','N'";

                //DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
                dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                dbCommand.CommandType = CommandType.StoredProcedure;
                this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str3);
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                num4 = dbCommand.ExecuteNonQuery();
                dbCommand.Parameters.Clear();

                return num4;
           
            return num4;
        }

        public int funmutregister(string dbname, string SchemaName, string ccode, int mutno, string mutdate1, int mutType, string mutName, string loginid, string docno, string docdate, string prices, DbCommand command2, DbTransaction transaction)
        {
            int num4 = 0;
           
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str3 = "mutregister";
                string str4 = "";
                string str5 = "";

                str4 = "ccode,mut_no,mut_date,mut_type,mut_name,talathi_id,ref_no1,ref_no2,ref_date2,amount,mut_status_code";
                str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + func.ConvertDateToMMddyyyyFormat(mutdate1) + "','" + Convert.ToInt32(mutType) + "','" + Convert.ToString(mutName) + "','" + Convert.ToString(loginid) + "',";
                str5 += "" + Convert.ToString("''") + ",'" + Convert.ToString(docno) + "','" + func.ConvertDateToMMddyyyyFormat(Convert.ToString(docdate)) + "'," + Convert.ToDecimal(prices) + ",1";

                command2.CommandType = CommandType.StoredProcedure;
                command2.CommandText = SchemaName + ".sptblmutregister_all";
                //   DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                handler2.SetInParameter(command2, "@para_table_name", DbType.String, str3);
                handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                command2.ExecuteNonQuery();
                // num4 = handler2.ExecuteNonQuery(command2);

                return num4;
           
            return num4;
        }

        public int funmutkharedi(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable,ref DbCommand dbCommand)
        {
            int num = 0;
           
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";
                string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
                int i = 0;
                foreach (DataRow row in PinTable.Rows)
                {
                    //if (i == 0)
                    //{
                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code3,remark,other_rights";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                    str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToInt32(0x35) + ",'Itar-M','" + Convert.ToString(row["other_rights"]) + "'";
                    str6 = "mut_kharedi";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, login_id);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                    
                }
                foreach (DataRow drow in PinTable.Rows)
                {
                    string col_name = "", col_value = "";
                    char[] charray = ((string)drow["pin"]).Trim().ToCharArray();
                    string strSurvey = "";
                    foreach (char ch in charray)
                    {
                        if (ch >= '0' && ch <= '9')
                            strSurvey = strSurvey + ch;
                        else
                            break;
                    }
                    int numeric_pin = 0;
                    if (strSurvey != "")
                        numeric_pin = Convert.ToInt32(strSurvey);
                    col_name = "ccode ,mutationno,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,pending_mut_flag";
                    col_value = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'";
                    col_value += numeric_pin + "','" + Convert.ToString(drow["pin"]) + "','" + Convert.ToString(drow["pin1"]) + "','" + Convert.ToString(drow["pin2"]) + "','" + Convert.ToString(drow["pin3"]) + "','" + Convert.ToString(drow["pin4"]) + "','" + Convert.ToString(drow["pin5"]) + "','" + Convert.ToString(drow["pin6"]) + "','" + Convert.ToString(drow["pin7"]) + "','" + Convert.ToString(drow["pin8"]) + "','T'";
                    string table_name2 = "tblrordetails";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, table_name2);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, col_name);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, col_value);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, login_id);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
                return num;
           

            return num;

        }




        public int funmutkharedi_verify(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, ref DbCommand dbCommand)
        {
            int num = 0;
            
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";
                string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
                int i = 0;
                foreach (DataRow row in PinTable.Rows)
                {
                    //if (i == 0)
                    //{
                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code3,remark,other_rights";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                    str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToInt32(0x35) + ",'Itar-M','" + Convert.ToString(row["other_rights"]) + "'";
                    str6 = "verify_mut_kharedi";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();

                }
               
                return num;
           

            return num;

        }

        public int funmutkharediLinkage(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable,string loginid,ref DbCommand dbCommand)
        {
            int num = 0;
           
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";
                //string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
                int i = 0;
                foreach (DataRow row in PinTable.Rows)
                {
                    //if (i == 0)
                    //{
                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code3,remark,other_rights";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                    str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToInt32(0x35) + ",'Itar-M','" + Convert.ToString(row["other_rights"]) + "'";
                    str6 = "mut_kharedi";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();

                }
                foreach (DataRow drow in PinTable.Rows)
                {
                    string col_name = "", col_value = "";
                    char[] charray = ((string)drow["pin"]).Trim().ToCharArray();
                    string strSurvey = "";
                    foreach (char ch in charray)
                    {
                        if (ch >= '0' && ch <= '9')
                            strSurvey = strSurvey + ch;
                        else
                            break;
                    }
                    int numeric_pin = 0;
                    if (strSurvey != "")
                        numeric_pin = Convert.ToInt32(strSurvey);
                    col_name = "ccode ,mutationno,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,pending_mut_flag";
                    col_value = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'";
                    col_value += numeric_pin + "','" + Convert.ToString(drow["pin"]) + "','" + Convert.ToString(drow["pin1"]) + "','" + Convert.ToString(drow["pin2"]) + "','" + Convert.ToString(drow["pin3"]) + "','" + Convert.ToString(drow["pin4"]) + "','" + Convert.ToString(drow["pin5"]) + "','" + Convert.ToString(drow["pin6"]) + "','" + Convert.ToString(drow["pin7"]) + "','" + Convert.ToString(drow["pin8"]) + "','T'";
                    string table_name2 = "tblrordetails";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, table_name2);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, col_name);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, col_value);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
                return num;
           

            return num;

        }

        //Function for transaction
        public int funmutkharedi(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DbCommand command2, DbTransaction transaction)
        {
            int num = 0;
           
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";

                int i = 0;
                foreach (DataRow row in PinTable.Rows)
                {
                    if (i == 0)
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code3,remark";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToInt32(0x35) + ",'Itar-M'";
                        str6 = "mut_kharedi";
                        //command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        command2.CommandType = CommandType.StoredProcedure;
                        command2.CommandText = SchemaName + ".sptblmutregister_all";
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                        //num = handler2.ExecuteNonQuery(command2);
                        command2.ExecuteNonQuery();
                    }
                    else
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code3";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToInt32(0x35) + "";
                        str6 = "mut_kharedi";
                        // command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        command2.CommandType = CommandType.StoredProcedure;
                        command2.CommandText = SchemaName + ".sptblmutregister_all";
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                        // num = handler2.ExecuteNonQuery(command2);
                        command2.ExecuteNonQuery();
                    }

                }
                return num;
           

            return num;

        }

        public int funbuyerSeller(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable Dtseller, DataTable dtbuyer)
        {
            int result = 0;
           
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                DbCommand command2;
                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                foreach (DataRow row in PinTable.Rows)
                {
                    int partsellreysrno = 1;
                    foreach (DataRow row2 in Dtseller.Rows)
                    {
                        string fname1 = Convert.ToString(row2["PartyFName"]).Trim();
                        string mname1 = Convert.ToString(row2["PartyMName"]).Trim();
                        string lname1 = Convert.ToString(row2["PartyLName"]).Trim();
                        decimal seller_area_culti = Convert.ToDecimal(row2["nave_area"]);
                        decimal vikri_area = Convert.ToDecimal(row2["vikri_area"]);
                        decimal rem_area = seller_area_culti - vikri_area;



                        str4 = "ccode,mut_no,fname,mname,lname,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,seller_area_h,seller_usrno,tenure_code,seller_area_culti,seller_anne,seller_khata_no,usrno";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + fname1.Trim() + "','" + mname1.Trim() + "','" + lname1.Trim() + "','" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]);
                        str5 += "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + vikri_area + ",53,0," + seller_area_culti + "," + rem_area + "," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToInt32(partsellreysrno) + "";

                        // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                        string str7 = "mut_kharedi_seller";
                        command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str7);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                        num2 = handler2.ExecuteNonQuery(command2);
                        partsellreysrno++;
                    }
                }

               
                foreach (DataRow row in PinTable.Rows)
                {
                    int partysrno = 1;
                    foreach (DataRow row2 in dtbuyer.Rows)
                    {
                    
                        string TOPANANEM = Convert.ToString(row2[2]);
                        decimal nave_area = Convert.ToDecimal(row2["nave_area"]);
                        //topan_name
                        string str3 = "ccode,mut_no,fname,mname,lname,buyer_doc_type1,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,buyer_khata_no,usrno,buyer_area_culti";
                        str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row2["PartyFName"]).Trim() + "','" + Convert.ToString(row2["PartyMName"]).Trim() + "','" + Convert.ToString(row2["PartyLName"]).Trim() + "',";
                        str4 += Convert.ToInt32(0x35) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row2["khata_no"]) + "'," + Convert.ToInt32(partysrno) + ",'" + nave_area + "'";
                        str5 = "mut_kharedi_buyer";
                        command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str5);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str3);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str4);
                        num = handler2.ExecuteNonQuery(command2);
                        partysrno++;
                    }
                }

                /************************* Pending mutation (Red ink mark)*****************************/
                foreach (DataRow drpin in PinTable.Rows)
                {
                    foreach (DataRow dr in Dtseller.Rows)
                    {
                       string col_name = "ccode,mutationno,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,pending_mut_flag";
                       string col_value = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno);
                          col_value += ",'" + Convert.ToString(drpin["pin"]) + "','" + Convert.ToString(drpin["pin"]) + "','" + Convert.ToString(drpin["pin1"]) + "','" + Convert.ToString(drpin["pin2"]) + "','" + Convert.ToString(drpin["pin3"]) + "','" + Convert.ToString(drpin["pin4"]) + "','" + Convert.ToString(drpin["pin5"]) + "','" + Convert.ToString(drpin["pin6"]) + "','" + Convert.ToString(drpin["pin7"]) + "','" + Convert.ToString(drpin["pin8"]) + "','T'";
                        string table_name3 = "tblrordetails";

                        command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, table_name3);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, col_name);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, col_value);
                        handler2.ExecuteNonQuery(command2);
                    }
                }

                if (num != 0 && num2 != 0)
                {
                    result = 1;
                    return 1;
                }
                else
                {
                    result = 0;
                    return 0;
                }
           
            return result;

        }


        public int funbuyerSeller(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable Dtseller, DataTable dtbuyer, DbCommand command2, DbTransaction transaction)
        {
            int result = 0;
           
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                // DbCommand command2;
                // DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                foreach (DataRow row in PinTable.Rows)
                {
                    foreach (DataRow row2 in Dtseller.Rows)
                    {
                        string fname1 = Convert.ToString(row2["firstname"]).Trim();
                        string mname1 = Convert.ToString(row2["middlename"]).Trim();
                        string lname1 = Convert.ToString(row2["surname"]).Trim();
                        decimal seller_area_culti = Convert.ToDecimal(row2["nave_area"]);
                        decimal vikri_area = Convert.ToDecimal(row2["vikri_area"]);
                        decimal rem_area = seller_area_culti - vikri_area;



                        str4 = "ccode,mut_no,fname,mname,lname,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,seller_area_h,seller_usrno,tenure_code,seller_area_culti,seller_anne,seller_khata_no,usrno";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + fname1.Trim() + "','" + mname1.Trim() + "','" + lname1.Trim() + "','" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]);
                        str5 += "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + vikri_area + ",53,0," + seller_area_culti + "," + rem_area + "," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToInt32(row2["partysrno"]) + "";

                        // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                        string str7 = "mut_kharedi_seller";
                        // command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        command2.CommandType = CommandType.StoredProcedure;
                        command2.CommandText = SchemaName + ".sptblmutregister_all";
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str7);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                        // num2 = handler2.ExecuteNonQuery(command2);
                        command2.ExecuteNonQuery();
                    }
                }


                foreach (DataRow row in PinTable.Rows)
                {
                    foreach (DataRow row2 in dtbuyer.Rows)
                    {
                        string TOPANANEM = Convert.ToString(row2[2]);
                        decimal nave_area = Convert.ToDecimal(row2["nave_area"]);
                        //topan_name
                        string str3 = "ccode,mut_no,fname,mname,lname,buyer_doc_type1,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,buyer_khata_no,usrno,buyer_area_culti";
                        str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row2["firstname"]).Trim() + "','" + Convert.ToString(row2["middlename"]).Trim() + "','" + Convert.ToString(row2["surname"]).Trim() + "',";
                        str4 += Convert.ToInt32(0x35) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row2["khata_no"]) + "'," + Convert.ToInt32(row2["partysrno"]) + ",'" + nave_area + "'";
                        str5 = "mut_kharedi_buyer";
                        // command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        command2.CommandType = CommandType.StoredProcedure;
                        command2.CommandText = SchemaName + ".sptblmutregister_all";
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str5);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str3);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str4);
                        num = handler2.ExecuteNonQuery(command2);
                    }
                }
                if (num != 0 && num2 != 0)
                {
                    result = 1;
                    return 1;
                }
                else
                {
                    result = 0;
                    return 0;
                }
           
            return result;

        }



        public int funbuyerSellerMultiple(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable Dtseller, DataTable dtbuyer)
        {
            int result = 0;
            
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                DbCommand command2;

                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");

                //foreach (DataRow row in PinTable.Rows)
                //{
                //    foreach (DataRow row2 in Dtseller.Rows)
                //    {
                //        string fname1 = Convert.ToString(row2["firstname"]).Trim();
                //        string mname1 = Convert.ToString(row2["middlename"]).Trim();
                //        string lname1 = Convert.ToString(row2["surname"]).Trim();
                //        decimal seller_area_culti = Convert.ToDecimal(row2["nave_area"]);
                //        decimal vikri_area = Convert.ToDecimal(row2["vikri_area"]);
                //        decimal rem_area = seller_area_culti - vikri_area;



                //        str4 = "ccode,mut_no,fname,mname,lname,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,seller_area_h,seller_usrno,tenure_code,seller_area_culti,seller_anne,seller_khata_no,usrno";
                //        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + fname1.Trim() + "','" + mname1.Trim() + "','" + lname1.Trim() + "','" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]);
                //        str5 += "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + vikri_area + ",53,0," + seller_area_culti + "," + rem_area + "," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToInt32(row2["partysrno"]) + "";

                //        // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                //        string str7 = "mut_kharedi_seller";
                //        command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                //        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                //        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str7);
                //        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                //        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                //        num2 = handler2.ExecuteNonQuery(command2);
                //    }
                //}



                foreach (DataRow row2 in Dtseller.Rows)
                {
                    string fname1 = Convert.ToString(row2["firstname"]).Trim();
                    string mname1 = Convert.ToString(row2["middlename"]).Trim();
                    string lname1 = Convert.ToString(row2["surname"]).Trim();
                    decimal seller_area_culti = Convert.ToDecimal(row2["nave_area"]);
                    decimal vikri_area = Convert.ToDecimal(row2["vikri_area"]);
                    decimal rem_area = seller_area_culti - vikri_area;
                    //string pin = row2["pins"].ToString().Split('/')[0];
                    //string pin1 = row2["pins"].ToString().Split('/')[1];
                    //string pin2 = row2["pins"].ToString().Split('/')[2];
                    //string pin3 = row2["pins"].ToString().Split('/')[3];
                    //string pin4 = row2["pins"].ToString().Split('/')[4];
                    //string pin5 = row2["pins"].ToString().Split('/')[5];
                    //string pin6 = row2["pins"].ToString().Split('/')[6];
                    //string pin7 = row2["pins"].ToString().Split('/')[7];
                    //string pin8 = row2["pins"].ToString().Split('/')[8];
                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];

                    }
                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();



                    str4 = "ccode,mut_no,fname,mname,lname,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,seller_area_h,seller_usrno,tenure_code,seller_area_culti,seller_anne,seller_khata_no,usrno";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + fname1.Trim() + "','" + mname1.Trim() + "','" + lname1.Trim() + "','" + pin + "','" + pin1 + "','" + pin2;
                    str5 += "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "'," + vikri_area + ",53,0," + seller_area_culti + "," + rem_area + "," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToInt32(row2["partysrno"]) + "";

                    // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                    string str7 = "mut_kharedi_seller";
                    command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str7);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                    num2 = handler2.ExecuteNonQuery(command2);
                }








                foreach (DataRow row2 in dtbuyer.Rows)
                {
                    string TOPANANEM = Convert.ToString(row2[2]);
                    decimal nave_area = Convert.ToDecimal(row2["nave_area"]);
                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];

                    }

                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();

                    //topan_name
                    string str3 = "ccode,mut_no,fname,mname,lname,buyer_doc_type1,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,buyer_khata_no,usrno,buyer_area_culti";
                    str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row2["firstname"]).Trim() + "','" + Convert.ToString(row2["middlename"]).Trim() + "','" + Convert.ToString(row2["surname"]).Trim() + "',";
                    str4 += Convert.ToInt32(0x35) + ",'" + pin + "','" + pin1 + "','" + pin2 + "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "','" + Convert.ToString(row2["khata_no"]) + "'," + Convert.ToInt32(row2["partysrno"]) + ",'" + nave_area + "'";
                    str5 = "mut_kharedi_buyer";
                    command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str5);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str3);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str4);
                    num = handler2.ExecuteNonQuery(command2);
                }

                if (num != 0 && num2 != 0)
                {
                    result = 1;
                    return 1;
                }
                else
                {
                    result = 0;
                    return 0;
                }



           
            return result;


        }


        public int funbuyerSellerMultiple(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable Dtseller, DataTable dtbuyer, DbCommand command2, DbTransaction transaction)
        {
            int result = 0;
           
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                // DbCommand command2;

                //  DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");

                //foreach (DataRow row in PinTable.Rows)
                //{
                //    foreach (DataRow row2 in Dtseller.Rows)
                //    {
                //        string fname1 = Convert.ToString(row2["firstname"]).Trim();
                //        string mname1 = Convert.ToString(row2["middlename"]).Trim();
                //        string lname1 = Convert.ToString(row2["surname"]).Trim();
                //        decimal seller_area_culti = Convert.ToDecimal(row2["nave_area"]);
                //        decimal vikri_area = Convert.ToDecimal(row2["vikri_area"]);
                //        decimal rem_area = seller_area_culti - vikri_area;



                //        str4 = "ccode,mut_no,fname,mname,lname,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,seller_area_h,seller_usrno,tenure_code,seller_area_culti,seller_anne,seller_khata_no,usrno";
                //        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + fname1.Trim() + "','" + mname1.Trim() + "','" + lname1.Trim() + "','" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]);
                //        str5 += "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + vikri_area + ",53,0," + seller_area_culti + "," + rem_area + "," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToInt32(row2["partysrno"]) + "";

                //        // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                //        string str7 = "mut_kharedi_seller";
                //        command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                //        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                //        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str7);
                //        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                //        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                //        num2 = handler2.ExecuteNonQuery(command2);
                //    }
                //}



                foreach (DataRow row2 in Dtseller.Rows)
                {
                    string fname1 = Convert.ToString(row2["firstname"]).Trim();
                    string mname1 = Convert.ToString(row2["middlename"]).Trim();
                    string lname1 = Convert.ToString(row2["surname"]).Trim();
                    decimal seller_area_culti = Convert.ToDecimal(row2["nave_area"]);
                    decimal vikri_area = Convert.ToDecimal(row2["vikri_area"]);
                    decimal rem_area = seller_area_culti - vikri_area;
                    //string pin = row2["pins"].ToString().Split('/')[0];
                    //string pin1 = row2["pins"].ToString().Split('/')[1];
                    //string pin2 = row2["pins"].ToString().Split('/')[2];
                    //string pin3 = row2["pins"].ToString().Split('/')[3];
                    //string pin4 = row2["pins"].ToString().Split('/')[4];
                    //string pin5 = row2["pins"].ToString().Split('/')[5];
                    //string pin6 = row2["pins"].ToString().Split('/')[6];
                    //string pin7 = row2["pins"].ToString().Split('/')[7];
                    //string pin8 = row2["pins"].ToString().Split('/')[8];
                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];

                    }
                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();



                    str4 = "ccode,mut_no,fname,mname,lname,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,seller_area_h,seller_usrno,tenure_code,seller_area_culti,seller_anne,seller_khata_no,usrno";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + fname1.Trim() + "','" + mname1.Trim() + "','" + lname1.Trim() + "','" + pin + "','" + pin1 + "','" + pin2;
                    str5 += "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "'," + vikri_area + ",53,0," + seller_area_culti + "," + rem_area + "," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToInt32(row2["partysrno"]) + "";

                    // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                    string str7 = "mut_kharedi_seller";
                    // command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.CommandText = SchemaName + ".sptblmutregister_all";
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str7);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                    //  num2 = handler2.ExecuteNonQuery(command2);
                    command2.ExecuteNonQuery();
                }








                foreach (DataRow row2 in dtbuyer.Rows)
                {
                    string TOPANANEM = Convert.ToString(row2[2]);
                    decimal nave_area = Convert.ToDecimal(row2["nave_area"]);
                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];

                    }

                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();

                    //topan_name
                    string str3 = "ccode,mut_no,fname,mname,lname,buyer_doc_type1,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,buyer_khata_no,usrno,buyer_area_culti";
                    str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row2["firstname"]).Trim() + "','" + Convert.ToString(row2["middlename"]).Trim() + "','" + Convert.ToString(row2["surname"]).Trim() + "',";
                    str4 += Convert.ToInt32(0x35) + ",'" + pin + "','" + pin1 + "','" + pin2 + "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "','" + Convert.ToString(row2["khata_no"]) + "'," + Convert.ToInt32(row2["partysrno"]) + ",'" + nave_area + "'";
                    str5 = "mut_kharedi_buyer";
                    // command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.CommandText = SchemaName + ".sptblmutregister_all";
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str5);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str3);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str4);
                    //num = handler2.ExecuteNonQuery(command2);
                    command2.ExecuteNonQuery();

                }

                if (num != 0 && num2 != 0)
                {
                    result = 1;
                    return 1;
                }
                else
                {
                    result = 0;
                    return 0;
                }



           
            return result;


        }

        

        public int funmutDeal(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, string deal_text, DbCommand command2, DbTransaction transaction)
        {
            int num = 0;
           
                // DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                foreach (DataRow row in PinTable.Rows)
                {


                    string str3 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,deal_text";
                    //   object obj2 = string.Concat(new object[] { "'", Convert.ToString(ccode), "',", Convert.ToInt32(mutno), "" });
                    //           string str4 = string.Concat(new object[] { 
                    // obj2, Convert.ToInt32(0x35), ",'", Convert.ToString(row["pin"]), "','", Convert.ToString(row["pin1"]), "','", Convert.ToString(row["pin2"]), "','", Convert.ToString(row["pin3"]), "','", Convert.ToString(row["pin4"]), "','", Convert.ToString(row["pin5"]), "','", Convert.ToString(row["pin6"]), 
                    // "','", Convert.ToString(row["pin7"]), "','", Convert.ToString(row["pin8"]), "','", deal_text, "'"
                    //});
                    string str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "',";
                    str4 += "'" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + deal_text + "'";

                    string str5 = "mut_deal";
                    // DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.CommandText = SchemaName + ".sptblmutregister_all";
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str5);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str3);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str4);
                    num = handler2.ExecuteNonQuery(command2);
                }
                return num;
           
            return num;

        }

        

        public int funOtherrights(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, string remarke, DbCommand command2, DbTransaction transaction)
        {
            int num = 0;
          
                // DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                foreach (DataRow row in PinTable.Rows)
                {

                    string str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,remark";
                    string str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]);
                    str5 += "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(remarke) + "'";
                    string str6 = "mut_other_rights";
                    //  DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.CommandText = SchemaName + ".sptblmutregister_all";
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                    //num = handler2.ExecuteNonQuery(command2);
                    command2.ExecuteNonQuery();
                }
                return num;

           
            return num;
        }

        public DataSet funReturnDataSet(string DBName, string TableName, string ColValue, string Condition, string Orderby)
        {
            DataBaseHandler handler = new DataBaseHandler(DBName, "Tahsil Connection String");
            DataSet set = new DataSet();
            string cmdText = "select  " + ColValue + " from " + TableName;
            if (Condition != "")
            {
                cmdText = cmdText + " WHERE " + Condition;
            }
            if (Orderby != "")
            {
                cmdText = cmdText + " Order by " + Orderby;
            }
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            return handler.FillDataset(command);
        }

        #region [---Kharedi New Functions---]

        public int funmutkharedisellerkhata(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable)
        {
            int num = 0;
            
                //DbCommand command2;
                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";

                int i = 0;
                DbCommand command2;
                foreach (DataRow row in PinTable.Rows)
                {
                    if (i == 0)
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,nave_area,nave_assessment";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["khata_no"]) + "','" + Convert.ToString(row["nave_area"]) + "','" + Convert.ToString(row["nave_assessment"]) + "'";
                        str6 = "mut_kharedi_seller_khata";
                        command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        //command2.CommandType = CommandType.StoredProcedure;
                        //command2.CommandText = SchemaName + ".sptblmutregister_all";
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                        num = handler2.ExecuteNonQuery(command2);
                        //command2.ExecuteNonQuery();
                    }
                    else
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code3";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToInt32(0x35) + "";
                        str6 = "mut_kharedi";
                        command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                        //command2.CommandType = CommandType.StoredProcedure;
                        //command2.CommandText = SchemaName + ".sptblmutregister_all";
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                        num = handler2.ExecuteNonQuery(command2);
                        //command2.ExecuteNonQuery();
                    }

                }
                return num;
           

            return num;

        }

        public int funmutkharedibuyerkhata(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable)
        {
            int num = 0;

                //DbCommand command2;
                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";

                int i = 0;
                DbCommand command2;
                foreach (DataRow row in PinTable.Rows)
                {

                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,seller_khata_no,buyer_assessment";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                    str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["TKN"]) + Convert.ToString(row["buyer_khata_no"]) + "','" + Convert.ToString(row["purchase_area"]) + "','" + Convert.ToString(row["seller_khata_no"]) + "','" + Convert.ToString(row["buyer_assessment"]) + "'";
                    str6 = "mut_kharedi_buyer_khata";
                    command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    //command2.CommandType = CommandType.StoredProcedure;
                    //command2.CommandText = SchemaName + ".sptblmutregister_all";
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                    num = handler2.ExecuteNonQuery(command2);
                    //command2.ExecuteNonQuery();

                }
                return num;
           

            return num;

        }

        //public int funmutkharedisellerkhataName(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable)
        //{
        //    int num = 0;
        //    
        //    {
        //        //DbCommand command2;
        //        DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
        //        string str6 = " ";
        //        string str4 = "";
        //        string str5 = "";
        //        string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
        //        int i = 0;
        //        DbCommand command2;
        //        foreach (DataRow row in PinTable.Rows)
        //        {
        //            if (i == 0)
        //            {
        //                str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,nave_area,nave_assessment,fname,mname,lname,topan_name,special_case,nave_pot";
        //                str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
        //                str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["khata_no"]) + "','" + Convert.ToString(row["nave_area"]) + "','" + Convert.ToString(row["nave_assessment"]) + "','" + Convert.ToString(row["fname"]) + "','" + Convert.ToString(row["mname"]) + "','" + Convert.ToString(row["lname"]) + "','" + Convert.ToString(row["topan_name"]) + "','" + Convert.ToString(row["special_case"]) + "'," + Convert.ToString(row["nave_potkharaba"]) + "";
        //                str6 = "mut_kharedi_seller_khata";
        //                command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
        //                //command2.CommandType = CommandType.StoredProcedure;
        //                //command2.CommandText = SchemaName + ".sptblmutregister_all";
        //                handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
        //                handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
        //                handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
        //                handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
        //                handler2.SetInParameter(command2, "@para_login_id", DbType.String, login_id);
        //                handler2.SetInParameter(command2, "@para_app_name", DbType.String, "reEdit");
        //                num = handler2.ExecuteNonQuery(command2);
        //                //command2.ExecuteNonQuery();
        //            }
        //        }
        //        return num;
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return num;

        //}

        public int funmutkharedisellerkhataName(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable,ref DbCommand dbCommand)
        {
            int num = 0;
            
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";
                string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
                int i = 0;
                //DbCommand command2;
                foreach (DataRow row in PinTable.Rows)
                {
                    if (i == 0)
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,nave_area,nave_assessment,fname,mname,lname,topan_name,special_case,nave_pot,temp_khata_no";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["khata_no"]) + "','" + Convert.ToString(row["nave_area"]) + "','" + Convert.ToString(row["nave_assessment"]) + "','" + Convert.ToString(row["fname1"]) + "','" + Convert.ToString(row["mname"]) + "','" + Convert.ToString(row["lname"]) + "','" + Convert.ToString(row["topan_name"]) + "','" + Convert.ToString(row["special_case"]) + "'," + Convert.ToString(row["nave_potkharaba"]) + ",'" + Convert.ToString(row["temp_khata_no"]) + "'";
                        str6 = "mut_kharedi_seller_khata";
                        dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                        dbCommand.CommandType = CommandType.StoredProcedure;

                        this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                        this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                        this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                        this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                        this.SetInParameter(dbCommand, "@para_login_id", DbType.String, login_id);
                        this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                        num = dbCommand.ExecuteNonQuery();
                        dbCommand.Parameters.Clear();
                        //command2.ExecuteNonQuery();
                    }
                }
                return num;
           

            return num;

        }

        public int funmutkharedisellerkhataNameREG(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, ref DbCommand dbCommand)
        {
            int num = 0;

            //DbCommand command2;
            //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
            string str6 = " ";
            string str4 = "";
            string str5 = "";
            string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
            int i = 0;
            //DbCommand command2;
            foreach (DataRow row in PinTable.Rows)
            {
                if (i == 0)
                {
                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,nave_area,nave_assessment,fname,mname,lname,topan_name,special_case,nave_pot,temp_khata_no";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                    str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["khata_no"]) + "','" + Convert.ToString(row["nave_area"]) + "','" + Convert.ToString(row["nave_assessment"]) + "','" + Convert.ToString(row["fname1"]) + "','" + Convert.ToString(row["mname"]) + "','" + Convert.ToString(row["lname"]) + "','" + Convert.ToString(row["topan_name"]) + "','" + Convert.ToString(row["special_case"]) + "'," + Convert.ToString(row["nave_pot"]) + ",'" + Convert.ToString(row["temp_khata_no"]) + "'";
                    str6 = "mut_kharedi_seller_khata";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;

                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, login_id);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                    //command2.ExecuteNonQuery();
                }
            }
            return num;


            return num;

        }

        public int funmutkharedisellerkhataName_verify(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, ref DbCommand dbCommand)
        {
            int num = 0;
            
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";
                string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
                int i = 0;
                //DbCommand command2;
                foreach (DataRow row in PinTable.Rows)
                {
                    if (i == 0)
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,nave_area,nave_assessment,fname,mname,lname,topan_name,special_case,nave_pot,temp_khata_no";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["khata_no"]) + "','" + Convert.ToString(row["nave_area"]) + "','" + Convert.ToString(row["nave_assessment"]) + "','" + Convert.ToString(row["fname1"]) + "','" + Convert.ToString(row["mname"]) + "','" + Convert.ToString(row["lname"]) + "','" + Convert.ToString(row["topan_name"]) + "','" + Convert.ToString(row["special_case"]) + "'," + Convert.ToString(row["nave_potkharaba"]) + ",'" + Convert.ToString(row["temp_khata_no"]) + "'";
                        str6 = "verify_mut_kharedi_seller_khata";
                        dbCommand.CommandText = SchemaName + ".sptblmutregister_all";
                        dbCommand.CommandType = CommandType.StoredProcedure;

                        this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                        this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                        this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                        this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                        
                        num = dbCommand.ExecuteNonQuery();
                        dbCommand.Parameters.Clear();
                        //command2.ExecuteNonQuery();
                    }
                }
                return num;
           

            return num;

        }

        public int funmutkharedisellerkhataName_verifyREG(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, ref DbCommand dbCommand)
        {
            int num = 0;

            //DbCommand command2;
            //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
            string str6 = " ";
            string str4 = "";
            string str5 = "";
            string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
            int i = 0;
            //DbCommand command2;
            foreach (DataRow row in PinTable.Rows)
            {
                if (i == 0)
                {
                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,nave_area,nave_assessment,fname,mname,lname,topan_name,special_case,nave_pot,temp_khata_no";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                    str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["khata_no"]) + "','" + Convert.ToString(row["nave_area"]) + "','" + Convert.ToString(row["nave_assessment"]) + "','" + Convert.ToString(row["fname1"]) + "','" + Convert.ToString(row["mname"]) + "','" + Convert.ToString(row["lname"]) + "','" + Convert.ToString(row["topan_name"]) + "','" + Convert.ToString(row["special_case"]) + "'," + Convert.ToString(row["nave_pot"]) + ",'" + Convert.ToString(row["temp_khata_no"]) + "'";
                    str6 = "verify_mut_kharedi_seller_khata";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all";
                    dbCommand.CommandType = CommandType.StoredProcedure;

                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);

                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                    //command2.ExecuteNonQuery();
                }
            }
            return num;


            return num;

        }

        //public int funmutkharedibuyerkhataName(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable)
        //{
        //    int num = 0;
        //    
        //    {
        //        //DbCommand command2;
        //        DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
        //        string str6 = " ";
        //        string str4 = "";
        //        string str5 = "";
        //        string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
        //        int i = 0;
        //        DbCommand command2;
        //        foreach (DataRow row in PinTable.Rows)
        //        {
        //            if (Convert.ToString(row["special_case"]) == "Yes")
        //            {
        //                str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,seller_khata_no,buyer_assessment,fname,mname,lname,topan_name,seller_fname,seller_mname,seller_lname,seller_topan_name,purchase_pot";
        //                str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
        //                str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["TKN"]) + Convert.ToString(row["buyer_khata_no"]) + "','" + Convert.ToString(row["purchase_area"]) + "','" + Convert.ToString(row["seller_khata_no"]) + "','" + Convert.ToString(row["buyer_assessment"]) + "','" + Convert.ToString(row["buyer_fname"]) + "','" + Convert.ToString(row["buyer_mname"]) + "','" + Convert.ToString(row["buyer_lname"]) + "','" + Convert.ToString(row["buyer_tname"]) + "','" + Convert.ToString(row["seller_fname"]) + "','" + Convert.ToString(row["seller_mname"]) + "','" + Convert.ToString(row["seller_lname"]) + "','" + Convert.ToString(row["seller_tname"]) + "'," + Convert.ToString(row["buyer_potkharaba"]) + "";
        //            }
        //            else
        //            {
        //                str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,seller_khata_no,buyer_assessment,fname,mname,lname,topan_name,purchase_pot";
        //                str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
        //                str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["TKN"]) + Convert.ToString(row["buyer_khata_no"]) + "','" + Convert.ToString(row["purchase_area"]) + "','" + Convert.ToString(row["seller_khata_no"]) + "','" + Convert.ToString(row["buyer_assessment"]) + "','" + Convert.ToString(row["buyer_fname"]) + "','" + Convert.ToString(row["buyer_mname"]) + "','" + Convert.ToString(row["buyer_lname"]) + "','" + Convert.ToString(row["buyer_tname"]) + "'," + Convert.ToString(row["buyer_potkharaba"]) + "";
        //            }
        //            str6 = "mut_kharedi_buyer_khata";
        //            command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
        //            //command2.CommandType = CommandType.StoredProcedure;
        //            //command2.CommandText = SchemaName + ".sptblmutregister_all";
        //            handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
        //            handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
        //            handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
        //            handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
        //            handler2.SetInParameter(command2, "@para_login_id", DbType.String, login_id);
        //            handler2.SetInParameter(command2, "@para_app_name", DbType.String, "reEdit");
        //            num = handler2.ExecuteNonQuery(command2);
        //            //command2.ExecuteNonQuery();

        //        }
        //        return num;
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //    return num;

        //}

        public int funmutkharedibuyerkhataName(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable,ref DbCommand dbCommand)
        {
            int num = 0;
           
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";
                string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
                int i = 0;
                //DbCommand command2;
                foreach (DataRow row in PinTable.Rows)
                {
                    if (Convert.ToString(row["special_case"]) == "Yes")
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,seller_khata_no,buyer_assessment,fname,mname,lname,topan_name,seller_fname,seller_mname,seller_lname,seller_topan_name,purchase_pot,seller_temp_khata_no";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["TKN"]) + Convert.ToString(row["buyer_khata_no"]) + "','" + Convert.ToString(row["purchase_area"]) + "','" + Convert.ToString(row["seller_khata_no"]) + "','" + Convert.ToString(row["buyer_assessment"]) + "','" + Convert.ToString(row["buyer_fname1"]) + "','" + Convert.ToString(row["buyer_mname"]) + "','" + Convert.ToString(row["buyer_lname"]) + "','" + Convert.ToString(row["buyer_tname"]) + "','" + Convert.ToString(row["seller_fname"]) + "','" + Convert.ToString(row["seller_mname"]) + "','" + Convert.ToString(row["seller_lname"]) + "','" + Convert.ToString(row["seller_tname"]) + "'," + Convert.ToString(row["buyer_potkharaba"]) + ",'" + Convert.ToString(row["seller_temp_khata_no"]) + "'";
                    }
                    else
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,seller_khata_no,buyer_assessment,fname,mname,lname,topan_name,purchase_pot,seller_temp_khata_no";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["TKN"]) + Convert.ToString(row["buyer_khata_no"]) + "','" + Convert.ToString(row["purchase_area"]) + "','" + Convert.ToString(row["seller_khata_no"]) + "','" + Convert.ToString(row["buyer_assessment"]) + "','" + Convert.ToString(row["buyer_fname1"]) + "','" + Convert.ToString(row["buyer_mname"]) + "','" + Convert.ToString(row["buyer_lname"]) + "','" + Convert.ToString(row["buyer_tname"]) + "'," + Convert.ToString(row["buyer_potkharaba"]) + ",'" + Convert.ToString(row["seller_temp_khata_no"]) + "'";
                    }
                    str6 = "mut_kharedi_buyer_khata";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, login_id);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                    //command2.ExecuteNonQuery();

                }
                return num;
           

            return num;

        }


        public int funmutkharedibuyerkhataName_verify(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, ref DbCommand dbCommand)
        {
            int num = 0;
            
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";
                string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
                int i = 0;
                //DbCommand command2;
                foreach (DataRow row in PinTable.Rows)
                {
                    if (Convert.ToString(row["special_case"]) == "Yes")
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,seller_khata_no,buyer_assessment,fname,mname,lname,topan_name,seller_fname,seller_mname,seller_lname,seller_topan_name,purchase_pot,seller_temp_khata_no";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["TKN"]) + Convert.ToString(row["buyer_khata_no"]) + "','" + Convert.ToString(row["purchase_area"]) + "','" + Convert.ToString(row["seller_khata_no"]) + "','" + Convert.ToString(row["buyer_assessment"]) + "','" + Convert.ToString(row["buyer_fname1"]) + "','" + Convert.ToString(row["buyer_mname"]) + "','" + Convert.ToString(row["buyer_lname"]) + "','" + Convert.ToString(row["buyer_tname"]) + "','" + Convert.ToString(row["seller_fname"]) + "','" + Convert.ToString(row["seller_mname"]) + "','" + Convert.ToString(row["seller_lname"]) + "','" + Convert.ToString(row["seller_tname"]) + "'," + Convert.ToString(row["buyer_potkharaba"]) + ",'" + Convert.ToString(row["seller_temp_khata_no"]) + "'";
                    }
                    else
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,seller_khata_no,buyer_assessment,fname,mname,lname,topan_name,purchase_pot,seller_temp_khata_no";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(row["TKN"]) + Convert.ToString(row["buyer_khata_no"]) + "','" + Convert.ToString(row["purchase_area"]) + "','" + Convert.ToString(row["seller_khata_no"]) + "','" + Convert.ToString(row["buyer_assessment"]) + "','" + Convert.ToString(row["buyer_fname1"]) + "','" + Convert.ToString(row["buyer_mname"]) + "','" + Convert.ToString(row["buyer_lname"]) + "','" + Convert.ToString(row["buyer_tname"]) + "'," + Convert.ToString(row["buyer_potkharaba"]) + ",'" + Convert.ToString(row["seller_temp_khata_no"]) + "'";
                    }
                    str6 = "verify_mut_kharedi_buyer_khata";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all";
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                    //command2.ExecuteNonQuery();

                }
                return num;
           

            return num;

        }

        public int funbuyerSeller_new(string dbname, string SchemaName, string ccode, string mutno, DataTable Dtseller, DataTable dtbuyer)
        {
            int result = 0;
           
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                DbCommand command2;
                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                //foreach (DataRow row in PinTable.Rows)
                //{
                int partsellreysrno = 1;
                foreach (DataRow row2 in Dtseller.Rows)
                {
                    string fname1 = Convert.ToString(row2["fname"]).Trim();
                    string mname1 = Convert.ToString(row2["mname"]).Trim();
                    string lname1 = Convert.ToString(row2["lname"]).Trim();
                    //decimal seller_area_culti = Convert.ToDecimal(row2["nave_area"]);
                    //decimal vikri_area = Convert.ToDecimal(row2["vikri_area"]);
                    //decimal rem_area = seller_area_culti - vikri_area;



                    str4 = "ccode,mut_no,fname,mname,lname,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,seller_khata_no";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + fname1.Trim() + "','" + mname1.Trim() + "','" + lname1.Trim() + "','" + Convert.ToString(row2["pin"]) + "','" + Convert.ToString(row2["pin1"]) + "','" + Convert.ToString(row2["pin2"]);
                    str5 += "','" + Convert.ToString(row2["pin3"]) + "','" + Convert.ToString(row2["pin4"]) + "','" + Convert.ToString(row2["pin5"]) + "','" + Convert.ToString(row2["pin6"]) + "','" + Convert.ToString(row2["pin7"]) + "','" + Convert.ToString(row2["pin8"]) + "','" + Convert.ToString(row2["seller_khata_no"]) + "'";

                    // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                    string str7 = "mut_kharedi_seller";
                    command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str7);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                    num2 = handler2.ExecuteNonQuery(command2);
                    partsellreysrno++;
                }
                //}


                //foreach (DataRow row in PinTable.Rows)
                //{
                int partysrno = 1;
                foreach (DataRow row2 in dtbuyer.Rows)
                {

                    //string TOPANANEM = Convert.ToString(row2[2]);
                    //decimal nave_area = Convert.ToDecimal(row2["nave_area"]);
                    //topan_name
                    string str3 = "ccode,mut_no,fname,mname,lname,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,buyer_khata_no,khata_no";
                    str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row2["fname"]).Trim() + "','" + Convert.ToString(row2["mname"]).Trim() + "','" + Convert.ToString(row2["lname"]).Trim() + "'";
                    str4 += ",'" + Convert.ToString(row2["pin"]) + "','" + Convert.ToString(row2["pin1"]) + "','" + Convert.ToString(row2["pin2"]) + "','" + Convert.ToString(row2["pin3"]) + "','" + Convert.ToString(row2["pin4"]) + "','" + Convert.ToString(row2["pin5"]) + "','" + Convert.ToString(row2["pin6"]) + "','" + Convert.ToString(row2["pin7"]) + "','" + Convert.ToString(row2["pin8"]) + "','" + Convert.ToString(row2["TKN"]) + Convert.ToString(row2["buyer_khata_no"]) + "','" + Convert.ToString(row2["TKN"]) + Convert.ToString(row2["khata_no"]) + "'";
                    str5 = "mut_kharedi_buyer";
                    command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str5);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str3);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str4);
                    num = handler2.ExecuteNonQuery(command2);
                    partysrno++;
                }
                //}

                /************************* Pending mutation (Red ink mark)*****************************/
                //foreach (DataRow drpin in PinTable.Rows)
                //{
                //    foreach (DataRow dr in Dtseller.Rows)
                //    {
                //        string col_name = "ccode,mutationno,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,pending_mut_flag";
                //        string col_value = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno);
                //        col_value += ",'" + Convert.ToString(drpin["pin"]) + "','" + Convert.ToString(drpin["pin"]) + "','" + Convert.ToString(drpin["pin1"]) + "','" + Convert.ToString(drpin["pin2"]) + "','" + Convert.ToString(drpin["pin3"]) + "','" + Convert.ToString(drpin["pin4"]) + "','" + Convert.ToString(drpin["pin5"]) + "','" + Convert.ToString(drpin["pin6"]) + "','" + Convert.ToString(drpin["pin7"]) + "','" + Convert.ToString(drpin["pin8"]) + "','T'";
                //        string table_name3 = "tblrordetails";

                //        command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                //        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                //        handler2.SetInParameter(command2, "@para_table_name", DbType.String, table_name3);
                //        handler2.SetInParameter(command2, "@para_column_name", DbType.String, col_name);
                //        handler2.SetInParameter(command2, "@para_column_value", DbType.String, col_value);
                //        handler2.ExecuteNonQuery(command2);
                //    }
                //}

                if (num != 0 && num2 != 0)
                {
                    result = 1;
                    return 1;
                }
                else
                {
                    result = 0;
                    return 0;
                }
           
            return result;

        }

        public int funOtherrights(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, string remarke)
        {
            int num = 0;
           
                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                foreach (DataRow row in PinTable.Rows)
                {

                    string str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,remark";
                    string str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]);
                    str5 += "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + Convert.ToString(remarke) + "'";
                    string str6 = "mut_other_rights";
                    DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all", CommandType.StoredProcedure);
                    handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, str6);
                    handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                    handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                    num = handler2.ExecuteNonQuery(command2);
                }
                return num;

         
            return num;
        }

        public int funmutDeal(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, string deal_text,ref DbCommand dbCommand)
        {
            int num = 0;
            

                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
                foreach (DataRow row in PinTable.Rows)
                {


                    string str3 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,deal_text";
                    //   object obj2 = string.Concat(new object[] { "'", Convert.ToString(ccode), "',", Convert.ToInt32(mutno), "" });
                    //           string str4 = string.Concat(new object[] { 
                    // obj2, Convert.ToInt32(0x35), ",'", Convert.ToString(row["pin"]), "','", Convert.ToString(row["pin1"]), "','", Convert.ToString(row["pin2"]), "','", Convert.ToString(row["pin3"]), "','", Convert.ToString(row["pin4"]), "','", Convert.ToString(row["pin5"]), "','", Convert.ToString(row["pin6"]), 
                    // "','", Convert.ToString(row["pin7"]), "','", Convert.ToString(row["pin8"]), "','", deal_text, "'"
                    //});
                    string str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "',";
                    str4 += "'" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + deal_text + "'";

                    string str5 = "mut_deal";
                    //DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str3);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, login_id);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
                return num;
           
            return num;

        }


        public int funmutDeal_verify(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, string deal_text, ref DbCommand dbCommand)
        {
            int num = 0;
            

                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string login_id = objclscommonfunedit.funReturnSingleValue(dbname, SchemaName + ".m_officermast", "username", "ccode='" + ccode + "' and user_type='1'", "");
                foreach (DataRow row in PinTable.Rows)
                {


                    string str3 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,deal_text";
                    //   object obj2 = string.Concat(new object[] { "'", Convert.ToString(ccode), "',", Convert.ToInt32(mutno), "" });
                    //           string str4 = string.Concat(new object[] { 
                    // obj2, Convert.ToInt32(0x35), ",'", Convert.ToString(row["pin"]), "','", Convert.ToString(row["pin1"]), "','", Convert.ToString(row["pin2"]), "','", Convert.ToString(row["pin3"]), "','", Convert.ToString(row["pin4"]), "','", Convert.ToString(row["pin5"]), "','", Convert.ToString(row["pin6"]), 
                    // "','", Convert.ToString(row["pin7"]), "','", Convert.ToString(row["pin8"]), "','", deal_text, "'"
                    //});
                    string str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "',";
                    str4 += "'" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "','" + deal_text + "'";

                    string str5 = "verify_mut_deal";
                    //DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str3);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str4);
                    
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
                return num;
           
            return num;

        }

        public int funDeleteMutData(string dbname, string SchemaName, string ccode, string mutno,string table_names)
        {
            int num = 0;
           
                string[] tbl_name = table_names.Split('#');
                string cond_val = "ccode='" + ccode + "' and mut_no='" + mutno + "'";
                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                for (int i = 0; i < tbl_name.Length; i++)
                {
                    DbCommand command2 = handler2.SetCommandText(SchemaName + ".sp_delete", CommandType.StoredProcedure);
                    handler2.SetInParameter(command2, "@para_table_name", DbType.String, SchemaName + "." + tbl_name[i]);
                    handler2.SetInParameter(command2, "@para_condition_column", DbType.String, cond_val);
                    handler2.SetOutParameter(command2, "@para_id", DbType.Int32, 0);
                    num = handler2.ExecuteNonQuery(command2);
                }
            
            return num;
        }

        #endregion

        public void GetKhataName(string databasename, string schmemaname, ref DropDownList ddl, string columname, string tablename, string ccode)
        {
            string cmdText = "Select " + columname + " from " + schmemaname + ".form7_khata where ccode=@ccode and marked<>'Y' order by fname,mname,lname";
            DataBaseHandler handler = new DataBaseHandler(databasename, "Tahsil Connection String");
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            handler.SetInParameter(command, "@ccode", DbType.String, ccode);
            DataSet set = handler.FillDataset(command);
            ddl.DataSource = set.Tables[0].DefaultView;
            ddl.DataTextField = set.Tables[0].Columns[1].ToString();
            ddl.DataValueField = set.Tables[0].Columns[0].ToString();
            ddl.DataBind();
        }

        public void funSetDropDownList(string DBName, ref DropDownList ddl, string TableName, string ColValue, string Condition, string Orderby)
        {
            DataBaseHandler handler = new DataBaseHandler(DBName, "Tahsil Connection String");
            DataSet set = new DataSet();
            string cmdText = "select " + ColValue + " from " + TableName;
            // string cmdText = "select  @ColValue  from "+ TableName;
            if (Condition != "")
            {
                cmdText = cmdText + " WHERE " + Condition;
            }
            if (Orderby != "")
            {
                cmdText = cmdText + " Order by " + Orderby;
            }
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
          
            set = handler.FillDataset(command);
            ddl.DataSource = set.Tables[0].DefaultView;
            ddl.DataValueField = set.Tables[0].Columns[0].ColumnName;
            ddl.DataTextField = set.Tables[0].Columns[1].ColumnName;
            ddl.DataBind();
            ddl.Items.Insert(0, "--Select--");
        }

        //public void funSetDropDownList(string DBName, ref DropDownList ddl, string TableName, string ColValue,string ccode, string fname, string mname,string lname,string topanname, string Orderby)
        //{
        //    DataBaseHandler handler = new DataBaseHandler(DBName, "Tahsil Connection String");
        //    DataSet set = new DataSet();
        //    string cmdText = "select " + ColValue + " from " + TableName;
           
        //    // string cmdText = "select  @ColValue  from "+ TableName;
        //    if (fname != "")
        //    {
        //        cmdText = cmdText + " WHERE ccode=@ccode and fname like @fname%";
        //    }
        //    cmdText =cmdText +"and marked<>'Y'";
        //    if (Orderby != "")
        //    {
        //        cmdText = cmdText + " Order by " + Orderby;
        //    }
        //    DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
        //    handler.SetInParameter(command, "@ccode", DbType.String, ccode);
        //    handler.SetInParameter(command, "@fname", DbType.String, fname);
        //    set = handler.FillDataset(command);
        //    ddl.DataSource = set.Tables[0].DefaultView;
        //    ddl.DataValueField = set.Tables[0].Columns[0].ColumnName;
        //    ddl.DataTextField = set.Tables[0].Columns[1].ColumnName;
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, "--Select--");
        //}

        public void funSetDropDownList(string DBName, ref DropDownList ddl, string TableName, string ColValue, string Condition, string Orderby, string TextField, string ValueField)
        {
            DataBaseHandler handler = new DataBaseHandler(DBName, "Tahsil Connection String");
            DataSet set = new DataSet();
            string cmdText = "select  " + ColValue + " from " + TableName;
            if (Condition != "")
            {
                cmdText = cmdText + " WHERE " + Condition;
            }
            if (Orderby != "")
            {
                cmdText = cmdText + " Order by " + Orderby;
            }
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            set = handler.FillDataset(command);
            ddl.DataSource = set.Tables[0].DefaultView;
            ddl.DataValueField = ValueField;
            ddl.DataTextField = TextField;
            ddl.DataBind();
            ddl.Items.Insert(0, "--Select--");
        }

        public DataSet funSetGridList1(string DBName, ref GridView gdv, string TableName, string ColValue, string Condition, string Orderby, string ccode)
        {
            DataBaseHandler handler = new DataBaseHandler(DBName, "Tahsil Connection String");
            DataSet set = new DataSet();
            string cmdText = "select  " + ColValue + " from " + TableName;
            if (Condition != "")
            {
                cmdText = cmdText + " WHERE " + Condition + "And " + ccode;
            }
            if (Orderby != "")
            {
                cmdText = cmdText + " Order by " + Orderby;
            }
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            set = handler.FillDataset(command);
            gdv.DataSource = set.Tables[0].DefaultView;
            gdv.DataBind();
            return set;
        }

        public DataSet FillGridView1(string DataBasename, string schemaname, ref GridView grv, string colunname, string tablename, string condition)
        {
            string cmdText = "select distinct " + colunname + " from " + schemaname + "." + tablename + " where " + condition + "";
            DataBaseHandler handler = new DataBaseHandler(DataBasename, "Tahsil Connection String");
            DbCommand command = handler.SetCommandText(cmdText, CommandType.Text);
            DataSet set = handler.FillDataset(command);
            grv.DataSource = set.Tables[0].DefaultView;
            grv.DataBind();
            return set;
        }
        

        public int funCheckMutDeatil(string DataBaseName, string SchemaName, string tablename, string ccode, string mut_No, DataSet dspin)
        {
            int i = 0;
            int j = 0, count = dspin.Tables[0].Rows.Count;
            while (count > 0)
            {

                string command = "select Count(*) from  " + SchemaName + "." + tablename + " where ccode='" + ccode + "'and mut_no='" + mut_No + "' and pin='" + dspin.Tables[0].Rows[j]["pin"].ToString() + "'";
                command += " and pin1='" + dspin.Tables[0].Rows[j]["pin1"].ToString() + "' and pin2='" + dspin.Tables[0].Rows[j]["pin2"].ToString() + "' and pin3='" + dspin.Tables[0].Rows[j]["pin3"].ToString() + "' and pin4='" + dspin.Tables[0].Rows[j]["pin4"].ToString() + "'";
                command += " and pin5='" + dspin.Tables[0].Rows[j]["pin5"].ToString() + "' and pin6='" + dspin.Tables[0].Rows[j]["pin6"].ToString() + "' and pin7='" + dspin.Tables[0].Rows[j]["pin7"].ToString() + "' and pin8='" + dspin.Tables[0].Rows[j]["pin8"].ToString() + "'";
                DataBaseHandler dbHandler = new DataBaseHandler(DataBaseName, "Tahsil Connection String");
                DbCommand dbCmd = dbHandler.SetCommandText(command, CommandType.Text);
                i = dbHandler.ExecuteScalar(dbCmd);
                if (i > 0)
                {
                    break;
                }
                j++;
                count--;

            }
            return i;

           
        }
        public int funCheckMutDeatilmutRegister(string DataBaseName, string SchemaName, string tablename, string ccode, string mut_No)
        {
            int i = 0;


            string command = "select Count(*) from  " + SchemaName + "." + tablename + " where ccode='" + ccode + "'and mut_no='" + mut_No + "'";
            DataBaseHandler dbHandler = new DataBaseHandler(DataBaseName, "Tahsil Connection String");
            DbCommand dbCmd = dbHandler.SetCommandText(command, CommandType.Text);
            i = dbHandler.ExecuteScalar(dbCmd);
            return i;
        }



        #region [---Linkage Functions---]

        public int mut_kharedi_seller_khata_multple(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable dtsellerkhata, string sellerall,string loginid,ref DbCommand dbCommand)
        {
            int result = 0;
            
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");

                foreach (DataRow row2 in dtsellerkhata.Rows)
                {

                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];

                    }
                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();


                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,nave_area,nave_pot,nave_assessment,fname,mname,lname,topan_name,temp_khata_no";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + " ,'" + pin + "','" + pin1 + "','" + pin2;
                    str5 += "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "'," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToDouble(row2["nave_area"]) + "," + Convert.ToDouble(row2["nave_pot"]) + "," + Convert.ToDouble(row2["nave_assessment"]) + ",'" + sellerall + "','-','-','-','" + Convert.ToString(row2["seller_temp_khata_no"]) + "'";

                    // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                    string str7 = "mut_kharedi_seller_khata";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str7);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num2 = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
           
            return result;
        }

        public int mut_kharedi_seller_khata_multple_single(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable dtsellerkhata,string loginid,ref DbCommand dbCommand)
        {
            int result = 0;
           
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");

                foreach (DataRow row2 in dtsellerkhata.Rows)
                {

                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];

                    }
                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();

                    int assess = 0;

                    if (Convert.ToString(row2["seller_temp_khata_no"]) != "")
                        row2["special_case"] = "";

                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,nave_area,nave_pot,nave_assessment,fname,mname,lname,topan_name,special_case,temp_khata_no";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + " ,'" + pin + "','" + pin1 + "','" + pin2;
                    str5 += "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "'," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToDouble(row2["nave_area"]) + "," + Convert.ToDouble(row2["nave_pot"]) + "," + Convert.ToDouble(row2["nave_assessment"]) + ",'" + Convert.ToString(row2["firstname"]) + "','" + Convert.ToString(row2["middlename"]) + "','" + Convert.ToString(row2["surname"]) + "','" + Convert.ToString(row2["aliasname"]) + "','" + Convert.ToString(row2["special_case"]) + "','" + Convert.ToString(row2["seller_temp_khata_no"]) + "'";

                    // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                    string str7 = "mut_kharedi_seller_khata";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str7);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num2 = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
           
            return result;
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


        public int funmutkharedibuyerkhata_multiple(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable dtbuyerkhata, string buyerall, string loginid,ref DbCommand dbCommand)
        {
            int result = 0;
            
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");

                foreach (DataRow row2 in dtbuyerkhata.Rows)
                {


                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";

                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().ToString().Split('/')[i];

                    }
                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();


                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,purchase_pot,seller_khata_no,buyer_assessment,fname,mname,lname,topan_name,seller_fname,seller_mname,seller_lname,seller_topan_name,seller_temp_khata_no";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + " ,'" + pin + "','" + pin1 + "','" + pin2;
                    str5 += "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "','" + Convert.ToString(row2["khata_no"]) + "'," + Convert.ToDouble(row2["nave_area"]) + "," + Convert.ToDouble(row2["nave_pot"]) + "," + Convert.ToInt32(row2["seller_khata_no"]) + "," + Convert.ToDecimal(row2["buyer_assessment"]) + ",'" + buyerall + "','-','-','-','" + Convert.ToString(row2["seller_fname"]) + "','" + Convert.ToString(row2["seller_mname"]) + "','" + Convert.ToString(row2["seller_lname"]) + "','" + Convert.ToString(row2["seller_topan_name"]) + "','" + Convert.ToString(row2["seller_temp_khata_no"]) + "'";


                    // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                    string str7 = "mut_kharedi_buyer_khata";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str7);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num2 = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
            
            return result;


        }

        public int funmutkharedibuyerkhata_multiple_single(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable dtbuyerkhata,string loginid,ref DbCommand dbCommand)
        {
            int result = 0;
            
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");

                foreach (DataRow row2 in dtbuyerkhata.Rows)
                {


                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];

                    }
                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();


                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,purchase_pot,seller_khata_no,buyer_assessment,fname,mname,lname,topan_name,seller_fname,seller_mname,seller_lname,seller_topan_name,seller_temp_khata_no";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + " ,'" + pin + "','" + pin1 + "','" + pin2;
                    str5 += "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "','" + Convert.ToString(row2["khata_no"]) + "'," + Convert.ToDouble(row2["nave_area"]) + "," + Convert.ToDouble(row2["nave_pot"]) + "," + Convert.ToInt32(row2["seller_khata_no"]) + "," + Convert.ToDecimal(row2["buyer_assessment"]) + ",'" + Convert.ToString(row2["firstname"]) + "','" + Convert.ToString(row2["middlename"]) + "','" + Convert.ToString(row2["surname"]) + "','" + Convert.ToString(row2["aliasname"]) + "','" + Convert.ToString(row2["seller_fname"]) + "','" + Convert.ToString(row2["seller_mname"]) + "','" + Convert.ToString(row2["seller_lname"]) + "','" + Convert.ToString(row2["seller_topan_name"]) + "','" + Convert.ToString(row2["seller_temp_khata_no"]) + "'";


                    // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                    string str7 = "mut_kharedi_buyer_khata";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str7);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num2 = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
           
            return result;


        }

        public int mut_kharedi_seller_khata(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable dtsellerkhata,string loginid)
        {
            int result = 0;
           
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                DbCommand command2;
                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                foreach (DataRow row in PinTable.Rows)
                {
                    foreach (DataRow row2 in dtsellerkhata.Rows)
                    {

                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,nave_area";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + " ,'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]);
                        str5 += "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToDouble(row2["nave_area"]) + " ";

                        // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                        string str7 = "mut_kharedi_seller_khata";
                        command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str7);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                        handler2.SetInParameter(command2, "@para_login_id", DbType.String, loginid);
                        handler2.SetInParameter(command2, "@para_app_name", DbType.String, "reEdit");
                        num2 = handler2.ExecuteNonQuery(command2);
                    }
                }
           
            return result;


        }

        public int funmutkharedibuyerkhata_multiple(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable dtbuyerkhata, string loginid,ref DbCommand dbCommand)
        {
            int result = 0;
            
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");

                foreach (DataRow row2 in dtbuyerkhata.Rows)
                {


                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];

                    }
                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();

                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,purchase_pot,seller_khata_no";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + " ,'" + pin + "','" + pin1 + "','" + pin2;
                    str5 += "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "','" + Convert.ToString(row2["khata_no"]) + "'," + Convert.ToDouble(row2["nave_area"]) + "," + Convert.ToDouble(row2["nave_pot"]) + "," + Convert.ToInt32(row2["seller_khata_no"]) + "";

                    // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                    string str7 = "mut_kharedi_buyer_khata";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str7);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num2 = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
           
            return result;


        }

        public int mut_kharedi_seller_khata_multple(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable dtsellerkhata, string loginid,ref DbCommand dbCommand)
        {
            int result = 0;
           
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");

                foreach (DataRow row2 in dtsellerkhata.Rows)
                {

                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];

                    }
                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();


                    str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,nave_area,nave_pot";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + " ,'" + pin + "','" + pin1 + "','" + pin2;
                    str5 += "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "'," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToDouble(row2["nave_area"]) + "," + Convert.ToDouble(row2["nave_pot"]) + " ";

                    // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                    string str7 = "mut_kharedi_seller_khata";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str7);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num2 = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }
           
            return result;


        }

        public int funmutregister_boja(string dbname, string SchemaName, string ccode, int mutno, string mutdate1, int mutType, string mutName, string loginid, string docno, string docdate, string prices,ref DbCommand dbCommand)
        {
            int num4 = 0;
           
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str3 = "mutregister";
                string str4 = "";
                string str5 = "";

                str4 = "ccode,mut_no,mut_date,mut_type,mut_name,talathi_id,ref_no1,ref_no2,ref_date2,amount,ref_date1,mut_info_date ,mut_status_code,table_name";
                str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + func.ConvertDateToMMddyyyyFormat(Convert.ToDateTime(mutdate1).ToShortDateString()) + "','" + Convert.ToInt32(mutType) + "','" + Convert.ToString(mutName) + "','" + Convert.ToString(loginid) + "',";
                str5 += "" + Convert.ToString("''") + ",'" + Convert.ToString(docno) + "','" + func.ConvertDateToMMddyyyyFormat(Convert.ToDateTime(docdate).ToShortDateString()) + "','" + Convert.ToDecimal(prices) + "','" + func.ConvertDateToMMddyyyyFormat(Convert.ToDateTime(mutdate1).ToShortDateString()) + "','" + func.ConvertDateToMMddyyyyFormat(Convert.ToDateTime(mutdate1).ToShortDateString()) + "',1,'SRO'";

               // DbCommand command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
                dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                dbCommand.CommandType = CommandType.StoredProcedure;
                this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str3);
                this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                num4 = dbCommand.ExecuteNonQuery();
                dbCommand.Parameters.Clear();

                return num4;
           
            return num4;
        }

        public int funmutkharedi_boja(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, string loginid,ref DbCommand dbCommand)
        {
            int num = 0;
           
                //DbCommand command2;
                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                string str6 = " ";
                string str4 = "";
                string str5 = "";

                int i = 0;
                foreach (DataRow row in PinTable.Rows)
                {
                    if (i == 0)
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code3,remark";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToInt32(0x42) + ",'Itar-M'";
                        str6 = "mut_kharedi";
                        dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                        this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                        this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                        this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                        this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                        this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                        num = dbCommand.ExecuteNonQuery();
                        dbCommand.Parameters.Clear();
                    }
                    else
                    {
                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code3";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]) + "',";
                        str5 += "'" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToInt32(0x42) + "";
                        str6 = "mut_kharedi";
                        dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                        dbCommand.CommandType = CommandType.StoredProcedure;

                        this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                        this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str6);
                        this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                        this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                        this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                        this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                        num = dbCommand.ExecuteNonQuery();
                        dbCommand.Parameters.Clear();
                    }

                }
                return num;
           

            return num;

        }

        public int funbuyerSellerMultiple_boja(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable Dtseller, DataTable dtbuyer_boja, string buyername, int mut_type,string loginid,ref DbCommand dbCommand)
        {
            int result = 0;
           
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                //DbCommand command2;
                int code = 0;

                if (mut_type == 2)
                {
                    code = 32;
                }
                else
                {
                    code = 27;
                }

                //DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");

                foreach (DataRow row2 in Dtseller.Rows)
                {
                    string fname1 = Convert.ToString(row2["firstname"]).Trim();
                    string mname1 = Convert.ToString(row2["middlename"]).Trim();
                    string lname1 = Convert.ToString(row2["surname"]).Trim();

                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];

                    }
                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();

                    str4 = "ccode,mut_no,fname,mname,lname,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,seller_khata_no";
                    str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + fname1.Trim() + "','" + mname1.Trim() + "','" + lname1.Trim() + "','" + pin + "','" + pin1 + "','" + pin2;
                    str5 += "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "','" + Convert.ToString(row2["khata_no"]) + "'";

                    // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                    string str7 = "mut_kharedi_seller";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str7);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num2 = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }

                foreach (DataRow row2 in dtbuyer_boja.Rows)
                {
                    //string TOPANANEM = Convert.ToString(row2[2]);
                    //decimal nave_area = Convert.ToDecimal(row2["nave_area"]);
                    string[] strp = new string[9];
                    string pin = "", pin1 = "", pin2 = "", pin3 = "", pin4 = "", pin5 = "", pin6 = "", pin7 = "", pin8 = "";
                    for (int i = 0; i < row2["pins"].ToString().Split('/').Length; i++)
                    {
                        if (i == 0)
                            strp[i] = row2["pins"].ToString().Split('/')[0];
                        else
                            strp[i] = row2["pins"].ToString().Split('/')[i];
                    }

                    if (strp[0] != null)
                        pin = strp[0].ToString();
                    if (strp[1] != null)
                        pin1 = strp[1].ToString();
                    if (strp[2] != null)
                        pin2 = strp[2].ToString();
                    if (strp[3] != null)
                        pin3 = strp[3].ToString();
                    if (strp[4] != null)
                        pin4 = strp[4].ToString();
                    if (strp[5] != null)
                        pin5 = strp[5].ToString();
                    if (strp[6] != null)
                        pin6 = strp[6].ToString();
                    if (strp[7] != null)
                        pin7 = strp[7].ToString();
                    if (strp[8] != null)
                        pin8 = strp[8].ToString();

                    //topan_name
                    //ccode ,mut_no ,fname,address,usrno,khata_no,buyer_doc_type1,buyer_name,tenure_code,tenure_sub_code,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8
                    string str3 = "ccode,mut_no,fname,mname,lname,address,buyer_doc_type1,tenure_code,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,buyer_name ";
                    str4 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + ",'" + Convert.ToString(row2["firstname"]).Trim() + "','" + Convert.ToString(row2["middlename"]).Trim() + "','" + Convert.ToString(row2["surname"]).Trim() + "','" + Convert.ToString(row2["address"]).Trim() + "',";
                    str4 += Convert.ToInt32(0x39) + ",'" + code + "','" + pin + "','" + pin1 + "','" + pin2 + "','" + pin3 + "','" + pin4 + "','" + pin5 + "','" + pin6 + "','" + pin7 + "','" + pin8 + "','" + Convert.ToString(row2["khata_no"]) + "','" + buyername + "'";
                    str5 = "mut_kharedi_buyer";
                    dbCommand.CommandText = SchemaName + ".sptblmutregister_all_em";
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    this.SetInParameter(dbCommand, "@para_schema_name", DbType.String, SchemaName);
                    this.SetInParameter(dbCommand, "@para_table_name", DbType.String, str5);
                    this.SetInParameter(dbCommand, "@para_column_name", DbType.String, str3);
                    this.SetInParameter(dbCommand, "@para_column_value", DbType.String, str4);
                    this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                    this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                    num = dbCommand.ExecuteNonQuery();
                    dbCommand.Parameters.Clear();
                }

                if (num != 0 && num2 != 0)
                {
                    result = 1;
                    return 1;
                }
                else
                {
                    result = 0;
                    return 0;
                }



           
            return result;


        }

        public string funReturnSroName(int loginid)
        {
            DataBaseHandler dbHandler = new DataBaseHandler("Linkage Connection String1");
            string name = "";
            string query = "select sromshortname from rcis_uni.sromaster where srocode=" + loginid;
            DbCommand dbCmd = dbHandler.SetCommandText(query, CommandType.Text);
            name = dbHandler.ExecuteScalarString(dbCmd);
            return name;
        }

        public int funmutkharedibuyerkhata(string dbname, string SchemaName, string ccode, string mutno, DataTable PinTable, DataTable dtbuyerkhata, string loginid)
        {
            int result = 0;
            
                string str4 = "";
                string str5 = "";
                int num2 = 0, num = 0;
                DbCommand command2;
                DataBaseHandler handler2 = new DataBaseHandler(dbname, "Tahsil Connection String");
                foreach (DataRow row in PinTable.Rows)
                {
                    foreach (DataRow row2 in dtbuyerkhata.Rows)
                    {

                        str4 = "ccode,mut_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,khata_no,purchase_area,seller_khata_no";
                        str5 = "'" + Convert.ToString(ccode) + "'," + Convert.ToInt32(mutno) + " ,'" + Convert.ToString(row["pin"]) + "','" + Convert.ToString(row["pin1"]) + "','" + Convert.ToString(row["pin2"]);
                        str5 += "','" + Convert.ToString(row["pin3"]) + "','" + Convert.ToString(row["pin4"]) + "','" + Convert.ToString(row["pin5"]) + "','" + Convert.ToString(row["pin6"]) + "','" + Convert.ToString(row["pin7"]) + "','" + Convert.ToString(row["pin8"]) + "'," + Convert.ToString(row2["khata_no"]) + "," + Convert.ToDouble(row2["nave_area"]) + "," + Convert.ToInt32(row2["seller_khata_no"]) + "";

                        // zstr5 ="'"+ Convert.ToString(ccode)+ "',"+Convert.ToInt32(mutno)+",'"+Convert.ToString(row2["firstname"]).Trim()+"','"+Convert.ToString(row2["middlename"]).Trim()+"','"+Convert.ToString(row2["surname"]).Trim()+"','""',
                        string str7 = "mut_kharedi_buyer_khata";
                        command2 = handler2.SetCommandText(SchemaName + ".sptblmutregister_all_em", CommandType.StoredProcedure);
                        handler2.SetInParameter(command2, "@para_schema_name", DbType.String, SchemaName);
                        handler2.SetInParameter(command2, "@para_table_name", DbType.String, str7);
                        handler2.SetInParameter(command2, "@para_column_name", DbType.String, str4);
                        handler2.SetInParameter(command2, "@para_column_value", DbType.String, str5);
                        handler2.SetInParameter(command2, "@para_login_id", DbType.String, loginid);
                        handler2.SetInParameter(command2, "@para_app_name", DbType.String, "reEdit");
                        num2 = handler2.ExecuteNonQuery(command2);
                    }
                }
           
            return result;
        }

        public void funInsertROR(string DataBaseName, string SchemaName, string loginid, int documentno, int year, int MutNo, string allpin)
        {

            DataBaseHandler dbHandler = new DataBaseHandler(DataBaseName, "Tahsil Connection String");
            if (allpin != "")
            {
                try
                {
                    string newpin = allpin.Replace("'", "");
                    string[] strp = new string[9];
                    strp = newpin.Split('/');
                    string col_name = "loginid,documentnumber,docyear,mutationno,numeric_pin,pin,";
                    string col_val = "'" + loginid + "'," + documentno + "," + year + "," + MutNo + "," + string.Join(null, System.Text.RegularExpressions.Regex.Split(strp[0], "[^\\d]")) + ",'" + strp[0] + "'";
                    for (int i = 1; i < allpin.Split('/').Length; i++)
                    {
                        col_name += "pin" + i + ",";
                        col_val += ",'" + strp[i] + "'";

                    }

                    col_name = col_name.Trim(',');
                    DbCommand dbCmd = dbHandler.SetCommandText(SchemaName + ".sp_insert_em", CommandType.StoredProcedure);
                    dbHandler.SetInParameter(dbCmd, "@para_table_name", DbType.String, SchemaName + ".tblrordetails");
                    dbHandler.SetInParameter(dbCmd, "@para_column_name", DbType.String, col_name);
                    dbHandler.SetInParameter(dbCmd, "@para_column_value", DbType.String, col_val);
                    dbHandler.SetInParameter(dbCmd, "@para_login_id", DbType.String, loginid);
                    dbHandler.SetInParameter(dbCmd, "@para_app_name", DbType.String, "reEdit");
                    dbHandler.SetOutParameter(dbCmd, "@para_id", DbType.Int32, 0);
                    int result = dbHandler.ExecuteNonQuery(dbCmd);


                }
                catch (Exception ex)
                {

                }
            }

        }

        public string funReturnSingleValue(string databaseName, string TableName, string ColValue, string Condition, string Orderby)
        {
            DataBaseHandler handler = new DataBaseHandler(databaseName, "Database Connection String");
            DataSet set = new DataSet();
            DbCommand command = handler.SelectCommandText(TableName, ColValue, Condition, Orderby);
            return handler.ExecuteScalarString(command);
        }

        public void funDeleteSROMutData(string DataBaseName, string SchemaName, string ccode, int mut_no)
        {
            DataBaseHandler dbhandler = new DataBaseHandler(DataBaseName, "LRSRO Connection StringMutation");

            string[] tablename = { "mutregister", "mut_kharedi", "mut_kharedi_seller", "mut_kharedi_buyer", "mut_kharedi_buyer_khata", "mut_kharedi_seller_khata", "mut_deal", "mut_other_rights" };
            for (int i = 0; i <= 7; i++)
            {
                DbCommand dbcommand = dbhandler.SetCommandText(SchemaName + ".sp_delete", CommandType.StoredProcedure);
                dbhandler.SetInParameter(dbcommand, "@para_table_name", DbType.String, SchemaName + "." + tablename[i]);
                dbhandler.SetInParameter(dbcommand, "@para_condition_column", DbType.String, "ccode='" + ccode + "' and mut_no=" + mut_no);
                dbhandler.SetOutParameter(dbcommand, "@para_id", DbType.Int32, 0);
                int check = dbhandler.ExecuteNonQuery(dbcommand);
                dbcommand.Parameters.Clear();
            }
        }

        public void funDeleteRecordSevarthID(string databaseName, string TableName, string Condition, string loginid, ref DbCommand dbCommand)
        {
            string[] table = { "mutregister", "mut_kharedi", "mut_kharedi_seller", "mut_kharedi_buyer", "mut_kharedi_buyer_khata", "mut_kharedi_seller_khata", "mut_deal", "mut_other_rights" };
            for (int i = 0; i <= 7; i++)
            {
                dbCommand.CommandText = TableName.Split('.')[0].ToString() + ".sp_delete_em";
                dbCommand.CommandType = CommandType.StoredProcedure;
                this.SetInParameter(dbCommand, "@para_table_name", DbType.String, TableName.Split('.')[0].ToString() + "." + table[i]);
                this.SetInParameter(dbCommand, "@para_condition_column", DbType.String, Condition);
                this.SetInParameter(dbCommand, "@para_login_id", DbType.String, loginid);
                this.SetInParameter(dbCommand, "@para_app_name", DbType.String, "reEdit");
                this.SetOutParameter(dbCommand, "@para_id", DbType.Int32, 0);
                int k = dbCommand.ExecuteNonQuery();
                dbCommand.Parameters.Clear();
            }
        }

        #endregion
    }
}
