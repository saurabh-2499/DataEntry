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

public partial class rptSameNamesDifferentKhataOnSameSurvey : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
     DataSet dsPins = new DataSet();
 
    StringBuilder sb = new StringBuilder();
   
    int i = 1;
  
   // static string pincase = " rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')as survey";
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

          //  dsPins = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), "select " + pincase + " from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new where ccode  ='" + (string)Session["ccode"] + "' and approve_flag <> 'Approve' order by pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ;");

           // dsPins = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), "select ccode ,survey , names , count(*) as khata_no_count,string_agg(khata_no, ', ') as khata_nos from (select ccode, string_agg(distinct trim( replace (replace(replace(fname,' ','') ,' %','') , '% ','') )||' '||trim(replace (replace(replace(mname,' ','') ,' %','') , '% ','') )||' '||trim(replace (replace(replace(lname,' ','') ,' %','') , '% ',''))||' '||trim(replace (replace(replace(topan_name,' ','') ,' %','') , '% ','') ), ', ') as names ,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey  from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata  where ccode  ='" + (string)Session["ccode"] + "'    group by ccode, khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ) as a  where ccode  ='" + (string)Session["ccode"] + "'    group by ccode , survey , names  having count(*) > 1 ");
            int cont_img_check_set = objedit.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".m_village_census_check", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and imaginary_mut_no_check = false", "");
            if (cont_img_check_set == 0)
            {
                dsPins = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), "select distinct  ccode ,survey,names,string_agg(distinct z.khata_nos, ', ') as khata_nos ,count(khata_nos) as khata_no_count from ((select distinct x.*, string_agg(distinct y.khata_no, ', ') as khata_nos from (select ccode,survey,names,count(names) from (select ccode, string_agg(distinct trim( replace (replace(replace(fname,' ','') ,' %','') , '% ','') )||' '||trim(replace (replace(replace(mname,' ','') ,' %','') , '% ','') )||' '||trim(replace (replace(replace(lname,' ','') ,' %','') , '% ',''))||' '||trim(replace (replace(replace(topan_name,' ','') ,' %','') , '% ','') ), ', ') as names ,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey  from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "' and  mut_no<100000  and marked<>'Y'  and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode ='" + (string)Session["ccode"] + "'  and  mut_no<100000   and khata_no='500001') group by ccode,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ) as a group by ccode,survey,names having count(names)>1) as x ,(select  khata_no,string_agg(distinct trim( fname)||' '||trim( mname)||' '||trim( lname)||' '||trim( topan_name), ', ') as names1,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey1 from  " + Convert.ToString(Session["SchemaName"]) + ".form7_khata   where  ccode='" + (string)Session["ccode"] + "'  and  mut_no<100000  and    khata_no<>'500001'  group by  khata_no,survey1 ) as y where x.names=y.names1 group by y.khata_no,ccode,survey,names,count)  order by survey )as z group by ccode ,survey,names  order by survey");
            }
            else
            {
                dsPins = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), "select distinct  ccode ,survey,names,string_agg(distinct z.khata_nos, ', ') as khata_nos ,count(khata_nos) as khata_no_count from ((select distinct x.*, string_agg(distinct y.khata_no, ', ') as khata_nos from (select ccode,survey,names,count(names) from (select ccode, string_agg(distinct trim( replace (replace(replace(fname,' ','') ,' %','') , '% ','') )||' '||trim(replace (replace(replace(mname,' ','') ,' %','') , '% ','') )||' '||trim(replace (replace(replace(lname,' ','') ,' %','') , '% ',''))||' '||trim(replace (replace(replace(topan_name,' ','') ,' %','') , '% ','') ), ', ') as names ,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey  from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and marked<>'Y'   and    ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8) not in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode ='" + (string)Session["ccode"] + "'  and khata_no='500001') group by ccode,khata_no,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') ) as a group by ccode,survey,names having count(names)>1) as x ,(select  khata_no,string_agg(distinct trim( fname)||' '||trim( mname)||' '||trim( lname)||' '||trim( topan_name), ', ') as names1,rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/') as survey1 from  " + Convert.ToString(Session["SchemaName"]) + ".form7_khata   where  ccode='" + (string)Session["ccode"] + "'  and    khata_no<>'500001'  group by  khata_no,survey1 ) as y where x.names=y.names1 group by y.khata_no,ccode,survey,names,count)  order by survey )as z group by ccode ,survey,names  order by survey");
            }
            sb.Append("<body>");

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>समान नावांची एकापेक्षा जास्त खाती असलेल्या सर्वे क्रमांकांची यादी </b></font></td>");
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
            sb.Append("<td width='30%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> गट / सर्वे क्रमांक</b></font></td>");
            sb.Append("<td width='40%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> खातेदाराचे नाव /नावे</b></font></td>");
            sb.Append("<td width='10%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> एकूण खाता क्रमांक</b></font></td>");
            sb.Append("<td width='10%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> खाता क्रमांक</b></font></td>");

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
                    sb.Append("<td width='40%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["names"]) + "");
                    sb.Append("</font></td >");
                    sb.Append("<td width='10%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["khata_no_count"]) + "");
                    sb.Append("</font></td >");
                    sb.Append("<td width='10%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(dr["khata_nos"]) + "");
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