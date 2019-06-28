<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Suggestions.aspx.cs" Inherits="Suggestions" %>

<%@ Register TagPrefix="uc" TagName="Suggestions" Src="UC_Suggestions.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Suggestions</title>
    <link rel="stylesheet" type="text/css" href="css/view.css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc:Suggestions runat="server" />
    </form>
</body>
</html>
