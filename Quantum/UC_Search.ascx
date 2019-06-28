<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Search.ascx.cs" Inherits="UC_Search" %>

<asp:Panel runat="server" ID="pnlSearch" DefaultButton="btnSearch">
    <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
    <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
</asp:Panel>
