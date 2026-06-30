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

public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if ((string)Session["newsession_id"] != null)
        //{
        //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
        //    {
        //       // Response.Redirect("pgLogout.aspx");
        //    }
        //    else
        //    {
        //        string guid = Guid.NewGuid().ToString();
        //        Session["AuthToken"] = guid;
        //        Response.Cookies.Add(new HttpCookie("AuthToken", guid));
        //    }
        //}
        //else
        //    

    }
}
