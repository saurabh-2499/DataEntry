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


public partial class pgSurveyChangesRevert : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction obj = new clsCommonFunction();
    clscommonfunedit objclscommonfunedit = new clscommonfunedit();
    string page_name = "सर्व्हे क्रमांकावरील खातेदारांची अद्यावत/दुरुस्त केलेली माहिती पुर्ववत करणे";
    protected void Page_Load(object sender, EventArgs e)
      {
        if (!Page.IsPostBack)
        {
            Session["page_heading"] = "सर्व्हे क्रमांकावरील खातेदारांची अद्यावत/दुरुस्त केलेली माहिती पुर्ववत करणे";
            bool DecII_cnt = Convert.ToBoolean(objclscommonfunedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b, " + Convert.ToString(Session["SchemaName"]) + ".m_ewc_checks as c", "(case when count(a.*)>11 then true else false end) as d2status", "a.ccode ='" + Session["ccode"].ToString() + "' and  a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true and  a.wc_code=c.wc_code and  c.check_type='S'  and a.ccode  in  (  select    ccode  from " + Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3  where ccode ='" + Session["ccode"].ToString() + "')", ""));
            if (DecII_cnt == true)
            {
                string popupScript = "<script language='javascript'>alert('सदर गावाचे Declaration- II  केले आहे . त्यामुळे सर्व्हे क्रमांकावरील खातेदारांची अद्यावत/दुरुस्त केलेली माहिती पुर्ववत करता येणार नाही याची नोंद घ्यावी.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
            int DecIII_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".tblewc_proforma3 ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and    trim(ah1remark)='होय' and trim(ah2remark)='होय' and  	trim(docremark)='होय' and  	trim(prapatr2remark)='होय'", "");
            if (DecIII_cnt > 0)
            {
                string popupScript = "<script language='javascript'>alert('सदर गावाचे Declaration- III  केले आहे . त्यामुळे सर्व्हे क्रमांकावरील खातेदारांची अद्यावत/दुरुस्त केलेली माहिती पुर्ववत  करता येणार नाही याची नोंद घ्यावी.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
        }
    }
    protected void gdvSurveySearch_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            Session["pin"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn")).Text;
            Session["pin1"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn1")).Text;
            Session["pin2"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn2")).Text;
            Session["pin3"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn3")).Text;
            Session["pin4"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn4")).Text;
            Session["pin5"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn5")).Text;
            Session["pin6"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn6")).Text;
            Session["pin7"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn7")).Text;
            Session["pin8"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn8")).Text;


            int pershishtChk = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new", "count(*)", "ccode='" + Session["ccode"].ToString() + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "'  and pin6='" + Convert.ToString(Session["pin6"]) + "' and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8='" + Convert.ToString(Session["pin8"]) + "' and report_status='Generated' ", "");
            if (pershishtChk > 0 )
            {
                btnSave.Enabled = false;
                string popupScript = "<script language='javascript'>alert('सदर सर्व्हे क्रमांकाचे परिशिष्ट तयार केलेले आहे.त्यामुळे सर्व्हे क्रमांकावरील खातेदारांची अद्यावत/दुरुस्त केलेली माहिती पुर्ववत  करता येणार नाही याची नोंद घ्यावी.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }

            string survey = Convert.ToString(Session["pin"]) + '/' + Convert.ToString(Session["pin1"]) + '/' + Convert.ToString(Session["pin2"] )+ '/' + Convert.ToString(Session["pin3"]) + '/' + Convert.ToString(Session["pin4"]) + '/' + Convert.ToString(Session["pin5"]) + '/' + Convert.ToString(Session["pin6"]) + '/' + Convert.ToString(Session["pin7"]) + '/' + Convert.ToString(Session["pin8"]);
            survey = survey.Trim('/');
                
            DataTable dtedf7k = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata", "(khata_no::int) as seller_khata_no,fname,mname,lname,topan_name,total_area_h as seller_area_tot,assessment as na_assessment,anne::int,pai,potkharaba,usrno,cast(0 as int) as tenure_code,'' as Checked,marked,mut_no, edit_flag", "ccode='" + Session["ccode"].ToString() + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "'  and pin6='" + Convert.ToString(Session["pin6"]) + "' and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8='" + Convert.ToString(Session["pin8"]) + "' and edit_flag<>'34' and edit_flag<>'40' and edit_appname='reEdit'", "khata_no::int,usrno");
            if (dtedf7k.Rows.Count > 0) 
            {
                 DataTable dtf7k = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7_khata", "(khata_no::int) as seller_khata_no,fname,mname,lname,topan_name,total_area_h as seller_area_tot,assessment as na_assessment,anne::int,pai,potkharaba,usrno,cast(0 as int) as tenure_code,'' as Checked,marked,mut_no,0 as edit_flag", "ccode='" + Session["ccode"].ToString() + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "'  and pin6='" + Convert.ToString(Session["pin6"]) + "' and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8='" + Convert.ToString(Session["pin8"]) + "' ", "");
                 if (dtf7k.Rows.Count > 0)
                 {
                     gdvSurveySearch.DataSource = null;
                     gdvSurveySearch.DataBind();
                     gdvSurveySearch.Visible = false;
                     lblSurveySelectedDisplay.Text = survey;
                     lblSurveySelected.Visible = true;
                     pnlkhataDetails.Visible = true;
                     pnlProcessing.Visible = true;
                     gdvSurveyDetails.DataSource = dtf7k.DefaultView;
                     gdvSurveyDetails.DataBind();
                     gdvSurveyProcessData.DataSource = dtedf7k.DefaultView;
                     gdvSurveyProcessData.DataBind();
                     lblOriginalKhataMaster.Visible = true;
                     lblProcessingData.Visible = true;
                     btnSave.Enabled = true;
                     lblSurveySelected.Visible = true;

                 }
                 else
                 {
                     btnSave.Enabled = false;
                     string popupScript = "<script language='javascript'>alert('सर्व्हे क्रमांक उपलब्ध नाही.');</script>";
                     ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                     return;
                 }
            }
            else
            {
                dtedf7k = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata", "*", "ccode='" + Session["ccode"].ToString() + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "'  and pin6='" + Convert.ToString(Session["pin6"]) + "' and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8='" + Convert.ToString(Session["pin8"]) + "' and edit_appname='reEdit'", "");
                if (dtedf7k.Rows.Count > 0)
                {
                    btnSave.Enabled = true;
                    string popupScript = "<script language='javascript'>alert('सर्व्हे क्रमांकावरील सर्व नावे वगळण्यात आली आहेत.');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
                else
                {
                    btnSave.Enabled = false;
                    string popupScript = "<script language='javascript'>alert('निवडलेला सर्व्हे क्रमांक दुरुस्तीसाठी डाटा एन्ट्री मॉड्युलमध्ये निवडलेला नाही.');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
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
    protected void btnSearchSurveyNo_Click(object sender, EventArgs e)
    {
        try
        {
            gdvSurveySearch.Focus();
            txtsurvey.Text = txtsurvey.Text;
            if (txtsurvey.Text != "")
            {
                DataSet ds = new DataSet();
                ds = objclscommonfunedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + Session["ccode"].ToString() + "' and  pin ='" + txtsurvey.Text + "'", "");
                if(ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
                {
                    gdvSurveySearch.DataSource = ds.Tables[0].DefaultView;
                    gdvSurveySearch.DataBind();
                }
                else
                {
                    btnSave.Enabled = false;
                    string popupScript = "<script language='javascript'>alert('सर्व्हे क्रमांक दुरुस्तीसाठी डाटा एन्ट्री मॉड्युलमध्ये निवडलेला नाही.'');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
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
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
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
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.funDeleteRecordSevarthID(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail", "ccode='" + Convert.ToString(Session["ccode"]) + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "'  and pin6='" + Convert.ToString(Session["pin6"]) + "' and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8='" + Convert.ToString(Session["pin8"]) + "'  and edit_appname='reEdit'", Convert.ToString(Session["UserName"]), ref dbCommand);
                        con.funDeleteRecordSevarthID(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_form7_khata", "ccode='" + Convert.ToString(Session["ccode"]) + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "'  and pin6='" + Convert.ToString(Session["pin6"]) + "' and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8='" + Convert.ToString(Session["pin8"]) + "'  and edit_appname='reEdit'", Convert.ToString(Session["UserName"]), ref dbCommand);
                        con.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_audit", "ccode='" + Convert.ToString(Session["ccode"]) + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "'  and pin6='" + Convert.ToString(Session["pin6"]) + "' and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8='" + Convert.ToString(Session["pin8"]) + "'  and edit_appname='reEdit'", ref dbCommand);
                        con.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_form7_khata_audit", "ccode='" + Convert.ToString(Session["ccode"]) + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "'  and pin6='" + Convert.ToString(Session["pin6"]) + "' and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8='" + Convert.ToString(Session["pin8"]) + "'  and edit_appname='reEdit'",  ref dbCommand);
                        obj.funUpdateMutTables(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_mut_deal_new", "deal_code_owner='',deal_text_owner_old='',deal_text_owner_new=''", "ccode='" + Convert.ToString(Session["ccode"]) + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "'  and pin6='" + Convert.ToString(Session["pin6"]) + "' and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8='" + Convert.ToString(Session["pin8"]) + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                        con.funUpdateValue(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_mut_deal_new_audit", "deal_code_owner='',deal_text_owner_old='',deal_text_owner_new=''", "ccode='" + Convert.ToString(Session["ccode"]) + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "'  and pin6='" + Convert.ToString(Session["pin6"]) + "' and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8='" + Convert.ToString(Session["pin8"]) + "'", ref dbCommand);
                        dbTransaction.Commit();
                        
                        txtsurvey.Text = String.Empty;
                        pnlkhataDetails.Visible = false;
                        pnlProcessing.Visible = false;
                        gdvSurveySearch.DataSource = null;
                        gdvSurveySearch.DataBind();
                        gdvSurveyDetails.DataSource = null;
                        gdvSurveyDetails.DataBind();
                        lblOriginalKhataMaster.Visible = false;
                        lblProcessingData.Visible = false;
                        lblSurveySelected.Visible = false;
                        lblSurveySelectedDisplay.Text = string.Empty;
                        lblSurveySelectedDisplay.Visible = false;
                        string popupScript = "<script language='javascript'>alert('खात्याची माहिती पुर्ववत करण्यात आली आहे.');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling excpt = new ExceptionHandling();
                        if (Session["UserName"] != null)
                            Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
                        else
                            Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                        return;
                    }
                }
            }
            connection.Close();
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        txtsurvey.Text = String.Empty;
        pnlkhataDetails.Visible = false;
        pnlProcessing.Visible = false;
        gdvSurveySearch.DataSource = null;
        gdvSurveySearch.DataBind();
        gdvSurveyDetails.DataSource = null;
        gdvSurveyDetails.DataBind();
        lblOriginalKhataMaster.Visible = false;
        lblProcessingData.Visible = false;
        lblSurveySelected.Visible = false;
        lblSurveySelectedDisplay.Text = string.Empty;
        lblSurveySelectedDisplay.Visible = false;

    }
}