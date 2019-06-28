<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Chan.ascx.cs" Inherits="UC_Chan" %>
<%@ OutputCache Duration="120" VaryByParam="none" %>

<%@ Import Namespace="megaswfLibrary" %>

<div style="text-align: left;">    
    <div class="fm2-title">
        <span class="fm2-titleText">Recent Comments</span>
    </div>
           
    <asp:Repeater runat="server" ID="repComments">
        <HeaderTemplate>
            
        </HeaderTemplate>
        <ItemTemplate>
            <asp:PlaceHolder runat="server" ID="pnlFile" Visible='<%#IsType(DataBinder.Eval(Container.DataItem, "image"), true)%>'>
                <br clear=left><hr />
                <a href="/serve/<%#DataBinder.Eval(Container.DataItem, "fileid")%>/"><%#DataBinder.Eval(Container.DataItem, "title")%></a>
                <br>
                <a href="/serve/<%#DataBinder.Eval(Container.DataItem, "fileid")%>/">
                    <img src="<%#File.DisplayImagePath(DataBinder.Eval(Container.DataItem, "image"))%>" border=0 align=left width=120 height=90 hspace=20>
                </a>
                <span class="postername"><%#Comment.DisplayUsername(DataBinder.Eval(Container.DataItem, "username"))%></span> 
                <%#DataBinder.Eval(Container.DataItem, "createdDate")%>
                <blockquote><%#Data.nlToBr(DataBinder.Eval(Container.DataItem, "comment"))%></blockquote>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="pnlComment"  Visible='<%#IsType(DataBinder.Eval(Container.DataItem, "image"), false)%>'>
                <table>
                    <tr>
                        <td nowrap class="doubledash"></td>
                        <td class="reply">
                            &nbsp;&nbsp;&nbsp;
                            <span class="commentpostername"><%#Comment.DisplayUsername(DataBinder.Eval(Container.DataItem, "username"))%></span> 
                            <%#DataBinder.Eval(Container.DataItem, "createdDate")%>
                            <br>
                            <blockquote>
                                <%#Data.nlToBr(DataBinder.Eval(Container.DataItem, "comment"))%>
                            </blockquote>
                        </td>
                    </tr>
                </table>
            </asp:PlaceHolder>
        </ItemTemplate>
        <FooterTemplate>
            
        </FooterTemplate>
    </asp:Repeater>        

</div>

