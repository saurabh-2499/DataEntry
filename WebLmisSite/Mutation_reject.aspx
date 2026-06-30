<%@ Page Title="समस्या निराकरण" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="Mutation_reject.aspx.cs" Inherits="Mutation_reject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row">
        &nbsp;<asp:Label ID="lblMutNo" runat="server" Text="फेरफार क्रमांक : " ForeColor="Purple" Font-Names="sakal marathi"  Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtMutNo" runat="server" Font-Names="sakal Marathi" TabIndex="0" OnTextChanged="txtKhataNo_TextChanged"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ErrorMessage="कृपया योग्य फेरफार क्रमांक भरा"  ValidationGroup="otherrightsgroup"  ControlToValidate="txtMutNo" CssClass="form_lbl_red_s" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
        <asp:Button ID="btnMutNo" runat="server" Text="फेरफार क्रमांक शोधा" Font-Names="sakal marathi" TabIndex="1" ToolTip="फेरफार क्रमांक शोधण्यासाठी येथे क्लिक करा." OnClick="btnMutNo_Click"/> &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:Button ID="btnCancel" runat="server" Text=" रद्द करा" Font-Names="sakal marathi" TabIndex="2" ToolTip="रद्द करण्यासाठी येथे क्लिक करा." Visible="false" OnClick="btnCancel_Click" /> &nbsp; &nbsp; &nbsp; &nbsp;
    </div>

    <div class="clear">
        <br />
    </div>
    <div class="row">
        &nbsp;<asp:Label ID="lblSlectedKhataNo" runat="server" Text="निवडलेला फेरफार क्रमांक : " ForeColor="Purple" Font-Names="sakal marathi" Font-Bold="true" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblSelectedkhataNoDisp" runat="server" Text=""  Font-Names="sakal marathi"  Font-Bold="true"  Visible="false" CssClass="form_header_txt"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblKhataType" runat="server" Text="खाता प्रकार : " ForeColor="Purple" Font-Names="sakal marathi"  Font-Bold="true"  Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblKhataTypeDisp" runat="server" Text="" CssClass="form_header_txt" Font-Names="sakal marathi"  Font-Bold="true"  Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblkhataNamesCnt" runat="server" Text="खातेदारांची संख्या : " ForeColor="Purple" Font-Names="sakal marathi"  Font-Bold="true"  Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblkhataNamesCntDisp" runat="server" Text="" CssClass="form_header_txt" Font-Names="sakal marathi"  Font-Bold="true"  Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblkhataNames" runat="server" Text="खातेदारांच्या नावांची माहिती खालील प्रमाणे : " ForeColor="Purple" Font-Names="sakal marathi"  Font-Bold="true"  Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <div class="clear">
        <br />
    </div>
    <div >
                            <asp:Panel ID="pnlkhataDetails" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="120px" Width="100%">
                                
                                <asp:GridView ID="gdvkhataDetails" runat="server" BorderWidth="1px" CssClass="grid"
                                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" UseAccessibleHeader="False">
                    
                                    <Columns>
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

 <div>
                     &nbsp;<asp:Label ID="lblKhataDelOnSurveySurveyListDispaly" runat="server" Text="निवडलेला खाता क्रमांक असलेल्या सर्व्हे क्रमांकांची यादी :" Visible="False"  ForeColor="Purple" Font-Names="sakal marathi" Font-Bold="true"></asp:Label>   <asp:Label ID="lblKhataOnSurveySurveyListDispVal" runat="server" Text=" " 
CssClass="form_header_txt" Font-Names="sakal marathi"  Font-Bold="true" ></asp:Label>
                            
                        </div>
                        <br/>
   <center><H1>
                 <asp:Label id="lnlLinkHead" runat="server" Text="खाता मास्टर ची माहिती दुरुस्त/अद्यावत करण्यासाठी खालील पर्याय उपलब्ध आहेत."   Font-Size="Large" ForeColor="Purple" Visible="False"></asp:Label></H1></center>
        <DIV  visible="false" >
            <BR />
                 <asp:Panel id="Panellinks" runat="server" Visible="false"  BorderWidth="1" Height="50px">
                 <CENTER>
                     <BR />
                     <asp:LinkButton id="lnkNameAdd" tabIndex=2  runat="server" CssClass="linkButton_btn" ToolTip="खात्यामध्ये नविन नावे समाविष्ट करण्यासाठी येथे क्लिक करा." OnClientClick="return confirm_Search();" Font-Underline="false" Font-Bold="true" OnClick="lnkNameAdd_Click" >नविन नावे समाविष्ट करणे</asp:LinkButton>&nbsp;
                 <asp:LinkButton id="lnkNameDelete" tabIndex=3  runat="server" CssClass="linkButton_btn" ToolTip="खात्यामधिल नावे काढण्यासाठी येथे क्लिक करा." OnClientClick="return confirm_Search();" Font-Underline="false" Font-Bold="true" OnClick="lnkNameDelete_Click" >नावे काढणे</asp:LinkButton>&nbsp;
                  <asp:LinkButton id="lnkNameSpellCorrection" tabIndex=4  runat="server" CssClass="linkButton_btn" ToolTip="खात्यामधिल नावांची स्पेलिंग दुरुस्ती करण्यासाठी येथे क्लिक करा." OnClientClick="bhogavat();" Font-Underline="false" Font-Bold="true" OnClick="lnkNameSpellCorrection_Click" >नावांची स्पेलिंग दुरुस्ती</asp:LinkButton>&nbsp; 
                     <asp:LinkButton id="lnkKhataType" tabIndex=5  runat="server" CssClass="linkButton_btn" ToolTip="खाता प्रकार बदलणे" OnClientClick="return confirm_Search();" Font-Underline="false" Font-Bold="true"  Visible="true" OnClick="lnkKhataType_Click">खाता प्रकार बदलणे</asp:LinkButton>&nbsp; &nbsp;
                     <asp:LinkButton ID="lnkKhataNoDeletionSurveyWise" runat="server" CssClass="linkButton_btn" OnClick="lnkKhataNoDeletionSurveyWise_Click" TabIndex="3" ToolTip="खाता क्रमांक निवडक सर्व्हे / गट क्रमांकावरुन वगळणे">खाता क्रमांक निवडक सर्व्हे / गट क्रमांकावरुन वगळणे
                     </asp:LinkButton>
                     &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnKhataConfirm" runat="server" Font-Names="Sakal Marathi" OnClick="btnKhataConfirm_Click" text="खाता मास्टरची दुरुस्त/अद्यावत केलेली माहिती कायम करणे"  tooltip="खाता मास्टरची दुरुस्त/अद्यावत केलेली माहिती कायम करण्यासाठी येथे क्लिक करा." TabIndex="3"/>
                     <br />
                     </CENTER></asp:Panel>
<BR /></DIV>

    
    
    <div id="divpopup_NameAdd" class="ontop"></div>
     <asp:Panel ID="pnlNameAdd" runat="server" Visible="false" CssClass="popupPnl_holderhakkden" BackColor="#EFEFEF" >
          <div class="clear_br">

                        </div>
<CENTER><asp:Label id="Label8" runat="server" Text="नविन नावे समाविष्ट करणे"  Font-Bold="True" CssClass="form_lblhead"></asp:Label></CENTER>
 <div class="clear_br">

                        </div>
         <div class="row">
             <br/>
              &nbsp;<asp:Label ID="Label3" runat="server" CssClass="form_lbl" Text="खाता क्रमांक :-" Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="Label1" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="Label4" runat="server" CssClass="form_lbl" Text="मुळ खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypeold" runat="server" ForeColor="#FF3300" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="Label5" runat="server" Text="नविन नाव समाविष्ट केल्यानंतर खात्याचा खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"  ></asp:Label>
              <asp:DropDownList ID="ddlkhatatype" runat="server" CssClass="form_drptxt" OnSelectedIndexChanged="ddlkhatatype_SelectedIndexChanged" Font-Names="Sakal Marathi" AutoPostBack="True"> </asp:DropDownList>
              <asp:Label ID="lblSelectedKhatatype" runat="server" Text="निवडलेला खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi" Visible="False"  ></asp:Label>
              <asp:Label ID="lblnewKhataType" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
         </div>

		  <div class="clear_br">
            
          </div>

          <asp:Panel ID="Panel3" runat="server" height="145px" ScrollBars="Vertical" CssClass="bs_pnl"  Width="100%">
            <hr style="margin-top: 0px" />
            <asp:GridView ID="gvKhataOwners" runat="server" AutoGenerateColumns="False" TabIndex="3" CssClass="grid" ShowHeaderWhenEmpty="True" >
                <PagerSettings FirstPageText="First" LastPageText="Last"  />
                <Columns>
                  
                    <asp:TemplateField HeaderText="खाता क्रमांक">
                        <ItemTemplate>
                            <asp:Label ID="lblkhata_no" runat="server" Text='<%# Bind("khata_no") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="पहिले नांव">
                        <ItemTemplate>
                            <asp:Label ID="lblfname" runat="server" Text='<%# Bind("fname") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="मधले नांव">
                        <ItemTemplate>
                            <asp:Label ID="lblmname" runat="server" Text='<%# Bind("mname") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="आडनांव">
                        <ItemTemplate>
                            <asp:Label ID="lbllname" runat="server" Text='<%# Bind("lname") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="टोपण नांव ">
                        <ItemTemplate>
                            <asp:Label ID="lbltopan_name" runat="server" Text='<%# Bind("topan_name") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="खाता प्रकार " Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblkhatatype" runat="server" Text='<%# Bind("khata_description") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="gridfooter" />
                <PagerStyle CssClass="gridpager" />
                <SelectedRowStyle CssClass="gridselectdrow" /> 
                <HeaderStyle CssClass="gridheader1" />
                <RowStyle CssClass="gridrow" />
            </asp:GridView>



        </asp:Panel>

         <div class ="row">

               &nbsp;<asp:Label ID="lblSurvey" runat="server" Text=" परिणाम होणारे सर्व्हे क्रमांक :-" Font-Names="Sakal Marathi"></asp:Label> &nbsp;&nbsp;
              <asp:Label ID="lblSurveyList" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
         </div>

         <br />

        
 

		

            

            <div class="row">
            <div class="column_s_wid40">
                <asp:Label ID="lblselected" runat="server" CssClass="form_lbl" Font-Bold="True" ForeColor="Aqua" BackColor="Orange" Visible="false"></asp:Label>
            </div>
        </div>

            <asp:panel ID="pnlWarasNames" runat="server" ScrollBars="Vertical" CssClass="bs_pnl" Height="150px" Width="100%" >
            
             &nbsp;<asp:Label ID="Label6" runat="server" Text="नविन नाव समाविष्ट करणे" CssClass="form_b_color" Visible="False" Font-Names="Sakal Marathi"></asp:Label>
            <asp:GridView ID="grvVars" runat="server"  AutoGenerateColumns="False"
                OnRowCancelingEdit="grvVars_RowCancelingEdit" OnRowCommand="grvVars_RowCommand"
                OnRowDeleting="grvVars_RowDeleting" OnRowEditing="grvVars_RowEditing" OnRowUpdating="grvVars_RowUpdating"  CssClass="grid" ShowFooter="True">
               
                <Columns>
                    <asp:TemplateField HeaderText="अ.क्र." Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAno" runat="server" Text='<%# Bind("usrno") %>'></asp:TextBox>
                                
                                 </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtNewAnoS" runat="server" Visible="false" CssClass="form_txt" ></asp:TextBox>
                                
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAnoS" runat="server" Text='<%# Bind("usrno") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="प्रथम नांव">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstNameS" runat="server" Text='<%# Bind("fname") %>' CssClass="form_txt"  MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtNewFirstNameS" runat="server" ControlToValidate="txtFirstNameS"
                                ErrorMessage="प्रथम नाव टाका"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtNewFirstNameS" runat="server" Visible="false" CssClass="form_txt" MaxLength="50" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtNewFirstNameS" runat="server" ControlToValidate="txtNewFirstNameS"
                                Enabled="false" ErrorMessage="प्रथम नाव टाका"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPartyFNameS" runat="server" Text='<%# Bind("fname") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="वडील/पतीचे नांव">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMiddleNameS" runat="server" Text='<%# Bind("mname") %>' CssClass="form_txt" MaxLength="50" ></asp:TextBox>
                       
                        </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtNewMiddleNameS" runat="server" Visible="false" CssClass="form_txt" MaxLength="50"></asp:TextBox>
                           
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPartyMNameS" runat="server" Text='<%# Bind("mname") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Font-Names="Sakal Marathi" HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="आडनांव">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSurNameS" runat="server" Text='<%# Bind("lname") %>' CssClass="form_txt" MaxLength="50"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtNewSurNameS" runat="server" Visible="false" CssClass="form_txt" MaxLength="50" ></asp:TextBox>
                           
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPartyLNameS" runat="server" Text='<%# Bind("lname") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle Font-Names="Sakal Marathi" HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="टोपन नाव">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAddressS" runat="server" Text='<%# Bind("topan_name") %>' CssClass="form_txt" MaxLength="75" ></asp:TextBox>
                            
                        </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtNewAddressS" runat="server" Visible="false" CssClass="form_txt" MaxLength="75"></asp:TextBox>
                         
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label18" runat="server" Text='<%# Bind("topan_name") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle Font-Names="Sakal Marathi" HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FullName" Visible="false">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtfullname"  Visible="false" runat="server" Text='<%# Bind("fullname") %>' CssClass="form_txt" MaxLength="75" ></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtfullname2" runat="server" Visible="false" CssClass="form_txt" MaxLength="75"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblfullname" runat="server"  Visible="false" Text='<%# Bind("fullname") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle Font-Names="Sakal Marathi" HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>


                     <asp:TemplateField HeaderText="फेरफार क्रमांक ">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMutationNo" runat="server" Text='<%# Bind("mut_no") %>' CssClass="form_txt" MaxLength="75" ></asp:TextBox>
                            
                        </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtMutationNoS" runat="server" Visible="false" CssClass="form_txt" MaxLength="75"></asp:TextBox>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ErrorMessage="कृपया फेरफार क्रमांक टाका"  ValidationGroup="otherrightsgroup"  ControlToValidate="txtMutationNoS" CssClass="form_lbl_red_s" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblMutationNo" runat="server" Text='<%# Bind("mut_no") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle Font-Names="Sakal Marathi" HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                   
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="Update"
                                Text="सुधारणा" Width="40px"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="रद्द करा"  Width="72px"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandName="New"
                                Text="नवीन" Width="70px" OnClick="LinkButton7_Click"></asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate >
                            <asp:LinkButton ID="LinkButton8" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="संपादन" Width="40px" enabled="true" OnClick="LinkButton8_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" ShowHeader="True" DeleteText="नष्ट करा" 
                        EditText="संपादन" />
                </Columns>
                <FooterStyle CssClass="gridfooter" />                
                <SelectedRowStyle CssClass="gridselectdrow" />
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridrow" />
            </asp:GridView>   </asp:panel>
         
           

         <div class="row">
            <center>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Visible="false" CssClass="form_lbl_red_ss" ></asp:Label>
                <div class="clear_br"> </div>
                <asp:Button ID="btnAddNameSave" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl" OnClick="btnAddNameSave_Click" Font-Names="Sakal Marathi"  />&nbsp;
                <asp:Button ID="btnAddNameBack" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False" OnClick="btnAddNameBack_Click" Font-Names="Sakal Marathi" />
                &nbsp;
                <div class="clear_br">
                </div>
                </center>
        </div>
         <br />

         </asp:Panel>

    <div id="divpopup_PaneNameDel" class="ontop"></div>
    <asp:Panel ID="PaneNameDel" runat="server"  Visible="false" CssClass="popupPnl_holderhakkden" BackColor="#EFEFEF">

        <div class="clear_br">
            <div class="clear_br">
            </div>
            <center>
                <asp:Label ID="Label108" runat="server" CssClass="form_lblhead" Font-Bold="True" Text="नावे काढणे"></asp:Label>
            </center>
            <div class="clear_br">
            </div>
        </div>
        <div class="row">
    &nbsp;<asp:Label ID="lblKhataNoDelDisp" runat="server" Text="खाता क्रमांक :"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;  <asp:Label ID="lblKhataNoDisp" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="lblKhataTypeDel" runat="server" CssClass="form_lbl" Text="मुळ खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypeDelDisp" runat="server" ForeColor="#FF3300" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypeDelele" runat="server" Text="नावे कमी केल्यानंतर खात्याचा खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"  ></asp:Label>
              <asp:DropDownList ID="ddlkhatatypeDel" runat="server" CssClass="form_drptxt"  Font-Names="Sakal Marathi" AutoPostBack="True" OnSelectedIndexChanged="ddlkhatatypeDel_SelectedIndexChanged"> </asp:DropDownList>
              <asp:Label ID="lblKhataTypeDelNew" runat="server" Text="निवडलेला खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi" Visible="False"  ></asp:Label>
              <asp:Label ID="lblKhataTypeDelDispNew" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
           
    </div>
<br/>
  <div >
                            <asp:Panel ID="pnlOldNamesDel" runat="server" ScrollBars="vertical" CssClass="bs_pnl" Visible="true" height="200px"  Width="100%" >
                                <asp:GridView ID="gdvOldNamesDel" runat="server" BorderWidth="1px" CssClass="grid" BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" OnRowDeleting="gdvOldNamesDel_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="पहिले नाव">
                                            <ItemTemplate>

                                                <script type="text/javascript">//<!--
                                                    var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                    //--></script>

                                                <div id="rtDiv1">
                                                </div>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="false"
                                                    CssClass="form_txt_85"> </asp:TextBox>

                                                <script type="text/javascript">//<!--
                                                    textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                    //--></script>

                                             

                                                <script type="text/javascript">//<!--
                                                    rtDiv = document.getElementById('rtDiv1');
                                                    //--></script>

                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले   नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="टोपण नाव           ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="खाता. क्र" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="खाता प्रकार" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                           <asp:CommandField ShowDeleteButton="True" Visible="true" ShowHeader="True" HeaderText="मिटवा"
                                        DeleteText="नष्ट करा"></asp:CommandField>
                                       
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



         <div >
                        </div>
                        <br/>
                        
                     
                        
                        <div>
                            &nbsp;<asp:Label ID="lblSurveyNameDelDisp" runat="server" Text="परिणाम होणारे सर्व्हे क्रमांक : " Visible="False"></asp:Label>   <asp:Label ID="lblSurveyNameDel" runat="server" Text=" " 
Font-Names="Sakal Marathi" ForeColor="#FF33CC"></asp:Label>
                            
                        </div>
                        
                        <br/>
                        
                     
                        
                        <br/>
                        

        <div class="row">
<center> &nbsp;<asp:Label ID="Label67" runat="server" Text="" ForeColor="Red"></asp:Label></center>
</div>
                       <div>
               <center>       

 <asp:Button ID="btnNameDelSave" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl"  Visible="False" Font-Names="Sakal Marathi"  />&nbsp;
                <asp:Button ID="btnNameDelBack" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False"  Font-Names="Sakal Marathi" OnClick="btnNameDelBack_Click" />
                   &nbsp; 
                   <div class="clear_br">
                   </div>
                           </center> 


                           <asp:HiddenField ID="HiddenField3" runat="server" />
                           <asp:HiddenField ID="HiddenField4" runat="server" />
                           <asp:HiddenField ID="HiddenField5" runat="server" />
    
                       </div>
    </asp:Panel>


        <div id="divpopup_NameCorr" class="ontop"></div>
    <asp:Panel ID="PnlNameCorr" runat="server"  Visible="False" CssClass="popupPnl_holderhakkden" BackColor="#EFEFEF">
         <div class="clear_br">
             <div class="clear_br">
             </div>
             <center>
                 <asp:Label ID="Label109" runat="server" CssClass="form_lblhead" Font-Bold="True" Text="नावांची स्पेलिंग दुरुस्ती करणे"></asp:Label>
             </center>
             <div class="clear_br">
             </div>
         </div>
        <div class="row">
    &nbsp;<asp:Label ID="lblKhataNoSpellCorr" runat="server" Text="खाता क्रमांक :"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;  <asp:Label ID="lblKhataNoNamesSpell" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>
           
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
           
    </div>
<br/>
  <div >
                            <asp:Panel ID="pnlOldNames" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="143px" Width="100%">
                                
                                <asp:GridView ID="gdvOldNames" runat="server" BorderWidth="1px" CssClass="grid"
                                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" UseAccessibleHeader="False">

                    
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblnivda" runat="server" Text="निवडा" CssClass="form_lbl"></asp:Label>
                                                <asp:CheckBox ID="chkeffect" runat="server"  Visible="false"
                                                    AutoPostBack="True" OnCheckedChanged="chkeffect_CheckedChanged"  />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkselect" runat="server" ToolTip="<%# ((GridViewRow)Container).RowIndex %>" OnCheckedChanged="chkselect_CheckedChanged"   />
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="पहिले नाव">
                                            <ItemTemplate>

                                                <script type="text/javascript">//<!--
                                                    var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                    //--></script>

                                                <div id="rtDiv1">
                                                </div>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="false"
                                                    CssClass="form_txt_85"> </asp:TextBox>

                                                <script type="text/javascript">//<!--
                                                    textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                    //--></script>

                                               

                                                <script type="text/javascript">//<!--
                                                    rtDiv = document.getElementById('rtDiv1');
                                                    //--></script>

                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले   नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="टोपण नाव           ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="खाता. क्र" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="खाता प्रकार" Visible="false" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
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
                         <asp:Button ID="btnAdd" runat="server" Text="समावेश करा" OnClick="btnAdd_Click" Visible="False"  />
                        </div>
                        <br/>
                        
                        <div>
                            &nbsp;<asp:Label ID="lblSurveyDisp" runat="server" Text="परिणाम होणारे सर्व्हे क्रमांक : " Visible="False"></asp:Label>   <asp:Label ID="lblSurveyListDispaly" runat="server" Text=" " Font-Names="Sakal Marathi" ForeColor="#FF33CC"></asp:Label>
                            
                        </div>
                        
                        <br/>
                        
                         <asp:Panel ID="pnlgdvNewBhogvatdar" runat="server" ScrollBars="vertical" CssClass="bhogvat_grdpnl" Height="125px" Width="100%" Visible="False">
                            <asp:GridView ID="gdvNewNames" runat="server" CssClass="grid" AutoGenerateColumns="False"
                                 TabIndex="4" OnRowDeleting="gdvNewNames_RowDeleting">
                                <Columns>
                                   
                                    
                                    <asp:CommandField ShowDeleteButton="True" Visible="false" ShowHeader="True" HeaderText="मिटवा"
                                        DeleteText="नष्ट करा"></asp:CommandField>
                                    
                                    <asp:TemplateField HeaderText="पहिले नाव">
                                        <ItemTemplate>

                                            <script type="text/javascript">//<!--
                                                var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                //--></script>

                                         
                                            <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="true"
                                                CssClass="form_txt_85"> </asp:TextBox>

                                            <script type="text/javascript">//<!--
                                                textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                //--></script>

                                         

                                            <script type="text/javascript">//<!--
                                                rtDiv = document.getElementById('rtDiv1');
                                                //--></script>

                                        </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="मधले   नाव        ">
                                        <ItemTemplate>
                                       
                                            <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="true"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                        <ItemTemplate>
                                            
                                            <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="true"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="टोपण  नाव           ">
                                        <ItemTemplate>
                                           
                                            <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="true"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="13%" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="खाता. क्र" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn1" runat="server" Enabled="False" Text='<%# Eval("khata_no") %>'
                                                CssClass="form_lbl"></asp:Label>
                                          
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="खाता प्रकार" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn6" runat="server" Enabled="False" Text='<%# Eval("khata_type") %>'
                                                CssClass="form_lbl"></asp:Label>
                                           
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    
                                    
                                    
                                </Columns>
                                <FooterStyle CssClass="gridfooter" />
                                <PagerStyle CssClass="gridpager" />
                                <SelectedRowStyle CssClass="gridselectdrow" />
                                <HeaderStyle CssClass="gridheader" />
                                <RowStyle CssClass="gridrow" />
                            </asp:GridView>
                        </asp:Panel>
                        
                        <br/>
                        

        <div class="row">
<center> &nbsp;<asp:Label ID="lblmsgSpell" runat="server" Text="" ForeColor="Red"></asp:Label></center>
</div>
                       <div>
               <center>       

 <asp:Button ID="btn" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl" OnClick="btn_Click" Visible="False" Font-Names="Sakal Marathi"  />&nbsp;
                <asp:Button ID="btnNameCorrBack" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False"  Font-Names="Sakal Marathi" OnClick="btnNameCorrBack_Click" />
                   &nbsp; 
                   <div class="clear_br">
                   </div>
                           </center> 


                       </div>



    </asp:Panel>
     <div id="divpopup_khataType" class="ontop"></div>
     <asp:Panel ID="pnlkhataType" runat="server" Visible="false" CssClass="popupPnl_holderhakkden" BackColor="#EFEFEF"  >
          <div class="clear_br">
              <div class="clear_br">
              </div>
              <center>
                  <asp:Label ID="Label110" runat="server" CssClass="form_lblhead" Font-Bold="True" Text="खाता प्रकार बदलणे "></asp:Label>
              </center>
              <div class="clear_br">
              </div>
          </div>
         <div class="row">
              &nbsp;<asp:Label ID="lblKhataTypechangeKhataNo" runat="server" CssClass="form_lbl" Text="खाता क्रमांक :-" Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypechangeKhataNoDisp" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypechangeKhataTypeOld" runat="server" CssClass="form_lbl" Text="मुळ खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypechangeKhataTypeOldDisp" runat="server" ForeColor="#FF3300" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypechangeKhataType" runat="server" Text="नविन खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"  ></asp:Label>
              <asp:DropDownList ID="ddlKhataTypechangeKhataTypeNew" runat="server" CssClass="form_drptxt" Font-Names="Sakal Marathi" AutoPostBack="True" OnSelectedIndexChanged="ddlKhataTypechangeKhataTypeNew_SelectedIndexChanged"> </asp:DropDownList>
              <asp:Label ID="lblKhataTypechangeKhataTypeNew" runat="server" Text="निवडलेला खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi" Visible="False"  ></asp:Label>
              <asp:Label ID="lblKhataTypechangeKhataTypeNewDisp" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
         </div>

         <div class="clear_br">

         </div>

           <div >
                            <asp:Panel ID="panelkhataTypechangeNames" runat="server" ScrollBars="vertical" CssClass="bhogvat_grdpnl" Visible="true" height="200px"  Width="100%" >
                                <asp:GridView ID="grdkhataTypechangeNames" runat="server" BorderWidth="1px" CssClass="grid"
                                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1">
                                    <Columns>
                                        <asp:TemplateField HeaderText="पहिले नाव">
                                            <ItemTemplate>

                                                <script type="text/javascript">//<!--
                                                    var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                    //--></script>

                                                <div id="rtDiv1">
                                                </div>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="false"
                                                    CssClass="form_txt_85"> </asp:TextBox>

                                                <script type="text/javascript">//<!--
                                                    textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                    //--></script>

                                               

                                                <script type="text/javascript">//<!--
                                                    rtDiv = document.getElementById('rtDiv1');
                                                    //--></script>

                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले   नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="टोपण नाव           ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
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
                        
                     
                        
                        <div>
                            &nbsp;<asp:Label ID="khataTypeChangeSurvey" runat="server" Text="परिणाम होणारे सर्व्हे क्रमांक : " Visible="False"></asp:Label>   <asp:Label ID="khataTypeChangeSurveyDisp" runat="server" Text=" " Font-Names="Sakal Marathi" ForeColor="#FF33CC"></asp:Label>
                            
                        </div>
                        
                        <br/>
          <div class="row">
<center> &nbsp;<asp:Label ID="lblktc" runat="server" Text="" ForeColor="Red"></asp:Label></center>
</div>
                        
                     <div>
               <center>       

 <asp:Button ID="btnkhataTypeChngeSave" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl"  Visible="False" Font-Names="Sakal Marathi" OnClick="btnkhataTypeChngeSave_Click"  />&nbsp;
                <asp:Button ID="btnkhataTyypeChngeBack" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False"  Font-Names="Sakal Marathi" OnClick="btnkhataTyypeChngeBack_Click"  />
                   &nbsp; 
                   <br />
                   <div class="clear_br">
                   </div>
                         </center> 


                           
    
                       </div>
                        
                        <br/>
         </asp:Panel>



    <div id="divpopup_PnlKhataDelOnSurvey" class="ontop"></div>
   <asp:Panel ID="PnlKhataDelOnSurvey" runat="server"  Visible="false" CssClass="popupPnl_holderhakkden" BackColor="#EFEFEF">

        <div class="clear_br">
            <div class="clear_br">
            </div>
            <center>
                <asp:Label ID="Label75" runat="server" CssClass="form_lblhead" Font-Bold="True" Text="खाता क्रमांक निवडक सर्व्हे / गट क्रमांकावरुन वगळणे"></asp:Label>
            </center>
            <div class="clear_br">
            </div>
        </div>
        <div class="row">
    &nbsp;<asp:Label ID="lblDelOnSurveykhataNoDisp" runat="server" Text="खाता क्रमांक :"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;  <asp:Label ID="lblDelOnSurveykhataNoDispVal" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
    <asp:Label ID="lblDelOnSurveykhataTypeDisp" runat="server" CssClass="form_lbl" Text="खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
    <asp:Label ID="lblDelOnSurveykhataTypeDispVal" runat="server" ForeColor="#FF3300" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
    </div>
<br/>
  <div >
                            <asp:Panel ID="pnlgrdKhataDelOnSurvey" runat="server" ScrollBars="vertical" CssClass="bs_pnl" Visible="true" height="200px"  Width="100%" >
                                <asp:GridView ID="grdKhataDelOnSurvey" runat="server" BorderWidth="1px" CssClass="grid" BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" OnRowDeleting="gdvOldNamesDel_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="पहिले नाव">
                                            <ItemTemplate>

                                                <script type="text/javascript">//<!--
                                                    var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                    //--></script>

                                                <div id="rtDiv1">
                                                </div>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="false"
                                                    CssClass="form_txt_85"> </asp:TextBox>

                                                <script type="text/javascript">//<!--
                                                    textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                    //--></script>

                                             

                                                <script type="text/javascript">//<!--
                                                    rtDiv = document.getElementById('rtDiv1');
                                                    //--></script>

                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले   नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="टोपण नाव           ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="खाता. क्र" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="खाता प्रकार" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
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
                                                             
                        <div>
                            &nbsp;<asp:Label ID="Label2" runat="server" Text="निवडलेला खाता क्रमांक असलेल्या सर्व्हे क्रमांकांची यादी :" Visible="False"></asp:Label>   <asp:Label ID="lblKhataDelOnSurveySurveyListDispVal" runat="server" Text=" " 
Font-Names="Sakal Marathi" ForeColor="#FF33CC"></asp:Label>
                            
                        </div>
                        <br/>
                        <br/>

        <div >
                            <asp:Panel ID="pnlSurveySelection" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="143px" Width="100%">
                                
                                <asp:GridView ID="gdvSurveySelection" runat="server" BorderWidth="1px" CssClass="grid"
                                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" UseAccessibleHeader="False" OnSelectedIndexChanged="gdvSurveySelection_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkeffect" runat="server" AutoPostBack="True" OnCheckedChanged="chkeffect_CheckedChanged"  ToolTip="सर्व निवडा" />
                                                <asp:Label ID="lblnivda" runat="server" Text="सर्व निवडा" CssClass="form_lbl"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate  >
                                                <asp:CheckBox ID="chkSelectSurvey" runat="server" ToolTip="<%# ((GridViewRow)Container).RowIndex %>" OnCheckedChanged="chkSelectSurvey_CheckedChanged" AutoPostBack="True"  />
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        
                                       <asp:TemplateField HeaderText="सर्व्हे क्रमांक"   >
                                            <ItemTemplate  >
                                                <asp:Label ID="lblpins" runat="server" Enabled="False" Text='<%# Eval("pincase") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="सर्व्हे" Visible="False"  >
                                            <ItemTemplate  >
                                                <asp:Label ID="lblpin" runat="server" Enabled="False" Text='<%# Eval("pin") %>' 
                                                     CssClass="form_lbl"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="सर्व्हे1" Visible="False" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin1" runat="server" Enabled="False" Text='<%# Eval("pin1") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="सर्व्हे2" Visible="False" >
                                            <ItemTemplate >
                                                <asp:Label ID="lblpin2" runat="server" Enabled="False" Text='<%# Eval("pin2") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="सर्व्हे3" Visible="False" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin3" runat="server" Enabled="False" Text='<%# Eval("pin3") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="सर्व्हे4" Visible="False"  >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin4" runat="server" Enabled="False" Text='<%# Eval("pin4") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="सर्व्हे5" Visible="False" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin5" runat="server" Enabled="False" Text='<%# Eval("pin5") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="सर्व्हे6" Visible="False" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin6" runat="server" Enabled="False" Text='<%# Eval("pin6") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="सर्व्हे7" Visible="False"  >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin7" runat="server" Enabled="False" Text='<%# Eval("pin7") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="सर्व्हे8"  Visible="False" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin8" runat="server" Enabled="False" Text='<%# Eval("pin8") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
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

          <div>
                            &nbsp;<asp:Label ID="Label76" runat="server" Text="खाता क्रमांक वगळण्यासाठी निवडलेल्या सर्व्हे क्रमांकांची यादी :"></asp:Label>   <asp:Label ID="lblSelectedSurveyForDelete" runat="server" Text=" " 
Font-Names="Sakal Marathi" ForeColor="#FF33CC"></asp:Label>
                            
                        </div>
                        <br/>
                        <br/>
                        

        <div class="row">
<center> &nbsp;<asp:Label ID="Label87" runat="server" Text="" ForeColor="Red"></asp:Label></center>
</div>
                       <div>
               <center>       

 <asp:Button ID="btnKhataDelOnSurvey" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl" OnClick="btnKhataDelOnSurvey_Click" Visible="False" Font-Names="Sakal Marathi"  />&nbsp;
                <asp:Button ID="btnBackKhataDelOnSurvey" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False"  Font-Names="Sakal Marathi" OnClick="btnBackKhataDelOnSurvey_Click" />
                   &nbsp; 
                   <div class="clear_br">
                   </div>
                           </center> 


                           <asp:HiddenField ID="HiddenField6" runat="server" />
                           <asp:HiddenField ID="HiddenField7" runat="server" />
                           <asp:HiddenField ID="HiddenField8" runat="server" />
    
                       </div>
    </asp:Panel>
                      

</asp:Content>

