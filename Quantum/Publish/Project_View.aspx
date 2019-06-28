<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Project_View.aspx.cs" Inherits="Quantum.Project_View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

<%@ Register TagPrefix="uc" TagName="ObjectListValue" Src="UC_ObjectListValue.ascx" %>
<%@ Register TagPrefix="uc" TagName="UserContact" Src="UC_UserContact.ascx" %>
<%@ Register TagPrefix="uc" TagName="UserProjects" Src="UC_UserProjects.ascx" %>
<%@ Register TagPrefix="uc" TagName="UserReport" Src="UC_UserReport.ascx" %>

<%@ Import Namespace="QuantumLibrary" %>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>        
            <asp:Panel runat="server">
<div class="container" style="margin-top: 40px">
        
        <section>
             <div class="row">
                <div class="col s12 center">
                    <h1><asp:Literal runat="server" ID="litName"></asp:Literal> <a runat="server" id="hlEditProject" visible="false" class="btn btn-primary">Edit</a></h1>
                    <h4 class="grey-text darken-4"><asp:Image runat="server" ID="imgUser" CssClass="circle responsive-img" Width="40" Height="40" /> <asp:HyperLink runat="server" id="hlUser"></asp:HyperLink></h4>
                </div>
             </div>
        </section>
        <section>
             <div class="row z-depth-1" style="border-radius: 5px; padding-top: 10px; padding-bottom: 10px">
                <div class="col s12">
                    <h5 style="height: 40px; max-height: 40px">Industry :</h5>
                    <p><asp:Literal runat="server" ID="litIndustry"></asp:Literal></p>
                </div>
                <div class="col s12">
                    <h5 style="height: 40px; max-height: 40px">Business Stage :</h5>
                    <p><asp:Literal runat="server" ID="litBusinessStage"></asp:Literal></p>  
                </div>
                 <div class="col s12">
                    <h5 style="height: 40px; max-height: 40px">Use of Funds :</h5>
                    <p><asp:Literal runat="server" ID="litUseOfFunds"></asp:Literal></p>  
                </div>
             </div>
        </section>

        <section>
             <div class="row z-depth-1" style="border-radius: 5px; padding-top: 10px; padding-bottom: 10px">
                <div class="col s12">
                    <h5 style="height: 40px; max-height: 40px">Investment Target :</h5>
                    <p><asp:Literal runat="server" ID="litInvestmentAmountRequiredUSD"></asp:Literal></p>  
                </div>
                <div class="col s12">
                    <h5 style="height: 40px; max-height: 40px">Raised :</h5>
                    <p><asp:Literal runat="server" ID="litInvestmentAmountRaisedUSD"></asp:Literal></p>  
                </div>
                <div class="col s12">
                    <h5 style="height: 40px; max-height: 40px">Minimum Accepted :</h5>
                    <p><asp:Literal runat="server" ID="litInvestmentAmountMinimumUSD"></asp:Literal></p>  
                </div>
             </div>
        </section>

        <asp:Panel runat="server" ID="pnlLoggedIn" Visible="false">
            <section>
                 <div class="row z-depth-1" style="border-radius: 5px; padding-top: 10px; padding-bottom: 10px">
                    <div class="col s12">
                        <h5 style="height: 40px; max-height: 40px">Description :</h5>
                        <p><asp:Literal runat="server" ID="litDescription"></asp:Literal></p>
                    </div>
                
                 </div>
            </section>

            <section>
                 <div class="row z-depth-1" style="border-radius: 5px; padding-top: 10px; padding-bottom: 10px">
                    <div class="col s12">
                        <h5 style="height: 40px; max-height: 40px">Deliverables :</h5>
                        <p><asp:Literal runat="server" ID="litDeliverables"></asp:Literal></p>  
                    </div>             
                    <div class="col s12">
                        <h5 style="height: 40px; max-height: 40px">Business Model :</h5>
                        <p><asp:Literal runat="server" ID="litBusinessModel"></asp:Literal></p>
                    </div>
                </div>
            </section>

            <section>
                 <div class="row z-depth-1" style="border-radius: 5px; padding-top: 10px; padding-bottom: 10px">
                    <div class="col s12">
                        <h5 style="height: 40px; max-height: 40px">Risks and Challenges :</h5>
                        <p><asp:Literal runat="server" ID="litRisksAndChallenges"></asp:Literal></p>
                    </div>
                    <div class="col s12">
                        <h5 style="height: 40px; max-height: 40px">Funding Aim :</h5>
                        <p><asp:Literal runat="server" ID="litFundingAim"></asp:Literal></p>
                    </div>                
                 </div>
            </section>        

            <section>
                 <div class="row z-depth-1" style="border-radius: 5px; padding-top: 10px; padding-bottom: 10px">
                    <div class="col s12">
                        <h5 style="height: 40px; max-height: 40px">Skills Required :</h5>
                        <p><uc:ObjectListValue ID="ucObjectListValue_SkillsRequired" runat="server" /></p>
                    </div>
                    <div class="col s12">
                        <h5 style="height: 40px; max-height: 40px">Milestones :</h5>
                        <p><uc:ObjectListValue ID="ucObjectListValue_Milestones" runat="server" /></p>
                    </div>
                    <div class="col s12">
                        <h5 style="height: 40px; max-height: 40px">Positions Required :</h5>
                        <p><uc:ObjectListValue ID="ucObjectListValue_PositionsRequired" runat="server" /></p>
                    </div>
                 </div>
            </section>
        </asp:Panel>
        <asp:Panel runat="server" ID="pnlLoggedOut" Visible="false">
            <div class="col m12 l12 s12 offset-l5 center" style="padding-top: 20px;">
                <a href="login.aspx" class="btn cyan wave-effect-purple white-text hoverable">Show All Pitch Details<i class="material-icons right">more_vert</i></a>
            </div>
        </asp:Panel>
</div>
                
<div class="container">
    <asp:Panel runat="server" ID="pnlFiles">
        <asp:DataGrid UseAccessibleHeader="true" CssClass="table table-striped" BorderWidth="0" ItemStyle-BorderWidth="" runat="server" ID="dgFiles" AutoGenerateColumns="false" >
            <Columns>
                <asp:TemplateColumn HeaderText="Title" SortExpression="Title" ItemStyle-Wrap="false">
                    <ItemTemplate>
                       <%----%> <a target="_blank" href='/<%=File.uploadedFilesDirectory %>/<%#DataBinder.Eval(Container.DataItem, "location")%>'><%#DataBinder.Eval(Container.DataItem, "FileName")%></a>
                    </ItemTemplate>
                </asp:TemplateColumn>  
                <asp:TemplateColumn HeaderText="Created" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "createdDate")%>
                    </ItemTemplate>
                </asp:TemplateColumn>  
                <asp:TemplateColumn HeaderText="File Size KBs" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "filesize")%>
                    </ItemTemplate>
                </asp:TemplateColumn>  
                <asp:TemplateColumn Visible="false" HeaderText="Thumbnail" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "image")%>
                    </ItemTemplate>
                </asp:TemplateColumn> 
                <asp:TemplateColumn HeaderText="Extension" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "ext")%>
                    </ItemTemplate>
                </asp:TemplateColumn>                 
            </Columns>            
        </asp:DataGrid>
        <asp:Literal runat="server" ID="litMessageFiles"></asp:Literal>
    </asp:Panel>

    <br /><br />
    <uc:UserContact ID="ucUserContact" runat="server" />

    <uc:UserReport ID="ucUserReport" runat="server" />   
    </asp:Panel>        
            
            
            
            
    </ContentTemplate>
</asp:UpdatePanel>


               


</div>

</asp:Content>
