<%@ Page Language="C#" MasterPageFile="~/newmasterweblmis.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"
    CodeFile="login.aspx.cs" Inherits="pgLogin" Title="लॉगिन फॉर्म" %>
<%@ OutputCache Location="None" VaryByParam ="None" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Button ID="btnhome" runat="server" OnClick="btnhome_Click" Text="मुखपृष्ठ"
        ToolTip="Click here to go  on Home Page (मुखपृष्ठ)" CssClass="form_lbl" />
    <div id="site_main_content">
        <div class="login_box">
            <div class="log_row">
                <div class="log_center">
                    <b>एक्सपर्ट लॉगइन</b></div>
            </div>
            <div class="clear">
            <br /> </div>
            <div class="row">
                <div class="log_col">
                    <asp:Label ID="lblUserName" runat="server" Text="युजरनेम" ToolTip="युजरनेम" CssClass="form_lbl"></asp:Label></div>
                <div class="log_col">
                    <asp:TextBox ID="txtLoginName" runat="server" MaxLength="10" CssClass="form_txt">MutTech</asp:TextBox></div>
            </div>
            <div class="clear">
            </div>
            <div class="row">
                <div class="log_col">
                    <asp:Label ID="lblPassword" runat="server" Text="पासवर्ड"
                        ToolTip="पासवर्ड" CssClass="form_lbl"></asp:Label></div>
                <div class="log_col">
                    <asp:TextBox ID="txtPassword" runat="server" MaxLength="10" CssClass="form_txt">admin</asp:TextBox></div>
            </div>
            <div class="clear">
             <br /></div>
            <center>
                <asp:Button ID="cmdLogin" runat="server" OnClick="cmdLogin_Click" Text="लॉगिन" ToolTip="लॉगिन" CssClass="form_lbl"/>
                <br />
                <asp:Label ID="lblerror" runat="server" CssClass="form_lbl_red_s"></asp:Label>
                <asp:Label ID="Errormsg" runat="server" CssClass="form_lbl_red_s"></asp:Label>
            </center>
        </div>
    </div>

    <script src="Javascript/md5-paj.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript"> 

    </script>

    <!-- <table id="TABLE2" border="0" cellpadding="0" cellspacing="0" width="255">
                    <tr>
                        <td style="color: #000033; font-family: Verdana, 'Times New Roman', 'Book Antiqua';
                            background-image: url(Image/imgMenuTop.JPG); background-color: transparent;"
                            colspan="3" height="40" width="255">
                            <div align="center">
                                <font color="#000000" face="Tahoma"><b>Login</b></font></div>
                        </td>
                    </tr>
                    <tr>
                        <td background="Image/imgSidePanelLeft.JPG" height="80" style="width: 5px">
                        </td>
                        <td height="80" style="width: 189px; text-align: center; vertical-align: middle;">
                            <marquee align="Center" scrolldelay="250" direction="up" loop="true" height="100">
                                <b><a href="http://164.100.111.5:8080/mahabhulekh/">Mahabhulekh</a></b><br />
                                <br />
                                <b><a href="http://igrMAHARASHTRA.gov.in/">Registration</a></b><br />
                                <br />
                                <b><a href="http://www.mah.nic.in/">NIC</a><br />
                                </b>
                                <br />
                                <br />
                                <b><a>Design & Developed By</a></b><br />
                                <br />
                                <b><a>Sandeep Tandale</a></b><br />
                                <br />
                            </marquee>
                        </td>
                        <td background="Image/imgSidePanelLeft.JPG" height="80" style="width: 5px">
                        </td>
                    </tr>
                    <tr>
                        <td background="Image/imgBottom.JPG" colspan="3" height="32">
                        </td>
                    </tr>
                </table>-->
    <asp:HiddenField ID="HashPass" runat="server" Visible="True" />
    <asp:HiddenField ID="SaltStr" runat="server" Visible="True" />
    
    
</asp:Content>
