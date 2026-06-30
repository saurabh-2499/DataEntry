<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="pgmutchecklist.aspx.cs" Inherits="pgmutchecklist"
    Title=".::राष्ट्रीय  भूमि अभिलेख आधुनिकीकरण कार्यक्रम,महाराष्ट्र राज्य::."  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" lang="mr">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="राष्ट्रीय  भूमि अभिलेख आधुनिकीकरण कार्यक्रम,बोजा फेरफार ,तहसिलदार,तलाठी,सर्कल ऑफिसर,तालुका ,जिल्हा,गाव,खाता,वारस,अंगठा तपासनी,७/१२ प्रमाणीत करणे,फ़ेरफ़ार रद्द करणे,
  तलाठि शेरा,७/१२ पहा" />
    <title>.::राष्ट्रीय भूमि अभिलेख आधुनिकीकरण कार्यक्रम,महाराष्ट्र राज्य::.</title>
    <link href="MainpageStyleSheet.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="stylescript/style.css" type="text/css" />
    <link id="Link1" rel="stylesheet" href="stylescript/StyleSheet.css" type="text/css"  runat="server" />

  

   

  
    <link href="CSS/dropdown.css" rel="stylesheet" type="text/css" />
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="Javascript/textsizer.js"></script>

   

    <script type="text/javascript" language="javascript">
javascript:window.history.forward(1)
    </script>

    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
       <br /><br /> <div id="main_content">
           <marquee direction="left" scrollamount="5" loop="true" width="100%" bgcolor="#ffffff"
                        onmouseover="this.stop();" onmouseout="this.start();">
<asp:Label id="Label4" runat="server" Text="ज्या पर्यायाच्या (एक/अनेक) आधारे हा फेरफार प्रमाणित करावयाचा आहे त्या पर्यायास निवडावे.(Click करावे) जे पर्याय (एक/अनेक) फेरफार प्रमाणित करण्यासाठी उपयुक्त नाहीत असे आपणास वाटते त्यांना निवडू नये.(Click करू नये)
" ForeColor="red" Font-Bold="True" ></asp:Label>

</marquee>
            <center>
                <div style="text-align: left">
                    &nbsp;<asp:Label ID="lblvillage" runat="server" CssClass="form_lbl" Text="गाव :"></asp:Label>
                    <asp:Label ID="lblvillagename" runat="server" CssClass="form_lbl" ForeColor="Red" Font-Bold="True"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1"
                        runat="server" Text="फ़ेरफ़ार क्रमांक :" CssClass="form_lbl"></asp:Label><asp:Label
                            ID="lblMutNo" runat="server" CssClass="form_lbl" ForeColor="Red" Font-Bold="True"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:Label ID="Label2" runat="server" Text="फ़ेरफ़ार प्रकार :" CssClass="form_lbl"></asp:Label><asp:Label
                        ID="lblmutype" runat="server" CssClass="form_lbl" ForeColor="Red" Font-Bold="True"></asp:Label>
                    <applet id="Object1" type="application/x-java-applet;jpi-version=1.6" height="150"
                        alt="Applet not loaded" archive="signapplet.jar" width="150" code="JSignApplet.class"
                        name="JSignApplet" style="width: 1px; height: 7px">
                        <param name="codebase_lookup" value="false">
                        <param name="java_arguments" value="-Djnlp.packEnabled=true">
                    </applet>

                    <script type="text/javascript" language="javascript">
                     function Activex() {
            try {      
                     var cnc1=document.getElementById("<%= hfconcatnatestr.ClientID %>").value;
                  var pk='<%= Session["pk"].ToString() %>';
                  // alert(sevarth);
                    var cert=new ActiveXObject("pdfSigner.Class1");
                   //alert(cert); 
                    document.getElementById("<%= hfSignDataString.ClientID %>").value = cert.SignDataString(cnc1,pk); 

                       }
            catch (e) {
             alert("An exception occurred !! Error name: " + e.name + ". Error message: " + e.message);
               
                  }
        }

                    </script>

                    <br />
                    <br />
                    <div class="row">
                    
                    <div class="partition">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="form_lbl" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged1" AutoPostBack="True">
                        </asp:CheckBoxList></div>
                        <div class="row">
                        <asp:Button ID="Button1" runat="server" Text="जमीन मालकाने" Visible="False" OnClick="Button1_Click"  Width="110"/>
                    <asp:Button ID="Button2" runat="server" Text="मुखत्यार धारकाने " Visible="False" OnClick="Button2_Click" Width="110" />
                    </div><br />
                    <div class="row">
                            <asp:Label ID="Label5" runat="server" Text="Label" Visible="False" Width="110"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" Visible="False"  CssClass="form_txt_160" AutoPostBack="True" OnTextChanged="CheckBoxList1_SelectedIndexChanged1"></asp:TextBox>
                            <asp:Label ID="Label6" runat="server" Text="Label" Visible="False" Width="110"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" Visible="False"  CssClass="form_txt_160" AutoPostBack="True" OnTextChanged="CheckBoxList1_SelectedIndexChanged1"></asp:TextBox></div><br />
                            <div class ="row">
                        <asp:Label ID="Label7" runat="server" Text="Label" Visible="False" Width="110"></asp:Label>
                        <asp:TextBox ID="TextBox3" runat="server" Visible="False" CssClass="form_txt_160" AutoPostBack="True" OnTextChanged="CheckBoxList1_SelectedIndexChanged1"></asp:TextBox>
                        <asp:Label ID="Label8" runat="server" Text="Label" Visible="False" Width="110"></asp:Label>
                        <asp:TextBox ID="TextBox4" runat="server" Visible="False" CssClass="form_txt_160" AutoPostBack="True" OnTextChanged="CheckBoxList1_SelectedIndexChanged1"></asp:TextBox>&nbsp;
                    </div><br />
                        <div class ="row">
                        <asp:Button ID="Button3" runat="server" Text="भोगवटा वर्ग १" Visible="False" OnClick="Button3_Click" Width="110"/>
                        <asp:Button ID="Button4" runat="server" Text="भोगवटा वर्ग २" Visible="False" OnClick="Button4_Click"  Width="110"/></div>
                    </div>
                    <br /><br />
                    
                   <div class="clear"></div> <br />
                   <center>
                   <div class="row">
                        <div class="column_25perwomargin">
                            <asp:Label ID="Label3" runat="server" Text="नोंद प्रमाणन आधिकरी  शेरा" CssClass="form_lbl"
                                meta:resourcekey="Label2Resource1"></asp:Label></div>
                                                        <asp:TextBox ID="txtcricleDeal" TabIndex="4" runat="server" CssClass="form_txt_query"
                            meta:resourcekey="txtDealResource1" Height="77px" TextMode="MultiLine" Width="683px" AutoPostBack="True" OnTextChanged="txtcricleDeal_TextChanged"></asp:TextBox><br />
                    </div></center><br />
<%--                    <div class="row" style="display:none">
--%>                       
<div class ="row"> <div class="column_25perwomargin">
                            </div>
                        
                        <asp:TextBox ID="txtdeal" runat="server" Height="132px" ReadOnly="True" TextMode="MultiLine"
                            Width="850px" Visible=False></asp:TextBox>
                            </div>
                   <div class="clear"></div> <br />
                   <center>
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Visible="False"></asp:Label><br /></center>
                    <br />
                   <center>
                       <asp:Button ID="btndeal" runat="server" OnClick="btndeal_Click" Text="व्यवहाराचा तपशील" Visible="False" />
                       <asp:Button ID="btn_save" runat="server" OnClick="btn_save_Click" Text="साठवा" CssClass="form_lbl" /></center> 
                  <div class="clear"></div>  <br />
                    <asp:HiddenField ID="hfvillagecode" runat="server" />
                </div>
            </center>
            
            <asp:HiddenField ID="hfmuationnumber" runat="server" />
            
            <asp:HiddenField ID="hfmuttype" runat="server" />
            <asp:HiddenField ID="hfSignature" runat="server" />
           <asp:HiddenField ID="hfSignDataString" runat="server" />
           <asp:HiddenField ID="hfrorSignDataString" runat="server" />
           <asp:HiddenField ID="hfconcatnatestr" runat="server" />
        </div>
    </form>
</body>
</html>
