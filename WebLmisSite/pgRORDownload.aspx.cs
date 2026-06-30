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
using LandRecordMasterLibrary;
using System.IO;

public partial class pgRORDownload : System.Web.UI.Page
{

    DataSet ds = new DataSet();
 
    #region [-- Local Variables --]

    clscommonfun con = new clscommonfun();
    
    clscommonfunedit objclscommfunedit = new clscommonfunedit();
    string page_name = "pgRORDownload.aspx";

    #endregion

   

    clsInputEntry objclsInputEntry = new clsInputEntry();
    clscommonfunedit objclscommonfunedit = new clscommonfunedit();
    clscommonfun objclsCommFun = new clscommonfun();
    NIC.WebLMISLibrary.clsCommonFunction objclsCommFunction = new NIC.WebLMISLibrary.clsCommonFunction();
    void Page_PreInit(object sender, EventArgs e)
    {

        if ((string)Session["user_type"] == "C")
        {
            if (this.Page.Master.ToString() != "ASP.circlemaster_master")
                this.Page.MasterPageFile = "~/circlemaster.master";
        }
    }

    protected void page_Init(object sender, EventArgs e)
    {
        base.OnPreInit(e);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["page_heading"] = "Village 7/12 PDF zip for download";
            if (!IsPostBack)
            {

                if (Session["ccode"] == null)
                {
                    string userExist = objclscommfunedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "user_id='" + Convert.ToString(Session["UserName"]) + "' and logout_time is null", "");
                    if (Convert.ToUInt32(userExist) == 0)
                    {
                        objclscommfunedit.funInserSingleRecord(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "session_id, user_id, login_time, logout_time, app_name", "'" + Convert.ToString(Session["newsession_id"]) + "','" + Convert.ToString(Session["UserName"]) + "',now(),null,'reEdit'");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Activex", "MultipleUserLogin();", true);
                    }
                }
                else
                {

                    string userExist = objclscommfunedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
                    if (Convert.ToUInt32(userExist) == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
                    }
                }
                //Session["page_heading"] = "७/१२ पाहुन सर्व्हे/गट क्रमांक हस्तलिखीत/LIMIS ७/१२ पाहुन सर्व्हे/गट क्रमांकाचा नविन ७/१२ तयार करणे";
                string str = ConfigurationManager.ConnectionStrings["Linkage Connection String1"].ConnectionString;
                ViewState["Parent_DatabaseName"] = str.Split('=')[2].Split(';')[0];
                ViewState["DatabaseName"] = Session["DataBaseName"].ToString();
                ViewState["SchemaName"] = Session["SchemaName"].ToString();

                

                ViewState["AllowBulkSign"] = "false";
                string popupScript = "";
                if (Session["ccode"] == null)
                {
                    popupScript = "alert('कृपया, कामाची सुरुवात करण्यापूर्वी गावाची निवड करा.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "popupScript", popupScript, true);
                }
                popupScript = "";


                DataSet ds = new DataSet();
                if (Convert.ToString(Session["DistCode"]) == "13" && Convert.ToString(Session["TalukaCode"]) == "15")
                {
                    ds = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o", "distinct v.village_code,v.ccode,v.village_name,'' as survey ", " v.ccode=o.ccode  and o.username='" + Convert.ToString(Session["UserName"]) + "' and  v.ccode in  ( select distinct ccode  from "+Convert.ToString(Session["SchemaName"])+".tbl_jivati_ror_pdf_status  )  group by v.village_code,v.ccode,v.village_name", "v.village_name");
                }
                else
                {
                    ////21/05/2025
                    // ds = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o," + Convert.ToString(Session["SchemaName"]) + ".form7 as form7 ", "distinct v.village_code,v.ccode,v.village_name,count(distinct form7.*) as survey ", " v.ccode=o.ccode and v.ccode=form7.ccode  and o.username='" + Convert.ToString(Session["UserName"]) + "'  group by v.village_code,v.ccode,v.village_name", "v.village_name");
                    ds = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o," + Convert.ToString(Session["SchemaName"]) + ".form7 as form7 ", "distinct v.village_code,v.ccode,v.village_name,count(distinct form7.*) as survey ", " v.ccode=o.ccode and v.ccode=form7.ccode  and o.username='" + Convert.ToString(Session["UserName"]) + "'  and  v.ccode in  ( select distinct ccode  from " + Convert.ToString(Session["SchemaName"]) + ".tbl_jivati_ror_pdf_status  ) group by v.village_code,v.ccode,v.village_name", "v.village_name");
                }

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ddlvillage.DataSource = ds.Tables[0].DefaultView;
                    ddlvillage.DataValueField = ds.Tables[0].Columns["ccode"].ToString();
                    ddlvillage.DataTextField = ds.Tables[0].Columns["village_name"].ToString();
                    ddlvillage.DataBind();
                    ddlvillage.Items.Insert(0, "---निवडा---");

                }
                else
                {
                    popupScript = "alert('कृपया, ७/१२ PDF फाईल उपलब्ध नाही याची नोंद घ्यावी.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "popupScript", popupScript, true);
                    return;
                }
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
    protected void ddlvillage_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if(ddlvillage.SelectedIndex>0)
            {
                Session["ccode"] = ddlvillage.SelectedItem.Value.ToString();
                DataSet ds_zip = objclsCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_jivati_ror_pdf_status", "distinct ccode, sequence_no, ccode||'_'||sequence_no||'.zip' filename,count(sequence_no) filecount,'' as survey ", " ccode= '" + Convert.ToString(Session["ccode"]) + "' group by ccode,sequence_no", "sequence_no");
                if(ds_zip != null && ds_zip.Tables[0].Rows.Count >0)
                {
                    gdvRORZip.DataSource = ds_zip.Tables[0].DefaultView;
                    gdvRORZip.DataBind();
                }
                else
                {
                    string popupScript = "alert('माहिती उपलब्ध नाही.');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "popupScript", popupScript, true);
                    return;
                }
            }
            else
            {
                string popupScript = "alert('गाव निवडा.');";
                ScriptManager.RegisterStartupScript(this, GetType(), "popupScript", popupScript, true);
                return;
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


    protected void gdvRORZip_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
       
      //  string filename = ((Label)gdvRORZip.Rows[e.NewSelectedIndex].FindControl("lblVillageCode")).Text;
      //// D:\DataEntry\JivatiRoR\27\7\272700070340500000\272700070340500000_2.zip

      //  string drive = System.Configuration.ConfigurationManager.AppSettings["drive"];
      ////  string folderpath = @"" + drive + "\\DataEntry\\JivatiRoR\\" + district_code + "\\" + taluka_code + "\\" + drowvillage["ccode"].ToString() + "\\" + drowvillage["ccode"].ToString() + "_" + folder_sequence + "\\";
      //  string archivepath = @"" + drive + "\\DataEntry\\JivatiRoR\\" + Convert.ToString(Session["DistCode"]) + "\\" + Convert.ToString(Session["TalukaCode"]) + "\\" + Convert.ToString(Session["ccode"]) + "'\\";

      //      // string filePath = @"" + drive + "\\DataEntry\\JivatiRoR\27\7\272700070340500000\272700070340500000_2.zip";
      ////  string startPath = folderpath;
      ////  string zipPath = archivepath + Convert.ToString(Session["ccode"]) + "_" + folder_sequence + ".zip"; //Convert.ToString(drowvillage["village_name"]) 
      //  string zipPath = archivepath + filename; //Convert.ToString(drowvillage["village_name"]) 


      //  string filePath = Server.MapPath(zipPath);

      //  Response.Clear();
      //  Response.ContentType = "application/zip";
      //  Response.AppendHeader("Content-Disposition", "attachment; filename="+filename+"");
      //  Response.TransmitFile(filePath);
      //  Response.End();

        //-------------------------------
        try
        {
            string filename = ((Label)gdvRORZip.Rows[e.NewSelectedIndex].FindControl("lblVillageCode")).Text;
            // D:\DataEntry\JivatiRoR\27\7\272700070340500000\272700070340500000_2.zip

            string drive = System.Configuration.ConfigurationManager.AppSettings["drive"];
            //  string folderpath = @"" + drive + "\\DataEntry\\JivatiRoR\\" + district_code + "\\" + taluka_code + "\\" + drowvillage["ccode"].ToString() + "\\" + drowvillage["ccode"].ToString() + "_" + folder_sequence + "\\";
            string archivepath = @"" + drive + "\\DataEntry\\JivatiRoR\\" + Convert.ToString(Session["DistCode"]) + "\\" + Convert.ToString(Session["TalukaCode"]) + "\\" + Convert.ToString(Session["ccode"]) + "\\";

            // string filePath = @"" + drive + "\\DataEntry\\JivatiRoR\27\7\272700070340500000\272700070340500000_2.zip";
            //  string startPath = folderpath;
            //  string zipPath = archivepath + Convert.ToString(Session["ccode"]) + "_" + folder_sequence + ".zip"; //Convert.ToString(drowvillage["village_name"]) 
            string zipPath = archivepath + filename; //

            //if (File.Exists(zipPath))
            //{
            //    Response.Clear();
            //    Response.ClearContent();
            //    Response.ClearHeaders();
            //    Response.Buffer = true;

            //    Response.ContentType = "application/zip";
            //    Response.AddHeader("Content-Disposition",
            //        "attachment; filename=" + Path.GetFileName(zipPath));

            //    //Response.ContentType = "application/zip";
            //    //Response.AddHeader("Content-Disposition", "attachment; filename="+filename+".zip");

            //    //Response.TransmitFile(zipPath);
            //    Response.WriteFile(zipPath);
            //    Response.Flush();
            //    HttpContext.Current.ApplicationInstance.CompleteRequest();

            //    Response.Flush();
            //    Response.End();
            //}
            if (System.IO.File.Exists(zipPath))
            {
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();

                Response.ContentType = "application/zip";
                Response.AddHeader(
                    "Content-Disposition",
                    "attachment; filename=" + Path.GetFileName(zipPath));

                Response.WriteFile(zipPath);
                Response.Flush();

                HttpContext.Current.ApplicationInstance.CompleteRequest();
                return;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
            // Log exception
        }


    }
    protected void gdvRORZip_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "DownloadZip")
            {
                string fileName = e.CommandArgument.ToString();
                string drive = System.Configuration.ConfigurationManager.AppSettings["drive"];
                string archivepath = @"" + drive + "\\DataEntry\\JivatiRoR\\" + Convert.ToString(Session["DistCode"]) + "\\" + Convert.ToString(Session["TalukaCode"]) + "\\" + Convert.ToString(Session["ccode"]) + "\\";
                string zipPath = archivepath + fileName;


                //string zipPath = Server.MapPath("~/Zips/" + fileName);

                if (System.IO.File.Exists(zipPath))
                {
                    Response.Clear();
                    Response.ContentType = "application/zip";
                    Response.AddHeader("Content-Disposition",
                        "attachment; filename=" + fileName);

                    Response.TransmitFile(zipPath);
                    Response.Flush();

                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
            // Log exception
        }
    }
}