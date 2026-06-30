<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rpt_summary.aspx.cs" Inherits="rpt_summary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>पडताळणी अहवालांची (१ ते १४) पुर्तता झाल्याचा संक्षिप्त अहवाल (समरी रिपोर्ट)</title>
    <style type="text/css">
        @media print {
   thead {display: table-header-group;}
   tbody (display: table-footer-group;)
}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lbl_error" runat="server" ForeColor="Red"></asp:Label>
    <asp:HiddenField ID="hfDatabaseName" runat="server" />
        <asp:HiddenField ID="hfSchemaName" runat="server" />
        <asp:HiddenField ID="hfccode" runat="server" />
    </div>
    </form>
    
</body>
</html>
