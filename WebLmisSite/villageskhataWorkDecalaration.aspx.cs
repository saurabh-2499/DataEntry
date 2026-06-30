using System;
using System.Data;
using System.Configuration;


using System.Data.Common;

using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using NIC.WebLMISLibrary;
using Npgsql;
public partial class villageskhataWorkDecalaration : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    clsCommonFunction con = new clsCommonFunction();
    StringBuilder sb = new StringBuilder();
    string page_name = "खाता वर्क डिक्लरेशन";
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Convert.ToString(Session["ccode"]) == "")
            {
                if (Session["user_type"].ToString() == "T")
                    Response.Redirect("pgSelectVillage.aspx");
                else if (Session["user_type"].ToString() == "DBA")
                    Response.Redirect("pgVillageSelect_DBA.aspx");
            }
            else
            {
                Session["ccode"] = Session["ccode"].ToString();
            }
            if (Convert.ToString(Session["ccode"]) != "")
            {

                string talathiname = con.funReturnSingleValue("rcis_uni.fpusers1", " distinct (case WHEN  trim(marathiname)    is  null then  trim(fullname) else  marathiname end)  ||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='T' and  servarthid='" + Convert.ToString(Session["UserName"]) + "' and user_status='L'", "");

                int maxkhata = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".holder_detail ", "count( distinct khata_no::int)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no not in ('TKN','0' ,'' ,'  ' , '500001') ", "");
                sb.Append("<body >");
                sb.Append("<Center>");
                sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='58%' bordercolorlight='#000000' >");
                sb.Append("<thead>");
                sb.Append("<tr>");
                sb.Append("<td width='100%' valign='top' align='center' format ='justify'><font size='5' face='Sakal Marathi  ' color= purple><b>Data Entry Module  मधील खात्यांची दुरुस्ती पुर्ण झाल्याचे ग्राम महसूल अधिकारी स्वयं घोषणा पत्र</b></font></td>");
                sb.Append("</tr>");
                sb.Append("</thead>");
                sb.Append("</table>");
                sb.Append("</br >");

                sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='58%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
                sb.Append("<tr width='100%'>");
                sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbspमी  &nbsp;&nbsp;<b>" + talathiname.Split('-')[0] + "</b> ग्राम महसूल अधिकारी, सेवार्थ आय. डी. <b>" + talathiname.Split('-')[1] + " </b>&nbsp;&nbsp; स्वयं घोषणा करतो की, </font></td>");
                sb.Append("</tr >");
                sb.Append("<tr width='100%'>");

                sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbspमौजे  <b>&nbsp;" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + "</b> तालुका  <b>" + Convert.ToString(Session["TalukaName"]) + "</b>&nbsp;&nbsp;या गावचे संगणकीकृत गाव नमुना 7/12 व 8अ, हस्तलिखत गाव नमुना 7/12 व 8अ शी तंतोतंत जुळविण्यासाठी दिलेल्या Data Entry Module मध्ये काम केले आहे व Data Entry Module  मधील खात्यांची दुरुस्ती बाबतची प्रक्रिया पुर्ण केली असून 1) खाते एकत्रिकरण व 2) खाते विभागणी गरजे प्रमाणे पुर्ण केले आहे. गावांत एकूण  <b>" + maxkhata + "</b>  इतकी खाती असुन ती गाव ऑनलाईन झाल्यापासूनचे सर्व मंजूर फेरफार विचारात घेऊन अद्यावत केली  आहेत . ONLINE खाता नोंदवही ठेवण्यसाठी शासन स्तरावरून दिलेल्या सूचना विचारात घेऊन खात्याशी संबंधित सर्व कामकाज पूर्ण केले आहे  म्हणून ही स्वयंघोषणा करत आहे. </font></td>");
                sb.Append("</tr >");
                sb.Append("</table>");
                sb.Append("</br >");
                sb.Append("</Center>");
                sb.Append("</body>");
                Response.Write(sb.ToString());
            }
            else
            {
                string popupScript = "<script language='javascript'>alert('कृपया गाव निवडा.' );</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }

    protected void workDeclairation_Click(object sender, System.EventArgs e)
    {
        try
        {
            if (Request.Form["confirm_value"] != "notOk")
            {
                #region[----Check  For Invalid Apk ,Ekume name  khatas----]
                DataSet ds_wrong_akp_akm = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".form7_khata", "ccode, khata_no, string_agg(distinct rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ,',') as survey, string_agg(fname||' '||mname||' '||lname||' '||topan_name,',') as names", "ccode  ='" + Convert.ToString(Session["ccode"]) + "' and  (ccode , khata_no) in (select ccode , khata_no  from  " + Session["SchemaName"].ToString() + ".holder_detail where  ccode  ='" + Convert.ToString(Session["ccode"]) + "' and   replace(fname||mname||lname||topan_name,' ','') ='एकुक'  or replace(fname||mname||lname||topan_name,'.','') ='एकुक'  or replace(fname||mname||lname||topan_name,'.','') ='अपाक'  or replace(fname||mname||lname||topan_name,' ','') ='अपाक' or replace(fname||mname||lname||topan_name,'.','') ='एकुमॅ'  or replace(fname||mname||lname||topan_name,' ','') ='एकुमॅ' )group by  ccode , khata_no ", "");
                if (ds_wrong_akp_akm.Tables[0].Rows.Count > 0)
                {
                    workDeclairation.Enabled = false;
                    workDeclairationIRpt.Enabled = false;
                    string message = @"सदर गावामध्ये ""चुकीच्या पद्धतीने भरलेली अपाक,ए.कु.मॅ नावांची खाती. आहेत.""( कृपया ODC मधील अतिरिक्त अहवाल  क्र 10.  ""चुकीच्या पद्धतीने भरलेली अपाक,ए.कु.मॅ नावांची खाती"" हा अहवाल बघावा व ReEdit  अद्न्यावालीद्वारे योग्य ती दुरुस्ती  करणेत यावी.";
                    string popupScript = "<script language='javascript'>alert('" + message + "' );</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
                #endregion
                string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
                using (DbConnection connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    DbTransaction dbTransaction;
                    using (dbTransaction = connection.BeginTransaction())
                    {
                        DbCommand dbCommand;
                        using (dbCommand = connection.CreateCommand())
                        {
                            dbCommand.Transaction = dbTransaction;
                            dbCommand.CommandType = CommandType.Text;
                            try
                            {
                                DataTable dt_khata_no = con.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "distinct khata_no::int,khata_master_declair_date", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no_status =false  ", " khata_no::int");
                                if (dt_khata_no.Rows.Count == 0)
                                {
                                    // string date = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
                                    //   DateTime date1 = System.DateTime.Today.Date;

                                    int date_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no_status =true and khata_master_declair_date  isnull  ", "");
                                    if (date_cnt != 0)
                                    {
                                        con.funUpdateMutTables(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "khata_master_declaration=true , khata_master_declair_date='now()' ", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no_status = true", ref dbCommand, Convert.ToString(Session["UserName"]));
                                        dbTransaction.Commit();
                                        string popupScript = "<script language='javascript'>alert('संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे ही माहिती साठवली.' );</script>";
                                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                        return;
                                    }
                                    else
                                    {
                                        int row_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' ", "");

                                        if (row_cnt == 0)
                                        {
                                             row_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".holder_detail", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' ", "");
                                             if (row_cnt > 0)
                                             {
                                                 con.funInsertMutEntry(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "ccode,khata_master_declaration,khata_master_declair_date,khata_no_status", "'" + Convert.ToString(Session["ccode"]) + "',true,now(), true", Convert.ToString(Session["UserName"]), ref dbCommand);
                                                 dbTransaction.Commit();
                                                 string popupScript = "<script language='javascript'>alert('संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे ही माहिती साठवली.' );</script>";
                                                 ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                                 return;
                                             }
                                             else
                                             {

                                                 string popupScript = "<script language='javascript'>alert('खात्यांची दुरुस्ती पुर्ण झाल्याचे ग्राम महसूल अधिकारी स्वयं घोषणा करण्यासाठी माहिती उपलब्ध नाही.' );</script>";
                                                 ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                                 return;
                                             }
                                        }
                                        else
                                        {
                                            string popupScript = "<script language='javascript'>alert('संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे ही माहिती या पुर्वीच साठवली आहे याची नोंद घ्यावी.' );</script>";
                                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    string khata_no_list = String.Empty;
                                    for (int i = 0; i < dt_khata_no.Rows.Count; i++)
                                    {
                                        khata_no_list = dt_khata_no.Rows[i]["khata_no"].ToString() + " ,";
                                    }
                                    khata_no_list = khata_no_list.ToString().Trim(',');
                                    string popupScript = "<script language='javascript'>alert('" + khata_no_list + " या खाता क्रमाकांची, खाता मास्टरची दुरुस्त/अद्यावत केलेली माहिती कायम करावयाचे राहिले आहे.\\nत्यामुळे संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्वाही देण्यासाठी प्रथम सदर खाता क्रमाकांची खाता मास्टरची दुरुस्त/अद्यावत केलेली माहिती कायम करणे आवश्यक आहे याची नोंद घ्यावी.' );</script>";
                                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                    return;

                                }
                            }
                            catch (Exception ex)
                            {
                                dbTransaction.Rollback();
                                ExceptionHandling excpt = new ExceptionHandling();
                                if (Session["UserName"] != null)
                                    Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
                                else
                                    Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                                string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("pgVillageSelection.aspx", false);
    }
    protected void btnKhataConfirm_Click(object sender, EventArgs e)
    {
        Response.Redirect("pgKhataConfirmation.aspx", false);
    }
    protected void workDeclairationIRpt_Click(object sender, EventArgs e)
    {
        DataSet ds_wrong_akp_akm = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".form7_khata", "ccode, khata_no, string_agg(distinct rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ,',') as survey, string_agg(fname||' '||mname||' '||lname||' '||topan_name,',') as names", "ccode  ='" + Convert.ToString(Session["ccode"]) + "' and  (ccode , khata_no) in (select ccode , khata_no  from  " + Session["SchemaName"].ToString() + ".holder_detail where  ccode  ='" + Convert.ToString(Session["ccode"]) + "' and   replace(fname||mname||lname||topan_name,' ','') ='एकुक'  or replace(fname||mname||lname||topan_name,'.','') ='एकुक'  or replace(fname||mname||lname||topan_name,'.','') ='अपाक'  or replace(fname||mname||lname||topan_name,' ','') ='अपाक' or replace(fname||mname||lname||topan_name,'.','') ='एकुमॅ'  or replace(fname||mname||lname||topan_name,' ','') ='एकुमॅ' )group by  ccode , khata_no ", "");
        if (ds_wrong_akp_akm != null && ds_wrong_akp_akm.Tables.Count > 0 && ds_wrong_akp_akm.Tables[0].Rows.Count > 0)
        {
            workDeclairation.Enabled = false;
            workDeclairationIRpt.Enabled = false;
            string message = @"सदर गावामध्ये ""चुकीच्या पद्धतीने भरलेली अपाक,ए.कु.मॅ नावांची खाती. आहेत.""( कृपया ODC मधील अतिरिक्त अहवाल  क्र 10.  ""चुकीच्या पद्धतीने भरलेली अपाक,ए.कु.मॅ नावांची खाती"" हा अहवाल बघावा व ReEdit  अद्न्यावालीद्वारे योग्य ती दुरुस्ती  करणेत यावी.";
            string popupScript = "<script language='javascript'>alert('" + message + "' );</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            return;
        }
        else
        {
            Response.Redirect("declarationI.aspx", false);
        }
    }
}