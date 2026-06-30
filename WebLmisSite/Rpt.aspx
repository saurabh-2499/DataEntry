
<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="Rpt.aspx.cs" Inherits="Rpt"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
  
       
<form runat="server">
         <div class="row"><center>
                      
                          <asp:scriptmanager runat="server"></asp:scriptmanager>
                        <asp:Button ID="btnsave" runat="server" Text="साठवा"  Width="110" OnClick="btnsave_Click" Visible="False"/>
                        <asp:Button ID="btnBack" runat="server" Text="मागे"  Width="110"  ToolTip="मागे" OnClick="btnBack_Click"/>
             </center><br />
             
                    </div><br />
         <div class="row">

    <br />    <center>
    <asp:Panel ID="pnl" runat="server" Width="75%" Height="600px" BackColor="White" ScrollBars="Auto">
        <center>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Width="100%" Height="600px"></rsweb:ReportViewer>
            </center>

    </asp:Panel>   
            </center>    
 </div>    
    </form>  
    


