<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true"
    CodeFile="Form12.aspx.cs" Inherits="Form12" Title="पीक पाहणी" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<div class="row">
    </div>--%>

    <script type="text/javascript" src="stylescript/InputCheck.js">
    </script>

    <div>
        <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged">
            <asp:View ID="View1" runat="server">
                <br />
                <div id="page_header">
                    <asp:Label ID="Label7" runat="server" Text="गाव नमुना १२ मध्ये दुरुस्ती"></asp:Label>&nbsp;
                </div>
                <center>
                    <asp:Button ID="btnmodify" runat="server" Text="दुरुस्ती" OnClick="btnmodify_Click" Visible="False" />
                    <asp:Button ID="btndelete" runat="server" Text="Delete" OnClick="btndelete_Click"
                        Visible="False" />
                    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btncancel_Click"
                        Visible="False" />
                    <asp:Button ID="btnsave" runat="server" Text="साठवा" OnClick="btnsave_Click" />
                    <asp:Button ID="btn_nextyear_survey" runat="server" Text="पुढील वर्षाचा डाटा कॉपी" Visible="False" OnClick="btn_nextyear_survey_Click" />
                    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" Visible="False" />
                    <asp:Button ID="btnreport" runat="server" Text="७/१२ पाहणे" OnClick="btnreport_Click1"
                        Visible="True" />&nbsp;<asp:Button ID="btn_year" runat="server" OnClick="btn_year_Click"
                            Text="वर्षाचा डाटा" />
                    <asp:Button ID="Button2" runat="server" Text="अक्शरि " Visible="False" />
                    <asp:Button ID="btnremark" runat="server" Text="शेरा भरणे " OnClick="btnremark_Click" />
                </center>
                <center>
                    <asp:Label ID="lblerrmsg" runat="server" ForeColor="Red" Visible="False" Width="343px"></asp:Label>
                </center>
                <center>
                    <asp:Label ID="lblareaerr" runat="server" ForeColor="Red" Visible="False" Width="343px"></asp:Label>&nbsp;</center>
                <%--  --minakshi--   <div class="column_10per_womargin">
                    <asp:Label ID="Label27" runat="server" CssClass="form_lbl" Text="गाव" Visible="False"></asp:Label></div>
                <asp:DropDownList ID="drdnvillage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdnvillage_SelectedIndexChanged"
                    CssClass="form_drp" Visible="False">
                </asp:DropDownList>--%>



                <%--minakshi-- <div class="column_50per_womargin" style=" padding-left: 50px; border-right: #3e73ac 1px solid;" >
                
                <div class="row">
                <asp:Label ID="lblnumericpin" runat="server" CssClass="form_lbl" Text="सर्व्हे.क्र.:" ></asp:Label>
                
                    <asp:DropDownList ID="drpsurvey" runat="server"  Width="192px" OnSelectedIndexChanged="drpsurvey_SelectedIndexChanged" AutoPostBack="True" CssClass="form_drp_97">
                    </asp:DropDownList>
                <asp:Button ID="btnchangeSurvey" runat="server" OnClick="btnchangeSurvey_Click" Text="दुरुस्ती सर्व्हे क्र."
                    CssClass="form_lbl" Enabled="False" />
                </div>
                <div class="clear">
                <br />
                </div>--%>

                <div class="row">
                    <asp:Label ID="lblupvibhag" runat="server" Text="उपविभाग :" CssClass="form_lbl" Visible="false"></asp:Label>
                    <asp:TextBox ID="tbnumericpin" runat="server" ValidationGroup="vg1" ReadOnly="True"
                        CssClass="form_txt" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="tbpin" runat="server" ReadOnly="True" ValidationGroup="vg1" Visible="False"
                        CssClass="form_txt_20"></asp:TextBox>
                    <asp:TextBox ID="tbpin1" runat="server" ReadOnly="True" Visible="False" CssClass="form_txt_20"></asp:TextBox>
                    <asp:TextBox ID="tbpin2" runat="server" ReadOnly="True" Visible="False" CssClass="form_txt_20"></asp:TextBox>
                    <asp:TextBox ID="tbpin3" runat="server" ReadOnly="True" Visible="False" CssClass="form_txt_20"></asp:TextBox>
                    <asp:TextBox ID="tbpin4" runat="server" ReadOnly="True" Visible="False" CssClass="form_txt_20"></asp:TextBox>
                    <asp:TextBox ID="tbpin5" runat="server" ReadOnly="True" Visible="False" CssClass="form_txt_20"></asp:TextBox>
                    <asp:TextBox ID="tbpin6" runat="server" ReadOnly="True" Visible="False" CssClass="form_txt_20"></asp:TextBox>
                    <asp:TextBox ID="tbpin7" runat="server" ReadOnly="True" Visible="False" CssClass="form_txt_20"></asp:TextBox>
                    <asp:TextBox ID="tbpin8" runat="server" ReadOnly="True" Visible="False" CssClass="form_txt_20"></asp:TextBox>&nbsp;
                    <asp:Button ID="btn_nextYear_data" runat="server" OnClick="btn_nextYear_data_Click" Text="पुढील वर्षाचा डाटा कॊपी "
                        CssClass="form_lbl" Visible="False" /><br />
                </div>
                <div class="clear">
                    <br />
                </div>
                <div class="row">
                    <center>
                        <asp:Label ID="lblnumericpin" runat="server" CssClass="form_lbl" Text="सर्व्हे.क्र.:"></asp:Label>
                        <asp:Label ID="lbsurveyno" runat="server" CssClass="form_lbl"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label12" runat="server" Text="हंगाम :" CssClass="form_lbl"></asp:Label>
                        <asp:DropDownList ID="drdnseason" runat="server" AutoPostBack="True" CausesValidation="True" OnSelectedIndexChanged="drdnseason_SelectedIndexChanged" ValidationGroup="vg2"
                            CssClass="form_drptxt_160">
                        </asp:DropDownList>
                        &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;                           
                     <asp:Label ID="Label11" runat="server" Text="वर्ष :" Font-Names="Sakal Marathi" CssClass="form_lbl"></asp:Label>
                        <asp:TextBox ID="tbyear" runat="server" MaxLength="4" ValidationGroup="vg2" Font-Names="Sakal Marathi"
                            CssClass="form_txt_96" OnTextChanged="tbyear_TextChanged" Width="100px"></asp:TextBox>

                    </center>
                </div>
                <div class="row">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" SelectText="निवडा" />
                            <asp:TemplateField HeaderText="वर्ष">
                                <ItemTemplate>
                                    &nbsp;<asp:Label ID="lblYear" runat="server" Font-Names="Sakal Marathi" Text='<%# Bind("years") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
                <asp:Button ID="btnsearch" runat="server" Text="Search" ValidationGroup="vg1" Enabled="False"
                    Visible="False" />
                &nbsp;

    <div class="row">
        <div class="column_10per_womargin">
            <asp:Label ID="lblsurveyno" runat="server" Text="सर्व्हे क्रमांक निवडा" Visible="False"
                CssClass="form_lbl"></asp:Label>
        </div>
        <div class="column_10per_womargin">
            <asp:DropDownList ID="drdnsurvvey" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drdnsurvvey_SelectedIndexChanged"
                ValidationGroup="vg2" Visible="False" CssClass="form_drp">
            </asp:DropDownList>
        </div>

    </div>
                <%--   <div class="clear">
                    <br />
                </div>--%>
                <div class="row">
                    <div class="column_s1">
                        <%--<asp:Label ID="Label28" runat="server" Text="वर्ष" CssClass="form_txt_100"></asp:Label>--%>
                    </div>
                    <div class="column_20per_womargin">
                        <%-- <asp:TextBox ID="tbyear" runat="server" MaxLength="4" ValidationGroup="vg2" ReadOnly="false"
                            CssClass="form_txt_85"></asp:TextBox>
                             <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                            <Columns>
                                <asp:CommandField  ShowSelectButton="True" SelectText="निवडा" />
                                <asp:TemplateField HeaderText="वर्ष">
                                <ItemTemplate >
                                    &nbsp;<asp:Label ID="lblYear" runat="server"  Text='<%# Bind("years") %>'></asp:Label>
                                </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>--%>
                    </div>
                    <div class="column">
                    </div>
                    <div class="column">
                        <%--<asp:Label ID="lblhangam" runat="server" Text="हंगाम :" CssClass="form_txt_100"></asp:Label>--%>
                    </div>
                    <div class="inner_column1">
                        <%--<asp:DropDownList ID="drdnseason" runat="server" AutoPostBack="True" CausesValidation="True"
                            Enabled="False" OnSelectedIndexChanged="drdnseason_SelectedIndexChanged" ValidationGroup="vg2"
                            CssClass="form_drp_86">
                        </asp:DropDownList>--%>
                    </div>
                </div>
                <br />
                <asp:Label ID="lblerrormsg1" runat="server" CssClass="LabelMessage" Visible="False"></asp:Label>
                <br />
                <div class="clear line_top">
                    <br />
                </div>
                <asp:Panel ID="Panel5" runat="server" CssClass="mar_left">
                    <asp:Label ID="Label22" runat="server" Text="मिश्र पिकाखालील जमीन" CssClass="form_b_color"></asp:Label>
                    <br />
                    <br />
                    <div class="column_s_wid10">
                        <asp:Label ID="Label10" runat="server" Text="सात वरील क्षेत्र" CssClass="form_lbl"></asp:Label>
                    </div>
                    <div class="column_20per_womargin">
                        <asp:TextBox ID="tb7area" runat="server" ReadOnly="True" CssClass="form_txt_85"></asp:TextBox>
                    </div>
                    <div class="column">
                        <asp:Label ID="Label71" runat="server" Text="हंगाम" CssClass="form_lbl"></asp:Label>
                    </div>
                    <div class="column_10">
                        <asp:TextBox ID="tbseason2" runat="server" Enabled="False" ReadOnly="True" CssClass="form_txt_85"></asp:TextBox>
                    </div>
                    <div class="clear">
                        <hr />
                    </div>

                    <div class="row">
                        <table style="width: 100%">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <asp:Label ID="Label1" runat="server" Text="घटक पिके व क्षेत्र" ForeColor="#FF8000" CssClass="form_lbl"></asp:Label></td>

                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td colspan="2">
                                    <asp:Label ID="Label6" runat="server" Text="निर्भळ पिकाखालील" ForeColor="#FF8000" CssClass="form_lbl"></asp:Label></td>

                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="height: 35px; width: 10%">
                                    <asp:Label ID="Label23" runat="server" Text="मिश्रनाचा सन्केत" CssClass="form_lbl"></asp:Label></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:Label ID="Label72" runat="server" Text="जल सिंचित " CssClass="form_lbl"></asp:Label></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:Label ID="Label73" runat="server" Text="अजल सिंचित " CssClass="form_lbl"></asp:Label></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:Label ID="Label2" runat="server" Text="पिकाचे नाव" CssClass="form_lbl"></asp:Label></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:Label ID="Label3" runat="server" Text="जल  सिंचित " CssClass="form_lbl"> </asp:Label></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:Label ID="Label5" runat="server" Text="अजल सिंचित " CssClass="form_lbl"></asp:Label></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:Label ID="Label8" runat="server" Text="पिकाचे नाव" CssClass="form_lbl"></asp:Label></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:Label ID="Label9" runat="server" Text="जल सिंचित " CssClass="form_lbl"></asp:Label>
                                </td>
                                <td style="height: 35px; width: 10%">
                                    <asp:Label ID="Label80" runat="server" Text="अजल सिंचित " CssClass="form_lbl"></asp:Label></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:Label ID="Label83" runat="server" Text="शेरा" CssClass="form_lbl" Visible="False"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="height: 35px; width: 10%">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form_txt_85"></asp:TextBox></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:TextBox ID="tbmixirr" runat="server" CssClass="form_txt_85"></asp:TextBox></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:TextBox ID="tbmixunirr" runat="server" CssClass="form_txt_85"></asp:TextBox></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:DropDownList ID="drdncrop" runat="server" OnSelectedIndexChanged="drdncrop_SelectedIndexChanged" CssClass="form_txt_160">
                                    </asp:DropDownList></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:TextBox ID="tbconstirr" runat="server" CssClass="form_txt_85"></asp:TextBox></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:TextBox ID="tbconstunirr" runat="server" CssClass="form_txt_85"></asp:TextBox></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:DropDownList ID="drdncrop1" runat="server" CssClass="form_txt_160"></asp:DropDownList></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:TextBox ID="tbpureirr" runat="server" CssClass="form_txt_85"></asp:TextBox></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:TextBox ID="tbpureunirr" runat="server" CssClass="form_txt_85"></asp:TextBox></td>
                                <td style="height: 35px; width: 10%">
                                    <asp:TextBox ID="tbremark" runat="server" CssClass="form_txt_85" Visible="False"></asp:TextBox></td>
                            </tr>
                        </table>
                        <br />
                    </div>
                    <div class="clear">
                        <br />
                    </div>
                    <div class="row">
                        <div style="width: 11%; float: left">
                            <asp:Button ID="btnenter" runat="server" OnClick="btnenter_Click" Text="समावेश" ValidationGroup="vgcrop" Enabled="false" />
                        </div>
                        <div style="width: 11%; float: left">
                            <asp:Label ID="lblcrop" runat="server" CssClass="LabelMessage" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                    <div class="clear">
                        <hr />
                    </div>

                    <table style="width: 429px">
                        <tr>
                            <td colspan="3" style="height: 14px; text-align: center">
                                <asp:Label ID="lbllandinfo" runat="server" CssClass="form_lbl" Style="text-align: center"></asp:Label></td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:Panel ID="Panel7" runat="server" CssClass="itar_grdpnl" ScrollBars="Both" Visible="false">
                            <br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting"
                                CssClass="grid" CellSpacing="2" CellPadding="4">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" SelectText="निवडा" />
                                    <asp:CommandField ShowDeleteButton="True" DeleteText="नष्ट करा" />
                                    <asp:BoundField DataField="Season" HeaderText="Season" Visible="False" />
                                    <asp:BoundField DataField="मिश्रजलसिन्चित" HeaderText="मिश्रजलसिंचित" />
                                    <asp:BoundField DataField="मिश्रअजलसिन्चित" HeaderText="मिश्रअजलसिंचित" />
                                    <asp:BoundField DataField="पिकाचेनाव" HeaderText="घटकपिकाचेनाव" />
                                    <asp:BoundField DataField="जलसिन्चित" HeaderText="घटकजलसिंचित" />
                                    <asp:BoundField DataField="अजलसिन्चित" HeaderText="घटकअजलसिंचित" />
                                    <asp:BoundField DataField="निर्भळपिकाचेनाव" HeaderText="निर्भळपिकाचेनाव" />
                                    <asp:BoundField DataField="निर्भळजलसिन्चित" HeaderText="निर्भळजलसिंचित" />
                                    <asp:BoundField DataField="निर्भळअजलसिन्चित" HeaderText="निर्भळअजलसिंचित" />
                                    <asp:BoundField DataField="गाव" HeaderText="गाव" Visible="False" />
                                    <asp:BoundField DataField="भुमाक्र" HeaderText="भुमाक्र" Visible="False" />
                                    <asp:BoundField DataField="pin" HeaderText="pin" Visible="False" />
                                    <asp:BoundField DataField="pin1" HeaderText="pin1" Visible="False" />
                                    <asp:BoundField DataField="pin2" HeaderText="pin2" Visible="False" />
                                    <asp:BoundField DataField="pin3" HeaderText="pin3" Visible="False" />
                                    <asp:BoundField DataField="pin4" HeaderText="pin4" Visible="False" />
                                    <asp:BoundField DataField="pin5" HeaderText="pin5" Visible="False" />
                                    <asp:BoundField DataField="pin6" HeaderText="pin6" Visible="False" />
                                    <asp:BoundField DataField="pin7" HeaderText="pin7" Visible="False" />
                                    <asp:BoundField DataField="pin8" HeaderText="pin8" Visible="False" />
                                    <asp:BoundField DataField="वर्ष" HeaderText="वर्ष" Visible="true" />
                                    <asp:BoundField DataField="seasoncode" HeaderText="seasoncode" Visible="False" />
                                    <asp:BoundField DataField="शेरा" HeaderText="शेरा" Visible="False" />
                                    <asp:BoundField DataField="constcropcode" HeaderText="constcropcode" Visible="False" />
                                    <asp:BoundField DataField="purecropcode" HeaderText="purecropcode" Visible="False" />
                                    <asp:BoundField DataField="constpurecrop" HeaderText="constpurecrop" Visible="False" />
                                </Columns>
                                <FooterStyle CssClass="gridfooter" />
                                <PagerStyle CssClass="gridpager" />
                                <SelectedRowStyle CssClass="gridselectdrow" />
                                <HeaderStyle CssClass="gridheader" />
                                <RowStyle CssClass="gridrow" />
                            </asp:GridView>
                            <br />
                            <br />
                        </asp:Panel>
                        <br />
                        <center>
                            <asp:Label ID="lblerror" runat="server" CssClass="LabelMessage"></asp:Label>

                        </center>
                    </asp:Panel>
                    <center>
                        <asp:Button ID="btnadd" runat="server" OnClick="btnadd_Click" Text="ADD" Visible="False"
                            Width="76px" />&nbsp;
                        <%--<asp:Button ID="btnback" runat="server" Text="Back" OnClick="btnback_Click" />&nbsp;--%>
                    </center>
                    <br />
                    <div class="row">
                        <div class="column_popup">
                            <asp:Label ID="lblland" runat="server" Text="लागवडीसाठी उपलब्ध नसलेली जमीन" CssClass="form_b_color"></asp:Label>
                            <div class="clear">
                            </div>
                            <div class="column_20per_womargin">
                                <asp:Label ID="lblhangam2" runat="server" Text="हंगाम :" CssClass="form_lbl"></asp:Label><br />
                                <asp:TextBox ID="tbulandhangam" runat="server" ReadOnly="True" CssClass="form_txt_85"></asp:TextBox>
                            </div>
                            <div class="column_womargin">
                                <asp:Label ID="lblarea" runat="server" Text="क्षेत्र :" CssClass="form_lbl"></asp:Label><br />
                                <asp:TextBox ID="tbulandarea" runat="server" CssClass="form_txt_85"></asp:TextBox>
                            </div>
                            <div class="column_womargin">
                                <asp:Label ID="lblswarup" runat="server" Text="स्वरुप :" CssClass="form_lbl"></asp:Label><br />
                                <asp:DropDownList ID="drdnulandname" runat="server" CssClass="form_drp_minwidth">
                                </asp:DropDownList>
                            </div>
                            <div class="clear">
                                <br />
                            </div>
                            <asp:Button ID="btnaddland" runat="server" OnClick="btnaddland_Click" Text="समावेश"
                                ValidationGroup="vgland" Enabled="false" />
                            <br />
                            <asp:Panel ID="Panel4" runat="server" ScrollBars="Both" CssClass="itar_grdpnl" Visible="False">
                                <asp:GridView ID="gvland" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvland_SelectedIndexChanged"
                                    OnRowDeleting="gvland_RowDeleting" CssClass="grid">
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" SelectText="निवडा" />
                                        <asp:CommandField ShowDeleteButton="True" DeleteText="नष्ट करा" />
                                        <asp:BoundField DataField="हंगाम" HeaderText="हंगाम" Visible="False" />
                                        <asp:BoundField DataField="क्षेत्र" HeaderText="क्षेत्र" />
                                        <asp:BoundField DataField="स्वरुप" HeaderText="स्वरुप" />
                                        <asp:BoundField DataField="landcode" HeaderText="landcode" Visible="false" />
                                        <asp:BoundField DataField="pin" HeaderText="pin" Visible="False" />
                                        <asp:BoundField DataField="pin1" HeaderText="pin1" Visible="False" />
                                        <asp:BoundField DataField="pin2" HeaderText="pin2" Visible="False" />
                                        <asp:BoundField DataField="pin3" HeaderText="pin3" Visible="False" />
                                        <asp:BoundField DataField="pin4" HeaderText="pin4" Visible="False" />
                                        <asp:BoundField DataField="pin5" HeaderText="pin5" Visible="False" />
                                        <asp:BoundField DataField="pin6" HeaderText="pin6" Visible="False" />
                                        <asp:BoundField DataField="pin7" HeaderText="pin7" Visible="False" />
                                        <asp:BoundField DataField="pin8" HeaderText="pin8" Visible="False" />
                                        <asp:BoundField DataField="वर्ष" HeaderText="वर्ष" Visible="False" />
                                        <asp:BoundField DataField="Season" HeaderText="Season" Visible="False" />
                                        <asp:BoundField DataField="गाव" HeaderText="गाव" Visible="False" />
                                    </Columns>
                                    <FooterStyle CssClass="gridfooter" />
                                    <PagerStyle CssClass="gridpager" />
                                    <SelectedRowStyle CssClass="gridselectdrow" />
                                    <HeaderStyle CssClass="gridheader" />
                                    <RowStyle CssClass="gridrow" />
                                </asp:GridView>
                            </asp:Panel>
                        </div>
                        <div class="inner_column1">
                            <center>
                                <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Small" Text="जल सिंचनाचे साधन"
                                    ForeColor="#FF8000" CssClass="form_lbl"></asp:Label>
                                <br />
                                <asp:Panel ID="Panel6" runat="server" Height="150px" ScrollBars="Vertical" Width="140px">
                                    <asp:CheckBoxList ID="chbirrsource" runat="server" Height="190px" Width="100%" CssClass="form_lbl">
                                    </asp:CheckBoxList>
                                    <br />
                                </asp:Panel>
                            </center>
                        </div>
                        </div>
                    <div class="clear">
                    </div>
                </asp:Panel>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="clear"></div>
                <br />
                <div class="page_header">
                    <asp:Label ID="Label4" runat="server" Text="दुरुस्तीसाठी सर्व्हे क्रमांक मार्क करणे"></asp:Label>

                </div>

                <div class="row">
                    <div class="column_10per_womargin">
                        &nbsp;
                    </div>
                    <div class="column_womargin">
                        <asp:LinkButton ID="lbtnallsurvey" runat="server" OnClick="lbtnallsurvey_Click" Visible="False">सर्व सर्व्हे क्र. मार्क करणे</asp:LinkButton>
                    </div>
                    <asp:Label ID="lblmsgnew" runat="server" ForeColor="Red" Visible="true" Width="343px"></asp:Label>
                </div>
                <div class="row">
                    <div class="inner_column3">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="LabelEng" Font-Bold="False"
                            OnClick="LinkButton1_Click" Visible="False">Undo Check</asp:LinkButton>&nbsp;
                    </div>
                </div>
                <div class="clear">
                    &nbsp;
                </div>
                <asp:Panel ID="Panel2" runat="server" Height="250px" ScrollBars="Both">
                    <asp:GridView ID="gvmarksurvey" runat="server" AutoGenerateColumns="False" CssClass="grid"
                        ShowFooter="True" Height="180px">
                        <RowStyle CssClass="gridrow" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkCheck" runat="server" Checked='<%# Bind("chk") %>'
                                        OnCheckedChanged="chkCheck_CheckedChanged" ToolTip="<%# ((GridViewRow)Container).RowIndex %>" />
                                </ItemTemplate>
                                <HeaderStyle Width="3%" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="pins" HeaderText="सर्व्हे क्र.">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle CssClass="gridfooter" />
                        <SelectedRowStyle CssClass="gridselectdrow" />
                        <HeaderStyle CssClass="gridheader" />
                    </asp:GridView>
                </asp:Panel>
                <center>
                    <asp:Label ID="lblerrsurvey" runat="server" CssClass="form_lbl_red_s"></asp:Label>
                    <br />
                    <asp:Button ID="btnbackchngsurvey" runat="server" Text="Back" OnClick="btnbackchngsurvey_Click"
                        Visible="False" />
                    <asp:Button ID="btnchange" runat="server" Font-Bold="False" OnClick="btnchange_Click"
                        Text="दुरुस्ती" />
                </center>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div class="page_header">
                    <asp:Label ID="Label19" runat="server" Text="दुरुस्तीसाठी मार्क केलेले सर्व्हे न."></asp:Label>
                </div>
                <asp:Panel ID="Panel3" runat="server" Height="145px" ScrollBars="Both" Width="800px">
                    <asp:GridView ID="gvchangesurvey" runat="server" AutoGenerateColumns="False" ShowFooter="True"
                        CssClass="grid" OnSelectedIndexChanged="gvchangesurvey_SelectedIndexChanged">
                        <PagerSettings FirstPageText="First" LastPageText="Last" />
                        <Columns>
                            <asp:CommandField HeaderStyle-Width="75px" ShowSelectButton="True" SelectText="निवडा" />
                            <asp:BoundField DataField="pin" HeaderText="सर्व्हे क्र." />
                            <asp:BoundField DataField="pin1" HeaderText=" " />
                            <asp:BoundField DataField="pin2" HeaderText=" " />
                            <asp:BoundField DataField="pin3" HeaderText=" " />
                            <asp:BoundField DataField="pin4" HeaderText=" " />
                            <asp:BoundField DataField="pin5" HeaderText=" " />
                            <asp:BoundField DataField="pin6" HeaderText=" " />
                            <asp:BoundField DataField="pin7" HeaderText=" " />
                            <asp:BoundField DataField="pin8" HeaderText=" " />
                        </Columns>
                        <FooterStyle CssClass="gridfooter" />
                        <PagerStyle CssClass="gridpager" />
                        <SelectedRowStyle CssClass="gridselectdrow" />
                        <HeaderStyle CssClass="gridheader" />
                        <RowStyle CssClass="gridrow" />
                    </asp:GridView>
                </asp:Panel>
                <center>
                    <input id="Button1" onclick="self.close()" type="button" value="Close Me" /></center>
            </asp:View>
            <asp:View ID="View4" runat="server">
                <asp:Panel ID="Panel8" runat="server">
                    <div align="center">
                        <span>
                            <asp:Button ID="Button4" runat="server" Text="मागे जा" OnClick="Button4_Click" />
                        </span><span>
                            <asp:Button ID="btnaddremark" runat="server" Text="समावेश " OnClick="btnaddremark_Click" />
                        </span><span>
                            <asp:Button ID="btneditremark" runat="server" Text="संपादन" OnClick="btneditremark_Click" />
                        </span><span>
                            <asp:Button ID="Button3" runat="server" Text="नष्ट करा " OnClick="Button3_Click" />
                        </span>
                    </div>
                    <div class="row">
                        <br />
                        <br />
                        <span>
                            <asp:Label ID="lblsurvey" runat="server" Text="सर्वे क्रमांक :" Visible="False" CssClass="form_lbl"></asp:Label>
                        </span><span>
                            <asp:TextBox ID="txtsurvey" runat="server" Visible="False"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfcsurvey" ControlToValidate="txtsurvey" runat="server"
                                ErrorMessage="सर्वे क्रमांक भरा " ValidationGroup="surveyselect"></asp:RequiredFieldValidator>
                        </span><span>
                            <asp:Button ID="btnsurveysearch" runat="server" Text="सर्वे क्रमांक शोधा" OnClick="btnsurveysearch_Click"
                                Visible="False" ValidationGroup="surveyselect" />
                        </span><span>
                            <asp:Button ID="btnaksharisurvey" runat="server" Text="अक्षरी सर्वे क्रमांक शोधा"
                                Visible="False" />
                        </span><span>
                            <asp:Label ID="lblhdselectedsurvey" runat="server" Text="निवडलेला सर्वे क्रमांक "
                                Visible="False"></asp:Label>
                        </span><span>
                            <asp:Label ID="lblselectedsurvey" runat="server" Visible="False"></asp:Label>
                        </span>
                        <asp:Panel ID="pnlremark" runat="server" ScrollBars="Vertical" Height="150px" Visible="false">
                            <center>
                                <asp:GridView ID="grdsurveysearch" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="grdsurveysearch_SelectedIndexChanging" CssClass="grid">
                                    <Columns>
                                        <asp:CommandField SelectText="निवडा " ShowSelectButton="True" />
                                        <asp:CommandField />
                                        <asp:TemplateField HeaderText="सर्वे क्रमांक">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin" runat="server" Text='<%# Eval("pin") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="उपविभाग १">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin1" runat="server" Text='<%# Eval("pin1") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="उपविभाग २">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin2" runat="server" Text='<%# Eval("pin2") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="उपविभाग ३">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin3" runat="server" Text='<%# Eval("pin3") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="उपविभाग ४">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin4" runat="server" Text='<%# Eval("pin4") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="उपविभाग ५">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin5" runat="server" Text='<%# Eval("pin5") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="उपविभाग ६">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin6" runat="server" Text='<%# Eval("pin6") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="उपविभाग ७">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin7" runat="server" Text='<%# Eval("pin7") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="उपविभाग ८">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpin8" runat="server" Text='<%# Eval("pin8") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </center>
                        </asp:Panel>
                        </div>
                       <br />
                        <div class="row">
                           
                                <asp:Label ID="lblyear" runat="server" Text="वर्ष " Visible="false" CssClass="form_lbl"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         
                                <asp:TextBox ID="txtyear" runat="server" MaxLength="4" Visible="false"></asp:TextBox>
                                <asp:Label ID="lblyearerr" runat="server" Visible="False"></asp:Label>
                                <asp:RequiredFieldValidator ID="rfcyear" runat="server" ErrorMessage="वर्ष भरा" ControlToValidate="txtyear"
                                    ValidationGroup="information"></asp:RequiredFieldValidator>
                         
                                <asp:Label ID="lblcroptype" runat="server" Text="७/१२ वर किती प्रकारची झाडे आहेत ?"
                                    Visible="False" CssClass="form_lbl"></asp:Label>
                        
                                <asp:TextBox ID="txtcroptype" runat="server" Visible="False"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfccroptype" ControlToValidate="txtcroptype" runat="server"
                                    ErrorMessage="किती प्रकारची झाडे आहेत ती संख्या भरा. " ValidationGroup="information"></asp:RequiredFieldValidator>
                        </div>                   
                        <br />                   
                    </div>
                    <div align="center">
                        <asp:Button ID="btninfo" runat="server" OnClick="btninfo_Click" ValidationGroup="information"
                            Visible="false" />
                    </div>
                    <br />
                    <center>
                        <asp:GridView ID="grdremark" runat="server" CssClass="grid"
                            AutoGenerateColumns="False" OnRowDataBound="grdremark_RowDataBound" OnRowDeleted="grdremark_RowDeleted"
                            OnRowDeleting="grdremark_RowDeleting" Width="80%">
                            <Columns>
                                <asp:CommandField DeleteText="नष्ट करा " HeaderText="नष्ट करा " ShowDeleteButton="True"
                                    ShowHeader="True" />
                                <asp:TemplateField HeaderText="झाडाचे नाव  " ItemStyle-Width="30%">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlcrop" runat="server" Width="80%">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="झाडांची एकूण संख्या " ItemStyle-Width="50%" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtcnt" runat="server" Width="70px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvcnt" ControlToValidate="txtcnt" runat="server"
                                            ErrorMessage="झाडांची एकूण संख्या भरा " ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="शेरा ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtremark" runat="server" Height="55px" TextMode="MultiLine" Width="390px"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="rfvremark" ControlToValidate="txtremark" runat="server"
                    ErrorMessage="शेरा भरा" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            </Columns>

                            <SelectedRowStyle CssClass="gridselectdrow" />
                            <HeaderStyle CssClass="gridheader" />
                            <RowStyle CssClass="gridrow" />
                        </asp:GridView>
                    </center>
                    <br />
                    <asp:GridView ID="GridView3" runat="server" CssClass="grid"
                        AutoGenerateColumns="False" OnRowDataBound="GridView3_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="नष्ट करण्यासाठी निवडा" Visible="False" ItemStyle-Width="30%">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkselect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="झाडाचे नाव  " ItemStyle-Width="30%">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlcrop" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="झाडांची एकूण संख्या " ItemStyle-Width="30%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtcnt" runat="server" Text='<%# Eval("crop_count") %>' Width="70px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvcnt" ControlToValidate="txtcnt" runat="server"
                                        ErrorMessage="झाडांची एकूण संख्या भरा " ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="शेरा ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtremark" runat="server" Text='<%# Eval("remark") %>' Height="55px" TextMode="MultiLine" Width="390px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvremark" ControlToValidate="txtremark" runat="server"
                    ErrorMessage="शेरा भरा" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                        <SelectedRowStyle CssClass="gridselectdrow" />
                        <HeaderStyle CssClass="gridheader" />
                        <RowStyle CssClass="gridrow" />
                    </asp:GridView>
                    <br />

                    <div align="center">
                        <asp:Button ID="btnremarksave" runat="server" Text="साठवा" OnClick="btnremarksave_Click"
                            ValidationGroup="save" Visible="false" />
                    </div>
                </asp:Panel>
            </asp:View>
        </asp:MultiView>
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="hfschema" runat="server" />
        <asp:HiddenField ID="hfdatabase" runat="server" />
        <asp:HiddenField ID="hfyearNew" runat="server" />
        <asp:HiddenField ID="hfccode" runat="server" />
        <asp:HiddenField ID="hfseason" runat="server" />
        <asp:HiddenField ID="hfoperation" runat="server" />
        <asp:RequiredFieldValidator ID="rfvtbulandarea" runat="server" ControlToValidate="tbulandarea"
            ErrorMessage="Enter area" ValidationGroup="vgland" Display="none"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvdrdnulandname" runat="server" ControlToValidate="drdnulandname"
            ErrorMessage="स्वरुप निवडा" InitialValue="--निवडा--" ValidationGroup="vgland"
            Display="none"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvtbmixirr" runat="server" ControlToValidate="tbmixirr"
            ErrorMessage="Enter Number" ValidationGroup="vgcrop" Display="none"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvtbmixunirr" runat="server" ControlToValidate="tbmixunirr"
            ErrorMessage="Enter Number" ValidationGroup="vgcrop" Display="none"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvtbconstirr" runat="server" ControlToValidate="tbconstirr"
            ErrorMessage="Enter Number" ValidationGroup="vgcrop" Display="none"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvtbconstunirr" runat="server" ControlToValidate="tbconstunirr"
            ErrorMessage="Enter Number" ValidationGroup="vgcrop" Display="none"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvtbpureirr" runat="server" ControlToValidate="tbpureirr"
            ErrorMessage="Enter Number" ValidationGroup="vgcrop" Display="none"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvtbpureunirr" runat="server" ControlToValidate="tbpureunirr"
            ErrorMessage="Enter number" ValidationGroup="vgcrop" Display="none"></asp:RequiredFieldValidator>
        <cc1:ValidatorCalloutExtender ID="vce_rfvtbulandarea" runat="server" TargetControlID="rfvtbulandarea">
        </cc1:ValidatorCalloutExtender>
        <cc1:ValidatorCalloutExtender ID="vce_rfvdrdnulandname" runat="server" TargetControlID="rfvdrdnulandname">
        </cc1:ValidatorCalloutExtender>
        <cc1:ValidatorCalloutExtender ID="vce_rfvtbmixirr" runat="server" TargetControlID="rfvtbmixirr">
        </cc1:ValidatorCalloutExtender>
        <cc1:ValidatorCalloutExtender ID="vce_rfvtbmixunirr" runat="server" TargetControlID="rfvtbmixunirr">
        </cc1:ValidatorCalloutExtender>

        <cc1:ValidatorCalloutExtender ID="vce_rfvtbconstirr" runat="server" TargetControlID="rfvtbconstirr">
        </cc1:ValidatorCalloutExtender>
        <cc1:ValidatorCalloutExtender ID="vce_rfvtbconstunirr" runat="server" TargetControlID="rfvtbconstunirr">
        </cc1:ValidatorCalloutExtender>

        <cc1:ValidatorCalloutExtender ID="vce_rfvtbpureirr" runat="server" TargetControlID="rfvtbpureirr">
        </cc1:ValidatorCalloutExtender>
        <cc1:ValidatorCalloutExtender ID="vce_rfvtbpureunirr" runat="server" TargetControlID="rfvtbpureunirr">
        </cc1:ValidatorCalloutExtender>
    </div>
</asp:Content>
