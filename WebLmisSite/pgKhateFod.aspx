<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgKhateFod.aspx.cs" Inherits="pgKhateFod" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
 <asp:Label ID="Label1" runat="server" Text="खाता क्रमांक :" Visible="true"   Font-Bold="True"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;
 <asp:TextBox ID="txtKhataNo" runat="server" ValidateRequestMode="Enabled" Font-Names="Sakal Marathi" OnTextChanged="txtKhataNo_TextChanged" TabIndex="1"></asp:TextBox>
      <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ErrorMessage="कृपया योग्य अंक भरा. अक्षर / स्पेस नको."  ValidationGroup="otherrightsgroup"  ControlToValidate="txtKhataNo" CssClass="form_lbl_red_s" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
    &nbsp;&nbsp;
    <asp:Button ID="btnsearch" runat="server" Text="खाते शोधा" OnClick="btnsearch_Click" TabIndex="2" />&nbsp;&nbsp;&nbsp;&nbsp;                       <asp:Button ID="btnView712" Text="७/१२ पहा" runat="server" ToolTip="७/१२ पाहणे" Visible="true" CssClass="form_lbl" OnClick="btnView712_Click"  /> <br />
    &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblerror" runat="server" ForeColor="Red"></asp:Label>
</div>

<br/>


    <div class=" row">
                        <asp:Label id="lblNote" runat="server" Text=" टिप: भोगवटदारांच्या नावासमोरील क्षेत्र, आकरणी, आणे, पै, पोटखराबा, नावांचा क्रम दुरुस्ती करुन खाते विभागणीसाठी नावे निवडावीत. <br/> " CssClass="form_lbl" Font-Bold="True" ForeColor="purple" Visible="false"></asp:Label>
                        &nbsp;</div>
                    <div class="clear_br"></div>
<div>
    
    <asp:GridView ID="gdvSurveySearch" runat="server" AutoGenerateColumns="False" CssClass="grid"  >
        <Columns>
            <asp:TemplateField HeaderText="निवडा">
                <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" runat="server" OnCheckedChanged="chkSelect_CheckedChanged" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" Width="10%" />
            </asp:TemplateField>
            
             <asp:TemplateField Visible="true" HeaderText="सर्व्हे क्रमांक">
                <ItemTemplate>
                    <asp:Label ID="lblPins" runat="server" CssClass="form_lbl" Text='<%# Eval("pins") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible="false" HeaderText="सर्व्हे क्रमांक">
                <ItemTemplate>
                    <asp:Label ID="lblPin" runat="server" CssClass="form_lbl" Text='<%# Eval("pin") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblPin1" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pin1") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" " Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblPin2" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pin2") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" " Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblPin3" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pin3") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" " Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblPin4" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pin4") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" " Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblPin5" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pin5") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" " Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblPin6" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pin6") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" " Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblPin7" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pin7") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" " Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblPin8" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pin8") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderTemplate>
                    फेरफार क्रमांक
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblMutNo" runat="server" Text='<%# Bind("mut_no") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Left" />
                <HeaderTemplate>
                    खातेदाराचे नाव
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblname" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible="False">
                <ItemStyle HorizontalAlign="Left" />
                <HeaderTemplate>
                    खातेदाराचे नाव
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblhash_name" runat="server" Text='<%# Bind("hash_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderTemplate>
                    क्षेत्र
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtTotalArea" runat="server" Text='<%# Bind("total_area_h") %>'  Font-Names="Sakal Marathi"
                        Width='50px'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderTemplate>
                    <asp:Button ID="btnakarni" runat="server" OnClick="btnakarni_Click" Text="आकारणी" /></HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtAssessment" runat="server" Text='<%# Bind("assessment") %>'  Font-Names="Sakal Marathi" Width='30px'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderTemplate>
                    आणे
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtAnne" runat="server" Text='<%# Bind("anne") %>'  Font-Names="Sakal Marathi" Width="30px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderTemplate>
                    पै
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtPai" runat="server" Text='<%# Bind("pai") %>'  Font-Names="Sakal Marathi" Width='30px'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderTemplate>
                    पोटखराबा
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtPotkharaba" runat="server" Text='<%# Bind("potkharaba") %>'  Font-Names="Sakal Marathi"  Width='50px'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderTemplate>
                    जुना खाता क्र. 
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblKhataNo" runat="server" Text='<%# Bind("khata_no") %>'  Font-Names="Sakal Marathi"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemStyle HorizontalAlign="Center" />
                <HeaderTemplate>
                  भोगवटदार क्र.
                </HeaderTemplate>
                <ItemTemplate>
                    <%--    <asp:Label ID="lblUserNo" runat="server" Text='<%# Bind("usrno") %>'></asp:Label>--%>
                    <asp:TextBox ID="txtUserNo" runat="server" Text='<%# Bind("usrno") %>'  Font-Names="Sakal Marathi" Width='30px'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="खाता प्रकार" Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("new_khata_type") %>'  Font-Names="Sakal Marathi"
                        Visible="true"></asp:Label>
                    <asp:DropDownList ID="drp_khata_type" runat="server" AutoPostBack="true" CssClass="form_drptxt"  Font-Names="Sakal Marathi"
                        Visible="false">
                        <asp:ListItem>---निवडा--</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField Visible="False">
                <ItemStyle HorizontalAlign="Center" />
                <HeaderTemplate>
                    नवीन खाता क्र.
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblNewKhataNo" runat="server" Text='<%# Bind("new_khata_no") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label ID="lblNewKhataNo" runat="server" Text='<%# Bind("new_khata_no") %>'></asp:Label>
                    <asp:TextBox ID="txtNewKhataNo" runat="server" Text='<%# Eval("new_khata_no") %>'
                        Visible="false" Width="60px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNewKhataNo" runat="server" ControlToValidate="txtNewKhataNo"
                        Display="None" ErrorMessage="<br/>खाता क्र.भरा" SetFocusOnError="true" ValidationGroup="gridupdate"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revNewKhataNo" runat="server" ControlToValidate="txtNewKhataNo"
                        Display="None" ErrorMessage="<br/>योग्य खाता क्र.भरा" SetFocusOnError="true"
                        ValidationExpression="^([0-9]{0,10})(\.[0-9]{0,2})?$" ValidationGroup="gridupdate"></asp:RegularExpressionValidator>
                </EditItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle CssClass="gridfooter" />
        <PagerStyle CssClass="gridpager" />
        <SelectedRowStyle CssClass="gridselectdrow" />
        <HeaderStyle CssClass="gridheader" />
        <RowStyle CssClass="gridrow" />
    </asp:GridView>
    &nbsp;</div>
    <br />

<div class="row">
    <asp:Label ID="Note" runat="server" Text="टिप: खाता विभागणीसाठी निवडलेल्या नावांचा खाता प्रकार निवडा."  CssClass="form_lbl" Font-Bold="True" ForeColor="purple" Visible="False"></asp:Label><br/>
    
    <asp:Label ID="lblKhataTypeDisp" runat="server" Text="खाता प्रकार :" Visible="False"   Font-Bold="True"></asp:Label>
    <asp:DropDownList ID="drp_khata_type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drp_khata_type_SelectedIndexChanged" Visible="False"  ToolTip="खाता विभागणीसाठी निवडलेल्या नावांचा खाता प्रकार निवडा.">
    </asp:DropDownList>
     <asp:Label ID="lbl_khata_type" runat="server" Visible="False" ForeColor="DarkViolet"></asp:Label>
    <br />
    
</div>
<div>
<asp:GridView ID="gdv_khata_no" runat="server" AutoGenerateColumns="False" 
            CssClass="grid" >
            <Columns>
            
          <%--  <asp:TemplateField HeaderText="निवडा">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                </asp:TemplateField>--%>
                
               <%-- <asp:TemplateField> 
                <ItemTemplate>
                   <asp:LinkButton ID="lnk_edit" runat="server" CommandName="Edit" Text="Sampadan"></asp:LinkButton>
                </ItemTemplate>
                <EditItemTemplate>
                 <asp:LinkButton ID="lnk_modify" runat="server" CommandName="Update" Text="Modify"></asp:LinkButton>
                  <asp:LinkButton ID="lnk_cancel" runat="server" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                </asp:TemplateField>--%>
                
                <asp:TemplateField Visible="true" HeaderText="सर्व्हे क्रमांक">
                <ItemTemplate>
                    <asp:Label ID="lblPins" runat="server" CssClass="form_lbl" Text='<%# Eval("pins") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
                
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPin" runat="server" Text='<%# Eval("khata_no") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPin1" runat="server" Enabled="true" Text='<%# Eval("pin1") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" " Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPin2" runat="server" Enabled="true" Text='<%# Eval("pin2") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" " Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPin3" runat="server" Enabled="true" Text='<%# Eval("pin3") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" " Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPin4" runat="server" Enabled="true" Text='<%# Eval("pin4") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" " Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPin5" runat="server" Enabled="true" Text='<%# Eval("pin5") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" " Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPin6" runat="server" Enabled="true" Text='<%# Eval("pin6") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" " Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPin7" runat="server" Enabled="true" Text='<%# Eval("pin7") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" " Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="lblPin8" runat="server" Enabled="true" Text='<%# Eval("pin8") %>'
                            CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        फेरफार क्रमांक
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblMutNo" runat="server" Text='<%# Bind("mut_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderTemplate>
                        खातेदाराचे नाव
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblname" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                   <asp:TemplateField Visible="false">
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderTemplate>
                        खातेदाराचे नाव
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblhashname" runat="server" Text='<%# Bind("hash_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        क्षेत्र
                    </HeaderTemplate>
                    <ItemTemplate>
                     <asp:Label ID="lblTotalArea" runat="server"  Text='<%# Bind("total_area_h") %>' CssClass="form_lbl"></asp:Label>
                       <%-- <asp:TextBox ID="txtTotalArea" runat="server" Text='<%# Bind("total_area_h") %>' Width='50px' Enabled="false"></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        आकारणी
                    </HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="lblAssessment" runat="server"  Text='<%# Bind("assessment") %>' CssClass="form_lbl"></asp:Label>
                       <%-- <asp:TextBox ID="txtAssessment" runat="server" Text='<%# Bind("assessment") %>' Width='30px' Enabled="false"></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        आणे
                    </HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="lblAnne" runat="server"  Text='<%# Bind("anne") %>' CssClass="form_lbl"></asp:Label>
                       <%-- <asp:TextBox ID="txtAnne" runat="server" Text='<%# Bind("anne") %>' Width="30px" Enabled="false"></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        पै
                    </HeaderTemplate>
                    <ItemTemplate >
                    <asp:Label ID="lblPai" runat="server"  Text='<%# Bind("pai") %>' CssClass="form_lbl"></asp:Label>
                       <%-- <asp:TextBox ID="txtPai" runat="server" Text='<%# Bind("pai") %>' Width='30px' Enabled="false"></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        पोटखराबा
                    </HeaderTemplate>
                    <ItemTemplate>
                     <asp:Label ID="lblPotkharaba" runat="server"  Text='<%# Bind("potkharaba") %>' CssClass="form_lbl"></asp:Label>
                      <%--  <asp:TextBox ID="txtPotkharaba" runat="server" Text='<%# Bind("potkharaba") %>'  Width='50px' Enabled="false"></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                
                 <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        जुना खाता क्र.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblKhataNo" runat="server" Text='<%# Bind("khata_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                  <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                      भोगवटदार क्र.
                    </HeaderTemplate>
                    <ItemTemplate>
                    <asp:Label ID="lblUserNo" runat="server" Text='<%# Bind("usrno") %>' CssClass="form_lbl"></asp:Label>
                       <%-- <asp:TextBox ID="txtUserNo" runat="server" Text='<%# Bind("usrno") %>' Width='30px'></asp:TextBox>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                
              <%--   <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Left" />
                    <HeaderTemplate>
                        Seller/Buyer.
                    </HeaderTemplate>
                    <ItemTemplate>
                       <%-- <asp:Label ID="lblKhataNo" runat="server" Text='<%# Bind("sell_buy") %>'></asp:Label>--%>
                        <%-- <asp:TextBox ID="txtSellBuy" runat="server" Text='<%# Bind("sell_buy") %>'></asp:TextBox>--%>
                       <%-- <asp:DropDownList ID="drpSellBuy" runat="server" AutoPostBack="True"  >
                            <asp:ListItem>निवडा</asp:ListItem>
                            <asp:ListItem>S</asp:ListItem>
                            <asp:ListItem>B</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>--%>
               
                
                   <asp:TemplateField HeaderText="खाता प्रकार" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblColumn2" runat="server" Visible="true" Enabled="true" Text='<%# Eval("new_khata_type") %>'></asp:Label>
                        <asp:DropDownList ID="drp_khata_type" runat="server" AutoPostBack="true"  
                            Visible="false" CssClass="form_drptxt"> 
                            <asp:ListItem>---निवडा--</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                
                <asp:TemplateField>
                    <ItemStyle HorizontalAlign="Center" />
                    <HeaderTemplate>
                        नवीन खाता क्र.
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNewKhataNo" runat="server" Text='<%# Bind("new_khata_no") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                      <asp:Label ID="lblNewKhataNo" runat="server" Text='<%# Bind("new_khata_no") %>'></asp:Label>
                        <asp:TextBox ID="txtNewKhataNo" Text='<%# Eval("new_khata_no") %>' runat="server"
                            Width="60px" Visible="false" />
                        <asp:RequiredFieldValidator ID="rfvNewKhataNo" runat="server" ErrorMessage="<br/>खाता क्र.भरा"
                            Display="None" SetFocusOnError="true" ControlToValidate="txtNewKhataNo" ValidationGroup="gridupdate"></asp:RequiredFieldValidator>
                        
                        <asp:RegularExpressionValidator ID="revNewKhataNo" runat="server" ErrorMessage="<br/>योग्य खाता क्र.भरा"
                            Display="None" SetFocusOnError="true" ControlToValidate="txtNewKhataNo" ValidationGroup="gridupdate"
                            ValidationExpression="^([0-9]{0,10})(\.[0-9]{0,2})?$"></asp:RegularExpressionValidator>
                        
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle CssClass="gridfooter" />
            <PagerStyle CssClass="gridpager" />
            <SelectedRowStyle CssClass="gridselectdrow" />
            <HeaderStyle CssClass="gridheader" />
            <RowStyle CssClass="gridrow" />
        </asp:GridView>
</div>
    <br />

<br />

<div class="row">
    <center>
    <asp:Button ID="btnSave" runat="server" Text="साठवा" OnClick="btnSave_Click" ToolTip="साठवा" Visible="False" Enabled="False" TabIndex="3" />&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button id="btnback" onclick="btnback_Click" runat="server" Text="मागे जा" CssClass="form_lbl" ToolTip="मागे जा" TabIndex="4" ></asp:Button>
    </center>
</div>

</asp:Content>

