using System;
using System.Data;
using System.Configuration;
using System.Data.Common;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using NIC.WebLMISLibrary;
using Npgsql;

public partial class papatr3form : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    clsCommonFunction con = new clsCommonFunction();
    StringBuilder sb = new StringBuilder();
    string page_name = "papatr3form";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (!Page.IsPostBack)
            {
                int _712cnt = 0;
                btnSave.Enabled = true;
                int cnt = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".tblewc_proforma3", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");
                Session["page_heading"] = "अचुक गाव नमुना ७/१२ व ८अ  साठी काम पुर्ण झाल्याचे अंतिम प्रमाणपत्र ( Declaration-III ) ची माहिती भरणे.";
                string talathiname = string.Empty;
                string circlename = string.Empty;
                string dbaname = string.Empty;



                if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b, " + Convert.ToString(Session["SchemaName"]) + ".m_ewc_checks as c", "(case when count(a.*)>11 then true else false end) as d2status", "a.ccode ='" + Session["ccode"].ToString() + "' and  a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true and  a.wc_code=c.wc_code and  c.check_type='S'   and a.ccode  in  (  select    ccode  from " + Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3  where ccode ='" + Session["ccode"].ToString() + "')", "")) == false)
                {
                    this.EnableDisableConrols();
                    string popupScript = "<script language='javascript'>alert('सदर गावाचे  घोषणापत्र -II ( DECLARATION-II )  चे काम  पूर्ण  झाल्याशिवाय   घोषणापत्र -III ( DECLARATION-III )  ची माहिती भरता येणार नाही याची नोंद घ्यावी.!!!!!!');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
                if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails", "(case when count(*)=1 then true else false end) as d3status ", "ccode ='" + Session["ccode"].ToString() + "'   and dba_d2_status=true ", "")) == true)
                {
                    this.EnableDisableConrols();
                    string popupScript = "<script language='javascript'>alert('सदर गावासाठी   घोषणापत्र -III ( DECLARATION-III ) ची डी.बी.ए यांनी भरावयाची माहिती यापूर्वी भरली  असल्यामुळे  घोषणापत्र -III ( DECLARATION-III )  ची  माहिती भरता येणार नाही याची नोंद घ्यावी.!!!!!!');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }

                int rec_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' ", "");
                if (rec_cnt > 0)
                {
                    int date_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  khata_master_declaration =false and khata_master_declair_date  isnull", "");
                    if (date_cnt != 0)
                    {
                        // Declaration - II [ Re-Edit Module मधील काम पूर्ण झाल्याचे तलाठी यांचे स्वयंघोषणापत्र ] करण्यापुर्वी   Declaration - I [ संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची तलाठी स्वयं घोषणा ] करणे आवश्यक आहे याची नोंद घ्यावी.
                        this.EnableDisableConrols();
                        string popupScript = "<script language='javascript'>alert('Declaration - III करण्यापुर्वी  Declaration - I [ संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्राम महसूल अधिकारी स्वयं घोषणा ]  ,  Declaration - II [ Re-Edit Module मधील काम पूर्ण झाल्याचे ग्राम महसूल अधिकारी यांचे स्वयंघोषणापत्र ] करणे आवश्यक आहे याची नोंद घ्यावी. ' );</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;

                    }
                }
                else
                {
                    this.EnableDisableConrols();
                    string popupScript = "<script language='javascript'>alert('Declaration - III करण्यापुर्वी  Declaration - I [ संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्राम महसूल अधिकारी स्वयं घोषणा ]  ,  Declaration - II [ Re-Edit Module मधील काम पूर्ण झाल्याचे ग्राम महसूल अधिकारी यांचे स्वयंघोषणापत्र ] करणे आवश्यक आहे याची नोंद घ्यावी. ' );</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }


                int chkOffDetails = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".tbl_ewc_officerdetails ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and ewc_status='true' ", "");
                if (chkOffDetails == 0)
                {
                    this.EnableDisableConrols();
                    string popupScript1 = "<script language='javascript'>alert('Declaration - II [माहिती तपासणी  सुची १- २४ ] चे काम पुर्ण झाल्याशिवाय प्रपत्र - ३ बघता येनार नाही.');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
                    return;
                }

                string reoffchkdate = string.Empty;
                DataSet dsDec3Details = con.funReturnDataSet((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".tblewc_proforma3", "ccode, village_name, taluka_ccode, taluka_name, district_ccode, district_name, tal_name, tal_sevarth, co_name, co_sevarth, dba_name,dba_sevarth, tah_name, tah_sevarth, col_name, col_sevarth, sdo_name,sdo_sevarth, revoff_name, revoff_sevarth, revoff_checkdate, ah1remark,ah2remark, docremark, prapatr2remark, tal_712cnt, co_712cnt, dba_712cnt, tah_712cnt, col_712cnt, sdo_712cnt, to_char(tal_chkdate,'dd/MM/yyyy')as  tal_chkdate,to_char(co_chkdate,'dd/MM/yyyy')as  co_chkdate,to_char(dba_chkdate,'dd/MM/yyyy')as  dba_chkdate,to_char(tah_chkdate,'dd/MM/yyyy')as  tah_chkdate,to_char(col_chkdate,'dd/MM/yyyy')as  col_chkdate,to_char(sdo_chkdate,'dd/MM/yyyy')as  sdo_chkdate,info_save_date", "ccode='" + Convert.ToString(Session["VillageDetail"]).Split('#')[0] + "'", "");
                reoffchkdate = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".tbl_ewc_officerdetails ", "to_char(ewc_date,'dd/MM/yyyy')as  ewc_date ", "ccode='" + Convert.ToString(Session["ccode"]) + "' and ewc_status='true' ", "");
                if (dsDec3Details != null && dsDec3Details.Tables[0].Rows.Count > 0)
                {
                    btnSave.Enabled = true;
                    lblVillageName.Text = Convert.ToString(Session["VillageDetail"]).Split('#')[1];
                    lblCcode.Text = Convert.ToString(Session["ccode"]);
                    lblTalukaName.Text = Convert.ToString(Session["TalukaName"]);
                    lblDistrictName.Text = Convert.ToString(Session["DistrictName"]);
                    lblTalathiName.Text = dsDec3Details.Tables[0].Rows[0]["tal_name"].ToString();
                    lblTalathiSevarth.Text = dsDec3Details.Tables[0].Rows[0]["tal_sevarth"].ToString();
                    lblCOName.Text = dsDec3Details.Tables[0].Rows[0]["co_name"].ToString();
                    lblCOSevarth.Text = dsDec3Details.Tables[0].Rows[0]["co_sevarth"].ToString();
                    lblCOSevarthTable.Text = dsDec3Details.Tables[0].Rows[0]["co_sevarth"].ToString();
                    lblTalathiSevarthTable.Text = dsDec3Details.Tables[0].Rows[0]["tal_sevarth"].ToString();
                    lblDBASevarthtbl.Text = dsDec3Details.Tables[0].Rows[0]["dba_sevarth"].ToString();

                    lblTalathiNameTable.Text = dsDec3Details.Tables[0].Rows[0]["tal_name"].ToString();
                    lblCONameTable.Text = dsDec3Details.Tables[0].Rows[0]["co_name"].ToString();
                    lbldbaNameTable.Text = dsDec3Details.Tables[0].Rows[0]["dba_name"].ToString();
                    lblTahNameTable.Text = dsDec3Details.Tables[0].Rows[0]["tah_name"].ToString();
                    lblTahSevarthtbl.Text = dsDec3Details.Tables[0].Rows[0]["tah_sevarth"].ToString();

                    lblRevOffName.Text = dsDec3Details.Tables[0].Rows[0]["revoff_name"].ToString();
                    lblRevOffSevarth.Text = dsDec3Details.Tables[0].Rows[0]["revoff_sevarth"].ToString();
                    lblRevOffCheckDate.Text = reoffchkdate;

                    lblSdoNametable.Text = dsDec3Details.Tables[0].Rows[0]["sdo_name"].ToString();
                    lblSdoSevarthtable.Text = dsDec3Details.Tables[0].Rows[0]["sdo_sevarth"].ToString();

                    lblColNametable.Text = dsDec3Details.Tables[0].Rows[0]["col_name"].ToString();
                    lblColSevarthtable.Text = dsDec3Details.Tables[0].Rows[0]["col_sevarth"].ToString();

                    lblTal712Cnt.Text = dsDec3Details.Tables[0].Rows[0]["tal_712cnt"].ToString();
                    lblCO712Cnt.Text = dsDec3Details.Tables[0].Rows[0]["co_712cnt"].ToString();
                    lblDBA712Cnt.Text = dsDec3Details.Tables[0].Rows[0]["dba_712cnt"].ToString();
                    lblTah712Cnt.Text = dsDec3Details.Tables[0].Rows[0]["tah_712cnt"].ToString();
                    lblSDO712Cnt.Text = dsDec3Details.Tables[0].Rows[0]["sdo_712cnt"].ToString();
                    lblCOL712Cnt.Text = dsDec3Details.Tables[0].Rows[0]["col_712cnt"].ToString();


                    lblTalDate.Text = dsDec3Details.Tables[0].Rows[0]["tal_chkdate"].ToString();
                    lblCODate.Text = dsDec3Details.Tables[0].Rows[0]["co_chkdate"].ToString();
                    lblDBADate.Text = dsDec3Details.Tables[0].Rows[0]["dba_chkdate"].ToString();
                    lblTahDate.Text = dsDec3Details.Tables[0].Rows[0]["tah_chkdate"].ToString();
                    lblSdoDate.Text = dsDec3Details.Tables[0].Rows[0]["col_chkdate"].ToString();
                    lblColDate.Text = dsDec3Details.Tables[0].Rows[0]["sdo_chkdate"].ToString();

                    //_712cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".form7 ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");
                }
            }
            if (Convert.ToString(Session["ccode"]) != "")
            {
                int maxkhata = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".holder_detail ", "count( distinct khata_no::int)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no not in ('TKN','0' ,'' ,'  ','500001') ", "");
                sb.Append("<body>");
            }
            else
            {
                string popupScript = "<script language='javascript'>alert('कृपया गाव निवडा.' );</script>";
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
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript1 = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
        }
    }
    void EnableDisableConrols()
    {
        btnSave.Enabled = false;
        rdbAh1No.Enabled = false;
        rdbAh1Yes.Enabled = false;
        rdbAh2No.Enabled = false;
        rdbAh2Yes.Enabled = false;
        rdbDocNo.Enabled = false;
        rdbDocYes.Enabled = false;
        rdbPrapatr2No.Enabled = false;
        rdbPrapatr2Yes.Enabled = false;
    }
    protected void rblAhwalCheck_SelectedIndexChanged(object sender, EventArgs e)
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
                    dbCommand.CommandType = CommandType.Text;
                    try
                    {
                        if ((rdbAh1No.Checked == true || rdbAh1Yes.Checked == true) && (rdbAh2No.Checked == true || rdbAh2Yes.Checked == true) && (rdbDocNo.Checked == true || rdbDocYes.Checked == true) && (rdbPrapatr2No.Checked == true || rdbPrapatr2Yes.Checked == true))
                        {
                            string ah1 = string.Empty;
                            string ah2 = string.Empty;
                            string doc = string.Empty;
                            string prapatr2 = string.Empty;
                            if (rdbAh1Yes.Checked == true)
                            {
                                ah1 = "होय";
                            }
                            else
                            {
                                ah1 = "नाही";
                            }

                            if (rdbAh2Yes.Checked == true)
                            {
                                ah2 = "होय";
                            }
                            else
                            {
                                ah2 = "नाही";
                            }

                            if (rdbDocYes.Checked == true)
                            {
                                doc = "होय";
                            }
                            else
                            {
                                doc = "नाही";
                            }

                            if (rdbPrapatr2Yes.Checked == true)
                            {
                                prapatr2 = "होय";
                            }
                            else
                            {
                                prapatr2 = "नाही";
                            }

                            //con.funUpdateValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".tblewc_proforma3", "ah1remark='" + ah1 + "',ah2remark='" + ah2 + "', docremark='" + doc + "', prapatr2remark='" + prapatr2 + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'", Convert.ToString(Session["UserName"]));
                            con.funUpdateValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".tbl_ewc_officerdetails", "dba_d2_status=true", "ccode='" + Convert.ToString(Session["ccode"]) + "'", Convert.ToString(Session["UserName"]));
                            dbTransaction.Commit();
                            btnSave.Enabled = false;
                            btnRpt.Visible = false;
                            string popupScript1 = "<script language='javascript'>alert('माहिती साठवली आहे. तथापी  UserCreation अद्यावलीद्वारे  तहसिलदार यांचे लॉगीन करून  DECLARATION-III ची  कार्यवाही पूर्ण करावी. ');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);

                        }
                        else
                        {
                            string popupScript = "<script language='javascript'>alert('कृपया सर्व  माहिती  भरा....!!!!');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                            return;
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
                connection.Close();
            }
        }
    }

    protected void rdbAh1Yes_CheckedChanged(object sender, EventArgs e)
    {
        rdbAh1No.Checked = false;
    }
    protected void rdbAh1No_CheckedChanged(object sender, EventArgs e)
    {
        rdbAh1Yes.Checked = false;
    }
    protected void rdbAh2Yes_CheckedChanged(object sender, EventArgs e)
    {
        rdbAh2No.Checked = false;
    }
    protected void rdbAh2No_CheckedChanged(object sender, EventArgs e)
    {
        rdbAh2Yes.Checked = false;
    }
    protected void rdbDocYes_CheckedChanged(object sender, EventArgs e)
    {
        rdbDocNo.Checked = false;
    }
    protected void rdbDocNo_CheckedChanged(object sender, EventArgs e)
    {
        rdbDocYes.Checked = false;
    }
    protected void btnRpt_Click(object sender, EventArgs e)
    {
        int chkOffDetails = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".tbl_ewc_officerdetails ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and ewc_status='true' ", "");
        if (chkOffDetails > 0)
        {
            //Response.Redirect("papatr3.aspx", false);
            Response.Redirect("rptThirdDeclaration.aspx", false);
        }
        else
        {
            string popupScript1 = "<script language='javascript'>alert('Declaration - II  [ माहिती तपासणी  सुची १- २४  ] चे काम पुर्ण झाल्याशिवाय प्रपत्र - ३ बघता येनार नाही.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
        }

    }
    protected void rdbPrapatr2Yes_CheckedChanged(object sender, EventArgs e)
    {
        rdbPrapatr2No.Checked = false;
    }
    protected void rdbPrapatr2No_CheckedChanged(object sender, EventArgs e)
    {
        rdbPrapatr2Yes.Checked = false;
    }
}