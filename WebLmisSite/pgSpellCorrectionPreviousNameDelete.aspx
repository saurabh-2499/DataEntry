<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgSpellCorrectionPreviousNameDelete.aspx.cs" Inherits="pgSpellCorrectionPreviousNameDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:Panel ID="pnlSpellCorrPrevNames" runat="server" ScrollBars="vertical" CssClass="bs_pnl" Height="200px" Width="100%">
            <asp:GridView ID="gdvSpellCorrPrevNames" runat="server" BorderWidth="1px" CssClass="grid"
                BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"
                TabIndex="1" UseAccessibleHeader="False">


                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblnivda" runat="server" Text="निवडा" CssClass="form_lbl"></asp:Label>
                            <asp:CheckBox ID="chkeffect" runat="server" Visible="true"
                                AutoPostBack="True" OnCheckedChanged="chkeffect_CheckedChanged" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkselect" runat="server" ToolTip="<%# ((GridViewRow)Container).RowIndex %>" />
                        </ItemTemplate>
                        <ItemStyle Width="6%" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="खाता. क्र" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="7%" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="पहिले नाव">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="मधले   नाव        ">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="टोपण नाव           ">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="12%" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="gridfooter" />
                <PagerStyle CssClass="gridpager" />
                <SelectedRowStyle CssClass="gridselectdrow" />
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridrow" />
            </asp:GridView>
        </asp:Panel>
    </div>
    <br />
    <div class="row">
        <center>
            <asp:Button ID="btnSave" runat="server" Text=" माहिती साठवा " CssClass="form_lbl" ToolTip="" OnClick="btnSave_Click" Visible="False"></asp:Button>

            <asp:Button ID="btnback" runat="server" Text="मागे जा"
                CssClass="form_lbl" ToolTip="मागे जा" OnClick="btnback_Click"></asp:Button>
            <div class="clear_br">
            </div>
        </center>
    </div>
</asp:Content>

