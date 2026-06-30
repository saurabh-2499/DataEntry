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

public partial class pgFerfarNoCreation : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction cls = new clsCommonFunction();
    string page_name = "pgFerfarNoCreation";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
                if (Convert.ToUInt32(userExist) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
                }
                Session["page_heading"] = "फेरफार क्रमांक तयार करणे";

               //// string o_mut_set = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census", "last_mut_no_flag", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");
                string o_mut_set = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census", "last_mut_no_flag", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");
                if (o_mut_set != "True")
                {
                    string popupScript = "<script language='javascript'>alert('डाटा एन्ट्री अज्ञावली मध्ये कामाची सुरवात करण्यापुर्वी ई - फेरफार अज्ञावली मधिल शेवटचा फेरफार अद्यावत करने या पर्यायाचा उपयोग करावा.');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
                int max_trans_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new", " edit_trans_no", "ccode='" + Convert.ToString(Session["ccode"]) + "' and report_status='Generated'  and  lock_flag <>'Lock'  and edit_trans_no<>0", "edit_trans_no");

                if (max_trans_cnt != 0)
                {
                    btnFerfarVI.Enabled = true;
                    btnFerfarCreation.Enabled = true;
                    lblVillageDisp.Text = Session["village_name"].ToString();

                    int mutno_chk = 0;
                    int mutregister_mutno_chk = 0;
                    int next_mutNo = 0;
                    //int cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_emptymutno", " count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  mut_no_use = false and mut_no<>0 ", "");
                    //if (cnt > 0)
                    //{
                    //    int mut_no = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_emptymutno", " min(mut_no)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and  mut_no_use = false ", "");
                    //    Session["mut_no"] = next_mutNo.ToString();
                    //    lblNextFerfarNoDisp.Text = next_mutNo.ToString();
                    //    Session["empty_mut_no"] = true;
                    //}
                    //else
                    //{

                    ////22/05/2025
                    ////lblCurrentFerfarNoDisp.Text = con.funReturnSingleValue(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_village_census", "mut_no", "ccode='" + Session["ccode"] + "'", "mut_no");
                    ////next_mutNo = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_village_census", "mut_no + 1 ", "ccode='" + Session["ccode"] + "'", "mut_no");
                    lblCurrentFerfarNoDisp.Text = con.funReturnSingleValue(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_village_census", "mut_no", "ccode='" + Session["ccode"] + "'", "mut_no");
                    next_mutNo = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_village_census", "mut_no + 1 ", "ccode='" + Session["ccode"] + "'", "mut_no");
                    do
                    {
                        mutregister_mutno_chk = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mutregister", "count(mut_no)", "ccode='" + Session["ccode"] + "' and mut_no=" + next_mutNo + " ", "");
                        if (mutregister_mutno_chk > 0)
                        {
                            next_mutNo = next_mutNo + 1;
                        }
                    } while (!(mutregister_mutno_chk == 0));
                    Session["mut_no"] = next_mutNo.ToString();
                    lblNextFerfarNoDisp.Text = next_mutNo.ToString();
                    Session["empty_mut_no"] = string.Empty;
                    //}
                    //update  edit_mut_no=0 in  edit_mut_deal_new  for survey which got  mutation no  in edit_mut_deal_new  but  edit_mut_new is with o(i.e  with default value)
                    cls.funUpdateValue(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_deal_new", "edit_mut_no=0", "ccode ='" + Session["ccode"] + "'  and edit_mut_no<>0 and (pin,pin1,	pin2,	pin3,	pin4,	pin5,	pin6,	pin7,	pin8) in (select pin,pin1,	pin2,	pin3,	pin4,	pin5,	pin6,	pin7,	pin8 from  " + Session["SchemaName"].ToString() + ".edit_mut_new  where ccode ='" + Session["ccode"] + "' and edit_mut_no=0)");
                    
                }
                else
                {
                    btnFerfarVI.Enabled = false;
                    btnFerfarCreation.Enabled = false;
                    string popupScript = "<script language='javascript'>alert('फेरफार क्रमांक तयार करण्यासाठी माहिती उपलब्ध नाही.');</script>";
                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    return;
                }
            }
        }
        catch (Exception ex)
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
    protected void btnFerfarCreation_Click(object sender, EventArgs e)
    {
        try
        {
            //// 22/05/2025
            ////string o_mut_set = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census", "last_mut_no_flag", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");
            string o_mut_set = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census", "last_mut_no_flag", "ccode='" + Convert.ToString(Session["ccode"]) + "'", "");
            if (o_mut_set != "True")
            {
                string popupScript = "<script language='javascript'>alert('डाटा एन्ट्री अज्ञावली मध्ये कामाची सुरवात करण्यापुर्वी ई - फेरफार अज्ञावली मधिल शेवटचा फेरफार अद्यावत करने या पर्यायाचा उपयोग करावा.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;

            }

            int cnt = cls.funReturnSingleValueInteger("rcis_uni.tbl_otp", "count(*)", "ccode='" + Session["ccode"] + "' and notice_genflag=true", "");
            if (cnt > 0)
            {
                string popupScript = "<script language='javascript'>alert('ई-फेरफार आज्ञावली मध्ये नमुद चुकिचे संगणकीकृत आदेशाने फेरफार क्रमांक बदलणे या फेरफारचे काम पुर्ण करा.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }


            string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
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
                            string flag_chk = "";
                            try
                            {
                                flag_chk = con.funReturnstring_forUpdate(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".m_village_census_check", Convert.ToString(Session["ccode"]), ref dbCommand);
                            }
                            catch (Exception ex)
                            {
                                ExceptionHandling excpt = new ExceptionHandling();
                                string popupScript = "<script language='javascript'>alert('" + Convert.ToString(ex) + "');</script>";
                                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

                            }
                            int mutno_chk = 1;
                            if (flag_chk != "" && Convert.ToInt32(flag_chk) == 0)
                            {
                                mutno_chk = 0;
                            }
                            if (mutno_chk == 0)
                            {
                                string dtmutdate = con.ConvertDateToddMMyyyyFormat(System.DateTime.Now.Date.ToString("dd/MM/yyyy"));
                                int max_trans_cnt = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new", " max(edit_trans_no)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and report_status='Generated' and  lock_flag<>'Lock' ", "");
                                string date = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new_audit", " timestatus::date", "ccode='" + Convert.ToString(Session["ccode"]) + "' and report_status='Generated' and edit_trans_no=" + max_trans_cnt + " ", "");
                                string date1 = (Convert.ToDateTime(date)).ToString("dd/MM/yyyy");
                                string tahsildarname = con.funReturnSingleValue("rcis_uni.fpusers1", "marathiname||' - '||servarthid", "district_code='" + Convert.ToString(Session["DistCode"]) + "' and taluka_code='" + Convert.ToString(Session["TalukaCode"]) + "' and desg='TAH' and user_status='L'", "");


                                string deal_VI = "नोंदीचा प्रकार :- दुरुस्ती चा आदेश " + "\n फेरफाराचा दिनांक :- " + System.DateTime.Now.Date.ToString("dd/MM/yyyy") + "\n मा. तहसिलदार : " + tahsildarname + " यांच्या दुरुस्तीच्या आदेश परिशिष्ट क्र." + max_trans_cnt + "   व दिनांक " + date1 + "    रोजी  बाजुला दर्शविलेल्या  सर्व्हे / गट क्रमांकांवर  चुक  दुरुस्तीचा  फेरफार घेण्यास मान्यता प्राप्त झाल्याने फेरफार नोंद घेण्यात येत आहे. संपुर्ण तपशिला साठी परिशिष्ट अ पहावे.";
                                DataSet allpins = con.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_deal_new", " distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "ccode='" + Convert.ToString(Session["ccode"]) + "' and edit_trans_no=" + Convert.ToInt32(Session["village_trans_cnt"]) + " and edit_mut_no='0' and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  )   in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Convert.ToString(Session["SchemaName"]) + ".mut_deal WHERE  ccode='" + Convert.ToString(Session["ccode"]) + "' and  deal_text_old='" + max_trans_cnt + "' and deal_text_old<>'' ) ", "");
                                if (allpins != null && allpins.Tables[0].Rows.Count > 0)
                                {
                                    int tempcount = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mutregister", "count(*)", "mut_no=" + Session["mut_no"].ToString() + " and ccode = '" + Convert.ToString(Session["ccode"]) + "'", "");
                                    if (tempcount > 0)
                                    {
                                        con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mutregister", "mut_date='" + dtmutdate + "', mut_name='दुरुस्ती चा आदेश',mut_type='101',mut_status_code='1',talathi_id='" + Convert.ToString(Session["UserName"]) + "',sdo_remark='" + Convert.ToString(Session["fullname"]).Trim() + "# '", "mut_no=" + Convert.ToString(Session["mut_no"]) + " and ccode = '" + Convert.ToString(Session["ccode"]) + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    }
                                    else
                                    {
                                        con.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mutregister", "ccode,mut_no,mut_date,mut_name,mut_type,mut_status_code,talathi_id,sdo_remark", "'" + Convert.ToString(Session["ccode"]) + "'," + Convert.ToString(Session["mut_no"]) + ",'" + dtmutdate + "','दुरुस्ती चा आदेश','101','1','" + Convert.ToString(Session["UserName"]) + "','" + Convert.ToString(Session["fullname"]).Trim() + "# '", Convert.ToString(Session["UserName"]), ref dbCommand);
                                    }

                                    DataTable dt_pins = ((DataSet)allpins).Tables[0].DefaultView.ToTable(true);
                                    for (int i = 0; i < dt_pins.Rows.Count; i++)
                                    {

                                        con.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_kharedi", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,mut_no,or_code4", "'" + Convert.ToString(Session["ccode"]) + "','" + Convert.ToString(dt_pins.Rows[i]["pin"]) + "', '" + Convert.ToString(dt_pins.Rows[i]["pin1"]) + "','" + Convert.ToString(dt_pins.Rows[i]["pin2"]) + "' ,'" + Convert.ToString(dt_pins.Rows[i]["pin3"]) + "' ,'" + Convert.ToString(dt_pins.Rows[i]["pin4"]) + "' ,'" + Convert.ToString(dt_pins.Rows[i]["pin5"]) + "' ,'" + Convert.ToString(dt_pins.Rows[i]["pin6"]) + "' ,'" + Convert.ToString(dt_pins.Rows[i]["pin7"]) + "','" + Convert.ToString(dt_pins.Rows[i]["pin8"]) + "','" + Convert.ToString(Session["mut_no"]) + "', 1 ", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        int f7m_cnt = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_mut_no", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and pin='" + Convert.ToString(dt_pins.Rows[i]["pin"]) + "' and pin1='" + Convert.ToString(dt_pins.Rows[i]["pin1"]) + "' and  pin2='" + Convert.ToString(dt_pins.Rows[i]["pin2"]) + "' and pin3='" + Convert.ToString(dt_pins.Rows[i]["pin3"]) + "' and pin4='" + Convert.ToString(dt_pins.Rows[i]["pin4"]) + "' and pin5='" + Convert.ToString(dt_pins.Rows[i]["pin5"]) + "' and pin6='" + Convert.ToString(dt_pins.Rows[i]["pin6"]) + "'  and pin7='" + Convert.ToString(dt_pins.Rows[i]["pin7"]) + "' and pin8 ='" + Convert.ToString(dt_pins.Rows[i]["pin8"]) + "' and  mutation_no ='" + Convert.ToString(Session["mut_no"]) + "'", "");
                                        if (f7m_cnt == 0)
                                        {
                                            con.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_mut_no", "ccode,pin, pin1, pin2, pin3, pin4, pin5, pin6,pin7, pin8, mutation_no,mut_no, edit_mut_no,edit_trans_no,edit_appname, edit_flag", "'" + Convert.ToString(Session["ccode"]) + "','" + Convert.ToString(dt_pins.Rows[i]["pin"]) + "', '" + Convert.ToString(dt_pins.Rows[i]["pin1"]) + "','" + Convert.ToString(dt_pins.Rows[i]["pin2"]) + "' ,'" + Convert.ToString(dt_pins.Rows[i]["pin3"]) + "' ,'" + Convert.ToString(dt_pins.Rows[i]["pin4"]) + "' ,'" + Convert.ToString(dt_pins.Rows[i]["pin5"]) + "' ,'" + Convert.ToString(dt_pins.Rows[i]["pin6"]) + "' ,'" + Convert.ToString(dt_pins.Rows[i]["pin7"]) + "','" + Convert.ToString(dt_pins.Rows[i]["pin8"]) + "','" + Convert.ToString(Session["mut_no"]) + "','" + Convert.ToString(Session["mut_no"]) + "','" + Convert.ToString(Session["mut_no"]) + "'," + Convert.ToInt32(Session["village_trans_cnt"]) + ",'reEdit', '61' ", Convert.ToString(Session["UserName"]), ref dbCommand);
                                        }
                                        con.funUpdateValue(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".dcu_form7_orights", "mut_no='" + Session["mut_no"].ToString() + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and pin='" + Convert.ToString(dt_pins.Rows[i]["pin"]) + "' and pin1='" + Convert.ToString(dt_pins.Rows[i]["pin1"]) + "' and  pin2='" + Convert.ToString(dt_pins.Rows[i]["pin2"]) + "' and pin3='" + Convert.ToString(dt_pins.Rows[i]["pin3"]) + "' and pin4='" + Convert.ToString(dt_pins.Rows[i]["pin4"]) + "' and pin5='" + Convert.ToString(dt_pins.Rows[i]["pin5"]) + "' and pin6='" + Convert.ToString(dt_pins.Rows[i]["pin6"]) + "'  and pin7='" + Convert.ToString(dt_pins.Rows[i]["pin7"]) + "' and pin8 ='" + Convert.ToString(dt_pins.Rows[i]["pin8"]) + "'  and other_rights_code='11' and ( other_rights_sub_code='100' or  other_rights_sub_code='101' ) and report_name='reEdit' and mut_no = 0", ref dbCommand);
                                    }

                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".mut_deal", "mut_no='" + Convert.ToInt32(Session["mut_no"]) + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and deal_text_old='" + max_trans_cnt + "' and  mut_no=0", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_deal_new", "edit_mut_no='" + Convert.ToInt32(Session["mut_no"]) + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and edit_trans_no=" + max_trans_cnt + " and  edit_mut_no=0  and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  )   in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Convert.ToString(Session["SchemaName"]) + ".mut_deal WHERE  ccode='" + Convert.ToString(Session["ccode"]) + "'  and deal_text_old<>'')", ref dbCommand, Convert.ToString(Session["UserName"]));

                                   //// con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_village_census", "mut_no='" + Convert.ToInt32(Session["mut_no"]) + "'", "ccode = '" + Convert.ToString(Session["ccode"]) + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                  //// 22/05/2025 

                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_village_census", "mut_no='" + Convert.ToInt32(Session["mut_no"]) + "'", "ccode = '" + Convert.ToString(Session["ccode"]) + "'", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "edit_mut_no='" + Convert.ToInt32(Session["mut_no"]) + "',lock_flag='Lock'", "ccode = '" + Convert.ToString(Session["ccode"]) + "' and edit_trans_no=" + max_trans_cnt + " and confirm_flag<>'Confirm' and report_status='Generated' ", ref dbCommand, Convert.ToString(Session["UserName"]));

                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7", "edit_mut_no='" + Session["mut_no"].ToString() + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and edit_trans_no=" + max_trans_cnt + " and edit_appname='reEdit' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_area", "edit_mut_no='" + Session["mut_no"].ToString() + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and edit_trans_no=" + max_trans_cnt + " and edit_appname='reEdit' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_khata", "edit_mut_no='" + Session["mut_no"].ToString() + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and edit_trans_no=" + max_trans_cnt + "  and edit_appname='reEdit' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_orights", "edit_mut_no='" + Session["mut_no"].ToString() + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and edit_trans_no=" + max_trans_cnt + "  and edit_appname='reEdit' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form7_mut_no", "edit_mut_no='" + Session["mut_no"].ToString() + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and edit_trans_no=" + max_trans_cnt + "  and edit_appname='reEdit' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_holder_detail", "edit_mut_no='" + Session["mut_no"].ToString() + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and edit_trans_no=" + max_trans_cnt + "  and edit_appname='reEdit' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_form8a", "edit_mut_no='" + Session["mut_no"].ToString() + "'", "ccode='" + Convert.ToString(Session["ccode"]) + "'  and edit_trans_no=" + max_trans_cnt + "  and edit_appname='reEdit' ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                    deal_VI = "";
                                    Session["village_trans_cnt"] = max_trans_cnt + 1; // For next survey edit or Confirm
                                    con.setMutationFlag(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]), Convert.ToString(Session["ccode"]), "T", ref dbCommand);
                                    dbTransaction.Commit();
                                    btnFerfarCreation.Enabled = false;
                                    string popupScript = "<script language='javascript'>alert('माहिती साठवली ');</script>";
                                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                    return;
                                }
                            }
                            else
                            {
                                dbTransaction.Rollback();
                                string popupScript = "<script language='javascript'>alert('सदर गावामध्ये अन्य वापरकर्त्याकडून काम सुरू आहे.');</script>";
                                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

                            }
                        }
                        catch (Exception ex)
                        {
                            dbTransaction.Rollback();
                            ExceptionHandling excpt = new ExceptionHandling();
                            if (Session["UserName"] != null)
                                Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
                            else
                                Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        }
                    }
                    connection.Close();
                }
            }
        }
        catch (Exception ex)
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
    
    protected void btnFerfarVI_Click(object sender, EventArgs e)
    {
        Response.Redirect("Report6.aspx", false);
    }
}