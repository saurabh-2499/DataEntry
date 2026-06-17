// Rajptrane Badal, AAPpKa, EeKuMe Certification Logic.
// ====================================================

//1. Open mut_kharedi dataset (DS_MK)  with condition of ccode, mut_no 

//2 Open mut_kharedi_seller dataset (DS_MKS)  with condition of ccode, mut_no 

//3 Open mut_kharedi_buyer dataset (DS_MKB)  with condition of ccode, mut_no 

//4. Open holder_detail data set (DS_HD) with condition of ccode,fname,mname,lname,topan_name from mut_kharedi_seller
//   select ccode, khata_no, fname,mname,lname,topan_name

//5. Open form7_khata data set (DS_F7K) with condition of ccode,fname,mname,lname,topan_name
//   select ccode, khata_no, fname,mname,lname,topan_name

//7.    Loop thru DS_HD

//8.         set DS_HD("marked") = "Y", session(usrno) = DS_HD(usrno), session(:khata_no") = = DS_HD(khata_no)

//9.         Loop thru DS_MKB

//10.             Insert into DS_HD (buyer name assign ccode, and khata_no from sesion, usrno = session(usrno) + 0.01
             
//11,   Loop thru DS_MK  

//11        Loop thru DS_F7K

//12.         set DS_F7K("marked") = "Y", session(usrno) = DS_HD(usrno), session(khata_no) = = DS_F7K(khata_no)

//13.         Loop thru DS_MKB

//14.             Insert into DS_F7K (buyer name as fname etc assign ccode, and khata_no from sesion, usrno = session(usrno) + 0.01
               

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
     public class clsNameChangeRajPatrane
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

        DataSet DS_MK=new DataSet();
        DataSet DS_MKS = new DataSet();
        DataSet DS_MKB = new DataSet();
        DataSet DS_HD = new DataSet();
        DataSet DS_F7K = new DataSet();
        int i4 = 0;
         int count = 0;
         int pre_count = 0;
         string loginid = string.Empty;
        #endregion[---Global Data----]

         #region[--- Certify----]

        public string certifyRaj(objCertify raj, DbCommand dbCmd4)
        {
            
            
                raj.Flag = "true";
                DataBaseHandler dbHandler = new DataBaseHandler(raj.Database, "LRSRO Connection StringMutation");

                loginid = objclscommonfunedit.funReturnSingleValue(raj.Database, raj.Schema + ".m_officermast", "username", "ccode='" + raj.Ccode + "' and user_type='2'", "");

                #region[----History-------]
                ds_h = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".mut_kharedi", "*", "mut_no=" + raj.Val + " and ccode = '" + raj.Ccode + "'and  or_code3 =64", "");

                if (ds_h.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds_h.Tables[0].Rows.Count - 1; i++)
                    {
                        history.Ccode = raj.Ccode;
                        history.Pin = ds_h.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds_h.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds_h.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds_h.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds_h.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds_h.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds_h.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds_h.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds_h.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = raj.Schema;
                        history.Database = raj.Database;
                        history.Val = raj.Val;
                        history.User = raj.User;
                        objHistory.insertdata_history(history, dbCmd4);
                    }
                }
                #endregion[---- End of History-------]
               
                DS_MK = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".mut_kharedi", "*", "mut_no=" + raj.Val + " and ccode = '" + raj.Ccode + "'", "");
                foreach (DataRow DR_MK in DS_MK.Tables[0].Rows)
                {
                    DS_MKS = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".mut_kharedi_seller", "*", "mut_no='" + raj.Val + "' and ccode = '" + raj.Ccode + "' and  pin='" + DR_MK["pin"] + "'  and pin1='" + DR_MK["pin1"] + "'  and pin2='" + DR_MK["pin2"] + "'  and pin3='" + DR_MK["pin3"] + "' and pin4='" + DR_MK["pin4"] + "' and pin5='" + DR_MK["pin5"] + "' and pin6='" + DR_MK["pin6"] + "' and pin7='" + DR_MK["pin7"] + "'  and pin8='" + DR_MK["pin8"] + "'", "");
                }
                DS_MKB = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + raj.Val + "' and ccode = '" + raj.Ccode + "'", "");
                DS_HD = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".holder_detail", " ccode, khata_no,fname,mname,lname,topan_name,usrno,khata_type", "ccode = '" + raj.Ccode + "' and fname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["fname"]).Trim() + "' and mname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["mname"]).Trim() + "' and lname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["lname"]).Trim() + "' and topan_name = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["topan_name"]).Trim() + "'", "");
                DS_F7K = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".form7_khata ", "*", "ccode = '" + raj.Ccode + "' and fname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["fname"]).Trim() + "' and mname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["mname"]).Trim() + "' and lname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["lname"]).Trim() + "' and topan_name = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["topan_name"]).Trim() + "'", "");
                double user_no_hd = Convert.ToDouble(DS_HD.Tables[0].Rows[0]["usrno"]);
                string Khata_no_hd = DS_HD.Tables[0].Rows[0]["khata_no"].ToString();
                
                double user_no_f7k = Convert.ToDouble(DS_F7K.Tables[0].Rows[0]["usrno"]);
                string Khata_no_f7k = DS_F7K.Tables[0].Rows[0]["khata_no"].ToString();
                string mmut_no = DS_MK.Tables[0].Rows[0]["mut_no"].ToString();
                foreach (DataRow DR_HD in DS_HD.Tables[0].Rows)
                {
                    objclscommonfunedit.funUpdateValueSevarthID(raj.Database, raj.Schema + ".holder_detail", "marked='Y'", "ccode = '" + raj.Ccode + "' and fname = '" + Convert.ToString(DR_HD["fname"]) + "' and mname = '" + Convert.ToString(DR_HD["mname"]) + "' and lname = '" + Convert.ToString(DR_HD["lname"]) + "' and topan_name = '" + Convert.ToString(DR_HD["topan_name"]) + "' ", loginid, ref dbCmd4);

                    foreach (DataRow DR_MKB in DS_MKB.Tables[0].Rows)
                    {
                        if (count == 0)
                        {
                            objclscommonfunedit.funInserSingleValueSevarthID(raj.Database, raj.Schema + ".holder_detail", "ccode,fname,mname,lname,topan_name,khata_no,usrno,khata_type,old_mut_no", "'" + raj.Ccode + "' ,'" + DR_MKB["fname"] + "','" + DR_MKB["mname"] + "','" + DR_MKB["lname"] + "','" + DR_MKB["topan_name"] + "','" + Khata_no_hd + "','" + (user_no_hd + 0.01) + "','" + Convert.ToString(DR_HD["khata_type"]) + "' , '" + mmut_no.ToString() + "' ", loginid, ref dbCmd4);
                            count = 1;
                        }

                    }
                }
                //foreach (DataRow DR_MK in DS_MK.Tables[0].Rows)
                //{
                    foreach (DataRow DR_F7K in DS_F7K.Tables[0].Rows)
                    {
                        objclscommonfunedit.funUpdateValueSevarthID(raj.Database, raj.Schema + ".form7_khata", "marked='Y', old_mut_no='" + DR_F7K["mut_no"] + "', mut_no='" + raj.Val + "'", "ccode = '" + raj.Ccode + "' and fname = '" + Convert.ToString(DR_F7K["fname"]) + "' and mname = '" + Convert.ToString(DR_F7K["mname"]) + "' and lname = '" + Convert.ToString(DR_F7K["lname"]) + "' and topan_name = '" + Convert.ToString(DR_F7K["topan_name"]) + "' ", loginid, ref dbCmd4);
                        DS_MKB = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + raj.Val + "' and ccode = '" + raj.Ccode + "'  and pin='" + DR_F7K["pin"] + "'  and pin1='" + DR_F7K["pin1"] + "'  and pin2='" + DR_F7K["pin2"] + "'  and pin3='" + DR_F7K["pin3"] + "' and pin4='" + DR_F7K["pin4"] + "' and pin5='" + DR_F7K["pin5"] + "' and pin6='" + DR_F7K["pin6"] + "' and pin7='" + DR_F7K["pin7"] + "'  and pin8='" + DR_F7K["pin8"] + "'", "");
                        foreach (DataRow DR_MKB in DS_MKB.Tables[0].Rows)
                        {
                            objclscommonfunedit.funInserSingleValueSevarthID(raj.Database, raj.Schema + ".form7_khata", "ccode,fname,mname,lname,topan_name,khata_no,usrno,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,mut_no,total_area_h,assessment,anne,pai,potkharaba", "'" + raj.Ccode + "' ,'" + DR_MKB["fname"] + "','" + DR_MKB["mname"] + "','" + DR_MKB["lname"] + "','" + DR_MKB["topan_name"] + "','" + DR_F7K["khata_no"].ToString() + "'," + (user_no_f7k) + ", '" + DR_F7K["numeric_pin"].ToString() + "', '" + DR_F7K["pin"].ToString() + "', '" + DR_F7K["pin1"].ToString() + "','" + DR_F7K["pin2"].ToString() + "','" + DR_F7K["pin3"].ToString() + "','" + DR_F7K["pin4"].ToString() + "','" + DR_F7K["pin5"].ToString() + "','" + DR_F7K["pin6"].ToString() + "','" + DR_F7K["pin7"].ToString() + "','" + DR_F7K["pin8"].ToString() + "', '" + raj.Val.ToString() + "','" + DR_F7K["total_area_h"] + "','" + DR_F7K["assessment"] + "','" + DR_F7K["anne"] + "','" + DR_F7K["pai"] + "','" + DR_F7K["potkharaba"] + "'", loginid, ref dbCmd4);
                            //objclscommonfunedit.funInserSingleValue(raj.Database, raj.Schema + ".form8a", "ccode,khata_no,usrno,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,old_mut_no", "'" + raj.Ccode + "' ,'" + DR_F7K["khata_no"].ToString() + "'," + (user_no_f7k) + ", '" + DR_F7K["numeric_pin"].ToString() + "', '" + DR_F7K["pin"].ToString() + "', '" + DR_F7K["pin1"].ToString() + "','" + DR_F7K["pin2"].ToString() + "','" + DR_F7K["pin3"].ToString() + "','" + DR_F7K["pin4"].ToString() + "','" + DR_F7K["pin5"].ToString() + "','" + DR_F7K["pin6"].ToString() + "','" + DR_F7K["pin7"].ToString() + "','" + DR_F7K["pin8"].ToString() + "', '" + raj.Val.ToString() + "'", ref dbCmd4);
                        }
                    }
                    //}



                    #region[----History-------]
                    //ds_h = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".mut_kharedi", "*", "mut_no=" + raj.Val + " and ccode = '" + raj.Ccode + "'and  or_code3 =64", "");

                    //if (ds_h.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int i = 0; i <= ds_h.Tables[0].Rows.Count - 1; i++)
                    //    {
                    //        history.Ccode = raj.Ccode;
                    //        history.Pin = ds_h.Tables[0].Rows[i]["pin"].ToString();
                    //        history.Pin1 = ds_h.Tables[0].Rows[i]["pin1"].ToString();
                    //        history.Pin2 = ds_h.Tables[0].Rows[i]["pin2"].ToString();
                    //        history.Pin3 = ds_h.Tables[0].Rows[i]["pin3"].ToString();
                    //        history.Pin4 = ds_h.Tables[0].Rows[i]["pin4"].ToString();
                    //        history.Pin5 = ds_h.Tables[0].Rows[i]["pin5"].ToString();
                    //        history.Pin6 = ds_h.Tables[0].Rows[i]["pin6"].ToString();
                    //        history.Pin7 = ds_h.Tables[0].Rows[i]["pin7"].ToString();
                    //        history.Pin8 = ds_h.Tables[0].Rows[i]["pin8"].ToString();
                    //        history.Schema = raj.Schema;
                    //        history.Database = raj.Database;
                    //        objHistory.insertdata_history(history, dbCmd4);
                    //    }
                    //}
                    #endregion[---- End of History-------]

                    #region[---Certify Flag---]
                        //flag = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".tblrordetails", "*", "mutationno='" + raj.Val + "' and ccode = '" + raj.Ccode + "' ", "");
                        //int y = 0;
                        //foreach (DataRow dr in flag.Tables[0].Rows)
                        //{
                        //    objclscommonfunedit.funUpdateValue(raj.Database, raj.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + raj.Ccode + "' and  pin='" + flag.Tables[0].Rows[y]["pin"].ToString() + "' and pin1='" + flag.Tables[0].Rows[y]["pin1"].ToString() + "' and  pin2='" + flag.Tables[0].Rows[y]["pin2"].ToString() + "' and pin3='" + flag.Tables[0].Rows[y]["pin3"].ToString() + "' and pin4='" + flag.Tables[0].Rows[y]["pin4"].ToString() + "' and pin5='" + flag.Tables[0].Rows[y]["pin5"].ToString() + "' and pin6='" + flag.Tables[0].Rows[y]["pin6"].ToString() + "'  and pin7='" + flag.Tables[0].Rows[y]["pin7"].ToString() + "' and pin8 ='" + flag.Tables[0].Rows[y]["pin8"].ToString() + "'", ref dbCmd4);
                        //    y++;
                        //}
                    foreach (DataRow Dr_MK1 in DS_MK.Tables[0].Rows)
                    {
                        int old_mut_no = objclscommonfunedit.funReturnSingleValueInt(raj.Database, raj.Schema + ".form7_khata", "old_mut_no", "ccode='" + raj.Ccode + "' and mut_no='" + DS_MKS.Tables[0].Rows[0]["mut_no"] + "'and pin='" + Dr_MK1["pin"].ToString() + "' and pin1='" + Dr_MK1["pin1"].ToString() + "' and  pin2='" + Dr_MK1["pin2"].ToString() + "' and pin3='" + Dr_MK1["pin3"].ToString() + "' and pin4='" + Dr_MK1["pin4"].ToString() + "' and pin5='" + Dr_MK1["pin5"].ToString() + "' and pin6='" + Dr_MK1["pin6"].ToString() + "'  and pin7='" + Dr_MK1["pin7"].ToString() + "' and pin8 ='" + Dr_MK1["pin8"].ToString() + "'", "");
                        String Etar_mut_no = objclscommonfunedit.funReturnSingleValue(raj.Database, raj.Schema + ".form7_mut_no", "Count(*)", "ccode='" + raj.Ccode + "' and mutation_no='" + old_mut_no + "'and pin='" + Dr_MK1["pin"].ToString() + "' and pin1='" + Dr_MK1["pin1"].ToString() + "' and  pin2='" + Dr_MK1["pin2"].ToString() + "' and pin3='" + Dr_MK1["pin3"].ToString() + "' and pin4='" + Dr_MK1["pin4"].ToString() + "' and pin5='" + Dr_MK1["pin5"].ToString() + "' and pin6='" + Dr_MK1["pin6"].ToString() + "'  and pin7='" + Dr_MK1["pin7"].ToString() + "' and pin8 ='" + Dr_MK1["pin8"].ToString() + "'", "");

                        if (Etar_mut_no == "0" && old_mut_no != 0)
                        {
                            objclscommonfunedit.funInserSingleValueSevarthID(raj.Database, raj.Schema + ".form7_mut_no", "ccode,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,mutation_no", "''" + raj.Ccode + "','" + Dr_MK1["pin"].ToString() + "','" + Dr_MK1["pin"].ToString() + "','" + Dr_MK1["pin1"].ToString() + "', '" + Dr_MK1["pin2"].ToString() + "','" + Dr_MK1["pin3"].ToString() + "' ,'" + Dr_MK1["pin4"].ToString() + "' ,'" + Dr_MK1["pin5"].ToString() + "' ,'" + Dr_MK1["pin6"].ToString() + "' ,'" + Dr_MK1["pin7"].ToString() + "','" + Dr_MK1["pin8"].ToString() + "'," + old_mut_no + "'", loginid, ref dbCmd4);
                        }
                    }

                     



                        if (raj.Flag == "true")
                        {
                            objclscommonfunedit.funUpdateValueSevarthID(raj.Database, raj.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + raj.Ccode + "'and  mut_no=" + Convert.ToInt32(raj.Val) + "and remark='Itar-M'", loginid, ref dbCmd4);
                            objclscommonfunedit.funUpdateValueSevarthID(raj.Database, raj.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + raj.Ccode + "'and mut_no=" + Convert.ToInt32(raj.Val) + "", loginid, ref dbCmd4);

                            objclscommonfunedit.funUpdateValueSevarthID(raj.Database, raj.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + raj.Ccode + "' AND mutationno=" + raj.Val + "", loginid, ref dbCmd4);
                            // Application["view"] = "1";
                            // Session["CircleClick"] = "1";

                            if (raj.Mut_type != "9")
                            {
                                string QueryString = "";
                                QueryString += "'pg712.aspx?DatabaseName=" + raj.Database;
                                QueryString += "&pin=" + raj.Pin;
                                QueryString += "&pin1=" + raj.Pin1;
                                QueryString += "&pin2=" + raj.Pin2;
                                QueryString += "&pin3=" + raj.Pin3;
                                QueryString += "&pin4=" + raj.Pin4;
                                QueryString += "&pin5=" + raj.Pin5;
                                QueryString += "&pin6=" + raj.Pin6;
                                QueryString += "&pin7=" + raj.Pin7;
                                QueryString += "&pin8=" + raj.Pin8;
                                QueryString += "&vcode=" + raj.Ccode;
                                QueryString += "&vname=" + raj.Vname;
                                QueryString += "&mschema=" + raj.Schema + "'";

                            } 

                        }
                        #endregion[--- End Certify Flag---]

                return "true";
            

        }
        #endregion[--- End of Certify----]

         #region[--Preview---]

         public string precertifyRaj(objCertify raj, DbCommand dbCmd4)
         {
             
           
                 raj.Flag = "true";

                 DataBaseHandler dbHandler = new DataBaseHandler(raj.Database, "LRSRO Connection StringMutation");

                 DS_MK = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".mut_kharedi", "*", "mut_no=" + raj.Val + " and ccode = '" + raj.Ccode + "'", "");
                 DS_MKS = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".mut_kharedi_seller", "*", "mut_no='" + raj.Val + "' and ccode = '" + raj.Ccode + "'", "");
                 DS_MKB = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + raj.Val + "' and ccode = '" + raj.Ccode + "'", "");
                 DS_HD = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".pre_holder_detail", " ccode, khata_no,fname,mname,lname,topan_name,usrno,khata_type", "ccode = '" + raj.Ccode + "' and fname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["fname"]) + "' and mname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["mname"]) + "' and lname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["lname"]) + "' and topan_name = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["topan_name"]) + "'", "");
                 DS_F7K = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".pre_form7_khata ", "*", "ccode = '" + raj.Ccode + "' and fname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["fname"]) + "' and mname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["mname"]) + "' and lname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["lname"]) + "' and topan_name = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["topan_name"]) + "'", "");
                 double user_no_hd = Convert.ToDouble(DS_HD.Tables[0].Rows[0]["usrno"]);
                 string Khata_no_hd = DS_HD.Tables[0].Rows[0]["khata_no"].ToString();

                 double user_no_f7k = Convert.ToDouble(DS_F7K.Tables[0].Rows[0]["usrno"]);
                 string Khata_no_f7k = DS_F7K.Tables[0].Rows[0]["khata_no"].ToString();
                 string mmut_no = DS_MK.Tables[0].Rows[0]["mut_no"].ToString();
                 foreach (DataRow DR_HD in DS_HD.Tables[0].Rows)
                 {
                     objclscommonfunedit.funUpdateValue(raj.Database, raj.Schema + ".pre_holder_detail", "marked='Y'", "ccode = '" + raj.Ccode + "' and fname = '" + Convert.ToString(DR_HD["fname"]) + "' and mname = '" + Convert.ToString(DR_HD["mname"]) + "' and lname = '" + Convert.ToString(DR_HD["lname"]) + "' and topan_name = '" + Convert.ToString(DR_HD["topan_name"]) + "' ", ref dbCmd4);

                     foreach (DataRow DR_MKB in DS_MKB.Tables[0].Rows)
                     {
                         if (pre_count == 0)
                         {
                             objclscommonfunedit.funInserSingleValue(raj.Database, raj.Schema + ".pre_holder_detail", "ccode,fname,mname,lname,topan_name,khata_no,usrno,khata_type,old_mut_no", "'" + raj.Ccode + "' ,'" + DR_MKB["fname"] + "','" + DR_MKB["mname"] + "','" + DR_MKB["lname"] + "','" + DR_MKB["topan_name"] + "','" + Khata_no_hd + "','" + (user_no_hd + 0.01) + "','" + Convert.ToString(DR_HD["khata_type"]) + "' , '" + mmut_no.ToString() + "' ", ref dbCmd4);
                             pre_count = 1;
                         }
                     }
                 }



                 //foreach (DataRow DR_MK in DS_MK.Tables[0].Rows)
                 //{
                 foreach (DataRow DR_F7K in DS_F7K.Tables[0].Rows)
                 {
                     objclscommonfunedit.funUpdateValue(raj.Database, raj.Schema + ".pre_form7_khata", "marked='Y', old_mut_no='" + DR_F7K["mut_no"] + "', mut_no='" + raj.Val + "'", "ccode = '" + raj.Ccode + "' and fname = '" + Convert.ToString(DR_F7K["fname"]) + "' and mname = '" + Convert.ToString(DR_F7K["mname"]) + "' and lname = '" + Convert.ToString(DR_F7K["lname"]) + "' and topan_name = '" + Convert.ToString(DR_F7K["topan_name"]) + "' ", ref dbCmd4);
                     DS_MKB = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + raj.Val + "' and ccode = '" + raj.Ccode + "'  and pin='" + DR_F7K["pin"] + "'  and pin1='" + DR_F7K["pin1"] + "'  and pin2='" + DR_F7K["pin2"] + "'  and pin3='" + DR_F7K["pin3"] + "' and pin4='" + DR_F7K["pin4"] + "' and pin5='" + DR_F7K["pin5"] + "' and pin6='" + DR_F7K["pin6"] + "' and pin7='" + DR_F7K["pin7"] + "'  and pin8='" + DR_F7K["pin8"] + "'", "");
                     foreach (DataRow DR_MKB in DS_MKB.Tables[0].Rows)
                     {
                         //objclscommonfunedit.funInserSingleValue(raj.Database, raj.Schema + ".pre_form7_khata", "ccode,fname,mname,lname,topan_name,khata_no,usrno,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,mut_no", "'" + raj.Ccode + "' ,'" + DR_MKB["fname"] + "','" + DR_MKB["mname"] + "','" + DR_MKB["lname"] + "','" + DR_MKB["topan_name"] + "','" + DR_F7K["khata_no"].ToString() + "','" + (user_no_f7k + 0.01) + "' , '" + DR_F7K["numeric_pin"].ToString() + "', '" + DR_F7K["pin"].ToString() + "', '" + DR_F7K["pin1"].ToString() + "','" + DR_F7K["pin2"].ToString() + "','" + DR_F7K["pin3"].ToString() + "','" + DR_F7K["pin4"].ToString() + "','" + DR_F7K["pin5"].ToString() + "','" + DR_F7K["pin6"].ToString() + "','" + DR_F7K["pin7"].ToString() + "','" + DR_F7K["pin8"].ToString() + "', '" + raj.Val.ToString() + "'", ref dbCmd4);

                         objclscommonfunedit.funInserSingleValue(raj.Database, raj.Schema + ".pre_form7_khata", "ccode,fname,mname,lname,topan_name,khata_no,usrno,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,mut_no,total_area_h,assessment,anne,pai,potkharaba", "'" + raj.Ccode + "' ,'" + DR_MKB["fname"] + "','" + DR_MKB["mname"] + "','" + DR_MKB["lname"] + "','" + DR_MKB["topan_name"] + "','" + DR_F7K["khata_no"].ToString() + "'," + (user_no_f7k) + ", '" + DR_F7K["numeric_pin"].ToString() + "', '" + DR_F7K["pin"].ToString() + "', '" + DR_F7K["pin1"].ToString() + "','" + DR_F7K["pin2"].ToString() + "','" + DR_F7K["pin3"].ToString() + "','" + DR_F7K["pin4"].ToString() + "','" + DR_F7K["pin5"].ToString() + "','" + DR_F7K["pin6"].ToString() + "','" + DR_F7K["pin7"].ToString() + "','" + DR_F7K["pin8"].ToString() + "', '" + raj.Val.ToString() + "','" + DR_F7K["total_area_h"] + "','" + DR_F7K["assessment"] + "','" + DR_F7K["anne"] + "','" + DR_F7K["pai"] + "','" + DR_F7K["potkharaba"] + "'", ref dbCmd4);
                           
                     
                     
                     }
                 }
                 //}



                 flag = objclscommonfunedit.funReturnDataSet(raj.Database, raj.Schema + ".tblrordetails", "*", "mutationno='" + raj.Val + "' and ccode = '" + raj.Ccode + "' ", "");
                 int y = 0;
                 foreach (DataRow dr in flag.Tables[0].Rows)
                 {
                     objclscommonfunedit.funUpdateValue(raj.Database, raj.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + raj.Ccode + "' and  pin='" + flag.Tables[0].Rows[y]["pin"].ToString() + "' and pin1='" + flag.Tables[0].Rows[y]["pin1"].ToString() + "' and  pin2='" + flag.Tables[0].Rows[y]["pin2"].ToString() + "' and pin3='" + flag.Tables[0].Rows[y]["pin3"].ToString() + "' and pin4='" + flag.Tables[0].Rows[y]["pin4"].ToString() + "' and pin5='" + flag.Tables[0].Rows[y]["pin5"].ToString() + "' and pin6='" + flag.Tables[0].Rows[y]["pin6"].ToString() + "'  and pin7='" + flag.Tables[0].Rows[y]["pin7"].ToString() + "' and pin8 ='" + flag.Tables[0].Rows[y]["pin8"].ToString() + "'", ref dbCmd4);
                     y++;
                 }




                 // ----- end of main logic --------
                

               


                 

                 return "true";
            

         }

         #endregion[-- End of Preview---]


     }
}
