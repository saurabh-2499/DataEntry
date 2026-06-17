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
    
    public class clsBoja
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

        public string certifyBoja(objCertify boja, DbCommand dbCmd4)
        {
            
           
                boja.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(boja.Database, "LRSRO Connection StringMutation");
                userid = objclscommonfunedit.funReturnSingleValue(boja.Database, boja.Schema + ".m_officermast", "username", "ccode='" + boja.Ccode + "' and user_type='2'", "");
                ds = objclscommonfunedit.funReturnDataSet(boja.Database, boja.Schema + ".mut_kharedi", "*", "mut_no=" + boja.Val + " and ccode = '" + boja.Ccode + "' and pin='"+ boja.Pin+ "' and pin1='"+boja.Pin1+"' and pin2='"+boja.Pin2+"' and pin3='"+boja.Pin3+"' and pin4='"+boja.Pin4+"' and pin5='"+boja.Pin5+"' and pin6='"+boja.Pin6+"' and pin7='"+boja.Pin7+"' and pin8='"+boja.Pin8+"' and  or_code3 =66", "");
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        history.Ccode = boja.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = boja.Schema;
                        history.Database = boja.Database;
                        history.Val = boja.Val;
                        history.User = boja.User;
                        objHistory.insertdata_history(history, dbCmd4);
                    }

                    ds1 = objclscommonfunedit.funReturnDataSet(boja.Database, boja.Schema + ".mut_kharedi_buyer", "*", "mut_no=" + boja.Val + " and ccode = '" + boja.Ccode + "' and pin='" + boja.Pin + "' and pin1='" + boja.Pin1 + "' and pin2='" + boja.Pin2 + "' and pin3='" + boja.Pin3 + "' and pin4='" + boja.Pin4 + "' and pin5='" + boja.Pin5 + "' and pin6='" + boja.Pin6 + "' and pin7='" + boja.Pin7 + "' and pin8='" + boja.Pin8 + "' and buyer_doc_type1=57", "");
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                            //objclscommonfunedit.funInserSingleValue(boja.Database, boja.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + boja.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_code"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", ref dbCmd4);
                        //objclscommonfunedit.funInserSingleValue_audit(boja.Database, boja.Schema + ".form7_orights",userid, "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + boja.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_code"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", ref dbCmd4);
                            objclscommonfunedit.funInserSingleValueSevarthID(boja.Database, boja.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + boja.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_code"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", userid.ToString(), ref dbCmd4);
                    }



                    flag = objclscommonfunedit.funReturnDataSet(boja.Database, boja.Schema + ".tblrordetails", "*", "mutationno='" + boja.Val + "' and ccode = '" + boja.Ccode + "' ", "");
                    for (int j=0; j <= flag.Tables[0].Rows.Count - 1; j++)
                    {
                        objclscommonfunedit.funUpdateValueSevarthID(boja.Database, boja.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + boja.Ccode + "' and  pin='" + flag.Tables[0].Rows[j]["pin"].ToString() + "' and pin1='" + flag.Tables[0].Rows[j]["pin1"].ToString() + "' and  pin2='" + flag.Tables[0].Rows[j]["pin2"].ToString() + "' and pin3='" + flag.Tables[0].Rows[j]["pin3"].ToString() + "' and pin4='" + flag.Tables[0].Rows[j]["pin4"].ToString() + "' and pin5='" + flag.Tables[0].Rows[j]["pin5"].ToString() + "' and pin6='" + flag.Tables[0].Rows[j]["pin6"].ToString() + "'  and pin7='" + flag.Tables[0].Rows[j]["pin7"].ToString() + "' and pin8 ='" + flag.Tables[0].Rows[j]["pin8"].ToString() + "'", userid, ref dbCmd4);
                        //objclscommonfunedit.funUpdateValue(boja.Database, boja.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + boja.Ccode + "' and  pin='" + flag.Tables[0].Rows[j]["pin"].ToString() + "' and pin1='" + flag.Tables[0].Rows[j]["pin1"].ToString() + "' and  pin2='" + flag.Tables[0].Rows[j]["pin2"].ToString() + "' and pin3='" + flag.Tables[0].Rows[j]["pin3"].ToString() + "' and pin4='" + flag.Tables[0].Rows[j]["pin4"].ToString() + "' and pin5='" + flag.Tables[0].Rows[j]["pin5"].ToString() + "' and pin6='" + flag.Tables[0].Rows[j]["pin6"].ToString() + "'  and pin7='" + flag.Tables[0].Rows[j]["pin7"].ToString() + "' and pin8 ='" + flag.Tables[0].Rows[j]["pin8"].ToString() + "'", ref dbCmd4);

                    }



                }


                if (boja.Flag == "true")
                {
                    //objclscommonfunedit.funUpdateValue(boja.Database, boja.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + boja.Ccode + "'and  mut_no=" + Convert.ToInt32(boja.Val) + "and remark='Itar-M'", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(boja.Database, boja.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + boja.Ccode + "'and mut_no=" + Convert.ToInt32(boja.Val) + "", ref dbCmd4);         
                    //objclscommonfunedit.funUpdateValue(boja.Database, boja.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + boja.Ccode + "' AND mutationno=" + boja.Val + "", ref dbCmd4);



                    objclscommonfunedit.funUpdateValueSevarthID(boja.Database, boja.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + boja.Ccode + "'and  mut_no=" + Convert.ToInt32(boja.Val) + "and pin='" + boja.Pin + "' and pin1='" + boja.Pin1 + "' and pin2='" + boja.Pin2 + "' and pin3='" + boja.Pin3 + "' and pin4='" + boja.Pin4 + "' and pin5='" + boja.Pin5 + "' and pin6='" + boja.Pin6 + "' and pin7='" + boja.Pin7 + "' and pin8='" + boja.Pin8 + "'", userid, ref dbCmd4);
                    //objclscommonfunedit.funUpdateValueSevarthID(boja.Database, boja.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + boja.Ccode + "'and mut_no=" + Convert.ToInt32(boja.Val) + "",userid, ref dbCmd4);         
                    objclscommonfunedit.funUpdateValueSevarthID(boja.Database, boja.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + boja.Ccode + "' AND mutationno=" + boja.Val + "", userid,ref dbCmd4);


                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (boja.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + boja.Database;
                        QueryString += "&pin=" + boja.Pin;
                        QueryString += "&pin1=" + boja.Pin1;
                        QueryString += "&pin2=" + boja.Pin2;
                        QueryString += "&pin3=" + boja.Pin3;
                        QueryString += "&pin4=" + boja.Pin4;
                        QueryString += "&pin5=" + boja.Pin5;
                        QueryString += "&pin6=" + boja.Pin6;
                        QueryString += "&pin7=" + boja.Pin7;
                        QueryString += "&pin8=" + boja.Pin8;
                        QueryString += "&vcode=" + boja.Ccode;
                        QueryString += "&vname=" + boja.Vname;
                        QueryString += "&mschema=" + boja.Schema + "'";

                    }

                }

                return "true";
           

        }

       

        public string precertifyBoja(objCertify boja, DbCommand dbCmd4)
        {
            
           

                boja.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(boja.Database, "LRSRO Connection StringMutation");


                ds = objclscommonfunedit.funReturnDataSet(boja.Database, boja.Schema + ".mut_kharedi", "*", "mut_no=" + boja.Val + " and ccode = '" + boja.Ccode + "'and  or_code3 =66", "");

                if (ds!=null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        ds1 = objclscommonfunedit.funReturnDataSet(boja.Database, boja.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + boja.Val + "' and ccode = '" + boja.Ccode + "'and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "' and buyer_doc_type1=57", "");
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValue(boja.Database, boja.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + boja.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','" + ds1.Tables[0].Rows[k][41].ToString() + "','" + ds1.Tables[0].Rows[k][42] + "','" + ds1.Tables[0].Rows[k][40] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'", ref dbCmd4);
                        }
                        history.Ccode = boja.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = boja.Schema;
                        history.Database = boja.Database;


                       


                      

                    }

                }


                if (boja.Flag == "true")
                {
                    //objclscommonfunedit.funUpdateValue(boja.Database, boja.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + boja.Ccode + "'and  mut_no=" + Convert.ToInt32(boja.Val) + "and remark='Itar-M'", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(boja.Database, boja.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + boja.Ccode + "'and mut_no=" + Convert.ToInt32(boja.Val) + "", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(boja.Database, boja.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + boja.Ccode + "' AND mutationno=" + boja.Val + "", ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (boja.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + boja.Database;
                        QueryString += "&pin=" + boja.Pin;
                        QueryString += "&pin1=" + boja.Pin1;
                        QueryString += "&pin2=" + boja.Pin2;
                        QueryString += "&pin3=" + boja.Pin3;
                        QueryString += "&pin4=" + boja.Pin4;
                        QueryString += "&pin5=" + boja.Pin5;
                        QueryString += "&pin6=" + boja.Pin6;
                        QueryString += "&pin7=" + boja.Pin7;
                        QueryString += "&pin8=" + boja.Pin8;
                        QueryString += "&vcode=" + boja.Ccode;
                        QueryString += "&vname=" + boja.Vname;
                        QueryString += "&mschema=" + boja.Schema + "'";

                    }

                }

                return "true";
           

        }


        public string talathi_certifyBoja(objCertify boja, DbCommand dbCmd4)
        {
            
            
                boja.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(boja.Database, "LRSRO Connection StringMutation");
                userid = objclscommonfunedit.funReturnSingleValue(boja.Database, boja.Schema + ".m_officermast", "username", "ccode='" + boja.Ccode + "' and user_type='1'", "");
                ds = objclscommonfunedit.funReturnDataSet(boja.Database, boja.Schema + ".verify_mut_kharedi", "*", "mut_no=" + boja.Val + " and ccode = '" + boja.Ccode + "' and pin='" + boja.Pin + "' and pin1='" + boja.Pin1 + "' and pin2='" + boja.Pin2 + "' and pin3='" + boja.Pin3 + "' and pin4='" + boja.Pin4 + "' and pin5='" + boja.Pin5 + "' and pin6='" + boja.Pin6 + "' and pin7='" + boja.Pin7 + "' and pin8='" + boja.Pin8 + "' and  or_code3 =66", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    

                    ds1 = objclscommonfunedit.funReturnDataSet(boja.Database, boja.Schema + ".verify_mut_kharedi_buyer", "*", "mut_no=" + boja.Val + " and ccode = '" + boja.Ccode + "' and pin='" + boja.Pin + "' and pin1='" + boja.Pin1 + "' and pin2='" + boja.Pin2 + "' and pin3='" + boja.Pin3 + "' and pin4='" + boja.Pin4 + "' and pin5='" + boja.Pin5 + "' and pin6='" + boja.Pin6 + "' and pin7='" + boja.Pin7 + "' and pin8='" + boja.Pin8 + "' and buyer_doc_type1=57", "");
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int k = 0; k <= ds1.Tables[0].Rows.Count - 1; k++)
                            //objclscommonfunedit.funInserSingleValue(boja.Database, boja.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + boja.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_code"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", ref dbCmd4);
                            //objclscommonfunedit.funInserSingleValue_audit(boja.Database, boja.Schema + ".form7_orights",userid, "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + boja.Ccode + "'," + ds1.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds1.Tables[0].Rows[k]["pin"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds1.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds1.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds1.Tables[0].Rows[k]["pin8"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_code"].ToString() + "','" + ds1.Tables[0].Rows[k]["tenure_sub_code"] + "','" + ds1.Tables[0].Rows[k]["buyer_name"] + "','" + ds1.Tables[0].Rows[k]["mut_no"] + "','" + ds1.Tables[0].Rows[k]["usrno"] + "'", ref dbCmd4);
                            objclscommonfunedit.funInserSingleValue(boja.Database, boja.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no,usrno", "'" + boja.Ccode + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][28].ToString() + "','" + ds1.Tables[0].Rows[k][29].ToString() + "', '" + ds1.Tables[0].Rows[k][30].ToString() + "','" + ds1.Tables[0].Rows[k][31].ToString() + "' ,'" + ds1.Tables[0].Rows[k][32].ToString() + "' ,'" + ds1.Tables[0].Rows[k][33].ToString() + "' ,'" + ds1.Tables[0].Rows[k][34].ToString() + "' ,'" + ds1.Tables[0].Rows[k][35].ToString() + "' ,'" + ds1.Tables[0].Rows[k][36].ToString() + "','" + ds1.Tables[0].Rows[k][41].ToString() + "','" + ds1.Tables[0].Rows[k][42] + "','" + ds1.Tables[0].Rows[k][40] + "','" + ds1.Tables[0].Rows[k][1] + "','" + ds1.Tables[0].Rows[k][24] + "'", ref dbCmd4);
                    }
                   


                }

                

                return "true";
           

        }
    }
}
