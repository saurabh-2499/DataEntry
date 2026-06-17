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
    public  class cls712ColseOpen
    {
        clscommonfunedit objclscommonfunedit = new clscommonfunedit();
        clsHistory objHistory = new clsHistory();
        objCertify history = new objCertify();
        string loginid = string.Empty;

        public string certifyCloseOpen(objCertify openclose, DbCommand dbCmd4)
        {

            openclose.Flag = "true";

            DataBaseHandler dbHandler = new DataBaseHandler(openclose.Database, "LRSRO Connection StringMutation");
            loginid = objclscommonfunedit.funReturnSingleValue(openclose.Database, openclose.Schema + ".m_officermast", "username", "ccode='" + openclose.Ccode + "' and user_type='2'", "");

            DataSet DS_MK = objclscommonfunedit.funReturnDataSet(openclose.Database, openclose.Schema + ".mut_kharedi", "*", "mut_no=" + openclose.Val + " and ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and or_code3='75'", "");
            if (DS_MK != null && DS_MK.Tables.Count > 0 && DS_MK.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i <= DS_MK.Tables[0].Rows.Count - 1; i++)
                {
                    history.Ccode = openclose.Ccode;
                    history.Pin = DS_MK.Tables[0].Rows[i]["pin"].ToString();
                    history.Pin1 = DS_MK.Tables[0].Rows[i]["pin1"].ToString();
                    history.Pin2 = DS_MK.Tables[0].Rows[i]["pin2"].ToString();
                    history.Pin3 = DS_MK.Tables[0].Rows[i]["pin3"].ToString();
                    history.Pin4 = DS_MK.Tables[0].Rows[i]["pin4"].ToString();
                    history.Pin5 = DS_MK.Tables[0].Rows[i]["pin5"].ToString();
                    history.Pin6 = DS_MK.Tables[0].Rows[i]["pin6"].ToString();
                    history.Pin7 = DS_MK.Tables[0].Rows[i]["pin7"].ToString();
                    history.Pin8 = DS_MK.Tables[0].Rows[i]["pin8"].ToString();
                    history.Schema = openclose.Schema;
                    history.Database = openclose.Database;
                    history.Val = openclose.Val;
                    history.User = openclose.User;
                    objHistory.insertdata_history(history, dbCmd4);
                }
                objclscommonfunedit.funUpdateValueSevarthID(openclose.Database, openclose.Schema + ".form7", "marked='', old_mut_no=mut_no, mut_no='" + openclose.Val + "'", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "'", loginid, ref dbCmd4);
                DataSet DS_MKB = objclscommonfunedit.funReturnDataSet(openclose.Database, openclose.Schema + ".mut_kharedi_buyer", "*", "mut_no=" + openclose.Val + " and ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and buyer_doc_type1='75'", "");
                if (DS_MKB != null && DS_MKB.Tables.Count > 0 && DS_MKB.Tables[0].Rows.Count > 0)
                {

                    int mut_no = objclscommonfunedit.funReturnSingleValueInt(openclose.Database, openclose.Schema + ".form7_khata", "mut_no", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and khata_no='500001'", "");
                    int cnt_mut_no = objclscommonfunedit.funReturnSingleValueInt(openclose.Database, openclose.Schema + ".form7_mut_no", "count(*)", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and mutation_no='" + mut_no + "'", "");
                    if (cnt_mut_no == 0)
                    {
                        objclscommonfunedit.funInserSingleValueSevarthID(openclose.Database, openclose.Schema + ".form7_mut_no", "ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,mut_no,mutation_no", "'" + openclose.Ccode + "','" + openclose.Pin + "', '" + openclose.Pin1 + "','" + openclose.Pin2 + "' ,'" + openclose.Pin3 + "' ,'" + openclose.Pin4 + "' ,'" + openclose.Pin5 + "' ,'" + openclose.Pin6 + "' ,'" + openclose.Pin7 + "','" + openclose.Pin8 + "','" + openclose.Val + "','" + openclose.Val + "'", loginid, ref dbCmd4);
                    }

                    objclscommonfunedit.funDeleteRecordSevarthID(openclose.Database, openclose.Schema + ".form7_khata", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and khata_no='500001'", loginid, ref dbCmd4);
                    for (int i = 0; i < DS_MKB.Tables[0].Rows.Count; i++)
                    {
                        objclscommonfunedit.funUpdateValueSevarthID(openclose.Database, openclose.Schema + ".form7_khata", "marked='' ", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and trim(fname)='" + DS_MKB.Tables[0].Rows[i]["fname"].ToString().Trim() + "'  and trim(mname)='" + DS_MKB.Tables[0].Rows[i]["mname"].ToString().Trim() + "' and trim(lname)='" + DS_MKB.Tables[0].Rows[i]["lname"].ToString().Trim() + "' and trim(topan_name)='" + DS_MKB.Tables[0].Rows[i]["topan_name"].ToString().Trim() + "'", loginid, ref dbCmd4);
                    }
                }
                objclscommonfunedit.funUpdateValueSevarthID(openclose.Database, openclose.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + openclose.Ccode + "' and mutationno=" + openclose.Val + " and  pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "'   ", loginid, ref dbCmd4);
                objclscommonfunedit.funUpdateValueSevarthID(openclose.Database, openclose.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + openclose.Ccode + "'and  mut_no=" + Convert.ToInt32(openclose.Val) + " and   pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "'", loginid, ref dbCmd4);
                objclscommonfunedit.funUpdateValueSevarthID(openclose.Database, openclose.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + openclose.Ccode + "' and mut_no=" + Convert.ToInt32(openclose.Val) + " ", loginid, ref dbCmd4);
            }
            return "true";
        }


        public string pre_CloseOpen(objCertify openclose, DbCommand dbCmd4)
        {

            DataBaseHandler dbHandler = new DataBaseHandler(openclose.Database, "LRSRO Connection StringMutation");
            loginid = objclscommonfunedit.funReturnSingleValue(openclose.Database, openclose.Schema + ".m_officermast", "username", "ccode='" + openclose.Ccode + "' and user_type='2'", "");

            DataSet DS_MK = objclscommonfunedit.funReturnDataSet(openclose.Database, openclose.Schema + ".mut_kharedi", "*", "mut_no=" + openclose.Val + " and ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and or_code3='75'", "");
            if (DS_MK != null && DS_MK.Tables.Count > 0 && DS_MK.Tables[0].Rows.Count > 0)
            {
                objclscommonfunedit.funUpdateValue(openclose.Database, openclose.Schema + ".pre_form7", "marked='', old_mut_no=mut_no, mut_no='" + openclose.Val + "'", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "'", ref dbCmd4);
                DataSet DS_MKB = objclscommonfunedit.funReturnDataSet(openclose.Database, openclose.Schema + ".mut_kharedi_buyer", "*", "mut_no=" + openclose.Val + " and ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and buyer_doc_type1='75'", "");
                if (DS_MKB != null && DS_MKB.Tables.Count > 0 && DS_MKB.Tables[0].Rows.Count > 0)
                {
                    int mut_no = objclscommonfunedit.funReturnSingleValueInt(openclose.Database, openclose.Schema + ".pre_form7_khata", "mut_no", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and khata_no='500001'", "");
                    int cnt_mut_no = objclscommonfunedit.funReturnSingleValueInt(openclose.Database, openclose.Schema + ".pre_form7_mut_no", "count(*)", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and mutation_no='" + mut_no + "'", "");
                    if (cnt_mut_no == 0)
                    {
                        objclscommonfunedit.funInserSingleValue(openclose.Database, openclose.Schema + ".pre_form7_mut_no", "ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,mut_no,mutation_no", "'" + openclose.Ccode + "','" + openclose.Pin + "', '" + openclose.Pin1 + "','" + openclose.Pin2 + "' ,'" + openclose.Pin3 + "' ,'" + openclose.Pin4 + "' ,'" + openclose.Pin5 + "' ,'" + openclose.Pin6 + "' ,'" + openclose.Pin7 + "','" + openclose.Pin8 + "','" + openclose.Val + "','" + openclose.Val + "'", ref dbCmd4);
                    }

                    objclscommonfunedit.funDeleteRecord(openclose.Database, openclose.Schema + ".pre_form7_khata", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and khata_no='500001'", ref dbCmd4);
                    for (int i = 0; i < DS_MKB.Tables[0].Rows.Count; i++)
                    {
                        objclscommonfunedit.funUpdateValue(openclose.Database, openclose.Schema + ".pre_form7_khata", "marked='' ", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and trim(fname)='" + DS_MKB.Tables[0].Rows[i]["fname"].ToString().Trim() + "'  and trim(mname)='" + DS_MKB.Tables[0].Rows[i]["mname"].ToString().Trim() + "' and trim(lname)='" + DS_MKB.Tables[0].Rows[i]["lname"].ToString().Trim() + "' and trim(topan_name)='" + DS_MKB.Tables[0].Rows[i]["topan_name"].ToString().Trim() + "'", ref dbCmd4);
                    }
                }

            }
            return "true";
        }

        public string pre_th_CloseOpen(objCertify openclose, DbCommand dbCmd4)
        {

            DataBaseHandler dbHandler = new DataBaseHandler(openclose.Database, "LRSRO Connection StringMutation");
            loginid = objclscommonfunedit.funReturnSingleValue(openclose.Database, openclose.Schema + ".m_officermast", "username", "ccode='" + openclose.Ccode + "' and user_type='2'", "");

            DataSet DS_MK = objclscommonfunedit.funReturnDataSet(openclose.Database, openclose.Schema + ".verify_mut_kharedi", "*", "mut_no=" + openclose.Val + " and ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and or_code3='75'", "");
            if (DS_MK != null && DS_MK.Tables.Count > 0 && DS_MK.Tables[0].Rows.Count > 0)
            {
                objclscommonfunedit.funUpdateValue(openclose.Database, openclose.Schema + ".pre_form7", "marked='', old_mut_no=mut_no, mut_no='" + openclose.Val + "'", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "'", ref dbCmd4);
                DataSet DS_MKB = objclscommonfunedit.funReturnDataSet(openclose.Database, openclose.Schema + ".verify_mut_kharedi_buyer", "*", "mut_no=" + openclose.Val + " and ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and buyer_doc_type1='75'", "");
                if (DS_MKB != null && DS_MKB.Tables.Count > 0 && DS_MKB.Tables[0].Rows.Count > 0)
                {
                    int mut_no = objclscommonfunedit.funReturnSingleValueInt(openclose.Database, openclose.Schema + ".pre_form7_khata", "mut_no", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and khata_no='500001'", "");
                    int cnt_mut_no = objclscommonfunedit.funReturnSingleValueInt(openclose.Database, openclose.Schema + ".pre_form7_mut_no", "count(*)", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and mutation_no='" + mut_no + "'", "");
                    if (cnt_mut_no == 0)
                    {
                        objclscommonfunedit.funInserSingleValue(openclose.Database, openclose.Schema + ".pre_form7_mut_no", "ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,mut_no,mutation_no", "'" + openclose.Ccode + "','" + openclose.Pin + "', '" + openclose.Pin1 + "','" + openclose.Pin2 + "' ,'" + openclose.Pin3 + "' ,'" + openclose.Pin4 + "' ,'" + openclose.Pin5 + "' ,'" + openclose.Pin6 + "' ,'" + openclose.Pin7 + "','" + openclose.Pin8 + "','" + openclose.Val + "','" + openclose.Val + "'", ref dbCmd4);
                    }

                    objclscommonfunedit.funDeleteRecord(openclose.Database, openclose.Schema + ".pre_form7_khata", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and khata_no='500001'", ref dbCmd4);
                    for (int i = 0; i < DS_MKB.Tables[0].Rows.Count; i++)
                    {
                        objclscommonfunedit.funUpdateValue(openclose.Database, openclose.Schema + ".pre_form7_khata", "marked='' ", "ccode = '" + openclose.Ccode + "' and pin='" + openclose.Pin + "' and pin1='" + openclose.Pin1 + "' and  pin2='" + openclose.Pin2 + "' and pin3='" + openclose.Pin3 + "' and pin4='" + openclose.Pin4 + "' and pin5='" + openclose.Pin5 + "' and pin6='" + openclose.Pin6 + "'  and pin7='" + openclose.Pin7 + "' and pin8 ='" + openclose.Pin8 + "' and trim(fname)='" + DS_MKB.Tables[0].Rows[i]["fname"].ToString().Trim() + "'  and trim(mname)='" + DS_MKB.Tables[0].Rows[i]["mname"].ToString().Trim() + "' and trim(lname)='" + DS_MKB.Tables[0].Rows[i]["lname"].ToString().Trim() + "' and trim(topan_name)='" + DS_MKB.Tables[0].Rows[i]["topan_name"].ToString().Trim() + "'", ref dbCmd4);
                    }
                }

            }
            return "true";
        }


    }
    
}
