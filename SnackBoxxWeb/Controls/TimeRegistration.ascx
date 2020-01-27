<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TimeRegistration.ascx.cs" Inherits="SnackBoxxWeb.Controls.TimeRegistration" %>
<asp:UpdatePanel ID="timeupdate" runat="server">
<ContentTemplate>
<div id="innerblock">
   <asp:Label ID="Label2" runat="server" Text="" CssClass="labtext"></asp:Label>
   <br />
   <table width="90%" border="0">
    <tr>
        <td><asp:Label ID="Label3" runat="server" Text="Year" CssClass="labtext"></asp:Label></td>
        <td>
        <asp:DropDownList ID="ddlYears" runat="server" CssClass="textbox" Width="100px">
        <asp:ListItem Selected="True" Value="0">This Year</asp:ListItem>
        <asp:ListItem Value="2009">2009</asp:ListItem>
        <asp:ListItem Value="2010">2010</asp:ListItem>
        <asp:ListItem Value="2011">2011</asp:ListItem>
        <asp:ListItem Value="2012">2012</asp:ListItem>
        <asp:ListItem Value="2013">2013</asp:ListItem>
        </asp:DropDownList>
        </td>
        <td><asp:Label ID="Label4" runat="server" Text="Month" CssClass="labtext"></asp:Label></td>
        <td>
         <asp:DropDownList ID="ddlMonth" runat="server" CssClass="textbox" Width="100px">
        <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
        <asp:ListItem Value="1">January</asp:ListItem>
        <asp:ListItem Value="2">February</asp:ListItem>
        <asp:ListItem Value="3">March</asp:ListItem>
        <asp:ListItem Value="4">April</asp:ListItem>
        <asp:ListItem Value="5">May</asp:ListItem>
        <asp:ListItem Value="6">June</asp:ListItem>
        <asp:ListItem Value="7">July</asp:ListItem>
        <asp:ListItem Value="8">August</asp:ListItem>
        <asp:ListItem Value="9">September</asp:ListItem>
        <asp:ListItem Value="10">October</asp:ListItem>
        <asp:ListItem Value="11">November</asp:ListItem>
        <asp:ListItem Value="12">December</asp:ListItem>
        </asp:DropDownList>
        </td>
        <td><asp:Label ID="Label1" runat="server" Text="Day" CssClass="labtext"></asp:Label></td>
        <td>
        <asp:DropDownList ID="ddlDays" runat="server" Width="100px" CssClass="textbox">
        <asp:ListItem Selected="True" Value="0">All</asp:ListItem>
        <asp:ListItem Value="1"> 1</asp:ListItem>
        <asp:ListItem Value="2"> 2</asp:ListItem>
        <asp:ListItem Value="3"> 3</asp:ListItem>
        <asp:ListItem Value="4"> 4</asp:ListItem>
        <asp:ListItem Value="5"> 5</asp:ListItem>
        <asp:ListItem Value="6"> 6</asp:ListItem>
        <asp:ListItem Value="7"> 7</asp:ListItem>
        <asp:ListItem Value="8"> 8</asp:ListItem>
        <asp:ListItem Value="9"> 9</asp:ListItem>
        <asp:ListItem Value="10">10</asp:ListItem>
        <asp:ListItem Value="11">11</asp:ListItem>
        <asp:ListItem Value="12">12</asp:ListItem>
        <asp:ListItem Value="13">13</asp:ListItem>
        <asp:ListItem Value="14">14</asp:ListItem>
        <asp:ListItem Value="15">15</asp:ListItem>
        <asp:ListItem Value="16">16</asp:ListItem>
        <asp:ListItem Value="17">17</asp:ListItem>
        <asp:ListItem Value="18">18</asp:ListItem>
        <asp:ListItem Value="19">19</asp:ListItem>
        <asp:ListItem Value="20">20</asp:ListItem>
        <asp:ListItem Value="21">21</asp:ListItem>
        <asp:ListItem Value="22">22</asp:ListItem>
        <asp:ListItem Value="23">23</asp:ListItem>
        <asp:ListItem Value="24">24</asp:ListItem>
        <asp:ListItem Value="25">25</asp:ListItem>
        <asp:ListItem Value="26">26</asp:ListItem>
        <asp:ListItem Value="27">27</asp:ListItem>
        <asp:ListItem Value="28">28</asp:ListItem>
        <asp:ListItem Value="29">29</asp:ListItem>
        <asp:ListItem Value="30">30</asp:ListItem>
        <asp:ListItem Value="31">31</asp:ListItem>
        </asp:DropDownList>
        </td>
        <td><asp:Button ID="btnsearch" runat="server" Text="Search" 
                onclick="btnsearch_Click" CssClass="btnstyle" /></td>
    </tr>    
   <tr>
    <td><asp:CheckBox ID="cbOnlyDayResults" runat="server" Text="only Day-Results" CssClass="labtextmin" /></td>
    <td><asp:CheckBox ID="cbwithWeekResults" runat="server" Text="with Week-Results" CssClass="labtextmin" /></td>
    <td colspan="5">&nbsp;</td>   
   </tr>
   </table>
   <div class="divdifference"><asp:Label ID="labeditfunktion" runat="server" CssClass="labtextminred"></asp:Label></div>
   <br />
   <asp:Table ID="tabledate" runat="server" Width="90%"></asp:Table>
   
</div>
</ContentTemplate>
</asp:UpdatePanel>


