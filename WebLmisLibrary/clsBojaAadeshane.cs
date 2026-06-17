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
   public class clsBojaAadeshane
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
        DataSet ds8a = new DataSet();
        DataSet flag = new DataSet();
       string userid = "";
       public string certifyBojaAadeshane(objCertify bojaAadeshane, DbCommand dbCmd4)
        {
            
            
                bojaAadeshane.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(bojaAadeshane.Database, "LRSRO Connection StringMutation");

                ds = objclscommonfunedit.funReturnDataSet(bojaAadeshane.Database, bojaAadeshane.Schema + ".mut_kharedi", "*", "mut_no=" + bojaAadeshane.Val + " and ccode = '" + bojaAadeshane.Ccode + "' and pin='" + bojaAadeshane.Pin + "' and pin1='" + bojaAadeshane.Pin1 + "' and pin2='" + bojaAadeshane.Pin2 + "' and pin3='" + bojaAadeshane.Pin3 + "' and pin4='" + bojaAadeshane.Pin4 + "' and pin5='" + bojaAadeshane.Pin5 + "' and pin6='" + bojaAadeshane.Pin6 + "' and pin7='" + bojaAadeshane.Pin7 + "' and pin8='" + bojaAadeshane.Pin8 + "' and  or_code3 =66", "");
                userid = objclscommonfunedit.funReturnSingleValue(bojaAadeshane.Database, bojaAadeshane.Schema + ".m_officermast", "username", "ccode='" + bojaAadeshane.Ccode + "' and user_type='2'", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {

                        history.Ccode = bojaAadeshane.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = bojaAadeshane.Schema;
                        history.Database = bojaAadeshane.Database;
                        history.Val = bojaAadeshane.Val;
                        history.User = bojaAadeshane.User;
                        objHistory.insertdata_history(history, dbCmd4);


                        ds1 = objclscommonfunedit.funReturnDataSet(bojaAadeshane.Database, bojaAadeshane.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + bojaAadeshane.Val + "' and ccode = '" + bojaAadeshane.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                                //objclscommonfunedit.funInserSingleValue(bojaAadeshane.Database, bojaAadeshane.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + bojaAadeshane.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_code"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", ref dbCmd4);
                                objclscommonfunedit.funInserSingleValueSevarthID(bojaAadeshane.Database, bojaAadeshane.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + bojaAadeshane.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_code"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'",userid.Trim(), ref dbCmd4);
                    
                        }
                        flag = objclscommonfunedit.funReturnDataSet(bojaAadeshane.Database, bojaAadeshane.Schema + ".tblrordetails", "*", "mutationno='" + bojaAadeshane.Val + "' and ccode = '" + bojaAadeshane.Ccode + "' ", "");
                        foreach (DataRow dr in flag.Tables[0].Rows)
                        {
                            //objclscommonfunedit.funUpdateValue(bojaAadeshane.Database, bojaAadeshane.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + bojaAadeshane.Ccode + "' and  pin='" + flag.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + flag.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + flag.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + flag.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + flag.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + flag.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + flag.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + flag.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + flag.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                            objclscommonfunedit.funUpdateValueSevarthID(bojaAadeshane.Database, bojaAadeshane.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + bojaAadeshane.Ccode + "' and  pin='" + flag.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + flag.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + flag.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + flag.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + flag.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + flag.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + flag.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + flag.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + flag.Tables[0].Rows[i]["pin8"].ToString() + "'",userid.Trim(),ref dbCmd4);
                        }


                      

                    }

                }


                if (bojaAadeshane.Flag == "true")
                {
                    //objclscommonfunedit.funUpdateValue(bojaAadeshane.Database, bojaAadeshane.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + bojaAadeshane.Ccode + "'and  mut_no=" + Convert.ToInt32(bojaAadeshane.Val) + "and remark='Itar-M'", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(bojaAadeshane.Database, bojaAadeshane.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + bojaAadeshane.Ccode + "'and mut_no=" + Convert.ToInt32(bojaAadeshane.Val) + "", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(bojaAadeshane.Database, bojaAadeshane.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + bojaAadeshane.Ccode + "' AND mutationno=" + bojaAadeshane.Val + "", ref dbCmd4);


                    objclscommonfunedit.funUpdateValueSevarthID(bojaAadeshane.Database, bojaAadeshane.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + bojaAadeshane.Ccode + "'and  mut_no=" + Convert.ToInt32(bojaAadeshane.Val) + "and pin='" + bojaAadeshane.Pin + "' and pin1='" + bojaAadeshane.Pin1 + "' and pin2='" + bojaAadeshane.Pin2 + "' and pin3='" + bojaAadeshane.Pin3 + "' and pin4='" + bojaAadeshane.Pin4 + "' and pin5='" + bojaAadeshane.Pin5 + "' and pin6='" + bojaAadeshane.Pin6 + "' and pin7='" + bojaAadeshane.Pin7 + "' and pin8='" + bojaAadeshane.Pin8 + "'", userid, ref dbCmd4);
                    //objclscommonfunedit.funUpdateValueSevarthID(bojaAadeshane.Database, bojaAadeshane.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + bojaAadeshane.Ccode + "'and mut_no=" + Convert.ToInt32(bojaAadeshane.Val) + "",userid.Trim(), ref dbCmd4);
                    objclscommonfunedit.funUpdateValueSevarthID(bojaAadeshane.Database, bojaAadeshane.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + bojaAadeshane.Ccode + "' AND mutationno=" + bojaAadeshane.Val + "",userid.Trim(), ref dbCmd4);
                   
                    
                    
                    
                    
                    
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (bojaAadeshane.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + bojaAadeshane.Database;
                        QueryString += "&pin=" + bojaAadeshane.Pin;
                        QueryString += "&pin1=" + bojaAadeshane.Pin1;
                        QueryString += "&pin2=" + bojaAadeshane.Pin2;
                        QueryString += "&pin3=" + bojaAadeshane.Pin3;
                        QueryString += "&pin4=" + bojaAadeshane.Pin4;
                        QueryString += "&pin5=" + bojaAadeshane.Pin5;
                        QueryString += "&pin6=" + bojaAadeshane.Pin6;
                        QueryString += "&pin7=" + bojaAadeshane.Pin7;
                        QueryString += "&pin8=" + bojaAadeshane.Pin8;
                        QueryString += "&vcode=" + bojaAadeshane.Ccode;
                        QueryString += "&vname=" + bojaAadeshane.Vname;
                        QueryString += "&mschema=" + bojaAadeshane.Schema + "'";

                    }

                }

                return "true";
           

        }



       public string precertifyBojaAadeshane(objCertify bojaAadeshane, DbCommand dbCmd4)
        {
            
           

                bojaAadeshane.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(bojaAadeshane.Database, "LRSRO Connection StringMutation");


                ds = objclscommonfunedit.funReturnDataSet(bojaAadeshane.Database, bojaAadeshane.Schema + ".mut_kharedi", "*", "mut_no=" + bojaAadeshane.Val + " and ccode = '" + bojaAadeshane.Ccode + "'and  or_code3 =66", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        ds1 = objclscommonfunedit.funReturnDataSet(bojaAadeshane.Database, bojaAadeshane.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + bojaAadeshane.Val + "' and ccode = '" + bojaAadeshane.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValue(bojaAadeshane.Database, bojaAadeshane.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + bojaAadeshane.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','" + ds1.Tables[0].Rows[k][41].ToString() + "','" + ds1.Tables[0].Rows[k][42] + "','" + ds1.Tables[0].Rows[k][40] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'", ref dbCmd4);
                        }
                        history.Ccode = bojaAadeshane.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = bojaAadeshane.Schema;
                        history.Database = bojaAadeshane.Database;


                       


                       

                    }

                }


                if (bojaAadeshane.Flag == "true")
                {
                    //objclscommonfunedit.funUpdateValue(bojaAadeshane.Database, bojaAadeshane.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + bojaAadeshane.Ccode + "'and  mut_no=" + Convert.ToInt32(bojaAadeshane.Val) + "and remark='Itar-M'", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(bojaAadeshane.Database, bojaAadeshane.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + bojaAadeshane.Ccode + "'and mut_no=" + Convert.ToInt32(bojaAadeshane.Val) + "", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(bojaAadeshane.Database, bojaAadeshane.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + bojaAadeshane.Ccode + "' AND mutationno=" + bojaAadeshane.Val + "", ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (bojaAadeshane.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + bojaAadeshane.Database;
                        QueryString += "&pin=" + bojaAadeshane.Pin;
                        QueryString += "&pin1=" + bojaAadeshane.Pin1;
                        QueryString += "&pin2=" + bojaAadeshane.Pin2;
                        QueryString += "&pin3=" + bojaAadeshane.Pin3;
                        QueryString += "&pin4=" + bojaAadeshane.Pin4;
                        QueryString += "&pin5=" + bojaAadeshane.Pin5;
                        QueryString += "&pin6=" + bojaAadeshane.Pin6;
                        QueryString += "&pin7=" + bojaAadeshane.Pin7;
                        QueryString += "&pin8=" + bojaAadeshane.Pin8;
                        QueryString += "&vcode=" + bojaAadeshane.Ccode;
                        QueryString += "&vname=" + bojaAadeshane.Vname;
                        QueryString += "&mschema=" + bojaAadeshane.Schema + "'";

                    }

                }

                return "true";
           

        }
    }
}
