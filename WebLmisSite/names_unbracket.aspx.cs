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
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Net;
using System.Globalization;
using System.Web.Caching;

public partial class names_unbracket : System.Web.UI.Page
{

    string page_name = "pgEdit712";
    clscommonfun con = new clscommonfun();
    clsCommonFunction obj = new clsCommonFunction();
    clscommonfunedit objedit = new clscommonfunedit();


    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            Session["page_heading"] = "गावातील सर्व खातेदारांच्या नावाचा कंस काढणे";
        }
    }
    protected void btnNamesunbracket_Click(object sender, EventArgs e)
    {

        if (Convert.ToString(Session["ccode"]) != string.Empty)
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
                        //----- (string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString()
                        try
                        {
                            objedit.funUpdateValueSevarthID(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7_khata", "marked=''", "ccode = '" + Convert.ToString(Session["ccode"]) + "'", Convert.ToString(Session["UserName"]),ref dbCommand);
                            obj.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".ror_bulk_sign_data", "census_code='" + Session["ccode"].ToString() + "'");
                            obj.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".ror_sign_tables", "ccode='" + Session["ccode"].ToString() + "'");
                            dbTransaction.Commit();
                            string popupScript = "<script language='javascript'>alert('माहिती साठवली');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                            return;
                        }
                        catch (Exception ex)
                        {

                            ExceptionHandling excpt = new ExceptionHandling();
                            if (Session["LoginID"] != null)
                                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
                            else
                                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";


                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        }
                    }
                }
                connection.Close();
            }
        }
        else
        {
            string popupScript = "<script language='javascript'>alert('कृपया, कामाची सुरुवात करण्यापूर्वी गावाची निवड करा.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            return;
        }
    }
}