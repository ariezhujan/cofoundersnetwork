<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="signup.aspx.cs" Inherits="Quantum.ds_signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<section style="background-image:url('Co-founders Netwrok_files/town-road.jpg'); background-size:cover; background:rgba('0,0,0,.10'); margin-bottom:-25px">
    <div class="row" style="margin-bottom: -20px;
">
      <div class="container" style="margin-top: 90px; margin-bottom:90px">
       <div class="col m4 l4 s12 offset-l4">
	      <div class="card hoverable" style="background:rgba(255, 255, 255, 0.6)">
	           <div class="card-content">
              <a class="brand-logo left" href="default.aspx"><img style="width:120px; margin-top:-10px" class="responsive-img" src="./Co-founders Netwrok_files/logo.png"></a>
                  <br>
                  <br>
                  <div class="form-field">
                     <i class="red-text text-darken-4 material-icons prefix">mail_outline</i>
                     <asp:TextBox placeholder="name@company.com"  CssClass="validate plc" runat="server" type="email" ID="txtEmail"></asp:TextBox>
                     <span class="helper-text" data-error="wrong" data-success="right"></span>
                     </div><br>
                  <div class="form-field">
                     <div class="form-field">
                     <i class="red-text text-darken-4 material-icons prefix">lock_outline</i>
                     <asp:TextBox CssClass="plc" placeholder="Password" runat="server" ID="txtPassword" TextMode="password"></asp:TextBox>
                     </div><br>
                     <div class="form-field">
                     <asp:button CssClass="btn btn-large" runat="server" ID="btnSignup" OnClick="btnSignup_Click" Text="Sign Up"/>
                     <br>
                     <asp:Literal runat="server" ID="litMessage"></asp:Literal>
                     <br>
                     <p class="grey-text text-darken-4 ">You have an account?<a class="teal-text text-darken-4" href="Login.aspx">&nbsp;Sign In</a></p>
                  </div>
               </div>
            </div>
        </div>
     </div>
    </div>
</section>
</asp:Content>

 
