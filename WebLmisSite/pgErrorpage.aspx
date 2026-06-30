<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="pgErrorpage.aspx.cs" Inherits="pgErrorpage" %>
<%@ OutputCache Location="None" VaryByParam ="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body bgcolor="#e0f7d6">
    <form id="form1" runat="server">
    <div>
    <center>
        &nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
        <table style="width: 889px; height: 213px" bgcolor="#ccccff" border="2">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Navy"
                    Text="--  Error Page Detail --"></asp:Label></td>
        </tr>
        <tr>
            <td align="center" colspan="2">
            <marquee  behavior="scroll" direction="left" scrolldelay="250">
                <asp:Label ID="Label5" runat="server" BackColor="Transparent" ForeColor="Red" Text="Please Contact to System Administrator"></asp:Label></marquee>
                </td>
             
        </tr>
     <tr><td style="width: 183px" align="right"> <asp:Label ID="Label2" runat="server" Text="Error On Page  :  " Font-Bold="True" Font-Size="Medium" ForeColor="SaddleBrown"></asp:Label></td><td style="width: 944px" align="left">  <asp:Label ID="lblpagename" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"></asp:Label></td></tr>
    <tr><td style="width: 183px" align="right"> <asp:Label ID="Label1" runat="server" Text="Error :  " Font-Bold="True" Font-Size="Medium" ForeColor="SaddleBrown"></asp:Label></td><td style="width: 944px" align="left">  <asp:Label ID="lblerror" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"></asp:Label></td></tr>
   <tr><td style="width: 183px; height: 35px;" align="right"> <asp:Label ID="Label4" runat="server" Text="Date Time of Error   :" Font-Bold="True" Font-Size="Medium" ForeColor="SaddleBrown"></asp:Label></td><td style="width: 944px; height: 35px;" align="left">  <asp:Label ID="lbldatetime" runat="server" Font-Bold="True" Font-Names="Verdana" ForeColor="Red"  ></asp:Label></td></tr>
    
    </table>
        </center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;</center>
        <center>
            &nbsp;</center>
    </div>
    </form>
</body>
</html>
