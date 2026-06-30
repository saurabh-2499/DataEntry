<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="Report6.aspx.cs" Inherits="Report6" Title="फेरफार रेजीस्टर" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center" >
        <asp:Button ID="btnMutationRegister" runat="server" OnClick="btnMutationRegister_Click"
        Text="पूर्ण गावाचे डाटा एन्ट्री  मॉड्युल फेरफार रेजीस्टर" CssClass="form_lbl" />
    <br />
    <br />
    <br />
    <asp:GridView ID="grd_mutation" runat="server" CssClass="grid" OnSelectedIndexChanged="grd_mutation_SelectedIndexChanged">
        <Columns>
            <asp:CommandField SelectText="निवडा" ShowSelectButton="True" />
        </Columns>
    <FooterStyle CssClass="gridfooter" />
                <PagerStyle CssClass="gridpager" />
                <SelectedRowStyle CssClass="gridselectdrow" />
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridrow" />
    </asp:GridView>
    </div>
    
</asp:Content>

