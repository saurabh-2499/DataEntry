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

public partial class pgSecondDeclaration : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction obj = new clsCommonFunction();
    clscommonfunedit objedit = new clscommonfunedit();
    DataSet ds_checks = new DataSet();
    string page_name = "pgSecondDeclaration";
    string talathiname = string.Empty;
    string circlename = string.Empty;
   // string dbaname = string.Empty;
    int totalSurvey, _712cnt = 0;
    string CoName, CoSevarth, tahsildarname = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                if (Session["user_type"].ToString() == "DBA")
                {

                    string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
                    if (Convert.ToUInt32(userExist) == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
                    }


                    if (Convert.ToString(Session["ccode"]) == "")
                    {
                        if (Session["user_type"].ToString() == "T")
                            Response.Redirect("pgSelectVillage.aspx");
                        else if (Session["user_type"].ToString() == "DBA")
                            Response.Redirect("pgVillageSelect_DBA.aspx");
                    }
                    else
                    {
                        Session["ccode"] = Session["ccode"].ToString();
                    }

                    if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b, " + Convert.ToString(Session["SchemaName"]) + ".m_ewc_checks as c", "(case when count(a.*)>11 then true else false end) as d2status", "a.ccode ='" + Session["ccode"].ToString() + "' and  a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true and  a.wc_code=c.wc_code and  c.check_type='S'  and a.ccode  in  (  select    ccode  from " + Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3  where ccode ='" + Session["ccode"].ToString() + "') ", "")) == true)
                    {
                        btnSave.Visible = false;
                        Panel1.Visible = false;
                        string popupScript = "<script language='javascript'>alert('सदर गावाचे  घोषणापत्र -II ( DECLARATION-II ) यापूर्वीच  झाले असल्यामुळे  घोषणापत्र -II ( DECLARATION-II ) पुन्हा करता येणार नाही याची नोंद घ्यावी.!!!!!!');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
                    if (this.isReEdit712WorkAprroved(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]), Convert.ToString(Session["ccode"])) == false)
                    {
                        btnSave.Visible = false;
                        Panel1.Visible = false;
                        string popupScript = "<script language='javascript'>alert('सदर गावात रि -एडीट अद्न्यावालीद्वारे घेणात आलेले फेरफार / परिशिष्ट मंजुरीचे काम पूर्ण करूनच DECLARATION-II चे काम करता येईल याची नोंद घ्यावी , सबब  DECLARATION-II करता येणार  नाही.!!!!' );</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
                    int rec_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' ", "");
                    if (rec_cnt > 0)
                    {
                        int date_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  khata_master_declaration =false and khata_master_declair_date  isnull", "");
                        if (date_cnt != 0)
                        {
                            btnSave.Enabled = false;
                            string popupScript = "<script language='javascript'>alert(' Declaration - II [ Re-Edit Module मधील काम पूर्ण झाल्याचे ग्राम महसूल अधिकारी यांचे स्वयंघोषणापत्र ] करण्यापुर्वी   Declaration - I [ संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्राम महसूल अधिकारी स्वयं घोषणा ] करणे आवश्यक आहे याची नोंद घ्यावी.' );</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                            return;

                        }
                    }
                    else
                    {
                        btnSave.Enabled = false;
                        string popupScript = "<script language='javascript'>alert(' Declaration - II [ Re-Edit Module मधील काम पूर्ण झाल्याचे ग्राम महसूल अधिकारी यांचे स्वयंघोषणापत्र ] करण्यापुर्वी   Declaration - I [ संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्राम महसूल अधिकारी स्वयं घोषणा ] करणे आवश्यक आहे याची नोंद घ्यावी.' );</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }

                    //
                    DataTable tal_sevarth = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp_audit", "distinct login_id, timestatus", "ccode='" + Convert.ToString(Session["ccode"]) + "' ", "timestatus  desc  limit 1");
                    talathiname = con.funReturnSingleValue("rcis_uni.fpusers1", "distinct (case WHEN  trim(marathiname)    is  null then  trim(fullname) else  marathiname end)||' - '||servarthid", "servarthid='" + tal_sevarth.Rows[0]["login_id"].ToString() + "'", "");
                    //
                    DataSet dssevarth = con.funReturnDataSet((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_officermast", "trim(username) as username,user_type", "ccode='" + Convert.ToString(Session["VillageDetail"]).Split('#')[0] + "' and user_type ='2'", "");
                   // dbaname = con.funReturnSingleValue("rcis_uni.fpusers1", " distinct (case WHEN  trim(marathiname)    is  null then  trim(fullname) else  marathiname end)  ||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='DBA' and user_status='L'    and ( servarthid  , createdate ) in (select servarthid  , createdate  from  rcis_uni.fpusers1  where  district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg  ='DBA'   and  user_status='L'  order by  createdate  limit 1)", "");
                    tahsildarname = con.funReturnSingleValue("rcis_uni.fpusers1", "distinct (case WHEN  trim(marathiname)    is  null then  trim(fullname) else  marathiname end) ||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='TAH' and user_status='L' and ( servarthid  , createdate ) in (select servarthid  , createdate  from  rcis_uni.fpusers1  where  district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg  ='TAH'   and  user_status='L'  order by  createdate  limit 1)", "");

                    if (dssevarth != null || dssevarth.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dssevarth.Tables[0].Rows)
                        {
                            if (Convert.ToString(dr["user_type"]) == "2")
                            {
                                circlename = con.funReturnSingleValue("rcis_uni.fpusers1", "distinct (case WHEN  trim(marathiname)    is  null then  trim(fullname) else  marathiname end)||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='C' and  servarthid='" + Convert.ToString(dr["username"]) + "' and user_status='L'", "");
                            }

                        }
                    }
                    else
                    {
                        btnSave.Enabled = false;
                        string popupScript1 = "<script language='javascript'>alert('संबंधित मंडळ अधिकारी यांचे रजिस्ट्रेशन करा.');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
                        return;
                    }

                    //if (dbaname == null || dbaname == "")
                    //{
                    //    btnSave.Enabled = false;
                    //    string popupScript1 = "<script language='javascript'>alert('संबंधित नायब तहसिलदार यांचे रजिस्ट्रेशन करा.');</script>";
                    //    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
                    //    return;
                    //}

                    if (tahsildarname == null || tahsildarname == "")
                    {
                        btnSave.Enabled = false;
                        string popupScript1 = "<script language='javascript'>alert('संबंधित  तहसिलदार यांचे रजिस्ट्रेशन करा.');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
                        return;
                    }
                    btnSave.Enabled = true;
                    lblVillageName.Text = Convert.ToString(Session["VillageDetail"]).Split('#')[1];
                    lblTalukaName.Text = Convert.ToString(Session["TalukaName"]);
                    lblDBAName.Text = Convert.ToString(Session["fullname"]); //talathiname.Split('-')[0];
                    CoSevarth = circlename.Split('-')[1];
                    CoName = circlename.Split('-')[0].Trim();
                    lblCOSevarthTable.Text = circlename.Split('-')[1];
                   
                    lblTalathiSevarthTable.Text = talathiname.Split('-')[1];
                    lblDBASevarthtbl.Text = Convert.ToString(Session["UserName"]);

                    lblTalathiNameTable.Text = talathiname.Split('-')[0].Trim();
                    lblCONameTable.Text = circlename.Split('-')[0].Trim();
                    lbldbaNameTable.Text = Convert.ToString(Session["fullname"]);
                    lblTahNameTable.Text = tahsildarname.Split('-')[0].Trim();
                    lblTahSevarthtbl.Text = tahsildarname.Split('-')[1].Trim();
                    totalSurvey = objedit.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7", "count(*)", " ccode='" + Convert.ToString(Session["ccode"]) + "' and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode ='" + Convert.ToString(Session["ccode"]) + "'  and khata_no='500001') group  by  ccode", "ccode");
                    _712cnt = totalSurvey;
                    ViewState["totalSurvey"] = totalSurvey;
                    if (totalSurvey==0)
                    {
                        btnSave.Enabled = false;
                        string popupScript = "<script language='javascript'>alert('कृपया गावं निवडा.....!!!!');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
                    //


                    lblDBASevarthID.Text = Convert.ToString(Session["UserName"]);//talathiname.Split('-')[1];
                    lblTalukaName.Text = Convert.ToString(Session["TalukaName"]);
                    lblVillageName.Text = Convert.ToString(Session["VillageDetail"]).Split('#')[1];
                    // lblvilldisp.Text = Convert.ToString(Session["VillageDetail"]).Split('#')[1];
                    villUser.Text = talathiname.Split('-')[0].ToString();
                    FillCheckGrid();
                    Session["page_heading"] = "प्रपत्र-२ ( DECLARATION-II )";

                    lbltotal712disp.Text = " एकूण ७१२  :  " + totalSurvey.ToString();
                    lblDBA_Taluka_name.Text = Convert.ToString(Session["TalukaName"]);
                    villUser_ID.Text = talathiname.Split('-')[1];
                    lblDBA_District_name.Text = Convert.ToString(Session["DistrictName"]);
                }
                else
                {
                    string popupScript = "<script language='javascript'>alert('कृपया DBA लॉगीन करा.....!!!!');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    Response.Redirect("pgLogout.aspx");

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
    void FillCheckGrid()
    {
        try
        {
            ds_checks = objedit.funSetGridList(Convert.ToString(Session["DataBaseName"]), ref gvEWC_Check, Convert.ToString(Session["SchemaName"]) + ".m_ewc_checks", "*", "wc_code<>0", "wc_code");
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
    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "MouseEvents(this, event)");
            e.Row.Attributes.Add("onmouseout", "MouseEvents(this, event)");
        }
    }
    protected void btn_goahed_Click(object sender, EventArgs e)
    {
        pnl2.Visible = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //txtTal712Cnt txtTalDate txtCO712Cnt txtCODate txtDBA712Cnt txtDBADate  txtTah712Cnt txtTahDate txtCOL712Cnt txtColDate txtSDO712Cnt txtSdoDate
        try
        {
            if (btnSave.Text.ToString() == "साठवा")
            {
                if (txtdesg.Text.Trim() == string.Empty || txtInspDate.Text.Trim() == string.Empty || txtInspectOfficer.Text.Trim() == string.Empty || txtInspOffID.Text.Trim() == string.Empty || txtTal712Cnt.Text.Trim() == string.Empty || txtTalDate.Text.Trim() == string.Empty || txtCO712Cnt.Text.Trim() == string.Empty || txtCODate.Text.Trim() == string.Empty || txtDBA712Cnt.Text.Trim() == string.Empty || txtDBADate.Text.Trim() == string.Empty || txtTah712Cnt.Text.Trim() == string.Empty || txtTahDate.Text.Trim() == string.Empty || txtCOL712Cnt.Text.Trim() == string.Empty || txtColDate.Text.Trim() == string.Empty || txtSDO712Cnt.Text.Trim() == string.Empty || txtSdoDate.Text.Trim() == string.Empty)
                {
                    string popupScript = "<script language='javascript'>alert('कृपया सर्व  माहिती  भरा....!!!!');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
                else
                {
                    if (Convert.ToInt32(txtTal712Cnt.Text.Trim()) > Convert.ToInt32(ViewState["totalSurvey"]) || Convert.ToInt32(txtTah712Cnt.Text.Trim()) > Convert.ToInt32(ViewState["totalSurvey"]) || Convert.ToInt32(txtCOL712Cnt.Text.Trim()) > Convert.ToInt32(ViewState["totalSurvey"]) || Convert.ToInt32(txtDBA712Cnt.Text.Trim()) > Convert.ToInt32(ViewState["totalSurvey"]) || Convert.ToInt32(txtCOL712Cnt.Text.Trim()) > Convert.ToInt32(ViewState["totalSurvey"]) || Convert.ToInt32(txtSDO712Cnt.Text.Trim()) > Convert.ToInt32(ViewState["totalSurvey"]))
                    {
                        string popupScript = "<script language='javascript'>alert('तपासणी केलेल्या ७/१२ ची संख्या हि एकूण ७/१२ म्हणजेच " + Convert.ToInt32(ViewState["totalSurvey"]) + " पेक्ष्या जास्त नसावी....!!!!');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
                    string InspDate = obj.ConvertToMDY(txtInspDate.Text.Trim());

                    string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
                    using (DbConnection connection = new NpgsqlConnection(_connectionString))
                    {
                        connection.Open();
                        using (DbTransaction transaction = connection.BeginTransaction())
                        {

                            DbCommand dbCmd;
                            using (dbCmd = connection.CreateCommand())
                            {
                                try
                                {
                                    //string[] date = txtDate.Text.ToString().Split('/');
                                    //string txtDates = date[1] + "/" + date[0] + "/" + date[2];
                                    string[] date;
                                    date = txtTalDate.Text.ToString().Split('/');
                                    string txtTalDates = date[1] + "/" + date[0] + "/" + date[2];

                                    date = txtCODate.Text.ToString().Split('/');
                                    string txtCODates = date[1] + "/" + date[0] + "/" + date[2];

                                    date = txtDBADate.Text.ToString().Split('/');
                                    string txtDBADates = date[1] + "/" + date[0] + "/" + date[2];

                                    date = txtTahDate.Text.ToString().Split('/');
                                    string txtTahDates = date[1] + "/" + date[0] + "/" + date[2];

                                    date = txtColDate.Text.ToString().Split('/');
                                    string txtColDates = date[1] + "/" + date[0] + "/" + date[2];

                                    date = txtSdoDate.Text.ToString().Split('/');
                                    string txtSdoDates = date[1] + "/" + date[0] + "/" + date[2];
                                    objedit.funDeleteRecordSevarthID(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3", " ccode='" + Convert.ToString(Session["ccode"]) + "'", Convert.ToString(Session["UserName"]), ref dbCmd);
                                    objedit.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".tblewc_proforma3", "ccode, village_name, taluka_ccode, taluka_name, district_ccode,district_name, tal_name, tal_sevarth, co_name, co_sevarth, dba_name,dba_sevarth, tah_name, tah_sevarth, col_name, col_sevarth, sdo_name, sdo_sevarth, revoff_name, revoff_sevarth, revoff_checkdate,  tal_712cnt, co_712cnt, dba_712cnt,tah_712cnt, col_712cnt, sdo_712cnt, tal_chkdate, co_chkdate, dba_chkdate, tah_chkdate, col_chkdate, sdo_chkdate ", "'" + Convert.ToString(Session["ccode"]) + "','" + Convert.ToString(lblVillageName.Text.Trim()) + "','" + Convert.ToString(Session["TalukaCode"]) + "','" + Convert.ToString(lblTalukaName.Text.Trim()) + "','" + Convert.ToString(Session["DistCode"]) + "','" + Convert.ToString(Session["DistrictName"]) + "','" + Convert.ToString(villUser.Text.Trim()) + "','" + Convert.ToString(villUser_ID.Text.Trim()) + "','" + lblCONameTable.Text.ToString() + "','" + lblCOSevarthTable.Text.ToString().Trim() + "','" + Convert.ToString(lbldbaNameTable.Text.Trim()) + "','" + Convert.ToString(lblDBASevarthtbl.Text.Trim()) + "','" + Convert.ToString(lblTahNameTable.Text.Trim()) + "','" + Convert.ToString(lblTahSevarthtbl.Text.Trim()) + "','" + Convert.ToString(txtColNametable.Text.Trim()) + "','" + Convert.ToString(txtColSevarthtable.Text.Trim()) + "','" + Convert.ToString(txtSdoNametable.Text.Trim()) + "' ,'" + Convert.ToString(txtSdoSevarthtable.Text.Trim()) + "','" + Convert.ToString(txtInspectOfficer.Text.Trim()) + "','" + Convert.ToString(txtInspOffID.Text.Trim()) + "','" + InspDate + "','" + Convert.ToString(txtTal712Cnt.Text.Trim()) + "','" + Convert.ToString(txtCO712Cnt.Text.Trim()) + "','" + Convert.ToString(txtDBA712Cnt.Text.Trim()) + "','" + Convert.ToString(txtTah712Cnt.Text.Trim()) + "','" + Convert.ToString(txtCOL712Cnt.Text.Trim()) + "','" + Convert.ToString(txtSDO712Cnt.Text.Trim()) + "','" + Convert.ToString(txtTalDates.Trim()) + "','" + Convert.ToString(txtCODates.Trim()) + "','" + Convert.ToString(txtDBADates.Trim()) + "','" + Convert.ToString(txtTahDates.Trim()) + "','" + Convert.ToString(txtColDates.Trim()) + "','" + Convert.ToString(txtSdoDates.Trim()) + "'", Convert.ToString(Session["UserName"]), ref dbCmd);
                                    // objedit.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".tblewc_proforma3", " ccode, village_name, taluka_ccode, taluka_name, district_ccode,district_name, tal_name, tal_sevarth, co_name, co_sevarth, dba_name,dba_sevarth, tah_name, tah_sevarth, col_name, col_sevarth, sdo_name, sdo_sevarth, revoff_name, revoff_sevarth, revoff_checkdate, ah1remark, ah2remark, docremark,prapatr2remark, tal_712cnt, co_712cnt, dba_712cnt,tah_712cnt, col_712cnt, sdo_712cnt, tal_chkdate, co_chkdate, dba_chkdate, tah_chkdate, col_chkdate, sdo_chkdate, info_save_date", "'" + Convert.ToString(Session["ccode"]) + "','" + Convert.ToString(lblVillageName.Text) + "','" + Convert.ToString(Session["TalukaCode"]) + "','" + Convert.ToString(lblTalukaName.Text) + "','" + Convert.ToString(Session["DistCode"]) + "','" + Convert.ToString(lblDistrictName.Text) + "','" + Convert.ToString(lblTalathiName.Text) + "','" + Convert.ToString(lblTalathiSevarth.Text) + "','" + Convert.ToString(lblCOName.Text) + "','" + Convert.ToString(lblCOSevarth.Text) + "','" + Convert.ToString(lbldbaNameTable.Text) + "','" + Convert.ToString(lblDBASevarthtbl.Text) + "','" + Convert.ToString(tahsildarname.Split('-')[0]) + "','" + Convert.ToString(Convert.ToString(tahsildarname.Split('-')[1])) + "','" + txtColNametable.Text + "','" + txtColSevarthtable.Text + "','" + txtSdoNametable.Text + "' ,'" + txtSdoSevarthtable.Text + "','" + txtRevOff.Text + "','" + Convert.ToString(txtRevenuSevarth.Text) + "','" + Convert.ToString(txtDates) + "','" + ah1 + "' ,'" + ah2 + "','" + doc + "','" + prapatr2 + "','" + Convert.ToString(txtTal712Cnt.Text) + "','" + Convert.ToString(txtCO712Cnt.Text) + "','" + Convert.ToString(txtDBA712Cnt.Text) + "','" + Convert.ToString(txtTah712Cnt.Text) + "','" + Convert.ToString(txtCO712Cnt.Text) + "','" + Convert.ToString(txtSDO712Cnt.Text) + "','" + Convert.ToString(txtTalDates) + "','" + Convert.ToString(txtCODates) + "','" + Convert.ToString(txtDBADates) + "','" + Convert.ToString(txtTahDates) + "','" + Convert.ToString(txtColDates) + "','" + Convert.ToString(txtSdoDates) + "','now()'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                    objedit.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails", " ccode='" + Convert.ToString(Session["ccode"]) + "'", ref dbCmd);
                                    objedit.funInserSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails", " ccode, officer_name, officer_desg, officer_sevarthid, ewc_date", " '" + Convert.ToString(Session["ccode"]) + "','" + Convert.ToString(txtInspectOfficer.Text) + "','" + Convert.ToString(txtdesg.Text) + "','" + Convert.ToString(txtInspOffID.Text) + "','" + InspDate + "'", ref dbCmd);
                                    transaction.Commit();
                                    btnSave.Text = "पुढे जा";

                                    string popupScript = "<script language='javascript'>alert('माहिती साठवली आहे ,  पुढे  जा  बटन वर क्लिक  करा.....!!!!');</script>";
                                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                    return;

                                }
                                catch (Exception exp)
                                {
                                    transaction.Rollback();
                                }

                            }
                        }
                        connection.Close();

                    }
                }
            }
            if (btnSave.Text.ToString() == "पुढे जा")
            {
                int totalSurvey = 0;
                int totalkhatano = 0;
                pnl2.Visible = true;
                Panel1.Visible = false;
                btnSave.Text = "मागे जा";
                btn_save2.Visible = true;
                //totalSurvey = objedit.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7", "count(*)", " ccode='" + Convert.ToString(Session["ccode"]) + "' group  by  ccode", "ccode");
                lblTotalror.Text = ViewState["totalSurvey"].ToString();
                totalkhatano = objedit.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".holder_detail", " count(distinct khata_no)", " ccode='" + Convert.ToString(Session["ccode"]) + "' group  by  ccode", "ccode");
                lblTotal_khata.Text = totalkhatano.ToString();
                return;
            }
            if (btnSave.Text.ToString() == "मागे जा")
            {
                btnSave.Text = "साठवा";
                pnl2.Visible = false;
                Panel1.Visible = true;
                btn_save2.Visible = false;
                btn_ShowReport.Visible = false;
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
    protected void btn_save2_Click(object sender, EventArgs e)
    {
        btn_ShowReport.Visible = true;
        int rbcheckall = 0;
        try
        {
            if ((Convert.ToInt32(lblTotalror.Text.ToString()) < Convert.ToInt32(txtCorrectedRor.Text.ToString())) || (Convert.ToInt32(lblTotal_khata.Text.ToString()) < Convert.ToInt32(txtCorrectedkhata.Text.ToString())))
            {
                string popupScript = "<script language='javascript'>alert('दुरुस्त  केलेले   एकूण ७१२  हे गावातील एकूण ७१२  पेक्षा  जास्त आहे /  दुरुस्त  केलेले एकूण  खाता क्रमांक  हे   गावातील एकूण खाता क्रमांक  पेक्षा  जास्त आहे ....!!!!');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
            foreach (GridViewRow grv in gvEWC_Check.Rows)
            {
                RadioButtonList rblist1 = (RadioButtonList)grv.FindControl("rblist");
                if (rblist1.SelectedValue == "Y" || rblist1.SelectedValue == "N")
                    rbcheckall++;

            }
            if (rbcheckall == 0 || rbcheckall < gvEWC_Check.Rows.Count)
            {
                btn_ShowReport.Enabled = false;
                string popupScript = "<script language='javascript'>alert('तपासणी सूची क्रमांक १ ते २४ मधील सर्व मुद्द्यांसाठी घोषणा करा.!!!!');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
            string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
            using (DbConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (DbTransaction transaction = connection.BeginTransaction())
                {

                    DbCommand dbCmd;
                    using (dbCmd = connection.CreateCommand())
                    {
                        try
                        {
                            foreach (GridViewRow grv in gvEWC_Check.Rows)
                            {
                                int status = 0;
                                Label lblcode = (Label)grv.FindControl("lblwc_code");
                                RadioButtonList rblist = (RadioButtonList)grv.FindControl("rblist");
                                if (rblist.SelectedValue == "Y")
                                    status = 1;
                                else if (rblist.SelectedValue == "N")
                                    status = 0;
                                objedit.funUpdateValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails", "total_ror =" + lblTotalror.Text.ToString() + ", total_reedited_ror=" + txtCorrectedRor.Text.ToString() + ", total_khata_no=" + lblTotal_khata.Text.ToString() + ", total_reedited_khata_no=" + txtCorrectedkhata.Text.ToString() + "", " ccode='" + Convert.ToString(Session["ccode"]) + "'", ref dbCmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status", " ccode='" + Convert.ToString(Session["ccode"]) + "' and  wc_code=" + Convert.ToInt32(lblcode.Text.ToString()) + "", ref dbCmd);
                                objedit.funInserSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status", " ccode, wc_code, status_code", " '" + Convert.ToString(Session["ccode"]) + "'," + Convert.ToInt32(lblcode.Text.ToString()) + "," + status + "", ref dbCmd);

                            }
                            transaction.Commit();
                            btn_ShowReport.Enabled = true;
                            string popupScript = "<script language='javascript'>alert('माहिती साठवली आहे .....!!!!');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        }
                        catch (Exception exp)
                        {
                            transaction.Rollback();
                        }

                    }
                }
                connection.Close();
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
    protected void btn_ShowReport_Click(object sender, EventArgs e)
    {
        try
        {
            string out_value = objedit.funCheckEWC_status(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]), Convert.ToString(Session["ccode"]));
            if (out_value == "Yes")
            {
                string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
                using (DbConnection connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (DbTransaction transaction = connection.BeginTransaction())
                    {

                        DbCommand dbCmd;
                        using (dbCmd = connection.CreateCommand())
                        {
                            try
                            {
                                objedit.funUpdateValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails", "ewc_status =true", " ccode='" + Convert.ToString(Session["ccode"]) + "'", ref dbCmd);
                                transaction.Commit();
                                connection.Close();
                                //Response.Redirect("rtpDeclrationII.aspx");
                                this.OpenNewWindow(1, "rtpDeclrationII.aspx");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                connection.Close();
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
                }
            }
            else
            {
                Session["outvalue"] = out_value;
                //objedit.funUpdateValue1(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status", "status_code ='0'", " ccode='" + Convert.ToString(Session["ccode"]) + "'");

                string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
                using (DbConnection connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (DbTransaction transaction = connection.BeginTransaction())
                    {

                        DbCommand dbCmd;
                        using (dbCmd = connection.CreateCommand())
                        {
                            try
                            {
                                //objedit.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status", " ccode='" + Convert.ToString(Session["ccode"]) + "'", ref dbCmd);
                                //objedit.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails", " ccode='" + Convert.ToString(Session["ccode"]) + "'", ref dbCmd);
                                //objedit.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3", " ccode='" + Convert.ToString(Session["ccode"]) + "'", ref dbCmd);
                                //transaction.Commit();
                                connection.Close();
                                this.OpenNewWindow(1, "rptDeclration_CrossCheck.aspx");
                                this.OpenNewWindow(2, "rpt_summary.aspx");
                                this.OpenNewWindow(3, "rpt_summary_26.aspx");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                connection.Close();
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
    public void OpenNewWindow(int filecnt,string filename)
    {

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "newWindow", String.Format("<script>window.open('{0}');</script>", url));
        //Response.Write("<script type='text/javascript'>window.open('rptDeclration_CrossCheck.aspx','_blank');window.open('rpt_summary.aspx','_blank');window.open('rpt_summary_26.aspx','_blank');</script>");
        //Response.Redirect("<script type='text/javascript'>window.open('rptDeclration_CrossCheck.aspx','_blank');window.open('rpt_summary.aspx','_blank');window.open('rpt_summary_26.aspx','_blank');</script>");
        Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_File" + filecnt, "window.open('" + filename + "','_blank');", true);
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_File2", "window.open('rpt_summary.aspx','_blank');", true);
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Popup_File3", "window.open('rpt_summary_26.aspx','_blank');", true);

    }

    public Boolean isReEdit712WorkAprroved(string databasename, string schemaname, string ccode)
    {
        if (objedit.funReturnSingleValue(databasename, schemaname + ".edit_mut_new", "(case when count(*)>0 then false else true end) as Aprroved_status", "ccode='" + ccode + "' and  approve_flag<>'Approve'", "").ToLower() == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}