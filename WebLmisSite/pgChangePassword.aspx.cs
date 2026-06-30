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
using System.Text.RegularExpressions;
using System.Data.Common;
using System.Web.SessionState;
using System.Net;
using NIC.WebLMISLibrary;

public partial class pgChangePassword : System.Web.UI.Page
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

            if (!objclscommonfun.validateTextBox_IsSpecialChar( ref txtconfirmpass) || !objclscommonfun.validateTextBox_IsSpecialChar( ref txtConfNewPassword) || !objclscommonfun.validateTextBox_IsSpecialChar( ref txtExistingPassword) || !objclscommonfun.validateTextBox_IsSpecialChar( ref txtLoginName) || !objclscommonfun.validateTextBox_IsSpecialChar( ref txtnewpass) || !objclscommonfun.validateTextBox_IsSpecialChar( ref txtNewPassword1) || !objclscommonfun.validateTextBox_IsSpecialChar( ref txtPassword) || !objclscommonfun.validateTextBox_IsSpecialChar( ref txtSevarthID))
            {
                string popupScript = "<script language='javascript'>alert('कृपया, योग्य माहिती भरा.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }


            if (!Page.IsPostBack)
            {
                Session["page_heading"] = "";

                txtLoginName.Focus();
                Session["date1"] = System.DateTime.Now;
                if (Session["DataBaseName"] != null)
                   
                if (Session["SchemaName"] != null)
                    


               // objclscommonfun.funSetDropDownList1("", ref ddldistrict, "rcis_uni.m_district_census", "db_name,district_name", "", "");
                this.Session["CaptchaImageText"] = objSFix.RandomString(5);
               Session["SaltStr"] = objSFix.RandomString(15).ToString();
               // ViewState["viewstatecnt"] = 0;


            }

            pnl_Login.Visible = false;
            pnl_change_pwd.Visible = true;
            if (this.CodeNumberTextBox.Text != this.Session["CaptchaImageText"].ToString())
            {
                this.CodeNumberTextBox.Text = "";
                this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
            }
            lblerror.Text = "";
            this.Form.DefaultButton = cmdLogin.UniqueID; 

            ////CodeNumberTextBox.Text = (string)Session["CaptchaImageText"];

            //else
            //{
            //    // Display an error message.
            //    //this.MessageLabel.CssClass = "error";
            //    //this.MessageLabel.Text = "ERROR: Incorrect, try again.";

            //    // Clear the input and create a new random code.
            //    this.CodeNumberTextBox.Text = "";
            //    this.Session["CaptchaImageText"] = objSFix.RandomString(1);
            //}
            lblerror.Text = "";
        }
        catch (Exception ex)
        {
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                 Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>"; 
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }

    }

    #endregion

    #region "---Button Click Event---"

    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(ViewState["viewstatecnt"]) >= 2)
            {
                this.Session["CaptchaImageText"] = objSFix.RandomString(5);
                lblerror.Text = "Login failed";
                lblattemptno.Text = "";
                cmdLogin.Enabled = false;
                CodeNumberTextBox.Text = (string)Session["CaptchaImageText"];
                return;
            }

            if (CodeNumberTextBox.Text == Session["CaptchaImageText"].ToString())
            {

                if (txtLoginName.Text.Contains("'") != true && txtLoginName.Text.Contains("=") != true && txtLoginName.Text.Contains("or") != true && txtLoginName.Text.Contains("OR") != true && txtLoginName.Text.Contains("CREATE") != true && txtLoginName.Text.Contains("create") != true && txtLoginName.Text.Contains("DROP") != true && txtLoginName.Text.Contains("drop") != true && txtLoginName.Text.Contains("%") != true)
                {
                    lblerror.Visible = false;
                    DataSet dsfpusers1 = objclscommonfun.funReturnds("rcis_uni.fpusers1", "*", "servarthid='" + txtLoginName.Text.Trim() + "' ", "");
                    if (dsfpusers1 != null && dsfpusers1.Tables.Count > 0 && dsfpusers1.Tables[0].Rows.Count > 0)
                    {
                        MD5pass = objSFix.md5en(Session["SaltStr"].ToString() + dsfpusers1.Tables[0].Rows[0]["password"].ToString());
                        if (hfhp.Value == MD5pass)
                        {
                            Session["UserName"] = txtLoginName.Text.Trim();

                            string dbDetails = objclscommonfun.funReturnSingleValueLink("", "rcis_uni.m_district_census", "district_code||'#'||district_name||'#'||db_name||'#'||ip", "district_code='" + Convert.ToString(dsfpusers1.Tables[0].Rows[0]["district_code"]).Trim() + "'", "");
                            //if (!Convert.ToString(dbDetails.Split('#')[2]).EndsWith("_tr"))
                            //{
                                if (dsfpusers1.Tables[0].Rows[0]["desg"].ToString().Trim() != "DBA")
                                {
                                    DataSet data = new DataSet();
                                    DataBaseHandler dbHandler1 = new DataBaseHandler("Linkage Connection String1");
                                    string CommandText4 = "select token_publickey from rcis_uni.dsc_tokenmaster" +
                                                            " where  sevarth_id = '" + Convert.ToString(Session["UserName"]) + "'";
                                    System.Data.Common.DbCommand dataC = dbHandler1.SetCommandText(CommandText4, CommandType.Text);
                                    data = dbHandler1.FillDataset(dataC);
                                    if (data == null || data.Tables[0].Rows.Count == 0)
                                    {
                                        if (!Convert.ToString(dbDetails.Split('#')[2]).EndsWith("_tr"))
                                        {
                                            lblerror.Text = "कृपया, ई-फेरफार प्रणालीचा वापर करण्या पूर्वी आपल्या डीजीटल सिग्नेचरची नोंदणी करा.";
                                            lblerror.Visible = true;
                                            txtLoginName.Text = "";
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
                                        //ClientScript.RegisterStartupScript(typeof(Page), "Test", "<script type='text/javascript'>RegisterTK();</script>");
                                        Session["DigSigReg"] = "Yes";
                                        ViewState["DigSigReg"]="Yes";
                                    }
                                }
                            //}


                            if (dsfpusers1.Tables[0].Rows[0]["desg"].ToString().Trim() == "T")
                                ViewState["UserType"] = "T";

                            else if (dsfpusers1.Tables[0].Rows[0]["desg"].ToString().Trim() == "DBA")
                                ViewState["UserType"] = "DBA";
                            else if (dsfpusers1.Tables[0].Rows[0]["desg"].ToString().Trim() == "MCI")
                                ViewState["UserType"] = "MCI";
                            else
                                ViewState["UserType"] = "C";
                           
                            if (dbDetails != "" && dbDetails.Split('#').Length == 4)
                            {
                                ViewState["DatabaseName"] = Convert.ToString(dbDetails.Split('#')[2]);
                                ViewState["DistrictName"] = Convert.ToString(dbDetails.Split('#')[1]);
                                ViewState["DistCode"] = Convert.ToString(dbDetails.Split('#')[0]);
                                ViewState["ip"] = Convert.ToString(dbDetails.Split('#')[3]);






                                string schDetails = objclscommonfun.funReturnSingleValue("host=" + Convert.ToString(ViewState["ip"]) + ";#" + (string)ViewState["DatabaseName"], "rcis_uni.m_taluka_census", "taluka_code||'#'||taluka_name||'#'||sch_name", "taluka_code='" + Convert.ToString(dsfpusers1.Tables[0].Rows[0]["taluka_code"]).Trim() + "'", "");
                                if (schDetails != "" && schDetails.Split('#').Length == 3)
                                {
                                    ViewState["SchemaName"] = Convert.ToString(schDetails.Split('#')[2]);
                                    ViewState["TalukaCode"] = Convert.ToString(schDetails.Split('#')[0]);
                                    ViewState["TalukaName"] = Convert.ToString(schDetails.Split('#')[1]);
                                }
                                else
                                {
                                    lblerror.Text = "Data missing in InnerMaster table";
                                    return;
                                }
                            }
                            else
                            {
                                lblerror.Text = "Data missing in Master table";
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
                            string datetime = System.DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
                            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                            Manager.SaveSessionID(Context, NewID, out redirected, out IsAdded);
                            

                           
                            #region [---Insert record in the login_audit table of regular schema Dt.:29-09-2014---]
                            objclscommonfun.funInsertValue("host=" + Convert.ToString(ViewState["ip"]) + ";#" + Convert.ToString(ViewState["DatabaseName"]), Convert.ToString(ViewState["SchemaName"]) + ".login_audit", "user_id, ip_address, date_time, login_status, pass_activity, login_id, app_name", "'" + txtLoginName.Text + "','" + GetIP4Address() + "','" + datetime + "','Y','Login','" + txtLoginName.Text + "','reEdit'");
                            #endregion

                            string guid = Guid.NewGuid().ToString();
                            Session["token"] = guid;
                            Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                            //******************** Code end **************************************
                            if (Convert.ToString(ViewState["DatabaseName"]) != "" || Convert.ToString(ViewState["SchemaName"]) != "")
                                //objForms.sp_login_audit1("host="+Convert.ToString(ViewState["ip"])+";#" + Convert.ToString(ViewState["DatabaseName"]), Convert.ToString(ViewState["SchemaName"]), txtLoginName.Text, GetIP4Address(), true, "Login");
                                if (Convert.ToString(ViewState["DigSigReg"]) == "Yes")
                                {
                                    //string popupwindow = "<script language='javascript'>window.open('pgTokenCheck.aspx', 'height=350,width=700,top=250,left=530,status=yes,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no'); </Script>";
                                    //ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupwindow);
                                    //Response.Redirect("pgTokenCheck.aspx", false);
                                    Response.Redirect("pgRedirectpagenew.aspx", false);
                                }
                                else
                                    Response.Redirect("pgRedirectpagenew.aspx", false);
                                
                        }
                        else
                        {
                            Session["SaltStr"] = objSFix.RandomString(5).ToString();
                            this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
                            //txtLoginName.Text = Convert.ToString(Session["UserName"]);
                            lblerror.Text = "कृपया वापरकर्त्याचे नाव व पासवर्ड तपासून पहा.";
                            lblerror.Visible = true;
                            ViewState["viewstatecnt"] = Convert.ToInt16(ViewState["viewstatecnt"]) + 1;
                            if (Convert.ToInt16(ViewState["viewstatecnt"]) == 1)
                                lblattemptno.Text = "Last 2 attempts";
                            else if (Convert.ToInt16(ViewState["viewstatecnt"]) == 2)
                                lblattemptno.Text = "Last 1 attempt";
                            txtLoginName.Text = Convert.ToString(Session["UserName"]);
                            if (Convert.ToString(ViewState["DatabaseName"]) != "" || Convert.ToString(ViewState["SchemaName"]) != "")
                                objForms.sp_login_audit1("host="+Convert.ToString(ViewState["ip"])+";#" + Convert.ToString(ViewState["DatabaseName"]), Convert.ToString(ViewState["SchemaName"]), txtLoginName.Text, GetIP4Address(), false, "Login");
                            CodeNumberTextBox.Text = "";
                            txtLoginName.Text = "";
                            txtPassword.Text = "";
                        }
                    }
                    else
                    {
                        Session["SaltStr"] = objSFix.RandomString(5).ToString();
                        this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
                        //txtLoginName.Text = Convert.ToString(Session["UserName"]);
                        lblerror.Text = "कृपया वापरकर्त्याचे नाव व पासवर्ड तपासून पहा.";
                        lblerror.Visible = true;
                        ViewState["viewstatecnt"] = Convert.ToInt16(ViewState["viewstatecnt"]) + 1;
                        if (Convert.ToInt16(ViewState["viewstatecnt"]) == 1)
                            lblattemptno.Text = "Last 2 attempts";
                        else if (Convert.ToInt16(ViewState["viewstatecnt"]) == 2)
                            lblattemptno.Text = "Last 1 attempt";
                        txtLoginName.Text = Convert.ToString(Session["UserName"]);
                        if (Convert.ToString(ViewState["DatabaseName"]) != "" || Convert.ToString(ViewState["SchemaName"]) != "")
                            objForms.sp_login_audit1("host="+Convert.ToString(ViewState["ip"])+";#" + Convert.ToString(ViewState["DatabaseName"]), Convert.ToString(ViewState["SchemaName"]), txtLoginName.Text, GetIP4Address(), false, "Login");
                        CodeNumberTextBox.Text = "";
                        txtLoginName.Text = "";
                        txtPassword.Text = "";
                    }
                }
                else
                {
                    Session["SaltStr"] = objSFix.RandomString(5).ToString();
                    this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
                    //txtLoginName.Text = Convert.ToString(Session["UserName"]);
                    lblerror.Text = "कृपया सदर जागेमध्ये  ही विशिष्ट  चिन्हे(',=,or,%...इ. ) भरू नका.";
                    lblerror.Visible = true;
                    ViewState["viewstatecnt"] = Convert.ToInt16(ViewState["viewstatecnt"]) + 1;
                    if (Convert.ToInt16(ViewState["viewstatecnt"]) == 1)
                        lblattemptno.Text = "Last 2 attempts";
                    else if (Convert.ToInt16(ViewState["viewstatecnt"]) == 2)
                        lblattemptno.Text = "Last 1 attempt";
                    txtLoginName.Text = Convert.ToString(Session["UserName"]);
                    if (Convert.ToString(ViewState["DatabaseName"]) != "" || Convert.ToString(ViewState["SchemaName"]) != "")
                        objForms.sp_login_audit1("host="+Convert.ToString(ViewState["ip"])+";#" + Convert.ToString(ViewState["DatabaseName"]), Convert.ToString(ViewState["SchemaName"]), txtLoginName.Text, GetIP4Address(), false, "Login");
                    txtLoginName.Text = "";
                    txtPassword.Text = "";
                    CodeNumberTextBox.Text = "";
                }
            }
            else
            {
                Session["SaltStr"] = objSFix.RandomString(5).ToString();
                this.Session["CaptchaImageText"] = objSFix.RandomString4Chars(3);
                //txtLoginName.Text = Convert.ToString(Session["UserName"]);
                // Clear the input and create a new random code.
                ViewState["viewstatecnt"] = Convert.ToInt16(ViewState["viewstatecnt"]) + 1;
                if (Convert.ToInt16(ViewState["viewstatecnt"]) == 1)
                    lblattemptno.Text = "Last 2 attempts";
                else if (Convert.ToInt16(ViewState["viewstatecnt"]) == 2)
                    lblattemptno.Text = "Last 1 attempt";
                txtLoginName.Text = Convert.ToString(Session["UserName"]);
                if (Convert.ToString(ViewState["DatabaseName"]) != "" || Convert.ToString(ViewState["SchemaName"]) != "")
                    objForms.sp_login_audit1("host="+Convert.ToString(ViewState["ip"])+";#" + Convert.ToString(ViewState["DatabaseName"]), Convert.ToString(ViewState["SchemaName"]), txtLoginName.Text, GetIP4Address(), false, "Login");
                this.CodeNumberTextBox.Text = "";
                txtLoginName.Text = "";
                txtPassword.Text = "";
            }

        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                 Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>"; 
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (op.Value != "0")
            {
                if (Convert.ToString(Session["UserName"]).Contains("'") != true && Convert.ToString(Session["UserName"]).Contains("=") != true && Convert.ToString(Session["UserName"]).Contains("or") != true && Convert.ToString(Session["UserName"]).Contains("OR") != true && Convert.ToString(Session["UserName"]).Contains("CREATE") != true && Convert.ToString(Session["UserName"]).Contains("create") != true && Convert.ToString(Session["UserName"]).Contains("DROP") != true && Convert.ToString(Session["UserName"]).Contains("drop") != true && Convert.ToString(Session["UserName"]).Contains("%") != true && Convert.ToString(Session["UserName"]) != "")
                {
                    DataSet mDataset = default(DataSet);
                    //mDataset = conObj.LoginChecking1(ViewState["Loginid"].ToString());

                    mDataset = objclscommonfun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".password_history ", " password ", "user_id='" + Convert.ToString(Session["UserName"]).Trim() + "'", " sr_no desc");

                    if (mDataset != null)
                    {
                        int cnt = mDataset.Tables[0].Rows.Count;
                        if (cnt != 0)
                        {
                            if (cnt > 3)
                            {
                                cnt = 3;
                            }
                            for (int i = 0; i < cnt; i++)
                            {
                                if (txtConfNewPassword.Text == Convert.ToString(mDataset.Tables[0].Rows[i]["password"]))
                                {
                                    lbl_msg.Visible = true;
                                    lbl_msg.Text = "भरलेला पासवर्ड  यापूर्वी वापरला गेला आहे. कृपया, नवीन पासवर्ड  भरा.";
                                    txtExistingPassword.Text = "";
                                    txtNewPassword1.Text = "";
                                    txtConfNewPassword.Text = "";
                                    return;
                                }

                            }
                        }
                    }

                    mDataset = objclscommonfun.funReturnds("rcis_uni.fpusers1", "*", "servarthid='" + Convert.ToString(Session["UserName"]).Trim() + "' ", "");


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
                                int flag = objclscommonfunedit.funUpdateValue1SevarthID_LNK("rcis_uni.fpusers1", "password='" + newpassword + "'", "servarthid='" + Convert.ToString(Session["UserName"]) + "'", Convert.ToString(Session["UserName"]).Trim());
                                if (flag != 0)
                                {
                                    lbl_msg.Visible = true;
                                    lbl_msg.Text = "पासवर्ड समाविष्ट झाला आहे";



                                    string popupScript = "<script language='javascript'>alert('पासवर्ड समाविष्ट झाला आहे');</script>";
                                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

                                    objclscommonfun.funInsertValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".password_history", "user_id, password, date_time", "'" + Convert.ToString(Session["UserName"]).Trim() + "','" + newpassword + "',now()");


                                    Session.Abandon();
                                    // ********************** Code to expire session id ****************************
                                    if (Request.Cookies["ASP.NET_SessionId"] != null)
                                    {
                                        Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                                        Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-20);
                                    }
                                    if (Request.Cookies["AuthToken"] != null)
                                    {
                                        Response.Cookies["AuthToken"].Value = string.Empty;
                                        Response.Cookies["AuthToken"].Expires = DateTime.Now.AddMonths(-20);
                                    }
                                    //********************** end **************************************************
                                    Session["AuthenticatePageRef"] = -1;
                                    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

                                    Response.Redirect("pgLogin.aspx", false);

                                    //Convert.ToString(Session["UserName"]) = "";
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
            else
            {
                lbl_msg.Visible = true;
                lbl_msg.Text = "कृपया माहिती बरोबर भरा.";
            }
        }
        catch (Exception ex)
        {
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                 Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>"; 
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
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
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                 Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>"; 
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
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
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                 Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>"; 
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
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
    protected void btnCancel_Click(object sender, EventArgs e)
    {
      ImageButton ImageButton1 = (ImageButton)Master.FindControl("ImageButton1");
            ImageButton1.Enabled = true;
            ImageButton ImageButton2 = (ImageButton)Master.FindControl("ImageButton2");
            ImageButton2.Enabled = true;
            LinkButton LinkButton2 = (LinkButton)Master.FindControl("LinkButton2");
            LinkButton2.Enabled = true;
            LinkButton LinkButton1 = (LinkButton)Master.FindControl("LinkButton1");
            LinkButton1.Enabled = true;
            LinkButton imgbtnPherPhar = (LinkButton)Master.FindControl("imgbtnPherPhar");
            imgbtnPherPhar.Enabled = true;
            LinkButton LinkButton3 = (LinkButton)Master.FindControl("LinkButton3");
            LinkButton3.Enabled = true;
            LinkButton LinkButton5 = (LinkButton)Master.FindControl("LinkButton5");
            LinkButton5.Enabled = true;
            LinkButton LinkButton8 = (LinkButton)Master.FindControl("LinkButton8");
            LinkButton8.Enabled = true;
            LinkButton LinkButton6 = (LinkButton)Master.FindControl("LinkButton6");
            LinkButton6.Enabled = true;
            LinkButton LinkButton4 = (LinkButton)Master.FindControl("LinkButton4");
            LinkButton4.Enabled = true;
            LinkButton lbkbtnfailservey_to_talathi = (LinkButton)Master.FindControl("lbkbtnfailservey_to_talathi");
            lbkbtnfailservey_to_talathi.Enabled = true;
            LinkButton LinkButton9 = (LinkButton)Master.FindControl("LinkButton9");
            LinkButton9.Enabled = true;
            LinkButton LinkButton7 = (LinkButton)Master.FindControl("LinkButton7");
            LinkButton7.Enabled = true;
            LinkButton btnNotice = (LinkButton)Master.FindControl("btnNotice");
            btnNotice.Enabled = true;
            LinkButton lnkFAQ = (LinkButton)Master.FindControl("lnkFAQ");
            lnkFAQ.Enabled = true;
            LinkButton LinkButton10 = (LinkButton)Master.FindControl("LinkButton10");
            LinkButton10.Enabled = true;
            LinkButton btnlogout = (LinkButton)Master.FindControl("btnlogout");
            btnlogout.Enabled = true;
       
                
                
        Response.Redirect("pgVillageSelection.aspx", false);

    }
}
//Land-Records2013*