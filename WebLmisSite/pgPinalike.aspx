<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgPinalike.aspx.cs" Inherits="pgPinalike" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <center>
       <span><strong><h3> अहवाल  -एकसारखे सर्वे क्रमांक पण अतिरिक्त स्पेस असेलेले सर्वे क्रमांक किंवा  <br />एकसारखे सर्वे क्रमांक  परंतू वेगळ्या पद्धतीनी उपविभागामध्ये सामाविष्ट केलेले  सर्वे क्रमांक </h3></strong> </span>
        <br />

    </center>


    <asp:Panel ID="pnlInfo" runat="server" Height="250px" ScrollBars="Vertical" CssClass="bs_pnl"
        Width="90%">

        <asp:GridView ID="GridView1" runat="server" BorderStyle="Solid" BorderWidth="1px" CellSpacing="3" BorderColor="Black" Width="100%" AutoGenerateColumns="False" CssClass="grid">
            <EmptyDataTemplate>
                <h3><center>
                माहिती उपलब्ध नाही .......
                    </center></h3>
            </EmptyDataTemplate>
            <Columns>

                <asp:TemplateField HeaderText="सर्वे क्रमांक">
                    <ItemTemplate>
                        <asp:Label ID="lblColumn" runat="server" Enabled="true" Text='<%# Eval("pincase") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="false"  HeaderText="उपविभाग" >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn" runat="server" Enabled="true" Text='<%# Eval("numeric_pin") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="उपविभाग" >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn" runat="server" Enabled="true" Text='<%# Eval("pin") %>'
                            CssClass="form_lbl" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="उपविभाग 1" >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn1" runat="server" Enabled="true" Text='<%# Eval("pin1") %>'
                            CssClass="form_lbl" ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="उपविभाग 2" >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("pin2") %>'
                            CssClass="form_lbl"  ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="उपविभाग 3" >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("pin3") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="उपविभाग 4" >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("pin4") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="उपविभाग 5" >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("pin5") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="उपविभाग 6" >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn6" runat="server" Enabled="true" Text='<%# Eval("pin6") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="उपविभाग 7" >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn7" runat="server" Enabled="true" Text='<%# Eval("pin7") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="उपविभाग 8 " >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn8" runat="server" Enabled="true" Text='<%# Eval("pin8") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

               <asp:TemplateField HeaderText=" एकूण लागवडी योग्य क्षेत्र  " >
                    <ItemTemplate>
                        <asp:Label ID="lblColumn9" runat="server" Enabled="true" Text='<%# Eval("total_area_h ") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle CssClass="gridfooter" />
            <PagerStyle CssClass="gridpager" />
            <SelectedRowStyle CssClass="gridselectdrow" />
            <HeaderStyle CssClass="gridheader" />
            <RowStyle CssClass="gridrow" />




        </asp:GridView>


    </asp:Panel>





</asp:Content>

