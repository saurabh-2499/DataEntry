<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="CopyofReport_6D.aspx.cs" Inherits="Report_6D" %>
<%@ OutputCache Location="None" VaryByParam ="None" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>.::राष्ट्रीय भूमि अभिलेख आधुनिकीकरण कार्यक्रम,महाराष्ट्र राज्य::.</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
   
</head>


      
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" Visible="False"
                CssClass="form_lbl" />
            <div class="row">
                <div class="column">
                    <asp:Label ID="Label1" runat="server" Text="?????? " Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:Label ID="lbldistrictname" runat="server" Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:DropDownList ID="ddldist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddldist_SelectedIndexChanged"
                        Visible="False" CssClass="form_txt">
                    </asp:DropDownList></div>
            </div>
            <div class="row">
                <div class="column">
                    <asp:Label ID="Label2" runat="server" Text="??????" Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:Label ID="lbltalukaname" runat="server" Visible="False" CssClass="form_lbl"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:Label ID="lblcntstr" runat="server" ></asp:Label>
                    <asp:Label ID="lblservrth" runat="server" Visible="False" ></asp:Label></div>
                <div class="column">
                    <asp:DropDownList ID="ddltal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddltal_SelectedIndexChanged"
                        Visible="False" CssClass="form_txt">
                    </asp:DropDownList></div>
            </div>
            <div class="row" >
                <div class="column">
                    <asp:Label ID="Label3" runat="server" Text="??? :" Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:Label ID="lblvillagename" runat="server" Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:DropDownList ID="ddlgaon" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlgaon_SelectedIndexChanged"
                        Visible="False" CssClass="form_txt">
                    </asp:DropDownList></div>
            </div>
            <div class="row">
                <div class="column">
                    <asp:Label ID="Label4" runat="server" Text="?????? ???????:" Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    &nbsp;</div>
                <div class="column">
                    <asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" Text="Search"
                        Visible="False" CssClass="form_lbl" /></div>
            </div>
            <div class="row">
                <asp:Label ID="lblmessage" runat="server" CssClass="form_lbl_red_s"></asp:Label></div>
            <asp:Panel ID="Panel1" runat="server" Visible="False">
                
            </asp:Panel>
            
            <asp:HiddenField ID="hftype" runat="server" />
            
            <asp:HiddenField ID="hfCcode" runat="server" />
            <asp:HiddenField ID="hdfMutno" runat="server" />
            <asp:HiddenField ID="hdfccode" runat="server" />
            <asp:HiddenField ID="hdfMutType" runat="server" />
            <asp:HiddenField ID="hdfMutName" runat="server" />
            <asp:HiddenField ID="hdfuserid" runat="server" />
            <br />
            <asp:HiddenField ID="hfconcatnatestr" runat="server" />
            <asp:HiddenField ID="hfservarthpk" runat="server" />
            <asp:HiddenField ID="hfSignDataString" runat="server" />
            <br />
            <asp:TextBox ID="txt" runat="server" Text=""></asp:TextBox>
            <br />
            <asp:HiddenField ID="hf_serail_key" runat="server" />
            <asp:HiddenField ID="hf" runat="server" />
            <asp:HiddenField ID="hfyd" runat="server" />
            <asp:HiddenField ID="hfdate" runat="server" />
            <asp:HiddenField ID="hf_file" runat="server" />
            <asp:HiddenField ID="hfname" runat="server" />
            <asp:HiddenField ID="hfcrdnm" runat="server" />
        </div>
    </form>
</body>
</html>
