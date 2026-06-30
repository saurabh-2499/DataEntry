<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="SignPdf.aspx.cs" Inherits="SignPdf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>

    <script type="text/javascript" language="javascript">
      
       function RLACreateMD6() {
           alert("कृपया अपने कार्ड का चयन करें।");
           var certificte = new ActiveXObject("pdfSigner.Class1");
             var   cert = certificte.sel_certificate().split("#");
             var valDate = cert[0];
             var cardcaname = cert[1].split(",");
             var serialno=cert[2];
             var cardusername=cert[3].split(",");
             var crdnm=cert[1];
             // Notafter  validupto    Issuername.name   Authorise issue  serialnumber serialno  subjectname  name 
             // card.NotAfter + "#" + card.IssuerName.Name + "#" + card.SerialNumber.ToString() + "#" + card.SubjectName.Name;
             
            document.getElementById("<%=hf_serail_key.ClientID %>").value = serialno;
            document.getElementById("<%=hfname.ClientID %>").value = cardusername;
            document.getElementById("<%=hfcrdnm.ClientID %>").value = crdnm;
            
        }
       
       
        function Activex() {
            try {
            
            
            var certificte = new ActiveXObject("pdfSigner.Class1");
                   
                    var c = certificte.certificate_token();
                    var pk='<%= Session["pk"].ToString() %>';
                    
                    
                    if(c.split('#')[0]==pk)
                    {
            
            var flag='<%= Session["IsSigned"].ToString() %>';
               
               if(flag=='True')
               {
            
             alert("कृपया अपने कार्ड का चयन करें।");
           var certificte = new ActiveXObject("pdfSigner.Class1");
             var   cert = certificte.sel_certificate().split("#");
             var valDate = cert[0];
             var cardcaname = cert[1].split(",");
             var serialno=cert[2];
             var cardusername=cert[3].split(",");
             var crdnm=cert[1];
             // Notafter  validupto    Issuername.name   Authorise issue  serialnumber serialno  subjectname  name 
             // card.NotAfter + "#" + card.IssuerName.Name + "#" + card.SerialNumber.ToString() + "#" + card.SubjectName.Name;
             
            document.getElementById("<%=hf_serail_key.ClientID %>").value = serialno;
            document.getElementById("<%=hfname.ClientID %>").value = cardusername;
            document.getElementById("<%=hfcrdnm.ClientID %>").value = crdnm;           
            
             
                    var a = document.getElementById("<%=hf.ClientID %>").value;
                    var path = document.getElementById("<%=hfyd.ClientID %>").value;
                    var serialkey = document.getElementById("<%=hf_serail_key.ClientID %>").value;

                    var date = document.getElementById("<%=hfdate.ClientID %>").value;
                    var array = path.split(',');
                    var c = certificte.PDFSigner(a, path, serialkey, date);
                    document.getElementById("<%=txt.ClientID %>").value = c;
                    
                    }
                    else
                    
                    {
                    alert("तुम्ही पी. डी.एफ. साइन करू शकत नाही."); 
                    }
                    
                     }
                    else
                    
                    {
                    alert('You are using wrong digital signature..');
                    }
            }
            catch (ex) 
            {
                alert("An exception occurred !! Error name: " + ex.name + ". Error message: " + ex.message);
            }
        }
        // use for card related information
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClientClick="RLACreateMD6();" OnClick="Button1_Click"
                Text="भाग २ " Height="39px" Width="238px" Visible="False" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click"
                Text="PDF दाखवा" Height="39px" Width="238px" OnClientClick="Activex();" /></div>
        <asp:HiddenField ID="hf_serail_key" runat="server" />
        <asp:HiddenField ID="hf" runat="server" />
        <asp:HiddenField ID="hfyd" runat="server" />
        <asp:HiddenField ID="hfdate" runat="server" />
        <asp:HiddenField ID="hf_file" runat="server" />
         <asp:HiddenField ID="hfname" runat="server" />
         <asp:HiddenField ID="hfcrdnm" runat="server" />
        <br />
        <asp:Label ID="lbl" runat="server" Text="PDF"></asp:Label>
        <asp:TextBox  ID="txt" runat="server" Text=""></asp:TextBox>&nbsp;
    </form>
</body>
</html>
