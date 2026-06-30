<%@ Page Title="" Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true" CodeFile="frmDownload712PDF.aspx.cs" Inherits="frmDownload712PDF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" onload="setSession();">
   
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

    

    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" charset="utf-8" />

<body>
   
        <div>
            <br />
            <asp:Panel ID="Panel8" runat="server" CssClass="all_pnl95">
           
                     <div class="row">
                <br /> <center>
                    <div class="column_margin5p ">
                        
                    </div>
                    <div class="column_10per_womargin">
                        <asp:DropDownList ID="ddlVillage" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlVillage_SelectedIndexChanged"  >
                        </asp:DropDownList><br /><br />   <asp:RequiredFieldValidator ID="rfvddlmut" runat="server" ControlToValidate="ddlVillage" InitialValue="--निवडा--" SetFocusOnError="true"
                                                    CssClass="form_lbl" ErrorMessage="गाव निवडा...!!!" ValidationGroup="Valid" ></asp:RequiredFieldValidator>
                    </div></center>
                         </div>
                </asp:Panel>
            </div>
    </body>
    </html>
</asp:Content>

