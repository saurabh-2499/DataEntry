<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="FinalSign.aspx.cs" Inherits="FinalSign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
     <script type="text/javascript" language="javascript">
   
         function RORFinal() 
            {
         try {
          
             var villagecode = document.getElementById("<%=hf_villagecode.ClientID %>").value;
             var sevarth = document.getElementById("<%=hf_sevarth.ClientID %>").value;
             var dbnm = '<%=Session["DataBaseName"] %>';
             var schmanm = '<%=Session["SchemaName"].ToString() %>';
             var host = document.getElementById("<%=hf_host.ClientID %>").value;
             var port = document.getElementById("<%=hf_port.ClientID %>").value;
              var token=7;
             var certificte = new ActiveXObject("pdfSigner.Class1");
             var SignDataString1 = certificte.BulkRORFinal   (villagecode, sevarth, dbnm, schmanm, host, port,token);
             
             alert(SignDataString1);
            
           }
            catch (ex) {
                alert("An exception occurred !! Error name: " + ex.name + ". Error message: " + ex.message);
            }
              
        }
        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HiddenField ID="hf_hash" runat="server" /><asp:HiddenField ID="hf_hashSign" runat="server" />
        <br />
        <br />
        <asp:HiddenField ID="hfKey" runat="server" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Height="58px" Text="rev"
            Width="269px" OnClientClick="RORFinal();" OnClick="Button2_Click" /><br />
        <asp:HiddenField ID="hf_villagecode" runat="server" />
        <asp:HiddenField ID="hf_sevarth" runat="server" />
        
        
        <asp:HiddenField ID="hf_host" runat="server" />
        <asp:HiddenField ID="hf_port" runat="server" />
    </div>
    </form>
</body>
</html>
