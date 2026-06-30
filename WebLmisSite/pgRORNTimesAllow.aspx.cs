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
using Npgsql;


public partial class pgRORNTimesAllow : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                Session["page_heading"] = "तयार केलेले सर्व्हे/गट क्रमांक दुरुस्ती करण्यासाठी दुबार उपलब्ध करणे";
                //objclsCommFun.funSetDropDownList(Convert.ToString(Session["DatabaseName"]), ref ddlVillage, Convert.ToString(Session["SchemaName"]) + ".m_village_census as v," + Convert.ToString(Session["SchemaName"]) + ".m_officermast as o", "distinct v.ccode,v.village_name", "v.ccode=o.ccode and o.username='" + userName + "'", "village_name");
                string str = ConfigurationManager.ConnectionStrings["Linkage Connection String1"].ConnectionString;
                ViewState["Parent_DatabaseName"] = str.Split('=')[2].Split(';')[0];
                Session["DatabaseName"] = Session["DataBaseName"].ToString();
                Session["SchemaName"] = Session["SchemaName"].ToString();
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
        

    }
    protected void btnSearchSurveyNo_Click(object sender, EventArgs e)
    {
        lblMsg.Visible = false;
        lblMsg.Text = "";
        Session["date_12_view"] = "";
        try
        {
            gdvSurveySearch.Focus();
            txtsurvey.Text = txtsurvey.Text;
            if (txtsurvey.Text != "")
            {
                bindsurve();
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }

    }
    protected void btnShow712New_Click(object sender, EventArgs e)
    {
        if (Convert.ToString(LblSurveyNO.Text) != string.Empty)
        {
            string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
            //  string _connectionString = ((string)Session["DataBaseName"]).Split('#')[0] + "database = " + ((string)Session["DataBaseName"]).Split('#')[1] + ";" + (string)System.Configuration.ConfigurationManager.ConnectionStrings["LRSRO Connection StringMutation"].ConnectionString.ToString();

            try
            {
               
                
                        using (DbConnection connection = new NpgsqlConnection(_connectionString))
                        {
                            connection.Open();
                            DbTransaction dbTransaction;
                            using (dbTransaction = connection.BeginTransaction())
                            {
                                DbCommand dbCommand;
                                using (dbCommand = connection.CreateCommand())
                                {
                                    dbCommand.Transaction = dbTransaction;
                                    dbCommand.CommandType = CommandType.Text;
                                    try
                                    {
                                        int f7cnt = objedit.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7_area", "Count(*)" ,"ccode = '" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'","");

                                        if (f7cnt == 0)
                                        {
                                            string popupScript1 = "<script language='javascript'>alert('सदर सर्व्हे/ गट क्रमांकाचा ७/१२ तयार केलेला नाही याची नोंद घ्यावी. .');</script>";
                                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript1);
                                            return;
                                        }
                                        else
                                        {
                                            objedit.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_mut_new_multi", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, survey, edit_mut_no, edit_trans_no, edit_appname,confirm_flag, marked_flag, lock_flag, approve_flag, report_status,correction_deal", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, survey, edit_mut_no, edit_trans_no, edit_appname,confirm_flag, marked_flag, lock_flag, approve_flag, report_status,correction_deal", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "' ", (string)Session["SchemaName"] + ".edit_mut_new", ref dbCommand);
                                            objedit.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_mut_deal_new_multi", "ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, mut_no,edit_mut_no, edit_trans_no, deal_code_area, deal_text_area_old,deal_text_area_new, deal_code_tenure, deal_text_tenure_old, deal_text_tenure_new,deal_code_owner, deal_text_owner_old, deal_text_owner_new, deal_code_orights_add,deal_text_orights_add_old, deal_text_orights_add_new, deal_code_orights_lesson,deal_text_orights_lesson_old, deal_text_orights_lesson_new, deal_code_kul_add,deal_text_kul_add_old, deal_text_kul_add_new, deal_code_kul_lesson,deal_text_kul_lesson_old, deal_text_kul_lesson_new, deal_code_itarferfar,deal_text_itarferfar_old, deal_text_itarferfar_new, deal_text_code,deal_text_old, deal_text_new, report_status, areaunit_code, deal_text_areaunit_old,deal_text_areaunit_new, localname_code, deal_text_localname_old,deal_text_localname_new, boundary_code, deal_text_boundary_old,deal_text_boundary_new", "ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, mut_no,edit_mut_no, edit_trans_no, deal_code_area, deal_text_area_old,deal_text_area_new, deal_code_tenure, deal_text_tenure_old, deal_text_tenure_new,deal_code_owner, deal_text_owner_old, deal_text_owner_new, deal_code_orights_add,deal_text_orights_add_old, deal_text_orights_add_new, deal_code_orights_lesson,deal_text_orights_lesson_old, deal_text_orights_lesson_new, deal_code_kul_add,deal_text_kul_add_old, deal_text_kul_add_new, deal_code_kul_lesson,deal_text_kul_lesson_old, deal_text_kul_lesson_new, deal_code_itarferfar,deal_text_itarferfar_old, deal_text_itarferfar_new, deal_text_code,deal_text_old, deal_text_new, report_status, areaunit_code, deal_text_areaunit_old,deal_text_areaunit_new, localname_code, deal_text_localname_old,deal_text_localname_new, boundary_code, deal_text_boundary_old,deal_text_boundary_new", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "' ", (string)Session["SchemaName"] + ".edit_mut_deal_new", ref dbCommand);

                                            objedit.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_multi", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no, tenure_code, tenure_sub_code, tenure_sub_code1,land_usage_code, land_usage_sub_code, land_usage_text, local_name,boundry_id, khand_no, khand_date, land_usage_mut_no, username, marked, old_mut_no, mut_no, edit_mut_no, edit_trans_no, edit_appname,edit_flag, edit_status", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no, tenure_code, tenure_sub_code, tenure_sub_code1,land_usage_code, land_usage_sub_code, land_usage_text, local_name,boundry_id, khand_no, khand_date, land_usage_mut_no, username, marked, old_mut_no, mut_no, edit_mut_no, edit_trans_no, edit_appname,edit_flag, edit_status", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "' ", (string)Session["SchemaName"] + ".edit_form7", ref dbCommand);
                                            objedit.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_area_multi", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, jirayat_area_h, jirayat_area_r, jirayat_area_sqm, bagayat_area_h, bagayat_area_r, bagayat_area_sqm, tari_area_h,tari_area_r, tari_area_sqm, varkas_area_h, varkas_area_r, varkas_area_sqm,itar_area_h, itar_area_r, itar_area_sqm, total_area_h, total_area_r,total_area_sqm, net_culti_area_h, assessment, judi, potkharaba_a_h,potkharaba_a_r, potkharaba_a_sqm, potkharaba_b_h, potkharaba_b_r,potkharaba_b_sqm, total_potkharaba_h, total_potkharaba_r, total_potkharaba_sqm,na_area_h, na_assessment, na_mut_no, marked, old_mut_no, mut_no,edit_mut_no, edit_trans_no, edit_appname, edit_flag, edit_status", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, jirayat_area_h, jirayat_area_r, jirayat_area_sqm, bagayat_area_h, bagayat_area_r, bagayat_area_sqm, tari_area_h,tari_area_r, tari_area_sqm, varkas_area_h, varkas_area_r, varkas_area_sqm,itar_area_h, itar_area_r, itar_area_sqm, total_area_h, total_area_r,total_area_sqm, net_culti_area_h, assessment, judi, potkharaba_a_h,potkharaba_a_r, potkharaba_a_sqm, potkharaba_b_h, potkharaba_b_r,potkharaba_b_sqm, total_potkharaba_h, total_potkharaba_r, total_potkharaba_sqm,na_area_h, na_assessment, na_mut_no, marked, old_mut_no, mut_no,edit_mut_no, edit_trans_no, edit_appname, edit_flag, edit_status", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "' ", (string)Session["SchemaName"] + ".edit_form7_area", ref dbCommand);

                                            objedit.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_holder_detail_multi", "ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, numeric_pin,usrno, name_of_holder, fname, mname, lname, category_code, caste_code,caste_sub_code, khata_no, khata_type, gender, caste, epic_code,resident_non, major_minor, literate_non, dateofbirth, closed_khata,topan_name, marked, old_mut_no, edit_mut_no, edit_trans_no, edit_appname,edit_flag, edit_status", "ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, numeric_pin,usrno, name_of_holder, fname, mname, lname, category_code, caste_code,caste_sub_code, khata_no, khata_type, gender, caste, epic_code,resident_non, major_minor, literate_non, dateofbirth, closed_khata,topan_name, marked, old_mut_no, edit_mut_no, edit_trans_no, edit_appname,edit_flag, edit_status", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no in ( select distinct khata_no from  " + Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata where ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "')", (string)Session["SchemaName"] + ".edit_holder_detail", ref dbCommand);

                                            //objedit.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_khata_multi", "ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, numeric_pin,usrno, name_of_holder, fname, mname, lname, category_code, caste_code,caste_sub_code, khata_no, khata_type, gender, caste, epic_code,resident_non, major_minor, literate_non, dateofbirth, closed_khata,topan_name, marked, old_mut_no, edit_mut_no, edit_trans_no, edit_appname,edit_flag, edit_status", "ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, numeric_pin,usrno, name_of_holder, fname, mname, lname, category_code, caste_code,caste_sub_code, khata_no, khata_type, gender, caste, epic_code,resident_non, major_minor, literate_non, dateofbirth, closed_khata,topan_name, marked, old_mut_no, edit_mut_no, edit_trans_no, edit_appname,edit_flag, edit_status", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "' ", (string)Session["SchemaName"] + ".edit_form7_khata", ref dbCommand);
                                            objedit.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_khata_multi", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no, fname, mname, lname, usrno, total_area_h,assessment, anne, pai, mut_no, topan_name, marked, old_mut_no,nave_area, nave_assessment, nave_anne, nave_pai, khata_type,potkharaba, edit_mut_no, edit_trans_no, edit_appname, edit_flag,edit_status", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, khata_no, fname, mname, lname, usrno, total_area_h,assessment, anne, pai, mut_no, topan_name, marked, old_mut_no,nave_area, nave_assessment, nave_anne, nave_pai, khata_type,potkharaba, edit_mut_no, edit_trans_no, edit_appname, edit_flag,edit_status", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "' ", (string)Session["SchemaName"] + ".edit_form7_khata", ref dbCommand);
                                            objedit.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_orights_multi", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, other_rights_code, other_rights_sub_code, other_rights_text,khata_no, tenant_name, total_area_h, rent, mut_no, usrno, assessment,marked, old_mut_no, edit_mut_no, edit_trans_no, edit_appname,edit_flag, edit_status", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, other_rights_code, other_rights_sub_code, other_rights_text,khata_no, tenant_name, total_area_h, rent, mut_no, usrno, assessment,marked, old_mut_no, edit_mut_no, edit_trans_no, edit_appname,edit_flag, edit_status", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "' ", (string)Session["SchemaName"] + ".edit_form7_orights", ref dbCommand);
                                            objedit.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + ".edit_form7_mut_no_multi", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, mutation_no, marked, old_mut_no, mut_no, edit_mut_no,edit_trans_no, edit_appname, edit_flag, edit_status", "ccode, numeric_pin, pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, mutation_no, marked, old_mut_no, mut_no, edit_mut_no,edit_trans_no, edit_appname, edit_flag, edit_status", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "' ", (string)Session["SchemaName"] + ".edit_form7_mut_no", ref dbCommand);


                                           





                                            //-- edit related regular and mutation tables 
                                            objedit.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                            objedit.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_deal_new", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                            objedit.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                            objedit.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_area", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                            objedit.funDeleteRecordSevarthID(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no in ( select distinct khata_no from  " + Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata where ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "' )", Convert.ToString(Session["UserName"]), ref dbCommand);
                                            objedit.funDeleteRecordSevarthID(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Convert.ToString(Session["pin"]) + "' and  pin1 ='" + Convert.ToString(Session["pin1"]) + "' and  pin2 ='" + Convert.ToString(Session["pin2"]) + "' and  pin3 ='" + Convert.ToString(Session["pin3"]) + "'  and  pin4 ='" + Convert.ToString(Session["pin4"]) + "'  and  pin5 ='" + Convert.ToString(Session["pin5"]) + "'  and  pin6 ='" + Convert.ToString(Session["pin6"]) + "'  and  pin7 ='" + Convert.ToString(Session["pin7"]) + "'  and  pin8 ='" + Convert.ToString(Session["pin8"]) + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                            objedit.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_orights", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);
                                            objedit.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_mut_no", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", Convert.ToString(Session["UserName"]), ref dbCommand);













                                            ////  objedit.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_kharedi", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Session["SchemaName"].ToString() + ".mut_kharedi_audit where  ccode='" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "' and app_name ='reEdit'  and  app_name <>'eMutation' and  app_name <>'DataUpdation' )", Convert.ToString(Session["UserName"]), ref dbCommand);
                                            ////   objedit.funDeleteRecordSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_deal", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "' and (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8)  in (select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8 from " + Session["SchemaName"].ToString() + ".mut_deal_audit where  ccode='" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "' and app_name ='reEdit'  and  app_name <>'eMutation' and  app_name <>'DataUpdation')", Convert.ToString(Session["UserName"]), ref dbCommand);

                                            //--  audit tables of edit related regular and mutation tables 

                                            /*
                                            objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", ref dbCommand);
                                            objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_deal_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", ref dbCommand);

                                            objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", ref dbCommand);
                                            objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_area_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", ref dbCommand);
                                            objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", ref dbCommand);
                                            objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_orights_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", ref dbCommand);
                                            objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_mut_no_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", ref dbCommand);
                                           */

                                            ////   objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_kharedi_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "' and  app_name ='reEdit' and  app_name <>'eMutation' and  app_name <>'DataUpdation' ", ref dbCommand);
                                            ////  objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_deal_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "' and   app_name ='reEdit' and  app_name <>'eMutation' and  app_name <>'DataUpdation'", ref dbCommand);


                                            ////int edit_mut_no = objedit.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "edit_mut_no", "ccode='" + Convert.ToString(Session["ccode"]) + "' and pin ='" + Session["pin"] + "' and pin1 ='" + Session["pin1"] + "' and pin2 ='" + Session["pin2"] + "' and pin3 ='" + Session["pin3"] + "' and pin4 ='" + Session["pin4"] + "' and pin5 ='" + Session["pin5"] + "' and pin6 ='" + Session["pin6"] + "' and pin7 ='" + Session["pin7"] + "' and pin8 ='" + Session["pin8"] + "'", "");
                                            ////int edit_mut_no_cnt = objedit.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "count(edit_mut_no)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and edit_mut_no='" + edit_mut_no + "'", "");
                                            ////if (edit_mut_no_cnt == 1)
                                            ////{
                                            ////    objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mutregister", "ccode = '" + Convert.ToString(Session["ccode"]) + "'  and mut_no='" + edit_mut_no + "' and  mut_type ='101' ", ref dbCommand);
                                            ////    objedit.funDeleteRecord(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mutregister_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "'  and mut_no='" + edit_mut_no + "' and  app_name ='reEdit' and  app_name <>'eMutation' and  app_name <>'DataUpdation' ", ref dbCommand);
                                            ////}
                                            dbTransaction.Commit();


                                            string popupScript2 = "<script language='javascript'>alert('माहिती साठवली');</script>";
                                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
                                        }
                                       
                                    }
                                    catch (Exception ex)
                                    {
                                        ExceptionHandling excpt = new ExceptionHandling();
                                        if (Session["LoginID"] != null)
                                            Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
                                        else
                                            Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                                        string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                    }
                                }
                            }
                            connection.Close();
                        }

                     
                
               
               


            }
            catch (Exception ex)
            {
                ExceptionHandling excpt = new ExceptionHandling();
                if (Session["LoginID"] != null)
                    Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
                else
                    Session["Error"] = excpt.Getex(ex, "pgD1RevertRequestByTalathi.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            }
        }
        else
        {
          //  btnSave.Enabled = false;
            string popupScript = "<script language='javascript'>alert('दुरुस्तीसाठी निवडलेले परंतु दुरुस्त्या न केलेले सर्व्हे क्रमांक / गट क्रमांक नविन ७/१२ तयार करण्यासाठी उपलब्ध करण्यासाठी माहिती उपलब्ध नाही.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
            return;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void gdvSurveySearch_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Session["pin"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn")).Text;
        Session["pin1"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn1")).Text;
        Session["pin2"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn2")).Text;
        Session["pin3"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn3")).Text;
        Session["pin4"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn4")).Text;
        Session["pin5"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn5")).Text;
        Session["pin6"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn6")).Text;
        Session["pin7"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn7")).Text;
        Session["pin8"] = ((Label)gdvSurveySearch.Rows[e.NewSelectedIndex].FindControl("lblColumn8")).Text;

        txtsurvey.Text = (string)Session["pin"];

        string survey = Session["pin"] + "/" + Session["pin1"] + "/" + Session["pin2"] + "/" + Session["pin3"] + "/" + Session["pin4"] + "/" + Session["pin5"] + "/" + Session["pin6"] + "/" + Session["pin7"] + "/" + Session["pin8"];
        survey = survey.Trim('/');
        LblSurveyNO.Text = survey;
        gdvSurveySearch.DataSource = null;
        gdvSurveySearch.DataBind();

    }


    public void bindsurve()
    {
        DataSet ds1 = new DataSet();
        ds1 = objedit.funSetGridList((string)Session["DatabaseName"], ref gdvSurveySearch, (string)Session["SchemaName"] + ".form7", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode ='" + Convert.ToString(Session["ccode"]) + "' and  pin ='" + txtsurvey.Text + "'", "");
    }



}