<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="~/circlemaster.master"
    AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="newholder.aspx.cs" Inherits="namefind" Title=".::राष्ट्रीय  भूमि अभिलेख आधुनिकीकरण कार्यक्रम,महाराष्ट्र राज्य::." %>
<%@ OutputCache Location="None" VaryByParam ="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
function myClose() {

    close();
    }
    </script>

    <script language="javascript" type="text/javascript">
function refreshmain(){ window.opener.location.reload( true); 
window.close();}
    </script>

    <asp:Panel ID="Panel1" runat="server" ScrollBars="horizontal" CssClass="bs_pnl">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView2_RowCancelingEdit"
            OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" CssClass="grid">
            <Columns>
                <asp:TemplateField HeaderText="दुरूस्त" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="संपादन"></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel"
                            Text="रद्द करा"></asp:LinkButton>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="AddNew"
                            Text="Add New"></asp:LinkButton>
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Edit"
                            Text="संपादन करा"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="खाता. क्र">
                    <ItemTemplate>
                        <asp:Label ID="lblColumn1" runat="server" Enabled="true" Text='<%# Eval("khata_no") %>'>
                        </asp:Label>
                        <asp:TextBox ID="grd2text1" runat="server" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ख़ाता प्रकार.">
                    <ItemTemplate>
                        <asp:Label ID="lblColumn2" runat="server" Visible="true" Enabled="true" Text='<%# Eval("buyer_khata_type") %>'></asp:Label>
                        <asp:DropDownList ID="grd2text2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropselectedchange"
                            AppendDataBoundItems="True" Visible="false">
                            <asp:ListItem>---निवडा--</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="अ.नु.क्रमांक">
                    <ItemTemplate>
                        <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("usrno") %>'>
                        </asp:Label>
                        <asp:TextBox ID="grd2text3" runat="server" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="नविन खातेदारचे नांव">
                    <ItemTemplate>
                        <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("buyer_name") %>'>
                        </asp:Label>
                        <asp:TextBox ID="grd2text4" runat="server" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="नविन खातेदारचे नांव" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("fname") %>'>
                        </asp:Label>
                        <asp:TextBox ID="grd2text5" runat="server" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="नविन खातेदारचे नांव" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblColumn6" runat="server" Enabled="true" Text='<%# Eval("mname") %>'>
                        </asp:Label>
                        <asp:TextBox ID="grd2text6" runat="server" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="नविन खातेदारचे नांव" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblColumn7" runat="server" Enabled="true" Text='<%# Eval("lname") %>'>
                        </asp:Label>
                        <asp:TextBox ID="grd2text7" runat="server" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="नविन खातेदारचे नांव" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblColumn8" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'>
                        </asp:Label>
                        <asp:TextBox ID="grd2text8" runat="server" Visible="false"></asp:TextBox>
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
    <center>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="पुढे जा" ToolTip="पुढे जा"
            TabIndex="1" CssClass="form_lbl" />&nbsp;
    </center>
    
</asp:Content>
