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

public partial class rtpDeclrationII : System.Web.UI.Page
{
    clsCommonFunction con = new clsCommonFunction();
    StringBuilder sb = new StringBuilder();
    clscommonfunedit objedit = new clscommonfunedit();
    DataSet ewc_status, ewc_proform3 = new DataSet();
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
            if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b, " + Convert.ToString(Session["SchemaName"]) + ".m_ewc_checks as c", "(case when count(a.*)>11 then true else false end) as d2status", "a.ccode ='" + Session["ccode"].ToString() + "' and  a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true and  a.wc_code=c.wc_code and  c.check_type='S'  and a.ccode  in  (  select    ccode  from " + Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3  where ccode ='" + Session["ccode"].ToString() + "')", "")) == false)
         //  if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b, " + Convert.ToString(Session["SchemaName"]) + ".m_ewc_checks as c", "(case when count(a.*)>11 then true else false end) as d2status", "a.ccode ='" + Session["ccode"].ToString() + "' and  a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true  and  c.check_type='S'  and a.ccode  in  (  select    ccode  from " + Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3  where ccode ='" + Session["ccode"].ToString() + "')", "")) == false)
            {
                //this.EnableDisableConrols();
                string popupScript = "<script language='javascript'>alert('सदर गावाचे  घोषणापत्र -II ( DECLARATION-II )  चे काम  पूर्ण  झाल्याशिवाय   घोषणापत्र -II ( DECLARATION-II )  बघता येणार नाही याची नोंद घ्यावी.!!!!!!');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }

            string total_712count = objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7 ", "count(*)", "ccode  ='" + Convert.ToString(Session["ccode"]) + "' and khata_no <>'500001' and marked<>'Y' ", "");
            string total_holdercount = objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".holder_detail ", "count(distinct khata_no)", "ccode  ='" + Convert.ToString(Session["ccode"]) + "' ", "");

            ds_officerDetails = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails ", "*", "ccode  ='" + Convert.ToString(Session["ccode"]) + "' ", "");
            ewc_status = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status  a , " + Convert.ToString(Session["SchemaName"]) + ".m_ewc_checks b ", "b.wc_code, b.wc_details ,  (case  when   a.status_code=1 then 'होय'  else  'नाही' end ) as status ", "a.ccode  ='" + Convert.ToString(Session["ccode"]) + "' and a.wc_code=b.wc_code", "b.wc_code");
            //ewc_proform3 = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3", "*", "ccode  ='" + Convert.ToString(Session["ccode"]) + "'", "");
            DataTable dt = con.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".tblewc_proforma3 ", "ccode, village_name, taluka_ccode, taluka_name, district_ccode, district_name, tal_name, tal_sevarth, co_name, co_sevarth, dba_name,dba_sevarth, tah_name, tah_sevarth, col_name, col_sevarth, sdo_name,sdo_sevarth, revoff_name, revoff_sevarth, revoff_checkdate, ah1remark,ah2remark, docremark, prapatr2remark, tal_712cnt, co_712cnt, dba_712cnt, tah_712cnt, col_712cnt, sdo_712cnt, to_char(tal_chkdate,'dd/MM/yyyy')as  tal_chkdate,to_char(co_chkdate,'dd/MM/yyyy')as  co_chkdate,to_char(dba_chkdate,'dd/MM/yyyy')as  dba_chkdate,to_char(tah_chkdate,'dd/MM/yyyy')as  tah_chkdate,to_char(col_chkdate,'dd/MM/yyyy')as  col_chkdate,to_char(sdo_chkdate,'dd/MM/yyyy')as  sdo_chkdate,info_save_date", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");
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
            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' <b><u>प्रपत्र २ (Declaration-II) </u></b></font></td>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='1' face='Sakal Marathi  ' <b> &nbsp;</b></font></td>");
            sb.Append("</tr>");

            sb.Append("<tr>");
          //  sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' <b>Re-Edit Module मधील काम पूर्ण झाल्याचे नायब तहसिलदार ( D.B.A.) यांचे स्वयंघोषणापत्र</b></font></td>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' <b>Data Entry Module मधील काम पूर्ण झाल्याचे नायब तहसीलदार (DBA) यांचे स्वयंघोषणा पत्र </b></font></td>");

            sb.Append("</tr>");
            sb.Append("</table>");
            sb.Append("</br >");
            sb.Append("</center>");

            sb.Append("<center>");
            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%'>");
            sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi  ' >");

            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;मी <b>" + Convert.ToString(dt.Rows[0]["dba_name"]) + "</b> नायब तहसिलदार तथा  डी.बी.ए. तालुका : <b>" + Convert.ToString(Session["TalukaName"]) + "</b> जिल्हा :  <b>" + Convert.ToString(Session["DistrictName"]) + "</b>  सेवार्थ आयडी : <b>" + Convert.ToString(dt.Rows[0]["dba_sevarth"]) + " </b> ");
            sb.Append("स्वयंघोषणा करतो की,<br/>");
            sb.Append("&nbsp;&nbsp;&nbsp;&nbsp;मौजे  <b>" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + "</b>  तालूका : <b>" + Convert.ToString(Session["TalukaName"]) + "</b> जिल्हा :  <b>" + Convert.ToString(Session["DistrictName"]) + "</b> या गावाचे संगणकीकृत गांव नमुना नं. 7/12 व 8 अ हस्तलिखित ");
            //sb.Append("गाव न.नं. 7/12 व 8 अ शी तंतोतंत जुळणे साठी दिलेया खालील पैकी एक किंवा सर्व सुविधांचा वापर करून ");
             sb.Append("गाव न.नं. 7/12 व 8 अ शी तंतोतंत जुळणेसाठी Data Entry Module  चा वापर करून ७/१२ व ८अ मधील दुरुस्त्या ग्राम महसूल अधिकारी  ");
            //sb.Append("तसेच ऑनलाईन झाल्यापासुन सर्व ऑनलाईन फेरफार नोंदी व त्याप्रमाणे 7/12 व 8अ मधील दुरुस्त्या तलाठी : <b> " + dt.Rows[0]["tal_name"].ToString() + " </b>  सेवार्थ  आयडी : <b> " + dt.Rows[0]["tal_sevarth"].ToString() + "</b> यांनी पूर्ण केल्या आहेत. </br >");
             sb.Append(" : <b> " + dt.Rows[0]["tal_name"].ToString() + " </b>  सेवार्थ  आयडी : <b> " + dt.Rows[0]["tal_sevarth"].ToString() + "</b> यांनी पूर्ण केल्या आहेत. </br >");
                        
             sb.Append("</br >");
             sb.Append("1. खाते दुरुस्ती संबंधी सर्व दुरुस्त्या  <b>Data entry Module </b> वापरून पूर्ण केल्या आहेत.</br >");
             sb.Append("</br >");
          // sb.Append("2. चावडी वाचनामध्ये प्राप्त आक्षेप व दिनांक  <b>०५/०५/२०१७ च्या परिपत्रका </b> प्रमाणे महसूल अधिकाऱ्यांच्या तपासणी ");
             sb.Append("2. १ ते २० मुद्द्यांच्या सर्व त्रुटी दुरुस्त करण्यात आलेल्या आहेत.</br >");
             sb.Append("</br >");
            //sb.Append("तक्त्यात ( १ ते २४ मुद्दे ) आढळून आलेल्या सर्वे त्रुटी दूर करण्यात आल्या आहेत.</br >");
            sb.Append("गावाची तपासणी केलेल्या महसूल अधिकाऱ्यांचे (पालक) नाव : <b> " + officername + " </b>.</br >");
            sb.Append("पदनाम :  <b>  " + desg + " </b> &nbsp; सेवार्थ आयडी :  <b>  " + officer_sevarthid + " </b>   व तपासणीची दिनांक :  <b>  " + inspectDate + " </b>. </br > प्रमाणे तपासणी सूचित आढळून आलेल्या चुका व त्रुटीदेखील दुरुस्त करण्यात आल्या आहेत.");
            sb.Append("</td >");
            sb.Append("</tr >");
            sb.Append("</table>"); sb.Append("</center>");
            sb.Append("</br >");
            
            sb.Append("3. हया गावाचे ऑनलाईन Data Entry Module  मध्ये  सर्व फेरफार नोंदीचा योग्य अमंल झाला आहे का? व खाते दुरुस्तीदेखील योग्य रित्या झाली आहे का?  हे खालील अधिकारी यांनी  प्रिंट ७/१२ वर तपासले आहे.</br > ");
            sb.Append("</br >");            

            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' ");

            sb.Append("<tr width='100%'>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> अ. क्र.</b> </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> पदनाम</b> </font></td>");
            sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> नाव </b></font></td>");
            sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> सेवार्थ आय.डी. </b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> % तपासणी  इष्टांक </b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> तपासणी केलेल्या  ७/१२ ची संख्या </b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> तपासणी प्रमाणपत्र  प्राप्त दिनांक </b></font></td>");
            sb.Append("</tr >");
                     
            sb.Append("<tr width='100%'>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १ </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> ग्राम महसूल अधिकारी </b></font></td>");
            sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tal_name"] + "</b> </font></td>");
            sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tal_sevarth"] + "</b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १००% </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["tal_712cnt"] + "</b> </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tal_chkdate"].ToString() + "</b></font></td>");
            sb.Append("</tr >");

            sb.Append("<tr width='100%'>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; २ </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> मंडळ अधिकारी </b></font></td>");
            sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["co_name"] + "</b> </font></td>");
            sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["co_sevarth"] + "</b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३०% </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["co_712cnt"] + "</b> </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["co_chkdate"].ToString() + "</b></font></td>");
            sb.Append("</tr >");

            sb.Append("<tr width='100%'>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३ </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> नायब तहसिलदार </b></font></td>");
            sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["dba_name"] + "</b> </font></td>");
            sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["dba_sevarth"] + "</b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १०% </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["dba_712cnt"] + "</b> </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["dba_chkdate"].ToString() + "</b></font></td>");
            sb.Append("</tr >");
            
            sb.Append("<tr width='100%'>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ४ </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>तहसिलदार </b></font></td>");
            sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tah_name"] + "</b> </font></td>");
            sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tah_sevarth"] + "</b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ५% </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["tah_712cnt"] + "</b> </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tah_chkdate"].ToString() + "</b></font></td>");
            sb.Append("</tr >");
            
            sb.Append("<tr width='100%'>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ५ </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> उपविभागिय अधिकारी </b></font></td>");
            sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["col_name"] + "</b> </font></td>");
            sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["col_sevarth"] + "</b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३% </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["col_712cnt"] + "</b> </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["col_chkdate"].ToString() + "</b></font></td>");
            sb.Append("</tr >");
            
            sb.Append("<tr width='100%'>");
            sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ६ </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> जिल्हाधिकारी/उपजिल्हाधिकारी </b></font></td>");
            sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["sdo_name"] + "</b> </font></td>");
            sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["sdo_sevarth"] + "</b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १% </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["sdo_712cnt"] + "</b> </font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["sdo_chkdate"].ToString() + "</b></font></td>");
            sb.Append("</tr >");
            sb.Append("</table>");
            sb.Append("</br >");
           
            sb.Append("</center>");
            
            sb.Append("<p><center><font size='4' face='Sakal Marathi  ' ><b>तपासणी सूची (१-२०) नुसार गावाचे खाता रजिस्टर व गावातील सर्व ७/१२ यांच्या दुरुस्त्या तपासणी सूची क्रमांकानुसार पूर्ण केल्याची घोषणा करणे </b></font></center></p>");

            sb.Append("<center>");
            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='5%' valign='top' align='center'><font size='4' face='Sakal Marathi  ' ><b>अनु. क्र.</b></font></td>");
            sb.Append("<td width='75%' valign='top' align='center'><font size='4' face='Sakal Marathi  ' ><b>तपासणी सूची क्रमांक १ ते २०.</b></font></td>");
            sb.Append("<td width='20%' valign='top' align='center'><font size='4' face='Sakal Marathi  ' ><b>घोषणा करणे</b></font></td>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            foreach (DataRow dr in ewc_status.Tables[0].Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td width='5%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' > " + Convert.ToString(dr["wc_code"]) + "</font></td>");
                sb.Append("<td width='75%' valign='top' align='left'><font size='3' face='Sakal Marathi  ' >&nbsp;" + Convert.ToString(dr["wc_details"]) + "</font></td>");
                sb.Append("<td width='20%' valign='top' align='center'><font size='3' face='Sakal Marathi  ' >" + Convert.ToString(dr["status"]) + "</font></td>");
                sb.Append("</tr>");
              
             }
            sb.Append("</center>");
            sb.Append("<center>");
            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%'>");
            sb.Append("</br >");
            sb.Append("४. ग्राम महसूल अधिकारी यांनी या गावामध्ये असलेल्या एकूण " + total_712count + "  ७/१२  पैकी  " + total_712count + "  आणि एकूण    " + total_holdercount + "    खात्यांपैकी    " + total_holdercount + "    खाते क्रमांक व ७/१२ Data Entry Module मध्ये दुरुस्त करण्यात आलेले आहेत. यानंतर या गावात एकही गट नं / सर्व्हे नं ७/१२ व ८अ दुरुस्तीसाठी प्रलंबित नाही.</br >");
            sb.Append("</br >");
            sb.Append("</table>"); 
            
            Response.Write(sb.ToString());

            
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