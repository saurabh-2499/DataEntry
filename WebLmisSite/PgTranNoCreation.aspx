<%@ Page Title="तहसिलदारांचा दुरुस्त्या मान्येतेचा आदेश व परिशिष्ट ब तयार करणे" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="PgTranNoCreation.aspx.cs" Inherits="PgTranNoCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="clear_br"></div>
    <div class="all_pnl" style="height:50px">
    <div class="row">
        <br />

        

        <div class="column_s_wid10">
        <asp:Label ID="lblVillage" runat="server" Text="गाव :-" CssClass="form_lbl"></asp:Label></div>
         <div class="column_18perwomargin">
            <asp:Label ID="lblVillageDisp" runat="server" ForeColor="Purple" CssClass="form_txt_160"></asp:Label>
            </div>
         <div class="column_18perwomargin">
        <asp:Label ID="lblCurrentFerfarNo" runat="server" Text=" परिशिष्ट ब क्रमांक:-" CssClass="form_lbl"></asp:Label></div>
             <div class="column_s_wid10">
             <asp:Label ID="lblCurrentTransNoDisp" runat="server" ForeColor="Purple" CssClass="form_lbl"></asp:Label><br />
             </div>       
            </div>    
     </div>
    <div class="clear_br"></div>
     <br />
    <div class="clear_br"></div>
     <div>       
           <center>
        <asp:Button ID="btnTransNoCreation" runat="server" Text="परिशिष्ट ब तयार करणे" OnClick="btnTransNoCreation_Click"  />  
             </center>
       </div>
</asp:Content>

