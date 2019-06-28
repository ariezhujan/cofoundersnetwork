<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ForgottenPassword.aspx.cs" Inherits="Quantum.ds_forgottenpassword" enableEventValidation="false" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <div style="margin-left: 30px;margin-right: 30px;">    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>  
                <div class="row">
                    <div class="col-md-4">                
                        <div class="form-group">
                            <label for="txtName">Email Address:</label>
                            <asp:TextBox class="form-control" runat="server" ID="txtEmail" Width="300"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">                
                        <div class="form-group">
                            <asp:button CssClass="btn" runat="server" ID="btnResetPassword" Text="Reset Password" OnClick="btnResetPassword_Click" />
                            <br />
                            <asp:Literal runat="server" ID="litMessage"></asp:Literal>                    
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
</asp:Content>

