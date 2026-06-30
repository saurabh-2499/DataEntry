<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgRORDownload.aspx.cs" Inherits="pgRORDownload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <div class="clear_br">

    </div>
    <div class="row">
        
          <asp:Label ID="lblVillageDisp" runat="server" Text="गाव :" ></asp:Label> &nbsp;&nbsp; <asp:DropDownList ID="ddlvillage" runat="server" CssClass="form_drp" OnSelectedIndexChanged="ddlvillage_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>

    <div class="bs_pnl_s"> <%--OnSelectedIndexChanging="gdvRORZip_SelectedIndexChanging" --%>
            
            <asp:GridView ID="gdvRORZip" runat="server" AutoGenerateColumns="False" OnRowCommand ="gdvRORZip_RowCommand"
                TabIndex="2" CssClass="grid_dark" BackColor="#DAE5F4" >
                <PagerSettings FirstPageText="First" LastPageText="Last" />
                <Columns>
                   
                    <asp:TemplateField HeaderText="फाईल" Visible="True">
                        <ItemTemplate>
                            <asp:Label ID="lblVillageCode" runat="server" Text='<%# Bind("filename") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="एकूण सर्व्हे/गट संख्या">
                        <ItemTemplate >
                            <asp:Label ID="lblSurvey" runat="server" Text='<%# Bind("filecount") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>

                     <%--<asp:CommandField ShowSelectButton="True" SelectText="Download" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>--%>


                    <asp:TemplateField HeaderText="Download">
    <ItemTemplate>
        <asp:LinkButton ID="lnkDownload" runat="server"
            Text="Download"
            CommandName="DownloadZip"
            CommandArgument='<%# Eval("filename") %>' />
    </ItemTemplate>
</asp:TemplateField>

                </Columns>
                <FooterStyle CssClass="gridfooter" />
                <PagerStyle CssClass="gridpager" />
                <SelectedRowStyle CssClass="gridselectdrow" />
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridrow" />
                <AlternatingRowStyle BackColor="#B8D1F3" />
            </asp:GridView>

            
            </div>
</asp:Content>

