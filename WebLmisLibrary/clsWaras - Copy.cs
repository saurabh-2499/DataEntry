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
    public class clsWaras
    {
        clscommonfunedit objclscommonfunedit = new clscommonfunedit();
        clsHistory objHistory = new clsHistory();
        objCertify history = new objCertify();
        DataSet DS_MK = new DataSet();
        DataSet dsMutKharedi = new DataSet();
        DataSet dsMutKharediBuyer = new DataSet();
        DataSet dsMutOtherRights = new DataSet();       
        DataSet ds1 = new DataSet();
        DataSet ds8a = new DataSet();
        DataSet flag = new DataSet();
        DataSet ds_h = new DataSet();

       // DataSet DS_MK = new DataSet();
        DataSet DS_MKB = new DataSet();
        DataSet DS_MKS = new DataSet();
        DataSet DS_HD = new DataSet();
        DataSet DS_F7K = new DataSet();

        string loginid = string.Empty;
            
        int i4 = 0;

       
        
        public string certifyWaras(objCertify waras, DbCommand dbCmd4)
        {
            try
            {
                waras.Flag = "true";
                
                DataBaseHandler dbHandler = new DataBaseHandler(waras.Database, "LRSRO Connection StringMutation");

                loginid = objclscommonfunedit.funReturnSingleValue(waras.Database, waras.Schema + ".m_officermast", "username", "ccode='" + waras.Ccode + "' and user_type='1'", "");

                ds_h = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".mut_kharedi", "*", "mut_no=" + waras.Val + " and ccode = '" + waras.Ccode + "'and  or_code3 =64", "");

                if (ds_h.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds_h.Tables[0].Rows.Count - 1; i++)
                    {
                        history.Ccode = waras.Ccode;
                        history.Pin = ds_h.Tables[0].Rows[i]["pin"].ToString();
                        history.Pin1 = ds_h.Tables[0].Rows[i]["pin1"].ToString();
                        history.Pin2 = ds_h.Tables[0].Rows[i]["pin2"].ToString();
                        history.Pin3 = ds_h.Tables[0].Rows[i]["pin3"].ToString();
                        history.Pin4 = ds_h.Tables[0].Rows[i]["pin4"].ToString();
                        history.Pin5 = ds_h.Tables[0].Rows[i]["pin5"].ToString();
                        history.Pin6 = ds_h.Tables[0].Rows[i]["pin6"].ToString();
                        history.Pin7 = ds_h.Tables[0].Rows[i]["pin7"].ToString();
                        history.Pin8 = ds_h.Tables[0].Rows[i]["pin8"].ToString();
                        history.Schema = waras.Schema;
                        history.Database = waras.Database;
                        history.Val = waras.Val;
                        objHistory.insertdata_history(history, dbCmd4);
                    }
                }

                DS_MK = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".mut_kharedi", "or_code3", "mut_no=" + waras.Val+ " and ccode = '" + waras.Ccode+ "'", "");

                if (DS_MK.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x <= DS_MK.Tables[0].Rows.Count - 1; x++)
                    {
                        //if (DS_MK.Tables[0].Rows[0].ItemArray[0].ToString() == "64")
                        //{
                           // Waras_certify(dbCmd4);
                            
           // DataSet DS_MKS = new DataSet();
          //  DataSet DS_F7K = new DataSet();
          //  DataSet DS_MKB = new DataSet();
            DS_MKB = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + waras.Val + "' and ccode = '" + waras.Ccode+ "' and buyer_doc_type1=64", "");
            DS_MKS = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".mut_kharedi_seller", "*", "mut_no='" + waras.Val + "' and ccode = '" + waras.Ccode+ "' and seller_usrno=64 and seller_name='YES'", "");

            objclscommonfunedit.funUpdateValueSevarthID(waras.Database, waras.Schema + ".form7_khata", "marked='Y', old_mut_no=mut_no, mut_no='" + waras.Val + "'", "ccode = '" + waras.Ccode + "' and  fname = '" + DS_MKS.Tables[0].Rows[0][6] + "' and mname = '" + DS_MKS.Tables[0].Rows[0][7] + "' and lname = '" + DS_MKS.Tables[0].Rows[0][8] + "'", loginid, ref dbCmd4);
            objclscommonfunedit.funUpdateValueSevarthID(waras.Database, waras.Schema + ".holder_detail", "marked='Y'", "ccode = '" + waras.Ccode + "' and  fname = '" + DS_MKS.Tables[0].Rows[0][6] + "' and mname = '" + DS_MKS.Tables[0].Rows[0][7] + "' and lname = '" + DS_MKS.Tables[0].Rows[0][8] + "'", loginid, ref dbCmd4);
            if (DS_MKS.Tables[0].Rows.Count > 0)
            {
                DS_F7K = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".form7_khata a," + waras.Schema + ".holder_detail b", "a.khata_no,b.khata_type,a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8,a.mut_no,count(*) as usrno,avg(a.total_area_h),avg(a.assessment),avg(a.anne),avg(a.pai),avg(a.potkharaba)", "a.ccode = b.ccode and a.khata_no = b.khata_no and a.ccode = '" + waras.Ccode + "' and a.fname = '" + DS_MKS.Tables[0].Rows[0][6] + "' and a.mname = '" + DS_MKS.Tables[0].Rows[0][7] + "' and a.lname = '" + DS_MKS.Tables[0].Rows[0][8] + "' Group by a.khata_no,b.khata_type,a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8,a.mut_no", "");
                DataSet dskhata_usrno = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema+ ".holder_detail a," + waras.Schema+ ".form7_khata b", "a.khata_no,(max(a.usrno))+1 as usrno ", "a.ccode=b.ccode and a.ccode = '" + (string)waras.Ccode+ "' and a.fname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["fname"]) + "' and a.mname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["mname"]) + "' and a.lname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["lname"]) + "' and a.topan_name = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["topan_name"]) + "' and a.fname = b.fname and a.mname = b.mname and a.lname = b.lname and a.topan_name = b.topan_name and a.khata_no=b.khata_no Group by a.khata_no", "khata_no");
                if (DS_F7K.Tables[0].Rows.Count > 0)
                {
                    string mkhata_no = DS_F7K.Tables[0].Rows[0]["khata_no"].ToString();
                    int usrcount = Convert.ToInt32(DS_F7K.Tables[0].Rows[0][13].ToString());

                    for (int i = 0; i <= DS_F7K.Tables[0].Rows.Count - 1; i++) //survey number loop
                    {
                        int usrnoMax = 0;
                        foreach (DataRow dr in dskhata_usrno.Tables[0].Select("khata_no='" + DS_F7K.Tables[0].Rows[i]["khata_no"].ToString() + "'"))
                            usrnoMax = Convert.ToInt32(dr["usrno"]);
                        if (DS_F7K.Tables[0].Rows[i][1].ToString() == "1" && DS_MKB.Tables[0].Rows.Count > 1)
                            objclscommonfunedit.funUpdateValueSevarthID(waras.Database, waras.Schema + ".holder_detail", "khata_type =2", "ccode = '" + waras.Ccode + "'and fname = '" + DS_MKS.Tables[0].Rows[0][6] + "' and mname = '" + DS_MKS.Tables[0].Rows[0][7] + "' and lname = '" + DS_MKS.Tables[0].Rows[0][8] + "' and topan_name = '" + DS_MKS.Tables[0].Rows[0][9] + "' AND khata_type = 1", loginid, ref dbCmd4);

                        if (DS_MKB.Tables[0].Rows.Count > 0)
                        {
                            int k = 0;
                            for (int j = 0; j <= DS_MKB.Tables[0].Rows.Count - 1; j++) // new waras names 
                            {
                                Int32 i5 = Convert.ToInt32(objclscommonfunedit.funReturnSingleValueInt(waras.Database, waras.Schema + ".form7_khata", "COUNT(*)", "ccode='" + waras.Ccode+ "' and numeric_pin='" + DS_F7K.Tables[0].Rows[i]["pin"].ToString() + "' and  pin='" + DS_F7K.Tables[0].Rows[i]["pin"].ToString() + "' and  pin1='" + DS_F7K.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + DS_F7K.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + DS_F7K.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + DS_F7K.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + DS_F7K.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + DS_F7K.Tables[0].Rows[i]["pin6"].ToString() + "' and pin7='" + DS_F7K.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8='" + DS_F7K.Tables[0].Rows[i]["pin8"].ToString() + "' and khata_no='" + DS_F7K.Tables[0].Rows[i]["khata_no"].ToString() + "' and fname='" + DS_MKB.Tables[0].Rows[k]["fname"] + "' and mname='" + DS_MKB.Tables[0].Rows[k]["mname"] + "' and lname='" + DS_MKB.Tables[0].Rows[k]["lname"] + "' and topan_name='" + DS_MKB.Tables[0].Rows[k]["topan_name"] + "' and usrno='" + usrnoMax + "'", ""));
                                if (i5 == 0)
                                {
                                    if (DS_F7K.Tables[0].Rows[i][1].ToString() == "1" && j == 0)//***************for single New Khata
                                        objclscommonfunedit.funInserSingleValueSevarthID(waras.Database, waras.Schema + ".form7_khata", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,fname,mname,lname,topan_name,khata_no,usrno, old_mut_no,mut_no,total_area_h,assessment,anne,pai,potkharaba", "'" + waras.Ccode + "' ," + DS_F7K.Tables[0].Rows[i][2].ToString() + ",'" + DS_F7K.Tables[0].Rows[i][3].ToString() + "', '" + DS_F7K.Tables[0].Rows[i][4].ToString() + "','" + DS_F7K.Tables[0].Rows[i][5].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][6].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][7].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][8].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][9].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][10].ToString() + "','" + DS_F7K.Tables[0].Rows[i][11].ToString() + "','" + DS_MKB.Tables[0].Rows[k][20] + "','" + DS_MKB.Tables[0].Rows[k][21] + "','" + DS_MKB.Tables[0].Rows[k][22] + "','" + DS_MKB.Tables[0].Rows[k][23] + "'," + DS_F7K.Tables[0].Rows[i][0].ToString() + "," + usrnoMax + "," + DS_F7K.Tables[0].Rows[i][12].ToString() + ",'" + waras.Val + "', " + Convert.ToDecimal(DS_F7K.Tables[0].Rows[i][14]) + "," + Convert.ToDecimal(DS_F7K.Tables[0].Rows[i][15]) + "," + Convert.ToInt32(DS_F7K.Tables[0].Rows[i][16]) + "," + Convert.ToInt32(DS_F7K.Tables[0].Rows[i][17]) + "," + Convert.ToDecimal(DS_F7K.Tables[0].Rows[i][18]) + "", loginid, ref dbCmd4);
                                    else
                                    {
                                        if (j == 0)
                                            objclscommonfunedit.funInserSingleValueSevarthID(waras.Database, waras.Schema + ".form7_khata", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,fname,mname,lname,topan_name,khata_no,usrno, old_mut_no,mut_no,total_area_h,assessment,anne,pai,potkharaba", "'" + waras.Ccode + "' ," + DS_F7K.Tables[0].Rows[i][2].ToString() + ",'" + DS_F7K.Tables[0].Rows[i][3].ToString() + "', '" + DS_F7K.Tables[0].Rows[i][4].ToString() + "','" + DS_F7K.Tables[0].Rows[i][5].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][6].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][7].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][8].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][9].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][10].ToString() + "','" + DS_F7K.Tables[0].Rows[i][11].ToString() + "','" + DS_MKB.Tables[0].Rows[k][20] + "','" + DS_MKB.Tables[0].Rows[k][21] + "','" + DS_MKB.Tables[0].Rows[k][22] + "','" + DS_MKB.Tables[0].Rows[k][23] + "'," + DS_F7K.Tables[0].Rows[i][0].ToString() + "," + usrnoMax + "," + DS_F7K.Tables[0].Rows[i][12].ToString() + ",'" + waras.Val + "', " + Convert.ToDecimal(DS_F7K.Tables[0].Rows[i][14]) + "," + Convert.ToDecimal(DS_F7K.Tables[0].Rows[i][15]) + "," + Convert.ToInt32(DS_F7K.Tables[0].Rows[i][16]) + "," + Convert.ToInt32(DS_F7K.Tables[0].Rows[i][17]) + "," + Convert.ToDecimal(DS_F7K.Tables[0].Rows[i][18]) + "", loginid, ref dbCmd4);
                                        else
                                            objclscommonfunedit.funInserSingleValueSevarthID(waras.Database, waras.Schema + ".form7_khata", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,fname,mname,lname,topan_name,khata_no,usrno, old_mut_no,mut_no", "'" + waras.Ccode + "' ," + DS_F7K.Tables[0].Rows[i][2].ToString() + ",'" + DS_F7K.Tables[0].Rows[i][3].ToString() + "', '" + DS_F7K.Tables[0].Rows[i][4].ToString() + "','" + DS_F7K.Tables[0].Rows[i][5].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][6].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][7].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][8].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][9].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][10].ToString() + "','" + DS_F7K.Tables[0].Rows[i][11].ToString() + "','" + DS_MKB.Tables[0].Rows[k][20] + "','" + DS_MKB.Tables[0].Rows[k][21] + "','" + DS_MKB.Tables[0].Rows[k][22] + "','" + DS_MKB.Tables[0].Rows[k][23] + "'," + DS_F7K.Tables[0].Rows[i][0].ToString() + "," + usrnoMax + "," + DS_F7K.Tables[0].Rows[i][12].ToString() + ",'" + waras.Val + "'", loginid, ref dbCmd4);
                                    }
                                    k++;
                                    usrnoMax++;
                                }
                              //  this.funForm7_MutEntry((string)ViewState["ccode"], Convert.ToString(waras.Val), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin1"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin2"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin3"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin4"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin5"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin6"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin7"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin8"]));
                            }
                        }

                        if ((DS_F7K.Tables[0].Rows[i][0].ToString() != mkhata_no) || (i == 0))
                        {
                            int usrnoMax1 = Convert.ToInt32(DS_F7K.Tables[0].Rows[i]["usrno"].ToString());
                            foreach (DataRow dr in dskhata_usrno.Tables[0].Select("khata_no='" + DS_F7K.Tables[0].Rows[i]["khata_no"].ToString() + "'"))
                                usrnoMax1 = Convert.ToInt32(dr["usrno"]);
                            int m = DS_MKB.Tables[0].Rows.Count;
                            int n = 0;
                            Int32 iCount = Convert.ToInt32(objclscommonfunedit.funReturnSingleValueInt(waras.Database, waras.Schema + ".holder_detail", "COUNT(*)", "ccode = '" + waras.Ccode+ "' and khata_no='" + DS_F7K.Tables[0].Rows[i]["khata_no"].ToString() + "' and usrno='" + DS_F7K.Tables[0].Rows[i]["usrno"].ToString() + "' and fname='" + DS_MKB.Tables[0].Rows[n]["fname"].ToString() + "' and mname='" + DS_MKB.Tables[0].Rows[n]["mname"].ToString() + "' and lname='" + DS_MKB.Tables[0].Rows[n]["lname"].ToString() + "' and topan_name='" + DS_MKB.Tables[0].Rows[n]["topan_name"].ToString() + "'", ""));
                            if (iCount == 0)
                            {
                                if (m > 1)
                                {
                                    while (m > 0)
                                    {
                                        objclscommonfunedit.funInserSingleValueSevarthID(waras.Database, waras.Schema + ".holder_detail", "ccode,fname,mname,lname,topan_name,khata_no,usrno, old_mut_no,khata_type", "'" + waras.Ccode + "' ,'" + DS_MKB.Tables[0].Rows[n][20] + "','" + DS_MKB.Tables[0].Rows[n][21] + "','" + DS_MKB.Tables[0].Rows[n][22] + "','" + DS_MKB.Tables[0].Rows[n][23] + "'," + DS_F7K.Tables[0].Rows[i][0].ToString() + "," + usrnoMax1 + "," + waras.Val + ",'2'", loginid, ref dbCmd4);
                                        usrnoMax1++;
                                        n++;
                                        m--;
                                    }
                                }
                                else
                                {
                                    objclscommonfunedit.funInserSingleValueSevarthID(waras.Database, waras.Schema + ".holder_detail", "ccode,fname,mname,lname,topan_name,khata_no,usrno, old_mut_no,khata_type", "'" + waras.Ccode + "' ,'" + DS_MKB.Tables[0].Rows[n][20] + "','" + DS_MKB.Tables[0].Rows[n][21] + "','" + DS_MKB.Tables[0].Rows[n][22] + "','" + DS_MKB.Tables[0].Rows[n][23] + "'," + DS_F7K.Tables[0].Rows[i][0].ToString() + "," + usrnoMax1 + "," + DS_F7K.Tables[0].Rows[i][12].ToString() + "," + DS_F7K.Tables[0].Rows[i][1].ToString() + "", loginid, ref dbCmd4);
                                    usrnoMax1++;
                                    n++;
                                }
                            }
                        }
                        mkhata_no = DS_F7K.Tables[0].Rows[i]["khata_no"].ToString();
                    }
                }
            }

                       // }
                       

                        flag = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".tblrordetails", "*", "mutationno='" + waras.Val + "' and ccode = '" + waras.Ccode + "' ", "");
                        int y=0;
                        foreach (DataRow dr in flag.Tables[0].Rows)
                           
                        {
                            objclscommonfunedit.funUpdateValueSevarthID(waras.Database, waras.Schema + ".tblrordetails", "pending_mut_flag='F'", " ccode = '" + waras.Ccode + "' and  pin='" + flag.Tables[0].Rows[y]["pin"].ToString() + "' and pin1='" + flag.Tables[0].Rows[y]["pin1"].ToString() + "' and  pin2='" + flag.Tables[0].Rows[y]["pin2"].ToString() + "' and pin3='" + flag.Tables[0].Rows[y]["pin3"].ToString() + "' and pin4='" + flag.Tables[0].Rows[y]["pin4"].ToString() + "' and pin5='" + flag.Tables[0].Rows[y]["pin5"].ToString() + "' and pin6='" + flag.Tables[0].Rows[y]["pin6"].ToString() + "'  and pin7='" + flag.Tables[0].Rows[y]["pin7"].ToString() + "' and pin8 ='" + flag.Tables[0].Rows[y]["pin8"].ToString() + "'", loginid, ref dbCmd4);
                            y++;
                        }

                       
                        
                    }

                   

                }


                if (waras.Flag == "true")
                {
                    objclscommonfunedit.funUpdateValueSevarthID(waras.Database, waras.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + waras.Ccode + "'and  mut_no=" + Convert.ToInt32(waras.Val) , loginid, ref dbCmd4);
                    objclscommonfunedit.funUpdateValueSevarthID(waras.Database, waras.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + waras.Ccode + "'and mut_no=" + Convert.ToInt32(waras.Val) + "", loginid, ref dbCmd4);
                   // objclscommonfunedit.funUpdateValue(waras.Database, waras.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + waras.Ccode + "' AND mutationno=" + waras.Val + "", ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (waras.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + waras.Database;
                        QueryString += "&pin=" + waras.Pin;
                        QueryString += "&pin1=" + waras.Pin1;
                        QueryString += "&pin2=" + waras.Pin2;
                        QueryString += "&pin3=" + waras.Pin3;
                        QueryString += "&pin4=" + waras.Pin4;
                        QueryString += "&pin5=" + waras.Pin5;
                        QueryString += "&pin6=" + waras.Pin6;
                        QueryString += "&pin7=" + waras.Pin7;
                        QueryString += "&pin8=" + waras.Pin8;
                        QueryString += "&vcode=" + waras.Ccode;
                        QueryString += "&vname=" + waras.Vname;
                        QueryString += "&mschema=" + waras.Schema + "'";

                    }

                }

                return "true";
            }
            catch (Exception ex)
            {
                return "false";
            }

        }


        public string precertifyWaras(objCertify waras, DbCommand dbCmd4)
        {
            try
            {
                waras.Flag = "true";

                DataBaseHandler dbHandler = new DataBaseHandler(waras.Database, "LRSRO Connection StringMutation");



                DS_MK = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".mut_kharedi", "or_code3", "mut_no=" + waras.Val + " and ccode = '" + waras.Ccode + "'and pin='" + waras.Pin + "' and pin1='" + waras.Pin1 + "' and  pin2='" + waras.Pin2 + "' and pin3='" + waras.Pin3 + "' and pin4='" + waras.Pin4 + "' and pin5='" + waras.Pin5 + "' and pin6='" + waras.Pin6 + "'  and pin7='" + waras.Pin7 + "' and pin8 ='" + waras.Pin8 + "'", "");

                if (DS_MK.Tables[0].Rows.Count > 0)
                {
                    for (int x = 0; x <= DS_MK.Tables[0].Rows.Count - 1; x++)
                    {
                        if (DS_MK.Tables[0].Rows[0].ItemArray[0].ToString() == "64")
                        {
                            // Waras_certify(dbCmd4);

                            DataSet DS_MKS = new DataSet();
                            DataSet DS_F7K = new DataSet();
                            DataSet DS_MKB = new DataSet();
                            DS_MKB = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".mut_kharedi_buyer", "*", "mut_no='" + waras.Val + "' and ccode = '" + waras.Ccode + "'and pin='" + waras.Pin + "' and pin1='" + waras.Pin1 + "' and  pin2='" + waras.Pin2 + "' and pin3='" + waras.Pin3 + "' and pin4='" + waras.Pin4 + "' and pin5='" + waras.Pin5 + "' and pin6='" + waras.Pin6 + "'  and pin7='" + waras.Pin7 + "' and pin8 ='" + waras.Pin8.ToString() + "' and buyer_doc_type1=64", "");
                            DS_MKS = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".mut_kharedi_seller", "*", "mut_no='" + waras.Val + "' and ccode = '" + waras.Ccode + "'and pin='" + waras.Pin + "' and pin1='" + waras.Pin1 + "' and  pin2='" + waras.Pin2 + "' and pin3='" + waras.Pin3 + "' and pin4='" + waras.Pin4 + "' and pin5='" + waras.Pin5 + "' and pin6='" + waras.Pin6 + "'  and pin7='" + waras.Pin7 + "' and pin8 ='" + waras.Pin8 + "' and seller_usrno=64 and seller_name='YES'", "");

                            objclscommonfunedit.funUpdateValue(waras.Database, waras.Schema + ".pre_form7_khata", "marked='Y', old_mut_no=mut_no, mut_no='" + waras.Val + "'", "ccode = '" + waras.Ccode + "' and  fname = '" + DS_MKS.Tables[0].Rows[0][6] + "' and mname = '" + DS_MKS.Tables[0].Rows[0][7] + "' and lname = '" + DS_MKS.Tables[0].Rows[0][8] + "'", ref dbCmd4);
                            objclscommonfunedit.funUpdateValue(waras.Database, waras.Schema + ".pre_holder_detail", "marked='Y'", "ccode = '" + waras.Ccode + "' and  fname = '" + DS_MKS.Tables[0].Rows[0][6] + "' and mname = '" + DS_MKS.Tables[0].Rows[0][7] + "' and lname = '" + DS_MKS.Tables[0].Rows[0][8] + "'", ref dbCmd4);
                            if (DS_MKS.Tables[0].Rows.Count > 0)
                            {
                                DS_F7K = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".form7_khata a," + waras.Schema + ".pre_holder_detail b", "a.khata_no,b.khata_type,a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8,a.mut_no,count(*) as usrno,avg(a.total_area_h),avg(a.assessment),avg(a.anne),avg(a.pai)", "a.ccode = b.ccode and a.khata_no = b.khata_no and a.ccode = '" + waras.Ccode + "' and a.fname = '" + DS_MKS.Tables[0].Rows[0][6] + "' and a.mname = '" + DS_MKS.Tables[0].Rows[0][7] + "' and a.lname = '" + DS_MKS.Tables[0].Rows[0][8] + "' Group by a.khata_no,b.khata_type,a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8,a.mut_no", "");
                                DataSet dskhata_usrno = objclscommonfunedit.funReturnDataSet(waras.Database, waras.Schema + ".holder_detail a," + waras.Schema + ".pre_form7_khata b", "a.khata_no,(max(a.usrno))+1 as usrno ", "a.ccode=b.ccode and a.ccode = '" + (string)waras.Ccode + "' and a.fname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["fname"]) + "' and a.mname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["mname"]) + "' and a.lname = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["lname"]) + "' and a.topan_name = '" + Convert.ToString(DS_MKS.Tables[0].Rows[0]["topan_name"]) + "' and a.fname = b.fname and a.mname = b.mname and a.lname = b.lname and a.topan_name = b.topan_name and a.khata_no=b.khata_no Group by a.khata_no", "khata_no");
                                if (DS_F7K.Tables[0].Rows.Count > 0)
                                {
                                    string mkhata_no = DS_F7K.Tables[0].Rows[0]["khata_no"].ToString();
                                    int usrcount = Convert.ToInt32(DS_F7K.Tables[0].Rows[0][13].ToString());

                                    for (int i = 0; i <= DS_F7K.Tables[0].Rows.Count - 1; i++) //survey number loop
                                    {
                                        int usrnoMax = 0;
                                        foreach (DataRow dr in dskhata_usrno.Tables[0].Select("khata_no='" + DS_F7K.Tables[0].Rows[i]["khata_no"].ToString() + "'"))
                                            usrnoMax = Convert.ToInt32(dr["usrno"]);
                                        if (DS_F7K.Tables[0].Rows[i][1].ToString() == "1" && DS_MKB.Tables[0].Rows.Count > 1)
                                            objclscommonfunedit.funUpdateValue(waras.Database, waras.Schema + ".pre_holder_detail", "khata_type =2", "ccode = '" + waras.Ccode + "'and fname = '" + DS_MKS.Tables[0].Rows[0][6] + "' and mname = '" + DS_MKS.Tables[0].Rows[0][7] + "' and lname = '" + DS_MKS.Tables[0].Rows[0][8] + "' and topan_name = '" + DS_MKS.Tables[0].Rows[0][9] + "' AND khata_type = 1", ref dbCmd4);

                                        if (DS_MKB.Tables[0].Rows.Count > 0)
                                        {
                                            int k = 0;
                                            for (int j = 0; j <= DS_MKB.Tables[0].Rows.Count - 1; j++) // new waras names 
                                            {
                                                Int32 i5 = Convert.ToInt32(objclscommonfunedit.funReturnSingleValueInt(waras.Database, waras.Schema + ".form7_khata", "COUNT(*)", "ccode='" + waras.Ccode + "' and numeric_pin='" + DS_F7K.Tables[0].Rows[i]["pin"].ToString() + "' and  pin='" + DS_F7K.Tables[0].Rows[i]["pin"].ToString() + "' and  pin1='" + DS_F7K.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + DS_F7K.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + DS_F7K.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + DS_F7K.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + DS_F7K.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + DS_F7K.Tables[0].Rows[i]["pin6"].ToString() + "' and pin7='" + DS_F7K.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8='" + DS_F7K.Tables[0].Rows[i]["pin8"].ToString() + "' and khata_no='" + DS_F7K.Tables[0].Rows[i]["khata_no"].ToString() + "' and fname='" + DS_MKB.Tables[0].Rows[k]["fname"] + "' and mname='" + DS_MKB.Tables[0].Rows[k]["mname"] + "' and lname='" + DS_MKB.Tables[0].Rows[k]["lname"] + "' and topan_name='" + DS_MKB.Tables[0].Rows[k]["topan_name"] + "' and usrno='" + usrnoMax + "'", ""));
                                                if (i5 == 0)
                                                {
                                                    if (DS_F7K.Tables[0].Rows[i][1].ToString() == "1" && j == 0)//***************for single New Khata
                                                        objclscommonfunedit.funInserSingleValue(waras.Database, waras.Schema + ".pre_form7_khata", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,fname,mname,lname,topan_name,khata_no,usrno, old_mut_no,mut_no,total_area_h,assessment,anne,pai", "'" + waras.Ccode + "' ," + DS_F7K.Tables[0].Rows[i][2].ToString() + ",'" + DS_F7K.Tables[0].Rows[i][3].ToString() + "', '" + DS_F7K.Tables[0].Rows[i][4].ToString() + "','" + DS_F7K.Tables[0].Rows[i][5].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][6].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][7].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][8].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][9].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][10].ToString() + "','" + DS_F7K.Tables[0].Rows[i][11].ToString() + "','" + DS_MKB.Tables[0].Rows[k][20] + "','" + DS_MKB.Tables[0].Rows[k][21] + "','" + DS_MKB.Tables[0].Rows[k][22] + "','" + DS_MKB.Tables[0].Rows[k][23] + "'," + DS_F7K.Tables[0].Rows[i][0].ToString() + "," + usrnoMax + "," + DS_F7K.Tables[0].Rows[i][12].ToString() + ",'" + waras.Val + "', " + Convert.ToDecimal(DS_F7K.Tables[0].Rows[i][14]) + "," + Convert.ToDecimal(DS_F7K.Tables[0].Rows[i][15]) + "," + Convert.ToInt32(DS_F7K.Tables[0].Rows[i][16]) + "," + Convert.ToInt32(DS_F7K.Tables[0].Rows[i][17]) + "", ref dbCmd4);
                                                    else
                                                    {
                                                        if (j == 0)
                                                            objclscommonfunedit.funInserSingleValue(waras.Database, waras.Schema + ".pre_form7_khata", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,fname,mname,lname,topan_name,khata_no,usrno, old_mut_no,mut_no,total_area_h,assessment,anne,pai", "'" + waras.Ccode + "' ," + DS_F7K.Tables[0].Rows[i][2].ToString() + ",'" + DS_F7K.Tables[0].Rows[i][3].ToString() + "', '" + DS_F7K.Tables[0].Rows[i][4].ToString() + "','" + DS_F7K.Tables[0].Rows[i][5].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][6].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][7].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][8].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][9].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][10].ToString() + "','" + DS_F7K.Tables[0].Rows[i][11].ToString() + "','" + DS_MKB.Tables[0].Rows[k][20] + "','" + DS_MKB.Tables[0].Rows[k][21] + "','" + DS_MKB.Tables[0].Rows[k][22] + "','" + DS_MKB.Tables[0].Rows[k][23] + "'," + DS_F7K.Tables[0].Rows[i][0].ToString() + "," + usrnoMax + "," + DS_F7K.Tables[0].Rows[i][12].ToString() + ",'" + waras.Val + "', " + Convert.ToDecimal(DS_F7K.Tables[0].Rows[i][14]) + "," + Convert.ToDecimal(DS_F7K.Tables[0].Rows[i][15]) + "," + Convert.ToInt32(DS_F7K.Tables[0].Rows[i][16]) + "," + Convert.ToInt32(DS_F7K.Tables[0].Rows[i][17]) + "", ref dbCmd4);
                                                        else
                                                            objclscommonfunedit.funInserSingleValue(waras.Database, waras.Schema + ".pre_form7_khata", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8,fname,mname,lname,topan_name,khata_no,usrno, old_mut_no,mut_no", "'" + waras.Ccode + "' ," + DS_F7K.Tables[0].Rows[i][2].ToString() + ",'" + DS_F7K.Tables[0].Rows[i][3].ToString() + "', '" + DS_F7K.Tables[0].Rows[i][4].ToString() + "','" + DS_F7K.Tables[0].Rows[i][5].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][6].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][7].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][8].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][9].ToString() + "' ,'" + DS_F7K.Tables[0].Rows[i][10].ToString() + "','" + DS_F7K.Tables[0].Rows[i][11].ToString() + "','" + DS_MKB.Tables[0].Rows[k][20] + "','" + DS_MKB.Tables[0].Rows[k][21] + "','" + DS_MKB.Tables[0].Rows[k][22] + "','" + DS_MKB.Tables[0].Rows[k][23] + "'," + DS_F7K.Tables[0].Rows[i][0].ToString() + "," + usrnoMax + "," + DS_F7K.Tables[0].Rows[i][12].ToString() + ",'" + waras.Val + "'", ref dbCmd4);
                                                    }
                                                    k++;
                                                    usrnoMax++;
                                                }
                                                //  this.funForm7_MutEntry((string)ViewState["ccode"], Convert.ToString(waras.Val), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin1"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin2"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin3"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin4"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin5"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin6"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin7"]), Convert.ToString(DS_F7K.Tables[0].Rows[i]["pin8"]));
                                            }
                                        }

                                        if ((DS_F7K.Tables[0].Rows[i][0].ToString() != mkhata_no) || (i == 0))
                                        {
                                            int usrnoMax1 = Convert.ToInt32(DS_F7K.Tables[0].Rows[i]["usrno"].ToString());
                                            foreach (DataRow dr in dskhata_usrno.Tables[0].Select("khata_no='" + DS_F7K.Tables[0].Rows[i]["khata_no"].ToString() + "'"))
                                                usrnoMax1 = Convert.ToInt32(dr["usrno"]);
                                            int m = DS_MKB.Tables[0].Rows.Count;
                                            int n = 0;
                                            Int32 iCount = Convert.ToInt32(objclscommonfunedit.funReturnSingleValueInt(waras.Database, waras.Schema + ".holder_detail", "COUNT(*)", "ccode = '" + waras.Ccode + "' and khata_no='" + DS_F7K.Tables[0].Rows[i]["khata_no"].ToString() + "' and usrno='" + DS_F7K.Tables[0].Rows[i]["usrno"].ToString() + "' and fname='" + DS_MKB.Tables[0].Rows[n]["fname"].ToString() + "' and mname='" + DS_MKB.Tables[0].Rows[n]["mname"].ToString() + "' and lname='" + DS_MKB.Tables[0].Rows[n]["lname"].ToString() + "' and topan_name='" + DS_MKB.Tables[0].Rows[n]["topan_name"].ToString() + "'", ""));
                                            if (iCount == 0)
                                            {
                                                if (m > 1)
                                                {
                                                    while (m > 0)
                                                    {
                                                        objclscommonfunedit.funInserSingleValue(waras.Database, waras.Schema + ".pre_holder_detail", "ccode,fname,mname,lname,topan_name,khata_no,usrno, old_mut_no,khata_type", "'" + waras.Ccode + "' ,'" + DS_MKB.Tables[0].Rows[n][20] + "','" + DS_MKB.Tables[0].Rows[n][21] + "','" + DS_MKB.Tables[0].Rows[n][22] + "','" + DS_MKB.Tables[0].Rows[n][23] + "'," + DS_F7K.Tables[0].Rows[i][0].ToString() + "," + usrnoMax1 + "," + DS_F7K.Tables[0].Rows[i][12].ToString() + ",'2'", ref dbCmd4);
                                                        usrnoMax1++;
                                                        n++;
                                                        m--;
                                                    }
                                                }
                                                else
                                                {
                                                    objclscommonfunedit.funInserSingleValue(waras.Database, waras.Schema + ".pre_holder_detail", "ccode,fname,mname,lname,topan_name,khata_no,usrno, old_mut_no,khata_type", "'" + waras.Ccode + "' ,'" + DS_MKB.Tables[0].Rows[n][20] + "','" + DS_MKB.Tables[0].Rows[n][21] + "','" + DS_MKB.Tables[0].Rows[n][22] + "','" + DS_MKB.Tables[0].Rows[n][23] + "'," + DS_F7K.Tables[0].Rows[i][0].ToString() + "," + usrnoMax1 + "," + DS_F7K.Tables[0].Rows[i][12].ToString() + "," + DS_F7K.Tables[0].Rows[i][1].ToString() + "", ref dbCmd4);
                                                    usrnoMax1++;
                                                    n++;
                                                }
                                            }
                                        }
                                        mkhata_no = DS_F7K.Tables[0].Rows[i]["khata_no"].ToString();
                                    }
                                }
                            }

                           // objclscommonfunedit.funUpdateValue(waras.Database, waras.Schema + ".mut_kharedi", "or_code4=1", "ccode = '" + waras.Ccode + "'and pin='" + waras.Pin + "' and pin1='" + waras.Pin1 + "' and  pin2='" + waras.Pin2 + "' and pin3='" + waras.Pin3 + "' and pin4='" + waras.Pin4 + "' and pin5='" + waras.Pin5 + "' and pin6='" + waras.Pin6 + "'  and pin7='" + waras.Pin7 + "' and pin8 ='" + waras.Pin8 + "'", ref dbCmd4);
                        }
                       

                    }

                }


                if (waras.Flag == "true")
                {
                    //objclscommonfunedit.funUpdateValue(waras.Database, waras.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + waras.Ccode + "'and  mut_no=" + Convert.ToInt32(waras.Val) + "and remark='Itar-M'", ref dbCmd4);
                    //objclscommonfunedit.funUpdateValue(waras.Database, waras.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + waras.Ccode + "'and mut_no=" + Convert.ToInt32(waras.Val) + "", ref dbCmd4);
                    // objclscommonfunedit.funUpdateValue(waras.Database, waras.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + waras.Ccode + "' AND mutationno=" + waras.Val + "", ref dbCmd4);
                    // Application["view"] = "1";
                    // Session["CircleClick"] = "1";

                    if (waras.Mut_type != "9")
                    {
                        string QueryString = "";
                        QueryString += "'pg712.aspx?DatabaseName=" + waras.Database;
                        QueryString += "&pin=" + waras.Pin;
                        QueryString += "&pin1=" + waras.Pin1;
                        QueryString += "&pin2=" + waras.Pin2;
                        QueryString += "&pin3=" + waras.Pin3;
                        QueryString += "&pin4=" + waras.Pin4;
                        QueryString += "&pin5=" + waras.Pin5;
                        QueryString += "&pin6=" + waras.Pin6;
                        QueryString += "&pin7=" + waras.Pin7;
                        QueryString += "&pin8=" + waras.Pin8;
                        QueryString += "&vcode=" + waras.Ccode;
                        QueryString += "&vname=" + waras.Vname;
                        QueryString += "&mschema=" + waras.Schema + "'";

                    }

                }

                return "true";
            }
            catch (Exception ex)
            {
                return "false";
            }

        }

    }
    }

