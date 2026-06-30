using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.Security.Cryptography;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Data.Common;
using System.Web.SessionState;
using System.Net;
using NIC.WebLMISLibrary;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Web.Caching;
using System.Text;
public partial class pgLogin : System.Web.UI.Page
{
    #region "-----Global Variable----"
    clscommonfunedit objclscommonfunedit = new clscommonfunedit();
    clsCommonFunction objclscommonfun = new clsCommonFunction();
    clscommonfun objcls = new clscommonfun();
    clsLoginChecking objForms = new clsLoginChecking();
    ExceptionHandling excpt = new ExceptionHandling();
    string page_name = "pgLogin";
    SFix objSFix = new SFix();
    DataSet mDataset = new DataSet();
    string MD5pass = "";
    #endregion

    protected void page_Init(object sender, EventArgs e)
    {
        base.OnPreInit(e);
        //HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
        // HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //HttpContext.Current.Response.Cache.SetNoStore();
    }




    #region "--------Page Load-------"

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //Response.Cache.SetExpires(DateTime.Now.AddMinutes(5));
            //Response.Cache.SetCacheability(HttpCacheability.Public);

            if (!objclscommonfun.validateTextBox_IsSpecialChar(ref txtLoginName) || !objclscommonfun.validateTextBox_IsSpecialChar(ref txtPassword) || !objclscommonfun.validateTextBox_IsSpecialChar(ref CodeNumberTextBox))
            {
                string popupScript = "alert('कृपया, योग्य माहिती भरा.')";
                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
                return;
            }
            //UsersOnlineLabel.Text = "वेब सर्व्हर वापरकर्ते संख्या : " + Convert.ToInt32(Application["OnlineVisitors"]);

            if (!Page.IsPostBack)
            {
                txtLoginName.Attributes.Add("autocomplete", "off");
                txtPassword.Attributes.Add("autocomplete", "off");
                CodeNumberTextBox.Attributes.Add("autocomplete", "off");

                txtLoginName.Focus();
                Session["date1"] = System.DateTime.Now;
                ViewState["DatabaseName"] = "";
                ViewState["SchemaName"] = "";
                Session["SaltStr"] = objSFix.RandomString(15).ToString();
                Session["viewstatecnt"] = 0;
                this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);

                try
                {

                    // if (Cache["DistrictData"] == null)
                    // {
                    //     DataSet ds = objcls.funReturnds("rcis_uni.m_district_census", "*", "", "");
                    //    Cache.Add("DistrictData", ds.Tables[0], null, DateTime.Now.AddMinutes(15), TimeSpan.Zero, CacheItemPriority.High, null);
                    // }

                    // string total_user_load = objcls.funReturnSingleValue("rcis_uni.login_details", "count(distinct user_id)", "login_time>'" + System.DateTime.Today.ToString("yyyy-MM-dd") + "' and logout_time is null ", "");
                    // TotalUsersOnlineLabel.Text = "एकूण वापरकर्ते संख्या : " + total_user_load;

                    //string web_server_user_load = objcls.funReturnSingleValue("rcis_uni.login_details", "count( distinct (user_id))", "login_time :: date ='" + System.DateTime.Today.ToString("yyyy-MM-dd") + "' and logout_time is null and distcode  in(select  district_code from rcis_uni.m_district_census where webip = '" + Request.Url.Authority.Split(':')[0] + "') ", "");
                    // UsersOnlineLabel.Text = "वेब सर्वर वापरकर्ते संख्या : " + web_server_user_load;


                    //DataTable dt = (DataTable)Cache["DistrictData"];

                    //DataRow[] row = dt.Select("webip='" + Request.Url.Authority.Split(':')[0] + "'");
                    //if (row.Length > 0)
                    //{
                    //    string web_limit = Convert.ToString(row[0]["web_limit"]);
                    //    if (Convert.ToInt32(web_server_user_load) > Convert.ToInt32(web_limit))
                    //    {
                    //        string popupScript = "alert('या वेब सर्वर वापरकर्ते यांची संख्या (" + web_server_user_load + ") कमाल मर्यादेपेक्षा (" + web_limit + ") जास्त होत आहे याची कृपया नोंद घ्यावी.')";
                    //        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
                    //        objForms.InsertUserCount(Convert.ToString(ViewState["DistCode"]), Convert.ToString(ViewState["TalukaCode"]), txtLoginName.Text, Request.Url.Authority.Split(':')[0], web_server_user_load, "0", "0");
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    string popupScript = "alert('" + ex.Message + "')";
                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
                }


            }

            if (this.CodeNumberTextBox.Text != Convert.ToString(this.Session["CaptchaImageText"]))
            {
                this.CodeNumberTextBox.Text = "";
                this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
            }
            lblerror.Text = "";
            this.Form.DefaultButton = cmdLogin.UniqueID;

            lblerror.Text = "";

        }
        catch (Exception ex)
        {
            string popupScript = "alert('" + ex.Message + "')";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
        }


    }

    #endregion

    #region "---Button Click Event---"

    protected void cmdLogin_Click(object sender, EventArgs e)
    
     {
        try
        {

            if (Convert.ToInt32(Session["viewstatecnt"]) >= 2)
            {
                this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
                lblerror.Text = "Login failed";
                lblattemptno.Text = "";
                cmdLogin.Enabled = false;
                txtLoginName.Text = "";
                txtPassword.Text = "";
                CodeNumberTextBox.Text = "";
                //CodeNumberTextBox.Text = (string)Session["CaptchaImageText"];
                return;
            }

            if (CodeNumberTextBox.Text == Session["CaptchaImageText"].ToString())
            {
                if (txtLoginName.Text.Contains("'") != true && txtLoginName.Text.Contains("=") != true && txtLoginName.Text.Contains("or") != true && txtLoginName.Text.Contains("OR") != true && txtLoginName.Text.Contains("CREATE") != true && txtLoginName.Text.Contains("create") != true && txtLoginName.Text.Contains("DROP") != true && txtLoginName.Text.Contains("drop") != true && txtLoginName.Text.Contains("%") != true)
                {
                    lblerror.Visible = false;

                    if (Cache["users"] == null)
                    {
                        DataSet dsfpusers1 = objclscommonfun.funReturnds("rcis_uni.fpusers1", "servarthid, password, desg, district_code, taluka_code, user_type, marathiname", "user_status='L'", "");
                        Cache.Add("users", dsfpusers1.Tables[0], null, DateTime.Now.AddHours(12), TimeSpan.Zero, CacheItemPriority.High, null);

                    }
                    DataSet dsfpusers1_1 = new DataSet();

                    if (Cache["users"] != null)
                    {
                        dsfpusers1_1.Tables.Add(new DataTable());
                        dsfpusers1_1.Tables[0].Columns.Add("servarthid");
                        dsfpusers1_1.Tables[0].Columns.Add("password");
                        dsfpusers1_1.Tables[0].Columns.Add("desg");
                        dsfpusers1_1.Tables[0].Columns.Add("district_code");
                        dsfpusers1_1.Tables[0].Columns.Add("taluka_code");
                        dsfpusers1_1.Tables[0].Columns.Add("user_type");
                        dsfpusers1_1.Tables[0].Columns.Add("marathiname");
                        foreach (DataRow dr in ((DataTable)Cache["users"]).Select("servarthid='" + txtLoginName.Text.Trim() + "'"))
                        {
                            DataRow drow = dsfpusers1_1.Tables[0].NewRow();
                            drow["servarthid"] = dr["servarthid"];
                            drow["password"] = dr["password"];
                            drow["desg"] = dr["desg"];
                            drow["district_code"] = dr["district_code"];
                            drow["taluka_code"] = dr["taluka_code"];
                            drow["user_type"] = dr["user_type"];
                            drow["marathiname"] = dr["marathiname"];
                            dsfpusers1_1.Tables[0].Rows.Add(drow);
                        }

                    }
                    else
                    {
                        Session["SaltStr"] = objSFix.RandomString(15).ToString();
                        this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
                        //txtLoginName.Text = txtLoginName.Text;
                        lblerror.Text = "कृपया सेवार्थ आय.डी. किंवा पासवर्ड तपासून पहा.";
                        lblerror.Visible = true;
                        return;
                    }
                    if (dsfpusers1_1 != null && dsfpusers1_1.Tables.Count > 0 && dsfpusers1_1.Tables[0].Rows.Count > 0)
                    {
                        string salt = Session["SaltStr"].ToString();
                        MD5pass = objSFix.md5en(Session["SaltStr"].ToString() + objSFix.sha1(dsfpusers1_1.Tables[0].Rows[0]["password"].ToString()));
                        if (hfhp.Value == MD5pass)
                        {
                            Session["UserName"] = txtLoginName.Text.Trim();

                            if (Cache["district_details" + Convert.ToString(dsfpusers1_1.Tables[0].Rows[0]["district_code"]).Trim()] == null)
                            {
                                string district_details = objclscommonfun.funReturnSingleValueLink("", "rcis_uni.m_district_census", "district_code||'#'||district_name||'#'||db_name||'#'||ip||'#'||webip", "district_code='" + Convert.ToString(dsfpusers1_1.Tables[0].Rows[0]["district_code"]).Trim() + "'", "");

                                Cache.Add("district_details" + Convert.ToString(dsfpusers1_1.Tables[0].Rows[0]["district_code"]).Trim(), district_details, null, DateTime.Now.AddHours(12), TimeSpan.Zero, CacheItemPriority.High, null);

                            }

                            string dbDetails = Convert.ToString(Cache["district_details" + Convert.ToString(dsfpusers1_1.Tables[0].Rows[0]["district_code"]).Trim()]);

                            //if (!Convert.ToString(dbDetails.Split('#')[2]).EndsWith("_tr"))
                            //{
                            if (dsfpusers1_1.Tables[0].Rows[0]["desg"].ToString().Trim() != "DBA")
                            {

                                if (dbDetails != "")
                                {

                                    if (Cache["tockens" + Convert.ToString(dbDetails.Split('#')[0])] == null)
                                    {

                                        DataSet data = new DataSet();
                                        DataBaseHandler dbHandler1 = new DataBaseHandler("Linkage Connection String1");
                                        string CommandText4 = "select sevarth_id, token_publickey from rcis_uni.dsc_tokenmaster as a join rcis_uni.fpusers1 as b on a.sevarth_id=b.servarthid where b.district_code='" + Convert.ToString(dbDetails.Split('#')[0]) + "'";
                                        // string CommandText4 = "select sevarth_id, token_publickey from rcis_uni.dsc_tokenmaster  where  sevarth_id = '" + txtLoginName.Text + "'";

                                        System.Data.Common.DbCommand dataC = dbHandler1.SetCommandText(CommandText4, CommandType.Text);
                                        data = dbHandler1.FillDataset(dataC);

                                        Cache.Add("tockens" + Convert.ToString(dbDetails.Split('#')[0]), data, null, DateTime.Now.AddHours(12), TimeSpan.Zero, CacheItemPriority.High, null);

                                    }
                                    if (Cache["tockens" + Convert.ToString(dbDetails.Split('#')[0])] == null || ((DataSet)(Cache["tockens" + Convert.ToString(dbDetails.Split('#')[0])])).Tables[0].Select("sevarth_id = '" + txtLoginName.Text + "'").Length == 0)
                                    {

                                        if (!Convert.ToString(dbDetails.Split('#')[2]).EndsWith("_tr"))
                                        {
                                            lblerror.Text = "कृपया, डाटा एन्ट्री मॉड्युलचा वापर करण्यापूर्वी आपल्या डीजीटल सिग्नेचरची नोंदणी करा.";
                                            lblerror.Visible = true;
                                            txtLoginName.Text = "";
                                            txtPassword.Text = "";
                                            CodeNumberTextBox.Text = "";
                                            return;
                                        }
                                        else
                                        {
                                            Session["DigSigReg"] = "";
                                            ViewState["DigSigReg"] = "";
                                        }
                                    }
                                    else
                                    {
                                        //ClientScript.RegisterStartupScript(typeof(Page), "Test", "<script type='text/javascript'>RegisterTK()");
                                        Session["DigSigReg"] = "Yes";
                                        ViewState["DigSigReg"] = "Yes";
                                    }
                                }
                            }
                            //}


                            if (dsfpusers1_1.Tables[0].Rows[0]["desg"].ToString().Trim() == "T")
                                ViewState["UserType"] = "T";

                            else if (dsfpusers1_1.Tables[0].Rows[0]["desg"].ToString().Trim() == "DBA")
                                ViewState["UserType"] = "DBA";
                            else if (dsfpusers1_1.Tables[0].Rows[0]["desg"].ToString().Trim() == "MCI")
                                ViewState["UserType"] = "MCI";
                            else
                                ViewState["UserType"] = "C";

                            if (dbDetails != "" && dbDetails.Split('#').Length == 5)
                            {
                                ViewState["DatabaseName"] = Convert.ToString(dbDetails.Split('#')[0]);
                                ViewState["DistrictName"] = Convert.ToString(dbDetails.Split('#')[1]);
                                ViewState["DistCode"] = Convert.ToString(dbDetails.Split('#')[0]);
                                ViewState["ip"] = Convert.ToString(dbDetails.Split('#')[3]);
                                ViewState["webip"] = Convert.ToString(dbDetails.Split('#')[4]);

                               

                                  //string oddeven = System.Configuration.ConfigurationManager.AppSettings["oddeven"];

                                  //if (Convert.ToBoolean(oddeven))
                                  //{
                                  //    if (Convert.ToString(ViewState["DistCode"]) != "9")
                                  //    {
                                  //        int date = System.DateTime.Now.Day;
                                  //        if (date % 2 == 0)
                                  //        {
                                  //            if (Convert.ToChar(ViewState["odd_even"]) == 'O')
                                  //            {
                                  //                string popupScript = "alert('जमाबंदी आयुक्त  कार्यालयाने डाटा एन्ट्री मॉड्युल वापराचे वेळापत्रक तयार केल्यानुसार आपल्या जिल्ह्यासाठी डाटा एन्ट्री मॉड्युलचा वापर आज आपणास करता येणार नाही. ')";
                                  //                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
                                  //                return;
                                  //            }
                                  //        }
                                  //        else
                                  //        {
                                  //            if (Convert.ToChar(ViewState["odd_even"]) == 'E')
                                  //            {
                                  //                string popupScript = "alert('जमाबंदी आयुक्त  कार्यालयाने डाटा एन्ट्री मॉड्युल वापराचे वेळापत्रक तयार केल्यानुसार आपल्या जिल्ह्यासाठी डाटा एन्ट्री मॉड्युलचा वापर आज आपणास करता येणार नाही. ')";
                                  //                ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
                                  //                return;
                                  //            }

                                  //        }
                                  //    }
                                  //}


                               // string schDetails = objclscommonfun.funReturnSingleValue("host=" + Convert.ToString(ViewState["ip"]) + ";#" + (string)ViewState["DatabaseName"], "rcis_uni.m_taluka_census", "taluka_code||'#'||taluka_name||'#'||sch_name", "taluka_code='" + Convert.ToString(dsfpusers1_1.Tables[0].Rows[0]["taluka_code"]).Trim() + "'", "");
                                ////21/05/2025
                               //// string schDetails = objclscommonfun.funReturnSingleValue(""+ (string)ViewState["DatabaseName"]+"", "rcis_uni.m_taluka_census", "taluka_code||'#'||taluka_name||'#'||sch_name", "taluka_code='" + Convert.ToString(dsfpusers1_1.Tables[0].Rows[0]["taluka_code"]).Trim() + "'", "");
                                string schDetails = objclscommonfun.funReturnSingleValue("" + (string)ViewState["DatabaseName"] + "", "rcis_uni.m_taluka_census", "taluka_code||'#'||taluka_name||'#'||sch_name", "taluka_code='" + Convert.ToString(dsfpusers1_1.Tables[0].Rows[0]["taluka_code"]).Trim() + "'", "");
                                if (schDetails != "" && schDetails.Split('#').Length == 3)
                                {
                                    ViewState["SchemaName"] = Convert.ToString(schDetails.Split('#')[2]);
                                    ViewState["TalukaCode"] = Convert.ToString(schDetails.Split('#')[0]);
                                    ViewState["TalukaName"] = Convert.ToString(schDetails.Split('#')[1]);
                                    //  Jivati Login


                                    ////if (Convert.ToString(ViewState["DistCode"]) == "27" && Convert.ToString(ViewState["TalukaCode"]) == "1")
                                    ////{

                                    ////}
                                    ////else
                                    ////{
                                    ////    if (Convert.ToString(ViewState["DistCode"]) == "27" && Convert.ToString(ViewState["TalukaCode"]) == "5")
                                    ////    {

                                    ////    }
                                    ////    else
                                    ////    {
                                    ////        if (Convert.ToString(ViewState["DistCode"]) == "8" && Convert.ToString(ViewState["TalukaCode"]) == "7")
                                    ////        {

                                    ////        }
                                    ////        else
                                    ////        {
                                    ////            if (Convert.ToString(ViewState["DistCode"]) == "26" && Convert.ToString(ViewState["TalukaCode"]) == "9")
                                    ////            {

                                    ////            }
                                    ////            else
                                    ////            {
                                    ////                if (Convert.ToString(ViewState["DistCode"]) == "7" && Convert.ToString(ViewState["TalukaCode"]) == "6")
                                    ////                {

                                    ////                }
                                    ////                else
                                    ////                {

                                    ////                    if (Convert.ToString(ViewState["DistCode"]) == "35" && Convert.ToString(ViewState["TalukaCode"]) == "1")
                                    ////                    {

                                    ////                    }
                                    ////                    else
                                    ////                    {

                                                            ////if (Convert.ToString(ViewState["DistCode"]) == "25" && Convert.ToString(ViewState["TalukaCode"]) == "7")
                                                            ////{

                                                            ////}
                                                            ////else
                                                            ////{

                                                                if (Convert.ToString(ViewState["DistCode"]) == "13" && Convert.ToString(ViewState["TalukaCode"]) == "15")
                                                                {

                                                                }
                                                                else
                                                                {
                                                                    ////21/05/2025
                                                                   //// string popupScript = "alert('डाटा एन्ट्री मॉड्युल हे फक्त 1. बीड जिल्ह्यातील आष्टी तालुक्यातील मोरेवाडी,वंजारवाडी या गावांना 2. बीड जिल्ह्यातील माजलगाव तालुक्यातील ब्रम्हगांव,चिंचगव्हाण या गावांना  3. वर्धा जिल्ह्यातील हिंगणघाट तालुक्यातील अल्लीपूर या गावासाठी 4.अहमदनगर जिल्ह्यातील अहमदनगर तालुक्यातील घाणेगाव या गावासाठी  5.अमरावती जिल्ह्यातील मोर्शी तालुक्यातील ठुणी या गावासाठी  6. सांगली जिल्ह्यातील शिराळा तालुक्यातील गवे,चांदोली खुर्द,सिद्धेश्वर,निवळे,झोळंबी,वेत्ती,टाकळे,जावळी,खुंदलापूर,नांदोली,कोन्होली,रुंदीव,लोटीव,पेठलोंड,आळोली,भोगीव,आंबोळे,देव्हारे या गावांना  7. चंद्रपूर जिल्ह्यातील जिवती तालुक्यातील कमलापूर, टिटवी, जनकापुर, सिंगारपठार, पांढरवाणी या गावांना देण्यात आले आहे.')";


                                                                    //////string popupScript = "alert('सदर डाटा एन्ट्री मॉड्युल हे फक्त चंद्रपूर जिल्ह्यातील जिवती तालुक्यातील कमलापूर, टिटवी, जनकापुर, सिंगारपठार, पांढरवाणी या गावांना देण्यात आले आहे.')";
                                                                    string popupScript = "alert('सदर डाटा एन्ट्री मॉड्युल हे फक्त चंद्रपूर जिल्ह्यातील जिवती तालुक्यातील गावांना देण्यात आले आहे.')";
                                                                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
                                                                    return;
                                                                }
                                                            ////}
                                  //                     // }
                                  //                 // }
                                  //              //}
                                  //         // }
                                  //     // }
                                  ////  }
                                }
                                else
                                {
                                    lblerror.Text = "Data missing in InnerMaster table";
                                    txtLoginName.Text = "";
                                    txtPassword.Text = "";
                                    CodeNumberTextBox.Text = "";
                                    return;
                                }
                            }
                            else
                            {
                                lblerror.Text = "Data missing in Master table";
                                txtLoginName.Text = "";
                                txtPassword.Text = "";
                                CodeNumberTextBox.Text = "";
                                return;
                            }
                            //******************** Code to generate new session-id****************
                            SessionIDManager Manager = new SessionIDManager();
                            string NewID = Manager.CreateSessionID(Context);
                            string OldID = Context.Session.SessionID;
                            bool redirected = false;
                            bool IsAdded = false;
                            string Type = (string)ViewState["UserType"];
                            Session.Abandon();
                            //string datetime = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                            Manager.SaveSessionID(Context, NewID, out redirected, out IsAdded);


                            objForms.LoginInsert("host=" + Convert.ToString(ViewState["ip"]) + ";#" + Convert.ToString(ViewState["DatabaseName"]), Convert.ToString(ViewState["SchemaName"]), NewID, GetIP4Address(), "", txtLoginName.Text, Convert.ToString(ViewState["DistrictName"]), Convert.ToString(ViewState["TalukaName"]), Convert.ToString(ViewState["DistCode"]), Convert.ToString(ViewState["TalukaCode"]), (string)ViewState["UserType"] + "#" + dsfpusers1_1.Tables[0].Rows[0]["marathiname"].ToString().Trim(), salt);

                            string guid = Guid.NewGuid().ToString();
                            Session["token"] = guid;
                            Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                            //******************** Code end **************************************

                            txtPassword.Text = "";
                            CodeNumberTextBox.Text = "";
                            string str = System.Configuration.ConfigurationManager.AppSettings["ipcheck"];
                            string appname = System.Configuration.ConfigurationManager.AppSettings["appname"];

                            if (Convert.ToString(ViewState["DatabaseName"]) != "" || Convert.ToString(ViewState["SchemaName"]) != "")
                            {
                                //objForms.sp_login_audit1("host="+Convert.ToString(ViewState["ip"])+";#" + Convert.ToString(ViewState["DatabaseName"]), Convert.ToString(ViewState["SchemaName"]), txtLoginName.Text, GetIP4Address(), true, "Login");
                                try
                                {
                                    //string popup = "";
                                    //if (dbDetails != null)
                                    //{
                                    //    string database_server_user_load = objcls.funReturnSingleValue("rcis_uni.login_details", "count( distinct (user_id))", "login_time :: date ='" + System.DateTime.Today.ToString("yyyy-MM-dd") + "' and logout_time is null and distcode  in(select  district_code from rcis_uni.m_district_census where ip = '" + dbDetails.Split('#')[3] + "') ", "");

                                    //    DataTable dt = (DataTable)Cache["DistrictData"];
                                    //    DataRow[] row = dt.Select("webip='" + Request.Url.Authority.Split(':')[0] + "' and district_code='" + Convert.ToString(ViewState["DistCode"]) + "'");
                                    //    if (row.Length > 0)
                                    //    {
                                    //        string db_limit = Convert.ToString(row[0]["db_limit"]);
                                    //        string db_ip = Convert.ToString(row[0]["ip"]);
                                    //        if (Convert.ToInt32(database_server_user_load) > Convert.ToInt32(db_limit))
                                    //        {
                                    //            string popupScript = "alert('या डाटाबेस सर्वर वापरकर्ते यांची संख्या (" + database_server_user_load + ") कमाल मर्यादेपेक्षा (" + db_limit + ") जास्त होत आहे याची कृपया नोंद घ्यावी.')";
                                    //            objForms.InsertUserCount(Convert.ToString(ViewState["DistCode"]), Convert.ToString(ViewState["TalukaCode"]), txtLoginName.Text, Convert.ToString(ViewState["webip"]), "0", db_ip, database_server_user_load);
                                    //        }
                                    //    }

                                    //}
                                    txtLoginName.Text = "";

                                   // ClientScript.RegisterStartupScript(this.GetType(), "७/१२ पाहणे", String.Format("<script>window.open('{0}');</script>", "Re-EditTapasni Suchi.pdf"));

                                    //string url = "Re-EditTapasni Suchi.pdf";
                                    //StringBuilder sb = new StringBuilder();
                                    //sb.Append("<script type = 'text/javascript'>");
                                    //sb.Append("window.open('");
                                    //sb.Append(url);
                                    //sb.Append("');");
                                    //sb.Append("</script>");
                                    //ClientScript.RegisterStartupScript(this.GetType(),
                                    //        "script", sb.ToString());


                                    if (Convert.ToString(HiddenField1.Value) != "")
                                    {
                                        Response.Cookies["PKCookies"].Value = Convert.ToString(HiddenField1.Value);

                                        
                                        if (Convert.ToBoolean(str))
                                        {
                                            Response.Redirect("https://" + Convert.ToString(ViewState["webip"]) + "/" + appname + "/pgRedirectpagenew.aspx?page=" + NewID, false);
                                        }
                                        else
                                        {
                                            Response.Redirect("pgRedirectpagenew.aspx", false);
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToString(ViewState["UserType"]) == "DBA" || Convert.ToString(ViewState["DatabaseName"]).EndsWith("_tr"))
                                        {
                                            Response.Cookies["PKCookies"].Value = "";
                                            //=====================================================================

                                            if (Convert.ToBoolean(str))
                                            {
                                                Response.Redirect("https://" + Convert.ToString(ViewState["webip"]) + "/" + appname + "/pgRedirectpagenew.aspx?page=" + NewID, false);
                                            }
                                            else
                                            {
                                                Response.Redirect("pgRedirectpagenew.aspx", false);
                                            }

                                        }
                                        else
                                        {

                                            // Response.Redirect("pgLogin.aspx", false);
                                            string popupScript = "alert('Please, select correct digital signature')";
                                            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);

                                        }
                                    }

                                }
                                catch (Exception ex)
                                {

                                    string popupScript = "alert('" + ex.Message + "')";
                                    ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
                                }

                            }


                        }
                        else
                        {
                            Session["SaltStr"] = objSFix.RandomString(15).ToString();
                            this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
                            //txtLoginName.Text = txtLoginName.Text;
                            lblerror.Text = "कृपया सेवार्थ आय.डी. किंवा पासवर्ड तपासून पहा.";
                            lblerror.Visible = true;
                            Session["viewstatecnt"] = Convert.ToInt16(Session["viewstatecnt"]) + 1;
                            if (Convert.ToInt16(Session["viewstatecnt"]) == 1)
                                lblattemptno.Text = "Last 2 attempts";
                            else if (Convert.ToInt16(Session["viewstatecnt"]) == 2)
                                lblattemptno.Text = "Last 1 attempt";
                            txtLoginName.Text = txtLoginName.Text;
                            CodeNumberTextBox.Text = "";
                            txtLoginName.Text = "";
                            txtPassword.Text = "";
                            CodeNumberTextBox.Text = "";
                        }
                    }
                    else
                    {
                        Session["SaltStr"] = objSFix.RandomString(15).ToString();
                        this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
                        //txtLoginName.Text = txtLoginName.Text;
                        lblerror.Text = "कृपया सेवार्थ आय.डी. किंवा पासवर्ड तपासून पहा.";
                        lblerror.Visible = true;
                        Session["viewstatecnt"] = Convert.ToInt16(Session["viewstatecnt"]) + 1;
                        if (Convert.ToInt16(Session["viewstatecnt"]) == 1)
                            lblattemptno.Text = "Last 2 attempts";
                        else if (Convert.ToInt16(Session["viewstatecnt"]) == 2)
                            lblattemptno.Text = "Last 1 attempt";
                        txtLoginName.Text = txtLoginName.Text;
                        CodeNumberTextBox.Text = "";
                        txtLoginName.Text = "";
                        txtPassword.Text = "";
                        CodeNumberTextBox.Text = "";
                    }
                }
                else
                {
                    Session["SaltStr"] = objSFix.RandomString(15).ToString();
                    this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
                    //txtLoginName.Text = txtLoginName.Text;
                    lblerror.Text = "कृपया सदर जागेमध्ये  ही विशिष्ट  चिन्हे(',=,or,%...इ. ) भरू नका.";
                    lblerror.Visible = true;
                    Session["viewstatecnt"] = Convert.ToInt16(Session["viewstatecnt"]) + 1;
                    if (Convert.ToInt16(Session["viewstatecnt"]) == 1)
                        lblattemptno.Text = "Last 2 attempts";
                    else if (Convert.ToInt16(Session["viewstatecnt"]) == 2)
                        lblattemptno.Text = "Last 1 attempt";
                    txtLoginName.Text = txtLoginName.Text;
                    txtLoginName.Text = "";
                    txtPassword.Text = "";
                    CodeNumberTextBox.Text = "";
                }
            }
            else
            {
                Session["SaltStr"] = objSFix.RandomString(15).ToString();
                this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
                //txtLoginName.Text = txtLoginName.Text;
                // Clear the input and create a new random code.
                Session["viewstatecnt"] = Convert.ToInt16(Session["viewstatecnt"]) + 1;
                if (Convert.ToInt16(Session["viewstatecnt"]) == 1)
                    lblattemptno.Text = "Last 2 attempts";
                else if (Convert.ToInt16(Session["viewstatecnt"]) == 2)
                    lblattemptno.Text = "Last 1 attempt";
                txtLoginName.Text = txtLoginName.Text;
                this.CodeNumberTextBox.Text = "";
                txtLoginName.Text = "";
                txtPassword.Text = "";
                CodeNumberTextBox.Text = "";
            }

        }
        catch (Exception ex)
        {
            txtLoginName.Text = "";
            txtPassword.Text = "";
            CodeNumberTextBox.Text = "";
            //ExceptionHandling excpt = new ExceptionHandling();
            //if (Session["UserName"] != null)
            //    Session["Error"] = excpt.Setex(ex, page_name, txtLoginName.Text, System.Reflection.MethodBase.GetCurrentMethod().Name + "#" + ex.TargetSite.Name + "#" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')), ((String.IsNullOrEmpty(Convert.ToString(Session["DataBaseName"]))) ? "" : Convert.ToString(Session["DataBaseName"]).Substring(5, Convert.ToString(Session["DataBaseName"]).IndexOf(';')-5)), Request.Url.Authority, Convert.ToString(Session["ccode"]), Convert.ToString(Session["mut_no"]));
            //else
            //    Session["Error"] = excpt.Setex(ex, page_name, txtLoginName.Text, System.Reflection.MethodBase.GetCurrentMethod().Name + "#" + ex.TargetSite.Name + "#" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')), "", Request.Url.Authority, Convert.ToString(Session["ccode"]), Convert.ToString(Session["mut_no"]));
            string popupScript = "alert('" + ex.Message + "')";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtSevarthID.Text.Contains("'") != true && txtSevarthID.Text.Contains("=") != true && txtSevarthID.Text.Contains("or") != true && txtSevarthID.Text.Contains("OR") != true && txtSevarthID.Text.Contains("CREATE") != true && txtSevarthID.Text.Contains("create") != true && txtSevarthID.Text.Contains("DROP") != true && txtSevarthID.Text.Contains("drop") != true && txtSevarthID.Text.Contains("%") != true && txtSevarthID.Text != "")
            {
                DataSet mDataset = default(DataSet);
                //mDataset = conObj.LoginChecking1(ViewState["Loginid"].ToString());
                mDataset = objclscommonfun.funReturnds("rcis_uni.fpusers1", "*", "servarthid='" + txtSevarthID.Text.Trim() + "' ", "");
                if (mDataset != null && mDataset.Tables[0].Rows.Count != 0)
                {
                    string LoginPass = null;
                    string LoginId = null;
                    string MD5pass = null;
                    //bool flag = true;
                    LoginPass = mDataset.Tables[0].Rows[0]["password"].ToString();
                    LoginId = mDataset.Tables[0].Rows[0]["servarthid"].ToString();
                    MD5pass = objSFix.md5en(Session["SaltStr"].ToString() + mDataset.Tables[0].Rows[0]["password"].ToString());//objEncrypt.md5en(LoginPass);

                    string oldpassword = txtExistingPassword.Text;
                    if (oldpassword == LoginPass)
                    {
                        //if (LoginId == ViewState["Loginid"].ToString())
                        //{
                        string newpassword = txtNewPassword1.Text;
                        //string originalpwd = conObj.funReturnSingleValueString("rcis_uni.tblfaqlogin", "password", "userid ='" + ViewState["Loginid"].ToString() + "' and password='" + txtOldPwd.Text + "' and district_code='" + ViewState["district_code"].ToString() + "'", "");
                        if (newpassword != LoginPass)
                        {
                            int flag = objclscommonfunedit.funUpdateValue1SevarthID_LNK("rcis_uni.fpusers1", "password='" + newpassword + "'", "servarthid='" + txtSevarthID.Text + "'", txtSevarthID.Text.Trim());
                            if (flag != 0)
                            {
                                lbl_msg.Visible = true;
                                lbl_msg.Text = "पासवर्ड समाविष्ट झाला आहे";
                                txtSevarthID.Text = "";
                                txtExistingPassword.Text = "";
                                txtNewPassword1.Text = "";
                                txtConfNewPassword.Text = "";
                            }
                            else
                            {
                                lbl_msg.Visible = true;
                                lbl_msg.Text = "वापरकर्ता व पासवर्ड बरोबर नाही";
                                txtExistingPassword.Text = "";
                                txtNewPassword1.Text = "";
                                txtConfNewPassword.Text = "";
                            }
                        }
                        else
                        {
                            lbl_msg.Visible = true;
                            lbl_msg.Text = "पासवर्ड दुसरा निवडा.";
                            txtExistingPassword.Text = "";
                            txtNewPassword1.Text = "";
                            txtConfNewPassword.Text = "";
                        }
                        //}
                        //else
                        //{
                        //    lbl_msg.Visible = true;
                        //    lbl_msg.Text = "वापरकर्ता व पासवर्ड बरोबर नाही";
                        //    txtExistingPassword.Text = "";
                        //    txtNewPassword1.Text = "";
                        //    txtConfNewPassword.Text = "";
                        //}
                    }
                    else
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "जुना पासवर्ड बरोबर नाही";
                        txtExistingPassword.Text = "";
                        txtNewPassword1.Text = "";
                        txtConfNewPassword.Text = "";
                    }
                }
            }
            else
            {
                lbl_msg.Visible = true;
                lbl_msg.Text = "कृपया सेवार्थ आय.डी. भरा";
            }
        }
        catch (Exception ex)
        {
            //if (Session["UserName"] != null)
            //    Session["Error"] = excpt.Setex(ex, page_name, txtSevarthID.Text, System.Reflection.MethodBase.GetCurrentMethod().Name + "#" + ex.TargetSite.Name + "#" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')), "", Request.Url.Authority, Convert.ToString(Session["ccode"]), Convert.ToString(Session["mut_no"]));
            //else
            //    Session["Error"] = excpt.Setex(ex, page_name, txtSevarthID.Text, System.Reflection.MethodBase.GetCurrentMethod().Name + "#" + ex.TargetSite.Name + "#" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')), "", Request.Url.Authority, Convert.ToString(Session["ccode"]), Convert.ToString(Session["mut_no"]));
            string popupScript = "alert('" + ex.Message + "')";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
        }
    }

    protected void btnchangepassword_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup').style.display = 'block';", true);
        pnl_Login.Visible = false;
        pnl_change_pwd.Visible = true;
    }

    #endregion

    #region [--- Dropdown ---]

    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddldistrict.SelectedIndex != -1 && ddldistrict.SelectedItem.Text != "--निवडा--")
            {
                ddltaluka.Items.Clear();
                ViewState["DatabaseName"] = objclscommonfun.funReturnSingleValueLink("", "rcis_uni.m_district_census", "db_name", "district_name='" + ddldistrict.SelectedItem.Text + "'", "");
                objclscommonfun.funSetDropDownList((string)ViewState["DatabaseName"], ref ddltaluka, "rcis_uni.m_taluka_census", "taluka_code,taluka_name", "", "");
                ViewState["DistrictName"] = ddldistrict.SelectedItem.Text.ToString();
                // ViewState["DistCode"] = ddldistrict.SelectedValue.ToString();
            }
            else
            {
                lblerror.Text = "Select District from dropdown";
            }
        }
        catch (Exception ex)
        {
            //if (Session["UserName"] != null)
            //    Session["Error"] = excpt.Setex(ex, page_name, txtLoginName.Text, System.Reflection.MethodBase.GetCurrentMethod().Name + "#" + ex.TargetSite.Name + "#" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')), "", Request.Url.Authority, Convert.ToString(Session["ccode"]), Convert.ToString(Session["mut_no"]));
            //else
            //    Session["Error"] = excpt.Setex(ex, page_name, txtLoginName.Text, System.Reflection.MethodBase.GetCurrentMethod().Name + "#" + ex.TargetSite.Name + "#" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')), "", Request.Url.Authority, Convert.ToString(Session["ccode"]), Convert.ToString(Session["mut_no"]));
            string popupScript = "alert('" + ex.Message + "')";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
        }
    }

    protected void ddltaluka_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddltaluka.SelectedIndex != -1 && ddltaluka.SelectedItem.Text != "--निवडा--")
            {
                ViewState["SchemaName"] = objclscommonfun.funReturnSingleValue((string)ViewState["DatabaseName"], "rcis_uni.m_taluka_census", "sch_name", "taluka_code='" + ddltaluka.SelectedValue.ToString() + "'", "");
                ViewState["DataBaseName"] = (string)ViewState["DatabaseName"];
                ViewState["SchemaName"] = (string)ViewState["SchemaName"];
                ViewState["TalukaCode"] = ddltaluka.SelectedValue.ToString();
                ViewState["TalukaName"] = ddltaluka.SelectedItem.Text.ToString();
            }
            else
            {
                lblerror.Text = "Select District from dropdown";
            }
        }
        catch (Exception ex)
        {
            //if (Session["UserName"] != null)
            //    Session["Error"] = excpt.Setex(ex, page_name, txtLoginName.Text, System.Reflection.MethodBase.GetCurrentMethod().Name + "#" + ex.TargetSite.Name + "#" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')), "", Request.Url.Authority, Convert.ToString(Session["ccode"]), Convert.ToString(Session["mut_no"]));
            //else
            //    Session["Error"] = excpt.Setex(ex, page_name, txtLoginName.Text, System.Reflection.MethodBase.GetCurrentMethod().Name + "#" + ex.TargetSite.Name + "#" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' ')), "", Request.Url.Authority, Convert.ToString(Session["ccode"]), Convert.ToString(Session["mut_no"]));
            string popupScript = "alert('" + ex.Message + "')";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", popupScript, true);
        }
    }

    #endregion

    #region "--------Get IP-------"

    public string GetIP4Address()
    {

        string IP4Address = String.Empty;

        foreach (IPAddress IPA in Dns.GetHostAddresses(Request.ServerVariables["REMOTE_ADDR"].ToString()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        if (IP4Address != String.Empty)
        {
            return IP4Address;
        }

        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily.ToString() == "InterNetwork")
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        return IP4Address;
    }
    #endregion

    protected void lnkLogin_Click1(object sender, EventArgs e)
    {
        pnl_Login.Visible = true;
        pnl_change_pwd.Visible = false;
    }
    protected void TEST_Click(object sender, EventArgs e)
    {
        DataTable dt = objclscommonfun.funReturnDataTable("host=10.187.205.249;#mhrorkol", "mhrorkol_kar.m_village_census", "ccode", "ccode<>''", "village_name");
        if (dt != null && dt.Rows.Count > 0)
        {
            for (int i = 0 ; i< dt.Rows.Count ; i++ )
            {
                DataTable dt_notinf7K = objclscommonfun.funReturnDataTable("host=10.187.205.249;#mhrorkol", "mhrorkol_kar.form7", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode='" + dt.Rows[i]["ccode"].ToString() + "' and (ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in ( select ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from mhrorkol_kar.form7_khata where ccode='" + dt.Rows[i]["ccode"].ToString() + "' ) ", "pin");
                if (dt_notinf7K != null && dt_notinf7K.Rows.Count > 0)
                {
                    for (int j = 0; j < dt_notinf7K.Rows.Count; j++)
                    {
                        objcls.funInserSingleRecord("host=10.187.205.249;#mhrorkol", "mhrorkol_kar.temp_intgritychk", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "'" + dt_notinf7K.Rows[j]["ccode"].ToString() + "','" + Convert.ToString(dt_notinf7K.Rows[j]["pin"]) + "' ,'" + Convert.ToString(dt_notinf7K.Rows[j]["pin1"]) + "' ,'" + Convert.ToString(dt_notinf7K.Rows[j]["pin2"]) + "' ,'" + Convert.ToString(dt_notinf7K.Rows[j]["pin3"]) + "' ,'" + Convert.ToString(dt_notinf7K.Rows[j]["pin4"]) + "' ,'" + Convert.ToString(dt_notinf7K.Rows[j]["pin5"]) + "' ,'" + Convert.ToString(dt_notinf7K.Rows[j]["pin6"]) + "' ,'" + Convert.ToString(dt_notinf7K.Rows[j]["pin7"]) + "' ,'" + Convert.ToString(dt_notinf7K.Rows[j]["pin8"]) + "'");
                    }
                }

            }

        }


    }
}
//Land-Records2013*