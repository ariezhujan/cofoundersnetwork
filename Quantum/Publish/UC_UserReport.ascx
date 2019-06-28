<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_UserReport.ascx.cs" Inherits="Quantum.UC_UserReport" %>


            <asp:HiddenField runat="server" ID="hfUserID"></asp:HiddenField>
            <asp:HiddenField runat="server" ID="hfProjectID"></asp:HiddenField>
            <asp:Panel runat="server" ID="pnlReport">
                <a class="btn" id="report">Report this page as inappropriate</a>
    
                <div id="reportDiv" class="row">
                    <div class="col-md-6">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:TextBox CssClass="inputBox form-control" ID="txtMessage" runat="server" TextMode="MultiLine" Width="400" Height="100" placeholder="Write a message to alert support of the issue."></asp:TextBox>
                                <asp:Button CssClass="btn" runat="server" ID="btnReport" Text="Send Message" OnClick="btnReport_Click" />
                                <asp:Literal runat="server" ID="litContactMessage"></asp:Literal>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                            <ProgressTemplate>           
                                <img alt="progress" src="img/ajax-loader.gif"/>            
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>       

                <script>
                    $("#reportDiv").hide();
        
                    $(document).ready(function () {
                        $("#report").click(function () {
                            $("#reportDiv").show();
                            $("#report").hide();
                        });
                    });
                </script>
            </asp:Panel>
