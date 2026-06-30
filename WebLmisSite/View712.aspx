<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/InnerMaster.master" MaintainScrollPositionOnPostback="true" CodeFile="View712.aspx.cs" Inherits="View712" Title="७/१२ पाहुन सर्व्हे/गट क्रमांक कन्फर्म किंवा एडिट साठी मार्क करणे" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server" >
     <marquee direction="left" scrollamount="5" loop="true" width="100%"  onmouseover="this.stop();" onmouseout="this.start();" >
<asp:Label id="Label4" runat="server" Text="जे सर्व्हे / गट क्रमांक डाटा एन्ट्री मॉड्युल द्वारे एडिट  करुन( दुरुस्त्या करुन ) प्रमाणित  अथवा  कन्फर्म  ( कायम ) केले आहेत  तेच  सर्व्हे / गट क्रमांक    डाटा एन्ट्री मॉड्युल  द्वारे  दुरुस्त्या करण्यास उपलब्ध  होतील ." ForeColor="Blue" Font-Bold="True" Font-Names="Sakal Marathi"></asp:Label></marquee>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

     <script type="text/javascript">
         function confirm_survey()
         {
             if (document.getElementById('ctl00_ContentPlaceHolder1_txtsurvey').value =="")
             {
                 alert(' सर्व्हे क्रमांक भरा ');
                 return false;
             }

         }

         </script>


  


   
    <script type="text/javascript" language="javascript">


        function Activex() {
            try {

                var certificte = new ActiveXObject("pdfSigner.Class1");

                var c = certificte.certificate_token();
                var pk = '<%= Session["pk"].ToString() %>';


                 if (c.split('#')[0] == pk) {

                     var flag = '<%= Session["IsSigned"].ToString() %>';

                        if (flag == 'True') {


                            var cnc = document.getElementById("<%= hfconcatnatestr.ClientID %>").value;
                            var sevarth = '<%= Session["pk"].ToString() %>';
                            var cert = new ActiveXObject("pdfSigner.Class1");

                            document.getElementById("<%= hfSignDataString.ClientID %>").value = cert.SignDataString(cnc, sevarth);
               }

               alert("कृपया, \"७/१२ पहा\" या बटनावर पुन्हा क्लिक करा.");
           }
           else {
               alert('You are using wrong digital signature..');
           }
       }
       catch (ex) {

       }
   }


        </script>

    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />

<body>
   
        <div>
            <br />
            <asp:Panel ID="Panel8" runat="server" CssClass="all_pnl95">
           
                <div class="row">
                    <asp:Label ID="Label1" runat="server" Text="टिप : हस्तलिखीत/LIMIS ७/१२ पाहुन सर्व्हे/गट क्रमांकाचा नविन ७/१२ तयार करणे  ( दुरुस्ती करणे ) करण्यासाठी पुर्ण ७/१२ खाली र्स्कोल करा." ForeColor="Red"></asp:Label><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text= " ७/१२ वर नविन ७/१२ ( दुरुस्ती करणे ) हे बटण गाव नमुना बारा संपल्यानंतर आहेत. " ForeColor="blue"></asp:Label><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label   ID="Label5" runat="server" Text= " आपण निवडलेला  ७/१२ हा कृषिक आहे किंवा अकृषिक आहे याची खात्री करा. ७/१२  कृषिक आहे किंवा अकृषिक आहे याला अनुसरुन  क्षेत्र व क्षेत्राचे एकक योग्य आहे याची खात्री करा." ForeColor="#CC3300" ></asp:Label> 
                </div>
                     <div class="row">
                <br /> <center>
                    <div class="column_margin5p ">
                        <asp:Label ID="Label24" runat="server" CssClass="form_lbl">गाव : </asp:Label>
                    </div>
                    <div class="column_10per_womargin">
                        <asp:Label ID="lblVillageName" runat="server" Text=""></asp:Label>
                        <br /><br />   
                    </div>
                  
                   
                    <div class="column_10per_womargin" style="text-align:left;">
                        
                        
                        <asp:Label ID="Label3" runat="server" CssClass="form_lbl" Text="सर्व्हे क्र. :"></asp:Label>
                    </div>
                    <div class="column_10per_womargin">
                        <asp:TextBox ID="txtsurvey" runat="server" TabIndex="18" CssClass="form_txt" MaxLength="20" CausesValidation="True" Width="90px"
                            ToolTip="कृपया सर्व्हे क्रमांक टाका"></asp:TextBox>
                    </div>
                    <div class="column_adjs">
                        <asp:Button ID="btnSearchSurveyNo" Text="सर्व्हे क्र. शोधा" runat="server" OnClick="btnSearchSurveyNo_Click" ValidationGroup="Valid"
                            ToolTip="सर्वे क्र. शोधा" TabIndex="19" CssClass="form_lbl" /></div>

                     <div class="column_adjs">
                          <asp:Button ID="Button2" runat="server" CssClass="form_lbl" OnClick="Button2_Click" OnClientClick="return confirm_survey();"
                            TabIndex="19" Text=" अक्षरी सर्व्हे क्र. शोधा" ToolTip=" अक्षरी सर्व्हे क्र. शोधा" ValidationGroup="Valid" Width="162px" /></div>
                        <br/><br />
                  
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="form_lbl" Height="1px" RepeatDirection="Horizontal" Width="500px" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" Visible="False">
                            <asp:ListItem Value="0" Selected="True">सर्व वर्षांचा पीक पहाणीचा डाटा</asp:ListItem>
                            <asp:ListItem  Value="1">फक्त शेवटच्या वर्षाचा पीक पहाणीचा डाटा</asp:ListItem>
                        </asp:RadioButtonList>

                       </center>
                   
                    <div class="column_womargin">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtsurvey"
                            ErrorMessage="enter number only" ValidationExpression="[0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]"
                            ValidationGroup="a" Visible="False" CssClass="form_lbl"></asp:RegularExpressionValidator>
                    </div>
                    <div class="column_a">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmutno"
                            ErrorMessage="enter number only" ValidationExpression="[0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5]"
                            CssClass="form_lbl" ValidationGroup="a" Visible="False"></asp:RegularExpressionValidator>
                        &nbsp;</div>
                </div>
                <div class="clear_br">
                    <br />
                </div>
                      <center>
                     <asp:Panel ID="panelpins" runat="server" BorderWidth="1px" Width="700px"  ><div class="clear_br">
                    <br /></div>  <asp:Label id="lblsub" runat="server" CssClass="form_lbl">उपविभाग :</asp:Label>&nbsp;
                        <asp:TextBox ID="txtpin1" runat="server" TabIndex="5" Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                    
                        <asp:TextBox ID="txtpin2" runat="server" TabIndex="5" Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                    
                        <asp:TextBox ID="txtpin3" runat="server" TabIndex="5"  Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                    
                        <asp:TextBox ID="txtpin4" runat="server" TabIndex="5"  Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                   
               
                
                        <asp:TextBox ID="txtpin5" runat="server" TabIndex="5"  Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                   
                        <asp:TextBox ID="txtpin6" runat="server" TabIndex="5"  Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                   
                        <asp:TextBox ID="txtpin7" runat="server" TabIndex="5"  Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox>
                   
                        <asp:TextBox ID="txtpin8" runat="server" TabIndex="5" Enabled="False" Width="50px"
                            ToolTip="कृपया सर्वे क्रमांक टाका"></asp:TextBox><div class="clear_br">
                    <br />
                </div>
                   </asp:Panel></center>
                <br />
                <asp:GridView ID="gdvSurveySearch" runat="server" AutoGenerateColumns="False" CellPadding="1"
                    CssClass="grid" OnSelectedIndexChanging="gdvSurveySearch_SelectedIndexChanging"
                    BorderStyle="None" BorderWidth="1px" CellSpacing="3">
                    <FooterStyle />
                    <RowStyle />
                    <PagerStyle VerticalAlign="Top" />
                    <SelectedRowStyle />
                    <HeaderStyle VerticalAlign="Top" />
                    <Columns>
                        <asp:TemplateField HeaderText="७/१२ पाहणे">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkselect" runat="server" CommandName="Select" Enabled="true"
                                    CssClass="form_lbl" Text="७/१२ पहा"></asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="सर्व्हे क्रमांक">
                            <ItemTemplate>
                                <asp:Label ID="lblColumn" runat="server" Enabled="true" Text='<%# Eval("pin") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn1" runat="server" Enabled="true" Text='<%# Eval("pin1") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("pin2") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("pin3") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("pin4") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("pin5") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn6" runat="server" Enabled="true" Text='<%# Eval("pin6") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn7" runat="server" Enabled="true" Text='<%# Eval("pin7") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="lblColumn8" runat="server" Enabled="true" Text='<%# Eval("pin8") %>'
                                    CssClass="form_lbl"></asp:Label>
                            </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle CssClass="gridfooter" />
                    <PagerStyle CssClass="gridpager" />
                    <SelectedRowStyle CssClass="gridselectdrow" />
                    <HeaderStyle CssClass="gridheader" />
                    <RowStyle CssClass="gridrow" />
                </asp:GridView>
                <br />
                        <center> <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label></center>
                         <center>
                         </center>
                    
                    <br />
                    
            </asp:Panel>
        </div>
    <asp:HiddenField ID="hfconcatnatestr" runat="server" />          
            <asp:HiddenField ID="hfSignDataString" runat="server" />
     <asp:HiddenField ID="hfreedit" runat="server" />
</body>
</html></asp:Content>
