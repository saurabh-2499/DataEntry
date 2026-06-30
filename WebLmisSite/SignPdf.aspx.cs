using iTextSharp.text;
using iTextSharp.text.pdf;
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
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.ObjectBuilder;
using System.Data.SqlClient;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
//using System.Security.Cryptography.Xml;
using System.Xml;
using System.Xml.Serialization;

using System.IO;
using System.Net;
using iTextSharp.text.pdf.parser;

public partial class SignPdf : System.Web.UI.Page
{
    public string str;
    string[] dy;
    string page_name = "SignPdf";
    EnCode.Cryptograpy crypt = new EnCode.Cryptograpy();

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
        if (!IsPostBack)
        {
            //string _filepath = Server.MapPath("sign.pdf");
            //byte[] pdfData = File.ReadAllBytes(_filepath);
            //hf.Value = Convert.ToBase64String(pdfData);
            //// hfserial.Value = "2208641ABA5CAAF5AC0A";
            //hfdate.Value = DateTime.Now.ToString("ddd MMM d HH:mm:ss \"UTC\"zzz yyyy");

            //int[] PosArray = ReadY(_filepath);
            //for (int iArray = 0; iArray <= PosArray.Length - 1; iArray++)
            //{
            //    hfyd.Value += PosArray[iArray].ToString() + ",";
            //}
            //hfyd.Value = hfyd.Value.Substring(0, hfyd.Value.Length - 1);
            try
            {
                string strPDFFile = Convert.ToString(Session["path"]);

                byte[] pdfData = File.ReadAllBytes(strPDFFile);
                hf.Value = Convert.ToBase64String(pdfData);

                hfdate.Value = DateTime.Now.ToString("ddd MMM d HH:mm:ss \"UTC\"zzz yyyy");

                int[] PosArray = ReadY(strPDFFile);
                for (int iArray = 0; iArray <= PosArray.Length - 1; iArray++)
                {
                    hfyd.Value += PosArray[iArray].ToString() + ",";
                }
                hfyd.Value = hfyd.Value.Substring(0, hfyd.Value.Length - 1);

              //  ScriptManager.RegisterStartupScript(this, GetType(), "Activex", "Activex();", true);

               

                
            }
            catch(Exception ex)
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
    }

    void showPdf()
    {
        try
        {
          if (Convert.ToString(Session["IsSigned"]) == "True")
            {
                hf_serail_key.Value = hf_serail_key.Value;
                hfname.Value = (hfname.Value.Trim());
                string[] myarray = hfname.Value.Split(',');
                string fName = myarray[0];

                if (txt.Text != "N")
                {
                    byte[] pdfData = Convert.FromBase64String(txt.Text);
                    //string filepath = Server.MapPath("Pdfs/202222_2013_1200.pdf");
                    string filepath = Convert.ToString(Session["path"]);
                    File.WriteAllBytes(Convert.ToString(Session["path"]), pdfData);
                    WebClient client = new WebClient();
                    Byte[] buffer = client.DownloadData(filepath);
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", buffer.Length.ToString());
                    Response.BinaryWrite(buffer);
                    Response.Flush();
                    Response.Close();

                }
            }

        }
            catch(Exception ex)
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            hf_serail_key.Value = hf_serail_key.Value;
            hfname.Value = (hfname.Value.Trim());
            string[] myarray = hfname.Value.Split(',');
            string fName = myarray[0];

            /// lbl.Text = String.Join(",", myarray);
            // hfcrdnm.Value = (hfcrdnm.Value.Trim());


            Button2.Enabled = true;
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

    protected void Button2_Click(object sender, EventArgs e)
    {

        try
        {
        showPdf();
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


    public int[] ReadY(string Filename)
    {
        return ReadPdfFile(Filename);
    }

    public int[] ReadPdfFile(Object fileName)
    {
        PdfReader pdfReader = new PdfReader((string)fileName);
        int[] position = new int[pdfReader.NumberOfPages];
       
        try
        {
        
            if (File.Exists((string)fileName))
            {
                for (int page = 1; page <= pdfReader.NumberOfPages; page++)
                {
                    //if (page == pdfReader.NumberOfPages)
                    //{
                    PdfReaderContentParser parser = new PdfReaderContentParser(pdfReader);
                    TextMarginFinder finder;
                    finder = parser.ProcessContent(page, new TextMarginFinder());
                    position[page - 1] = 760 - Convert.ToInt16(finder.GetHeight());
                    //}
                }
            }
      
        pdfReader.Close();
        
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
    return (position);
    }


    protected void btnReport_Click(object sender, EventArgs e)
    {
        //string strPDFFile = Convert.ToString(Session["path"]);

        //byte[] pdfData = File.ReadAllBytes(strPDFFile);
        //hf.Value = Convert.ToBase64String(pdfData);

        //hfdate.Value = DateTime.Now.ToString("ddd MMM d HH:mm:ss \"UTC\"zzz yyyy");

        //int[] PosArray = ReadY(strPDFFile);
        //for (int iArray = 0; iArray <= PosArray.Length - 1; iArray++)
        //{
        //    hfyd.Value += PosArray[iArray].ToString() + ",";
        //}
        //hfyd.Value = hfyd.Value.Substring(0, hfyd.Value.Length - 1);

    }
}
