<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_ObjectListValue.ascx.cs" Inherits="Quantum.UC_ObjectListValue" %>
<%@ Import Namespace="QuantumLibrary" %>


 
        <asp:HiddenField runat="server" ID="hfObjectID"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hfObjectType"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hfValueType"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hflistValueID1_Name"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hflist1IncPreviouslyUsed"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hflist1"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hflistValueID2_Name"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hflist2IncPreviouslyUsed"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hflist2"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hfstringValue1_Name"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hfstringValue2_Name"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hfstringValue3_Name"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hfintValue1_Name"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hfintValue2_Name"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hfdecValue1_Name"></asp:HiddenField>
        <asp:HiddenField runat="server" ID="hfdateValue1_Name"></asp:HiddenField>


        <asp:Panel runat="server" ID="pnlObjectListValue">
            <table>
                <tr>
                    <td>
                        <asp:Literal runat="server" ID="litValues"></asp:Literal>
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:DataGrid ItemStyle-BorderWidth="0" UseAccessibleHeader="true" CssClass="table table-striped" BorderWidth="0" runat="server" ID="dgValues" AutoGenerateColumns="false" >
                                    <Columns>
                                        <asp:TemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "listValue1")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn> 
                                        <asp:TemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "listValue2")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>  
                                        <asp:TemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "stringValue1")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>  
                                        <asp:TemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "stringValue2")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>  
                                        <asp:TemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "stringValue3")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>  
                                        <asp:TemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "intValue1")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>  
                                        <asp:TemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "intValue2")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>  
                                        <asp:TemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "decValue1")%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>  
                                        <asp:TemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <%#Data.formatDateTime(DataBinder.Eval(Container.DataItem, "dateValue1"))%>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>  
                                        <asp:TemplateColumn Visible="false">
                                            <ItemTemplate>
                                                <asp:Button CssClass="btn" runat="server" id="btnDelete" OnClick="btnDelete_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "id")%>' Text="Delete"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>                                       
                                    </Columns>            
                                </asp:DataGrid>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:Panel runat="server" ID="pnlInput" DefaultButton="btnAdd" Visible="false">
                            <table>
                                <tr runat="server" id="trList1">
                                    <td><label><asp:Literal runat="server" ID="litListTitle1"></asp:Literal></label></td>
                                    <td>                            
                                        <asp:RadioButtonList CssClass="" runat="server" ID="s" Visible="false"></asp:RadioButtonList>
                                        <select runat="server" ID="ddlList1" Visible="false"></select>
                                        <asp:Literal runat="server" ID="litMessageddlList1"></asp:Literal>
                                    </td>
                                </tr>
                                <tr runat="server" id="trList2">
                                    <td><label><asp:Literal runat="server" ID="litListTitle2"></asp:Literal></label></td>
                                    <td>
                                        <asp:RadioButtonList CssClass="" runat="server" ID="ss" Visible="false"></asp:RadioButtonList>
                                        <select runat="server" ID="ddlList2"  Visible="false"></select>
                                        <asp:Literal runat="server" ID="litMessageddlList2"></asp:Literal>
                                    </td>
                                </tr>
                                <tr runat="server" id="trString1">
                                    <td><label><asp:Literal runat="server" ID="litStringTitle1"></asp:Literal></label></td>
                                    <td><asp:TextBox CssClass="form-control mr-1" runat="server" ID="txtStringValue1"></asp:TextBox></td>
                                </tr>
                                <tr runat="server" id="trString2">
                                    <td><label><asp:Literal runat="server" ID="litStringTitle2"></asp:Literal></label></td>
                                    <td><asp:TextBox CssClass="form-control mr-1" runat="server" ID="txtStringValue2"></asp:TextBox></td>
                                </tr>
                                <tr runat="server" id="trString3">
                                    <td><label><asp:Literal runat="server" ID="litStringTitle3"></asp:Literal></label></td>
                                    <td><asp:TextBox CssClass="form-control mr-1" runat="server" ID="txtStringValue3"></asp:TextBox></td>
                                </tr>
                                <tr runat="server" id="trInt1">
                                    <td><label><asp:Literal runat="server" ID="litIntTitle1"></asp:Literal></label></td>
                                    <td>
                                        <input type="text" class="form-control mr-1" runat="server" id="txtIntValue1"  onkeypress="return isNumber(event)"/>
                                        <asp:RegularExpressionValidator ID="revIntValue1" Enabled="false"
                                            ControlToValidate="txtIntValue1" runat="server"
                                            ErrorMessage="Enter numbers only. e.g. 5000"
                                            ValidationExpression="\d+">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr runat="server" id="trInt2">
                                    <td><label><asp:Literal runat="server" ID="litIntTitle2"></asp:Literal></label></td>
                                    <td>
                                        <input type="text" class="form-control mr-1" runat="server" id="txtIntValue2" onkeypress="return isNumber(event)"/>
                                        <asp:RegularExpressionValidator ID="revIntValue2" Enabled="false"
                                            ControlToValidate="txtIntValue2" runat="server"
                                            ErrorMessage="Enter numbers only. e.g. 5000"
                                            ValidationExpression="\d+">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr runat="server" id="trDec1">
                                    <td><label><asp:Literal runat="server" ID="litDecTitle1"></asp:Literal></label></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control mr-1" runat="server" ID="txtDecValue1"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" Enabled="false"
                                            ControlToValidate="txtDecValue1" runat="server"
                                            ErrorMessage="Enter numbers only. e.g. 5000"
                                            ValidationExpression="^[1-9]\d*(\.\d+)?$">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr runat="server" id="trDate1">
                                    <td><label><asp:Literal runat="server" ID="litDateTitle1"></asp:Literal></label></td>
                                    <td>
                                        <asp:TextBox CssClass="form-control mr-1" runat="server" ID="txtDateValue1"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                            <script type="text/javascript">     
                                function isNumber(evt) {
                                    evt = (evt) ? evt : window.event;
                                    var charCode = (evt.which) ? evt.which : evt.keyCode;
                                    if ( (charCode > 31 && charCode < 48) || charCode > 57) {
                                        return false;
                                    }
                                    return true;
                                }
                            </script>
                            <!--<script>
                                function pageLoad() {
                                    $(document).ready(function () {
                                        $('.selectpicker').selectpicker();
                                    });
                                }
                            </script>-->
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>  
                                    <asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click" CssClass="btn" />
                                    <asp:Literal runat="server" ID="litMessage"></asp:Literal>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </td>
                </tr>
            </table>         
        </asp:Panel>
    

