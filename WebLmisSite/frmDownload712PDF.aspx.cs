using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text.RegularExpressions;
using NIC.WebLMISLibrary;
using System.Data.Common;
using System.Data;
using System.Net;
using System.Configuration;
using Npgsql;
using System.Globalization;


public partial class frmDownload712PDF : System.Web.UI.Page
{
    clscommonfun objclsCommFun = new clscommonfun();
    protected void page_Init(object sender, EventArgs e)
    {
        base.OnPreInit(e);
        //objclsCommFun = new clscommonfun((clsUser)Session["User"]);
       
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["DistCode"]) == "13" && Convert.ToString(Session["TalukaCode"]) == "15")
        {
            DataSet ds = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o", "distinct v.village_code,v.ccode,v.village_name,'' as survey ", " v.ccode=o.ccode  and o.username='" + Convert.ToString(Session["UserName"]) + "'  group by v.village_code,v.ccode,v.village_name", "v.village_name");
        }
       //objclsCommFun.funSetDropDownList(Convert.ToString(Session["DatabaseName"]), ref ddlVillage, Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o", "distinct v.ccode,v.village_name", "v.ccode=o.ccode and o.username='" + userName + "'", "village_name");
            
    }
    protected void ddlVillage_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}