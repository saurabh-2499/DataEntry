<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="RptConfirm.aspx.cs" Inherits="RptConfirm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<form runat ="server">

     <div class="row"><centre>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>
         <centre>
              <asp:Button ID="btnBack" runat="server" Text="मागे"  Width="110"  ToolTip="मागे" OnClick="btnBack_Click"/>
             </center><br />
    <br /> <center>
    <asp:Panel ID="pnl" runat="server" Width="75%" Height="600px" BackColor="White"  ScrollBars="Auto">
        <center>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server"  Width="100%" Height="600px"></rsweb:ReportViewer>
            </center>

    </asp:Panel>  
         </center>     
 </div>  
    </centre>
    </form>    



