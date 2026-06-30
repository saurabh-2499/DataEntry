using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NIC.WebLMISLibrary;
using System.Data.Common;

public partial class pgSearchPartyName : System.Web.UI.Page
{
    clsCommonFunction objCommFun = new clsCommonFunction();

    SellerDataset obj_SellerDataSet = new SellerDataset();


    #region " Pageload"

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            string ccode = Request.QueryString["ccode"];
            string Mut_No = Convert.ToString(Session["Mut_No"]);
            string Mut_Type = Convert.ToString(Session["Mut_Type"]);
            string Info_Date = Convert.ToString(Session["Info_Date"]);
            string Mut_Date = Convert.ToString(Session["Mut_Date"]); 
            
            
            hfVillageName.Value = Convert.ToString(Session["village_name"]);
            hfCcode.Value = Convert.ToString(Session["ccode"]);
            objCommFun.funSetDropDownList(Convert.ToString(Session["DataBaseName"]), ref ddlname, Session["SchemaName"].ToString() + ".holder_detail AS a", "DISTINCT fname|| mname|| lname|| topan_name as pname,fname || '#' || mname || '#' || lname || '#' || topan_name as pvalue", "ccode = '" + ccode + "'", "pname", "pname", "pvalue");
        }
    }

    # endregion

    # region "  Button Event  "

    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtkhata.Text == "")
        {
            string strData = ddlname.SelectedValue ;
            string[] strSplitArr = strData.Split('#');
            objCommFun.funSetGridList(Convert.ToString(Session["DataBaseName"]), ref gvPartyDetail, Session["SchemaName"].ToString() + ".holder_detail AS a,"+ Session["SchemaName"].ToString() + ".m_khata_type AS p", "distinct fname,mname,lname,topan_name,khata_description,khata_no", "a.khata_type = p.khata_type and marked <> 'Y' and fname ='" + strSplitArr[0] + "' and mname ='" + strSplitArr[1] + "' and lname ='" + strSplitArr[2] + "' and  ccode = '"+hfCcode.Value+"'", "fname");
        }
        else
        {
            objCommFun.funSetGridList(Convert.ToString(Session["DataBaseName"]), ref gvPartyDetail, Session["SchemaName"].ToString() + ".holder_detail AS a," + Session["SchemaName"].ToString() + ".m_khata_type AS p", "distinct fname,mname,lname,topan_name,khata_description,khata_no", "a.khata_type = p.khata_type and marked <> 'Y' AND khata_no ='" + txtkhata.Text + "' AND  ccode = '" + hfCcode.Value + "'", "fname");
        }
    }

    protected void btnGo_Click(object sender, EventArgs e)
    {
       //Response.Redirect("pg_Bhoja.aspx");
    }

    # endregion

    # region "  Grid View Event  "

    protected void gvPartyDetail_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        Session["rno"] = e.NewSelectedIndex;
        int rno;
        rno = e.NewSelectedIndex;
        
        //Label l1 = new System.Web.UI.WebControls.Label();
        //Label l2 = new System.Web.UI.WebControls.Label();
        //Label l3 = new System.Web.UI.WebControls.Label();
        //Label l4 = new System.Web.UI.WebControls.Label();
        //Label l5 = new System.Web.UI.WebControls.Label();

        //l1 = (Label)gvPartyDetail.Rows[rno].FindControl("lblColumn5");
        //l2 = (Label)gvPartyDetail.Rows[rno].FindControl("lblColumn1");
        //l3 = (Label)gvPartyDetail.Rows[rno].FindControl("lblColumn2");
        //l4 = (Label)gvPartyDetail.Rows[rno].FindControl("lblColumn3");
        //l5 = (Label)gvPartyDetail.Rows[rno].FindControl("lblColumn4");

        //Session["mkhatano"] = l2.Text;
        //Session["fnkhata"] = l3.Text;
        //Session["mnkhata"] = l4.Text;
        //Session["lnkhata"] = l5.Text;
        //Session["tnkhata"] = l1.Text;
        
        string lblkhata_no = Convert.ToString( ((Label)gvPartyDetail.Rows[e.NewSelectedIndex].FindControl("lblkhata_no")).Text);
        string lblkhata_description = Convert.ToString(((Label)gvPartyDetail.Rows[e.NewSelectedIndex].FindControl("lblkhata_description")).Text);
        string lblfname = Convert.ToString(((Label)gvPartyDetail.Rows[e.NewSelectedIndex].FindControl("lblfname")).Text);
        string lblmname = Convert.ToString(((Label)gvPartyDetail.Rows[e.NewSelectedIndex].FindControl("lblmname")).Text);
        string lbllname = Convert.ToString(((Label)gvPartyDetail.Rows[e.NewSelectedIndex].FindControl("lbllname")).Text);
        string lbltopan_name = Convert.ToString(((Label)gvPartyDetail.Rows[e.NewSelectedIndex].FindControl("lbltopan_name")).Text);


        DataRow dr = obj_SellerDataSet.Tables["SellerDetails"].NewRow();
            dr[0] = lblkhata_no;
            dr[1] = lblkhata_description;
            dr[2] = lblfname;
            dr[3] = lblmname;
            dr[4] = lbllname;
            dr[5] = lbltopan_name;
         Session["SellerDataset"]=obj_SellerDataSet ;
    }

    # endregion


}
