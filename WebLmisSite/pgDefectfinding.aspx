<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true"
    CodeFile="pgDefectfinding.aspx.cs" Inherits="pgDefectfinding" Title="..::National Land Record Modernization Programme::." %>
<%@ OutputCache Location="None" VaryByParam ="None" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page_header">
        <asp:Label ID="Label1" runat="server" Text="Defect Find Program" CssClass="form_lbl"></asp:Label>
    </div>
    <div class="clear_br">
    </div>
    <div class="row">
        <center>
            <asp:Button ID="btnprev" runat="server" OnClick="btnprev_Click" Text="मुखपृष्ठ"
                CssClass="form_lbl" />
            <asp:Button ID="btnlogout" runat="server" OnClick="btnlogout_Click" Text="बाहेर पडा"
                CssClass="form_lbl" />
        </center>
    </div>
    <div class="clear_br">
    </div>
    <div class="row">
        <div class="column">
            <asp:Label ID="Label2" runat="server" Text="गाव निवडा" CssClass="form_lbl"></asp:Label>
        </div>
        <div class="column_womargin">
            <asp:DropDownList ID="ddlvillage" runat="server" CssClass="form_drp">
            </asp:DropDownList>
        </div>
        <div class="column_s">
            <asp:Button ID="btnSelect" runat="server" Text="निवडा" OnClick="btnSelect_Click"
                CssClass="form_lbl" />
        </div>
    </div>
    <div class="clear_br">
    </div>
    <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" CssClass="bs_pnl">
        <asp:GridView ID="gvKhataOwners" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanging="gvKhataOwners_SelectedIndexChanging"
            ShowFooter="True" OnRowDeleting="gvKhataOwners_RowDeleting" CssClass="grid">
            <PagerSettings FirstPageText="First" LastPageText="Last" />
            <Columns>
                <asp:CommandField HeaderText="निवडा" ShowSelectButton="True" SelectText="निवडा" />
                <asp:CommandField DeleteText="सुधारित करा" HeaderText="सुधारित करा" ShowDeleteButton="True"
                    SelectText="निवडा" UpdateText="सुधारित करा" />
                <asp:TemplateField HeaderText="खाता क्र.">
                    <ItemTemplate>
                        <asp:Label ID="lblkhata_no" runat="server" Text='<%# Bind("khata_no") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पहिले नांव">
                    <ItemTemplate>
                        <asp:Label ID="lblfname" runat="server" Text='<%# Bind("fname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="मधले नांव">
                    <ItemTemplate>
                        <asp:Label ID="lblmname" runat="server" Text='<%# Bind("mname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="आडनांव">
                    <ItemTemplate>
                        <asp:Label ID="lbllname" runat="server" Text='<%# Bind("lname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="टोपण नांव ">
                    <ItemTemplate>
                        <asp:Label ID="lbltopan_name" runat="server" Text='<%# Bind("topan_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="युजर नं.">
                    <ItemTemplate>
                        <asp:TextBox ID="txthoderuser" runat="server" Text='<%# Bind("usrno") %>'></asp:TextBox>
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
        <asp:Label ID="lblMsgholder" runat="server" Text="Label" CssClass="form_lbl_red_s"></asp:Label>
    </center>
    <div class="clear_br">
    </div>
    <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" CssClass="bs_pnl">
        <asp:GridView ID="dgvpin" runat="server" AutoGenerateColumns="False" ShowFooter="True"
            OnSelectedIndexChanging="dgvpin_SelectedIndexChanging" CssClass="grid">
            <PagerSettings FirstPageText="First" LastPageText="Last" />
            <Columns>
                <asp:CommandField HeaderText="सुधारित करा" SelectText="सुधारित करा" ShowSelectButton="True" />
                <asp:TemplateField HeaderText="खाता नं.">
                    <ItemTemplate>
                        <asp:Label ID="lblpinkhata" runat="server" Text='<%# Bind("khata_no") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पिन">
                    <ItemTemplate>
                        <asp:Label ID="lblpin" runat="server" Text='<%# Bind("pin") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पिन१">
                    <ItemTemplate>
                        <asp:Label ID="lblpin1" runat="server" Text='<%# Bind("pin1") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पिन२">
                    <ItemTemplate>
                        <asp:Label ID="lblpin2" runat="server" Text='<%# Bind("pin2") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पिन३">
                    <ItemTemplate>
                        <asp:Label ID="lblpin3" runat="server" Text='<%# Bind("pin3") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पिन४">
                    <ItemTemplate>
                        <asp:Label ID="lblpin4" runat="server" Text='<%# Bind("pin4") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पिन५">
                    <ItemTemplate>
                        <asp:Label ID="lblpin5" runat="server" Text='<%# Bind("pin5") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पिन६">
                    <ItemTemplate>
                        <asp:Label ID="lblpin6" runat="server" Text='<%# Bind("pin6") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पिन७">
                    <ItemTemplate>
                        <asp:Label ID="lblpin7" runat="server" Text='<%# Bind("pin7") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पिन८">
                    <ItemTemplate>
                        <asp:Label ID="lblpin8" runat="server" Text='<%# Bind("pin8") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="पहिले नांव">
                    <ItemTemplate>
                        <asp:Label ID="lblfname" runat="server" Text='<%# Bind("fname") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="मधले नांव">
                    <ItemTemplate>
                        <asp:Label ID="lblmname" runat="server" Text='<%# Bind("mname") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="आडनांव">
                    <ItemTemplate>
                        <asp:Label ID="lbllname" runat="server" Text='<%# Bind("lname") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="युजर नं.">
                    <ItemTemplate>
                        <asp:TextBox ID="txtusrno" runat="server" Text='<%# Bind("usrno") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="खाता प्रकार">
                    <ItemTemplate>
                        <asp:Label ID="lblkhatype" runat="server" Text='<%# Bind("khata_type") %>' CssClass="form_lbl"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="क्षेत्र">
                    <ItemTemplate>
                        <asp:Label ID="lbltotal_area_h" runat="server" Text='<%# Bind("total_area_h") %>'
                            CssClass="form_lbl"></asp:Label>
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
        <asp:Label ID="lblkhata" runat="server" Visible="False" CssClass="form_lbl_red_s"></asp:Label>
    </center>
    <div class="clear_br">
    </div>
    
    
    <asp:HiddenField ID="hfVillageName" runat="server" />
    <asp:HiddenField ID="hfCcode" runat="server" />
</asp:Content>
