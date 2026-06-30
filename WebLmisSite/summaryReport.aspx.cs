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

public partial class summaryReport : System.Web.UI.Page
{
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
        clscommonfunDB objclscommonfunDB = new clscommonfunDB("Tahsil Connection String");
        string schemaName = Convert.ToString(Session["Schema"]);
        try
        {
            DataSet dsSummary = new DataSet();
            dsSummary = objclscommonfunDB.funReturnDataSet(Convert.ToString(Session["DataBase"]), "rcis_uni.db_objects_summary", "*", "", "schema_name");

            Response.Write("<table rules='all' style='border-right: #000000 thin solid; border-top: #000000 thin solid;");
            Response.Write("border-left: #000000 thin solid; border-bottom: #000000 thin solid' width='100%'>");
            Response.Write("<tr>");
            Response.Write("<td style='width: 100px; height: 23px; text-align: center;'>");
            Response.Write("Schema Name</td>");
            Response.Write("<td style='width: 100px; height: 23px; text-align: center;'>");
            Response.Write("ObjectType</td>");
            Response.Write("<td style='width: 100px; height: 23px; text-align: center;'>");
            Response.Write("Total Count</td>");
            Response.Write("<td style='width: 100px; height: 23px; text-align: center;'>");
            Response.Write("Actual Count</td>");
            Response.Write("</tr>");
            for (int i = 0; i < dsSummary.Tables[0].Rows.Count; i++)
            {                
                Response.Write("<tr>");
                Response.Write("<td style='width: 100px; height: 21px; text-align: center;'>");
                Response.Write(Convert.ToString(dsSummary.Tables[0].Rows[i]["schema_name"]));                
                Response.Write("</td>");
                Response.Write("<td style='width: 100px; height: 21px; text-align: center;'>");
                Response.Write(Convert.ToString(dsSummary.Tables[0].Rows[i]["object_type"]));
                Response.Write("</td>");
                Response.Write("<td style='width: 100px; height: 21px; text-align: center;'>");
                Response.Write(Convert.ToString(dsSummary.Tables[0].Rows[i]["total_count"]));
                Response.Write("</td>");
                Response.Write("<td style='width: 100px; height: 21px; text-align: center;'>");
                Response.Write(Convert.ToString(dsSummary.Tables[0].Rows[i]["actual_count"]));
                Response.Write("</td>");
                Response.Write("</tr>");
            }
            Response.Write("</table>");
        }
        catch (Exception ex)
        {
            string popupScript = "<script language='javascript'>alert('In edit() : " + ex.Message.Replace("'", " ") + " ');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
}
