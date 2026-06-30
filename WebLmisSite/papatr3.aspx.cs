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
public partial class papatr3 : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    clsCommonFunction con = new clsCommonFunction();
    StringBuilder sb = new StringBuilder();
    string page_name = "प्रपत्र - ३";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToString(Session["ccode"]) != "")
            {

                DataTable dt = con.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".tblewc_proforma3 ", "*", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");

                if (dt != null)
                {
                    string talathiname = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='T' and  servarthid='" + Convert.ToString(Session["UserName"]) + "' and user_status='L'", "");

                    int maxkhata = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".holder_detail ", "max(khata_no::int)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no not in ('TKN','0' ,'' ,'  ') ", "");
                    sb.Append("<body>");

                    sb.Append("<center>");
                    sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='95%' bordercolorlight='#000000' >");
                    sb.Append("<tr>");
                    sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple ><b><u>Declaration - III </u> </b></font></td>");
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple ><b>अचुक गाव नमुना ७/१२ व ८अ  साठी काम पुर्ण झाल्याचे अंतिम प्रमाणपत्र </b></font></td>");
                    sb.Append("</tr>");
                    sb.Append("</table>");                  
                    sb.Append("</center>");


                    sb.Append("<center>");
                    sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='95%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
                    sb.Append("<tr width='100%'>");
                    //sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;गावाचे नाव  :&nbsp;&nbsp;<b>" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + "</b>&nbsp;&nbsp; तालुका  : &nbsp;&nbsp;<b>" + Convert.ToString(Session["TalukaName"]) + "</b>&nbsp;&nbsp;  जिल्हा  : &nbsp;&nbsp;<b>" + Convert.ToString(Session["DistrictName"]) + "</b>&nbsp;&nbsp;</font></td>");
                    sb.Append("<td width='33%' align='center'> <font size='3' face='Sakal Marathi'>गावाचे नाव  :&nbsp;&nbsp;<b>" + Convert.ToString(Session["VillageDetail"]).Split('#')[1] + "</b></font></td>");
                    sb.Append("<td width='33%' align='center'> <font size='3' face='Sakal Marathi'>तालुका  :&nbsp;&nbsp;<b>" + Convert.ToString(Session["TalukaName"]) + "</b></font></td>");
                    sb.Append("<td width='34%' align='center'> <font size='3' face='Sakal Marathi'>जिल्हा  :&nbsp;&nbsp;<b>" + Convert.ToString(Session["DistrictName"]) + "</b></font></td>");
               // तालुका  : &nbsp;&nbsp;<b>" + Convert.ToString(Session["TalukaName"]) + "</b>&nbsp;&nbsp;  जिल्हा  : &nbsp;&nbsp;<b>" + Convert.ToString(Session["DistrictName"]) + "</b>&nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");
                   
                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left' colspan='3'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;सेन्सस कोड  :&nbsp;&nbsp;<b>" + Convert.ToString(Session["ccode"]) + "</b></font></td>");
                    sb.Append("</tr >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left' colspan='3'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ग्राम महसूल अधिकारी नाव :&nbsp;&nbsp;<b>" + talathiname.Split('-')[0] + "</b>  , सेवार्थ आय. डी. :&nbsp;&nbsp;<b>" + dt.Rows[0]["tal_sevarth"] + " </b>&nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");
                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left' colspan='3'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;मंडळ अधिकारी नाव :&nbsp;&nbsp;<b>" + dt.Rows[0]["co_name"] + "</b>  , सेवार्थ आय. डी. :&nbsp;&nbsp;<b>" + dt.Rows[0]["co_sevarth"] + " </b>&nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");
                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left' colspan='3'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;पालक महसुल अधिकारी यांचे नाव :&nbsp;&nbsp;<b>" + dt.Rows[0]["revoff_name"] + "</b>  , सेवार्थ आय. डी. :&nbsp;&nbsp;<b>" + dt.Rows[0]["revoff_sevarth"] + " </b>&nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >"); //revoff_name
                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;१)  दिनांक ०५/०५/२०१७ चे परिपत्रका प्रमाणे महसुल अधिकाऱ्यांनी गाव तपासणी केल्याचा दिनांक &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;<b>" + dt.Rows[0]["revoff_checkdate"].ToString().Split(' ')[0] + "</b> &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left' colspan='3'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;२)  तालुका समरी अहवाल - १ (अहवाल १ ते १४ ) निरंक आहे का ?  (अहवाल १ , ३ व ६ वगळून) &nbsp;&nbsp; :&nbsp;&nbsp;<b>" + dt.Rows[0]["ah1remark"] + "</b> &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left' colspan='3'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;३)  तालुका समरी अहवाल - २ (अहवाल १५ ते २६ ) निरंक आहे का ?   &nbsp;&nbsp; :&nbsp;&nbsp;<b>" + dt.Rows[0]["ah2remark"] + "</b> &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");


                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left' colspan='3'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;४ )   दिनांक ०५/०५/२०१७ चे परिपत्रका तील तपासणी अधिकाऱ्यांनी व कर्मचाऱ्यांनी सादर करावयाची प्रमाणपत्रे &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  दिली आहेत का ?   &nbsp;&nbsp; :&nbsp;&nbsp;<b>" + dt.Rows[0]["ah2remark"] + "</b> &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");

                    sb.Append("</table>");
                    sb.Append("</center>");
                   

                    sb.Append("<center>");
                    sb.Append("<table  border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' ");
                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='center'> <font size='3' face='Sakal Marathi'><b>( प्रपत्र क्रमांक - १ ) </b> &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");
                    sb.Append("</table>");
                    sb.Append("</center>");

                    sb.Append("<center>");
                    sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' ");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> अ. क्र.</b> </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> पद</b> </font></td>");
                    sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> नाव </b></font></td>");
                    sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> सेवार्थ आय. डी. </b></font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> % तपासणी  इष्टांक </b></font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> तपासणी केलेल्या  ७/१२ ची संख्या </b></font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> तपासणी प्रमाणपत्र  प्राप्त दिनांक </b></font></td>");
                    sb.Append("</tr >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १ </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; २ </font></td>");
                    sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३ </font></td>");
                    sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ४ </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ५ </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ६ </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ७ </font></td>");
                    sb.Append("</tr >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १ </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> ग्राम महसूल अधिकारी </b></font></td>");
                    sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tal_name"] + "</b> </font></td>");
                    sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tal_sevarth"] + "</b></font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १००% </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["tal_712cnt"] + "</b> </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tal_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                    sb.Append("</tr >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; २ </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> मंडळ अधिकारी </b></font></td>");
                    sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["co_name"] + "</b> </font></td>");
                    sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["co_sevarth"] + "</b></font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३०% </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["co_712cnt"] + "</b> </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["co_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                    sb.Append("</tr >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३ </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> नायब तहसिलदार </b></font></td>");
                    sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["dba_name"] + "</b> </font></td>");
                    sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["dba_sevarth"] + "</b></font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १०% </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["dba_712cnt"] + "</b> </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["dba_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                    sb.Append("</tr >");


                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ४ </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>तहसिलदार </b></font></td>");
                    sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tah_name"] + "</b> </font></td>");
                    sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tah_sevarth"] + "</b></font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ५% </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["tah_712cnt"] + "</b> </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tah_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                    sb.Append("</tr >");


                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ५ </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> उपविभागिय अधिकारी </b></font></td>");
                    sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["col_name"] + "</b> </font></td>");
                    sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["col_sevarth"] + "</b></font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३% </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["col_712cnt"] + "</b> </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["col_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                    sb.Append("</tr >");


                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ६ </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> जिल्हाधिकारी/उपजिल्हाधिकारी </b></font></td>");
                    sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["sdo_name"] + "</b> </font></td>");
                    sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["sdo_sevarth"] + "</b></font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १% </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["sdo_712cnt"] + "</b> </font></td>");
                    sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["sdo_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                    sb.Append("</tr >");


                    sb.Append("</table>");
                    sb.Append("</center >");                  

                    sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' ");
                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='centre'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;५) संबंधित तलाठी,मंडळ अधिकारी,नायब तहसिलदार व तहसिलदार यांनी गाव निहाय संगणिकृत ७/१२ च्या डेटा &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; अचुकते बाबत जिल्हाधिकारी यंना प्रमाणपत्र सादर केलेले आहे का ?</font></td>");
                    sb.Append("</tr >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='centre'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>( प्रपत्र क्रमांक - २ )</b> : &nbsp;&nbsp;<b>" + dt.Rows[0]["prapatr2remark"] + "</b> &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");
                    sb.Append("</br >");
                    sb.Append("</br >");


                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>६) या गावातील संगणिकृत ७/१२ व ८अ, ऑनलाईन फेरफार व डिजीटल स्वाक्षरीने ७/१२ वितरीत करण्यासाठी योग्य &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; असलेचे प्रमाणित करण्यात येत आहे.</b>&nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");

                    sb.Append("</br >");
                    sb.Append("</br >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;तपासणी अधिकारी.&nbsp;&nbsp;</font></td>");
                    sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;स्वाक्षरी &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");

                    sb.Append("</br >");
                    sb.Append("</br >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;१.ग्राम महसूल अधिकारी &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");

                    sb.Append("</br >");
                    sb.Append("</br >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;२.मंडळ अधिकारी  &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");

                    sb.Append("</br >");
                    sb.Append("</br >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;३.नायब तहसिलदार   &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");

                    sb.Append("</br >");
                    sb.Append("</br >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ४.तहसिलदार  &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");

                    sb.Append("</br >");
                    sb.Append("</br >");

                    sb.Append("<tr width='100%'>");
                    sb.Append("<td width='100%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;५.उपविभागिय अधिकारी &nbsp;&nbsp;</font></td>");
                    sb.Append("</tr >");

                    sb.Append("</br >");
                    sb.Append("</br >");
                    sb.Append("<table>");
                    //sb.Append("<tr width='100%'>");
                    //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; या प्रमाणपत्राची माहिती तलाठी भरतील व नायब तहसिलदार ( DBA ) प्रमाणित करतील . &nbsp;&nbsp;</font></td>");
                    //sb.Append("</tr >");

                    Response.Write(sb.ToString());
                }
                else
                {
                    string popupScript = "<script language='javascript'>alert('कृपया गाव निवडा.' );</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
            }
            else
            {
                string popupScript = "<script language='javascript'>alert('माहिती उपलब्ध नाही.' );</script>";
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