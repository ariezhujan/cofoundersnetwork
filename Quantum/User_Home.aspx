 <%-- @ Page Language="C#" ValidateRequest="false" MasterPageFile="~/MasterPage_MegaSWF.master" AutoEventWireup="true" CodeFile="User_Home.aspx.cs" Inherits="User_Home" Title="Untitled Page"--%>
 <%--@ Import Namespace="megaswfLibrary" --%>

<%-- @ Register TagPrefix="uc" TagName="UserBandwidth" Src="UC_User_Bandwidth.ascx" --%>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" Runat="Server">

<style>
    .inputBox
    {
        width: 200px;
    }
</style>

<div style="text-align:left;">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnChangePassword">
                <h2><p class="title">Change Password</p></h2>
                <hr />
                <asp:Literal runat="server" ID="litPasswordNeedsToChange" Visible="false"><span style="color: Red;">Due to system changes, please update your account password immediately.</span></asp:Literal>
                <table>
                    <tr>
                        <td style="width: 200px;">New Password</td>
                        <td>
                            <asp:TextBox CssClass="inputBox" runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Confirm Password</td>
                        <td>
                            <asp:TextBox CssClass="inputBox" runat="server" ID="txtPassword2" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button runat="server" Text="Change Password" ID="btnChangePassword" OnClick="btnChangePassword_Click" />
                            <asp:Literal runat="server" ID="litPasswordMessage"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        
            <asp:Panel runat="server" DefaultButton="btnUpdate">
                <h2><p class="title">My Account</p></h2>
                <hr />
                <table>
                    <tr>
                        <td style="width: 200px;">Account Status</td>
                        <td>
                            <b><asp:Literal runat="server" ID="litUserType"></asp:Literal></b>
                        </td>
                    </tr>
                    <tr>
                        <td>Username</td>
                        <td>
                            <b><asp:Literal runat="server" ID="litUsernameDisplay"></asp:Literal></b>
                        </td>
                    </tr>
                    <tr>
                        <td>Email</td>
                        <td>
                            <asp:TextBox CssClass="inputBox" runat="server" ID="txtEmail"></asp:TextBox>
                            <asp:Literal runat="server" ID="txtEmail_Empty" Visible="false"><span style="color: Red;">Please enter an email address.</span></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Name</td>
                        <td>
                            <asp:TextBox CssClass="inputBox" runat="server" ID="txtName"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Accept email from MegaSWF admin?</td>
                        <td>
                            <asp:CheckBox runat="server" ID="chkAcceptEmail" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="btnUpdate" runat="server" Text="Save Changes" OnClick="btnUpdate_Click" />
                            <asp:Literal runat="server" ID="litUpdateMessageProfile"></asp:Literal>
                        </td>
                    </tr>
                    
                </table>            
                
                <br />
                
                <asp:Panel ID="pnlPro" runat="server" Visible="false">
                    <h2><p class="title">Pro Account</p></h2>
                    <hr />
                    <table>
                        <tr>
                            <td style="width: 200px;">
                                Embed Whitelist
                                <br />
                                <span style="color: Gray; font-size: x-small;">Enter the domains permitted to embed your files when the privacy option 'Private + No Hotlink' is selected. (eg. megaswf.com) One per line.</span>
                            </td>
                            <td>
                                <asp:TextBox CssClass="inputBox" runat="server" Height="100" ID="txtEmbedWhitelist" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                
                <br />
                
                <a href="/users/<asp:Literal runat="server" ID="litUsername"></asp:Literal>">
                    <h2><p class="title">Public Profile</p></h2>
                </a>
                <hr />
                <table>
                    <tr>
                        <td>Age</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtAge"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px;">Website</td>
                        <td>
                            <asp:TextBox CssClass="inputBox" runat="server" ID="txtWebsite"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Country</td>
                        <td>
                            <asp:TextBox CssClass="inputBox" runat="server" ID="txtCountry"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>About</td>
                        <td>
                            <asp:TextBox CssClass="inputBox" runat="server" ID="txtAbout" TextMode="MultiLine" Height="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button runat="server" Text="Save Changes" OnClick="btnUpdate_Click" />
                            <asp:Literal runat="server" ID="litUpdateMessagePublicProfile"></asp:Literal>
                        </td>
                    </tr>
                </table>
                
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
        
    <br />
    <a name="upgrade" />
    <div runat="server" id="divUpgrade" visible="true">
        <a href="/upgrade"><h2>Upgrade Options</h2></a>
        <hr />
        
        Embed on your website without ads plus other features. <a href="/upgrade">Click here</a> to learn more.
        <br /><br />
		<center>
		  <table border=".5" cellpadding="0" cellspacing="0">
              <tr>
                <th align="center" scope="col">&nbsp;Streaming Plan&nbsp;</th>
                <th align="center"  scope="col">&nbsp;GB Transfer/Month&nbsp;</th>
                <th scope="col">&nbsp;GB Storage&nbsp;</th>
                <th scope="col">&nbsp;Overage Rate&nbsp;</th>
                <th scope="col">&nbsp;Price/Mo&nbsp;</th>
                <th scope="col"></th>
              </tr>
                <tr>
                <td colspan="6" bgcolor="#FFCC00">Standard Plans</td>
              </tr>
              <tr>
                <td>Level 1</td>
                <td>5GB</td>

                <td>10GB</td>
                <td>$3/GB</td>
                <td>$5</td>
                <td>
                    <a href="<%--=PayPal.URL(Page, PayPal.Pro_Month_1) --%>">Register</a><br />
                    <a href="<%--=PayPal.URL(Page, PayPal.Pro_Month_6) --%>">$27.50 6 months</a><br />
                    <a href="<%--=PayPal.URL(Page, PayPal.Pro_Month_12) --%>">$49.99 12 months</a>
                </td>
              </tr>
              <tr>
                <td>Level 2</td>
                <td>15GB</td>

                <td>20GB</td>
                <td>$3/GB</td>
                <td>$14.95</td>
                <td><a href="<%--=PayPal.URL(Page, PayPal.Pro_L2_Month_1) --%>">Register</a></td>
              </tr>
              <tr>
                <td>Level 3</td>
                <td>50GB</td>

                <td>40GB</td>
                <td>$3/GB</td>
                <td>$49.95</td>
                <td><a href="<%--=PayPal.URL(Page, PayPal.Pro_L3_Month_1) --%>">Register</a></td>
              </tr>
              <tr>
                <td colspan="6" bgcolor="#FFCC00">Enterprise Plans (an excellent value for larger projects)</td>
              </tr>

                <tr>
                <td>Enterprise 1</td>
                <td>150GB</td>
                <td>80GB</td>
                <td>$1/GB</td>
                <td>$99.95</td>
                <td><a href="<%--=PayPal.URL(Page, PayPal.Pro_E1_Month_1) --%>">Register</a></td>
              </tr>
              <tr>
                <td>Enterprise 2</td>
                <td>250GB</td>
                <td>120GB</td>
                <td>$1/GB</td>
                <td>$149.95</td>
                <td><a href="<%-- =PayPal.URL(Page, PayPal.Pro_E2_Month_1)--%>">Register</a></td>
              </tr>
              <tr>
                <td>Enterprise 3</td>
                <td>350GB</td>
                <td>160GB</td>
                <td>$1/GB</td>
                <td>$199.95</td>
                <td><a href="<%-- =PayPal.URL(Page, PayPal.Pro_E3_Month_1) --%>">Register</a></td>
              </tr>
              <tr>
                <td>Enterprise 4</td>
                <td>475GB</td>
                <td>200GB</td>
                <td>$1/GB</td>
                <td>$249.95</td>
                <td><a href="<%--=PayPal.URL(Page, PayPal.Pro_E4_Month_1) --%>">Register</a></td>
              </tr>
              <tr>
                <td>Enterprise 5</td>
                <td>600GB</td>
                <td>240GB</td>
                <td>$1/GB</td>
                <td>$299.95</td>
                <td><a href="<%--=PayPal.URL(Page, PayPal.Pro_E5_Month_1)--%>">Register</a></td>
              </tr>
              <tr>
                <td>Enterprise 6</td>
                <td>750GB</td>
                <td>280GB</td>
                <td>$1/GB</td>
                <td>$349.95</td>
                <td><a href="<%--=PayPal.URL(Page, PayPal.Pro_E6_Month_1)--%>">Register</a></td>
              </tr>
                <tr>
                <td colspan="6" bgcolor="#FFCC00">High Activity Plans (an exceptional value for very large projects)</td>
              </tr>
                <tr>
                <td>HA1</td>
                <td>1,500GB</td>
                <td>400GB</td>
                <td>$.50/GB</td>
                <td>$599.95</td>
                <td><a href="/help">Contact us</a></td>
              </tr>
                <tr>
                <td>HA2</td>
                <td>3,000GB</td>
                <td>800GB</td>
                <td>$.50/GB</td>
                <td>$999.95</td>
                <td><a href="/help">Contact us</a></td>
              </tr>
                <tr>
                <td>HA3</td>
                <td>6,000GB</td>
                <td>800GB</td>
                <td>$.50/GB</td>
                <td>$1,899.95</td>
                <td><a href="/help">Contact us</a></td>
              </tr>
                <tr>
                <td>HA4</td>
                <td>10,000GB</td>
                <td>800GB</td>
                <td>$.50/GB</td>
                <td>$2,699.95</td>
                <td><a href="/help">Contact us</a></td>
              </tr>  
                <tr>
                <td colspan="6" >Higher plans available. <a href="/help">Contact us</a> with your project requirements for pricing and details</td>
              </tr>
            </table>
        </center>
    </div>
    

</div>



</asp:Content>

