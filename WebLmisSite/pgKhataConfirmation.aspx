<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgKhataConfirmation.aspx.cs" Inherits="pgKhataConfirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script type="text/javascript">
         function CheckOne(obj) {
             var grid = obj.parentNode.parentNode.parentNode;
             var inputs = grid.getElementsByTagName("input");
             for (var i = 0; i < inputs.length; i++) {
                 if (inputs[i].type == "checkbox") {
                     if (obj.checked && inputs[i] != obj && inputs[i].checked) {
                         inputs[i].checked = false;
                     }
                 }
             }


         }

            function confirm_confirm()
            {
                if (!confirm('निवडलेल्या सदर गावाचे संपुर्ण खाता मास्टरचे काम योग्यरीत्या पुर्ण झाले आहे याची खात्री केली आहे का ?.\nसंपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्वाही द्यावयाची असल्यास OK क्लिक करा.\nसंपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्वाही द्यावयाची नसल्यास Cancel क्लिक करा.'))
                {
                    var confirm_value = document.createElement("INPUT");
                    confirm_value.type = "hidden";
                    confirm_value.name = "confirm_value";
                    confirm_value.value = "notOk";
                    document.forms[0].appendChild(confirm_value);
                    return false;
                }
            }
      
    </script>

           <asp:Panel ID="pnlKhataNoConfirmation" runat="server" Height="150px" ScrollBars="Vertical">
                        <asp:GridView ID="gdvKhataNoConfirmation" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            OnRowCommand="gdvKhataNoConfirmation_RowCommand" 
                            BorderWidth="1px" OnRowEditing="gdvKhataNoConfirmation_RowEditing" TabIndex="3" CssClass="grid"
                            meta:resourcekey="gdvCertifyResource1" OnRowDataBound="gdvKhataNoConfirmation_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="निवडा" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"
                                            onclick="CheckOne(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="checklist" meta:resourcekey="TemplateFieldResource1"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnchecklist" runat="server" Text="check" CommandName="select" meta:resourcekey="btnchecklistResource1" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 
                                 <asp:TemplateField HeaderText="खाता क्रमांक" meta:resourcekey="TemplateFieldResource14">
                                    <ItemTemplate>
                                        <asp:Label ID="lblkhataNo" runat="server" Text='<%# Eval("khata_no") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumn0Resource1"></asp:Label>
                                    </ItemTemplate> 
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="दुरुस्त्या पहा" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnRpt" runat="server" CommandName="oldnewrpt" Text="दुरुस्त्या पहा"
                                              CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" OnClick="btnRpt_Click"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   
                                <asp:TemplateField HeaderText="खाता मास्टरची दुरुस्त/अद्यावत केलेली माहिती कायम करणे " meta:resourcekey="TemplateFieldResource3">
                                    <ItemTemplate>
                                        <asp:Button ID="btnConfirm" runat="server" CommandName="select" Text="कायम करणे" Enabled="false"
                                            CssClass="form_lbl" meta:resourcekey="button1Resource1" OnClick="btnConfirm_Click" ></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                
                                
                               
                               
                                
                            </Columns>
                            <FooterStyle CssClass="gridfooter" />
                            <PagerStyle CssClass="gridpager" />
                            <SelectedRowStyle CssClass="gridselectdrow" BackColor="#FF80FF" BorderColor="#400000" />
                            <HeaderStyle CssClass="gridheader1" />
                            <RowStyle CssClass="gridrow" />
                        </asp:GridView>
                        <br />

                        <asp:Repeater ID="rptPager" runat="server" >
                                <ItemTemplate>
                                    <asp:LinkButton  Font-Size="Large"  ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>

                            <br />
                       </asp:Panel>
                    <br />

    <div class="row">
        <center >
        <asp:Button ID="btnKPWorkCompletion" runat="server" Text="खात्यांची दुरुस्ती पुर्ण झाल्याचे ग्राम महसूल अधिकारी स्वयं घोषणा करणे" Font-Names="sakal marathi" TabIndex="1" ToolTip="खात्यांची दुरुस्ती पुर्ण झाल्याचे ग्राम महसूल अधिकारी स्वयं घोषणा करण्यासाठी येथे क्लिक करा." OnClick="btnKPWorkCompletion_Click" Visible="False"/>
        &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" CausesValidation="False" CssClass="form_lbl" EnableViewState="False" Font-Names="Sakal Marathi" OnClick="btnBack_Click" TabIndex="4" Text="मागे जा" /> 
        </center>
    </div>
</asp:Content>

