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

public partial class Rpt : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    string page_name = "७/१२ वरील दुरुस्त्या सुरु करण्यासाठीचा तहसिलददार यांचा आदेश";
    
    dsEdit ds = new dsEdit();
    DataTable sortedDT = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {  

        if(!IsPostBack)
        {
            string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
            if (Convert.ToUInt32(userExist) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
            }
            Session["page_heading"] = "";
            ShowReport();
        }
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
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
                        con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "report_status='Generated'", "ccode = '" + (string)Session["ccode"] + "' and  edit_trans_no='" + Convert.ToString(Session["village_trans_cnt"]) + "' and marked_flag='Edit' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                        dbTransaction.Commit();
                        //for max tranaction count

               
                        string popupScript = "<script language='javascript'>alert('माहिती साठवली आहे .');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
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
            connection.Close();
        }
    }
    
    protected void btnBack_Click(object sender, EventArgs e)
    {

        string user_type = con.funReturnSingleValue((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_officermast", "user_type", "ccode='" + Convert.ToString(Session["ccode"]) + "' and username='" + Convert.ToString(Session["UserName"]) + "'", "");
           if (user_type != null || user_type !="")
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
    public void ShowReport()
    {
        //RDLC REPORT CODING
        try { 

        NpgsqlDataAdapter sqlDAdapter = new NpgsqlDataAdapter();
        
        string pincase1 = "rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||";
        pincase1 += "(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno";


        DataSet dsEditSurvey = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "distinct survey,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode = '" + (string)Session["ccode"] + "'  and marked_flag='Edit' and confirm_flag='' and  edit_trans_no<>0 and survey<>''", "survey");

      

            if (dsEditSurvey != null && dsEditSurvey.Tables.Count>0 && dsEditSurvey.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsEditSurvey.Tables[0].Rows.Count; i++)
                {
                    DataSet dsEditSurveyMaxTransNoDate = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_audit", "max(edit_trans_no) as edit_trans_no,max(timestatus::date)::text as correction_date ", "ccode = '" + (string)Session["ccode"] + "'  and marked_flag='Edit' and survey='" + dsEditSurvey.Tables[0].Rows[i]["survey"] + "'", "");
                    int cnt_change = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_deal_new", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and pin='" + dsEditSurvey.Tables[0].Rows[i]["pin"] + "' and pin1='" + dsEditSurvey.Tables[0].Rows[i]["pin1"] + "' and pin2='" + dsEditSurvey.Tables[0].Rows[i]["pin2"] + "' and pin3='" + dsEditSurvey.Tables[0].Rows[i]["pin3"] + "' and pin4='" + dsEditSurvey.Tables[0].Rows[i]["pin4"] + "' and pin5='" + dsEditSurvey.Tables[0].Rows[i]["pin5"] + "' and pin6='" + dsEditSurvey.Tables[0].Rows[i]["pin6"] + "' and pin7='" + dsEditSurvey.Tables[0].Rows[i]["pin7"] + "' and pin8='" + dsEditSurvey.Tables[0].Rows[i]["pin8"] + "'", "");
                    int cnt_save = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_deal_audit", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and pin='" + dsEditSurvey.Tables[0].Rows[i]["pin"] + "' and pin1='" + dsEditSurvey.Tables[0].Rows[i]["pin1"] + "' and pin2='" + dsEditSurvey.Tables[0].Rows[i]["pin2"] + "' and pin3='" + dsEditSurvey.Tables[0].Rows[i]["pin3"] + "' and pin4='" + dsEditSurvey.Tables[0].Rows[i]["pin4"] + "' and pin5='" + dsEditSurvey.Tables[0].Rows[i]["pin5"] + "' and pin6='" + dsEditSurvey.Tables[0].Rows[i]["pin6"] + "' and pin7='" + dsEditSurvey.Tables[0].Rows[i]["pin7"] + "' and pin8='" + dsEditSurvey.Tables[0].Rows[i]["pin8"] + "' and app_name='reEdit'", "");

                    string query = " select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno from " + Convert.ToString(Session["SchemaName"]) + ".form12_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and pin='" + dsEditSurvey.Tables[0].Rows[i]["pin"] + "' and pin1='" + dsEditSurvey.Tables[0].Rows[i]["pin1"] + "' and pin2='" + dsEditSurvey.Tables[0].Rows[i]["pin2"] + "' and pin3='" + dsEditSurvey.Tables[0].Rows[i]["pin3"] + "' and pin4='" + dsEditSurvey.Tables[0].Rows[i]["pin4"] + "' and pin5='" + dsEditSurvey.Tables[0].Rows[i]["pin5"] + "' and pin6='" + dsEditSurvey.Tables[0].Rows[i]["pin6"] + "' and pin7='" + dsEditSurvey.Tables[0].Rows[i]["pin7"] + "' and pin8='" + dsEditSurvey.Tables[0].Rows[i]["pin8"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' ) union ";
                    query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno from " + Convert.ToString(Session["SchemaName"]) + ".form12_main_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and pin='" + dsEditSurvey.Tables[0].Rows[i]["pin"] + "' and pin1='" + dsEditSurvey.Tables[0].Rows[i]["pin1"] + "' and pin2='" + dsEditSurvey.Tables[0].Rows[i]["pin2"] + "' and pin3='" + dsEditSurvey.Tables[0].Rows[i]["pin3"] + "' and pin4='" + dsEditSurvey.Tables[0].Rows[i]["pin4"] + "' and pin5='" + dsEditSurvey.Tables[0].Rows[i]["pin5"] + "' and pin6='" + dsEditSurvey.Tables[0].Rows[i]["pin6"] + "' and pin7='" + dsEditSurvey.Tables[0].Rows[i]["pin7"] + "' and pin8='" + dsEditSurvey.Tables[0].Rows[i]["pin8"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit'  ) union ";
                    query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno from " + Convert.ToString(Session["SchemaName"]) + ".form12_uncultiland_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and pin='" + dsEditSurvey.Tables[0].Rows[i]["pin"] + "' and pin1='" + dsEditSurvey.Tables[0].Rows[i]["pin1"] + "' and pin2='" + dsEditSurvey.Tables[0].Rows[i]["pin2"] + "' and pin3='" + dsEditSurvey.Tables[0].Rows[i]["pin3"] + "' and pin4='" + dsEditSurvey.Tables[0].Rows[i]["pin4"] + "' and pin5='" + dsEditSurvey.Tables[0].Rows[i]["pin5"] + "' and pin6='" + dsEditSurvey.Tables[0].Rows[i]["pin6"] + "' and pin7='" + dsEditSurvey.Tables[0].Rows[i]["pin7"] + "' and pin8='" + dsEditSurvey.Tables[0].Rows[i]["pin8"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' ) union ";
                    query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno from " + Convert.ToString(Session["SchemaName"]) + ".form12_irrsource_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and pin='" + dsEditSurvey.Tables[0].Rows[i]["pin"] + "' and pin1='" + dsEditSurvey.Tables[0].Rows[i]["pin1"] + "' and pin2='" + dsEditSurvey.Tables[0].Rows[i]["pin2"] + "' and pin3='" + dsEditSurvey.Tables[0].Rows[i]["pin3"] + "' and pin4='" + dsEditSurvey.Tables[0].Rows[i]["pin4"] + "' and pin5='" + dsEditSurvey.Tables[0].Rows[i]["pin5"] + "' and pin6='" + dsEditSurvey.Tables[0].Rows[i]["pin6"] + "' and pin7='" + dsEditSurvey.Tables[0].Rows[i]["pin7"] + "' and pin8='" + dsEditSurvey.Tables[0].Rows[i]["pin8"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit'  ) union ";
                    query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno from " + Convert.ToString(Session["SchemaName"]) + ".form12_remark_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and pin='" + dsEditSurvey.Tables[0].Rows[i]["pin"] + "' and pin1='" + dsEditSurvey.Tables[0].Rows[i]["pin1"] + "' and pin2='" + dsEditSurvey.Tables[0].Rows[i]["pin2"] + "' and pin3='" + dsEditSurvey.Tables[0].Rows[i]["pin3"] + "' and pin4='" + dsEditSurvey.Tables[0].Rows[i]["pin4"] + "' and pin5='" + dsEditSurvey.Tables[0].Rows[i]["pin5"] + "' and pin6='" + dsEditSurvey.Tables[0].Rows[i]["pin6"] + "' and pin7='" + dsEditSurvey.Tables[0].Rows[i]["pin7"] + "' and pin8='" + dsEditSurvey.Tables[0].Rows[i]["pin8"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' )";


                   

                    DataSet ds12 = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), query);

           

                    DataRow drtemp = ds.Tables["dataRpt"].NewRow();
                   // drtemp["id"] = i +1;
                    drtemp["surveyno"] = dsEditSurvey.Tables[0].Rows[i]["survey"];
                   // drtemp["correction_deal"] = dsEditSurveyMaxTransNoDate.Tables[0].Rows[0]["edit_trans_no"];
                    
                    drtemp["correction_date"] = dsEditSurveyMaxTransNoDate.Tables[0].Rows[0]["correction_date"];
                    drtemp["edit_trans_no"] = dsEditSurveyMaxTransNoDate.Tables[0].Rows[0]["edit_trans_no"];
                    if (cnt_change > 0)
                    {
                        drtemp["edit_change"] = "होय";
                    }
                    else
                    {
                        drtemp["edit_change"] = "नाही";
                    }
                    if (cnt_save > 0)
                    {
                        drtemp["edit_save"] = "होय";
                    }
                    else
                    {
                        drtemp["edit_save"] = "नाही";
                    }

                    if (ds12 != null && ds12.Tables.Count > 0 && ds12.Tables[0].Rows.Count > 0 )
                    { 
                        drtemp["edit_12"] = "होय";
                    }
                    else
                    {
                        drtemp["edit_12"] = "नाही";
                    }
                    ds.Tables["dataRpt"].Rows.Add(drtemp);

                   
                   
                }

                DataView dv = ds.Tables["dataRpt"].DefaultView;
                dv.Sort = "edit_trans_no ,correction_date asc";
                 sortedDT = dv.ToTable().Copy();

                for (int i=0; i< sortedDT.Rows.Count; i++)
                {
                    sortedDT.Rows[i]["id"] = i + 1;
                }
            }

        string ccode = Convert.ToString(Session["VillageDetail"]).Split('#')[0];
        string Gaon = Convert.ToString(Session["VillageDetail"]).Split('#')[1];
        string taluka = Convert.ToString(Session["TalukaName"]);
        string jilha = Convert.ToString(Session["DistrictName"]);
        string tahsildarname = string.Empty;
        string circlename = string.Empty;
        string talathiname = string.Empty;
        //string adeshNo = string.Empty;
        //string adeshDate = string.Empty;


      


        DataSet dssevarth = con.funReturnDataSet((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_officermast", "trim(username) as username,user_type", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");
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
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("ReportEdit.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();


        List<ReportParameter> reportParams = new List<ReportParameter>();
        //reportParams.Add(new ReportParameter("ccode", ccode));
        reportParams.Add(new ReportParameter("gaon", Gaon));
        reportParams.Add(new ReportParameter("taluka", taluka));
        reportParams.Add(new ReportParameter("jilha", jilha));
        reportParams.Add(new ReportParameter("tahsildarname", tahsildarname));
        //reportParams.Add(new ReportParameter("adeshNo", adeshNo));
        //reportParams.Add(new ReportParameter("adeshDate", adeshDate));

        reportParams.Add(new ReportParameter("circlename", circlename));
        reportParams.Add(new ReportParameter("talathiname", talathiname));

        ReportViewer1.LocalReport.SetParameters(reportParams);
       // ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsEdit", ds.Tables["dataRpt"]));
        ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsEdit", sortedDT));

        ReportViewer1.DataBind();
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
}