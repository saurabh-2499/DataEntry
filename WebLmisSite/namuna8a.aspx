<%@ Page Language="C#" MasterPageFile="~/InnerMaster.master" AutoEventWireup="true"  CodeFile="namuna8a.aspx.cs" Inherits="namuna8a" Title="गाव नमुना आठ-अ" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ OutputCache Location="None" VaryByParam="None" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



<script type="text/javascript">
    
  document.getElementById("<%=pnl2.ClientID%>").style.display = 'none';
 
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
                  
                     
            }
       

    </script>
    

     <asp:Panel ID="pnl2" runat="server" Height="80%" Style="z-index: 100; left: 9px;
                     top: 43px" Width="100%" BorderStyle="Solid" ScrollBars="Both" Visible="False">
                    <table style="z-index: 100; left: 0px; width: 100%; top: 0px;
                        height: 49px">
                        <tr>
                            <td style="width:10%; height: 83px; vertical-align: top; text-align: left;">
                                <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />&nbsp;
                              <asp:Image ID="btnPrint" runat="server" Height="33px" ImageUrl="~/Image/print.JPG" onclick="PopUpWindow()" Visible="false" Width="48px" ImageAlign="AbsMiddle" />
                                &nbsp; &nbsp;&nbsp;</td>
                            <td style="width: 90%; height: 83px;">
                             <asp:Label ID="Label3" runat="server" BackColor="White" Text="Label"  ></asp:Label>
    
                            </td>
                        </tr>
                    </table>
                              
                </asp:Panel>
           
        <asp:Panel runat="server" id="pnl1" Width="100%">
    
    
  
        <table width="100%" >
        
        
        
        <tr>
            <td style="width: 100px; " >   

       
  
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
            <td style="width: 100px">
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
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td colspan="2" style="height: 23px">
                    <asp:Button ID="Button1" runat="server" Height="43px" OnClick="Button1_Click1" Text="पूर्ण गावाचा आठ-अ "
                        Width="179px" /></td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 365px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 365px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
                </td>
                <td style="width: 100px; height: 23px">
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
            <td colspan="2">
                <asp:Label ID="Label5" runat="server" CssClass="form_lbl" Text="नाव :(आडनाव  किंवा पहिले नाव)"></asp:Label></td>
            <td colspan="3">
                <asp:TextBox ID="txtNameCriteria" runat="server" Width="138px"></asp:TextBox></td>
            <td style="width: 100px">
                <asp:Button ID="btnsearch" runat="server" CssClass="form_lbl" OnClick="btnsearch_Click"
                    TabIndex="1" Text="खातेदार शोधणे" ValidationGroup="khata" /></td>
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
                <asp:TextBox ID="txtKhataNo" runat="server" Width="78px"></asp:TextBox>
                &nbsp; &nbsp;<asp:DropDownList ID="ddlKhata_no" runat="server" Width="132px" AutoPostBack="True" OnSelectedIndexChanged="ddlKhata_no_SelectedIndexChanged" CssClass="DropDownFont">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList></td>
            <td style="width: 100px">
            <asp:Button ID="btnShow" runat="server" OnClick="btnShow_Click" Text="गाव नमुना" Width="124px" CssClass="LabelFont" OnClientClick="showDiv();" /></td>
            <td colspan="4">
                &nbsp; &nbsp; &nbsp;
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
                
         
    
    &nbsp;
    <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Center" ScrollBars="Both"
        Width="100%">
        &nbsp;</asp:Panel>
    &nbsp; &nbsp;
    <br />
    <asp:HiddenField ID="hfKhata_no" runat="server" />
    &nbsp;
    <br />
    <asp:HiddenField ID="hfFname" runat="server" OnValueChanged="HiddenField1_ValueChanged" />
    &nbsp;&nbsp;
    <asp:HiddenField ID="hfMname" runat="server" />
    <asp:HiddenField ID="hfLname" runat="server" />
    
     <asp:HiddenField ID="hf3" runat="server" />

</asp:Content>

