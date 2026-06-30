using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIC.WebLMISLibrary;
using System.Text;
using System.IO;
using System.Data;

public partial class pgPinalike : System.Web.UI.Page
{
    string page_name = "pgPinalike";
    clsCommonFunctions objCommonFun = new clsCommonFunctions();
    clscommonfunedit objclscommonfunedit = new clscommonfunedit();
    clscommonfun con = new clscommonfun();

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Convert.ToString(Session["user_type"]) == "T")
        {
            this.MasterPageFile = "~/InnerMaster.master";
        }
        else if (Convert.ToString(Session["user_type"]) == "C")
        {
            this.MasterPageFile = "~/circlemaster.master";
        }

        else if (Convert.ToString(Session["user_type"]) == "DBA")
        {
            this.MasterPageFile = "~/Copy of InnerMaster.master";
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {

            string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
            if (Convert.ToUInt32(userExist) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
            }
            string dbname = Session["DataBaseName"].ToString();
            string schema = Convert.ToString(Session["SchemaName"]);
            string villagename = Convert.ToString(Session["VillageDetail"]).Split('#')[1];
            string ccode = Convert.ToString(Session["VillageDetail"]).Split('#')[0];
            Session["page_heading"] = "डुप्लिकेट  सर्वे क्रमांक यांची यादी";

            //lblvillage.Text = villagename;
            //lbltaluka.Text = Convert.ToString(Session["TalukaName"]);
            //lbldistrict.Text = Convert.ToString(Session["DistrictName"]);

            bindsurve(ccode);
        }


    }
    public void bindsurve(string ccode)
    {
        try
        {
            DataSet ds = new DataSet();
            //ds1 = objclscommonfunedit.funSetGridList((string)ViewState["DatabaseName"], ref GridView1, (string)ViewState["SchemaName"] + ".form7_khata", "distinct numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + ddlVillage.SelectedValue + "' and khata_no<>'500001' and marked<>'Y' and trim(fname)<>'हा ७/१२ रद्द झाला आहे' and (numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) in (select numeric_pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from  " + (string)ViewState["SchemaName"] + ".form7 where ccode ='" + ddlVillage.SelectedValue + "' and numeric_pin = '" + txtsurvey.Text + "')", "");
            // 19 Dec 2013



            string pincase1 = "rtrim(((CASE WHEN pin<>'' THEN cast(trim(pin) as text)|| '/' WHEN pin='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin1<>'' THEN cast(trim(pin1) as text)|| '/' WHEN pin1='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin2<>'' THEN cast(trim(pin2) as text)|| '/' WHEN pin2='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin3<>'' THEN cast(trim(pin3)as text)|| '/' WHEN pin3='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin4<>'' THEN cast(trim(pin4) as text)|| '/' WHEN pin4='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin5<>'' THEN cast(trim(pin5) as text)|| '/' WHEN pin5='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin6<>'' THEN cast(trim(pin6) as text)|| '/' WHEN pin6='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin7<>'' THEN cast(trim(pin7) as text)|| '/' WHEN pin7='' THEN '' END)  ||";
            pincase1 += "(CASE WHEN pin8<>'' THEN cast(trim(pin8) as text)|| '/' WHEN pin8='' THEN '' END)),'/')";
            ds = objclscommonfunedit.funReturnDataSet(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".form7_area", "distinct  " + pincase1 + "  as pincase ,numeric_pin,count(*) as mcount", "ccode ='" + ccode + "'  group by pincase,numeric_pin having count(" + pincase1 + ")>1  ", "numeric_pin");



            DataTable dt = new DataTable();
            dt.Columns.Add("pincase");
            dt.Columns.Add("numeric_pin");
            dt.Columns.Add("pin");
            dt.Columns.Add("pin1");
            dt.Columns.Add("pin2");
            dt.Columns.Add("pin3");
            dt.Columns.Add("pin4");
            dt.Columns.Add("pin5");
            dt.Columns.Add("pin6");
            dt.Columns.Add("pin7");
            dt.Columns.Add("pin8");
            dt.Columns.Add("total_area_h ");

            if (ds != null || ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DataSet ds1 = objclscommonfunedit.funSetGridList(Session["DataBaseName"].ToString(), ref GridView1, Convert.ToString(Session["SchemaName"]) + ".form7_area", " " + pincase1 + " as pincase,numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,total_area_h  ", "ccode ='" + ccode + "'  and " + pincase1 + "='" + dr["pincase"] + "'", "numeric_pin,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8");
                    foreach (DataRow drow in ds1.Tables[0].Rows)
                    {
                        DataRow d = dt.NewRow();
                        d["pincase"] = drow["pincase"];
                        d["numeric_pin"] = drow["numeric_pin"];
                        d["pin"] = drow["pin"];
                        d["pin1"] = drow["pin1"];
                        d["pin2"] = drow["pin2"];
                        d["pin3"] = drow["pin3"];
                        d["pin4"] = drow["pin4"];
                        d["pin5"] = drow["pin5"];
                        d["pin6"] = drow["pin6"];
                        d["pin7"] = drow["pin7"];
                        d["pin8"] = drow["pin8"];
                        d["total_area_h "] = drow["total_area_h "];
                        dt.Rows.Add(d);

                    }
                    dt.AcceptChanges();
                }
            }
            if (dt != null || dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
              //  string popupScript = "<script language='javascript'>alert('माहिती उपलब्ध नाही ....... ');</script>";
              //  ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                 Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
           
            return;
        }
    }

}