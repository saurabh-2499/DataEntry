<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pg712.aspx.vb" Inherits="pg712" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="scrptmhr1" runat="server"  AsyncPostBackTimeout="360"></asp:ScriptManager>
    <div>
        <asp:Label ID="lblmessage" runat="server"></asp:Label><br />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
            Visible="False" />
        &nbsp;
        <rsweb:ReportViewer ID="ReportViewer712" runat="server" Width="0px"  Height="0px"  ShowPageNavigationControls="false"  ShowExportControls="false" ShowDocumentMapButton="false" ShowPrintButton="false" ShowToolBar="false" ShowRefreshButton="false" ></rsweb:ReportViewer>


    </div>
    </form>
</body>
</html>
