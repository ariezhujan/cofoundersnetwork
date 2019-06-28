<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_HustlerArticles.ascx.cs" Inherits="Quantum.UC_HustlerArticles" %>
<%@ Import Namespace="QuantumLibrary" %>

    <section><!--Start Section 2-->
        <div class="row" style="color:Black">

            <asp:Repeater runat="server" ID="dgForumThreads">
                <HeaderTemplate>
                    <div class="container"><!--Start Row-->
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="col m3 l3 s12">
                        <a style="text-decoration-line: none" href="/Forum_Thread.aspx?ID=<%#DataBinder.Eval(Container.DataItem, "commentid")%>">        
                            <div class="card sticky-action hoverable" style="max-height:450px;height: 450px">
                                <div class="card-image waves-effect waves-block waves-light">
                                    <img class="responsive-img" src="<%#File.uploadedFilesDirectory + "\\" + Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "image").ToString(), "blog_no_image.jpg")%>" data-lazy-load="true" alt="" />
                                </div>
                                <div class="card-content">
                                    <span class="card-title activator grey-text text-darken-4"><%#DataBinder.Eval(Container.DataItem, "Title")%> </span>
                                    <p><%#Data.maxStringDisplay(Data.StripHTML(DataBinder.Eval(Container.DataItem, "LastCommentText").ToString()), 100)%></p>
                                </div>
                            </div>
                        </a>
                    </div>
                        
                    <%#CreateRows(4)%>           
                </ItemTemplate>
                <FooterTemplate>
                        </div><!--End row-->            
                </FooterTemplate>
            </asp:Repeater>        
            </div>
        </section><!--End Section 2 -->




        <style>
            .crop {
                width: 100%;
                max-height: 200px;
                overflow: hidden;
                object-fit: cover;
                border-radius: calc(.25rem - 1px);
            }
        </style>
        