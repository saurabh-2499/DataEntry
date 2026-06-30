using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using NIC.WebLMISLibrary;

public partial class rptKhataReEdit : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    DataSet dsNames = new DataSet();
    DataSet dsPins = new DataSet();
    DataSet dsNamesPins = new DataSet();
    DataSet dsNamesPinsnew = new DataSet();
    StringBuilder sb = new StringBuilder();
    int total_servey = 0;
    int edit_servey = 0;
    int i = 1;
    int j = 1;
    static string pincaseagg = "string_agg(distinct rtrim((pin||'/'||pin1||'/'||pin2||'/'||pin3||'/'||pin4||'/'||pin5||'/'||pin6||'/'||pin7||'/'||pin8),'/') ,',')";
    static string pincase = " rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["ccode"]) == "")
            {
                if (Session["user_type"].ToString() == "T")
                    Response.Redirect("pgSelectVillage.aspx");
                else if (Session["user_type"].ToString() == "DBA")
                    Response.Redirect("pgVillageSelect_DBA.aspx");
            }
            else
            {
                Session["ccode"] = Session["ccode"].ToString();
            }

            dsNamesPins = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), " select distinct h.khata_no::int,string_agg( distinct COALESCE(cast(h.fname as character varying),'')||' '||COALESCE(cast(h.mname as character varying),'')||' '||COALESCE(cast(h.lname as character varying),''),',')as fullname,string_agg(distinct rtrim((f.pin||'/'||f.pin1||'/'||f.pin2||'/'||f.pin3||'/'||f.pin4||'/'||f.pin5||'/'||f.pin6||'/'||f.pin7||'/'||f.pin8),'/') ,',')as survey from " + Convert.ToString(Session["SchemaName"]) + "_his.holder_detail_kp as h INNER JOIN " + Convert.ToString(Session["SchemaName"]) + "_his.form7_khata_kp as f ON h.ccode = f.ccode and h.khata_no =f.khata_no where h.ccode  ='" + (string)Session["ccode"] + "' group by h.khata_no   order by h.khata_no::int ;");
            dsNamesPinsnew = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), " select distinct h.khata_no::int,string_agg( distinct COALESCE(cast(h.fname as character varying),'')||' '||COALESCE(cast(h.mname as character varying),'')||' '||COALESCE(cast(h.lname as character varying),''),',')as fullname,string_agg(distinct rtrim((f.pin||'/'||f.pin1||'/'||f.pin2||'/'||f.pin3||'/'||f.pin4||'/'||f.pin5||'/'||f.pin6||'/'||f.pin7||'/'||f.pin8),'/') ,',')as survey from " + Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp as h INNER JOIN " + Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata_kp as f ON h.ccode = f.ccode and h.khata_no =f.khata_no  where h.ccode  ='" + (string)Session["ccode"] + "' and  h.edit_flag <>'34'  group by h.khata_no   order by h.khata_no::int ;");

            sb.Append("<body>");

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>डाटा एन्ट्री आज्ञावलीद्वारे  खातेनिहाय खाता मास्टर दुरुस्तीचा माहिती उतारा </b></font></td>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("</table>");
            sb.Append("</br >");


            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%' >");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi' >&nbsp;<b>गाव :-  </b>" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + "</font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>तालुका :-  </b> " + Convert.ToString(Session["TalukaName"]) + "</font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>जिल्हा :-  </b> " + Convert.ToString(Session["DistrictName"]) + "</font></td>");
            sb.Append("<td width='40%' align='left' > <font size='3' face='Sakal Marathi  '>&nbsp;<b>अहवाल दिनांक:- </b> " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "</font></td>");
            sb.Append("</tr >");
            
            sb.Append("<tr width='100%' >");
            sb.Append("<td width='100%'   colspan='4' align='left'><center> <font size='4' face='Sakal Marathi  '  >&nbsp;</b></font></center> </td>");
            sb.Append("</tr >");


      
            sb.Append("</table>");
        

            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%'  >");
            sb.Append("<td width='5%'><font size='3' face='Sakal Marathi  ' > <b>अनु. क्रं.</b></font> </td >");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp<b> खाता क्रं.</b></font></td>");
         
            sb.Append("<td width='38%' align='center'> <font size='3' face='Sakal Marathi  '> &nbsp; <b>मूळ भोगवटदाराची नावे </b></font></td>");
            sb.Append("<td width='40%' align='center'> <font size='3' face='Sakal Marathi  '> &nbsp; <b>अदयावत भोगवटदाराची नावे </b></font></td>");
            sb.Append("<td width='12%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> गट / सर्वे क्रमांक.</b></font></td>");
            sb.Append("</tr >");

            if (dsNamesPins != null || dsNamesPins.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsNamesPins.Tables[0].Rows)
                {
                    sb.Append("<tr width='100%'  >");
                    sb.Append("<td width='5%' ><font size='3' face='Sakal Marathi  ' >&nbsp;" + i + "</font></td>");
                    sb.Append("<td width='5%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["khata_no"]) + "");
                    sb.Append("</font></td >");
                   
                    sb.Append("<td width='38%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["fullname"]) + "");
                    sb.Append("</font></td >");

                    if (dsNamesPinsnew != null || dsNamesPinsnew.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr1 in dsNamesPinsnew.Tables[0].Select("Khata_no="+Convert.ToString(dr["khata_no"])+""))
                        {
                            sb.Append("<td width='40%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                            sb.Append("&nbsp;" + Convert.ToString(dr1["fullname"]) + "");
                            sb.Append("</font></td >");
                        }

                    }

                    sb.Append("<td width='12%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["survey"]) + "");
                    sb.Append("</font></td >");


                    i++;
                }
        

            }
        
            sb.Append("</tr >");
            sb.Append("</table>");
        
            sb.Append("</body>");
            Response.Write(sb.ToString());

           
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, "rptNotEditedPins.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "rptNotEditedPins.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";

            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }



    }
}