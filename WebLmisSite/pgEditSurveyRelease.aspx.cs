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
public partial class pgEditSurveyRelease : System.Web.UI.Page
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
            Session["page_heading"] = "दुरुस्तीसाठी निवडलेले परंतु दुरुस्त्या न केलेले सर्व्हे क्रमांक / गट क्रमांक नविन ७/१२ तयार करण्यासाठी उपलब्ध करणे";
            string query = " select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new   where ccode = '" + Convert.ToString(Session["ccode"]) + "' and marked_flag='Edit' and confirm_flag<>'Confirm'  and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "' )  ";
            string query1 = " select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new   where ccode = '" + Convert.ToString(Session["ccode"]) + "' and report_status ='Generated'   and marked_flag='Edit' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode='" + Convert.ToString(Session["ccode"]) + "' and deal_code_area='' and deal_code_tenure='' and   deal_code_owner='' and  deal_code_orights_add='' and  deal_code_orights_lesson='' and  deal_code_kul_add='' and  deal_code_kul_lesson='' and  deal_code_itarferfar='' and areaunit_code='' and localname_code ='' )  order by pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  ";
            DataSet dsEditRemove = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), query);
            DataSet dsEditRemove_emd = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), query1);

            if (dsEditRemove_emd != null && dsEditRemove_emd.Tables.Count > 0 && dsEditRemove_emd.Tables[0].Rows.Count > 0)
            {
                 if (dsEditRemove != null && dsEditRemove.Tables.Count > 0 && dsEditRemove.Tables[0].Rows.Count > 0)
                 {
                     dsEditRemove.Merge(dsEditRemove_emd);
                 }
                 else
                 {
                     dsEditRemove = dsEditRemove_emd.Copy();
                 }
            }
            if (dsEditRemove != null && dsEditRemove.Tables.Count > 0 && dsEditRemove.Tables[0].Rows.Count > 0 )
            {
                gdvEditRemove.DataSource = dsEditRemove.Tables[0].DefaultView;
                gdvEditRemove.DataBind();
                btnSave.Enabled = true;
                Session["dsEditRemove"] = dsEditRemove;
            }
            else
            {
                string popupScript = "<script language='javascript'>alert('दुरुस्तीसाठी निवडलेले परंतु दुरुस्त्या न केलेले सर्व्हे क्रमांक / गट क्रमांक नविन ७/१२ तयार करण्यासाठी उपलब्ध करण्यासाठी माहिती उपलब्ध नाही.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
               
        }
    }
    
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("pgVillageSelection.aspx", false);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (gdvEditRemove.Rows.Count > 0)
        {
            string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
          //  string _connectionString = ((string)Session["DataBaseName"]).Split('#')[0] + "database = " + ((string)Session["DataBaseName"]).Split('#')[1] + ";" + (string)System.Configuration.ConfigurationManager.ConnectionStrings["LRSRO Connection StringMutation"].ConnectionString.ToString();

            try
            {
                int cnt = 0;
                DataSet ds = new DataSet();
                DataSet dsEditRemove = (DataSet)Session["dsEditRemove"];
                for (int i = 0; i < gdvEditRemove.Rows.Count; i++)
                {
                    CheckBox chk = (CheckBox)gdvEditRemove.Rows[i].FindControl("chkselect");
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

                                        //-- edit related regular and mutation tables 
                                        con.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        con.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_deal_new", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);

                                        con.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        con.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_area", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        con.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        con.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_orights", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        con.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_mut_no", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);


                                        con.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_kharedi", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Session["SchemaName"].ToString() + ".mut_kharedi_audit where  ccode='" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "' and app_name ='reEdit'  and  app_name <>'eMutation' and  app_name <>'DataUpdation' )", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        con.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_deal", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Session["SchemaName"].ToString() + ".mut_deal_audit where  ccode='" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "' and app_name ='reEdit'  and  app_name <>'eMutation' and  app_name <>'DataUpdation')", Convert.ToString(Session["UserName"]), ref dbCommand);

                                        //--  audit tables of edit related regular and mutation tables 

                                        con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", ref dbCommand);
                                        con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_deal_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", ref dbCommand);

                                        con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", ref dbCommand);
                                        con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_area_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", ref dbCommand);
                                        con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", ref dbCommand);
                                        con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_orights_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", ref dbCommand);
                                        con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_mut_no_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", ref dbCommand);
                                        con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_kharedi_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "' and  app_name ='reEdit' and  app_name <>'eMutation' and  app_name <>'DataUpdation' ", ref dbCommand);
                                        con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_deal_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "' and   app_name ='reEdit' and  app_name <>'eMutation' and  app_name <>'DataUpdation'", ref dbCommand);


                                        int edit_mut_no = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "edit_mut_no", "ccode='" + Convert.ToString(Session["ccode"]) + "' and pin ='" + dsEditRemove.Tables[0].Rows[i]["pin"] + "' and pin1 ='" + dsEditRemove.Tables[0].Rows[i]["pin1"] + "' and pin2 ='" + dsEditRemove.Tables[0].Rows[i]["pin2"] + "' and pin3 ='" + dsEditRemove.Tables[0].Rows[i]["pin3"] + "' and pin4 ='" + dsEditRemove.Tables[0].Rows[i]["pin4"] + "' and pin5 ='" + dsEditRemove.Tables[0].Rows[i]["pin5"] + "' and pin6 ='" + dsEditRemove.Tables[0].Rows[i]["pin6"] + "' and pin7 ='" + dsEditRemove.Tables[0].Rows[i]["pin7"] + "' and pin8 ='" + dsEditRemove.Tables[0].Rows[i]["pin8"] + "'", "");
                                        int edit_mut_no_cnt = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "count(edit_mut_no)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and edit_mut_no='" + edit_mut_no + "'", "");
                                        if (edit_mut_no_cnt == 1)
                                        {
                                            con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mutregister", "ccode = '" + Convert.ToString(Session["ccode"]) + "'  and mut_no='" + edit_mut_no + "' and  mut_type ='101' ", ref dbCommand);
                                            con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mutregister_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "'  and mut_no='" + edit_mut_no + "' and  app_name ='reEdit' and  app_name <>'eMutation' and  app_name <>'DataUpdation' ", ref dbCommand);
                                        }
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

                        string query = " select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and marked_flag='Edit' and confirm_flag<>'Confirm'  and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "' )  order by pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ";
                        string query1 = " select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and report_status ='Generated'   and marked_flag='Edit' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode='" + Convert.ToString(Session["ccode"]) + "' and deal_code_area='' and deal_code_tenure='' and   deal_code_owner='' and  deal_code_orights_add='' and  deal_code_orights_lesson='' and  deal_code_kul_add='' and  deal_code_kul_lesson='' and  deal_code_itarferfar='' and areaunit_code='' and localname_code ='' )  order by pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  ";

                        ds = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), query);
                        DataSet dsEditRemove_emd = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), query1);

                        if (dsEditRemove_emd != null && dsEditRemove_emd.Tables.Count > 0 && dsEditRemove_emd.Tables[0].Rows.Count > 0)
                        {
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                ds.Merge(dsEditRemove_emd);
                            }
                            else
                            {
                                ds = dsEditRemove_emd.Copy();
                            }
                        }


                        cnt = 0;
                    }


                }
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gdvEditRemove.DataSource = ds.Tables[0].DefaultView;
                    gdvEditRemove.DataBind();
                    gdvEditRemove.Enabled = true;
                    Session["dsEditRemove"] = ds;

                }
                ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('div_iterfer').style.display = 'block';", true);
                string popupScript = "<script language='javascript'>alert('माहिती साठवली...!!!');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                gdvEditRemove.DataBind();


            }
            catch (Exception ex)
            {
                //   dbTransaction.Rollback();
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
            string popupScript = "<script language='javascript'>alert('दुरुस्तीसाठी निवडलेले परंतु दुरुस्त्या न केलेले सर्व्हे क्रमांक / गट क्रमांक नविन ७/१२ तयार करण्यासाठी उपलब्ध करण्यासाठी माहिती उपलब्ध नाही.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            return;
        }
    }
    protected void chkselect_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = (CheckBox)gdvEditRemove.HeaderRow.FindControl("chkSelectAll");
        if (chkSelectAll.Checked == true)
        {

            for (int i = 0; i < gdvEditRemove.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gdvEditRemove.Rows[i].FindControl("chkselect");
                chk.Checked = true;
            }
        }
        else if (chkSelectAll.Checked == false)
        {
            for (int i = 0; i < gdvEditRemove.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gdvEditRemove.Rows[i].FindControl("chkselect");
                chk.Checked = false; ;
            }
        }
    }
}