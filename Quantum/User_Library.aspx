<%@ Page Language="C#" MasterPageFile="~/MasterPage_MegaSWF.master" AutoEventWireup="true" CodeFile="User_Library.aspx.cs" Inherits="User_Library" Title="Untitled Page" %>
<%@ Import Namespace="megaswfLibrary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">

    <div style="text-align: left;" runat="server" id="divFiles">
        <span style="font-size: xx-small;">Click the column headers to sort.</span>

        <asp:DataGrid CssClass="Grid" runat="server" ID="dgFiles" AutoGenerateColumns="false" BorderWidth="0" AllowSorting="true" OnSortCommand="DataGrid1_SortCommand">
            <HeaderStyle CssClass="GridHeader"></HeaderStyle>
            <ItemStyle CssClass="GridItem"></ItemStyle>
            <AlternatingItemStyle CssClass="GridAltItem"></AlternatingItemStyle>
            <Columns>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <img border="0" width="20" height="20" src='<%#File.DisplayImagePath(DataBinder.Eval(Container.DataItem, "image"))%>' />
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Title" SortExpression="Title" ItemStyle-Wrap="false" Visible="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "Title")%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Date Created" SortExpression="CreatedDate" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "CreatedDate")%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="File Name" SortExpression="Filename" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "Filename")%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Ext" SortExpression="Ext">
                    <ItemStyle HorizontalAlign="Center" />                
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "ext")%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Views" SortExpression="num_views">
                    <ItemStyle HorizontalAlign="Center" />                
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "num_views")%>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Like" SortExpression="count_like" Visible="false">
                    <HeaderTemplate><img src="/images/thumb_up.png" /></HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" />                
                    <ItemTemplate>
                        <span style="color: Green;"><%#DataBinder.Eval(Container.DataItem, "count_like")%></span>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn HeaderText="Dislike" SortExpression="count_dislike" Visible="false">
                    <HeaderTemplate><img src="/images/thumb_down.png" /></HeaderTemplate>
                    <ItemStyle HorizontalAlign="Center" />                
                    <ItemTemplate>
                        <span style="color: Red;"><%#DataBinder.Eval(Container.DataItem, "count_dislike")%></span>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <a href='/serve/<%#DataBinder.Eval(Container.DataItem, "id")%>/' target="_top">View</a>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <a href='/User_Library_Edit.aspx?fileID=<%#DataBinder.Eval(Container.DataItem, "id")%>' target="_top">Edit</a>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <a href='/filelinks/<%#DataBinder.Eval(Container.DataItem, "id")%>' target="_top">Embed</a>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" OnClick="btnDownload_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "id")%>'>DL</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" OnClick="btnDelete_Click" OnClientClick="if(!confirm('Delete this file?'))return false;" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "id")%>'>Delete</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
    </div>    
       
    
    <asp:Literal runat="server" ID="litNoFiles" Visible="false"><br /><br />No files found. <a href="/?Upload=1">Upload a file.</a></asp:Literal>

</asp:Content>

