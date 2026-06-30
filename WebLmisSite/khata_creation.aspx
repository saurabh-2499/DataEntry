<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="khata_creation.aspx.cs" Inherits="khata_creation" Title="नविन  खाते तयार करणे" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <hr />

    <center><asp:Label ID="lblKhataCreation" runat="server" Text="नविन खाते तयार करणे" CssClass="form_lblhead" ForeColor="purple" Font-Underline="true" Visible="false"></asp:Label></center>
    
    <br />
     <div class="column">
    <asp:Label ID="Label1" runat="server" Text="गावातील सध्याचा शेवटचा खाता क्रमांक :-" cssClass="form_lbl" width="300px"  ></asp:Label>
    </div>
    <div class="column">
    <asp:Label ID="lblKhata_no" runat="server" Text="" cssClass="form_lbl"  ></asp:Label>&nbsp;
    </div>
  
     <asp:Button ID="btnKhataCheck" runat="server" Text="खाता मास्टर व एडिट खाता मास्टर टेबल यातील तफावत दुरुस्त करणे."  Width="500px" OnClick="btnKhataCheck_Click" ToolTip="खाता मास्टर व एडिट खाता मास्टर टेबल यातील  तफावत दुरुस्त करण्यासाठी येथे क्लिक करा." />
   
   


    <br />
    <br />


      <div class="column" style="width: 30%">
      <asp:Label ID="Label2" runat="server" Text="खाता प्रकार :-" cssClass="form_lbl"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          
         <asp:DropDownList ID="drpKhataType" runat="server" AutoPostBack="true" 
                            AppendDataBoundItems="True" Visible="true" OnSelectedIndexChanged="drpKhataType_SelectedIndexChanged" Width="285px" CssClass="form_txt_160" >
                          
                        </asp:DropDownList>
    </div>
     
   
   
    <div class="row">
        <asp:Button ID="btn_add_new_row" runat="server" cssClass="form_lbl" Text="नविन खातेदारांची नावे समावेश करा" OnClick="btn_add_new_row_Click" Width="232px" Visible="False"  />
    </div>
    <div class="column" style="width: 10%">
        <asp:Label ID="lblKhataType" runat="server" ForeColor="Purple" Visible="false" ></asp:Label>&nbsp;
    </div>
    
   
    
    <div class="row">
    <center>
    <asp:Label ID="lblmsg" runat="server" ForeColor="red" Text=""  Visible="false"></asp:Label>&nbsp;
    </center>
    </div>

    &nbsp;<div class="row">
 <asp:Panel ID="pnlgdvNewBhogvatdar" runat="server" ScrollBars="Auto" CssClass="bhogvat_grdpnl" Height="300px">
                            <asp:GridView ID="gdvNewBhogvatdar" runat="server" CssClass="grid" BackColor="White"
                                BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False" CellSpacing="3"
                                 OnSelectedIndexChanged="gdvNewBhogvatdar_SelectedIndexChanged1"
                                OnRowEditing="gdvNewBhogvatdar_RowEditing" 
                                TabIndex="4" OnRowDeleting="gdvNewBhogvatdar_RowDeleting">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkselect" runat="server" AutoPostBack="true" CommandName="select"
                                                CssClass="form_lbl" Enabled="true" Text="संपादन"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="6%" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:CommandField ShowDeleteButton="True" DeleteText="नष्ट करा" />
                                    <asp:TemplateField HeaderText="खाता.क्र">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn1" runat="server" Enabled="False" Text='<%# Eval("khata_no") %>'
                                                CssClass="form_lbl"></asp:Label>
                                            <asp:TextBox ID="grd2text1" runat="server" Enabled="false" Text='<%# Eval("khata_no") %>'
                                                Visible="false" CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="7%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                  
                                    <asp:TemplateField HeaderText="पहिले नाव">
                                        <ItemTemplate>

                                         
                                            <br />
                                            <asp:Label ID="lblColumn2" runat="server" Enabled="true" Text='<%# Eval("fname") %>'
                                                CssClass="form_lbl"></asp:Label>
                                            <asp:TextBox ID="grd2text2" runat="server" Text='<%# Eval("fname") %>' Visible="false" MaxLength="50"
                                                CssClass="form_txt_85">
                                            </asp:TextBox>

                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="grd2text2"
                                                                        CssClass="form_lbl" ErrorMessage="पहिले नाव भरा...!!!"  SetFocusOnError="true" ValidationGroup="Valid"></asp:RequiredFieldValidator>&nbsp;
                    
                     

                                            <script type="text/javascript">//<!--
                                                textFieldArr[textFieldArr.length]="grd2text2";devExists = true;
                                                                //--></script>

                                          

                                            <script type="text/javascript">//<!--
	                                                rtDiv = document.getElementById ('rtDiv1');	     
                                                                //--></script>

                                        </ItemTemplate>
                                        <ItemStyle Width="14%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="मधले   नाव  ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn3" runat="server" Enabled="true" Text='<%# Eval("mname") %>'
                                                CssClass="form_lbl"></asp:Label>
                                            <asp:TextBox ID="grd2text3" runat="server" Text='<%# Eval("mname") %>' Visible="false" MaxLength="50"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%"  HorizontalAlign="Center"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="शेवटचे  नाव  ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn4" runat="server" Enabled="true" Text='<%# Eval("lname") %>'
                                                CssClass="form_lbl"></asp:Label>
                                            <asp:TextBox ID="grd2text4" runat="server" Text='<%# Eval("lname") %>' Visible="false" MaxLength="50"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="14%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="टोपण  नाव   ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn5" runat="server" Enabled="true" Text='<%# Eval("topan_name") %>'
                                                CssClass="form_lbl"></asp:Label>
                                            <asp:TextBox ID="grd2text5" runat="server" Text='<%# Eval("topan_name") %>' Visible="false" MaxLength="50"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="13%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="युजर नंबर">
                                        <ItemTemplate>
                                            <asp:Label ID="lblColumn11" runat="server" Text='<%# Eval("usrno") %>'
                                                CssClass="form_lbl" Visible="false"></asp:Label>
                                            <asp:TextBox ID="grd2text11" runat="server" Text='<%# Eval("usrno") %>' Visible="True"
                                                CssClass="form_txt_85"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" Visible="False" ShowHeader="True" HeaderText="मिटवा"
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
<br />
 <center>
        <asp:Button ID="Button1" runat="server" Text="नविन खाता क्रमांक नियुक्त( Assign ) करा" OnClick="Button1_Click" Width="303px" Visible="False" ValidationGroup="Valid" /></center>
    


</asp:Content>

