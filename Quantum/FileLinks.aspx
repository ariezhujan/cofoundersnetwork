<%@ Page Language="C#" MasterPageFile="~/MasterPage_MegaSWF.master" AutoEventWireup="true" CodeFile="FileLinks.aspx.cs" Inherits="FileLinks" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">

    <center>
        <div id="fb-root"></div><script src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script><fb:like-box href="http://www.facebook.com/pages/MegaSWF/118726804869152" width="292" show_faces="false" border_color="" stream="false" header="false"></fb:like-box>

        <br /><br />
        <h1><a href="/s/<%=fileID %>"><asp:Literal runat="server" ID="litFileName"></asp:Literal></a> has been uploaded</h1>
        <br />
        
        <a href="/User_Library_Edit.aspx?fileID=<%=fileID %>">Click here</a> to alter the meta data and display dimentions (height and width) of your file.
        <br /><br />
        
        <style>
            .input
            {
                width: 300px;
            }
        </style>

        <table width="600" border="0" cellpadding="5" style="background-color:#eee;border:1px solid #ccc;">
            <asp:PlaceHolder runat="server" ID="phLinks_Pro">
                <tr>
                    <td class="info">Direct link / full screen</td>
                    <td class="info">
                        <input class="input" type="text" size="50" readonly="true" onclick="javascript:this.select();" value="http://megaswf.com/file/<%=fileID %>">
                        <a href="http://loclhost.com/file/<%=fileID %>">View File</a>
                    </td>
                </tr>
                
                <asp:PlaceHolder runat="server" ID="phEmbedCode_SWF" Visible="false">
                    <tr>
                        <td class="info">Embed code for websites</td>
                        <td class="info">
                            <textarea class="input" rows="5" size="50" readonly="true" onclick="javascript:this.select();"><object type='application/x-shockwave-flash' data='http://megaswf.com/file/<%=fileID %>' width='<%=fileWidth.ToString() %>' height='<%=fileHeight.ToString() %>'><param name='movie' value='http://megaswf.com/file/<%=fileID %>' /></object></textarea>
                        </td>
                    </tr>
                </asp:PlaceHolder>
                <asp:PlaceHolder runat="server" ID="phEmbedCode_XAP" Visible="false">
                    <tr>
                        <td class="info">Embed code for websites</td>
                        <td class="info">
                            <textarea class="input" rows="5" size="50" readonly="true" onclick="javascript:this.select();"><iframe frameborder="0" scrolling="no" src="http://megaswf.com/ServeSilverlight.aspx?fileID=<%=fileID %>&fileWidth=<%=fileWidth.ToString() %>&fileHeight=<%=fileHeight.ToString() %>" width="<%=fileWidth.ToString() %>" height="<%=fileHeight.ToString() %>"></iframe></textarea>
                        </td>
                    </tr>
                </asp:PlaceHolder>
            </asp:PlaceHolder>
            
            <asp:PlaceHolder runat="server" ID="phLinks_NotPro" Visible="false">
                <tr>
                    <td class="info">Direct link</td>
                    <td class="info">
                        <input class="input" type="text" size="50" readonly="true" onclick="javascript:this.select();" value="http://megaswf.com/f/<%=fileID %>">
                    </td>
                </tr>
            </asp:PlaceHolder>
            
            <asp:PlaceHolder runat="server" ID="phLinks_NotPro_IsSWF" Visible="false">
                <tr>
		            <td class="info">Link</td>
		            <td class="info">
		                <input class="input" type="text" size="50" readonly="true" onclick="javascript:this.select();" value="http://megaswf.com/s/<%=fileID %>">
		                <a href="http://megaswf.com/s/<%=fileID %>">View</a>
		            </td>
	            </tr>
                <tr>
			        <td class="info"><b>Embed code</b> for websites</td>
			        <td class="info"><textarea class="input" rows="5" cols="50" size="40" readonly="true" onclick="javascript:this.select();"><iframe frameborder="0" scrolling="no" src="" id="megaswf"></iframe><script src="http://megaswf.com/ServeEmbedJS.aspx?fileID=<%=fileID %>&height=<%=fileHeight %>&width=<%=fileWidth %>&iframeID=megaswf" type="text/javascript"></script></textarea></td>
		        </tr>
                <tr>
			        <td class="info"><b>Embed code</b> for professional websites</td>
			        <td class="info"><a href="<%=upgradeLink %>" title="MegaSWF Pro Hosting">Click here</a></td>
		        </tr>
                <tr>
			        <td class="info">Direct link / Full screen</td>
			        <td class="info"><a href="<%=upgradeLink %>" title="MegaSWF Pro Hosting">Click here</a></td>
		        </tr>
		        <tr>
			        <td class="info">Remove ads / suggestions</td>
			        <td class="info"><a href="<%=upgradeLink %>" title="MegaSWF Pro Hosting">Click here</a></td>
		        </tr>
		    </asp:PlaceHolder>
        </table>
        
        <asp:PlaceHolder runat="server" ID="phDisplayDimentions" Visible="false">
        <br />
        <table width="600" border="0" cellpadding="5" style="background-color:#eee;border:1px solid #ccc;">
	        <tr>
		        <td class="info" style="width: 100px;">Display width</td>
		        <td class="info">
                    <asp:Literal runat="server" ID="litWidth"></asp:Literal>
                </td>
		    </tr>
		    <tr>
		        <td class="info">Display height</td>
		        <td class="info">
                    <asp:Literal runat="server" ID="litHeight"></asp:Literal>
                </td>
		    </tr>
		    <tr>
		        <td class="info"></td>
		        <td class="info">
                    These are the display dimentions which will be used for your file on the serve page. 
                    <br />
                    <a href="/User_Library_Edit.aspx?fileID=<%=fileID %>">Edit Settings</a>
                </td>
		    </tr>
	    </table>
	    </asp:PlaceHolder>
	    
	    
	    <asp:PlaceHolder runat="server" ID="phFLAFile" Visible="false">
	    <br />
	    <table width="600" border="0" cellpadding="5" style="background-color:#eee;border:1px solid #ccc;">
	        <tr>
		        <td class="info" style="width: 100px; vertical-align: top;"><b>FLA Files</b></td>
		        <td class="info">
                    Please upload your FLA file as an attachment to this SWF file so that other users can learn and build apon your work. 
                    <br /><br />
                    A library of FLA files is soon to be created and displayed on MegaSWF with your help.
                    <br /><br />
                    <a href="/?responseTo=<%=fileID %>">Upload an FLA file</a>
                </td>
		    </tr>
	    </table>
	    </asp:PlaceHolder>


    </center>
</asp:Content>

