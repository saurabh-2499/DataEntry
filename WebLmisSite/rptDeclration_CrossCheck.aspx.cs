using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NIC.WebLMISLibrary;
using System.Data.Common;
using Npgsql;
using System.Text.RegularExpressions;
using System.Text;

public partial class rptDeclration_CrossCheck : System.Web.UI.Page
{
    StringBuilder sb = new StringBuilder();
    clscommonfunedit objedit = new clscommonfunedit();
    clscommonfun con = new clscommonfun();
    DataSet ewc_status = new DataSet();
    string page_name = "rtpDeclrationII.aspx";
    string officername = string.Empty;
    string desg = string.Empty;
    string officer_sevarthid = string.Empty;
    string inspectDate = string.Empty;

    string totalror = string.Empty;
    string total_corr_ror = string.Empty;

    string totalkhata_no = string.Empty;
    string total_corr_khata_no = string.Empty;
    DataSet ds_officerDetails = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
            if (Convert.ToUInt32(userExist) == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
            }

            if (Convert.ToString(Session["user_type"]).Equals("T") || Convert.ToString(Session["user_type"]).Equals("DBA"))
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


                ds_officerDetails = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails ", "*", "ccode  ='" + Convert.ToString(Session["ccode"]) + "' ", "");

                ewc_status = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_ewc_checks ", "*", "wc_code in (" + Session["outvalue"].ToString() + ")", "wc_code");
                if (ds_officerDetails.Tables[0].Rows.Count > 0)
                {
                    officername = ds_officerDetails.Tables[0].Rows[0]["officer_name"].ToString();
                    desg = ds_officerDetails.Tables[0].Rows[0]["officer_desg"].ToString();
                    officer_sevarthid = ds_officerDetails.Tables[0].Rows[0]["officer_sevarthid"].ToString();
                    totalror = ds_officerDetails.Tables[0].Rows[0]["total_ror"].ToString();
                    total_corr_ror = ds_officerDetails.Tables[0].Rows[0]["total_reedited_ror"].ToString();
                    totalkhata_no = ds_officerDetails.Tables[0].Rows[0]["total_khata_no"].ToString();
                    total_corr_khata_no = ds_officerDetails.Tables[0].Rows[0]["total_reedited_khata_no"].ToString();

                }
                inspectDate = objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails ", "to_char(ewc_date,'DD/MM/YYYY')as ewc_date", "ccode  ='" + Convert.ToString(Session["ccode"]) + "' ", "");
                sb.Append("<body>");

                sb.Append("<center>");
                 sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'>");

               
               

                 sb.Append("<tr>");
                 sb.Append("<td width='100%' valign='top'>");
                 sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'>");
                #region [----tr start---]
                 sb.Append("<tr>");
                 sb.Append("<td width='33%' valign='top'><font size='2' face='Sakal Marathi'></font></td>");
                 sb.Append("<td width='33%' valign='top'>");
                 sb.Append("<p align='center'><font size='2' face='Sakal Marathi'><b></b></font></td>");
                 sb.Append("<td width='34%' valign='top'>");
                 sb.Append("<p align='right'><font size='2' face='Sakal Marathi'>अहवाल दिनांक: " +  DateTime.Now.ToShortDateString() + "</font></td>");
                 sb.Append("</tr>");
                #endregion

                #region [---------tr start---------]
                 sb.Append("<tr>");
                 sb.Append("<td width='100%' valign='top' colspan='3'>");
                //  sb.Append("<p align='center'><font size='2' face='Sakal Marathi'><b>अहवाल क्र. ५<br>");
                 sb.Append("</tr>");
                #endregion

                #region [----tr start---]
                 sb.Append("<tr>");
                 sb.Append("<td width='100%' valign='top' colspan='3'>");
                 sb.Append("<p><center><font size='4' face='Sakal Marathi  ' ><b>तपासणी सूची ( १-२४ ) नुसार निदर्शनास आलेल्या त्रुटी</b></font></center></p>");
                 sb.Append("</tr>");
                #endregion

                #region [----tr start---]
                 sb.Append("<tr>");
                 sb.Append("<td width='33%' valign='top'><font size='2' face='Sakal Marathi'>गाव: ");
                 sb.Append(Session["village_name"].ToString() + "</font></td>");
                 sb.Append("<td width='33%' valign='top'>");
                 sb.Append("<p align='center'><font size='2' face='Sakal Marathi'>तालुका: ");
                 sb.Append(Session["TalukaName"].ToString() + "</font></td>");
                 sb.Append("<td width='34%' valign='top'>");
                 sb.Append("<p align='center'><font size='2' face='Sakal Marathi'>जिल्हा: ");
                 sb.Append(Session["DistrictName"].ToString() + "</font></td>");
                 sb.Append("</tr>");
                #endregion

                #region [----tr start---]
                 sb.Append("<tr>");
                 sb.Append("<td width='100%' valign='top' colspan='3'>");
                 sb.Append("</td>");
                 sb.Append("</tr>");
                #endregion

                 sb.Append("</table>");

                //sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
                //sb.Append("<tr width='100%'>");
                //sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi  ' >");
                //sb.Append("<p><center><font size='4' face='Sakal Marathi  ' ><b>तपासणी सूची ( १-२४ ) नुसार निदर्शनास आलेल्या त्रुटी</b></font></center></p>");
                sb.Append("<center>");
                sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' >");
                sb.Append("<thead>");
                sb.Append("<tr>");
                sb.Append("<td width='5%' valign='top' align='center'><font size='4' face='Sakal Marathi  ' ><b>अनु. क्र.</b></font></td>");
                sb.Append("<td width='75%' valign='top' align='center'><font size='4' face='Sakal Marathi  ' ><b>तपासणी सूची</b></font></td>");

                sb.Append("</tr>");
                sb.Append("</thead>");
                int i = 1;
                foreach (DataRow dr in ewc_status.Tables[0].Rows)
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + i + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >&nbsp;" + Convert.ToString(dr["wc_details"]) + "</font></td>");

                    sb.Append("</tr>");
                    i++;
                }
                if (Session["outvalue"].ToString().Contains("25"))
                {
                    //string s25 = @"@एकाच सर्व्हे क्रमांकावर समान नावांची एकापेक्षा जास्त खाती आहेत.(कृपया , ""समान नावांची एकापेक्षा जास्त खाती असलेल्या सर्वे क्रमांकांची"" यादी हा अहवाल बघावा. )";
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + ( i++ )+ "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""एकाच सर्व्हे क्रमांकावर समान नावांची एकापेक्षा जास्त खाती आहेत.""</b> ( कृपया , ""<b>समान नावांची एकापेक्षा जास्त खाती असलेल्या सर्वे क्रमांकांची यादी</b>"" हा अहवाल बघावा.</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                if (Session["outvalue"].ToString().Contains("26"))
                {
                    //string s25 = @"@एकाच सर्व्हे क्रमांकावर समान नावांची एकापेक्षा जास्त खाती आहेत.(कृपया , ""समान नावांची एकापेक्षा जास्त खाती असलेल्या सर्वे क्रमांकांची"" यादी हा अहवाल बघावा. )";
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""७/१२ वरील खात्यांवर निरंक नावे आहेत.""</b>( कृपया ODC मधील अहवाल क्र २७.  ""<b>खातेदारांचे नाव/नावे  निरंक असलेले खाता - सर्व्हे क्रमांक</b>"" हा अहवाल बघावा व रेकॉर्ड दुरुस्तीच्या  सुविधा मधील  सुविधा क्र. १६ ""<b>खातेदारांचे नाव / नावे  निरंक असलेले खाते क्रमांक / नावे  सर्व्हे क्रमांकावरून काढून टाकणे.</b>"" हा  पर्याय सदर गावच्या ग्राम महसूल अधिकारी यांनी वापरावा.)</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                if (Session["outvalue"].ToString().Contains("27"))
                {                    
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""खातेदारांच्या नावामध्ये स्पेस असल्याने डूप्लीकेट रेकॉर्ड्स  आहेत.""</b>( कृपया ODC मधील अतिरिक्त अहवाल  क्र ८.  ""<b>खातेदारांच्या नावामध्ये स्पेस असल्याने डूप्लीकेट तयार झालेल्या नावांची खाता -सर्व्हे क्रमांक निहाय यादी</b>"" हा अहवाल बघावा व रेकॉर्ड दुरुस्तीच्या  सुविधा मधील  सुविधा क्र. १७ ""<b>खातेदारांच्या नावामध्ये स्पेस असल्याने तयार झालेले डूप्लीकेट काढून टाकणे.</b>"" हा  पर्याय सदर गावच्या ग्राम महसूल अधिकारी यांनी वापरावा.)</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                if (Session["outvalue"].ToString().Contains("28"))
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""चुकीच्या पद्धतीने भरलेली अपाक,ए.कु.मॅ नावांची खाती. आहेत.""</b>( कृपया ODC मधील अतिरिक्त अहवाल  क्र १०.  ""<b>चुकीच्या पद्धतीने भरलेली अपाक,ए.कु.मॅ नावांची खाती</b>"" हा अहवाल बघावा व ReEdit  अद्न्यावालीद्वारे योग्य ती दुरुस्ती  करणेत यावी.</b>"" .)</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }

                if (Session["outvalue"].ToString().Contains("29"))
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""गाव नमुना ७ वरील एकुण क्षेत्र व जिरायत,बागायत,इत्यादी क्षेत्र यांचा मेळ न बसलेले सर्व्हे क्र आहेत.""</b>( कृपया ODC मधील   अहवाल  क्र ४.  ""<b>गाव नमुना ७ वरील एकुण क्षेत्र व जिरायत,बागायत,इत्यादी क्षेत्र यांचा मेळ न बसलेले सर्व्हे क्र</b>"" हा अहवाल बघावा व ReEdit  अद्न्यावालीद्वारे योग्य ती दुरुस्ती  करणेत यावी.</b>"" .)</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }

                if (Session["outvalue"].ToString().Contains("30"))
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""फ़ेरफ़ार क्र. नसलेल्या कब्जेदारांची नावे आहेत.""</b>( कृपया ODC मधील   अहवाल  क्र ८.  ""<b>फ़ेरफ़ार क्र. नसलेल्या कब्जेदारांची नावे</b>"" हा अहवाल बघावा व ReEdit  अद्न्यावालीद्वारे योग्य ती दुरुस्ती  करणेत यावी.</b>"" .)</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                if (Session["outvalue"].ToString().Contains("31"))
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""इतर आधिकारात नोंदीचा प्रकार निवडलेला नाही अशी माहिती सापडली आहे.""</b>( कृपया ODC मधील   अहवाल  क्र ११ .  ""<b>इतर आधिकारात नोंदीचा प्रकार निवडलेला नाही</b>"" हा अहवाल बघावा व ReEdit  अद्न्यावालीद्वारे योग्य ती दुरुस्ती  करणेत यावी.</b>"" .)</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                if (Session["outvalue"].ToString().Contains("32"))
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""फ़ेरफ़ार क्र.नसलेल्या इतर अधिकारांच्या नोंदी आहेत.""</b>( कृपया ODC मधील   अहवाल  क्र १२. ""<b>फ़ेरफ़ार क्र.नसलेल्या इतर अधिकारांच्या नोंदी</b>"" हा अहवाल बघावा व ReEdit  अद्न्यावालीद्वारे योग्य ती दुरुस्ती  करणेत यावी.</b>"" .)</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                if (Session["outvalue"].ToString().Contains("33"))
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""गाव नमुना ७ वरील एकुण आकारणी व ७/१२ वरील खात्यांच्या एकुण आकारणीचा फ़रक आहे.""</b>( कृपया ODC मधील  अतिरिक्त अहवाल  क्र ९.  ""<b>गाव नमुना ७ वरील एकुण आकारणी व ७/१२ वरील खात्यांच्या एकुण आकारणीचा फ़रक</b>"" हा अहवाल बघावा व ReEdit  अद्न्यावालीद्वारे योग्य ती दुरुस्ती  करणेत यावी.</b>"" .)</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                if (Session["outvalue"].ToString().Contains("34"))
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""खातामास्टर मध्ये अतिरिक्त नावे  खाते आहेत.""</b>( कृपया ODC मधील  अतिरिक्त अहवाल  क्र ११.  ""<b>खातामास्टर मध्ये अतिरिक्त नावे  असलेल्या खात्यांची सर्व्हे क्रमांकनिहाय यादी</b>"" हा अहवाल बघावा व   रेकॉर्ड दुरुस्तीच्या  सुविधा मधील  सुविधा क्र. १९  ""<b>खातामास्टर वरील अतिरिक्त नावे काढणे.</b>"" हा  पर्याय सदर गावच्या ग्राम महसूल अधिकारी यांनी वापरावा.</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                if (Session["outvalue"].ToString().Contains("35"))
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""निरंक अथवा '-' अथवा '0' अथवा 'TKN' असलेले खाते आहेत.""</b>( कृपया ODC मधील   अहवाल  क्र १५.  ""<b>निरंक अथवा '-' अथवा '0' अथवा 'TKN' असलेले खाते</b>"" हा अहवाल बघावा व   रेकॉर्ड दुरुस्तीच्या  सुविधा मधील  सुविधा क्र. ९ ""<b> निरंक अथवा '-' अथवा '0' अथवा 'TKN' असलेले  खाता क्रमांक दुरुस्ती .</b>"" हा  पर्याय सदर गावच्या ग्राम महसूल अधिकारी यांनी वापरावा.</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }

                if (Session["outvalue"].ToString().Contains("36"))
                {
                    sb.Append("<tr>");
                    sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + (i++) + "</font></td>");
                    sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >");
                    sb.Append(@"सदर गावामध्ये <b>""अहवाल 5- अतिरिक्त मध्ये त्रुटी आहेत.""</b>( कृपया ODC मधील अतिरिक्त अहवाल क्र १२.  ""<b>अहवाल 5- अतिरिक्त</b>"" हा अहवाल बघावा व रेकॉर्ड दुरुस्तीच्या सुविधा मधील सुविधा क्र. २१ ""<b> अतिरिक्त अहवाल 5 ची दुरुस्ती.</b>"" हा  पर्याय सदर गावच्या ग्राम महसूल अधिकारी यांनी वापरावा.</font>");
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                sb.Append("</br >");
                sb.Append("<center>");
                sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
                sb.Append("<tr width='100%'>");
                sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi  ' >");

                sb.Append(@"टीप : वरील त्रुटी दुरुस्त  करणेसाठी  ""<b>री - डाटा एन्ट्री मॉड्युल द्वारे करावयाच्या कामांची पडताळणी सुची</b>"" यातील सुचवलेल्या सूचनांचा उपयोग करून कार्यवाही करावी.सदर त्रुटी निरंक झाल्यावरच प्रपत्र -२ तयार होईल याची   नोंद घ्यावी.<br><a href='Downloads/Re-EditTapasni Suchi.pdf' target='_blank'>री - डाटा एन्ट्री मॉड्युल द्वारे करावयाच्या कामांची पडताळणी सुची </a>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</center>");
                sb.Append("</table>");
                sb.Append("</br >");

                sb.Append("</br >");

                sb.Append("</br >");
                 Response.Write(sb.ToString());
            }
            else
            {

                string popupscript = "<script>alert('कृपया तलाठी/DBA  यांनी  लॉंगीन करा.')</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupscript);
                Response.Redirect("pgLogout.aspx", false);
            }
        }
        catch (Exception ex)
        {

            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }

    }
}