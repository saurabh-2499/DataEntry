<%@ Page Title="खाता प्रोसेसिंग साठी निवडुन केलेल्या दुरुस्त्याची माहिती खाता मास्टर प्रमाणे पुर्ववत करणे" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgKhataNoDataDiscrCorrection.aspx.cs" Inherits="pgKhataNoDataDiscrCorrection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="clear">
      
    </div>
    <div class="row">
        &nbsp;<asp:Label ID="lblkhataNo" runat="server" Text="खाता क्रमांक : " ForeColor="Purple" Font-Names="sakal marathi"  Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtKhataNo" runat="server" Font-Names="sakal Marathi" TabIndex="0" OnTextChanged="txtKhataNo_TextChanged"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ErrorMessage="कृपया योग्य अंक भरा. अक्षर / स्पेस नको."  ValidationGroup="otherrightsgroup"  ControlToValidate="txtKhataNo" CssClass="form_lbl_red_s" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
        <asp:Button ID="btnKhataNo" runat="server" Text="खाता क्रमांक शोधा" Font-Names="sakal marathi" TabIndex="1" ToolTip="खाता क्रमांक शोधण्यासाठी येथे क्लिक करा." OnClick="btnKhataNo_Click"/> &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnCancel" runat="server" Text=" रद्द करा" Font-Names="sakal marathi" TabIndex="2" ToolTip="रद्द करण्यासाठी येथे क्लिक करा." Visible="false" OnClick="btnCancel_Click" /> &nbsp; &nbsp; &nbsp; &nbsp;
    </div>

    <div class="clear">
    </div>

     <div class="row">
        &nbsp;<asp:Label ID="lblSlectedKhataNo" runat="server" Text="निवडलेला खाता क्रमांक : " ForeColor="Purple" Font-Names="sakal marathi" Font-Bold="true" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblSelectedkhataNoDisp" runat="server" Text=""  Font-Names="sakal marathi"  Font-Bold="true"  Visible="false" CssClass="form_header_txt"></asp:Label>
    </div>
    <div class="clear">
        <br />
    </div>

    <div class="row">

    </div>
    <asp:Label ID="lblOriginalKhataMaster" runat="server" Text="सध्य स्थितीत खाता मास्टरची माहिती :- " ForeColor="Purple" Font-Names="sakal marathi" Font-Bold="true" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <div >
                            <asp:Panel ID="pnlkhataDetails" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="120px" Width="100%" Visible="false">
                                
                                <asp:GridView ID="gdvkhataDetails" runat="server" BorderWidth="1px" CssClass="grid"
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
         <asp:Label ID="lblProcessingData" runat="server" Text="खाता प्रोसेसिंगसाठी निवडुन केलेल्या दुरुस्त्यांसह  खाता मास्टरची माहिती :- " ForeColor="Purple" Font-Names="sakal marathi" Font-Bold="true" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>

    <div>
       <asp:Panel ID="pnlProcessing" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="120px" Width="100%" Visible="false">
                                
                                <asp:GridView ID="gdvProcessData" runat="server" BorderWidth="1px" CssClass="grid"
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
        <asp:Button ID="btnSave" runat="server" Text="खाता प्रोसेसिंग साठी निवडुन केलेल्या दुरुस्त्याची माहिती खाता मास्टर प्रमाणे पुर्ववत करणे" Font-Names="sakal marathi" TabIndex="1" ToolTip="खाता प्रोसेसिंग साठी निवडुन केलेल्या दुरुस्त्याची माहिती खाता मास्टर प्रमाणे पुर्ववत करण्यासाठी येथे क्लिक करा." OnClick="btnSave_Click" Enabled="false" /> &nbsp; &nbsp; &nbsp; &nbsp;
          <asp:Button ID="btnCan" runat="server" Text="रद्द करा" Font-Names="sakal marathi" TabIndex="1" ToolTip="रद्द करण्यासाठी येथे क्लिक करा." OnClick="btnCan_Click"  />  
             </center>
    </div>
</asp:Content>

