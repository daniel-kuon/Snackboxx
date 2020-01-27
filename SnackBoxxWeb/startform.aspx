<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="startform.aspx.cs" Inherits="SnackBoxxWeb.startform" %>
<%@ Register Src="Controls/TimeRegistration.ascx" TagName="TimeRegistration" TagPrefix="ucl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Snackboxx</title>
    <link rel="shortcut icon" href="http://localhost:2687/images/BioHazard.ico" type="images/BioHazard.ico" />
    <link rel="icon" href="http://localhost:2687/images/BioHazard.ico" type="images/BioHazard.ico" />
    <link rel="stylesheet" type="text/css"  href="globalstyle.css" />      
    <script type="text/javascript">
     function pageLoad() {   }    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="globaldiv">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="pnlglobal" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
           
        <div id="top">
            <table cellpadding="0" cellspacing="0" border="0" id="toptable">
                <tr>
                    <td width="30%" valign="top">             
                        <asp:label ID="info" runat="server" text="" CssClass="labtextmin"></asp:label><br /> 
                    </td>
                    <td colspan="2" valign="top" align="right">
                        <asp:Label ID="username" runat="server" Text="" CssClass="labtextmin"></asp:Label>
                        <asp:LinkButton ID="logout" runat="server" Text="logout" CssClass="labtextminred" onclick="logout_Click"></asp:LinkButton>        
                    </td>
                </tr>
                <tr>
                    <td width="30%" valign="top">
                        <!--  <asp:LinkButton ID="refresh" runat="server" Text="Refresh" onclick="refresh_Click"></asp:LinkButton> 
                        -->
                    </td>
                    <td align="center" width="40%"><h4>Snackboxx</h4></td>                     
                    <td align="right"> <img alt="" src="images/CitrixWatermark.gif" width="60%" height="60%" />          
                    </td>
                </tr>
            </table> 
        </div>
        <div id="content">                 
            <table cellpadding="0" cellspacing="0" id="contenttable" border="0">
            <tr>
                <td width="12%" class="bgimageleft" valign="top" align="center"><br />
                    <asp:Label ID="menuleft" runat="server" Text="" CssClass="labtext"></asp:Label>
                </td>
                <td align="center" valign="top">
                <asp:PlaceHolder ID="phcentercontent" runat="server"></asp:PlaceHolder>
                <asp:Label ID="menucenter" runat="server" Text="" CssClass="labtext"></asp:Label>                                
                </td>             
                
                <td width="12%" class="bgimageright" valign="top" align="center"><br />
                <asp:Label ID="menuright" runat="server" Text="" CssClass="labtext"></asp:Label>                 
                </td>
            </tr>           
            </table>
        </div>
        <div id="footer"></div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>

