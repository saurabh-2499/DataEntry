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
    
    public class clsGahanKhat
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

        public string certifyGahanKhat(objCertify GahanKhat, DbCommand dbCmd4)
        {
            
            
                GahanKhat.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(GahanKhat.Database, "LRSRO Connection StringMutation");

                ds = objclscommonfunedit.funReturnDataSet(GahanKhat.Database, GahanKhat.Schema + ".mut_kharedi", "*", "mut_no=" + GahanKhat.Val + " and ccode = '" + GahanKhat.Ccode + "' and pin='" + GahanKhat.Pin + "' and pin1='" + GahanKhat.Pin1 + "' and pin2='" + GahanKhat.Pin2 + "' and pin3='" + GahanKhat.Pin3 + "' and pin4='" + GahanKhat.Pin4 + "' and pin5='" + GahanKhat.Pin5 + "' and pin6='" + GahanKhat.Pin6 + "' and pin7='" + GahanKhat.Pin7 + "' and pin8='" + GahanKhat.Pin8 + "' and  or_code3 =66", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        history.Ccode = GahanKhat.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = GahanKhat.Schema;
                        history.Database = GahanKhat.Database;
                        history.Val = GahanKhat.Val;
                        history.User = GahanKhat.User;
                        objHistory.insertdata_history(history, dbCmd4);

                        ds1 = objclscommonfunedit.funReturnDataSet(GahanKhat.Database, GahanKhat.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + GahanKhat.Val + "' and ccode = '" + GahanKhat.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValue(GahanKhat.Database, GahanKhat.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + GahanKhat.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','107','1','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", ref dbCmd4);
                        }
                        

                      
                        flag = objclscommonfunedit.funReturnDataSet(GahanKhat.Database, GahanKhat.Schema + ".tblrordetails", "*", "mutationno='" + GahanKhat.Val + "' and ccode = '" + GahanKhat.Ccode + "' ", "");
                            foreach (DataRow dr in flag.Tables[0].Rows)
                            {
                                objclscommonfunedit.funUpdateValue(GahanKhat.Database, GahanKhat.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + GahanKhat.Ccode + "' and  pin='" + flag.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + flag.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + flag.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + flag.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + flag.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + flag.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + flag.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + flag.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + flag.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                            }
                       

                       
                        
                    }

                }


                if (GahanKhat.Flag == "true")
                {
                    objclscommonfunedit.funUpdateValueSevarthID(GahanKhat.Database, GahanKhat.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + GahanKhat.Ccode + "'and  mut_no=" + Convert.ToInt32(GahanKhat.Val) + "and pin='" + GahanKhat.Pin + "' and pin1='" + GahanKhat.Pin1 + "' and pin2='" + GahanKhat.Pin2 + "' and pin3='" + GahanKhat.Pin3 + "' and pin4='" + GahanKhat.Pin4 + "' and pin5='" + GahanKhat.Pin5 + "' and pin6='" + GahanKhat.Pin6 + "' and pin7='" + GahanKhat.Pin7 + "' and pin8='" + GahanKhat.Pin8 + "'", "", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(GahanKhat.Database, GahanKhat.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + GahanKhat.Ccode + "'and mut_no=" + Convert.ToInt32(GahanKhat.Val) + "", ref dbCmd4);
                    objclscommonfunedit.funUpdateValue(GahanKhat.Database, GahanKhat.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + GahanKhat.Ccode + "' AND mutationno=" + GahanKhat.Val + "", ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (GahanKhat.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + GahanKhat.Database;
                        QueryString += "&pin=" + GahanKhat.Pin;
                        QueryString += "&pin1=" + GahanKhat.Pin1;
                        QueryString += "&pin2=" + GahanKhat.Pin2;
                        QueryString += "&pin3=" + GahanKhat.Pin3;
                        QueryString += "&pin4=" + GahanKhat.Pin4;
                        QueryString += "&pin5=" + GahanKhat.Pin5;
                        QueryString += "&pin6=" + GahanKhat.Pin6;
                        QueryString += "&pin7=" + GahanKhat.Pin7;
                        QueryString += "&pin8=" + GahanKhat.Pin8;
                        QueryString += "&vcode=" + GahanKhat.Ccode;
                        QueryString += "&vname=" + GahanKhat.Vname;
                        QueryString += "&mschema=" + GahanKhat.Schema + "'";

                    }

                }

                return "true";
           

        }

       

        public string precertifyGahanKhat(objCertify GahanKhat, DbCommand dbCmd4)
        {
            
           

                GahanKhat.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(GahanKhat.Database, "LRSRO Connection StringMutation");


                ds = objclscommonfunedit.funReturnDataSet(GahanKhat.Database, GahanKhat.Schema + ".mut_kharedi", "*", "mut_no=" + GahanKhat.Val + " and ccode = '" + GahanKhat.Ccode + "'and  or_code3 =66", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        ds1 = objclscommonfunedit.funReturnDataSet(GahanKhat.Database, GahanKhat.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + GahanKhat.Val + "' and ccode = '" + GahanKhat.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValue(GahanKhat.Database, GahanKhat.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + GahanKhat.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','107','1','" + ds1.Tables[0].Rows[k][40] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'", ref dbCmd4);
                        }
                        history.Ccode = GahanKhat.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = GahanKhat.Schema;
                        history.Database = GahanKhat.Database;                    


                       

                    }

                }


                if (GahanKhat.Flag == "true")
                {
                    //objclscommonfunedit.funUpdateValue(GahanKhat.Database, GahanKhat.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + GahanKhat.Ccode + "'and  mut_no=" + Convert.ToInt32(GahanKhat.Val) + "and remark='Itar-M'", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(GahanKhat.Database, GahanKhat.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + GahanKhat.Ccode + "'and mut_no=" + Convert.ToInt32(GahanKhat.Val) + "", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(GahanKhat.Database, GahanKhat.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + GahanKhat.Ccode + "' AND mutationno=" + GahanKhat.Val + "", ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (GahanKhat.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + GahanKhat.Database;
                        QueryString += "&pin=" + GahanKhat.Pin;
                        QueryString += "&pin1=" + GahanKhat.Pin1;
                        QueryString += "&pin2=" + GahanKhat.Pin2;
                        QueryString += "&pin3=" + GahanKhat.Pin3;
                        QueryString += "&pin4=" + GahanKhat.Pin4;
                        QueryString += "&pin5=" + GahanKhat.Pin5;
                        QueryString += "&pin6=" + GahanKhat.Pin6;
                        QueryString += "&pin7=" + GahanKhat.Pin7;
                        QueryString += "&pin8=" + GahanKhat.Pin8;
                        QueryString += "&vcode=" + GahanKhat.Ccode;
                        QueryString += "&vname=" + GahanKhat.Vname;
                        QueryString += "&mschema=" + GahanKhat.Schema + "'";

                    }

                }

                return "true";
           

        }

        public string talathi_certifyGahanKhat(objCertify GahanKhat, DbCommand dbCmd4)
        {
            
           
                GahanKhat.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(GahanKhat.Database, "LRSRO Connection StringMutation");

                ds = objclscommonfunedit.funReturnDataSet(GahanKhat.Database, GahanKhat.Schema + ".verify_mut_kharedi", "*", "mut_no=" + GahanKhat.Val + " and ccode = '" + GahanKhat.Ccode + "'and  or_code3 =66", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        ds1 = objclscommonfunedit.funReturnDataSet(GahanKhat.Database, GahanKhat.Schema + ".verify_mut_kharedi_buyer", "*", "mut_no='" + GahanKhat.Val + "' and ccode = '" + GahanKhat.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValue(GahanKhat.Database, GahanKhat.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + GahanKhat.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','107','1','" + ds1.Tables[0].Rows[k][40] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'", ref dbCmd4);
                        }
                    }
                }
                return "true";
           
        }
    }
}
