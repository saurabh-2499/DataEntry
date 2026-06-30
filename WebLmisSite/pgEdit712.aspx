<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgEdit712.aspx.cs" Inherits="pgEdit712" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script runat="server">

</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <script language="javascript" type="text/javascript">
         function ECT() {
             var txt = "प्रतिबंधीत सर्व्हे / गट क्रमांक";
             var disp_txt;
             var disp_DBA;
             if (document.getElementById("<%=hfRptName.ClientID%>").value != '') {
           disp_txt = txt + "\n " + document.getElementById("<%=hfRptName.ClientID%>").value + " मध्ये त्रुटी असल्यामुळे जमाबंदी आयुक्त कार्यालय यांचे परिपत्रक क्र./रा.भू.अ.आ.का.४/डे.दु.आ./प्र.क्र. १७/२०१४ दि. २३/०७/२०१४ अन्वये हा सर्व्हे क्रमांक इ-फ़ेरफ़ार घेण्यासाठी सध्य: प्रतिबंधीत आहे सबब हा फ़ेरफ़ार या सर्व्हे / गट क्रमांकावर घेता येनार नाही याची नोद घ्यावी !!!\n";

       }
       if (document.getElementById("<%=hfDBATool.ClientID%>").value != '') {
        disp_DBA = "\nडेटा दुरुस्ती आज्ञावली एक्सटेंडेड (DBA Tool)  -\n " + document.getElementById("<%=hfDBATool.ClientID%>").value + " मध्ये त्रुटी असल्यामुळे या सर्व्हे क्रमांकवर इ-फ़ेरफ़ार घेण्याआधी योग्य ती दुरुस्ती करावी याची नोंद घ्यावी !!!\n";

       }
       alert(disp_txt + disp_DBA);
   }

   function ECT_Other() {
       alert(document.getElementById("<%=hfOther.ClientID%>").value + " मध्ये त्रुटी असल्यामुळे हा सर्व्हे क्रमांक इ-फ़ेरफ़ार घेण्यासाठी सध्य: प्रतिबंधीत आहे सबब हा फ़ेरफ़ार या सर्व्हे / गट क्रमांकावर घेता येणार नाही याची नोंद घ्यावी !!!\n");
    }


         function confirm_save() {

             if (!confirm('७/१२ संपुर्ण एडिट करुन झाला आहे का ? असल्यास OK क्लिक करा. एडिट करायचा असल्यास Cancel क्लिक करा.')) {


                 var confirm_value = document.createElement("INPUT");
                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 confirm_value.value = "notOk";
                 document.forms[0].appendChild(confirm_value);
                 return false;
             }
         }

         function confirm_delete_mut() {


             if (confirm("फेरफार क्रमांक या यादीत नको असल्यास OK क्लिक करा. ") == true) {
                 document.getElementById('ctl00_ContentPlaceHolder1_HiddenField1').value = "true";
                 return true;
             }
             else {
                 document.getElementById('ctl00$ContentPlaceHolder1$HiddenField1').value = "false";
                 return false;
             }
             return false;
         }

         function confirm_genOldNewRpt() {

             if (!confirm('या आदेशा तील निवडलेले सर्व सर्व्हे / गट क्रमांक एडिट करावयाचे काम पुर्ण झाले असुन तहसिलदारांच्या दुरुस्त्या मान्येतेचा अहवाल जनरेट करावयाचा असल्यास OK क्लिक करा. एडिट करायच काम राहिले असल्यास Cancel क्लिक करा.')) {
                 var confirm_value = document.createElement("INPUT");
                 confirm_value.type = "hidden";
                 confirm_value.name = "confirm_value";
                 confirm_value.value = "notOk";
                 document.forms[0].appendChild(confirm_value);
                 
                 return false;
             }


         }


     </script><div class="row"> 
        &nbsp;&nbsp;<asp:Label ID="lblSurveySelcted" runat="server" Text="निवडलेला सर्व्हे क्रमांक :-" Font-Bold="True" Visible="true" Font-Names="Sakal Marathi"></asp:Label> <asp:Label ID="lblSurveyNo" runat="server" Font-Bold="True" Font-Names="Sakal Marathi" ForeColor="Purple" Visible="true"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="lblText" runat="server" Text="हा हस्तलिखीत ७/१२ प्रमाणे  अद्यावत/दुरुस्त करण्यात येत आहेत." Font-Bold="True" Font-Names="Sakal Marathi" Visible="false"></asp:Label>&nbsp;&nbsp;&nbsp;
                       <asp:Button ID="btnView712" Text="७/१२ पहा" runat="server" ToolTip="७/१२ पाहणे" Visible="true" CssClass="form_lbl" OnClick="btnView712_Click"  /> <br />
        &nbsp;&nbsp;<asp:Label ID="lbltransNoselected" runat="server" Text="परिशिष्ट क्रमांक :-" Font-Bold="True" Font-Names="Sakal Marathi" Visible="false"></asp:Label> <asp:Label ID="lblTransNoDisp" runat="server" Font-Bold="True" ForeColor="Purple" Visible="false" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
      </div>
    <br />

    <DIV class="all_pnl">
                 <asp:Panel id="Panellinks" runat="server" >
                 <CENTER><H3>
                 <asp:Label id="Label85" runat="server" Text=" ७/१२ वरील खालील भागांमध्ये माहिती अद्यावत/दुरुस्त करावयाची आहे." CssClass="form_b"></asp:Label></H3>
                     <asp:LinkButton id="lnkKshetra" tabIndex=1 onclick="lnkKshetra_Click" runat="server" CssClass="linkButton_btn" ToolTip="क्षेत्र" OnClientClick="return confirm_Search();" Font-Underline="false" Font-Bold="true" Enabled="False">क्षेत्र</asp:LinkButton>&nbsp;
                 <asp:LinkButton id="lnkBhudharna" tabIndex=2 onclick="lnkBhudharna_Click" runat="server" CssClass="linkButton_btn" ToolTip="भुधारणा" OnClientClick="return confirm_Search();" Font-Underline="false" Font-Bold="true" Enabled="False">भुधारणा</asp:LinkButton>&nbsp;
                  <asp:LinkButton id="lnkBhogvatdarInfo" tabIndex=3 onclick="lnkBhogvatdarInfo_Click" runat="server" CssClass="linkButton_btn" ToolTip="भोगवटादार" OnClientClick="bhogavat();" Font-Underline="false" Font-Bold="true" Enabled="False">भोगवटादाराची माहिती</asp:LinkButton>&nbsp; 
                     <asp:LinkButton id="lnkKul" tabIndex=4 onclick="lnkKul_Click" runat="server" CssClass="linkButton_btn" ToolTip="कुळ" OnClientClick="return confirm_Search();" Font-Underline="false" Font-Bold="true" Enabled="False" Visible="true">कुळ</asp:LinkButton>&nbsp;
                      <asp:LinkButton id="lnkEtarAdhikar" tabIndex=5 onclick="lnkEtarAdhikar_Click" runat="server" CssClass="linkButton_btn" ToolTip="इतर अधिकार" OnClientClick="return confirm_Search();" Font-Underline="false" Font-Bold="true" Enabled="False">इतर अधिकार</asp:LinkButton>&nbsp;
                    <asp:LinkButton id="lnkEtarFerfarNo" tabIndex=6 onclick="lnkEtarFerfarNo_Click" runat="server" CssClass="linkButton_btn" ToolTip="इतर फेरफार क्रमांक" OnClientClick="return confirm_Search();" Font-Underline="false" Font-Bold="true" Enabled="False">इतर फेरफार क्रमांक</asp:LinkButton>&nbsp; 
                      <asp:LinkButton id="lnkagriLocalName" tabIndex=7  runat="server" CssClass="linkButton_btn" ToolTip="शेतीचे स्थानिक नाव व सीमा आणि भुमापन चिन्हे भरण्यासाठी येथे क्लिक करा."  Font-Underline="false" Font-Bold="true" Enabled="False" OnClick="lnkagriLocalName_Click">शेतीचे स्थानिक नाव व सीमा आणि भुमापन चिन्हे</asp:LinkButton>&nbsp;

                     <asp:LinkButton id="lnk12part" tabIndex=8  runat="server" CssClass="linkButton_btn" ToolTip="पीक पाहणीची  दुरुस्ती " OnClientClick="return confirm_Search();" Font-Underline="false" Font-Bold="true" OnClick="lnk12part_Click"  Visible="false" >पीक पाहणीची  दुरुस्ती </asp:LinkButton>&nbsp; 
                     <%-- seemanew--%></CENTER></asp:Panel>
<BR /></DIV>


    <asp:Panel id="Panel41" runat="server" CssClass="popupPnl_holderhakkden" Visible="False" BackColor="#EFEFEF">
                <br /><CENTER><asp:Label id="Label19" runat="server" Text="क्षेत्रातील बदल "  Font-Bold="True" CssClass="form_lblhead"></asp:Label></CENTER>
<HR />
<DIV class="row"><DIV class="column" align="right"><asp:Label id="Label86" runat="server" Text="क्षेत्राचे एकक निवडा" CssClass="form_lbl"></asp:Label> </DIV><DIV class="column_large" align="left"><asp:RadioButtonList id="RadioButtonList1" runat="server" CssClass="form_lbl" Height="1px" Enabled="False" RepeatDirection="horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="आर.चौ.मी">आर.चौ.मी</asp:ListItem>
                                    <asp:ListItem Value="1" Text="हे.आर.चौ.मी">हे.आर.चौ.मी</asp:ListItem>
                                 </asp:RadioButtonList> </DIV></DIV><DIV class="clear_br"></DIV><DIV class="row"><DIV class="column_s_wid6"></DIV>
                                 
                                 <DIV class="column_margin10_adj"><asp:Label id="lblmut_no2" runat="server" CssClass="form_lbl" Visible="False">फेरफार क्रमांक</asp:Label> </DIV>
                                 <DIV class="column_womargin"><asp:TextBox id="txtmut_no2" runat="server" CssClass="form_txt" Visible="False"></asp:TextBox> </DIV></DIV><DIV class="clear_br"></DIV>
                                 <DIV class="partition"><CENTER><asp:Label id="Label33" runat="server" Text="<u> मुळ ७/१२ वरिल क्षेत्र </u>" CssClass="form_b_color"></asp:Label> </CENTER>
                                 <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label47" runat="server" Text="जिरायत" CssClass="form_lbl"></asp:Label> 
                                 </DIV><DIV class="column_womargin"><asp:TextBox id="txtoldArea1" runat="server" CssClass="form_txt_xs" Enabled="False" MaxLength="10">0.0000</asp:TextBox> </DIV>
                                 <DIV class="column_20per"><asp:Label id="Label56" runat="server" Text="जुडी" CssClass="form_lbl"></asp:Label> </DIV>
                                 <DIV class="column_womargin">
                                 <asp:TextBox id="txtoldArea10" runat="server" CssClass="form_txt_xs" Enabled="False" MaxLength="10">0.0000</asp:TextBox> </DIV></DIV>
                                     <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label48" runat="server" Text="बागायत" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea2" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False">0.0000</asp:TextBox> </DIV>
                                         <DIV class="column_20per"><asp:Label id="Label54" runat="server" Text=" पो.ख. वर्ग-१" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea8" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False">0.0000</asp:TextBox> </DIV></DIV>
                                     <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label49" runat="server" Text="तरी" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea3" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False">0.0000</asp:TextBox> </DIV>
                                         <DIV class="column_20per"><asp:Label id="Label55" runat="server" Text=" पो.ख. वर्ग-२" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea9" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False">0.0000</asp:TextBox> </DIV></DIV>
                                     <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label50" runat="server" Text="वरकस" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea4" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False">0.0000</asp:TextBox> </DIV>
                                         <DIV class="column_20per"><asp:Label id="Label53" runat="server" Text="आकारणी" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea7" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False">0.00</asp:TextBox> </DIV></DIV>
                                     <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label51" runat="server" Text="इतर" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea5" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False">0.0000</asp:TextBox> </DIV>
                                         <DIV class="column_20per"><asp:Label id="Label57" runat="server" Text=" एन. ए .क्षेत्र" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea11" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False">0</asp:TextBox> </DIV></DIV>
                                     <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label52" runat="server" Text=" एकुण लागवड योग्य" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea6" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False"></asp:TextBox> </DIV>
                                         <DIV class="column_20per"><asp:Label id="Label58" runat="server" Text="आकारणी" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea12" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False">0.00</asp:TextBox> </DIV></DIV>
                                     <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2">&nbsp;</DIV><DIV class="column_womargin">&nbsp;</DIV>
                                         <DIV class="column_20per"><asp:Label id="Label59" runat="server" Text="फेरफार क्र" CssClass="form_lbl"></asp:Label> </DIV>
                                         <DIV class="column_womargin"><asp:TextBox id="txtoldArea13" runat="server" MaxLength="10" CssClass="form_txt_xs" Enabled="False"></asp:TextBox> </DIV></DIV></DIV>
                    <DIV class="partition"><%--class="partition"--%><CENTER><asp:Label id="Label60" runat="server" Text="<u> क्षेत्रात होणारे बदल </u>" CssClass="form_b_color"></asp:Label> </CENTER>
<DIV class="clear_br"></DIV>
                        <DIV class="row"><DIV class="inner_column2"><asp:Label id="Label34" runat="server" Text="जिरायत" CssClass="form_lbl"></asp:Label></DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea1" tabIndex=1 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="जिरायत क्षेत्र टाका"  CausesValidation="True">0.0000</asp:TextBox> </DIV>
                            <DIV class="column_20per"><asp:Label id="Label43" runat="server" Text="जुडी" CssClass="form_lbl"></asp:Label> </DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea10" tabIndex=9 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="कृपया जुडी टाका">0.0000</asp:TextBox> </DIV></DIV>
                        <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label35" runat="server" Text="बागायत" CssClass="form_lbl"></asp:Label></DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea2" tabIndex=2 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="बागायत क्षेत्र टाका"  CausesValidation="True">0.0000</asp:TextBox> </DIV>
                            <DIV class="column_20per"><asp:Label id="Label41" runat="server" Text=" पो.ख. वर्ग-१" CssClass="form_lbl"></asp:Label> </DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea8" tabIndex=7 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="कृपया पो.ख. वर्ग-१ टाका" >0.0000</asp:TextBox> </DIV></DIV>
                        <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label36" runat="server" Text="तरी" CssClass="form_lbl"></asp:Label></DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea3" tabIndex=3 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="तरी क्षेत्र टाका" >0.0000</asp:TextBox></DIV>
                            <DIV class="column_20per"><asp:Label id="Label42" runat="server" Text=" पो.ख. वर्ग-२" CssClass="form_lbl"></asp:Label> </DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea9" tabIndex=8 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="कृपया  पो.ख. वर्ग-२ टाका" >0.0000</asp:TextBox> </DIV></DIV>
                        <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label37" runat="server" Text="वरकस " CssClass="form_lbl" ToolTip="वरकस क्षेत्र टाका"></asp:Label> </DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea4" tabIndex=4 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="क्षेत्र टाका" >0.0000</asp:TextBox></DIV>
                            <DIV class="column_20per"><asp:Label id="Label40" runat="server" Text="आकारणी" CssClass="form_lbl"></asp:Label> </DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea7" tabIndex=6 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="कृपया आकारणी टाका" >0.00</asp:TextBox> </DIV></DIV>
                        <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label38" runat="server" Text="इतर" CssClass="form_lbl"></asp:Label> </DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea5" tabIndex=5 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="ईतर क्षेत्र टाका" >0.0000</asp:TextBox> </DIV>
                            <DIV class="column_20per"><asp:Label id="Label44" runat="server" Text=" एन. ए .क्षेत्र" CssClass="form_lbl"></asp:Label> </DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea11" tabIndex=10 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="कृपया  एन. ए .क्षेत्र टाका"  CausesValidation="True" AutoPostBack="True" OnTextChanged="txtNewArea11_TextChanged">0</asp:TextBox> </DIV></DIV>
                        <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label39" runat="server" Text=" एकुण लागवड योग्य" CssClass="form_lbl"></asp:Label> </DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea6" tabIndex=5 runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="False" CausesValidation="True" AutoPostBack="True" ></asp:TextBox> </DIV>
                            <DIV class="column_20per"><asp:Label id="Label45" runat="server" Text="आकारणी" CssClass="form_lbl"></asp:Label> </DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea12" tabIndex=11 runat="server" CssClass="form_txt_xs" MaxLength="10" ToolTip="कृपया आकारणी टाका" AutoPostBack="True" >0.00</asp:TextBox> </DIV></DIV>
                        <DIV class="clear_br"></DIV><DIV class="row"><DIV class="inner_column2"><asp:Label id="Label46" runat="server" Text="फेरफार क्र" CssClass="form_lbl"></asp:Label> </DIV>
                            <DIV class="column_womargin"><asp:TextBox id="txtNewArea13" runat="server" CssClass="form_txt_xs" MaxLength="10" Enabled="True"></asp:TextBox> </DIV></DIV></DIV>
                    <DIV class="clear_br"></DIV><DIV class="row"><CENTER><asp:Label id="Label65" runat="server" CssClass="form_lbl_red_s"></asp:Label> 
                        <asp:Label id="Label66" runat="server" CssClass="form_lbl_red_s"></asp:Label> </CENTER></DIV>
                    <DIV class="clear_br"><CENTER><asp:Button id="btnKshetraExit" tabIndex=12 onclick="btnKshetraExit_Click" runat="server" Text="माहिती साठवा" CssClass="form_lbl" ToolTip="माहिती साठवा"></asp:Button>&nbsp; <asp:Button id="btnback" onclick="btnback_Click" runat="server" Text="मागे जा" CssClass="form_lbl" ToolTip="मागे जा"></asp:Button></CENTER></DIV></asp:Panel>

    <div id="div_bhudharna" class="ontop"></div>
                <asp:Panel id="Panel2" runat="server" CssClass="popupPnl_bhudarnanew" Visible="false" BackColor="#EFEFEF">
                <BR />
                <CENTER><asp:Label id="Label20" runat="server" Text="भुधारणातील बदल"  Font-Bold="True" CssClass="form_lblhead"></asp:Label></CENTER>
<HR />
<DIV class="row"><DIV class="column_s_wid6"></DIV><!-- <script language="javascript" type="text/javascript">Blink('prem_hint');</script>--><DIV class="column_margin10_adj"><asp:Label id="lblmut_no1" runat="server" CssClass="form_lbl" Visible="False">फेरफार क्रमांक</asp:Label> </DIV><DIV class="column_womargin"><asp:TextBox id="txtmut_no1" runat="server" CssClass="form_txt" Visible="False"></asp:TextBox> </DIV></DIV><DIV class="row">
<DIV class="partition"><CENTER><asp:Label id="Label27" runat="server" Text="<u> मुळ माहिती </u>" CssClass="form_b_color"></asp:Label> </CENTER>
<DIV class="clear_br"><BR /></DIV><DIV class="row"><DIV class="column35_wo"><asp:Label id="Label30" runat="server" Text="भुधारणा" CssClass="form_lbl"></asp:Label> </DIV>
<DIV class="column35_wo"><asp:DropDownList id="ddltenure2" runat="server" CssClass="form_drp_97" Enabled="False" AutoPostBack="True">
                                    </asp:DropDownList> </DIV></DIV><DIV class="clear_br"><BR /></DIV><DIV class="row"><DIV class="column35_wo"><asp:Label id="Label31" runat="server" Text="उप भुधारणा" CssClass="form_lbl"></asp:Label> </DIV><DIV class="column35_wo"><asp:DropDownList id="ddltenure22" runat="server" CssClass="form_drp_97" Enabled="False" AutoPostBack="True">
                                    </asp:DropDownList> </DIV></DIV><DIV class="clear_br"><BR /></DIV><DIV class="row"><DIV class="column35_wo"><asp:Label id="Label94" runat="server" Text="उप-उपभुधारणा" CssClass="form_lbl"></asp:Label> </DIV><DIV class="column35_wo"><asp:DropDownList id="ddltenure23" runat="server" CssClass="form_drp_97" Enabled="False" AutoPostBack="True">
                                    </asp:DropDownList> </DIV></DIV><DIV class="clear_br"><BR /></DIV></DIV>
                                   <DIV >
                                    <asp:Label id="Label26" runat="server" Text="<u> नविन माहिती </u>" CssClass="form_b_color" ></asp:Label></DIV>
                                     <DIV class="partition"><DIV class="clear_br"><BR /></DIV><DIV class="row"><DIV class="column35_wo"><asp:Label id="Label28" runat="server" Text="भुधारणा" CssClass="form_lbl" Visible="false"></asp:Label> </DIV><DIV class="column35_wo"><asp:DropDownList id="ddltenure1" tabIndex=1 runat="server" CssClass="form_drp_97" ToolTip="कृपया भुधारणेचा प्रकार निवडा " AppendDataBoundItems="True" OnSelectedIndexChanged="ddltenure1_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Value="-1">---निवडा--</asp:ListItem>
                                    </asp:DropDownList> </DIV></DIV><DIV class="clear_br"><BR /></DIV><DIV class="row"><DIV class="column35_wo"><asp:Label id="Label29" runat="server" Text="उप भुधारणा" CssClass="form_lbl" Visible="false"></asp:Label> </DIV><DIV class="column35_wo"><asp:DropDownList id="ddltenure12" tabIndex=2 runat="server" CssClass="form_drp_97" ToolTip="कृपया उपभुधारणेचा प्रकार निवडा " AppendDataBoundItems="True" OnSelectedIndexChanged="ddltenure12_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
                                        <asp:ListItem Value="-1">---निवडा--</asp:ListItem>
                                    </asp:DropDownList> </DIV></DIV><DIV class="clear_br"><BR /></DIV><DIV class="row"><DIV class="column35_wo"><asp:Label id="Label93" runat="server" Text="उप-उपभुधारणा" CssClass="form_lbl" Visible="false"></asp:Label> </DIV><DIV class="column35_wo"><asp:DropDownList id="ddltenure13" tabIndex=3 runat="server" CssClass="form_drp_97" AppendDataBoundItems="True" OnSelectedIndexChanged="ddltenure13_SelectedIndexChanged" AutoPostBack="True" Enabled="False">
                                        <asp:ListItem Value="-1">---निवडा--</asp:ListItem>
                                    </asp:DropDownList> </DIV></DIV></DIV></DIV><DIV class="clear_br"><CENTER><asp:Button id="btnBhudharnaExit" tabIndex=4 onclick="btnBhudharnaExit_Click" runat="server" Text="माहिती साठवा" CssClass="form_lbl" ToolTip="माहिती साठवा"></asp:Button>&nbsp; <asp:Button id="btnCancelBudharna" onclick="btnCancelBudharna_Click" runat="server"  Visible="false"  Text="रद्द करा" CssClass="form_lbl"   ToolTip="रद्द करा"></asp:Button> <asp:Button id="btnbackBudharna" onclick="btnbackBudharna_Click" runat="server" Text="मागे जा" CssClass="form_lbl" ToolTip="मागे जा"></asp:Button> </CENTER></DIV></asp:Panel>  <BR /><BR /></CENTER>
                                                                      


    <div id="div_iterfer" class="ontop"></DIV>
                <CENTER><asp:Panel id="Panel5" runat="server" CssClass="popupPnl_kul" Visible="false" BackColor="#EFEFEF"><br />
                <CENTER><asp:Label id="Label21" runat="server" Text="इतर फेरफार क्रमांक"  Font-Bold="true" CssClass="form_lblhead"></asp:Label> </CENTER>
                <DIV class="clear_br"><BR /></DIV><DIV class="row"><DIV class="partition"><DIV style="MARGIN-LEFT: 5%" class="inner_column3">
                <asp:Label id="Label12" runat="server" Text="नवीन फेरफार क्रमांक" CssClass="form_b_color"></asp:Label> </DIV>
                <DIV><asp:TextBox id="TextBox5" tabIndex=1 runat="server" MaxLength="8" CssClass="form_txt_adj" ToolTip="कृपया नवीन फेरफार क्रमांक टाका"></asp:TextBox><br /><br />
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button id="btnEtarFerfarAdd" tabIndex=2 onclick="btnEtarFerfarAdd_Click" runat="server" Text="समावेश करा " CssClass="form_lbl" ToolTip="समावेश करा " ValidationGroup="a"  OnClientClick="return confirm_Search_iterferno();"></asp:Button>
               </DIV>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                    
                <asp:RegularExpressionValidator id="RegularExpressionValidator8" runat="server" CssClass="form_lbl" ControlToValidate="TextBox5" ErrorMessage="कृपया अंक भरा!!!" ValidationExpression="[0-9]+" ValidationGroup="a"></asp:RegularExpressionValidator> 
                <BR /><DIV style="MARGIN-LEFT: 5%" class="inner_column3">&nbsp;</DIV>
                <DIV class="column_face"><asp:ListBox id="lstNewFerfarNo" tabIndex=3 runat="server" CssClass="lst_adj" Height="160px" Width="152px" OnSelectedIndexChanged="lstNewFerfarNo_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox> </DIV></DIV>
                
                 <DIV class="partition"><DIV class="inner_column40"><DIV style="MARGIN-LEFT: 5%" class="inner_column40">&nbsp;</DIV>
                    <br /><br /><asp:Label id="lbloldmut" runat="server" Text="जुने फेरफार क्रमांक" CssClass="form_b_color"></asp:Label> </DIV>
                
                <DIV class="clear_br"><BR /><DIV style="MARGIN-LEFT: 5%" class="inner_column3">&nbsp;</DIV><DIV class="inner_column1">
                    <asp:panel ID="pnlitr" runat="server" ScrollBars="vertical" CssClass="itar_grdpnl">
                           
                            <asp:GridView ID="grditer" runat="server" AutoGenerateColumns="False"
                                CssClass="grid" CellPadding="1" BorderStyle="None" BorderWidth="1px" CellSpacing="3"
                               TabIndex="3" OnSelectedIndexChanging="grditer_SelectedIndexChanging">
                                <Columns>
                                  
                                    <asp:TemplateField HeaderText="जुने फेरफार क्रमांक ">
                                        <ItemTemplate>
                                            <asp:Label ID="lbloldmutno" runat="server" Enabled="true" Text='<%# Eval("mutation_no") %>'
                                                CssClass="form_lbl"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                       <asp:CommandField ShowSelectButton="True" SelectText="नष्ट करा"></asp:CommandField>  
                                   
                                </Columns>
                                <FooterStyle CssClass="gridfooter" />
                                <PagerStyle CssClass="gridpager" />
                                <SelectedRowStyle CssClass="gridselectdrow" />
                                <HeaderStyle CssClass="gridheader" />
                                <RowStyle CssClass="gridrow" />
                            </asp:GridView>
                        </asp:Panel>                                                                     </DIV></DIV></DIV><DIV class="clear_br"><BR /></DIV><DIV class="clear_br"><CENTER><asp:Button id="btnEtarFerfarNoExit" tabIndex=12 onclick="btnEtarFerfarNoExit_Click" runat="server" Text="माहिती साठवा" CssClass="form_lbl" ToolTip="माहिती साठवा" Enabled="False"></asp:Button>&nbsp; <asp:Button id="btnCancelNoEx" onclick="btnCancelNoEx_Click" runat="server"  Visible="false"  Text="रद्द करा" CssClass="form_lbl"></asp:Button> <asp:Button id="btnbackNoExit" onclick="btnbackNoExit_Click" runat="server" Text="मागे जा" CssClass="form_lbl" ToolTip="मागे जा"></asp:Button> </CENTER><BR /></DIV></asp:Panel></CENTER>

    <div id="divpopup_bhogvatdar" class="ontop"></div>
                <CENTER>

    <asp:Panel id="panelfirst" runat="server" CssClass="popupPnl_holder" Visible="false" BackColor="#EFEFEF"><BR /><DIV><DIV class="column_s_wid8">
                <asp:Label id="lbl_error_area" runat="server" CssClass="form_lbl_red_s" Visible="False"></asp:Label></DIV><CENTER><asp:Label id="Label88" runat="server" Text="भोगावटदारातील फेरफाराची माहिती"  Font-Bold="true"  CssClass="form_lblhead" Font-Underline="true"></asp:Label></CENTER><DIV class="clear_br"></DIV><CENTER><asp:Button id="btndenara" onclick="btndenara_Click" runat="server"  Text="हक्क देणाऱ्यांची माहिती" CssClass="form_lbl"></asp:Button> <asp:Button id="btnghenara" onclick="btnghenara_Click" runat="server" Text="हक्क घेणाऱ्यांची माहिती" CssClass="form_lbl" Enabled="false"></asp:Button> <asp:Button id="btnBhogvatdarExit" onclick="btnBhogvatdarExit_Click" runat="server" Text="माहिती साठवा" CssClass="form_lbl" ToolTip="माहिती साठवा" Enabled="false"></asp:Button> <asp:Button id="btnbackbhog" onclick="btnbackbhog_Click" runat="server" Text="मागे जा" CssClass="form_lbl" ToolTip="मागे जा"></asp:Button> </CENTER><DIV class="clear_br">&nbsp;</DIV></DIV>
                <CENTER><asp:Label id="lblmsg" runat="server" Font-Names="Sakal Marathi" Visible="false"></asp:Label></CENTER></asp:Panel></CENTER>

    <asp:Panel id="Panel51" runat="server" CssClass="popupPnl_holderhakkden" Visible="false" BackColor="#EFEFEF"><BR />
                
                 <DIV class="row">
                <CENTER><asp:Label id="Label2" runat="server" Text="सध्या ७/१२ असलेले  भोगवटदारांची   माहिती" CssClass="form_lblhead" Font-Bold="True"></asp:Label></CENTER></DIV><hr />
               
                <DIV class="row">
                   
                     <asp:LinkButton ID="lnkKhataAdd" runat="server" OnClick="lnkKhataAdd_Click" TabIndex="3" ToolTip="खाते समावेश करणे ">खाते समावेश करणे</asp:LinkButton>&nbsp; &nbsp;
                    <asp:LinkButton ID="lnlAhwal5Corrction" runat="server"  TabIndex="3" ToolTip="खात्यांवरील, ७/१२ व खाता रजिस्टर मधील नावांचा फरक दुरुस्त करणे" OnClick="lnlAhwal5Corrction_Click">७/१२ व खाता रजिस्टर मधील नावांचा फरक दुरुस्त करणे</asp:LinkButton> &nbsp;&nbsp;<asp:LinkButton ID="linkKhataType" runat="server" TabIndex="3" ToolTip="खाता प्रकार बदलणे" OnClick="linkKhataType_Click" >खाता प्रकार बदलणे</asp:LinkButton>&nbsp; &nbsp;<asp:LinkButton ID="lnkKhataNoDeletionSurveyWise" runat="server"  TabIndex="3" ToolTip="खाता क्रमांक निवडक सर्व्हे / गट क्रमांकावरुन वगळणे" OnClick="lnkKhataNoDeletionSurveyWise_Click" >खाता क्रमांक निवडक सर्व्हे / गट क्रमांकावरुन वगळणे </asp:LinkButton>
                   
                  
                    <asp:Button id="btnConfirmAllKhataDone" tabIndex="4"  runat="server" Text="सर्व खात्यांची दुरुस्ती प्रक्रिया पुर्ण झाली आहे. "  ToolTip="सर्व खात्यांची दुरुस्ती प्रक्रिया पुर्ण झाली असल्यास येथे क्लिक करा." CssClass="form_lbl" OnClick="btnConfirmAllKhataDone_Click"></asp:Button>&nbsp;&nbsp;&nbsp;<div class="clear_br"></div>
                                             
                    <div class=" row">
                        <asp:Label id="Label6" runat="server" Text=" भोगवटदारांच्या नावाला कंस करणे, कंस काढणे, क्षेत्र, आकरणी, आणे, पै, पोटखराबा, फेरफार क्रमांक दुरुस्ती करण्यासाठी, सर्व खात्यांची दुरुस्ती प्रक्रिया पुर्ण झाली असल्यास अथवा करावयाची नसल्यास, <br/>  'सर्व खात्यांची दुरुस्ती प्रक्रिया पुर्ण झाली आहे ह्या बटणावर क्लिक करा.'" CssClass="form_lbl" Font-Bold="True" ForeColor="purple"></asp:Label>
                        &nbsp;</div>
                                   
                    <div class="clear_br"></div>

                               <div class="row">
                <asp:Label ID="Label25" runat="server" Text="टिप : ज्या नावाला कंस करावयाचा आहे त्या नावासमोर टिक करा ." ForeColor="Red"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label32" runat="server" Text="ज्या नावाचा कंस काढावयाचा आहे त्या नावासमोरील टिक काढा ." ForeColor="Blue"></asp:Label>
            </div>
            <div class="clear_br">
            </div>
                   
                          
                <DIV ><asp:Panel id="pnlOldBhogvatdar1" runat="server" CssClass="bhogvat_grdpnl" Height="320px" ScrollBars="Auto"><%--seema11--%>
                                <asp:GridView ID="gdvOldBhogvatdar1" runat="server" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" CellSpacing="3" CssClass="grid" OnRowDataBound="gdvOldBhogvatdar1_RowDataBound" OnRowDeleting="gdvOldBhogvatdar1_RowDeleting" OnRowEditing="gdvOldBhogvatdar1_RowEditing1" OnSelectedIndexChanged="gdvOldBhogvatdar1_SelectedIndexChanged1" OnSelectedIndexChanging="gdvOldBhogvatdar1_SelectedIndexChanging1" TabIndex="1">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblnivda" runat="server" CssClass="form_lbl" Text="खाता क्र निवडा"></asp:Label>
                                   
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <center>
                                        <asp:CheckBox ID="chkselect" runat="server" AutoPostBack="True" OnCheckedChanged="chkselect_CheckedChanged" ToolTip="<%# ((GridViewRow)Container).RowIndex %>" />
                                    </center>
                                </ItemTemplate>
                                <ItemStyle Width="6%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblkans" runat="server" CssClass="form_lbl" Text="कंस करा"></asp:Label>
                                    <center>
                                        <asp:CheckBox ID="ckhbracket" runat="server" AutoPostBack="True" Enabled="false" OnCheckedChanged="ckhbracket_CheckedChanged" ToolTip="फेरफारात सहभाग घेणारे सर्व खातेदार कंस करण्यासाठी येथे कंस करा" />
                                    </center>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <center>
                                        <asp:CheckBox ID="chkbrk" runat="server" AutoPostBack="True" Enabled="false" OnCheckedChanged="chkbrk_CheckedChanged" ToolTip="<%# ((GridViewRow)Container).RowIndex %>" />
                                    </center>
                                </ItemTemplate>
                                <ItemStyle Width="4%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:Label ID="lblKansRem" runat="server" CssClass="form_lbl" Text="कंस काढणे"></asp:Label>
                                    <asp:CheckBox ID="ckhbracketRem" runat="server" AutoPostBack="True" Enabled="false" ToolTip="फेरफारात सहभाग घेणारे सर्व खातेदार कंस काढण्यासाठी येथे टिक करा" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    &nbsp;
                                    <asp:CheckBox ID="chkbrkRem" runat="server" AutoPostBack="True" Enabled="false" ToolTip="<%# ((GridViewRow)Container).RowIndex %>" />
                                </ItemTemplate>
                                <ItemStyle Width="4%" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="खाता क्रमांक">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn1" runat="server" CssClass="form_lbl" Enabled="false" Text='<%# Eval("seller_khata_no") %>'></asp:Label>
                                    <asp:TextBox ID="grd2text1" runat="server" CssClass="form_txt_85" Enabled="false" Text='<%# Eval("seller_khata_no") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="अ.क्र." Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn10" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("usrno") %>'></asp:Label>
                                    <asp:TextBox ID="grd2text10" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("usrno") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="पहिले नाव">
                                <ItemTemplate>
                                    <script type="text/javascript">

//<!--
                                                    var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                    //--></script>
                                    <div id="rtDiv1">
                                    </div>
                                    <asp:Label ID="lblColumn2" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("fname") %>'></asp:Label>
                                    <asp:TextBox ID="grd2text2" runat="server" CssClass="form_txt_85" Text='<%# Eval("fname") %>' Visible="false">
                                    </asp:TextBox>
                                    <script type="text/javascript">

//<!--
                                                    textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                    //--></script>
                                    <script type="text/javascript">

//<!--
                                                    rtDiv = document.getElementById('rtDiv1');
                                                    //--></script>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="मधले   नाव        ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn3" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("mname") %>'></asp:Label>
                                    <asp:TextBox ID="grd2text3" runat="server" CssClass="form_txt_85" Text='<%# Eval("mname") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="शेवटचे    नाव        ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn4" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("lname") %>'></asp:Label>
                                    <asp:TextBox ID="grd2text4" runat="server" CssClass="form_txt_85" Text='<%# Eval("lname") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="टोपण नाव           ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn5" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("topan_name") %>'></asp:Label>
                                    <asp:TextBox ID="grd2text5" runat="server" CssClass="form_txt_85" Text='<%# Eval("topan_name") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="  क्षेत्र               ">
                                <HeaderTemplate>
                                    <asp:Button ID="btnAnneToArea" runat="server" enabled="false" OnClick="btnAnneToArea_Click" Text="आणे ते क्षेत्र रुपांतर" ToolTip="आणे ते क्षेत्र रुपांतर " />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn6" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("seller_area_tot") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text6" runat="server" AutoPostBack="True" CssClass="form_txt_85" MaxLength="10" OnTextChanged="grd2text6_TextChanged" Text='<%# Eval("seller_area_tot") %>' ToolTip="<%#((GridViewRow)Container).RowIndex %>" Visible="False"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="आकारणी">
                                <HeaderTemplate>
                                    <HeaderTemplate>
                                        <asp:Button ID="btnakarni" runat="server" enabled="false"  OnClick="btnakarni_Click" Text="आकारणी"   />
                                    </HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn7" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("na_assessment") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text7" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("na_assessment") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="आणे              ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn8" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("anne") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text8" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("anne") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" पै                 ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn9" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("pai") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text9" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("pai") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" पोट. ख.                ">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn11" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("potkharaba") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text11" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("potkharaba") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" पोट. ख.                " Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn13" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("tenure_code") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2text13" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("tenure_code") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" फेरफार क्रमांक               ">
                                <ItemTemplate>
                                    <asp:Label ID="lblmutno" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("mut_no") %>'> </asp:Label>
                                    <asp:TextBox ID="grd2textmutno" runat="server" CssClass="form_txt_85" Text='<%# Eval("mut_no") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkselect" runat="server" CommandName="select" CssClass="form_lbl" Enabled="false" Text="संपादन" Visible="false"></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="7%" />
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle CssClass="gridfooter" />
                        <PagerStyle CssClass="gridpager" />
                        <SelectedRowStyle CssClass="gridselectdrow" />
                        <HeaderStyle CssClass="gridheader" />
                        <RowStyle CssClass="gridrow" />
                    </asp:GridView>
                            </asp:Panel> </DIV></DIV>
                            
                            <div id="divkhata" class="ontop"></div>
                            <%--0809--%>
                            <asp:Panel ID="panelkhata" runat="server" CssClass="popupPnl_khata" BackColor="#EFEFEF" Visible="false"><br /> <%--0809--%>
                           <asp:Label id="lblkhata" runat="server" Text="खाता प्रकार" CssClass="form_lbl"></asp:Label>
                            <asp:DropDownList id="khata_type" runat="server" Visible="False" OnSelectedIndexChanged="khata_type_SelectedIndexChanged" AutoPostBack="True" ToolTip="खाता प्रकार निवडा व साठवा करुन पुढे जा ">
                    </asp:DropDownList><DIV class="clear"><br /></DIV><asp:Button ID="btnkhataback" runat="server" Text="मागे जा"
                                CssClass="form_lbl" ToolTip="मागे जा"  ></asp:Button></asp:Panel>
                      <CENTER><asp:Button id="btnbackbgvt" onclick="btnbackbgvt_Click" runat="server" Text="माहिती साठवा " CssClass="form_lbl" ToolTip="साठवा करुन पुढे जा" Enabled="False"></asp:Button>
                       
                          <%--0409--%><asp:Button ID="btnbackbog" runat="server" Text="मागे जा"
                                CssClass="form_lbl" ToolTip="मागे जा" OnClick="btnbackbog_Click1" ></asp:Button> <%--0409--%>
                          <div class="clear_br">
                          </div>
                      </CENTER>
                        </asp:Panel>

    <div id="div_iter1" class="ontop">
    </div>
    <asp:Panel ID="panelnew" runat="server" CssClass="popupPnl_holder" BackColor="#EFEFEF" Visible="false">
        <br />
        <div>
            <div class="column_s_wid8">
                <asp:Label ID="Label106" runat="server" CssClass="form_lbl_red_s" Visible="False"></asp:Label>
            </div>
            <center>
                <asp:Label ID="Label107" runat="server" Text="इतर अधिकाराची माहिती" Font-Bold="true" CssClass="form_lblhead"></asp:Label></center>
            <div class="clear_br"></div>
            <center>



                <asp:Button ID="btnEtarHakkNondakami" OnClick="btnEtarHakkNondakami_Click" runat="server" Text="इतर अधिकारात नोंद कमी/ दुरुस्त करणे" CssClass="form_lbl" ToolTip="इतर अधिकारात नोंद कमी/ दुरुस्त करणे" ></asp:Button>
                <asp:Button ID="btnEtarHakkNonda" OnClick="btnEtarHakkNonda_Click" runat="server" Text="इतर हक्कात नविन नोंद" CssClass="form_lbl" ToolTip="इतर हक्कात नविन नोंद"
                                    ></asp:Button>
                <asp:Button ID="Button7" runat="server" Text="मागे जा" CssClass="form_lbl" ToolTip="मागे जा" OnClick="Button7_Click"></asp:Button>
            </center>
        </div>
    </asp:Panel>

    <center>
        <asp:Panel ID="Panel1" runat="server" CssClass="popupPnl_holderhakkden" Visible="false" BackColor="#EFEFEF" >
            <br />
            <div>
                <center>

                    <asp:Label ID="Label11" runat="server" Text="इतर अधिकारात नोंद कमी/ दुरुस्त करणे" Font-Bold="True" CssClass="form_lblhead" ToolTip="इतर अधिकारात नोंद कमी/ दुरुस्त करणे"></asp:Label>
                </center>
            </div>
            <hr />
           
            <div class="clear_br">
                <br />
            </div>

            <div class="column">
                <asp:Panel ID="pnlCheck" runat="server" ScrollBars="Auto" Height="50px">
                <asp:CheckBoxList ID="CheckBoxList1" TabIndex="2" runat="server" CssClass="checkbox_face" 
                    RepeatDirection="Vertical" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:CheckBoxList>
                    </asp:Panel>
            </div>

           
            <div class="clear_br">
            </div>
            <div class="row">
                <div class="column_s_wid10">
                    <asp:Label ID="Label14" runat="server" Text="फेरफार क्रमांक" CssClass="form_lbl"></asp:Label>
                </div>
                <div class="column_18perwomargin">
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form_txt_160" ToolTip="कृपया फेरफार क्रमांक टाका"
                        Enabled="False"></asp:TextBox>
                </div>
                <div class="column_18perwomargin">
                    <asp:Label ID="Label15" runat="server" Text="इतर अधिकाराचे प्रकार" Width="180px" CssClass="form_lbl"
                        ToolTip="इतर अधिकाराचा प्रकार"></asp:Label>
                </div>
                <div class="column_18perwomargin">
                    <asp:DropDownList ID="ddlEtarHakkaType" runat="server" CssClass="form_txt_160"
                        ToolTip="कृपया ईतर अधिकाराचा प्रकार निवडा " Enabled="true">
                    </asp:DropDownList>
                </div>
                <div class="column_s_wid10">
                    <asp:Label ID="Label16" runat="server" Text="उपप्रकार" CssClass="form_lbl"></asp:Label>
                </div>
                <div class="column_18perwomargin">
                    <asp:DropDownList ID="ddlEtarHakkaSubType" runat="server" CssClass="form_txt_160" ToolTip="कृपया ईतर अधिकाराचा उपप्रकार निवडा "
                        Enabled="true">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="clear_br">
            </div>
            <div class="row">
                <asp:Label ID="Label23" runat="server" Text="टिप : माहिती उपलब्ध असल्यास ज्या तपशील ला कंस करावयाचा आहे त्यासमोर टिक करा ." ForeColor="Red"></asp:Label><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label24" runat="server" Text="माहिती उपलब्ध असल्यास ज्या तपशील चा कंस काढावयाचा आहे त्यासमोर टिक करा ." ForeColor="Blue"></asp:Label>
            </div>
            <div class="clear_br">
            </div>

            <asp:Panel ID="pnlgdvEtarHakka" runat="server" BackColor="#EFEFEF" ScrollBars="Auto"
                Height="220px">
                <asp:GridView ID="gdvEtarHakka" runat="server" CssClass="grid" BorderWidth="1px" OnRowDeleting="gdvEtarHakka_RowDeleting"  OnRowEditing="gdvEtarHakka_RowEditing"
                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3" TabIndex="3" OnRowCancelingEdit="gdvEtarHakka_RowCancelingEdit" OnRowUpdating="gdvEtarHakka_RowUpdating">
                    <Columns>
                        <asp:TemplateField HeaderText="कंस" Visible="true">
                            <HeaderTemplate>
                                <asp:Label ID="lblkans" runat="server" Text="कंस करा"  CssClass="form_lbl"></asp:Label>
                                <asp:CheckBox ID="chkkans" runat="server" ToolTip="कंस करण्यासाठी सर्व निवडा"
                                    AutoPostBack="True" OnCheckedChanged="chkkans_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkbrk" runat="server" AutoPostBack="True" OnCheckedChanged="chkbrk_CheckedChanged1" />
                                <asp:Label ID="lblyes" runat="server" Enabled="true" Visible="false" Text="YES" CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="कंस काढा" Visible="true">
                            <HeaderTemplate>
                                <asp:Label ID="lblkansrem" runat="server" Text="कंस काढा"  CssClass="form_lbl"></asp:Label>
                                <asp:CheckBox ID="chkkansrem" runat="server" ToolTip="कंस काढण्यासाठी सर्व निवडा" OnCheckedChanged="chkkansrem_CheckedChanged"
                                    AutoPostBack="True" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkbrkrem" runat="server" AutoPostBack="True" OnCheckedChanged="chkbrkrem_CheckedChanged1" />
                                <asp:Label ID="lblyesrem" runat="server" Enabled="true" Visible="false" Text="YES" CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="फेरफार क्रमांक">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn1" runat="server" Enabled="true" Text='<%# Eval("mut_no") %>'
                                    CssClass="form_lbl"></asp:Label>
                                <asp:TextBox ID="grd2text1" runat="server" Text='<%# Eval("mut_no") %>' Visible="false"
                                    CssClass="form_txt"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                             <EditItemTemplate>
                                      <asp:TextBox ID="grdtxtmutno" runat="server" Text='<%# Eval("mut_no") %>'  CssClass="form_txt_85"
                                   ></asp:TextBox>
                   
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="कृपया योग्य अंक भरा" ControlToValidate="grdtxtmutno" CssClass="form_lbl_red_s" Display="Dynamic" ValidationExpression="^[0-9]{1,5}$"></asp:RegularExpressionValidator>
                              
                            </EditItemTemplate>
                             <FooterTemplate>
                                          <asp:TextBox ID="grdtxtnewmutno" runat="server" CssClass="form_txt_85"></asp:TextBox>
                              </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="सर्व्हे क्रमांक">
                            <ItemTemplate>
                                <asp:Label ID="lblpins" runat="server" Enabled="true" Text='<%# Eval("pins") %>'
                                    CssClass="form_lbl"></asp:Label>
                                <asp:TextBox ID="grdpins" runat="server" Text='<%# Eval("pins") %>' Visible="false"
                                    CssClass="form_txt"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="तपशील">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("tenant_name") %>'
                                    CssClass="form_lbl"></asp:Label>
                            
                            </ItemTemplate>
                            <ItemStyle Width="50%" HorizontalAlign="left" />
                             <EditItemTemplate>
                                      <asp:TextBox ID="grdtxtdetails" runat="server" Text='<%# Eval("tenant_name") %>'  CssClass="form_txt_85"
                                   ></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                          <asp:TextBox ID="grdnewtxtdetails" runat="server" CssClass="form_txt_85"></asp:TextBox>
                              </FooterTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="btnUpdateA" runat="server" CausesValidation="True" CommandName="Update"
                                                    Text="सुधारीत" Width="40px"></asp:LinkButton>|&nbsp&nbsp
                                                <asp:LinkButton ID="btnCancelA" runat="server" CausesValidation="False" CommandName="Cancel"
                                                    Text="रद्द"></asp:LinkButton>
                                                
                                            </EditItemTemplate>
                                        
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEditA" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="दुरूस्ती" Width="30px"></asp:LinkButton>
                                            </ItemTemplate>
                            <ItemStyle Width="35%" HorizontalAlign="left" />
                            
                                        </asp:TemplateField>
                         
                         <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="LinkButton12" runat="server" CausesValidation="False" CommandName="Delete"
                                                            Text="नष्ट करा" ToolTip="मिटवा"></asp:LinkButton>
                                                    </ItemTemplate>
                             <ItemStyle Width="10%" HorizontalAlign="left" />
                                              </asp:TemplateField>

                        <asp:TemplateField HeaderText="user" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("usrno") %>'
                                    CssClass="form_lbl"></asp:Label>
                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("usrno") %>' Visible="false"
                                    CssClass="form_txt"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="drp1" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn4" runat="server" Visible="false" Enabled="true" Text='<%# Eval("other_rights_code") %>'
                                    CssClass="form_lbl"></asp:Label>
                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("other_rights_code") %>'
                                    CssClass="form_txt" Visible="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="drp2" Visible="False">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn5" runat="server" Visible="false" Enabled="true" Text='<%# Eval("other_rights_sub_code") %>'
                                    CssClass="form_lbl"></asp:Label>
                                <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("other_rights_sub_code") %>'
                                    CssClass="form_txt" Visible="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="gridfooter" />
                    <PagerStyle CssClass="gridpager" />
                    <SelectedRowStyle CssClass="gridselectdrow" />
                    <HeaderStyle CssClass="gridheader" />
                    <RowStyle CssClass="gridrow" />
                </asp:GridView>
            </asp:Panel>
            <div class="clear_br">
            
            </div>
            <center>
                <asp:Button ID="btnEtarAdhikarOldExit" TabIndex="5" OnClick="btnEtarAdhikarOldExit_Click"
                    runat="server" Text="माहिती साठवा" CssClass="form_lbl" ToolTip="माहिती साठवा" Enabled="False"></asp:Button>
                <asp:Button ID="btnCancelor" runat="server" Text="रद्द करा" Visible="false" CssClass="form_lbl" OnClick="btnCancelor_Click"></asp:Button>
                <asp:Button ID="btnbackor" runat="server" Text="मागे जा" CssClass="form_lbl" OnClick="btnbackor_Click"></asp:Button>
            </center>
                <div class="clear_br"></div>
        </asp:Panel>
    </center>
    <div class="clear_br"></br></div>
    <center>
        <div id="div_iter" class="ontop">
        </div>
        <asp:Panel ID="Panel4" runat="server" CssClass="popupPnl_holderhakkden" Visible="false" BackColor="#EFEFEF">
            <br />
            <center>

                <asp:Label ID="Label91" runat="server" Text="इतर अधिकारात नविन नोंद करणे" Font-Bold="true" CssClass="form_lblhead"></asp:Label>
            </center>
            <hr />
            <div class="clear_br">
            </div>
            <div class="column_s_wid8">
                <asp:Button ID="btnEtarNewAdhikarEnable" TabIndex="1" OnClick="btnEtarNewAdhikarEnable_Click"
                    runat="server" Text="समावेश" CssClass="form_lbl" ToolTip="समावेश"></asp:Button>&nbsp;
            </div>
            <div class="clear_br">
            </div>

            <div class="row">
                <div class="column_s_wid22p">
                    <asp:Label ID="Label17" runat="server" Text="इतर अधिकाराचे प्रकार" CssClass="form_lbl"></asp:Label>
                </div>
                <div class="column_18perwomargin">
                    <asp:DropDownList ID="ddlEtarNewAdhikar" TabIndex="2" runat="server" CssClass="form_txt_160"
                        ToolTip="कृपया ईतर अधिकाराचा प्रकार निवडा " Enabled="False" AppendDataBoundItems="True"
                        OnSelectedIndexChanged="ddlEtarNewAdhikar_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem>---निवडा--</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="column_s_wid10">
                    <asp:Label ID="Label22" runat="server" Text="उपप्रकार" CssClass="form_lbl"></asp:Label>
                </div>
                <div class="column_18perwomargin">
                    <asp:DropDownList ID="ddlEtarNewSubAdhikar" TabIndex="3" runat="server" CssClass="form_txt_160"
                        ToolTip="कृपया ईतर अधिकाराचा उपप्रकार निवडा " Enabled="False" AppendDataBoundItems="True">
                        <asp:ListItem>---निवडा--</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="clear_br">
            </div>
            <center>
                <asp:RadioButton ID="rdbsingle" TabIndex="6" runat="server" Text="एक सर्व्हे क्र"
                    CssClass="form_lbl" AutoPostBack="True" GroupName="Adhikar" OnCheckedChanged="rdbsingle_CheckedChanged" Visible="false"
                    Checked="True" Enabled="False"></asp:RadioButton>
                <asp:RadioButton ID="rdbmultiple" TabIndex="7" runat="server" Text="अनेक सर्व्हे क्र"
                    CssClass="form_lbl" AutoPostBack="True" GroupName="Adhikar" OnCheckedChanged="rdbmultiple_CheckedChanged" Visible="false" Enabled="False"></asp:RadioButton>
            </center>
            <div class="clear_br">
            </div>
            <div class="row">
                <asp:Label ID="Label10" runat="server" Text="टिप : ७/१२ वर इतर हक्कात दिसणारा तपशील भरण्यासाठी खालील '७/१२ वर इतर हक्कात दिसणारा तपशील' या बटणा वर क्लिक करा." ForeColor="Red"></asp:Label><br />
                <asp:Label ID="Label9" runat="server" Text=" या क्लिक द्वारे आपण एक किंवा अनेक नविन ओळी तयार करु शकता." ForeColor="Blue"></asp:Label>
            </div>
            <div class="clear_br">
            </div>
            <div class="set_btn">
                <asp:Button ID="btnAddEtarNewAdhikar" TabIndex="4" OnClick="btnAddEtarNewAdhikar_Click"
                    runat="server" Text="७/१२ वर इतर हक्कात दिसणारा तपशील" CssClass="form_lbl" ToolTip="७/१२ वर इतर हक्कात दिसणारा तपशील" Visible="False"></asp:Button>
            </div>
            <div class="clear_br">
            </div>
            <asp:Panel ID="pnlgdvEtarNewAdhikar" runat="server" CssClass="itar_grdpnl" ScrollBars="Auto"
                Height="300px">
                  <asp:GridView ID="gdvEtarNewAdhikar" runat="server" CssClass="grid" BorderWidth="1px"
                    BorderStyle="None" OnSelectedIndexChanging="gdvEtarNewAdhikar_SelectedIndexChanging"
                    AutoGenerateColumns="False" CellSpacing="3" TabIndex="5" >
                    <Columns>                     
                         <asp:CommandField ShowSelectButton="True" SelectText="नष्ट करा"></asp:CommandField>                   
                        <asp:TemplateField HeaderText="फेरफार क्रमांक">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn1" runat="server" Enabled="true" Text='<%# Eval("mut_no") %>' Visible="false"
                                    CssClass="form_lbl"></asp:Label>
                                <asp:TextBox ID="grd2text1" Text='<%# Eval("mut_no") %>' runat="server" Visible="true"
                                    CssClass="form_txt"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtmutno" runat="server" ControlToValidate="grd2text1" ValidationGroup="otherrightsgroup"
                                                    Enabled="false" ErrorMessage="फेरफार क्रमांक भरा" CssClass="form_lbl_red_s" Display="Dynamic"></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"  ErrorMessage="कृपया योग्य अंक भरा. अक्षर / स्पेस नको."  ValidationGroup="otherrightsgroup"  ControlToValidate="grd2text1" CssClass="form_lbl_red_s" Display="Dynamic" ValidationExpression="^[0-9]{1,5}$"></asp:RegularExpressionValidator>
                                               
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" ईतर हक्काचा तपशील">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn2" runat="server" Visible="false" Enabled="true" Text='<%# Eval("tenant_name") %>'
                                    CssClass="form_lbl"></asp:Label>
                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("tenant_name") %>' CssClass="form_txt_95" MaxLength="500"
                                    Visible="true" TextMode="MultiLine" Height="50px" Rows="5"></asp:TextBox>
                                   
                                 <asp:RequiredFieldValidator ID="rfvtxtNewBuyerName" runat="server" ControlToValidate="grd2text2" ValidationGroup="otherrightsgroup"
                                                    Enabled="false" ErrorMessage="ईतर हक्काचा तपशील भरा" CssClass="form_lbl_red_s" Display="Dynamic"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="65%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="क्षेत्र" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblArea" runat="server" Visible="false" Enabled="true" Text='<%# Eval("buyer_area_tot") %>'
                                    CssClass="form_lbl"></asp:Label>
                                <asp:TextBox ID="txtArea" runat="server" Text='<%# Eval("buyer_area_tot") %>' CssClass="form_txt" MaxLength="10"
                                    Visible="true"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="5%" />
                            <HeaderStyle Width="5%" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="क्षेत्र एकक" Visible="false">
                            <ItemTemplate>
                                <asp:DropDownList ID="drpAreaType" runat="server" Visible="true" AutoPostBack="false">
                                    <asp:ListItem Value="0">निवडा</asp:ListItem>
                                    <asp:ListItem Value="1">हे.आर.चौ.मी</asp:ListItem>
                                    <asp:ListItem Value="2">आर.चौ.मी</asp:ListItem>
                                    
                                </asp:DropDownList>
                                <asp:Label ID="lblAreaType" runat="server" Text='<%# Bind("area_unit") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="12%" />
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderText="प्रकार"  >
                            <ItemTemplate>
                                <asp:Label ID="lblother_rights_name" runat="server"  Enabled="true" Text='<%# Eval("other_rights_name") %>'
                                    CssClass="form_lbl"></asp:Label>
                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("other_rights_code") %>'
                                    CssClass="form_txt" Visible="False"></asp:TextBox>

                            </ItemTemplate>
                        </asp:TemplateField>
                      
                        <asp:TemplateField HeaderText="उपप्रकार"  >
                            <ItemTemplate>
                                <asp:Label ID="lblother_rights_sub_name" runat="server"  Enabled="true" Text='<%# Eval("other_rights_sub_name") %>'
                                    CssClass="form_lbl"></asp:Label>
                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("other_rights_sub_code") %>'
                                    CssClass="form_txt" Visible="False"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="gridfooter" />
                    <PagerStyle CssClass="gridpager" />
                    <SelectedRowStyle CssClass="gridselectdrow" />
                    <HeaderStyle CssClass="gridheader" />
                    <RowStyle CssClass="gridrow" />
                </asp:GridView>
            </asp:Panel>          
            <center>
                <asp:Button ID="btnEtarNewAdhikarExit" TabIndex="8" OnClick="btnEtarNewAdhikarExit_Click"
                    runat="server" Text="माहिती साठवा" CssClass="form_lbl" ToolTip="माहिती साठवा" ValidationGroup="otherrightsgroup"></asp:Button>
                <asp:Button ID="btnCancelOr2" OnClick="btnCancelOr2_Click" runat="server" Text="रद्द करा" Visible="false"
                    CssClass="form_lbl"></asp:Button>
                <asp:Button ID="btnBackOr2" OnClick="btnBackOr2_Click" runat="server" Text="मागे जा"
                    CssClass="form_lbl" ToolTip="मागे जा"></asp:Button></center>
            
                   <div class="clear_br"></div>
        </asp:Panel>
    </center>

      <DIV id="div_multi" class="ontop"></DIV>
                
                    <asp:Panel ID="Panel11" runat="server" BackColor="#EFEFEF" CssClass="popupPnl_bhudarna_survey" Visible="false" ScrollBars="Auto">
                    <br />
                   <center><asp:Label id="lblname12" runat="server" Text="अनेक सर्व्हे क्रमांक"  Font-Bold="True" CssClass="form_lblhead" Visible="False"></asp:Label></center> 
                        <center>
                                <asp:RadioButton ID="RdbtnHAM" runat="server" Checked="True" GroupName="Area" Text="हे. आर. चौ.मी."
                                    TabIndex="5" CssClass="form_lbl" Visible="false" /><asp:RadioButton ID="RdbtnAM" runat="server" GroupName="Area"
                                        Text="आर. चौ.मी." TabIndex="6" CssClass="form_lbl" Visible="false" /></center>
                    <hr>
                       <br />

                            <div class="row">
                            <center>
                                <asp:Label ID="Label62" runat="server" CssClass="form_lbl">सर्व्हे क्र</asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;
                            
                                <asp:TextBox ID="txtAdhikarSurvey" runat="server" CausesValidation="True" CssClass="form_txt" MaxLength="20"
                                    TabIndex="1" ToolTip="कृपया सर्व्हे क्रमांक टाका"></asp:TextBox>
                           
                           
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           
                           
                                <asp:Button ID="btnAdhikarSearch" Text="शोधा" runat="server" OnClick="btnAdhikarSearch_Click" OnClientClick="return confirm_survey();"
                                    ToolTip="शोधा" TabIndex="2" CssClass="form_lbl" />
                             </center>
                        </div>
                       <br />
                        <asp:Panel ID="pnlgrdMultipleAdhikar" runat="server" ScrollBars="vertical" CssClass="itar_grdpnl">
                            <asp:Label ID="lblMulSurvey" runat="server" Text="सर्व्हे क्रमांक शोधा" Visible="False"></asp:Label>
                            <asp:GridView ID="grdMultipleAdhikar" runat="server" AutoGenerateColumns="False"
                                CssClass="grid" CellPadding="1" BorderStyle="None" BorderWidth="1px" CellSpacing="3"
                                OnSelectedIndexChanging="grdMultipleAdhikar_SelectedIndexChanging" TabIndex="3">
                                <Columns>
                                    <asp:TemplateField HeaderText="निवडा">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkselect" runat="server" CommandName="select" Enabled="true"
                                                CssClass="form_lbl" Text="निवडा"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="सर्व्हे क्रमांक">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn" runat="server" Enabled="true" Text='<%# Eval("pin") %>'
                                                CssClass="form_lbl"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn1" runat="server" Enabled="true" Text='<%# Eval("pin1") %>'
                                                CssClass="form_lbl"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("pin2") %>'
                                                CssClass="form_lbl"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("pin3") %>'
                                                CssClass="form_lbl"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("pin4") %>'
                                                CssClass="form_lbl"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("pin5") %>'
                                                CssClass="form_lbl"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn6" runat="server" Enabled="true" Text='<%# Eval("pin6") %>'
                                                CssClass="form_lbl"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn7" runat="server" Enabled="true" Text='<%# Eval("pin7") %>'
                                                CssClass="form_lbl"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn8" runat="server" Enabled="true" Text='<%# Eval("pin8") %>'
                                                CssClass="form_lbl"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="10%" />
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle CssClass="gridfooter" />
                                <PagerStyle CssClass="gridpager" />
                                <SelectedRowStyle CssClass="gridselectdrow" />
                                <HeaderStyle CssClass="gridheader" />
                                <RowStyle CssClass="gridrow" />
                            </asp:GridView>
                        </asp:Panel>
                        
                        
                    <div class="clear_br">
                        <br />
                    </div>
                    
                    
                    <asp:Panel ID="Panel12" runat="server" CssClass="itar_grdpnl" ScrollBars="Auto" Height="200px">
                        <asp:Label ID="lblmulselect" runat="server" Text="निवडलेले सर्व्हे क्रमांक" Visible="False"></asp:Label>
                        <asp:GridView ID="grdNewMultiAdhikar" runat="server" AutoGenerateColumns="False"
                           BorderStyle="None"
                            OnRowDeleting="grdNewMultiAdhikar_RowDeleting" TabIndex="4" CssClass="grid">
                            <PagerStyle VerticalAlign="Top" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select" Visible="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkselect" runat="server" CommandName="select" Enabled="true"
                                            CssClass="form_lbl" Text="Select"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="सर्व्हे क्रमांक">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn" runat="server" Enabled="true" Text='<%# Eval("pin") %>'
                                            CssClass="form_lbl"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn1" runat="server" Enabled="true" Text='<%# Eval("pin1") %>'
                                            CssClass="form_lbl"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("pin2") %>'
                                            CssClass="form_lbl"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("pin3") %>'
                                            CssClass="form_lbl"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("pin4") %>'
                                            CssClass="form_lbl"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("pin5") %>'
                                            CssClass="form_lbl"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn6" runat="server" Enabled="true" Text='<%# Eval("pin6") %>'
                                            CssClass="form_lbl"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn7" runat="server" Enabled="true" Text='<%# Eval("pin7") %>'
                                            CssClass="form_lbl"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn8" runat="server" Enabled="true" Text='<%# Eval("pin8") %>'
                                            CssClass="form_lbl"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Width="10%" />
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" DeleteText="नष्ट करा" />
                            </Columns>
                            <FooterStyle CssClass="gridfooter" />
                            <PagerStyle CssClass="gridpager" />
                            <SelectedRowStyle CssClass="gridselectdrow" />
                            <HeaderStyle CssClass="gridheader" />
                            <RowStyle CssClass="gridrow" />
                        </asp:GridView>
                        <div class="clear_br">
                        </div>
                    </asp:Panel>
                    
                     <center>
                                <asp:Button ID="btnExitMultipleAdk" Text="माहिती साठवा" runat="server" OnClick="btnExitMultipleAdk_Click"
                                    ToolTip="माहिती साठवा" TabIndex="5" CssClass="form_lbl" />
                                    <asp:Button ID="btnCancelmult" runat="server" Text="रद्द करा"  Visible="false"  CssClass="form_lbl" OnClick="btnCancelmult_Click" />
                                        <asp:Button id="btnbackmult" runat="server" Text="मागे जा" CssClass="form_lbl" ToolTip="मागे जा" OnClick="btnbackmult_Click"></asp:Button>
                            </center>
                    </asp:Panel>

    <DIV id="divpopup_pins" class="ontop_survey"></DIV>
                
                <center>
                <asp:Panel id="Panelgrid" runat="server" CssClass="popupPnl_holder_survey" BackColor="#EFEFEF" Visible="false" ScrollBars="auto">
                   <br />
                  
                    <br /> 
                    
               
                    
                 
                </asp:Panel></center>  

   

    <div class="clear_br"></br></div>
     <%--Kul Start--%>
     <center>
                    <div id="div_kul" class="ontop">
                    </div>
                    <asp:Panel ID="pnlkulnondkami" runat="server" CssClass="popupPnl_kul" Visible="false" BackColor="#EFEFEF">
                        <div>
                            <center>
                                <br />
                                
                                    <asp:Label ID="Label61" runat="server" Text="कुळातील नोंद कमी करणे "  Font-Bold="true" CssClass="form_lblhead"
                                       ></asp:Label>
                                
                            </center>
                            <hr />
                        </div>
                        <br />
                        <center>
                            <asp:Button ID="btnKulNewNonda" TabIndex="1" OnClick="btnKulNewNonda_Click" runat="server"
                                Text="कुळा मधे नविन नोंद" CssClass="form_lbl" ToolTip="कुळा मधे नविन नोंद" >
                            </asp:Button>
                        </center>
                        <div class="clear_br">
                            <br />
                        </div>
                        <div class="row">
                            <div class="column_s_wid10">
                                <asp:Label ID="Label63" runat="server" Text="फेरफार क्रमांक" CssClass="form_lbl" Visible="false"></asp:Label>
                            </div>
                            <div class="column_20per_womargin">
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form_txt" Visible="false" Enabled="False" MaxLength="10"></asp:TextBox>
                            </div>
                            <div class="column_s_wid10">
                                <asp:Label ID="Label64" runat="server" Text="कुळाचे प्रकार" CssClass="form_lbl" Visible="false"></asp:Label>
                            </div>
                            <div class="column_womargin">
                                <asp:DropDownList ID="ddlKulType" runat="server" CssClass="form_txt_160" Visible="false"
                                    AppendDataBoundItems="True" Enabled="False" AutoPostBack="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="clear_br">
                           
                        </div>
                        <div class="row">
                            <asp:CheckBoxList ID="CheckBoxList2" TabIndex="2" runat="server" CssClass="checkbox_face"
                                OnSelectedIndexChanged="CheckBoxList2_SelectedIndexChanged" AutoPostBack="True">
                            </asp:CheckBoxList>
                            <div class="column_face3">
                                <asp:Panel ID="pnlgdvKul" runat="server" CssClass="itar_grdpnl" ScrollBars="auto">
                                    <asp:GridView ID="gdvKul" runat="server" CssClass="grid" BackColor="White" BorderWidth="1px" OnRowDeleting="gdvKul_RowDeleting"
                                        BorderStyle="None" AutoGenerateColumns="False" OnRowEditing="gdvKul_RowEditing" OnRowCancelingEdit="gdvKul_RowCancelingEdit" OnRowUpdating="gdvKul_RowUpdating"
                                        CellSpacing="3" TabIndex="3">
                                        <RowStyle BackColor="White" />
                                        <Columns>
                                          <asp:TemplateField HeaderText="कंस">
                                           <HeaderTemplate>
                                              <asp:Label ID="lblkanskul" runat="server" Text="कंस करा"  CssClass="form_lbl"></asp:Label>
                                              <asp:CheckBox ID="chkkanskul" runat="server" ToolTip="कंस करण्यासाठी सर्व निवडा" OnCheckedChanged="chkkanskul_CheckedChanged"
                                              AutoPostBack="True" />
                                           </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkbrkkul" runat="server" OnCheckedChanged="chkbrkkul_CheckedChanged"  AutoPostBack="true"/>
                                                    <asp:Label ID="lblyeskul" runat="server" Enabled="true" Visible="false" Text="YES" CssClass="form_lbl"></asp:Label>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="कंस काढा" Visible="true">
                            <HeaderTemplate>
                                <asp:Label ID="lblkansremkul" runat="server" Text="कंस काढा"  CssClass="form_lbl"></asp:Label>
                                <asp:CheckBox ID="chkkansremkul" runat="server" ToolTip="कंस काढण्यासाठी सर्व निवडा" OnCheckedChanged="chkkansremkul_CheckedChanged"
                                    AutoPostBack="True" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkbrkremkul" runat="server" AutoPostBack="True" OnCheckedChanged="chkbrkremkul_CheckedChanged"  />
                                <asp:Label ID="lblyesremkul" runat="server" Enabled="true" Visible="false" Text="YES" CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="center" />
                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="फेरफार क्रमांक">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblColumn1kul" runat="server" Enabled="true" Text='<%# Eval("mut_no") %>'
                                                        CssClass="form_lbl"></asp:Label>
                                                    <asp:TextBox ID="grd2text1" runat="server" Text='<%# Eval("mut_no") %>' Visible="false" MaxLength="10"
                                                        CssClass="form_txt"></asp:TextBox>
                                                </ItemTemplate>
                                              <ItemStyle HorizontalAlign="Center" />
                                                 <EditItemTemplate>
                                      <asp:TextBox ID="grdtxtmutnokul" runat="server" Text='<%# Eval("mut_no") %>'  CssClass="form_txt_85"
                                   ></asp:TextBox>
                   
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="कृपया योग्य अंक भरा" ControlToValidate="grdtxtmutnokul" CssClass="form_lbl_red_s" Display="Dynamic" ValidationExpression="^[0-9]{1,5}$"></asp:RegularExpressionValidator>
                              
                            </EditItemTemplate>
                             <FooterTemplate>
                                          <asp:TextBox ID="grdtxtnewmutnokul" runat="server" CssClass="form_txt_85"></asp:TextBox>
                              </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="तपशील">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblColumn2kul" runat="server" Enabled="true" Text='<%# Eval("tenant_name") %>'
                                                        CssClass="form_lbl"></asp:Label>
                                                    <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("tenant_name") %>' CssClass="form_txt"
                                                        Visible="false"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" />
                                                 <EditItemTemplate>
                                      <asp:TextBox ID="grdtxtdetailskul" runat="server" Text='<%# Eval("tenant_name") %>'  CssClass="form_txt_85"
                                   ></asp:TextBox>
                            </EditItemTemplate>
                             <FooterTemplate>
                                          <asp:TextBox ID="grdnewtxtdetailskul" runat="server" CssClass="form_txt_85"></asp:TextBox>
                              </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="user" Visible="False">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label64" runat="server" Enabled="true" Text='<%# Eval("usrno") %>'
                                                        CssClass="form_lbl"></asp:Label>
                                                    <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("usrno") %>' Visible="false"
                                                        CssClass="form_txt"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                               <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="btnUpdateAkul" runat="server" CausesValidation="True" CommandName="Update"
                                                    Text="सुधारीत" Width="40px"></asp:LinkButton>|&nbsp&nbsp
                                                <asp:LinkButton ID="btnCancelAkul" runat="server" CausesValidation="False" CommandName="Cancel"
                                                    Text="रद्द"></asp:LinkButton>
                                                
                                            </EditItemTemplate>
                                          
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEditAkul" runat="server" CausesValidation="False" CommandName="Edit"
                                                    Text="दुरूस्ती" Width="30px"></asp:LinkButton>
                                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="left" />
                            
                                        </asp:TemplateField>

                                              <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkdeletekul" runat="server" CausesValidation="False" CommandName="Delete"
                                                            Text="नष्ट करा" ToolTip="मिटवा"></asp:LinkButton>
                                                    </ItemTemplate>
                             <ItemStyle HorizontalAlign="left" />
                                              </asp:TemplateField>
                                            
                                        </Columns>
                                        <FooterStyle CssClass="gridfooter" />
                                        <PagerStyle CssClass="gridpager" />
                                        <SelectedRowStyle CssClass="gridselectdrow" />
                                        <HeaderStyle CssClass="gridheader" />
                                        <RowStyle CssClass="gridrow" />
                                    </asp:GridView>
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="clear_br">
                        </div>
                        <center>
                            <asp:Button ID="btnKulNondaExit" TabIndex="5" OnClick="btnKulNondaExit_Click" runat="server"
                                Text="माहिती साठवा" CssClass="form_lbl" ToolTip="माहिती साठवा" Enabled="False"></asp:Button>
                            <asp:Button ID="btnCancelkul" runat="server" Text="रद्द करा"  Visible="false"  CssClass="form_lbl"
                                OnClick="btnCancelkul_Click"></asp:Button>
                            <asp:Button ID="btnbackkul" runat="server" Text="मागे जा" CssClass="form_lbl" ToolTip="मागे जा"
                                OnClick="btnbackkul_Click"></asp:Button></center>
                        <br />
                    </asp:Panel>
                </center>

     <div id="div_kul2" class="ontop"></div>
                <CENTER><asp:Panel id="Panelkul" runat="server" CssClass="popupPnl_kul" Visible="false" BackColor="#EFEFEF"><BR /><DIV>
                <center><asp:Label id="Label68" runat="server" Text=" कुळामधे नविन नोंद करणे"  Font-Bold="true" CssClass="form_lblhead"></asp:Label></center>
                
                <DIV class="column_s_wid10"><asp:Button id="btnNewKulShow" tabIndex=1 onclick="btnNewKulShow_Click" runat="server" Text="नविन" CssClass="form_lbl" ToolTip="नविन"></asp:Button> </DIV>
                <DIV class="clear_br"><BR /></DIV>
                <DIV class="row"><DIV class="column_margin10"><asp:Label id="Label69" runat="server" Text="कुळाचे प्रकार :" Width="100px" CssClass="form_lbl"></asp:Label> </DIV>
                <DIV class="column_s_wid10"><asp:DropDownList id="ddlNewKulType" tabIndex=2 runat="server" CssClass="form_drp_minwidth" ToolTip="कृपया कुळाचा प्रकार निवडा " AppendDataBoundItems="True" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="ddlNewKulType_SelectedIndexChanged">
                                <asp:ListItem>---निवडा--</asp:ListItem>
                            </asp:DropDownList> </DIV>
                            <DIV class="column_s_wid10"><asp:Button id="btnNewKulSave" runat="server" Text="Save" CssClass="form_lbl" Visible="False"></asp:Button> </DIV>
                            <DIV class="column_margin10"><asp:Button id="btnNewKulAdd" tabIndex=3 onclick="btnNewKulAdd_Click" runat="server" Text="नविन नोंद" CssClass="form_lbl" ToolTip="नविन नोंद" Visible="False"></asp:Button> </DIV></DIV><DIV class="clear_br"><BR /></DIV>
                            
                            
                            <asp:Panel id="pnlgdvNewKul" runat="server" CssClass="faqpnl" ScrollBars="Auto" Height="300px">
                        <asp:GridView ID="gdvNewKul" runat="server" CssClass="grid" BorderWidth="1px" BorderStyle="None"
                            OnSelectedIndexChanging="gdvNewKul_SelectedIndexChanging" AutoGenerateColumns="False"
                            CellSpacing="3" TabIndex="4">
                            <RowStyle></RowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="नष्ट करा">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" AutoPostBack="true" CommandName="select"
                                            CssClass="form_lbl" Text="नष्ट करा"></asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="फेरफार क्रमांक" >
                                    <ItemTemplate>
                                        <asp:Label ID="Label69" runat="server" Enabled="true" Text='<%# Eval("mut_no") %>'  Visible="false"
                                            CssClass="form_lbl"></asp:Label>
                                        <asp:TextBox ID="grd2text1" runat="server" Text='<%# Eval("mut_no") %>' MaxLength="10"  Visible="true"
                                            CssClass="form_txt"></asp:TextBox>
                                    </ItemTemplate>
                                     <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="कुळाचे नाव">
                                    <ItemTemplate>
                                    
                                        <asp:Label ID="Label70" runat="server" Visible="false" Enabled="true" Text='<%# Eval("m_kul") %>'
                                            CssClass="form_lbl"></asp:Label>
                                        <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("m_kul") %>' Visible="true" Width="500px" MaxLength="100"
                                            ></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" खाता क्र" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label71" runat="server" Visible="false" Enabled="false" Text='<%# Eval("khata_no") %>'
                                            CssClass="form_lbl"></asp:Label>
                                        <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("khata_no") %>' Enabled="false" MaxLength="10"
                                            CssClass="form_txt" Visible="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" क्षेत्र" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label72" runat="server" Visible="false" Enabled="true" Text='<%# Eval("m_area") %>'
                                            CssClass="form_lbl"></asp:Label>
                                        <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("m_area") %>' Enabled="false" MaxLength="10"
                                            CssClass="form_txt" Visible="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="खंड" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label73" runat="server" Visible="false" Enabled="true" Text='<%# Eval("m_brand") %>'
                                            CssClass="form_lbl"></asp:Label>
                                        <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("m_brand") %>' Enabled="false"
                                            CssClass="form_txt" Visible="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" id" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="Label74" runat="server" Visible="false" Enabled="true" Text='<%# Eval("m_drpid") %>'
                                            CssClass="form_lbl"></asp:Label>
                                        <asp:TextBox ID="grd2text6" runat="server" Text='<%# Eval("m_drpid") %>' Visible="false"
                                            CssClass="form_txt"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle CssClass="gridfooter" />
                            <PagerStyle CssClass="gridpager" />
                            <SelectedRowStyle CssClass="gridselectdrow" />
                            <HeaderStyle CssClass="gridheader" />
                            <RowStyle CssClass="gridrow" />
                        </asp:GridView>
                    </asp:Panel></div> <BR /><BR />
                    <CENTER><asp:Button id="btnNewKulExit" tabIndex=5 onclick="btnNewKulExit_Click" runat="server" Text="माहिती साठवा" CssClass="form_lbl" ToolTip="माहिती साठवा" ></asp:Button>
                     <asp:Button id="btnCancelkul2" runat="server" Text="रद्द करा" CssClass="form_lbl" OnClick="btnCancelkul2_Click" Visible="false" ></asp:Button>
                      <asp:Button id="btnbackkul2" runat="server" Text="मागे जा" CssClass="form_lbl" ToolTip="मागे जा" OnClick="btnbackkul2_Click"></asp:Button></CENTER></asp:Panel></CENTER>


    <div class="clear_br"></br></div>

    <div id="divpopup_NameAdd" class="ontop"></div>
     <asp:Panel ID="pnlNameAdd" runat="server" Visible="false" CssClass="popupPnl_holderhakkden" BackColor="#EFEFEF" >
          <div class="clear_br">

                        </div>
<CENTER><asp:Label id="Label8" runat="server" Text="नविन नावे समाविष्ट करणे"  Font-Bold="True" CssClass="form_lblhead"></asp:Label></CENTER>
 <div class="clear_br">

                        </div>
         <div class="row">
             <br/>
              &nbsp;<asp:Label ID="Label3" runat="server" CssClass="form_lbl" Text="खाता क्रमांक :-" Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataNo" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="Label4" runat="server" CssClass="form_lbl" Text="मुळ खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataType" runat="server" ForeColor="#FF3300" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="Label5" runat="server" Text="नविन नाव समाविष्ट केल्यानंतर खात्याचा खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"  ></asp:Label>
              <asp:DropDownList ID="ddlkhatatype" runat="server" CssClass="form_drptxt" OnSelectedIndexChanged="ddlkhatatype_SelectedIndexChanged" Font-Names="Sakal Marathi" AutoPostBack="True"> </asp:DropDownList>
              <asp:Label ID="lblSelectedKhatatype" runat="server" Text="निवडलेला खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi" Visible="False"  ></asp:Label>
              <asp:Label ID="lblnewKhataType" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
         </div>

		  <div class="clear_br">
            
          </div>

          <asp:Panel ID="Panel3" runat="server" height="145px" ScrollBars="Vertical" CssClass="bs_pnl"  Width="100%">
            <hr style="margin-top: 0px" />
            <asp:GridView ID="gvKhataOwners" runat="server" AutoGenerateColumns="False" TabIndex="3" CssClass="grid" ShowHeaderWhenEmpty="True" >
                <PagerSettings FirstPageText="First" LastPageText="Last"  />
                <Columns>
                  
                    <asp:TemplateField HeaderText="खाता क्रमांक">
                        <ItemTemplate>
                            <asp:Label ID="lblkhata_no" runat="server" Text='<%# Bind("khata_no") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="पहिले नांव">
                        <ItemTemplate>
                            <asp:Label ID="lblfname" runat="server" Text='<%# Bind("fname") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="मधले नांव">
                        <ItemTemplate>
                            <asp:Label ID="lblmname" runat="server" Text='<%# Bind("mname") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="आडनांव">
                        <ItemTemplate>
                            <asp:Label ID="lbllname" runat="server" Text='<%# Bind("lname") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="टोपण नांव ">
                        <ItemTemplate>
                            <asp:Label ID="lbltopan_name" runat="server" Text='<%# Bind("topan_name") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="खाता प्रकार " Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblkhatatype" runat="server" Text='<%# Bind("khata_description") %>' CssClass="form_lbl"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="gridfooter" />
                <PagerStyle CssClass="gridpager" />
                <SelectedRowStyle CssClass="gridselectdrow" /> 
                <HeaderStyle CssClass="gridheader1" />
                <RowStyle CssClass="gridrow" />
            </asp:GridView>



        </asp:Panel>

         <div class ="row">

               &nbsp;<asp:Label ID="lblSurvey" runat="server" Text=" परिणाम होणारे सर्व्हे क्रमांक :-" Font-Names="Sakal Marathi"></asp:Label> &nbsp;&nbsp;
              <asp:Label ID="lblSurveyList" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
         </div>

         <br />

        
 

		

            

            <div class="row">
            <div class="column_s_wid40">
                <asp:Label ID="lblselected" runat="server" CssClass="form_lbl" Font-Bold="True" ForeColor="Aqua" BackColor="Orange" Visible="false"></asp:Label>
            </div>
        </div>

            <asp:panel ID="pnlWarasNames" runat="server" ScrollBars="Vertical" CssClass="bs_pnl" Height="150px" Width="100%" >
            
             &nbsp;<asp:Label ID="Label1" runat="server" Text="नविन नाव समाविष्ट करणे" CssClass="form_b_color" Visible="False" Font-Names="Sakal Marathi"></asp:Label>
            <asp:GridView ID="grvVars" runat="server"  AutoGenerateColumns="False"
                OnRowCancelingEdit="grvVars_RowCancelingEdit" OnRowCommand="grvVars_RowCommand"
                OnRowDeleting="grvVars_RowDeleting" OnRowEditing="grvVars_RowEditing" OnRowUpdating="grvVars_RowUpdating"  CssClass="grid" ShowFooter="True">
               
                <Columns>
                    <asp:TemplateField HeaderText="अ.क्र." Visible="False">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAno" runat="server" Text='<%# Bind("usrno") %>'></asp:TextBox>
                                
                                 </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtNewAnoS" runat="server" Visible="false" CssClass="form_txt" ></asp:TextBox>
                                
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblAnoS" runat="server" Text='<%# Bind("usrno") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                        <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="प्रथम नांव">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstNameS" runat="server" Text='<%# Bind("fname") %>' CssClass="form_txt"  MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtNewFirstNameS" runat="server" ControlToValidate="txtFirstNameS"
                                ErrorMessage="प्रथम नाव टाका"></asp:RequiredFieldValidator>
                        </EditItemTemplate>
                        
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtNewFirstNameS" runat="server" Visible="false" CssClass="form_txt" MaxLength="50" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtNewFirstNameS" runat="server" ControlToValidate="txtNewFirstNameS"
                                Enabled="false" ErrorMessage="प्रथम नाव टाका"></asp:RequiredFieldValidator>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPartyFNameS" runat="server" Text='<%# Bind("fname") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="वडील/पतीचे नांव">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMiddleNameS" runat="server" Text='<%# Bind("mname") %>' CssClass="form_txt" MaxLength="50" ></asp:TextBox>
                       
                        </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtNewMiddleNameS" runat="server" Visible="false" CssClass="form_txt" MaxLength="50"></asp:TextBox>
                           
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPartyMNameS" runat="server" Text='<%# Bind("mname") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Font-Names="Sakal Marathi" HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="आडनांव">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtSurNameS" runat="server" Text='<%# Bind("lname") %>' CssClass="form_txt" MaxLength="50"></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtNewSurNameS" runat="server" Visible="false" CssClass="form_txt" MaxLength="50" ></asp:TextBox>
                           
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPartyLNameS" runat="server" Text='<%# Bind("lname") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle Font-Names="Sakal Marathi" HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="टोपन नाव">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtAddressS" runat="server" Text='<%# Bind("topan_name") %>' CssClass="form_txt" MaxLength="75" ></asp:TextBox>
                            
                        </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtNewAddressS" runat="server" Visible="false" CssClass="form_txt" MaxLength="75"></asp:TextBox>
                         
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label18" runat="server" Text='<%# Bind("topan_name") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle Font-Names="Sakal Marathi" HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FullName" Visible="false">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtfullname"  Visible="false" runat="server" Text='<%# Bind("fullname") %>' CssClass="form_txt" MaxLength="75" ></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <edititemtemplate></edititemtemplate>
                            <asp:TextBox ID="txtfullname2" runat="server" Visible="false" CssClass="form_txt" MaxLength="75"></asp:TextBox>
                        </FooterTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblfullname" runat="server"  Visible="false" Text='<%# Bind("fullname") %>'></asp:Label>
                        </ItemTemplate>
                         <ItemStyle Font-Names="Sakal Marathi" HorizontalAlign="Center" />
                         <FooterStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                   
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton5" runat="server" CausesValidation="False" CommandName="Update"
                                Text="सुधारणा" Width="40px"></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton6" runat="server" CausesValidation="False" CommandName="Cancel"
                                Text="रद्द करा"  Width="72px"></asp:LinkButton>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButton7" runat="server" CausesValidation="False" CommandName="New"
                                Text="नवीन" Width="70px"></asp:LinkButton>
                        </FooterTemplate>
                        <ItemTemplate >
                            <asp:LinkButton ID="LinkButton8" runat="server" CausesValidation="False" CommandName="Edit"
                                Text="संपादन" Width="40px" enabled="true"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowDeleteButton="True" ShowHeader="True" DeleteText="नष्ट करा" 
                        EditText="संपादन" />
                </Columns>
                <FooterStyle CssClass="gridfooter" />                
                <SelectedRowStyle CssClass="gridselectdrow" />
                <HeaderStyle CssClass="gridheader" />
                <RowStyle CssClass="gridrow" />
            </asp:GridView>   </asp:panel>
         
           

         <div class="row">
            <center>
                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" Visible="false" CssClass="form_lbl_red_ss" ></asp:Label>
                <div class="clear_br"> </div>
                <asp:Button ID="btnAddNameSave" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl" OnClick="btnAddNameSave_Click" Font-Names="Sakal Marathi"  />&nbsp;
                <asp:Button ID="btnAddNameBack" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False" OnClick="btnAddNameBack_Click" Font-Names="Sakal Marathi" />
                &nbsp;
                <div class="clear_br">
                </div>
                </center>
        </div>
         <br />

         </asp:Panel>
    <center>

    <asp:Label ID="lblMes" runat="server" Text=""  Visible="false" ForeColor="Red"></asp:Label>

    </center>

     <div id="divpopup_NameCorr" class="ontop"></div>
    <asp:Panel ID="PnlNameCorr" runat="server"  Visible="False" CssClass="popupPnl_holderhakkden" BackColor="#EFEFEF">
         <div class="clear_br">
             <div class="clear_br">
             </div>
             <center>
                 <asp:Label ID="Label109" runat="server" CssClass="form_lblhead" Font-Bold="True" Text="नावांची स्पेलिंग दुरुस्ती करणे"></asp:Label>
             </center>
             <div class="clear_br">
             </div>
         </div>
        <div class="row">
    &nbsp;<asp:Label ID="lblKhataNoSpellCorr" runat="server" Text="खाता क्रमांक :"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;  <asp:Label ID="lblKhataNoNamesSpell" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>
           
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
           
    </div>
<br/>
  <div >
                            <asp:Panel ID="pnlOldNames" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="143px" Width="100%">
                                
                                <asp:GridView ID="gdvOldNames" runat="server" BorderWidth="1px" CssClass="grid"
                                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" UseAccessibleHeader="False">

                    
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="lblnivda" runat="server" Text="निवडा" CssClass="form_lbl"></asp:Label>
                                                <asp:CheckBox ID="chkeffect" runat="server"  Visible="false"
                                                    AutoPostBack="True" OnCheckedChanged="chkeffect_CheckedChanged"  />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkselect" runat="server" ToolTip="<%# ((GridViewRow)Container).RowIndex %>"   />
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="पहिले नाव">
                                            <ItemTemplate>

                                                <script type="text/javascript">//<!--
                                                    var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                    //--></script>

                                                <div id="rtDiv1">
                                                </div>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="false"
                                                    CssClass="form_txt_85"> </asp:TextBox>

                                                <script type="text/javascript">//<!--
                                                    textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                    //--></script>

                                               

                                                <script type="text/javascript">//<!--
                                                    rtDiv = document.getElementById('rtDiv1');
                                                    //--></script>

                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले   नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="टोपण नाव           ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="खाता. क्र" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="खाता प्रकार" Visible="false" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                       
                                    </Columns>
                                    <FooterStyle CssClass="gridfooter" />
                                    <PagerStyle CssClass="gridpager" />
                                    <SelectedRowStyle CssClass="gridselectdrow" />
                                    <HeaderStyle CssClass="gridheader" />
                                    <RowStyle CssClass="gridrow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                        <br/>
                        
                        <div class="row">
                         <asp:Button ID="btnAdd" runat="server" Text="समावेश करा" OnClick="btnAdd_Click" Visible="False"  />
                        </div>
                        <br/>
                        
                        <div>
                            &nbsp;<asp:Label ID="lblSurveyDisp" runat="server" Text="परिणाम होणारे सर्व्हे क्रमांक : " Visible="False"></asp:Label>   <asp:Label ID="lblSurveyListDispaly" runat="server" Text=" " Font-Names="Sakal Marathi" ForeColor="#FF33CC"></asp:Label>
                            
                        </div>
                        
                        <br/>
                        
                         <asp:Panel ID="pnlgdvNewBhogvatdar" runat="server" ScrollBars="vertical" CssClass="bhogvat_grdpnl" Height="125px" Width="100%" Visible="False">
                            <asp:GridView ID="gdvNewNames" runat="server" CssClass="grid" AutoGenerateColumns="False"
                                 TabIndex="4" OnRowDeleting="gdvNewNames_RowDeleting">
                                <Columns>
                                   
                                    
                                    <asp:CommandField ShowDeleteButton="True" Visible="false" ShowHeader="True" HeaderText="मिटवा"
                                        DeleteText="नष्ट करा"></asp:CommandField>
                                    
                                    <asp:TemplateField HeaderText="पहिले नाव">
                                        <ItemTemplate>

                                            <script type="text/javascript">//<!--
                                                var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                //--></script>

                                         
                                            <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="true"
                                                CssClass="form_txt_85"> </asp:TextBox>

                                            <script type="text/javascript">//<!--
                                                textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                //--></script>

                                         

                                            <script type="text/javascript">//<!--
                                                rtDiv = document.getElementById('rtDiv1');
                                                //--></script>

                                        </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="मधले   नाव        ">
                                        <ItemTemplate>
                                       
                                            <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="true"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                        <ItemTemplate>
                                            
                                            <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="true"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="टोपण  नाव           ">
                                        <ItemTemplate>
                                           
                                            <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="true"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="13%" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="खाता. क्र" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn1" runat="server" Enabled="False" Text='<%# Eval("khata_no") %>'
                                                CssClass="form_lbl"></asp:Label>
                                          
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="खाता प्रकार" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn6" runat="server" Enabled="False" Text='<%# Eval("khata_type") %>'
                                                CssClass="form_lbl"></asp:Label>
                                           
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" />
                                    </asp:TemplateField>
                                    
                                    
                                    
                                </Columns>
                                <FooterStyle CssClass="gridfooter" />
                                <PagerStyle CssClass="gridpager" />
                                <SelectedRowStyle CssClass="gridselectdrow" />
                                <HeaderStyle CssClass="gridheader" />
                                <RowStyle CssClass="gridrow" />
                            </asp:GridView>
                        </asp:Panel>
                        
                        <br/>
                        

        <div class="row">
<center> &nbsp;<asp:Label ID="lblmsgSpell" runat="server" Text="" ForeColor="Red"></asp:Label></center>
</div>
                       <div>
               <center>       

 <asp:Button ID="btn" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl" OnClick="btn_Click" Visible="False" Font-Names="Sakal Marathi"  />&nbsp;
                <asp:Button ID="btnNameCorrBack" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False"  Font-Names="Sakal Marathi" OnClick="btnNameCorrBack_Click" />
                   &nbsp; 
                   <div class="clear_br">
                   </div>
                           </center> 


                       </div>
    </asp:Panel>




    <div id="divpopup_PaneNameDel" class="ontop"></div>
    <asp:Panel ID="PaneNameDel" runat="server"  Visible="false" CssClass="popupPnl_holderhakkden" BackColor="#EFEFEF">

        <div class="clear_br">
            <div class="clear_br">
            </div>
            <center>
                <asp:Label ID="Label108" runat="server" CssClass="form_lblhead" Font-Bold="True" Text="नावे काढणे"></asp:Label>
            </center>
            <div class="clear_br">
            </div>
        </div>
        <div class="row">
    &nbsp;<asp:Label ID="lblKhataNoDelDisp" runat="server" Text="खाता क्रमांक :"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;  <asp:Label ID="lblKhataNoDisp" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="lblKhataTypeDel" runat="server" CssClass="form_lbl" Text="मुळ खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypeDelDisp" runat="server" ForeColor="#FF3300" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypeDelele" runat="server" Text="नावे कमी केल्यानंतर खात्याचा खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"  ></asp:Label>
              <asp:DropDownList ID="ddlkhatatypeDel" runat="server" CssClass="form_drptxt"  Font-Names="Sakal Marathi" AutoPostBack="True" OnSelectedIndexChanged="ddlkhatatypeDel_SelectedIndexChanged"> </asp:DropDownList>
              <asp:Label ID="lblKhataTypeDelNew" runat="server" Text="निवडलेला खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi" Visible="False"  ></asp:Label>
              <asp:Label ID="lblKhataTypeDelDispNew" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
           
    </div>
<br/>
  <div >
                            <asp:Panel ID="pnlOldNamesDel" runat="server" ScrollBars="vertical" CssClass="bs_pnl" Visible="true" height="200px"  Width="100%" >
                                <asp:GridView ID="gdvOldNamesDel" runat="server" BorderWidth="1px" CssClass="grid" BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" OnRowDeleting="gdvOldNamesDel_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="पहिले नाव">
                                            <ItemTemplate>

                                                <script type="text/javascript">//<!--
                                                    var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                    //--></script>

                                                <div id="rtDiv1">
                                                </div>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="false"
                                                    CssClass="form_txt_85"> </asp:TextBox>

                                                <script type="text/javascript">//<!--
                                                    textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                    //--></script>

                                             

                                                <script type="text/javascript">//<!--
                                                    rtDiv = document.getElementById('rtDiv1');
                                                    //--></script>

                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले   नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="टोपण नाव           ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="खाता. क्र" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="खाता प्रकार" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                           <asp:CommandField ShowDeleteButton="True" Visible="true" ShowHeader="True" HeaderText="मिटवा"
                                        DeleteText="नष्ट करा"></asp:CommandField>
                                       
                                    </Columns>
                                    <FooterStyle CssClass="gridfooter" />
                                    <PagerStyle CssClass="gridpager" />
                                    <SelectedRowStyle CssClass="gridselectdrow" />
                                    <HeaderStyle CssClass="gridheader" />
                                    <RowStyle CssClass="gridrow" />
                                </asp:GridView>
                                </asp:Panel>
                        </div>
                        <br/>



         <div >
                            <asp:Panel ID="pnlOldNamesDelSurveyWise" runat="server" ScrollBars="vertical" CssClass="bs_pnl" Visible="true" height="200px"  Width="100%" >
                                <asp:GridView ID="GdvKhataDelSurveyWise" runat="server" BorderWidth="1px" CssClass="grid" BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" OnRowDeleting="gdvOldNamesDel_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="पहिले नाव">
                                            <ItemTemplate>

                                                <script type="text/javascript">//<!--
                                                    var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                    //--></script>

                                                <div id="rtDiv1">
                                                </div>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="false"
                                                    CssClass="form_txt_85"> </asp:TextBox>

                                                <script type="text/javascript">//<!--
                                                    textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                    //--></script>

                                             

                                                <script type="text/javascript">//<!--
                                                    rtDiv = document.getElementById('rtDiv1');
                                                    //--></script>

                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले   नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="टोपण नाव           ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="खाता. क्र" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="खाता प्रकार" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                           <asp:CommandField ShowDeleteButton="True" Visible="true" ShowHeader="True" HeaderText="मिटवा"
                                        DeleteText="नष्ट करा"></asp:CommandField>
                                       
                                    </Columns>
                                    <FooterStyle CssClass="gridfooter" />
                                    <PagerStyle CssClass="gridpager" />
                                    <SelectedRowStyle CssClass="gridselectdrow" />
                                    <HeaderStyle CssClass="gridheader" />
                                    <RowStyle CssClass="gridrow" />
                                </asp:GridView>
                                </asp:Panel>
                        </div>
                        <br/>
                        
                     
                        
                        <div>
                            &nbsp;<asp:Label ID="lblSurveyNameDelDisp" runat="server" Text="परिणाम होणारे सर्व्हे क्रमांक : " Visible="False"></asp:Label>   <asp:Label ID="lblSurveyNameDel" runat="server" Text=" " 
Font-Names="Sakal Marathi" ForeColor="#FF33CC"></asp:Label>
                            
                        </div>
                        
                        <br/>
                        
                     
                        
                        <br/>
                        

        <div class="row">
<center> &nbsp;<asp:Label ID="Label67" runat="server" Text="" ForeColor="Red"></asp:Label></center>
</div>
                       <div>
               <center>       

 <asp:Button ID="btnNameDelSave" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl" OnClick="btnNaeCorrBack_Click" Visible="False" Font-Names="Sakal Marathi"  />&nbsp;
                <asp:Button ID="btnNameDelBack" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False"  Font-Names="Sakal Marathi" OnClick="btnNameDelBack_Click" />
                   &nbsp; 
                   <div class="clear_br">
                   </div>
                           </center> 


                           <asp:HiddenField ID="HiddenField3" runat="server" />
                           <asp:HiddenField ID="HiddenField4" runat="server" />
                           <asp:HiddenField ID="HiddenField5" runat="server" />
    
                       </div>
    </asp:Panel>



     <div id="divpopup_PnlKhataDelOnSurvey" class="ontop"></div>
    <asp:Panel ID="PnlKhataDelOnSurvey" runat="server"  Visible="false" CssClass="popupPnl_holderhakkden" BackColor="#EFEFEF">

        <div class="clear_br">
            <div class="clear_br">
            </div>
            <center>
                <asp:Label ID="Label75" runat="server" CssClass="form_lblhead" Font-Bold="True" Text="खाता क्रमांक निवडक सर्व्हे / गट क्रमांकावरुन वगळणे"></asp:Label>
            </center>
            <div class="clear_br">
            </div>
        </div>
        <div class="row">
    &nbsp;<asp:Label ID="lblDelOnSurveykhataNoDisp" runat="server" Text="खाता क्रमांक :"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;  <asp:Label ID="lblDelOnSurveykhataNoDispVal" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
    <asp:Label ID="lblDelOnSurveykhataTypeDisp" runat="server" CssClass="form_lbl" Text="खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
    <asp:Label ID="lblDelOnSurveykhataTypeDispVal" runat="server" ForeColor="#FF3300" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
    </div>
<br/>
  <div >
                            <asp:Panel ID="pnlgrdKhataDelOnSurvey" runat="server" ScrollBars="vertical" CssClass="bs_pnl" Visible="true" height="200px"  Width="100%" >
                                <asp:GridView ID="grdKhataDelOnSurvey" runat="server" BorderWidth="1px" CssClass="grid" BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" OnRowDeleting="gdvOldNamesDel_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="पहिले नाव">
                                            <ItemTemplate>

                                                <script type="text/javascript">//<!--
                                                    var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                    //--></script>

                                                <div id="rtDiv1">
                                                </div>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="false"
                                                    CssClass="form_txt_85"> </asp:TextBox>

                                                <script type="text/javascript">//<!--
                                                    textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                    //--></script>

                                             

                                                <script type="text/javascript">//<!--
                                                    rtDiv = document.getElementById('rtDiv1');
                                                    //--></script>

                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले   नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="टोपण नाव           ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="खाता. क्र" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="खाता प्रकार" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text6" runat="server" Enabled="false" Text='<%# Eval("khata_type") %>'
                                                    Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                        
                                       
                                    </Columns>
                                    <FooterStyle CssClass="gridfooter" />
                                    <PagerStyle CssClass="gridpager" />
                                    <SelectedRowStyle CssClass="gridselectdrow" />
                                    <HeaderStyle CssClass="gridheader" />
                                    <RowStyle CssClass="gridrow" />
                                </asp:GridView>
                                </asp:Panel>
                        </div>
                        <br/>
                                                             
                        <div>
                            &nbsp;<asp:Label ID="lblKhataDelOnSurveySurveyListDispaly" runat="server" Text="निवडलेला खाता क्रमांक असलेल्या सर्व्हे क्रमांकांची यादी :" Visible="False"></asp:Label>   <asp:Label ID="lblKhataDelOnSurveySurveyListDispVal" runat="server" Text=" " 
Font-Names="Sakal Marathi" ForeColor="#FF33CC"></asp:Label>
                            
                        </div>
                        <br/>
                        <br/>

        <div >
                            <asp:Panel ID="pnlSurveySelection" runat="server" ScrollBars="vertical" CssClass="bs_pnl"  Height="143px" Width="100%">
                                
                                <asp:GridView ID="gdvSurveySelection" runat="server" BorderWidth="1px" CssClass="grid"
                                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1" UseAccessibleHeader="False" OnSelectedIndexChanged="gdvSurveySelection_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkeffect" runat="server" AutoPostBack="True" OnCheckedChanged="chkeffect_CheckedChanged"  ToolTip="सर्व निवडा" />
                                                <asp:Label ID="lblnivda" runat="server" Text="सर्व निवडा" CssClass="form_lbl"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate  >
                                                <asp:CheckBox ID="chkSelectSurvey" runat="server" ToolTip="<%# ((GridViewRow)Container).RowIndex %>" OnCheckedChanged="chkSelectSurvey_CheckedChanged" AutoPostBack="True"  />
                                            </ItemTemplate>
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        
                                       <asp:TemplateField HeaderText="सर्व्हे क्रमांक"   >
                                            <ItemTemplate  >
                                                <asp:Label ID="lblpins" runat="server" Enabled="False" Text='<%# Eval("pins") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="सर्व्हे" Visible="False"  >
                                            <ItemTemplate  >
                                                <asp:Label ID="lblpin" runat="server" Enabled="False" Text='<%# Eval("pin") %>' 
                                                     CssClass="form_lbl"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="सर्व्हे1" Visible="False" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin1" runat="server" Enabled="False" Text='<%# Eval("pin1") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="सर्व्हे2" Visible="False" >
                                            <ItemTemplate >
                                                <asp:Label ID="lblpin2" runat="server" Enabled="False" Text='<%# Eval("pin2") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="सर्व्हे3" Visible="False" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin3" runat="server" Enabled="False" Text='<%# Eval("pin3") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="सर्व्हे4" Visible="False"  >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin4" runat="server" Enabled="False" Text='<%# Eval("pin4") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="सर्व्हे5" Visible="False" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin5" runat="server" Enabled="False" Text='<%# Eval("pin5") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="सर्व्हे6" Visible="False" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin6" runat="server" Enabled="False" Text='<%# Eval("pin6") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="सर्व्हे7" Visible="False"  >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin7" runat="server" Enabled="False" Text='<%# Eval("pin7") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="सर्व्हे8"  Visible="False" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin8" runat="server" Enabled="False" Text='<%# Eval("pin8") %>'
                                                    CssClass="form_lbl"  Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="7%" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle CssClass="gridfooter" />
                                    <PagerStyle CssClass="gridpager" />
                                    <SelectedRowStyle CssClass="gridselectdrow" />
                                    <HeaderStyle CssClass="gridheader" />
                                    <RowStyle CssClass="gridrow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                        <br/>

          <div>
                            &nbsp;<asp:Label ID="Label76" runat="server" Text="खाता क्रमांक वगळण्यासाठी निवडलेल्या सर्व्हे क्रमांकांची यादी :"></asp:Label>   <asp:Label ID="lblSelectedSurveyForDelete" runat="server" Text=" " 
Font-Names="Sakal Marathi" ForeColor="#FF33CC"></asp:Label>
                            
                        </div>
                        <br/>
                        <br/>
                        

        <div class="row">
<center> &nbsp;<asp:Label ID="Label87" runat="server" Text="" ForeColor="Red"></asp:Label></center>
</div>
                       <div>
               <center>       

 <asp:Button ID="btnKhataDelOnSurvey" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl" OnClick="btnKhataDelOnSurvey_Click" Visible="False" Font-Names="Sakal Marathi"  />&nbsp;
                <asp:Button ID="btnBackKhataDelOnSurvey" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False"  Font-Names="Sakal Marathi" OnClick="btnBackKhataDelOnSurvey_Click" />
                   &nbsp; 
                   <div class="clear_br">
                   </div>
                           </center> 


                           <asp:HiddenField ID="HiddenField6" runat="server" />
                           <asp:HiddenField ID="HiddenField7" runat="server" />
                           <asp:HiddenField ID="HiddenField8" runat="server" />
    
                       </div>
    </asp:Panel>




     <div id="divpopup_khataType" class="ontop"></div>
     <asp:Panel ID="pnlkhataType" runat="server" Visible="false" CssClass="popupPnl_holderhakkden" BackColor="#EFEFEF"  >
          <div class="clear_br">
              <div class="clear_br">
              </div>
              <center>
                  <asp:Label ID="Label110" runat="server" CssClass="form_lblhead" Font-Bold="True" Text="खाता प्रकार बदलणे "></asp:Label>
              </center>
              <div class="clear_br">
              </div>
          </div>
         <div class="row">
              &nbsp;<asp:Label ID="lblKhataTypechangeKhataNo" runat="server" CssClass="form_lbl" Text="खाता क्रमांक :-" Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypechangeKhataNoDisp" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypechangeKhataTypeOld" runat="server" CssClass="form_lbl" Text="मुळ खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypechangeKhataTypeOldDisp" runat="server" ForeColor="#FF3300" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
              <asp:Label ID="lblKhataTypechangeKhataType" runat="server" Text="नविन खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi"  ></asp:Label>
              <asp:DropDownList ID="ddlKhataTypechangeKhataTypeNew" runat="server" CssClass="form_drptxt" Font-Names="Sakal Marathi" AutoPostBack="True" OnSelectedIndexChanged="ddlKhataTypechangeKhataTypeNew_SelectedIndexChanged"> </asp:DropDownList>
              <asp:Label ID="lblKhataTypechangeKhataTypeNew" runat="server" Text="निवडलेला खाता प्रकार :- " Font-Bold="True" Font-Names="Sakal Marathi" Visible="False"  ></asp:Label>
              <asp:Label ID="lblKhataTypechangeKhataTypeNewDisp" runat="server" ForeColor="#FF33CC" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
         </div>

         <div class="clear_br">

         </div>

           <div >
                            <asp:Panel ID="panelkhataTypechangeNames" runat="server" ScrollBars="vertical" CssClass="bhogvat_grdpnl" Visible="true" height="200px"  Width="100%" >
                                <asp:GridView ID="grdkhataTypechangeNames" runat="server" BorderWidth="1px" CssClass="grid"
                                    BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"                                    
                                    TabIndex="1">
                                    <Columns>
                                        <asp:TemplateField HeaderText="पहिले नाव">
                                            <ItemTemplate>

                                                <script type="text/javascript">//<!--
                                                    var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                    //--></script>

                                                <div id="rtDiv1">
                                                </div>
                                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="false"
                                                    CssClass="form_txt_85"> </asp:TextBox>

                                                <script type="text/javascript">//<!--
                                                    textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                    //--></script>

                                               

                                                <script type="text/javascript">//<!--
                                                    rtDiv = document.getElementById('rtDiv1');
                                                    //--></script>

                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="मधले   नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="टोपण नाव           ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                    CssClass="form_lbl"></asp:Label>
                                                <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="false"
                                                    CssClass="form_txt_85"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="12%" />
                                        </asp:TemplateField>
                                       
                                       

                                          
                                       
                                    </Columns>
                                    <FooterStyle CssClass="gridfooter" />
                                    <PagerStyle CssClass="gridpager" />
                                    <SelectedRowStyle CssClass="gridselectdrow" />
                                    <HeaderStyle CssClass="gridheader" />
                                    <RowStyle CssClass="gridrow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                        <br/>
                        
                     
                        
                        <div>
                            &nbsp;<asp:Label ID="khataTypeChangeSurvey" runat="server" Text="परिणाम होणारे सर्व्हे क्रमांक : " Visible="False"></asp:Label>   <asp:Label ID="khataTypeChangeSurveyDisp" runat="server" Text=" " Font-Names="Sakal Marathi" ForeColor="#FF33CC"></asp:Label>
                            
                        </div>
                        
                        <br/>
          <div class="row">
<center> &nbsp;<asp:Label ID="lblktc" runat="server" Text="" ForeColor="Red"></asp:Label></center>
</div>
                        
                     <div>
               <center>       

 <asp:Button ID="btnkhataTypeChngeSave" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl"  Visible="False" Font-Names="Sakal Marathi" OnClick="btnkhataTypeChngeSave_Click"  />&nbsp;
                <asp:Button ID="btnkhataTyypeChngeBack" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False"  Font-Names="Sakal Marathi" OnClick="btnkhataTyypeChngeBack_Click"  />
                   &nbsp; 
                   <br />
                   <div class="clear_br">
                   </div>
                         </center> 


                           
    
                       </div>
                        
                        <br/>
         </asp:Panel>



        <DIV class="all_pnl">
                 <asp:Panel id="Paneldeal" runat="server" ><CENTER><H3><br />

                     &nbsp;&nbsp;<asp:Button id="btn_show" tabIndex=7 onclick="btn_show_Click" runat="server" Text="दुरुस्त्या पहा"  ToolTip="दुरुस्त्या पहा." CssClass="form_lbl" Enabled="False"></asp:Button>&nbsp;&nbsp;&nbsp;<asp:Button id="btn_pre" tabIndex=7 onclick="btn_pre_Click" runat="server" Text="पुर्वावलोकन पहा"  ToolTip="पुर्वावलोकन पहा." CssClass="form_lbl" Enabled="False"></asp:Button>&nbsp;&nbsp;<asp:Button ID="btnSave" runat="server" CssClass="form_lbl" Enabled="False" OnClick="btnSave_Click" Text="साठवा" ToolTip="साठवा" OnCommand="btnSave_Command" OnClientClick="confirm_save();" />
                     &nbsp;&nbsp;<asp:Button id="genDetailReport" runat="server" Text="तहसिलदारांच्या दुरुस्त्या मान्येतेचा अहवाल "  CssClass="form_lbl" OnClick="genDetailReport_Click" ToolTip="तहसिलदारांच्या दुरुस्त्या मान्येतेचा अहवाल " OnClientClick="confirm_genOldNewRpt();" Visible="False"></asp:Button>
&nbsp;<asp:Button id="btnMulNextSurvey" onclick="btnMulNextSurvey_Click" runat="server" Text="मागे"  CssClass="form_lbl" ToolTip="मागे"></asp:Button>
                     </asp:Panel></DIV>


     <asp:Button ID="btnNotUse" runat="server" Text="Button" style="display:none"/>
          <cc1:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlPopup" TargetControlID="btnNotUse"
        OkControlID="btnYes" BackgroundCssClass="modalBackground" BehaviorID="ModalPopBehave"/>
    
        <asp:Panel ID="pnlPopup" runat="server" Style="background-color: #FFFFFF;width: 40%;height:30%;border : 3px solid #0DA9D0; border-radius: 12px;padding: 0;" Visible="false">
        <div Style="background-color: #2FBDF1;height: 40px; color: White;line-height: 30px;text-align: center;font-weight: bold;border-top-left-radius: 6px;border-top-right-radius: 6px;">
            Confirmation
        </div>
        <div Style="font-family: Arial;font-size: 14pt;">
         <asp:Label ID="lblpopup" runat="server" Text="Label"></asp:Label>
        </div>
        <div Style="padding: 6px;" align="right">
            <asp:Button ID="btnYes" runat="server" Text="OK" Style="background-color: #2FBDF1; border: 1px solid #0DA9D0;" />            
            </div>
    </asp:Panel>

      <div id="divpopup_KhataNoAdd" class="ontop"></div>
                    <asp:Panel ID="pnlKhataNoAdd" runat="server" CssClass="popupPnl_holderhakkden" Visible="false" BackColor="#EFEFEF">
                        <div class="clear_br">

                        </div>

                        <CENTER><asp:Label id="Label7" runat="server" Text="खाते समावेश करणे"  Font-Bold="True" CssClass="form_lblhead"></asp:Label></CENTER>
                         <div class="clear_br">

                        </div>
                       
                     <DIV id="khataAdd"  class="row" visible="false"><DIV style="FLOAT: left; MARGIN-LEFT: 1%; WIDTH: 100%; HEIGHT: 58px">
                         <asp:Label id="lblKhataAddNo" runat="server" Text="खाता क्र." CssClass="form_lbl"></asp:Label>
                <asp:TextBox id="txtKhataNoAdd" tabIndex=2 runat="server" CssClass="form_txt" Width="55px" MaxLength="10" OnTextChanged="txtKhataNoAdd_TextChanged"></asp:TextBox> 
                         <asp:Button ID="btnNewBhogvatdarAdd0" runat="server" CssClass="form_lbl" onclick="btnNewBhogvatdarAdd_Click" OnClientClick="confirm_Search_khatano()" tabIndex="3" Text="खातेदार शोधा" ToolTip="खाता शोधा" />
                         <asp:Label ID="Label89" runat="server" CssClass="form_lbl" Text=" किंवा खातेदार शोधण्यासाठी नाव भरा : "></asp:Label>
                         <asp:TextBox ID="txtname1" runat="server" CssClass="form_txt" MaxLength="100" tabIndex="2"></asp:TextBox>
                <asp:Button id="btnNewBhovatdarSearch" tabIndex=6 onclick="btnNewBhovatdarSearch_Click" runat="server" Text="खातेदार शोधा" CssClass="form_lbl" ToolTip="खातेदार शोधा" OnClientClick="confirm_Search_khataname()" ></asp:Button> 
                <asp:DropDownList id="ddlname" tabIndex=2 runat="server" OnSelectedIndexChanged="ddlname_SelectedIndexChanged" ToolTip="शोधलेले नाव ड्रॉपडाउन मध्ये निवडा" AutoPostBack="True" width="300px">
                                        </asp:DropDownList>           
                         <br />
                         </DIV> 
                        
                
               </DIV>

                          <asp:Panel id="Panel6" runat="server" CssClass="bhogvat_grdpnl" height="200px"  Width="100%"  ScrollBars="vertical" >  <%--seema11--%>
                            <asp:GridView ID="gdvNewBhogvatdar" runat="server" CssClass="grid" BackColor="White"
                                BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"
                                OnSelectedIndexChanging="gdvNewBhogvatdar_SelectedIndexChanging1" OnSelectedIndexChanged="gdvNewBhogvatdar_SelectedIndexChanged1"
                                OnRowEditing="gdvNewBhogvatdar_RowEditing" OnRowDeleting="gdvNewBhogvatdar_RowDeleting1"
                                OnRowCancelingEdit="gdvNewBhogvatdar_RowCancelingEdit1" TabIndex="4">
                                <Columns>
                                    
                                    <asp:TemplateField HeaderText="खाता. क्र">                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn1" runat="server" Enabled="False" Text='<%# Eval("khata_no") %>'
                                                CssClass="form_lbl"></asp:Label>
                                            <asp:TextBox ID="grd2text1" runat="server" Enabled="false" MaxLength="10" Text='<%# Eval("khata_no") %>'
                                                Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:TemplateField>


                                     <asp:TemplateField HeaderText="अ.क्र." Visible="true">
                                <ItemTemplate>
                                    <asp:Label ID="lblColumn6" runat="server" CssClass="form_lbl" Enabled="true" Text='<%# Eval("usrno") %>'></asp:Label>
                                    <asp:TextBox ID="grd2text6" runat="server" CssClass="form_txt_85" MaxLength="10" Text='<%# Eval("usrno") %>' Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पहिले नाव">
                                        <ItemTemplate>

                                            <script type="text/javascript">//<!--
                                                var devExists = false; var devEditExists = false; var doctype = true; var formName = ""; var textAreaName = ""; var inputModeRadioName = ""; var textFieldArr = new Array(); var comments = new Array(); var commentDivs = new Array(); var rteArr = new Array(); var divRelativePos = false; var acEnabled = false; var dx = false;
                                                //--></script>

                                            <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                CssClass="form_lbl"></asp:Label>
                                            <asp:TextBox ID="grd2text2" runat="server" MaxLength="50" Text='<%# Eval("fname") %>' Visible="false"
                                                CssClass="form_txt_85">
                                            </asp:TextBox>

                                            <script type="text/javascript">//<!--
                                                textFieldArr[textFieldArr.length] = "grd2text2"; devExists = true;
                                                //--></script>

                                          

                                            <script type="text/javascript">//<!--
                                                rtDiv = document.getElementById('rtDiv1');
                                                //--></script>

                                        </ItemTemplate>
                                        <ItemStyle Width="14%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="मधले   नाव        ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                CssClass="form_lbl"></asp:Label>
                                            <asp:TextBox ID="grd2text3" runat="server" MaxLength="50" Text='<%# Eval("mname") %>' Visible="false"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="शेवटचे  नाव        ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                CssClass="form_lbl"></asp:Label>
                                            <asp:TextBox ID="grd2text4" runat="server" MaxLength="50" Text='<%# Eval("lname") %>' Visible="false"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="टोपण  नाव           ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                CssClass="form_lbl"></asp:Label>
                                            <asp:TextBox ID="grd2text5" runat="server" MaxLength="50" Text='<%# Eval("topan_name") %>' Visible="false"
                                                CssClass="form_txt_85" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="13%" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                     <asp:CommandField ShowDeleteButton="True" Visible="true" ShowHeader="True" HeaderText="मिटवा"
                                        DeleteText="नष्ट करा"></asp:CommandField>
                                </Columns>
                                <FooterStyle CssClass="gridfooter" />
                                <PagerStyle CssClass="gridpager" />
                                <SelectedRowStyle CssClass="gridselectdrow" />
                                <HeaderStyle CssClass="gridheader" />
                                <RowStyle CssClass="gridrow" />
                            </asp:GridView>
                        </asp:Panel> &nbsp;<BR />

                         <div>
               <center>       

 <asp:Button ID="btnNewKhataAddSave" runat="server" Text="माहिती साठवा " 
                    ValidationGroup="Check" TabIndex="23" CssClass="form_lbl"  Visible="False" Font-Names="Sakal Marathi" OnClick="btnNewKhataAddSave_Click"  />&nbsp;
                <asp:Button ID="btnKhataAddBack" runat="server"  Text="मागे जा"
                     TabIndex="4" CssClass="form_lbl" CausesValidation="False" EnableViewState="False"  Font-Names="Sakal Marathi" OnClick="btnKhataAddBack_Click"  />
                   &nbsp; </center> 


                           
    
                       </div>
                        
                        <br/>
                        </asp:Panel>
    <div id="divpopup_LocalNameAdd" class="ontop"></div>

       <asp:Panel ID="pnlLocalNameAdd" runat="server" CssClass="popupPnl_holderhakkden" Visible="false" BackColor="#EFEFEF" > 
              <div class="clear_br">

                        </div>

                        <CENTER><asp:Label id="Label13" runat="server" Text="शेतीचे स्थानिक नाव  व  सीमा आणि भुमापन चिन्हे भरणे"  Font-Bold="True" CssClass="form_lblhead"></asp:Label></CENTER>
                         <div class="clear_br">
                        </div>

                         <div class="row">
                             &nbsp; &nbsp;<asp:Label ID="lblAgriLocalNameDisp" runat="server" Text="शेतीचे स्थानिक नाव : " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                              <asp:TextBox ID="txtAgriLocalName" runat="server" TextMode="MultiLine" Width="75%" ToolTip="येथे शेतीचे स्थानिक नाव भरा अथवा दुरुस्त करा." Height="50px" OnTextChanged="txtAgriLocalName_TextChanged"></asp:TextBox>
                              <div class="clear_br">
                             </div>

                             <div class="row">
                             &nbsp; &nbsp;<asp:Label ID="lblBoundryIdDisp" runat="server" Text="सीमा आणि भुमापन चिन्हे :" CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;
                              <asp:TextBox ID="txtBoundryId" runat="server" Width="75%" ToolTip="येथे सीमा आणि भुमापन चिन्हे भरा अथवा दुरुस्त करा."  Height="50px" MaxLength="50" OnTextChanged="txtBoundryId_TextChanged"  TextMode="MultiLine"></asp:TextBox>
                              <div class="clear_br">
                             </div>

                              <center>
                                  <asp:Button ID="btnAgriLocalNameSave" runat="server" Text="साठवा" CssClass="form_lbl"  ToolTip="शेतीचे स्थानिक नाव साठविण्यासाठी येथे क्लिक करा." Font-Names="Sakal Marathi" OnClick="btnAgriLocalNameSave_Click"/>&nbsp;
                                  <asp:Button ID="Button1" runat="server"  Text="मागे जा"  CssClass="form_lbl" CausesValidation="False" EnableViewState="False"  Font-Names="Sakal Marathi" OnClick="Button1_Click1"   />
                              </center>
                              <div class="clear_br">
                                  <asp:HiddenField ID="hf_concated_mut_data" runat="server" />
                                  <asp:HiddenField ID="hfSignDataString" runat="server" />
                                  <asp:HiddenField ID="HiddenField2" runat="server" />
                             </div>
                         </div>
             
                        


       </asp:Panel>

    <asp:HiddenField id="HiddenField1" runat="server"></asp:HiddenField>
    <asp:HiddenField id="hfRptName" runat="server"></asp:HiddenField> <asp:HiddenField id="hfOther" runat="server"></asp:HiddenField> <asp:HiddenField id="hfDBATool" runat="server"></asp:HiddenField> 
</asp:Content>

