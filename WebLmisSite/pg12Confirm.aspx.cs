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
public partial class pg12Confirm : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction cls = new clsCommonFunction();
    string page_name = "pg12Confirm";
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
            Session["page_heading"] = "७/१२ वरील फक्त पीक पहाणी चे काम केलेले सर्व्हे / गट क्रमांक ई-फेरफार साठी कन्फर्म ( कायम ) करणे";

            string query = " select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno , pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form12_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit'  and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' and confirm_flag<>'Confirm'  and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "')) union ";
            query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno , pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form12_main_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' and confirm_flag<>'Confirm' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "')) union ";
            query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno , pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form12_uncultiland_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' and confirm_flag<>'Confirm' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "')) union ";
            query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno , pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form12_irrsource_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' and confirm_flag<>'Confirm' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "')) union ";
            query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno , pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form12_remark_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' and confirm_flag<>'Confirm'  and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'))";

            DataSet ds12 = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), query);
            if (ds12 != null && ds12.Tables.Count>0 && ds12.Tables[0].Rows.Count>0)
            {
                gdv12Confirm.DataSource = ds12.Tables[0].DefaultView;
                gdv12Confirm.DataBind();
                btnConfirm.Enabled = true;
                Session["ds12"] = ds12;
            }
            else
            {
                string popupScript = "<script language='javascript'>alert('माहिती उपलब्ध नाही.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }

        }
    }
    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAll = (CheckBox)gdv12Confirm.HeaderRow.FindControl("chkSelectAll");
        if (chkSelectAll.Checked == true)
        {

            for (int i = 0; i < gdv12Confirm.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gdv12Confirm.Rows[i].FindControl("chkselect");
                chk.Checked = true;
            }
        }
        else if (chkSelectAll.Checked == false)
        {
            for (int i = 0; i < gdv12Confirm.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gdv12Confirm.Rows[i].FindControl("chkselect");
                chk.Checked = false;;
            }
        }
    }
    protected void chkselect_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btnConfirm_Click(object sender, EventArgs e)
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
                        int cnt = 0;
                        DataSet ds12 = (DataSet)Session["ds12"];
                        for (int i = 0; i < gdv12Confirm.Rows.Count; i++)
                        {
                            CheckBox chk = (CheckBox)gdv12Confirm.Rows[i].FindControl("chkselect");
                            if (chk.Checked == true)
                            {
                                con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "confirm_flag='Confirm'", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and survey ='" + ds12.Tables[0].Rows[i]["surveyno"] + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                cnt = 1;

                                string unit = con.funReturnSingleValue(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7", "khand_no", " ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin='" + ds12.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds12.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds12.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds12.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds12.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds12.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds12.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds12.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds12.Tables[0].Rows[i]["pin8"].ToString() + "'", "");
                                if (unit.Trim() != "1" && unit.Trim() != "2")
                                {
                                    con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7", "khand_no='1'", "ccode = '" + (string)Session["ccode"] + "' and pin='" + ds12.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds12.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds12.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds12.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds12.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds12.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds12.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds12.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds12.Tables[0].Rows[i]["pin8"].ToString() + "'", "ccode = '" + (string)Session["ccode"] + "' and  pin='" + ds12.Tables[0].Rows[i]["pin"].ToString() + "' and pin1='" + ds12.Tables[0].Rows[i]["pin1"].ToString() + "' and  pin2='" + ds12.Tables[0].Rows[i]["pin2"].ToString() + "' and pin3='" + ds12.Tables[0].Rows[i]["pin3"].ToString() + "' and pin4='" + ds12.Tables[0].Rows[i]["pin4"].ToString() + "' and pin5='" + ds12.Tables[0].Rows[i]["pin5"].ToString() + "' and pin6='" + ds12.Tables[0].Rows[i]["pin6"].ToString() + "'  and pin7='" + ds12.Tables[0].Rows[i]["pin7"].ToString() + "' and pin8 ='" + ds12.Tables[0].Rows[i]["pin8"].ToString() + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                }

                            }
                           
                        }
                        dbTransaction.Commit();
                        if (cnt == 1)
                        {
                            string query = " select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno , pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form12_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit'  and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' and confirm_flag<>'Confirm'  and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "')) union ";
                            query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno , pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form12_main_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' and confirm_flag<>'Confirm' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "')) union ";
                            query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno , pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form12_uncultiland_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' and confirm_flag<>'Confirm' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "')) union ";
                            query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno , pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form12_irrsource_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' and confirm_flag<>'Confirm' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "')) union ";
                            query += "select distinct rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/') as surveyno , pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form12_remark_audit  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and   app_name='reEdit' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )  in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and marked_flag='Edit' and confirm_flag<>'Confirm'  and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'))";


                            DataSet ds = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), query);

                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                gdv12Confirm.DataSource = ds.Tables[0].DefaultView;
                                gdv12Confirm.DataBind();
                                btnConfirm.Enabled = true;
                               
                            }
                            gdv12Confirm.DataSource = ds.Tables[0].DefaultView;
                            gdv12Confirm.DataBind();
                            ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('div_iterfer').style.display = 'block';", true);
                            string popupScript = "<script language='javascript'>alert('माहिती साठवली...!!!');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
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
                        string popupScript1 = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
                    }
                }
            }
            connection.Close();
        }

    }
    protected void btnback_Click(object sender, EventArgs e)
    {

    }
}