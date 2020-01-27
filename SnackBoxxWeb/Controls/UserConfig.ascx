<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserConfig.ascx.cs" Inherits="SnackBoxxWeb.Controls.UserConfig" %>
<div>

<asp:UpdatePanel ID="userupdate" runat="server">
<ContentTemplate>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />

</ContentTemplate>
</asp:UpdatePanel>

</div>

