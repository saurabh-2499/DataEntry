<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="pgD1RevertRequestByTalathi.aspx.cs" Inherits="pgD1RevertRequestByTalathi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <hr />
  <asp:Panel  runat="server"  ID="pnl1">
    
     <div class="row" >
       <center>
           <br />
           <table style="width: 50%">
               <tr>
                   <td style="text-align: left">
                       <asp:Label ID="Label1" runat="server" Font-Names="Sakal Marathi" text="गावाचे नाव : " Font-Bold="True" Font-Size="Large"></asp:Label>
                   </td>
                   <td style="text-align: left">
                       <asp:Label ID="lblVillName" runat="server" Font-Names="Sakal Marathi"  Font-Bold="True" ForeColor="#cc3300"></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td style="text-align: left">
                       <asp:Label ID="Label4" runat="server" Font-Names="Sakal Marathi" text="घोषणापत्र 1 (Declaration - I ) केल्याची दिनांक: " Font-Bold="True" Font-Size="Large"></asp:Label>
                   </td>
                   <td style="text-align: left">
                       <asp:Label ID="lblD1Date" runat="server" Font-Names="Sakal Marathi" Font-Bold="True"  ForeColor="#cc3300" ></asp:Label>
                   </td>
               </tr>
               <tr>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
               <tr>
                   <td style="text-align: left">
                       <asp:Label ID="Label5" runat="server" Font-Names="Sakal Marathi" text="शेरा :" Font-Bold="True" Font-Size="Large"></asp:Label>
                   </td>
                   <td style="text-align: left">
                       <asp:TextBox ID="txtRemark" runat="server" Font-Names="Sakal Marathi" TextMode="MultiLine" Height="38px" Width="204px"></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td colspan="2">
                       &nbsp;</td>
               </tr>
               <tr>
                   <td colspan="2" style="text-align: center">
                       <asp:Button ID="btnSave" runat="server" Font-Bold="True" Font-Names="Sakal Marathi" OnClick="btnSave_Click" text="साठवा" />
                   </td>
               </tr>
               <tr>
                   <td>&nbsp;</td>
                   <td>&nbsp;</td>
               </tr>
           </table>
         </center> 
         </div>


    </asp:Panel>
       
</asp:Content>

