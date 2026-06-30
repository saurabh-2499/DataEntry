<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pg712_view.aspx.vb" Inherits="pg712" Title="७/१२"%>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblmessage" runat="server"></asp:Label>
        <br />
        <br />
        <center>
        <asp:Button ID="btnEdit" runat="server" Text="७/१२ एडिट करणे" ToolTip="७/१२ एडिट करण्यासाठी येथे क्लिक करा." Visible="false"/>&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="७/१२ कन्फर्म करणे" ToolTip="७/१२ कन्फर्म करण्यासाठी येथे क्लिक करा" Visible="false" />
         </center>
        <br />
        <br />
        &nbsp;&nbsp;</div>
    </form>
    
<asp:Image ID="Img712" runat="server" />
</body>
</html>
