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

public partial class pgKhataNoDataDiscrCorrection : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction obj = new clsCommonFunction();
    string page_name = "खाता प्रोसेसिंगसाठी निवडुन केलेल्या दुरुस्त्यांची माहिती खाता मास्टर प्रमाणे पुर्ववत करणे";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["page_heading"] = "खाता प्रोसेसिंग साठी निवडुन केलेल्या दुरुस्त्यांची माहिती खाता मास्टर प्रमाणे पुर्ववत करणे";
           

            int date_cnt = obj.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_master_declaration = false and khata_master_declair_date  isnull  ", "");
            if (date_cnt == 0)
            {
                int row_cnt = obj.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' ", "");
                if (row_cnt > 0)
                {
                    btnKhataNo.Enabled = false;
                    btnSave.Enabled = false;
                    string popupScript = "<script language='javascript'>alert('संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे ही माहिती या पुर्वीच साठवली आहे याची नोंद घ्यावी.' );</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
            }
            txtKhataNo.Focus();
            btnKhataNo.Enabled = true;
        }
    }
    protected void btnKhataNo_Click(object sender, EventArgs e)
    {
        DataTable edhddt = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "fname,mname,lname,topan_name", "ccode='" + Convert.ToString(Session["ccode"]) + "' and trim(khata_no)='" + txtKhataNo.Text.Trim() + "' and  edit_flag<>'34'  and edit_flag<>'40'", "old_mut_no,usrno");
        if(edhddt.Rows.Count > 0)
        {
            DataTable hddt = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".holder_detail", "fname,mname,lname,topan_name", "ccode='" + Convert.ToString(Session["ccode"]) + "' and trim(khata_no)='" + txtKhataNo.Text.Trim() + "' ", "old_mut_no,usrno");
            if (hddt.Rows.Count > 0)
            {
                pnlkhataDetails.Visible = true;
                pnlProcessing.Visible = true;
                gdvkhataDetails.DataSource = hddt.DefaultView;
                gdvkhataDetails.DataBind();
                gdvProcessData.DataSource = edhddt.DefaultView;
                gdvProcessData.DataBind();
                btnSave.Enabled = true;
                lblOriginalKhataMaster.Visible = true;
                lblProcessingData.Visible = true;
            }
            else
            {
                btnSave.Enabled = false;
                string popupScript = "<script language='javascript'>alert('खाता क्रमांकाची माहिती उपलब्ध नाही.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
        }
        else
        {
            edhddt = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "fname,mname,lname,topan_name", "ccode='" + Convert.ToString(Session["ccode"]) + "' and trim(khata_no)='" + txtKhataNo.Text.Trim() + "' ", "old_mut_no,usrno");
            if (edhddt.Rows.Count > 0)
            {
                btnSave.Enabled = true;
                string popupScript = "<script language='javascript'>alert('खात्यावरील सर्व नावे वगळण्यात आली आहेत.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
            else
            {
                btnSave.Enabled = false;
                string popupScript = "<script language='javascript'>alert('निवडलेला खाता क्रमांक खाता प्रोसेसींगसाठी निवडलेला नाही.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        btnSave.Enabled = false;
        txtKhataNo.Text = String.Empty;
        pnlkhataDetails.Visible = false;
        pnlProcessing.Visible = false;
        gdvkhataDetails.DataSource = null;
        gdvkhataDetails.DataBind();
        gdvProcessData.DataSource = null;
        gdvProcessData.DataBind();
        lblOriginalKhataMaster.Visible = false;
        lblProcessingData.Visible = false;
       
    }
    protected void txtKhataNo_TextChanged(object sender, EventArgs e)
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
                    dbCommand.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        con.funDeleteRecordSevarthID(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp", "ccode='" + Convert.ToString(Session["ccode"]) + "' and trim(khata_no)='" + txtKhataNo.Text.Trim() + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                        con.funDeleteRecordSevarthID(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_form7_khata_kp", "ccode='" + Convert.ToString(Session["ccode"]) + "' and trim(khata_no)='" + txtKhataNo.Text.Trim() + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                        dbTransaction.Commit();
                        txtKhataNo.Text = String.Empty;
                        pnlkhataDetails.Visible = false;
                        pnlProcessing.Visible = false;
                        gdvkhataDetails.DataSource = null;
                        gdvkhataDetails.DataBind();
                        gdvProcessData.DataSource = null;
                        gdvProcessData.DataBind();
                        lblOriginalKhataMaster.Visible = false;
                        lblProcessingData.Visible = false;
                        string popupScript = "<script language='javascript'>alert('खात्याची माहिती पुर्ववत करण्यात आली आहे.');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandling excpt = new ExceptionHandling();
                        if (Session["UserName"] != null)
                            Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
                        else
                            Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                            return;
                    }
                }
            }
            connection.Close();
        }
    }
    protected void btnCan_Click(object sender, EventArgs e)
    {
        txtKhataNo.Text = String.Empty;
        pnlkhataDetails.Visible = false;
        pnlProcessing.Visible = false;
        gdvkhataDetails.DataSource = null;
        gdvkhataDetails.DataBind();
        gdvProcessData.DataSource = null;
        gdvProcessData.DataBind();
        lblOriginalKhataMaster.Visible = false;
        lblProcessingData.Visible = false;
    }
}