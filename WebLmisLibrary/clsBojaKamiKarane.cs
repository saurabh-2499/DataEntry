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
   public class clsBojaKamiKarane
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
       string userid = "";

       public string certifyBojaKamiKarane(objCertify bojaK, DbCommand dbCmd4)
        {
            
           
                
                bojaK.Flag = "true";
               
                DataBaseHandler dbHandler = new DataBaseHandler(bojaK.Database, "LRSRO Connection StringMutation");           

                ds = objclscommonfunedit.funReturnDataSet(bojaK.Database, bojaK.Schema + ".mut_kharedi", "*", "mut_no=" + bojaK.Val + " and ccode = '" + bojaK.Ccode + "' and  pin='" + bojaK.Pin + "' and pin1='" + bojaK.Pin1 + "' and pin2='" + bojaK.Pin2 + "' and pin3='" + bojaK.Pin3 + "' and pin4='" + bojaK.Pin4 + "' and pin5='" + bojaK.Pin5 + "' and pin6='" + bojaK.Pin6 + "' and pin7='" + bojaK.Pin7 + "' and pin8='" + bojaK.Pin8 + "' and  or_code3 =69", "");
                userid = objclscommonfunedit.funReturnSingleValue(bojaK.Database, bojaK.Schema + ".m_officermast", "username", "ccode='" + bojaK.Ccode + "' and user_type='2'", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int old_mut_no_bracket = Convert.ToInt32(ds.Tables[0].Rows[0]["or_code1"]);
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        history.Ccode = bojaK.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = bojaK.Schema;
                        history.Database = bojaK.Database;
                        history.Val = bojaK.Val;
                        history.User = bojaK.User;
                        objHistory.insertdata_history(history, dbCmd4);
                    }


                    ds1 = objclscommonfunedit.funReturnDataSet(bojaK.Database, bojaK.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + bojaK.Val + "' and ccode = '" + bojaK.Ccode + "'and  pin='" + bojaK.Pin + "' and pin1='" + bojaK.Pin1 + "' and pin2='" + bojaK.Pin2 + "' and pin3='" + bojaK.Pin3 + "' and pin4='" + bojaK.Pin4 + "' and pin5='" + bojaK.Pin5 + "' and pin6='" + bojaK.Pin6 + "' and pin7='" + bojaK.Pin7 + "' and pin8='" + bojaK.Pin8 + "' and buyer_doc_type1=57", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                            {

                                //objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".form7_orights", "marked='Y' ", "ccode='" + bojaK.Ccode + "' and pin='" + ds1.Tables[0].Rows[k][28].ToString() + "' and pin1='" + ds1.Tables[0].Rows[k][29].ToString() + "' and pin2='" + ds1.Tables[0].Rows[k][30].ToString() + "' and pin3='" + ds1.Tables[0].Rows[k][31].ToString() + "' and pin4='" + ds1.Tables[0].Rows[k][32].ToString() + "' and pin5='" + ds1.Tables[0].Rows[k][33].ToString() + "' and pin6='" + ds1.Tables[0].Rows[k][34].ToString() + "' and pin7='" + ds1.Tables[0].Rows[k][35].ToString() + "' and pin8='" + ds1.Tables[0].Rows[k][36].ToString() + "' and mut_no='" + old_mut_no_bracket + "'", ref dbCmd4);
                                objclscommonfunedit.funUpdateValueSevarthID(bojaK.Database, bojaK.Schema + ".form7_orights", "marked='Y' ", "ccode='" + bojaK.Ccode + "' and pin='" + ds1.Tables[0].Rows[k][28].ToString() + "' and pin1='" + ds1.Tables[0].Rows[k][29].ToString() + "' and pin2='" + ds1.Tables[0].Rows[k][30].ToString() + "' and pin3='" + ds1.Tables[0].Rows[k][31].ToString() + "' and pin4='" + ds1.Tables[0].Rows[k][32].ToString() + "' and pin5='" + ds1.Tables[0].Rows[k][33].ToString() + "' and pin6='" + ds1.Tables[0].Rows[k][34].ToString() + "' and pin7='" + ds1.Tables[0].Rows[k][35].ToString() + "' and pin8='" + ds1.Tables[0].Rows[k][36].ToString() + "' and mut_no='" + old_mut_no_bracket + "'", userid, ref dbCmd4);

                                //objclscommonfunedit.funInserSingleValue(bojaK.Database, bojaK.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,mut_no,usrno,old_mut_no", "'" + bojaK.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_code"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'," + old_mut_no_bracket, ref dbCmd4);
                                objclscommonfunedit.funInserSingleValueSevarthID(bojaK.Database, bojaK.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,mut_no,usrno,old_mut_no", "'" + bojaK.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','105','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'," + old_mut_no_bracket, userid, ref dbCmd4);
                                //this.funForm7_MutEntry(bojaK.Ccode, Convert.ToString(old_mut_no_bracket), ds1.Tables[0].Rows[k][28].ToString(), ds1.Tables[0].Rows[k][29].ToString(), ds1.Tables[0].Rows[k][30].ToString(), ds1.Tables[0].Rows[k][31].ToString(), ds1.Tables[0].Rows[k][32].ToString(), ds1.Tables[0].Rows[k][33].ToString(), ds1.Tables[0].Rows[k][34].ToString(), ds1.Tables[0].Rows[k][35].ToString(), ds1.Tables[0].Rows[k][36].ToString());

                                //objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".mut_kharedi", "or_code4=1", "ccode = '" + bojaK.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                               // objclscommonfunedit.funUpdateValueSevarthID(bojaK.Database, bojaK.Schema + ".mut_kharedi", "or_code4=1", "ccode = '" + bojaK.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "'", userid, ref dbCmd4);
                            }
                        }
                       
                    }

                


                if (bojaK.Flag == "true")
                {
                    //objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + bojaK.Ccode + "'and  mut_no=" + Convert.ToInt32(bojaK.Val) + "and remark='Itar-M'", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + bojaK.Ccode + "'and mut_no=" + Convert.ToInt32(bojaK.Val) + "", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + bojaK.Ccode + "' AND mutationno=" + bojaK.Val + "", ref dbCmd4);


                    objclscommonfunedit.funUpdateValueSevarthID(bojaK.Database, bojaK.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + bojaK.Ccode + "'and  mut_no=" + Convert.ToInt32(bojaK.Val) + "and pin='" + bojaK.Pin + "' and pin1='" + bojaK.Pin1 + "' and pin2='" + bojaK.Pin2 + "' and pin3='" + bojaK.Pin3 + "' and pin4='" + bojaK.Pin4 + "' and pin5='" + bojaK.Pin5 + "' and pin6='" + bojaK.Pin6 + "' and pin7='" + bojaK.Pin7 + "' and pin8='" + bojaK.Pin8 + "'", userid, ref dbCmd4);
                    //objclscommonfunedit.funUpdateValueSevarthID(bojaK.Database, bojaK.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + bojaK.Ccode + "'and mut_no=" + Convert.ToInt32(bojaK.Val) + "", userid, ref dbCmd4);
                    objclscommonfunedit.funUpdateValueSevarthID(bojaK.Database, bojaK.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + bojaK.Ccode + "' AND mutationno=" + bojaK.Val + "", userid, ref dbCmd4);
                                
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (bojaK.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + bojaK.Database;
                        QueryString += "&pin=" + bojaK.Pin;
                        QueryString += "&pin1=" + bojaK.Pin1;
                        QueryString += "&pin2=" + bojaK.Pin2;
                        QueryString += "&pin3=" + bojaK.Pin3;
                        QueryString += "&pin4=" + bojaK.Pin4;
                        QueryString += "&pin5=" + bojaK.Pin5;
                        QueryString += "&pin6=" + bojaK.Pin6;
                        QueryString += "&pin7=" + bojaK.Pin7;
                        QueryString += "&pin8=" + bojaK.Pin8;
                        QueryString += "&vcode=" + bojaK.Ccode;
                        QueryString += "&vname=" + bojaK.Vname;
                        QueryString += "&mschema=" + bojaK.Schema + "'";

                    }

                }

                return "true";
           

        }

       public string precertifyBojaKamiKarane(objCertify bojaK, DbCommand dbCmd4)
       {
           
          
               bojaK.Flag = "true";

               DataBaseHandler dbHandler = new DataBaseHandler(bojaK.Database, "LRSRO Connection StringMutation");             

               ds = objclscommonfunedit.funReturnDataSet(bojaK.Database, bojaK.Schema + ".mut_kharedi", "*", "mut_no=" + bojaK.Val + " and ccode = '" + bojaK.Ccode + "'and  or_code3 =69", "");

               if (ds.Tables[0].Rows.Count > 0)
               {
                   int old_mut_no_bracket = Convert.ToInt32(ds.Tables[0].Rows[0]["or_code1"]);
                   for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                   {
                       ds1 = objclscommonfunedit.funReturnDataSet(bojaK.Database, bojaK.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + bojaK.Val + "' and ccode = '" + bojaK.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                       if (ds1.Tables[0].Rows.Count > 0)
                       {
                           for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                           {

                               objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".pre_form7_orights", "marked='Y' ", "ccode='" + bojaK.Ccode + "' and pin='" + ds1.Tables[0].Rows[k][28].ToString() + "' and pin1='" + ds1.Tables[0].Rows[k][29].ToString() + "' and pin2='" + ds1.Tables[0].Rows[k][30].ToString() + "' and pin3='" + ds1.Tables[0].Rows[k][31].ToString() + "' and pin4='" + ds1.Tables[0].Rows[k][32].ToString() + "' and pin5='" + ds1.Tables[0].Rows[k][33].ToString() + "' and pin6='" + ds1.Tables[0].Rows[k][34].ToString() + "' and pin7='" + ds1.Tables[0].Rows[k][35].ToString() + "' and pin8='" + ds1.Tables[0].Rows[k][36].ToString() + "' and mut_no='" + old_mut_no_bracket + "'", ref dbCmd4);

                               objclscommonfunedit.funInserSingleValue(bojaK.Database, bojaK.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,mut_no,usrno,old_mut_no", "'" + bojaK.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','105','" + ds1.Tables[0].Rows[k][42] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'," + old_mut_no_bracket, ref dbCmd4);
                               //this.funForm7_MutEntry(bojaK.Ccode, Convert.ToString(old_mut_no_bracket), ds1.Tables[0].Rows[k][28].ToString(), ds1.Tables[0].Rows[k][29].ToString(), ds1.Tables[0].Rows[k][30].ToString(), ds1.Tables[0].Rows[k][31].ToString(), ds1.Tables[0].Rows[k][32].ToString(), ds1.Tables[0].Rows[k][33].ToString(), ds1.Tables[0].Rows[k][34].ToString(), ds1.Tables[0].Rows[k][35].ToString(), ds1.Tables[0].Rows[k][36].ToString());
                           }
                           objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".mut_kharedi", "or_code4=1", "ccode = '" + bojaK.Ccode + "'and pin='" + ds.Tables[0].Rows[i][7].ToString() + "' and pin1='" + ds.Tables[0].Rows[i][8].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i][9].ToString() + "' and pin3='" + ds.Tables[0].Rows[i][10].ToString() + "' and pin4='" + ds.Tables[0].Rows[i][11].ToString() + "' and pin5='" + ds.Tables[0].Rows[i][12].ToString() + "' and pin6='" + ds.Tables[0].Rows[i][13].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i][14].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i][15].ToString() + "'", ref dbCmd4);

                       }
                     

                   }

               }


               if (bojaK.Flag == "true")
               {
                   //objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + bojaK.Ccode + "'and  mut_no=" + Convert.ToInt32(bojaK.Val) + "and remark='Itar-M'", ref dbCmd4);
                   //objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + bojaK.Ccode + "'and mut_no=" + Convert.ToInt32(bojaK.Val) + "", ref dbCmd4);
                   // objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + bojaK.Ccode + "' AND mutationno=" + bojaK.Val + "", ref dbCmd4);
                   // Application["view"] = "1";
                   // Session["CircleClick"] = "1";

                   if (bojaK.Mut_type != "9")
                   {
                       string QueryString = "";
                       QueryString += "'pg712.aspx?DatabaseName=" + bojaK.Database;
                       QueryString += "&pin=" + bojaK.Pin;
                       QueryString += "&pin1=" + bojaK.Pin1;
                       QueryString += "&pin2=" + bojaK.Pin2;
                       QueryString += "&pin3=" + bojaK.Pin3;
                       QueryString += "&pin4=" + bojaK.Pin4;
                       QueryString += "&pin5=" + bojaK.Pin5;
                       QueryString += "&pin6=" + bojaK.Pin6;
                       QueryString += "&pin7=" + bojaK.Pin7;
                       QueryString += "&pin8=" + bojaK.Pin8;
                       QueryString += "&vcode=" + bojaK.Ccode;
                       QueryString += "&vname=" + bojaK.Vname;
                       QueryString += "&mschema=" + bojaK.Schema + "'";

                   }

               }

               return "true";
         

       }


       public string precertifyBojaKamiKarane_verify(objCertify bojaK, DbCommand dbCmd4)
       {
           
          
               bojaK.Flag = "true";

               DataBaseHandler dbHandler = new DataBaseHandler(bojaK.Database, "LRSRO Connection StringMutation");


               //if (ds.Tables[0].Rows.Count > 0)
               //{
               //    //this is the old mutation to which the bracket is to  be put 
               //    int old_mut_no_bracket = Convert.ToInt32(ds.Tables[0].Rows[0]["or_code1"]);
               //    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
               //    {
               //        ds1 = objclscommonfunedit.funReturnDataSet(bojaK.Database, bojaK.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + (string)ViewState["mut_no_val"] + "' and ccode = '" + bojaK.Ccode + "'and pin='" + ds.Tables[0].Rows[i][7].ToString() + "' and pin1='" + ds.Tables[0].Rows[i][8].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i][9].ToString() + "' and pin3='" + ds.Tables[0].Rows[i][10].ToString() + "' and pin4='" + ds.Tables[0].Rows[i][11].ToString() + "' and pin5='" + ds.Tables[0].Rows[i][12].ToString() + "' and pin6='" + ds.Tables[0].Rows[i][13].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i][14].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i][15].ToString() + "' and buyer_doc_type1=57", "");
               //        if (ds1.Tables[0].Rows.Count > 0)
               //        {
               //            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
               //            {
               //                tempint = objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".form7_orights", "marked='Y' ,mut_no='" + (string)ViewState["mut_no_val"] + "',old_mut_no='" + old_mut_no_bracket + "'", "ccode='" + bojaK.Ccode + "' and pin='" + ds1.Tables[0].Rows[k][28].ToString() + "' and pin1='" + ds1.Tables[0].Rows[k][29].ToString() + "' and pin2='" + ds1.Tables[0].Rows[k][30].ToString() + "' and pin3='" + ds1.Tables[0].Rows[k][31].ToString() + "' and pin4='" + ds1.Tables[0].Rows[k][32].ToString() + "' and pin5='" + ds1.Tables[0].Rows[k][33].ToString() + "' and pin6='" + ds1.Tables[0].Rows[k][34].ToString() + "' and pin7='" + ds1.Tables[0].Rows[k][35].ToString() + "' and pin8='" + ds1.Tables[0].Rows[k][36].ToString() + "' and mut_no='" + old_mut_no_bracket + "'", ref dbCmd4);
               //                this.funForm7_MutEntry(bojaK.Ccode, Convert.ToString(old_mut_no_bracket), ds1.Tables[0].Rows[k][28].ToString(), ds1.Tables[0].Rows[k][29].ToString(), ds1.Tables[0].Rows[k][30].ToString(), ds1.Tables[0].Rows[k][31].ToString(), ds1.Tables[0].Rows[k][32].ToString(), ds1.Tables[0].Rows[k][33].ToString(), ds1.Tables[0].Rows[k][34].ToString(), ds1.Tables[0].Rows[k][35].ToString(), ds1.Tables[0].Rows[k][36].ToString());
               //            }
               //        }
               //        tempint = objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".mut_kharedi", "or_code4=1", "ccode = '" + bojaK.Ccode + "'and pin='" + ds.Tables[0].Rows[i][7].ToString() + "' and pin1='" + ds.Tables[0].Rows[i][8].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i][9].ToString() + "' and pin3='" + ds.Tables[0].Rows[i][10].ToString() + "' and pin4='" + ds.Tables[0].Rows[i][11].ToString() + "' and pin5='" + ds.Tables[0].Rows[i][12].ToString() + "' and pin6='" + ds.Tables[0].Rows[i][13].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i][14].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i][15].ToString() + "'", ref dbCmd4);
               //    }
               //    //bindservey();
               //}

               ds = objclscommonfunedit.funReturnDataSet(bojaK.Database, bojaK.Schema + ".verify_mut_kharedi", "*", "mut_no=" + bojaK.Val + " and ccode = '" + bojaK.Ccode + "'and  or_code3 =69", "");

               if (ds.Tables[0].Rows.Count > 0)
               {
                   int old_mut_no_bracket = Convert.ToInt32(ds.Tables[0].Rows[0]["or_code1"]);
                   for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                   {
                       ds1 = objclscommonfunedit.funReturnDataSet(bojaK.Database, bojaK.Schema + ".verify_mut_kharedi_buyer", "*", "mut_no='" + bojaK.Val + "' and ccode = '" + bojaK.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                       if (ds1.Tables[0].Rows.Count > 0)
                       {
                           for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                           {
                               objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".pre_form7_orights", "marked='Y' ", "ccode='" + bojaK.Ccode + "' and pin='" + ds1.Tables[0].Rows[k][28].ToString() + "' and pin1='" + ds1.Tables[0].Rows[k][29].ToString() + "' and pin2='" + ds1.Tables[0].Rows[k][30].ToString() + "' and pin3='" + ds1.Tables[0].Rows[k][31].ToString() + "' and pin4='" + ds1.Tables[0].Rows[k][32].ToString() + "' and pin5='" + ds1.Tables[0].Rows[k][33].ToString() + "' and pin6='" + ds1.Tables[0].Rows[k][34].ToString() + "' and pin7='" + ds1.Tables[0].Rows[k][35].ToString() + "' and pin8='" + ds1.Tables[0].Rows[k][36].ToString() + "' and mut_no='" + old_mut_no_bracket + "'", ref dbCmd4);

                               objclscommonfunedit.funInserSingleValue(bojaK.Database, bojaK.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,mut_no,usrno,old_mut_no", "'" + bojaK.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','105','" + ds1.Tables[0].Rows[k][42] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'," + old_mut_no_bracket, ref dbCmd4);
                               //this.funForm7_MutEntry(bojaK.Ccode, Convert.ToString(old_mut_no_bracket), ds1.Tables[0].Rows[k][28].ToString(), ds1.Tables[0].Rows[k][29].ToString(), ds1.Tables[0].Rows[k][30].ToString(), ds1.Tables[0].Rows[k][31].ToString(), ds1.Tables[0].Rows[k][32].ToString(), ds1.Tables[0].Rows[k][33].ToString(), ds1.Tables[0].Rows[k][34].ToString(), ds1.Tables[0].Rows[k][35].ToString(), ds1.Tables[0].Rows[k][36].ToString());
                           }
                           objclscommonfunedit.funUpdateValue(bojaK.Database, bojaK.Schema + ".verify_mut_kharedi", "or_code4=1", "ccode = '" + bojaK.Ccode + "'and pin='" + ds.Tables[0].Rows[i][7].ToString() + "' and pin1='" + ds.Tables[0].Rows[i][8].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i][9].ToString() + "' and pin3='" + ds.Tables[0].Rows[i][10].ToString() + "' and pin4='" + ds.Tables[0].Rows[i][11].ToString() + "' and pin5='" + ds.Tables[0].Rows[i][12].ToString() + "' and pin6='" + ds.Tables[0].Rows[i][13].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i][14].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i][15].ToString() + "'", ref dbCmd4);

                       }
                   }

               }


              
               return "true";
          

       }
    }
}
