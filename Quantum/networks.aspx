
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Quantum.Default3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">


	<div style="width: 100%; height: 55px; z-index: 500;"></div>
	
	<!-- Connect popout -->
	<div id="app_network_connectpop" class="center_box" style="display: none; background: rgba(0, 0, 0, 0.48);">
		<input type="hidden" id="app_network_connectpop_id" />
		<div class="center_frame">
			<div class="row">
				<div class="col-md-4 col-sm-4 col-xs-1"></div>
				<div class="col-md-4 col-sm-4 col-xs-10 clean-straight-box" style="z-index: 4000; padding: 20px 10px 0px 10px; border-radius: 10px;">
					<div class="row">
						<div class="col-md-12 col-sm-12 cols-xs-12">
							<p>Do you want to connect with <span id="app_network_connectpop_name" style="font-weight: bold;"></span> ?</p>
							<hr/>
						</div>
						<div class="col-md-12 col-sm-12 cols-xs-12">
							<button class="contact_form_button" id="app_network_connectpop_view"> View Profile</button>
						</div>
					</div>
					<div class="row">
						<div class="col-md-6 col-sm-6 cols-xs-6">
							<button class="contact_form_button" style="background: #c52121; color: #fff;" id="app_network_connectpop_no"><i class="fa fa-times"></i> No</button>
						</div>
						<div class="col-md-6 col-sm-6 cols-xs-6">
							<button class="contact_form_button" style="background: #84ba25; color: #fff;" id="app_network_connectpop_yes"><i class="fa fa-check"></i> Yes</button>
						</div>
					</div>
				</div>
				<div class="col-md-4 col-sm-4 col-xs-1"></div>
			</div>
		</div>
	</div>
	
	<div style="width: 100%; padding: 30px;">
		<div class="row">
			<div class="col-md-4 col-xs-12">
				
				<div class="row">
					<div class="col-md-12">
						<h3 style="color: #17a6bd;">Network</h3>
						<input type="text" placeholder="Search Project" id="app_project_search" style="border: 1px solid #34a4ae; width: 70%; float: left; padding: 10px;" />
					</div>
				</div>
				
				<div class="row">
					<div class="col-md-12">
						<h3 style="color: #17a6bd; margin: 10px 0px;">Skill</h3>
						<div class="checkbox">
						  <label><input type="checkbox" value="Android Developer">Android Developer</label>
						</div>
						<div class="checkbox">
						  <label><input type="checkbox" value="Digital Marketing">Digital Marketing</label>
						</div>
						<div class="checkbox">
						  <label><input type="checkbox" value="UI / UX">UI / UX</label>
						</div>
					</div>
				</div>
				
				<div class="row">
					<div class="col-md-12">
						<h3 style="color: #17a6bd; margin: 10px 0px;">Country</h3>
						<select style="border: 1px solid #34a4ae; width: 70%; float: left; padding: 10px;">
							<option value="">Select Country</option>
						</select>
					</div>
				</div>
				
				<div class="row">
					<div class="col-md-12">
						<h3 style="color: #17a6bd; margin: 10px 0px;">City</h3>
						<select style="border: 1px solid #34a4ae; width: 70%; float: left; padding: 10px;">
							<option value="">Select City</option>
						</select>
					</div>
				</div>
				
				<div class="row">
					<div class="col-md-12">
						<h3 style="color: #17a6bd; margin: 10px 0px;">Industry</h3>
						<div class="checkbox">
						  <label><input type="checkbox" value="Accounting / Tax Services">Accounting / Tax Services</label>
						</div>
						<div class="checkbox">
						  <label><input type="checkbox" value="Banking / Finance">Banking / Finance</label>
						</div>
						<div class="checkbox">
						  <label><input type="checkbox" value="Consumer Products / FMCG">Consumer Products / FMCG</label>
						</div>
					</div>
				</div>
				
				<div class="row">
					<div class="col-md-12">
						<h3 style="color: #17a6bd; margin: 10px 0px;">Business Stage</h3>
						<div class="checkbox">
						  <label><input type="checkbox" value="Idea">Idea</label>
						</div>
						<div class="checkbox">
						  <label><input type="checkbox" value="Business Plan Created">Business Plan Created</label>
						</div>
						<div class="checkbox">
						  <label><input type="checkbox" value="Minimum Viable Product Created">Minimum Viable Product Created</label>
						</div>
						<div class="checkbox">
						  <label><input type="checkbox" value="Sales Generated">Sales Generated</label>
						</div>
					</div>
				</div>
				
				<div class="row">
					<div class="col-md-12">
						<h3 style="color: #17a6bd; margin: 10px 0px;">Startup Experience</h3>
						<div class="checkbox">
						  <label><input type="checkbox" value="No Experience">No Experience</label>
						</div>
						<div class="checkbox">
						  <label><input type="checkbox" value="1 Start-up created">1 Start-up created</label>
						</div>
						<div class="checkbox">
						  <label><input type="checkbox" value="2 - 3 Start-up created">2 - 3 Start-up created</label>
						</div>
						<div class="checkbox">
						  <label><input type="checkbox" value="4+ Start-up created">4+ Start-up created</label>
						</div>
					</div>
				</div>
				
			</div>
			<div class="col-md-8 col-xs-12" id="app_network_list">
				
			</div>
		</div>
	</div>
	
		
</asp:Content>
