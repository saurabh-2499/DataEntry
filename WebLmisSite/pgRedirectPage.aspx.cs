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

public partial class pgRedirectPage : System.Web.UI.Page
{
   
    
    #region "--------Page Load-------"

   string cross =  "";

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Button1_Click(sender, e);
    }

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


    #region "-----User  Function----"

    //Clear the Page Header
    private void funClearValue()
    {
        Response.ClearHeaders();
        Response.AppendHeader("Cache-Control", "no-cache");            //'HTTP 1.1 
        Response.AppendHeader("Cache-Control", "private");            // HTTP 1.1 
        Response.AppendHeader("Cache-Control", "no-store");            // HTTP 1.1 
        Response.AppendHeader("Cache-Control", "must-revalidate");            // HTTP 1.1 
        Response.AppendHeader("Cache-Control", "max-stale=0");            //HTTP 1.1 
        Response.AppendHeader("Cache-Control", "post-check=0");            // HTTP 1.1 
        Response.AppendHeader("Cache-Control", "pre-check=0");            // HTTP 1.1 
        Response.AppendHeader("Pragma", "no-cache");            //HTTP 1.1 
        Response.AppendHeader("Keep-Alive", "timeout=3, max=993");            // HTTP 1.1 
        Response.AppendHeader("Expires", "Mon, 26 Jul 2006 05:00:00 GMT");            // HTTP 1.1 
    }

    //Store Random String in Cookie & Session & Query String
    private void AntiFixationInit(SFix objSFix)
    {
        cross = objSFix.RandomString(10).ToString();
        HttpCookie objCookie = new HttpCookie("ASPFIXATION");
        Response.Cookies.Add(objCookie);
        objCookie.Values.Add("ASPFIXATION", cross);
        Session["Cross"] = cross;
    }
    #endregion 

    protected void Button1_Click(object sender, EventArgs e)
    {
        //this.funClearValue();

        string DataBaseName = Request.QueryString["DataBase"];
        string SchemaName = Request.QueryString["SchemaName"];
        string UserName = Request.QueryString["LoginName"];
        string Type = Request.QueryString["Type"];
        string Key = Request.QueryString["Key"];

        SFix objSFix = new SFix();
        Session["AuthenticatePage"] = -1;
        string password = objSFix.md5en(objSFix.md5en("pgRedirectPage.aspx") + Key);
        
        AntiFixationInit(objSFix);
        Session["AuthenticatePage"] = 1;
        Session["DataBaseName"] = DataBaseName;
        Session["SchemaName"] = SchemaName;
        Session["UserName"] = UserName;
        string strIPAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        if (Type == "T")
        {
            Response.Redirect("pgTalathiScreen.aspx?&cross=" + cross + "&password=" + password + "&key=" + Key, true);
        }
        else if (Type == "C")
        {
            Response.Redirect("pgEntryverify.aspx?&cross=" + cross + "&password=" + password + "&key=" + Key);
        }

        
        
    }


}
