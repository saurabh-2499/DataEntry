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

public partial class rptNotCertifyMutNo: System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
     DataSet dsPins = new DataSet();
     string page_name;
    StringBuilder sb = new StringBuilder();
    clscommonfun objcls = new clscommonfun();
    int i = 1;
   
   // static string pincase = " rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')as survey";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Session["Dbname"] = Session["DataBaseName"].ToString();
            Session["Schname"] = Session["SchemaName"].ToString();
            page_name = " rptNotCertifyMutNo";

            dsPins = objedit.funReturnDataSet(Session["Dbname"].ToString(), "select  * from ((select a.ccode, 'ई-फेरफार' as module_name, a.mut_no,to_char(b.mut_date ,'dd/MM/yyyy') as mu_date ,string_agg( ( rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)   ||(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)   ||(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)    ||(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')),',') as surveys from  " + Session["Schname"].ToString() + ".mut_kharedi a , " + Session["Schname"].ToString() + ".mutregister b ," + Session["Schname"].ToString() + ".m_village_census   c where c.ccode='" + Session["ccode"].ToString() + "' and   a.ccode  =b.ccode and a.ccode  =c.ccode and a.mut_no=b.mut_no  and  b.mut_type not  in (100,101) and a.mut_no>c.pending_mut_no_cnt and a.or_code4 not in (2,4,5) and pin<>'' group  by a.mut_no,b.mut_date,a.ccode ,module_name order by a.mut_no) union  (select a.ccode, 'एडीट' as module_name, a.mut_no,to_char(b.mut_date ,'dd/MM/yyyy') as mu_date ,string_agg( ( rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)   ||(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)   ||(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)    ||(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')),',') as surveys from  " + Session["Schname"].ToString() + ".mut_kharedi a , " + Session["Schname"].ToString() + ".mutregister b ," + Session["Schname"].ToString() + ".m_village_census   c where  a.ccode='" + Session["ccode"].ToString() + "' and    a.ccode  =b.ccode and a.ccode  =c.ccode and a.mut_no=b.mut_no  and  b.mut_type  in (100) and a.mut_no>c.pending_mut_no_cnt and a.or_code4 not in (2,3) and pin<>'' group  by a.mut_no,b.mut_date,a.ccode ,module_name order by a.mut_no ) union (select a.ccode, 'रि-एडीट' as module_name, a.mut_no,to_char(b.mut_date ,'dd/MM/yyyy') as mu_date ,string_agg( ( rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  ||(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)   ||(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)    ||(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')),',') as surveys from  " + Session["Schname"].ToString() + ".mut_kharedi a , " + Session["Schname"].ToString() + ".mutregister b ," + Session["Schname"].ToString() + ".m_village_census   c where    a.ccode='" + Session["ccode"].ToString() + "' and   a.ccode  =b.ccode and a.ccode  =c.ccode and a.mut_no=b.mut_no  and  b.mut_type  in (101) and a.mut_no>c.pending_mut_no_cnt and a.or_code4 not in (2,3) and pin<>'' group  by a.mut_no,b.mut_date,a.ccode ,module_name order by  a.mut_no)  union  (select a.ccode, 'ओ.डी.यु' as module_name, a.mut_no,to_char(b.mut_date ,'dd/MM/yyyy') as mu_date ,string_agg( ( rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  ||(CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  ||(CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  ||(CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)   ||(CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  ||(CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)   ||(CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  ||(CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)    ||(CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')),',') as surveys from  " + Session["Schname"].ToString() + ".mut_kharedi a , " + Session["Schname"].ToString() + ".mutregister b ," + Session["Schname"].ToString() + ".m_village_census   c where  a.ccode='" + Session["ccode"].ToString() + "'  and    a.ccode  =b.ccode and a.ccode  =c.ccode and a.mut_no=b.mut_no    and a.mut_no<c.pending_mut_no_cnt and a.or_code4 <>0  and pin<>'' group  by a.mut_no,b.mut_date,a.ccode ,module_name order by  a.mut_no    ) )as x  order by mut_no ");
            sb.Append("<body>");

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>ई -फेरफार,एडिट,री-एडिट व ओ.डी.यु आज्ञावलीमधून नोंद घेतलेले परंतू प्रमाणित न केलेल्या फेरफार क्रमांकाची यादी  </b></font></td>");
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
            sb.Append("<tr width='100%' >");
        
            sb.Append("<tr width='100%'  >");
            sb.Append("<td width='10%'><font size='3' face='Sakal Marathi  ' > <b>अनु. क्रं.</b></font> </td >");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> आज्ञावलीचे नाव </b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> फेरफार क्रमांक </b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> फेरफार दिनांक </b></font></td>");
            sb.Append("<td width='40%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> नोंद घेतलेले सर्वे /गट क्रमांक </b></font></td>");
            sb.Append("</tr >");

            if ( dsPins.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsPins.Tables[0].Rows)
                {
                    sb.Append("<tr width='100%'  >");
                    sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;" + i + "</font></td>");
                    sb.Append("<td width='20%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["module_name"]) + "");
                    sb.Append("<td width='15%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["mut_no"]) + "");
                    sb.Append("<td width='15%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["mu_date"]) + "");
                    sb.Append("<td width='40%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["surveys"]) + "");
                    sb.Append("</font></td >");
              
                
                                      i++;
                }

            }
            else
            {
                sb.Append("<tr>");
                sb.Append("<td colspan='5' style='width: 100%;background-color: #ffff33;text-align: center;'><b>माहिती उपलब्ध नाही .");
                sb.Append("</tr>");
            }
            sb.Append("</tr >");
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