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
public partial class pgNew712AddEntry : System.Web.UI.Page
{
    clscommonfun con = new clscommonfun();
    clsCommonFunction obj = new clsCommonFunction();
    string page_name = "pgNew712AddEntry";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           // Cache[Page.Request.FilePath + "page_heading"] = "नविन ७/१२ तयार करणे";

            Session["page_heading"] = "नविन ७/१२ तयार करणे";
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        
        if (txtsurvey.Text.ToString().Trim() != string.Empty)
        {

            txtsurvey.Enabled = false;
            txtpin1.Enabled = false;
            txtpin2.Enabled = false;
            txtpin3.Enabled = false;
            txtpin4.Enabled = false;
            txtpin5.Enabled = false;
            txtpin6.Enabled = false;
            txtpin7.Enabled = false;
            txtpin8.Enabled = false;

        }
        else
        {
            string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक  भरणे  आवश्यक आहे.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
            // ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "PopupScript", "alert('सर्व्हे क्रमांकउपलब्ध आहे !');", true);
            return;
        }

        int cnt = con.funReturnSingleValueInt((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".form7", "count(*)", "ccode = '" + (string)Session["ccode"] + "'and pin='" + txtsurvey.Text.ToString().Trim() + "' and pin1='" + txtpin1.Text.ToString().Trim() + "' and  pin2='" + txtpin2.Text.ToString().Trim() + "' and pin3='" + txtpin3.Text.ToString().Trim() + "' and pin4='" + txtpin4.Text.ToString().Trim() + "' and pin5='" + txtpin5.Text.ToString().Trim() + "' and pin6='" + txtpin6.Text.ToString().Trim() + "'  and pin7='" + txtpin7.Text.ToString().Trim() + "' and pin8 ='" + txtpin8.Text.ToString().Trim() + "' ", "");
        if (cnt > 0)
        {
            txtsurvey.Text = string.Empty;
            txtsurvey.Enabled = true;
            btnCancel.Enabled = true;
            string popupScript2 = "<script language='javascript'>alert('हा सर्व्हे क्रमांक अस्तितवात आहे. कृपया दुसरा सर्व्हे क्रमांक भरा.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
            return;
        }
        else
        {
         //cnt = con.funReturnSingleValueInt((string)Session["DataBaseName"], (string)Session["SchemaName"] + ".tbl_newsurvey", "count(*)", "ccode = '" + (string)Session["ccode"] + "'and newpin='" + txtsurvey.Text.ToString().Trim() + "' and newpin1='" + txtpin1.Text.ToString().Trim() + "' and  newpin2='" + txtpin2.Text.ToString().Trim() + "' and newpin3='" + txtpin3.Text.ToString().Trim() + "' and newpin4='" + txtpin4.Text.ToString().Trim() + "' and newpin5='" + txtpin5.Text.ToString().Trim() + "' and newpin6='" + txtpin6.Text.ToString().Trim() + "'  and newpin7='" + txtpin7.Text.ToString().Trim() + "' and newpin8 ='" + txtpin8.Text.ToString().Trim() + "' ", "");
         //if (cnt > 0)
         //{
         //    txtsurvey.Text = string.Empty;
         //    txtpin1.Text = string.Empty;
         //    txtpin2.Text = string.Empty;
         //    txtpin3.Text = string.Empty;
         //    txtpin4.Text = string.Empty;
         //    txtpin5.Text = string.Empty;
         //    txtpin6.Text = string.Empty;
         //    txtpin7.Text = string.Empty;
         //    txtpin8.Text = string.Empty;
         //    txtsurvey.Enabled = true;
         //    btnCancel.Enabled = true;
         //    string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक नविन ७/१२ तयार करण्यासाठी यापुर्वीच साठविण्यात आलेला आहे .');</script>";
         //    ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
         //    return;
         //}
         //else
         //{
            btnSave.Enabled = true;
             string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक नविन ७/१२ तयार करण्यासाठी उपलब्ध आहे.');</script>";
             ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
           
         //}

        }
    }
    
    
    
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void txtsurvey_TextChanged(object sender, EventArgs e)
    {
        //try
        //{
            if (txtsurvey.Text.ToString().Trim() != string.Empty)
            {
                txtpin1.Enabled = true;
                btnGo.Enabled = true;
            }
            else
            {
                txtpin1.Enabled = false;
                txtpin2.Enabled = false;
                txtpin3.Enabled = false;
                txtpin4.Enabled = false;
                txtpin5.Enabled = false;
                txtpin6.Enabled = false;
                txtpin7.Enabled = false;
                txtpin8.Enabled = false;
                btnGo.Enabled = false;
                string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक भरणे आवश्यक आहे.');</script>";
                ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
                return;
            }
        //}
        //catch
        //{

        //}


    }
    protected void txtpin1_TextChanged(object sender, EventArgs e)
    {
        if (txtpin1.Text.ToString().Trim() != string.Empty)
        {
            txtpin2.Enabled = true;
        }
        else
        {
            
            txtpin2.Enabled = false;
            txtpin3.Enabled = false;
            txtpin4.Enabled = false;
            txtpin5.Enabled = false;
            txtpin6.Enabled = false;
            txtpin7.Enabled = false;
            txtpin8.Enabled = false;
           
            string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक उपविभाग भरणे  आवश्यक आहे.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
            return;
        }

    }
    protected void txtpin2_TextChanged(object sender, EventArgs e)
    {
        if (txtpin2.Text.ToString().Trim() != string.Empty)
        {
            txtpin3.Enabled = true;
        }
        else
        {
            
            txtpin3.Enabled = false;
            txtpin4.Enabled = false;
            txtpin5.Enabled = false;
            txtpin6.Enabled = false;
            txtpin7.Enabled = false;
            txtpin8.Enabled = false;
            string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक उपविभाग भरणे  आवश्यक आहे.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
            return;
        }
    }
    protected void txtpin3_TextChanged(object sender, EventArgs e)
    {
        if (txtpin3.Text.ToString().Trim() != string.Empty)
        {
            txtpin4.Enabled = true;
        }
        else
        {
           
            txtpin4.Enabled = false;
            txtpin5.Enabled = false;
            txtpin6.Enabled = false;
            txtpin7.Enabled = false;
            txtpin8.Enabled = false;
            string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक उपविभाग भरणे  आवश्यक आहे.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
            return;
        }
    }
    protected void txtpin4_TextChanged(object sender, EventArgs e)
    {
        if (txtpin4.Text.ToString().Trim() != string.Empty)
        {
            txtpin5.Enabled = true;
        }
        else
        {
           
            txtpin5.Enabled = false;
            txtpin6.Enabled = false;
            txtpin7.Enabled = false;
            txtpin8.Enabled = false;
            string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक उपविभाग भरणे  आवश्यक आहे.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
            return;
        }
    }
    protected void txtpin5_TextChanged(object sender, EventArgs e)
    {
        if (txtpin5.Text.ToString().Trim() != string.Empty)
        {
            txtpin6.Enabled = true;
        }
        else
        {
            txtpin6.Enabled = false;
            txtpin7.Enabled = false;
            txtpin8.Enabled = false;
            string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक उपविभाग भरणे  आवश्यक आहे.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
            return;
        }
    }
    protected void txtpin6_TextChanged(object sender, EventArgs e)
    {
        if (txtpin6.Text.ToString().Trim() != string.Empty)
        {
            txtpin7.Enabled = true;
        }
        else
        {
            txtpin7.Enabled = false;
            txtpin8.Enabled = false;
            string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक उपविभाग भरणे  आवश्यक आहे.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
            return;
        }
    }
    protected void txtpin7_TextChanged(object sender, EventArgs e)
    {
        if (txtpin7.Text.ToString().Trim() != string.Empty)
        {
            txtpin8.Enabled = true;
        }
        else
        {
            
            string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक उपविभाग भरणे  आवश्यक आहे.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
            return;
        }
    }
    protected void txtpin8_TextChanged(object sender, EventArgs e)
    {
        if (txtpin8.Text.ToString().Trim() != string.Empty)
        {
            
        }
        else
        {
            string popupScript2 = "<script language='javascript'>alert('सर्व्हे क्रमांक उपविभाग भरणे  आवश्यक आहे.');</script>";
            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
            return;
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            btnSave.Enabled = false;
            txtsurvey.Text = string.Empty;
            txtpin1.Text = string.Empty;
            txtpin2.Text = string.Empty;
            txtpin3.Text = string.Empty;
            txtpin4.Text = string.Empty;
            txtpin5.Text = string.Empty;
            txtpin6.Text = string.Empty;
            txtpin7.Text = string.Empty;
            txtpin8.Text = string.Empty;

            txtsurvey.Enabled = true;
            txtpin1.Enabled = false;
            txtpin2.Enabled = false;
            txtpin3.Enabled = false;
            txtpin4.Enabled = false;
            txtpin5.Enabled = false;
            txtpin6.Enabled = false;
            txtpin7.Enabled = false;
            txtpin8.Enabled = false;

            btnGo.Enabled = false;
           
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
    protected void btnSave_Click(object sender, EventArgs e)
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
                        dbCommand.CommandType = CommandType.StoredProcedure;
                        //-----
                        try
                        {
                            //if (Convert.ToUInt32(drpAreaType.SelectedItem.Value) == 1)
                            //{
                            //    //,'" + System.DateTime.Today.Date.ToString("MM-dd-yyyy") + "'
                            //    obj.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".tbl_newSurvey", "ccode, talathi_sevarthid,newpin, newpin1,newpin2, newpin3, newpin4, newpin5, newpin6, newpin7, newpin8,tenure_code, unit, area_type, culti_area, assessment,potkharaba", "'" + Convert.ToString(Session["ccode"]) + "','" + Convert.ToString(Session["UserName"]) + "','" + Convert.ToString(txtsurvey.Text).Trim() + "','" + Convert.ToString(txtpin1.Text).Trim() + "','" + Convert.ToString(txtpin2.Text).Trim() + "','" + Convert.ToString(txtpin3.Text).Trim() + "','" + Convert.ToString(txtpin4.Text).Trim() + "','" + Convert.ToString(txtpin5.Text).Trim() + "','" + Convert.ToString(txtpin6.Text).Trim() + "','" + Convert.ToString(txtpin7.Text).Trim() + "','" + Convert.ToString(txtpin8.Text).Trim() + "','" + drpTenure.SelectedItem.Value + "','" + drpAreaUnit.SelectedItem.Value + "','" + drpAreaType.SelectedItem.Value + "','"+txtCultiArea.Text+"' , '"+txtAssesment.Text+"','"+txtPotkharaba.Text+"'", Convert.ToString(Session["UserName"]), ref dbCommand);
                            //}
                            //else
                            //{
                            //    obj.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".tbl_newSurvey", "ccode, talathi_sevarthid,newpin, newpin1,newpin2, newpin3, newpin4, newpin5, newpin6, newpin7, newpin8,tenure_code, unit, area_type,na_area_h, na_assessment", "'" + Convert.ToString(Session["ccode"]) + "','" + Convert.ToString(Session["UserName"]) + "','" + Convert.ToString(txtsurvey.Text).Trim() + "','" + Convert.ToString(txtpin1.Text).Trim() + "','" + Convert.ToString(txtpin2.Text).Trim() + "','" + Convert.ToString(txtpin3.Text).Trim() + "','" + Convert.ToString(txtpin4.Text).Trim() + "','" + Convert.ToString(txtpin5.Text).Trim() + "','" + Convert.ToString(txtpin6.Text).Trim() + "','" + Convert.ToString(txtpin7.Text).Trim() + "','" + Convert.ToString(txtpin8.Text).Trim() + "','" + drpTenure.SelectedItem.Value + "','" + drpAreaUnit.SelectedItem.Value + "','" + drpAreaType.SelectedItem.Value + "','"+txtNA.Text+"','"+txtNAAssesment.Text+"'", Convert.ToString(Session["UserName"]), ref dbCommand);
                            //}

                            obj.funInserSingleValueSevarthID(Session["DataBaseName"].ToString(), Session["SchemaName"].ToString() + ".form7", "ccode,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8", "'" + Convert.ToString(Session["ccode"]) + "','" + Convert.ToString(txtsurvey.Text).Trim() + "','" + Convert.ToString(txtpin1.Text).Trim() + "','" + Convert.ToString(txtpin2.Text).Trim() + "','" + Convert.ToString(txtpin3.Text).Trim() + "','" + Convert.ToString(txtpin4.Text).Trim() + "','" + Convert.ToString(txtpin5.Text).Trim() + "','" + Convert.ToString(txtpin6.Text).Trim() + "','" + Convert.ToString(txtpin7.Text).Trim() + "','" + Convert.ToString(txtpin8.Text).Trim() + "'", Convert.ToString(Session["UserName"]), ref dbCommand);

                            dbTransaction.Commit();
                            btnSave.Enabled = false;
                            txtsurvey.Text = string.Empty;
                            txtpin1.Text = string.Empty;
                            txtpin2.Text = string.Empty;
                            txtpin3.Text = string.Empty;
                            txtpin4.Text = string.Empty;
                            txtpin5.Text = string.Empty;
                            txtpin6.Text = string.Empty;
                            txtpin7.Text = string.Empty;
                            txtpin8.Text = string.Empty;

                            txtsurvey.Enabled = true;
                            txtpin1.Enabled = false;
                            txtpin2.Enabled = false;
                            txtpin3.Enabled = false;
                            txtpin4.Enabled = false;
                            txtpin5.Enabled = false;
                            txtpin6.Enabled = false;
                            txtpin7.Enabled = false;
                            txtpin8.Enabled = false;

                            btnGo.Enabled = false;
                           



                            string popupScript2 = "<script language='javascript'>alert('माहिती साठवली.');</script>";
                            ClientScript.RegisterStartupScript(GetType(), "PopupScript", popupScript2);
                            return;


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
                connection.Close();
            }
    }
    protected void txtCultiArea_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void txtNA_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void txtPotkharaba_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void txtAssesment_TextChanged(object sender, EventArgs e)
    {

    }
}