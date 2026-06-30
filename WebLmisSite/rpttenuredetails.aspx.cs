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

public partial class rpttenuredetails : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    
     DataSet DataUpdation = new DataSet();
     DataSet eMutation = new DataSet();
     DataSet edit = new DataSet();
     DataSet reEdit = new DataSet();

    StringBuilder sb = new StringBuilder();
    string page_name;
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
            page_name = "भूधारणा बदलेल्या सर्वे क्रमांकाचा अहवाल ";

            DataUpdation = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), "select distinct a.ccode,a.app_name ,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  || (CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  || (CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  || (CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  || (CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  || (CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  || (CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  || (CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/')as survey, a.mut_no,a.tenure_code ,to_char(a.timestatus, 'dd/MM/yyyy')as changetime, a.timestatus ,a.operation, case when a.app_name='DataUpdation' then 'ओ.डी.यू'    when a.app_name='edit' then 'एडिट'  when    a.app_name='eMutation'  then 'ई - फेरफार' when a.app_name='ReEdit'  then 'री-एडिट'  end as appname , case when c.tenure_name='' then'-' else  c.tenure_name end  from " + Convert.ToString(Session["SchemaName"]) + ".form7_audit a, " + Convert.ToString(Session["SchemaName"]) + ".form7_audit b , " + Convert.ToString(Session["SchemaName"]) + ".m_tenure as c where  a.ccode  ='" + (string)Session["ccode"] + "' and  a.ccode  =b.ccode and  a.pin=b.pin and  a.pin1=b.pin1 and  a.pin2=b.pin2 and  a.pin3=b.pin3 and  a.pin4=b.pin4 and  a.pin5=b.pin5   and  a.pin6=b.pin6   and  a.pin7=b.pin7  and  a.pin8=b.pin8 and  a.tenure_code<>b.tenure_code and a.operation<>'I' and  a.tenure_code=c.tenure_code and a.app_name='DataUpdation' group  by  a.ccode,  a.tenure_code , a.timestatus,a.operation, a.app_name ,a.mut_no,c.tenure_name,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  || (CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  || (CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  || (CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  || (CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  || (CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  || (CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  || (CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/') order by  a.ccode, survey , a.timestatus ,a.app_name");
            eMutation = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), "select distinct a.ccode,a.app_name ,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  || (CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  || (CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  || (CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  || (CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  || (CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  || (CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  || (CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/')as survey, a.mut_no,a.tenure_code ,to_char(a.timestatus, 'dd/MM/yyyy')as changetime, a.timestatus ,a.operation, case when a.app_name='DataUpdation' then 'ओ.डी.यू'    when a.app_name='edit' then 'एडिट'  when    a.app_name='eMutation'  then 'ई - फेरफार' when a.app_name='ReEdit'  then 'री-एडिट'  end as appname , case when c.tenure_name='' then'-' else  c.tenure_name end  from " + Convert.ToString(Session["SchemaName"]) + ".form7_audit a, " + Convert.ToString(Session["SchemaName"]) + ".form7_audit b , " + Convert.ToString(Session["SchemaName"]) + ".m_tenure as c where  a.ccode  ='" + (string)Session["ccode"] + "' and  a.ccode  =b.ccode and  a.pin=b.pin and  a.pin1=b.pin1 and  a.pin2=b.pin2 and  a.pin3=b.pin3 and  a.pin4=b.pin4 and  a.pin5=b.pin5   and  a.pin6=b.pin6   and  a.pin7=b.pin7  and  a.pin8=b.pin8 and  a.tenure_code<>b.tenure_code and a.operation<>'I' and  a.tenure_code=c.tenure_code and a.app_name='eMutation' group  by  a.ccode,  a.tenure_code , a.timestatus,a.operation, a.app_name ,a.mut_no,c.tenure_name,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  || (CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  || (CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  || (CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  || (CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  || (CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  || (CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  || (CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/') order by  a.ccode, survey , a.timestatus ,a.app_name ");
            edit = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), "select distinct a.ccode,a.app_name ,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  || (CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  || (CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  || (CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  || (CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  || (CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  || (CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  || (CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/')as survey, a.mut_no,a.tenure_code ,to_char(a.timestatus, 'dd/MM/yyyy')as changetime, a.timestatus ,a.operation, case when a.app_name='DataUpdation' then 'ओ.डी.यू'    when a.app_name='edit' then 'एडिट'  when    a.app_name='eMutation'  then 'ई - फेरफार' when a.app_name='ReEdit'  then 'री-एडिट'  end as appname , case when c.tenure_name='' then'-' else  c.tenure_name end  from " + Convert.ToString(Session["SchemaName"]) + ".form7_audit a, " + Convert.ToString(Session["SchemaName"]) + ".form7_audit b , " + Convert.ToString(Session["SchemaName"]) + ".m_tenure as c where  a.ccode  ='" + (string)Session["ccode"] + "' and  a.ccode  =b.ccode and  a.pin=b.pin and  a.pin1=b.pin1 and  a.pin2=b.pin2 and  a.pin3=b.pin3 and  a.pin4=b.pin4 and  a.pin5=b.pin5   and  a.pin6=b.pin6   and  a.pin7=b.pin7  and  a.pin8=b.pin8 and  a.tenure_code<>b.tenure_code and a.operation<>'I' and  a.tenure_code=c.tenure_code and a.app_name='edit' group  by  a.ccode,  a.tenure_code , a.timestatus,a.operation, a.app_name ,a.mut_no,c.tenure_name,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  || (CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  || (CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  || (CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  || (CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  || (CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  || (CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  || (CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/') order by  a.ccode, survey , a.timestatus ,a.app_name");
            reEdit = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), "select distinct a.ccode,a.app_name ,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  || (CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  || (CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  || (CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  || (CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  || (CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  || (CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  || (CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/')as survey, a.mut_no,a.tenure_code ,to_char(a.timestatus, 'dd/MM/yyyy')as changetime, a.timestatus ,a.operation, case when a.app_name='DataUpdation' then 'ओ.डी.यू'    when a.app_name='edit' then 'एडिट'  when    a.app_name='eMutation'  then 'ई - फेरफार' when a.app_name='ReEdit'  then 'री-एडिट'  end as appname , case when c.tenure_name='' then'-' else  c.tenure_name end  from " + Convert.ToString(Session["SchemaName"]) + ".form7_audit a, " + Convert.ToString(Session["SchemaName"]) + ".form7_audit b , " + Convert.ToString(Session["SchemaName"]) + ".m_tenure as c where  a.ccode  ='" + (string)Session["ccode"] + "' and  a.ccode  =b.ccode and  a.pin=b.pin and  a.pin1=b.pin1 and  a.pin2=b.pin2 and  a.pin3=b.pin3 and  a.pin4=b.pin4 and  a.pin5=b.pin5   and  a.pin6=b.pin6   and  a.pin7=b.pin7  and  a.pin8=b.pin8 and  a.tenure_code<>b.tenure_code and a.operation<>'I' and  a.tenure_code=c.tenure_code and a.app_name='reEdit' group  by  a.ccode,  a.tenure_code , a.timestatus,a.operation, a.app_name ,a.mut_no,c.tenure_name,rtrim(((CASE WHEN a.pin<>'' THEN cast(a.pin as text)|| '/' WHEN a.pin='' THEN '' END)  || (CASE WHEN a.pin1<>'' THEN cast(a.pin1 as text)|| '/' WHEN a.pin1='' THEN '' END)  || (CASE WHEN a.pin2<>'' THEN cast(a.pin2 as text)|| '/' WHEN a.pin2='' THEN '' END)  || (CASE WHEN a.pin3<>'' THEN cast(a.pin3 as text)|| '/' WHEN a.pin3='' THEN '' END)  || (CASE WHEN a.pin4<>'' THEN cast(a.pin4 as text)|| '/' WHEN a.pin4='' THEN '' END)  || (CASE WHEN a.pin5<>'' THEN cast(a.pin5 as text)|| '/' WHEN a.pin5='' THEN '' END)  || (CASE WHEN a.pin6<>'' THEN cast(a.pin6 as text)|| '/' WHEN a.pin6='' THEN '' END)  || (CASE WHEN a.pin7<>'' THEN cast(a.pin7 as text)|| '/' WHEN a.pin7='' THEN '' END)  || (CASE WHEN a.pin8<>'' THEN cast(a.pin8 as text)|| '/' WHEN a.pin8='' THEN '' END)),'/') order by  a.ccode, survey , a.timestatus ,a.app_name");
            
            DataTable tbltenure = new DataTable();
            tbltenure.Columns.Add("survey", typeof(string));
            tbltenure.Columns.Add("mut_no", typeof(int));
            tbltenure.Columns.Add("appname", typeof(string));
            tbltenure.Columns.Add("oldtenuarename", typeof(string));
            tbltenure.Columns.Add("newtenuarename", typeof(string));
            tbltenure.Columns.Add("oldtimestaus", typeof(DateTime));
            tbltenure.Columns.Add("newtimestaus", typeof(string));

            //--------------------------------DataUpdation------------------------------------------
            if (DataUpdation.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i< DataUpdation.Tables[0].Rows.Count; i++)
                {
                    if (i == (DataUpdation.Tables[0].Rows.Count -1))
                    {

                    }
                    else
                    {
                        if ((DataUpdation.Tables[0].Rows[i]["mut_no"].ToString()) == (DataUpdation.Tables[0].Rows[i + 1]["mut_no"].ToString()))
                        {
                            if ((DataUpdation.Tables[0].Rows[i]["operation"].ToString().Trim() == "OLD") && (DataUpdation.Tables[0].Rows[i + 1]["operation"].ToString().Trim() == "NEW"))
                            {
                                if ((DataUpdation.Tables[0].Rows[i]["tenure_code"].ToString()) != (DataUpdation.Tables[0].Rows[i + 1]["tenure_code"].ToString()))
                                {
                                    tbltenure.Rows.Add(DataUpdation.Tables[0].Rows[i]["survey"].ToString(), DataUpdation.Tables[0].Rows[i]["mut_no"].ToString(), DataUpdation.Tables[0].Rows[i]["appname"].ToString(), DataUpdation.Tables[0].Rows[i]["tenure_name"].ToString(), DataUpdation.Tables[0].Rows[i + 1]["tenure_name"].ToString(), DataUpdation.Tables[0].Rows[i]["timestatus"].ToString(), DataUpdation.Tables[0].Rows[i + 1]["changetime"].ToString());
                                }
                            }
                        }
                    }
                   
                   
                }

            }
            //--------------------------------end DataUpdation------------------------------------------

            #region eMutation
            //--------------------------------eMutation------------------------------------------
            if (eMutation.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < eMutation.Tables[0].Rows.Count; i++)
                {
                    if (i == (eMutation.Tables[0].Rows.Count - 1))
                    {

                    }
                    else
                    {
                        if ((eMutation.Tables[0].Rows[i]["mut_no"].ToString()) == (eMutation.Tables[0].Rows[i + 1]["mut_no"].ToString()))
                        {
                            if ((eMutation.Tables[0].Rows[i]["operation"].ToString().Trim() == "OLD") && (eMutation.Tables[0].Rows[i + 1]["operation"].ToString().Trim() == "NEW"))
                            {
                                if ((eMutation.Tables[0].Rows[i]["tenure_code"].ToString()) != (eMutation.Tables[0].Rows[i + 1]["tenure_code"].ToString()))
                                {
                                    tbltenure.Rows.Add(eMutation.Tables[0].Rows[i]["survey"].ToString(), eMutation.Tables[0].Rows[i]["mut_no"].ToString(), eMutation.Tables[0].Rows[i]["appname"].ToString(), eMutation.Tables[0].Rows[i]["tenure_name"].ToString(), eMutation.Tables[0].Rows[i + 1]["tenure_name"].ToString(), eMutation.Tables[0].Rows[i]["timestatus"].ToString(), eMutation.Tables[0].Rows[i + 1]["changetime"].ToString());
                                }
                            }
                        }
                    }


                }

            }
            //--------------------------------end eMutation------------------------------------------
            #endregion

            #region edit
            ////--------------------------------edit------------------------------------------
            if (edit.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < edit.Tables[0].Rows.Count; i++)
                {
                    if (i == (edit.Tables[0].Rows.Count - 1))
                    {

                    }
                    else
                    {
                        if ((edit.Tables[0].Rows[i]["mut_no"].ToString()) == (edit.Tables[0].Rows[i + 1]["mut_no"].ToString()))
                        {
                            if ((edit.Tables[0].Rows[i]["operation"].ToString().Trim() == "OLD") && (edit.Tables[0].Rows[i + 1]["operation"].ToString().Trim() == "NEW"))
                            {
                                if ((edit.Tables[0].Rows[i]["tenure_code"].ToString()) != (edit.Tables[0].Rows[i + 1]["tenure_code"].ToString()))
                                {
                                    tbltenure.Rows.Add(edit.Tables[0].Rows[i]["survey"].ToString(), edit.Tables[0].Rows[i]["mut_no"].ToString(), edit.Tables[0].Rows[i]["appname"].ToString(), edit.Tables[0].Rows[i]["tenure_name"].ToString(), edit.Tables[0].Rows[i + 1]["tenure_name"].ToString(), edit.Tables[0].Rows[i]["timestatus"].ToString(), edit.Tables[0].Rows[i + 1]["changetime"].ToString());
                                }
                            }
                        }
                    }


                }

            }
            ////--------------------------------end edit------------------------------------------
            #endregion

            #region reEdit
            ////--------------------------------reEdit------------------------------------------
            if (reEdit.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < reEdit.Tables[0].Rows.Count; i++)
                {
                    if (i == (reEdit.Tables[0].Rows.Count - 1))
                    {

                    }
                    else
                    {
                        if ((reEdit.Tables[0].Rows[i]["mut_no"].ToString()) == (reEdit.Tables[0].Rows[i + 1]["mut_no"].ToString()))
                        {
                            if ((reEdit.Tables[0].Rows[i]["operation"].ToString().Trim() == "OLD") && (reEdit.Tables[0].Rows[i + 1]["operation"].ToString().Trim() == "NEW"))
                            {
                                if ((reEdit.Tables[0].Rows[i]["tenure_code"].ToString()) != (reEdit.Tables[0].Rows[i + 1]["tenure_code"].ToString()))
                                {
                                    tbltenure.Rows.Add(reEdit.Tables[0].Rows[i]["survey"].ToString(), reEdit.Tables[0].Rows[i]["mut_no"].ToString(), reEdit.Tables[0].Rows[i]["appname"].ToString(), reEdit.Tables[0].Rows[i]["tenure_name"].ToString(), reEdit.Tables[0].Rows[i + 1]["tenure_name"].ToString(), reEdit.Tables[0].Rows[i]["timestatus"].ToString(), reEdit.Tables[0].Rows[i + 1]["changetime"].ToString());
                                }
                            }
                        }
                    }


                }

            }
            ////--------------------------------end reEdit------------------------------------------
            #endregion
          

            sb.Append("<body>");

            sb.Append("<table border='0' cellpadding='0' cellspacing='0' width='100%' bordercolorlight='#000000' >");
            sb.Append("<thead>");
            sb.Append("<tr>");
            sb.Append("<td width='100%' valign='top' align='center'><font size='5' face='Sakal Marathi  ' color= purple><b>भूधारणा बदलेल्या सर्वे क्रमांकाचा अहवाल  </b></font></td>");
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
            sb.Append("<td width='5%'><font size='3' face='Sakal Marathi  ' > <b>अनु. क्रं.</b></font> </td >");
            sb.Append("<td width='25%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> गट / सर्वे क्रमांक.</b></font></td>");
            sb.Append("<td width='10%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> फेरफार क्रमांक</b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> मूळ भूधारणा</b></font></td>");
            sb.Append("<td width='15%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> बदलेली भूधारणा</b></font></td>");
            sb.Append("<td width='10%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> आज्ञावलीचे नाव  </b></font></td>");
            sb.Append("<td width='20%' align='left'> <font size='3' face='Sakal Marathi  '> &nbsp;<b> बदलेला दिनांक</b></font></td>");
         
            sb.Append("</tr >");

            if (tbltenure.Rows.Count > 0)
            {
                foreach (DataRow drow in tbltenure.Rows)
                {
                    sb.Append("<tr width='100%'  >");
                    sb.Append("<td width='5%' ><font size='3' face='Sakal Marathi  ' >&nbsp;" + i + "</font></td>");

                    sb.Append("<td width='25%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(drow["survey"]) + "");
                    sb.Append("</font></td >");

                    sb.Append("<td width='10%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(drow["mut_no"]) + "");
                    sb.Append("</font></td >");

                    sb.Append("<td width='15%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(drow["oldtenuarename"]) + "");
                    sb.Append("</font></td >");

                    sb.Append("<td width='15%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(drow["newtenuarename"]) + "");
                    sb.Append("</font></td >");

                    sb.Append("<td width='10%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + Convert.ToString(drow["appname"]) + "");
                    sb.Append("</font></td >");

                    sb.Append("<td width='10%'  align='left' > <font size='3' face='Sakal Marathi  ' >");
                    sb.Append("&nbsp;" + drow["newtimestaus"].ToString() + "");
                    sb.Append("</font></td >");
                    i++;
                }
            }
            else
            {
                sb.Append("<tr>");
                sb.Append("<td colspan='7' style='width: 100%;background-color: #ffff33;text-align: center;'><b>माहिती उपलब्ध नाही .");
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
                Session["Error"] = excpt.Getex(ex, "rpttenuredetails.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "rpttenuredetails.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";

            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }



    }
}