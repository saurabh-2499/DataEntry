<%@ Page Language="C#" MasterPageFile="~/newmasterweblmis.master" AutoEventWireup="true" CodeFile="downloads.aspx.cs" Inherits="downloads" Title=".डाऊनलोड::राष्ट्रीय  भूमि अभिलेख आधुनिकीकरण कार्यक्रम,महाराष्ट्र राज्य::." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
     
           <div class="login_box">
                
                        <div id="page_header">
                            डाऊनलोड लिंक 
                        </div><div class="clear_br">
            
        </div>
              <marquee direction="up" scrollamount="5" onmouseover="this.stop()" onmouseout="this.start()"
                                                scrolldelay="200" width="400">
                  <center>
                        <table style="text-align: left" id="TABLE1" onclick="return TABLE1_onclick()" cellspacing="2" cellpadding="10">
        <tr style="background:white;width: 304px; height: 35px;" >
            <td>
            
                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="blink_" NavigateUrl="~/Downloads/Signature.msi"   Font-Names="Times New Roman" Font-Bold="True" Font-Size="Larger" ForeColor="Blue">ActiveX Control</asp:HyperLink></td>
        </tr>
        <tr style="background:white; height: 35px;">
            <td style="width: 304px">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Downloads/sc-sed.zip"   Font-Names="Times New Roman" Font-Bold="True" Font-Size="Larger" ForeColor="Blue">SC-SED Driver</asp:HyperLink></td>
        </tr>
        <tr style="background:white;height: 35px;">
            <td style="width: 304px">
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Downloads/AdbeRdr11002_en_US.exe"   Font-Names="Times New Roman" Font-Bold="True" Font-Size="Larger" ForeColor="Blue">Adobe Reader</asp:HyperLink></td>
        </tr>
        <tr style="background:white;height: 35px;">
            <td style="width: 304px; height: 22px;">
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Downloads/ISM 6.3 GOM(1.0.5.9).zip"   Font-Names="Times New Roman" Font-Bold="True" Font-Size="Larger" ForeColor="Blue">ISM 6.3</asp:HyperLink></td>
        </tr>
        <tr style="background:white;height: 35px;">
            <td style="width: 304px">
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Downloads/CuteWriter.exe"   Font-Names="Times New Roman" Font-Bold="True" Font-Size="Larger" ForeColor="Blue">Cute PDF Writer</asp:HyperLink></td>
        </tr>
        <tr style="background:white;height: 35px;">
            <td style="width: 304px">
                <asp:HyperLink ID="HyperLink7" runat="server"   Font-Bold="True"
                    Font-Names="Times New Roman" Font-Size="Larger" ForeColor="Blue" NavigateUrl="~/Downloads/digitalsig_installation.docx"
                    Width="272px">SC-SED Driver Installation Help</asp:HyperLink></td>
        </tr >
        <tr style="background:white;height: 35px;">
            <td style="width: 304px; height: 22px;">
                <asp:HyperLink ID="HyperLink8" runat="server"   Font-Bold="True"
                    Font-Names="Times New Roman" Font-Size="Larger" ForeColor="Blue" NavigateUrl="~/Downloads/Date Settings.docx"
                    Width="159px">Date Setting Help</asp:HyperLink></td>
        </tr>
        <tr style="background:white;height: 35px;">
            <td style="width: 304px; height: 22px" colspan="">
                <asp:HyperLink ID="HyperLink9" runat="server"   Font-Bold="True"
                    Font-Names="Times New Roman" Font-Size="Larger" ForeColor="Blue" NavigateUrl="~/Downloads/Khata_Implementation.docx"
                    Width="256px">दस्त नोंदनी व्यवहाराचा अंमल</asp:HyperLink></td>
        </tr>
        
    </table>
          </center>
</marquee>
    <div class="clear_br">
            
        </div>
              </div>
        
</asp:Content>

