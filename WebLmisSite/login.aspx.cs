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
using NIC.WebLMISLibrary;
using System.Data.Common;
public partial class pgLogin : System.Web.UI.Page
{
    #region "-----Global Variable----"

    clsCommonFunction objclscommonfun = new clsCommonFunction();

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
        if (!Page.IsPostBack)
        {
            Session["date1"] = System.DateTime.Now;
            Session["SchemaName"] = "rcis_uni";
        }
        lblerror.Text = "";
    }

    #endregion

    #region "---Button Click Event---"

    protected void cmdLogin_Click(object sender, EventArgs e)
    {
        if (Session["SchemaName"].ToString() != "")
        {
            string username = objclscommonfun.funReturnstring(Session["SchemaName"].ToString() + ".tblloginmaster", "loginid ||'#'||  loginpassword  ||'#'|| usertype as userdetail", Convert.ToString(txtLoginName.Text) ,Convert.ToString(txtPassword.Text), "");
            if (txtLoginName.Text == username.Split('#')[0].ToString() && txtPassword.Text == username.Split('#')[1].ToString())
            {

                Session["LoginName"] = txtLoginName.Text;
                Session["usertype"] = username.Split('#').ToString()[2].ToString();
                Response.Redirect("FAQreply.aspx");
            }
            else
                lblerror.Text = "Incorrect ID-Password";
        }
        else
        {
            lblerror.Text = "Select District";
        }
    }

    #endregion

    protected void btnhome_Click(object sender, EventArgs e)
    {
        Response.Redirect("pgWelCome.aspx");
    }
}
