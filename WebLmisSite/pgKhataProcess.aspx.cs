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

public partial class pgKhataProcess : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction obj = new clsCommonFunction();
    DataTable NewPurTable = new DataTable("tblVars");
    DataTable Dthaksod = new DataTable("tblhaksod");
    clsValidInput objvalidip = new clsValidInput();
    DataRow Drow;
    string page_name = "खाता प्रोसेसिंग";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Session["page_heading"] = "खाता प्रोसेसिंग करणे";
                txtKhataNo.Focus();
                btnKhataNo.Enabled = true;
            }

            int reedit_Certwork = obj.funReturnSingleValueInt((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and approve_flag<>'Approve'", "");
            if (reedit_Certwork > 0)
            {
                btnKhataNo.Enabled = false;
                string popupScript122 = "<script language='javascript'>alert('या गावात खाता प्रोसेसिंग करण्यापुर्वी   री-एडीट मॉड्युल  मधिल सर्व्हे क्रमांकाच्या सुरु केलेल्या दुरुस्त्या पुर्ण करुन प्रमाणित करणे आवश्यक आहे. त्यासाठी सर्व्हे क्रमांक/गट क्रमांकांच्या दुरुस्त्या या पर्यायाचा उपयोग करा. खाता प्रोसससिंगचे काम सुरु करण्यापूर्वी री-एडीट मधील दुरुस्ती करण्यासाठी निवडलेल्या सर्वे क्रमांकाची यादी  हा अहवाल  डाटा एन्ट्री मॉड्युल  अहवाल पर्यायात दिलेला आहे.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript122);
                return;
            }

            int date_cnt = obj.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_master_declaration = false and khata_master_declair_date  isnull  ", "");
            if (date_cnt == 0)
            {
                int row_cnt = obj.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' ", "");
                if (row_cnt > 0)
                {
                    btnKhataNo.Enabled = false;
                    string popupScript = "<script language='javascript'>alert('संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे ही माहिती या पुर्वीच साठवली आहे याची नोंद घ्यावी.' );</script>";
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
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }

        
    }
    protected void btnKhataNo_Click(object sender, EventArgs e)
    {
        try
        {
            int date_cnt = obj.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_master_declaration = false and khata_master_declair_date  isnull  ", "");
            if (date_cnt == 0)
            {
                int row_cnt = obj.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' ", "");
                if (row_cnt > 0)
                {
                    string popupScript = "<script language='javascript'>alert('संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे ही माहिती या पुर्वीच साठवली आहे याची नोंद घ्यावी.' );</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
            }




            if (Convert.ToString(Session["ccode"]) != String.Empty)
            {
                if (txtKhataNo.Text.Trim() != String.Empty)
                {
                    DataTable dtKhataNoInfo = new DataTable();
                    int ehd_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and trim(khata_no)='" + txtKhataNo.Text.Trim() + "'", "");
                    if (ehd_cnt > 0)
                    {
                        dtKhataNoInfo = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp e ," + Session["SchemaName"].ToString() + ".m_khata_type m ", "fname,mname,lname,topan_name,e.khata_type,m.khata_description", "ccode='" + Convert.ToString(Session["ccode"]) + "' and trim(khata_no)='" + txtKhataNo.Text.Trim() + "' and m.khata_type=e.khata_type and  edit_flag<>'34'  and edit_flag<>'40' ", "old_mut_no,usrno");
                    }
                    else
                    {
                        dtKhataNoInfo = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".holder_detail h ," + Session["SchemaName"].ToString() + ".m_khata_type m ", "fname,mname,lname,topan_name,h.khata_type,m.khata_description", "ccode='" + Convert.ToString(Session["ccode"]) + "' and trim(khata_no)='" + txtKhataNo.Text.Trim() + "' and m.khata_type=h.khata_type", "old_mut_no,usrno");
                    }
                    if (dtKhataNoInfo.Rows.Count > 0)
                    {
                        string KhataNoPending = string.Empty;
                        KhataNoPending = con.KhataNoPendingChecks(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString(), Convert.ToString(Session["ccode"]), "1", txtKhataNo.Text.ToString().Trim());

                        if (KhataNoPending != string.Empty)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", KhataNoPending);
                            return;
                        }
                        //.edit_holder_detail_kp ", "distinct khata_no::int", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no_status = false


                        gdvkhataDetails.Visible = true;
                        gdvkhataDetails.DataSource = dtKhataNoInfo.DefaultView;
                        gdvkhataDetails.DataBind();
                        Session["khata_no"] = txtKhataNo.Text;
                        btnKhataNo.Enabled = false;

                        lblSelectedkhataNoDisp.Visible = true;
                        lblkhataNamesCntDisp.Visible = true;
                        lblKhataTypeDisp.Visible = true;
                        lblSlectedKhataNo.Visible = true;
                        lblKhataType.Visible = true;
                        lblkhataNamesCnt.Visible = true;
                        lblkhataNames.Visible = true;
                        lblSelectedkhataNoDisp.Text = txtKhataNo.Text;
                        lblkhataNamesCntDisp.Text = dtKhataNoInfo.Rows.Count.ToString();
                        lblKhataTypeDisp.Text = dtKhataNoInfo.Rows[0]["khata_description"].ToString();
                        Panellinks.Visible = true;
                        lnlLinkHead.Visible = true;
                        lblKhataDelOnSurveySurveyListDispaly.Visible = true;

                        string pincase = "((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END))AS pins";



                        DataSet dssurvey = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7_khata", "distinct numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "khata_no ='" + Session["khata_no"].ToString() + "' AND  ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no='" + (Session["khata_no"]).ToString() + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  not in  ( select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + Session["SchemaName"].ToString() + ".edit_form7_khata_kp  where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and khata_no='" + (Session["khata_no"]).ToString() + "' and  ( edit_flag='34' or edit_flag='40'  ) )", "numeric_pin");
                        if (dssurvey != null && dssurvey.Tables.Count > 0 && dssurvey.Tables[0].Rows.Count > 0)
                        {

                            DataTable dt = dssurvey.Tables[0].DefaultView.ToTable(true, "pin", "pin1", "pin2", "pin3", "pin4", "pin5", "pin6", "pin7", "pin8", "pins");
                            Session["tblSurveypin1"] = dt;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                string survey = "";
                                if (i == 0)
                                {
                                    survey = dssurvey.Tables[0].Rows[i]["pins"].ToString().Trim('/');
                                    Session["survey"] = survey;
                                }
                                else
                                {
                                    survey = Session["survey"].ToString().Trim('/') + "," + dssurvey.Tables[0].Rows[i]["pins"].ToString().Trim('/');
                                    Session["survey"] = survey;
                                }
                            }
                            lblKhataOnSurveySurveyListDispVal.Visible = true;
                            lblKhataOnSurveySurveyListDispVal.Text = Session["survey"].ToString().Trim('/');
                        }

                        Session["khata_type_old"] = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".holder_detail h , " + Convert.ToString(Session["SchemaName"]) + ".m_khata_type m", "khata_description", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no ='" + Session["khata_no"].ToString() + "' and h.khata_type=m.khata_type", "");

                        btnCancel.Visible = true;
                    }
                    else
                    {
                        Session["khata_no"] = string.Empty;
                        txtKhataNo.Focus();
                        txtKhataNo.Text = string.Empty;
                        lblSelectedkhataNoDisp.Visible = false;
                        lblkhataNamesCntDisp.Visible = false;
                        lblKhataTypeDisp.Visible = false;
                        lblSlectedKhataNo.Visible = false;
                        lblKhataType.Visible = false;
                        lblkhataNamesCnt.Visible = false;
                        gdvkhataDetails.Visible = false;
                        lblkhataNames.Visible = false;
                        Panellinks.Visible = false;
                        lnlLinkHead.Visible = false;
                        lblKhataOnSurveySurveyListDispVal.Visible = false;
                        lblKhataOnSurveySurveyListDispVal.Text = String.Empty;
                        Session["khata_type_old"] = string.Empty;
                        lblKhataDelOnSurveySurveyListDispaly.Visible = false;

                        string popupScript = "<script language='javascript'>alert('खाता क्रमांक उपलब्ध नाही.');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }

                }
                else
                {
                    txtKhataNo.Focus();
                    string popupScript = "<script language='javascript'>alert('कृपया खाता क्रमांक टाका.');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;

                }
            }
            else
            {
                string popupScript = "<script language='javascript'>alert('कृपया गाव निवडा.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;

            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
}
    
    protected void txtKhataNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            btnKhataNo.Focus();
            btnKhataNo.Enabled = true;
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void lnkNameAdd_Click(object sender, EventArgs e)
    {
        try
        {
            btnAddNameSave.Enabled = true;
            ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup_NameAdd').style.display = 'block';", true);
            pnlNameAdd.Visible = true;
            Panel3.Visible = true;

            Panellinks.Visible = false;
            //  lblKhataNo.Text = Convert.ToString(Session["khata_no"]);
            string pincase = "rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||";
            pincase += "(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||";
            pincase += "(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||";
            pincase += "(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||";
            pincase += "(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||";
            pincase += "(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  ||";
            pincase += "(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||";
            pincase += "(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  ||";
            pincase += "(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')AS pins";

            int cnt_editf7k_add = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "");
            int cnt_f7k = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "");
            decimal max_usrno_khata = 0;
            if (cnt_editf7k_add == 0)
            {
                con.funSetGridList(Convert.ToString(Session["DataBaseName"]), ref gvKhataOwners, Convert.ToString(Session["SchemaName"]) + ".holder_detail AS a," + Convert.ToString(Session["SchemaName"]) + ".form7_khata AS f," + Convert.ToString(Session["SchemaName"]) + ".m_khata_type AS p", "distinct f.fname,f.mname,f.lname,f.topan_name,p.khata_description,f.khata_no", "a.khata_type = p.khata_type   and f.khata_no ='" + Convert.ToString(Session["khata_no"]) + "' AND  f.ccode = '" + Convert.ToString(Session["ccode"]) + "' and a.ccode=f.ccode and a.khata_no=f.khata_no and a.fname = f.fname and a.mname = f.mname and a.lname =f.lname and a.topan_name=f.topan_name", "f.khata_no,f.fname,f.mname,f.lname,f.topan_name");
                lblKhataTypeold.Text = Convert.ToString(Session["khata_type_old"]);
                Session["editf7k_add"] = "";
                int f7kcnt = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "");
                if (f7kcnt > 0)
                {
                    max_usrno_khata = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", " max(usrno)", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "");
                }
                else
                {
                    max_usrno_khata = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".holder_detail", " max(usrno)", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "");
                }
            }
            else
            {
                con.funSetGridList(Convert.ToString(Session["DataBaseName"]), ref gvKhataOwners, Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp AS a," + Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata_kp AS f," + Convert.ToString(Session["SchemaName"]) + ".m_khata_type AS p", "distinct f.fname,f.mname,f.lname,f.topan_name,p.khata_description,f.khata_no,f.usrno", "a.khata_type = p.khata_type   and f.khata_no ='" + Convert.ToString(Session["khata_no"]) + "' AND  f.ccode = '" + Convert.ToString(Session["ccode"]) + "' and a.ccode=f.ccode and a.khata_no=f.khata_no and a.fname = f.fname and a.mname = f.mname and a.lname =f.lname and a.topan_name=f.topan_name  and f.edit_flag<>'34'", "f.usrno");
                Session["khata_type_old"] = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp h , " + Convert.ToString(Session["SchemaName"]) + ".m_khata_type m", "khata_description", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no ='" + Session["khata_no"].ToString() + "' and h.khata_type=m.khata_type", "");
                lblKhataTypeold.Text = Convert.ToString(Session["khata_type_old"]);
                lblKhataTypeold.Visible = true;
                Session["editf7k_add"] = "YES";
                max_usrno_khata = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", " max(usrno)", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "");
            }
            Session["max_usrno_khata"] = max_usrno_khata;
            con.funSetDropDownList(Convert.ToString(Session["DataBaseName"]), ref ddlkhatatype, Session["SchemaName"].ToString() + ".m_khata_type", "khata_type,khata_description", "khata_type <> 0", "khata_type");
            DataSet dssurvey = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7_khata ", "distinct numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "khata_no ='" + Session["khata_no"].ToString() + "' AND  ccode = '" + Convert.ToString(Session["ccode"]) + "'", "numeric_pin");
            DataSet dssurvey_khataAdd = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata_kp ", "distinct numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "khata_no ='" + Session["khata_no"].ToString() + "' AND  ccode = '" + Convert.ToString(Session["ccode"]) + "'", "numeric_pin");
            if (dssurvey != null && dssurvey.Tables.Count > 0 && dssurvey.Tables[0].Rows.Count > 0)
            {
                if (dssurvey_khataAdd != null && dssurvey_khataAdd.Tables.Count > 0 && dssurvey_khataAdd.Tables[0].Rows.Count > 0)
                {
                    dssurvey.Merge(dssurvey_khataAdd);
                }
                DataTable dt = dssurvey.Tables[0].DefaultView.ToTable(true, "pin", "pin1", "pin2", "pin3", "pin4", "pin5", "pin6", "pin7", "pin8", "pins");
                Session["tblSurveypin1"] = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string survey = "";
                    if (i == 0)
                    {
                        survey = dssurvey.Tables[0].Rows[i]["pins"].ToString();
                        Session["survey"] = survey;
                    }
                    else
                    {
                        survey = Session["survey"] + "," + dssurvey.Tables[0].Rows[i]["pins"].ToString();
                        Session["survey"] = survey;
                    }
                }
                lblSurveyList.Visible = true;
                lblSurveyList.Text = Session["survey"].ToString();
                Label1.Visible = true;
                pnlWarasNames.Visible = true;
                this.funInitilisation();
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
    protected void lnkNameDelete_Click(object sender, EventArgs e)
    {
        //PaneNameDel
        try
        {
            Session["Name_Del"] = null;

            if ((Session["khata_no"] == null))
            {
                string popupScript = "<script language='javascript'>alert(' ज्या खात्यात नावे काढणे करावयाची आहे तो खाता क्रमांक निवडा.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;

            }
            else
            {



                DataSet ds_old_names_del = new DataSet();
                int chk_edit_hd_khata = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*) ", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + (Convert.ToString(Session["khata_no"])) + "' ", "");
                if (chk_edit_hd_khata == 0)
                {
                    ds_old_names_del = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".holder_detail ", "fname,mname,lname,topan_name,khata_no,khata_type,cast('0' as bool) as chk, '' as flag", "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "'  ", "khata_no::int");
                }
                else
                {

                    ds_old_names_del = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "fname,mname,lname,topan_name,khata_no,khata_type,cast('0' as bool) as chk, '' as flag", "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "' and  edit_flag<>'34' and  edit_flag<>'40' ", "khata_no::int");
                }
                Session["khata_type_old_del"] = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".holder_detail h , " + Convert.ToString(Session["SchemaName"]) + ".m_khata_type m", "khata_description", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no ='" + Session["khata_no"].ToString() + "' and h.khata_type=m.khata_type", "");
                lblKhataTypeDelDisp.Text = Convert.ToString(Session["khata_type_old"]);

                con.funSetDropDownList(Convert.ToString(Session["DataBaseName"]), ref ddlkhatatypeDel, Session["SchemaName"].ToString() + ".m_khata_type", "khata_type,khata_description", "khata_type <> 0", "khata_type");

                if (ds_old_names_del.Tables.Count > 0 && ds_old_names_del.Tables[0].Rows.Count > 1)
                {

                    ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup_PaneNameDel').style.display = 'block';", true);
                    PaneNameDel.Visible = true;
                    Panellinks.Visible = false;

                    gdvOldNamesDel.DataSource = ds_old_names_del.Tables[0].DefaultView;
                    gdvOldNamesDel.DataBind();
                    ViewState["ds_old_names_del"] = ds_old_names_del;
                    pnlOldNamesDel.Visible = true;
                    gdvOldNamesDel.Visible = true;
                    lblKhataNoDisp.Visible = true;
                    lblKhataNoDisp.Text = Session["khata_no"].ToString();
                    lblSurveyNameDel.Text = "";
                    lblSurveyNameDelDisp.Visible = true;

                    string pincase = "rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||";
                    pincase += "(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||";
                    pincase += "(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||";
                    pincase += "(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||";
                    pincase += "(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||";
                    pincase += "(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  ||";
                    pincase += "(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||";
                    pincase += "(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  ||";
                    pincase += "(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')AS pins";
                    ViewState["lblSurveyList"] = "";
                    DataSet ds_pins = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", " distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "' ", "");

                    int pins_cnt = 1;
                    if (ds_pins.Tables.Count > 0 && ds_pins.Tables[0].Rows.Count > 0)
                    {

                        DataTable dt_pins = ds_pins.Tables[0].DefaultView.ToTable(true, "pin", "pin1", "pin2", "pin3", "pin4", "pin5", "pin6", "pin7", "pin8", "pins");

                        foreach (DataRow dr_pin in dt_pins.Rows)
                        {

                            lblSurveyNameDel.Text = dr_pin["pins"].ToString();

                            if (ViewState["lblSurveyList"].ToString() == "")
                            {
                                ViewState["lblSurveyList"] = lblSurveyNameDel.Text;
                            }
                            else
                            {
                                if (ViewState["lblSurveyList"].ToString().Length <= pins_cnt * 120)
                                {
                                    ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + lblSurveyNameDel.Text;
                                    pins_cnt = pins_cnt + 1;
                                }
                                else
                                {
                                    ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + lblSurveyNameDel.Text + "<br/>";
                                }
                            }
                        }

                        lblSurveyNameDelDisp.Visible = true;
                        lblSurveyNameDel.Text = "";
                        lblSurveyNameDel.Visible = true;
                        lblSurveyNameDel.Text = ViewState["lblSurveyList"].ToString();
                        ViewState["ds_pins"] = ds_pins;

                    }


                }
                else
                {
                    string popupScript = "<script language='javascript'>alert('या खात्यामध्ये एकच नाव असल्यामुळे  ह्या खात्यातुन  नाव काढता येनार नाही .');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }

  
    protected void lnkNameSpellCorrection_Click(object sender, EventArgs e)
    {
        try
        {
            btn.Enabled = true;
            ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup_NameCorr').style.display = 'block';", true);
            PnlNameCorr.Visible = true;
            DataSet ds_old_names = new DataSet();
            int chk_edit_hd_khata = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*) ", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + (Convert.ToString(Session["khata_no"])) + "'", "");
            if (chk_edit_hd_khata == 0)
            {
                ds_old_names = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".holder_detail ", "fname,mname,lname,topan_name,khata_no,khata_type,cast('0' as bool) as chk, '' as flag", "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "'  ", "khata_no::int");
            }
            else
            {
                ds_old_names = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "fname,mname,lname,topan_name,khata_no,khata_type,cast('0' as bool) as chk, '' as flag", "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "' and edit_flag <>'34' ", "khata_no::int");
            }

            if (ds_old_names.Tables.Count > 0 && ds_old_names.Tables[0].Rows.Count > 0)
            {
                gdvOldNames.DataSource = ds_old_names.Tables[0].DefaultView;
                gdvOldNames.DataBind();
                ViewState["ds_old_names"] = ds_old_names;
                pnlOldNames.Visible = true;
                gdvOldNames.Visible = true;
                lblKhataNoSpellCorr.Visible = true;
                lblKhataNoNamesSpell.Text = Session["khata_no"].ToString();
                lblSurveyListDispaly.Text = "";
                lblSurveyList.Visible = true;
                btnAdd.Visible = true;
                lblmsgSpell.Visible = false;
                lblKhataNoSpellCorr.Visible = true;
                string pincase = "rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')AS pins";
                ViewState["lblSurveyList"] = "";
                DataSet ds_pins = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", " distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "' ", "");
                int pins_cnt = 1;
                if (ds_pins.Tables.Count > 0 && ds_pins.Tables[0].Rows.Count > 0)
                {
                    DataTable dt_pins = ds_pins.Tables[0].DefaultView.ToTable(true, "pin", "pin1", "pin2", "pin3", "pin4", "pin5", "pin6", "pin7", "pin8", "pins");
                    foreach (DataRow dr_pin in dt_pins.Rows)
                    {
                        lblSurveyListDispaly.Text = dr_pin["pins"].ToString();
                        if (ViewState["lblSurveyList"].ToString() == "")
                        {
                            ViewState["lblSurveyList"] = lblSurveyListDispaly.Text;
                        }
                        else
                        {
                            if (ViewState["lblSurveyList"].ToString().Length <= pins_cnt * 120)
                            {
                                ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + lblSurveyListDispaly.Text;
                                pins_cnt = pins_cnt + 1;
                            }
                            else
                            {
                                ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + lblSurveyListDispaly.Text + "<br/>";
                            }
                        }
                    }
                    lblSurveyDisp.Visible = true;
                    lblSurveyListDispaly.Text = "";
                    lblSurveyListDispaly.Visible = true;
                    lblSurveyListDispaly.Text = ViewState["lblSurveyList"].ToString();
                    ViewState["ds_pins"] = ds_pins;
                }
            }
            else
            {
                lblmsgSpell.Visible = true;
                lblmsgSpell.Text = "माहिती उपलब्ध नाही.";
            }
        }
        catch(Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
        
    }
    protected void lnkKhataType_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup_khataType').style.display = 'block';", true);
            pnlkhataType.Visible = true;
            DataSet ds_khata_type_change = new DataSet();
            int chk_edit_hd_khata = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*) ", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + (Convert.ToString(Session["khata_no"])) + "'", "");
            if (chk_edit_hd_khata == 0)
            {
                ds_khata_type_change = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".holder_detail ", "fname,mname,lname,topan_name,khata_no,khata_type,cast('0' as bool) as chk, '' as flag", "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "'  ", "khata_no::int");
                Session["khata_type_change"] = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".holder_detail h , " + Convert.ToString(Session["SchemaName"]) + ".m_khata_type m", "khata_description", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no ='" + Session["khata_no"].ToString() + "' and h.khata_type=m.khata_type", "");
            }
            else
            {
                ds_khata_type_change = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "fname,mname,lname,topan_name,khata_no,khata_type,cast('0' as bool) as chk, '' as flag", "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "' and  edit_flag<>'34' ", "khata_no::int");
                Session["khata_type_change"] = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp h , " + Convert.ToString(Session["SchemaName"]) + ".m_khata_type m", "khata_description", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no ='" + Session["khata_no"].ToString() + "' and h.khata_type=m.khata_type", "");
            }
            Session["ds_khata_type_change"] = ds_khata_type_change;

            lblKhataTypechangeKhataTypeOldDisp.Visible = true;
            lblKhataTypechangeKhataTypeOldDisp.Text = Convert.ToString(Session["khata_type_change"]);

            con.funSetDropDownList(Convert.ToString(Session["DataBaseName"]), ref ddlKhataTypechangeKhataTypeNew, Session["SchemaName"].ToString() + ".m_khata_type", "khata_type,khata_description", "khata_type <> 0", "khata_type");

            if (ds_khata_type_change.Tables.Count > 0 && ds_khata_type_change.Tables[0].Rows.Count > 0)
            {
                grdkhataTypechangeNames.DataSource = ds_khata_type_change.Tables[0].DefaultView;
                grdkhataTypechangeNames.DataBind();
                panelkhataTypechangeNames.Visible = true;
                grdkhataTypechangeNames.Visible = true;
                lblKhataTypechangeKhataNoDisp.Visible = true;
                lblKhataTypechangeKhataNoDisp.Text = Session["khata_no"].ToString();
                lblSurveyNameDel.Text = "";
                lblSurveyNameDelDisp.Visible = true;
                btnkhataTypeChngeSave.Visible = true;
                lblktc.Visible = false;

                string pincase = "rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  ||";
                pincase += "(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')AS pins";
                ViewState["lblSurveyList"] = "";
                DataSet ds_pins = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", " distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "' ", "");
                DataSet dssurvey_khataAdd = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata ", "distinct numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "khata_no ='" + Session["khata_no"].ToString() + "' AND  ccode = '" + Convert.ToString(Session["ccode"]) + "'", "numeric_pin");
                int pins_cnt = 1;
                if ((ds_pins.Tables.Count > 0 && ds_pins.Tables[0].Rows.Count > 0) || (dssurvey_khataAdd != null && dssurvey_khataAdd.Tables.Count > 0 && dssurvey_khataAdd.Tables[0].Rows.Count > 0))
                {
                    if (ds_pins.Tables.Count > 0 && ds_pins.Tables[0].Rows.Count == 0)
                    {
                        ds_pins = dssurvey_khataAdd.Copy();
                    }
                    if (dssurvey_khataAdd != null && dssurvey_khataAdd.Tables.Count > 0 && dssurvey_khataAdd.Tables[0].Rows.Count > 0)
                    {
                        ds_pins.Merge(dssurvey_khataAdd);
                    }
                    DataTable dt_pins = ds_pins.Tables[0].DefaultView.ToTable(true, "pin", "pin1", "pin2", "pin3", "pin4", "pin5", "pin6", "pin7", "pin8", "pins");
                    foreach (DataRow dr_pin in dt_pins.Rows)
                    {
                        khataTypeChangeSurveyDisp.Text = dr_pin["pins"].ToString();
                        if (ViewState["lblSurveyList"].ToString() == "")
                        {
                            ViewState["lblSurveyList"] = khataTypeChangeSurveyDisp.Text;
                        }
                        else
                        {
                            if (ViewState["lblSurveyList"].ToString().Length <= pins_cnt * 120)
                            {
                                ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + khataTypeChangeSurveyDisp.Text;
                                pins_cnt = pins_cnt + 1;
                            }
                            else
                            {
                                ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + khataTypeChangeSurveyDisp.Text + "<br/>";
                            }
                        }
                    }
                    khataTypeChangeSurvey.Visible = true;
                    khataTypeChangeSurveyDisp.Visible = true;
                    khataTypeChangeSurveyDisp.Text = "";
                    khataTypeChangeSurveyDisp.Text = ViewState["lblSurveyList"].ToString();
                    ViewState["ds_pins"] = ds_pins;
                }
            }
            else
            {
                lblktc.Visible = true;
                lblktc.Text = "खाता मास्टर मध्ये निवडलेल्या खात्याची माहिती उपलब्ध नाही.";
            }
        }
        catch(Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
        
    }
    protected void lnkSoftwreProcess_Click(object sender, EventArgs e)
    {

    }
    protected void lnkKhatarNoDelete_Click(object sender, EventArgs e)
    {

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            txtKhataNo.Focus();
            txtKhataNo.Text = string.Empty;
            lblSelectedkhataNoDisp.Visible = false;
            lblkhataNamesCntDisp.Visible = false;
            lblKhataTypeDisp.Visible = false;
            lblSlectedKhataNo.Visible = false;
            lblKhataType.Visible = false;
            lblkhataNamesCnt.Visible = false;
            gdvkhataDetails.Visible = false;
            lblkhataNames.Visible = false;
            Panellinks.Visible = false;
            lnlLinkHead.Visible = false;
            btnKhataNo.Visible = true;
            btnCancel.Visible = false;
            lblKhataOnSurveySurveyListDispVal.Visible = false;
            lblKhataOnSurveySurveyListDispVal.Text = String.Empty;
            Session["khata_type_old"] = string.Empty;
            lblKhataDelOnSurveySurveyListDispaly.Visible = false;
            btnKhataNo.Enabled = true;
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
    protected void btnAddNameBack_Click(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup_bhogvatdar').style.display = 'block';", true);
            Panellinks.Visible = true;

            pnlNameAdd.Visible = false;
            lblSelectedKhatatype.Visible = false;
            lblnewKhataType.Visible = false;
            lblnewKhataType.Text = "";



            Session["editf7k_add"] = null;
            // Session["khata_type_old"] = null;
            Session["khata_type"] = null;
            Session["khata_name"] = null;
            lblSelectedKhatatype.Visible = false;
            lblnewKhataType.Visible = false;
            ViewState["grdOldkhata"] = null;




            DataSet ds_editf7kp = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", " distinct (khata_no::int) as seller_khata_no,fname,mname,lname,topan_name", "ccode = '" + Convert.ToString(Session["ccode"]) + "'and khata_no='" + Convert.ToString(Session["khata_no"]) + "' and  khata_no<>''  and edit_flag<>'34'  and edit_flag<>'40'", "khata_no::int");
            if (ds_editf7kp != null && ds_editf7kp.Tables[0].Rows.Count > 0)
            {

                lblkhataNamesCntDisp.Text = ds_editf7kp.Tables[0].Rows.Count.ToString();
                ViewState["orignal_sellers_ds"] = ds_editf7kp;
                gdvkhataDetails.DataSource = ds_editf7kp.Tables[0].DefaultView;
                gdvkhataDetails.DataBind();
                ViewState["Ds_toEnble"] = ds_editf7kp;
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void btnAddNameSave_Click(object sender, EventArgs e)
    {
        lblMessage.Visible = false;
        lblMessage.Text = String.Empty;

        try
        {
            if (ddlkhatatype.Text == "--निवडा--")
            {
                btnAddNameSave.Enabled = true;
                lblMessage.Visible = true;
                lblMessage.Text = "खाता प्रकार निवडा ";
                return;
            }
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
                            #region[--validations of khata type --]
                            int cnt_owners = gvKhataOwners.Rows.Count + grvVars.Rows.Count;
                            string status = "";
                            if (Convert.ToInt32(ddlkhatatype.Text) == 1)
                            {
                                if (cnt_owners == 1)
                                {
                                    status = "OK";
                                }
                                else
                                {
                                    status = "NOT OK";
                                }
                            }
                            else if (Convert.ToInt32(ddlkhatatype.Text) == 2 || Convert.ToInt32(ddlkhatatype.Text) == 3)
                            {
                                if (cnt_owners == 1)
                                {
                                    status = "NOT OK";
                                }
                                else
                                {
                                    status = "OK";
                                }
                            }
                            else
                            {
                                status = "OK";
                            }
                            #endregion[--validations of khata type --]

                            if (status == "OK")
                            {
                                lblMessage.Visible = false;
                                lblMessage.Text = " ";
                                DataTable dtboja = new DataTable();
                                Boja_table(ref dtboja);

                                DataTable dtpins = (DataTable)Session["tblSurveypin1"];
                                DataTable dtnewname = (DataTable)Session["tblVars"];
                                int cnt_editf7kp_Add = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "");
                                if (cnt_editf7kp_Add == 0)
                                {
                                    //foreach (DataRow drpins in dtpins.Rows)
                                    //{
                                    //    cnt_editf7kp_Add = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and  pin='" + Convert.ToString(drpins["pin"]) + "' and pin1='" + Convert.ToString(drpins["pin1"]) + "' and  pin2='" + Convert.ToString(drpins["pin2"]) + "' and pin3='" + Convert.ToString(drpins["pin3"]) + "' and pin4='" + Convert.ToString(drpins["pin4"]) + "' and pin5='" + Convert.ToString(drpins["pin5"]) + "' and pin6='" + Convert.ToString(drpins["pin6"]) + "'  and pin7='" + Convert.ToString(drpins["pin7"]) + "' and pin8 ='" + Convert.ToString(drpins["pin8"]) + "' ", "");
                                    //    if (cnt_editf7kp_Add == 0)
                                    //    {
                                            con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_khata_kp", " ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,khata_type,total_area_h,assessment, anne,pai,potkharaba,edit_trans_no,edit_appname,edit_flag", " ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,khata_type,total_area_h,assessment, anne,pai,potkharaba,'" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','31'", " ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", (string)Session["SchemaName"] + ".form7_khata", Convert.ToString(Session["UserName"]), ref dbCommand);
                                    //   }
                                    //} 
                                }



                                int chk_edit_hd_khata = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*) ", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "");
                                if (chk_edit_hd_khata == 0)
                                {
                                    con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_holder_detail_kp", " ccode,fname, mname, lname, topan_name,khata_no, khata_type,edit_trans_no,edit_appname,edit_flag", " ccode, fname, mname, lname, topan_name,khata_no,khata_type,'" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','31'", " ccode = '" + (string)Session["ccode"] + "'   and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", (string)Session["SchemaName"] + ".holder_detail", Convert.ToString(Session["UserName"]), ref dbCommand);
                                }

                                decimal max_usrno_khata = Convert.ToDecimal(Session["max_usrno_khata"]) + 1;

                                for (int j = 0; j < dtpins.Rows.Count; j++)
                                {
                                    decimal usrno = max_usrno_khata;
                                    for (int i = 0; i < dtnewname.Rows.Count; i++)
                                    {
                                        if (Convert.ToString(dtnewname.Rows[i]["mut_no"]).Trim() == "")
                                        {
                                            string popupScript = "<script language='javascript'>alert('नविन समावेश केलेल्या नावांसमोर फेरफार क्रमांक टाका');</script>";
                                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                            return;
                                        }
                                        else
                                        {
                                            int cnt_editf7k_Add = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and pin='" + Convert.ToString(dtpins.Rows[j]["pin"]) + "' and pin1='" + Convert.ToString(dtpins.Rows[j]["pin1"]) + "' and  pin2='" + Convert.ToString(dtpins.Rows[j]["pin2"]) + "' and pin3='" + Convert.ToString(dtpins.Rows[j]["pin3"]) + "' and pin4='" + Convert.ToString(dtpins.Rows[j]["pin4"]) + "' and pin5='" + Convert.ToString(dtpins.Rows[j]["pin5"]) + "' and pin6='" + Convert.ToString(dtpins.Rows[j]["pin6"]) + "'  and pin7='" + Convert.ToString(dtpins.Rows[j]["pin7"]) + "' and pin8 ='" + Convert.ToString(dtpins.Rows[j]["pin8"]) + "' and fname='" + Convert.ToString(dtnewname.Rows[i]["fname"]).Trim() + "'  and mname='" + Convert.ToString(dtnewname.Rows[i]["mname"]).Trim() + "' and lname='" + Convert.ToString(dtnewname.Rows[i]["lname"]).Trim() + "' and topan_name='" + Convert.ToString(dtnewname.Rows[i]["topan_name"]).Trim() + "' and khata_no='" + Convert.ToString(Session["khata_no"]).Trim() + "' and edit_flag<>'34' ", "");
                                            if (cnt_editf7k_Add == 0)
                                            {
                                                con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "ccode = '" + (string)Session["ccode"] + "' and pin='" + Convert.ToString(dtpins.Rows[j]["pin"]) + "' and pin1='" + Convert.ToString(dtpins.Rows[j]["pin1"]) + "' and  pin2='" + Convert.ToString(dtpins.Rows[j]["pin2"]) + "' and pin3='" + Convert.ToString(dtpins.Rows[j]["pin3"]) + "' and pin4='" + Convert.ToString(dtpins.Rows[j]["pin4"]) + "' and pin5='" + Convert.ToString(dtpins.Rows[j]["pin5"]) + "' and pin6='" + Convert.ToString(dtpins.Rows[j]["pin6"]) + "'  and pin7='" + Convert.ToString(dtpins.Rows[j]["pin7"]) + "' and pin8 ='" + Convert.ToString(dtpins.Rows[j]["pin8"]) + "' and fname='" + Convert.ToString(dtnewname.Rows[i]["fname"]).Trim() + "'  and mname='" + Convert.ToString(dtnewname.Rows[i]["mname"]).Trim() + "' and lname='" + Convert.ToString(dtnewname.Rows[i]["lname"]).Trim() + "' and topan_name='" + Convert.ToString(dtnewname.Rows[i]["topan_name"]).Trim() + "' and khata_no='" + Convert.ToString(Session["khata_no"]).Trim() + "' and edit_flag='34'", ref dbCommand);
                                                con.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,edit_trans_no,edit_appname,edit_flag", "'" + (string)Session["ccode"] + "','" + Convert.ToString(dtpins.Rows[j]["pin"]) + "','" + Convert.ToString(dtpins.Rows[j]["pin1"]) + "','" + Convert.ToString(dtpins.Rows[j]["pin2"]) + "','" + Convert.ToString(dtpins.Rows[j]["pin3"]) + "','" + Convert.ToString(dtpins.Rows[j]["pin4"]) + "','" + Convert.ToString(dtpins.Rows[j]["pin5"]) + "','" + Convert.ToString(dtpins.Rows[j]["pin6"]) + "','" + Convert.ToString(dtpins.Rows[j]["pin7"]) + "','" + Convert.ToString(dtpins.Rows[j]["pin8"]) + "','" + Convert.ToString(Session["khata_no"]).Trim() + "','" + Convert.ToString(dtnewname.Rows[i]["fname"]).Trim() + "' ,'" + Convert.ToString(dtnewname.Rows[i]["mname"]).Trim() + "','" + Convert.ToString(dtnewname.Rows[i]["lname"]).Trim() + "','" + Convert.ToString(dtnewname.Rows[i]["topan_name"]).Trim() + "','" + usrno + "','" + Convert.ToString(dtnewname.Rows[i]["mut_no"]).Trim() + "' ,'" + Convert.ToString(Session["village_trans_cnt"]) + "' ,'reEdit','32'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                                usrno++;
                                            }
                                        }
                                    }
                                }

                                for (int i = 0; i < dtnewname.Rows.Count; i++)
                                {
                                    chk_edit_hd_khata = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and fname='" + Convert.ToString(dtnewname.Rows[i]["fname"]).Trim() + "'  and mname='" + Convert.ToString(dtnewname.Rows[i]["mname"]).Trim() + "' and lname='" + Convert.ToString(dtnewname.Rows[i]["lname"]).Trim() + "' and topan_name='" + Convert.ToString(dtnewname.Rows[i]["topan_name"]).Trim() + "' and khata_no='" + Convert.ToString(Session["khata_no"]).Trim() + "' and edit_flag<>'34' ", "");
                                    if (chk_edit_hd_khata == 0)
                                    {
                                        con.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "ccode = '" + (string)Session["ccode"] + "' and fname='" + Convert.ToString(dtnewname.Rows[i]["fname"]).Trim() + "'  and mname='" + Convert.ToString(dtnewname.Rows[i]["mname"]).Trim() + "' and lname='" + Convert.ToString(dtnewname.Rows[i]["lname"]).Trim() + "' and topan_name='" + Convert.ToString(dtnewname.Rows[i]["topan_name"]).Trim() + "' and khata_no='" + Convert.ToString(Session["khata_no"]).Trim() + "' and edit_flag='34'", ref dbCommand);
                                        con.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "ccode,khata_no,fname, mname, lname,topan_name,old_mut_no,edit_trans_no,edit_appname,edit_flag", "'" + (string)Session["ccode"] + "','" + Convert.ToString(Session["khata_no"]).Trim() + "'  ,'" + Convert.ToString(dtnewname.Rows[i]["fname"]).Trim() + "' ,'" + Convert.ToString(dtnewname.Rows[i]["mname"]).Trim() + "','" + Convert.ToString(dtnewname.Rows[i]["lname"]).Trim() + "','" + Convert.ToString(dtnewname.Rows[i]["topan_name"]).Trim() + "','" + Convert.ToString(dtnewname.Rows[i]["mut_no"]).Trim() + "','" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','32'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                    }
                                }

                                if (dtnewname.Rows.Count > 0)
                                {

                                    con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "khata_type=" + ddlkhatatype.Text.ToString() + " ", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "'", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "' and khata_type=" + ddlkhatatype.Text.ToString() + "", ref dbCommand, Convert.ToString(Session["UserName"]));
                                }

                                dbTransaction.Commit();

                                //----------
                                Session["editf7k_add"] = null;
                               // Session["khata_type_old"] = null;
                                Session["khata_type"] = null;
                                Session["khata_name"] = null;
                                lblSelectedKhatatype.Visible = false;
                                lblnewKhataType.Visible = false;
                                ViewState["grdOldkhata"] = null;
                                //-------------
                                grvVars.DataSource = null;
                                grvVars.DataBind();


                                btnAddNameSave.Enabled = false;
                                string popupScript1 = "<script language='javascript'>alert('माहिती साठवली.');</script>";
                                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
                            }
                            else
                            {
                                string popupScript = "<script language='javascript'>alert('योग्य खाता प्रकार निवडा.');</script>";
                                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                ddlkhatatype.SelectedIndex = -1;
                                return;
                            }

                        }
                        catch (Exception ex)
                        {
                            ExceptionHandling excpt = new ExceptionHandling();
                            if (Session["UserName"] != null)
                                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
                            else
                                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                            lblMessage.Visible = true;
                            lblMessage.Text = ex.Message;
                            return;
                        }
                    }
                }
                connection.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));

            lblMessage.Visible = true;
            lblMessage.Text = "समस्या : माहिती साठवली नाही.";
            return;
        }

        Panel3.Visible = false;
    }
    protected void ddlkhatatype_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlkhatatype.SelectedItem.Text.ToString() != "--निवडा--")
            {
                Session["khata_type"] = ddlkhatatype.SelectedItem.Value;
                Session["khata_name"] = ddlkhatatype.SelectedItem.Text;
                lblSelectedKhatatype.Visible = true;
                lblnewKhataType.Visible = true;
                lblnewKhataType.Text = ddlkhatatype.SelectedItem.Text;
                lblKhataTypeDisp.Text = ddlkhatatype.SelectedItem.Text;

            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void grvVars_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        try
        {
            grvVars.EditIndex = -1;
            Session["purindex"] = -1;
            FilPartyDetails('P');
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "alert('" + Convert.ToString(Session["Error"]) + "')";
            // ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "popupscript", popupScript, true);
        }
    }
    protected void grvVars_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {

            TextBox txtNewFirstName = (TextBox)grvVars.FooterRow.FindControl("txtNewFirstNameS");
            TextBox txtNewMiddleName = (TextBox)grvVars.FooterRow.FindControl("txtNewMiddleNameS");
            TextBox txtNewSurName = (TextBox)grvVars.FooterRow.FindControl("txtNewSurNameS");
            TextBox txtNewAddress = (TextBox)grvVars.FooterRow.FindControl("txtNewAddressS");
            TextBox txtfullname2 = (TextBox)grvVars.FooterRow.FindControl("txtfullname2");
            TextBox txtMutationNo = (TextBox)grvVars.FooterRow.FindControl("txtMutationNoS");



            if (!objvalidip.IsValidInput("not special char", txtNewFirstName.Text) || !objvalidip.IsValidInput("not special char", txtNewMiddleName.Text) || !objvalidip.IsValidInput("not special char", txtNewSurName.Text) || !objvalidip.IsValidInput("not special char", txtNewAddress.Text))
            {
                Session["Error"] = "माहिती  बरोबर भरा.";
                string popupScript = "alert('" + Convert.ToString(Session["Error"]) + "')";
            }
            else
            {

                if (e.CommandName.Equals("New"))
                {
                    LinkButton btnNew = (LinkButton)grvVars.FooterRow.FindControl("LinkButton7");
                    if (btnNew.Text == "साठवा")
                    {

                        if (txtNewFirstName.Text == "")
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "संपुर्ण माहिती भरा";
                            return;
                        }

                        string strtxtNewFirstName = Regex.IsMatch(txtNewFirstName.Text, @"^[0-9०-९'.\s]{1,40}$") ? "Error" : Regex.Replace(txtNewFirstName.Text, "'", "''");
                        string strtxtNewMiddleName = Regex.IsMatch(txtNewMiddleName.Text, @"^[0-9०-९'.\s]{1,40}$") ? "Error" : Regex.Replace(txtNewMiddleName.Text, "'", "''");
                        string strtxtNewSurName = Regex.IsMatch(txtNewSurName.Text, @"^[0-9०-९'.\s]{1,40}$") ? "Error" : Regex.Replace(txtNewSurName.Text, "'", "''");
                        string strtxtNewAddress = "";
                        string strtxtfullname2 = "";
                        string strtxtMutNo = txtMutationNo.Text;

                        if (txtNewAddress.Text.ToString() != "")
                        {
                            strtxtNewAddress = Regex.IsMatch(txtNewAddress.Text, @"^[`|@#$%^&*{}~:<>?[]]{1,500}$") ? "Error" : Regex.Replace(txtNewAddress.Text, "'", "''");
                        }


                        if (strtxtNewFirstName == "Error" || strtxtNewMiddleName == "Error" || strtxtNewSurName == "Error" || strtxtNewAddress == "Error")
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "माहिती  बरोबर भरा";
                            return;
                        }




                        if (((DataTable)Session["tblVars"]) == null)
                            CreateTable('P', NewPurTable);
                        else
                            NewPurTable = ((DataTable)Session["tblVars"]);






                        Drow = NewPurTable.NewRow();
                        if (ViewState["usrno"] == null)
                        {
                            Drow["usrno"] = 1;
                            ViewState["usrno"] = 1;
                        }
                        else
                        {
                            Drow["usrno"] = ((int)ViewState["usrno"]) + 1;
                            ViewState["usrno"] = ((int)ViewState["usrno"]) + 1;
                        }
                        Drow["fname"] = strtxtNewFirstName;
                        Drow["mname"] = strtxtNewMiddleName;
                        Drow["lname"] = strtxtNewSurName;
                        Drow["topan_name"] = strtxtNewAddress;
                        Drow["mut_no"] = strtxtMutNo;

                        strtxtfullname2 = strtxtNewFirstName + " " + strtxtNewMiddleName + " " + strtxtNewSurName + " " + strtxtNewAddress;
                        Drow["fullname"] = strtxtfullname2;
                        NewPurTable.Rows.Add(Drow);

                        Session["tblVars"] = (DataTable)NewPurTable;
                        FilPartyDetails('P');




                        txtNewFirstName.Visible = false;
                        txtNewMiddleName.Visible = false;
                        txtNewSurName.Visible = false;
                        txtNewAddress.Visible = false;
                        txtMutationNo.Visible = false;

                        btnNew.Text = "New";
                        lblMessage.Visible = false;



                    }
                    else
                    {
                        int maxCount = grvVars.Rows.Count;
                        maxCount = maxCount + 1;

                        txtNewFirstName.Visible = true;
                        txtNewMiddleName.Visible = true;
                        txtNewSurName.Visible = true;
                        txtNewAddress.Visible = true;
                        txtMutationNo.Visible = true;

                        RequiredFieldValidator rfvNewFirstName = (RequiredFieldValidator)grvVars.FooterRow.FindControl("rfvtxtNewFirstNameS");
                        rfvNewFirstName.Enabled = true;
                        btnNew.Text = "साठवा";
                    }
                }
                else
                {
                    if (grvVars.Rows.Count == 1 && ((DataTable)(Session["tblVars"])).Rows.Count == 0)
                    {
                        string popupScript = "alert('कृपया, नवीन या बटनावर क्लिक करा.')";
                        //  ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "popupscript", popupScript, true);
                    }
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
            string popupScript = "alert('" + Convert.ToString(Session["Error"]) + "')";
            // ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "popupscript", popupScript, true);
        }
    }
    protected void grvVars_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (((DataTable)Session["tblhaksod"]) == null)
                CreateTable('H', Dthaksod);
            else
            {
                NewPurTable = ((DataTable)Session["txtPresent"]);
                Dthaksod = (DataTable)Session["tblhaksod"];
            }


            Label lblAnoS = (Label)grvVars.Rows[e.RowIndex].FindControl("lblAnoS");
            Label lblPartyFNameS = (Label)grvVars.Rows[e.RowIndex].FindControl("lblPartyFNameS");
            Label lblPartyMNameS = (Label)grvVars.Rows[e.RowIndex].FindControl("lblPartyMNameS");
            Label lblPartyLNameS = (Label)grvVars.Rows[e.RowIndex].FindControl("lblPartyLNameS");
            Label Lbltopanname = (Label)grvVars.Rows[e.RowIndex].FindControl("Label18");
            Label lblfullname = (Label)grvVars.Rows[e.RowIndex].FindControl("lblfullname");


            Drow = Dthaksod.NewRow();
            Drow["usrno"] = lblAnoS.Text;
            Drow["fname"] = lblPartyFNameS.Text;
            Drow["mname"] = lblPartyMNameS.Text;
            Drow["lname"] = lblPartyLNameS.Text;
            Drow["topan_name"] = Lbltopanname.Text;
            Drow["fullname"] = lblfullname.Text;
            Dthaksod.Rows.Add(Drow);

            Session["Dthaksod"] = (DataTable)Dthaksod;
            NewPurTable = ((DataTable)Session["tblVars"]);

            Drow = NewPurTable.Rows[e.RowIndex];


            NewPurTable.Rows.Remove(Drow);
            Session["tblVars"] = (DataTable)NewPurTable;
            FilPartyDetails('P');


        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "alert('" + Convert.ToString(Session["Error"]) + "')";
            // ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "popupscript", popupScript, true);
        }
    }
    protected void grvVars_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            if (grvVars.Rows.Count >= 1 && ((DataTable)(Session["tblVars"])).Rows.Count > 0)
            {
                grvVars.EditIndex = e.NewEditIndex;
                FilPartyDetails('P');
                Session["purindex"] = e.NewEditIndex;
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "alert('" + Convert.ToString(Session["Error"]) + "')";
            //  ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "popupscript", popupScript, true);
        }
    }
    protected void grvVars_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            TextBox txtFirstName = (TextBox)grvVars.Rows[e.RowIndex].FindControl("txtFirstNameS");
            TextBox txtMiddleName = (TextBox)grvVars.Rows[e.RowIndex].FindControl("txtMiddleNameS");
            TextBox txtSurName = (TextBox)grvVars.Rows[e.RowIndex].FindControl("txtSurNameS");
            TextBox txtAddress = (TextBox)grvVars.Rows[e.RowIndex].FindControl("txtAddressS");
            TextBox txtfullname = (TextBox)grvVars.Rows[e.RowIndex].FindControl("txtfullname");
            TextBox txtMuatationNo = (TextBox)grvVars.Rows[e.RowIndex].FindControl("txtMutationNo");

            if (!objvalidip.IsValidInput("not special char", txtFirstName.Text) || !objvalidip.IsValidInput("not special char", txtMiddleName.Text) || !objvalidip.IsValidInput("not special char", txtSurName.Text) || !objvalidip.IsValidInput("not special char", txtAddress.Text))
            {
                Session["Error"] = "माहिती  बरोबर भरा.";
                string popupScript = "alert('" + Convert.ToString(Session["Error"]) + "')";
                // ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "popupscript", popupScript, true);
            }
            else
            {

                string strtxtFirstName = Regex.IsMatch(txtFirstName.Text, @"^[0-9०-९'.\s]{1,40}$") ? "Error" : Regex.Replace(txtFirstName.Text, "'", "''");
                string strtxtMiddleName = Regex.IsMatch(txtMiddleName.Text, @"^[0-9०-९'.\s]{1,40}$") ? "Error" : Regex.Replace(txtMiddleName.Text, "'", "''");
                string strtxtSurName = Regex.IsMatch(txtSurName.Text, @"^[0-9०-९'.\s]{1,40}$") ? "Error" : Regex.Replace(txtSurName.Text, "'", "''");
                string strtxtAddress = "";
                string strtxtfullname = "";
                string strtxtMuatationNo = txtMuatationNo.Text;
                if (txtAddress.Text.ToString() != "")
                {
                    strtxtAddress = Regex.IsMatch(txtAddress.Text, @"^[`|@#$%^&*{}~:<>?[]]{1,500}$") ? "Error" : Regex.Replace(txtAddress.Text, "'", "''");
                }

                if (strtxtFirstName == "Error" || strtxtMiddleName == "Error" || strtxtSurName == "Error" || strtxtAddress == "Error")
                {
                    lblMessage.Enabled = true;
                    lblMessage.Text = "माहिती  बरोबर भरा";
                    return;
                }
                grvVars.EditIndex = -1;
                NewPurTable = ((DataTable)Session["tblVars"]);
                Drow = NewPurTable.Rows[Convert.ToInt16(Session["purindex"])];
                if (ViewState["usrno"] == null)
                {
                    Drow["usrno"] = 1;
                    ViewState["usrno"] = 1;
                }
                else
                {
                    Drow["usrno"] = ((int)ViewState["usrno"]) + 1;
                    ViewState["usrno"] = ((int)ViewState["usrno"]) + 1;
                }
                Drow["fname"] = strtxtFirstName;
                Drow["mname"] = strtxtMiddleName;
                Drow["lname"] = strtxtSurName;
                Drow["topan_name"] = strtxtAddress;
                strtxtfullname = strtxtFirstName + " " + strtxtMiddleName + " " + strtxtSurName + " " + strtxtAddress;
                Drow["fullname"] = strtxtfullname;
                Drow["mut_no"] = strtxtMuatationNo;
                Session["tblVars"] = (DataTable)NewPurTable;
                FilPartyDetails('P');
                Session["purindex"] = -1;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "alert('" + Convert.ToString(Session["Error"]) + "')";
            //  ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "popupscript", popupScript, true);
        }
    }


    private void funInitilisation()
    {
        try
        {
            Session["tblVars"] = null;

            CreateTable('P', NewPurTable);

            FilPartyDetails('P');
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }


    }

    protected void CreateTable(char type, DataTable dt)
    {
        try
        {
            dt.Columns.Clear();
            dt.Columns.Add("usrno");
            dt.Columns.Add("PartyNo");
            dt.Columns.Add("fname");
            dt.Columns.Add("mname");
            dt.Columns.Add("lname");
            dt.Columns.Add("topan_name");
            dt.Columns.Add("buyer_age");
            dt.Columns.Add("buyer_relation");
            dt.Columns.Add("buyer_apk");
            dt.Columns.Add("fullname");
            dt.Columns.Add("mut_no");

            if (type == 'P')
                Session["tblVars"] = dt;
            if (type == 'H')
                Session["tblhaksod"] = dt;
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }

    private void createTable(ref DataTable TableName, string colName)
    {
        try
        {
            //[-- this function is to create table --]
            string[] strSplitArr = colName.Split(',');
            int count = strSplitArr.Length;
            TableName.Columns.Clear();
            for (int i = 0; i < count; i++)
                TableName.Columns.Add(strSplitArr[i]);
            TableName.AcceptChanges();
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }

    private void FilPartyDetails(char type)
    {
        //  lblMessage.Text = "";
        //customer.Fetch();
        try
        {

            if (type == 'P')
            {
                DataTable dtPurchaser = (DataTable)Session["tblVars"];
                if (dtPurchaser != null && dtPurchaser.Rows.Count > 0)
                {
                    grvVars.DataSource = dtPurchaser;
                    grvVars.DataBind();
                }
                else
                {
                    dtPurchaser.Rows.Add(dtPurchaser.NewRow());
                    grvVars.DataSource = dtPurchaser;
                    grvVars.DataBind();
                    if (dtPurchaser.Rows.Count == 1) dtPurchaser.Rows.RemoveAt(0);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }


    }
    protected void LinkButton8_Click(object sender, EventArgs e)
    {

    }
    protected void LinkButton7_Click(object sender, EventArgs e)
    {

    }

    private void Boja_table(ref DataTable dtboja)
    {
        try
        {

            string[] array = Convert.ToString(Session["Owner_name"]).Split('#');


            string[] arrmut_data = Convert.ToString(Session["MutationDetail"]).Split('#');

            createTable(ref dtboja, "optype,ccode,mut_no,mut_type,Mut_name,mut_date,mut_info_date,khata_no,seller_khata_no,information,user_name,khata_type");
            DataRow dr = dtboja.NewRow();
            dr["khata_type"] = ddlkhatatype.SelectedItem.Value;

            //fields of mut_register
            dr["ccode"] = Convert.ToString(Session["ccode"]);
            dr["khata_no"] = Convert.ToString(Session["khata_no"]);
            dr["seller_khata_no"] = array[0];
            dr["user_name"] = (string)Session["UserName"];
            dtboja.Rows.Add(dr);
            dtboja.AcceptChanges();
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void btnNameDelBack_Click(object sender, EventArgs e)
    {
        try
        {
            #region[--validations of khata type --]
            int cnt_owners = gdvOldNamesDel.Rows.Count;
            string status = "";
            if (Convert.ToInt32(Session["khata_type_del"]) == 1)
            {
                if (cnt_owners == 1)
                {
                    status = "OK";
                }
                else
                {
                    status = "NOT OK";
                }

            }
            else if (Convert.ToInt32(Session["khata_type_del"]) == 2 || Convert.ToInt32(Session["khata_type_del"]) == 3)
            {
                if (cnt_owners == 1)
                {
                    status = "NOT OK";
                }
                else
                {
                    status = "OK";
                }
            }
            else
            {
                status = "OK";
            }



            #endregion[--validations of khata type --]

            if (status == "OK")
            {

                // string _connectionString = Convert.ToString(Session["DataBaseName"]).Split('#')[0] + "database = " + Convert.ToString(Session["DataBaseName"]).Split('#')[1] + ";" + (string)System.Configuration.ConfigurationManager.ConnectionStrings["Database Connection String"].ConnectionString.ToString();
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
                            //-----
                            try
                            {
                                if (ddlkhatatypeDel.SelectedItem.Text.ToString() != "--निवडा--")
                                {
                                    con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "khata_type=" + Session["khata_type_del"].ToString() + "", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "'", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "' and khata_type=" + Session["khata_type_del"].ToString() + "", ref dbCommand, Convert.ToString(Session["UserName"]));

                                    int khata_confirm_chk = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  khata_no_status = true and trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "'", "");
                                    if (khata_confirm_chk > 0)
                                    {
                                        con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "khata_no_status=false", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "'", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    }
                                }




                                //--------
                                //  Session["khata_no"] = null;
                                Session["editf7k_del"] = null;
                                Session["khata_type"] = null;
                                lblSelectedKhatatype.Visible = false;
                                lblnewKhataType.Visible = false;
                                ViewState["grdOldkhata"] = null;
                                ViewState["ds_pins"] = null;
                                Session["ds_names_delete"] = null;

                                lblKhataTypeDelNew.Visible = false;
                                lblKhataTypeDelDispNew.Visible = false;
                                Session["khata_type_del"] = null;
                                Session["khata_name_del"] = null;

                                //  DataSet ds_editf7 = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata", "(khata_no::int) as seller_khata_no,fname,mname,lname,topan_name,total_area_h as seller_area_tot,assessment as na_assessment,anne::int,pai,potkharaba,usrno,cast(0 as int) as tenure_code,'' as Checked,marked,mut_no,edit_flag", "ccode = '" + Convert.ToString(Session["ccode"]) + "'and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "' and pin6='" + Convert.ToString(Session["pin6"]) + "'  and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8 ='" + Convert.ToString(Session["pin8"]) + "' and  khata_no<>'' and   edit_trans_no=" + Convert.ToInt32(Session["village_trans_cnt"]) + " and edit_flag<>'34'", "khata_no::int,usrno ");
                                DataSet ds_editf7kp = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "distinct (khata_no::int) as seller_khata_no,fname,mname,lname,topan_name", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and  khata_no ='" + Convert.ToString(Session["khata_no"]) + "' and  khata_no<>''  and edit_flag<>'34' and edit_flag<>'40'", "khata_no::int ");
                                if (ds_editf7kp != null && ds_editf7kp.Tables[0].Rows.Count > 0)
                                {

                                    if (ds_editf7kp.Tables[0].Rows.Count == 1 && ddlkhatatypeDel.SelectedItem.Text.ToString() == "--निवडा--")
                                    {
                                        string popupScript = "<script language='javascript'>alert('योग्य खाता प्रकार निवडा.');</script>";
                                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                        ddlkhatatypeDel.SelectedIndex = -1;
                                        return;
                                    }

                                    lblkhataNamesCntDisp.Text = ds_editf7kp.Tables[0].Rows.Count.ToString();
                                    ViewState["orignal_sellers_ds"] = ds_editf7kp;
                                    gdvkhataDetails.DataSource = ds_editf7kp.Tables[0].DefaultView;
                                    gdvkhataDetails.DataBind();
                                    ViewState["Ds_toEnble"] = ds_editf7kp;
                                }
                                else
                                {
                                    if (Convert.ToString(Session["Name_Del"]) == "Yes")
                                    {
                                        gdvkhataDetails.DataSource = ds_editf7kp.Tables[0].DefaultView;
                                        gdvkhataDetails.DataBind();
                                        ViewState["Ds_toEnble"] = ds_editf7kp;
                                        Session["Name_Del"] = null;
                                    }
                                }
                                ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup_bhogvatdar').style.display = 'block';", true);

                                pnlOldNamesDel.Visible = false;
                                PaneNameDel.Visible = false;
                                Panellinks.Visible = true;
                                dbTransaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandling excpt = new ExceptionHandling();
                                if (Session["LoginID"] != null)
                                    Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
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

            else
            {
                string popupScript = "<script language='javascript'>alert('योग्य खाता प्रकार निवडा.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                ddlkhatatypeDel.SelectedIndex = -1;
                return;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void gdvOldNamesDel_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int cnt = gdvOldNamesDel.Rows.Count;
            Session["Name_Del"] = "Yes";
            int index = e.RowIndex;
            DataTable dt_names_delete = new DataTable();
            DataSet ds_names_delete = (DataSet)ViewState["ds_old_names_del"];
            dt_names_delete = ds_names_delete.Tables[0].Clone();

            DataRow dr_delete = dt_names_delete.NewRow();
            dr_delete["fname"] = ((TextBox)gdvOldNamesDel.Rows[index].FindControl("grd2text2")).Text;
            dr_delete["mname"] = ((TextBox)gdvOldNamesDel.Rows[index].FindControl("grd2text3")).Text;
            dr_delete["lname"] = ((TextBox)gdvOldNamesDel.Rows[index].FindControl("grd2text4")).Text;
            dr_delete["topan_name"] = ((TextBox)gdvOldNamesDel.Rows[index].FindControl("grd2text5")).Text;
            dr_delete["khata_no"] = ((Label)gdvOldNamesDel.Rows[index].FindControl("lblColumn1")).Text;
            dr_delete["khata_type"] = ((Label)gdvOldNamesDel.Rows[index].FindControl("lblColumn6")).Text;
            dr_delete["flag"] = "delete";
            dt_names_delete.Rows.Add(dr_delete);

            Session["dt_names_delete"] = dt_names_delete;
            foreach (DataRow dr_ in ds_names_delete.Tables[0].Select("fname='" + dr_delete["fname"] + "' and mname='" + dr_delete["mname"] + "' and lname='" + dr_delete["lname"] + "' and topan_name='" + dr_delete["topan_name"] + "' and khata_no='" + dr_delete["khata_no"] + "'"))
            {
                ds_names_delete.Tables[0].Rows.Remove(dr_);
            }

            Session["ds_names_delete"] = ds_names_delete;

            if (ds_names_delete.Tables[0].Rows.Count > 0)
            {
                btnNameDelBack.Enabled = true;
                gdvOldNamesDel.DataSource = ds_names_delete;
                gdvOldNamesDel.DataBind();
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
                                DataTable dt_pins = new DataTable();

                                if (ViewState["ds_pins"] != null)
                                {
                                    dt_pins = ((DataSet)ViewState["ds_pins"]).Tables[0];
                                }
                                DataTable dt_nameDel = (DataTable)Session["dt_names_delete"];
                                int cnt_editf7k_del = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "");
                                if (cnt_editf7k_del == 0)
                                {
                                    con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_khata_kp", " ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,khata_type,total_area_h,assessment, anne,pai,potkharaba, edit_trans_no,edit_appname,edit_flag", " ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,khata_type,total_area_h,assessment, anne,pai,potkharaba,'" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','31'", " ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", (string)Session["SchemaName"] + ".form7_khata", Convert.ToString(Session["UserName"]), ref dbCommand);
                                    DataTable dt_khata = new DataTable();
                                    dt_khata.Columns.Add("khata_no");
                                    int edit_hd = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + (Convert.ToString(Session["khata_no"])).Trim() + "' ", "");
                                    if (edit_hd == 0)
                                    {
                                        con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_holder_detail_kp", " ccode,fname, mname, lname, topan_name,khata_no, khata_type,edit_trans_no,edit_appname,edit_flag", " ccode, fname, mname, lname, topan_name,khata_no,khata_type,'" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','31'", " ccode = '" + (string)Session["ccode"] + "'   and trim(khata_no)='" + (Convert.ToString(Session["khata_no"])).Trim() + "'", (string)Session["SchemaName"] + ".holder_detail", Convert.ToString(Session["UserName"]), ref dbCommand);
                                    }
                                }
                                for (int i = 0; i < dt_nameDel.Rows.Count; i++)
                                {
                                    con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", " edit_flag='34'", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "' and  fname='" + Convert.ToString(dt_nameDel.Rows[i]["fname"]) + "' and  mname='" + Convert.ToString(dt_nameDel.Rows[i]["mname"]) + "' and  lname='" + Convert.ToString(dt_nameDel.Rows[i]["lname"]) + "' and topan_name='" + Convert.ToString(dt_nameDel.Rows[i]["topan_name"]) + "' ", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "' and  fname='" + Convert.ToString(dt_nameDel.Rows[i]["fname"]) + "' and  mname='" + Convert.ToString(dt_nameDel.Rows[i]["mname"]) + "' and  lname='" + Convert.ToString(dt_nameDel.Rows[i]["lname"]) + "' and  topan_name='" + Convert.ToString(dt_nameDel.Rows[i]["topan_name"]) + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                }


                                for (int i = 0; i < dt_nameDel.Rows.Count; i++)
                                {
                                    con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", " edit_flag='34' ", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "' and fname='" + Convert.ToString(dt_nameDel.Rows[i]["fname"]) + "' and mname='" + Convert.ToString(dt_nameDel.Rows[i]["mname"]) + "' and  lname='" + Convert.ToString(dt_nameDel.Rows[i]["lname"]) + "' and  topan_name='" + Convert.ToString(dt_nameDel.Rows[i]["topan_name"]) + "'", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "' and fname='" + Convert.ToString(dt_nameDel.Rows[i]["fname"]) + "' and  mname='" + Convert.ToString(dt_nameDel.Rows[i]["mname"]) + "' and  lname='" + Convert.ToString(dt_nameDel.Rows[i]["lname"]) + "' and  topan_name='" + Convert.ToString(dt_nameDel.Rows[i]["topan_name"]) + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                }

                                if (ddlkhatatypeDel.SelectedItem.Text.ToString() != "--निवडा--")
                                {
                                    con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "khata_type=" + Session["khata_type_del"].ToString() + "", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "' and khata_type=" + Session["khata_type_del"].ToString() + "", ref dbCommand, Convert.ToString(Session["UserName"]));
                                }

                                int khata_confirm_chk = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  khata_no_status = true and trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "'", "");
                                if (khata_confirm_chk > 0)
                                {
                                    con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "khata_no_status=false", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                }
                                dbTransaction.Commit();
                                gdvOldNamesDel.DataSource = null;
                                lblSurveyList.Visible = false;
                                string popupScript = "<script language='javascript'>alert('माहिती साठवली आहे.');</script>";
                                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                return;
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandling excpt = new ExceptionHandling();
                                if (Session["LoginID"] != null)
                                    Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
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
            else
            {


                string khata_type = string.Empty;
                if (ddlkhatatypeDel.SelectedItem.Text.ToString() == "--निवडा--")
                {
                    khata_type = "Error";
                }
                if (khata_type == "Error")
                {
                    btnNameDelBack.Enabled = false;
                    string popupScript = "<script language='javascript'>alert('या खात्यामध्ये एकच नाव राहिल्यामुळे ह्या खात्यातुन नाव काढता येनार नाही.  तसेच योग्य खाता प्रकार निवडा. ');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
                else
                {
                    btnNameDelBack.Enabled = false;
                    string popupScript = "<script language='javascript'>alert('या खात्यामध्ये एकच नाव राहिल्यामुळे ह्या खात्यातुन नाव काढता येनार नाही. ');</script>";
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
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void ddlkhatatypeDel_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlkhatatypeDel.SelectedItem.Text.ToString() != "--निवडा--")
            {
                Session["khata_type_del"] = ddlkhatatypeDel.SelectedItem.Value;
                Session["khata_name_del"] = ddlkhatatypeDel.SelectedItem.Text;
                lblSelectedKhatatype.Visible = true;
                lblKhataTypeDelDispNew.Visible = true;
                lblKhataTypeDelDispNew.Text = ddlkhatatypeDel.SelectedItem.Text;
                lblKhataTypeDisp.Text = ddlkhatatypeDel.SelectedItem.Text;
                btnNameDelBack.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            pnlgdvNewBhogvatdar.Visible = true;
            DataSet ds_old_names = (DataSet)ViewState["ds_old_names"];
            DataTable dt_old_names_change = ds_old_names.Tables[0].Clone();
            int flag = 1;
            foreach (GridViewRow gdvr in gdvOldNames.Rows)
            {
                if (((CheckBox)gdvr.FindControl("chkSelect")).Checked == true)
                {
                    DataRow dr = dt_old_names_change.NewRow();
                    dr["fname"] = ((TextBox)gdvr.FindControl("grd2text2")).Text;
                    dr["mname"] = ((TextBox)gdvr.FindControl("grd2text3")).Text;
                    dr["lname"] = ((TextBox)gdvr.FindControl("grd2text4")).Text;
                    dr["topan_name"] = ((TextBox)gdvr.FindControl("grd2text5")).Text;
                    dr["khata_no"] = ((Label)gdvr.FindControl("lblColumn1")).Text;
                    dr["khata_type"] = ((Label)gdvr.FindControl("lblColumn6")).Text;
                    dr["flag"] = flag;
                    dt_old_names_change.Rows.Add(dr);
                    flag = flag + 1;
                    btn.Visible = true;
                }
                Session["dt_new_names_change"] = dt_old_names_change;
                gdvNewNames.Visible = true;
                gdvNewNames.DataSource = dt_old_names_change.DefaultView;
                gdvNewNames.DataBind();
                Session["dt_old_names_change"] = dt_old_names_change;
            }
            if (flag == 1)
            {
                string popupScript122 = "<script language='javascript'>alert('ज्या नावांची स्पेलिंग दुरुस्ती करावयाची आहे ती नावे निवडा.' );</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript122);
                return;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        try
        {
            pnlgdvNewBhogvatdar.Visible = false;
            DataSet ds_new_names = (DataSet)ViewState["ds_old_names"];
            DataTable dt_new_names_change = ds_new_names.Tables[0].Clone();
            int flag = 1;
            foreach (GridViewRow gdvr in gdvNewNames.Rows)
            {
                DataRow dr = dt_new_names_change.NewRow();
                dr["fname"] = ((TextBox)gdvr.FindControl("grd2text2")).Text;
                dr["mname"] = ((TextBox)gdvr.FindControl("grd2text3")).Text;
                dr["lname"] = ((TextBox)gdvr.FindControl("grd2text4")).Text;
                dr["topan_name"] = ((TextBox)gdvr.FindControl("grd2text5")).Text;
                dr["khata_no"] = ((Label)gdvr.FindControl("lblColumn1")).Text;
                dr["khata_type"] = ((Label)gdvr.FindControl("lblColumn6")).Text;
                dr["flag"] = flag;
                dt_new_names_change.Rows.Add(dr);
                flag = flag + 1;

            }

            if (dt_new_names_change.Rows.Count > 0)
            {
                Session["dt_new_names_change"] = dt_new_names_change;
            }

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
                        //-----
                        try
                        {
                            DataTable dt_pins = new DataTable();
                            if (ViewState["ds_pins"] != null)
                            {
                                dt_pins = ((DataSet)ViewState["ds_pins"]).Tables[0];
                            }
                            lblmsgSpell.Visible = false;
                            lblmsgSpell.Text = "";
                            dt_new_names_change = (DataTable)Session["dt_new_names_change"];
                            DataTable dt_old_names_change = (DataTable)Session["dt_old_names_change"];
                            int cnt_editf7k_spell = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and   khata_no ='" + Convert.ToString(Session["khata_no"]) + "'  ", "");
                            if (cnt_editf7k_spell == 0)
                            {
                                con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_khata_kp", " ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,khata_type,total_area_h,assessment, anne,pai,potkharaba, edit_trans_no,edit_appname,edit_flag", " ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,khata_type,total_area_h,assessment, anne,pai,potkharaba,'" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','31'", " ccode = '" + (string)Session["ccode"] + "' and  khata_no ='" + Convert.ToString(Session["khata_no"]) + "' ", (string)Session["SchemaName"] + ".form7_khata", Convert.ToString(Session["UserName"]), ref dbCommand);
                                DataTable dt_khata = new DataTable();
                                dt_khata.Columns.Add("khata_no");
                                cnt_editf7k_spell = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and trim(khata_no)='" + (Convert.ToString(Session["khata_no"])).Trim() + "'", "");
                                if (cnt_editf7k_spell == 0)
                                {
                                    con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_holder_detail_kp", " ccode,fname, mname, lname, topan_name,khata_no, khata_type,edit_trans_no,edit_appname,edit_flag", " ccode, fname, mname, lname, topan_name,khata_no,khata_type, '" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','31'", " ccode = '" + (string)Session["ccode"] + "'   and khata_no='" + (Convert.ToString(Session["khata_no"])).Trim() + "'", (string)Session["SchemaName"] + ".holder_detail", Convert.ToString(Session["UserName"]), ref dbCommand);
                                }

                            }


                            //if (ViewState["ds_pins"] != null)
                            //{
                            //foreach (DataRow drpins in dt_pins.Rows)
                            //{
                            for (int i = 0; i < dt_old_names_change.Rows.Count; i++)
                            {
                                for (int j = 0; j < dt_new_names_change.Rows.Count; j++)
                                {
                                    if (i == j)
                                    {
                                        con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "fname='" + Convert.ToString(dt_new_names_change.Rows[i]["fname"]).Trim() + "' ,  mname='" + Convert.ToString(dt_new_names_change.Rows[i]["mname"]).Trim() + "' ,  lname='" + Convert.ToString(dt_new_names_change.Rows[i]["lname"]).Trim() + "' ,  topan_name='" + Convert.ToString(dt_new_names_change.Rows[i]["topan_name"]).Trim() + "', edit_flag='33'", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "' and  fname='" + Convert.ToString(dt_old_names_change.Rows[j]["fname"]) + "' and  mname='" + Convert.ToString(dt_old_names_change.Rows[j]["mname"]) + "' and  lname='" + Convert.ToString(dt_old_names_change.Rows[j]["lname"]) + "' and  topan_name='" + Convert.ToString(dt_old_names_change.Rows[j]["topan_name"]) + "'", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "' and  fname='" + Convert.ToString(dt_new_names_change.Rows[i]["fname"]) + "' and  mname='" + Convert.ToString(dt_new_names_change.Rows[i]["mname"]) + "' and  lname='" + Convert.ToString(dt_new_names_change.Rows[i]["lname"]) + "' and  topan_name='" + Convert.ToString(dt_new_names_change.Rows[i]["topan_name"]) + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    }
                                }
                            }
                            //}
                            // }
                            //else
                            //{
                            //    for (int i = 0; i < dt_old_names_change.Rows.Count; i++)
                            //    {
                            //        for (int j = 0; j < dt_new_names_change.Rows.Count; j++)
                            //        {
                            //            if (i == j)
                            //            {
                            //                con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata", "fname='" + Convert.ToString(dt_new_names_change.Rows[i]["fname"]).Trim() + "' ,  mname='" + Convert.ToString(dt_new_names_change.Rows[i]["mname"]).Trim() + "' ,  lname='" + Convert.ToString(dt_new_names_change.Rows[i]["lname"]).Trim() + "' ,  topan_name='" + Convert.ToString(dt_new_names_change.Rows[i]["topan_name"]).Trim() + "', edit_flag='33'", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "' and  trim(fname)='" + Convert.ToString(dt_old_names_change.Rows[j]["fname"]).Trim() + "' and  trim(mname)='" + Convert.ToString(dt_old_names_change.Rows[j]["mname"]).Trim() + "' and  trim(lname)='" + Convert.ToString(dt_old_names_change.Rows[j]["lname"]).Trim() + "' and  trim(topan_name)='" + Convert.ToString(dt_old_names_change.Rows[j]["topan_name"]).Trim() + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and  pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "' and pin6='" + Convert.ToString(Session["pin6"]) + "'  and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8 ='" + Convert.ToString(Session["pin8"]) + "' ", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "' and  trim(fname)='" + Convert.ToString(dt_new_names_change.Rows[i]["fname"]).Trim() + "' and  trim(mname)='" + Convert.ToString(dt_new_names_change.Rows[i]["mname"]).Trim() + "' and  trim(lname)='" + Convert.ToString(dt_new_names_change.Rows[i]["lname"]).Trim() + "' and  trim(topan_name)='" + Convert.ToString(dt_new_names_change.Rows[i]["topan_name"]).Trim() + "' and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and  pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "' and pin6='" + Convert.ToString(Session["pin6"]) + "'  and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8 ='" + Convert.ToString(Session["pin8"]) + "' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                            //            }
                            //        }
                            //    }
                            //}

                            for (int i = 0; i < dt_old_names_change.Rows.Count; i++)
                            {
                                for (int j = 0; j < dt_new_names_change.Rows.Count; j++)
                                {
                                    if (i == j)
                                    {
                                        con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "fname='" + Convert.ToString(dt_new_names_change.Rows[i]["fname"]).Trim() + "' ,  mname='" + Convert.ToString(dt_new_names_change.Rows[i]["mname"]).Trim() + "' ,  lname='" + Convert.ToString(dt_new_names_change.Rows[i]["lname"]).Trim() + "' ,  topan_name='" + Convert.ToString(dt_new_names_change.Rows[i]["topan_name"]).Trim() + "',edit_flag='33'", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "' and fname='" + Convert.ToString(dt_old_names_change.Rows[j]["fname"]) + "' and  mname='" + Convert.ToString(dt_old_names_change.Rows[j]["mname"]) + "' and  lname='" + Convert.ToString(dt_old_names_change.Rows[j]["lname"]) + "' and  topan_name='" + Convert.ToString(dt_old_names_change.Rows[j]["topan_name"]) + "'", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "' and fname='" + Convert.ToString(dt_new_names_change.Rows[i]["fname"]) + "' and  mname='" + Convert.ToString(dt_new_names_change.Rows[i]["mname"]) + "' and  lname='" + Convert.ToString(dt_new_names_change.Rows[i]["lname"]) + "' and  topan_name='" + Convert.ToString(dt_new_names_change.Rows[i]["topan_name"]) + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    }
                                }
                            }

                            int khata_confirm_chk = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  khata_no_status = true and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "");
                            if (khata_confirm_chk > 0)
                            {
                                con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "khata_no_status=false", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + Convert.ToString(Session["khata_no"]) + "'", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                            }
                            dbTransaction.Commit();
                            btn.Enabled = false;

                            lblmsgSpell.Visible = true;
                            lblmsgSpell.Text = "माहिती साठवली आहे.";

                            lblKhataNoNamesSpell.Text = "";
                            gdvNewNames.DataSource = null;
                            gdvOldNames.DataSource = null;
                            gdvOldNames.Visible = false;
                            gdvNewNames.Visible = false;
                            lblSurveyListDispaly.Text = "";
                            lblSurveyList.Visible = false;
                            btnAdd.Visible = false;
                            btn.Visible = false;
                            lblKhataNoSpellCorr.Visible = false;
                            lblSurveyDisp.Visible = false;
                        }

                        catch (Exception ex)
                        {

                            ExceptionHandling excpt = new ExceptionHandling();
                            if (Session["LoginID"] != null)
                                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
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
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void btnNameCorrBack_Click(object sender, EventArgs e)
    {
        try
        {
            pnlgdvNewBhogvatdar.Visible = false;
            ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup_bhogvatdar').style.display = 'block';", true);
            pnlNameAdd.Visible = false;
            lblSelectedKhatatype.Visible = false;
            lblnewKhataType.Visible = false;
            lblnewKhataType.Text = "";
            PnlNameCorr.Visible = false;
            //--------

            // Session["khata_no"] = null;
            Session["editf7k_add"] = null;
            //   Session["khata_type_old"] = null;
            Session["khata_type"] = null;
            Session["khata_name"] = null;
            lblSelectedKhatatype.Visible = false;
            lblnewKhataType.Visible = false;
            ViewState["grdOldkhata"] = null;
            gdvNewNames.DataSource = null;
            gdvNewNames.DataBind();
            // ----------
            DataSet ds_editf7 = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "distinct (khata_no::int) as seller_khata_no,fname,mname,lname,topan_name", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "' and  khata_no<>''  and edit_flag<>'34' and edit_flag<>'40'", "khata_no::int ");
            if (ds_editf7 != null && ds_editf7.Tables[0].Rows.Count > 0)
            {
                gdvkhataDetails.DataSource = ds_editf7.Tables[0].DefaultView;
                gdvkhataDetails.DataBind();
                ViewState["orignal_sellers_ds"] = ds_editf7;
                ViewState["Ds_toEnble"] = ds_editf7;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void gdvNewNames_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void chkselect_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvr = ((GridViewRow)((Control)sender).Parent.Parent);
            if (((CheckBox)gvr.FindControl("chkSelect")).Checked == true)
            {
                Label lblKhata = (Label)gvr.FindControl("lblColumn1");
                Session["khata_no"] = lblKhata.Text;
                Session["khata_type_old"] = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".holder_detail h , " + Convert.ToString(Session["SchemaName"]) + ".m_khata_type m", "khata_description", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no ='" + Session["khata_no"].ToString() + "' and h.khata_type=m.khata_type", "");
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void chkeffect_CheckedChanged(object sender, EventArgs e)
    {
        
    }
    protected void ddlKhataTypechangeKhataTypeNew_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlKhataTypechangeKhataTypeNew.SelectedItem.Text.ToString() != "--निवडा--")
            {
                Session["khata_type_change"] = ddlKhataTypechangeKhataTypeNew.SelectedItem.Value;
                Session["khata_name_change"] = ddlKhataTypechangeKhataTypeNew.SelectedItem.Text;
                lblKhataTypechangeKhataTypeNew.Visible = true;
                lblKhataTypechangeKhataTypeNewDisp.Visible = true;
                lblKhataTypechangeKhataTypeNewDisp.Text = ddlKhataTypechangeKhataTypeNew.SelectedItem.Text;
                lblKhataTypeDisp.Text = ddlKhataTypechangeKhataTypeNew.SelectedItem.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void btnkhataTypeChngeSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlKhataTypechangeKhataTypeNew.SelectedItem.Text.ToString() != "--निवडा--")
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
                                #region[--validations of khata type --]
                                int cnt_owners = grdkhataTypechangeNames.Rows.Count;
                                string status = "";
                                if (Convert.ToInt32(Session["khata_type_change"]) == 1)
                                {
                                    if (cnt_owners == 1)
                                    {
                                        status = "OK";
                                    }
                                    else
                                    {
                                        status = "NOT OK";
                                    }

                                }
                                else if (Convert.ToInt32(Session["khata_type_change"]) == 2 || Convert.ToInt32(Session["khata_type_change"]) == 3)
                                {
                                    if (cnt_owners == 1)
                                    {
                                        status = "NOT OK";
                                    }
                                    else
                                    {
                                        status = "OK";
                                    }
                                }
                                else
                                {
                                    status = "OK";
                                }

                                #endregion[--validations of khata type --]

                                if (status == "OK")
                                {

                                    if (ViewState["ds_pins"] != null)
                                    {
                                        DataTable dt_pins = ((DataSet)ViewState["ds_pins"]).Tables[0];
                                    }

                                    int cnt_editf7k_ktc = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "' ", "");
                                    if (cnt_editf7k_ktc == 0)
                                    {
                                        con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_khata_kp", " ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,khata_type,total_area_h,assessment, anne,pai,potkharaba, edit_trans_no,edit_appname,edit_flag", " ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,khata_type,total_area_h,assessment, anne,pai,potkharaba,'" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','31'", " ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "'", (string)Session["SchemaName"] + ".form7_khata", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_holder_detail_kp", " ccode,fname, mname, lname, topan_name,khata_no, khata_type,edit_trans_no,edit_appname,edit_flag", " ccode, fname, mname, lname, topan_name,khata_no,khata_type,'" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','31'", " ccode = '" + (string)Session["ccode"] + "'   and khata_no='" + (Convert.ToString(Session["khata_no"])) + "'", (string)Session["SchemaName"] + ".holder_detail", Convert.ToString(Session["UserName"]), ref dbCommand);
                                    }
                                    con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "khata_type=" + Session["khata_type_change"].ToString() + "", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "'", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "' and khata_type=" + Session["khata_type_change"].ToString() + "", ref dbCommand, Convert.ToString(Session["UserName"]));

                                    int khata_confirm_chk = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  khata_no_status = true and trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "'", "");
                                    if (khata_confirm_chk > 0)
                                    {
                                        con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "khata_no_status=false", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "'", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    }
                                    dbTransaction.Commit();
                                    lblktc.Visible = true;
                                    lblktc.Text = "माहिती साठवली आहे.";
                                    btnkhataTyypeChngeBack.Enabled = true;
                                    lblKhataNoNamesSpell.Text = "";
                                    grdkhataTypechangeNames.DataSource = null;
                                    khataTypeChangeSurveyDisp.Text = "";
                                    Session["khata_type_change"] = null;
                                    Session["khata_name_change"] = null;
                                }
                                else
                                {
                                    btnkhataTyypeChngeBack.Enabled = false;
                                    string popupScript = "<script language='javascript'>alert('योग्य खाता प्रकार निवडा.');</script>";
                                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                    ddlKhataTypechangeKhataTypeNew.SelectedIndex = -1;
                                    return;
                                }
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandling excpt = new ExceptionHandling();
                                if (Session["LoginID"] != null)
                                    Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
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
            else
            {
                btnkhataTyypeChngeBack.Enabled = false;
                lblktc.Visible = true;
                lblktc.Text = "खाता प्रकार निवडा ";
                return;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }
    }
    protected void btnkhataTyypeChngeBack_Click(object sender, EventArgs e)
    {

        try
        {
            #region[--validations of khata type --]
            int cnt_owners = grdkhataTypechangeNames.Rows.Count;
            string status = "";
            if (Convert.ToInt32(Session["khata_type_change"]) == 1)
            {
                if (cnt_owners == 1)
                {
                    status = "OK";
                }
                else
                {
                    status = "NOT OK";
                }

            }
            else if (Convert.ToInt32(Session["khata_type_change"]) == 2 || Convert.ToInt32(Session["khata_type_change"]) == 3)
            {
                if (cnt_owners == 1)
                {
                    status = "NOT OK";
                }
                else
                {
                    status = "OK";
                }
            }
            else
            {
                status = "OK";
            }

            #endregion[---validations of khata type ---]

            if (status == "OK")
            {
                Panellinks.Enabled = true;
                ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup_bhogvatdar').style.display = 'block';", true);

                pnlkhataType.Visible = false;
                panelkhataTypechangeNames.Visible = false;

                //--------
                khataTypeChangeSurvey.Visible = false;
                khataTypeChangeSurveyDisp.Text = null;
                grdkhataTypechangeNames.DataSource = null;
                // Session["khata_no"] = null;

                lblSelectedKhatatype.Visible = false;
                lblnewKhataType.Visible = false;
                ViewState["grdOldkhata"] = null;
                ViewState["ds_pins"] = null;


                lblKhataTypechangeKhataTypeOldDisp.Visible = false;
                lblKhataTypechangeKhataTypeNewDisp.Visible = false;
                Session["khata_type_change"] = null;
                Session["khata_name_change"] = null;



                //DataSet ds_editf7 = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata", "(khata_no::int) as seller_khata_no,fname,mname,lname,topan_name,total_area_h as seller_area_tot,assessment as na_assessment,anne::int,pai,potkharaba,usrno,cast(0 as int) as tenure_code,'' as Checked,marked,mut_no,edit_flag", "ccode = '" + Convert.ToString(Session["ccode"]) + "'and pin='" + Convert.ToString(Session["pin"]) + "' and pin1='" + Convert.ToString(Session["pin1"]) + "' and pin2='" + Convert.ToString(Session["pin2"]) + "' and pin3='" + Convert.ToString(Session["pin3"]) + "' and pin4='" + Convert.ToString(Session["pin4"]) + "' and pin5='" + Convert.ToString(Session["pin5"]) + "' and pin6='" + Convert.ToString(Session["pin6"]) + "'  and pin7='" + Convert.ToString(Session["pin7"]) + "' and pin8 ='" + Convert.ToString(Session["pin8"]) + "' and  khata_no<>'' and edit_trans_no=" + Convert.ToInt32(Session["village_trans_cnt"]) + " and edit_flag<>'34'", "khata_no::int,usrno ");
                DataSet ds_editf7 = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", " distinct (khata_no::int) as seller_khata_no,fname,mname,lname,topan_name", "ccode = '" + Convert.ToString(Session["ccode"]) + "'and khata_no='" + Convert.ToString(Session["khata_no"]) + "' and  khata_no<>''  and edit_flag<>'34' and edit_flag<>'40'", "khata_no::int ");




                if (ds_editf7 != null && ds_editf7.Tables[0].Rows.Count > 0)
                {

                    ViewState["orignal_sellers_ds"] = ds_editf7;
                    gdvkhataDetails.DataSource = ds_editf7.Tables[0].DefaultView;

                    gdvkhataDetails.DataBind();
                    ViewState["Ds_toEnble"] = ds_editf7;
                    //for (int i = 0; i < ds_editf7.Tables[0].Rows.Count; i++)
                    //{
                    //    CheckBox chk = (CheckBox)gdvOldBhogvatdar1.Rows[i].FindControl("chkbrk");
                    //    CheckBox chkbrkRem = (CheckBox)gdvOldBhogvatdar1.Rows[i].FindControl("chkbrkRem");
                    //    if (ds_editf7.Tables[0].Rows[i]["Checked"].ToString() == "YES")
                    //        chk.Checked = true;
                    //    else
                    //        chk.Checked = false;

                    //    if (ds_editf7.Tables[0].Rows[i]["marked"].ToString() == "Y")
                    //    {
                    //        chk.Enabled = false;
                    //        chkbrkRem.Checked = true;
                    //    }
                    //    else
                    //        chkbrkRem.Checked = false;
                    // }
                }
            }
            else
            {
                Panellinks.Enabled = false;
                string popupScript = "<script language='javascript'>alert('योग्य खाता प्रकार निवडा.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                ddlkhatatype.SelectedIndex = -1;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

        }


    }
    protected void btnKhataConfirm_Click(object sender, EventArgs e)
    {
        Response.Redirect("pgKhataConfirmation.aspx", false);
    }

    public Boolean prev()
    {
        try
        {
            DataTable dseditf7k_spell_correction = obj.funReturnDataTable((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_audit", "distinct  khata_no ,fname ,mname,lname,topan_name ,operation ,edit_flag,sr_no", "ccode='" + (string)Session["ccode"] + "' and trim(khata_no)= '" + txtKhataNo.Text.ToString().Trim() + "' and edit_flag  in ('31','33') and operation in ('OLD','NEW' )  and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8   from " + Session["SchemaName"].ToString() + ".edit_mut where ccode='" + (string)Session["ccode"] + "' and  marked_flag='Edit' and confirm_flag<>'Confirm' and approve_flag='Approve')", "sr_no");
            if (dseditf7k_spell_correction != null && dseditf7k_spell_correction.Rows.Count > 0)
            {
                DataTable dt_spell = dseditf7k_spell_correction.Clone();
                DataTable dt_spell_survey = dseditf7k_spell_correction.Clone();
                if (dseditf7k_spell_correction != null && dseditf7k_spell_correction.Rows.Count > 0)
                {
                    for (int i = 0; i < dseditf7k_spell_correction.Rows.Count - 1; i++)
                    {
                        if (dseditf7k_spell_correction.Rows[i]["operation"].ToString().Trim() == "OLD" && dseditf7k_spell_correction.Rows[i]["edit_flag"].ToString().Trim() == "31")
                        {
                            if (i < dseditf7k_spell_correction.Rows.Count)
                            {
                                if (dseditf7k_spell_correction.Rows.Count > 1)
                                {
                                    if (dseditf7k_spell_correction.Rows[i + 1]["operation"].ToString().Trim() == "NEW" && dseditf7k_spell_correction.Rows[i + 1]["edit_flag"].ToString().Trim() == "33")
                                    {
                                        if (dseditf7k_spell_correction.Rows[i]["fname"].ToString() != dseditf7k_spell_correction.Rows[i + 1]["fname"].ToString() || dseditf7k_spell_correction.Rows[i]["mname"].ToString() != dseditf7k_spell_correction.Rows[i + 1]["mname"].ToString() || dseditf7k_spell_correction.Rows[i]["lname"].ToString() != dseditf7k_spell_correction.Rows[i + 1]["lname"].ToString() || dseditf7k_spell_correction.Rows[i]["topan_name"].ToString() != dseditf7k_spell_correction.Rows[i + 1]["topan_name"].ToString())
                                        {
                                            if (dseditf7k_spell_correction.Rows[i]["khata_no"].ToString() == dseditf7k_spell_correction.Rows[i + 1]["khata_no"].ToString())
                                            {
                                                if (Convert.ToInt32(dseditf7k_spell_correction.Rows[i]["sr_no"]) == (Convert.ToInt32(dseditf7k_spell_correction.Rows[i + 1]["sr_no"]) - 1))
                                                {

                                                    DataRow dr = dt_spell.NewRow();
                                                    dr["khata_no"] = dseditf7k_spell_correction.Rows[i]["khata_no"].ToString();
                                                    dr["fname"] = dseditf7k_spell_correction.Rows[i]["fname"].ToString();
                                                    dr["mname"] = dseditf7k_spell_correction.Rows[i]["mname"].ToString();
                                                    dr["lname"] = dseditf7k_spell_correction.Rows[i]["lname"].ToString();
                                                    dr["topan_name"] = dseditf7k_spell_correction.Rows[i]["topan_name"].ToString();
                                                    dt_spell.Rows.Add(dr);

                                                }
                                            }
                                        }
                                        i = i + 1;
                                    }
                                }
                            }
                        }
                    }
                }

                if (dt_spell != null && dt_spell.Rows.Count > 0)
                {
                    DataTable dt = dt_spell.Clone();
                    for (int i = 0; i < dt_spell.Rows.Count; i++)
                    {
                        // int cnt_hd = con.funReturnSingleValueInt((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".holder_detail", " count(*)", " ccode='" + (string)Session["ccode"] + "' and trim(khata_no)='" + dt_spell.Rows[i]["khata_no"].ToString().Trim() + "' and trim(fname)='" + dt_spell.Rows[i]["fname"].ToString().Trim() + "' and trim(mname)='" + dt_spell.Rows[i]["mname"].ToString().Trim() + "' and trim(lname)='" + dt_spell.Rows[i]["lname"].ToString().Trim() + "' and trim(topan_name)='" + dt_spell.Rows[i]["topan_name"].ToString().Trim() + "'", "");
                        int cnt_hd = con.funReturnSingleValueInt((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".holder_detail", " count(*)", " ccode='" + (string)Session["ccode"] + "' and trim(khata_no)='" + dt_spell.Rows[i]["khata_no"].ToString().Trim() + "' and fname='" + dt_spell.Rows[i]["fname"].ToString() + "' and mname='" + dt_spell.Rows[i]["mname"].ToString() + "' and lname='" + dt_spell.Rows[i]["lname"].ToString() + "' and topan_name='" + dt_spell.Rows[i]["topan_name"].ToString() + "'", "");
                        if (cnt_hd > 0)
                        {
                            DataRow dr = dt.NewRow();
                            dr["khata_no"] = dt_spell.Rows[i]["khata_no"].ToString();
                            dr["fname"] = dt_spell.Rows[i]["fname"].ToString();
                            dr["mname"] = dt_spell.Rows[i]["mname"].ToString();
                            dr["lname"] = dt_spell.Rows[i]["lname"].ToString();
                            dr["topan_name"] = dt_spell.Rows[i]["topan_name"].ToString();
                            dt.Rows.Add(dr);
                        }
                    }

                    if (dt.Rows.Count > 0)
                    {
                        dt = dt.DefaultView.ToTable(true, "khata_no", "fname", "mname", "lname", "topan_name");
                        Session["dt"] = dt;
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }


            }
            else
            {
                return false;
            }
        }
   
          catch (Exception ex)
        {
            
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            return false;

        }
}


    public Boolean spellCorrection()
    {
        try
        {
        DataTable dseditf7k_spell_correction = obj.funReturnDataTable((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_audit", "distinct  khata_no ,fname ,mname,lname,topan_name ,operation ,edit_flag,sr_no,'' as newfname , '' as newmname ,''as newlname,'' as newtopan_name", "ccode='" + (string)Session["ccode"] + "' and trim(khata_no) = '"+ txtKhataNo.Text.ToString().Trim()+"' and edit_flag  in ('31','33') and operation in ('OLD','NEW' )  and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8   from " + Session["SchemaName"].ToString() + ".edit_mut where ccode='" + (string)Session["ccode"] + "' and  marked_flag='Edit' and confirm_flag<>'Confirm' and approve_flag='Approve')", "sr_no");
        if (dseditf7k_spell_correction != null && dseditf7k_spell_correction.Rows.Count > 0)
        {
            DataTable dt_spell = dseditf7k_spell_correction.Clone();
            if (dseditf7k_spell_correction != null && dseditf7k_spell_correction.Rows.Count > 0)
            {
                for (int i = 0; i < dseditf7k_spell_correction.Rows.Count - 1; i++)
                {
                    if (dseditf7k_spell_correction.Rows[i]["operation"].ToString().Trim() == "OLD" && dseditf7k_spell_correction.Rows[i]["edit_flag"].ToString().Trim() == "31")
                    {
                        if (i < dseditf7k_spell_correction.Rows.Count)
                        {
                            if (dseditf7k_spell_correction.Rows.Count > 1)
                            {
                                if (dseditf7k_spell_correction.Rows[i + 1]["operation"].ToString().Trim() == "NEW" && dseditf7k_spell_correction.Rows[i + 1]["edit_flag"].ToString().Trim() == "33")
                                {
                                    if (dseditf7k_spell_correction.Rows[i]["fname"].ToString() != dseditf7k_spell_correction.Rows[i + 1]["fname"].ToString() || dseditf7k_spell_correction.Rows[i]["mname"].ToString() != dseditf7k_spell_correction.Rows[i + 1]["mname"].ToString() || dseditf7k_spell_correction.Rows[i]["lname"].ToString() != dseditf7k_spell_correction.Rows[i + 1]["lname"].ToString() || dseditf7k_spell_correction.Rows[i]["topan_name"].ToString() != dseditf7k_spell_correction.Rows[i + 1]["topan_name"].ToString())
                                    {
                                        if (dseditf7k_spell_correction.Rows[i]["khata_no"].ToString() == dseditf7k_spell_correction.Rows[i + 1]["khata_no"].ToString())
                                        {
                                            if (Convert.ToInt32(dseditf7k_spell_correction.Rows[i]["sr_no"]) == (Convert.ToInt32(dseditf7k_spell_correction.Rows[i + 1]["sr_no"]) - 1))
                                            {
                                                DataRow dr = dt_spell.NewRow();
                                                dr["khata_no"] = dseditf7k_spell_correction.Rows[i]["khata_no"].ToString();
                                                dr["fname"] = dseditf7k_spell_correction.Rows[i]["fname"].ToString();
                                                dr["mname"] = dseditf7k_spell_correction.Rows[i]["mname"].ToString();
                                                dr["lname"] = dseditf7k_spell_correction.Rows[i]["lname"].ToString();
                                                dr["topan_name"] = dseditf7k_spell_correction.Rows[i]["topan_name"].ToString();
                                                dr["topan_name"] = dseditf7k_spell_correction.Rows[i]["topan_name"].ToString();
                                                dr["newfname"] = dseditf7k_spell_correction.Rows[i + 1]["fname"].ToString();
                                                dr["newmname"] = dseditf7k_spell_correction.Rows[i + 1]["mname"].ToString();
                                                dr["newlname"] = dseditf7k_spell_correction.Rows[i + 1]["lname"].ToString();
                                                dr["newtopan_name"] = dseditf7k_spell_correction.Rows[i + 1]["topan_name"].ToString();
                                                dt_spell.Rows.Add(dr);
                                            }
                                        }
                                    }
                                    i = i + 1;
                                }
                            }
                        }
                    }

                }
            }

            if (dt_spell != null && dt_spell.Rows.Count > 0)
            {


                DataTable dt = dt_spell.Clone();
                for (int i = 0; i < dt_spell.Rows.Count; i++)
                {
                    //  int cnt_f7k = con.funReturnSingleValueInt((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".form7_khata", " count(*)", " ccode='" + (string)Session["ccode"] + "' and trim(khata_no)='" + dt_spell.Rows[i]["khata_no"].ToString().Trim() + "' and trim(fname)='" + dt_spell.Rows[i]["fname"].ToString().Trim() + "' and trim(mname)='" + dt_spell.Rows[i]["mname"].ToString().Trim() + "' and trim(lname)='" + dt_spell.Rows[i]["lname"].ToString().Trim() + "' and trim(topan_name)='" + dt_spell.Rows[i]["topan_name"].ToString().Trim() + "'", "");
                    int cnt_f7k = con.funReturnSingleValueInt((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".form7_khata", " count(*)", " ccode='" + (string)Session["ccode"] + "' and trim(khata_no)='" + dt_spell.Rows[i]["khata_no"].ToString().Trim() + "' and fname='" + dt_spell.Rows[i]["fname"].ToString() + "' and mname='" + dt_spell.Rows[i]["mname"].ToString() + "' and lname='" + dt_spell.Rows[i]["lname"].ToString() + "' and topan_name='" + dt_spell.Rows[i]["topan_name"].ToString() + "'", "");
                    if (cnt_f7k > 0)
                    {
                        cnt_f7k = con.funReturnSingleValueInt((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".form7_khata", " count(*)", " ccode='" + (string)Session["ccode"] + "' and trim(khata_no)='" + dt_spell.Rows[i]["khata_no"].ToString().Trim() + "' and fname='" + dt_spell.Rows[i]["fname"].ToString() + "' and mname='" + dt_spell.Rows[i]["mname"].ToString() + "' and lname='" + dt_spell.Rows[i]["lname"].ToString() + "' and topan_name='" + dt_spell.Rows[i]["topan_name"].ToString() + "'", "");
                        DataRow dr = dt.NewRow();
                        dr["khata_no"] = dt_spell.Rows[i]["khata_no"].ToString();
                        dr["fname"] = dt_spell.Rows[i]["fname"].ToString();
                        dr["mname"] = dt_spell.Rows[i]["mname"].ToString();
                        dr["lname"] = dt_spell.Rows[i]["lname"].ToString();
                        dr["topan_name"] = dt_spell.Rows[i]["topan_name"].ToString();
                        dr["newfname"] = dt_spell.Rows[i]["newfname"].ToString();
                        dr["newmname"] = dt_spell.Rows[i]["newmname"].ToString();
                        dr["newlname"] = dt_spell.Rows[i]["newlname"].ToString();
                        dr["newtopan_name"] = dt_spell.Rows[i]["newtopan_name"].ToString();
                        dt.Rows.Add(dr);
                    }
                }


                if (dt.Rows.Count > 0)
                {
                    dt = dt.DefaultView.ToTable(true, "khata_no", "fname", "mname", "lname", "topan_name", "newfname", "newmname", "newlname", "newtopan_name");
                    Session["dt"] = dt;
                    return true;

                }
                else
                {
                    return false;
                }



            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
        catch (Exception ex)
        {
            
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            return false;

        }
    }

    protected Boolean nameDupCheck_hd()
    {
        try
        {
            DataSet ds_holderdetails = obj.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".holder_detail ", "fname, mname ,lname, topan_name ,khata_no", "ccode = '" + Convert.ToString(Session["ccode"]) + "'and khata_no='" + Convert.ToString(Session["khata_no"]) + "' group by fname, mname ,lname, topan_name ,khata_no having count(*) > 1 ", "");

            if (ds_holderdetails.Tables.Count > 0 && ds_holderdetails.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {

            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            return false;

        }
        

    }
    protected void btnKhataDelOnSurvey_Click(object sender, EventArgs e)
    {
        try
        {
            int cnt = gdvOldNamesDel.Rows.Count;
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
                        //-----
                        try
                        {
                            DataTable dt_pins = new DataTable();
                            if (ViewState["dt_pin"] != null)
                            {
                                dt_pins = ((DataTable)ViewState["dt_pin"]);
                            }
                            int cnt_editf7k_del = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and    khata_no ='" + Convert.ToString(Session["khata_no"]) + "' ", "");
                            if (cnt_editf7k_del == 0)
                            {

                                cnt_editf7k_del = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "'  and  trim(khata_no)='" + (Convert.ToString(Session["khata_no"])).Trim() + "' ", "");
                                if (cnt_editf7k_del == 0)
                                    con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_khata_kp", " ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,khata_type,total_area_h,assessment, anne,pai,potkharaba, edit_trans_no,edit_appname,edit_flag", " ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,khata_type,total_area_h,assessment, anne,pai,potkharaba,'" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','31'", " ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + (Convert.ToString(Session["khata_no"])).Trim() + "' ", (string)Session["SchemaName"] + ".form7_khata", Convert.ToString(Session["UserName"]), ref dbCommand);
                                int edit_hd = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + (Convert.ToString(Session["khata_no"])).Trim() + "' ", "");
                                if (edit_hd == 0)
                                {
                                    con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_holder_detail_kp", " ccode,fname, mname, lname, topan_name,khata_no, khata_type,edit_trans_no,edit_appname,edit_flag", " ccode, fname, mname, lname, topan_name,khata_no,khata_type,'" + Convert.ToString(Session["village_trans_cnt"]) + "','reEdit','31'", " ccode = '" + (string)Session["ccode"] + "'   and trim(khata_no)='" + (Convert.ToString(Session["khata_no"])).Trim() + "'", (string)Session["SchemaName"] + ".holder_detail", Convert.ToString(Session["UserName"]), ref dbCommand);
                                }

                            }
                            if (ViewState["dt_pin"] != null)
                            {

                                foreach (DataRow drpins in dt_pins.Rows)
                                {
                                    con.funUpdatesEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", " edit_flag='40'", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "' and pin='" + Convert.ToString(drpins["pin"]) + "' and pin1='" + Convert.ToString(drpins["pin1"]) + "'  and pin2='" + Convert.ToString(drpins["pin2"]) + "'  and pin3='" + Convert.ToString(drpins["pin3"]) + "'  and pin4='" + Convert.ToString(drpins["pin4"]) + "'  and pin5='" + Convert.ToString(drpins["pin5"]) + "'  and pin6='" + Convert.ToString(drpins["pin6"]) + "'  and pin7='" + Convert.ToString(drpins["pin7"]) + "'  and pin8='" + Convert.ToString(drpins["pin8"]) + "'", "ccode = '" + (string)Session["ccode"] + "' and  trim(khata_no)='" + Convert.ToString(Session["khata_no"]).Trim() + "'  and pin='" + Convert.ToString(drpins["pin"]) + "' and pin1='" + Convert.ToString(drpins["pin1"]) + "'  and pin2='" + Convert.ToString(drpins["pin2"]) + "'  and pin3='" + Convert.ToString(drpins["pin3"]) + "'  and pin4='" + Convert.ToString(drpins["pin4"]) + "'  and pin5='" + Convert.ToString(drpins["pin5"]) + "'  and pin6='" + Convert.ToString(drpins["pin6"]) + "'  and pin7='" + Convert.ToString(drpins["pin7"]) + "'  and pin8='" + Convert.ToString(drpins["pin8"]) + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                }
                            }

                            dbTransaction.Commit();

                            string pincase = "rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||";
                            pincase += "(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||";
                            pincase += "(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||";
                            pincase += "(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||";
                            pincase += "(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||";
                            pincase += "(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  ||";
                            pincase += "(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||";
                            pincase += "(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  ||";
                            pincase += "(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')AS pins";
                            ViewState["lblSurveyList"] = "";
                            DataSet ds_pins = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", " distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + (Session["khata_no"]).ToString() + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  not in  ( select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + Session["SchemaName"].ToString() + ".edit_form7_khata_kp  where ccode = '" + Convert.ToString(Session["ccode"]) + "'  and khata_no='" + (Session["khata_no"]).ToString() + "' and  ( edit_flag='34' or edit_flag='40'  ) ) ", "");
                            DataSet dssurvey_khataAdd = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata_kp ", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "khata_no ='" + Session["khata_no"].ToString() + "' AND  ccode = '" + Convert.ToString(Session["ccode"]) + "' and edit_flag<>'34' and edit_flag<>'40'", "pin");
                            int pins_cnt = 1;
                            if (ds_pins.Tables.Count > 0 && ds_pins.Tables[0].Rows.Count > 0)
                            {
                                if (dssurvey_khataAdd != null && dssurvey_khataAdd.Tables.Count > 0 && dssurvey_khataAdd.Tables[0].Rows.Count > 0)
                                {
                                    ds_pins.Merge(dssurvey_khataAdd);
                                }
                                dt_pins = ds_pins.Tables[0].DefaultView.ToTable(true, "pin", "pin1", "pin2", "pin3", "pin4", "pin5", "pin6", "pin7", "pin8", "pins");

                                foreach (DataRow dr_pin in dt_pins.Rows)
                                {
                                    lblKhataDelOnSurveySurveyListDispVal.Text = dr_pin["pins"].ToString();
                                    if (ViewState["lblSurveyList"].ToString() == "")
                                    {
                                        ViewState["lblSurveyList"] = lblKhataDelOnSurveySurveyListDispVal.Text;
                                    }
                                    else
                                    {
                                        ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + lblKhataDelOnSurveySurveyListDispVal.Text;
                                        pins_cnt = pins_cnt + 1;
                                    }
                                }

                                lblKhataDelOnSurveySurveyListDispaly.Visible = true;
                                lblKhataDelOnSurveySurveyListDispVal.Text = "";
                                lblKhataDelOnSurveySurveyListDispVal.Visible = true;
                                //  lblKhataDelOnSurveySurveyListDispVal.Text = ViewState["lblSurveyList"].ToString();
                                lblKhataOnSurveySurveyListDispVal.Text = ViewState["lblSurveyList"].ToString();

                                ViewState["ds_pins"] = ds_pins;
                            }


                            ////   ViewState["lblSurveyList"] = String.Empty;
                            ////   DataTable dt_surveyAllowDeleteKhata = (DataTable)Session["dt_surveyAllowDeleteKhata"];


                            ////foreach (DataRow dr_pin in dt_surveyAllowDeleteKhata.Rows)
                            ////{

                            ////    lblKhataDelOnSurveySurveyListDispVal.Text = dr_pin["pincase"].ToString();
                            ////    if (Convert.ToString(ViewState["lblSurveyList"]) == "")
                            ////    {
                            ////        ViewState["lblSurveyList"] = lblKhataDelOnSurveySurveyListDispVal.Text;
                            ////    }
                            ////    else
                            ////    {
                            ////        ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + lblKhataDelOnSurveySurveyListDispVal.Text;
                            ////    }
                            ////}

                            ////lblKhataDelOnSurveySurveyListDispaly.Visible = true;
                            ////lblKhataDelOnSurveySurveyListDispVal.Text = "";
                            ////lblKhataDelOnSurveySurveyListDispVal.Visible = true;
                            ////lblKhataDelOnSurveySurveyListDispVal.Text = ViewState["lblSurveyList"].ToString();
                            ////lblKhataOnSurveySurveyListDispVal.Text = ViewState["lblSurveyList"].ToString();
                            // ViewState["ds_pins"] = ds_pins;





                            //DataSet ds_editf7 = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "distinct (khata_no::int) as seller_khata_no,fname,mname,lname,topan_name", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "' and  khata_no<>''  and edit_flag<>'34' and edit_flag<>'40'", "khata_no::int ");
                            //if (ds_editf7 != null && ds_editf7.Tables[0].Rows.Count > 0)
                            //{
                            //    gdvSurveySelection.DataSource = ds_editf7.Tables[0].DefaultView;
                            //    gdvSurveySelection.DataBind();
                            //                          }

                            lblSelectedSurveyForDelete.Text = "";
                            gdvSurveySelection.DataSource = null;
                            gdvSurveySelection.DataBind();
                            lblSurveyList.Visible = false;
                            btnAdd.Visible = false;
                            btn.Visible = false;
                            btnKhataDelOnSurvey.Enabled = false;
                            string popupScript = "<script language='javascript'>alert('माहिती साठवली आहे.');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                            return;
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandling excpt = new ExceptionHandling();
                            if (Session["LoginID"] != null)
                                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
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
        catch (Exception ex)
        {

            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, ex.Message, Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
    protected void btnBackKhataDelOnSurvey_Click(object sender, EventArgs e)
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
                    //-----
                    try
                    {
                        ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup_bhogvatdar').style.display = 'block';", true);
                        PnlKhataDelOnSurvey.Visible = false;
                        pnlgrdKhataDelOnSurvey.Visible = false;
                        btnBackKhataDelOnSurvey.Enabled = false;
                        //--------
                        Session["khata_no"] = null;
                        Session["editf7k_del"] = null;
                        Session["khata_type"] = null;
                        lblSelectedKhatatype.Visible = false;
                        lblnewKhataType.Visible = false;
                        ViewState["grdOldkhata"] = null;
                        ViewState["ds_pins"] = null;
                        Session["ds_names_delete"] = null;
                        lblKhataTypeDelNew.Visible = false;
                        lblKhataTypeDelDispNew.Visible = false;
                        Session["khata_type_del"] = null;
                        Session["khata_name_del"] = null;
                        DataSet ds_editf7 = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "distinct (khata_no::int) as seller_khata_no,fname,mname,lname,topan_name", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no='" + Convert.ToString(Session["khata_no"]) + "' and  khata_no<>''  and edit_flag<>'34' and edit_flag<>'40'", "khata_no::int ");
                        if (ds_editf7 != null && ds_editf7.Tables[0].Rows.Count > 0)
                        {
                            gdvkhataDetails.DataSource = ds_editf7.Tables[0].DefaultView;
                            gdvkhataDetails.DataBind();
                            ViewState["orignal_sellers_ds"] = ds_editf7;
                            ViewState["Ds_toEnble"] = ds_editf7;
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling excpt = new ExceptionHandling();
                        if (Session["LoginID"] != null)
                            Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
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
    protected void chkSelectSurvey_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            int pins_cnt = 0;
            CheckBox chkSelectSurvey = (CheckBox)sender;
            ViewState["SelectedSurveyForDelete"] = null;
            ViewState["ds_pins"] = null;
            DataTable dt_khata_delete = new DataTable();
            dt_khata_delete.Columns.Add("pins");
            dt_khata_delete.Columns.Add("pin");
            dt_khata_delete.Columns.Add("pin1");
            dt_khata_delete.Columns.Add("pin2");
            dt_khata_delete.Columns.Add("pin3");
            dt_khata_delete.Columns.Add("pin4");
            dt_khata_delete.Columns.Add("pin5");
            dt_khata_delete.Columns.Add("pin6");
            dt_khata_delete.Columns.Add("pin7");
            dt_khata_delete.Columns.Add("pin8");
            for (int i = 0; i < gdvSurveySelection.Rows.Count; i++)
            {
                CheckBox chk = ((CheckBox)gdvSurveySelection.Rows[i].FindControl("chkSelectSurvey"));
                if (chk.Checked == true)
                {
                    lblSelectedSurveyForDelete.Text = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpins")).Text;
                    if (Convert.ToString(ViewState["SelectedSurveyForDelete"]) == "")
                    {
                        ViewState["SelectedSurveyForDelete"] = lblSelectedSurveyForDelete.Text;
                    }
                    else
                    {
                        if (ViewState["SelectedSurveyForDelete"].ToString().Length <= pins_cnt * 120)
                        {
                            ViewState["SelectedSurveyForDelete"] = ViewState["SelectedSurveyForDelete"] + ", " + lblSelectedSurveyForDelete.Text;
                            pins_cnt = pins_cnt + 1;
                        }
                        else
                        {
                            ViewState["SelectedSurveyForDelete"] = ViewState["SelectedSurveyForDelete"] + ", " + lblSelectedSurveyForDelete.Text + "<br/>";
                        }
                    }
                    DataRow dr_delete = dt_khata_delete.NewRow();
                    dr_delete["pins"] = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpins")).Text;
                    dr_delete["pin"] = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpin")).Text;
                    dr_delete["pin1"] = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpin1")).Text;
                    dr_delete["pin2"] = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpin2")).Text;
                    dr_delete["pin3"] = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpin3")).Text;
                    dr_delete["pin4"] = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpin4")).Text;
                    dr_delete["pin5"] = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpin5")).Text;
                    dr_delete["pin6"] = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpin6")).Text;
                    dr_delete["pin7"] = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpin7")).Text;
                    dr_delete["pin8"] = ((Label)gdvSurveySelection.Rows[i].FindControl("lblpin8")).Text;
                    dt_khata_delete.Rows.Add(dr_delete);
                }
            }
            lblSelectedSurveyForDelete.Text = Convert.ToString(ViewState["SelectedSurveyForDelete"]).Trim(',');


            ViewState["dt_pin"] = dt_khata_delete;
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }


    }
    protected void gdvSurveySelection_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnkKhataNoDeletionSurveyWise_Click(object sender, EventArgs e)
    {
        try
        {

            btnKhataDelOnSurvey.Enabled = true;
            if (Convert.ToString(txtKhataNo.Text) == "")
            {
                string popupScript = "<script language='javascript'>alert('जो खाता क्रमांक निवडक सर्व्हे / गट क्रमांकावरुन वगळायचा आहे तो खाता क्रमांक निवडा.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
            else
            {
                DataTable dt_khataOnMulSurveyChk = new DataTable();
                DataTable dt_ListOfMulKhataOnSurvey = new DataTable();
                int countOfSurvey = 0;
                int countOfMulKhataOnSurvey = 0;
                DataTable dt_surveyAllowDeleteKhata = new DataTable();
                dt_surveyAllowDeleteKhata.Columns.Add("pin");
                dt_surveyAllowDeleteKhata.Columns.Add("pin1");
                dt_surveyAllowDeleteKhata.Columns.Add("pin2");
                dt_surveyAllowDeleteKhata.Columns.Add("pin3");
                dt_surveyAllowDeleteKhata.Columns.Add("pin4");
                dt_surveyAllowDeleteKhata.Columns.Add("pin5");
                dt_surveyAllowDeleteKhata.Columns.Add("pin6");
                dt_surveyAllowDeleteKhata.Columns.Add("pin7");
                dt_surveyAllowDeleteKhata.Columns.Add("pin8");
                dt_surveyAllowDeleteKhata.Columns.Add("pincase");
                countOfSurvey = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "count( distinct pin||'/'||pin1||'/'||pin2||'/'||pin3||'/'||pin4||'/'||pin5||'/'||pin6||'/'||pin7||'/'||pin8) ", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + (Convert.ToString(Session["khata_no"])) + "'  and edit_flag not in ('34' , '40')", "");
                if (countOfSurvey > 0)
                {
                    dt_khataOnMulSurveyChk = obj.funReturnDataTable(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + (Convert.ToString(Session["khata_no"])) + "' and edit_flag not in ('34' , '40')", "");
                    for (int i = 0; i < dt_khataOnMulSurveyChk.Rows.Count; i++)
                    {
                        countOfMulKhataOnSurvey = obj.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", " count (distinct khata_no )", "ccode = '" + (string)Session["ccode"] + "' and  pin='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin"])) + "' and  pin1='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin1"])) + "' and  pin2='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin2"])) + "'  and  pin3='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin3"])) + "' and  pin4='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin4"])) + "' and  pin5='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin5"])) + "' and  pin6='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin6"])) + "' and  pin7='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin7"])) + "' and  pin8='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin8"])) + "' and edit_flag not in ('34' , '40')", "");
                        if (countOfMulKhataOnSurvey > 1)
                        {
                            DataRow dr = dt_surveyAllowDeleteKhata.NewRow();
                            dr["pin"] = dt_khataOnMulSurveyChk.Rows[i]["pin"].ToString();
                            dr["pin1"] = dt_khataOnMulSurveyChk.Rows[i]["pin1"].ToString();
                            dr["pin2"] = dt_khataOnMulSurveyChk.Rows[i]["pin2"].ToString();
                            dr["pin3"] = dt_khataOnMulSurveyChk.Rows[i]["pin3"].ToString();
                            dr["pin4"] = dt_khataOnMulSurveyChk.Rows[i]["pin4"].ToString();
                            dr["pin5"] = dt_khataOnMulSurveyChk.Rows[i]["pin5"].ToString();
                            dr["pin6"] = dt_khataOnMulSurveyChk.Rows[i]["pin6"].ToString();
                            dr["pin7"] = dt_khataOnMulSurveyChk.Rows[i]["pin7"].ToString();
                            dr["pin8"] = dt_khataOnMulSurveyChk.Rows[i]["pin8"].ToString();
                            dr["pincase"] = (dt_khataOnMulSurveyChk.Rows[i]["pin"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin1"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin2"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin3"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin4"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin5"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin6"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin7"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin8"].ToString()).Trim('/');
                            dt_surveyAllowDeleteKhata.Rows.Add(dr);
                        }

                    }
                    if (dt_surveyAllowDeleteKhata.Rows.Count > 0)
                    {
                        int pins_cnt = 1;
                        foreach (DataRow dr_pin in dt_surveyAllowDeleteKhata.Rows)
                        {
                            lblKhataDelOnSurveySurveyListDispVal.Text = dr_pin["pincase"].ToString();
                            if (Convert.ToString(ViewState["lblSurveyList"]) == "")
                            {
                                ViewState["lblSurveyList"] = lblKhataDelOnSurveySurveyListDispVal.Text;
                            }
                            else
                            {
                                ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + lblKhataDelOnSurveySurveyListDispVal.Text;
                                pins_cnt = pins_cnt + 1;
                            }
                        }
                        lblKhataDelOnSurveySurveyListDispaly.Visible = true;
                        lblKhataDelOnSurveySurveyListDispVal.Text = "";
                        lblKhataDelOnSurveySurveyListDispVal.Visible = true;
                        lblKhataDelOnSurveySurveyListDispVal.Text = ViewState["lblSurveyList"].ToString();
                        ViewState["ds_pins"] = dt_surveyAllowDeleteKhata;
                        gdvSurveySelection.DataSource = dt_surveyAllowDeleteKhata.DefaultView;
                        gdvSurveySelection.DataBind();
                        btnKhataDelOnSurvey.Visible = true;
                    }
                    else
                    {
                        // string popupScript = "<script language='javascript'>alert(' not allowed as only khata  present on  these survey.');</script>";
                        string popupScript = "<script language='javascript'>alert('सदर खाते सर्व्हे क्रमांकावर  नसल्यामुळे या पर्यायाद्वारे वगळता येणार नाही.');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
                }
                else
                {
                    countOfSurvey = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", "count( distinct pin||'/'||pin1||'/'||pin2||'/'||pin3||'/'||pin4||'/'||pin5||'/'||pin6||'/'||pin7||'/'||pin8)  ", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + (Convert.ToString(Session["khata_no"])) + "'", "");
                    if (countOfSurvey > 0)
                    {
                        dt_khataOnMulSurveyChk = obj.funReturnDataTable(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + (Convert.ToString(Session["khata_no"])) + "'", "");
                        for (int i = 0; i < dt_khataOnMulSurveyChk.Rows.Count; i++)
                        {
                            countOfMulKhataOnSurvey = obj.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", " count (distinct khata_no )", "ccode = '" + (string)Session["ccode"] + "' and  pin='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin"])) + "' and  pin1='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin1"])) + "' and  pin2='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin2"])) + "'  and  pin3='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin3"])) + "' and  pin4='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin4"])) + "' and  pin5='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin5"])) + "' and  pin6='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin6"])) + "' and  pin7='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin7"])) + "' and  pin8='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin8"])) + "' ", "");
                            if (countOfMulKhataOnSurvey > 1)
                            {
                                dt_ListOfMulKhataOnSurvey = obj.funReturnDataTable(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", " distinct khata_no ", "ccode = '" + (string)Session["ccode"] + "' and  pin='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin"])) + "' and  pin1='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin1"])) + "' and  pin2='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin2"])) + "'  and  pin3='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin3"])) + "' and  pin4='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin4"])) + "' and  pin5='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin5"])) + "' and  pin6='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin6"])) + "' and  pin7='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin7"])) + "' and  pin8='" + (Convert.ToString(dt_khataOnMulSurveyChk.Rows[i]["pin8"])) + "' ", "");
                                DataRow dr = dt_surveyAllowDeleteKhata.NewRow();
                                dr["pin"] = dt_khataOnMulSurveyChk.Rows[i]["pin"].ToString();
                                dr["pin1"] = dt_khataOnMulSurveyChk.Rows[i]["pin1"].ToString();
                                dr["pin2"] = dt_khataOnMulSurveyChk.Rows[i]["pin2"].ToString();
                                dr["pin3"] = dt_khataOnMulSurveyChk.Rows[i]["pin3"].ToString();
                                dr["pin4"] = dt_khataOnMulSurveyChk.Rows[i]["pin4"].ToString();
                                dr["pin5"] = dt_khataOnMulSurveyChk.Rows[i]["pin5"].ToString();
                                dr["pin6"] = dt_khataOnMulSurveyChk.Rows[i]["pin6"].ToString();
                                dr["pin7"] = dt_khataOnMulSurveyChk.Rows[i]["pin7"].ToString();
                                dr["pin8"] = dt_khataOnMulSurveyChk.Rows[i]["pin8"].ToString();
                                dr["pincase"] = (dt_khataOnMulSurveyChk.Rows[i]["pin"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin1"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin2"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin3"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin4"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin5"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin6"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin7"].ToString() + "/" + dt_khataOnMulSurveyChk.Rows[i]["pin8"].ToString()).Trim('/');
                                dt_surveyAllowDeleteKhata.Rows.Add(dr);
                            }
                        }
                        if (dt_surveyAllowDeleteKhata.Rows.Count > 0)
                        {
                            int pins_cnt = 1;
                            foreach (DataRow dr_pin in dt_surveyAllowDeleteKhata.Rows)
                            {
                                lblKhataDelOnSurveySurveyListDispVal.Text = dr_pin["pincase"].ToString();
                                if (Convert.ToString(ViewState["lblSurveyList"]) == "")
                                {
                                    ViewState["lblSurveyList"] = lblKhataDelOnSurveySurveyListDispVal.Text;
                                }
                                else
                                {
                                    ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + lblKhataDelOnSurveySurveyListDispVal.Text;
                                    pins_cnt = pins_cnt + 1;
                                }
                            }
                            lblKhataDelOnSurveySurveyListDispaly.Visible = true;
                            lblKhataDelOnSurveySurveyListDispVal.Text = "";
                            lblKhataDelOnSurveySurveyListDispVal.Visible = true;
                            lblKhataDelOnSurveySurveyListDispVal.Text = ViewState["lblSurveyList"].ToString();
                            ViewState["ds_pins"] = dt_surveyAllowDeleteKhata;
                            gdvSurveySelection.DataSource = dt_surveyAllowDeleteKhata.DefaultView;
                            gdvSurveySelection.DataBind();
                            btnKhataDelOnSurvey.Visible = true;
                        }
                        else
                        {
                            string popupScript = "<script language='javascript'>alert(' सदर खाते या सर्व्हे क्रमांकावर वर एकमेव असल्यामुळे या पर्यायाद्वारे वगळता येणार नाही.');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                            return;
                        }

                    }
                    else
                    {
                        string popupScript = "<script language='javascript'>alert('सदर खाते सर्व्हे क्रमांकावर  नसल्यामुळे या पर्यायाद्वारे वगळता येणार नाही.');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
                }


                if (dt_surveyAllowDeleteKhata.Rows.Count > 0)
                {


                    Session["dt_surveyAllowDeleteKhata"] = dt_surveyAllowDeleteKhata;
                    ScriptManager.RegisterStartupScript(Page, GetType(), @"poppup", @"document.getElementById('divpopup_PaneNameDel').style.display = 'block';", true);
                    PnlKhataDelOnSurvey.Visible = true;
                    DataSet ds_KhataDelOnSurvey = new DataSet();
                    int chk_edit_hd_khata = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "count(*) ", "ccode = '" + (string)Session["ccode"] + "' and  khata_no='" + (Convert.ToString(Session["khata_no"])) + "'", "");
                    if (chk_edit_hd_khata == 0)
                    {
                        ds_KhataDelOnSurvey = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".holder_detail ", "fname,mname,lname,topan_name,khata_no,khata_type,cast('0' as bool) as chk, '' as flag", "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "'  ", "khata_no::int");
                    }
                    else
                    {
                        ds_KhataDelOnSurvey = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "fname,mname,lname,topan_name,khata_no,khata_type,cast('0' as bool) as chk, '' as flag", "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "' ", "khata_no::int");
                    }
                    Session["KhataDelOnSurveykhata_type"] = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".holder_detail h , " + Convert.ToString(Session["SchemaName"]) + ".m_khata_type m", "khata_description", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no ='" + Session["khata_no"].ToString() + "' and h.khata_type=m.khata_type", "");
                    lblDelOnSurveykhataTypeDispVal.Text = Convert.ToString(Session["KhataDelOnSurveykhata_type"]);

                    if (ds_KhataDelOnSurvey.Tables.Count > 0 && ds_KhataDelOnSurvey.Tables[0].Rows.Count > 0)
                    {

                        grdKhataDelOnSurvey.DataSource = ds_KhataDelOnSurvey.Tables[0].DefaultView;
                        grdKhataDelOnSurvey.DataBind();
                        ViewState["ds_KhataDelOnSurvey"] = ds_KhataDelOnSurvey;
                        pnlgrdKhataDelOnSurvey.Visible = true;
                        grdKhataDelOnSurvey.Visible = true;
                        lblKhataNoDisp.Visible = true;
                        lblDelOnSurveykhataNoDispVal.Text = Session["khata_no"].ToString();
                        lblSurveyNameDel.Text = "";
                        lblSurveyNameDelDisp.Visible = true;
                        btnAdd.Visible = true;
                        lblmsgSpell.Visible = false;

                        string pincase = "rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  ||";
                        pincase += "(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')AS pins";
                        // ViewState["lblSurveyList"] = "";
                        //DataSet ds_pins = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_khata", " distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "ccode = '" + (string)Session["ccode"] + "'and khata_no='" + (Session["khata_no"]).ToString() + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  not in  ( select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + Session["SchemaName"].ToString() + ".edit_form7_khata_kp  where ccode = '" + Convert.ToString(Session["ccode"]) + "' and khata_no='" + (Session["khata_no"]).ToString() + "' and  ( edit_flag='34' or edit_flag='40'  ) )", "");
                        //DataSet dssurvey_khataAdd = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata_kp ", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8," + pincase, "khata_no ='" + Session["khata_no"].ToString() + "' AND  ccode = '" + Convert.ToString(Session["ccode"]) + "' and edit_flag<>'34' and edit_flag<>'40'", "pin");
                        //int pins_cnt = 1;
                        //if (ds_pins.Tables.Count > 0 && ds_pins.Tables[0].Rows.Count > 0)
                        //{
                        //    if (dssurvey_khataAdd != null && dssurvey_khataAdd.Tables.Count > 0 && dssurvey_khataAdd.Tables[0].Rows.Count > 0)
                        //    {
                        //        ds_pins.Merge(dssurvey_khataAdd);
                        //    }
                        //    DataTable dt_pins = ds_pins.Tables[0].DefaultView.ToTable(true, "pin", "pin1", "pin2", "pin3", "pin4", "pin5", "pin6", "pin7", "pin8", "pins");

                        //    foreach (DataRow dr_pin in dt_pins.Rows)
                        //    {
                        //        lblKhataDelOnSurveySurveyListDispVal.Text = dr_pin["pins"].ToString();
                        //        if (ViewState["lblSurveyList"].ToString() == "")
                        //        {
                        //            ViewState["lblSurveyList"] = lblKhataDelOnSurveySurveyListDispVal.Text;
                        //        }
                        //        else
                        //        {
                        //            ViewState["lblSurveyList"] = ViewState["lblSurveyList"] + ", " + lblKhataDelOnSurveySurveyListDispVal.Text;
                        //            pins_cnt = pins_cnt + 1;
                        //        }
                        //    }
                        //    lblKhataDelOnSurveySurveyListDispaly.Visible = true;
                        //    lblKhataDelOnSurveySurveyListDispVal.Text = "";
                        //    lblKhataDelOnSurveySurveyListDispVal.Visible = true;
                        //    lblKhataDelOnSurveySurveyListDispVal.Text = ViewState["lblSurveyList"].ToString();
                        //    ViewState["ds_pins"] = ds_pins;
                        //    gdvSurveySelection.DataSource = dt_pins.DefaultView;
                        //    gdvSurveySelection.DataBind();
                        //    btnKhataDelOnSurvey.Visible = true;
                        //}
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
    
}