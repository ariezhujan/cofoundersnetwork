<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Quantum.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server" ScriptMode="Release"></asp:ScriptManager>
    <%@ Register TagPrefix="uc" TagName="ObjectListValue" Src="UC_ObjectListValue.ascx" %>
    <%@ Register TagPrefix="uc" TagName="UserContact" Src="UC_UserContact.ascx" %>
    <%@ Register TagPrefix="uc" TagName="UserReport" Src="UC_UserReport.ascx" %>

    <%@ Import Namespace="QuantumLibrary" %>
    
    <div class="container nav-wrapper" style="margin-top: 50px"><!--Start container-->
    <div class="row"><!--Start row-->
        <div class="col m10 l10 s12"><!--Start Col-->

            <section>
                <div class="row">
                    <div class="col m4 l4 s12 push-l2">
                        <asp:Image style="max-height:150px;height:150px;width:150px;max-width:150px;border-radius:100%" CssClass="responsive-img" runat="server" ID="imgUser" />
                    </div>
                    <div class="col m8 l8 s12 s12 pull-l2" style="margin-top: 40px">
                        <h5 class="card-title center-align"><asp:Literal runat="server" ID="litName"></asp:Literal></h5><hr class="cyan" style="width:100px">
                        <div class="card-title center-align">Joined at <asp:Literal runat="server" ID="litJoined"></asp:Literal>, Last Visit at <asp:Literal runat="server" ID="litLastVisitDate"></asp:Literal></div>                 
                    </div>
                </div>
                <div class="row z-depth-2" style="margin-top: 50px">
                    <div class="col s12">
                        <p><asp:Literal runat="server" ID="litAbout"></asp:Literal></p>
                    </div>
                </div>
            </section>
            
            <section style="margin-top: 50px">
            <div class="row">
                <div class="col s12">
                <table class="centered">
                    <thead>
                        <th>Country</th>
                        <th>Industry</th>
                        <th>Business Stage</th>
                        <th>Start-up Experience</th>
                        <th>Skills</th>
                        <th>Age</th>
                    </thead>
                    <tbody>
                        <td><asp:Literal runat="server" ID="litCountry"></asp:Literal></td>
                        <td><asp:Literal runat="server" ID="litIndustry"></asp:Literal></td>
                        <td><asp:Literal runat="server" ID="litBusinessStage"></asp:Literal></td>
                        <td><asp:Literal runat="server" ID="litStartUpExperience"></asp:Literal></td>
                        <td><asp:Literal runat="server" ID="litSkills"></asp:Literal></td>
                        <td><asp:Literal runat="server" ID="litAge"></asp:Literal></td>
                    </tbody>
                </table>
                </div>
                </div>
            </section> 
                 
            <section style="margin-top:50px">
            <div class="row">
                <div class="col m6 l6 s12">
                    <p class="font-title center-align"><b>Certification</b></p>
                    <uc:ObjectListValue ID="ucObjectListValue_Certification" runat="server" />
                </div>
                <div class="col m6 l6 s12">
                    <p class="font-title center-align"><b>Education</b></p>
                    <uc:ObjectListValue ID="ucObjectListValue_Education" runat="server" />
                </div>
            </div>
            </section> 
            
            <section style="margin-top: 50px">
            <div class="row">
                <div class="col s12">
                    <uc:UserContact ID="ucUserContact" runat="server" /> 
                </div>
            </div>
            </section>  
        </div><!--End col 8-->

        <div class="col m2 l2 s12" style="max-width:300px;width:300px; margin-right:25px">
        <asp:Repeater runat="server" ID="dgProjects">
            <ItemTemplate>
                <div class="card hoverable">
                    <div class="card-body">
                        <h5 class="card-title"><%#Data.maxStringDisplay(DataBinder.Eval(Container.DataItem, "Name"), 30)%></h5>
                        <p class="card-text"><%# DataBinder.Eval(Container.DataItem, "Industry")%> <%# DataBinder.Eval(Container.DataItem, "BusinessStage")%></p>
                        <p>Investment goal: $<%# String.Format("{0:n0}", DataBinder.Eval(Container.DataItem, "InvestmentAmountRequiredUSD"))%></p>                                    
                        <p><a href='/Project_View.aspx?ID=<%#DataBinder.Eval(Container.DataItem, "projectid")%>' class="btn btn-primary">View</a></p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        </div><!--End col 4-->
    </div><!--End row-->

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>  
            <uc:UserReport ID="ucUserReport" runat="server" />    
        </ContentTemplate>
    </asp:UpdatePanel>

    </div><!--container-->
</asp:Content>
