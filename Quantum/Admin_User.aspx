<%@ Page Language="C#" MasterPageFile="~/MasterPage_MegaSWF.master" AutoEventWireup="true" CodeFile="Admin_User.aspx.cs" Inherits="Admin_User" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">

<%@ Register TagPrefix="uc" TagName="UserBandwidth" Src="UC_User_Bandwidth.ascx" %>

<table>
    <tr>
        <td>username</td>
        <td>
            <asp:Literal runat="server" ID="litUsername"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td>name</td>
        <td>
            <asp:Literal runat="server" ID="litName"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td>created</td>
        <td>
            <asp:Literal runat="server" ID="litCreated"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td>last login</td>
        <td>
            <asp:Literal runat="server" ID="litLastLogin"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td>email</td>
        <td>
            <asp:Literal runat="server" ID="litEmail"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td>usertype</td>
        <td>
            <asp:Literal runat="server" ID="litUsertype"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td>dateCreated</td>
        <td>
            <asp:Literal runat="server" ID="litDateCreated"></asp:Literal>
        </td>
    </tr>
</table>
<br /><br /><br />

<uc:UserBandwidth runat="server" id="userBandwidth" />


</asp:Content>

