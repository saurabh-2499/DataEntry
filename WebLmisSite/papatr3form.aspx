<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster_DBA.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="papatr3form.aspx.cs" Inherits="papatr3form" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
    </script>
    <div class="clear">
    </div>
    <div class="row">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="गावाचे नाव :  " CssClass="form_lbl" Font-Names="Sakal Marathi"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="lblVillageName" runat="server" Text="" CssClass="form_lbl" ForeColor="Purple"></asp:Label>&nbsp; &nbsp;<asp:Label ID="Label8" runat="server" Text="तालुका :  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="lblTalukaName" runat="server" Text="" CssClass="form_lbl" ForeColor="Purple"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label9" runat="server" Text="जिल्हा :  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="lblDistrictName" runat="server" Text="" CssClass="form_lbl" ForeColor="Purple"></asp:Label>
    </div>
    <div class="row">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="सेन्सस कोड :  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="lblCcode" runat="server" Text="" CssClass="form_lbl" ForeColor="Purple"></asp:Label>
    </div>
    <div class="row">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="ग्राम महसूल अधिकारी नाव :  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="lblTalathiName" runat="server" Text="" CssClass="form_lbl" ForeColor="Purple"></asp:Label>&nbsp;&nbsp;<asp:Label ID="Label12" runat="server" Text="सेवार्थ आय. डी. :  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="lblTalathiSevarth" runat="server" Text="" CssClass="form_lbl" ForeColor="Purple"></asp:Label>
    </div>
    <div class="row">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Text="मंडळ अधिकारी नाव :  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="lblCOName" runat="server" Text="" CssClass="form_lbl" ForeColor="Purple"></asp:Label>&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="सेवार्थ आय. डी. :  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="lblCOSevarth" runat="server" Text="" CssClass="form_lbl" ForeColor="Purple"></asp:Label>
    </div>
    <div class="row">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Text="पालक महसुल अधिकारी यांचे नाव :  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lblRevOffName" runat="server" CssClass="form_lbl" ForeColor="Purple"></asp:Label>&nbsp;&nbsp;&nbsp;<asp:Label ID="Label11" runat="server" Text="सेवार्थ आय. डी. :  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="lblRevOffSevarth" runat="server" CssClass="form_lbl" ForeColor="Purple"></asp:Label>

    </div>
    <div class="row">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label runat="server" Text="१)  दिनांक ०५/०५/२०१७ चे परिपत्रका प्रमाणे महसुल अधिकाऱ्यांनी गाव तपासणी केल्याचा दिनांक" CssClass="form_lbl"></asp:Label>
        &nbsp;:&nbsp;
        <asp:Label ID="lblRevOffCheckDate" runat="server" CssClass="form_lbl" ForeColor="Purple"></asp:Label>
    </div>
    <div class="row">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl" runat="server" Text=" २)  तालुका समरी अहवाल - १ (अहवाल १ ते १४ ) निरंक आहे का ?  (अहवाल १ , ३ व ६ वगळून)" CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbAh1Yes" runat="server" Text="होय" AutoPostBack="True" OnCheckedChanged="rdbAh1Yes_CheckedChanged" /><asp:RadioButton ID="rdbAh1No" runat="server" Text="नाही" AutoPostBack="True" OnCheckedChanged="rdbAh1No_CheckedChanged" />
    </div>
    <div class="row">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lbl1" runat="server" Text=" ३)  तालुका समरी अहवाल - २ (अहवाल १५ ते २६ ) निरंक आहे का ?  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbAh2Yes" runat="server" Text="होय" AutoPostBack="True" OnCheckedChanged="rdbAh2Yes_CheckedChanged" /><asp:RadioButton ID="rdbAh2No" runat="server" Text="नाही" AutoPostBack="True" OnCheckedChanged="rdbAh2No_CheckedChanged" />
    </div>
    <div class="row">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Text=" ४ )   दिनांक ०५/०५/२०१७ चे परिपत्रका तील तपासणी अधिकाऱ्यांनी व कर्मचाऱ्यांनी सादर करावयाची प्रमाणपत्रे दिली आहेत का ?  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbDocYes" runat="server" Text="होय" AutoPostBack="True" OnCheckedChanged="rdbDocYes_CheckedChanged" /><asp:RadioButton ID="rdbDocNo" runat="server" Text="नाही" AutoPostBack="True" OnCheckedChanged="rdbDocNo_CheckedChanged" />
    </div>
    <br />
    <center>
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1px" CellSpacing="0">
            <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%" Font-Bold="true" Font-Names="Sakal Marathi">
                    <asp:Label ID="Label10" runat="server" Text="अ. क्र."></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Font-Bold="true" Font-Names="Sakal Marathi">
                    <asp:Label ID="Label20" runat="server" Text="पद"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="20%" Font-Bold="true" Font-Names="Sakal Marathi">
                    <asp:Label ID="Label13" runat="server" Text="नाव"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%" Font-Bold="true" Font-Names="Sakal Marathi">
                    <asp:Label ID="Label14" runat="server" Text="सेवार्थ आय. डी."></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center" Font-Bold="true" Font-Names="Sakal Marathi">
                    <asp:Label ID="Label15" runat="server" Text="% तपासणी  इष्टांक"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Font-Bold="true" Font-Names="Sakal Marathi">
                    <asp:Label ID="Label16" runat="server" Text="तपासणी केलेल्या  ७/१२ ची संख्या"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Font-Bold="true" Font-Names="Sakal Marathi">
                    <asp:Label ID="Label17" runat="server" Text="तपासणी प्रमाणपत्र  प्राप्त दिनांक"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%">
                    <asp:Label ID="Label49" runat="server" Text="१"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="Label50" runat="server" Text="२"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="20%">
                    <asp:Label ID="Label51" runat="server" Text="३"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center" Width="15%">
                    <asp:Label ID="Label52" runat="server" Text="४"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="Label53" runat="server" Text="५"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="Label54" runat="server" Text="६"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="Label22" runat="server" Text="७"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%">
                    <asp:Label ID="Label18" runat="server" Text="१"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="Label19" runat="server" Text="  ग्राम महसूल अधिकारी  " Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblTalathiNameTable" runat="server" Text="  "></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%">
                    <asp:Label ID="lblTalathiSevarthTable" runat="server" Text="    "></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center">
                    <asp:Label ID="Label21" runat="server" Text="१००%"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblTal712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblTalDate" runat="server" Enabled="true" Width="70px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%">
                    <asp:Label ID="Label24" runat="server" Text="२"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="Label25" runat="server" Text="मंडळ अधिकारी" Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="20%">
                    <asp:Label ID="lblCONameTable" runat="server" Text="  "></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%">
                    <asp:Label ID="lblCOSevarthTable" runat="server" Text="   "></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center">
                    <asp:Label ID="Label27" runat="server" Text="३०%"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblCO712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblCODate" runat="server" Enabled="true" Width="70px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%">
                    <asp:Label ID="Label30" runat="server" Text="३"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="Label31" runat="server" Text="नायब तहसिलदार" Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lbldbaNameTable" runat="server" Text="  " Width="20%"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%">
                    <asp:Label ID="lblDBASevarthtbl" runat="server" Text=""></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center">
                    <asp:Label ID="Label33" runat="server" Text="१०%"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblDBA712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblDBADate" runat="server" Enabled="true" Width="70px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>

            <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%">
                    <asp:Label ID="Label23" runat="server" Text="४"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="Label26" runat="server" Text="तहसिलदार" Font-Bold="true" Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblTahNameTable" runat="server" Text="  " Width="20%"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%">
                    <asp:Label ID="lblTahSevarthtbl" runat="server" Text=""></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center">
                    <asp:Label ID="Label32" runat="server" Text="५%"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblTah712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblTahDate" runat="server" Enabled="true" Width="70px"></asp:Label>
                </asp:TableCell>
            </asp:TableRow>


            <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%">
                    <asp:Label ID="Label36" runat="server" Text="५"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="Label37" runat="server" Text="उपविभागिय अधिकारी" Font-Bold="true" Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="20%">
                    <asp:Label ID="lblColNametable" runat="server"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%">
                    <asp:Label ID="lblColSevarthtable" runat="server"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center">
                    <asp:Label ID="Label39" runat="server" Text="३%"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblCOL712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblColDate" runat="server" Enabled="true" Width="70px"></asp:Label>

                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%">
                    <asp:Label ID="Label42" runat="server" Text="६"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="Label43" runat="server" Text="जिल्हाधिकारी/उपजिल्हाधिकारी" Font-Bold="true" Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="20%">
                    <asp:Label ID="lblSdoNametable" runat="server"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%">
                    <asp:Label ID="lblSdoSevarthtable" runat="server"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center">
                    <asp:Label ID="Label45" runat="server" Text="१%"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblSDO712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:Label></asp:TableCell>
                <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px">
                    <asp:Label ID="lblSdoDate" runat="server" Enabled="true" Width="70px"></asp:Label>

                </asp:TableCell>
            </asp:TableRow>


        </asp:Table>

    </center>


    <br />

    <div class="row">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label28" runat="server" Text=" ५ )   संबंधित तलाठी,मंडळ अधिकारी,नायब तहसिलदार व तहसिलदार यांनी गाव निहाय संगणिकृत ७/१२ च्या डेटा अचुकते बाबत जिल्हाधिकारी यंना प्रमाणपत्र सादर केलेले आहे का ? <b>( प्रपत्र क्रमांक - २ )  " CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="rdbPrapatr2Yes" runat="server" Text="होय" AutoPostBack="True" OnCheckedChanged="rdbPrapatr2Yes_CheckedChanged" /><asp:RadioButton ID="rdbPrapatr2No" runat="server" Text="नाही" AutoPostBack="True" OnCheckedChanged="rdbPrapatr2No_CheckedChanged" />
    </div>
    <div class="clear">
    </div>
    <br />

    <div class="row">
        <center>
            <asp:Button ID="btnSave" runat="server" Text="साठवा" OnClick="btnSave_Click" />
            <asp:Button ID="btnRpt" runat="server" Text="प्रपत्र -३ अंतिम प्रमाणपत्र" OnClick="btnRpt_Click" Visible="false" OnClientClick="SetTarget();" />

        </center>
    </div>

</asp:Content>

