<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"
    CodeFile="pgChangePassword.aspx.cs" Inherits="pgChangePassword" Title=".::राष्ट्रीय  भूमि अभिलेख आधुनिकीकरण कार्यक्रम,महाराष्ट्र राज्य::."%>

<%--<%@ OutputCache Location="None" VaryByParam="None" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <script src="Javascript/md5-paj.js" type="text/javascript"></script>



    <script language="javascript" type="text/javascript"> 
    function RegisterTK() {
            try {
             
                    //var a = document.getElementById("<%=HiddenField1.ClientID %>").value;
                    
                    
//                   if(confirm('कृपया निवडलेला सेवार्थ क्रमांक हा तेथे उपस्थित व्यक्तीचाच आहे याची खात्री करा.'))
//                   {
                   
                    var certificte = new ActiveXObject("pdfSigner.Class1");
                   
                    var c = certificte.certificate_token();
                    document.getElementById("<%=HiddenField1.ClientID %>").value=c;
                    
                    //alert("आता तुम्ही डीजीटल सिग्नेचर रेजीस्टर करण्यासाठी तयार आहात.");
                    
//                    }
                    
                    
                         
                  }
            catch (ex) {
                alert("An exception occurred !! Error name: " + ex.name + ". Error message: " + ex.message);
            }
        }
    
   function EncryptMD5()
    {
       
         var Pass = document.getElementById("<%=txtPassword.ClientID%>").value;
         if (Pass.length > 0)
         {            
             var MD5Hash = hex_md5(Pass); 
          
            var salt = '<%= Session["SaltStr"].ToString() %>';
             MD5Hash = hex_md5(salt+MD5Hash);   
             document.getElementById("<%=hfhp.ClientID%>").value = MD5Hash;                 
             document.getElementById("<%=txtPassword.ClientID%>").value = MD5Hash;
         }
    } 
    
    function EncryptMD5new()
    {
          var Pass = document.getElementById("<%=txtExistingPassword.ClientID%>").value;
          var newpass = document.getElementById("<%=txtNewPassword1.ClientID%>").value;
          var conpass = document.getElementById("<%=txtConfNewPassword.ClientID%>").value;          
          var emailPat =/((?=.*\d)(?=.*[a-zA-Z])(?=.*[@#$&]).{6,20})/;       
          
       var matchArray=newpass.match(emailPat);
       if(matchArray==null)
       {
           alert("Please enter new password in Correct Format..");  
           document.getElementById("<%=op.ClientID%>").value = '0';
           document.getElementById("<%=txtExistingPassword.ClientID%>").value = '';  
            document.getElementById("<%=txtNewPassword1.ClientID%>").value = '';  
            document.getElementById("<%=txtConfNewPassword.ClientID%>").value='';
            
           return false;                       
       }
       else if(newpass =="")
       {
        alert('नवीन पासवर्ड भरा.');
        document.getElementById("<%=txtExistingPassword.ClientID%>").value = '';  
            document.getElementById("<%=txtNewPassword1.ClientID%>").value = '';  
            document.getElementById("<%=txtConfNewPassword.ClientID%>").value='';
        
        return false;
       }       
       else if(newpass!=conpass)
       {
         alert('पुन्हा भरलेला पासवर्ड व नवीन पासवर्ड समान नाहीत.');
         document.getElementById("<%=txtExistingPassword.ClientID%>").value = '';  
            document.getElementById("<%=txtNewPassword1.ClientID%>").value = '';  
            document.getElementById("<%=txtConfNewPassword.ClientID%>").value='';
          
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
    
    
     function EncryptMD5cancel()
    {
     var Pass = document.getElementById("<%=txtExistingPassword.ClientID%>").value;
          var newpass = document.getElementById("<%=txtNewPassword1.ClientID%>").value;
          var conpass = document.getElementById("<%=txtConfNewPassword.ClientID%>").value;  
          
            var MD5Hash2=hex_md5(Pass);      
            var MD5Hash3=hex_md5(newpass);
            var MD5Hash4=hex_md5(conpass);
            document.getElementById("<%=txtExistingPassword.ClientID%>").value = '';  
            document.getElementById("<%=txtNewPassword1.ClientID%>").value = '';  
            document.getElementById("<%=txtConfNewPassword.ClientID%>").value='';
       
    }
    
//     function EncryptMD5new()
//    {
//         var newpass = document.getElementById("<%=txtnewpass.ClientID%>").value;
//         var conpass = document.getElementById("<%=txtconfirmpass.ClientID%>").value;
//         if(newpass!="")
//         {
//            if(newpass==conpass)
//            {
//                var MD5Hashnew=hex_md5(newpass);
//                var salt = '<%= Session["SaltStr"].ToString() %>';
//                document.getElementById("<%=HiddenField1.ClientID%>").value = MD5Hashnew;
//                MD5Hashnew = hex_md5(salt+MD5Hashnew);
//                document.getElementById("<%=txtnewpass.ClientID%>").value = MD5Hashnew;
//            }
//         }
//    }  
   

 
    </script>

    <script language="javascript" type="text/javascript"> 
function disableautocompletion(id)
{ 
    var passwordControl = document.getElementById(id);
    passwordControl.setAttribute("autocomplete", "off");
}
    </script>

    &nbsp;<div id="site_main_content">
        <asp:Panel ID="pnl_Login" runat="server">
        
        <div class="login_box">
            <div id="page_header">
                प्रवेश पटल
            </div>
            <div class="clear">
                <br />
            </div>
            <div class="row">
                <div class="log_col_Left">
                    <asp:Label ID="lblUserName" runat="server" Text="सेवार्थ आय.डी." CssClass="form_lbl"></asp:Label></div>
                <div class="log_col">
                    <asp:TextBox ID="txtLoginName" runat="server" MaxLength="12" AutoCompleteType="Disabled"
                        onfocus="disableautocompletion(this.id);" EnableViewState="False" CssClass="form_txt" ValidationGroup="login"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtLoginName"
                        ErrorMessage="User Name Required" SetFocusOnError="True" Width="1px" Display="Dynamic"  ValidationGroup="login">*</asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="revtxtusername" runat="server" ControlToValidate="txtLoginName"
                    ErrorMessage="Special character is not allowed" SetFocusOnError="True" ValidationExpression="[\w\s]{1,10}$"
                    Display="Dynamic">*</asp:RegularExpressionValidator>--%>
                </div>
            </div>
            <div class="clear">
                <br />
            </div>
            <div class="row">
                <div class="log_col_Left">
                    <asp:Label ID="lblPassword" runat="server" Text="पासवर्ड" CssClass="form_lbl"></asp:Label></div>
                <div class="log_col">
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="12" Font-Names="Arial" TextMode="Password"
                        onfocus="disableautocompletion(this.id);" AutoCompleteType="Disabled" EnableViewState="False"
                        CssClass="form_txt" ValidationGroup="login"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="Password Required" SetFocusOnError="True" Display="Dynamic" ValidationGroup="login">*</asp:RequiredFieldValidator><br />
                </div>
            </div>
            <div class="clear">
                <br />
            </div>
            <div class="row">
                <div class="log_col_Left">
                    <img alt ="" src="JpegImage.aspx" /></div>
                <div class="log_col">
                    <asp:TextBox ID="CodeNumberTextBox" runat="server" AutoCompleteType="Disabled" Font-Names="Arial Unicode MS"
                        CssClass="form_txt" onfocus="disableautocompletion(this.id);"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label5" runat="server" CssClass="form_lbl" Text="पुढे दिलेली सांकेतिक अक्षरे भरा."></asp:Label></div>
            </div>
            <div class="clear">
                <br />
            </div>
            <center>
                <asp:Button ID="cmdLogin" runat="server" TabIndex="0" OnClientClick="EncryptMD5()" OnClick="cmdLogin_Click"
                    Text="लॉगिन" CssClass="form_lbl"  ValidationGroup="login"/>
                    <asp:Button ID="btnchangepassword" runat="server"  
                    Text="पासवर्ड बदला" CssClass="form_lbl" OnClick="btnchangepassword_Click" />&nbsp;
                <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" OnClientClick="EncryptMD5new()"
                    Text="नाविन पासवर्ड साठवा" Visible="False" CssClass="form_lbl" /></center>
            <center>
                <br />
                <asp:Label ID="lblattemptno" runat="server" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblerror" runat="server" CssClass="form_lbl_red_s" ForeColor="Red"></asp:Label>&nbsp;
                <asp:Label ID="Errormsg" runat="server" CssClass="form_lbl_red_s"></asp:Label>
            </center>
            <center>
                &nbsp;</center>
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
        
        </asp:Panel>
        
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
                    <asp:Label ID="Label4" runat="server" Text="सेवार्थ आय.डी." CssClass="form_lbl" Visible="False"></asp:Label></div>
                <div class="log_col">
                    <asp:TextBox ID="txtSevarthID" runat="server" MaxLength="12" AutoCompleteType="Disabled"
                        onfocus="disableautocompletion(this.id);" EnableViewState="False" CssClass="form_txt" ValidationGroup="login" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSevarthID"
                        ErrorMessage="User Name Required" SetFocusOnError="True" Width="1px" Display="Dynamic"  ValidationGroup="login" Visible="False">*</asp:RequiredFieldValidator>
                    <%--<asp:RegularExpressionValidator ID="revtxtusername" runat="server" ControlToValidate="txtLoginName"
                    ErrorMessage="Special character is not allowed" SetFocusOnError="True" ValidationExpression="[\w\s]{1,10}$"
                    Display="Dynamic">*</asp:RegularExpressionValidator>--%>
                </div>
            </div>
            <div class="clear">
                <br />
            </div>
            <div class="row">
                <div class="log_col_Left">
                    <asp:Label ID="Label6" runat="server" Text="सध्याचा पासवर्ड" CssClass="form_lbl"></asp:Label></div>
                <div class="log_col">
                    <asp:TextBox ID="txtExistingPassword" runat="server" MaxLength="12" Font-Names="Arial" TextMode="Password"
                        onfocus="disableautocompletion(this.id);" AutoCompleteType="Disabled" EnableViewState="False"
                        CssClass="form_txt" ValidationGroup="login"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtExistingPassword"
                        ErrorMessage="Password Required" SetFocusOnError="True" Display="Dynamic" ValidationGroup="login">*</asp:RequiredFieldValidator><br />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtExistingPassword"
                        Display="Dynamic" ErrorMessage="कृपया, सदर जागेमध्ये माहिती भरा." Width="253px" ValidationGroup="login"></asp:RequiredFieldValidator></div>
            </div>
            <div class="clear">
                <br />
            </div>
            <div class="row">
                <div class="log_col_Left">
                    <asp:Label ID="Label11" runat="server" Text="नाविन पासवर्ड" CssClass="form_lbl"></asp:Label></div>
                <div class="log_col">
                    <asp:TextBox ID="txtNewPassword1" runat="server" MaxLength="12" Font-Names="Arial" TextMode="Password"
                        onfocus="disableautocompletion(this.id);" AutoCompleteType="Disabled" EnableViewState="False"
                        CssClass="form_txt" ValidationGroup="login"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNewPassword1"
                        ErrorMessage="New Password Required" SetFocusOnError="True" Display="Dynamic" ValidationGroup="login">*</asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="rfvPass" runat="server" ControlToValidate="txtNewPassword1"
                        CssClass="form_lbl_red_s" Display="Dynamic" ErrorMessage="पासवर्ड तपासा." Font-Bold="True"
                        SetFocusOnError="true" ValidationExpression="((?=.*\d)(?=.*[A-Z])(?=.*\W).{6,12})" Width="122px"></asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNewPassword1"
                        Display="Dynamic" ErrorMessage="कृपया, सदर जागेमध्ये माहिती भरा." Width="253px" ValidationGroup="login"></asp:RequiredFieldValidator></div>
            </div>
            <div class="clear">
                <br />
            </div>
            <div class="row">
                <div class="log_col_Left">
                    <asp:Label ID="Label12" runat="server" Text="नाविन पासवर्ड पडताळणी" CssClass="form_lbl"></asp:Label></div>
                <div class="log_col">
                    <asp:TextBox ID="txtConfNewPassword" runat="server" MaxLength="12" Font-Names="Arial" TextMode="Password"
                        onfocus="disableautocompletion(this.id);" AutoCompleteType="Disabled" EnableViewState="False"
                        CssClass="form_txt" ValidationGroup="login"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfNewPassword"
                        ErrorMessage="Confirm New Password Required" SetFocusOnError="True" Display="Dynamic" ValidationGroup="login">*</asp:RequiredFieldValidator><br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtConfNewPassword"
                        CssClass="form_lbl_red_s" Display="Dynamic" ErrorMessage="पासवर्ड तपासा." Font-Bold="True"
                        SetFocusOnError="true" ValidationExpression="((?=.*\d)(?=.*[A-Z])(?=.*\W).{6,12})" Width="122px"></asp:RegularExpressionValidator><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtConfNewPassword"
                        Display="Dynamic" ErrorMessage="कृपया, सदर जागेमध्ये माहिती भरा." Width="253px" ValidationGroup="login"></asp:RequiredFieldValidator></div>
            </div>
            <div class="clear">
                <br />
            </div>
            
            <div class="clear">
                <br />
            </div>
            <center>
                <asp:Button ID="Button3" runat="server" OnClick="btnsave_Click" OnClientClick="EncryptMD5new()"
                    Text="नाविन पासवर्ड साठवा" CssClass="form_lbl" Width="141px" ValidationGroup="login" />
                <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" OnClientClick="EncryptMD5cancel()"
                    Text="रद्द करा." CssClass="form_lbl" Width="64px" /></center>
            <center>
                <br />
                <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" CssClass="form_lbl"></asp:Label>&nbsp;
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
    
    
    <asp:HiddenField ID="op" runat="server" />
    
</asp:Content>
