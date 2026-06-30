
<%@ Page Language="C#" MasterPageFile="~/InnerMaster_DBA.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="pgSecondDeclaration.aspx.cs" Inherits="pgSecondDeclaration" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" onload="setSession();">

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js">

    </script>
    <script type = "text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
</script>
    <script type="text/javascript">
        function MouseEvents(objRef, evt) {
            var checkbox = objRef.getElementsByTagName("input")[0];
            if (evt.type == "mouseover") {
                objRef.style.backgroundColor = "orange";
            }
            else {
                if (checkbox.checked) {
                    objRef.style.backgroundColor = "aqua";
                }
                else if (evt.type == "mouseout") {
                    if (objRef.rowIndex % 2 == 0) {
                        //Alternating Row Color
                        objRef.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        objRef.style.backgroundColor = "white";
                    }
                }
            }
        }
    </script>
    <script type="text/javascript" language="javascript">


        document.onreadystatechange = function () {
            if (document.readyState == "interactive") {
                document.getElementById('myHiddenDiv').style.display = "none";;
            }
        }

        function MultipleUserLogin() {
            if (confirm('जर तुम्ही दुसऱ्या मशीनवरून काम करत असाल तर आपल्या या लॉगिन ने पूर्वीचे लॉगिन हे लॉग आउट होईल अन्यथा आपणास पुढे काम करता येणार नाही.\n आपणास तरीही लॉगिन करावयाचे आहे का??')) {
                document.getElementById("<%=hfMultipleUsers.ClientID %>").value = "true";
            }
            else {
                window.location = window.location.protocol + '//' + window.location.hostname + '/edit/pglogout.aspx';
            }
        }

    </script>

    <script language="javascript"  type="text/javascript">
        function validatenumerics(key) {
            //getting key code of pressed key
            var keycode = (key.which) ? key.which : key.keyCode;
            //comparing pressed keycodes

            if (keycode > 31 && (keycode < 48 || keycode > 57)) {
                alert(" माहिती अंकात भरा...!!!! ");
                return false;
            }
            else return true;
        }

</script>
    <asp:HiddenField ID="Version" runat="server" />
    <asp:HiddenField ID="hfMultipleUsers" runat="server" />
    <div class="printdiv">
    </div>
    <a id="MainContent" name="MainContent"></a>
    <%-- <br />--%>
    <center>
        <asp:Panel ID="Panel1" runat="server" BorderWidth="1" Width="90%">
            <%--<div class="row">
                    <center>
                        <asp:Label ID="Label1" runat="server" Text="Declaration-II" Font-Bold="True" Font-Size="X-Large" style="text-decoration: underline"></asp:Label>
                    </center>
                </div>
                <br />--%><br />
            <div class="row">
                <center style="font-size: large">
                    <asp:Label ID="Label2" runat="server" Text="Re-Edit Module मधील काम पूर्ण झाल्याचे  नायब तहसिलदार ( D.B.A.) यांचे   स्वयंघोषणापत्र" Font-Names="Sakal Marathi" Style="font-size: x-large; font-weight: 700; color: #3399FF; text-decoration: underline"></asp:Label><%--<asp:Label ID="Label2" runat="server" Text="तपासणी सूची ( १-२४ )  नुसार गावाचे  खाता  रजिष्टर व गावातील सर्व ७/१२ यांच्या दुरुस्त्या तपासणी " Font-Names="Sakal Marathi" Style="font-size: x-large; font-weight: 700; color: #3399FF; text-decoration: underline"></asp:Label>
                    <br /><asp:Label ID="Label1" runat="server" Text=" सूची   क्रमांकानुसार पूर्ण केल्याची  घोषणा  करणे" Font-Names="Sakal Marathi" Style="font-size: x-large; font-weight: 700; color: #3399FF; text-decoration: underline"></asp:Label>--%></center>
            </div>
            <br />
            <center>
                <div class="row" style="width: 90%; text-align: justify; font-family: 'Sakal Marathi';">
                    <span style="font-size: medium">मी <b>
                        <asp:Label ID="lblDBAName" runat="server"></asp:Label></b>
                        नायब तहसिलदार तथा  डी.बी.ए. तालुका   : <b>
                           <asp:Label ID="lblDBA_Taluka_name" runat="server"></asp:Label></b> जिल्हा  :  <b>
                           <asp:Label ID="lblDBA_District_name" runat="server"></asp:Label></b> <span id="ctl00_ContentPlaceHolder1_Label14">सेवार्थ</span> आय डी : 
                       <b><asp:Label ID="lblDBASevarthID" runat="server"></asp:Label></b> स्वयंघोषणा करतो की,
                    </span>
                    <br style="font-size: medium" />
                    <span style="font-size: medium"></span><br style="font-size: medium" />
                    <p><span style="font-size: medium">मौजे&nbsp;
                        <b>
                            <asp:Label ID="lblVillageName" runat="server"></asp:Label></b>
                        &nbsp;तालूका : 
                       <b>
                           <asp:Label ID="lblTalukaName" runat="server"></asp:Label></b>
                        &nbsp;या गावाचे संगणकीकृत गांव नमुना नं. 7/12 व 8 अ हस्तलिखित</span><span style="font-size: medium">गाव न.नं. 7/12 व 8 अ शी तंतोतंत जुळणे साठी दिलेया खालील पैकी एक किंवा सर्व सुविधांचा वापर करून</span> 
                    <span style="font-size: medium">तसेच ऑनलाईन झाल्यापासुन सर्व ऑनलाईन फेरफार नोंदी व त्याप्रमाणे 7/12 व 8अ मधील दुरुस्त्या  ग्राम महसूल अधिकारी : <b> <asp:Label ID="villUser" runat="server" Text=""></asp:Label> </b>  सेवार्थ <font face="Sakal Marathi  " size="3">आयडी</font>. : <b> <asp:Label ID="villUser_ID" runat="server" Text=""></asp:Label></b>  यांनी  पूर्ण केल्या आहेत.</span><br style="font-size: medium" />
                    </p>
                   <%-- <br />--%>

                    <center>
                        <table width="60%" cellpadding="0" cellspacing="0">
                             <tr>
                                 <td style="text-align: left;font-size: medium;">1. eFarfar.</td>
                                 <td style="text-align: left;font-size: medium;">2. OnlineData Updation.</td>
                             </tr>
                            <tr>
                                 <td style="text-align: left;font-size: medium;">3. Edit Module.</td>
                                 <td style="text-align: left;font-size: medium;">4. Re-Edit Module.</td>
                             </tr>
                             <tr>
                                 <td style="text-align: left;font-size: medium;">5. Online Data Correction.</td>
                                 <td style="text-align: left;font-size: medium;">6. Online Crop Updation.</td>
                             </tr>
                            <tr>
                                 <td style="text-align: left;font-size: medium;">7. Online DBA Tool.</td>
                                 <td style="text-align: left;font-size: medium;">8. HTML 7/12 Generation.</td>
                             </tr>
                            <tr>
                                 <td style="text-align: left;font-size: medium;">9. User Creation.</td>
                                 <td></td>
                             </tr>
                        </table>
                    </center>               
                    
                  
                </div>
            </center>
            <br />
            <center>
                <div class="row" style="width: 90%; text-align: left; font-family: 'Sakal Marathi';">
                    <span style="font-size: medium">1. खाते दुरुस्ती संबंधी सर्व दुरुस्त्या Re-Edit Module वापरून पूर्ण केल्या आहेत.</span><br style="font-size: medium" />
                    <span style="font-size: medium">2. चावडी वाचनामध्ये प्राप्त आक्षेप व दिनांक ०५/०५/२०१७ च्या परिपत्रका प्रमाणे महसूल अधिकाऱ्यांच्या तपासणी</span>
                    <span style="font-size: medium">तक्त्यात ( १ ते २४ मुद्दे ) आढळून आलेल्या सर्वे त्रुटी दूर करण्यात आल्या आहेत.</span><br style="font-size: medium" />
                    <hr>
                    <span style="font-size: medium">
                        <br />
                        गावाची तपासणी केलेल्या महसूल अधिकाऱ्यांचे (पालक) नाव
                        <asp:TextBox ID="txtInspectOfficer" runat="server" Width="289px"></asp:TextBox>
                        <br />
                        <br />
                        पदनाम<asp:TextBox ID="txtdesg" runat="server" Width="220px"></asp:TextBox>
                        &nbsp;सेवार्थ आयडी
                        <asp:TextBox ID="txtInspOffID" runat="server" Width="180px"></asp:TextBox>
                        &nbsp;व तपासणीची दिनांक<asp:TextBox ID="txtInspDate" runat="server" Width="85px"></asp:TextBox><img id="img1" src="Image/calender.jpg" alt="Text" />
                    </span>
                    <br />
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtInspDate"
                        PopupButtonID="img1" Format="dd/MM/yyyy">
                    </cc1:CalendarExtender><br />
                    <span style="font-size: medium"> प्रमाणे तपासणीसुचित आढळून आलेल्या चुका / तृटी देखील दुरुस्त करणेत आल्या आहेत.</span> 
                </div>
            </center>
            <br />
            <center>
               <center> <div style="text-align:left;width:90%"><span style="font-size: medium;font-family:'Sakal Marathi';text-align:left">  ४ ) हे गाव ऑनलाइन केले पासूनच्या सर्व फेरफार नोंदीचा योग्य अंमल झाला आहे का ?  व खाते दुरुस्ती देखील  योग्यरित्या झाली आहे का ? हे खालील अधिकाऱ्यांनी प्रिंट ७/१२ वर  तपासले  आहे.</span> </div></center>
           <div style="text-align:left">&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lbltotal712disp" runat="server" Text="" Font-Bold="true" Font-Names="Sakal Marathi" Visible="false"></asp:Label> </div>
           <div  ><span style="font-size: medium;font-family:'Sakal Marathi';text-align:center">(प्रपत्र क्रमांक-1)</span></div>
    <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1px" CellSpacing="0" Width="98%">        
        <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" >
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"  Width="4%" Font-Bold="true" Font-Names="Sakal Marathi"> <asp:Label ID="Label10" runat="server" Text="अ. क्र."  Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
             <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Font-Bold="true" Font-Names="Sakal Marathi" ><asp:Label ID="Label20" runat="server" Text="पद"  Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="20%"  Font-Bold="true" Font-Names="Sakal Marathi"><asp:Label ID="Label13" runat="server" Text="नाव"  Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%" Font-Bold="true" Font-Names="Sakal Marathi"><asp:Label ID="Label14" runat="server" Text="सेवार्थ आय. डी."  Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center" Font-Bold="true" Font-Names="Sakal Marathi"><asp:Label ID="Label15" runat="server" Text="% तपासणी  इष्टांक"  Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Font-Bold="true" Font-Names="Sakal Marathi"><asp:Label ID="Label16" runat="server" Text="तपासणी केलेल्या  ७/१२ ची संख्या"  Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Font-Bold="true" Font-Names="Sakal Marathi" ><asp:Label ID="Label17" runat="server" Text="तपासणी प्रमाणपत्र  प्राप्त दिनांक"  Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
        </asp:TableRow>
         <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" >
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%"> <asp:Label ID="Label49" runat="server" Text="१"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="Label50" runat="server" Text="२"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="20%"><asp:Label ID="Label51" runat="server" Text="३"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center" Width="15%"><asp:Label ID="Label52" runat="server" Text="४"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="Label53" runat="server" Text="५"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="Label54" runat="server" Text="६"></asp:Label></asp:TableCell>
             <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="Label22" runat="server" Text="७"></asp:Label></asp:TableCell>
        </asp:TableRow>
         <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" >
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%"> <asp:Label ID="Label18" runat="server" Text="१"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="Label19" runat="server" Text="  ग्राम महसूल अधिकारी  " Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
             <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="lblTalathiNameTable" runat="server" Text="  "></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%"><asp:Label ID="lblTalathiSevarthTable" runat="server" Text="    " Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center"><asp:Label ID="Label21" runat="server" Text="१००%"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtTal712Cnt" runat="server"  Width="90px" onkeypress="return validatenumerics(event)"></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtTalDate" runat="server" Enabled="true" Width="70px"></asp:TextBox><asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Image/calender.jpg" />

                            <cc1:calendarextender ID="CalendarExtender6" runat="server" PopupButtonID="ImageButton5"
                                TargetControlID="txtTalDate" Format="dd/MM/yyyy">
                            </cc1:calendarextender></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" >
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%"> <asp:Label ID="Label24" runat="server" Text="२"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="Label25" runat="server" Text="मंडळ अधिकारी" Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
                         <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="20%"><asp:Label ID="lblCONameTable" runat="server" Text="  " Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%"><asp:Label ID="lblCOSevarthTable" runat="server" Text="   " Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center"><asp:Label ID="Label27" runat="server" Text="३०%"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtCO712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtCODate" runat="server" Enabled="true" Width="70px"></asp:TextBox><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Image/calender.jpg" />

                            <cc1:calendarextender ID="CalendarExtender5" runat="server" PopupButtonID="ImageButton4"
                                TargetControlID="txtCODate" Format="dd/MM/yyyy">
                            </cc1:calendarextender></asp:TableCell>
        </asp:TableRow>
        <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" >
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%"> <asp:Label ID="Label30" runat="server" Text="३"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="Label31" runat="server" Text="नायब तहसिलदार" Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="lbldbaNameTable" runat="server" ></asp:TextBox><%--<asp:Label ID="lbldbaNameTable" runat="server" Text="  " Width="20%" Font-Names="Sakal Marathi"></asp:Label>--%></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%"><asp:TextBox ID="lblDBASevarthtbl" runat="server" ></asp:TextBox><%--<asp:Label ID="lblDBASevarthtbl" runat="server" Text="" Font-Names="Sakal Marathi"></asp:Label>--%></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center"><asp:Label ID="Label33" runat="server" Text="१०%"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtDBA712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtDBADate" runat="server" Enabled="true" Width="70px"></asp:TextBox><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Image/calender.jpg" />

                            <cc1:calendarextender ID="CalendarExtender4" runat="server" PopupButtonID="ImageButton3"
                                TargetControlID="txtDBADate" Format="dd/MM/yyyy">
                            </cc1:calendarextender></asp:TableCell>
        </asp:TableRow>

         <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" >
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%"> <asp:Label ID="Label23" runat="server" Text="४"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="Label26" runat="server" Text="तहसिलदार" Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="lblTahNameTable" runat="server" Text="  " Width="20%" Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%"><asp:Label ID="lblTahSevarthtbl" runat="server" Text="" Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center"><asp:Label ID="Label32" runat="server" Text="५%"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtTah712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtTahDate" runat="server" Enabled="true" Width="70px"></asp:TextBox><asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="~/Image/calender.jpg" />

                            <cc1:calendarextender ID="CalendarExtender7" runat="server" PopupButtonID="ImageButton6"
                                TargetControlID="txtTahDate" Format="dd/MM/yyyy">
                            </cc1:calendarextender></asp:TableCell>
        </asp:TableRow>


        <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" >
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%"> <asp:Label ID="Label36" runat="server" Text="५"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="Label37" runat="server" Text="उपविभागिय अधिकारी" Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="20%"><asp:TextBox ID="txtColNametable" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%"><asp:TextBox ID="txtColSevarthtable" runat="server"></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center"><asp:Label ID="Label39" runat="server" Text="३%"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtCOL712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtColDate" runat="server" Enabled="true" Width="70px"></asp:TextBox><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Image/calender.jpg" />

                            <cc1:calendarextender ID="CalendarExtender3" runat="server" PopupButtonID="ImageButton2"
                                TargetControlID="txtColDate" Format="dd/MM/yyyy">
                            </cc1:calendarextender></asp:TableCell> 
        </asp:TableRow>
        <asp:TableRow runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" >
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="4%"> <asp:Label ID="Label42" runat="server" Text="६"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:Label ID="Label43" runat="server" Text="जिल्हाधिकारी/उपजिल्हाधिकारी" Font-Bold="true"  Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="20%"><asp:TextBox ID="txtSdoNametable" runat="server"></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" Width="15%"><asp:TextBox ID="txtSdoSevarthtable" runat="server" ></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px" HorizontalAlign="Center"><asp:Label ID="Label45" runat="server" Text="१%" Font-Names="Sakal Marathi"></asp:Label></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtSDO712Cnt" runat="server" Width="90px" onkeypress="return validatenumerics(event)"></asp:TextBox></asp:TableCell>
            <asp:TableCell runat="server" BorderColor="Black" ForeColor="Black" BorderWidth="1px"><asp:TextBox ID="txtSdoDate" runat="server" Enabled="true" Width="70px"></asp:TextBox><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Image/calender - Copy.jpg" />

                            <cc1:calendarextender ID="CalendarExtender2" runat="server" PopupButtonID="ImageButton1"
                                TargetControlID="txtSdoDate" Format="dd/MM/yyyy">
                            </cc1:calendarextender></asp:TableCell>
        </asp:TableRow>

        
    </asp:Table>

         <asp:RegularExpressionValidator id="RegularExpressionValidator8" runat="server" CssClass="form_lbl" ControlToValidate="txtTal712Cnt" ErrorMessage="ग्राम महसूल अधिकारी यांनी तपासणी केलेल्या ७/१२ ची संख्या भरा." ValidationExpression="[0-9]+" ValidationGroup="a"></asp:RegularExpressionValidator> 
         <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" CssClass="form_lbl" ControlToValidate="txtCO712Cnt" ErrorMessage="मंडळ अधिकारी यांनी तपासणी केलेल्या ७/१२ ची संख्या भरा." ValidationExpression="[0-9]+" ValidationGroup="a"></asp:RegularExpressionValidator> 
         <asp:RegularExpressionValidator id="RegularExpressionValidator3" runat="server" CssClass="form_lbl" ControlToValidate="txtDBA712Cnt" ErrorMessage="नायब तहसिलदार यांनी तपासणी केलेल्या ७/१२ ची संख्या भरा." ValidationExpression="[0-9]+" ValidationGroup="a"></asp:RegularExpressionValidator> 
         <asp:RegularExpressionValidator id="RegularExpressionValidator4" runat="server" CssClass="form_lbl" ControlToValidate="txtCOL712Cnt" ErrorMessage="उपविभागिय अधिकारी यांनी तपासणी केलेल्या ७/१२ ची संख्या भरा." ValidationExpression="[0-9]+" ValidationGroup="a"></asp:RegularExpressionValidator> 
         <asp:RegularExpressionValidator id="RegularExpressionValidator5" runat="server" CssClass="form_lbl" ControlToValidate="txtSDO712Cnt" ErrorMessage="जिल्हाधिकारी/उपजिल्हाधिकारी यांनी तपासणी केलेल्या ७/१२ ची संख्या भरा." ValidationExpression="[0-9]+" ValidationGroup="a"></asp:RegularExpressionValidator> 
    </center>
            </b>
        </asp:Panel>
    </center>
    <center>
        <div class="row" style="width: 90%; text-align: center">
            <br />
            <asp:Button ID="btnSave" runat="server" Text="साठवा" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_goahed" runat="server" Text="पुढे जा" OnClick="btn_goahed_Click" Visible="False" />
        </div>
    </center>
    <br />
    <asp:Panel ID="pnl2" runat="server" Visible="false" Width="100%">
        <div class="row">
            <center>
                <%--<asp:Label ID="Label3" runat="server" Text="वरील प्रमाणे तपासणीतील 1 ते 24 मुददयांची मी खालील दुरुस्त्या  केल्या  आहेत." Font-Bold="True" Font-Size="X-Large" Style="text-decoration: underline" Font-Names="Sakal Marathi"></asp:Label>--%>
                <h3 style="font-family: 'Sakal Marathi'"><%-- <asp:Label ID="Label2" runat="server" Text="Re-Edit Module मधील काम पूर्ण झाल्याचे  तलाठी  यांचे   स्वयंघोषणापत्र" Font-Names="Sakal Marathi" Style="font-size: x-large; font-weight: 700; color: #3399FF; text-decoration: underline"></asp:Label>--%><%--<asp:Label ID="Label2" runat="server" Text="तपासणी सूची ( १-२४ )  नुसार गावाचे  खाता  रजिष्टर व गावातील सर्व ७/१२ यांच्या दुरुस्त्या तपासणी " Font-Names="Sakal Marathi" Style="font-size: x-large; font-weight: 700; color: #3399FF; text-decoration: underline"></asp:Label>
                    <br /><asp:Label ID="Label1" runat="server" Text=" सूची   क्रमांकानुसार पूर्ण केल्याची  घोषणा  करणे" Font-Names="Sakal Marathi" Style="font-size: x-large; font-weight: 700; color: #3399FF; text-decoration: underline"></asp:Label>--%><span style="font-size: large">तपासणी सूची ( १-२४ ) नुसार गावाचे खाता रजिष्टर व गावातील सर्व ७/१२ यांच्या दुरुस्त्या <br/> तपासणी सूची क्रमांकानुसार पूर्ण केल्याची घोषणा करणे </span></h3>
            </center>
        </div>
        <div class="row">
            <center>
                <asp:GridView ID="gvEWC_Check" runat="server" Visible="true" AutoGenerateColumns="False" OnRowDataBound="RowDataBound"
                    TabIndex="2" CssClass="grid_dark" BackColor="#DAE5F4" Style="text-align: left;" Width="90%">
                    <PagerSettings FirstPageText="First" LastPageText="Last" />
                    <Columns>
                        <asp:TemplateField HeaderText="अनु. क्र." Visible="true">
                            <ItemTemplate>
                                <asp:Label ID="lblwc_code" runat="server" Text='<%# Bind("wc_code") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="तपासणी सूची क्रमांक १ ते २४">
                            <ItemTemplate>
                                <asp:Label ID="lblwc_details" runat="server" Text='<%# Bind("wc_details") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="घोषणा  करणे">
                            <ItemTemplate>
                                <asp:RadioButtonList ID="rblist" runat="server" Font-Names="Sakal Marathi" RepeatDirection="Horizontal">
                                   <%-- <asp:ListItem Value="Y" Selected="True">होय</asp:ListItem>--%>
                                     <asp:ListItem Value="Y">होय</asp:ListItem>
                                    <asp:ListItem Value="N">नाही</asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>

                    </Columns>
                    <FooterStyle CssClass="gridfooter" />
                    <PagerStyle CssClass="gridpager" />
                    <SelectedRowStyle CssClass="gridselectdrow" />
                    <HeaderStyle CssClass="gridheader" />
                    <RowStyle CssClass="gridrow" />
                    <AlternatingRowStyle BackColor="#B8D1F3" />
                </asp:GridView>
                <br />
                <div class="row" style="width: 90%; text-align: left; font-family: 'Sakal Marathi';">
                    <span style="font-size: medium">३ ) ग्राम महसूल अधिकारी यांनी या&nbsp; गावामध्ये असलेल्या एकूण&nbsp; <asp:Label ID="lblTotalror" runat="server" Font-Bold="True" Font-Size="X-Large" Style="text-decoration: underline" Font-Names="Sakal Marathi"></asp:Label> &nbsp; 7/12 पैकी   <asp:TextBox ID="txtCorrectedRor" runat="server" Width="122px" onkeypress="return validatenumerics(event)"></asp:TextBox>  &nbsp; आणि एकूण
                    <asp:Label ID="lblTotal_khata" runat="server" Font-Bold="True" Font-Names="Sakal Marathi" Font-Size="X-Large" Style="text-decoration: underline"></asp:Label>
                    &nbsp;खात्यांपैकी
                    <asp:TextBox ID="txtCorrectedkhata" runat="server" Width="122px" onkeypress="return validatenumerics(event)"></asp:TextBox>
                    &nbsp;खाते क्रंमांक इतके 7/12 RE-EDIT मध्येदुरुस्त केले आहेत. यानंतर या गावात एकही गट नं./ स.नं 7/12 व 8 अ दुरुस्तीसाठी प्रलंबीत नाही.</span><br style="font-size: medium" />
                    <br style="font-size: medium" />
                    </div>
            </center>
        </div>
    </asp:Panel>
    <center>
        <div class="row" style="width: 90%; text-align: center">
            <br />
            <asp:Button ID="btn_save2" runat="server" Text="माहिती साठवा" OnClick="btn_save2_Click" Visible="False" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btn_ShowReport" runat="server" Text=" स्वयंघोषणापत्र पहा"  Visible="False" OnClick="btn_ShowReport_Click"   />&nbsp;</div>
    </center>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

