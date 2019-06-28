<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Forum_Comment.aspx.cs" Inherits="Quantum.Forum_Comment"  enableEventValidation="false" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"></asp:ScriptManager>
    <%@ Register TagPrefix="uc" TagName="ObjectListValue" Src="UC_ObjectListValue.ascx" %>
    <%@ Register TagPrefix="uc" TagName="UserProjects" Src="UC_UserProjects.ascx" %>
    <%@ Import Namespace="QuantumLibrary" %>

    <div class="container" style="margin-top: 50px">  

        <div class="row">
            <div class="col-md-3 col l3 s12"><!--start col 3-->
                <section><!--Upload Picture-->
                    <div class="text-center">
                        <picture>
                            <asp:Image runat="server" ID="imgUser" Width="150" />
                        </picture>
                    </div>
                    <br />
                    <%@ Register TagPrefix="nup" Namespace="Brettle.Web.NeatUpload" Assembly="Brettle.Web.NeatUpload" %>
                    <h2 class="font-title">Change Image</h2>
                    <div class="from-group row mr-1">
                        <div class="custom-file" id="file">
                            <nup:InputFile id="FileUploader" runat="server" CssClass="inputBox form-control" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col l7 s12">
                            <asp:Button CssClass="btn btn-primary" id="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_OnClick" /> 
                            <asp:Literal runat="server" ID="litFileUploadMessage" />
                        </div>
                    </div>
                </section><!--End Upload Picture-->
            </div><!--end col 3--> 

            <div class="col m9 l9 s12">
                <asp:Panel ID="pnlDetails" runat="server" DefaultButton="btnUpdate">
                  <div class="form-group row">
                    <label for="txtWebsite" class="col-sm-2 col-form-label">Title</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtTitle" class="form-control" placeholder="CEO at Google since 2015"></asp:TextBox>
                    </div>
                  </div>       
                  <div class="form-group row">
                    <label for="txtAbout" class="col-sm-2 col-form-label">Comment</label>
                    <div class="col-sm-10">
                        <asp:TextBox CssClass="form-control" runat="server" ID="txtComment" TextMode="MultiLine" Height="100"></asp:TextBox>
                        <script type="text/javascript">
                            //<![CDATA[
                            function pageLoad() { // this gets fired when the UpdatePanel.Update() completes
                                $('#<%=txtComment.ClientID%>').summernote({
                                    tabsize: 2,
                                    height: 150,
                                    toolbar: [
                                        ['style', ['bold', 'italic', 'underline']],
                                        ['color', ['color']],
                                        ['para', ['ol', 'paragraph']],
                                        ['insert', ['link', 'picture', 'video', 'table', 'hr']]
                                    ]
                                });
                            }                                
                            //]]>
                        </script>
                    </div>
                  </div>  

                    </asp:Panel>   
                     

                  <div class="row">
                    <div class="col-sm-10">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>           
                                <asp:Button runat="server" ID="btnUpdate" Text="Save Changes" OnClick="btnUpdate_Click" class="btn btn-primary"/>
                                <asp:Literal runat="server" ID="litUpdateMessage"></asp:Literal>
                            </ContentTemplate>
                         </asp:UpdatePanel>  
                        
                        <a href="Forum_Thread.aspx?id=<%=Request["id"].ToString() %>">View Thread</a>
                        <br /><br />
                        <div runat="server" id="pnlDeletePost" visible="true">
                            <asp:Button runat="server" id="btnDeletePost" OnClick="btnDeletePost_Click" Text="Delete Post" OnClientClick="if ( ! confirm('Are you sure you want to delete this post?')) return false;" class="btn"></asp:Button>
                        </div> 
                    </div>
                  </div>                    
            </div>
        </div>                
    </div>
</asp:Content>
