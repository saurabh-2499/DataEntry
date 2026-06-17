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
    public class clsNA
    {
        #region[---Global Data----]
        clscommonfunedit objclscommonfunedit = new clscommonfunedit();
        clsHistory objHistory = new clsHistory();
        objCertify history = new objCertify();
        DataSet ds = new DataSet();
        DataSet dsMutKharedi = new DataSet();
        DataSet dsMutKharediBuyer = new DataSet();
        DataSet dsMutOtherRights = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds8a = new DataSet();
        DataSet flag = new DataSet();
        DataSet ds_h = new DataSet();

        DataSet DS_MK = new DataSet();
        DataSet DS_MKS = new DataSet();
        DataSet DS_MKB = new DataSet();
        DataSet DS_HD = new DataSet();
        DataSet DS_F7K = new DataSet();
        DataSet DS_F7A = new DataSet();
        DataSet DS_F7A_for_mut_no = new DataSet();
        int i4 = 0;
        string loginid = string.Empty;
        #endregion[---Global Data----]

        #region[--- Certify----]

        public string certifyNA(objCertify na, DbCommand dbCmd4)
        {
            
            
                #region [---Fetch Login Id for App Audit---]
                loginid = objclscommonfunedit.funReturnSingleValue(na.Database, na.Schema + ".m_officermast", "username", "ccode='" + na.Ccode + "' and user_type='2'", "");
                #endregion

                #region[----History-------]
                ds_h = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".mut_kharedi", "*", "mut_no=" + na.Val + " and ccode = '" + na.Ccode + "'", "");

                if (ds_h.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds_h.Tables[0].Rows.Count - 1; i++)
                    {
                        history.Ccode = na.Ccode;
                        history.Pin = ds_h.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds_h.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds_h.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds_h.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds_h.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds_h.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds_h.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds_h.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds_h.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = na.Schema;
                        history.Database = na.Database;
                        history.Val = na.Val;
                        history.User = na.User;
                        objHistory.insertdata_history(history, dbCmd4);
                    }
                }
                #endregion[---- End of History-------]

                na.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(na.Database, "LRSRO Connection StringMutation");

                DS_MK = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".mut_kharedi", "*", "mut_no=" + na.Val + " and ccode = '" + na.Ccode + "'", "");
                //foreach (DataRow DR_MK in DS_MK.Tables[0].Rows)
                //{
                //    DS_MKS = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".mut_kharedi_seller", "*", "mut_no='" + na.Val + "' and ccode = '" + na.Ccode + "' and  pin='" + DR_MK["pin"] + "'  and pin1='" + DR_MK["pin1"] + "'  and pin2='" + DR_MK["pin2"] + "'  and pin3='" + DR_MK["pin3"] + "' and pin4='" + DR_MK["pin4"] + "' and pin5='" + DR_MK["pin5"] + "' and pin6='" + DR_MK["pin6"] + "' and pin7='" + DR_MK["pin7"] + "'  and pin8='" + DR_MK["pin8"] + "'", "");
                //}

                DS_MKB = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".mut_kharedi_buyer", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,jirayat_area_h,bagayat_area_h,tari_area_h,varkas_area_h,itar_area_h,buyer_area_culti,na_area_h,na_assessment,buyer_area_pot,buyer_area_pot2,judi,buyer_area_tot,mut_no,buyer_name,usrno,tenure_code,tenure_sub_code", "mut_no='" + na.Val + "' and ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");
                if (DS_MKB.Tables[0].Rows.Count > 0)
                {
                    DS_F7A = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".form7_area", "distinct mut_no", " ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");

                    if (DS_F7A.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= DS_MKB.Tables[0].Rows.Count - 1; i++)
                        {
                            objclscommonfunedit.funUpdateValueSevarthID(na.Database, na.Schema + ".form7_area", "jirayat_area_h= '" + DS_MKB.Tables[0].Rows[i]["jirayat_area_h"].ToString() + "', bagayat_area_h=" + DS_MKB.Tables[0].Rows[i]["bagayat_area_h"].ToString() + ", tari_area_h=" + DS_MKB.Tables[0].Rows[i]["tari_area_h"].ToString() + ",   varkas_area_h=" + DS_MKB.Tables[0].Rows[i]["varkas_area_h"].ToString() + "  , itar_area_h=" + DS_MKB.Tables[0].Rows[i]["itar_area_h"].ToString() + ",   net_culti_area_h=" + DS_MKB.Tables[0].Rows[i]["buyer_area_culti"].ToString() + ", assessment=" + DS_MKB.Tables[0].Rows[i]["buyer_area_tot"].ToString() + ",na_area_h=" + DS_MKB.Tables[0].Rows[i]["na_area_h"].ToString() + ", na_assessment=" + DS_MKB.Tables[0].Rows[i]["na_assessment"].ToString() + ", judi=" + DS_MKB.Tables[0].Rows[i]["judi"].ToString() + ", potkharaba_a_h=" + DS_MKB.Tables[0].Rows[i]["buyer_area_pot"].ToString() + ",  potkharaba_b_h=" + DS_MKB.Tables[0].Rows[i]["buyer_area_pot2"].ToString() + ",mut_no=" + na.Val + ",old_mut_no=" + DS_F7A.Tables[0].Rows[0]["mut_no"].ToString() + "", "ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", loginid, ref dbCmd4);
                            for (int k = 0; k <= DS_MKB.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValueSevarthID(na.Database, na.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,tenant_name,mut_no,usrno,other_rights_code,other_rights_sub_code", "'" + na.Ccode + "'," + DS_MKB.Tables[0].Rows[k]["pin"].ToString() + ",'" + DS_MKB.Tables[0].Rows[k]["pin"].ToString() + "','" + DS_MKB.Tables[0].Rows[k]["pin1"].ToString() + "', '" + DS_MKB.Tables[0].Rows[k]["pin2"].ToString() + "','" + DS_MKB.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin8"].ToString() + "','" + DS_MKB.Tables[0].Rows[k]["buyer_name"] + "','" + DS_MKB.Tables[0].Rows[k]["mut_no"] + "','" + DS_MKB.Tables[0].Rows[k]["usrno"] + "'," + DS_MKB.Tables[0].Rows[k]["tenure_code"] + "," + DS_MKB.Tables[0].Rows[k]["tenure_sub_code"] + "", loginid, ref dbCmd4);
                        
                        
                        }
                    }

                    DS_F7A_for_mut_no = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".form7_area", "mut_no,old_mut_no", "mut_no=" + na.Val + " and ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");
                    if (DS_F7A_for_mut_no.Tables[0].Rows.Count > 0)
                    {
                        int mold_mutno = Convert.ToInt32(DS_F7A_for_mut_no.Tables[0].Rows[0]["old_mut_no"]);
                        i4 = objclscommonfunedit.funReturnSingleValueInt(na.Database, na.Schema + ".form7_mut_no", "count(*)", "ccode = '" + na.Ccode + "' and mutation_no=" + mold_mutno + " and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");
                        if (i4 == 0 && mold_mutno > 0)
                            objclscommonfunedit.funInserSingleValueSevarthID(na.Database, na.Schema + ".form7_mut_no", "mutation_no", "'" + mold_mutno + "'", loginid, ref dbCmd4);
                    }

                    
                }

               

                #region[---Certify Flag---]


                String Etar_mut_no = objclscommonfunedit.funReturnSingleValue(na.Database, na.Schema + ".form7_mut_no", "Count(*)", "ccode='" + na.Ccode + "' and mut_no='" + DS_MK.Tables[0].Rows[0]["mut_no"] + "'and pin='" + DS_MK.Tables[0].Rows[0]["pin"].ToString() + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"].ToString() + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"].ToString() + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"].ToString() + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"].ToString() + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"].ToString() + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"].ToString() + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"].ToString() + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"].ToString() + "'", "");

                if (Etar_mut_no == "0")
                {
                    objclscommonfunedit.funInserSingleValueSevarthID(na.Database, na.Schema + ".form7_mut_no", "mutation_no", "'" + DS_MK.Tables[0].Rows[0]["mut_no"] + "'", loginid, ref dbCmd4);
                }



                if (na.Flag == "true")
                {
                    objclscommonfunedit.funUpdateValueSevarthID(na.Database, na.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + na.Ccode + "'and  mut_no=" + Convert.ToInt32(na.Val) + "and remark='Itar-M'", loginid, ref dbCmd4);
                    objclscommonfunedit.funUpdateValueSevarthID(na.Database, na.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + na.Ccode + "'and mut_no=" + Convert.ToInt32(na.Val) + "", loginid, ref dbCmd4);

                    objclscommonfunedit.funUpdateValueSevarthID(na.Database, na.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + na.Ccode + "' AND mutationno=" + na.Val + "", loginid, ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (na.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + na.Database;
                        QueryString += "&pin=" + na.Pin;
                        QueryString += "&pin1=" + na.Pin1;
                        QueryString += "&pin2=" + na.Pin2;
                        QueryString += "&pin3=" + na.Pin3;
                        QueryString += "&pin4=" + na.Pin4;
                        QueryString += "&pin5=" + na.Pin5;
                        QueryString += "&pin6=" + na.Pin6;
                        QueryString += "&pin7=" + na.Pin7;
                        QueryString += "&pin8=" + na.Pin8;
                        QueryString += "&vcode=" + na.Ccode;
                        QueryString += "&vname=" + na.Vname;
                        QueryString += "&mschema=" + na.Schema + "'";

                    }

                }
                #endregion[--- End Certify Flag---]

                return "true";
           

        }
        #endregion[--- End of Certify----]

        public string precertifyNA(objCertify na, DbCommand dbCmd4)
        {
            
          
                na.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(na.Database, "LRSRO Connection StringMutation");

             
                DS_MK = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".mut_kharedi", "*", "mut_no=" + na.Val + " and ccode = '" + na.Ccode + "'", "");
                DS_MKB = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".mut_kharedi_buyer", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,jirayat_area_h,bagayat_area_h,tari_area_h,varkas_area_h,itar_area_h,buyer_area_culti,na_area_h,na_assessment,buyer_area_pot,buyer_area_pot2,judi,buyer_area_tot,mut_no,buyer_name,usrno,tenure_code,tenure_sub_code", "mut_no='" + na.Val + "' and ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");
                if (DS_MKB.Tables[0].Rows.Count > 0)
                {
                    DS_F7A = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".pre_form7_area", "distinct mut_no", " ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");

                    if (DS_F7A.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= DS_MKB.Tables[0].Rows.Count - 1; i++)
                        {
                            objclscommonfunedit.funUpdateValue(na.Database, na.Schema + ".pre_form7_area", "jirayat_area_h= '" + DS_MKB.Tables[0].Rows[i]["jirayat_area_h"].ToString() + "', bagayat_area_h=" + DS_MKB.Tables[0].Rows[i]["bagayat_area_h"].ToString() + ", tari_area_h=" + DS_MKB.Tables[0].Rows[i]["tari_area_h"].ToString() + ",   varkas_area_h=" + DS_MKB.Tables[0].Rows[i]["varkas_area_h"].ToString() + "  , itar_area_h=" + DS_MKB.Tables[0].Rows[i]["itar_area_h"].ToString() + ",   net_culti_area_h=" + DS_MKB.Tables[0].Rows[i]["buyer_area_culti"].ToString() + ", assessment=" + DS_MKB.Tables[0].Rows[i]["buyer_area_tot"].ToString() + ",na_area_h=" + DS_MKB.Tables[0].Rows[i]["na_area_h"].ToString() + ", na_assessment=" + DS_MKB.Tables[0].Rows[i]["na_assessment"].ToString() + ", judi=" + DS_MKB.Tables[0].Rows[i]["judi"].ToString() + ", potkharaba_a_h=" + DS_MKB.Tables[0].Rows[i]["buyer_area_pot"].ToString() + ",  potkharaba_b_h=" + DS_MKB.Tables[0].Rows[i]["buyer_area_pot2"].ToString() + ",mut_no=" + na.Val + ",old_mut_no=" + DS_F7A.Tables[0].Rows[0]["mut_no"].ToString() + "", "ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", ref dbCmd4);

                            for (int k = 0; k <= DS_MKB.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValue(na.Database, na.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,tenant_name,mut_no,usrno,other_rights_code,other_rights_sub_code", "'" + na.Ccode + "'," + DS_MKB.Tables[0].Rows[k]["pin"].ToString() + ",'" + DS_MKB.Tables[0].Rows[k]["pin"].ToString() + "','" + DS_MKB.Tables[0].Rows[k]["pin1"].ToString() + "', '" + DS_MKB.Tables[0].Rows[k]["pin2"].ToString() + "','" + DS_MKB.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin8"].ToString() + "','" + DS_MKB.Tables[0].Rows[k]["buyer_name"] + "','" + DS_MKB.Tables[0].Rows[k]["mut_no"] + "','" + DS_MKB.Tables[0].Rows[k]["usrno"] + "'," + DS_MKB.Tables[0].Rows[k]["tenure_code"] + "," + DS_MKB.Tables[0].Rows[k]["tenure_sub_code"] + "", ref dbCmd4);
                        
                        }
                    }
                    DS_F7A_for_mut_no = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".pre_form7_area", "mut_no,old_mut_no", "mut_no=" + na.Val + " and ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");
                    if (DS_F7A_for_mut_no.Tables[0].Rows.Count > 0)
                    {
                        int mold_mutno = Convert.ToInt32(DS_F7A_for_mut_no.Tables[0].Rows[0]["old_mut_no"]);
                        i4 = objclscommonfunedit.funReturnSingleValueInt(na.Database, na.Schema + ".pre_form7_mut_no", "count(*)", "ccode = '" + na.Ccode + "' and mutation_no=" + mold_mutno + " and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");
                        if (i4 == 0 && mold_mutno > 0)
                            objclscommonfunedit.funInserSingleValue(na.Database, na.Schema + ".pre_form7_mut_no", "mutation_no", "'" + mold_mutno + "'", ref dbCmd4);
                        // this.funForm7_MutEntry((string)ViewState["ccode"], Convert.ToString(mold_mutno), (string)ViewState["pin"], (string)ViewState["pin1"], (string)ViewState["pin2"], (string)ViewState["pin3"], (string)ViewState["pin4"], (string)ViewState["pin5"], (string)ViewState["pin6"], (string)ViewState["pin7"], (string)ViewState["pin8"]);
                    }
                }

               

              


               

                return "true";
           
        }


        public string talathi_certifyNA(objCertify na, DbCommand dbCmd4)
        {
            
         
                na.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(na.Database, "LRSRO Connection StringMutation");


                DS_MK = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".verify_mut_kharedi", "*", "mut_no=" + na.Val + " and ccode = '" + na.Ccode + "'", "");
                DS_MKB = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".verify_mut_kharedi_buyer", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,jirayat_area_h,bagayat_area_h,tari_area_h,varkas_area_h,itar_area_h,buyer_area_culti,na_area_h,na_assessment,buyer_area_pot,buyer_area_pot2,judi,buyer_area_tot,mut_no,buyer_name,usrno,tenure_code,tenure_sub_code", "mut_no='" + na.Val + "' and ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");
                if (DS_MKB.Tables[0].Rows.Count > 0)
                {
                    DS_F7A = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".pre_form7_area", "distinct mut_no", " ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");

                    if (DS_F7A.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= DS_MKB.Tables[0].Rows.Count - 1; i++)
                        {
                            objclscommonfunedit.funUpdateValue(na.Database, na.Schema + ".pre_form7_area", "jirayat_area_h= '" + DS_MKB.Tables[0].Rows[i]["jirayat_area_h"].ToString() + "', bagayat_area_h=" + DS_MKB.Tables[0].Rows[i]["bagayat_area_h"].ToString() + ", tari_area_h=" + DS_MKB.Tables[0].Rows[i]["tari_area_h"].ToString() + ",   varkas_area_h=" + DS_MKB.Tables[0].Rows[i]["varkas_area_h"].ToString() + "  , itar_area_h=" + DS_MKB.Tables[0].Rows[i]["itar_area_h"].ToString() + ",   net_culti_area_h=" + DS_MKB.Tables[0].Rows[i]["buyer_area_culti"].ToString() + ", assessment=" + DS_MKB.Tables[0].Rows[i]["buyer_area_tot"].ToString() + ",na_area_h=" + DS_MKB.Tables[0].Rows[i]["na_area_h"].ToString() + ", na_assessment=" + DS_MKB.Tables[0].Rows[i]["na_assessment"].ToString() + ", judi=" + DS_MKB.Tables[0].Rows[i]["judi"].ToString() + ", potkharaba_a_h=" + DS_MKB.Tables[0].Rows[i]["buyer_area_pot"].ToString() + ",  potkharaba_b_h=" + DS_MKB.Tables[0].Rows[i]["buyer_area_pot2"].ToString() + ",mut_no=" + na.Val + ",old_mut_no=" + DS_F7A.Tables[0].Rows[0]["mut_no"].ToString() + "", "ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", ref dbCmd4);

                            for (int k = 0; k <= DS_MKB.Tables[0].Rows.Count - 1; k++)
                                objclscommonfunedit.funInserSingleValue(na.Database, na.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,tenant_name,mut_no,usrno,other_rights_code,other_rights_sub_code", "'" + na.Ccode + "'," + DS_MKB.Tables[0].Rows[k]["pin"].ToString() + ",'" + DS_MKB.Tables[0].Rows[k]["pin"].ToString() + "','" + DS_MKB.Tables[0].Rows[k]["pin1"].ToString() + "', '" + DS_MKB.Tables[0].Rows[k]["pin2"].ToString() + "','" + DS_MKB.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + DS_MKB.Tables[0].Rows[k]["pin8"].ToString() + "','" + DS_MKB.Tables[0].Rows[k]["buyer_name"] + "','" + DS_MKB.Tables[0].Rows[k]["mut_no"] + "','" + DS_MKB.Tables[0].Rows[k]["usrno"] + "'," + DS_MKB.Tables[0].Rows[k]["tenure_code"] + "," + DS_MKB.Tables[0].Rows[k]["tenure_sub_code"] + "", ref dbCmd4);

                        }
                    }
                    DS_F7A_for_mut_no = objclscommonfunedit.funReturnDataSet(na.Database, na.Schema + ".pre_form7_area", "mut_no,old_mut_no", "mut_no=" + na.Val + " and ccode = '" + na.Ccode + "' and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");
                    if (DS_F7A_for_mut_no.Tables[0].Rows.Count > 0)
                    {
                        int mold_mutno = Convert.ToInt32(DS_F7A_for_mut_no.Tables[0].Rows[0]["old_mut_no"]);
                        i4 = objclscommonfunedit.funReturnSingleValueInt(na.Database, na.Schema + ".pre_form7_mut_no", "count(*)", "ccode = '" + na.Ccode + "' and mutation_no=" + mold_mutno + " and pin='" + DS_MK.Tables[0].Rows[0]["pin"] + "' and pin1='" + DS_MK.Tables[0].Rows[0]["pin1"] + "' and  pin2='" + DS_MK.Tables[0].Rows[0]["pin2"] + "' and pin3='" + DS_MK.Tables[0].Rows[0]["pin3"] + "' and pin4='" + DS_MK.Tables[0].Rows[0]["pin4"] + "' and pin5='" + DS_MK.Tables[0].Rows[0]["pin5"] + "' and pin6='" + DS_MK.Tables[0].Rows[0]["pin6"] + "'  and pin7='" + DS_MK.Tables[0].Rows[0]["pin7"] + "' and pin8 ='" + DS_MK.Tables[0].Rows[0]["pin8"] + "'", "");
                        if (i4 == 0 && mold_mutno > 0)
                            objclscommonfunedit.funInserSingleValue(na.Database, na.Schema + ".pre_form7_mut_no", "mutation_no", "'" + mold_mutno + "'", ref dbCmd4);
                        // this.funForm7_MutEntry((string)ViewState["ccode"], Convert.ToString(mold_mutno), (string)ViewState["pin"], (string)ViewState["pin1"], (string)ViewState["pin2"], (string)ViewState["pin3"], (string)ViewState["pin4"], (string)ViewState["pin5"], (string)ViewState["pin6"], (string)ViewState["pin7"], (string)ViewState["pin8"]);
                    }
                }
                return "true";
          
        }
    }
}
