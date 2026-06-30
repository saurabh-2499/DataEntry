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

public partial class rptRejectMutDetails : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    DataSet dsPins = new DataSet();
    StringBuilder sb = new StringBuilder();
    int total_servey = 0;
    int edit_servey = 0;
    int i = 1;
    static string pincase = "rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')";
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
            dsPins = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_rejected", pincase + "as pincase, edit_mut_no, edit_trans_no  ", "ccode  ='" + (string)Session["ccode"] + "'", "edit_mut_no");
           
            sb.Append("<body>");

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>डाटा एन्ट्री आज्ञावलीद्वारे  नामंजूर केलेले गट / सर्वे क्रमांक-फेरफार क्रमांक. </b></font></td>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("</table>");
            sb.Append("</br >");


            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%' >");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi' >&nbsp;<b>गाव :-  </b>" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + "</font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>तालुका :-  </b> " + Convert.ToString(Session["TalukaName"]) + "</font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>जिल्हा :-  </b> " + Convert.ToString(Session["DistrictName"]) + "</font></td>");
            sb.Append("<td width='40%' align='left' > <font size='3' face='Sakal Marathi  '>&nbsp;<b>अहवाल दिनांक:- </b> " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "</font></td>");
            sb.Append("</tr >");
            
            sb.Append("<tr width='100%' >");
            sb.Append("<td width='100%'   colspan='4' align='left'><center> <font size='4' face='Sakal Marathi  '  >&nbsp;</b></font></center> </td>");
            sb.Append("</tr >");

            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >"); 
            sb.Append("<tr width='100%'  >");
            sb.Append("<td width='5%'><font size='3' face='Sakal Marathi  ' > <b>अनु. क्रं.</b></font> </td >");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp<b> फेरफार क्रमांक.</b></font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp; <b>परिशिष्ट  क्रमांक.</b></font></td>");
            sb.Append("<td width='55%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> गट / सर्वे क्रमांक.</b></font></td>");         
            sb.Append("</tr >");

            if (dsPins != null || dsPins.Tables[0].Rows.Count>0)
            {
                foreach (DataRow dr in dsPins.Tables[0].Rows)
                {
                    sb.Append("<tr width='100%'  >");
                    sb.Append("<td width='5%' ><font size='3' face='Sakal Marathi  ' >&nbsp;" + i + "</font></td>");                   
                    sb.Append("<td width='20%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["edit_mut_no"]) + "");
                    sb.Append("</font></td >");
                    sb.Append("<td width='20%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["edit_trans_no"]) + "");
                    sb.Append("</font></td >");
                    sb.Append("<td width='55%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["pincase"]) + "");
                    sb.Append("</font></td >");
                    sb.Append("</tr >");
                    i++;
                }
                sb.Append("<tr width='100%' >");
                sb.Append("<td width='100%'   colspan='4' align='left'>  <font size='4' face='Sakal Marathi  '  >&nbsp;<b>एकूण : " + dsPins.Tables[0].Rows.Count + "</b></font>  </td>");
                sb.Append("</tr >");

            }
            else
            {
                sb.Append("<tr width='100%' >");
                sb.Append("<td width='100%' bgcolor='green' colspan='4' align='left'><center> <font size='4' face='Sakal Marathi  '  >&nbsp;<b>" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + " गावात ,  सर्व  गट / सर्वे क्रमांकांचे एडीट आज्ञावली द्वारे  फेरफार मंजूर करण्यात आले आहे..!!!!   </b></font></center> </td>");
                sb.Append("</tr >");
            }
            sb.Append("</table>");
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