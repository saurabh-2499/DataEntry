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

public partial class pgEmnNotMkCorrection : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction cls = new clsCommonFunction();
    string page_name = "pgEditSurveyRelease";
    string query = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
            if (Convert.ToUInt32(userExist) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
            }
            Session["page_heading"] = "री-एडिट फेज - १ मधिल  दुरुस्त्या केलेले सर्व्हे क्रमांक / गट क्रमांक प्रमाणित करण्यासाठी उपलब्ध  करणे ";
            string query = "select distinct rtrim(((CASE WHEN emn.pin<>'' THEN cast(trim(emn.pin) as text)|| '/' WHEN emn.pin='' THEN '' END)  ||(CASE WHEN emn.pin1<>'' THEN cast(trim(emn.pin1) as text)|| '/' WHEN emn.pin1='' THEN '' END)  ||(CASE WHEN emn.pin2<>'' THEN cast(trim(emn.pin2) as text)|| '/' WHEN emn.pin2='' THEN '' END)  ||(CASE WHEN emn.pin3<>'' THEN cast(trim(emn.pin3)as text)|| '/' WHEN emn.pin3='' THEN '' END)  ||(CASE WHEN emn.pin4<>'' THEN cast(trim(emn.pin4) as text)|| '/' WHEN emn.pin4='' THEN '' END)  ||(CASE WHEN emn.pin5<>'' THEN cast(trim(emn.pin5) as text)|| '/' WHEN emn.pin5='' THEN '' END)  ||(CASE WHEN emn.pin6<>'' THEN cast(trim(emn.pin6) as text)|| '/' WHEN emn.pin6='' THEN '' END)  ||(CASE WHEN emn.pin7<>'' THEN cast(trim(emn.pin7) as text)|| '/' WHEN emn.pin7='' THEN '' END)  ||(CASE WHEN emn.pin8<>'' THEN cast(trim(emn.pin8) as text)|| '/' WHEN emn.pin8='' THEN '' END)),'/') as surveyno , emn.edit_mut_no ,emn.edit_trans_no, emn.pin , emn.pin1, emn.pin2,emn.pin3,emn.pin4,emn.pin5,emn.pin6,emn.pin7,emn.pin8  from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  emn, " + Convert.ToString(Session["SchemaName"]) + ".mut_kharedi m  where emn.ccode = '" + Convert.ToString(Session["ccode"]) + "' and  emn.ccode= m.ccode   and approve_flag <>'Approve' and lock_flag='Lock' and edit_mut_no<>'0' and  correction_deal <>'emn'  and  emn.edit_mut_no <> m.mut_no order by  emn.pin , emn.pin1, emn.pin2,emn.pin3,emn.pin4,emn.pin5,emn.pin6,emn.pin7,emn.pin8 ";
            DataSet dsEditRemove = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), query);
            if (dsEditRemove != null && dsEditRemove.Tables.Count > 0 && dsEditRemove.Tables[0].Rows.Count > 0)
            {
                gdvreEditNamanjurSurvey.DataSource = dsEditRemove.Tables[0].DefaultView;
                gdvreEditNamanjurSurvey.DataBind();
                btnSave.Enabled = true;
                Session["dsEditRemove"] = dsEditRemove;
            }
            else
            {
                string popupScript = "<script language='javascript'>alert('री-एडिट फेज - १ मधिल  दुरुस्त्या केलेले सर्व्हे क्रमांक / गट क्रमांक प्रमाणित करण्यासाठी उपलब्ध करण्यासाठी माहिती उपलब्ध नाही.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (gdvreEditNamanjurSurvey.Rows.Count > 0)
        {
            string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
            try
            {
                int cnt = 0;
                DataSet ds = new DataSet();
                DataSet dsEditRemove = (DataSet)Session["dsEditRemove"];
                for (int i = 0; i < gdvreEditNamanjurSurvey.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)gdvreEditNamanjurSurvey.Rows[i].FindControl("chkselect");
                    if (chk.Checked == true)
                    {
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
                                        //-- insert in mut_kharedi 
                                        con.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_kharedi", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,or_code4,mut_no", "'" + Convert.ToString(Session["ccode"]) + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin1"].ToString() + "','" + dsEditRemove.Tables[0].Rows[i]["pin2"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin3"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin4"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin5"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin6"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin7"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin8"].ToString() + "',1,'" + dsEditRemove.Tables[0].Rows[i]["edit_mut_no"].ToString() + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        con.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_deal", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,mut_no,deal_text_old", "'" + Convert.ToString(Session["ccode"]) + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "','" + dsEditRemove.Tables[0].Rows[i]["pin2"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin3"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin4"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin5"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin6"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin7"].ToString() + "' ,'" + dsEditRemove.Tables[0].Rows[i]["pin8"].ToString() + "','" + dsEditRemove.Tables[0].Rows[i]["edit_mut_no"].ToString() + "','" + dsEditRemove.Tables[0].Rows[i]["edit_trans_no"].ToString() + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mutregister", "mut_status_code=1", " ccode ='" + Convert.ToString(Session["ccode"]) + "' and  mut_no ='" + dsEditRemove.Tables[0].Rows[i]["edit_mut_no"].ToString() + "' and mut_type = 101", ref dbCommand, Convert.ToString(Session["UserName"]));
                                        con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "correction_deal ='emn'", " ccode ='" + Convert.ToString(Session["ccode"]) + "' and edit_mut_no ='" + dsEditRemove.Tables[0].Rows[i]["edit_mut_no"].ToString() + "' and  pin='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "'  and  pin1='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and  pin2='" + dsEditRemove.Tables[0].Rows[i]["pin2"].ToString() + "'  and  pin3='" + dsEditRemove.Tables[0].Rows[i]["pin3"].ToString() + "'  and  pin4='" + dsEditRemove.Tables[0].Rows[i]["pin4"].ToString() + "'  and  pin5='" + dsEditRemove.Tables[0].Rows[i]["pin5"].ToString() + "'  and  pin6='" + dsEditRemove.Tables[0].Rows[i]["pin6"].ToString() + "'  and  pin7='" + dsEditRemove.Tables[0].Rows[i]["pin7"].ToString() + "'  and  pin8='" + dsEditRemove.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                        //-- reedit related tables 
                                        dbTransaction.Commit();
                                        cnt = 1;
                                    }
                                    catch (Exception ex)
                                    {
                                        dbTransaction.Rollback();
                                        ExceptionHandling excpt = new ExceptionHandling();
                                        if (Session["UserName"] != null)
                                            Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
                                        else
                                            Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                                        string popupScript1 = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
                                    }
                                }
                            }
                            connection.Close();
                        }
                    }
                    if (cnt == 1)
                    {
                        string query = "select distinct rtrim(((CASE WHEN emn.pin<>'' THEN cast(trim(emn.pin) as text)|| '/' WHEN emn.pin='' THEN '' END)  ||(CASE WHEN emn.pin1<>'' THEN cast(trim(emn.pin1) as text)|| '/' WHEN emn.pin1='' THEN '' END)  ||(CASE WHEN emn.pin2<>'' THEN cast(trim(emn.pin2) as text)|| '/' WHEN emn.pin2='' THEN '' END)  ||(CASE WHEN emn.pin3<>'' THEN cast(trim(emn.pin3)as text)|| '/' WHEN emn.pin3='' THEN '' END)  ||(CASE WHEN emn.pin4<>'' THEN cast(trim(emn.pin4) as text)|| '/' WHEN emn.pin4='' THEN '' END)  ||(CASE WHEN emn.pin5<>'' THEN cast(trim(emn.pin5) as text)|| '/' WHEN emn.pin5='' THEN '' END)  ||(CASE WHEN emn.pin6<>'' THEN cast(trim(emn.pin6) as text)|| '/' WHEN emn.pin6='' THEN '' END)  ||(CASE WHEN emn.pin7<>'' THEN cast(trim(emn.pin7) as text)|| '/' WHEN emn.pin7='' THEN '' END)  ||(CASE WHEN emn.pin8<>'' THEN cast(trim(emn.pin8) as text)|| '/' WHEN emn.pin8='' THEN '' END)),'/') as surveyno , emn.edit_mut_no ,emn.edit_trans_no, emn.pin , emn.pin1, emn.pin2,emn.pin3,emn.pin4,emn.pin5,emn.pin6,emn.pin7,emn.pin8  from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  emn, " + Convert.ToString(Session["SchemaName"]) + ".mut_kharedi m  where emn.ccode = '" + Convert.ToString(Session["ccode"]) + "' and  emn.ccode= m.ccode   and approve_flag <>'Approve' and lock_flag='Lock' and edit_mut_no<>'0'  and correction_deal <>'emn'  and  emn.edit_mut_no <> m.mut_no order by  emn.pin , emn.pin1, emn.pin2,emn.pin3,emn.pin4,emn.pin5,emn.pin6,emn.pin7,emn.pin8 ";
                        ds = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), query);
                        cnt = 0;
                    }
                }
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gdvreEditNamanjurSurvey.DataSource = ds.Tables[0].DefaultView;
                    gdvreEditNamanjurSurvey.DataBind();
                    gdvreEditNamanjurSurvey.Enabled = true;
                    Session["dsEditRemove"] = ds;
                }
                ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('div_iterfer').style.display = 'block';", true);
                string popupScript = "<script language='javascript'>alert('माहिती साठवली...!!!');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                gdvreEditNamanjurSurvey.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionHandling excpt = new ExceptionHandling();
                if (Session["UserName"] != null)
                    Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
                else
                    Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                string popupScript1 = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
            }
        }
        else
        {
            btnSave.Enabled = false;
            string popupScript = "<script language='javascript'>alert(' फेज - १ मधिल  दुरुस्त्या केलेले सर्व्हे क्रमांक / गट क्रमांक प्रमाणित करण्यासाठी उपलब्ध करण्यासाठी माहिती उपलब्ध नाही.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            return;
        }
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("pgVillageSelection.aspx", false);
    }
    protected void chkselect_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = (CheckBox)gdvreEditNamanjurSurvey.HeaderRow.FindControl("chkSelectAll");
        if (chkSelectAll.Checked == true)
        {
            for (int i = 0; i < gdvreEditNamanjurSurvey.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gdvreEditNamanjurSurvey.Rows[i].FindControl("chkselect");
                chk.Checked = true;
            }
        }
        else if (chkSelectAll.Checked == false)
        {
            for (int i = 0; i < gdvreEditNamanjurSurvey.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gdvreEditNamanjurSurvey.Rows[i].FindControl("chkselect");
                chk.Checked = false; ;
            }
        }
    }
}