<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgNew712AddEntry.aspx.cs" Inherits="pgNew712AddEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <br />
    <div class="row">
      
                         <asp:Panel ID="panelpins" runat="server" Visible="true" BorderWidth="1px" Width="1200px" ScrollBars="Auto">
                                <div class="clear_br"></div>
                                &nbsp;<asp:Label ID="lblSurvey" runat="server" CssClass="form_lbl">सर्व्हे क्रमांक</asp:Label>&nbsp;
                      <asp:TextBox ID="txtsurvey" TabIndex="16" runat="server" Width="50px" ToolTip="कृपया सर्व्हे क्रमांक टाका" CausesValidation="True" MaxLength="20" AutoPostBack="True" OnTextChanged="txtsurvey_TextChanged"></asp:TextBox><div class="clear_br"></div>&nbsp; 
                      
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtsurvey" Display="None"
                        CssClass="form_lbl" ErrorMessage="सर्व्हे क्रमांक टाका...!!!" SetFocusOnError="false" ValidationGroup="Valid"></asp:RequiredFieldValidator>
                                <asp:Label ID="lblsub" runat="server" CssClass="form_lbl">उपविभाग</asp:Label>&nbsp;&nbsp;&nbsp;
                         <asp:TextBox ID="txtpin1" runat="server" TabIndex="5" Visible="true" Width="30px" AutoPostBack="True" Enabled="False" OnTextChanged="txtpin1_TextChanged"></asp:TextBox>
                                &nbsp;
                    <asp:TextBox ID="txtpin2" runat="server"  TabIndex="5" Visible="true" Width="30px" AutoPostBack="True" Enabled="False" OnTextChanged="txtpin2_TextChanged"></asp:TextBox>
                                &nbsp;
                    <asp:TextBox ID="txtpin3" runat="server"  TabIndex="5" Visible="true" Width="30px" AutoPostBack="True" Enabled="False" OnTextChanged="txtpin3_TextChanged"></asp:TextBox>
                                &nbsp;
                    <asp:TextBox ID="txtpin4" runat="server"  TabIndex="5" Visible="true" Width="30px" AutoPostBack="True" Enabled="False" OnTextChanged="txtpin4_TextChanged"></asp:TextBox>
                                &nbsp;
                    <asp:TextBox ID="txtpin5" runat="server"  TabIndex="5" Visible="true" Width="30px" AutoPostBack="True" Enabled="False" OnTextChanged="txtpin5_TextChanged"></asp:TextBox>
                                &nbsp;
                    <asp:TextBox ID="txtpin6" runat="server"  TabIndex="5" Visible="true" Width="30px" AutoPostBack="True" Enabled="False" OnTextChanged="txtpin6_TextChanged"></asp:TextBox>
                                &nbsp;
                    <asp:TextBox ID="txtpin7" runat="server"  TabIndex="5" Visible="true" Width="30px" AutoPostBack="True" Enabled="False" OnTextChanged="txtpin7_TextChanged"></asp:TextBox>
                                &nbsp;
                    <asp:TextBox ID="txtpin8" runat="server"  TabIndex="5" Visible="true" Width="30px" AutoPostBack="True" Enabled="False" OnTextChanged="txtpin8_TextChanged"></asp:TextBox>
                                 &nbsp; <asp:Button ID="btnGo" runat="server" Text=" पुढे जा" OnClick="btnGo_Click" Enabled="False" />
                                <div class="clear_br"> </div>
                    
                        

                             <div class="row">
                                 <center>
                                 <asp:Button ID="btnSave" runat="server" Text="साठवा" OnClick="btnSave_Click" Enabled="False" ToolTip="साठवा करण्यासाठी येथे क्लिक करा ." /> &nbsp;&nbsp;
                                 <asp:Button ID="btnCancel" runat="server" Text="रद्द करा" OnClick="btnCancel_Click" Enabled="False" ToolTip="रद्द करण्यासाठी येथे क्लिक करा ." />
                                     </center>
                             </div>
                             <br />

                              

                            </asp:Panel>
           
                       
    </div>

</asp:Content>

