<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="pgRedirectpagenew.aspx.cs" Inherits="gpRedirectpage" %>
<%@ OutputCache Location="None" VaryByParam ="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript" language="javascript">
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
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    </form>
</body>
</html>
