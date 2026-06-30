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

public partial class rptNotEditedPins : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    clsCommonFunction con = new clsCommonFunction();
    
    DataTable dtTotalOpenSurveyNo = new DataTable();
    DataTable dtTotalClosedSurveyNo = new DataTable();
    DataTable dttTotalNotMarkSurveyNo = new DataTable();
    DataTable dtTotalEditMarkSurveyNoFinal = new DataTable();
    DataTable dtTotalEditMarkSurveyNoNotFinal = new DataTable();
    DataTable dtTotalConfirmedMarkSurveyNo = new DataTable();

    StringBuilder sb = new StringBuilder();

    int cntTotalSurveyNo = 0, cntTotalOpenSurveyNo = 0, cntTotalClosedSurveyNo = 0, cntTotalNotMarkSurveyNo = 0,  cntTotalEditMarkSurveyNoFinal = 0, cntTotalEditMarkSurveyNoNotFinal = 0, cntTotalConfirmedMarkSurveyNo = 0;
    
    //int edit_servey = 0;
    //int not_finalized_servey = 0;
    //DataSet dsPins = new DataSet();
    //DataSet dsNFS = new DataSet();

    int i = 1;
    static string pincase = " rtrim(((CASE WHEN pin<>'' THEN cast(pin as text)|| '/' WHEN pin='' THEN '' END)  || (CASE WHEN pin1<>'' THEN cast(pin1 as text)|| '/' WHEN pin1='' THEN '' END)  || (CASE WHEN pin2<>'' THEN cast(pin2 as text)|| '/' WHEN pin2='' THEN '' END)  || (CASE WHEN pin3<>'' THEN cast(pin3 as text)|| '/' WHEN pin3='' THEN '' END)  || (CASE WHEN pin4<>'' THEN cast(pin4 as text)|| '/' WHEN pin4='' THEN '' END)  || (CASE WHEN pin5<>'' THEN cast(pin5 as text)|| '/' WHEN pin5='' THEN '' END)  || (CASE WHEN pin6<>'' THEN cast(pin6 as text)|| '/' WHEN pin6='' THEN '' END)  || (CASE WHEN pin7<>'' THEN cast(pin7 as text)|| '/' WHEN pin7='' THEN '' END)  || (CASE WHEN pin8<>'' THEN cast(pin8 as text)|| '/' WHEN pin8='' THEN '' END)),'/')";
    static string surveyNo= " distinct rtrim(((CASE WHEN f.pin<>'' THEN cast(f.pin as text)|| '/' WHEN f.pin='' THEN '' END)  || (CASE WHEN f.pin1<>'' THEN cast(f.pin1 as text)|| '/' WHEN f.pin1='' THEN '' END)  || (CASE WHEN f.pin2<>'' THEN cast(f.pin2 as text)|| '/' WHEN f.pin2='' THEN '' END)  || (CASE WHEN f.pin3<>'' THEN cast(f.pin3 as text)|| '/' WHEN f.pin3='' THEN '' END)  || (CASE WHEN f.pin4<>'' THEN cast(f.pin4 as text)|| '/' WHEN f.pin4='' THEN '' END)  || (CASE WHEN f.pin5<>'' THEN cast(f.pin5 as text)|| '/' WHEN f.pin5='' THEN '' END)  || (CASE WHEN f.pin6<>'' THEN cast(f.pin6 as text)|| '/' WHEN f.pin6='' THEN '' END)  || (CASE WHEN f.pin7<>'' THEN cast(f.pin7 as text)|| '/' WHEN f.pin7='' THEN '' END)  || (CASE WHEN f.pin8<>'' THEN cast(f.pin8 as text)|| '/' WHEN f.pin8='' THEN '' END)),'/')";
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

            cntTotalSurveyNo = objedit.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".form7", "count(distinct ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8))", "ccode  ='" + (string)Session["ccode"] + "'", "");
            cntTotalOpenSurveyNo   = objedit.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".form7", "count(distinct ( pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8))", "ccode  ='" + (string)Session["ccode"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' )", "");
            cntTotalClosedSurveyNo = objedit.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".form7", "count (distinct (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8))", "ccode  ='" + (string)Session["ccode"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' )  ", "");
            //cntTotalNotMarkSurveyNo = objedit.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".form7", "count (distinct (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8))", "ccode  ='" + (string)Session["ccode"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' )  and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new where ccode='" + (string)Session["ccode"] + "' )", "");
           
            
            cntTotalEditMarkSurveyNoNotFinal = objedit.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new e ," + Convert.ToString(Session["SchemaName"]) + ".form7 f", "count( distinct (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8 ))", "f.ccode  ='" + (string)Session["ccode"] + "' and f.ccode=e.ccode and f.pin=e.pin and f.pin1=e.pin1 and f.pin2=e.pin2 and f.pin3=e.pin3 and f.pin4=e.pin4 and f.pin5=e.pin5 and f.pin6=e.pin6 and f.pin7=e.pin7 and f.pin8=e.pin8   and  confirm_flag<> 'Confirm' and 	approve_flag<>'Approve' and (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' )", "");
            cntTotalEditMarkSurveyNoFinal = objedit.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new e," + Convert.ToString(Session["SchemaName"]) + ".form7 f", "count( distinct (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8 ))", "f.ccode  ='" + (string)Session["ccode"] + "' and f.ccode=e.ccode and f.pin=e.pin and f.pin1=e.pin1 and f.pin2=e.pin2 and f.pin3=e.pin3 and f.pin4=e.pin4 and f.pin5=e.pin5 and f.pin6=e.pin6 and f.pin7=e.pin7 and f.pin8=e.pin8 and marked_flag= 'Edit'  and  approve_flag='Approve' and (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' ) ", "");
           // cntTotalConfirmedMarkSurveyNo = objedit.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new e," + Convert.ToString(Session["SchemaName"]) + ".form7 f", "count( distinct (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8 ))", "f.ccode  ='" + (string)Session["ccode"] + "' and f.ccode=e.ccode and f.pin=e.pin and f.pin1=e.pin1 and f.pin2=e.pin2 and f.pin3=e.pin3 and f.pin4=e.pin4 and f.pin5=e.pin5 and f.pin6=e.pin6 and f.pin7=e.pin7 and f.pin8=e.pin8 and   confirm_flag= 'Confirm' and (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' ) ", "");

            dtTotalOpenSurveyNo = con.funReturnDataTable(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".form7" , pincase + "as pincase,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8" , "ccode='" + (string)Session["ccode"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001'   )", "pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8");
            dtTotalClosedSurveyNo = con.funReturnDataTable(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".form7 f", surveyNo + "as  surveyNo ,f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8", " f.ccode='" + (string)Session["ccode"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' ) ", "pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8");
            //dttTotalNotMarkSurveyNo = con.funReturnDataTable(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".form7 f", surveyNo + "as pincase,f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8", "f.ccode  ='" + (string)Session["ccode"] + "' and (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' )  and (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_new where ccode='" + (string)Session["ccode"] + "' )", "f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8");
            dtTotalEditMarkSurveyNoNotFinal = con.funReturnDataTable(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new e," + Convert.ToString(Session["SchemaName"]) + ".form7 f", surveyNo + "as pincase,f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8", "f.ccode='" + (string)Session["ccode"] + "' and f.ccode=e.ccode and f.pin=e.pin and f.pin1=e.pin1 and f.pin2=e.pin2 and f.pin3=e.pin3 and f.pin4=e.pin4 and f.pin5=e.pin5 and f.pin6=e.pin6 and f.pin7=e.pin7 and f.pin8=e.pin8  and confirm_flag<> 'Confirm' and 	approve_flag<>'Approve' and (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' ) ", "f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8");
            dtTotalEditMarkSurveyNoFinal = con.funReturnDataTable(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new  e," + Convert.ToString(Session["SchemaName"]) + ".form7 f", surveyNo + "as pincase,f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8", "f.ccode='" + (string)Session["ccode"] + "' and f.ccode=e.ccode and f.pin=e.pin and f.pin1=e.pin1 and f.pin2=e.pin2 and f.pin3=e.pin3 and f.pin4=e.pin4 and f.pin5=e.pin5 and f.pin6=e.pin6 and f.pin7=e.pin7 and f.pin8=e.pin8 and marked_flag= 'Edit'  and  approve_flag='Approve' and (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' )", "f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8");
           // dtTotalConfirmedMarkSurveyNo = con.funReturnDataTable(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new e," + Convert.ToString(Session["SchemaName"]) + ".form7 f", surveyNo + "as pincase,f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8", "f.ccode='" + (string)Session["ccode"] + "' and f.ccode=e.ccode and f.pin=e.pin and f.pin1=e.pin1 and f.pin2=e.pin2 and f.pin3=e.pin3 and f.pin4=e.pin4 and f.pin5=e.pin5 and f.pin6=e.pin6 and f.pin7=e.pin7 and f.pin8=e.pin8 and confirm_flag= 'Confirm' and (f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8)  not in (select distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Convert.ToString(Session["SchemaName"]) + ".form7_khata where ccode='" + (string)Session["ccode"] + "'  and khata_no ='500001' ) ", "f.pin,f.pin1,f.pin2,f.pin3,f.pin4,f.pin5,f.pin6,f.pin7,f.pin8");

            
        
            sb.Append("<body>");

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>डाटा एन्ट्री आज्ञावलीद्वारे केलेल्या कामाचा गाव - सर्व्हे निहाय सारांश अहवाल</b></font></td>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("</table>");
            sb.Append("</br >");


            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%'>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp;<b>गाव :-  </b>" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + "</font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>तालुका :-  </b> " + Convert.ToString(Session["TalukaName"]) + "</font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>जिल्हा :-  </b> " + Convert.ToString(Session["DistrictName"]) + "</font></td>");
            sb.Append("<td width='40%' align='left' > <font size='3' face='Sakal Marathi  '>&nbsp;<b>अहवाल दिनांक:- </b> " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "</font></td>");
            sb.Append("</tr >");
            sb.Append("</table>");
            sb.Append("</br >");

            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%' rowspan='4'>");
            sb.Append("</tr >");


          
            
            
            sb.Append("<tr width='100%'>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp;<b>एकूण गट / सर्वे क्रमांक</b></font></td>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp;<b>एकूण चालु गट / सर्वे क्रमांक</b></font></td>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp;<b>एकूण बंद गट / सर्वे क्रमांक</b></font></td>");
            //sb.Append("<td width='22%' colspan='2' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b>एकूण एडिट ( दुरुस्ती करणे ) साठी मार्क न केलेले गट / सर्वे क्रमांक</b></font></td>");
            sb.Append("<td width='23%' colspan='2' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b>एकूण हस्तलिखीत/LIMIS ७/१२ पाहुन सर्व्हे/गट क्रमांकाचा नविन ७/१२ तयार करणे  ( दुरुस्ती करणे ) साठी मार्क परंतु दुरुस्ती अथवा प्रमाणित न केलेले गट / सर्वे क्रमांक</b></font></td>");
            sb.Append("<td width='23%' colspan='2' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b>एकूण हस्तलिखीत/LIMIS ७/१२ पाहुन सर्व्हे/गट क्रमांकाचा नविन ७/१२ तयार करणे  ( दुरुस्ती करणे ) साठी मार्क व प्रमाणित केलेले गट / सर्वे क्रमांक</b> </font></td>");
           // sb.Append("<td width='22%' colspan='2' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b>एकूण कन्फर्म ( कायम करणे ) केलेले गट / सर्वे क्रमांक</b></font></td>");

            sb.Append("</tr >");
            sb.Append("<tr width='100%'>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp;" + cntTotalSurveyNo + "</font></td>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp;" + cntTotalOpenSurveyNo + "</font></td>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi  ' >&nbsp;" + cntTotalClosedSurveyNo + "</font></td>");
           // sb.Append("<td width='22%' colspan='2' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp; " + cntTotalNotMarkSurveyNo + "</font></td>");
            sb.Append("<td width='23%' colspan='2' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;" + cntTotalEditMarkSurveyNoNotFinal + "</font></td>");
            sb.Append("<td width='23%' colspan='2' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp; " + cntTotalEditMarkSurveyNoFinal + "</font></td>");
           // sb.Append("<td width='22%' colspan='2' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;" + cntTotalConfirmedMarkSurveyNo + "</font></td>");

            sb.Append("</tr >");

            sb.Append("</table>");
            sb.Append("</br >");


            if (dtTotalClosedSurveyNo.Rows.Count > 0)
            {
                sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
                sb.Append("<thead>");
                sb.Append("<tr>");
                sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>बंद गट / सर्वे क्रमांक</b></font></td>");
                sb.Append("</tr>");
                sb.Append("</thead>");
                sb.Append("</table>");
                sb.Append("</br >");


                sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
                sb.Append("<tr width='100%'  rowspan='4'>");
                sb.Append("</tr >");

                sb.Append("<tr width='100%'  >");
                sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;<b>अनु क्रमांक</b></font></td>");
                sb.Append("<td width='90%' colspan='3' align='left' colspan='4'> <font size='3' face='Sakal Marathi' >");
                sb.Append("</font>&nbsp;<b>गट / सर्वे क्रमांक</b>");
                sb.Append("</td >");
                sb.Append("</tr >");


                foreach (DataRow dr in dtTotalClosedSurveyNo.Rows)
                {
                    sb.Append("<tr width='100%'  >");
                    sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;" + i + "</font></td>");
                    sb.Append("<td width='90%' colspan='3' align='left' colspan='4'> <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + dr["surveyno"].ToString() + "");
                    sb.Append("</font></td >");
                    sb.Append("</tr >");
                    i++;
                }

            }


            sb.Append("</table>");
            sb.Append("</br >");
            i = 1;



            //if (cntTotalNotMarkSurveyNo > 0)
            //{

            //sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            //sb.Append("<thead>");
            //sb.Append("<tr>");
            //sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b> कन्फर्म ( कायम करणे ) अथवा  एडिट ( दुरुस्ती करणे ) साठी मार्क न केलेले गट / सर्वे क्रमांक </b></font></td>");
            //sb.Append("</tr>");
            //sb.Append("</thead>");
            //sb.Append("</table>");
            //sb.Append("</br >");


            //sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            //sb.Append("<tr width='100%'  rowspan='4'>");
            //sb.Append("</tr >");


            //sb.Append("<tr width='100%'  >");
            //sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;<b>अनु क्रमांक</b></font></td>");
            //sb.Append("<td width='90%' colspan='3' align='left' colspan='4'> <font size='3' face='Sakal Marathi' >");
            //sb.Append("</font>&nbsp;<b>गट / सर्वे क्रमांक</b>");
            //sb.Append("</td >");
            //sb.Append("</tr >");

          
            //    foreach (DataRow dr in dttTotalNotMarkSurveyNo.Rows)
            //    {
            //        sb.Append("<tr width='100%'  >");
            //        sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;" + i + "</font></td>");
            //        sb.Append("<td width='90%' colspan='3' align='left' colspan='4'> <font size='3' face='Sakal Marathi  ' >");
            //        sb.Append("&nbsp;" + dr["pincase"].ToString() + "");
            //        sb.Append("</font></td >");
            //        sb.Append("</tr >");
            //        i++;
            //    }

            //}

            //sb.Append("</table>");
            //sb.Append("</br >");
            //i = 1;

            if (dtTotalEditMarkSurveyNoFinal.Rows.Count > 0)
            {
            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>हस्तलिखीत/LIMIS ७/१२ पाहुन सर्व्हे/गट क्रमांकाचा नविन ७/१२ तयार करणे  ( दुरुस्ती करणे ) साठी मार्क व प्रमाणित केलेले गट / सर्वे क्रमांक</b></font></td>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("</table>");
            sb.Append("</br >");


            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%'  rowspan='4'>");
            sb.Append("</tr >");

            sb.Append("<tr width='100%'  >");
            sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;<b>अनु क्रमांक</b></font></td>");
            sb.Append("<td width='90%' colspan='3' align='left' colspan='4'> <font size='3' face='Sakal Marathi' >");
            sb.Append("</font>&nbsp;<b>गट / सर्वे क्रमांक</b>");
            sb.Append("</td >");
            sb.Append("</tr >");

            
                foreach (DataRow dr in dtTotalEditMarkSurveyNoFinal.Rows)
                {
                    sb.Append("<tr width='100%'  >");
                    sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;" + i + "</font></td>");
                    sb.Append("<td width='90%' colspan='3' align='left' colspan='4'> <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + dr["pincase"].ToString() + "");
                    sb.Append("</font></td >");
                    sb.Append("</tr >");
                    i++;
                }

            }
           

            sb.Append("</table>");
            sb.Append("</br >");
            i = 1;

            if (dtTotalEditMarkSurveyNoNotFinal.Rows.Count > 0)
            {

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>हस्तलिखीत/LIMIS ७/१२ पाहुन सर्व्हे/गट क्रमांकाचा नविन ७/१२ तयार करणे  ( दुरुस्ती करणे ) साठी मार्क परंतु दुरुस्ती अथवा प्रमाणित न केलेले गट / सर्वे क्रमांक </b></font></td>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("</table>");
            sb.Append("</br >");


            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%'  rowspan='4'>");
            sb.Append("</tr >");

            sb.Append("<tr width='100%'  >");
            sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;<b>अनु क्रमांक</b></font></td>");
            sb.Append("<td width='90%' colspan='3' align='left' colspan='4'> <font size='3' face='Sakal Marathi' >");
            sb.Append("</font>&nbsp;<b>गट / सर्वे क्रमांक</b>");
            sb.Append("</td >");
            sb.Append("</tr >");

           
                foreach (DataRow dr in dtTotalEditMarkSurveyNoNotFinal.Rows)
                {
                    sb.Append("<tr width='100%'  >");
                    sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;" + i + "</font></td>");
                    sb.Append("<td width='90%' colspan='3' align='left' colspan='4'> <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + dr["pincase"].ToString() + "");
                    sb.Append("</font></td >");
                    sb.Append("</tr >");
                    i++;
                }

            }


            sb.Append("</table>");
            sb.Append("</br >");
            i = 1;
            //if (dtTotalConfirmedMarkSurveyNo.Rows.Count > 0)
            //{
            //sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            //sb.Append("<thead>");
            //sb.Append("<tr>");
            //sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>कन्फर्म ( कायम करणे ) केलेले गट / सर्वे क्रमांक </b></font></td>");
            //sb.Append("</tr>");
            //sb.Append("</thead>");
            //sb.Append("</table>");
            //sb.Append("</br >");


            //sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            //sb.Append("<tr width='100%'  rowspan='4'>");
            //sb.Append("</tr >");

            //sb.Append("<tr width='100%'  >");
            //sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;<b>अनु क्रमांक</b></font></td>");
            //sb.Append("<td width='90%' colspan='3' align='left' colspan='4'> <font size='3' face='Sakal Marathi' >");
            //sb.Append("</font>&nbsp;<b>गट / सर्वे क्रमांक</b>");
            //sb.Append("</td >");
            //sb.Append("</tr >");

           
            //    foreach (DataRow dr in dtTotalConfirmedMarkSurveyNo.Rows)
            //    {
            //        sb.Append("<tr width='100%'  >");
            //        sb.Append("<td width='10%' ><font size='3' face='Sakal Marathi  ' >&nbsp;" + i + "</font></td>");
            //        sb.Append("<td width='90%' colspan='3' align='left' colspan='4'> <font size='3' face='Sakal Marathi  ' >");
            //        sb.Append("&nbsp;" + dr["pincase"].ToString() + "");
            //        sb.Append("</font></td >");
            //        sb.Append("</tr >");
            //        i++;
            //    }

            //}


            //sb.Append("</table>");
            //sb.Append("</br >");
            //i = 1 ;

            if (cntTotalOpenSurveyNo == (cntTotalEditMarkSurveyNoFinal + cntTotalConfirmedMarkSurveyNo))
           {
              sb.Append("<tr width='100%' >");
              sb.Append("<td width='100%' bgcolor='green' colspan='4' align='left'><center> <font size='4' face='Sakal Marathi  '  >&nbsp;<b>" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + " गावातील सर्व चालु गट / सर्वे क्रमांकांचे   कन्फर्म ( कायम करणे )  अथवा  एडिट ( दुरुस्ती ) करुन प्रमाणित करण्याचे काम पूर्ण झाले आहे.!!!!   </b></font></center> </td>");
              sb.Append("</tr >");
           }

           

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