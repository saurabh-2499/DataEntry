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
    public class clsVapratBadal
    {

        clscommonfunedit objclscommonfunedit = new clscommonfunedit();
        clsHistory objHistory = new clsHistory();


        int mflag = 0;
        int i4 = 0;
        objCertify history = new objCertify();
        DataSet ds = new DataSet();
        DataSet dsMutKharedi = new DataSet();
        DataSet dsMutKharediBuyer = new DataSet();
        DataSet dsMutOtherRights = new DataSet();
        string dsmuttype;
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet ds8a = new DataSet();
        DataSet flag = new DataSet();
        string loginid = string.Empty;

        public string certifyVapratBadal(objCertify vapratBadal, DbCommand dbCmd4)
        {
            
            
                vapratBadal.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(vapratBadal.Database, "LRSRO Connection StringMutation");

                loginid = objclscommonfunedit.funReturnSingleValue(vapratBadal.Database, vapratBadal.Schema + ".m_officermast", "username", "ccode='" + vapratBadal.Ccode + "' and user_type='2'", "");

                ds = objclscommonfunedit.funReturnDataSet(vapratBadal.Database, vapratBadal.Schema + ".mut_kharedi", " distinct * ", "mut_no=" + vapratBadal.Val + " and ccode = '" + vapratBadal.Ccode + "' and pin='" + vapratBadal.Pin + "' and pin1='" + vapratBadal.Pin1 + "' and pin2='" + vapratBadal.Pin2 + "' and pin3='" + vapratBadal.Pin3 + "' and pin4='" + vapratBadal.Pin4 + "' and pin5='" + vapratBadal.Pin5 + "' and pin6='" + vapratBadal.Pin6 + "' and pin7='" + vapratBadal.Pin7 + "' and pin8='" + vapratBadal.Pin8 + "' and  or_code3 =66", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {

                        history.Ccode = vapratBadal.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = vapratBadal.Schema;
                        history.Database = vapratBadal.Database;
                        history.Val = vapratBadal.Val;
                        history.User = vapratBadal.User;
                        objHistory.insertdata_history(history, dbCmd4);


                        ds1 = objclscommonfunedit.funReturnDataSet(vapratBadal.Database, vapratBadal.Schema + ".mut_kharedi_buyer", "distinct * ", "mut_no='" + vapratBadal.Val + "' and ccode = '" + vapratBadal.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=52", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValueSevarthID(vapratBadal.Database, vapratBadal.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + vapratBadal.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','" + ds1.Tables[0].Rows[k][41].ToString() + "','" + ds1.Tables[0].Rows[k][42] + "','" + ds1.Tables[0].Rows[k][40] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'", loginid, ref dbCmd4);
                        }
                      


                        flag = objclscommonfunedit.funReturnDataSet(vapratBadal.Database, vapratBadal.Schema + ".tblrordetails", "*", "mutationno='" + vapratBadal.Val + "' and ccode = '" + vapratBadal.Ccode + "' ", "");
                        foreach (DataRow dr in flag.Tables[0].Rows)
                        {
                            objclscommonfunedit.funUpdateValueSevarthID(vapratBadal.Database, vapratBadal.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + vapratBadal.Ccode + "' and  pin='" + flag.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + flag.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + flag.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + flag.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + flag.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + flag.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + flag.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + flag.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + flag.Tables[0].Rows[i]["pin8"].ToString() + "'", loginid, ref dbCmd4);
                        }


                        

                    }

                }
                if (vapratBadal.Flag == "true")
                {
                    objclscommonfunedit.funUpdateValueSevarthID(vapratBadal.Database, vapratBadal.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + vapratBadal.Ccode + "'and  mut_no=" + Convert.ToInt32(vapratBadal.Val) + " and pin='" + vapratBadal.Pin + "' and pin1='" + vapratBadal.Pin1 + "' and pin2='" + vapratBadal.Pin2 + "' and pin3='" + vapratBadal.Pin3 + "' and pin4='" + vapratBadal.Pin4 + "' and pin5='" + vapratBadal.Pin5 + "' and pin6='" + vapratBadal.Pin6 + "' and pin7='" + vapratBadal.Pin7 + "' and pin8='" + vapratBadal.Pin8 + "' ", loginid, ref dbCmd4);
                    //objclscommonfunedit.funUpdateValueSevarthID(vapratBadal.Database, vapratBadal.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + vapratBadal.Ccode + "'and mut_no=" + Convert.ToInt32(vapratBadal.Val) + "", loginid, ref dbCmd4);
                    objclscommonfunedit.funUpdateValueSevarthID(vapratBadal.Database, vapratBadal.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + vapratBadal.Ccode + "' AND mutationno=" + vapratBadal.Val + "", loginid, ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (vapratBadal.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + vapratBadal.Database;
                        QueryString += "&pin=" + vapratBadal.Pin;
                        QueryString += "&pin1=" + vapratBadal.Pin1;
                        QueryString += "&pin2=" + vapratBadal.Pin2;
                        QueryString += "&pin3=" + vapratBadal.Pin3;
                        QueryString += "&pin4=" + vapratBadal.Pin4;
                        QueryString += "&pin5=" + vapratBadal.Pin5;
                        QueryString += "&pin6=" + vapratBadal.Pin6;
                        QueryString += "&pin7=" + vapratBadal.Pin7;
                        QueryString += "&pin8=" + vapratBadal.Pin8;
                        QueryString += "&vcode=" + vapratBadal.Ccode;
                        QueryString += "&vname=" + vapratBadal.Vname;
                        QueryString += "&mschema=" + vapratBadal.Schema + "'";

                    }

                }








                return "true";
          

        }


        public string precertifyVapratBadal(objCertify vapratBadal, DbCommand dbCmd4)
        {
            
            
                vapratBadal.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(vapratBadal.Database, "LRSRO Connection StringMutation");


                ds = objclscommonfunedit.funReturnDataSet(vapratBadal.Database, vapratBadal.Schema + ".mut_kharedi", "*", "mut_no=" + vapratBadal.Val + " and ccode = '" + vapratBadal.Ccode + "'and  or_code3 =66", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {

                        history.Ccode = vapratBadal.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = vapratBadal.Schema;
                        history.Database = vapratBadal.Database;
                        history.Val = vapratBadal.Val;
                  


                        ds1 = objclscommonfunedit.funReturnDataSet(vapratBadal.Database, vapratBadal.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + vapratBadal.Val + "' and ccode = '" + vapratBadal.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=52", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValue(vapratBadal.Database, vapratBadal.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + vapratBadal.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','" + ds1.Tables[0].Rows[k][41].ToString() + "','" + ds1.Tables[0].Rows[k][42] + "','" + ds1.Tables[0].Rows[k][40] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'", ref dbCmd4);
                        }







                    }

                }
                if (vapratBadal.Flag == "true")
                {
                    //objclscommonfunedit.funUpdateValue(vapratBadal.Database, vapratBadal.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + vapratBadal.Ccode + "'and  mut_no=" + Convert.ToInt32(vapratBadal.Val) + "and remark='Itar-M'", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(vapratBadal.Database, vapratBadal.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + vapratBadal.Ccode + "'and mut_no=" + Convert.ToInt32(vapratBadal.Val) + "", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(vapratBadal.Database, vapratBadal.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + vapratBadal.Ccode + "' AND mutationno=" + vapratBadal.Val + "", ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (vapratBadal.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + vapratBadal.Database;
                        QueryString += "&pin=" + vapratBadal.Pin;
                        QueryString += "&pin1=" + vapratBadal.Pin1;
                        QueryString += "&pin2=" + vapratBadal.Pin2;
                        QueryString += "&pin3=" + vapratBadal.Pin3;
                        QueryString += "&pin4=" + vapratBadal.Pin4;
                        QueryString += "&pin5=" + vapratBadal.Pin5;
                        QueryString += "&pin6=" + vapratBadal.Pin6;
                        QueryString += "&pin7=" + vapratBadal.Pin7;
                        QueryString += "&pin8=" + vapratBadal.Pin8;
                        QueryString += "&vcode=" + vapratBadal.Ccode;
                        QueryString += "&vname=" + vapratBadal.Vname;
                        QueryString += "&mschema=" + vapratBadal.Schema + "'";

                    }

                }








                return "true";
          

        }


        public string talathi_certifyVapratBadal(objCertify vapratBadal, DbCommand dbCmd4)
        {
            
            
                vapratBadal.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(vapratBadal.Database, "LRSRO Connection StringMutation");

                loginid = objclscommonfunedit.funReturnSingleValue(vapratBadal.Database, vapratBadal.Schema + ".m_officermast", "username", "ccode='" + vapratBadal.Ccode + "' and user_type='1'", "");

                ds = objclscommonfunedit.funReturnDataSet(vapratBadal.Database, vapratBadal.Schema + ".verify_mut_kharedi", " distinct * ", "mut_no=" + vapratBadal.Val + " and ccode = '" + vapratBadal.Ccode + "' and pin='" + vapratBadal.Pin + "' and pin1='" + vapratBadal.Pin1 + "' and pin2='" + vapratBadal.Pin2 + "' and pin3='" + vapratBadal.Pin3 + "' and pin4='" + vapratBadal.Pin4 + "' and pin5='" + vapratBadal.Pin5 + "' and pin6='" + vapratBadal.Pin6 + "' and pin7='" + vapratBadal.Pin7 + "' and pin8='" + vapratBadal.Pin8 + "' and  or_code3 =66", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {                                           
                        
                        ds1 = objclscommonfunedit.funReturnDataSet(vapratBadal.Database, vapratBadal.Schema + ".verify_mut_kharedi_buyer", "distinct * ", "mut_no='" + vapratBadal.Val + "' and ccode = '" + vapratBadal.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=52", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValue(vapratBadal.Database, vapratBadal.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + vapratBadal.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','" + ds1.Tables[0].Rows[k][41].ToString() + "','" + ds1.Tables[0].Rows[k][42] + "','" + ds1.Tables[0].Rows[k][40] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'", ref dbCmd4);
                        }

                        //flag = objclscommonfunedit.funReturnDataSet(vapratBadal.Database, vapratBadal.Schema + ".tblrordetails", "*", "mutationno='" + vapratBadal.Val + "' and ccode = '" + vapratBadal.Ccode + "' ", "");
                        //foreach (DataRow dr in flag.Tables[0].Rows)
                        //{
                        //    objclscommonfunedit.funUpdateValueSevarthID(vapratBadal.Database, vapratBadal.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + vapratBadal.Ccode + "' and  pin='" + flag.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + flag.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + flag.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + flag.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + flag.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + flag.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + flag.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + flag.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + flag.Tables[0].Rows[i]["pin8"].ToString() + "'", loginid, ref dbCmd4);
                        //}
                    }
                }                

                return "true";
           
        }

    }

}