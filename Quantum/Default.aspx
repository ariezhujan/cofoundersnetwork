<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Quantum.Default3" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

        <section><!--start section 1-->
                <div class="slider fullscreen" >
                    <ul class="slides">
                        <li>
                            <img class="responsive-img" src="Co-founders Netwrok_files/road.jpg"> <!-- random image -->
                            <div class="caption top-align">
                             <div class="carousel-fixed-item center">
                            <span class=" hide-on-med-and-down ">
                            <div class="card hoverable white-text" style="background:rgba(0,0,0,.6); width: 600px; margin-left: 170px; padding-top: 30px; padding-bottom: 40px; margin-top: 120px" >
                            <h1 class=" center">Co-Founders Network</h1>
                                <h5 class="center">A new way of finding co-founders and connecting with investors. </h5> 
                                <h5 class="center">A fast way to get discovered and get funded.</h5>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="true">
                                        <ContentTemplate>        
                                            <asp:Panel CssClass="center" ID="pnlSignUp" runat="server" DefaultButton="btnSignup" style="margin-top:30px">
                                                <asp:button CssClass="btn-large waves-effect waves-light hoverable" style="margin-top: 10px;font-size: 20px;font-family:calibri;" runat="server" ID="btnSignup" Text="Start a free trial" OnClick="btnSignup_Click" />
                                            </asp:Panel>
                                        <asp:Literal runat="server" ID="litMessage"></asp:Literal>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            </span>
                            <span class=" hide-on-med-and-up ">
                            <div class="card hoverable" style="background:rgba(0,0,0,.6); width: 6; padding-top: 30px; padding-bottom: 40px; ">
                                <h1 class=" center">Co-Founders Network</h1>
                                   <h5 class="center">A new way of finding co-founders and connecting with investors. </h5> 
                                      <h5 class="center">A fast way to get discovered and get funded.</h5>
                                        <ContentTemplate>        
                                           <asp:Panel CssClass="center" ID="Panel1" runat="server" DefaultButton="btnSignup" style="margin-top:30px">
                                              <asp:button CssClass="btn-large waves-effect waves-light hoverable" style="margin-top: 10px;font-size: 18px;font-family:calibri;" runat="server" ID="Button1" Text="Start a free trial" OnClick="btnSignup_Click" />
                                            </asp:Panel>
                                            <asp:Literal runat="server" ID="Literal1"></asp:Literal>
                                        </ContentTemplate>
                            </div>
                            </span>
                            </div>
                            </div>
                        </li>
                        <li>
                            <img class="responsive-img" src="Co-founders Netwrok_files/slide2.jpg"> <!-- random image -->
                            <div class="caption left-align">
                             <div class="carousel-fixed-item center" style="margin-top: 120px">
                            <span class=" hide-on-med-and-down ">
                            <div class="card hoverable white-text" style="background:rgba(0,0,0,.6); width: 600px; margin-left: 170px; padding-top: 30px; padding-bottom: 40px;  margin-top: 120px">
                            <h1 class=" center">Co-Founders Network</h1>
                                <h5 class="center">A new way of finding co-founders and connecting with investors. </h5> 
                                <h5 class="center">A fast way to get discovered and get funded.</h5>
                                <ContentTemplate>        
                                           <asp:Panel CssClass="center" ID="Panel2" runat="server" DefaultButton="btnSignup" style="margin-top:30px">
                                              <asp:button CssClass="btn-large waves-effect waves-light hoverable" style="margin-top: 10px;font-size: 20px;font-family:calibri;" runat="server" ID="Button2" Text="Start a free trial" OnClick="btnSignup_Click" />
                                            </asp:Panel>
                                            <asp:Literal runat="server" ID="Literal2"></asp:Literal>
                                        </ContentTemplate>
                            </div>
                            </span>
                            <span class=" hide-on-med-and-up ">
                            <div class="card hoverable" style="margin-top:-100px; background:rgba(0,0,0,.6); width: 6; padding-top: 30px; padding-bottom: 40px; ">
                                <h1 class=" center">Co-Founders Network</h1>
                                   <h5 class="center">A new way of finding co-founders and connecting with investors. </h5> 
                                      <h5 class="center">A fast way to get discovered and get funded.</h5>
                                        <ContentTemplate>        
                                           <asp:Panel CssClass="center" ID="Panel3" runat="server" DefaultButton="btnSignup" style="margin-top:30px">
                                              <asp:button CssClass="btn-large waves-effect waves-light hoverable" style="margin-top: 10px;font-size: 18px;font-family:calibri;" runat="server" ID="Button3" Text="Start a free trial" OnClick="btnSignup_Click" />
                                            </asp:Panel>
                                            <asp:Literal runat="server" ID="Literal3"></asp:Literal>
                                        </ContentTemplate>
                            </div>
                            </span>
                            </div>
                            </div>
                        </li>
                        <li>
                        <img class="responsive-img" src="Co-founders Netwrok_files/slide3.jpg"> <!-- random image -->
                           <div class="caption right-align">
                             <div class="carousel-fixed-item center" style="margin-top: 120px">
                             <div class="carousel-fixed-item center" >
                            <span class=" hide-on-med-and-down ">
                            <div class="card hoverable white-text" style="background:rgba(0,0,0,.6); width: 600px; margin-left: 170px; padding-top: 30px; padding-bottom: 40px; margin-top: 120px">
                            <h1 class=" center">Co-Founders Network</h1>
                                <h5 class="center">A new way of finding co-founders and connecting with investors. </h5> 
                                <h5 class="center">A fast way to get discovered and get funded.</h5>
                                <ContentTemplate>        
                                           <asp:Panel CssClass="center" ID="Panel4" runat="server" DefaultButton="btnSignup" style="margin-top:30px">
                                              <asp:button CssClass="btn-large waves-effect waves-light hoverable" style="margin-top: 10px;font-size: 20px;font-family:calibri;" runat="server" ID="Button4" Text="Start a free trial" OnClick="btnSignup_Click" />
                                            </asp:Panel>
                                            <asp:Literal runat="server" ID="Literal4"></asp:Literal>
                                        </ContentTemplate>
                            </div>
                            </span>
                            <span class=" hide-on-med-and-up ">
                            <div class="card hoverable" style="background:rgba(0,0,0,.6);margin-top:-100px; width: 6; padding-top: 20px; padding-bottom: 40px; ">
                                <h1 class=" center">Co-Founders Network</h1>
                                   <h5 class="center">A new way of finding co-founders and connecting with investors. </h5> 
                                      <h5 class="center">A fast way to get discovered and get funded.</h5>
                                        <ContentTemplate>        
                                           <asp:Panel CssClass="center" ID="Panel5" runat="server" DefaultButton="btnSignup" style="margin-top:30px">
                                              <asp:button CssClass="btn-large waves-effect waves-light hoverable" style="margin-top: 10px;font-size: 18px;font-family:calibri;" runat="server" ID="Button5" Text="Start a free trial" OnClick="btnSignup_Click" />
                                            </asp:Panel>
                                            <asp:Literal runat="server" ID="Literal5"></asp:Literal>
                                        </ContentTemplate>
                            </div>
                            </span>
                            </div>
                            </div>
                        </li>
                        <li>
                        <img class="responsive-img"  src="Co-founders Netwrok_files/slide4.jpg"> <!-- random image -->
                           <div class="caption left-align">
                             <div class="carousel-fixed-item center" style="margin-top: 120px">
                            <span class=" hide-on-med-and-down ">
                            <div class="card hoverable white-text" style="background:rgba(0,0,0,.6); width: 600px; margin-left: 170px; padding-top: 30px; padding-bottom: 40px; margin-top: 120px ">
                            <h1 class=" center">Co-Founders Network</h1>
                                <h5 class="center">A new way of finding co-founders and connecting with investors. </h5> 
                                <h5 class="center">A fast way to get discovered and get funded.</h5>
                                <ContentTemplate>        
                                           <asp:Panel CssClass="center" ID="Panel6" runat="server" DefaultButton="btnSignup" style="margin-top:30px">
                                              <asp:button CssClass="btn-large waves-effect waves-light hoverable" style="margin-top: 10px;font-size: 20px;font-family:calibri;" runat="server" ID="Button6" Text="Start a free trial" OnClick="btnSignup_Click" />
                                            </asp:Panel>
                                            <asp:Literal runat="server" ID="Literal6"></asp:Literal>
                                        </ContentTemplate>
                            </div>
                            </span>
                            <span class=" hide-on-med-and-up ">
                            <div class="card hoverable" style="margin-top:-100px; background:rgba(0,0,0,.6); width: 6; padding-top: 30px; padding-bottom: 40px; ">
                                <h1 class=" center">Co-Founders Network</h1>
                                   <h5 class="center">A new way of finding co-founders and connecting with investors. </h5> 
                                      <h5 class="center">A fast way to get discovered and get funded.</h5>
                                        <ContentTemplate>        
                                           <asp:Panel CssClass="center" ID="Panel7" runat="server" DefaultButton="btnSignup" style="margin-top:30px">
                                              <asp:button CssClass="btn-large waves-effect waves-light hoverable" style="margin-top: 10px;font-size: 18px;font-family:calibri;" runat="server" ID="Button7" Text="Start a free trial" OnClick="btnSignup_Click" />
                                            </asp:Panel>
                                            <asp:Literal runat="server" ID="Literal7"></asp:Literal>
                                        </ContentTemplate>
                            </div>
                            </span>
                            </div>
                            </div>
                        </li>
                        </ul>
                </div>
    </section><!--end section 1-->

	<section><!--start section 2-->
			<div class="row center" style="font-family:calibri; margin-top: 600px; margin-bottom: 70px">
                <div class="container">
                    <div class="col s12">
                    <h1 class="black-text lighten-4" style="text-align:center">We will connect you with thousands of startup founders, aspiring entrepreneurs and investors in South East Asia. We focus on emerging markets and small-scale investments.</h1>
                    </div>
                </div>
				<div class="container" style="margin-top: 50px">
						<div class="col l4 s12">
							<h1><i class=" red-text large material-icons">card_travel</i></h1>
							<h4>No Co-Founder</h4>
							<p>
                                Starting a business is hard. Really hard. You have a great idea and get excited to launch it, your adrenaline is flowing but all the work, meetings and responsibilities can burn you out in just days. The probability of failure by working alone and taking all liabilities on yourself is high. But if you have a co-founding team, they take things off your shoulders you’ll have access to their network, they hold you accountable, they can let you take a break and join you in your startup journey.
                                <br /><br />
                                Our platform is easy to use, helpful for startup collaboration and co-founders can innovate. One can find a potential cofounder in days if the users’ needs are match right.
                            </p>
						</div>
						<div class="col l4 s12">
							<h1><i class=" red-text large material-icons">card_membership</i></h1>
							<h4>Lack Of Collaboration</h4>
							<p>
                                As your business begins to grow, you’ll face new challenges -- from hiring the right people to deciding on the best marketing strategy. However, hiring talents can be exhausting and takes a lot of time to process. You’ll need a solid network of experienced professionals to help you. But what if you don’t have a network or money to do all these things?
                                <br /><br />
                                Our platform will help startups and co-founders not just to offer partnership but also to allow them to collaborate in their project for short-term or long-term commitment. Our platform will have additional connections as well as competitive skills to help them face all the startup challenges. 
							</p>
						</div>
						<div class="col l4 s12">
							<h1><i class=" red-text large material-icons">card_giftcard</i></h1>
							<h4>No Investments</h4>
							<p>
                                The investments group is no longer only for the rich or “elite club”. The game in the business has changed and many people will be willing to invest from small amount of funds to large investments in exchange to equity and/or profit sharing. However, not many investment firms, network or websites are easy to gain access to investment. The process to pitch is long and to submit a pitch deck is expensive.
                                <br /><br />
                                Our platform was created to allow startups to be discovered, to pitch and get funded by the investors at affordable price. They can focus more on traction, sales and networking. 
							</p>
						</div>
			     </div>
			</div>

	<section><!--start section 3-->
	<div class="parallax-container" style="height:100%; font-family:calibri ;">
      <div class="parallax"><img style="-webkit-filter: grayscale(100%); filter:grayscale(100%);" class="responsive-img" src="Co-founders Netwrok_files/road.jpg"></div>
      <div class="container white-text darken-1 center" style="margin-top: 50px; margin-bottom: 50px;">
	  <div class="card hoverable" style="background:rgba(0,0,0,.6);padding-top: 30px; padding-bottom: 30px;">
        <h1>Co-Founders Network</h1>
					<h3>Why we exist ?</h3>
				<h5>The three (3) top reasons why startups fail are No Co-Founding Team, Lack Of Collaboration and No Investments. We created this platform to help startups find their co-founders, create an opportunity for strategic collaboration and potentially get funded by thousands of investors.</h5>
		</div>
      </div>
    </div>
    </section><!--end section 3-->

<%--	<section><!--start section 4-->
	<div class="container center" style="margin-top: 100px; margin-bottom: 30px">
		<div class="responsive-video" controls>
        <iframe width="720" height="405" src="https://www.youtube.com/embed/sY5MmhLQBng" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
      </div>
		</div>
	</section><!--End section 4-->--%>

	<section><!--start section 5-->
	<div class="row" style="margin-top: 70px; margin-bottom: 40px; ">
	    <div class="container">
			<div class="col m12 12">
				<h1 style="text-align: center; color: black;">HOW IT WORKS</h1>
			</div>
		</div>

		<div class="container" style="margin-top:50px">
			<div class="col m4 l4">
				<img style="margin-top:" class="responsive-img" src="./Co-founders Netwrok_files/duo-people.jpg">
			</div>
			<div class="col m4 l4">
				<p>
                    Co-Founders Network seeks to create a platform that connects aspiring and serial entrepreneurs, and investors in one platform. We strive to develop our business model to help users search co-founders who can potentially be a business partner, pitch to investors without going through unnecessary process and long-screening, and innovate. The possibilities are endless. 
                    <br /><br />
                    We strive to grow our business with quality, values, integrity and a lot of hard work to help co-founders like you to kickstart your business instead to drag a decision making or delaying a business launch just because you do not have a co-founder or investment. 
                </p>
			</div>
			<div class="col m4 l4">
				<img style="margin-top:" style="width:300px" class="responsive-img" src="./Co-founders Netwrok_files/maps-people.jpg">
			</div>
		</div>
	</div>
	</section><!--end section 5-->


</asp:Content>


