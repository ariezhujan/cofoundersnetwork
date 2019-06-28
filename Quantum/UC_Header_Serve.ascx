<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Header_Serve.ascx.cs" Inherits="UC_Header_Serve" %>

<%@ Register TagPrefix="uc" TagName="Search" Src="UC_Search.ascx" %>

<asp:Panel runat="server" ID="pnlSearch" DefaultButton="btnSearch">
    <a style="color: Green; font-size: larger;" href="/"><img alt="MegaSWF" src="/images/logo.png" style="border: none; position: relative; top: 7px;" /></a>&nbsp;&nbsp;&nbsp;&nbsp;
    
    <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
    <asp:Button runat="server" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
    
    &nbsp;&nbsp;|&nbsp;&nbsp;
    
    <a href="/Games">Games</a>
    &nbsp;&nbsp;|&nbsp;&nbsp;
    <a href="/browse/animations/">Animations</a>
    &nbsp;&nbsp;|&nbsp;&nbsp;
    <a href="/browse/videos/">Videos</a>
    &nbsp;&nbsp;|&nbsp;&nbsp;   
    <a href="/?Upload?=1">Upload</a>
    &nbsp;&nbsp;|&nbsp;&nbsp;
    <a href="/Forum">Forum</a>
    &nbsp;&nbsp;|&nbsp;&nbsp;
    <a href="/User/Profile">My Account</a>
</asp:Panel>
