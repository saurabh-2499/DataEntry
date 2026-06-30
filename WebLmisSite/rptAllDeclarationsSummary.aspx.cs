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

public partial class rptAllDeclarationsSummary : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    clsCommonFunction con = new clsCommonFunction();
    StringBuilder sb = new StringBuilder();
    string page_name = "rptAllDeclarationsSummary";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet Ds_all_ccode = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census ", "ccode,village_name", "ccode  <>''", "village_name");
            //int total_villages = objedit.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census ", "count(*)", "ccode  <>''", "");
            //DataSet ds_d1_done = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census ", "string_agg(distinct   trim(village_name) ,',') as village_name,count(*) as total_completed_villages", "ccode  in ( select distinct  ccode  from  "+Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp  where khata_master_declaration=true  )", "village_name");
            //DataSet ds_d1_Notdone = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census ", "string_agg(distinct   trim(village_name) ,',') as village_name,count(*) as total_incompleted_villages", "ccode not in ( select distinct  ccode  from  " + Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp  where khata_master_declaration=true  )", "village_name");
            //DataSet ds_d2_done = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census ", "string_agg(distinct   trim(village_name) ,',') as village_name,count(*) as total_d2Done_villages", "ccode  in ( select distinct a.ccode from " + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b   where a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true )", "village_name");
            //DataSet ds_d2_Notdone = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census ", "string_agg(distinct   trim(village_name) ,',') as village_name,count(*) as total_d2notDone_villages", "ccode not in ( select distinct a.ccode from " + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b   where a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true )", "village_name");

            //DataSet ds_d3_done = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census ", "string_agg(distinct   trim(village_name) ,',') as village_name,count(*) as total_d3Done_villages", "ccode  in ( select distinct  ccode  from  " + Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3  where  trim(ah1remark)='होय' and trim(ah2remark)='होय' and trim(docremark)='होय' and  trim(prapatr2remark)='होय' )", "village_name");
            //DataSet ds_d3_Notdone = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census ", "string_agg(distinct   trim(village_name) ,',') as village_name,count(*) as total_d3notDone_villages", "ccode not in (select distinct  ccode  from  " + Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3  where  trim(ah1remark)='होय' and trim(ah2remark)='होय' and trim(docremark)='होय' and  trim(prapatr2remark)='होय' )", "village_name");

            DataSet ds_d1_status = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), "(select ccode, (case when count(*)=1 then 'होय' else 'n' end) as D1_status, village_name  from " + Convert.ToString(Session["SchemaName"]) + ".m_village_census   where   ccode  in ( select distinct  ccode  from  " + Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp  where     khata_master_declaration=true  )  group  by  ccode, village_name union select ccode, (case when count(*)=1 then 'नाही' else 'y' end) as D1_status, village_name  from " + Convert.ToString(Session["SchemaName"]) + ".m_village_census   where   ccode not in ( select distinct  ccode  from  " + Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp  where     khata_master_declaration=true  )  group  by  ccode, village_name ) order by village_name ");
            DataSet ds_d2_status = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), "(select ccode, (case when count(*)=1 then 'होय' else 'n' end) as D2_status, village_name  from " + Convert.ToString(Session["SchemaName"]) + ".m_village_census   where   ccode  in   ( select distinct a.ccode from " + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b   where a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true )    group  by  ccode, village_name union (select ccode, (case when count(*)=1 then 'नाही' else 'n' end) as D2_status, village_name  from " + Convert.ToString(Session["SchemaName"]) + ".m_village_census   where   ccode not  in   ( select distinct a.ccode from " + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b   where a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true )    group  by  ccode, village_name)  )order by village_name ");
            DataSet ds_d3_status = objedit.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), " (select ccode, (case when count(*)=1 then 'होय' else 'n' end) as D3_status, village_name  from " + Convert.ToString(Session["SchemaName"]) + ".m_village_census   where   ccode  in   ( select distinct  ccode  from  " + Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3  where  trim(ah1remark)='होय' and trim(ah2remark)='होय' and trim(docremark)='होय' and  trim(prapatr2remark)='होय'  )    group  by  ccode, village_name union (select ccode, (case when count(*)=1 then 'नाही' else 'n' end) as D3_status, village_name  from " + Convert.ToString(Session["SchemaName"]) + ".m_village_census   where   ccode not  in   ( select distinct  ccode  from  " + Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3  where  trim(ah1remark)='होय' and trim(ah2remark)='होय' and trim(docremark)='होय' and  trim(prapatr2remark)='होय'  )    group  by  ccode, village_name)) order by village_name ");
            sb.Append("<body>");

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>री-एडीट आज्ञावलीद्वारे घोषणापत्र १,२,३ बाबतच्या कामाचा गाव निहाय सारांश अहवाल</b></font></td>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("</table>");
            sb.Append("</br >");


            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
            sb.Append("<tr width='100%'>");
            sb.Append("<td width='33%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>तालुका :-  </b> " + Convert.ToString(Session["TalukaName"]) + "</font></td>");
            sb.Append("<td width='33%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>जिल्हा :-  </b> " + Convert.ToString(Session["DistrictName"]) + "</font></td>");
            sb.Append("<td width='34%' align='left' valign='top' > <font size='3' face='Sakal Marathi  '>&nbsp;<b>अहवाल दिनांक:- </b> " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "</font></td>");
            sb.Append("</tr >");
            sb.Append("</table>");           


            sb.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' bordercolordark='#FFFFFF'  >");
          
            sb.Append("<tr width='100%'>");
            sb.Append("<td width='5%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>अ.क्र.</b></font></td>");
            sb.Append("<td width='20%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>गावाचे नाव</b></font></td>");
            sb.Append("<td width='25%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>घोषणापत्र -१ ( DECLARATION - I )</b></font></td>");
            sb.Append("<td width='25%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>घोषणापत्र -२ ( DECLARATION - II )</b></font></td>");
            sb.Append("<td width='25%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>&nbsp;<b>घोषणापत्र -३ ( DECLARATION - III )</b></font></td>");
            sb.Append("</tr >");
            int i = 0; int srno = 1;
            foreach (DataRow drccode in Ds_all_ccode.Tables[0].Rows)
            {
                sb.Append("<tr width='100%'>");
                sb.Append("<td width='5%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>" + srno + "</font></td>");
                sb.Append("<td width='20%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>"+drccode["village_name"].ToString()+"</font></td>");
                sb.Append("<td width='25%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>" + ds_d1_status.Tables[0].Rows[i]["D1_status"].ToString() + "</font></td>");
                sb.Append("<td width='25%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>" + ds_d2_status.Tables[0].Rows[i]["D2_status"].ToString() + "</font></td>");
                if (ds_d2_status.Tables[0].Rows[i]["D2_status"].ToString() == "होय")
                sb.Append("<td width='25%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>" + ds_d3_status.Tables[0].Rows[i]["D3_status"].ToString() + "</font></td>");
                else
                    sb.Append("<td width='25%' align='left' valign='top'> <font size='3' face='Sakal Marathi  '>नाही</font></td>");
                sb.Append("</tr >");
                i++; srno++;
            }

            sb.Append("</body>");
            Response.Output.Write(sb.ToString());

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