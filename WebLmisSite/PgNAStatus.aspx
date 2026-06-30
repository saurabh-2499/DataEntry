<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="PgNAStatus.aspx.cs" Inherits="PgNAStatus" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <br />
      <asp:Panel ID="pnl" runat="server" Width="85%" Height="500px" ScrollBars="Vertical" BackColor="#CCCCCC" >
     
          <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"  Height="100%" style="margin-right: 2px"     ></rsweb:ReportViewer>
         
          </asp:Panel>
</asp:Content>

