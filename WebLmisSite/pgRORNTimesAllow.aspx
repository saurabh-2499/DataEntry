<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgRORNTimesAllow.aspx.cs" Inherits="pgRORNTimesAllow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <body>
   
        <div>
            <br />
            <asp:Panel ID="Panel8" runat="server" CssClass="all_pnl95">
           
                     <div class="row">
                <br /> <center>
                    
                  
                   
                    <div class="column_10per_womargin" style="text-align:left;">
                        <asp:Label ID="lblSurvey" runat="server" CssClass="form_lbl">सर्व्हे क्रमांक : </asp:Label>
                       
                    </div>
                    <div class="column_10per_womargin">
                        <asp:TextBox ID="txtsurvey" runat="server" TabIndex="18" CssClass="form_txt" MaxLength="20" CausesValidation="True" Width="90px"
                            ToolTip="कृपया सर्व्हे क्रमांक टाका"></asp:TextBox>
                    </div>
                    <div class="column_adjs">
                        <asp:Button ID="btnSearchSurveyNo" Text="सर्व्हे क्रमांक शोधा" runat="server" OnClick="btnSearchSurveyNo_Click" OnClientClick="return confirm_survey();" ValidationGroup="Valid"
                            ToolTip="सर्वे क्रमांक शोधा" TabIndex="19" CssClass="form_lbl" /></div>

                     <div class="column_adjs" style="text-align:left;">
                        <asp:Label ID="Label1" runat="server" CssClass="form_lbl">निवडलेला सर्व्हे क्रमांक : </asp:Label> &nbsp;
                        
                    </div>
                    <div class="column_10per_womargin">
                       <asp:Label ID="LblSurveyNO" runat="server" CssClass="form_lbl"></asp:Label>
                    </div>
                        <br/><br /><br />
                        


                        


                       </center>
                   
                    <div class="column_womargin">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtsurvey"
                            ErrorMessage="enter number only" ValidationExpression="[0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]"
                            ValidationGroup="a" Visible="False" CssClass="form_lbl"></asp:RegularExpressionValidator>
                    </div>
                    <div class="column_a">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmutno"
                            ErrorMessage="enter number only" ValidationExpression="[0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]"
                            CssClass="form_lbl" ValidationGroup="a" Visible="False"></asp:RegularExpressionValidator>
                        &nbsp;</div>
                </div>

                <br />
                <asp:GridView ID="gdvSurveySearch" runat="server" AutoGenerateColumns="False" CellPadding="1"
                    CssClass="grid" OnSelectedIndexChanging="gdvSurveySearch_SelectedIndexChanging"
                    BorderStyle="None" BorderWidth="1px" CellSpacing="3">
                    <FooterStyle />
                    <RowStyle />
                    <PagerStyle VerticalAlign="Top" />
                    <SelectedRowStyle />
                    <HeaderStyle VerticalAlign="Top" />
                    <Columns>
                        <asp:TemplateField HeaderText="सर्वे क्रमांक निवडणे.">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkselect" runat="server" CommandName="Select" Enabled="true"
                                    CssClass="form_lbl" Text="सर्वे क्रमांक निवडणे."></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="सर्व्हे क्रमांक">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn" runat="server" Enabled="true" Text='<%# Eval("pin") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn1" runat="server" Enabled="true" Text='<%# Eval("pin1") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("pin2") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("pin3") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("pin4") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("pin5") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn6" runat="server" Enabled="true" Text='<%# Eval("pin6") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn7" runat="server" Enabled="true" Text='<%# Eval("pin7") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn8" runat="server" Enabled="true" Text='<%# Eval("pin8") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="gridfooter" />
                    <PagerStyle CssClass="gridpager" />
                    <SelectedRowStyle CssClass="gridselectdrow" />
                    <HeaderStyle CssClass="gridheader" />
                    <RowStyle CssClass="gridrow" />
                </asp:GridView>
                <br />
                         
                        <center> <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label></center>
                         <center><asp:Button ID="btnShow712New" Text="सर्वे क्रमांक उपलब्ध करणे " runat="server" ToolTip="सर्वे क्रमांक उपलब्ध करणे"
                            TabIndex="21" CssClass="form_lbl" OnClick="btnShow712New_Click" Visible="true" Height="26px" />
                              &nbsp;&nbsp;<asp:Button ID="Button1" Text="मागे जा" runat="server" ToolTip="मागे जा"
                            TabIndex="21" CssClass="form_lbl" OnClick="Button1_Click"  />
                         </center>                    
                    <br />
                    
            </asp:Panel>
        </div>
    
</body>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server"> </asp:UpdatePanel>

</asp:Content>

