using System;
using System.Data;
using System.Configuration;


using System.Data.Common;

using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using NIC.WebLMISLibrary;
using Npgsql;

public partial class declarationI : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    clsCommonFunction con = new clsCommonFunction();
    StringBuilder sb = new StringBuilder();
    string page_name = "खाता वर्क डिक्लरेशन";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["ccode"]) != "")
            {
                int rec_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' ", "");
                if (rec_cnt > 0)
                {
                    int date_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  khata_master_declaration =false and khata_master_declair_date  isnull", "");
                    if (date_cnt > 0)
                    {
                        string popupScript = "<script language='javascript'>alert('Declaration I  बघण्या पुर्वी  संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्राम महसूल अधिकारी स्वयं घोषणा करणे आवश्यक आहे याची नोंद घ्यावी.' );</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;

                    }
                }
                else
                {

                    string popupScript = "<script language='javascript'>alert('Declaration I  बघण्या पुर्वी  संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्राम महसूल अधिकारी स्वयं घोषणा करणे आवश्यक आहे याची नोंद घ्यावी.' );</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
               //// string tal_sevarth = string.Empty;
               //// tal_sevarth = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp_audit", "distinct login_id", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_master_declaration=true", "timestatus  desc  limit 1");
               // if (tal_sevarth == string.Empty)
              //  {
                  //  tal_sevarth = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".m_officermast", "distinct username", "ccode='" + Convert.ToString(Session["ccode"]) + "' and user_type='1'", "");
               // }
                //string talathiname = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='T' and  servarthid='" + Convert.ToString(Session["UserName"]) + "' and user_status='L'", "");
               //// string talathiname = con.funReturnSingleValue("rcis_uni.fpusers1", "distinct (case WHEN  trim(marathiname)    is  null then  trim(fullname) else  marathiname end)||' - '||servarthid", "servarthid='" + tal_sevarth + "'", "");


                DataTable tal_sevarth = con.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp_audit", "distinct login_id, timestatus", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "timestatus  desc  limit 1");
                string talathiname = con.funReturnSingleValue("rcis_uni.fpusers1", "distinct (case WHEN  trim(marathiname)    is  null then  trim(fullname) else  marathiname end)||' - '||servarthid", "servarthid='" + tal_sevarth.Rows[0]["login_id"].ToString() + "'", "");

                //if (talathiname == "" || talathiname == null)
                //{
                //    tal_sevarth = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".m_officermast", "distinct username", "ccode='" + Convert.ToString(Session["ccode"]) + "' and user_type='1'", "");
                //    talathiname = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='T' and  Trim(servarthid)='" + tal_sevarth.ToString().Trim() + "' and user_status='L'", "");
                //}

                int maxkhata = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".holder_detail ", "count( distinct khata_no::int)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no not in ('TKN','0' ,'' ,'  ' , '500001') ", "");
                sb.Append("<body >");
                sb.Append("<Center>");
                sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='58%' bordercolorlight='#000000' >");
                sb.Append("<thead>");
                sb.Append("<tr>");
                sb.Append("<td width='100%' valign='top' align='center' format ='justify' underline='true'><font size='5' face='Sakal Marathi  ' color= purple><b><u>Declaration-I</u></b></font></td>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                //sb.Append("<td width='100%' valign='top' align='center' format ='justify'><font size='5' face='Sakal Marathi  ' color= purple><b>री-एडीट आज्ञावली मधील खात्यांची दुरुस्ती पुर्ण झाल्याचे तलाठी स्वयं घोषणा पत्र</b></font></td>");

                sb.Append("<td width='100%' valign='top' align='center' format ='justify'><font size='5' face='Sakal Marathi  ' color= purple><b>Data Entry Module मधील खात्यांची दुरुस्ती पुर्ण झाल्याचे ग्राम महसूल अधिकारी यांचे स्वयं घोषणा पत्र</b></font></td>");
                sb.Append("</tr>");
                sb.Append("</thead>");
                sb.Append("</table>");
                sb.Append("</br >");

                sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='58%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  text-align: justify; text-justify: inter-word; >");
                sb.Append("<tr width='100%'>");
                sb.Append("<td width='100%' align='justify'> <font size='3' face='Sakal Marathi  ' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbspमी  &nbsp;&nbsp;<b>" + talathiname.Split('-')[0] + "</b> ग्राम महसूल अधिकारी , सेवार्थ आय. डी. <b>" + talathiname.Split('-')[1] + " </b>&nbsp;&nbsp; स्वयं घोषणा करतो, </font></td>");
                sb.Append("</tr >");

                sb.Append("<tr width='100%'>");
                //sb.Append("<td width='100%' text-align: justify; text-justify: inter-word;> <font size='3' face='Sakal Marathi  ' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbspमौजे  <b>&nbsp;" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + "</b> तालुका  <b>" + Convert.ToString(Session["TalukaName"]) + "</b>&nbsp;&nbsp;या गावचे संगणकीकृत गाव नमुना 7/12 व 8अ हस्तलिखत गाव नमुना 7/12 व अद्ययावत 8अ शी तंतोतंत जुळविण्यासाठी दिलेल्या एडीट आज्ञावली मध्ये काम केले आहे. व री-एडीट आज्ञावली मधील खात्यांची दुरुस्ती बाबतची प्रक्रिया पुर्ण  केली असून 1) खाते एकत्रिकरण व 2) खाते विभागणी गरजे प्रमाणे पुर्ण केले आहे. गावांत एकूण  <b>" + maxkhata + "</b>  इतकी खाती असुन ती गाव ऑनलाईन झाल्यापासूनचे सर्व मंजूर फेरफार विचारात घेऊन अद्यावत केली आहेत . ONLINE खाता नोंदवही ठेवण्यसाठी शासन स्तरावरून दिलेल्या सूचना विचारात घेऊन खात्याशी संबंधित सर्व कामकाज पूर्ण केले आहे म्हणून ही स्वयंघोषणा करत आहे. </font></td>");

                sb.Append("<td width='100%' text-align: justify; text-justify: inter-word;> <font size='3' face='Sakal Marathi  ' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbspमौजे  <b>&nbsp;" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + "</b> तालुका  <b>" + Convert.ToString(Session["TalukaName"]) + "</b>&nbsp;&nbsp;या गावचे संगणकीकृत गाव नमुना 7/12 व 8अ, हस्तलिखत गाव नमुना 7/12 व 8अ शी तंतोतंत जुळविण्यासाठी दिलेल्या Data Entry Module मध्ये काम केले आहे व Data Entry Module  मधील खात्यांची दुरुस्ती बाबतची प्रक्रिया पुर्ण केली असून 1) खाते एकत्रिकरण व 2) खाते विभागणी गरजे प्रमाणे पुर्ण केले आहे</font></td>");
                sb.Append("</tr>");
    
                sb.Append("<td width='100%' text-align: justify; text-justify: inter-word;> <font size='3' face='Sakal Marathi  ' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp गावांत एकूण  <b>" + maxkhata + "</b>  इतकी खाती असुन ती गाव ऑनलाईन झाल्यापासूनचे सर्व मंजूर फेरफार विचारात घेऊन अद्यावत केली आहेत .</font></td>");
                sb.Append("</tr>");
                sb.Append("<br>");
                sb.Append("<br>");
                sb.Append("<td width='100%' text-align: justify; text-justify: inter-word;> <font size='3' face='Sakal Marathi  ' >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp ONLINE खाता नोंदवही ठेवण्यसाठी शासन स्तरावरून दिलेल्या सूचना विचारात घेऊन खात्याशी संबंधित सर्व कामकाज पूर्ण केले आहे म्हणून ही स्वयंघोषणा करत आहे. </font></td>");
                sb.Append("</tr>");
                sb.Append("</table>");
               
                
                sb.Append("</br>");
                sb.Append("</br>");


                sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='58%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
                sb.Append("<tr width='100%'>");
                sb.Append("<td width='60%' align='left'> <font size='3' face='Sakal Marathi  ' >दिनांक : <b>" + System.DateTime.Now.ToShortDateString() + "</b>");
                sb.Append("</td>");
                sb.Append("<td width='40%' align='left'> <font size='3' face='Sakal Marathi  ' >स्वाक्षरी : ");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr width='100%'>");
                sb.Append("<td width='60%' align='left'> <font size='3' face='Sakal Marathi  ' >ठिकाण : <b>" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + "</b>");
                sb.Append("</td>");
                sb.Append("<td width='40%' align='left'> <font size='3' face='Sakal Marathi  ' >ग्राम महसूल अधिकारी नाव  :   <b>" + talathiname.Split('-')[0] + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");

                sb.Append("<tr width='100%'>");
                sb.Append("<td width='60%' align='left'> <font size='3' face='Sakal Marathi  ' >");
                sb.Append("</td>");
                sb.Append("<td width='40%' align='left'> <font size='3' face='Sakal Marathi  ' >सेवार्थ आयडी  :   <b>" + talathiname.Split('-')[1] + "</b>");
                sb.Append("</td>");
                sb.Append("</tr>");



                sb.Append("</center>");
                sb.Append("</table>");
                sb.Append("</br >");



                sb.Append("</br>");
                sb.Append("</Center>");
                sb.Append("</body>");
                Response.Write(sb.ToString());
            }
            else
            {
                string popupScript = "<script language='javascript'>alert('कृपया गाव निवडा.' );</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
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