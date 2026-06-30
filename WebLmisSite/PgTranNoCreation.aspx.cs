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

public partial class PgTranNoCreation : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    string page_name = "PgTranNoCreation";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                string userExist = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), "rcis_uni.login_details", "Count(*)", "session_id='" + Convert.ToString(Session["newsession_id"]) + "' and logout_time is null", "");
                if (Convert.ToUInt32(userExist) == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('आपल्या सेवार्थ आयडी ने अन्य ठिकाणी लॉगिन करण्यात आले आहे, तथापि आपणास लॉग आऊट करण्यात येत आहे.');window.location ='pgLogout.aspx';", true);
                }
                Session["page_heading"] = "तहसिलदारांचा दुरुस्त्या मान्येतेचा आदेश व परिशिष्ट ब तयार करणे";
                lblVillageDisp.Text = Session["village_name"].ToString();
                int cntAdeshgen = con.funReturnSingleValueInt(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "count(*)", "ccode = '" + (string)Session["ccode"] + "' and  report_status<>'Generated'  and  confirm_flag <>'Confirm'", "");
                if (cntAdeshgen > 0)
                {

                    int village_trans_cnt = 0;
                    btnTransNoCreation.Enabled = true;
                    //// string max_trans_cnt = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new", " max(edit_trans_no)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and report_status<>'Generated' and lock_flag<>'Lock' and edit_mut_no=0 ", "");
                    string max_trans_cnt = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new", " max(edit_trans_no)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and report_status='Generated' and lock_flag='Lock'", "");
                  
                    int tokan = 1;
                    ////int redit = 0;
                    if (Convert.ToString(max_trans_cnt) != "")
                    {
                         tokan = Convert.ToInt32(max_trans_cnt) + 1;
                    }
                    ////else
                    ////{
                    ////     max_trans_cnt = con.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new", " max(edit_trans_no)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and marked_flag='Edit' and report_status<>'Generated' and lock_flag<>'Lock' and edit_mut_no=0", "");
                    ////     tokan = Convert.ToInt32(max_trans_cnt);
                    ////    redit =1;
                          
                    ////}

                    int entry_present = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new", " count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and edit_trans_no='" + tokan + "' ", "");
                    if (entry_present > 0)
                    {
                        if (max_trans_cnt != "")
                        {

                            ////if (redit == 1)
                            ////{
                            ////    village_trans_cnt = Convert.ToInt32(max_trans_cnt);
                            ////}
                            ////else
                            ////{
                                village_trans_cnt = Convert.ToInt32(max_trans_cnt) + 1;
                            ////}


                            Session["village_trans_cnt"] = village_trans_cnt;
                            lblCurrentTransNoDisp.Text = Convert.ToString(village_trans_cnt);
                        }
                        else
                        {
                            int transNo = con.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new", "max(edit_trans_no)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and marked_flag='Edit' ", "");
                            if (transNo == 1)
                            {
                                village_trans_cnt = Convert.ToInt32(transNo);
                                Session["village_trans_cnt"] = transNo;
                                lblCurrentTransNoDisp.Text = Convert.ToString(village_trans_cnt);
                            }
                            else
                            {
                                btnTransNoCreation.Enabled = false;
                                string popupScript = "<script language='javascript'>alert('\"तहसिलदारांचा दुरुस्त्या मान्येतेचा आदेश व परिशिष्ट ब\" तयार करण्यासाठी माहिती उपलब्ध नाही.\\nयापुर्वी \"तहसिलदारांचा दुरुस्त्या मान्येतेचा आदेश व परिशिष्ट ब\" तयार केले असल्यास, \"डाटा एन्ट्री अहवाल\" या पर्यायातील \"आदेश व परिशिष्ट ब\" या पर्यायाद्वारे ते पहाता येतील याची नोंद घ्यावी.');</script>";
                                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                return;
                            }
                        }
                    }
                    else
                    {
                        btnTransNoCreation.Enabled = false;
                        string popupScript = "<script language='javascript'>alert('\"तहसिलदारांचा दुरुस्त्या मान्येतेचा आदेश व परिशिष्ट ब\" तयार करण्यासाठी माहिती उपलब्ध नाही.\\nयापुर्वी \"तहसिलदारांचा दुरुस्त्या मान्येतेचा आदेश व परिशिष्ट ब\" तयार केले असल्यास, \"डाटा एन्ट्री अहवाल\" या पर्यायातील \"आदेश व परिशिष्ट ब\" या पर्यायाद्वारे ते पहाता येतील याची नोंद घ्यावी.');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        return;
                    }
                }
                else
                {
                    btnTransNoCreation.Enabled = false;
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
    protected void btnTransNoCreation_Click(object sender, EventArgs e)
    {

        try
        {
            if (Request.Form["confirm_value"] != "notOk")
            {
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
                                con.funUpdateEditTables(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".edit_mut_new", "report_status='Generated'", "ccode = '" + (string)Session["ccode"] + "' and  edit_trans_no='" + Convert.ToString(Session["village_trans_cnt"]) + "' and  (pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  )   in ( select pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8  from " + Session["SchemaName"].ToString() + ".mut_deal WHERE ccode='" + (string)Session["ccode"] + "' and  deal_text_old='" + Convert.ToString(Session["village_trans_cnt"]) + "' and deal_text_old<>'')  ", ref dbCommand, Convert.ToString(Session["UserName"]));
                                btnTransNoCreation.Enabled = false;
                                dbTransaction.Commit();
                                ClientScript.RegisterStartupScript(this.GetType(), "आदेश व परिशिष्ट ब", String.Format("<script>window.open('{0}');</script>", "FerfarOLDNEW_summary.aspx"));
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
                    }
                    connection.Close();
                }
            }
            else
            {
                string popupScript = "<script language='javascript'>alert('कृपया, या आदेशातील निवडलेले  सर्व सर्व्हे / गट क्रमांक डाटा एन्ट्री  करावयाचे काम पुर्ण  करुन तहसिलदारांच्या दुरुस्त्या मान्येतेचा अहवाल जनरेट करा..!');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

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
}