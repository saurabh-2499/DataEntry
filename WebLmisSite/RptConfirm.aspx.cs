using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIC.WebLMISLibrary;
using System.Data.Common;
using Npgsql;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Microsoft.Reporting;
using Microsoft.Reporting.WebForms;

public partial class RptConfirm : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    string page_name = "Confirm ( कायम ठेवलेल्या ) ७/१२ ची यादी";
    dsEdit ds = new dsEdit();
    DataTable sortedDT = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
            if (Convert.ToUInt32(userExist) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
            }
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
            ShowReport();
        }
    }
    public void ShowReport()
    {
        //RDLC REPORT CODING


        NpgsqlDataAdapter sqlDAdapter = new NpgsqlDataAdapter();
        string pincase1 = "rtrim(((CASE WHEN pin<>'' THEN cast((pin) as text)|| '/' WHEN pin='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin1<>'' THEN cast((pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin2<>'' THEN cast((pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin3<>'' THEN cast((pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin4<>'' THEN cast((pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin5<>'' THEN cast((pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin6<>'' THEN cast((pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin7<>'' THEN cast((pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin8<>'' THEN cast((pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno";

        DataSet ds1 = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "row_number() over (ORDER BY ccode)as id," + pincase1 + ",correction_deal", "ccode = '" + Convert.ToString(Session["VillageDetail"]).Split('#')[0] + "' and confirm_flag='Confirm' ", "survey");

        
       
        foreach (DataRow dr in ds1.Tables[0].Rows)
        {
            DataSet ds1ConfirmMaxTransNoDate = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_audit", "max(edit_trans_no) as edit_trans_no,max(timestatus::date)::text as confirm_date ", "ccode = '" + (string)Session["ccode"] + "'  and confirm_flag='Confirm' and survey='" + dr["surveyno"] + "'", "");
            DataRow drtemp = ds.Tables["dataRpt"].NewRow();
           // drtemp["id"] = dr["id"];
            drtemp["surveyno"] = dr["surveyno"];
            drtemp["correction_deal"] = dr["correction_deal"];
            drtemp["confirm_date"] = ds1ConfirmMaxTransNoDate.Tables[0].Rows[0]["confirm_date"];
            ds.Tables["dataRpt"].Rows.Add(drtemp);
        }

        DataView dv = ds.Tables["dataRpt"].DefaultView;
        dv.Sort = "confirm_date asc";
        sortedDT = dv.ToTable().Copy();

        for (int i = 0; i < sortedDT.Rows.Count; i++)
        {
            sortedDT.Rows[i]["id"] = i + 1;
        }


        string Gaon = Convert.ToString(Session["VillageDetail"]).Split('#')[1];
        string taluka = Convert.ToString(Session["TalukaName"]);
        string jilha = Convert.ToString(Session["DistrictName"]);
        string tahsildarname = string.Empty;
        string circlename = string.Empty;
        string talathiname = string.Empty;

        DataSet dssevarth = con.funReturnDataSet((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_officermast", "trim(username) as username,user_type", "ccode='" + Convert.ToString(Session["VillageDetail"]).Split('#')[0] + "'", "");
        if (dssevarth != null || dssevarth.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in dssevarth.Tables[0].Rows)
            {
                if (Convert.ToString(dr["user_type"]) == "1")
                {
                    talathiname = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='T' and  servarthid='" + Convert.ToString(dr["username"]) + "' and user_status='L'", "");
                }
                else if (Convert.ToString(dr["user_type"]) == "2")
                {
                    circlename = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='C' and  servarthid='" + Convert.ToString(dr["username"]) + "' and user_status='L'", "");
                }

            }
        }
        tahsildarname = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='TAH' and user_status='L'", "");
           


        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("ReportConfirm.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();

        List<ReportParameter> reportParams = new List<ReportParameter>();
        reportParams.Add(new ReportParameter("gaon", Gaon));
        reportParams.Add(new ReportParameter("taluka", taluka));
        reportParams.Add(new ReportParameter("jilha", jilha));
        reportParams.Add(new ReportParameter("talathiname", talathiname ));
        reportParams.Add(new ReportParameter("circlename", circlename));
        reportParams.Add(new ReportParameter("tahsildarname", tahsildarname));



        ReportViewer1.LocalReport.SetParameters(reportParams);
       // ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsEdit", ds.Tables["dataRpt"]))
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsEdit", sortedDT));
        
        ReportViewer1.DataBind();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        string user_type = con.funReturnSingleValue((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_officermast", "user_type", "ccode='" + Convert.ToString(Session["ccode"]) + "' and username='" + Convert.ToString(Session["UserName"]) + "'", "");
        if (user_type != null || user_type != "")
        {
            if (user_type == "1")
            {
                Response.Redirect("pgVillageSelection.aspx", false);
            }
            else if (user_type == "2")
            {
                Response.Redirect("pgEntryverify.aspx", false);
            }
        }
    }
}