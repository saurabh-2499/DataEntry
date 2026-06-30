<%@ Page Language="C#" MasterPageFile="~/newmasterweblmis.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="pgNewHolders.aspx.cs" Inherits="pgNewHolders" Title="नवीन खातेदार" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script language="javascript" type="text/javascript">
function myClose()
{

    close();
    }
    </script>

    <script language="javascript" type="text/javascript">
function refreshmain(){ window.opener.location.reload( true); 
window.close();}
    </script>

    <asp:Panel ID="Panel1" runat="server" ScrollBars="horizontal" CssClass="bs_pnl">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView2_RowCancelingEdit"
            OnRowEditing="GridView2_RowEditing" OnRowUpdating="GridView2_RowUpdating" CssClass="grid" OnRowDataBound="GridView2_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="दुरूस्त" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update"
                            Text="साठवा"></asp:LinkButton>
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
                        <asp:Label ID="lblkhata_no" runat="server" Enabled="true" Text='<%# Eval("khata_no") %>'>
                        </asp:Label>
                        <%--<asp:TextBox ID="grd2text1" runat="server" Visible="false"></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="खातेदाराचे नाव">
                    <ItemTemplate>
                        <asp:Label ID="lblnames" runat="server" Enabled="true" Text='<%# Eval("names") %>'>
                        </asp:Label>
                        <%--<asp:TextBox ID="grd2text1" runat="server" Visible="false"></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="ख़ाता प्रकार.">
                    <ItemTemplate>
                        <asp:Label ID="lblkhata_type" runat="server" Visible="true" Enabled="true" Text='<%# Eval("buyer_khata_type") %>'></asp:Label>
                        <asp:DropDownList ID="grd2text2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropselectedchange"
                            AppendDataBoundItems="True" Visible="false">
                            <asp:ListItem>---निवडा--</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="खाता. क्र">
                    <ItemTemplate>
                        <asp:Label ID="lblnewkhata_no" runat="server" Enabled="true" Text='<%# Eval("new_khata_no") %>'>
                        </asp:Label>
                        <asp:TextBox ID="grd2text3" runat="server" Visible="false"></asp:TextBox>
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
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="साठवा" ToolTip="पुढे जा"
            TabIndex="1" CssClass="form_lbl" />&nbsp;&nbsp;
        <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Visible="False"></asp:Label></center>
    
    <br />
    
</asp:Content>

