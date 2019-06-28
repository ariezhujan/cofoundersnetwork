<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_BlogArticles.ascx.cs" Inherits="Quantum.UC_BlogArticles" %>
<%@ Import Namespace="QuantumLibrary" %>



        <style>
            .crop {
                width: 100%;
                max-height: 200px;
                overflow: hidden;
                object-fit: cover;
                border-radius: calc(.25rem - 1px);
            }
        </style>
        <asp:Repeater runat="server" ID="dgForumThreads">
            <HeaderTemplate>
                <div class="row"><!--start section row 1-->
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col s12"><!--div 1-->
                    <div class="card-body" style="font-family:calibri; ">   
                        <div class="card-head">
                            <h4>
                                <a class="black-text" style="text-decoration-line: none" href="/Forum_Thread.aspx?ID=<%#DataBinder.Eval(Container.DataItem, "commentid")%>">
                                    <%#DataBinder.Eval(Container.DataItem, "Title")%> 
                                </a>
                            </h4>
                            <p>
                                <%#Data.maxStringDisplay(Data.StripHTML(DataBinder.Eval(Container.DataItem, "LastCommentText").ToString()), 100)%>
                            </p>    
                        </div>
                        <div class="row">
                            <div class="col s12">
                                <img style="width: 50px; height: 50px; object-fit:cover; max-width: 50px;" src="<%#File.uploadedFilesDirectory + "\\" + Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "userImage").ToString(), "user_no_image.jpg")%>" class="rounded-circle" style="width: 100%;" alt="John Peterson" class="circle">
                                <br>
                                <a style="font-size: 14px" href="user.aspx?id=<%#DataBinder.Eval(Container.DataItem, "userid")%>" class="author url fn" rel="author"><%#DataBinder.Eval(Container.DataItem, "username")%></a>
                                <span style="font-size: 12px;"></span>
                            </div> 
                        </div>
                    </div> 
                </div><!--End div 1-->
                <%#CreateRows(2)%>
            </ItemTemplate>
            <FooterTemplate>
                    </div><!--end section row 1-->
            </FooterTemplate>
        </asp:Repeater>
