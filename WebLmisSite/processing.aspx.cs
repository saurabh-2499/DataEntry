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
using NIC.WebLMISLibrary;

public partial class processing : System.Web.UI.Page
{
    //DataTable dt = new DataTable();
    clsCommonFunction objclsCommFun = new clsCommonFunction();
    protected void page_Init(object sender, EventArgs e)
    {
        base.OnPreInit(e);
        //HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
       // HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
       //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //HttpContext.Current.Response.Cache.SetNoStore();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       
        
        string ccode = Convert.ToString(Session["VillageDetail"]).Split('#')[0];

        int total_survey = objclsCommFun.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7", "count(*)", "ccode='" + ccode + "'", "");

        for (int i = 0; i < total_survey; i++)
        {
            int signed = objclsCommFun.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".ror_bulk_sign_data", "count(*)", "census_code='" + ccode + "'", "");
           // i = signed;
            //string popupscript = "<script>alert('" + signed + "')</script>";
            // Write out the parent script callback.
          
            // To be sure the response isn't buffered on the server.
            Response.Flush();

        }
    }
}
