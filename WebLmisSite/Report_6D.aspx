<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="Report_6D.aspx.cs" Inherits="Report_6D"  Title="फेरफार पत्रक"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ OutputCache Location="None" VaryByParam ="None" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>.::राष्ट्रीय भूमि अभिलेख आधुनिकीकरण कार्यक्रम,महाराष्ट्र राज्य::.</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
   
</head>
 <script type="text/javascript" language="javascript">
      

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
               
               
                 var cnc=document.getElementById("<%= hfconcatnatestr.ClientID %>").value;
                  var sevarth='<%= Session["pk"].ToString() %>';
                    var cert=new ActiveXObject("pdfSigner.Class1");
                    
                    document.getElementById("<%= hfSignDataString.ClientID %>").value = cert.SignDataString(cnc,sevarth);
                    }
                   
                    alert("Now you are ready to sign data.");
                    }
                    else
                    
                    {
                    alert('You are using wrong digital signature..');
                    }
            }
            catch (ex)
             {
             //alert("An exception occurred !! Error name: " + ex.name + ". Error message: " + ex.message);
             
               
            }
        }
        
        
        
        
         function pdf() {
            try {
            
          
            
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
            catch (ex) 
            {
                alert("An exception occurred !! Error name: " + ex.name + ". Error message: " + ex.message);
            }
        }
                
        </script>
<body>
    <form id="form1" runat="server">
           <asp:ScriptManager ID="ScriptManager1" runat="server"  AsyncPostBackTimeout="360">
        </asp:ScriptManager>  
        <div>
            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
            <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" Visible="False"
                CssClass="form_lbl" />
            <div class="row">
                <div class="column">
                    <asp:Label ID="Label1" runat="server" Text="जिल्हा " Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:Label ID="lbldistrictname" runat="server"  Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:DropDownList ID="ddldist" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddldist_SelectedIndexChanged"
                        Visible="False" CssClass="form_txt">
                    </asp:DropDownList></div>
            </div>
          
            <div class="row">
                <div class="column">
                    <asp:Label ID="Label2" runat="server" Text="तालुका" Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:Label ID="lbltalukaname" runat="server" Visible="False" CssClass="form_lbl"></asp:Label>
                    <asp:Button ID="Button2" runat="server" OnClientClick="Activex();" Text="डिजिटल स्वाक्षरी निवडा" Width="143px" Height="35px" />
                    <asp:Button ID="Button1" runat="server" Height="34px" Text="डाटा साइन" Width="134px"  OnClick="Button1_Click" />
                    <asp:Button ID="Button3" runat="server" Height="35px" OnClick="Button2_Click" OnClientClick="pdf();"
                        Text="साइन PDF" Width="122px" Enabled="False" />
                    <asp:Label ID="lblcntstr" runat="server" ></asp:Label>
                    <asp:Label ID="lblservrth" runat="server" Visible="False" ></asp:Label></div>
                <div class="column">
                    <asp:DropDownList ID="ddltal" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddltal_SelectedIndexChanged"
                        Visible="False" CssClass="form_txt">
                    </asp:DropDownList></div>
            </div>
            <div class="row" >
                <div class="column">
                    <asp:Label ID="Label3" runat="server" Text="गाव :" Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:Label ID="lblvillagename" runat="server" Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:DropDownList ID="ddlgaon" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlgaon_SelectedIndexChanged"
                        Visible="False" CssClass="form_txt">
                    </asp:DropDownList></div>
            </div>
            <div class="row">
                <div class="column">
                    <asp:Label ID="Label4" runat="server" Text="फेरफार क्रमांक:" Visible="False" CssClass="form_lbl"></asp:Label></div>
                <div class="column">
                    <asp:TextBox ID="txtmut_no" runat="server" Visible="False" CssClass="form_txt"></asp:TextBox></div>
                <div class="column">
                    <asp:Button ID="btnsearch" runat="server" OnClick="btnsearch_Click" Text="Search"
                        Visible="False" CssClass="form_lbl" /></div>
            </div>
            <div class="row">
                <asp:Label ID="lblmessage" runat="server" CssClass="form_lbl_red_s"></asp:Label></div>
          <%--  <asp:Panel ID="Panel1" runat="server" Visible="False">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                    ReuseParameterValuesOnRefresh="True" HasCrystalLogo="False" Visible="False" OnUnload="CrystalReportViewer1_Unload" />
            </asp:Panel>--%>

            <asp:Panel ID="Panel1" runat="server" Visible="true">          

            <center>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Width="0px"  Height="0px"  ShowPageNavigationControls="false"  ShowExportControls="false" ShowDocumentMapButton="false" ShowPrintButton="false" ShowToolBar="false" ShowRefreshButton="false"></rsweb:ReportViewer>
            
                </center>

            </asp:Panel>

            
            <asp:HiddenField ID="hftype" runat="server" />
            
            <asp:HiddenField ID="hfCcode" runat="server" />
            <asp:HiddenField ID="hdfMutno" runat="server" />
            <asp:HiddenField ID="hdfccode" runat="server" />
            <asp:HiddenField ID="hdfMutType" runat="server" />
            <asp:HiddenField ID="hdfMutName" runat="server" />
            <asp:HiddenField ID="hdfuserid" runat="server" />
            <br />
            <asp:HiddenField ID="hfconcatnatestr" runat="server" />
            <asp:HiddenField ID="hfservarthpk" runat="server" />
            <asp:HiddenField ID="hfSignDataString" runat="server" />
            <br />
            <asp:TextBox ID="txt" runat="server" Text=""></asp:TextBox>
            <br />
            <asp:HiddenField ID="hf_serail_key" runat="server" />
            <asp:HiddenField ID="hf" runat="server" />
            <asp:HiddenField ID="hfyd" runat="server" />
            <asp:HiddenField ID="hfdate" runat="server" />
            <asp:HiddenField ID="hf_file" runat="server" />
            <asp:HiddenField ID="hfname" runat="server" />
            <asp:HiddenField ID="hfcrdnm" runat="server" />
        </div>
    </form>
</body>
</html>
