
<%@ Page Language="C#" MasterPageFile="~/newmasterweblmis.master" AutoEventWireup="true" ClientTarget="uplevel" 
    MaintainScrollPositionOnPostback="true" CodeFile="pgLogin.aspx.cs" Inherits="pgLogin"
    Title=".लॉगिन::राष्ट्रीय  भूमि अभिलेख आधुनिकीकरण कार्यक्रम,महाराष्ट्र राज्य::." EnableViewState="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">   
    <script src="Javascript/md5-paj.js" type="text/javascript"></script>
    <script src="Javascript/Sha1.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript"> 

    function RegisterTK() {
            try {           
                    var certificte = new ActiveXObject("pdfSigner.Class1");
                   
                    var c = certificte.certificate_token();
                    document.getElementById("<%=HiddenField1.ClientID %>").value = c; 
                         
                  }
            catch (ex) {
                alert("An exception occurred !! Error name: " + ex.name + ". Error message: " + ex.message);
            }
        }
    
   function EncryptMD5()
    {
        try {
         var Pass = document.getElementById("<%=txtPassword.ClientID%>").value;
         if (Pass.length > 0)
         {            
             var MD5Hash = SHA1(hex_md5(Pass)); 
          
            var salt = '<%= Session["SaltStr"].ToString() %>';
             MD5Hash = hex_md5(salt + MD5Hash);
             document.getElementById("<%=hfhp.ClientID%>").value = MD5Hash;                 
             document.getElementById("<%=txtPassword.ClientID%>").value = MD5Hash;
         }           
                    var certificte = new ActiveXObject("pdfSigner.Class1");                   
                    var c = hex_md5(certificte.certificate_token().toString().split('#')[0] + salt);
                    document.getElementById("<%=HiddenField1.ClientID %>").value=c;                         
                  }
            catch (ex) {
                alert("An exception occurred !! Error name: " + ex.name + ". Error message: " + ex.message);
            }
        
    } 
    
    function EncryptMD5new()
    {
          var Pass = document.getElementById("<%=txtExistingPassword.ClientID%>").value;
          var newpass = document.getElementById("<%=txtNewPassword1.ClientID%>").value;
          var conpass = document.getElementById("<%=txtConfNewPassword.ClientID%>").value;          
          var emailPat =/((?=.*\d)(?=.*[a-zA-Z])(?=.*[@#$&]).{6,20})/;       
          
       var matchArray=newpass.match(emailPat);
       if(newpass =="")
       {
        alert('नवीन पासवर्ड भरा.');
        return false;
       }       
       else if(newpass!=conpass)
       {
         alert('पुन्हा भरलेला पासवर्ड व नवीन पासवर्ड समान नाहीत.');
         return false;
       }
       else if(matchArray==null)
       {
           alert("Please enter new password in Correct Format..");      
           return false;                       
       }
       else
       {        
            var MD5Hash2=hex_md5(Pass);      
            var MD5Hash3=hex_md5(newpass);
            var MD5Hash4=hex_md5(conpass);
            document.getElementById("<%=txtExistingPassword.ClientID%>").value = MD5Hash2;  
            document.getElementById("<%=txtNewPassword1.ClientID%>").value = MD5Hash3;  
            document.getElementById("<%=txtConfNewPassword.ClientID%>").value=MD5Hash4;
       }
    }
    
 
        function checkPassword()
        {
                return EncryptMD5();
        }

 
    </script><script language="javascript" type="text/javascript"> 
function disableautocompletion(id)
{ 
    var passwordControl = document.getElementById(id);
    passwordControl.setAttribute("autocomplete", "off");
}
    </script><div>
        

       
            <div id="site_main_content" >
                
               <asp:UpdatePanel ID="UpdatePanel1"  runat="server">

                   <ContentTemplate>

                <asp:Panel ID="pnl_Login" runat="server">
                    <div class="login_box">
                        <div id="page_header">

                            
                            प्रवेश पटल
                        </div>
                        
                      
                             
                        <div class="clear">
                          <asp:Label ID="UsersOnlineLabel" runat="server" CssClass="form_lbl" ForeColor="#FF3300" ></asp:Label>
                            <br/>   
                            <br />                                                                          
                        </div>
                                                                            
                           
                        <div class="row">
                            <div class="log_col_Left">
                                <asp:Label ID="lblUserName" runat="server" Text="सेवार्थ आय.डी." CssClass="form_lbl"></asp:Label></div>
                            <div class="log_col">
                                <asp:TextBox ID="txtLoginName" runat="server" MaxLength="12" autocomplete="off"
                                    onfocus="disableautocompletion(this.id);" EnableViewState="False" CssClass="form_txt"
                                    ValidationGroup="login"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtLoginName"
                                    ErrorMessage="User Name Required" SetFocusOnError="True" Width="1px" Display="Dynamic"
                                    ValidationGroup="login">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="clear_br">            
        </div>
                        <div class="row">
                            <div class="log_col_Left">
                                <asp:Label ID="lblPassword" runat="server" Text="पासवर्ड" CssClass="form_lbl"></asp:Label></div>
                            <div class="log_col">
                                <asp:TextBox ID="txtPassword" runat="server" MaxLength="40" Font-Names="Arial" TextMode="Password"
                                    onfocus="disableautocompletion(this.id);" EnableViewState="False" autocomplete="off"
                                    CssClass="form_txt" ValidationGroup="login"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                    ErrorMessage="Password Required" SetFocusOnError="True" Display="Dynamic" ValidationGroup="login">*</asp:RequiredFieldValidator><br />
                            </div>
                        </div>
                        <div class="clear_br">            
        </div>
                        <div class="row">
                            <div class="log_col_Left">
                                <img alt="" src="JpegImage.aspx" /></div>
                            <div class="log_col">
                                <asp:TextBox ID="CodeNumberTextBox" runat="server" autocomplete="off" Font-Names="Arial Unicode MS"
                                    CssClass="form_txt" onfocus="disableautocompletion(this.id);" MaxLength="6"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="CodeNumberTextBox"
                                    CssClass="form_lbl_red_s" Display="Dynamic" ErrorMessage="कृपया, सदर जागे मध्ये सांकेतिक अक्षरे भरू नका."
                                    Font-Bold="True" SetFocusOnError="true" ValidationExpression="^[ A-Za-z0-9{}]*$"
                                    ValidationGroup="login" Width="122px"></asp:RegularExpressionValidator><br /><br />
                                <asp:Label ID="Label5" runat="server" CssClass="form_lbl" Text="दिलेली सांकेतिक अक्षरे भरा."></asp:Label></div>
                        </div>
                        <div class="clear_br">
            
        </div>
                        <center>
                            <asp:Button ID="cmdLogin" runat="server" TabIndex="0" OnClientClick="checkPassword()"
                                OnClick="cmdLogin_Click" Text="लॉगिन" CssClass="form_lbl" ValidationGroup="login" />
                            <asp:Button ID="btnchangepassword" runat="server" Text="पासवर्ड बदला" CssClass="form_lbl"
                                OnClick="btnchangepassword_Click" EnableTheming="False" Visible="False" />&nbsp;
                            <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" OnClientClick="EncryptMD5new()"
                                Text="नाविन पासवर्ड साठवा" Visible="False" CssClass="form_lbl" />&nbsp;<asp:Button ID="TEST" runat="server" OnClick="TEST_Click" Text="Intigrty Check" Visible="False" />
                        </center>
                       <div class="clear_br">
            
        </div>
                        <center>
                            <asp:HyperLink ID="hprHelpDesk" runat="server" ForeColor="Blue" Font-Underline="True"
                                NavigateUrl="~/Downloads/Re-EditTapasni Suchi.pdf">विभाग निहाय मदत कक्षाची संपर्क माहिती.</asp:HyperLink>
           
             
    
                        </center>
                      
                        <asp:Label ID="lblattemptno" runat="server" ForeColor="Red"></asp:Label>
                        <asp:Label ID="lblerror" runat="server" CssClass="form_lbl_red_s" ForeColor="Red"></asp:Label>&nbsp;
                        <asp:Label ID="Errormsg" runat="server" CssClass="form_lbl_red_s"></asp:Label>
                        <center>
                            &nbsp;<br /> </center>
                        <cc1:ValidatorCalloutExtender ID="vceUserName" runat="server" TargetControlID="rfvUserName">
                        </cc1:ValidatorCalloutExtender>
                        <cc1:ValidatorCalloutExtender ID="vcePassword" runat="server" TargetControlID="rfvPassword">
                        </cc1:ValidatorCalloutExtender>
                        <asp:HiddenField ID="hfhp" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <div style="display: none">
                            <div class="clear">
                            </div>
                            <div class="row">
                                <div class="log_col_Left">
                                    <asp:Label ID="lblnewpass" runat="server" CssClass="form_lbl" Text="नाविन पासवर्ड"
                                        Visible="false"></asp:Label></div>
                                <div class="log_col">
                                    <asp:TextBox ID="txtnewpass" runat="server" AutoCompleteType="Disabled" CssClass="form_txt"
                                        EnableViewState="False" Font-Names="Arial" MaxLength="12" onfocus="disableautocompletion(this.id);"
                                        TextMode="Password" Visible="false"></asp:TextBox></div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="row">
                                <div class="log_col_Left">
                                    <asp:Label ID="lblconfirmpass" runat="server" CssClass="form_lbl" Text="नाविन पासवर्ड कंफर्म करा"
                                        Visible="false"></asp:Label></div>
                                <div class="log_col">
                                    <asp:TextBox ID="txtconfirmpass" runat="server" AutoCompleteType="Disabled" CssClass="form_txt"
                                        EnableViewState="False" Font-Names="Arial" MaxLength="12" onfocus="disableautocompletion(this.id);"
                                        TextMode="Password" Visible="false">a</asp:TextBox></div>
                                <div class="clear">
                                </div>
                            </div>
                            <asp:RadioButton ID="rbmul" runat="server" Text="Mul" AutoPostBack="True" Visible="False"
                                CssClass="form_lbl" />&nbsp;<asp:RadioButton ID="rbhav" runat="server" Text="hav"
                                    AutoPostBack="True" Visible="False" CssClass="form_lbl" />
                            <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged"
                                CssClass="form_drptxt" Visible="False">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddltaluka" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                OnSelectedIndexChanged="ddltaluka_SelectedIndexChanged" CssClass="form_drptxt"
                                Visible="False">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br /><br />
                </asp:Panel>
                   </ContentTemplate>

                    </asp:UpdatePanel>

               
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
                    <ProgressTemplate>
                         
                                                   
                   <div id="blur" >
               
                         <asp:Panel ID="PanelProgress" runat="server" CssClass="PanelPopUp" Style="left: 42%;  position: absolute; top: 35%" Width="300" Height="100">
                             <br />
                                         <img src="Image/process.gif"  width="225px" height="175px"/>
                        <div class="clear_br">
            
        </div>
                        
                    </asp:Panel>
                   </div>
                                                       

                               
                    </ProgressTemplate>
                </asp:UpdateProgress>
                             
                <asp:Panel ID="pnl_change_pwd" runat="server" Visible="false">
                    <div class="login_box">
                        <div id="page_header">
                            पासवर्ड बदला
                        </div>
                        <div class="clear">
                            <br />
                        </div>
                        <div class="row">
                            <div class="log_col_Left">
                                <asp:Label ID="Label4" runat="server" Text="सेवार्थ आय.डी." CssClass="form_lbl"></asp:Label></div>
                            <div class="log_col">
                                <asp:TextBox ID="txtSevarthID" runat="server" MaxLength="12" AutoCompleteType="Disabled"
                                    onfocus="disableautocompletion(this.id);" EnableViewState="False" CssClass="form_txt"
                                    ValidationGroup="login"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSevarthID"
                                    ErrorMessage="User Name Required" SetFocusOnError="True" Width="1px" Display="Dynamic"
                                    ValidationGroup="login"></asp:RequiredFieldValidator>
                              
                            </div>
                        </div>
                        <div class="clear">
                            <br />
                        </div>
                        <div class="row">
                            <div class="log_col_Left">
                                <asp:Label ID="Label6" runat="server" Text="सध्याचा पासवर्ड" CssClass="form_lbl"></asp:Label></div>
                            <div class="log_col">
                                <asp:TextBox ID="txtExistingPassword" runat="server" MaxLength="12" Font-Names="Arial"
                                    TextMode="Password" onfocus="disableautocompletion(this.id);" AutoCompleteType="Disabled"
                                    EnableViewState="False" CssClass="form_txt" ValidationGroup="login"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtExistingPassword"
                                    ErrorMessage="Password Required" SetFocusOnError="True" Display="Dynamic" ValidationGroup="login"></asp:RequiredFieldValidator><br />
                            </div>
                        </div>
                        <div class="clear">
                            <br />
                        </div>
                        <div class="row">
                            <div class="log_col_Left">
                                <asp:Label ID="Label11" runat="server" Text="नाविन पासवर्ड" CssClass="form_lbl"></asp:Label></div>
                            <div class="log_col">
                                <asp:TextBox ID="txtNewPassword1" runat="server" MaxLength="12" Font-Names="Arial"
                                    TextMode="Password" onfocus="disableautocompletion(this.id);" AutoCompleteType="Disabled"
                                    EnableViewState="False" CssClass="form_txt" ValidationGroup="login"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewPassword1"
                                    ErrorMessage="New Password Required" SetFocusOnError="True" Display="Dynamic"
                                    ValidationGroup="login">*</asp:RequiredFieldValidator><br />
                            </div>
                        </div>
                        <div class="clear">
                            <br />
                        </div>
                        <div class="row">
                            <div class="log_col_Left">
                                <asp:Label ID="Label12" runat="server" Text="नाविन पासवर्ड पडताळणी" CssClass="form_lbl"></asp:Label></div>
                            <div class="log_col">
                                <asp:TextBox ID="txtConfNewPassword" runat="server" MaxLength="12" Font-Names="Arial"
                                    TextMode="Password" onfocus="disableautocompletion(this.id);" AutoCompleteType="Disabled"
                                    EnableViewState="False" CssClass="form_txt" ValidationGroup="login"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfNewPassword"
                                    ErrorMessage="Confirm New Password Required" SetFocusOnError="True" Display="Dynamic"
                                    ValidationGroup="login">*</asp:RequiredFieldValidator><br />
                            </div>
                        </div>
                        <div class="clear">
                            <br />
                        </div>
                        <div class="clear">
                            <br />
                        </div>
                        <center>
                            <asp:Button ID="Button3" runat="server" OnClick="btnsave_Click" OnClientClick="EncryptMD5new()"
                                Text="नाविन पासवर्ड साठवा" CssClass="form_lbl" /></center>
                        <center>
                            <br />
                            <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" CssClass="form_lbl"></asp:Label>
                            <asp:LinkButton ID="lnkLogin" runat="server" CssClass="form_lbl" OnClick="lnkLogin_Click1">प्रवेश पटल वर जाण्यासाठी येथे क्लीक करा</asp:LinkButton>
                            <asp:Label ID="Label9" runat="server" CssClass="form_lbl_red_s" ForeColor="Red"></asp:Label>&nbsp;
                            <asp:Label ID="Label10" runat="server" CssClass="form_lbl_red_s"></asp:Label>
                        </center>
                        <center>
                            &nbsp;</center>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rfvUserName">
                        </cc1:ValidatorCalloutExtender>
                        <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="rfvPassword">
                        </cc1:ValidatorCalloutExtender>
                    </div>
                </asp:Panel>
            </div>
        </div>
    
   
</asp:Content>
