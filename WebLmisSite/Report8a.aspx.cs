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

public partial class Report8a : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = Convert.ToString(Cache[Convert.ToString(Session["VillageDetail"]).Split('#')[0] + "8A"]);
       // Response.Write(Convert.ToString(Cache[Convert.ToString(Session["VillageDetail"]).Split('#')[0] + "8A"]));
    }
}
