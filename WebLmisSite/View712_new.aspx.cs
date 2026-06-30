using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NIC.WebLMISLibrary;
using LandRecordMasterLibrary;


public partial class View712_new : System.Web.UI.Page
{
    string page_name = "View712.aspx";
    clsInputEntry objclsInputEntry = new clsInputEntry();
    clscommonfunedit objclscommonfunedit = new clscommonfunedit();
    clscommonfun objclsCommFun = new clscommonfun();
    NIC.WebLMISLibrary.clsCommonFunction objclsCommFunction = new NIC.WebLMISLibrary.clsCommonFunction();
    void Page_PreInit(object sender, EventArgs e)
    {

        if ((string)Session["user_type"] == "C")
        {
            if (this.Page.Master.ToString() != "ASP.circlemaster_master")
                this.Page.MasterPageFile = "~/circlemaster.master";
        }
    }
    protected void page_Init(object sender, EventArgs e)
    {
        base.OnPreInit(e);
        //HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        // HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //HttpContext.Current.Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        // ViewState["DatabaseName"] = "mulshi";
        ViewState["DatabaseName"] = (string)Session["DataBaseName"];
        ViewState["SchemaName"] = (string)Session["SchemaName"];
        string userName = (string)Session["UserName"];



        if (!objclsCommFunction.validateTextBox_IsSpecialChar(ref txtpin1) || !objclsCommFunction.validateTextBox_IsSpecialChar(ref txtpin2) || !objclsCommFunction.validateTextBox_IsSpecialChar(ref txtpin3) || !objclsCommFunction.validateTextBox_IsSpecialChar(ref txtpin4) || !objclsCommFunction.validateTextBox_IsSpecialChar(ref txtpin5) || !objclsCommFunction.validateTextBox_IsSpecialChar(ref txtpin6) || !objclsCommFunction.validateTextBox_IsSpecialChar(ref txtpin7) || !objclsCommFunction.validateTextBox_IsSpecialChar(ref txtpin8) || !objclsCommFunction.validateTextBox_IsSpecialChar(ref txtsurvey) || !objclsCommFunction.validateTextBox_IsSpecialChar(ref txtsurvey))
        {

            string popupScript = "<script language='javascript'>alert('कृपया, योग्य माहिती भरा.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            return;
        }

        if (!IsPostBack)
        {
            string userExist = objclsCommFun.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
            if (Convert.ToUInt32(userExist) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
            }
            Session["page_heading"] = "७/१२ पहा";
            //if (Session["user_type"].ToString() == "DBA")
            //    objclsCommFun.funSetDropDownList(Convert.ToString(ViewState["DatabaseName"]), ref ddlVillage, Convert.ToString(ViewState["SchemaName"]) + ".m_village_census as v," + Convert.ToString(ViewState["SchemaName"]) + ".m_officermast as o", "distinct v.ccode,v.village_name", "v.ccode='273100030379750000' and v.ccode=o.ccode ", "village_name");
            //else
            //    objclsCommFun.funSetDropDownList(Convert.ToString(ViewState["DatabaseName"]), ref ddlVillage, Convert.ToString(ViewState["SchemaName"]) + ".m_village_census as v," + Convert.ToString(ViewState["SchemaName"]) + ".m_officermast as o", "distinct v.ccode,v.village_name", "v.ccode='273100030379750000' and v.ccode=o.ccode and o.username='" + userName + "'", "village_name");

            if (Session["user_type"].ToString() == "DBA")
                 ////22/05/2025
                 //objclsCommFun.funSetDropDownList(Convert.ToString(ViewState["DatabaseName"]), ref ddlVillage, Convert.ToString(ViewState["SchemaName"]) + ".m_village_census as v," + Convert.ToString(ViewState["SchemaName"]) + ".m_officermast as o", "distinct v.ccode,v.village_name", " v.ccode=o.ccode ", "village_name");
                objclsCommFun.funSetDropDownList(Convert.ToString(ViewState["DatabaseName"]), ref ddlVillage, Convert.ToString(ViewState["SchemaName"]) + ".m_village_census as v," + Convert.ToString(ViewState["SchemaName"]) + ".m_officermast as o", "distinct v.ccode,v.village_name", " v.ccode=o.ccode ", "village_name");
            else
                ////22/05/2025
               // objclsCommFun.funSetDropDownList(Convert.ToString(ViewState["DatabaseName"]), ref ddlVillage, Convert.ToString(ViewState["SchemaName"]) + ".m_village_census as v," + Convert.ToString(ViewState["SchemaName"]) + ".m_officermast as o", "distinct v.ccode,v.village_name", " v.ccode=o.ccode and o.username='" + userName + "'", "village_name");
                objclsCommFun.funSetDropDownList(Convert.ToString(ViewState["DatabaseName"]), ref ddlVillage, Convert.ToString(ViewState["SchemaName"]) + ".m_village_census as v," + Convert.ToString(ViewState["SchemaName"]) + ".m_officermast as o", "distinct v.ccode,v.village_name", " v.ccode=o.ccode and o.username='" + userName + "'", "village_name");
            string str = ConfigurationManager.ConnectionStrings["Linkage Connection String1"].ConnectionString;
            ViewState["Parent_DatabaseName"] = str.Split('=')[2].Split(';')[0];
            ViewState["DatabaseName"] = Session["DataBaseName"].ToString();
            ViewState["SchemaName"] = Session["SchemaName"].ToString();
        }
    }


    protected void btnSearchSurveyNo_Click(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        lblMsg.Text = "";
        Session["date_12_view"] = "";
        try
        {
            gdvSurveySearch.Focus();
            txtsurvey.Text = txtsurvey.Text;
            if (txtsurvey.Text != "")
            {
                switch (rblSearch.SelectedValue)
                {
                    case "1":
                        bindsurve();
                        break;
                    case "2":
                        bindsurve_khata_no();
                        break;
                    case "3":
                        bindsurve_fname();
                        break;
                    case "4":
                        bindsurve_mname();
                        break;
                    case "5":
                        bindsurve_lname();
                        break;
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

    public void bindsurve()
    {
        DataSet ds1 = new DataSet();
        //ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7_khata", "distinct numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and khata_no<>'500001' and marked<>'Y' and trim(fname)<>'हा ७/१२ रद्द झाला आहे' and (numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) in (select numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + (string)ViewState["SchemaName"] + ".form7 where ccode ='" + ddlVillage.SelectedValue + "' and numeric_pin = '" + txtsurvey.Text + "')", "");
        // 19 Dec 2013
        ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and  pin ='" + txtsurvey.Text + "'", "");
    }

    public void bindsurve_khata_no()
    {
        DataSet ds1 = new DataSet();
        //ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7_khata", "distinct numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and khata_no<>'500001' and marked<>'Y' and trim(fname)<>'हा ७/१२ रद्द झाला आहे' and (numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) in (select numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + (string)ViewState["SchemaName"] + ".form7 where ccode ='" + ddlVillage.SelectedValue + "' and numeric_pin = '" + txtsurvey.Text + "')", "");
        // 19 Dec 2013
        ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7_khata", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and  khata_no ='" + txtsurvey.Text + "'", "");
    }


    public void bindsurve_fname()
    {
        DataSet ds1 = new DataSet();
        //ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7_khata", "distinct numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and khata_no<>'500001' and marked<>'Y' and trim(fname)<>'हा ७/१२ रद्द झाला आहे' and (numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) in (select numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + (string)ViewState["SchemaName"] + ".form7 where ccode ='" + ddlVillage.SelectedValue + "' and numeric_pin = '" + txtsurvey.Text + "')", "");
        // 19 Dec 2013
        ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7_khata", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and  fname like '%" + txtsurvey.Text + "%'", "");
    }

    public void bindsurve_mname()
    {
        DataSet ds1 = new DataSet();
        //ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7_khata", "distinct numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and khata_no<>'500001' and marked<>'Y' and trim(fname)<>'हा ७/१२ रद्द झाला आहे' and (numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) in (select numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + (string)ViewState["SchemaName"] + ".form7 where ccode ='" + ddlVillage.SelectedValue + "' and numeric_pin = '" + txtsurvey.Text + "')", "");
        // 19 Dec 2013
        ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7_khata", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and  mname like '%" + txtsurvey.Text + "%'", "");
    }

    public void bindsurve_lname()
    {
        DataSet ds1 = new DataSet();
        //ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7_khata", "distinct numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and khata_no<>'500001' and marked<>'Y' and trim(fname)<>'हा ७/१२ रद्द झाला आहे' and (numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) in (select numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + (string)ViewState["SchemaName"] + ".form7 where ccode ='" + ddlVillage.SelectedValue + "' and numeric_pin = '" + txtsurvey.Text + "')", "");
        // 19 Dec 2013
        ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7_khata", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and  lname like '%" + txtsurvey.Text + "%'", "");
    }

    #region [--- Grid Region ---]

    protected void gdvSurveySearch_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            ViewState["pin"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn")).Text;
            ViewState["pin1"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn1")).Text;
            ViewState["pin2"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn2")).Text;
            ViewState["pin3"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn3")).Text;
            ViewState["pin4"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn4")).Text;
            ViewState["pin5"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn5")).Text;
            ViewState["pin6"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn6")).Text;
            ViewState["pin7"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn7")).Text;
            ViewState["pin8"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn8")).Text;

            txtsurvey.Text = (string)ViewState["pin"];
            txtpin1.Text = (string)ViewState["pin1"];
            txtpin2.Text = (string)ViewState["pin2"];
            txtpin3.Text = (string)ViewState["pin3"];
            txtpin4.Text = (string)ViewState["pin4"];
            txtpin5.Text = (string)ViewState["pin5"];
            txtpin6.Text = (string)ViewState["pin6"];
            txtpin7.Text = (string)ViewState["pin7"];
            txtpin8.Text = (string)ViewState["pin8"];


            try
            {
                if (RadioButtonList1.SelectedIndex == 1)
                {
                    string date = System.DateTime.Today.Year.ToString();
                    Session["date_12_view"] = date;
                }
                else
                {
                    Session["date_12_view"] = "";
                }

                Session["pin"] = txtsurvey.Text;
                Session["pin1"] = txtpin1.Text;
                Session["pin2"] = txtpin2.Text;
                Session["pin3"] = txtpin3.Text;
                Session["pin4"] = txtpin4.Text;
                Session["pin5"] = txtpin5.Text;
                Session["pin6"] = txtpin6.Text;
                Session["pin7"] = txtpin7.Text;
                Session["pin8"] = txtpin8.Text;
                Session["val"] = "22";
                Session["gaon"] = ddlVillage.SelectedValue;
                Session["vcode"] = ddlVillage.SelectedValue;
                Session["vname"] = ddlVillage.SelectedItem.Text;
                Session["CircleClick"] = "";
                Session["DataBaseName"] = (string)ViewState["DatabaseName"];
                Session["SchemaName"] = (string)ViewState["SchemaName"];
                Session["reportType"] = "HTML";
                Application["view"] = "2";
                if (txtsurvey.Text != "")
                {

                    int khata = objclscommonfunedit.funReturnSingleValueInt((string)ViewState["DatabaseName"], (string)ViewState["SchemaName"] + ".form7_khata", "count(*)", "khata_no like '%TKN%' and pin='" + txtsurvey.Text + "'  and  pin1='" + txtpin1.Text + "' and  pin2='" + txtpin2.Text + "' and  pin3='" + txtpin3.Text + "' and  pin4='" + txtpin4.Text + "' and  pin5='" + txtpin5.Text + "' and  pin6='" + txtpin6.Text + "' and  pin7='" + txtpin7.Text + "' and  pin8='" + txtpin8.Text + "' and ccode='" + Session["gaon"] + "'", "");

                    if (khata == 0)
                    {
                        lblMsg.Visible = false;
                        lblMsg.Text = "";


                        //Response.Write("<script language='javascript'>window.open('Show712_1.aspx'); </Script>");
                        ClientScript.RegisterStartupScript(this.GetType(), "७/१२ पाहणे", String.Format("<script>window.open('{0}');</script>", "pg712_view.aspx"));
                    }
                    else
                    {
                        lblMsg.Visible = true;
                        lblMsg.Text = "या सर्व्हे क्रमांकावर TKN खाता क्रमांक आहे. TKN दुरुस्ती करण्यासाठी  लिंक  https://10.187.203.134/odbatool येथे ग्राम महसूल अधिकारी लॉगीन वापरावे.";
                        string popupScript122 = "<script language='javascript'>alert('या सर्व्हे क्रमांकावर TKN खाता क्रमांक आहे. TKN दुरुस्ती करण्यासाठी  लिंक  https://10.187.203.134/odbatool येथे ग्राम महसूल अधिकारी लॉगीन वापरावे.');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript122);


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


            //   int khata = objclscommonfunedit.funReturnSingleValueInt((string)ViewState["DatabaseName"], (string)ViewState["SchemaName"] + ".form7_khata", "count(*)", "khata_no like '%TKN%' and pin='" + txtsurvey.Text + "'  and  pin1='" + txtpin1.Text + "' and  pin2='" + txtpin2.Text + "' and  pin3='" + txtpin3.Text + "' and  pin4='" + txtpin4.Text + "' and  pin5='" + txtpin5.Text + "' and  pin6='" + txtpin6.Text + "' and  pin7='" + txtpin7.Text + "' and  pin8='" + txtpin8.Text + "' ccode='" + ddlVillage.SelectedValue + "'", "");





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

    #endregion

    protected void btnShow712_Click(object sender, EventArgs e)
    {
        try
        {
            Session["pin"] = txtsurvey.Text;
            Session["pin1"] = txtpin1.Text;
            Session["pin2"] = txtpin2.Text;
            Session["pin3"] = txtpin3.Text;
            Session["pin4"] = txtpin4.Text;
            Session["pin5"] = txtpin5.Text;
            Session["pin6"] = txtpin6.Text;
            Session["pin7"] = txtpin7.Text;
            Session["pin8"] = txtpin8.Text;
            Session["val"] = "22";
            Session["gaon"] = ddlVillage.SelectedValue;
            Session["vcode"] = ddlVillage.SelectedValue;
            Session["vname"] = ddlVillage.SelectedItem.Text;
            Session["CircleClick"] = "";
            Session["DataBaseName"] = (string)ViewState["DatabaseName"];
            Session["SchemaName"] = (string)ViewState["SchemaName"];
            Session["reportType"] = "HTML";
            Application["view"] = "2";
            if (txtsurvey.Text != "")
            {
                //Response.Write("<script language='javascript'>window.open('Show712_1.aspx'); </Script>");
                ClientScript.RegisterStartupScript(this.GetType(), "७/१२ पाहणे", String.Format("<script>window.open('{0}');</script>", "Show712_1.aspx"));
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

    protected void btnShow712New_Click(object sender, EventArgs e)
    {
        try
        {
            if (RadioButtonList1.SelectedIndex == 1)
            {
                string date = System.DateTime.Today.Year.ToString();
                Session["date_12_view"] = date;
            }
            else
            {
                Session["date_12_view"] = "";
            }

            Session["pin"] = txtsurvey.Text;
            Session["pin1"] = txtpin1.Text;
            Session["pin2"] = txtpin2.Text;
            Session["pin3"] = txtpin3.Text;
            Session["pin4"] = txtpin4.Text;
            Session["pin5"] = txtpin5.Text;
            Session["pin6"] = txtpin6.Text;
            Session["pin7"] = txtpin7.Text;
            Session["pin8"] = txtpin8.Text;
            Session["val"] = "22";
            Session["gaon"] = ddlVillage.SelectedValue;
            Session["vcode"] = ddlVillage.SelectedValue;
            Session["vname"] = ddlVillage.SelectedItem.Text;
            Session["CircleClick"] = "";
            Session["DataBaseName"] = (string)ViewState["DatabaseName"];
            Session["SchemaName"] = (string)ViewState["SchemaName"];
            Session["reportType"] = "HTML";
            Application["view"] = "2";
            if (txtsurvey.Text != "")
            {

                int khata = objclscommonfunedit.funReturnSingleValueInt((string)ViewState["DatabaseName"], (string)ViewState["SchemaName"] + ".form7_khata", "count(*)", "khata_no like '%TKN%' and pin='" + txtsurvey.Text + "'  and  pin1='" + txtpin1.Text + "' and  pin2='" + txtpin2.Text + "' and  pin3='" + txtpin3.Text + "' and  pin4='" + txtpin4.Text + "' and  pin5='" + txtpin5.Text + "' and  pin6='" + txtpin6.Text + "' and  pin7='" + txtpin7.Text + "' and  pin8='" + txtpin8.Text + "' and ccode='" + Session["gaon"] + "'", "");

                if (khata == 0)
                {
                    lblMsg.Visible = false;
                    lblMsg.Text = "";


                    //Response.Write("<script language='javascript'>window.open('Show712_1.aspx'); </Script>");
                    ClientScript.RegisterStartupScript(this.GetType(), "७/१२ पाहणे", String.Format("<script>window.open('{0}');</script>", "pg712_view.aspx"));
                }
                else
                {
                    lblMsg.Visible = true;
                    lblMsg.Text = "या सर्व्हे क्रमांकावर TKN खाता क्रमांक आहे. TKN दुरुस्ती करण्यासाठी  लिंक  https://10.187.203.134/odbatool येथे ग्राम महसूल अधिकारी लॉगीन वापरावे.";
                    string popupScript122 = "<script language='javascript'>alert('या सर्व्हे क्रमांकावर TKN खाता क्रमांक आहे. TKN दुरुस्ती करण्यासाठी  लिंक  https://10.187.203.134/odbatool येथे ग्राम महसूल अधिकारी लॉगीन वापरावे.');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript122);


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
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Convert.ToString(Session["user_type"]) == "T")
        {
            Response.Redirect("pgVillageSelection.aspx");
        }
        else if (Convert.ToString(Session["user_type"]) == "C")
        {
            Response.Redirect("pgEntryverify.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Word"] = "YES";
            // txtsurvey.Text = "";
            txtpin1.Text = "";
            txtpin2.Text = "";
            txtpin3.Text = "";
            txtpin4.Text = "";
            txtpin5.Text = "";
            txtpin6.Text = "";
            txtpin7.Text = "";
            txtpin8.Text = "";

            gdvSurveySearch.Focus();
            txtsurvey.Text = txtsurvey.Text;
            if (txtsurvey.Text != "")
            {
                DataSet ds1 = new DataSet();
                // bindsurve_character();
                ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref gdvSurveySearch, (string)ViewState["SchemaName"] + ".form7", "distinct numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and  (pin  like '%" + txtsurvey.Text + "%' or (numeric_pin > 0 and numeric_pin::text != pin)) ", "numeric_pin,pin");
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
    protected void btn12CurYear_Click(object sender, EventArgs e)
    {
        string date = System.DateTime.Today.Year.ToString();
        Session["date_12_view"] = date;


    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedIndex == 1)
        {
            string date = System.DateTime.Today.Year.ToString();
            Session["date_12_view"] = date;
        }
        else
        {
            Session["date_12_view"] = "";
        }


    }
    protected void ddlVillage_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(objclscommonfunedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3", "case  when count(*)=1 then true else false end", "ccode  ='" + ddlVillage.SelectedItem.Value.ToString() + "' and trim(ah1remark)='होय' and trim(ah2remark)='होय' and  	trim(docremark)='होय' and  	trim(prapatr2remark)='होय' ", "")) == true)
        {
            //Session["ccode"] = null;
            ddlVillage.SelectedIndex = 0;
            gdvSurveySearch.DataSource = null;
            gdvSurveySearch.DataBind();
            btnSearchSurveyNo.Enabled = false;
            Button2.Enabled = false;


            string popupScript = "alert('सदर गावाचे Declaration-III  झाले आहे. तथापी आपणांस री-डाटा एन्ट्री मॉड्युल मध्ये  काम करता येणार नाही  याची नोंद घ्यावी.');";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "popupScript", popupScript, true);
            return;

        }
        else
        {
            btnSearchSurveyNo.Enabled = true;
            Button2.Enabled = true;
        }
    }
}