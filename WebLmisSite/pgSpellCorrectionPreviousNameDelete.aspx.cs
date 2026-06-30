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

public partial class pgSpellCorrectionPreviousNameDelete : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction obj = new clsCommonFunction();
    string page_name = "pgSpellCorrectionPreviousNameDelete";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
            if (Convert.ToUInt32(userExist) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
            }
            Session["page_heading"] = "एडीट आज्ञावलीद्वारे नावांची स्पेलिंग दुरुस्ती केल्याने तयार झालेल्या अहवाल ७ ची दुरुस्ती";
            prev();
        }
    }
  
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int cnt = 0;
        if ((DataTable)Session["dt"] != null)
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
                            DataTable dt = (DataTable)Session["dt"];

                            for (int i = 0; i < gdvSpellCorrPrevNames.Rows.Count; i++)
                            {
                                if (((CheckBox)gdvSpellCorrPrevNames.Rows[i].FindControl("chkselect")).Checked == true)
                                {
                                    con.funDeleteRecordSevarthID((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".holder_detail", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + dt.Rows[i]["khata_no"].ToString() + "' and fname='" + dt.Rows[i]["fname"].ToString() + "' and mname='" + dt.Rows[i]["mname"].ToString() + "' and lname='" + dt.Rows[i]["lname"].ToString() + "' and topan_name='" + dt.Rows[i]["topan_name"].ToString() + "' ", Convert.ToString(Session["UserName"]), ref dbCommand);
                                    cnt = 1;
                                }
                            }
                            dbTransaction.Commit();
                            if (cnt == 1)
                            {
                                string popupScript = "<script language='javascript'>alert('माहिती साठवली.');</script>";
                                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                prev();
                            }
                            else
                            {
                                string popupScript = "<script language='javascript'>alert(' दुरुस्तीसाठी  रेकॉर्ड  निवडले नाही. ');</script>";
                                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                prev();
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
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("pgVillageSelection.aspx",false);
    }
    protected void chkeffect_CheckedChanged(object sender, EventArgs e)
    {
        if (((CheckBox)gdvSpellCorrPrevNames.HeaderRow.FindControl("chkeffect")).Checked == true)
        {

            for (int i = 0; i < gdvSpellCorrPrevNames.Rows.Count; i++)
            {
                ((CheckBox)gdvSpellCorrPrevNames.Rows[i].FindControl("chkselect")).Checked = true;

            }
        }
        else
        {
            for (int i = 0; i < gdvSpellCorrPrevNames.Rows.Count; i++)
            {
                ((CheckBox)gdvSpellCorrPrevNames.Rows[i].FindControl("chkselect")).Checked = false;

            }
        }
    }

    public void prev() 
    {
        DataTable dseditf7k_spell_correction = obj.funReturnDataTable((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_audit", "distinct  khata_no ,fname ,mname,lname,topan_name ,operation ,edit_flag,sr_no", "ccode='" + (string)Session["ccode"] + "' and edit_flag  in ('31','33') and operation in ('OLD','NEW' )  and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8   from " + Session["SchemaName"].ToString() + ".edit_mut_new where ccode='" + (string)Session["ccode"] + "' and  marked_flag='Edit' and confirm_flag<>'Confirm' and approve_flag='Approve')", "sr_no");
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
                    dt = dt.DefaultView.ToTable(true,"khata_no", "fname", "mname", "lname", "topan_name");
                    Session["dt"] = dt;
                    btnSave.Visible = true;
                }
                else
                {
                    btnSave.Visible = false;
                    string popupScript = "<script language='javascript'>alert('माहिती उपल्बध नाही.');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                }
                gdvSpellCorrPrevNames.DataSource = dt;
                gdvSpellCorrPrevNames.DataBind();



            }



        }
        else
        {
            string popupScript = "<script language='javascript'>alert('माहिती उपल्बध नाही.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
}