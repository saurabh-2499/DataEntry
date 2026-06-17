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
    public class clshakkasod
    {
        clscommonfunedit objclscommonfunedit = new clscommonfunedit();
        clsHistory objHistory = new clsHistory();
        objCertify history = new objCertify();
        public string certifyKharedi(objCertify kharedi, DbCommand dbCmd4)
        {
            
           
                kharedi.Flag = "true";
                //int mflag = 0;
                //int i4 = 0;
                //DataBaseHandler dbHandler = new DataBaseHandler(boja.Database, "LRSRO Connection StringMutation");

                DataSet ds = new DataSet();
                DataSet dsMutKharedi = new DataSet();
                DataSet dsMutKharediBuyer = new DataSet();
                //DataSet dsMKSK = new DataSet();
                //DataSet dsMKBK = new DataSet();
                DataSet ds_MKBNames = new DataSet();
                DataSet dsMutOtherRights = new DataSet();
                string dsmuttype, sum_area, assessment_form7;
                double area8a, assessment8a, total_area_h;
                //DataSet ds1 = new DataSet();
                //DataSet ds8a = new DataSet();
                DataSet dsmutregi = new DataSet();
                DataSet dsMKS = new DataSet();
                DataSet dsF7k=new DataSet();

                ds = objclscommonfunedit.funReturnDataSet(kharedi.Database, kharedi.Schema + ".mut_kharedi", "*", "mut_no=" + kharedi.Val + " and ccode = '" + kharedi.Ccode + "' and  or_code3 =53", "");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        history.Ccode = kharedi.Ccode;
                        history.Pin = ds.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = kharedi.Schema;
                        history.Database = kharedi.Database;
                        history.Val = kharedi.Val;
                        history.User = kharedi.User;
                        objHistory.insertdata_history(history, dbCmd4);
                    }
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                       
                                          

                        //dsmutregi = objclscommonfunedit.funReturnDataSet(kharedi.Database, "select * from " + kharedi.Schema + ".mutregister where mut_no='" + kharedi.Val + "'and ccode = '" + kharedi.Ccode + "'");
                        //dsmutregi = objclscommonfunedit.funReturnDataSet(kharedi.Database, kharedi.Schema + ".mutrgister", "*", "mut_no='" + kharedi.Val + "' and ccode = '" + kharedi.Ccode + "'");

                        dsMKS = objclscommonfunedit.funReturnDataSet(kharedi.Database,"select * from "+ kharedi.Schema + ".mut_kharedi_seller where mut_no='" + kharedi.Val + "' and ccode = '" + kharedi.Ccode + "' and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "'");
                        if (dsMKS.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j <= dsMKS.Tables[0].Rows.Count - 1; j++)
                            {
                                //dsF7k=objclscommonfunedit.funReturnDataSet(kharedi.Database,""

                                objclscommonfunedit.funUpdateValue(kharedi.Database, kharedi.Schema + ".form7_khata", "old_mut_no=mut_no,mut_no='" + kharedi.Val + "',marked='Y'", "ccode='" + kharedi.Ccode + "' and khata_no='" + dsMKS.Tables[0].Rows[j]["seller_khata_no"].ToString() + "' and pin='" + ds.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds.Tables[0].Rows[i]["pin8"].ToString() + "'and fname ='" + dsMKS.Tables[0].Rows[j]["fname"].ToString() + "'and mname ='" + dsMKS.Tables[0].Rows[j]["mname"].ToString() + "'and lname ='" + dsMKS.Tables[0].Rows[j]["lname"].ToString() + "'", ref dbCmd4);

                            }
                        }
   
                            
                        //(kharedi.Database, kharedi.Schema + ".mut_kharedi", "*", "mut_no=" + kharedi.Val + " and ccode = '" + kharedi.Ccode + "' and  or_code3 =53", "");
                        
                        //processing for hakka sod
                        // open mutregister ds (DSMR) ccode,mut_no
                        // session(mmut_type ) = DSMR("mut_type")
                        // if DSMR("mut_type") = 15
                        //{
                        // open mut_kharedi_seller (DSMKS) for hakka sodnara name (ccode,mut_no)
                        // foreach (DataRow DSMKS in DSMKS.Tables[0].Rows)
                        //       fetch ccode,khta_no,fname,mname,lname,topan_name from form7_khata for that ccode,khta_no,fname,mname,lname,topan_nam of cuurent row of survey number
                        //       foreach (DataRow dsf7k in dsf7k.Tables[0].Rows)
                        //           update form7_khata set marked = "Y", old_mut_no = mut_no, mut_no = sesion(mut_no)
                        //)
           

                        #region [---form7_orights---]
                        objclscommonfunedit.funInserSingleValue(kharedi.Database, kharedi.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,other_rights_code,other_rights_sub_code,tenant_name,mut_no", "'" + kharedi.Ccode + "','" + ds.Tables[0].Rows[i]["pin"].ToString() + "','" + ds.Tables[0].Rows[i]["pin"].ToString() + "','" + ds.Tables[0].Rows[i]["pin1"].ToString() + "', '" + ds.Tables[0].Rows[i]["pin2"].ToString() + "','" + ds.Tables[0].Rows[i]["pin3"].ToString() + "' ,'" + ds.Tables[0].Rows[i]["pin4"].ToString() + "' ,'" + ds.Tables[0].Rows[i]["pin5"].ToString() + "' ,'" + ds.Tables[0].Rows[i]["pin6"].ToString() + "' ,'" + ds.Tables[0].Rows[i]["pin7"].ToString() + "' ,'" + ds.Tables[0].Rows[i]["pin8"].ToString() + "'," + 25 + "," + 0 + ",'" + ds.Tables[0].Rows[i]["other_rights"] + "'," + kharedi.Val + "", ref dbCmd4);
                        #endregion
                    }

                }

               

                if (kharedi.Flag == "true")
                {
                    objclscommonfunedit.funUpdateValue(kharedi.Database, kharedi.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + kharedi.Ccode + "' and  mut_no=" + Convert.ToInt32(kharedi.Val) + " and remark='Itar-M'", ref dbCmd4);
                    objclscommonfunedit.funUpdateValue(kharedi.Database, kharedi.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + kharedi.Ccode + "' and mut_no=" + Convert.ToInt32(kharedi.Val) + "", ref dbCmd4);
                    objclscommonfunedit.funUpdateValue(kharedi.Database, kharedi.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + kharedi.Ccode + "' AND mutationno=" + kharedi.Val + "", ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (kharedi.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + kharedi.Database;
                        QueryString += "&pin=" + kharedi.Pin;
                        QueryString += "&pin1=" + kharedi.Pin1;
                        QueryString += "&pin2=" + kharedi.Pin2;
                        QueryString += "&pin3=" + kharedi.Pin3;
                        QueryString += "&pin4=" + kharedi.Pin4;
                        QueryString += "&pin5=" + kharedi.Pin5;
                        QueryString += "&pin6=" + kharedi.Pin6;
                        QueryString += "&pin7=" + kharedi.Pin7;
                        QueryString += "&pin8=" + kharedi.Pin8;
                        QueryString += "&vcode=" + kharedi.Ccode;
                        QueryString += "&vname=" + kharedi.Vname;
                        QueryString += "&mschema=" + kharedi.Schema + "'";

                    }

                }

                return "true";
           

        }
    }
}
