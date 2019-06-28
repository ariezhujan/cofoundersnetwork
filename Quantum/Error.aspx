<%@ Page Title="An Error Occurred!" Language="C#" MasterPageFile="~/MasterPage_MegaSWF.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">

    <h1>Opps! An error occurred.</h1>
           
    <asp:Panel CssClass="fieldWrapper" runat="server" ID="pnlSendMessage" DefaultButton="btnSubmit">
        Please tell us the steps you took to cause the error with as much detail as possible and we will fix the problem.
        <br /><br />
        If the error occured while attempting to upload a file, please try again with another browser.
        <br /><br />
        <asp:TextBox Width="300" runat="server" ID="txtMessage" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:LinkButton runat="server" ID="btnSubmit" OnClick="btnSubmit_Click">Submit your error report</asp:LinkButton>
    </asp:Panel>
    <asp:Literal runat="server" ID="litMessageSent"></asp:Literal>

    
    <br /><br /><br />
    <a href="#" onClick="history.go(-1)">Go back to the last page</a> | <a href="/">Go to the homepage</a> 

    <br />
    
    <div>
        <asp:Literal runat="server" ID="litError"></asp:Literal>
    </div>
</asp:Content>

