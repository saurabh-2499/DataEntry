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

public partial class PgRptBilkSign : System.Web.UI.Page
{

    #region [-- Local Variables --]
    clscommonfun con = new clscommonfun();
    clsCommonFunction objclsCommFun = new clsCommonFunction();
    clscommonfunedit objclscommfunedit = new clscommonfunedit();
    string page_name = "PgBulkDataSighReport.aspx";
    DsBulkRpt dsbulk = new DsBulkRpt();

    #endregion


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
                Session["page_heading"] = "गावनिहाय बल्क साईन झालेल्या  सर्वे क्रमांकाचा अहवाल ";

                string a = Session["user_type"].ToString();

                DataSet ds = new DataSet();//form7
                DataSet dsrst = new DataSet();//ror_sign_tables
                DataSet dsrbst = new DataSet();//ror_bulk_sign
                string form7count = "count( distinct  rtrim(((CASE WHEN a.pin<>'' THEN cast(trim(a.pin) as text)|| '/' WHEN a.pin='' THEN '' END)  ||(CASE WHEN a.pin1<>'' THEN cast(trim(a.pin1) as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(trim(a.pin2) as text)|| '/' WHEN a.pin2='' THEN '' END)  ||(CASE WHEN a.pin3<>'' THEN cast(trim(a.pin3)as text)|| '/' WHEN a.pin3='' THEN '' END)  ||(CASE WHEN a.pin4<>'' THEN cast(trim(a.pin4) as text)|| '/' WHEN a.pin4='' THEN '' END)  ||(CASE WHEN a.pin5<>'' THEN cast(trim(a.pin5) as text)|| '/' WHEN a.pin5='' THEN '' END)  ||(CASE WHEN a.pin6<>'' THEN cast(trim(a.pin6) as text)|| '/' WHEN a.pin6='' THEN '' END)  ||(CASE WHEN a.pin7<>'' THEN cast(trim(a.pin7) as text)|| '/' WHEN a.pin7='' THEN '' END)  ||(CASE WHEN a.pin8<>'' THEN cast(trim(a.pin8) as text)|| '/' WHEN a.pin8='' THEN '' END)),'/') ) as form7count";
                string ror_sign_tables_count = "count( distinct  rtrim(((CASE WHEN b.pin<>'' THEN cast(trim(b.pin) as text)|| '/' WHEN b.pin='' THEN '' END)  ||(CASE WHEN b.pin1<>'' THEN cast(trim(b.pin1) as text)|| '/' WHEN b.pin1='' THEN '' END)  || (CASE WHEN b.pin2<>'' THEN cast(trim(b.pin2) as text)|| '/' WHEN b.pin2='' THEN '' END)  ||(CASE WHEN b.pin3<>'' THEN cast(trim(b.pin3)as text)|| '/' WHEN b.pin3='' THEN '' END)  ||(CASE WHEN b.pin4<>'' THEN cast(trim(b.pin4) as text)|| '/' WHEN b.pin4='' THEN '' END)  ||(CASE WHEN b.pin5<>'' THEN cast(trim(b.pin5) as text)|| '/' WHEN b.pin5='' THEN '' END)  ||(CASE WHEN b.pin6<>'' THEN cast(trim(b.pin6) as text)|| '/' WHEN b.pin6='' THEN '' END)  ||(CASE WHEN b.pin7<>'' THEN cast(trim(b.pin7) as text)|| '/' WHEN b.pin7='' THEN '' END)  ||(CASE WHEN b.pin8<>'' THEN cast(trim(b.pin8) as text)|| '/' WHEN b.pin8='' THEN '' END)),'/') ) as ror_sign_tables_count";
                string ror_bulk_sign_count = "count( distinct  rtrim(((CASE WHEN c.pin<>'' THEN cast(trim(c.pin) as text)|| '/' WHEN c.pin='' THEN '' END)  ||(CASE WHEN c.pin1<>'' THEN cast(trim(c.pin1) as text)|| '/' WHEN c.pin1='' THEN '' END)  || (CASE WHEN c.pin2<>'' THEN cast(trim(c.pin2) as text)|| '/' WHEN c.pin2='' THEN '' END)  ||(CASE WHEN c.pin3<>'' THEN cast(trim(c.pin3)as text)|| '/' WHEN c.pin3='' THEN '' END)  ||(CASE WHEN c.pin4<>'' THEN cast(trim(c.pin4) as text)|| '/' WHEN c.pin4='' THEN '' END)  ||(CASE WHEN c.pin5<>'' THEN cast(trim(c.pin5) as text)|| '/' WHEN c.pin5='' THEN '' END)  ||(CASE WHEN c.pin6<>'' THEN cast(trim(c.pin6) as text)|| '/' WHEN c.pin6='' THEN '' END)  ||(CASE WHEN c.pin7<>'' THEN cast(trim(c.pin7) as text)|| '/' WHEN c.pin7='' THEN '' END)  ||(CASE WHEN c.pin8<>'' THEN cast(trim(c.pin8) as text)|| '/' WHEN c.pin8='' THEN '' END)),'/') ) as ror_bulk_sign_count";

                string username = Convert.ToString(Session["fullname"]);
                if (a == "T")
                {
                    username = Convert.ToString(Session["fullname"]) + "(तलाठी)";
                }
                else if (a == "C")
                {
                    username = Convert.ToString(Session["fullname"]) + " (मंडळ  अधिकारी)";
                }
                else if (a == "DBA")
                {
                    username = Convert.ToString(Session["fullname"]) + " (डी.बी.ए.)";
                }
                if (a == "DBA")
                {

                    ds = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".form7 as a ", "distinct v.village_code,v.ccode,v.village_name," + form7count + " ", " v.ccode=a.ccode  group by v.village_code,v.ccode,v.village_name", "v.village_name");
                    dsrst = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".ror_sign_tables as b ", "distinct v.village_code,v.ccode,v.village_name," + ror_sign_tables_count + " ", " v.ccode=b.ccode  group by v.village_code,v.ccode,v.village_name", "v.village_name");
                    dsrbst = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".ror_bulk_sign_data as c ", "distinct v.village_code,v.ccode,v.village_name," + ror_bulk_sign_count + "", " v.ccode=c.census_code   group by v.village_code,v.ccode,v.village_name", "v.village_name");


                }
                else
                {   // ds = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o," + Convert.ToString(Session["SchemaName"]) + ".form7 as a," + Convert.ToString(Session["SchemaName"]) + ".ror_sign_tables as b ," + Convert.ToString(Session["SchemaName"]) + ".ror_bulk_sign_data as c ", "distinct v.village_code,v.ccode,v.village_name," + form7count + "," + ror_sign_tables_count + "," + ror_bulk_sign_count + "", "v.ccode=o.ccode and v.ccode=a.ccode and v.ccode=b.ccode and v.ccode=c.census_code  and o.username='" + Convert.ToString(Session["UserName"]) + "'  group by v.village_code,v.ccode,v.village_name", "v.village_name");

                    ds = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o," + Convert.ToString(Session["SchemaName"]) + ".form7 as a ", "distinct v.village_code,v.ccode,v.village_name," + form7count + " ", "v.ccode=o.ccode and v.ccode=a.ccode  and o.username='" + Convert.ToString(Session["UserName"]) + "'  group by v.village_code,v.ccode,v.village_name", "v.village_name");
                    dsrst = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o," + Convert.ToString(Session["SchemaName"]) + ".ror_sign_tables as b ", "distinct v.village_code,v.ccode,v.village_name," + ror_sign_tables_count + " ", "v.ccode=o.ccode and v.ccode=b.ccode  and o.username='" + Convert.ToString(Session["UserName"]) + "'  group by v.village_code,v.ccode,v.village_name", "v.village_name");
                    dsrbst = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o," + Convert.ToString(Session["SchemaName"]) + ".ror_bulk_sign_data as c ", "distinct v.village_code,v.ccode,v.village_name," + ror_bulk_sign_count + "", "v.ccode=o.ccode and v.ccode=c.census_code  and o.username='" + Convert.ToString(Session["UserName"]) + "'  group by v.village_code,v.ccode,v.village_name", "v.village_name");


                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataRow drtemp = dsbulk.Tables["dttable"].NewRow();
                    drtemp["ccode"] = dr["ccode"];
                    drtemp["village_name"] = dr["village_name"];
                    drtemp["form7count"] = dr["form7count"];
                    drtemp["ror_sign_tables_count"] = "0";
                    drtemp["ror_bulk_sign_count"] = "0";
                    dsbulk.Tables["dttable"].Rows.Add(drtemp);
                }

                foreach (DataRow dr in dsbulk.Tables["dttable"].Rows)
                {
                    foreach (DataRow drnew in dsrst.Tables[0].Select("ccode='" + dr["ccode"] + "'"))
                    {
                        dr["ror_sign_tables_count"] = drnew["ror_sign_tables_count"];
                    }
                }
                dsrst.Dispose();
                dsbulk.AcceptChanges();

                foreach (DataRow dr in dsbulk.Tables["dttable"].Rows)
                {
                    foreach (DataRow drnew in dsrbst.Tables[0].Select("ccode='" + dr["ccode"] + "'"))
                    {
                        dr["ror_bulk_sign_count"] = drnew["ror_bulk_sign_count"];
                    }
                }
                dsrbst.Dispose();
                dsbulk.AcceptChanges();


                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("RptBulSignData.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                List<ReportParameter> reportParams = new List<ReportParameter>();
                reportParams.Add(new ReportParameter("TalukaName", Convert.ToString(Session["TalukaName"])));
                reportParams.Add(new ReportParameter("DistrictName", Convert.ToString(Session["DistrictName"])));
                reportParams.Add(new ReportParameter("UserName", username));
                ReportViewer1.LocalReport.SetParameters(reportParams);
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DsBulkRpt", dsbulk.Tables["dttable"]));
                ReportViewer1.DataBind();

            }

        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                 Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }


    }

}