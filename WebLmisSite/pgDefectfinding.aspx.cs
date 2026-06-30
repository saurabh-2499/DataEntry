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
using NIC.WebLMISLibrary;

public partial class pgDefectfinding : System.Web.UI.Page
{
    clsCommonFunction objCommFun = new clsCommonFunction();
    clsMutationLr objmutaiondetail = new clsMutationLr();
    DataTable tblholder = new DataTable();
    DataTable tblform7khata = new DataTable();

    protected void page_Init(object sender, EventArgs e)
    {
        base.OnPreInit(e);
        //HttpContext.Current.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
       // HttpContext.Current.Response.Cache.SetValidUntilExpires(false);
        //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
       //HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        //HttpContext.Current.Response.Cache.SetNoStore();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {


                objCommFun.funSetDropDownList(Convert.ToString(Session["DataBaseName"]), ref ddlvillage, Convert.ToString(Session["SchemaName"]) + ".m_village_census as m", "m.ccode,m.village_name", "", "");
            }
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnprev_Click(object sender, EventArgs e)
    {
        Response.Redirect("pgselectMutation.aspx");
    }
    protected void btnlogout_Click(object sender, EventArgs e)
    {
       // Response.Redirect("pgLogout.aspx");
    }
    protected void gvKhataOwners_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //--from gvKhataOwners grid owmer deatils are fetch--
        string strkhatano = ((Label)gvKhataOwners.Rows[e.NewSelectedIndex].FindControl("lblkhata_no")).Text;
        string strfname = ((Label)gvKhataOwners.Rows[e.NewSelectedIndex].FindControl("lblfname")).Text;
        string strmname = ((Label)gvKhataOwners.Rows[e.NewSelectedIndex].FindControl("lblmname")).Text;
        string strlname = ((Label)gvKhataOwners.Rows[e.NewSelectedIndex].FindControl("lbllname")).Text;
        string strtopanname = ((Label)gvKhataOwners.Rows[e.NewSelectedIndex].FindControl("lbltopan_name")).Text;

        //[-- gvpinselect grid is filled with survey no for selected owner DBname(mhrorpun),schema(mhrorpun_mul),tablename(form7_khata),class(clsCommonFunction)--]
//        objCommFun.funSetGridList(Convert.ToString(Session["DataBaseName"]), ref dgvpin, Session["SchemaName"].ToString() + ".form7_khata AS p", "khata_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,numeric_pin,fname,mname,lname,usrno", "p.ccode = '" + hfCcode.Value + "' AND khata_no ='" + strkhatano + "' and fname='" + strfname + "' and mname='" + strmname + "' and lname='" + strlname + "' and topan_name='" + strtopanname + "'", "p.ccode");
       // objCommFun.funSetGridList(Convert.ToString(Session["DataBaseName"]), ref dgvpin, Session["SchemaName"].ToString() + ".form7_khata AS p", "khata_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,numeric_pin,fname,mname,lname,usrno,khata_type,total_area_h", "p.ccode = '" + hfCcode.Value + "' AND khata_no ='" + strkhatano + "'", "p.pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,usrno");
        DataSet ds = objCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".form7_khata AS p", "khata_no,pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,numeric_pin,fname,mname,lname,usrno,khata_type,total_area_h", "p.ccode = '" + hfCcode.Value + "' AND khata_no ='" + strkhatano + "'", "p.pin,pin1,pin2,pin3,pin4,pin5,pin6,pin7,pin8,usrno");
        Session["tblform7khata"] = (DataTable)ds.Tables[0];
        dgvpin.DataSource = (DataTable)ds.Tables[0];
        dgvpin.DataBind();
    }
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        hfCcode.Value = ddlvillage.SelectedValue.ToString();

        //objCommFun.funSetGridList(Convert.ToString(Session["DataBaseName"]), ref gvKhataOwners, Session["SchemaName"].ToString() + ".holder_detail AS a," + Session["SchemaName"].ToString() + ".m_khata_type AS p", "distinct fname,mname,lname,topan_name,khata_no,usrno", "a.khata_type = p.khata_type  AND ccode = '" + hfCcode.Value + "'", "khata_no,usrno");
     DataSet ds=   objCommFun.funReturnDataSet(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]) + ".holder_detail AS a," + Convert.ToString(Session["SchemaName"]) + ".m_khata_type AS p", "distinct fname,mname,lname,topan_name,khata_no,usrno", "a.khata_type = p.khata_type  AND ccode = '" + hfCcode.Value + "'", "khata_no,usrno");
     Session["tblhoder"] = (DataTable)ds.Tables[0];
     gvKhataOwners.DataSource = (DataTable)ds.Tables[0];
     gvKhataOwners.DataBind();
    }



    #region "[[[[[[ User Define function]]]]]]]]"
    protected void Createholder()
    {
        tblholder.Columns.Clear();
        tblholder.Columns.Add("khata_no");   
        tblholder.Columns.Add("pin");
        tblholder.Columns.Add("Pin1");
        tblholder.Columns.Add("Pin2");
        tblholder.Columns.Add("Pin3");
        tblholder.Columns.Add("Pin4");
        tblholder.Columns.Add("Pin5");
        tblholder.Columns.Add("Pin6");
        tblholder.Columns.Add("Pin7");
        tblholder.Columns.Add("Pin8");
        tblholder.Columns.Add("fname");
        tblholder.Columns.Add("mname");
        tblholder.Columns.Add("lname");
        tblholder.Columns.Add("topan_name");
        tblholder.Columns.Add("usrno");
    }


    protected void Createform7khata()
    {
        tblform7khata.Columns.Clear();
        tblform7khata.Columns.Add("khata_no");
        tblform7khata.Columns.Add("pin");
        tblform7khata.Columns.Add("Pin1");
        tblform7khata.Columns.Add("Pin2");
        tblform7khata.Columns.Add("Pin3");
        tblform7khata.Columns.Add("Pin4");
        tblform7khata.Columns.Add("Pin5");
        tblform7khata.Columns.Add("Pin6");
        tblform7khata.Columns.Add("Pin7");
        tblform7khata.Columns.Add("Pin8");
        tblform7khata.Columns.Add("fname");
        tblform7khata.Columns.Add("mname");
        tblform7khata.Columns.Add("lname");
        tblform7khata.Columns.Add("usrno");
        tblform7khata.Columns.Add("khata_type");
        tblform7khata.Columns.Add("total_area_h");
    }
    #endregion
    protected void gvKhataOwners_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            lblMsgholder.Text = "";
            int i = 0;
            TextBox txtusrno = (TextBox)gvKhataOwners.Rows[e.RowIndex].FindControl("txthoderuser");
            Label lblkhata_no = (Label)gvKhataOwners.Rows[e.RowIndex].FindControl("lblkhata_no");
            Label lblfname = (Label)gvKhataOwners.Rows[e.RowIndex].FindControl("lblfname");
            Label lblmname = (Label)gvKhataOwners.Rows[e.RowIndex].FindControl("lblmname");
            Label lbllname = (Label)gvKhataOwners.Rows[e.RowIndex].FindControl("lbllname");

            if (Session["tblhoder"] != null)
            {
                i = objmutaiondetail.funupdatehoderdata(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]), hfCcode.Value, lblkhata_no.Text, lblfname.Text, lblmname.Text, lbllname.Text, txtusrno.Text);
                if (i > 0)
                {
                    DataTable dt = (DataTable)Session["tblhoder"];

                    dt.Rows[e.RowIndex]["usrno"] = txtusrno.Text;
                    Session["tblhoder"] = dt;
                    gvKhataOwners.DataSource = dt;
                    gvKhataOwners.DataBind();
                    lblMsgholder.Visible = true;
                    lblMsgholder.Text = "Record is updated successfully!!!";
                }
                else
                {
                    lblMsgholder.Visible = true;
                    lblMsgholder.Text = "Record is not updated !!!";
                }
            }
        }
        catch (Exception ex)
        { }
    }
    protected void dgvpin_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int i = 0;
        TextBox txtusrno = (TextBox)dgvpin.Rows[e.NewSelectedIndex].FindControl("txtusrno");
        Label lblkhata_no = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblpinkhata");
        Label lblfname = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblfname");
        Label lblmname = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblmname");
        Label lbllname = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lbllname");
        Label pin = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblpin");
        Label pin1 = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblpin1");
        Label pin2 = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblpin2");
        Label pin3 = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblpin3");
        Label pin4 = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblpin4");
        Label pin5 = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblpin5");
        Label pin6 = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblpin6");
        Label pin7 = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblpin7");
        Label pin8 = (Label)dgvpin.Rows[e.NewSelectedIndex].FindControl("lblpin8");


        if (Session["tblform7khata"] != null)
        {
            i = objmutaiondetail.funupdatekhata(Convert.ToString(Session["DataBaseName"]), Convert.ToString(Session["SchemaName"]), hfCcode.Value, lblkhata_no.Text, lblfname.Text, lblmname.Text, lbllname.Text, txtusrno.Text, pin.Text, pin1.Text, pin2.Text, pin3.Text, pin4.Text, pin5.Text, pin6.Text, pin7.Text, pin8.Text);
            if (i > 0)
            {
                DataTable dt = (DataTable)Session["tblform7khata"];

                dt.Rows[e.NewSelectedIndex]["usrno"] = txtusrno.Text;
                Session["tblform7khata"] = dt;
                dgvpin.DataSource = dt;
                dgvpin.DataBind();
                lblkhata.Visible = true;
                lblkhata.Text = "Record is updated successfully!!!";
            }
            else
            {
                lblkhata.Visible = true;
                lblkhata.Text = "Record is not updated !!!";
            }

        }
    }
}
