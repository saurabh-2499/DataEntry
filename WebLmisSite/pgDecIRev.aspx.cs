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

public partial class pgDecIRev : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    #region [-- Local Variables --]

    clscommonfun con = new clscommonfun();
    clsCommonFunction objclsCommFun = new clsCommonFunction();
    clscommonfunedit objclscommfunedit = new clscommonfunedit();
    string page_name = "pgDecIRev.aspx";

    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
       
        try
                {
                    string a = Session["user_type"].ToString();
                    if (!Page.IsPostBack)
                    {
                        if (Session["ccode"] == null)
                        {
                            string userExist = objclscommfunedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "user_id='" + Convert.ToString(Session["UserName"]) + "' and logout_time is null", "");
                            if (Convert.ToUInt32(userExist) == 0)
                            {
                                objclscommfunedit.funInserSingleRecord(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "session_id, user_id, login_time, logout_time, app_name", "'" + Convert.ToString(Session["newsession_id"]) + "','" + Convert.ToString(Session["UserName"]) + "',now(),null,'reEdit'");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Activex", "MultipleUserLogin();", true);
                            }
                        }
                        else
                        {
                            string userExist = objclscommfunedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
                            if (Convert.ToUInt32(userExist) == 0)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
                            }
                        }

                        ViewState["AllowBulkSign"] = "false";
                        string popupScript = "";
                        if (Session["ccode"] == null)
                        {
                            

                            popupScript = "<script language='javascript'>alert('कृपया, कामाची सुरुवात करण्यापूर्वी गावाची निवड करा.');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                            return;
                        }
                        popupScript = "";
                        DataSet ds = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o," + Convert.ToString(Session["SchemaName"]) + ".form7 as form7 ", "distinct v.village_code,v.ccode,v.village_name,count(distinct form7.*) as survey ", "v.ccode=o.ccode and v.ccode=form7.ccode    group by v.village_code,v.ccode,v.village_name", "v.village_name");
                        dgvVillageSelection.DataSource = ds.Tables[0].DefaultView;
                        dgvVillageSelection.DataBind();
                        hftype.Value = "R";

                       //// Session["page_heading"] = "गाव निवडा";
                        Label lblusername = (Label)Master.FindControl("lblusername");
                        lblusername.Text = Convert.ToString(Session["UserName"]);
                      //  Panel1.Visible = true;
                    }
                    else
                    {
                        if (Convert.ToString(hfMultipleUsers.Value) == "true")
                        {
                            objclscommfunedit.funUpdateValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]), "rcis_uni.login_details", "logout_time=now()", "user_id='" + Convert.ToString(Session["UserName"]) + "'");
                            objclscommfunedit.funInserSingleRecord(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "session_id, user_id, login_time, logout_time, app_name", "'" + Convert.ToString(Session["newsession_id"]) + "','" + Convert.ToString(Session["UserName"]) + "',now(),null,'reEdit'");
                            hfMultipleUsers.Value = "";
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
                    string popupScript = "alert('" + Convert.ToString(Session["Error"]) + "');";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                            return;
                }
            }



    protected void dgvVillageSelection_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }
}