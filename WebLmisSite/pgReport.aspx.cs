using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIC.WebLMISLibrary;
public partial class pgReport : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    string page_name = "pgReport";
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Convert.ToString(Session["user_type"]) == "T")
        {
            this.MasterPageFile = "~/InnerMaster.master";
        }
        else if (Convert.ToString(Session["user_type"]) == "C")
        {
            this.MasterPageFile = "~/circlemaster.master";
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
            if (Convert.ToUInt32(userExist) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
            }
            Session["page_heading"] = "आदेश व परिशिष्ट ब";

        }
    }
    protected void grd_mutation_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["MutationDetail"] = grd_mutation.SelectedRow.Cells[1].Text + "#";

        Session["mut_no"] = Convert.ToString(Session["MutationDetail"]).Split('#')[0];
        Session["sub_mut_name"] = Convert.ToString(Session["MutationDetail"]).Split('#')[1];
        ClientScript.RegisterStartupScript(this.GetType(), "आदेश व परिशिष्ट ब", String.Format("<script>window.open('{0}');</script>", "FerfarOLDNEW_summary.aspx?report=mutno"));
    }
    protected void rbtnlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            clscommonfunedit objclscommonfunedit = new clscommonfunedit();
            if (rbtnlist.SelectedValue == "1")
            {
                pnlmutno.Visible = true;
                pnltransno.Visible = false;
                objclscommonfunedit.funSetGridList((string)Session["DataBaseName"], ref grd_mutation, (string)Session["SchemaName"] + ".mutregister_audit as mr,  " + (string)Session["SchemaName"] + ".m_village_census as v, " + (string)Session["SchemaName"] + ".edit_mut_new e ", "distinct  mr.mut_no,mr.mut_name", " mr.ccode='" + Convert.ToString(Session["VillageDetail"]).Split('#')[0] + "' and mr.ccode=v.ccode and mr.ccode=e.ccode and e.edit_mut_no=mr.mut_no and mr.mut_type=101 and e.lock_flag='Lock'   and mr.app_name='reEdit'  and e.edit_appname='reEdit'", "mr.mut_no");
                int cnt = grd_mutation.Rows.Count;
                if (cnt > 0)
                {
                    grd_mutation.HeaderRow.Cells[1].Text = "फेरफार क्रमांक";
                    grd_mutation.HeaderRow.Cells[2].Text = "फेरफार प्रकार";
                }
            }
            else if (rbtnlist.SelectedValue == "2")
            {
                pnlmutno.Visible = false;
                pnltransno.Visible = true;
                objclscommonfunedit.funSetDropDownList((string)Session["DataBaseName"], ref ddltransno, (string)Session["SchemaName"] + ".mut_deal_audit as m ," + (string)Session["SchemaName"] + ".edit_mut_new e ", "distinct  m.deal_text_old::int,m.deal_text_old", "m.ccode='" + Convert.ToString(Session["VillageDetail"]).Split('#')[0] + "' and m.ccode=e.ccode and e.edit_mut_no=m.mut_no and e.edit_appname='reEdit' and   m.deal_text_old <>'' and app_name='reEdit'", "m.deal_text_old::INT");
                
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
    protected void ddltransno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int tranno = Convert.ToInt32(ddltransno.SelectedValue);
            Session["transno"] = tranno;
            ClientScript.RegisterStartupScript(this.GetType(), "आदेश व परिशिष्ट ब", String.Format("<script>window.open('{0}');</script>", "FerfarOLDNEW_summary.aspx?report=transno"));

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
}