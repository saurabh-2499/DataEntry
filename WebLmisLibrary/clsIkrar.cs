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
   public class clsIkrar
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
        int i4 = 0;
       string loginid = string.Empty;


       public string certifyIkrar(objCertify ikrar, DbCommand dbCmd4)
        {
            
           
                ikrar.Flag = "true";
               
                DataBaseHandler dbHandler = new DataBaseHandler(ikrar.Database, "LRSRO Connection StringMutation");

                loginid = objclscommonfunedit.funReturnSingleValue(ikrar.Database, ikrar.Schema + ".m_officermast", "username", "ccode='" + ikrar.Ccode + "' and user_type='2'", "");


                ds = objclscommonfunedit.funReturnDataSet(ikrar.Database, ikrar.Schema + ".mut_kharedi", "distinct *", "mut_no=" + ikrar.Val + " and ccode = '" + ikrar.Ccode + "' and pin='" + ikrar.Pin + "' and pin1='" + ikrar.Pin1 + "' and pin2='" + ikrar.Pin2 + "' and pin3='" + ikrar.Pin3 + "' and pin4='" + ikrar.Pin4 + "' and pin5='" + ikrar.Pin5 + "' and pin6='" + ikrar.Pin6 + "' and pin7='" + ikrar.Pin7 + "' and pin8='" + ikrar.Pin8 + "' and  or_code3 =66", "");

                if (ds.Tables[0].Rows.Count > 0)
                {

                   
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {

                        history.Ccode = ikrar.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = ikrar.Schema;
                        history.Database = ikrar.Database;
                        history.Val = ikrar.Val;
                        history.User = ikrar.User;
                        objHistory.insertdata_history(history, dbCmd4);

                        ds1 = objclscommonfunedit.funReturnDataSet(ikrar.Database, ikrar.Schema + ".mut_kharedi_buyer", "distinct *", "mut_no='" + ikrar.Val + "' and ccode = '" + ikrar.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                           
                                  //objclscommonfunedit.funInserSingleValueSevarthID(ikrar.Database, ikrar.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + ikrar.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_code"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", loginid, ref dbCmd4);
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                            {
                                int count = objclscommonfunedit.funReturnSingleValueInt(ikrar.Database, ikrar.Schema + ".form7_orights", "Count(*)", "ccode='" + ikrar.Ccode + "' and pin='" + ds1.Tables[0].Rows[k]["pin"].ToString() + "' and pin1='" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "' and pin2='" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "' and pin3='" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' and pin4='" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' and pin5='" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' and pin6='" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' and  pin7='" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' and pin8='" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "' and mut_no=" + Convert.ToString(ds1.Tables[0].Rows[k]["mut_no"]) + " and other_rights_code='12' and other_rights_sub_code='2' and tenant_name='" + ds1.Tables[0].Rows[k]["buyer_name"] + "' and usrno='" + ds1.Tables[0].Rows[k]["usrno"] + "'", "");
                                if (count == 0)
                                {
                                    objclscommonfunedit.funInserSingleValueSevarthID(ikrar.Database, ikrar.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + ikrar.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','12','2','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", loginid, ref dbCmd4);
                                }
                                }
                        }
                        

                    }

                }


                if (ikrar.Flag == "true")
                {
                    objclscommonfunedit.funUpdateValueSevarthID(ikrar.Database, ikrar.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + ikrar.Ccode + "'and  mut_no=" + Convert.ToInt32(ikrar.Val) + " and pin='" + ikrar.Pin + "' and pin1='" + ikrar.Pin1 + "' and pin2='" + ikrar.Pin2 + "' and pin3='" + ikrar.Pin3 + "' and pin4='" + ikrar.Pin4 + "' and pin5='" + ikrar.Pin5 + "' and pin6='" + ikrar.Pin6 + "' and pin7='" + ikrar.Pin7 + "' and pin8='" + ikrar.Pin8 + "'  and remark='Itar-M'", loginid, ref dbCmd4);
                    //objclscommonfunedit.funUpdateValueSevarthID(ikrar.Database, ikrar.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + ikrar.Ccode + "'and mut_no=" + Convert.ToInt32(ikrar.Val) + "", loginid, ref dbCmd4);
                    objclscommonfunedit.funUpdateValueSevarthID(ikrar.Database, ikrar.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + ikrar.Ccode + "' AND mutationno=" + ikrar.Val + "  and pin='" + ikrar.Pin + "' and pin1='" + ikrar.Pin1 + "' and pin2='" + ikrar.Pin2 + "' and pin3='" + ikrar.Pin3 + "' and pin4='" + ikrar.Pin4 + "' and pin5='" + ikrar.Pin5 + "' and pin6='" + ikrar.Pin6 + "' and pin7='" + ikrar.Pin7 + "' and pin8='" + ikrar.Pin8 + "'", loginid, ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (ikrar.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + ikrar.Database;
                        QueryString += "&pin=" + ikrar.Pin;
                        QueryString += "&pin1=" + ikrar.Pin1;
                        QueryString += "&pin2=" + ikrar.Pin2;
                        QueryString += "&pin3=" + ikrar.Pin3;
                        QueryString += "&pin4=" + ikrar.Pin4;
                        QueryString += "&pin5=" + ikrar.Pin5;
                        QueryString += "&pin6=" + ikrar.Pin6;
                        QueryString += "&pin7=" + ikrar.Pin7;
                        QueryString += "&pin8=" + ikrar.Pin8;
                        QueryString += "&vcode=" + ikrar.Ccode;
                        QueryString += "&vname=" + ikrar.Vname;
                        QueryString += "&mschema=" + ikrar.Schema + "'";

                    }

                }

                return "true";
           

        }

       public string precertifyIkrar(objCertify ikrar, DbCommand dbCmd4)
       {
           
           
               ikrar.Flag = "true";

               DataBaseHandler dbHandler = new DataBaseHandler(ikrar.Database, "LRSRO Connection StringMutation");




               ds = objclscommonfunedit.funReturnDataSet(ikrar.Database, ikrar.Schema + ".mut_kharedi", "*", "mut_no=" + ikrar.Val + " and ccode = '" + ikrar.Ccode + "'and  or_code3 =66", "");

               if (ds.Tables[0].Rows.Count > 0)
               {
                   for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                   {
                       ds1 = objclscommonfunedit.funReturnDataSet(ikrar.Database, ikrar.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + ikrar.Val + "' and ccode = '" + ikrar.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                       if (ds1.Tables[0].Rows.Count > 0)
                       {
                           for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                               objclscommonfunedit.funInserSingleValue(ikrar.Database, ikrar.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + ikrar.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','12','2','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", ref dbCmd4);
                       }
                       history.Ccode = ikrar.Ccode;
                       history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                       history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                       history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                       history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                       history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                       history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                       history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                       history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                       history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                       history.Schema = ikrar.Schema;
                       history.Database = ikrar.Database;

                      

                   }

               }


               if (ikrar.Flag == "true")
               {
                   //objclscommonfunedit.funUpdateValue(ikrar.Database, ikrar.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + ikrar.Ccode + "'and  mut_no=" + Convert.ToInt32(ikrar.Val) + "and remark='Itar-M'", ref dbCmd4);
                   //objclscommonfunedit.funUpdateValue(ikrar.Database, ikrar.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + ikrar.Ccode + "'and mut_no=" + Convert.ToInt32(ikrar.Val) + "", ref dbCmd4);
                   // objclscommonfunedit.funUpdateValue(ikrar.Database, ikrar.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + ikrar.Ccode + "' AND mutationno=" + ikrar.Val + "", ref dbCmd4);
                   // Application["view"] = "1";
                   // Session["CircleClick"] = "1";

                   if (ikrar.Mut_type != "9")
                   {
                       string QueryString = "";
                       QueryString += "'pg712.aspx?DatabaseName=" + ikrar.Database;
                       QueryString += "&pin=" + ikrar.Pin;
                       QueryString += "&pin1=" + ikrar.Pin1;
                       QueryString += "&pin2=" + ikrar.Pin2;
                       QueryString += "&pin3=" + ikrar.Pin3;
                       QueryString += "&pin4=" + ikrar.Pin4;
                       QueryString += "&pin5=" + ikrar.Pin5;
                       QueryString += "&pin6=" + ikrar.Pin6;
                       QueryString += "&pin7=" + ikrar.Pin7;
                       QueryString += "&pin8=" + ikrar.Pin8;
                       QueryString += "&vcode=" + ikrar.Ccode;
                       QueryString += "&vname=" + ikrar.Vname;
                       QueryString += "&mschema=" + ikrar.Schema + "'";

                   }

               }

               return "true";
          

       }

       public string talathi_certifyIkrar(objCertify ikrar, DbCommand dbCmd4)
       {
           
          
               ikrar.Flag = "true";

               DataBaseHandler dbHandler = new DataBaseHandler(ikrar.Database, "LRSRO Connection StringMutation");

               loginid = objclscommonfunedit.funReturnSingleValue(ikrar.Database, ikrar.Schema + ".m_officermast", "username", "ccode='" + ikrar.Ccode + "' and user_type='1'", "");


               ds = objclscommonfunedit.funReturnDataSet(ikrar.Database, ikrar.Schema + ".verify_mut_kharedi", "*", "mut_no=" + ikrar.Val + " and ccode = '" + ikrar.Ccode + "'and  or_code3 =66", "");

               if (ds.Tables[0].Rows.Count > 0)
               {

                   for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                   {

                       ds1 = objclscommonfunedit.funReturnDataSet(ikrar.Database, ikrar.Schema + ".verify_mut_kharedi_buyer", "*", "mut_no='" + ikrar.Val + "' and ccode = '" + ikrar.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                       if (ds1.Tables[0].Rows.Count > 0)
                       {
                           for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                               //objclscommonfunedit.funInserSingleValueSevarthID(ikrar.Database, ikrar.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + ikrar.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_code"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", loginid, ref dbCmd4);
                               objclscommonfunedit.funInserSingleValue(ikrar.Database, ikrar.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + ikrar.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','12','2','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'",  ref dbCmd4);
                       }
                   }
               }               

               return "true";
         

       }
    }
}
