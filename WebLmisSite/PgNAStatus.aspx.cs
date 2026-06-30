using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using NIC.WebLMISLibrary;
using System.Data.Common;
using System.Data;
using System.Net;
using System.Configuration;
using Npgsql;
using System.Globalization;
using Npgsql;
using Microsoft.Reporting;
using Microsoft.Reporting.WebForms;
using iTextSharp.text.pdf.parser;
using System.Collections.Generic;

public partial class PgNAStatus : System.Web.UI.Page
{
    string page_name = "PgNAStatus.aspx";
    clsCommonFunction objclsCommFun = new clsCommonFunction();
    clscommonfun con = new clscommonfun();
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Convert.ToString(Session["user_type"]) == "T")
        {
            this.MasterPageFile = "~/InnerMaster.master";
        }
        else if (Convert.ToString(Session["user_type"]) == "C")
        {
            this.MasterPageFile = "~/circlemaster.master";
        }

        else if (Convert.ToString(Session["user_type"]) == "DBA")
        {
            this.MasterPageFile = "~/Copy of InnerMaster.master";
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
                if (Convert.ToUInt32(userExist) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
                }
                if (Convert.ToString(Session["VillageDetail"]).Split('#')[0] != "")
                {


                    Session["page_heading"] = "सर्व्हे क्रमांकाचा शेती - बिगर शेतीचा अहवाल";

                    string a = Session["user_type"].ToString();



                    DataSet ds = new DataSet();
                    ds = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7 a," + Convert.ToString(Session["SchemaName"]) + ".form7_area  b", "a.numeric_pin,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  || (CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  ||  (CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  ||(CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  || (CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  || (CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  ||  (CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  ||  (CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/') AS pincase,a.khand_no,(CASE WHEN a.khand_no='2' THEN 'आर.चौ.मी' else 'हे.आर.चौ.मी' END)  as unitarea,b.na_area_h,(CASE WHEN b.na_area_h>0 THEN 'बिगर शेती (NA)' else 'शेती' END)  as nastatus  ,total_area_h as totalarea", "a.pin=b.pin and a.pin1=b.pin1 and a.pin2=b.pin2 and   a.pin3=b.pin3 and   a.pin4=b.pin4 and  a.pin5=b.pin5 and  a.pin6=b.pin6 and  a.pin7=b.pin7 and   a.pin8=b.pin8   and a.ccode=b.ccode and  a.ccode='" + Convert.ToString(Session["VillageDetail"]).Split('#')[0] + "'", "a.numeric_pin,a.pin,a.pin1,a.pin2,a.pin3,a.pin4,a.pin5,a.pin6,a.pin7,a.pin8");


                    ReportViewer1.LocalReport.Refresh();
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("ReportNA.rdlc");
                    ReportViewer1.LocalReport.DataSources.Clear();

                    List<ReportParameter> reportParams = new List<ReportParameter>();
                    reportParams.Add(new ReportParameter("TalukaName", Convert.ToString(Session["TalukaName"])));
                    reportParams.Add(new ReportParameter("DistrictName", Convert.ToString(Session["DistrictName"])));
                    reportParams.Add(new ReportParameter("gav", Convert.ToString(Session["VillageDetail"]).Split('#')[1]));

                    ReportViewer1.LocalReport.SetParameters(reportParams);
                    ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsNAStatus", ds.Tables[0]));
                    ReportViewer1.DataBind();
                }
                else
                {
                    string popupScript = "<script language='javascript'>alert('कृपया, गाव निवडा .');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }

            }

        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]),Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "Unknown", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }

    }
}