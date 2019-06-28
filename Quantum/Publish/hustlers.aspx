<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Hustlers.aspx.cs" Inherits="Quantum.Hustlers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <%@ Import Namespace="QuantumLibrary" %>
    <%@ Register TagPrefix="uc" TagName="HustlerArticles" Src="UC_HustlerArticles.ascx" %>
        

    <section><!--Start Section 1-->
        <div class="row" style="margin-top:-10px">
            <div class="col s12 m6">
                <div class="card blue lighten-5">
                    <div class="card-content dark-text" style="margin-top: 10px">
                        <h1 class="center-align" style="font-size: 60px;"></p>The worlds fastest growing <br>businesses choose Co-Founders  </p></h1>
                    </div>
                </div>
            </div>
        </div>
    <section><!--End Section 1-->
    
    <uc:HustlerArticles runat="server"></uc:HustlerArticles>


    <section><!--Start Section 3-->
         <div class="container black-text">
           <div class="container">
               <div class="col m12 l12 s12 offset-l5 center">
                   <a href="login.aspx" class="btn cyan wave-effect-purple white-text hoverable">Get Started<i class="material-icons right">more_vert</i></a>
               </div>
           </div>
         </div>
    <section><!--End Section 3-->

    <asp:Panel runat="server" ID="pnlCreatePost" Visible="false">
        <asp:TextBox CssClass="form-control" placeholder="Post Name" runat="server" ID="txtPostName" Width="200"></asp:TextBox>
        <div style="margin-top: 5px;"><asp:Button CssClass="btn btn-primary" runat="server" Text="Create New Post" ID="btn_CreateNewPost" OnClick="btn_CreateNewPost_Click" Width="200" /></div>
        <asp:Literal runat="server" ID="litNewPostMessage"></asp:Literal>
    </asp:Panel>
</asp:Content>



