<%@ Page Language="C#" AutoEventWireup="true" CodeFile="villageskhataWorkDecalaration.aspx.cs" Inherits="villageskhataWorkDecalaration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>


     <script type="text/javascript">
       

         function confirm_confirm() {
             if (!confirm('निवडलेल्या सदर गावाचे संपुर्ण खाता मास्टरचे काम योग्यरीत्या पुर्ण झाले आहे याची खात्री केली आहे का ?.\nसंपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्राम महसूल अधिकारी स्वयं घोषणा करावयाची असल्यास OK क्लिक करा.\nसंपुर्ण गावाचे खाता मास्टरचे काम पुर्ण झाले आहे याची ग्राम महसूल अधिकारी स्वयं घोषणा करावयाची नसल्यास Cancel क्लिक करा.')) {
                 var confirm_value = document.createElement("INPUT");
                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 confirm_value.value = "notOk";
                 document.forms[0].appendChild(confirm_value);
                 return false;
             }
         }

    </script>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
    
    </div>

        <center>
        <div class="row">
           
        <asp:Button ID="workDeclairation" runat="server" OnClick="workDeclairation_Click" Text="खात्यांची दुरुस्ती पुर्ण झाल्याचे ग्राम महसूल अधिकारी स्वयं घोषणा करणे" Font-Names="Sakal Marathi" CssClass="form_lbl" OnClientClick="confirm_confirm();" />&nbsp;&nbsp;&nbsp;<asp:Button ID="workDeclairationIRpt" runat="server" OnClick="workDeclairationIRpt_Click" Text="Declaration - I ( खात्यांची दुरुस्ती पुर्ण झाल्याचे ग्राम महसूल अधिकारी स्वयं घोषणापत्र )" Font-Names="Sakal Marathi" CssClass="form_lbl" OnClientClick="confirm_confirm();" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBack" runat="server" CausesValidation="False" CssClass="form_lbl" EnableViewState="False" Font-Names="Sakal Marathi" OnClick="btnBack_Click" TabIndex="4" Text="मागे जा" /> 
            
            </div>
            </center>
    </form>
</body>
</html>
