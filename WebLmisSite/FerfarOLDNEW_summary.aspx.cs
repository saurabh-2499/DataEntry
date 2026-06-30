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
using System.Collections.Generic;
using Microsoft.Reporting;
using Microsoft.Reporting.WebForms;

public partial class FerfarOLDNEW_summary : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction objclscommonfun = new clsCommonFunction();
    clsCommonFunc objFunC = new clsCommonFunc();
    string page_name = "आदेश व परिशिष्ट ब";
    dsEdit dstext = new dsEdit();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            ShowReport();      
        }
    }
    public void ShowReport()
    {
        try
        {
            //RDLC REPORT CODING
            string ccode = Convert.ToString(Session["VillageDetail"]).Split('#')[0];
            string gaov = Convert.ToString(Session["VillageDetail"]).Split('#')[1];
            string muttype = Convert.ToString(Session["sub_mut_name"]);
          //  string mutno = Convert.ToString(Session["mut_no"]);
            string surveyno = Convert.ToString(Session["pin"]);
            string mutdate = string.Empty;
            string mutno = string.Empty;
            string transnumber = string.Empty; 

            string tahsildarname = string.Empty;
            string circlename=string.Empty;
            string talathiname = string.Empty;
            string adeshNo = string.Empty;
            string adeshDate = string.Empty;

          // mutdate = con.ConvertDateToddMMyyyyFormat(System.DateTime.Now.Date.ToString("dd/MM/yyyy"));
          
           // string date = con.funReturnSingleValue((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_audit", "timestatus :: date", "ccode='" + Convert.ToString(Session["ccode"]) + "' and edit_trans_no= '"+ +"'  ", "edit_trans_no");

          // mutdate = con.ConvertDateToddMMyyyyFormat(System.DateTime.Now.Date.ToString("dd/MM/yyyy"));
          // mutdate = con.funReturnSingleValue((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_audit")
            DataSet dssevarth = objclscommonfun.funReturnDataSet((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_officermast", "trim(username) as username,user_type", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");
            if (dssevarth != null || dssevarth.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dssevarth.Tables[0].Rows)
                {
                    if (Convert.ToString(dr["user_type"]) == "1")
                    {
                        talathiname = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='T' and  servarthid='" + Convert.ToString(dr["username"]) + "' and user_status='L'", "");
                    }
                    else if (Convert.ToString(dr["user_type"]) == "2")
                    {
                        circlename = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='C' and  servarthid='" + Convert.ToString(dr["username"]) + "' and user_status='L'", "");
                    }

                }
            }
            tahsildarname = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='TAH' and user_status='L'", "");

            DataSet ds_old = new DataSet();

            #region[--for ahwal--]
            string flagreport = Convert.ToString(Request.QueryString["report"]);

            if (flagreport == "mutno")
            {
                ds_old = objclscommonfun.funReturnDataSet(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new", "trim(trailing '/' from( pin||'/'||pin1||'/'||pin2||'/'||pin3||'/'||pin4||'/'||pin5||'/'||pin6||'/'||pin7||'/'||pin8)) as surveyno,mut_no, edit_mut_no, edit_trans_no, deal_code_area, deal_text_area_old, deal_text_area_new, deal_code_tenure, deal_text_tenure_old, deal_text_tenure_new, deal_code_owner, deal_text_owner_old, deal_text_owner_new, deal_code_orights_add, deal_text_orights_add_old, deal_text_orights_add_new, deal_code_orights_lesson,deal_text_orights_lesson_old, deal_text_orights_lesson_new, deal_code_kul_add, deal_text_kul_add_old, deal_text_kul_add_new, deal_code_kul_lesson, deal_text_kul_lesson_old, deal_text_kul_lesson_new, deal_code_itarferfar,deal_text_itarferfar_old, deal_text_itarferfar_new,localname_code,deal_text_localname_old,deal_text_localname_new,boundary_code, deal_text_boundary_old,deal_text_boundary_new, deal_text_code, deal_text_old, deal_text_new, report_status,row_number() over (ORDER BY ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )as id", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  edit_mut_no='" + Convert.ToInt32(Session["mut_no"]) + "' and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  )   in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Convert.ToString(Session["SchemaName"]) + ".mut_deal WHERE  ccode='" + Convert.ToString(Session["ccode"]) + "' and  mut_no=" + Convert.ToInt32(Session["mut_no"]) + " and deal_text_old<>'' ) ", "pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ");
                mutno = Convert.ToString(ds_old.Tables[0].Rows[0]["edit_mut_no"]);
                transnumber =Convert.ToString( ds_old.Tables[0].Rows[0]["edit_trans_no"]);
            }
            else if (flagreport == "transno")
            {
                //by tranaction number
                int i = Convert.ToInt32(Session["transno"]);
                ds_old = objclscommonfun.funReturnDataSet(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new", "trim(trailing '/' from( pin||'/'||pin1||'/'||pin2||'/'||pin3||'/'||pin4||'/'||pin5||'/'||pin6||'/'||pin7||'/'||pin8)) as surveyno,mut_no, edit_mut_no, edit_trans_no, deal_code_area, deal_text_area_old, deal_text_area_new, deal_code_tenure, deal_text_tenure_old, deal_text_tenure_new, deal_code_owner, deal_text_owner_old, deal_text_owner_new, deal_code_orights_add, deal_text_orights_add_old, deal_text_orights_add_new, deal_code_orights_lesson,deal_text_orights_lesson_old, deal_text_orights_lesson_new, deal_code_kul_add, deal_text_kul_add_old, deal_text_kul_add_new, deal_code_kul_lesson, deal_text_kul_lesson_old, deal_text_kul_lesson_new, deal_code_itarferfar,deal_text_itarferfar_old, deal_text_itarferfar_new,localname_code,deal_text_localname_old,deal_text_localname_new,boundary_code, deal_text_boundary_old,deal_text_boundary_new, deal_text_code, deal_text_old, deal_text_new, report_status,row_number() over (ORDER BY ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )as id", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  edit_trans_no='" + i + "' and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  )   in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Convert.ToString(Session["SchemaName"]) + ".mut_deal WHERE ccode='" + Convert.ToString(Session["ccode"]) + "' and  deal_text_old='" + i + "' and deal_text_old<>'') ", "pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ");
                if (Convert.ToString(ds_old.Tables[0].Rows[0]["edit_mut_no"]) == "0")
                {
                    mutno = "";
                }
                else
                {
                    mutno = Convert.ToString(ds_old.Tables[0].Rows[0]["edit_mut_no"]);

                }          
                transnumber = Convert.ToString(ds_old.Tables[0].Rows[0]["edit_trans_no"]);
            }
            #endregion
            else
            {
                if (Session["user_type"].ToString() == "C")
                {
                    ds_old = objclscommonfun.funReturnDataSet(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new", "trim(trailing '/' from( pin||'/'||pin1||'/'||pin2||'/'||pin3||'/'||pin4||'/'||pin5||'/'||pin6||'/'||pin7||'/'||pin8)) as surveyno,mut_no, edit_mut_no, edit_trans_no, deal_code_area, deal_text_area_old, deal_text_area_new, deal_code_tenure, deal_text_tenure_old, deal_text_tenure_new, deal_code_owner, deal_text_owner_old, deal_text_owner_new, deal_code_orights_add, deal_text_orights_add_old, deal_text_orights_add_new, deal_code_orights_lesson,deal_text_orights_lesson_old, deal_text_orights_lesson_new, deal_code_kul_add, deal_text_kul_add_old, deal_text_kul_add_new, deal_code_kul_lesson, deal_text_kul_lesson_old, deal_text_kul_lesson_new, deal_code_itarferfar,deal_text_itarferfar_old, deal_text_itarferfar_new,localname_code,deal_text_localname_old,deal_text_localname_new,boundary_code, deal_text_boundary_old,deal_text_boundary_new, deal_text_code, deal_text_old, deal_text_new, report_status,row_number() over (ORDER BY ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )as id", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  edit_mut_no='" + Convert.ToInt32(Session["mut_no"]) + "' and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  )   in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Convert.ToString(Session["SchemaName"]) + ".mut_deal WHERE  ccode='" + Convert.ToString(Session["ccode"]) + "' and  mut_no=" + Convert.ToInt32(Session["mut_no"]) + "  and deal_text_old<>'') ", "pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ");
                    mutno = Convert.ToString(ds_old.Tables[0].Rows[0]["edit_mut_no"]);
                    transnumber = Convert.ToString(ds_old.Tables[0].Rows[0]["edit_trans_no"]);
                }
                else if (Session["user_type"].ToString() == "T")
                {
                    int village_trans_cnt = 0;
                    string max_trans_cnt = objclscommonfun.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new", " max(edit_trans_no)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and report_status='Generated' and lock_flag<>'Lock' and edit_mut_no=0 ", "");
                    if (max_trans_cnt == "")
                    {
                        village_trans_cnt = 1;
                    }
                    else
                    {
                        village_trans_cnt = Convert.ToInt32(max_trans_cnt);
                    }
                    Session["village_trans_cnt"] = village_trans_cnt;


                    ds_old = objclscommonfun.funReturnDataSet(Session["DataBaseName"].ToString(), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new", "trim(trailing '/' from( pin||'/'||pin1||'/'||pin2||'/'||pin3||'/'||pin4||'/'||pin5||'/'||pin6||'/'||pin7||'/'||pin8)) as surveyno,mut_no, edit_mut_no, edit_trans_no, deal_code_area, deal_text_area_old, deal_text_area_new, deal_code_tenure, deal_text_tenure_old, deal_text_tenure_new, deal_code_owner, deal_text_owner_old, deal_text_owner_new, deal_code_orights_add, deal_text_orights_add_old, deal_text_orights_add_new, deal_code_orights_lesson,deal_text_orights_lesson_old, deal_text_orights_lesson_new, deal_code_kul_add, deal_text_kul_add_old, deal_text_kul_add_new, deal_code_kul_lesson, deal_text_kul_lesson_old, deal_text_kul_lesson_new, deal_code_itarferfar,deal_text_itarferfar_old, deal_text_itarferfar_new,localname_code,deal_text_localname_old,deal_text_localname_new,boundary_code, deal_text_boundary_old,deal_text_boundary_new, deal_text_code, deal_text_old, deal_text_new, report_status,row_number() over (ORDER BY ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 )as id", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  edit_trans_no='" + Convert.ToInt32(Session["village_trans_cnt"]) + "'  and edit_mut_no=0 and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  )   in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Convert.ToString(Session["SchemaName"]) + ".mut_deal WHERE ccode='" + Convert.ToString(Session["ccode"]) + "' and  deal_text_old='" + Convert.ToInt32(Session["village_trans_cnt"]) + "' and deal_text_old<>'' ) ", "pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 ");
                    transnumber = Convert.ToString(Session["village_trans_cnt"]);
                    mutno = "";
                }
               
            }
            mutdate = con.funReturnSingleValue((string)Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new_audit", " distinct to_char (max(timestatus :: date),'dd/MM/YYYY') as mut_date", "edit_trans_no='" + transnumber + "' and report_status='Generated' and lock_flag<>'Lock' and edit_mut_no=0 ", "");
            if (ds_old != null && ds_old.Tables.Count > 0 && ds_old.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds_old.Tables[0].Rows)
                {
                    bool flag = false;
                    if (Convert.ToString(dr["deal_code_area"]).Trim() != "")
                    {
                        flag = true;
                        DataRow drtemp = dstext.Tables["dtSummary"].NewRow();
                        drtemp["id"] = dr["id"];
                        drtemp["surveyno"] = dr["surveyno"];
                        drtemp["deal_code_text"] = "क्षेत्र";
                        drtemp["deal_text_original_old"] = dr["deal_text_area_old"].ToString().Replace("\n", "<br>");
                        drtemp["deal_text_original_new"] = dr["deal_text_area_new"].ToString().Replace("\n", "<br>");
                        dstext.Tables["dtSummary"].Rows.Add(drtemp);
                    }
                    if (Convert.ToString(dr["deal_code_tenure"]).Trim() != "")
                    {
                        DataRow drtemp = dstext.Tables["dtSummary"].NewRow();
                        if (flag)
                        {
                            drtemp["id"] = "";
                            drtemp["surveyno"] = "";
                        }
                        else
                        {
                            flag = true;
                            drtemp["id"] = dr["id"];
                            drtemp["surveyno"] = dr["surveyno"];
                        }
                        drtemp["deal_code_text"] = "भुधारणा";
                        drtemp["deal_text_original_old"] = dr["deal_text_tenure_old"].ToString().Replace("\n", "<br>");
                        drtemp["deal_text_original_new"] = dr["deal_text_tenure_new"].ToString().Replace("\n", "<br>");
                        dstext.Tables["dtSummary"].Rows.Add(drtemp);
                    }
                    if (Convert.ToString(dr["deal_code_owner"]).Trim() != "")
                    {
                        DataRow drtemp = dstext.Tables["dtSummary"].NewRow();
                        if (flag)
                        {
                            drtemp["id"] = "";
                            drtemp["surveyno"] = "";
                        }
                        else
                        {
                            flag = true;
                            drtemp["id"] = dr["id"];
                            drtemp["surveyno"] = dr["surveyno"];
                        }
                        drtemp["deal_code_text"] = "भोगवटादाराची माहिती";
                        drtemp["deal_text_original_old"] = dr["deal_text_owner_old"].ToString().Replace("\n", "<br>");
                        drtemp["deal_text_original_new"] = dr["deal_text_owner_new"].ToString().Replace("\n", "<br>");
                        dstext.Tables["dtSummary"].Rows.Add(drtemp);

                    }
                    if (Convert.ToString(dr["deal_code_orights_add"]).Trim() != "")
                    {
                        DataRow drtemp = dstext.Tables["dtSummary"].NewRow();
                        if (flag)
                        {
                            drtemp["id"] = "";
                            drtemp["surveyno"] = "";
                        }
                        else
                        {
                            flag = true;
                            drtemp["id"] = dr["id"];
                            drtemp["surveyno"] = dr["surveyno"];
                        }
                        drtemp["deal_code_text"] = "इतर अधिकार";
                        drtemp["deal_text_original_old"] = dr["deal_text_orights_add_old"].ToString().Replace("\n", "<br>");
                        drtemp["deal_text_original_new"] = dr["deal_text_orights_add_new"].ToString().Replace("\n", "<br>");
                        dstext.Tables["dtSummary"].Rows.Add(drtemp);
                    }
                    if (Convert.ToString(dr["deal_code_orights_lesson"]).Trim() != "")
                    {
                        DataRow drtemp = dstext.Tables["dtSummary"].NewRow();
                        if (flag)
                        {
                            drtemp["id"] = "";
                            drtemp["surveyno"] = "";
                        }
                        else
                        {
                            flag = true;
                            drtemp["id"] = dr["id"];
                            drtemp["surveyno"] = dr["surveyno"];
                        }
                        drtemp["deal_code_text"] = "इतर अधिकार";
                        drtemp["deal_text_original_old"] = dr["deal_text_orights_lesson_old"].ToString().Replace("\n", "<br>");
                        drtemp["deal_text_original_new"] = dr["deal_text_orights_lesson_new"].ToString().Replace("\n", "<br>");
                        dstext.Tables["dtSummary"].Rows.Add(drtemp);

                    }
                    if (Convert.ToString(dr["deal_code_kul_add"]).Trim() != "")
                    {
                        DataRow drtemp = dstext.Tables["dtSummary"].NewRow();
                        if (flag)
                        {
                            drtemp["id"] = "";
                            drtemp["surveyno"] = "";
                        }
                        else
                        {
                            flag = true;
                            drtemp["id"] = dr["id"];
                            drtemp["surveyno"] = dr["surveyno"];
                        }
                        drtemp["deal_code_text"] = "कुळ";
                        drtemp["deal_text_original_old"] = dr["deal_text_kul_add_old"].ToString().Replace("\n", "<br>");
                        drtemp["deal_text_original_new"] = dr["deal_text_kul_add_new"].ToString().Replace("\n", "<br>");
                        dstext.Tables["dtSummary"].Rows.Add(drtemp);
                    }
                    if (Convert.ToString(dr["deal_code_kul_lesson"]).Trim() != "")
                    {
                        DataRow drtemp = dstext.Tables["dtSummary"].NewRow();
                        if (flag)
                        {
                            drtemp["id"] = "";
                            drtemp["surveyno"] = "";
                        }
                        else
                        {
                            flag = true;
                            drtemp["id"] = dr["id"];
                            drtemp["surveyno"] = dr["surveyno"];
                        }
                        drtemp["deal_code_text"] = "कुळ";
                        drtemp["deal_text_original_old"] = dr["deal_text_kul_lesson_old"].ToString().Replace("\n", "<br>");
                        drtemp["deal_text_original_new"] = dr["deal_text_kul_lesson_new"].ToString().Replace("\n", "<br>");
                        dstext.Tables["dtSummary"].Rows.Add(drtemp);
                    }
                    if (Convert.ToString(dr["deal_code_itarferfar"]).Trim() != "")
                    {
                        DataRow drtemp = dstext.Tables["dtSummary"].NewRow();
                        if (flag)
                        {
                            drtemp["id"] = "";
                            drtemp["surveyno"] = "";
                        }
                        else
                        {
                            flag = true;
                            drtemp["id"] = dr["id"];
                            drtemp["surveyno"] = dr["surveyno"];
                        }
                        drtemp["deal_code_text"] = "इतर फेरफार क्रमांक";
                        drtemp["deal_text_original_old"] = dr["deal_text_itarferfar_old"].ToString().Replace("\n", "<br>");
                        drtemp["deal_text_original_new"] = dr["deal_text_itarferfar_new"].ToString().Replace("\n", "<br>");
                        dstext.Tables["dtSummary"].Rows.Add(drtemp);
                    }

                    if (Convert.ToString(dr["localname_code"]).Trim() != "")
                    {
                        DataRow drtemp = dstext.Tables["dtSummary"].NewRow();
                        if (flag)
                        {
                            drtemp["id"] = "";
                            drtemp["surveyno"] = "";
                        }
                        else
                        {
                            flag = true;
                            drtemp["id"] = dr["id"];
                            drtemp["surveyno"] = dr["surveyno"];
                        }
                        drtemp["deal_code_text"] = "शेतीचे स्थानिक नाव";
                        drtemp["deal_text_original_old"] = dr["deal_text_localname_old"].ToString().Replace("\n", "<br>");
                        drtemp["deal_text_original_new"] = dr["deal_text_localname_new"].ToString().Replace("\n", "<br>");
                        dstext.Tables["dtSummary"].Rows.Add(drtemp);
                    }

                    if (Convert.ToString(dr["boundary_code"]).Trim() != "")
                    {
                        DataRow drtemp = dstext.Tables["dtSummary"].NewRow();
                        if (flag)
                        {
                            drtemp["id"] = "";
                            drtemp["surveyno"] = "";
                        }
                        else
                        {
                            flag = true;
                            drtemp["id"] = dr["id"];
                            drtemp["surveyno"] = dr["surveyno"];
                        }
                        drtemp["deal_code_text"] = "सीमा आणि भुमापन चिन्हे";
                        drtemp["deal_text_original_old"] = dr["deal_text_boundary_old"].ToString().Replace("\n", "<br>");
                        drtemp["deal_text_original_new"] = dr["deal_text_boundary_new"].ToString().Replace("\n", "<br>");
                        dstext.Tables["dtSummary"].Rows.Add(drtemp);
                    }


                }
                ReportViewer1.LocalReport.Refresh();
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("ReportSummary.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();

                string pageno = Convert.ToString(ReportViewer1.LocalReport.GetTotalPages());
                List<ReportParameter> reportParams1 = new List<ReportParameter>();

                reportParams1.Add(new ReportParameter("ccode", ccode));
                reportParams1.Add(new ReportParameter("gaov", gaov));
                reportParams1.Add(new ReportParameter("taluka", Convert.ToString(Session["TalukaName"])));
                reportParams1.Add(new ReportParameter("jilha", Convert.ToString(Session["DistrictName"])));
                reportParams1.Add(new ReportParameter("mutno", mutno));
                reportParams1.Add(new ReportParameter("mutdate", mutdate.Split(' ')[0]));
                reportParams1.Add(new ReportParameter("tahsildarname", tahsildarname));
                reportParams1.Add(new ReportParameter("transno", transnumber));
                


                reportParams1.Add(new ReportParameter("circlename", circlename));
                reportParams1.Add(new ReportParameter("talathiname", talathiname));

                reportParams1.Add(new ReportParameter("pageno", pageno));



                ReportViewer1.LocalReport.SetParameters(reportParams1);
                ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsEdit", dstext.Tables["dtSummary"]));

                ReportViewer1.DataBind();
            }
            else
            {
                string popupScript = "<script language='javascript'>alert('\"तहसिलदारांचा दुरुस्त्या मान्येतेचा आदेश व परिशिष्ट ब\" तयार करण्यासाठी माहिती उपलब्ध नाही.\\nयापुर्वी \"तहसिलदारांचा दुरुस्त्या मान्येतेचा आदेश व परिशिष्ट ब\" तयार केले असल्यास, \"डाटा एन्ट्री अहवाल\" या पर्यायातील \"आदेश व परिशिष्ट ब\" या पर्यायाद्वारे ते पहाता येतील याची नोंद घ्यावी.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }

         
           
        }
        catch(Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["UserName"] != null)
                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
            else
                 Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }

    }
  
}