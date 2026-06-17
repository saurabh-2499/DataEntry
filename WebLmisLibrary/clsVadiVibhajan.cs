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
    public class clsVadiVibhajan
    {
        clscommonfunedit objclscommonfunedit = new clscommonfunedit();
        clsCommonFunction objclscommonfun = new clsCommonFunction();
        clsHistory objHistory = new clsHistory();


        int mflag = 0;
        int i4 = 0;
        objCertify history = new objCertify();
        DataSet ds = new DataSet();
        DataSet dsMutKharedi = new DataSet();
        DataSet dsMutKharediBuyer = new DataSet();
        DataSet dsMutOtherRights = new DataSet();
        string dsmuttype;
        DataSet dsOld = new DataSet();
        DataSet dsNew = new DataSet();
        DataSet flag = new DataSet();
        int tempint;

        public string certifyVadiVibhajan(objCertify vadiVibhajan, DbCommand dbCmd4)
        {
           
                
                     string CurrentYear = objclscommonfun.getCurrentYear("");
                        dsOld = objclscommonfunedit.funReturnDataSet( vadiVibhajan.Database, vadiVibhajan.Schema + ".mut_kharedi_seller", "*", " mut_no=" + vadiVibhajan.Val + " and seller_usrno=68", "");//ccode,  pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, seller_khata_no, fname, mname, lname, topan_name, usrno
                        dsNew = objclscommonfunedit.funReturnDataSet( vadiVibhajan.Database, vadiVibhajan.Schema + ".mut_kharedi_buyer", "ccode, pin, pin1, pin2, pin3, pin4,pin5, pin6, pin7, pin8,fname,mname,lname,topan_name,buyer_khata_no as khata_no,usrno, buyer_area_tot,na_assessment,buyer_anne,buyer_pai,buyer_area_pot,mut_no,buyer_khata_type", "mut_no=" + vadiVibhajan.Val + " and buyer_doc_type1=68", "");// ccode,  pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, buyer_khata_no, fname, mname, lname, topan_name, usrno
                        bool flag = true;
                        if (dsOld.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dsOld.Tables[0].Rows.Count; i++)
                            {
                                history.Ccode = vadiVibhajan.Ccode;
                                history.Pin = dsOld.Tables[0].Rows[i]["pin"].ToString();
                                history.Pin1 = dsOld.Tables[0].Rows[i]["pin1"].ToString();
                                history.Pin2 = dsOld.Tables[0].Rows[i]["pin2"].ToString();
                                history.Pin3 = dsOld.Tables[0].Rows[i]["pin3"].ToString();
                                history.Pin4 = dsOld.Tables[0].Rows[i]["pin4"].ToString();
                                history.Pin5 = dsOld.Tables[0].Rows[i]["pin5"].ToString();
                                history.Pin6 = dsOld.Tables[0].Rows[i]["pin6"].ToString();
                                history.Pin7 = dsOld.Tables[0].Rows[i]["pin7"].ToString();
                                history.Pin8 = dsOld.Tables[0].Rows[i]["pin8"].ToString();
                                history.Schema = vadiVibhajan.Schema;
                                history.Database = vadiVibhajan.Database;
                                history.Val = vadiVibhajan.Val;
                                history.User = vadiVibhajan.User;
                                objHistory.insertdata_history(history, dbCmd4);

                                // 1. form7_khata
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form7_khata", "ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "',khata_no='" + dsNew.Tables[0].Rows[i]["khata_no"].ToString().Trim() + "', mut_no='" + dsNew.Tables[0].Rows[i]["mut_no"].ToString() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               "", "ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "' AND khata_no='" + dsOld.Tables[0].Rows[i]["seller_khata_no"].ToString().Trim() + "' " +
                                               " AND fname='" + dsOld.Tables[0].Rows[i]["fname"].ToString() + "' AND mname='" + dsOld.Tables[0].Rows[i]["mname"].ToString() + "' AND lname='" + dsOld.Tables[0].Rows[i]["lname"].ToString() + "' AND topan_name='" + dsOld.Tables[0].Rows[i]["topan_name"].ToString() + "'" +
                                                " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                                // 2. holder_detail                                                
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".holder_detail", "ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "', khata_no='" + dsNew.Tables[0].Rows[i]["khata_no"].ToString().Trim() + "', old_mut_no='" + dsNew.Tables[0].Rows[i]["mut_no"].ToString() + "'",
                                    " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "' AND khata_no='" + dsOld.Tables[0].Rows[i]["seller_khata_no"].ToString().Trim() + "' " +
                                     " AND fname='" + dsOld.Tables[0].Rows[i]["fname"].ToString() + "' AND mname='" + dsOld.Tables[0].Rows[i]["mname"].ToString() + "' AND lname='" + dsOld.Tables[0].Rows[i]["lname"].ToString() + "' AND topan_name='" + dsOld.Tables[0].Rows[i]["topan_name"].ToString() + "'", ref dbCmd4);
                                //3. form8a
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form8a",
                                            " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "', khata_no='" + dsNew.Tables[0].Rows[i]["khata_no"].ToString().Trim() + "', old_mut_no='" + dsNew.Tables[0].Rows[i]["mut_no"].ToString() + "'," +
                                            " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                            " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "' AND khata_no='" + dsOld.Tables[0].Rows[i]["seller_khata_no"].ToString().Trim() + "' " +
                                            " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                                //4. form7
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form7",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "', mut_no='" + dsNew.Tables[0].Rows[i]["mut_no"].ToString() + "'," +
                                    " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                    " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                    " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                                //5. form7_area
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form7_area",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "', mut_no='" + dsNew.Tables[0].Rows[i]["mut_no"].ToString() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                                //6. form7_orights
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form7_orights",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "', mut_no='" + dsNew.Tables[0].Rows[i]["mut_no"].ToString() + "'," +
                                    " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                    " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                    " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                                //7. form12
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form12",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                                //8. form12_main
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form12_main",
                                     "ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                                //9. form12_uncultiland
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form12_uncultiland",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                     " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                     " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                     " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                                //10. form12_irrsource
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form12_irrsource",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                    " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                    " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                    " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);

                                //11. form7_mut_no    
                                /*                                                
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form7_mut_no",
                                            "old_mut_no = mutation_no",
                                               "ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);

                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form7_mut_no",
                                    "ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "',mutation_no='" + dsNew.Tables[0].Rows[i]["mut_no"].ToString() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               "ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);*/
                                for (int j = 0; j < i; j++)
                                {
                                    if (dsNew.Tables[0].Rows[i]["pin"].ToString() == dsNew.Tables[0].Rows[j]["pin"].ToString() && dsNew.Tables[0].Rows[i]["pin1"].ToString() == dsNew.Tables[0].Rows[j]["pin1"].ToString() && dsNew.Tables[0].Rows[i]["pin2"].ToString() == dsNew.Tables[0].Rows[j]["pin2"].ToString() && dsNew.Tables[0].Rows[i]["pin3"].ToString() == dsNew.Tables[0].Rows[j]["pin3"].ToString() && dsNew.Tables[0].Rows[i]["pin4"].ToString() == dsNew.Tables[0].Rows[j]["pin4"].ToString() && dsNew.Tables[0].Rows[i]["pin5"].ToString() == dsNew.Tables[0].Rows[j]["pin5"].ToString() && dsNew.Tables[0].Rows[i]["pin6"].ToString() == dsNew.Tables[0].Rows[j]["pin6"].ToString() && dsNew.Tables[0].Rows[i]["pin7"].ToString() == dsNew.Tables[0].Rows[j]["pin7"].ToString() && dsNew.Tables[0].Rows[i]["pin8"].ToString() == dsNew.Tables[0].Rows[j]["pin8"].ToString())
                                    {
                                        flag = false;
                                        break;
                                    }
                                    else
                                        flag = true;
                                }
                                if (flag == true)
                                {
                                    tempint = objclscommonfunedit.funInserSingleValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form7_mut_no", "ccode,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,mutation_no",
                                    "'" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," + dsNew.Tables[0].Rows[i]["pin"].ToString() + ",'" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "','" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "','" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "','" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "','" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "','" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "','" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "','" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "','" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'," + dsNew.Tables[0].Rows[i]["mut_no"].ToString(), ref dbCmd4);
                                }

                                //12. form1
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form1",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCmd4);
                                //13. form1a
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form1a",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "',old_mut_no=" + dsNew.Tables[0].Rows[i]["mut_no"].ToString() + "," +
                                    " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                    " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                    " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                    " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //14. form1b
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form1b",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                   " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                   " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                   " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                   " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //15. form1c
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form1c",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "',old_mut_no=" + dsNew.Tables[0].Rows[i]["mut_no"].ToString() + "," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //16. form1d
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form1d",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //17. form1e
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form1e",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //18. form2
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form2",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //19. form3
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form3",
                                     " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //20. form6a
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form6a",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //21. form6c                                                
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form6c",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //22. form6d
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form6d",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //23. form7a
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form7a",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "'," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "'" +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               " AND year='" + CurrentYear + "'", ref dbCmd4);
                                //24. form7b                                               
                                tempint = objclscommonfunedit.funUpdateValue( vadiVibhajan.Database, vadiVibhajan.Schema + ".form7b",
                                    " ccode='" + dsNew.Tables[0].Rows[i]["ccode"].ToString().Trim() + "', khate_no=" + dsNew.Tables[0].Rows[i]["khata_no"].ToString().Trim() + "," +
                                               " numeric_pin=" + dsNew.Tables[0].Rows[i]["pin"].ToString() + " , pin='" + dsNew.Tables[0].Rows[i]["pin"].ToString() + "' , pin1='" + dsNew.Tables[0].Rows[i]["pin1"].ToString() + "' , pin2='" + dsNew.Tables[0].Rows[i]["pin2"].ToString() + "' , pin3='" + dsNew.Tables[0].Rows[i]["pin3"].ToString() + "' , pin4='" + dsNew.Tables[0].Rows[i]["pin4"].ToString() + "' , pin5='" + dsNew.Tables[0].Rows[i]["pin5"].ToString() + "' , pin6='" + dsNew.Tables[0].Rows[i]["pin6"].ToString() + "' , pin7='" + dsNew.Tables[0].Rows[i]["pin7"].ToString() + "' , pin8='" + dsNew.Tables[0].Rows[i]["pin8"].ToString() + "'",
                                               " ccode='" + dsOld.Tables[0].Rows[i]["ccode"] + "' AND khate_no=" + dsOld.Tables[0].Rows[i]["seller_khata_no"].ToString().Trim() +
                                               " AND numeric_pin=" + dsOld.Tables[0].Rows[i]["pin"].ToString() + " AND pin='" + dsOld.Tables[0].Rows[i]["pin"].ToString() + "' AND pin1='" + dsOld.Tables[0].Rows[i]["pin1"].ToString() + "' AND pin2='" + dsOld.Tables[0].Rows[i]["pin2"].ToString() + "' AND pin3='" + dsOld.Tables[0].Rows[i]["pin3"].ToString() + "' AND pin4='" + dsOld.Tables[0].Rows[i]["pin4"].ToString() + "' AND pin5='" + dsOld.Tables[0].Rows[i]["pin5"].ToString() + "' AND pin6='" + dsOld.Tables[0].Rows[i]["pin6"].ToString() + "' AND pin7='" + dsOld.Tables[0].Rows[i]["pin7"].ToString() + "' AND pin8='" + dsOld.Tables[0].Rows[i]["pin8"].ToString() + "'" +
                                               " AND year='" + CurrentYear + "'", ref dbCmd4);
                            }
                        }
                

                objclscommonfunedit.funUpdateValue(vadiVibhajan.Database, vadiVibhajan.Schema + ".mut_kharedi", "or_code4=2", "ccode = '" + vadiVibhajan.Ccode + "'and  mut_no=" + Convert.ToInt32(vadiVibhajan.Val) + "and remark='Itar-M'", ref dbCmd4);
                objclscommonfunedit.funUpdateValue(vadiVibhajan.Database, vadiVibhajan.Schema + ".mutregister", "mut_status_code=2", "ccode = '" + vadiVibhajan.Ccode + "'and mut_no=" + Convert.ToInt32(vadiVibhajan.Val) + "", ref dbCmd4);
                objclscommonfunedit.funUpdateValue(vadiVibhajan.Database, vadiVibhajan.Schema + ".tblrordetails", "pending_mut_flag='F'", "ccode='" + vadiVibhajan.Ccode + "' AND mutationno=" + vadiVibhajan.Val + "", ref dbCmd4);
                    
                   
                return "true";
           
        }
    }
    }

