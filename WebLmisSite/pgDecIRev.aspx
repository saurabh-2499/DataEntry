<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster_DBA.master" AutoEventWireup="true" CodeFile="pgDecIRev.aspx.cs" Inherits="pgDecIRev" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script><script type="text/javascript" language="javascript">

                                                                                                                       document.onreadystatechange = function () {
                                                                                                                           if (document.readyState == "interactive") {
                                                                                                                               document.getElementById('myHiddenDiv').style.display = "none";;
                                                                                                                           }
                                                                                                                       }

                                                                                                                       function MultipleUserLogin() {
                                                                                                                           if (confirm('जर तुम्ही दुसऱ्या मशीनवरून काम करत असाल तर आपल्या या लॉगिन ने पूर्वीचे लॉगिन हे लॉग आउट होईल अन्यथा आपणास पुढे काम करता येणार नाही.\n आपणास तरीही लॉगिन करावयाचे आहे का??')) {
                                                                                                                               document.getElementById("<%=hfMultipleUsers.ClientID %>").value = "true";
             }
             else {
                 window.location = window.location.protocol + '//' + window.location.hostname + '/edit/pglogout.aspx';
             }
         }



        </script><asp:HiddenField ID="Version" runat="server" />
                 <asp:HiddenField ID="hfMultipleUsers" runat="server" />
       <asp:Panel ID="printPanel" runat="server">
        <div class="bs_pnl_s">
            
            <asp:GridView ID="dgvVillageSelection" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="dgvVillageSelection_SelectedIndexChanging"
                TabIndex="2" CssClass="grid_dark" BackColor="#DAE5F4" >
                <PagerSettings FirstPageText="First" LastPageText="Last" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" SelectText="निवडा" >
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:TemplateField HeaderText="कोड" Visible="False">
                        <ItemTemplate>
                            <asp:Label ID="lblVillageCode" runat="server" Text='<%# Bind("village_code") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="नांव">
                        <ItemTemplate>
                            <asp:Label ID="lblVillageName" runat="server" Text='<%# Bind("village_name") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="सेन्सस कोड">
                        <ItemTemplate >
                            <asp:Label ID="lblCCode" runat="server" Text='<%# Bind("ccode") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="एकूण सर्व्हे/गट संख्या">
                        <ItemTemplate >
                            <asp:Label ID="lblSurvey" runat="server" Text='<%# Bind("survey") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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

        <center>
            <asp:Label ID="lblVillageDisp" runat="server" Text="निवडलेले गाव :-" Visible="False"></asp:Label> &nbsp;&nbsp; <asp:Label ID="lblVillage" runat="server" ForeColor="Purple" Visible="False"></asp:Label> 
                </center>
        
        <div class="clear_br">
            <br />
        </div>
       



    </asp:Panel>

    <asp:HiddenField ID="hftype" runat="server" />    
</asp:Content>

