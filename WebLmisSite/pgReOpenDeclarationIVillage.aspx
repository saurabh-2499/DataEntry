<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster_DBA.master" AutoEventWireup="true" CodeFile="pgReOpenDeclarationIVillage.aspx.cs" Inherits="pgReOpenDeclarationIVillage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <hr />
    <asp:Panel ID="Panel1" runat="server" Style="text-align: center">
        <div class="row">
            <center>
                <asp:GridView ID="gvRevertD1" runat="server" Visible="true" AutoGenerateColumns="False"
                    TabIndex="2" CssClass="grid_dark" BackColor="#DAE5F4" Style="text-align: left;" Width="90%"  OnSelectedIndexChanging="gvRevertD1_SelectedIndexChanging">
                    <PagerSettings FirstPageText="First" LastPageText="Last" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" SelectText="पूर्ववत करा" HeaderText="पूर्ववत करणे">
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:CommandField>
                        <asp:TemplateField HeaderText="गावाचे नाव" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblVname" runat="server" Text='<%# Bind("village_name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="तलाठी" Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblTname" runat="server" Text='<%# Bind("talathi_name") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Declaration I केल्याचा दिनांक">
                            <ItemTemplate>
                                <asp:Label ID="lbld1Date" runat="server" Text='<%# Bind("d1date") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Revert Declaration I Request date ">
                            <ItemTemplate>
                                <asp:Label ID="lbld1ReqDate" runat="server" Text='<%# Bind("request_date") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ccode" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblccode" runat="server" Text='<%# Bind("ccode") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="gridfooter" />
                    <PagerStyle CssClass="gridpager" />
                    <SelectedRowStyle CssClass="gridselectdrow" />
                    <HeaderStyle CssClass="gridheader" />
                    <RowStyle CssClass="gridrow" />
                    <AlternatingRowStyle BackColor="#B8D1F3" />
                </asp:GridView>
                <br />
            </center>
        </div>
        <br />
        <asp:Label ID="lblVillagetext" runat="server" Font-Names="Sakal Marathi" CssClass="form_lbl" Font-Size="Large" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnRevertD1" runat="server" Text="पूर्ववत करणे" Font-Names="Sakal Marathi" CssClass="btn-success" OnClick="btnRevertD1_Click" Visible="False" />
    </asp:Panel>
</asp:Content>

