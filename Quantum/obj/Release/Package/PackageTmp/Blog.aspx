<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="Quantum.Blog" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <%@ Import Namespace="QuantumLibrary" %>
    <%@ Register TagPrefix="uc" TagName="BlogArticles" Src="UC_BlogArticles.ascx" %>  
    
    
    <section><!--start section 1-->
        <div class="row" style="font-family: calibri">
		    <div class="col s12 m12">
			        <div class="parallax-container" style="height:300px; font-family:calibri; background:rgba('0,0,0,.10')">
				    <div class="parallax grey darken-4"><img class="responsive-img" src="Co-founders Netwrok_files/blog1.jpg"></div>
					    <div class="container" style="margin-top: .2em">
						    <div class="row">
							    <div class="col m12 l12 l12 " style="font-size:4em; margin-top:150px">
							        <p style="background:rgba(0,0,0,.6);" class="white-text text-darken-4 center-align">Publish, Media & News Blog</p>
							    </div>
						    </div>
					    </div>
				    </div>
            </div>
        </div>    
    </section><!--end section 1-->
    
          
    <uc:BlogArticles runat="server"></uc:BlogArticles>

    <asp:Panel runat="server" ID="pnlCreatePost" Visible="false">
        <asp:TextBox CssClass="form-control" placeholder="Post Name" runat="server" ID="txtPostName" Width="200"></asp:TextBox>
        <div style="margin-top: 5px;"><asp:Button CssClass="btn btn-primary" runat="server" Text="Create New Post" ID="btn_CreateNewPost" OnClick="btn_CreateNewPost_Click" Width="200" /></div>
        <asp:Literal runat="server" ID="litNewPostMessage"></asp:Literal>
    </asp:Panel>
</asp:Content>



