<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgFerfarNoCreation.aspx.cs" Inherits="pgFerfarNoCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="clear_br"></div>
    <div class="all_pnl">
    <div class="row">
        <br />

        

        <div class="column_s_wid10">
        <asp:Label ID="lblVillage" runat="server" Text="गाव :-" CssClass="form_lbl"></asp:Label></div>
         <div class="column_18perwomargin">
            <asp:Label ID="lblVillageDisp" runat="server" ForeColor="Purple" CssClass="form_txt_160"></asp:Label>
            </div>
         <div class="column_s_wid10">
        <asp:Label ID="lblCurrentFerfarNo" runat="server" Text="चालु फेरफार क्रमांक :-" CssClass="form_lbl"></asp:Label></div>
             <div class="column_18perwomargin">
             <asp:Label ID="lblCurrentFerfarNoDisp" runat="server" ForeColor="Purple" CssClass="form_txt_160"></asp:Label><br />
             </div>
         <div class="column_s_wid10">
        <asp:Label ID="lblNextFerfarNo" runat="server" Text="नविन फेरफार क्रमांक :-" CssClass="form_lbl"></asp:Label></div>
             <div class="column_18perwomargin">
             <asp:Label ID="lblNextFerfarNoDisp" runat="server" ForeColor="Purple" CssClass="form_txt_160"></asp:Label><br />
             </div>
            </div>
          <div class="clear_br"></div>
   
    
   
         </div>
    <div class="clear_br"></div>
    <br />
    <br />
    <div class="clear_br"></div>
     <div>

       
           <center>
               <asp:Button ID="btnFerfarCreation" runat="server" Text="फेरफार क्रमांक तयार करणे" OnClick="btnFerfarCreation_Click" />
               &nbsp;&nbsp;<asp:Button ID="btnFerfarVI" runat="server" Text="फेरफार रेजीस्टर" OnClick="btnFerfarVI_Click"  />
             </center>
       </div>
    
</asp:Content>


