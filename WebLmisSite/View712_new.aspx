<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="View712_new.aspx.cs" Inherits="View712_new" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<%@ OutputCache Location="None" VaryByParam="None" %>--%>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
     <script type="text/javascript">
         function confirm_survey() {
             if (document.getElementById('ctl00_ContentPlaceHolder1_txtsurvey').value == "") {
                 alert(' सर्व्हे क्रमांक भरा ');
                 return false;
             }

         }

         </script>

    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <body>
   
        <div>
            <br />
            <asp:Panel ID="Panel8" runat="server" CssClass="all_pnl95">
           
                     <div class="row">
                <br /> <center>
                    <div class="column_margin5p ">
                        <asp:Label ID="Label24" runat="server" CssClass="form_lbl">गाव : </asp:Label>
                    </div>
                    <div class="column_10per_womargin">
                        <asp:DropDownList ID="ddlVillage" runat="server" Width="100px" OnSelectedIndexChanged="ddlVillage_SelectedIndexChanged" AutoPostBack="True"  >
                        </asp:DropDownList><br /><br />   <asp:RequiredFieldValidator ID="rfvddlmut" runat="server" ControlToValidate="ddlVillage" InitialValue="--निवडा--" SetFocusOnError="true"
                                                    CssClass="form_lbl" ErrorMessage="गाव निवडा...!!!" ValidationGroup="Valid" ></asp:RequiredFieldValidator>
                    </div>
                  
                   
                    <div class="column_10per_womargin" style="text-align:left;">
                        <asp:RadioButtonList ID="rblSearch" runat="server" Width="136px">
                            <asp:ListItem Value="1" Selected="True">सर्व्हे क्र.</asp:ListItem>
                            <asp:ListItem Value="2">खाता क्र.</asp:ListItem>
                            <asp:ListItem Value="3">पहिले नाव</asp:ListItem>
                            <asp:ListItem Value="4">मधील नाव</asp:ListItem>
                            <asp:ListItem Value="5">आडनाव</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div class="column_10per_womargin">
                        <asp:TextBox ID="txtsurvey" runat="server" TabIndex="18" CssClass="form_txt" MaxLength="20" CausesValidation="True" Width="90px"
                            ToolTip="कृपया सर्व्हे क्रमांक टाका"></asp:TextBox>
                    </div>
                    <div class="column_adjs">
                        <asp:Button ID="btnSearchSurveyNo" Text="सर्व्हे क्र. शोधा" runat="server" OnClick="btnSearchSurveyNo_Click" OnClientClick="return confirm_survey();" ValidationGroup="Valid"
                            ToolTip="सर्वे क्र. शोधा" TabIndex="19" CssClass="form_lbl" /><br /><asp:Button ID="Button2" runat="server" CssClass="form_lbl" OnClick="Button2_Click" OnClientClick="return confirm_survey();"
                            TabIndex="19" Text=" अक्षरी ७/१२ सर्व्हे क्र. शोधा" ToolTip=" अक्षरी ७/१२ सर्व्हे क्र. शोधा" ValidationGroup="Valid" /></div>
                        <br/><br /><br />
                        
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="form_lbl" Height="1px" RepeatDirection="Horizontal" Width="650px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                            <asp:ListItem Value="0" Selected="True"> पीक पहाणी केलेल्या शेवटच्या ३ वर्षांचा डाटा</asp:ListItem>
                            <asp:ListItem  Value="1"> पीक पहाणी केलेल्या फक्त शेवटच्या वर्षाचा डाटा</asp:ListItem>
                        </asp:RadioButtonList>

                       <asp:Button ID="Button3" Text="७/१२ पहा" runat="server" ToolTip="७/१२ पाहणे" 
                            TabIndex="21" CssClass="form_lbl" OnClick="btnShow712New_Click" Visible="False" /></center>
                   
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
                <div class="clear_br">
                    <br />
                </div>
                      <center>
                     <asp:Panel ID="panelpins" runat="server" BorderWidth="1px" Width="700px"  ><div class="clear_br">
                    <br /></div>  <asp:Label id="lblsub" runat="server" CssClass="form_lbl">उपविभाग :</asp:Label>&nbsp;
                        <asp:TextBox ID="txtpin1" runat="server" TabIndex="5" Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                    
                        <asp:TextBox ID="txtpin2" runat="server" TabIndex="5" Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                    
                        <asp:TextBox ID="txtpin3" runat="server" TabIndex="5"  Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                    
                        <asp:TextBox ID="txtpin4" runat="server" TabIndex="5"  Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                   
               
                
                        <asp:TextBox ID="txtpin5" runat="server" TabIndex="5"  Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                   
                        <asp:TextBox ID="txtpin6" runat="server" TabIndex="5"  Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                   
                        <asp:TextBox ID="txtpin7" runat="server" TabIndex="5"  Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                   
                        <asp:TextBox ID="txtpin8" runat="server" TabIndex="5" Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox><div class="clear_br">
                    <br />
                </div>
                   </asp:Panel></center>
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
                <br />
              
                
                          <asp:Button ID="btnShow712" Text="७/१२ पाहणे (Old)" runat="server" OnClick="btnShow712_Click"
                            ToolTip="७/१२ पाहणे" TabIndex="21" CssClass="form_lbl" Visible="False" />
                        <center> <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                            <asp:Button ID="Button4" runat="server" CssClass="form_lbl" OnClick="btnShow712New_Click" TabIndex="21" Text="७/१२ पहा" ToolTip="७/१२ पाहणे" Visible="False" />
                            <asp:Button ID="Button1" runat="server" CssClass="form_lbl" OnClick="Button1_Click" TabIndex="21" Text="मागे जा" ToolTip="मागे जा" />
                     </center>
                    
                    <br />
                    
            </asp:Panel>
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"></asp:UpdatePanel>
    
</body>
</html>
</asp:Content>

