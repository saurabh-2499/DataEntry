using Npgsql;
using NpgsqlTypes;
using iTextSharp.text.pdf.parser;
using System.Text;
using iTextSharp.text.html;
using System.Web;
//-------------00----------

using System.Data;
using System.Configuration;


using System.Data.Common;
using System.Collections;
using System.Data.SqlClient;
using System.Data.OleDb;


//-------
using iTextSharp.text;
using iTextSharp.text.pdf;
using Org.BouncyCastle.X509;
using System;
using System.Drawing;
using System.Web.UI;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Globalization;
using Org.BouncyCastle.Asn1.X509;
using System.Web.Script.Serialization;


using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.ObjectBuilder;

public partial class FinalSign : System.Web.UI.Page
{
    DataSet ds = new DataSet();
 
    DataTable dt = new DataTable();
    string str = null;

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
        hf_villagecode.Value = Session["VillageDetail"].ToString().Split('#')[0];
        
        hf_sevarth.Value = Convert.ToString(Session["UserName"]);
        
        hf_host.Value = "10.153.8.154";
        hf_port.Value = "5433";
        hfKey.Value = Session["pk"].ToString();
       int tkn = 2;
      
    }





    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}
