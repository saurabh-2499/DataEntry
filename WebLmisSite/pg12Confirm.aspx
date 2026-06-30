<%@ Page  Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pg12Confirm.aspx.cs" Inherits="pg12Confirm" title="७/१२ वरील फक्त पीक पहाणी चे काम केलेले सर्व्हे/गट क्रमांक कन्फर्म करणे"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class ="row">
        <br/>
    </div>
    <br/>
  <div >
                            <asp:Panel ID="pnl12Confirm" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="143px" Width="100%">
                                
                                <asp:GridView ID="gdv12Confirm" runat="server" BorderWidth="1px" CssClass="grid"
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
    <CENTER><asp:Button id="btnConfirm"  runat="server" Text="कन्फर्म करणे" CssClass="form_lbl" ToolTip="निवडलेले सर्व्हे/गट क्रमांक ई-फेरफार साठी कन्फर्म(कायम करणे) करण्यासाठी येथे क्लिक करा." Enabled="False" OnClick="btnConfirm_Click"></asp:Button>
                       
                          <asp:Button ID="btnback" runat="server" Text="मागे जा"
                                CssClass="form_lbl" ToolTip="मागे जा" OnClick="btnback_Click" Visible="False"  ></asp:Button> 
                          <div class="clear_br">
                          </div>
                      </CENTER>
        </div>


</asp:Content>

