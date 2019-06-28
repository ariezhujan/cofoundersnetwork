
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User_Welcome.aspx.cs" Inherits="Quantum.User_Welcome" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<%@ Import Namespace="QuantumLibrary" %>
<%@ Register TagPrefix="uc" TagName="UserProjects" Src="UC_UserProjects.ascx" %>

<div class="container" style="margin-top: 50px">
<h1 class="font-title text-center">Hello, <%=GoalUser.CurrentUser(Page).name %></h1>
    <div class="row center" style="margin-top: 50px">
        <div class="col l4 s12 ">
            <h1><i class="cyan-text large material-icons">account_circle</i></h1>
            <a class="app_nav_big a_button" href="User.aspx?id=<%=GoalUser.CurrentUserId(Page).ToString() %>">
                View My Public Profile
            </a>
        </div>
        <div class="col l4 s12 ">
            <h1><i class="cyan-text large material-icons">mode_edit</i></h1>
            <a class="app_nav_big a_button" href="User_Edit.aspx">
                Edit My User Profile
            </a>
        </div>
        <div class="col l4 s12 ">
            <h1><i class="cyan-text large material-icons">mail_outline</i></h1>
            <a class="app_nav_big a_button" href="Messaging.aspx">
                Private Messaging
            </a>      
        </div>
    </div>
</div>

<!-- this statement for showing project list -->
<div class="container" style="margin-top: 60px; margin-bottom: 60px">
    <uc:UserProjects ID="ucUserProjects" runat="server" />    
</div>



<!--
<div class="container" style="border-top: solid #cecece 1px;"> 
    <br>
    <div class="row">
        <div class="col-md-3 col-sm-3 col-xs-6">
    <a class="app_nav_big a_button" href="Project_Search.aspx">
        Project Search
    </a>    </div>
        <div class="col-md-3 col-sm-3 col-xs-6">
    <a class="app_nav_big a_button" href="User_Search.aspx">
        User Search
    </a>  </div>
        <div class="col-md-3 col-sm-3 col-xs-6">
    <a class="app_nav_big a_button" href="Admin_User_List.aspx">
        User List
    </a>    </div>
        <div class="col-md-3 col-sm-3 col-xs-6">
    <a class="app_nav_big a_button" href="Admin_Project_List.aspx">
        Project List
    </a>          </div>
</div>
    -->

    <asp:Panel runat="server" id="pnlAdmin" Visible="false">
    <br /><br />
    <div class="container" style="border-top: solid #cecece 1px;"> 
        <br>
        <div class="row">
            <div class="col-md-3 col-sm-3 col-xs-6">
                <a class="app_nav_big a_button" href="User_Search.aspx?admin=1">
                    User Admin
                </a>
            </div>
            <div class="col-md-3 col-sm-3 col-xs-6">
                <a class="app_nav_big a_button" href="Project_Search.aspx?admin=1">
                    Project Admin
                </a>          
            </div>
        </div>
    </asp:Panel>
</div>
</asp:Content>
