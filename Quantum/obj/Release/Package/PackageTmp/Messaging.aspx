<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Messaging.aspx.cs" Inherits="Quantum.Messaging" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <%@ Import Namespace="QuantumLibrary" %>
    <asp:ScriptManager ID="ScriptManager2" runat="server" ScriptMode="Release"></asp:ScriptManager>


    <style>
        html, body
        {
            height: 100%;
        }
        .hide {
            display: none;
        }
        .img {
            max-width: 100%;
            border-radius: 100%;
        }

        .inbox_msg {
            border: 1px solid #c4c4c4;
            clear: both;
            overflow: hidden;
        }

        .top_spac {
            margin: 20px 0 0;
        }


        .recent_heading {
            float: left;
            width: 40%;
        }

        .srch_bar {
            display: inline-block;
            text-align: right;
            width: 60%;
        }

        .headind_srch {
            padding: 10px 29px 10px 20px;
            overflow: hidden;
            border-bottom: 1px solid #c4c4c4;
        }

        .recent_heading h4 {
            color: #05728f;
            font-size: 21px;
            margin: auto;
        }

        .srch_bar input {
            border: 1px solid #cdcdcd;
            border-width: 0 0 1px 0;
            width: 80%;
            padding: 2px 0 4px 6px;
            background: none;
        }

        .srch_bar .input-group-addon button {
            background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
            border: medium none;
            padding: 0;
            color: #707070;
            font-size: 18px;
        }

        .srch_bar .input-group-addon {
            margin: 0 0 0 -27px;
        }

        .chat_ib h5 {
            font-size: 15px;
            color: #464646;
            margin: 0 0 8px 0;
        }

            .chat_ib h5 span {
                font-size: 13px;
                float: right;
            }

        .chat_ib p {
            font-size: 14px;
            color: #989898;
            margin: auto;
        }

        .chat_img {
            float: left;
            width: 11%;
        }

        .chat_ib {
            float: left;
            padding: 0 0 0 15px;
            width: 88%;
        }

        .chat_people {
            overflow: hidden;
            clear: both;
        }

        .chat_list {
            border-bottom: 1px solid #c4c4c4;
            margin: 0;
            padding: 18px 16px 10px;
        }

        .inbox_chat {
            /*height: 400px;*/
            overflow-y: auto;
        }

        .active_chat {
            background: #ebebeb;
        }

        .incoming_msg_img {
            display: inline-block;
            width: 6%;
        }

        .out_msg_img {
            float: right;
            display: inline-block;
            width: 6%;
        }

        .received_msg {
            display: inline-block;
            padding: 0 0 0 10px;
            vertical-align: top;
            width: 92%;
        }

        .received_withd_msg p {
            background: #ebebeb none repeat scroll 0 0;
            border-radius: 3px;
            color: #646464;
            font-size: 14px;
            margin: 0;
            padding: 5px 10px 5px 12px;
            width: 60%;
        }

        .time_date {
            color: #747474;
            display: block;
            font-size: 12px;
            margin: 8px 0 0;
        }

        .sent_msg p {
            background: #05728f none repeat scroll 0 0;
            border-radius: 3px;
            font-size: 14px;
            margin: 0;
            color: #fff;
            padding: 5px 10px 5px 12px;
            width: 100%;
        }

        .outgoing_msg {
            overflow: hidden;
            margin: 26px 0 26px;
        }

        .sent_msg {
            float: right;
            width: 46%;
            margin-right: 10px;
        }

        .input_msg_write input {
            background: rgba(0, 0, 0, 0) none repeat scroll 0 0;
            border: medium none;
            color: #4c4c4c;
            font-size: 15px;
            min-height: 48px;
            width: 100%;
        }

        .type_msg {
            border-top: 1px solid #c4c4c4;
            position: relative;
        }

        .msg_send_btn {
            background: #05728f none repeat scroll 0 0;
            border: medium none;
            border-radius: 50%;
            color: #fff;
            cursor: pointer;
            font-size: 17px;
            height: 33px;
            position: absolute;
            right: 0;
            top: 11px;
            width: 33px;
        }

        .msg_history {
            height: 516px;
            overflow-y: auto;
        }
    </style>

    <asp:Literal runat="server" ID="litMessage" Visible="false">
        <h4>You have no conversations at present. Search for other users via the <a href="user_search.aspx">networking search</a> to start a dialogue. </h4>
    </asp:Literal>

    <div class="row" runat="server" id="divMessaging">
        <div class="container" style="margin-top: 50px">
            <div class="col s12 m6 l6">
                <div class="headind_srch">
                    <div class="recent_heading">
                        <h4>Recent</h4>
                    </div><!--end recent_heading-->
                    <div style="display:none;" class="srch_bar">
                        <div class="search-wrapper">
                            <input id="search" placeholder="Search"><i class="material-icons">search</i>
                            <div class="search-results"></div>
                        </div><!--end search-wrapper-->
                    </div><!--end srch_bar-->
                </div><!--End headind_srch-->
                <div class="inbox_chat">
                    <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                        <ProgressTemplate>           
                            <img alt="progress" src="img/ajax-loader.gif"/>           
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Repeater runat="server" ID="dgForumThreads">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="chat_list">
                                        <div class="chat_people">
                                        <div class="chat_img"> <img class="img" style="width:50px; height:50px;" src="<%#File.uploadedFilesDirectory + "\\" + Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "userImage").ToString(), "user_no_image.jpg")%>" alt=""></div>
                                        <div class="chat_ib">
                                            <h5 class="font-title">
                                                <a href='user.aspx?id=<%#DataBinder.Eval(Container.DataItem, "userid")%>''><%#DataBinder.Eval(Container.DataItem, "Title")%></a><span class="chat_date"><%#DataBinder.Eval(Container.DataItem, "LastComment")%></span></h5>
                                            <p class="black-text"><%#Data.maxStringDisplay(DataBinder.Eval(Container.DataItem, "LastCommentText"), 100)%></p>
                                            <span style="float:right;">
                                                <%--<a runat="server" onclick="document.getElementById('commentsDiv').scrollTop = elem.scrollHeight;" OnServerClick="btnThreadView_Click" name='<%#DataBinder.Eval(Container.DataItem, "id")%>' href='/Forum_Thread.aspx?ID=<%#DataBinder.Eval(Container.DataItem, "id")%>' style="height:100%; weidth:100%;border-radius: 100%; float:right" class="btn halfway-fab waves-effect teal darken-1"><i class="material-icons">chevron_right</i></a>--%>
                                                <asp:LinkButton runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "id")%>' OnClick="btnThreadView_Click" CssClass="btn halfway-fab waves-effect teal darken-1">></asp:LinkButton>
                                            </span>                                        
                                        </div><!--End chat_ib -->
                                        </div><!--End chat_people-->
                                    </div><!--End chat_list-->     
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div><!--End inbox_chat-->
            </div>
    
            <div class="col s12 m6 l6">
                <div style="overflow-y: scroll; height:410px;" id="commentsDiv">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Repeater runat="server" ID="dgComments">
                                <ItemTemplate>   
                                    <div class="outgoing_msg" <%#UserMessageAlignment(DataBinder.Eval(Container.DataItem, "username").ToString(), true)%>>
                                        <div class="out_msg_img"> 
                                            <img class="img" style="height:30px; width: 30px;" src="<%#File.uploadedFilesDirectory + "\\" + Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "image").ToString(), "user_no_image.jpg")%>" alt="">
                                        </div><!--End incoming_msg_img-->
                                        <div class="sent_msg">
                                            <p><%#DataBinder.Eval(Container.DataItem, "Comment")%></p>
                                            <span class="time_date"> <%#DataBinder.Eval(Container.DataItem, "createdDate")%></span>
                                        </div><!--End sent_msg-->
                                    </div><!--End outgoing_msg-->

                                    <div class="incoming_msg" <%#UserMessageAlignment(DataBinder.Eval(Container.DataItem, "username").ToString(), false)%>>
                                        <div class="incoming_msg_img"> 
                                            <img class="img" style="height:30px; width: 30px;" src="<%#File.uploadedFilesDirectory + "\\" + Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "image").ToString(), "user_no_image.jpg")%>" alt="">
                                        </div><!--End incoming_msg_img-->
                                        <div class="received_msg">
                                            <div class="received_withd_msg">
                                                <p><%#DataBinder.Eval(Container.DataItem, "Comment")%></p>
                                                <span class="time_date"> <%#DataBinder.Eval(Container.DataItem, "createdDate")%></span>
                                            </div><!--End received_withd_msg-->
                                        </div><!--End received_msg-->
                                    </div><!--End incoming_msg -->
                                </ItemTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="type_msg">
                    <div class="input_msg_write">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:HiddenField ID="hdnThreadID" runat="server" />
                                    <asp:Panel runat="server" DefaultButton="btnAdd">
                                        <asp:TextBox runat="server" ID="txtMessage" CssClass="write_msg" placeholder="Type a message"></asp:TextBox>
                                        <button runat="server" id="btnAddMessage" onServerClick="btnAddMessage_OnClick" class="msg_send_btn" type="button"><i class="fa fa-paper-plane-o" aria-hidden="true"></i></button>
                                        <asp:Button runat="server" ID="btnAdd" CssClass="hide" OnClick="btnAddMessage_OnClick" />
                                    </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div><!--End input_msg_write-->
                </div><!--type_msg-->
                <%--</div><!--end incoming_msg-->--%>
            </div>
        </div><!--End container-->
    </div><!--End row-->


     <script>
         function pageLoad() {
             //scroll to the bottom of the comments div
             var objDiv = document.getElementById("commentsDiv");
             objDiv.scrollTop = objDiv.scrollHeight;
             objDiv.focus();
         }
     </script>   
    
</asp:Content>
                        



<asp:Content ID="Content2" ContentPlaceHolderID="contentFooter" runat="server"></asp:Content>



