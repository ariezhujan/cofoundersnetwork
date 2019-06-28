<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User_Search.aspx.cs" Inherits="Quantum.User_Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <%@ Import Namespace="QuantumLibrary" %>

    
        
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnSearch">
             <div class="row" style="margin-right: 30px;margin-left: 30px;">
            <div class="col-md-3">
                <div class="form-group mr-2">
                    <label for="ddlCountry">Entrepreneur's Country :</label>
                    <asp:DropDownList runat="server" ID="ddlCountry" CssClass="form-control">
                        <asp:ListItem Value="Any" Text="Any" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="India" Text="India"></asp:ListItem>
                        <asp:ListItem Value="Indonesia" Text="Indonesia"></asp:ListItem>
                        <asp:ListItem Value="Malaysia" Text="Malaysia"></asp:ListItem>
                        <asp:ListItem Value="Philippines" Text="Philippines"></asp:ListItem>
                        <asp:ListItem Value="Singapore" Text="Singapore"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group mr-2">
                    <label for="rblStartUpExperience">Entrepreneur's Minimum Experience :</label>
                    <asp:RadioButtonList runat="server" ID="rblStartUpExperience">
                        <asp:ListItem Text="No Experience" Selected="True" Value="0"></asp:ListItem>
                        <asp:ListItem Text="1 Start-up Created" Value="1"></asp:ListItem>
                        <asp:ListItem Text="2 Start-ups Created" Value="2"></asp:ListItem>
                        <asp:ListItem Text="3 Start-ups Created" Value="3"></asp:ListItem>
                        <asp:ListItem Text="4+ Start-ups Created" Value="4"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-inline">
                    <label class="mr-2">Entrepreneur's Age :</label>
                    <asp:DropDownList runat="server" ID="ddlAgeFrom" class="form-control mr-1"></asp:DropDownList> - <asp:DropDownList runat="server" ID="ddlAgeTo" class="form-control ml-1"></asp:DropDownList>
                </div>            
                <br>    
                <div class="form-group mr-2">
                    <label for="rblIndustry">Industry :</label>
                    <asp:RadioButtonList runat="server" ID="rblIndustry">
                        <asp:ListItem Text="Any" Value="Any" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Finance" Value="Finance"></asp:ListItem>
                        <asp:ListItem Text="Transportation" Value="Transportation"></asp:ListItem>
                        <asp:ListItem Text="Online Sales" Value="Online Sales"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="form-group mr-2">
                    <label for="rblBusinessStage">Business Stage :</label>
                    <asp:RadioButtonList runat="server" ID="rblBusinessStage">
                        <asp:ListItem Text="Any" Value="Any" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Idea" Value="Idea"></asp:ListItem>
                        <asp:ListItem Text="Business Plan Created" Value="Business Plan Created"></asp:ListItem>
                        <asp:ListItem Text="MVP Created" Value="Minimum Viable Product Created"></asp:ListItem>
                        <asp:ListItem Text="Sales Generated" Value="Sales Generated"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div class="text-right mr-2">
                    <asp:Button runat="server" id="btnSearch" Text="Search" OnClick="btnSearch_OnClick" CssClass="btn btn-primary" />
                </div>
            </div>
            
                 
            <asp:Literal runat="server" ID="litMessage"></asp:Literal>
            <asp:Repeater runat="server" ID="dgUsers">
                <HeaderTemplate>
                    <div class="col-md-9">
                </HeaderTemplate>
                <AlternatingItemTemplate>                    
                        <div class="col-md-3">
                        <div class="card">
                          <img class="card-img-top" src="<%#File.uploadedFilesDirectory + "\\" + Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "image").ToString(), "user_no_image.jpg")%>" alt="Card image cap">
                          <div class="card-body">
                            <h5 class="card-title font-title"><%#Data.maxStringDisplay(DataBinder.Eval(Container.DataItem, "name"), 30)%></h5>
                            <p class="card-text"><%#Data.maxStringDisplay(DataBinder.Eval(Container.DataItem, "about"), 30)%></p>
                            <a href="User.aspx?id=<%#DataBinder.Eval(Container.DataItem, "userid")%>" class="btn btn-secondary">View Detail</a>
                          </div>
                        </div>
                    </div>                
                    </div>
                    <br />
                </AlternatingItemTemplate>
                <ItemTemplate>
                    <div class="row">
                    <div class="col-md-3">
                        <div class="card">
                          <img class="card-img-top" src="<%#File.uploadedFilesDirectory + "\\" + Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "image").ToString(), "user_no_image.jpg")%>" alt="Card image cap">
                          <div class="card-body">
                            <h5 class="card-title font-title"><%#Data.maxStringDisplay(DataBinder.Eval(Container.DataItem, "name"), 30)%></h5>
                            <p class="card-text"><%#Data.maxStringDisplay(DataBinder.Eval(Container.DataItem, "about"), 30)%></p>
                            <a href="User.aspx?id=<%#DataBinder.Eval(Container.DataItem, "userid")%>" class="btn btn-secondary">View Detail</a>
                          </div>
                        </div>
                    </div>
                        
                        
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
            </div>
 
            </asp:Panel>
        
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
