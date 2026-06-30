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

public partial class weblmis : System.Web.UI.MasterPage
{
    protected string theStyleSheet;
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        HttpCookie cookie = Request.Cookies["CookieKey2"];

        if (cookie == null)
        {
            string cookieValue = @"CSS/StyleSheet.css";
            Response.Cookies["CookieKey2"].Value = cookieValue;
            themestyle.Href = @"CSS/StyleSheet.css";
        }
        else
        {
            themestyle.Href = Convert.ToString(cookie.Value);
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lnkgreen_Click(object sender, EventArgs e)
    {
        string cookieValue = @"CSS/Green.css";
        Response.Cookies["CookieKey2"].Value = cookieValue;
        themestyle.Href = @"CSS/Green.css";
    }
    protected void lnkblue_Click(object sender, EventArgs e)
    {
        string cookieValue = @"CSS/StyleSheet.css";
        Response.Cookies["CookieKey2"].Value = cookieValue;
        themestyle.Href = @"CSS/StyleSheet.css";
    }
    protected void lnkgray_Click(object sender, EventArgs e)
    {
        string cookieValue = @"CSS/Gray.css";
        Response.Cookies["CookieKey2"].Value = cookieValue;
        themestyle.Href = @"CSS/Gray.css";
    }
}
