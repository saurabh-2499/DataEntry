<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FerfarOLDNEW_summary.aspx.cs" Inherits="FerfarOLDNEW_summary"  Title="	
आदेश व परिशिष्ट ब"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .grid {}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
         <center>        

    <asp:Panel ID="pnl" runat="server"  ScrollBars="Auto"  Width="70%" Height="700px"   >
        <center>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Width="100%" Height="700px"></rsweb:ReportViewer>
            </center>
     
    </asp:Panel>   
            </center> 
    </div>
    </form>
</body>
</html>
