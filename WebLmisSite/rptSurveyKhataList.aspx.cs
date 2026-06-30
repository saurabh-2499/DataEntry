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
using System.Data.Common;
using Npgsql;
using System.Text;

public partial class rptSurveyKhataList : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
     DataSet dsPins = new DataSet();
     string page_name;
    StringBuilder sb = new StringBuilder();
   
    int i = 1;
   
   // static string pincase = " rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')as survey";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

         

            page_name = " एकच खाते असलेल्या सर्व्हे क्रमांकाची यादी";
            //dsPins = objedit.funReturnDataSet(Convert.ToString(Session["Dbname"]), " select " + pincase + " from " + Convert.ToString(Session["Schname"]) + ".edit_mut_new where ccode  ='" + Convert.ToString(Session["ccode"]) + "' and approve_flag <> 'Approve' order by pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ;");

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
            //dsPins = objedit.funReturnDataSet(Convert.ToString(Session["Dbname"]), "SELECT ccode, rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')as survey,substring(pin||pin1||pin2||pin3||pin4||pin5||pin6||pin7||pin8 FROM '[0-9]+'):: int as result   FROM " + Convert.ToString(Session["Schname"]) + ".form7_khata where ccode='" + Convert.ToString(Session["ccode"]) + "' group by ccode,  rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/'),pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 having count(*)=1 order by result");
            //dsPins = objedit.funReturnDataSet(Convert.ToString(Session["Dbname"]), "SELECT a.ccode, a.survey , result,b.khata_no , string_agg(b.fname||' '||b.mname||' '||b.lname||' '||b.topan_name,',') as khatedar_names  from  (SELECT ccode, rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')as survey,substring(pin||pin1||pin2||pin3||pin4||pin5||pin6||pin7||pin8 FROM '[0-9]+'):: int as result    FROM " + Convert.ToString(Session["Schname"]) + ".form7_khata where ccode='" + Convert.ToString(Session["ccode"]) + "' group by ccode,  rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/'),pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 having count(*)=1 order by result) as a ," + Convert.ToString(Session["Schname"]) + ".form7_khata as b  where  a.ccode='" + Convert.ToString(Session["ccode"]) + "'  and a.ccode =b.ccode and   a.survey= rtrim(((CASE WHEN b.pin<>'' THEN cast(b.pin as text)|| '/' WHEN b.pin='' THEN '' END)  || (CASE WHEN b.pin1<>'' THEN cast(b.pin1 as text)|| '/' WHEN b.pin1='' THEN '' END)  || (CASE WHEN b.pin2<>'' THEN cast(b.pin2 as text)|| '/' WHEN b.pin2='' THEN '' END)  || (CASE WHEN b.pin3<>'' THEN cast(b.pin3 as text)|| '/' WHEN b.pin3='' THEN '' END)  || (CASE WHEN b.pin4<>'' THEN cast(b.pin4 as text)|| '/' WHEN b.pin4='' THEN '' END)  || (CASE WHEN b.pin5<>'' THEN cast(b.pin5 as text)|| '/' WHEN b.pin5='' THEN '' END)  || (CASE WHEN b.pin6<>'' THEN cast(b.pin6 as text)|| '/' WHEN b.pin6='' THEN '' END)  || (CASE WHEN b.pin7<>'' THEN cast(b.pin7 as text)|| '/' WHEN b.pin7='' THEN '' END)  || (CASE WHEN b.pin8<>'' THEN cast(b.pin8 as text)|| '/' WHEN b.pin8='' THEN '' END)),'/') and  b.khata_no<>'500001' group  by a.ccode, a.survey , result,b.khata_no order by result");
           // dsPins = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), "select c.survey , c.khata_no ,  string_agg(b.fname||' '||b.mname||' '||b.lname||' '||b.topan_name,',') as khatedar_names from  ( select  survey , khata_no     from (select rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')as survey ,khata_no  FROM " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + Convert.ToString(Session["ccode"]) + "' and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in( select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  FROM " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no='500001' )  group by pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  ,khata_no) as a   group by a.survey,a.khata_no having count(*)=1 order by a.survey  ) as c ," + Convert.ToString(Session["SchemaName"]) + ".form7_khata as b where b.ccode='" + Convert.ToString(Session["ccode"]) + "' and  c.survey= rtrim(((CASE WHEN b.pin<>'' THEN cast(b.pin as text)|| '/' WHEN b.pin='' THEN '' END)  || (CASE WHEN b.pin1<>'' THEN cast(b.pin1 as text)|| '/' WHEN b.pin1='' THEN '' END)  || (CASE WHEN b.pin2<>'' THEN cast(b.pin2 as text)|| '/' WHEN b.pin2='' THEN '' END)  || (CASE WHEN b.pin3<>'' THEN cast(b.pin3 as text)|| '/' WHEN b.pin3='' THEN '' END)  || (CASE WHEN b.pin4<>'' THEN cast(b.pin4 as text)|| '/' WHEN b.pin4='' THEN '' END)  || (CASE WHEN b.pin5<>'' THEN cast(b.pin5 as text)|| '/' WHEN b.pin5='' THEN '' END)  || (CASE WHEN b.pin6<>'' THEN cast(b.pin6 as text)|| '/' WHEN b.pin6='' THEN '' END)  || (CASE WHEN b.pin7<>'' THEN cast(b.pin7 as text)|| '/' WHEN b.pin7='' THEN '' END)  || (CASE WHEN b.pin8<>'' THEN cast(b.pin8 as text)|| '/' WHEN b.pin8='' THEN '' END)),'/') and b.khata_no<>'500001' group  by c.survey , c.khata_no  order by   c.survey");
            dsPins = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), "select c.survey , b.khata_no ,  string_agg(b.fname||' '||b.mname||' '||b.lname||' '||b.topan_name,',') as khatedar_names from ( select  survey from  ( select distinct survey , khata_no     from (select rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')as survey ,khata_no  FROM " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + Convert.ToString(Session["ccode"]) + "' and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ) not in( select distinct  pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  FROM " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no='500001' )  group by pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  ,khata_no) as a   group by a.survey,a.khata_no  order by a.survey  ) as temp group  by survey having count(*)=1 ) as c ," + Convert.ToString(Session["SchemaName"]) + ".form7_khata as b where b.ccode='" + Convert.ToString(Session["ccode"]) + "' and  c.survey= rtrim(((CASE WHEN b.pin<>'' THEN cast(b.pin as text)|| '/' WHEN b.pin='' THEN '' END)  || (CASE WHEN b.pin1<>'' THEN cast(b.pin1 as text)|| '/' WHEN b.pin1='' THEN '' END)  || (CASE WHEN b.pin2<>'' THEN cast(b.pin2 as text)|| '/' WHEN b.pin2='' THEN '' END)  || (CASE WHEN b.pin3<>'' THEN cast(b.pin3 as text)|| '/' WHEN b.pin3='' THEN '' END)  || (CASE WHEN b.pin4<>'' THEN cast(b.pin4 as text)|| '/' WHEN b.pin4='' THEN '' END)  || (CASE WHEN b.pin5<>'' THEN cast(b.pin5 as text)|| '/' WHEN b.pin5='' THEN '' END)  || (CASE WHEN b.pin6<>'' THEN cast(b.pin6 as text)|| '/' WHEN b.pin6='' THEN '' END)  || (CASE WHEN b.pin7<>'' THEN cast(b.pin7 as text)|| '/' WHEN b.pin7='' THEN '' END)  || (CASE WHEN b.pin8<>'' THEN cast(b.pin8 as text)|| '/' WHEN b.pin8='' THEN '' END)),'/') and b.khata_no<>'500001' group  by c.survey , b.khata_no  order by   c.survey");
            sb.Append("<body>");

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>एकच खाते असलेल्या सर्व्हे क्रमांकाची यादी</b></font></td>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("</table>");
            sb.Append("</br >");




            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%' >");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi' >&nbsp;<b>गाव :-  </b>" + Session["VillageDetail"].ToString() + "</font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>तालुका :-  </b> " + Convert.ToString(Session["TalukaName"]) + "</font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>जिल्हा :-  </b> " + Convert.ToString(Session["DistrictName"]) + "</font></td>");
            sb.Append("<td width='40%' align='left' > <font size='3' face='Sakal Marathi  '>&nbsp;<b>अहवाल दिनांक:- </b> " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "</font></td>");
            sb.Append("</tr >");
            
            sb.Append("<tr width='100%' >");
            sb.Append("<td width='100%'   colspan='4' align='left'><center> <font size='4' face='Sakal Marathi  ' font color='red'  ><b>टीप : एकाच खात्याचे , ७/१२ साठी खाते  योग्य नसल्यास घोषणापत्र -१ ( DECLARATION-I ) करावे व  सर्व्हे दुरुस्ती मध्ये दुसरे खाते समाविष्ट करून मूळ खाते नष्ट करावे.</b></font></center> </td>");
            sb.Append("</tr >");
            sb.Append("</table>");

            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%' >");
        
            sb.Append("<tr width='100%'  >");
            sb.Append("<td width='10%'><font size='3' face='Sakal Marathi  ' > <b>अनु. क्रं.</b></font> </td >");
            sb.Append("<td width='30%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> गट / सर्व्हे क्रमांक.</b></font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> खाता क्रमांक.</b></font></td>");
            sb.Append("<td width='40%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> खातेदारांचे नाव/नावे.</b></font></td>");
            sb.Append("</tr >");

            if ( dsPins.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dsPins.Tables[0].Rows)
                {
                    sb.Append("<tr width='100%'  >");
                    sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;" + i + "</font></td>");
                    sb.Append("<td width='30%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["survey"]) + "");
                    sb.Append("</font></td >");
                    sb.Append("<td width='20%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["khata_no"]) + "");
                    sb.Append("</font></td >");
                    sb.Append("<td width='40%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["khatedar_names"]) + "");
                    sb.Append("</font></td >");
                                      i++;
                }

            }
            else
            {
                sb.Append("<tr>");
                sb.Append("<td colspan='4' style='width: 100%;background-color: #ffff33;text-align: center;'><b>माहिती उपलब्ध नाही .");
                sb.Append("</tr>");
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
                Session["Error"] = excpt.Getex(ex, "rptSurveyKhataList.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "rptSurveyKhataList.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";

            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }



    }
}