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

public partial class pgKhataConfirmation : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction obj = new clsCommonFunction();
    clscommonfunedit objclscommonfunedit = new clscommonfunedit();
    string page_name = "खाता मास्टरची दुरुस्त/अद्यावत केलेली माहिती कायम करणे";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!Page.IsPostBack)
            {
                Session["page_heading"] = "खाता मास्टरची दुरुस्त/अद्यावत केलेली माहिती कायम करणे";
                gdvbind();
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

    public void gdvbind()
    {
        try
        {
            DataTable dtKhata = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "distinct khata_no::int", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no_status = false ", "khata_no::int");
            if (dtKhata.Rows.Count > 0)
            {
                gdvKhataNoConfirmation.DataSource = dtKhata.DefaultView;
                gdvKhataNoConfirmation.DataBind();
            }
            else
            { //खाता मास्टरची दुरुस्त/अद्यावत केलेली माहिती कायम करण्यासाठी माहिती उपलब्ध नाही.'
                gdvKhataNoConfirmation.DataSource = null;
                gdvKhataNoConfirmation.DataBind();
                string popupScript = "<script language='javascript'>alert('माहिती साठवली आहे. );</script>";
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
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            for (int i = 0; i < gdvKhataNoConfirmation.Rows.Count; i++)
            {
                CheckBox chk = (CheckBox)gdvKhataNoConfirmation.Rows[i].FindControl("CheckBox1");
                if (chk.Checked == true)
                {
                    ViewState["rowIndex"] = i;
                    Button btn = (Button)gdvKhataNoConfirmation.Rows[i].FindControl("btnConfirm");
                    btn.Enabled = true;
                    gdvKhataNoConfirmation.Rows[i].Focus();
                    gdvKhataNoConfirmation.SelectedIndex = i;
                    gdvKhataNoConfirmation.SelectedRow.Focus();
                    gdvKhataNoConfirmation.Rows[i].BackColor = System.Drawing.Color.Aqua;

                    Session["khataNo"] = ((Label)gdvKhataNoConfirmation.Rows[i].FindControl("lblkhataNo")).Text;
                }
                else
                {
                    Button btn = (Button)gdvKhataNoConfirmation.Rows[i].FindControl("btnConfirm");
                    btn.Enabled = false;
                    Button btn1 = (Button)gdvKhataNoConfirmation.Rows[i].FindControl("btnRpt");
                    btn1.Enabled = false;
                    if (gdvKhataNoConfirmation.Rows[i].BackColor == System.Drawing.Color.Aqua)
                    {
                        gdvKhataNoConfirmation.Rows[i].BackColor = System.Drawing.Color.Transparent;

                    }
                }
            }
        }
        catch(Exception ex)
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
    protected void btnRpt_Click(object sender, EventArgs e)
    {

        ClientScript.RegisterStartupScript(GetType(), "री-एडीट आज्ञावलीद्वारे खाता मास्टर दुरुस्तीचा माहिती उतारा", String.Format("<script>window.open('{0}');</script>", "rptKhataNoReEdit.aspx"));
    }
    protected void button1_Click(object sender, EventArgs e)
    {

    }
    protected void gdvKhataNoConfirmation_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void gdvKhataNoConfirmation_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void gdvKhataNoConfirmation_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    public void Page_Changed(Object sender, EventArgs e)
    {
        try
        {
            int pageIndex = int.Parse((sender as LinkButton).CommandArgument);
            BindGrid(pageIndex);
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

    private void PopulatePager(int recordCount, int currentPage)
    {
        //double dblPageCount = (double)((decimal)recordCount / decimal.Parse(ddlPageSize.SelectedValue));
        //int pageCount = (int)Math.Ceiling(dblPageCount);
        //List<ListItem> pages = new List<ListItem>();
        //if (pageCount > 0)
        //{
        //    pages.Add(new ListItem("पहिल पेज", "1", currentPage > 1));
        //    for (int i = 1; i <= pageCount; i++)
        //    {
        //        pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
        //    }
        //    pages.Add(new ListItem("शेवटच पेज", pageCount.ToString(), currentPage < pageCount));
        //}
        //rptPager.DataSource = pages;
        //rptPager.DataBind();
    }

    public void BindGrid(int PageIndex)
    {

        try
        {

            // Session["VillageDetail"] = ddlVillage.SelectedValue + '#' + ddlVillage.SelectedItem;
            if (Convert.ToString(Session["mut_no"]) != "" && Convert.ToString(Session["mut_no"]) != "--निवडा--")// ddlMutationNo.SelectedItem.Text.ToString() != "--निवडा--")
            {
                //   int cnt = objclscommonfunedit.FillGridViewCircle((string)ViewState["DatabaseName"], (string)ViewState["SchemaName"], ref gdvKhataNoConfirmation, Session["ccode"].ToString(), Convert.ToInt32(Session["mut_no"]), PageIndex - 1, Convert.ToInt32(ddlPageSize.SelectedValue));
                //   this.PopulatePager(cnt, PageIndex);
                int Certgrid_cnt = objclscommonfunedit.funReturnSingleValueInt((string)ViewState["DatabaseName"], (string)ViewState["SchemaName"] + ".mutregister m," + (string)ViewState["SchemaName"] + ".mut_kharedi k", "distinct count(k.mut_no)", " m.ccode = '" + Session["ccode"].ToString() + "' and m.mut_no='" + Convert.ToString(Session["mut_no"]) + "' and  m.ccode=k.ccode  and or_code4 in (0,1,2) and  m.mut_type='101'  and m.mut_no=k.mut_no and  m.mut_status_code <> 0  and trim(k.pin) <>''  group by m.mut_no", "");


            }

        }
        catch(Exception ex)
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
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        try
        {
            string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
            using (DbConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                DbTransaction dbTransaction;
                using (dbTransaction = connection.BeginTransaction())
                {
                    DbCommand dbCmd4;
                    using (dbCmd4 = connection.CreateCommand())
                    {
                        try
                        {
                            int status = 0;
                            int cnt_edit_f7kp = con.funReturnSingleValueInt((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".edit_form7_khata_kp", " count(*)", " ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khataNo"]) + "' ", "");
                            if (cnt_edit_f7kp > 0)
                            {
                                con.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + "_his.form7_khata_kp", "ccode,pin, pin1, pin2, pin3, pin4, pin5,pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,old_mut_no,khata_type,total_area_h,assessment,anne,pai,potkharaba", " distinct f.ccode,f.pin, f.pin1, f.pin2, f.pin3, f.pin4, f.pin5, f.pin6,f.pin7, f.pin8, f.khata_no,f.fname, f.mname, f.lname,f.topan_name,f.usrno,f.mut_no,f.marked,f.old_mut_no,f.khata_type,f.total_area_h,f.assessment, f.anne,f.pai,f.potkharaba", " f.ccode = '" + (string)Session["ccode"] + "'   and   f.khata_no ='" + Session["khatano"].ToString() + "' ", (string)Session["SchemaName"] + ".form7_khata f ", ref dbCmd4);
                                // con.funInserSingleRecord((string)Session["DataBaseName"], (string)Session["SchemaName"] +  "_his.form7_khata_kp","*",)
                                objclscommonfunedit.funDeleteRecordSevarthID((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".form7_khata", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khataNo"]) + "'", Convert.ToString(Session["UserName"]), ref dbCmd4);
                                con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".form7_khata", "ccode,pin, pin1, pin2, pin3, pin4, pin5,pin6,pin7, pin8, khata_no,fname, mname, lname,topan_name,usrno,mut_no,marked,old_mut_no,khata_type,total_area_h,assessment,anne,pai,potkharaba", " distinct f.ccode,f.pin, f.pin1, f.pin2, f.pin3, f.pin4, f.pin5, f.pin6,f.pin7, f.pin8, f.khata_no,f.fname, f.mname, f.lname,f.topan_name,f.usrno,f.mut_no,f.marked,f.old_mut_no,f.khata_type,f.total_area_h,f.assessment, f.anne,f.pai,f.potkharaba", " f.ccode = '" + (string)Session["ccode"] + "'  and f.edit_flag<>'34'  and f.edit_flag<>'40' and   f.khata_no ='" + Session["khatano"].ToString() + "' ", (string)Session["SchemaName"] + ".edit_form7_khata_kp f ", Convert.ToString(Session["UserName"]), ref dbCmd4);
                            }

                            int cnt_edit_hdkp = con.funReturnSingleValueInt((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".edit_holder_detail_kp", " count(*)", " ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khataNo"]) + "' ", "");
                            if (cnt_edit_hdkp > 0)
                            {
                                con.funPopulateValue((string)Session["SchemaName"], (string)Session["SchemaName"] + "_his.holder_detail_kp", "ccode,khata_no,usrno,fname, mname, lname,topan_name,khata_type, marked, old_mut_no", " distinct ccode,khata_no,usrno,fname, mname, lname,topan_name,khata_type, marked, old_mut_no", " ccode = '" + (string)Session["ccode"] + "'   and   khata_no ='" + Session["khatano"].ToString() + "' ", (string)Session["SchemaName"] + ".holder_detail ", ref dbCmd4);
                                objclscommonfunedit.funDeleteRecordSevarthID((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".holder_detail", "ccode = '" + (string)Session["ccode"] + "' and khata_no='" + Convert.ToString(Session["khataNo"]) + "'", Convert.ToString(Session["UserName"]), ref dbCmd4);
                                con.funPopulateValueSevarth((string)Session["SchemaName"], (string)Session["SchemaName"] + ".holder_detail", "ccode,khata_no,usrno,fname, mname, lname,topan_name,khata_type, marked, old_mut_no", " distinct ccode,khata_no,usrno,fname, mname, lname,topan_name,khata_type, marked, old_mut_no", " ccode = '" + (string)Session["ccode"] + "'  and edit_flag<>'34' and edit_flag<>'40' and   khata_no ='" + Session["khatano"].ToString() + "' ", (string)Session["SchemaName"] + ".edit_holder_detail_kp ", Convert.ToString(Session["UserName"]), ref dbCmd4);
                                // con.funInserSingleValueSevarthID((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".holder_detail", "ccode,khata_no,usrno,fname, mname, lname,topan_name,khata_type, marked, old_mut_no", "'" + (string)Session["ccode"] + "','" + dsedithd.Tables[0].Rows[i]["khata_no"].ToString().Trim() + "','" + dsedithd.Tables[0].Rows[i]["usrno"].ToString() + "','" + dsedithd.Tables[0].Rows[i]["fname"].ToString().Trim() + "','" + dsedithd.Tables[0].Rows[i]["mname"].ToString().Trim() + "','" + dsedithd.Tables[0].Rows[i]["lname"].ToString().Trim() + "','" + dsedithd.Tables[0].Rows[i]["topan_name"].ToString().Trim() + "'," + dsedithd.Tables[0].Rows[i]["khata_type"].ToString() + ",'" + dsedithd.Tables[0].Rows[i]["marked"].ToString().Trim() + "','" + dsedithd.Tables[0].Rows[i]["old_mut_no"].ToString() + "'", Convert.ToString(Session["UserName"]), ref dbCmd4);
                                status = 1;
                            }
                            if (status == 1)
                            {

                                DataSet dssurvey = con.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7_khata", "distinct pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "khata_no ='" + Session["khatano"].ToString() + "' AND  ccode = '" + Convert.ToString(Session["ccode"]) + "'", "");
                                if (dssurvey != null && dssurvey.Tables.Count > 0 && dssurvey.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < dssurvey.Tables[0].Rows.Count; i++)
                                    {

                                        con.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".ror_bulk_sign_data", "census_code = '" + Convert.ToString(Session["ccode"]) + "'  and pin='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin"]) + "' and pin1='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin1"]) + "' and  pin2='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin2"]) + "' and pin3='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin3"]) + "' and pin4='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin4"]) + "' and pin5='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin5"]) + "' and pin6='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin6"]) + "'  and pin7='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin7"]) + "' and pin8 ='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin8"]) + "'", ref dbCmd4);
                                        con.funDeleteRecord(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".ror_sign_tables", "ccode = '" + Convert.ToString(Session["ccode"]) + "'  and pin='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin"]) + "' and pin1='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin1"]) + "' and  pin2='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin2"]) + "' and pin3='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin3"]) + "' and pin4='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin4"]) + "' and pin5='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin5"]) + "' and pin6='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin6"]) + "'  and pin7='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin7"]) + "' and pin8 ='" + Convert.ToString(dssurvey.Tables[0].Rows[i]["pin8"]) + "'", ref dbCmd4);
                                    }
                                }
                                con.funUpdateValue(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", " khata_no_status = true", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no='" + Convert.ToString(Session["khataNo"]) + "'", ref dbCmd4);
                                dbTransaction.Commit();
                                gdvbind();
                                string popupScript = "<script language='javascript'>alert('माहिती  साठवली.');</script>";
                                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                                return;
                            }

                        }
                        catch (Exception ex)
                        {


                            dbTransaction.Rollback();
                            string popupScript = "alert(' " + ex.Message + " ');";

                            return;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            
            string popupScript = "alert('" + ex.Message + " ');";
            return;
        }
    }

    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        try
        {

            int rno = 0;
            int r1 = 0;
            int rowcount = gdvKhataNoConfirmation.Rows.Count;
            while (rowcount > 0)
            {
                CheckBox chk = (CheckBox)gdvKhataNoConfirmation.Rows[rno].FindControl("CheckBox1");

                Button bt = gdvKhataNoConfirmation.Rows[rno].FindControl("btnConfirm") as Button;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(bt);


                if (chk.Checked == true)
                {
                    gdvKhataNoConfirmation.Rows[rno].Focus();
                    gdvKhataNoConfirmation.Rows[rno].BackColor = System.Drawing.Color.Aqua;
                    gdvKhataNoConfirmation.Rows[rno].Enabled = true;
                    gdvKhataNoConfirmation.SelectedIndex = rno;

                }
                else
                {
                    if (gdvKhataNoConfirmation.SelectedIndex == rno)
                    {
                        gdvKhataNoConfirmation.SelectedIndex = -1;
                    }
                }

                rno++;
                rowcount--;
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
    protected void btnKPWorkCompletion_Click(object sender, EventArgs e)
    {


        Response.Redirect("villageskhataWorkDecalaration.aspx", false);
        
        
        
        //if (Request.Form["confirm_value"] != "notOk")
        //{
        //    string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
        //    using (DbConnection connection = new NpgsqlConnection(_connectionString))
        //    {
        //        connection.Open();
        //        DbTransaction dbTransaction;
        //        using (dbTransaction = connection.BeginTransaction())
        //        {
        //            DbCommand dbCommand;
        //            using (dbCommand = connection.CreateCommand())
        //            {
        //                dbCommand.Transaction = dbTransaction;
        //                dbCommand.CommandType = CommandType.Text;
        //                try
        //                {
        //                    DataTable dt_khata_no = obj.funReturnDataTable(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "distinct khata_no::int,khata_master_declair_date", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no_status =false  ", " khata_no::int");
        //                    if (dt_khata_no.Rows.Count == 0)
        //                    {
        //                       // string date = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
        //                     //   DateTime date1 = System.DateTime.Today.Date;

        //                        int date_cnt = obj.funReturnSingleValueInt(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "count(*)", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no_status =true and khata_master_declair_date  isnull  ", "");
        //                        if (date_cnt != 0)
        //                        {
        //                            con.funUpdateValue(Convert.ToString(Session["DataBaseName"]), Session["SchemaName"].ToString() + ".edit_holder_detail_kp ", "khata_master_declaration=true , khata_master_declair_date='now()' ", "ccode='" + Convert.ToString(Session["ccode"]) + "' and khata_no_status = true", ref dbCommand);
        //                            dbTransaction.Commit();
        //                            string popupScript = "<script language='javascript'>alert('संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे ही माहिती साठवली.' );</script>";
        //                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        //                            return;
        //                        }
        //                        else
        //                        {
        //                            string popupScript = "<script language='javascript'>alert('संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे ही माहिती  या पुर्वीच साठवली आहे याची नोंद घ्यावी.' );</script>";
        //                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        //                            return;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        string khata_no_list = String.Empty;
        //                        for (int i = 0; i < dt_khata_no.Rows.Count; i++)
        //                        {
        //                            khata_no_list = dt_khata_no.Rows[i]["khata_no"].ToString() + " ,";
        //                        }
        //                        khata_no_list = khata_no_list.ToString().Trim(',');
        //                        string popupScript = "<script language='javascript'>alert('" + khata_no_list + " या खाता क्रमाकांची, खाता मास्टरची दुरुस्त/अद्यावत केलेली माहिती कायम करावयाचे राहिले आहे.\\nत्यामुळे संपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्वाही देण्यासाठी प्रथम सदर खाता क्रमाकांची खाता मास्टरची दुरुस्त/अद्यावत केलेली माहिती कायम करणे आवश्यक आहे याची नोंद घ्यावी.' );</script>";
        //                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        //                        return;

        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    dbTransaction.Rollback();
        //                    ExceptionHandling excpt = new ExceptionHandling();
        //                    if (Session["UserName"] != null)
        //                        Session["Error"] = Session["Error"] = excpt.Getex(ex, page_name, Convert.ToString(Session["UserName"]), Convert.ToString(Session["DataBaseName"]));
        //                    else
        //                        Session["Error"] = excpt.Getex(ex, page_name, "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
        //                    string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
        //                    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        //                }
        //            }
        //        }
        //    }
        //}
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("pgKhataProcess.aspx", false);
    }
}
