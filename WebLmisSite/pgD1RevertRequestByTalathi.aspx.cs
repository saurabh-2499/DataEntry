using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
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

public partial class pgD1RevertRequestByTalathi : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
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
                    lblVillName.Text = Convert.ToString(Session["VillageDetail"]).Split('#')[1];
                }
                Session["page_heading"] = "घोषणापत्र -I( DECLARATION-I ) पूर्ववत(Revert) करणेसाठी DBA कडे  Request करणे.";
                if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp", "(case when count(*)=0 then true else false end) as isd1Started ", "ccode ='" + Session["ccode"].ToString() + "' ", "")) == true)
                {

                    this.disableControls();
                    string popupScript = "<script language='javascript'>alert('सदर गावाचे  खाता मास्टर चे काम अद्याप सुरु करणेत आलेले नाही  याची नोंद घ्यावी.!!!!!!');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
                if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp", "(case when count(*)>=1 then true else false end) as isd1declaired ", "ccode ='" + Session["ccode"].ToString() + "' and khata_master_declaration=false", "")) == true)
                {
                    this.disableControls();
                    string popupScript = "<script language='javascript'>alert('सदर गावाचे  खाता मास्टर च्या कामाचे घोषणापत्र -I ( DECLARATION-I ) सबंधित ग्राम महसूल अधिकारी यांनी अद्याप  केलेले नाही याची नोंद घ्यावी.!!!!!!');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
                if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b, " + Convert.ToString(Session["SchemaName"]) + ".m_ewc_checks as c", "(case when count(a.*)>11 then true else false end) as d2status", "a.ccode ='" + Session["ccode"].ToString() + "' and  a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true and  a.wc_code=c.wc_code and  c.check_type='S' ", "")) == true)
                {
                    this.disableControls();
                    string popupScript = "<script language='javascript'>alert('सदर गावाचे  घोषणापत्र -II ( DECLARATION-II ) झाले असल्यामुळे  घोषणापत्र -I ( DECLARATION-I ) चे काम पूर्ववत(REVERT) करता येणार नाही याची नोंद घ्यावी.!!!!!!');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }

                if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3", "(case when count(*)=1 then true else false end) as d3status ", "ccode ='" + Session["ccode"].ToString() + "'   and  trim(ah1remark)='होय' and trim(ah2remark)='होय' and  	trim(docremark)='होय' and  	trim(prapatr2remark)='होय' ", "")) == true)
                {
                    this.disableControls();
                    string popupScript = "<script language='javascript'>alert('सदर गावाचे  घोषणापत्र -III ( DECLARATION-III ) झाले असल्यामुळे  घोषणापत्र -I ( DECLARATION-I ) चे काम पूर्ववत(REVERT) करता येणार नाही याची नोंद घ्यावी.!!!!!!');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }

                if (this.isReEdit712WorkAprroved(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]), Convert.ToString(Session["ccode"])) == false)
                {
                    this.disableControls();
                    string popupScript = "<script language='javascript'>alert('सदर गावात रि -एडीट अद्न्यावालीद्वारे घेणात आलेले फेरफार / परिशिष्ट मंजुरीचे काम पूर्ण करूनच घोषणापत्र -I ( DECLARATION-I ) चे काम पूर्ववत(REVERT) करता येईल याची नोंद घ्यावी .!!!!' );</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
                else
                {
                    lblD1Date.Text=  objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp", "distinct   to_char(khata_master_declair_date,'dd/MM/yyyy') as d1Date", "ccode ='" + Convert.ToString(Session["ccode"]) + "' limit 1", "");
                    //lblVillagetext.Text = Convert.ToString(Session["VillageDetail"]).Split('#')[1] + @" गावाचे  री - एडिट घोषणापत्र -I( DECLARATION-I ) पूर्ववत(Revert) करणेसाठी  ""पूर्ववत करणे "" बटन वर क्लीक करा.";
                }

            }
            catch (Exception ex)
            {
                ExceptionHandling excpt = new ExceptionHandling();
                if (Session["LoginID"] != null)
                    Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
                else
                    Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            }
        }
    }
    void disableControls()
    {
        btnSave.Enabled = false;
        txtRemark.Enabled = false;
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
    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
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
                             objedit.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".revert_d1status", "ccode='" + Convert.ToString(Session["ccode"]) + "'",ref dbCmd);
                             //Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]), Convert.ToString(Session["ccode"])
                             objedit.funInserSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".revert_d1status", "ccode, talathi_sevarth, talathi_name, remark, request_date", "'" + Convert.ToString(Session["ccode"]) + "','" + Convert.ToString(Session["UserName"]) + "','" + Convert.ToString(Session["fullname"]) + "','" + txtRemark.Text.ToString() + "',now()", ref dbCmd);
                             this.disableControls();
                             txtRemark.Text = string.Empty;
                             transaction.Commit();
                             string popupScript = "<script language='javascript'>alert('माहिती साठवली आहे .');</script>";
                             ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                         }
                         catch (Exception ex)
                         {
                             transaction.Rollback();
                             ExceptionHandling excpt = new ExceptionHandling();
                             if (Session["LoginID"] != null)
                                 Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
                             else
                                 Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                             string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                             ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                         }
                     }

                 }
             }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
}