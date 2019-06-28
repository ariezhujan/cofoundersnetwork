<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User_ConfirmEmail.aspx.cs" Inherits="Quantum.ds_userconfirmemail" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div style="margin-left: 30px;margin-right: 30px;">    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>  
                <div class="row">
                    <div class="col-md-4">                
                        <div class="form-group">
                            <asp:Literal runat="server" ID="litMessage"></asp:Literal>                        
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
