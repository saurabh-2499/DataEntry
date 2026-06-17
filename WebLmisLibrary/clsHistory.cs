using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NIC.WebLMISLibrary;
using System.Data.Common;
using Npgsql;
using NpgsqlTypes;
using Microsoft.VisualBasic;

using System.Drawing;




namespace NIC.WebLMISLibrary
{
   public class clsHistory
    {

        clscommonfunedit objclscommonfunedit = new clscommonfunedit();
        clsCommonFunction objclscommonfun = new clsCommonFunction();
        #region[============history region for maintain old 712===============]

       

      


        public void insertdata_history(objCertify certify, DbCommand dbCmd4)
        {
           // DataBaseHandler dbHandler = new DataBaseHandler(databasname, "LRSRO Connection StringMutation");
           // int i3;
            //DbCommand dbCmd3;

           // int index = objclscommonfunedit.funReturnSingleValueInt(certify.Database, certify.Schema + "_his.form7", "max(index_id)", "ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", "");
            int index = 0;
            string index_id = objclscommonfunedit.funReturnSingleValue(certify.Database, certify.Schema + "_his.index", "max(index_id)", "ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", "");
            if (index_id == "")
            {
                index = 1;
            }
            else
            {
                index = Convert.ToInt32(index_id);
            }

            index = index + 1;
            objclscommonfunedit.funInserSingleValue(certify.Database, certify.Schema + "_his.index","ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, mut_no, index_id, date_of_certification,date_cert"," '" + certify.Ccode + "','" + certify.Pin +"','" + certify.Pin1 +"','" + certify.Pin2 +"','" + certify.Pin3 +"','" + certify.Pin4 +"','" + certify.Pin5 +"','" + certify.Pin6 +"','" + certify.Pin7 +"','" + certify.Pin8 +"','"+ certify.Val+"','"+ index +"',now(),now()", ref dbCmd4);
            objclscommonfunedit.funInserSingleValue(certify.Database, certify.Schema + "_his.form7", "", "Select *,now(),now()," + certify.Val + ","+ index +" from " + certify.Schema + ".form7  where ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", ref dbCmd4);
           // objclscommonfunedit.funUpdateValue(certify.Database, certify.Schema + "_his.form7", "mutno=" + certify.Val, "ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", ref dbCmd4);


            objclscommonfunedit.funInserSingleValue(certify.Database, certify.Schema + "_his.form7_area", "", "Select *,now(),now()," + certify.Val + "," + index + " from " + certify.Schema + ".form7_area where ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", ref dbCmd4);
            objclscommonfunedit.funInserSingleValue(certify.Database, certify.Schema + "_his.form7_khata", "", "Select *,now(),now()," + certify.Val + "," + index + " from " + certify.Schema + ".form7_khata where ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", ref dbCmd4);
            objclscommonfunedit.funInserSingleValue(certify.Database, certify.Schema + "_his.form7_mut_no", "", "Select *,now(),now()," + certify.Val + "," + index + " from " + certify.Schema + ".form7_mut_no where ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", ref dbCmd4);
            objclscommonfunedit.funInserSingleValue(certify.Database, certify.Schema + "_his.form7_orights", "", "Select *,now(),now()," + certify.Val + "," + index + " from " + certify.Schema + ".form7_orights where ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", ref dbCmd4);
            objclscommonfunedit.funInserSingleValue(certify.Database, certify.Schema + "_his.form8a", "", "Select *,now(),now()," + certify.Val + "," + index + " from " + certify.Schema + ".form8a where ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", ref dbCmd4);
            objclscommonfunedit.funInserSingleValue(certify.Database, certify.Schema + "_his.holder_detail", "", "Select *,now(),now()," + certify.Val + "," + index + " from " + certify.Schema + ".holder_detail where (ccode,khata_no) in (select distinct ccode,khata_no from " + certify.Schema + ".form7_khata where ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "')", ref dbCmd4);
            objclscommonfunedit.funInserSingleValue(certify.Database, certify.Schema + "_his.tblrordetails", "", "Select *,now(),now()," + certify.Val + "," + index + " from " + certify.Schema + ".tblrordetails where ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", ref dbCmd4);
            objclscommonfunedit.funInserSingleValue(certify.Database, certify.Schema + "_his.mut_kharedi", "", "Select *,now(),now()," + certify.Val + "," + index + " from " + certify.Schema + ".mut_kharedi where ccode = '" + certify.Ccode + "'and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and  pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "'  and pin7='" + certify.Pin7 + "' and pin8 ='" + certify.Pin8 + "'", ref dbCmd4);

            objclscommonfunedit.funInserSingleValue1(certify.Database, certify.Schema, certify.Schema + "_his.ror_bulk_sign_data", "census_code,sevarth_id ,token_srno,signed_data,signed_date, pin , pin1 , pin2 , pin3 , pin4 , pin5 , pin6 , pin7 ,pin8 ", "Select census_code,sevarth_id ,token_srno,signed_data,signed_date , pin , pin1 , pin2 , pin3 , pin4 , pin5 , pin6 , pin7 ,pin8 from " + certify.Schema + ".ror_bulk_sign_data where census_code='" + certify.Ccode + "' and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "' and pin7='" + certify.Pin7 + "' and pin8='" + certify.Pin8 + "'", ref dbCmd4);
            objclscommonfunedit.funDeleteRecord(certify.Database, certify.Schema + ".ror_bulk_sign_data ", "census_code='" + certify.Ccode + "' and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "' and pin7='" + certify.Pin7 + "' and pin8='" + certify.Pin8 + "'", ref dbCmd4);
            //// //If want history of 12 do here....

            //string flag = objclscommonfun.funReturnIfExistValue(certify.Database, certify.Schema, "ror_sign_tables");
            // if (flag == "True")
            // {
                 objclscommonfunedit.funDeleteRecord(certify.Database, certify.Schema + ".ror_sign_tables ", "ccode='" + certify.Ccode + "' and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "' and pin7='" + certify.Pin7 + "' and pin8='" + certify.Pin8 + "'", ref dbCmd4);
                 objclscommonfun.funUpdateValueSevarthID(certify.Database, certify.Schema + ".form1c", "restriction=''", "ccode='" + certify.Ccode + "' and pin='" + certify.Pin + "' and pin1='" + certify.Pin1 + "' and pin2='" + certify.Pin2 + "' and pin3='" + certify.Pin3 + "' and pin4='" + certify.Pin4 + "' and pin5='" + certify.Pin5 + "' and pin6='" + certify.Pin6 + "' and pin7='" + certify.Pin7 + "' and pin8='" + certify.Pin8 + "'", certify.User);
                                             
            // }


        #endregion

        }
}
}
