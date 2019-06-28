<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_User_Bandwidth.ascx.cs" Inherits="UC_User_Bandwidth" %>

<asp:HiddenField runat="server" ID="hdnUserID" runat="server" />

<div style="text-align: left;">
    <b>Monthly</b>
    <br /><br />
    <asp:datagrid id="grdBandwidthMonthly" ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="black" EnableViewState="true" AutoGenerateColumns="false" runat="server" Width="500">
        <HeaderStyle CssClass="GridHeader"></HeaderStyle>
        <ItemStyle CssClass="GridItem"></ItemStyle>
        <AlternatingItemStyle CssClass="GridAltItem"></AlternatingItemStyle>
        <Columns>
	        <asp:TemplateColumn HeaderText="Bandwidth in MB (1GB = 1000MB)">
		        <ItemTemplate>
			        <%# DataBinder.Eval(Container.DataItem, "totalBandwidthMB", "{0:###,###,###}")%>
		        </ItemTemplate>
	        </asp:TemplateColumn>
	        <asp:BoundColumn DataField="month" HeaderText="month"></asp:BoundColumn>
	        <asp:BoundColumn DataField="year" HeaderText="year"></asp:BoundColumn>
        </Columns>
    </asp:datagrid>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>   
            <asp:Panel runat="server" DefaultButton="bandwidthSearch">
                <br /><br />
                <b>Bandwidth Usage Per File</b>
                <br />
                <table>
                    <tr>
                        <td style="width: 50px;">Year</td>
                        <td>
                            <asp:DropDownList Width="100" runat="server" ID="ddlYear"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Month</td>
                        <td>
                            <asp:DropDownList Width="100" runat="server" ID="ddlMonth"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button runat="server" ID="bandwidthSearch" OnClick="btnBandwidthSearch_Click" Text="Search" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>

            <br />

            <asp:datagrid id="grdBandwidth" ItemStyle-VerticalAlign="Top" ItemStyle-BorderStyle="Solid" ItemStyle-BorderWidth="1" ItemStyle-BorderColor="black" EnableViewState="true" AutoGenerateColumns="false" runat="server" Width="500">
                <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                <ItemStyle CssClass="GridItem"></ItemStyle>
                <AlternatingItemStyle CssClass="GridAltItem"></AlternatingItemStyle>
                <Columns>
	                <asp:TemplateColumn HeaderText="Bandwidth in MB">
		                <ItemTemplate>
			                <%# DataBinder.Eval(Container.DataItem, "BandwidthMB", "{0:###,###,###}")%>
		                </ItemTemplate>
	                </asp:TemplateColumn>
	                <asp:TemplateColumn HeaderText="Views">
		                <ItemTemplate>
			                <%# DataBinder.Eval(Container.DataItem, "Views", "{0:###,###,###}")%>
		                </ItemTemplate>
	                </asp:TemplateColumn>
	                <asp:TemplateColumn HeaderText="fileID">
		                <ItemTemplate>
			                <a href="/serve/<%# DataBinder.Eval(Container.DataItem,"objectID") %>"><%# DataBinder.Eval(Container.DataItem,"objectID") %></a>
		                </ItemTemplate>
	                </asp:TemplateColumn>
	                <asp:TemplateColumn HeaderText="File Size in KB">
		                <ItemTemplate>
			                <%# DataBinder.Eval(Container.DataItem, "filesize", "{0:###,###,###}")%>
		                </ItemTemplate>
	                </asp:TemplateColumn>
                </Columns>
            </asp:datagrid>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
