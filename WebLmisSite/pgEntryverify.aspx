<%@ Page EnableEventValidation="false" Language="C#" MasterPageFile="~/circlemaster.master"
    AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="pgEntryverify.aspx.cs"
    Inherits="pgEntryverify" Title=".::राष्ट्रीय  भूमि अभिलेख आधुनिकीकरण कार्यक्रम,महाराष्ट्र राज्य::."
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%--<%@ OutputCache Location="None" VaryByParam="None" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

       


       <script type="text/javascript" language="javascript">

           function MultipleUserLogin() {
               if (confirm('जर तुम्ही दुसऱ्या मशीनवरून काम करत असाल तर आपल्या या लॉगिन ने पूर्वीचे लॉगिन हे लॉग आउट होईल अन्यथा आपणास पुढे काम करता येणार नाही.\n आपणास तरीही लॉगिन करावयाचे आहे का?')) {
                   document.getElementById("<%=hfMultipleUsers.ClientID %>").value = "true";
                    }
                    else {
                        window.location = window.location.protocol + '//' + window.location.hostname + '/reEdit/pglogout.aspx';
                    }
                }

           function Activex(c) {
               try {

                   var flag = '<%= Session["IsSigned"].ToString() %>';

                if (flag == 'True') {
                    var pk = '<%= Session["pk"].ToString() %>';

                   var newwin = window.open('processing.aspx', '_blank', 'height=150,width=300,top=250,left=530,status=yes,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=no,titlebar=no');

                   var villagecode = document.getElementById("<%=hf_villagecode.ClientID %>").value;
              var sevarth = document.getElementById("<%=hf_sevarth.ClientID %>").value;

                   var dbnm = document.getElementById("<%=hf_dbnm.ClientID %>").value;
                   var schema = document.getElementById("<%=hf_schmanm.ClientID %>").value;

                   var certificte = new ActiveXObject("pdfSigner.Class1");

                   var count = certificte.BulkDataSign89(villagecode, sevarth, pk, dbnm, schema.concat("#", sevarth));

                   newwin.close();

                   if (c == undefined) {
                       window.open("pg712.aspx");
                      // window.open("Report_6D.aspx");
                   }

               }


           }
           catch (e) {
               newwin.close();
               alert("An exception occurred !! Error name: " + e.name + ". Error message: " + e.message);

           }
       }


       function check_version() {

           try {

               var certificte = new ActiveXObject("pdfSigner.Class1");

               var c = certificte.CheckInstallation();

           }
           catch (ex) {
               alert('Please, install new ActiveX controll');
           }



       }


       function verify() {
           try {

               var check = document.getElementById("<%= hfCheckData.ClientID %>").value;

                if (check == '1') {

                    check_version();
                }

                var pk = document.getElementById("<%= hfTalathiPublicKey.ClientID %>").value;
             var signed = document.getElementById("<%= hfRorSignedString.ClientID %>").value;
                var hf_verify = document.getElementById("<%= hf_verify.ClientID %>").value;
                var dbname = '<%= Session["DatabaseName"].ToString() %>';
                var schema = '<%= Session["SchemaName"].ToString() %>';
                var ccode = document.getElementById("<%= hf_villagecode.ClientID %>").value;
                var pin = document.getElementById("<%= hfpin.ClientID %>").value;
                var pin1 = document.getElementById("<%= hfpin1.ClientID %>").value;
                var pin2 = document.getElementById("<%= hfpin2.ClientID %>").value;
                var pin3 = document.getElementById("<%= hfpin3.ClientID %>").value;
                var pin4 = document.getElementById("<%= hfpin4.ClientID %>").value;
                var pin5 = document.getElementById("<%= hfpin5.ClientID %>").value;
                var pin6 = document.getElementById("<%= hfpin6.ClientID %>").value;
                var pin7 = document.getElementById("<%= hfpin7.ClientID %>").value;
                var pin8 = document.getElementById("<%= hfpin8.ClientID %>").value;

                if (signed != '' && pk != '') {
                    var certificte1 = new ActiveXObject("pdfSigner.Class1");
                    var c = certificte1.VerifySign99(ccode, pin, pin1, pin2, pin3, pin4, pin5, pin6, pin7, pin8, pk, signed, dbname, schema);

                    if (c == "1") {

                        if (hf_verify == 'True') {
                            // alert(" तपासलेली माहिती बरोबर आहे. ");     

                            document.getElementById("<%=btn_checklist.ClientID%>").disabled = false;

                               document.getElementById("<%=hfc.ClientID%>").value = "True";
                           }
                           else {
                               // alert(" तपासलेली माहिती चुकिची आहे. ");

                               document.getElementById("<%=btn_checklist.ClientID%>").disabled = true;
                               document.getElementById("<%=btn_certify.ClientID%>").disabled = true;
                               document.getElementById("<%=btn_mutation_cancel.ClientID%>").disabled = true;
                               document.getElementById("<%=hfc.ClientID%>").value = "False";
                           }

                       }
                       else {
                           // alert(" तपासलेली माहिती बरोबर आहे. ");

                           document.getElementById("<%=btn_checklist.ClientID%>").disabled = false;

                           document.getElementById("<%=hfc.ClientID%>").value = "True";

                       }
                   }
                   else {
                       document.getElementById("<%=hfc.ClientID%>").value = "True";
                       // alert(" तपासलेली माहिती बरोबर आहे. ");
                   }


               }
               catch (e) {
                   //document.getElementById("<%=hfc.ClientID%>").value = "False";
                alert("An exception occurred !! Error name: " + e.name + ". Error message: " + e.message);

            }
        }



        function ECT() {
            var txt = "प्रतिबंधीत सर्व्हे / गट क्रमांक";
            var disp_txt;
            var disp_DBA;
            if (document.getElementById("<%=hfRptName.ClientID%>").value != '') {
           disp_txt = txt + "\n " + document.getElementById("<%=hfRptName.ClientID%>").value + " मध्ये त्रुटी असल्यामुळे जमाबंदी आयुक्त कार्यालय यांचे परिपत्रक क्र./रा.भू.अ.आ.का.४/डे.दु.आ./प्र.क्र. १७/२०१४ दि. २३/०७/२०१४ अन्वये हा सर्व्हे क्रमांक इ-फ़ेरफ़ार घेण्यासाठी सध्य: प्रतिबंधीत आहे सबब हा फ़ेरफ़ार या सर्व्हे / गट क्रमांकावर घेता येनार नाही याची नोद घ्यावी !!!\n";
           //alert(txt+"\n "+disp_txt);
       }
       if (document.getElementById("<%=hfDBATool.ClientID%>").value != '') {
                disp_DBA = "\nडेटा दुरुस्ती आज्ञावली एक्सटेंडेड (DBA Tool)  -\n " + document.getElementById("<%=hfDBATool.ClientID%>").value + " मध्ये त्रुटी असल्यामुळे हा सर्व्हे क्रमांक इ-फ़ेरफ़ार घेण्यासाठी सध्य: प्रतिबंधीत आहे सबब हा फ़ेरफ़ार या सर्व्हे / गट क्रमांकावर घेता येणार नाही याची नोंद घ्यावी !!!\n";
           //alert("\nडेटा दुरुस्ती आज्ञावली एक्सटेंडेड (DBA Tool)  -\n "+disp_DBA);
       }
       alert(disp_txt + disp_DBA);
   }

   function ECT_Other() {
       alert(document.getElementById("<%=hfOther.ClientID%>").value + " मध्ये त्रुटी असल्यामुळे हा सर्व्हे क्रमांक इ-फ़ेरफ़ार घेण्यासाठी सध्य: प्रतिबंधीत आहे सबब हा फ़ेरफ़ार या सर्व्हे / गट क्रमांकावर घेता येणार नाही याची नोंद घ्यावी !!!\n");
    }
    </script>


    <script type="text/javascript">
    function CheckOne(obj)
    {
        var grid = obj.parentNode.parentNode.parentNode;
        var inputs = grid.getElementsByTagName("input");
        for(var i=0;i<inputs.length;i++)
        {
            if (inputs[i].type =="checkbox")
            {
                if(obj.checked && inputs[i] != obj && inputs[i].checked)
                {
                    inputs[i].checked = false;
                }
            }
        }        
        

    }
    </script>
<%-- <div class="row">
        <asp:Panel ID="Panel6" runat="server" Width="100%" Height="100px">
            <asp:Label ID="Label6" runat="server" Text="तहसिलदार : " Font-Bold="true"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txtTahsildar" runat="server"></asp:TextBox>&nbsp;&nbsp;
            <asp:Label ID="Label10" runat="server" Text="यांचे कडील " Font-Bold="true"></asp:Label>
            <asp:Label ID="Label7" runat="server" Text=" आदेश क्रमांक :" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="txtAdeshNo" runat="server"></asp:TextBox>&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" Text="प्रमाणे  दिनांक :" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
            <asp:TextBox ID="txtDate" runat="server" Font-Bold="true" AutoPostBack="true"></asp:TextBox>
            <img id="img1" src="Image/calender.jpg" alt="Text" />&nbsp;&nbsp;&nbsp;&nbsp;
            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                PopupButtonID="img1" Format="dd/MM/yyyy" >
            </cc1:CalendarExtender>
            <br /><br />
            <asp:Label ID="Label23" runat="server" Text=" रोजी,मौजे :" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="lblvillagenew" runat="server" Text="lblvilge" ForeColor="Purple"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="Label24" runat="server" Text=" तालुका :" Font-Bold="True"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="lblTahsil" runat="server" Text="" Font-Bold="true" ForeColor="Purple"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label25" runat="server" Text=" येथे ७/१२ वरील चुक दुरुस्त प्रमाणीत करण्याचा आदेश  प्राप्त  झाला आहे ."
                Font-Bold="true"></asp:Label>&nbsp;&nbsp;&nbsp;
            <br />
        </asp:Panel>
    </div>--%>
    <asp:Panel ID="pnl2" runat="server" Visible="false">
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View2" runat="server">
                <div>
                    <table>
                         <div class="clear_br">
           
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Downloads/Standard Operations Procedure.docx" Font-Bold="True" Font-Size="Medium" Visible="False">फेरफार माहिती भरणे व प्रमाणित करणे यांचे SOP</asp:HyperLink>
           
                             <tr>
                                 <td>&nbsp;</td>
                             </tr>
           
        </div>
                       
                    </table>
                </div>
              
                <asp:Panel ID="Panel10" runat="server">                 
                    
                    <center>
                        
                       
                           <asp:Button ID="btn_report_6" runat="server"  Text="फेरफार रजिस्ट्रर"
                            CssClass="form_lbl" OnClick="btn_report_6_Click1"  />
                        <asp:Button ID="mc_notice" runat="server"  CssClass="form_lbl"
                            Text="नमुना ९ (फेरफार कक्ष)" Visible="False" OnClick="mc_notice_Click1"  />
                        
                        <asp:Button ID="btn_Talathi_remark" runat="server" Text="तलाठि शेरा" 
                            CssClass="form_lbl" OnClick="btn_Talathi_remark_Click1" />
                        <asp:Button ID="btn_7_12" runat="server" Text="७/१२ पहा" 
                            CssClass="form_lbl" OnClick="btn_7_12_Click1"  />
                        <asp:Button ID="btn_checklist" runat="server" Text="पडताळणी सुची"
                            CssClass="form_lbl" OnClick="btn_checklist_Click1"  />
                        <asp:Button ID="btn_privew" runat="server" Text="पूर्वावलोकन" 
                            CssClass="form_lbl"  Visible="False" OnClick="btn_privew_Click1" />                    
                        <asp:Button ID="btn_certify" runat="server" Text="फेरफार प्रमाणीत करणे" OnClick="btn_certify_Click"
                            CssClass="form_lbl" />
                        <asp:Button ID="btn_mutation_cancel" runat="server" Text="नामंजुर करणे"  OnClick="btn_mutation_cancel_Click"
                            CssClass="form_lbl" />                       
                    </center>
                    <br />
                        <asp:Label ID="lblVillage" runat="server" Text="गाव निवडा :" Font-Bold="true" CssClass="form_lbl"></asp:Label>
                        <asp:DropDownList ID="ddlVillage" Height="25px" runat="server"  OnSelectedIndexChanged="ddltaluka_SelectedIndexChanged" CssClass="form_lbl" AutoPostBack="true">
                        </asp:DropDownList>  &nbsp;
                        
                        <asp:Label ID="lblFerfarNiwada" runat="server" Text="फेरफार क्रमांक निवडा :" Font-Bold="True" CssClass="form_lbl" Visible="False"></asp:Label>
                        <asp:DropDownList ID="ddlMutationNo" Height="25px" runat="server"   CssClass="form_lbl" AutoPostBack="true" OnSelectedIndexChanged="ddlMutationNo_SelectedIndexChanged" Visible="False">
                        </asp:DropDownList>      
                        <asp:Label ID="lblstr" runat="server" ForeColor="Red"></asp:Label>&nbsp;</center>   
                       <asp:Label ID="Label1" runat="server" Text="पेज साइज :" Font-Bold="true" CssClass="form_lbl"></asp:Label>
                            
                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed" CssClass="form_lbl">
                                 <asp:ListItem Text="2" Value="2" />
                                 <asp:ListItem Text="5" Value="5" />
                                <asp:ListItem Text="10" Value="10" />
                                <asp:ListItem Text="25" Value="25" />
                                <asp:ListItem Text="50" Value="50" />
                            </asp:DropDownList>
                            <br />
                    <br />
                            <asp:Label ID="Label3" runat="server" Text="७/१२ दुरुस्त केलेला फेरफार क्रमांक निवडा  :" Font-Bold="True" CssClass="form_lbl" Visible="False"></asp:Label>
                             <asp:DropDownList ID="ddlmutno" Height="25px" runat="server"  CssClass="form_lbl" AutoPostBack="true"  Width="240px" OnSelectedIndexChanged="ddlmutno_SelectedIndexChanged" Visible="False">
                        </asp:DropDownList>  
                        
                                
                  
                    <asp:Panel ID="Panel3" runat="server" Height="300px" ScrollBars="Vertical">
                        <asp:GridView ID="gdvCertify" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            OnRowCommand="gdvCertify_RowCommand" 
                            BorderWidth="1px" OnRowEditing="gdvCertify_RowEditing" TabIndex="3" CssClass="grid"
                            meta:resourcekey="gdvCertifyResource1" OnRowDataBound="gdvCertify_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="निवडा" meta:resourcekey="TemplateFieldResource1">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"
                                            onclick="CheckOne(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="checklist" meta:resourcekey="TemplateFieldResource1"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnchecklist" runat="server" Text="check" CommandName="select" meta:resourcekey="btnchecklistResource1" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 
                                <asp:TemplateField HeaderText="पूर्वावलोकन" meta:resourcekey="TemplateFieldResource51">
                                                              <ItemTemplate>
                                <asp:Button ID="Preview" runat="server" Text="पूर्वावलोकन" Enabled="false" CommandName="Preview" 
                             CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  />
                            </ItemTemplate>
                        </asp:TemplateField>  
                        
                        
                        <asp:TemplateField HeaderText="पूर्वावलोकन शेरा" meta:resourcekey="TemplateFieldResource51">
                            <ItemTemplate>
                                <asp:Button ID="Preview_certification" runat="server" Text="पूर्वावलोकन शेरा" Enabled="false" CommandName="Preview_certification" 
                             CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  />
                            </ItemTemplate>
                        </asp:TemplateField> 
                                
                                <asp:TemplateField HeaderText="७/१२ पहा" >
                                    <ItemTemplate>
                                        <asp:Button ID="btn712" runat="server" CommandName="select" Text="७/१२" Enabled="false" 
                                              CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="दुरुस्त्या पहा" >
                                    <ItemTemplate>
                                        <asp:Button ID="btnRpt" runat="server" CommandName="oldnewrpt" Text="दुरुस्त्या पहा" Enabled="false"
                                              CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   
                                <asp:TemplateField HeaderText="७/१२ प्रमाणीत करणे" meta:resourcekey="TemplateFieldResource3"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="button1" runat="server" CommandName="select" Text="प्रमाणीत करणे"
                                            CssClass="form_lbl" meta:resourcekey="button1Resource1"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preview" meta:resourcekey="TemplateFieldResource4"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnprv" runat="server" CommandName="select" Text="पूर्वावलोकन" CssClass="form_lbl"
                                            meta:resourcekey="btnprvResource1"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="फ़ेरफ़ार रद्द करणे" meta:resourcekey="TemplateFieldResource5"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnMutCancel" runat="server" CommandName="select" Text="रद्द करा"
                                            CssClass="form_lbl" meta:resourcekey="btnMutCancelResource1"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="तलाठि शेरा" meta:resourcekey="TemplateFieldResource6"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDeal" runat="server" CommandName="select" Text="शेरा" CssClass="form_lbl"
                                            meta:resourcekey="btnDealResource1"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Button" EditText="Change" HeaderText="SellerNameChange"
                                    ShowEditButton="True" Visible="False" meta:resourcekey="CommandFieldResource1" />
                                <asp:TemplateField HeaderText="७/१२ पहा" meta:resourcekey="TemplateFieldResource7"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="button2" runat="server" CommandName="select" Text="७/१२" CssClass="form_lbl"
                                            meta:resourcekey="button2Resource1"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="फ़ेरफ़ार माहिती" meta:resourcekey="TemplateFieldResource8"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btnMuationshow" runat="server" CommandName="select" Text="फ़ेरफ़ार"
                                            CssClass="form_lbl" meta:resourcekey="btnMuationshowResource1"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="फ़ेरफ़ार रजिस्ट्रर(6)" meta:resourcekey="TemplateFieldResource9"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="btn6dshow" runat="server" CommandName="select" Text="6" CssClass="form_lbl"
                                            meta:resourcekey="btn6dshowResource1"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sro बजावलेली नोटिस" meta:resourcekey="TemplateFieldResource10"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="buttonnotices" runat="server" CommandName="select" Text="नोटिस ९"
                                            CssClass="form_lbl" meta:resourcekey="buttonnoticesResource1"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="तलाठि बजावलेली नोटिस" meta:resourcekey="TemplateFieldResource11"
                                    Visible="False">
                                    <ItemTemplate>
                                        <asp:Button ID="butttalthinotices" runat="server" CommandName="select" Text="त.नोटिस ९"
                                            CssClass="form_lbl" meta:resourcekey="butttalthinoticesResource1"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                                <asp:TemplateField HeaderText="फेरफार क्रमांक" meta:resourcekey="TemplateFieldResource14">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn0" runat="server" Text='<%# Eval("mut_no") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumn0Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="फेरफाराचा प्रकार" meta:resourcekey="TemplateFieldResource15">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmut_name" runat="server" Text='<%# Eval("mut_name") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblmut_nameResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="फ़ेरफ़ाराचे type" Visible="False" meta:resourcekey="TemplateFieldResource16">
                                    <ItemTemplate>
                                        <asp:Label ID="lblmut_type" runat="server" Text='<%# Eval("mut_type") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblmut_typeResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="सर्वे क्रमांक" meta:resourcekey="TemplateFieldResource17">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpins" runat="server" Text='<%# Eval("pincase") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblpinsResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="सर्वे क्रमांक" Visible="False" meta:resourcekey="TemplateFieldResource18">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn" runat="server" Text='<%# Eval("pin") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumnResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="फेरफार योग्यरीत्या प्रमाणित झाला" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="फेरफार योग्यरीत्या प्रमाणित झाला नाही" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox3_CheckedChanged" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" meta:resourcekey="TemplateFieldResource19">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn1" runat="server" Text='<%# Eval("pin1") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumn1Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" meta:resourcekey="TemplateFieldResource20">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn2" runat="server" Text='<%# Eval("pin2") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumn2Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" meta:resourcekey="TemplateFieldResource21">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn3" runat="server" Text='<%# Eval("pin3") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumn3Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" meta:resourcekey="TemplateFieldResource22">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn4" runat="server" Text='<%# Eval("pin4") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumn4Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" meta:resourcekey="TemplateFieldResource23">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn5" runat="server" Text='<%# Eval("pin5") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumn5Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" meta:resourcekey="TemplateFieldResource24">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn6" runat="server" Text='<%# Eval("pin6") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumn6Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" meta:resourcekey="TemplateFieldResource25">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn7" runat="server" Text='<%# Eval("pin7") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumn7Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="False" meta:resourcekey="TemplateFieldResource26">
                                    <ItemTemplate>
                                        <asp:Label ID="lblColumn8" runat="server" Text='<%# Eval("pin8") %>' CssClass="form_lbl"
                                            meta:resourcekey="lblColumn8Resource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <%--<asp:TemplateField HeaderText="नोटीस बजावल्याचा दिनांक" meta:resourcekey="TemplateFieldResource17">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoticeDate" runat="server" Text='<%# Eval("notice_issue_date") %>'
                                            CssClass="form_lbl" meta:resourcekey="lblpinsResource1"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                
                                
                            </Columns>
                            <FooterStyle CssClass="gridfooter" />
                            <PagerStyle CssClass="gridpager" />
                            <SelectedRowStyle CssClass="gridselectdrow" BackColor="#FF80FF" BorderColor="#400000" />
                            <HeaderStyle CssClass="gridheader1" />
                            <RowStyle CssClass="gridrow" />
                        </asp:GridView>
                        <br />

                        <asp:Repeater ID="rptPager" runat="server" >
                                <ItemTemplate>
                                    <asp:LinkButton  Font-Size="Large"  ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>' Enabled='<%# Eval("Enabled") %>' OnClick="Page_Changed"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>

                            <br />
                       </asp:Panel>
                    <br />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <center>
                        <asp:Label ID="lbl" runat="server" Visible="False" CssClass="form_lbl" meta:resourcekey="lblResource1"></asp:Label>
                    </center>
                    <center>
                        <asp:Label ID="lbldigimsg" runat="server" CssClass="form_lbl" ForeColor="Black" meta:resourcekey="lblResource1"></asp:Label>&nbsp;</center>
                </asp:Panel>
                <div class="clear_br">
                </div>
                <asp:Panel ID="Panel2" runat="server" meta:resourcekey="Panel2Resource1">
                    <%--<asp:Label ID="lbltext1" runat="server" CssClass="form_b_color" Text="ग्राम महसूल अधिकारी यांच्या कडे  प्राप्त झालेले प्ररंतु  मंजुरीसाठी उपलब्ध नसलेले  फ़ेरफ़ार"></asp:Label><br />
                <asp:GridView ID="gdvPendingMutation" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" BorderWidth="1px" TabIndex="3" CssClass="grid" meta:resourcekey="gdvPendingMutationResource1">
                    <Columns>
                        <asp:TemplateField HeaderText="गाव" meta:resourcekey="TemplateFieldResource27">
                            <ItemTemplate>
                                <asp:Label ID="lblvillage" runat="server" CssClass="form_lbl" Text='<%# Eval("village_name") %>'
                                    meta:resourcekey="lblvillageResource2"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="फ़ेरफ़ार क्र्माक" meta:resourcekey="TemplateFieldResource28">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn0" runat="server" CssClass="form_lbl" Text='<%# Eval("mut_no") %>'
                                    meta:resourcekey="lblColumn0Resource2"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="फ़ेरफ़ाराचे प्रकार" meta:resourcekey="TemplateFieldResource29">
                            <ItemTemplate>
                                <asp:Label ID="lblmut_name" runat="server" CssClass="form_lbl" Text='<%# Eval("mut_name") %>'
                                    meta:resourcekey="lblmut_nameResource2"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="सर्वे क्रमांक" meta:resourcekey="TemplateFieldResource30">
                            <ItemTemplate>
                                <asp:Label ID="lblpins" runat="server" CssClass="form_lbl" Text='<%# Eval("pincase") %>'
                                    meta:resourcekey="lblpinsResource2"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="gridfooter" />
                    <PagerStyle CssClass="gridpager" />
                    <SelectedRowStyle CssClass="gridselectdrow" />
                    <HeaderStyle CssClass="gridheader" />
                    <RowStyle CssClass="gridrow" />
                </asp:GridView>
                <div class="clear">
                    <br />
                </div>--%>
                    <div class="row">
                        <div class="column_womargin">
                            <asp:Label ID="Label5" runat="server" Text="व्यवहाराचा तपशील" CssClass="form_lbl"
                                Visible="False"></asp:Label></div>
                        <asp:TextBox ID="txtdealnew" Enabled="false" runat="server" Height="45px" TextMode="MultiLine"
                            Width="684px" Visible="False"></asp:TextBox>
                    </div>
                    <div class="clear">
                        <br />
                    </div>
                    <center>
                        <asp:HiddenField ID="hfSignature" runat="server" />
                    </center>
                </asp:Panel>
                <%--<asp:Label ID="lbltext1" runat="server" CssClass="form_b_color" Text="ग्राम महसूल अधिकारी यांच्या कडे  प्राप्त झालेले प्ररंतु  मंजुरीसाठी उपलब्ध नसलेले  फ़ेरफ़ार"></asp:Label><br />
                <asp:GridView ID="gdvPendingMutation" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" BorderWidth="1px" TabIndex="3" CssClass="grid" meta:resourcekey="gdvPendingMutationResource1">
                    <Columns>
                        <asp:TemplateField HeaderText="गाव" meta:resourcekey="TemplateFieldResource27">
                            <ItemTemplate>
                                <asp:Label ID="lblvillage" runat="server" CssClass="form_lbl" Text='<%# Eval("village_name") %>'
                                    meta:resourcekey="lblvillageResource2"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="फ़ेरफ़ार क्र्माक" meta:resourcekey="TemplateFieldResource28">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn0" runat="server" CssClass="form_lbl" Text='<%# Eval("mut_no") %>'
                                    meta:resourcekey="lblColumn0Resource2"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="फ़ेरफ़ाराचे प्रकार" meta:resourcekey="TemplateFieldResource29">
                            <ItemTemplate>
                                <asp:Label ID="lblmut_name" runat="server" CssClass="form_lbl" Text='<%# Eval("mut_name") %>'
                                    meta:resourcekey="lblmut_nameResource2"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="सर्वे क्रमांक" meta:resourcekey="TemplateFieldResource30">
                            <ItemTemplate>
                                <asp:Label ID="lblpins" runat="server" CssClass="form_lbl" Text='<%# Eval("pincase") %>' meta:resourcekey="lblpinsResource2"&gt; <FOOTERSTYLE CssClass="gridfooter" /><PAGERSTYLE CssClass="gridpager" /><SELECTEDROWSTYLE CssClass="gridselectdrow" /><HEADERSTYLE CssClass="gridheader" /><ROWSTYLE CssClass="gridrow" /><DIV class="clear"><BR /></DIV>--%&gt; <DIV class="row" __designer:dtid="1407374883553449"><DIV class="column_womargin" __designer:dtid="1407374883553450"><asp:Label id="Label5" runat="server" Text="व्यवहाराचा तपशील" CssClass="form_lbl" __designer:dtid="1407374883553451" Visible="False"></asp:Label></DIV><asp:TextBox id="txtdealnew" runat="server" __designer:dtid="1407374883553452" Visible="False" Width="1011px" Height="45px" TextMode="MultiLine" Enabled="false"></asp:TextBox> </DIV><DIV class="clear" __designer:dtid="1407374883553453"><BR __designer:dtid="1407374883553454" /></DIV><CENTER __designer:dtid="1407374883553455"><asp:HiddenField id="hfSignature" runat="server" __designer:dtid="1407374883553456"></asp:HiddenField> </CENTER></asp:Panel> </asp:View> <asp:View id="viewCircledeal" runat="server" __designer:dtid="1407374883553457"><asp:Panel id="Panel22" runat="server" __designer:dtid="1407374883553458" Width="835px" Height="210px" meta:resourcekey="Panel22Resource1"><DIV class="row" __designer:dtid="1407374883553459"><CENTER __designer:dtid="1407374883553460"><asp:Button id="btnSave" onclick="btnSave_Click" runat="server" Text="साठवा" CssClass="form_lbl" __designer:dtid="1407374883553461" meta:resourcekey="btnSaveResource1"></asp:Button> <asp:Button id="btnExit" onclick="btnDealExit_Click" runat="server" Text="बाहेर पडा" CssClass="form_lbl" __designer:dtid="1407374883553462" meta:resourcekey="btnExitResource1"></asp:Button> </CENTER></DIV><DIV class="clear_br" __designer:dtid="1407374883553463"></DIV><DIV class="row" __designer:dtid="1407374883553464"><DIV class="column_womargin1" __designer:dtid="1407374883553465"><asp:Label id="Label32" runat="server" Text="सर्कल शेरा" CssClass="form_lbl_med" __designer:dtid="1407374883553466" meta:resourcekey="Label32Resource1"></asp:Label> </DIV><asp:TextBox id="txtcricleDeal" runat="server" CssClass="form_txt_query" __designer:dtid="1407374883553467" Width="1012px" meta:resourcekey="txtcricleDealResource1"></asp:TextBox> </DIV></asp:Panel> <%--<marquee style="font-weight: bold; font-size: 13px; color: #006600"></marquee>--%>
            </asp:View>
            <asp:View ID="viewCircledeal" runat="server">
                <center>
                <asp:Panel ID="Panel22" runat="server" Height="210px" Width="835px" meta:resourcekey="Panel22Resource1">
                      <div class="clear_br">
                          <asp:Label ID="lbl_RejectmutNo0" runat="server" CssClass="form_lbl" Text="फेरफार नामंजूर करणे." Font-Bold="True" Font-Names="Sakal Marathi" Font-Size="X-Large" ForeColor="#6600CC"></asp:Label>
                    </div>
                    <div class="clear_br">
                    </div>
                     <div class="row">
                        <center>
                           <asp:Label ID="lbl_RejectmutNo" runat="server" CssClass="form_lbl"  Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Label ID="lbl_RejectServeyNo" runat="server" CssClass="form_lbl"   Text=""></asp:Label>
                        </center>
                    </div>
                     <div class="clear_br">
                    </div>
                    <div class="row">
                        <center>
                            <asp:Button ID="Button3" runat="server" Text="साठवा" OnClick="btnSave_Click" CssClass="form_lbl"
                                meta:resourcekey="btnSaveResource1" />
                            <asp:Button ID="Button4" runat="server" Text="मागे जा" OnClick="btnDealExit_Click"
                                CssClass="form_lbl" meta:resourcekey="btnExitResource1" />
                        </center>
                    </div>
                   
                    <div class="clear_br">
                    </div>
                    <div class="row">
                        <div class="column_womargin1">
                            <asp:Label ID="Label32" runat="server" Text="सर्कल शेरा" CssClass="form_lbl_med"
                                meta:resourcekey="Label32Resource1"></asp:Label>
                        </div>
                        <asp:TextBox ID="txtcricleDeal" runat="server" Height ="70px"  Width="600px" CssClass="form_txt_query" meta:resourcekey="txtcricleDealResource1"></asp:TextBox>
                    </div>
                </asp:Panel>
                    </center>
                <%--<marquee style="font-weight: bold; font-size: 13px; color: #006600"></marquee>--%>
            </asp:View>
        </asp:MultiView>
    </asp:Panel>
    <div class="clear_br">
    </div>
    <asp:MultiView ID="MultiView2" runat="server">
        <asp:View ID="ViewDeal" runat="server">
            <asp:Panel ID="Panel1" runat="server" Height="210px" Width="835px" meta:resourcekey="Panel1Resource1">
                <div class="row">
                    <center>
                        <asp:Button ID="btnDealExit" runat="server" Text="बाहेर पडा" OnClick="btnDealExit_Click"
                            TabIndex="5" CssClass="form_lbl" meta:resourcekey="btnDealExitResource1" />
                    </center>
                </div>
                <div class="clear_br">
                </div>
                <div class="row">
                    <div class="column_womargin1">
                        <asp:Label ID="Label2" runat="server" Text="तलाठि शेरा" CssClass="form_lbl_med" meta:resourcekey="Label2Resource1"></asp:Label>
                    </div>
                    <asp:TextBox ID="txtDeal" runat="server" TabIndex="4" CssClass="form_txt_query" meta:resourcekey="txtDealResource1"></asp:TextBox>
                </div>
            </asp:Panel>
            <%-- <marquee style="font-weight: bold; font-size: 13px; color: #006600">!!!!! युजरने व्हेरीफ़ै बटन वापरुन नंतर सर्टीफ़ै बटन क्लीक करावे !!!!!</marquee>--%>
        </asp:View>

     

    </asp:MultiView>
    
    
    
      <div id="divpopup" class="ontop_cirlce">
                                                <div style="background-color: white; position: fixed; left: 25%; top: 42%; min-height: 10%;
                                                    min-width: 25%; border: 2px solid orange; ">
                                                    <center>
                                                           <table>
            <tr>
                <td style="width: 630px">
                </td>
                <td style="width: 129px">
                </td>
            </tr>
            <tr>
                <td style="color:black;">
                    १) पूर्वावलोकन नुसार फेरफार प्रमाणित केला व फेरफाराचा अंमल ७/१२ वर योग्य रीत्या
                    झाला.
                </td>
                <td   >
                    <asp:RadioButton ID="rdo_yes" runat="server" ForeColor="white" AutoPostBack="True"  OnCheckedChanged="rdo_yes_CheckedChanged" /></td>
               
            </tr>                                                            
                                                            
            <tr>
                <td style="color:black;">
                    २) पूर्वावलोकन नुसार फेरफार प्रमाणित केला व फेरफाराचा अंमल ७/१२ वर योग्य रीत्या
                    झाला नाही.</td>
                <td >
                    <asp:RadioButton ID="rdo_no" runat="server" ForeColor="orange" AutoPostBack="True" OnCheckedChanged="rdo_no_CheckedChanged" /></td>
            </tr>
        </table>
                                                    </center>
                                                </div>
                                            </div>

            <asp:HiddenField ID="hf1" runat="server" />    
    <asp:HiddenField ID="hfservarthpk" runat="server" />   
    <asp:HiddenField ID="hfRorSignedString" runat="server" />
    <asp:HiddenField ID="hfRorSigningString" runat="server" />
    <asp:HiddenField ID="hfRorCertifiedString" runat="server" />    
    <asp:HiddenField ID="hf_villagecode" runat="server" />
    <asp:HiddenField ID="hf_sevarth" runat="server" />
    <asp:HiddenField ID="hf_dbnm" runat="server" />
    <asp:HiddenField ID="hf_schmanm" runat="server" />
    <asp:HiddenField ID="hfc" runat="server" Value="" />
    <asp:HiddenField ID="hfCheckData" runat="server" />
    <asp:HiddenField ID="hf_verify" runat="server" />   
    <asp:HiddenField ID="hfRptName" runat="server" />
    <asp:HiddenField ID="hfOther" runat="server" />
    <asp:HiddenField ID="hfDBATool" runat="server" />

            <asp:HiddenField ID="hfpin" runat="server" />
            <asp:HiddenField ID="hfpin1" runat="server" />
            <asp:HiddenField ID="hfpin2" runat="server" />
            <asp:HiddenField ID="hfpin3" runat="server" />
            <asp:HiddenField ID="hfpin4" runat="server" />
            <asp:HiddenField ID="hfpin5" runat="server" />
            <asp:HiddenField ID="hfpin6" runat="server" />
            <asp:HiddenField ID="hfpin7" runat="server" />
            <asp:HiddenField ID="hfpin8" runat="server" />
            <asp:HiddenField ID="hfTalathiPublicKey" runat="server" />
             <asp:HiddenField ID="hfconcatnatestr" runat="server" />          
            <asp:HiddenField ID="hfSignDataString" runat="server" />
            <asp:HiddenField ID="hfMultipleUsers" runat="server" />
             </ContentTemplate>
        <Triggers>
           
        </Triggers>
    </asp:UpdatePanel>


     <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" runat="server" >
                    <ProgressTemplate>                                               
                   <div id="blur" >
               
                         <asp:Panel ID="PanelProgress" runat="server" CssClass="PanelPopUp" Style="left: 42%;  position: absolute; top: 35%" Width="300" Height="100">
                             <br />
                                         <img src="Image/process.gif"  width="225px" height="175px"/>
                         <br />
                         <br />
                        <br />
                        
                    </asp:Panel> 
                       </div>                          
                    </ProgressTemplate>
                </asp:UpdateProgress> 
    
</asp:Content>
