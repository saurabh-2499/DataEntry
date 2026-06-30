<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pg712.aspx.vb" Inherits="pg712"  Title="७/१२"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <style type="text/css">

.form_lbl
{
	font-family: Sakal Marathi;
	font-size: 11pt;
	font-weight:bold;	
}

.form_lbl
{
	font-family: Sakal Marathi;
	font-size: small;
}

    </style>
</head>

<body>
    <form id="form1" runat="server">
          <asp:ScriptManager ID="scrptmhr1" runat="server"  AsyncPostBackTimeout="360"></asp:ScriptManager>

        <script language="javascript" type="text/javascript">
            function confirm_confirm()
            {

                if (!confirm('निवडलेला सदर ७/१२ कन्फर्म करण्यापुर्वी कृषिक आहे किंवा अकृषिक आहे याची खात्री करा. ७/१२ कृषिक आहे किंवा अकृषिक आहे याला अनुसरुन क्षेत्र व क्षेत्राचे एकक योग्य आहे याची खात्री करा.\n ७/१२ कन्फर्म करायचा आहे का ? असल्यास OK क्लिक करा. कन्फर्म करायचा नसल्यास Cancel क्लिक करा.'))
                {


                    var confirm_value = document.createElement("INPUT");
                    confirm_value.type = "hidden";
                    confirm_value.name = "confirm_value";
                    confirm_value.value = "notOk";
                    document.forms[0].appendChild(confirm_value);
                   // alert('कृपया, ७/१२ कन्फर्म करायचा आहे किंवा एडिट करायचा आहे हे तपासुन पहा.');

                    return false;
                }


            }

            function confirm_edit() {

                if (!confirm('नविन ७/१२ तयार / /दुरुस्त करायचा आहे का ? असल्यास OK क्लिक करा. नविन ७/१२ तयार /दुरुस्त करायचा नसल्यास Cancel क्लिक करा.'))
                {


                    var confirm_value = document.createElement("INPUT");
                    confirm_value.type = "hidden";
                    confirm_value.name = "confirm_value";
                    confirm_value.value = "notOk";
                    document.forms[0].appendChild(confirm_value);
                   // alert('कृपया, ७/१२ कन्फर्म करायचा आहे किंवा एडिट करायचा आहे हे तपासुन पहा.');

                    return false;
                }


            }

            </script>


<%--    <div>

         <center>
        <asp:Button ID="btnConfirmUp" runat="server" Text="CONFIRM (कायम करणे)" ToolTip="७/१२ CONFIRM (कायम करणे) करण्यासाठी येथे क्लिक करा" OnClientClick="confirm_confirm();" />
         &nbsp;&nbsp;
        <asp:Button ID="btnEditUp" runat="server" Text="EDIT (दुरुस्ती साठी मार्क करणे)" ToolTip="७/१२ EDIT (दुरुस्ती) साठी मार्क करण्यासाठी येथे क्लिक करा." OnClientClick="confirm_edit();" />&nbsp;&nbsp;
         </center>
         </div>
        <div>--%>

        <asp:Label ID="lblmessage" runat="server"></asp:Label>
          <br />
          <div>

         <center>
        <asp:Button ID="btnConfirm" runat="server" Text="कन्फर्म ( कायम करणे )" ToolTip="७/१२ कन्फर्म ( कायम करणे / ई-फेरफार साठी स्विकृतीत ) करण्यासाठी येथे क्लिक करा" OnClientClick="confirm_confirm();" CssClass="form_lbl" Visible="False" />
         &nbsp;&nbsp;
        <asp:Button ID="btnEdit" runat="server" Text=" नविन ७/१२ तयार करणे/दुरुस्त करणे" ToolTip="नविन ७/१२ तयार दुरुस्त करण्यासाठी येथे क्लिक करा." OnClientClick="confirm_edit();" CssClass="form_lbl" />&nbsp;&nbsp;
         <asp:Button ID="btnBack" Text="मागे जा" runat="server" ToolTip="मागे जा"
                            TabIndex="21" CssClass="form_lbl"  />
         </center>
            <br />

            <div class="clear_br">

            </div>

                <div class="clear_br">

            </div>

             <div class="clear_br">

            </div>

                <div class="clear_br">

            </div>

             <div class="clear_br">

            </div>

                <div class="clear_br">

            </div>

             <div class="clear_br">

            </div>

                <div class="clear_br">

            </div>



            <DIV id="divpopup_pins" class="ontop_survey"></DIV>
                
                <center>
                
            
            <asp:Panel ID="PanelCorrection" runat="server" CssClass="popupPnl_holder_survey" BackColor="#EFEFEF" Visible="false">
                <div class ="row">
                   <center> &nbsp;&nbsp; <asp:Label ID="lblCorrectionDetails" runat="server" Text="दुरुस्तीचा तपशिल" ></asp:Label> &nbsp;&nbsp;</center>
                    <br />
                    <asp:TextBox ID="txtCorrectionDetails" runat="server" TextMode="MultiLine" Height="28px" Width="921px"></asp:TextBox>
                    <br />
                    <center> &nbsp;&nbsp; <asp:Label ID="lblMsg" runat="server" Text=""  ForeColor="red"></asp:Label> &nbsp;&nbsp;</center>
                    <br />
                    <center><asp:Button ID="btnCorrctionDetailsSave" runat="server" Text="दुरुस्तीचा तपशिल साठवा" /></center>
                </div>
            </asp:Panel>
        
        &nbsp;
        <rsweb:ReportViewer ID="ReportViewer712" runat="server" Width="0px"  Height="0px"  ShowPageNavigationControls="false"  ShowExportControls="false" ShowDocumentMapButton="false" ShowPrintButton="false" ShowToolBar="false" ShowRefreshButton="false" ></rsweb:ReportViewer>


    </div>
        
            
      
        <asp:HiddenField id="hfRptName" runat="server"></asp:HiddenField>
        <asp:HiddenField id="hfOther" runat="server"></asp:HiddenField>
        <asp:HiddenField id="hfDBATool" runat="server"></asp:HiddenField> 

    </form>
    
<asp:Image ID="Img712" runat="server" />
</body>
</html>
