<%@ Page Title="चुकीने निवडलेले परंतु दुरुस्त्या न केलेले सर्व्हे क्रमांक/गट क्रमांक काढुन टाकणे" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgEditSurveyRelease.aspx.cs" Inherits="pgEditSurveyRelease" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
  <div >
                            <asp:Panel ID="pnl12Confirm" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="143px" Width="100%">
                                
                                <asp:GridView ID="gdvEditRemove" runat="server" BorderWidth="1px" CssClass="grid"
                                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" UseAccessibleHeader="False">

                    
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblnivda" runat="server" Text="निवडा" CssClass="form_lbl"></asp:Label>
                                                <asp:CheckBox ID="chkSelectAll" runat="server"  Visible="true"
                                                    AutoPostBack="True" OnCheckedChanged="chkSelectAll_CheckedChanged"  />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkselect" runat="server" ToolTip="<%# ((GridViewRow)Container).RowIndex %>" OnCheckedChanged="chkselect_CheckedChanged"  />
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText=" सर्व्हे/गट क्रमांक">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("surveyno") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("surveyno") %>' Visible="false"
                                                    CssClass="form_txt_85"> </asp:TextBox>
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
                        <br/>
    <div class="row">
    <CENTER><asp:Button id="btnSave"  runat="server" Text=" माहिती साठवा " CssClass="form_lbl" ToolTip="डाटा एन्ट्री मॉड्युल द्वारे दुरुस्तीसाठी चुकीने निवडलेले परंतु दुरुस्त्या न केलेले अथवा दुरुस्त्या न साठविल्या सर्व्हे क्रमांक /गट क्रमांक काढण्यासाठी येथे क्लिक करा." Enabled="False" OnClick="btnSave_Click"></asp:Button>
                       
                         <asp:Button ID="btnback" runat="server" Text="मागे जा"
                                CssClass="form_lbl" ToolTip="मागे जा" OnClick="btnback_Click" Visible="False"  ></asp:Button> 
                          <div class="clear_br">
                          </div>
                      </CENTER>
        </div>
</asp:Content>

