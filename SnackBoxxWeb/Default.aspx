<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SnackBoxxWeb._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

<title>Snackboxx</title>
<link rel="shortcut icon" href="http://localhost:2687/images/BioHazard.ico" type="images/BioHazard.ico" />
<link rel="icon" href="http://localhost:2687/images/BioHazard.ico" type="images/BioHazard.ico" />

<link rel="stylesheet" type="text/css"  href="globalstyle.css" />   

</head>
<body>
    <form id="form1" runat="server">    
        
        <table cellpadding="0" cellspacing="0" class="defaulttable" id="default" border="0">
            <tr>
                <td style="width:12%" rowspan="3" class="bgimageleft"></td>
                <td class="bgimagetop"><div class="topimage"></div></td>
                <td style="width:12%" rowspan="3" class="bgimageright"></td>
            </tr>
            <tr>                
                <td class="bgimagelogin middle">
                <table id="login" class="innertabledefault innertableouter" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="29%"></td>
                        <td class="middle">
                            <br />
                            <div class="divlogin">
                                <table cellpadding="0" cellspacing="0" class="innertablelogin innertabledefault">
                                    <tr>
                                        <td colspan="4" class="textheader"><h4>&nbsp;Welcome to Blue-Net Snackboxx</h4></td>                                        
                                    </tr>
                                    <tr><td colspan="4" class="text">&nbsp;Please Login</td></tr>
                                    <tr>
                                        <td rowspan="3"><img alt="" src="images/BioHazard.png" width="90%" height="90%" /></td>
                                        <td class="alignright">
                                            <asp:Label ID="Label1" runat="server" Text="Username" CssClass="labtext"></asp:Label>
                                        </td>
                                        <td class="alignright"><asp:TextBox runat="server" ID="tbusername" 
                                                CssClass="btnstyle" ontextchanged="tbusername_TextChanged"></asp:TextBox></td>
                                        <td rowspan="3"></td>
                                        
                                    </tr>
                                    <tr>
                                        <td class="alignright">
                                            <asp:Label ID="Label2" runat="server" Text="Password" CssClass="labtext"></asp:Label>
                                        </td>
                                        <td class="alignright">
                                            <asp:TextBox ID="tbpassword" runat="server" 
                                                TextMode="Password" CssClass="btnstyle"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="alignright">&nbsp;</td>
                                        <td class="alignright"><asp:Button ID="btnlogon" runat="server" Text="Log On" 
                                                CssClass="btnstyle" PostBackUrl="Default.aspx" onclick="btnlogon_Click" /></td>
                                    </tr>
                                </table>
                            </div>
                            <asp:Label ID="labinfo" runat="server" Text="" CssClass="labtext"></asp:Label>
                        </td>
                        <td width="29%"></td>
                    </tr>                    
                </table>
                </td>                
            </tr>
            <tr>
                <td class="footer"><img alt="" src="images/CitrixWatermark.gif"  /></td>
            </tr>              
        </table>
    
    </form>
</body>
</html>
