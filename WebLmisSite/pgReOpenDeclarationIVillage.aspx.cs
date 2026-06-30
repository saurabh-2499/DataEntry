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

public partial class pgReOpenDeclarationIVillage : System.Web.UI.Page
{
    clscommonfunedit objedit = new clscommonfunedit();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //if (Convert.ToString(Session["ccode"]) == "")
                //{
                //    if (Session["user_type"].ToString() == "T")
                //        Response.Redirect("pgSelectVillage.aspx");
                //    else if (Session["user_type"].ToString() == "DBA")
                //        Response.Redirect("pgVillageSelect_DBA.aspx");
                //}
                //else
                //{
                //    Session["ccode"] = Session["ccode"].ToString();
                //}
                Session["page_heading"] = "घोषणापत्र -I( DECLARATION-I ) पूर्ववत(Revert) करणे.";
                this.bindGridData();

            }
            //else
            //{
            //    btnRevertD1.Visible = true;
            //    lblVillagetext.Text = Convert.ToString(Session["VillageDetail"]).Split('#')[1] + @" गावाचे  री - एडिट घोषणापत्र -I( DECLARATION-I ) पूर्ववत(Revert) करणेसाठी  ""पूर्ववत करणे "" बटन वर क्लीक करा.";
            //}

        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }

    }

    void bindGridData()
    {
        try
        {
            DataSet tblnewnames = objedit.funReturnDataSet(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".m_village_census a , " + Session["SchemaName"].ToString() + ".revert_d1status  b ," + Session["SchemaName"].ToString() + ".edit_holder_detail_kp  c", "distinct a.ccode, a.village_name,b.talathi_name , to_char(b.request_date,'dd/MM/yyyy') as request_date   ,    to_char(c.khata_master_declair_date,'dd/MM/yyyy') as d1date ", "a.ccode =b.ccode and a.ccode  =c.ccode    and isd1revert=false and  c.khata_master_declair_date is not null", "village_name");
            if (tblnewnames.Tables[0].Rows.Count > 0)
            {
                ViewState["tblnewnames"] = tblnewnames;
                gvRevertD1.DataSource = tblnewnames;
                gvRevertD1.DataBind();
                gvRevertD1.Visible = true;
            }
            else
            {
                RebindGridData(tblnewnames.Tables[0]);
                gvRevertD1.Visible = true;               
                ViewState["tblnewnames"] = null;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }

    private void RebindGridData(DataTable table3)
    {

        try
        {
            table3.Rows.Add(table3.NewRow());
            gvRevertD1.DataSource = table3;
            ViewState["tbl_mutnoselect"] = table3;
            gvRevertD1.DataBind();
            int TotalColumns1 = gvRevertD1.Rows[0].Cells.Count;
            gvRevertD1.Rows[0].Cells.Clear();
            gvRevertD1.Rows[0].Cells.Add(new TableCell());
            gvRevertD1.Rows[0].Cells[0].ColumnSpan = TotalColumns1;
            gvRevertD1.Rows[0].Cells[0].Text = "माहिती सापडली नाही";//"No Record Found";
            if (table3.Rows.Count == 1) table3.Rows.RemoveAt(0);
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
    public Boolean isReEdit712WorkAprroved(string databasename, string schemaname, string ccode)
    {
        if (objedit.funReturnSingleValue(databasename, schemaname + ".edit_mut_new", "(case when count(*)>0 then false else true end) as Aprroved_status", "ccode='" + ccode + "' and  approve_flag<>'Approve'", "").ToLower() == "true")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected void btnRevertD1_Click(object sender, EventArgs e)
    {
        try
        {
            clscommonfun objcom = new clscommonfun();
            objcom.funExecuteTableScripts(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]));

            string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();
            
            using (DbConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        DbCommand Objdbcmd;
                        using (Objdbcmd = connection.CreateCommand())
                        {
                          
                            //move  the Old Deal  To  edit_mut_deal_new_rejected from edit_mut_deal table and  same is to be refer in VF6.
                            objedit.funInserSingleValue(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new_rejected", "", "select  * from  " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Convert.ToString(Session["ccode"]) + "'", ref Objdbcmd);

                            #region[--Delete  Data  From  edit  tables--])

                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new", "ccode = '" + Convert.ToString(Session["ccode"]) + "' ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "'  ", ref Objdbcmd);

                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new", "ccode = '" + Convert.ToString(Session["ccode"]) + "' ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "'   ", ref Objdbcmd);

                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7", "ccode = '" + Convert.ToString(Session["ccode"]) + "' ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_area", "ccode = '" + Convert.ToString(Session["ccode"]) + "' ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata", "ccode = '" + Convert.ToString(Session["ccode"]) + "' ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_orights", "ccode = '" + Convert.ToString(Session["ccode"]) + "' ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_mut_no", "ccode = '" + Convert.ToString(Session["ccode"]) + "' ", ref Objdbcmd);

                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_area_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "' ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_orights_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "'   ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_mut_no_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "'   ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail", "ccode = '" + Convert.ToString(Session["ccode"]) + "'   ", ref Objdbcmd);
                            objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_audit", "ccode = '" + Convert.ToString(Session["ccode"]) + "'  ", ref Objdbcmd);
                            objedit.funUpdateValueSevarthID(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp", "khata_master_declaration=false,khata_master_declair_date=null", "ccode = '" + Convert.ToString(Session["ccode"]) + "'  ", Convert.ToString(Session["UserName"]), ref Objdbcmd);
                            
                            #endregion
                            //bindservey();


                        }
                        transaction.Commit();
                        btnRevertD1.Visible = false;
                        lblVillagetext.Visible = false;
                        string popupScript = "<script language='javascript'>alert('सदर गावाचे  रि -एडीट अद्न्यावालीद्वारे करण्यात  आलेले   घोषणापत्र -I ( DECLARATION-I ) चे काम पूर्ववत(REVERT) यशस्वीरीत्या  करणेत आले आहे , तथापी  ग्राम महसूल अधिकारी यांना खाता प्रोसेसिंग (Khata Processing) चे काम पुन्हा सुरु  करता येईल याची नोंद  घ्यावी .!!!!' );</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        ExceptionHandling excpt = new ExceptionHandling();
                        if (Session["LoginID"] != null)
                            Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
                        else
                            Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                        string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                        ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
   
    protected void gvRevertD1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            //Label ccode = (Label)gvRevertD1.SelectedRow.FindControl("ccode");
            Label Lblccode = (Label)gvRevertD1.Rows[e.NewSelectedIndex].FindControl("lblccode");
            if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp", "(case when count(*)=0 then true else false end) as isd1Started ", "ccode ='" + Lblccode.Text.ToString() + "' ", "")) == true)
            {

                btnRevertD1.Visible = false;
                string popupScript = "<script language='javascript'>alert('सदर गावाचे  खाता मास्टर चे काम अद्याप सुरु करणेत आलेले नाही  याची नोंद घ्यावी.!!!!!!');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
            if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp", "(case when count(*)>=1 then true else false end) as isd1declaired ", "ccode ='" + Lblccode.Text.ToString() + "' and khata_master_declaration=false", "")) == true)
            {
                btnRevertD1.Visible = false;
                string popupScript = "<script language='javascript'>alert('सदर गावाचे  खाता मास्टर च्या कामाचे घोषणापत्र -I ( DECLARATION-I ) सबंधित ग्राम महसूल अधिकारी यांनी अद्याप  केलेले नाही याची नोंद घ्यावी.!!!!!!');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
            if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_status as a ," + Convert.ToString(Session["SchemaName"]) + ".tbl_ewc_officerdetails as b, " + Convert.ToString(Session["SchemaName"]) + ".m_ewc_checks as c", "(case when count(a.*)>11 then true else false end) as d2status", "a.ccode ='" + Lblccode.Text.ToString() + "' and  a.ccode=b.ccode  and a.status_code=1 and  b.ewc_status=true and  a.wc_code=c.wc_code and  c.check_type='S' ", "")) == true)
            {
                btnRevertD1.Visible = false;
                string popupScript = "<script language='javascript'>alert('सदर गावाचे  घोषणापत्र -II ( DECLARATION-II ) झाले असल्यामुळे  घोषणापत्र -I ( DECLARATION-I ) चे काम पूर्ववत(REVERT) करता येणार नाही याची नोंद घ्यावी.!!!!!!');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }

            if (Convert.ToBoolean(objedit.funReturnSingleValue(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".tblewc_proforma3", "(case when count(*)=1 then true else false end) as d3status ", "ccode ='" + Lblccode.Text.ToString() + "'   and  trim(ah1remark)='होय' and trim(ah2remark)='होय' and  	trim(docremark)='होय' and  	trim(prapatr2remark)='होय' ", "")) == true)
            {
                btnRevertD1.Visible = false;
                string popupScript = "<script language='javascript'>alert('सदर गावाचे  घोषणापत्र -III ( DECLARATION-III ) झाले असल्यामुळे  घोषणापत्र -I ( DECLARATION-I ) चे काम पूर्ववत(REVERT) करता येणार नाही याची नोंद घ्यावी.!!!!!!');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }

            if (this.isReEdit712WorkAprroved(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]), Lblccode.Text.ToString()) == false)
            {
                btnRevertD1.Visible = false;
                string popupScript = "<script language='javascript'>alert('सदर गावात रि -एडीट अद्न्यावालीद्वारे घेणात आलेले फेरफार / परिशिष्ट मंजुरीचे काम पूर्ण करूनच घोषणापत्र -I ( DECLARATION-I ) चे काम पूर्ववत(REVERT) करता येईल याची नोंद घ्यावी .!!!!' );</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                return;
            }
            else
            {
               // clscommonfun objcom = new clscommonfun();
               // objcom.funExecuteTableScripts(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]));

                string _connectionString = (string)System.Configuration.ConfigurationManager.ConnectionStrings["District" + Convert.ToString(Session["DataBaseName"])].ConnectionString.ToString();

                using (DbConnection connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (DbTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            DbCommand Objdbcmd;
                            using (Objdbcmd = connection.CreateCommand())
                            {

                                //move  the Old Deal  To  edit_mut_deal_new_rejected from edit_mut_deal table and  same is to be refer in VF6.
                                objedit.funInserSingleValue(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new_rejected", "", "select  * from  " + Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new  where ccode = '" + Lblccode.Text.ToString() + "'", ref Objdbcmd);

                                #region[--Delete  Data  From  edit  tables--])

                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new", "ccode = '" + Lblccode.Text.ToString() + "' ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_deal_new_audit", "ccode = '" + Lblccode.Text.ToString() + "'  ", ref Objdbcmd);

                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new", "ccode = '" + Lblccode.Text.ToString() + "' ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_mut_new_audit", "ccode = '" + Lblccode.Text.ToString() + "'   ", ref Objdbcmd);

                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7", "ccode = '" + Lblccode.Text.ToString() + "' ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_area", "ccode = '" + Lblccode.Text.ToString() + "' ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata", "ccode = '" + Lblccode.Text.ToString() + "' ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_orights", "ccode = '" + Lblccode.Text.ToString() + "' ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_mut_no", "ccode = '" + Lblccode.Text.ToString() + "' ", ref Objdbcmd);

                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_audit", "ccode = '" + Lblccode.Text.ToString() + "' ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_area_audit", "ccode = '" + Lblccode.Text.ToString() + "' ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_khata_audit", "ccode = '" + Lblccode.Text.ToString() + "' ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_orights_audit", "ccode = '" + Lblccode.Text.ToString() + "'   ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_form7_mut_no_audit", "ccode = '" + Lblccode.Text.ToString() + "'   ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail", "ccode = '" + Lblccode.Text.ToString() + "'   ", ref Objdbcmd);
                                objedit.funDeleteRecord(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_audit", "ccode = '" + Lblccode.Text.ToString() + "'  ", ref Objdbcmd);
                                objedit.funUpdateValueSevarthID(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".edit_holder_detail_kp", "khata_master_declaration=false,khata_master_declair_date=null", "ccode = '" + Lblccode.Text.ToString() + "'  ", Convert.ToString(Session["UserName"]), ref Objdbcmd);
                                objedit.funUpdateValue(Convert.ToString(Session["DatabaseName"]), Convert.ToString(Session["SchemaName"]) + ".revert_d1status", " isd1revert=true,d1revert_date=now(), dba_sevarth='"+ Convert.ToString(Session["UserName"])+"'", "ccode = '" + Lblccode.Text.ToString() + "'  ", ref Objdbcmd);
                                #endregion
                                //bindservey();


                            }
                            transaction.Commit();                            
                            this.bindGridData();
                            string popupScript = "<script language='javascript'>alert('सदर गावाचे  रि -एडीट अद्न्यावालीद्वारे करण्यात  आलेले   घोषणापत्र -I ( DECLARATION-I ) चे काम पूर्ववत(REVERT) यशस्वीरीत्या  करणेत आले आहे , तथापी  ग्राम महसूल अधिकारी यांना खाता प्रोसेसिंग (Khata Processing) चे काम पुन्हा सुरु  करता येईल याची नोंद  घ्यावी .!!!!' );</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            ExceptionHandling excpt = new ExceptionHandling();
                            if (Session["LoginID"] != null)
                                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
                            else
                                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
                            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
                        }
                    }

                }
            }
        }
        catch (Exception ex)
        {
            ExceptionHandling excpt = new ExceptionHandling();
            if (Session["LoginID"] != null)
                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", Convert.ToString(Session["LoginID"]), Convert.ToString(Session["DataBaseName"]));
            else
                Session["Error"] = excpt.Getex(ex, "pgReOpenDeclarationIVillage.aspx", "UNKNOWN", Convert.ToString(Session["DataBaseName"]));
            string popupScript = "<script language='javascript'>alert('" + Convert.ToString(Session["Error"]) + "');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript);
        }
    }
}