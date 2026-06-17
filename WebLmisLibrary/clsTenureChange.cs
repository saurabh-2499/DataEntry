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
    
    public class clsTenureChange
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
        DataTable dtform7_mut_no = new DataTable();
        string loginid = string.Empty;

        public string certifyTenureChange(objCertify tenure, DbCommand dbCmd4)
        {
            
            
                tenure.Flag = "true";
                loginid = objclscommonfunedit.funReturnSingleValue(tenure.Database, tenure.Schema + ".m_officermast", "username", "ccode='" + tenure.Ccode + "' and user_type='2'", "");

                DataBaseHandler dbHandler = new DataBaseHandler(tenure.Database, "LRSRO Connection StringMutation");

                history.Ccode = tenure.Ccode;
                history.Pin = tenure.Pin;
                history.Pin1 = tenure.Pin1;
                history.Pin2 = tenure.Pin2;
                history.Pin3 = tenure.Pin3;
                history.Pin4 = tenure.Pin4;
                history.Pin5 = tenure.Pin5;
                history.Pin6 = tenure.Pin6;
                history.Pin7 = tenure.Pin7;
                history.Pin8 = tenure.Pin8;
                history.Schema = tenure.Schema;
                history.Database = tenure.Database;
                history.Val = tenure.Val;
                history.User = tenure.User;
                objHistory.insertdata_history(history, dbCmd4);



                ds = objclscommonfunedit.funReturnDataSet(tenure.Database, tenure.Schema + ".mut_kharedi_buyer", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,buyer_khata_no as khata_no,mut_no,tenure_code,tenure_sub_code,tenure_sub_code1,buyer_name,usrno,buyer_anne,buyer_pai", "mut_no=" + tenure.Val + " and ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "' and buyer_doc_type1='52'", "");
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    ds1 = objclscommonfunedit.funReturnDataSet(tenure.Database, tenure.Schema + ".form7", "distinct  mut_no", "ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", "");
                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                                            objclscommonfunedit.funUpdateValueSevarthID(tenure.Database, tenure.Schema + ".form7", "tenure_code=" + ds.Tables[0].Rows[i][12].ToString() + ",tenure_sub_code=" + ds.Tables[0].Rows[i][13].ToString() + ",tenure_sub_code1 =" + ds.Tables[0].Rows[i][14].ToString() + " , mut_no=" + tenure.Val + " ,old_mut_no=" + ds1.Tables[0].Rows[0][0].ToString() + "", "ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", loginid, ref dbCmd4);

                                        for (int k = 0; k <= ds.Tables[0].Rows.Count - 1; k++)
                                            objclscommonfunedit.funInserSingleValueSevarthID(tenure.Database, tenure.Schema + ".form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,tenant_name,mut_no,usrno,other_rights_code,other_rights_sub_code", "'" + tenure.Ccode + "'," + ds.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds.Tables[0].Rows[k]["pin"].ToString() + "','" + ds.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin8"].ToString() + "','','" + ds.Tables[0].Rows[k]["mut_no"] + "','" + ds.Tables[0].Rows[k]["usrno"] + "'," + ds.Tables[0].Rows[k]["buyer_anne"] + "," + ds.Tables[0].Rows[k]["buyer_pai"] + "", loginid, ref dbCmd4);
                        
                                    
                                    }

                                    ds = objclscommonfunedit.funReturnDataSet(tenure.Database, tenure.Schema + ".form7", "mut_no,old_mut_no", "mut_no=" + tenure.Val + " and ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", "");
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        int mold_mutno = Convert.ToInt32(ds.Tables[0].Rows[0]["old_mut_no"]);
                                        i4 = objclscommonfunedit.funReturnSingleValueInt(tenure.Database, tenure.Schema + ".form7_mut_no", "COUNT(*)", "ccode = '" + tenure.Ccode + "' and mutation_no=" + mold_mutno + " and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", "");
                                        if (i4 == 0 && mold_mutno > 0)
                                            funForm7_MutEntry(tenure.Ccode, Convert.ToString(mold_mutno), tenure.Pin, tenure.Pin1, tenure.Pin2, tenure.Pin3, tenure.Pin4, tenure.Pin5, tenure.Pin6, tenure.Pin7, tenure.Pin8);
                                    }


                      
                        
                    }

              


                if (tenure.Flag == "true")
                {
                    objclscommonfunedit.funUpdateValueSevarthID(tenure.Database, tenure.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + tenure.Ccode + "'and  mut_no=" + Convert.ToInt32(tenure.Val) + " and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "' and pin7='" + tenure.Pin7 + "' and pin8='" + tenure.Pin8 + "'", loginid, ref dbCmd4);
                   // objclscommonfunedit.funUpdateValueSevarthID(tenure.Database, tenure.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + tenure.Ccode + "'and mut_no=" + Convert.ToInt32(tenure.Val) + "", loginid, ref dbCmd4);
                    objclscommonfunedit.funUpdateValueSevarthID(tenure.Database, tenure.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + tenure.Ccode + "' AND mutationno=" + tenure.Val + "", loginid, ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (tenure.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + tenure.Database;
                        QueryString += "&pin=" + tenure.Pin;
                        QueryString += "&pin1=" + tenure.Pin1;
                        QueryString += "&pin2=" + tenure.Pin2;
                        QueryString += "&pin3=" + tenure.Pin3;
                        QueryString += "&pin4=" + tenure.Pin4;
                        QueryString += "&pin5=" + tenure.Pin5;
                        QueryString += "&pin6=" + tenure.Pin6;
                        QueryString += "&pin7=" + tenure.Pin7;
                        QueryString += "&pin8=" + tenure.Pin8;
                        QueryString += "&vcode=" + tenure.Ccode;
                        QueryString += "&vname=" + tenure.Vname;
                        QueryString += "&mschema=" + tenure.Schema + "'";

                    }

                }

                return "true";
           

        }

        public string precertifyTenureChange(objCertify tenure, DbCommand dbCmd4)
        {
            
           
                tenure.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(tenure.Database, "LRSRO Connection StringMutation");

                history.Ccode = tenure.Ccode;
                history.Pin = tenure.Pin;
                history.Pin1 = tenure.Pin1;
                history.Pin2 = tenure.Pin2;
                history.Pin3 = tenure.Pin3;
                history.Pin4 = tenure.Pin4;
                history.Pin5 = tenure.Pin5;
                history.Pin6 = tenure.Pin6;
                history.Pin7 = tenure.Pin7;
                history.Pin8 = tenure.Pin8;
                history.Schema = tenure.Schema;
                history.Database = tenure.Database;
                history.Val = tenure.Val;
             



                ds = objclscommonfunedit.funReturnDataSet(tenure.Database, tenure.Schema + ".mut_kharedi_buyer", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,buyer_khata_no as khata_no,mut_no,tenure_code,tenure_sub_code,tenure_sub_code1,buyer_name,usrno,buyer_anne,buyer_pai", "mut_no=" + tenure.Val + " and ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "' and buyer_doc_type1='52'", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds1 = objclscommonfunedit.funReturnDataSet(tenure.Database, tenure.Schema + ".form7", "distinct  mut_no", "ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", "");
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                            objclscommonfunedit.funUpdateValue(tenure.Database, tenure.Schema + ".pre_form7", "tenure_code=" + ds.Tables[0].Rows[i][12].ToString() + ",tenure_sub_code=" + ds.Tables[0].Rows[i][13].ToString() + ",tenure_sub_code1 =" + ds.Tables[0].Rows[i][14].ToString() + " , mut_no=" + tenure.Val + " ,old_mut_no=" + ds1.Tables[0].Rows[0][0].ToString() + "", "ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", ref dbCmd4);

                        for (int k = 0; k <= ds.Tables[0].Rows.Count - 1; k++)
                           
                            objclscommonfunedit.funInserSingleValue(tenure.Database, tenure.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,tenant_name,mut_no,usrno,other_rights_code,other_rights_sub_code", "'" + tenure.Ccode + "'," + ds.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds.Tables[0].Rows[k]["pin"].ToString() + "','" + ds.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin8"].ToString() + "','','" + ds.Tables[0].Rows[k]["mut_no"] + "','" + ds.Tables[0].Rows[k]["usrno"] + "'," + ds.Tables[0].Rows[k]["buyer_anne"] + "," + ds.Tables[0].Rows[k]["buyer_pai"] + "", ref dbCmd4);
                        
                    
                    }

                    ds = objclscommonfunedit.funReturnDataSet(tenure.Database, tenure.Schema + ".form7", "mut_no,old_mut_no", "mut_no=" + tenure.Val + " and ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", "");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int mold_mutno = Convert.ToInt32(ds.Tables[0].Rows[0]["old_mut_no"]);
                        i4 = objclscommonfunedit.funReturnSingleValueInt(tenure.Database, tenure.Schema + ".pre_form7_mut_no", "COUNT(*)", "ccode = '" + tenure.Ccode + "' and mutation_no=" + mold_mutno + " and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", "");
                        if (i4 == 0 && mold_mutno > 0)
                            funForm7_MutEntry(tenure.Ccode, Convert.ToString(mold_mutno), tenure.Pin, tenure.Pin1, tenure.Pin2, tenure.Pin3, tenure.Pin4, tenure.Pin5, tenure.Pin6, tenure.Pin7, tenure.Pin8);
                    }




                }




                if (tenure.Flag == "true")
                {
                    //objclscommonfunedit.funUpdateValue(tenure.Database, tenure.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + tenure.Ccode + "'and  mut_no=" + Convert.ToInt32(tenure.Val) + "and remark='Itar-M'", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(tenure.Database, tenure.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + tenure.Ccode + "'and mut_no=" + Convert.ToInt32(tenure.Val) + "", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(tenure.Database, tenure.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + tenure.Ccode + "' AND mutationno=" + tenure.Val + "", ref dbCmd4);
                    //// Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (tenure.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + tenure.Database;
                        QueryString += "&pin=" + tenure.Pin;
                        QueryString += "&pin1=" + tenure.Pin1;
                        QueryString += "&pin2=" + tenure.Pin2;
                        QueryString += "&pin3=" + tenure.Pin3;
                        QueryString += "&pin4=" + tenure.Pin4;
                        QueryString += "&pin5=" + tenure.Pin5;
                        QueryString += "&pin6=" + tenure.Pin6;
                        QueryString += "&pin7=" + tenure.Pin7;
                        QueryString += "&pin8=" + tenure.Pin8;
                        QueryString += "&vcode=" + tenure.Ccode;
                        QueryString += "&vname=" + tenure.Vname;
                        QueryString += "&mschema=" + tenure.Schema + "'";

                    }

                }

                return "true";

        }


        public string talathi_certifyTenureChange(objCertify tenure, DbCommand dbCmd4)
        {
            
           
                tenure.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(tenure.Database, "LRSRO Connection StringMutation");

               
                ds = objclscommonfunedit.funReturnDataSet(tenure.Database, tenure.Schema + ".verify_mut_kharedi_buyer", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,buyer_khata_no as khata_no,mut_no,tenure_code,tenure_sub_code,tenure_sub_code1,buyer_name,usrno,buyer_anne,buyer_pai", "mut_no=" + tenure.Val + " and ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "' and buyer_doc_type1='52'", "");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ds1 = objclscommonfunedit.funReturnDataSet(tenure.Database, tenure.Schema + ".pre_form7", "distinct  mut_no", "ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", "");
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                            objclscommonfunedit.funUpdateValue(tenure.Database, tenure.Schema + ".pre_form7", "tenure_code=" + ds.Tables[0].Rows[i][12].ToString() + ",tenure_sub_code=" + ds.Tables[0].Rows[i][13].ToString() + ",tenure_sub_code1 =" + ds.Tables[0].Rows[i][14].ToString() + " , mut_no=" + tenure.Val + " ,old_mut_no=" + ds1.Tables[0].Rows[0][0].ToString() + "", "ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", ref dbCmd4);

                        for (int k = 0; k <= ds.Tables[0].Rows.Count - 1; k++)

                            objclscommonfunedit.funInserSingleValue(tenure.Database, tenure.Schema + ".pre_form7_orights", "ccode,numeric_pin,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,tenant_name,mut_no,usrno,other_rights_code,other_rights_sub_code", "'" + tenure.Ccode + "'," + ds.Tables[0].Rows[k]["pin"].ToString() + ",'" + ds.Tables[0].Rows[k]["pin"].ToString() + "','" + ds.Tables[0].Rows[k]["pin1"].ToString() + "', '" + ds.Tables[0].Rows[k]["pin2"].ToString() + "','" + ds.Tables[0].Rows[k]["pin3"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin4"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin5"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin6"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin7"].ToString() + "' ,'" + ds.Tables[0].Rows[k]["pin8"].ToString() + "','','" + ds.Tables[0].Rows[k]["mut_no"] + "','" + ds.Tables[0].Rows[k]["usrno"] + "'," + ds.Tables[0].Rows[k]["buyer_anne"] + "," + ds.Tables[0].Rows[k]["buyer_pai"] + "", ref dbCmd4);


                    }

                    ds = objclscommonfunedit.funReturnDataSet(tenure.Database, tenure.Schema + ".pre_form7", "mut_no,old_mut_no", "mut_no=" + tenure.Val + " and ccode = '" + tenure.Ccode + "'and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", "");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int mold_mutno = Convert.ToInt32(ds.Tables[0].Rows[0]["old_mut_no"]);
                        i4 = objclscommonfunedit.funReturnSingleValueInt(tenure.Database, tenure.Schema + ".pre_form7_mut_no", "COUNT(*)", "ccode = '" + tenure.Ccode + "' and mutation_no=" + mold_mutno + " and pin='" + tenure.Pin + "' and pin1='" + tenure.Pin1 + "' and  pin2='" + tenure.Pin2 + "' and pin3='" + tenure.Pin3 + "' and pin4='" + tenure.Pin4 + "' and pin5='" + tenure.Pin5 + "' and pin6='" + tenure.Pin6 + "'  and pin7='" + tenure.Pin7 + "' and pin8 ='" + tenure.Pin8 + "'", "");
                        if (i4 == 0 && mold_mutno > 0)
                            funForm7_MutEntry(tenure.Ccode, Convert.ToString(mold_mutno), tenure.Pin, tenure.Pin1, tenure.Pin2, tenure.Pin3, tenure.Pin4, tenure.Pin5, tenure.Pin6, tenure.Pin7, tenure.Pin8);
                    }
                }
                return "true";
          
        }
        private void funForm7_MutEntry(string ccode, string mut_no, string pin, string pin1, string pin2, string pin3, string pin4, string pin5, string pin6, string pin7, string pin8)
        {
            bool stat = false;
            foreach (DataRow dr in dtform7_mut_no.Select("ccode='" + ccode + "' and mut_no='" + mut_no + "' and pin='" + pin + "' and pin1='" + pin1 + "' and pin2='" + pin2 + "' and pin3='" + pin3 + "' and pin4='" + pin4 + "' and pin5='" + pin5 + "' and pin6='" + pin6 + "' and pin7='" + pin7 + "' and pin8='" + pin8 + "'"))
            {
                stat = true;
            }
            if (!stat && ccode != "")
            {
                DataRow dr = dtform7_mut_no.NewRow();
                dr["ccode"] = ccode;
                dr["mut_no"] = mut_no;
                dr["pin"] = pin;
                dr["pin1"] = pin1;
                dr["pin2"] = pin2;
                dr["pin3"] = pin3;
                dr["pin4"] = pin4;
                dr["pin5"] = pin5;
                dr["pin6"] = pin6;
                dr["pin7"] = pin7;
                dr["pin8"] = pin8;
                dtform7_mut_no.Rows.Add(dr);
                dtform7_mut_no.AcceptChanges();
            }
        }


       
    }
}
