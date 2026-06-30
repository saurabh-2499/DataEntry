<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true"  CodeFile="wfrmNamuna-8-A.aspx.cs" Inherits="wfrmNamuna_8_A" Title="गाव नमुना आठ-अ" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%--<%@ OutputCache Location="None" VaryByParam="None" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<script type="text/javascript">
    
 
 
 function showDiv()
{
 document.getElementById('myHiddenDiv').style.display =""; 
       document.images["myAnimatedImage"].src="Image/g-process-bar.gif"
}
  //  window.onload = function () { alert("It's loaded!") }
    
   document.onreadystatechange = function () 
   {
  if (document.readyState == "interactive") 
  {
    document.getElementById('myHiddenDiv').style.display ="none"; ;
  }
}

 function PopUpWindow()
        {
          
            var lbltext =  document.getElementById("<%=Label3.ClientID%>").innerHTML;
           OpenWindow = window.open("", null, "height=650, width=1100,toolbar=no,scrollbars=yes,menubar=no");
           OpenWindow.document.write(lbltext);
           if(OpenWindow.print())
           { 
           OpenWindow.close();
           }          
           
                  
        }
        
        
         function fun1()
    {
     
          document.getElementById("<%=pnl2.ClientID%>").style.display = 'none';
           
               
//           document.getElementById("<%=pnl1.ClientID%>").style.display = '';
     
    }
       

    </script>
    

     <asp:Panel ID="pnl2" runat="server" Height="80%" Style="z-index: 100; left: 9px;
                     top: 43px" Width="100%" BorderStyle="Solid" ScrollBars="Both" Visible="False">
                    <table style="z-index: 100; left: 0px; width: 100%; top: 0px;
                        height: 49px">
                        <tr>
                            <td style="width:10%; height: 83px; vertical-align: top; text-align: left;">
                              &nbsp
                              <asp:Image ID="btnPrint" runat="server" Height="34px" ImageUrl="~/Image/print.JPG" onclick="PopUpWindow()" Visible="False" Width="46px" />
                                &nbsp; &nbsp;&nbsp;</td>
                            <td style="width: 90%; height: 83px;">
                             <asp:Label ID="Label3" runat="server" BackColor="White" Text="Label"  ></asp:Label>
    
                                pge</td>
                        </tr>
                    </table>
                              
                </asp:Panel>
           
        <asp:Panel runat="server" id="pnl1" Width="100%" Visible="False">
    
    
  
        <table width="100%" >
        
        
        
        <tr>
            <td style="width: 100px">   

       
  
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td align="center" colspan="7">
                <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="X-Large" 
                    Height="24px" Text="गाव नमुना आठ-अ" Width="223px" CssClass="HeadingFont"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 365px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px; ">
            </td>
            <td style="width: 100px">
            </td>
            <td align="center" colspan="7">
                <asp:Label ID="Label37" runat="server" Font-Bold="True" Font-Size="X-Large" CssClass="TitleFont"
                    Height="25px" Text="धारण जमिनींची नोंदवही" Width="415px"></asp:Label></td>
            <td style="width: 100px">
            </td>
            <td style="width: 365px; ">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 365px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
            <td style="width: 100px; height: 23px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                </td>
            <td colspan="3">
                </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 365px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label1" runat="server" Height="21px" Text="नाव " Width="58px" CssClass="LabelFont"></asp:Label></td>
            <td colspan="3">
                <asp:DropDownList ID="ddlName" runat="server" Width="254px" AutoPostBack="True" OnSelectedIndexChanged="ddlName_SelectedIndexChanged1" CssClass="DropDownFont">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 365px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td colspan="4">
               
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
                <asp:Label ID="Label2" runat="server" Height="21px" Text="खाते क्र." Width="70px" CssClass="LabelFont"></asp:Label></td>
            <td colspan="3">
                <asp:DropDownList ID="ddlKhata_no" runat="server" Width="132px" AutoPostBack="True" OnSelectedIndexChanged="ddlKhata_no_SelectedIndexChanged" CssClass="DropDownFont">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 100px">
            </td>
            <td colspan="4">
                &nbsp;<asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="गाव नमुना" CssClass="form_lbl" OnClientClick="showDiv();" />
                &nbsp;
                &nbsp; &nbsp;
                
               
                  
            </td>
        </tr>
        <tr>
            <td colspan="17" style="height: 62px" align="center">
                <%-- <span id="myHiddenDiv" style="display: none">
                  <div id="blur">&nbsp;</div>
                        <div id="progress1" >
                            <img id="myAnimatedImage" alt="" src="" />
                            <font color="white">Please wait............</font>
                         </div>
             </span>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/g-process-bar.gif" Style ="visibility:hidden;"  />
                --%></td>
  
        </tr>
        </table>
        </asp:Panel>
        
         <span id="myHiddenDiv" style="display: none">
                  <div id="blur">&nbsp;</div>
                        <div id="progress1" >
                            <img id="myAnimatedImage" alt="" src="" />
                            <font color="white">Please wait............</font>
                         </div>
             </span>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/Processing.gif" Style ="visibility:hidden;"  />
                
         
    
   
    <asp:HiddenField ID="hfKhata_no" runat="server" />
  
    <asp:HiddenField ID="hfFname" runat="server" OnValueChanged="HiddenField1_ValueChanged" />
    <asp:HiddenField ID="hfMname" runat="server" />
    <asp:HiddenField ID="hfLname" runat="server" />
    
     <asp:HiddenField ID="hf3" runat="server" />

</asp:Content>

