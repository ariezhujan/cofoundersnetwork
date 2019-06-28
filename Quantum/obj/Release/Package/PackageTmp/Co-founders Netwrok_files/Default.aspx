<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Quantum.Default3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

 <div style="width: 100%; margin-top: 5px; z-index: 300;">
		<div class="row">

			<div class="col-md-6 col-xs-12" style="background-color:rgb(255, 255, 255); color: rgb(255, 255, 255); display: table; height: 470px;" id="app_homepage_left_banner">

				<div style="padding: 80px 30px; display: table-cell; vertical-align: top;">

					<h1 style="color:rgba(0, 0, 0, 0.884);size:200px; font-family:cursive">Co-Founders Network</h1>

					<h3 style="font-family:cursive;color:grey">Co-Founders Network is a platform that <a style="font-style:normal;font-family:cursive; color:#777;" href="login.aspx">connects</a></h3> <h3 style="font-family:cursive; color:grey">aspiring individuals in partnerships, projects and investments.</h3>
					<br />
					<br />
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                        <ContentTemplate>        
                            <asp:Panel ID="pnlSignUp" runat="server" DefaultButton="btnSignup">
								<asp:button CssClass="btn btn-primary hover" style="font-size: 20px;font-family:cursive;" ForeColor="#ffffff" runat="server" ID="btnSignup" Text="Start a free trial" OnClick="btnSignup_Click" />
								
                            </asp:Panel>
                            <br />
                            <asp:Literal runat="server" ID="litMessage"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>

				</div>

			</div>

			<div class="col-md-6 col-xs-12" style="background-color:rgb(255, 255, 255); position: relative; height: 470px;" id="app_homepage_right_banner">

				<!--<img src="img/standguy.png" style="max-width: 120px; position: absolute; bottom: 0px; right: 30px; z-index: 120;" />-->

				<img class="responsive-img" src="./Co-founders Netwrok_files/howwework_02.png">
			</div>

		</div>
	</div>

	<section style="margin-top: 20px" >
			<div class="header">
				<h3 style="text-align: center;font-family:cursive;color:grey">Trusted by the world’s most innovative businesses – big and small</h3>
		  
				<div class="row" style="padding-left: 80px">
						<div class="col-md-2 col-xs-12">
							<div style="margin-top: 25px;"><img src="./Co-founders Netwrok_files/why_cofounder.png"></div>
						</div>
						<div class="col-md-2 col-xs-12">
							<div style="margin-top: 25px;"><img src="./Co-founders Netwrok_files/why_colaborate.png"></div>
						</div>
						<div class="col-md-2 col-xs-12">
							<div style="margin-top: 25px;"><img src="./Co-founders Netwrok_files/why_investment.png"></div>
						</div>
						<div class="col-md-2 col-xs-12">
							<div style="margin-top: 25px;"><img src="./Co-founders Netwrok_files/why_colaborate.png"></div>
						</div>
						<div class="col-md-2 col-xs-12">
							<div style="margin-top: 25px;"><img src="./Co-founders Netwrok_files/why_investment.png"></div>
						</div>
						<div class="col-md-2 col-xs-12">
							<div style="margin-top: 25px;"><img src="./Co-founders Netwrok_files/why_cofounder.png"></div>
						</div>
						
			     </div>

			</div>
		  </section>

	<div class="Header" style="font-family:cursive; margin-top: 55px; background-color:rgb(240, 238, 238);color:#425255; height: 180px;">
		<div class="row">
			<div class="col-md-12 col-xs-12">
				<h1 style="text-align: center;">Why we exist ?</h1>
				<h3 style="text-align: center;">We created this platform to help startups find their cofounders, create an opportunity and collaborate in projects. Here's the top 3 reasons why start-up fails </h3>
			</div>
		</div>
	</div>
	
	<div class="container" style="margin-top: 55px;">
		<div class="row">
			<div class="col-md-4 col-xs-12">
				<h4 style="text-align: center; color: #777; margin-top: 30px;">No Co-Founder</h4>
				<center style="margin-top: 25px;"><img src="./Co-founders Netwrok_files/why_cofounder.png"></center>
				<p style="text-align: center; margin-top: 25px;">Starting a business is hard. Really hard. You have a great idea and get excited to launch it, the adrenaline is flowing but all the work, meetings and responsibilities can burn you out within days. The probability of failure...</p><br>
			</div>
			
			<div class="col-md-4 col-xs-12">
				<h4 style="text-align: center; color: #777; margin-top: 30px;">Lack of collaboration</h4>
				<center style="margin-top: 25px;"><img src="./Co-founders Netwrok_files/why_colaborate.png"></center>
				<p style="text-align: center; margin-top: 25px;">As your business begins to grow, you will always face new challenges, from hiring the right people to deciding on the best marketing strategy. To hire talents can be exhausted, and takes a lot of time in decision making....</p><br>
			</div>
			
			<div class="col-md-4 col-xs-12">
				<h4 style="text-align: center; color: #777; margin-top: 30px;">No investments</h4>
				<center style="margin-top: 25px;"><img src="./Co-founders Netwrok_files/why_investment.png"></center>
				<p style="text-align: center; margin-top: 25px;">The investments network is no longer for the rich or 'elite club'. The game in the business has changed and many people will be willing to invest from small amount of funds to large investments in exchange...</p><br>
			</div>
	  </div>
	</div>
	
	<div class="container" style="margin-top: 55px;">
		<div class="row">
			<div class="col-md-12 col-xs-12">
				<h1 style="text-align: center; color: #17a6bd;">HOW WE WORK</h1>
			</div>
		</div>
	</div>
	
	<div class="container" style="margin-top: 55px;">
		<div class="row">
			<div class="col-md-7 col-xs-12">
				<div class="row">
					<div class="col-md-5 col-xs-12" style="position: relative; height: 470px; display: block;" id="app_homepage_left_how">
						<img src="./Co-founders Netwrok_files/howwework_01.png" style="position: absolute; top: 0px; left: 0px; max-width: 700px;">
					</div>
					<div class="col-md-7 col-xs-12">
						<p style="margin-top: 40px;">Co-Founders Network seeks to create a platform that connects aspiring and serial entrepreneurs and investors in one platform. We strive to develop our business model to help our users connect, engage and innovate regardless of where they come from, what kind of industry they work and how much equity or funds they can offer. We strive to grow our business with values, honesty, integrity and a lot of hard work. </p>
					</div>
				</div>
			</div>
			<div class="col-md-5 col-xs-12">
				<center><img src="./Co-founders Netwrok_files/howwework_02.png" style="width: 100%; margin-top: 60px;"></center>
			</div>
		</div>
	</div>
	


</asp:Content>

