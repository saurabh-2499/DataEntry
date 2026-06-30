<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgReport.aspx.cs" Inherits="pgReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <div class="row">
            <br />
            <asp:RadioButtonList ID="rbtnlist" runat="server" CssClass="form_lbl" Font-Size="Medium" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnlist_SelectedIndexChanged" AutoPostBack="true" >
                <asp:ListItem Value="1">फेरफार क्रमांकानुसार </asp:ListItem>
                <asp:ListItem Value="2">परिशिष्ट क्रमांकानुसार </asp:ListItem>

            </asp:RadioButtonList>
        </div>
            <br />
             <asp:Panel ID="pnltransno" runat="server"    Height="50px" Visible="false">
                 <center>
                     <asp:Label ID="Label1" runat="server" Text="परिशिष्ट क्रमांक:  " CssClass="form_lbl"></asp:Label>

                 <asp:DropDownList ID="ddltransno" runat="server" CssClass="form_drp_60" Height="25px" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddltransno_SelectedIndexChanged"></asp:DropDownList>
                     </center>
                 </asp:Panel>
     <asp:Panel ID="pnlmutno" runat="server"  ScrollBars="Auto"  Width="70%" Height="300px" Visible="false">

                <asp:GridView ID="grd_mutation" runat="server" CssClass="grid"  Width="100%" OnSelectedIndexChanged="grd_mutation_SelectedIndexChanged" >
        <Columns>
            <asp:CommandField SelectText="निवडा" ShowSelectButton="True" />
        </Columns>
    <FooterStyle CssClass="gridfooter" />
                <PagerStyle CssClass="gridpager" />
                <SelectedRowStyle CssClass="gridselectdrow" />
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridrow" />
    </asp:GridView>
          </asp:Panel>
        </center>
</asp:Content>

