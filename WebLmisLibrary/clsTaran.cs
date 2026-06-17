//1. 11012016 tblrordetails survey wise update
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
   public class clsTaran
    {
        clscommonfunedit objclscommonfunedit = new clscommonfunedit();
        clsHistory objHistory = new clsHistory();      
        objCertify history = new objCertify();
        DataSet ds = new DataSet();
        DataSet dsMutKharedi = new DataSet();
        DataSet dsMutKharediBuyer = new DataSet();
        DataSet dsMutOtherRights = new DataSet();       
        DataSet ds1 = new DataSet();
        DataSet ds8a = new DataSet();
       string loginid = string.Empty;

       public string certifyTaran(objCertify taran, DbCommand dbCmd4)
        {
            
          
                taran.Flag = "true";
                
                DataBaseHandler dbHandler = new DataBaseHandler(taran.Database, "LRSRO Connection StringMutation");

                loginid = objclscommonfunedit.funReturnSingleValue(taran.Database, taran.Schema + ".m_officermast", "username", "ccode='" + taran.Ccode + "' and user_type='2'", "");

                ds = objclscommonfunedit.funReturnDataSet(taran.Database, taran.Schema + ".mut_kharedi", "*", "mut_no=" + taran.Val + " and ccode = '" + taran.Ccode + "' and pin='" + taran.Pin + "' and pin1='" + taran.Pin1 + "' and pin2='" + taran.Pin2 + "' and pin3='" + taran.Pin3 + "' and pin4='" + taran.Pin4 + "' and pin5='" + taran.Pin5 + "' and pin6='" + taran.Pin6 + "' and pin7='" + taran.Pin7 + "' and pin8='" + taran.Pin8 + "' and  or_code3 =66", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        history.Ccode = taran.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = taran.Schema;
                        history.Database = taran.Database;
                        history.Val = taran.Val;
                        history.User = taran.User;
                        objHistory.insertdata_history(history, dbCmd4);

                        ds1 = objclscommonfunedit.funReturnDataSet(taran.Database, taran.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + taran.Val + "' and ccode = '" + taran.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValueSevarthID(taran.Database, taran.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + taran.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','104','1','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", loginid, ref dbCmd4);
                    
                        }
                       
                        
                    }

                }


                if (taran.Flag == "true")
                {
                    objclscommonfunedit.funUpdateValueSevarthID(taran.Database, taran.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + taran.Ccode + "'and  mut_no=" + Convert.ToInt32(taran.Val) + " and pin='" + taran.Pin + "' and pin1='" + taran.Pin1 + "' and pin2='" + taran.Pin2 + "' and pin3='" + taran.Pin3 + "' and pin4='" + taran.Pin4 + "' and pin5='" + taran.Pin5 + "' and pin6='" + taran.Pin6 + "' and pin7='" + taran.Pin7 + "' and pin8='" + taran.Pin8 + "'", loginid, ref dbCmd4);
                    //objclscommonfunedit.funUpdateValueSevarthID(taran.Database, taran.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + taran.Ccode + "'and mut_no=" + Convert.ToInt32(taran.Val) + "", loginid, ref dbCmd4);
                    //1. 11012016 tblrordetails survey wise update
                    objclscommonfunedit.funUpdateValueSevarthID(taran.Database, taran.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + taran.Ccode + "' AND mutationno=" + taran.Val + " and pin='" + taran.Pin + "' and pin1='" + taran.Pin1 + "' and pin2='" + taran.Pin2 + "' and pin3='" + taran.Pin3 + "' and pin4='" + taran.Pin4 + "' and pin5='" + taran.Pin5 + "' and pin6='" + taran.Pin6 + "' and pin7='" + taran.Pin7 + "' and pin8='" + taran.Pin8 + "'", loginid, ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (taran.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + taran.Database;
                        QueryString += "&pin=" + taran.Pin;
                        QueryString += "&pin1=" + taran.Pin1;
                        QueryString += "&pin2=" + taran.Pin2;
                        QueryString += "&pin3=" + taran.Pin3;
                        QueryString += "&pin4=" + taran.Pin4;
                        QueryString += "&pin5=" + taran.Pin5;
                        QueryString += "&pin6=" + taran.Pin6;
                        QueryString += "&pin7=" + taran.Pin7;
                        QueryString += "&pin8=" + taran.Pin8;
                        QueryString += "&vcode=" + taran.Ccode;
                        QueryString += "&vname=" + taran.Vname;
                        QueryString += "&mschema=" + taran.Schema + "'";

                    }

                }

                return "true";
           

        }

       public string precertifyTaran(objCertify taran, DbCommand dbCmd4)
       {
           
              taran.Flag = "true";

               DataBaseHandler dbHandler = new DataBaseHandler(taran.Database, "LRSRO Connection StringMutation");




               ds = objclscommonfunedit.funReturnDataSet(taran.Database, taran.Schema + ".mut_kharedi", "*", "mut_no=" + taran.Val + " and ccode = '" + taran.Ccode + "'and  or_code3 =66", "");

               if (ds.Tables[0].Rows.Count > 0)
               {
                   for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                   {
                       ds1 = objclscommonfunedit.funReturnDataSet(taran.Database, taran.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + taran.Val + "' and ccode = '" + taran.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                       if (ds1.Tables[0].Rows.Count > 0)
                       {
                           for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                               objclscommonfunedit.funInserSingleValue(taran.Database, taran.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + taran.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','104','1','" + ds1.Tables[0].Rows[k][40] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'", ref dbCmd4);
                       }
                       history.Ccode = taran.Ccode;
                       history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                       history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                       history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                       history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                       history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                       history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                       history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                       history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                       history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                       history.Schema = taran.Schema;
                       history.Database = taran.Database;

                    
//
                   }

               }


               if (taran.Flag == "true")
               {
                   //objclscommonfunedit.funUpdateValue(taran.Database, taran.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + taran.Ccode + "'and  mut_no=" + Convert.ToInt32(taran.Val) + "and remark='Itar-M'", ref dbCmd4);
                   //objclscommonfunedit.funUpdateValue(taran.Database, taran.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + taran.Ccode + "'and mut_no=" + Convert.ToInt32(taran.Val) + "", ref dbCmd4);
                   // objclscommonfunedit.funUpdateValue(taran.Database, taran.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + taran.Ccode + "' AND mutationno=" + taran.Val + "", ref dbCmd4);
                   // Application["view"] = "1";
                   // Session["CircleClick"] = "1";

                   if (taran.Mut_type != "9")
                   {
                       string QueryString = "";
                       QueryString += "'pg712.aspx?DatabaseName=" + taran.Database;
                       QueryString += "&pin=" + taran.Pin;
                       QueryString += "&pin1=" + taran.Pin1;
                       QueryString += "&pin2=" + taran.Pin2;
                       QueryString += "&pin3=" + taran.Pin3;
                       QueryString += "&pin4=" + taran.Pin4;
                       QueryString += "&pin5=" + taran.Pin5;
                       QueryString += "&pin6=" + taran.Pin6;
                       QueryString += "&pin7=" + taran.Pin7;
                       QueryString += "&pin8=" + taran.Pin8;
                       QueryString += "&vcode=" + taran.Ccode;
                       QueryString += "&vname=" + taran.Vname;
                       QueryString += "&mschema=" + taran.Schema + "'";

                   }

               }

               return "true";
          

       }

       public string talathi_certifyTaran(objCertify taran, DbCommand dbCmd4)
       {
           
          
               taran.Flag = "true";

               DataBaseHandler dbHandler = new DataBaseHandler(taran.Database, "LRSRO Connection StringMutation");

               loginid = objclscommonfunedit.funReturnSingleValue(taran.Database, taran.Schema + ".m_officermast", "username", "ccode='" + taran.Ccode + "' and user_type='1'", "");

               ds = objclscommonfunedit.funReturnDataSet(taran.Database, taran.Schema + ".verify_mut_kharedi", "*", "mut_no=" + taran.Val + " and ccode = '" + taran.Ccode + "' and pin='" + taran.Pin + "' and pin1='" + taran.Pin1 + "' and pin2='" + taran.Pin2 + "' and pin3='" + taran.Pin3 + "' and pin4='" + taran.Pin4 + "' and pin5='" + taran.Pin5 + "' and pin6='" + taran.Pin6 + "' and pin7='" + taran.Pin7 + "' and pin8='" + taran.Pin8 + "' and  or_code3 =66", "");

               if (ds.Tables[0].Rows.Count > 0)
               {
                   for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                   {                    
                       ds1 = objclscommonfunedit.funReturnDataSet(taran.Database, taran.Schema + ".verify_mut_kharedi_buyer", "*", "mut_no='" + taran.Val + "' and ccode = '" + taran.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                       if (ds1.Tables[0].Rows.Count > 0)
                       {
                           for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                               objclscommonfunedit.funInserSingleValue(taran.Database, taran.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + taran.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','104','1','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", ref dbCmd4);
                       }
                   }
               }         

               return "true";
          

       }
    
    }
}
