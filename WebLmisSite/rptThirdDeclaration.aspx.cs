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

public partial class rptThirdDeclaration : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    clsCommonFunction con = new clsCommonFunction();
    StringBuilder sb = new StringBuilder();
    string inspectDate = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Convert.ToString(Session["ccode"]) != "")
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
                   
                    if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3", "(case when count(*)=1 then true else false end) as d3status ", "ccode ='" + Session["ccode"].ToString() + "'   and  trim(ah1remark)='होय' and trim(ah2remark)='होय' and  	trim(docremark)='होय' and  	trim(prapatr2remark)='होय' ", "")) == false)
                    {
                        string popupScript = "<script language='javascript'>alert('सदर गावाचे  घोषणापत्र -III ( DECLARATION-III )  चे काम  पूर्ण  झाल्याशिवाय   घोषणापत्र -III ( DECLARATION-III ) बघता येणार नाही याची नोंद घ्यावी.!!!!!!');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
                    DataTable dt = con.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".tblewc_proforma3 ", "*", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");
                    inspectDate = objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails ", "to_char(ewc_date,'DD/MM/YYYY')as ewc_date", "ccode  ='" + Convert.ToString(Session["ccode"]) + "' ", "");
                    if (dt != null)
                    {
                        string talathiname = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='T' and  servarthid='" + Convert.ToString(Session["UserName"]) + "' and user_status='L'", "");

                        sb.Append("<center>");
                        sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' >");
                        sb.Append("<tr>");
                        sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple ><b><u>Declaration - III </u> </b></font></td>");
                        sb.Append("</tr>");
                        sb.Append("<tr>");
                        sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple ><b>अचुक गाव नमुना ७/१२ व ८अ  साठी काम पुर्ण झाल्याचे <br><u>तहसिलदार यांचे अंतिम प्रमाणपत्र</u> </b></font></td>");
                        sb.Append("</tr>");
                        sb.Append("</table>");


                        sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
                        sb.Append("<tr width='100%'>");
                        sb.Append("<td width='25%' align='left'> <font size='3' face='Sakal Marathi'>गावाचे नाव  :&nbsp;&nbsp;<b>" + Convert.ToString(dt.Rows[0]["village_name"]) + "</b></font></td>");
                        sb.Append("<td width='25%' align='center'> <font size='3' face='Sakal Marathi'>तालुका  :&nbsp;&nbsp;<b>" + Convert.ToString(dt.Rows[0]["taluka_name"]) + "</b></font></td>");
                        sb.Append("<td width='25%' align='right'> <font size='3' face='Sakal Marathi'>जिल्हा  :&nbsp;&nbsp;<b>" + Convert.ToString(dt.Rows[0]["district_name"]) + "</b></font></td>");
                        sb.Append("<td width='25%' align='left'> <font size='3' face='Sakal Marathi'></font></td>");
                        sb.Append("</tr >");
                        sb.Append("<tr width='100%'>");
                        sb.Append("<td width='100%' align='left' colspan='4'> <font size='3' face='Sakal Marathi'>सेन्सस कोड  :&nbsp;&nbsp;<b>" + Convert.ToString(Session["ccode"]) + "</b></font></td>");
                        sb.Append("</tr >");


                        sb.Append("<tr width='100%'>");
                        sb.Append("<td width='50%' align='left' colspan='2' > <font size='3' face='Sakal Marathi'>ग्राम महसूल अधिकारी नाव  :&nbsp;&nbsp;<b>" + Convert.ToString(dt.Rows[0]["tal_name"]) + "</b></font></td>");
                        sb.Append("<td width='50%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'>सेवार्थ आय. डी. :&nbsp;&nbsp;<b>" + Convert.ToString(dt.Rows[0]["tal_sevarth"]) + "</b></font></td>");
                        sb.Append("</tr >");

                        sb.Append("<tr width='100%'>");
                        sb.Append("<td width='50%' align='left' colspan='2' > <font size='3' face='Sakal Marathi'>मंडळ अधिकारी नाव :&nbsp;&nbsp;<b>" + Convert.ToString(dt.Rows[0]["co_name"]) + "</b></font></td>");
                        sb.Append("<td width='50%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'>सेवार्थ आय. डी. :&nbsp;&nbsp;<b>" + Convert.ToString(dt.Rows[0]["co_sevarth"]) + "</b></font></td>");
                        sb.Append("</tr >");


                        sb.Append("<tr width='100%'>");
                        sb.Append("<td width='50%' align='left' colspan='2' > <font size='3' face='Sakal Marathi'>पालक महसुल अधिकारी यांचे नाव  :&nbsp;&nbsp;<b>" + Convert.ToString(dt.Rows[0]["revoff_name"]) + "</b></font></td>");
                        sb.Append("<td width='50%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'>सेवार्थ आय. डी. :&nbsp;&nbsp;<b>" + Convert.ToString(dt.Rows[0]["revoff_sevarth"]) + "</b></font></td>");
                        sb.Append("</tr >");


                        sb.Append("<tr width='100%'>");
                        sb.Append("<td width='75%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'>१) दिनांक ०५/०५/२०१७ चे परिपत्रका प्रमाणे महसूल अधिकारी गाव तपासणी केल्याचा दिनांक: </font></td>");
                        sb.Append("<td width='25%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'><b>" + inspectDate + "</b></font></td>");

                        sb.Append("</tr >");

                        sb.Append("<tr width='100%'>");

                        sb.Append("<td width='75%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'>२) तालुका समरी अहवाल - १ (अहवाल १ ते १४ ) निरंक आहे का ?  (अहवाल १ , ३ व ६ वगळून) :</font></td>");
                        sb.Append("<td width='25%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'> <b>" + dt.Rows[0]["ah1remark"] + " </b></font></td>");
                        sb.Append("</tr >");

                        sb.Append("<tr width='100%'>");
                        sb.Append("<td width='75%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'>३) तालुका समरी अहवाल - २ (अहवाल १५ ते २६ )) निरंक आहे का ? :</font></td>");
                        sb.Append("<td width='25%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'> <b>" + dt.Rows[0]["ah2remark"] + " </b></font></td>");
                        sb.Append("</tr >");

                        sb.Append("<tr width='100%'>");
                        sb.Append("<td width='75%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'>४) दिनांक ०५/०५/२०१७ चे परिपत्रका तील तपासणी अधिकाऱ्यांनी व कर्मचाऱ्यांनी सादर करावयाची प्रमाणपत्रे दिली आहेत का ?:</font></td>");
                        sb.Append("<td width='25%' align='left' colspan='2'> <font size='3' face='Sakal Marathi'> <b>" + dt.Rows[0]["docremark"] + " </b></font></td>");
                        sb.Append("</tr >");
                        sb.Append("</table>");

                        //sb.Append("<table  border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' ");
                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='100%' align='center'> <font size='3' face='Sakal Marathi'><b>( प्रपत्र क्रमांक - १ ) </b> &nbsp;&nbsp;</font></td>");
                        //sb.Append("</tr >");
                        //sb.Append("</table>");
                        sb.Append("</center>");

                        //sb.Append("<center>");
                        //sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' ");

                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> अ. क्र.</b> </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> पद</b> </font></td>");
                        //sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> नाव </b></font></td>");
                        //sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> सेवार्थ आय. डी. </b></font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> % तपासणी  इष्टांक </b></font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> तपासणी केलेल्या  ७/१२ ची संख्या </b></font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> तपासणी प्रमाणपत्र  प्राप्त दिनांक </b></font></td>");
                        //sb.Append("</tr >");

                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १ </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; २ </font></td>");
                        //sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३ </font></td>");
                        //sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ४ </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ५ </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ६ </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ७ </font></td>");
                        //sb.Append("</tr >");

                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १ </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> तलाठी </b></font></td>");
                        //sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tal_name"] + "</b> </font></td>");
                        //sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tal_sevarth"] + "</b></font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १००% </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["tal_712cnt"] + "</b> </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tal_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                        //sb.Append("</tr >");

                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; २ </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> मंडळ अधिकारी </b></font></td>");
                        //sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["co_name"] + "</b> </font></td>");
                        //sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["co_sevarth"] + "</b></font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३०% </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["co_712cnt"] + "</b> </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["co_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                        //sb.Append("</tr >");

                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३ </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> नायब तहसिलदार </b></font></td>");
                        //sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["dba_name"] + "</b> </font></td>");
                        //sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["dba_sevarth"] + "</b></font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १०% </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["dba_712cnt"] + "</b> </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["dba_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                        //sb.Append("</tr >");


                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ४ </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>तहसिलदार </b></font></td>");
                        //sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tah_name"] + "</b> </font></td>");
                        //sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tah_sevarth"] + "</b></font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ५% </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["tah_712cnt"] + "</b> </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["tah_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                        //sb.Append("</tr >");


                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ५ </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> उपविभागिय अधिकारी </b></font></td>");
                        //sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["col_name"] + "</b> </font></td>");
                        //sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["col_sevarth"] + "</b></font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ३% </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["col_712cnt"] + "</b> </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["col_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                        //sb.Append("</tr >");


                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='5%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; ६ </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b> जिल्हाधिकारी/उपजिल्हाधिकारी </b></font></td>");
                        //sb.Append("<td width='21%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["sdo_name"] + "</b> </font></td>");
                        //sb.Append("<td width='14%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["sdo_sevarth"] + "</b></font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; १% </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp;<b>" + dt.Rows[0]["sdo_712cnt"] + "</b> </font></td>");
                        //sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi'>&nbsp; <b>" + dt.Rows[0]["sdo_chkdate"].ToString().Split(' ')[0] + "</b></font></td>");
                        //sb.Append("</tr >");
                        //sb.Append("</table>");
                        // sb.Append("</br >");
                        sb.Append("<center>");
                        sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' ");
                        sb.Append("<tr width='100%'>");
                        sb.Append("<td width='100%' align='centre'> <font size='3' face='Sakal Marathi'>५) संबधीत तलाठी, मंडळ अधिकारी, नायब तहसिलदार व तहसिलदार यांनी गांवनिहाय संगणकृत   7/12 च्या डेटा च्या अचुकते बाबत प्रमाणपत्र  <b>(प्रपत्र क्रमांक-2)</b>  उपविभागीय अधिकारी यांनी जिल्हाधिकारी यांना  सादर केलेले आहे काय .<b> : &nbsp;&nbsp;<b>" + dt.Rows[0]["prapatr2remark"] + "</b></font></td>");
                        sb.Append("</tr >");
                        sb.Append("<td width='100%' align='centre'> <font size='3' face='Sakal Marathi'>६) ग्राम महसूल अधिकारी  ( १००%) ,  मंडळ अधिकारी (३०%) , नायब तहसिलदार ( १०%) , तहसिलदार ( ५ % ) , उपविभागीय अधिकारी ( 3% ) , जिल्हाधिकारी अथवा जिल्हाधिकारी यांचे प्रतिनिधी म्हणून उप जिल्हाधिकारी (१%) यांनी तपासणी करून  स्वाक्षरीत केलेले ७/१२ तालुका अभिलेख कक्षात जमा करणेत आले आहेत .</font></td>");
                        sb.Append("</tr >");
                        sb.Append("</tr >");
                        sb.Append("<td width='100%' align='centre'> <font size='3' face='Sakal Marathi'>७) ग्राम महसूल अधिकारी दप्तरामध्ये असलेले सर्व हस्तलिखित ७/१२ व हस्तलिखित ८अ देखील तालुका अभिलेख कक्षात जमा करून घेणेत आले आहेत .ह्याची मी स्वतः खात्री केली आहे . </font></td>");
                        sb.Append("</tr >");
                        sb.Append("</tr >");
                        sb.Append("<td width='100%' align='centre'> <font size='3' face='Sakal Marathi'>८) या गावातील संगणकीकृत 7/12 व 8 अ डेटा, ऑनलाईन फेरफार व डिजिटल स्वाक्षरीने 7/12 वितरीत करणेसाठी योग्य असलेचे प्रमाणित करण्यात येत आहे. म्हणून हे घोषणापत्र करत आहे .  </font></td>");
                        sb.Append("</tr >");
                        sb.Append("<table>");


                        //sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'><b>तपासणी अधिकारी</b></font></td>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'><b>स्वाक्षरी</b></font></td>");
                        //sb.Append("</tr >");
                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'>१.तलाठी</font></td>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'></b></font></td>");
                        //sb.Append("</tr >");
                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'>२.मंडळ अधिकारी</font></td>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'></b></font></td>");
                        //sb.Append("</tr >");
                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'>३.नायब तहसिलदार</font></td>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'></b></font></td>");
                        //sb.Append("</tr >");

                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'>४.तहसिलदार</font></td>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'></b></font></td>");
                        //sb.Append("</tr >");

                        //sb.Append("<tr width='100%'>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'>५.उपविभागिय अधिकारी</font></td>");
                        //sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi'></b></font></td>");
                        //sb.Append("</tr >");
                        sb.Append("</br >");
                        sb.Append("<center>");
                        sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='90%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
                        sb.Append("<tr width='100%'>");
                        sb.Append("<td width='50%' align='left'> <font size='3' face='Sakal Marathi  ' >दिनांक : <b>" + System.DateTime.Now.ToShortDateString() + "</b>");
                        sb.Append("</td>");
                        sb.Append("<td width='50%' align='center'> <font size='3' face='Sakal Marathi  ' > <b>" + dt.Rows[0]["tah_name"].ToString() + " </b> तहसिलदार  ,  सेवार्थ आयडी : <b>" + dt.Rows[0]["tah_sevarth"].ToString() + "</b>");
                        sb.Append("</td>");
                        sb.Append("</tr>");

                        sb.Append("</center>");
                        sb.Append("</table>");
                        sb.Append("</br >"); sb.Append("</br >"); sb.Append("</br >"); sb.Append("</br >"); sb.Append("</br >");
                        sb.Append("</center>");
                        Response.Write(sb.ToString());
                    }
                    else
                    {
                        string popupScript = "<script language='javascript'>alert('कृपया गाव निवडा.' );</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
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
}