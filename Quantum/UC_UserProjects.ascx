<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UserProjects.ascx.cs" Inherits="Quantum.UC_UserProjects" %>
<%@ Import Namespace="QuantumLibrary" %>

<asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" id="pnlNoProjects" Visible="false">
                <br />
                Congratulations on joining CoFounders Network! Please fill in your <a href="user_edit.aspx">user profile</a> to get started and be found by other users using the networking search. When ready begin your pitth draft below. Your pitch allows you to share your vision with others and gain traction in establishing a team and investors.
            </asp:Panel>
            
            <div class="row">
            <asp:Repeater runat="server" ID="dgProjects">
                <ItemTemplate>                    
                    <div class="col-md-4 col-sm-4 col-12">
                        <div class="card">
                            <div class="card-body">
                            <h5 class="card-title"><%#Data.maxStringDisplay(DataBinder.Eval(Container.DataItem, "Name"), 30)%></h5>
                            <p class="card-text"><%# DataBinder.Eval(Container.DataItem, "editeddate")%> - <%# DataBinder.Eval(Container.DataItem, "status")%></p>
                            <a href="/Project_Edit.aspx?ID=<%#DataBinder.Eval(Container.DataItem, "projectID")%>" class="btn btn-primary">Edit</a>
                            <a href="/Project_View.aspx?ID=<%#DataBinder.Eval(Container.DataItem, "projectID")%>" class="btn btn-primary">View</a>
                            </div>
                        </div>
                    </div>                 
                </ItemTemplate>
            </asp:Repeater>
            </div>

            <asp:TextBox CssClass="form-control" placeholder="Pitch Name" runat="server" ID="txtProjectName" Width="200"></asp:TextBox>
            <div style="margin-top: 5px;"><asp:Button CssClass="btn btn-primary" runat="server" Text="Create New Pitch" ID="btn_CreateNewProject" OnClick="btn_CreateNewProject_Click" Width="200" /></div>
            <asp:Literal runat="server" ID="litNewProjectMessage"></asp:Literal>
        </ContentTemplate>
    </asp:UpdatePanel>