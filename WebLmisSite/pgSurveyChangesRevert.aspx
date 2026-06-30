<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgSurveyChangesRevert.aspx.cs" Inherits="pgSurveyChangesRevert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="clear">

    </div>

      <div class="column_10per_womargin" style="text-align:left;">
                        
                        
                        <asp:Label ID="Label3" runat="server" CssClass="form_lbl" Text="सर्व्हे क्र. :"></asp:Label>
                    </div>
                    <div class="column_10per_womargin">
                        <asp:TextBox ID="txtsurvey" runat="server" TabIndex="18" CssClass="form_txt" MaxLength="20" CausesValidation="True" Width="90px"
                            ToolTip="कृपया सर्व्हे क्रमांक टाका"></asp:TextBox>
                    </div>
                    <div class="column_adjs">
                        <asp:Button ID="btnSearchSurveyNo" Text="सर्व्हे क्र. शोधा" runat="server" OnClick="btnSearchSurveyNo_Click" ValidationGroup="Valid"
                            ToolTip="सर्वे क्र. शोधा" TabIndex="19" CssClass="form_lbl" /></div>

                     <div class="column_adjs">
                          <asp:Button ID="Button2" runat="server" CssClass="form_lbl" OnClick="Button2_Click" OnClientClick="return confirm_survey();"
                            TabIndex="19" Text=" अक्षरी सर्व्हे क्र. शोधा" ToolTip=" अक्षरी सर्व्हे क्र. शोधा" ValidationGroup="Valid" Width="162px" /></div>

     <div class="column_womargin">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtsurvey"
                            ErrorMessage="enter number only" ValidationExpression="[0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]"
                            ValidationGroup="a" Visible="False" CssClass="form_lbl"></asp:RegularExpressionValidator>
                    </div>

      <asp:GridView ID="gdvSurveySearch" runat="server" AutoGenerateColumns="False" CellPadding="1"
                    CssClass="grid" OnSelectedIndexChanging="gdvSurveySearch_SelectedIndexChanging"
                    BorderStyle="None" BorderWidth="1px" CellSpacing="3">
                    <FooterStyle />
                    <RowStyle />
                    <PagerStyle VerticalAlign="Top" />
                    <SelectedRowStyle />
                    <HeaderStyle VerticalAlign="Top" />
                    <Columns>
                        <asp:TemplateField HeaderText="निवडा">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkselect" runat="server" CommandName="Select" Enabled="true"
                                    CssClass="form_lbl" Text="निवडा"></asp:LinkButton>
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

    <div class="clear">

    </div>
   
    
    <div class="row" >
         <asp:Label ID="lblSurveySelected" runat="server" CssClass="form_lbl" Text="निवडलेला सर्व्हे क्र.:" ForeColor="Purple" Visible="False"></asp:Label> &nbsp;&nbsp;<asp:Label ID="lblSurveySelectedDisplay" runat="server" CssClass="form_lbl"></asp:Label>

    </div>
    <asp:Label ID="lblOriginalKhataMaster" runat="server" Text="सध्य स्थितीत सर्व्हे क्र.ची माहिती :- " ForeColor="Purple" Font-Names="sakal marathi" Font-Bold="true" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <div >
                            <asp:Panel ID="pnlkhataDetails" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="120px" Width="100%" Visible="false">
                                
                                <asp:GridView ID="gdvSurveyDetails" runat="server" BorderWidth="1px" CssClass="grid"
                                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" UseAccessibleHeader="False" >
                    
                                    <Columns >
                                        
                                        <asp:TemplateField HeaderText="पहिले नाव        ">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले  नाव        ">
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

                                         <asp:TemplateField HeaderText="  क्षेत्र               ">
                               
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn6" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("seller_area_tot") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text6" runat="server" AutoPostBack="True" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("seller_area_tot") %>' ToolTip="<%#((GridViewRow)Container).RowIndex %>" Visible="False"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="आकारणी">
                                <HeaderTemplate>
                                  
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn7" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("na_assessment") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text7" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("na_assessment") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="आणे              ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn8" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("anne") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text8" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("anne") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" पै                 ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn9" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pai") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text9" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("pai") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" पोट. ख.                ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn11" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("potkharaba") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text11" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("potkharaba") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" पोट. ख.                " Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn13" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("tenure_code") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text13" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("tenure_code") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" फेरफार क्रमांक               ">
                                <ItemTemplate>
                                    <asp:Label ID="lblmutno" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("mut_no") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2textmutno" runat="server" CssClass="form_txt_85" Text='<%# Eval("mut_no") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
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
    <div class="clear">
        <br />
    </div>

    <div class="row"> 
         <asp:Label ID="lblProcessingData" runat="server" Text="दुरुस्तीसाठी निवडुन केलेल्या दुरुस्त्यांसह सर्व्हे क्र. माहिती :- " ForeColor="Purple" Font-Names="sakal marathi" Font-Bold="true" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>

    <div>
       <asp:Panel ID="pnlProcessing" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="120px" Width="100%" Visible="false">
                                
                                <asp:GridView ID="gdvSurveyProcessData" runat="server" BorderWidth="1px" CssClass="grid"
                                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" UseAccessibleHeader="False" >
                    
                                    <Columns >
                                        
                                        <asp:TemplateField HeaderText="पहिले नाव        ">
                                            
                                            <ItemTemplate>
                                                <asp:Label ID="lblfname" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblmname" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lbllname" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="टोपण नाव           ">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltopan_name" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="  क्षेत्र               ">
                               
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn6" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("seller_area_tot") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text6" runat="server" AutoPostBack="True" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("seller_area_tot") %>' ToolTip="<%#((GridViewRow)Container).RowIndex %>" Visible="False"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="आकारणी">
                                <HeaderTemplate>
                                  
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn7" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("na_assessment") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text7" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("na_assessment") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="आणे              ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn8" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("anne") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text8" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("anne") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" पै                 ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn9" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pai") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text9" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("pai") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" पोट. ख.                ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn11" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("potkharaba") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text11" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("potkharaba") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" पोट. ख.                " Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn13" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("tenure_code") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text13" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("tenure_code") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" फेरफार क्रमांक               ">
                                <ItemTemplate>
                                    <asp:Label ID="lblmutno" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("mut_no") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2textmutno" runat="server" CssClass="form_txt_85" Text='<%# Eval("mut_no") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
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
    <div class="clear">

    </div>

    <div class="row">
        <center>
        <asp:Button ID="btnSave" runat="server" Text="दुरुस्तीसाठी सर्व्हे क्रमांक / गट क्रमांक निवडुन अद्यावत/दुरुस्त्या केलेली माहिती पुर्ववत करणे " Font-Names="sakal marathi" TabIndex="1" ToolTip="दुरुस्तीसाठी सर्व्हे क्रमांक / गट क्रमांक निवडुन अद्यावत/दुरुस्त्या केलेली माहिती पुर्ववत करण्यासाठी येथे क्लिक करा." OnClick="btnSave_Click" Enabled="false" /> &nbsp; &nbsp; &nbsp; &nbsp;
          <asp:Button ID="btnCan" runat="server" Text="रद्द करा" Font-Names="sakal marathi" TabIndex="1" ToolTip="रद्द करण्यासाठी येथे क्लिक करा." OnClick="btnCan_Click"  />  
             </center>
    </div>

</asp:Content>

