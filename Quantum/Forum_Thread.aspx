<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Forum_Thread.aspx.cs" Inherits="Quantum.Forum_Thread" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" runat="server">
    <%@ Register TagPrefix="uc" TagName="BlogArticles" Src="UC_BlogArticles.ascx" %>
    <%@ Register TagPrefix="uc" TagName="HustlerArticles" Src="UC_HustlerArticles.ascx" %>


    <div class="container responsive-img">
        <div style="text-align: center;">
            <style>            
                .headerImage {
                    max-height: 600px;
                    max-height: 600px;
                }
            </style>
            <asp:Image runat="server" ID="imgThread" style="margin-top:20px" CssClass="responsive-img headerImage" />
            <br /><br />
            <h5 class="card-title center-align"><asp:Literal runat="server" ID="litTitle"></asp:Literal></h5>
            <hr class="cyan" style="width:100px">
        </div>
        <asp:Literal runat="server" ID="litComment" ></asp:Literal>
        <br /><br />
        <asp:Image runat="server" ID="imgUser" CssClass="circle responsive-img" Width="40" Height="40" /> <asp:HyperLink runat="server" id="hlUser"></asp:HyperLink>

        <br /><br />
        <a runat="server" id="linkEdit" visible="false" class="btn btn-secondary">Edit this post</a> 



        <div id="disqus_thread"></div>
        <script>

        /**
        *  RECOMMENDED CONFIGURATION VARIABLES: EDIT AND UNCOMMENT THE SECTION BELOW TO INSERT DYNAMIC VALUES FROM YOUR PLATFORM OR CMS.
        *  LEARN WHY DEFINING THESE VARIABLES IS IMPORTANT: https://disqus.com/admin/universalcode/#configuration-variables*/
        /*
        var disqus_config = function () {
        this.page.url = PAGE_URL;  // Replace PAGE_URL with your page's canonical URL variable
        this.page.identifier = PAGE_IDENTIFIER; // Replace PAGE_IDENTIFIER with your page's unique identifier variable
        };
        */
        (function() { // DON'T EDIT BELOW THIS LINE
        var d = document, s = d.createElement('script');
        s.src = 'https://cofoundersnetwork.disqus.com/embed.js';
        s.setAttribute('data-timestamp', +new Date());
        (d.head || d.body).appendChild(s);
        })();
        </script>
        <noscript>Please enable JavaScript to view the <a href="https://disqus.com/?ref_noscript">comments powered by Disqus.</a></noscript>
                            

            
        <uc:BlogArticles ID="ucBlogArticles" Visible="false" runat="server"></uc:BlogArticles>
        <uc:HustlerArticles ID="ucHustlerArticles" Visible="false" runat="server"></uc:HustlerArticles>

    </div>
</asp:Content>
