<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UserContact.ascx.cs" Inherits="Quantum.UC_UserContact" %>

<asp:HiddenField runat="server" ID="hfUserID"></asp:HiddenField>
<asp:Panel runat="server" ID="pnlContact">
    <div class="row">
        <div class="col-md-6">
            <p class="font-title">Contact</p>
            <asp:TextBox CssClass="inputBox form-control" ID="txtMessage" runat="server" TextMode="MultiLine" Width="400" Height="100" placeholder="Write a message to contact this user with a propsal."></asp:TextBox>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
               <ContentTemplate>   
                    <asp:Button CssClass="btn" runat="server" ID="btnContact" Text="Send Message" OnClick="btnContact_Click" />
                    <asp:Literal runat="server" ID="litContactMessage"></asp:Literal>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                <ProgressTemplate>           
                    <img alt="progress" src="img/ajax-loader.gif"/>            
                </ProgressTemplate>
            </asp:UpdateProgress>
        </div>
    </div>       
</asp:Panel>