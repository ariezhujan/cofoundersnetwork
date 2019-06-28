<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThumbVideo.aspx.cs" Inherits="ThumbVideo" %>
<%@ OutputCache Duration="3600" VaryByParam="fileID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" src="/mediaplayer/jwplayer.js"></script>
</head>
<body style="border: 0px; margin: 0px;">
    <form id="form1" runat="server">
    <div>
        <center>
            <div id="container">Loading the player ...</div>
            <script type="text/javascript">
            jwplayer("container").setup({
            flashplayer: "/mediaplayer/player57.swf",
            file: "http://files.megaswf.com/<%=thumbVideo %>",
            autostart: true,
            image: "<%=videoFrame %>",
            height: "<%=height %>",width: "<%=width %>",
            controlbar: "none",
            repeat: 'always',
            displayclick: 'link',
            linktarget: '_top',
            link: '/s/<%=fileID %>'
            });
            </script>
        </center>
    </div>
    </form>
</body>
</html>
