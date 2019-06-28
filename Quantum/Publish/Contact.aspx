<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Quantum.Contact" %>
<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>

<asp:Content ID="ContentContact" runat="server" ContentPlaceHolderID="Content">

<section style="background-image:url('Co-founders Netwrok_files/cover-signup.jpg'); background-size:cover; margin-bottom:-25px">
		
		<div class="row" style="margin-bottom: -20px">
			<div class="col s12 l4 " style="background:rgba(255, 255, 255, 0.6)">
						<div class="grey-text text-darken-4" style=" margin-top:180px; margin-bottom:180px;">
						       <h4 class="center">Office Address:</h4>
								<p class="center">One Raffles Place Tower One<br/>
								#44-01A Singapore (048616)</p>
								<br>
								<h4 class="center">Tech Office</h4>
								<p class="center">Co-Founders Network, DS Office Tech Hub<br/>
								Semarang Plaza F1.1 No. 101<br/>
								JI. K.H. Agus Salim No.7 Kauman<br/>
								Semarang 50137</p>
					    </div>
			</div>
			<div class="col s12 l8  " style="padding: none; ">
				<div class="card hoverable" style="background:rgba(0,0,0,.6); margin-left:auto; margin-top:80px; margin-bottom:80px; width:70%; margin-right: auto">
				  <div class="card-content">
					<i class="white-text darken-4 material-icons prefix">mail_outline</i>
					
                    <%--<input type="text" class="white-text contact_form_input black-text" placeholder="Email Address" />--%>
                    <asp:TextBox runat="server" CssClass="white-text contact_form_input black-text" id="txtEmail" placeholder="Email Address"></asp:TextBox>

					<i class="white-text darken-4 material-icons prefix">account_circle</i>
					<%--<input type="text" class="white-text contact_form_input" placeholder="Your Name" />--%>
                    <asp:TextBox runat="server" CssClass="white-text contact_form_input" id="txtName" placeholder="Your Name"></asp:TextBox>

                    <select runat="server" id="ddlReason" class="white-text">
                        <option selected>General</option>
                        <option>Technical</option>
                        <option>Pricing</option>
                        <option>Feedback</option>
                    </select>

					<i class="white-text darken-4 material-icons prefix">mode_edit</i>
					<%--<textarea class="white-text materialize-textarea" data-length="120" placeholder="Your Message"></textarea>--%>
                    <asp:TextBox runat="server" CssClass="white-text materialize-textarea" MaxLength="120" id="txtMessage" TextMode="MultiLine" placeholder="Your Message"></asp:TextBox>
                    <div class="g-recaptcha" data-sitekey="6LfDgIAUAAAAAAHcUWqOXG2J3m_UA5YnAH8n1YRg" style="width: 70% !important"></div>

					<%--<button class="btn btn-large waves-efect">Send</button>--%>
                    <asp:Button CssClass="btn btn-large waves-efect" runat="server" ID="btnSend" OnClick="btnSend_Click" Text="Send" />
                      
                    <i class="white-text"><asp:Literal runat="server" ID="litMessage"></asp:Literal></i>
				  </div>
				</div>
			</div>
		</div>
</section>
</asp:Content>
