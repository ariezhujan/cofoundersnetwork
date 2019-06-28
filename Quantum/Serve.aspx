<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/MasterPage_Serve.master" AutoEventWireup="true" CodeFile="Serve.aspx.cs" Inherits="Serve" Title="Untitled Page" %>
<%@ OutputCache Duration="60" VaryByParam="fileID" %>

<%@ Import Namespace="megaswfLibrary" %> 

<%@ Register TagPrefix="uc" TagName="Header" Src="UC_Header_Serve.ascx" %>
<%@ Register TagPrefix="uc" TagName="Comments" Src="UC_Comments.ascx" %>
<%@ Register TagPrefix="uc" TagName="Suggestions" Src="UC_Suggestions.ascx" %>
<%@ Register TagPrefix="uc" TagName="Chan" Src="UC_Chan.ascx" %>
<%@ Register TagPrefix="uc" TagName="RecentLikes" Src="UC_Recent_Likes.ascx" %>

<%@ Register TagPrefix="Upload" Namespace="Brettle.Web.NeatUpload"
             Assembly="Brettle.Web.NeatUpload" %>
            
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder_Header" Runat="Server">
    <asp:literal runat="server" id="Meta_Description"></asp:literal>
    <asp:literal runat="server" id="Meta_Keywords"></asp:literal>
    <asp:literal runat="server" id="Meta_Image"></asp:literal>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
        <asp:Panel runat="server" ID="pnlHeader">
            <uc:Header runat="server" Visible="false" />
            <br />
        </asp:Panel>
        
        <div id="swf">
        <table>
            <tr>
                <td style="vertical-align: top; text-align: center; width: 400px;">
                    
                    <asp:PlaceHolder runat="server" ID="phLikeButtonsTop" Visible="false">
                        <h2>
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnSimpleServeLike_Click" CommandArgument="true"><span style="color: Green">Like</span> <img src="/images/thumb_up.png" /></asp:LinkButton> |
                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btnSimpleServeLike_Click" CommandArgument="false"><span style="color: Red">Dislike</span> <img src="/images/thumb_down.png" /></asp:LinkButton> |
                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="btnSimpleServeLike_Click" CommandArgument="">Next -></asp:LinkButton>
                        </h2>
                    </asp:PlaceHolder>
            
                    <asp:PlaceHolder runat="server" ID="phUCServe"></asp:PlaceHolder>
        
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" Visible="false">
                        <ContentTemplate>
                            <div style="width: 550px; text-align:left;display:none;">
                                <span style="float: right; text-align: right; position: relative; top: -15px;">
                                    <i>
                                        <asp:LinkButton runat="server" ID="btnReport" OnClick="btnReport_Click">Report Adult / Inappropriate For Children</asp:LinkButton>
                                        <asp:Literal runat="server" ID="litReport"></asp:Literal>
                                    </i>
                                    &nbsp;&nbsp;|&nbsp;&nbsp;
                                    <a href="/?responseTo=<%=fileID %>">Post a file in response</a>
                                    &nbsp;&nbsp;|&nbsp;&nbsp;
                                    <span runat="server" id="spanEmbedLink" style="color: Blue; cursor: pointer;" onclick="embed();">Embed Code</span>
                                    <asp:LinkButton Visible="false" runat="server" ID="btnDownload" OnClick="btnDownload_Click">Download File</asp:LinkButton>
                                </span>
                                
                                <span style="position: relative; bottom: -5px;">
                                    <asp:LinkButton runat="server" OnClick="btnLike_Click" ID="btnLike">
                                        Like <img src="/images/thumb_up.png" />
                                    </asp:LinkButton>
                                     (<span style="color: Green;"><asp:Literal runat="server" ID="litCount_like">0</asp:Literal></span>)
                                    <asp:LinkButton runat="server" OnClick="btnDislike_Click" ID="btnDislike">
                                        <img src="/images/thumb_down.png" />
                                    </asp:LinkButton>
                                     (<span style="color: Red;"><asp:Literal runat="server" ID="litCount_dislike">0</asp:Literal></span>)
                                 </span>
                                 
                                 
                                 <div style="display:none;" id="divEmbed">
                                    <br />
                                    <b>Embed Code</b>
                                    <br />
                                    <textarea class="input" rows="5" cols="50" size="40" readonly="true" onclick="javascript:this.select();"><iframe frameborder="0" scrolling="no" src="" id="megaswf"></iframe><script src="http://megaswf.com/ServeEmbedJS.aspx?fileID=<%=fileID %>&height=<%=fileHeight %>&width=<%=fileWidth %>&iframeID=megaswf" type="text/javascript"></script></textarea>
                                 </div>
                                 <script>
                                    function embed()
                                    {
                                        document.getElementById('divEmbed').style.display = "block";
                                        document.getElementById('<%=spanEmbedLink.ClientID.ToString() %>').style.display = "none";
                                    }
                                </script>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>         
                        
                    <br />
                    <uc:Suggestions ID="SuggestionsUC" runat="server" />
                    
                    <asp:PlaceHolder runat="server" ID="phAds_Serve_Square" Visible="false">
                        <%--<br />
                        <script type="text/javascript"><!--
                        google_ad_client = "pub-0116731060988039";
                        /* 300x250, created 3/2/11 */
                        google_ad_slot = "3313246140";
                        google_ad_width = 300;
                        google_ad_height = 250;
                        //-->
                        </script>
                        <script type="text/javascript"
                        src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
                        </script>--%>
                    </asp:PlaceHolder>
                    
                    <br />
                    <table width='<%=fbCommentsWidth %>'><tr><td>
                    <table runat="server" id="tblChan"><tr><td>
                    <%--<uc:Chan ID="Chan" runat="server" />--%>
                    </td></tr></table>
                    </td></tr></table>
                </td>
                <td style="vertical-align: top; width: 250px;" runat="server" id="tdSuggestions">
                    <div id="fb-root"></div><script src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script><fb:like-box href="http://www.facebook.com/pages/MegaSWF/118726804869152" width="292" show_faces="false" border_color="" stream="false" header="false"></fb:like-box>
                    
                    <p runat="server" id="comments" visible="true">
                        <asp:PlaceHolder runat="server" ID="CommentsFB" Visible="true">
                            <uc:Comments ID="CommentsUC" runat="server" />
                        </asp:PlaceHolder>
                    </p>
                    
                    
                    <%--<br /><br />
                    <uc:RecentLikes ID="RecentLikes1" runat="server" />--%>
                </td>
            </tr>
        </table>
    </div>

    <br />
    <asp:PlaceHolder runat="server" ID="phAds_Serve" Visible="false">
        <%--<script type="text/javascript"><!--
        google_ad_client = "pub-0116731060988039";
        /* 728x90, created 12/17/10 */
        google_ad_slot = "7660820522";
        google_ad_width = 728;
        google_ad_height = 90;
        //-->
        </script>
        <script type="text/javascript"
        src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
        </script>--%>
    </asp:PlaceHolder>
    <asp:PlaceHolder runat="server" ID="phAds_SimpleServe" Visible="false">
        <%--<script type="text/javascript"><!--
        google_ad_client = "pub-0116731060988039";
        /* 728x90, created 11/24/10 */
        google_ad_slot = "9750694171";
        google_ad_width = 728;
        google_ad_height = 90;
        //-->
        </script>
        <script type="text/javascript"
        src="http://pagead2.googlesyndication.com/pagead/show_ads.js">
        </script>--%>
    </asp:PlaceHolder>


    
  </center> 
</asp:Content>

