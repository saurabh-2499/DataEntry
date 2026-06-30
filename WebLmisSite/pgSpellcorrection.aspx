<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgSpellcorrection.aspx.cs" Inherits="pgSpellcorrection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
        <asp:Panel ID="pnlSpellCorrNames" runat="server" ScrollBars="vertical" CssClass="bs_pnl" Height="200px" Width="100%">
            <asp:GridView ID="gdvSpellCorrNames" runat="server" BorderWidth="1px" CssClass="grid"
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
                        <ItemStyle Width="5%" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="खाता. क्र" Visible="true">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="5%" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText=" मुळ पहिले नाव">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                CssClass="form_lbl" ForeColor="red" Font-Strikeout="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="11%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" मुळ मधले   नाव        ">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                CssClass="form_lbl" ForeColor="red" Font-Strikeout="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="11%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" मुळ शेवटचे  नाव        ">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                CssClass="form_lbl" ForeColor="red" Font-Strikeout="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="11%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" मुळ टोपण नाव           ">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                CssClass="form_lbl" ForeColor="red" Font-Strikeout="true"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="11%" />
                    </asp:TemplateField>


                     <asp:TemplateField HeaderText=" नविन पहिले नाव">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn6" runat="server" Enabled="true" Text='<%# Eval("newfname") %>'
                                CssClass="form_lbl" ForeColor="Green"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="11%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" नविन मधले   नाव        ">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn7" runat="server" Enabled="true" Text='<%# Eval("newmname") %>'
                                CssClass="form_lbl" ForeColor="Green"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="11%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" नविन शेवटचे  नाव        ">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn8" runat="server" Enabled="true" Text='<%# Eval("newlname") %>'
                                CssClass="form_lbl"   ForeColor="Green"></asp:Label>
                        </ItemTemplate >
                        <ItemStyle Width="11%" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" नविन टोपण नाव           ">
                        <ItemTemplate>
                            <asp:Label ID="lblColumn9" runat="server" Enabled="true" Text='<%# Eval("newtopan_name") %>'
                                CssClass="form_lbl" ForeColor="Green"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="11%" />
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

