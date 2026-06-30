<%@ Page Language="C#" MasterPageFile="~/newmasterweblmis.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"
    CodeFile="pgLogout.aspx.cs" Inherits="pgLogout" Title=".लॉग आऊट::राष्ट्रीय  भूमि अभिलेख आधुनिकीकरण कार्यक्रम,महाराष्ट्र राज्य::." %>

<%--<%@ OutputCache Location="None" VaryByParam="None" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- script to disable back button. -->

    <script type="text/javascript">
        function disableBackButton()
        {
            window.history.forward();
        }
            setTimeout("disableBackButton()", 0);
    </script>

    <!-- end script to disable back button. -->
   <%-- <p>
        Sorry, your Session has expired.
    </p>--%><center>
    <%--<div id="main_content">--%>
        
            <div id="site_main_content" >
                <asp:Panel ID="pnl_Login" runat="server">
                    <div class="login_box">
                        <div id="page_header">
                            लॉग आऊट
                        </div>
          
            <asp:Label ID="Label1" runat="server" Text="तुम्ही वेबसाईट मधून बाहेर पडलेले आहात" CssClass="form_lbl_B"></asp:Label><br />
            <br />
            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
            <asp:LinkButton ID="LinkLogin" runat="server" Style="position: relative; left: 0px;
                top: 27px;" OnClick="LinkLogin_Click"  CssClass="linkButton_btn" Font-Underline="false">प्रवेश करण्यासाठी येथे क्लिक करा</asp:LinkButton>
                        <asp:Label ID="Label2" runat="server" ForeColor="Red" Visible="false"></asp:Label><br />
            <br />
            <br />
           </div> </asp:Panel> 
              </div>   
          <%--</div> --%>

            </center>
    
</asp:Content>
