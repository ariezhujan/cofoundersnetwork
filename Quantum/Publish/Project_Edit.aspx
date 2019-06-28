<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Project_Edit.aspx.cs" Inherits="Quantum.Project_Edit" enableEventValidation="false" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"></asp:ScriptManager>
<%@ Register TagPrefix="uc" TagName="ObjectListValue" Src="UC_ObjectListValue.ascx" %>
<%@ Register TagPrefix="uc" TagName="UserProjects" Src="UC_UserProjects.ascx" %>
<%@ Register TagPrefix="nup" Namespace="Brettle.Web.NeatUpload" Assembly="Brettle.Web.NeatUpload" %>
<%@ Import Namespace="QuantumLibrary" %>

    
       
            <asp:Panel runat="server" DefaultButton="btnUpdate">
                <div class="text-center" style="margin-top: 20px"><h1 class="font-title">Pitch Details</h1></div>
                <br>
                <div class="container" style="border-top:solid #cecece 1px;">
                    <br>
                    <div class="form-group">           
                        <label for="txtName">Name</label>
                        <asp:TextBox runat="server" ID="txtName" class="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">           
                        <label for="txtName">Summary</label>
                        <asp:TextBox runat="server" ID="txtSummary" class="form-control" placeholder="Short summary less than 100 characters." MaxLength="100"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="ddlCountry">Country</label>
                        <select runat="server" id="ddlCountry" data-live-search="true">
                                <option></option>
                                <option>Afghanistan</option>
                                <option>Akrotiri</option>
                                <option>Albania</option>
                                <option>Algeria</option>
                                <option>American Samoa</option>
                                <option>Andorra</option>
                                <option>Angola</option>
                                <option>Anguilla</option>
                                <option>Antarctica</option>
                                <option>Antigua and Barbuda</option>
                                <option>Argentina</option>
                                <option>Armenia</option>
                                <option>Aruba</option>
                                <option>Ashmore and Cartier Islands</option>
                                <option>Australia</option>
                                <option>Austria</option>
                                <option>Azerbaijan</option>
                                <option>Bahamas, The</option>
                                <option>Bahrain</option>
                                <option>Bangladesh</option>
                                <option>Barbados</option>
                                <option>Bassas da India</option>
                                <option>Belarus</option>
                                <option>Belgium</option>
                                <option>Belize</option>
                                <option>Benin</option>
                                <option>Bermuda</option>
                                <option>Bhutan</option>
                                <option>Bolivia</option>
                                <option>Bosnia and Herzegovina</option>
                                <option>Botswana</option>
                                <option>Bouvet Island</option>
                                <option>Brazil</option>
                                <option>British Indian Ocean Territory</option>
                                <option>British Virgin Islands</option>
                                <option>Brunei</option>
                                <option>Bulgaria</option>
                                <option>Burkina Faso</option>
                                <option>Burma</option>
                                <option>Burundi</option>
                                <option>Cambodia</option>
                                <option>Cameroon</option>
                                <option>Canada</option>
                                <option>Cape Verde</option>
                                <option>Cayman Islands</option>
                                <option>Central African Republic</option>
                                <option>Chad</option>
                                <option>Chile</option>
                                <option>China</option>
                                <option>Christmas Island</option>
                                <option>Clipperton Island</option>
                                <option>Cocos (Keeling) Islands</option>
                                <option>Colombia</option>
                                <option>Comoros</option>
                                <option>Congo, Democratic Republic of the</option>
                                <option>Congo, Republic of the</option>
                                <option>Cook Islands</option>
                                <option>Coral Sea Islands</option>
                                <option>Costa Rica</option>
                                <option>Cote d Ivoire</option>
                                <option>Croatia</option>
                                <option>Cuba</option>
                                <option>Cyprus</option>
                                <option>Czech Republic</option>
                                <option>Denmark</option>
                                <option>Dhekelia</option>
                                <option>Djibouti</option>
                                <option>Dominica</option>
                                <option>Dominican Republic</option>
                                <option>Ecuador</option>
                                <option>Egypt</option>
                                <option>El Salvador</option>
                                <option>Equatorial Guinea</option>
                                <option>Eritrea</option>
                                <option>Estonia</option>
                                <option>Ethiopia</option>
                                <option>Europa Island</option>
                                <option>Falkland Islands (Islas Malvinas)</option>
                                <option>Faroe Islands</option>
                                <option>Fiji</option>
                                <option>Finland</option>
                                <option>France</option>
                                <option>French Guiana</option>
                                <option>French Polynesia</option>
                                <option>French Southern and Antarctic Lands</option>
                                <option>Gabon</option>
                                <option>Gambia, The</option>
                                <option>Gaza Strip</option>
                                <option>Georgia</option>
                                <option>Germany</option>
                                <option>Ghana</option>
                                <option>Gibraltar</option>
                                <option>Glorioso Islands</option>
                                <option>Greece</option>
                                <option>Greenland</option>
                                <option>Grenada</option>
                                <option>Guadeloupe</option>
                                <option>Guam</option>
                                <option>Guatemala</option>
                                <option>Guernsey</option>
                                <option>Guinea</option>
                                <option>Guinea-Bissau</option>
                                <option>Guyana</option>
                                <option>Haiti</option>
                                <option>Heard Island and McDonald Islands</option>
                                <option>Holy See (Vatican City)</option>
                                <option>Honduras</option>
                                <option>Hong Kong</option>
                                <option>Hungary</option>
                                <option>Iceland</option>
                                <option>India</option>
                                <option>Indonesia</option>
                                <option>Iran</option>
                                <option>Iraq</option>
                                <option>Ireland</option>
                                <option>Isle of Man</option>
                                <option>Israel</option>
                                <option>Italy</option>
                                <option>Jamaica</option>
                                <option>Jan Mayen</option>
                                <option>Japan</option>
                                <option>Jersey</option>
                                <option>Jordan</option>
                                <option>Juan de Nova Island</option>
                                <option>Kazakhstan</option>
                                <option>Kenya</option>
                                <option>Kiribati</option>
                                <option>Korea, North</option>
                                <option>Korea, South</option>
                                <option>Kuwait</option>
                                <option>Kyrgyzstan</option>
                                <option>Laos</option>
                                <option>Latvia</option>
                                <option>Lebanon</option>
                                <option>Lesotho</option>
                                <option>Liberia</option>
                                <option>Libya</option>
                                <option>Liechtenstein</option>
                                <option>Lithuania</option>
                                <option>Luxembourg</option>
                                <option>Macau</option>
                                <option>Macedonia</option>
                                <option>Madagascar</option>
                                <option>Malawi</option>
                                <option>Malaysia</option>
                                <option>Maldives</option>
                                <option>Mali</option>
                                <option>Malta</option>
                                <option>Marshall Islands</option>
                                <option>Martinique</option>
                                <option>Mauritania</option>
                                <option>Mauritius</option>
                                <option>Mayotte</option>
                                <option>Mexico</option>
                                <option>Micronesia, Federated States of</option>
                                <option>Moldova</option>
                                <option>Monaco</option>
                                <option>Mongolia</option>
                                <option>Montserrat</option>
                                <option>Morocco</option>
                                <option>Mozambique</option>
                                <option>Namibia</option>
                                <option>Nauru</option>
                                <option>Navassa Island</option>
                                <option>Nepal</option>
                                <option>Netherlands</option>
                                <option>Netherlands Antilles</option>
                                <option>New Caledonia</option>
                                <option>New Zealand</option>
                                <option>Nicaragua</option>
                                <option>Niger</option>
                                <option>Nigeria</option>
                                <option>Niue</option>
                                <option>Norfolk Island</option>
                                <option>Northern Mariana Islands</option>
                                <option>Norway</option>
                                <option>Oman</option>
                                <option>Pakistan</option>
                                <option>Palau</option>
                                <option>Panama</option>
                                <option>Papua New Guinea</option>
                                <option>Paracel Islands</option>
                                <option>Paraguay</option>
                                <option>Peru</option>
                                <option>Philippines</option>
                                <option>Pitcairn Islands</option>
                                <option>Poland</option>
                                <option>Portugal</option>
                                <option>Puerto Rico</option>
                                <option>Qatar</option>
                                <option>Reunion</option>
                                <option>Romania</option>
                                <option>Russia</option>
                                <option>Rwanda</option>
                                <option>Saint Helena</option>
                                <option>Saint Kitts and Nevis</option>
                                <option>Saint Lucia</option>
                                <option>Saint Pierre and Miquelon</option>
                                <option>Saint Vincent and the Grenadines</option>
                                <option>Samoa</option>
                                <option>San Marino</option>
                                <option>Sao Tome and Principe</option>
                                <option>Saudi Arabia</option>
                                <option>Senegal</option>
                                <option>Serbia and Montenegro</option>
                                <option>Seychelles</option>
                                <option>Sierra Leone</option>
                                <option>Singapore</option>
                                <option>Slovakia</option>
                                <option>Slovenia</option>
                                <option>Solomon Islands</option>
                                <option>Somalia</option>
                                <option>South Africa</option>
                                <option>South Georgia and the South Sandwich Islands</option>
                                <option>Spain</option>
                                <option>Spratly Islands</option>
                                <option>Sri Lanka</option>
                                <option>Sudan</option>
                                <option>Suriname</option>
                                <option>Svalbard</option>
                                <option>Swaziland</option>
                                <option>Sweden</option>
                                <option>Switzerland</option>
                                <option>Syria</option>
                                <option>Taiwan</option>
                                <option>Tajikistan</option>
                                <option>Tanzania</option>
                                <option>Thailand</option>
                                <option>Timor-Leste</option>
                                <option>Togo</option>
                                <option>Tokelau</option>
                                <option>Tonga</option>
                                <option>Trinidad and Tobago</option>
                                <option>Tromelin Island</option>
                                <option>Tunisia</option>
                                <option>Turkey</option>
                                <option>Turkmenistan</option>
                                <option>Turks and Caicos Islands</option>
                                <option>Tuvalu</option>
                                <option>Uganda</option>
                                <option>Ukraine</option>
                                <option>United Arab Emirates</option>
                                <option>United Kingdom</option>
                                <option>United States</option>
                                <option>Uruguay</option>
                                <option>Uzbekistan</option>
                                <option>Vanuatu</option>
                                <option>Venezuela</option>
                                <option>Vietnam</option>
                                <option>Virgin Islands</option>
                                <option>Wake Island</option>
                                <option>Wallis and Futuna</option>
                                <option>West Bank</option>
                                <option>Western Sahara</option>
                                <option>Yemen</option>
                                <option>Zambia</option>
                                <option>Zimbabwe</option>
                            </select>
                        </div>
                    <div class="form-group">
                        <label for="txtDescription">Overview</label>
                        <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Height="150" class="form-control" placeholder="Describe the project at a high level."></asp:TextBox>
                        <script type="text/javascript">
                            //<![CDATA[
                            function pageLoad() { // this gets fired when the UpdatePanel.Update() completes
                                $('#<%=txtDescription.ClientID%>').summernote({
                                    tabsize: 2,
                                    height: 150,
                                    toolbar: [
                                        ['style', ['bold', 'italic', 'underline']],
                                        ['color', ['color']],
                                        ['para', ['ol', 'paragraph']],
                                        ['insert', ['link', 'picture', 'video', 'table', 'hr']]
                                    ]
                                });
                            }                                
                            //]]>

                            $('#<%=txtDescription.ClientID%>').summernote({
                                tabsize: 2,
                                height: 150,
                                toolbar: [
                                    ['style', ['bold', 'italic', 'underline']],
                                    ['color', ['color']],
                                    ['para', ['ol', 'paragraph']],
                                    ['insert', ['link', 'picture', 'video', 'table', 'hr']]
                                ]
                            });
                        </script>
                    </div>
                    <div class="form-group">
                        <label for="deliverables">Deliverables</label>
                        <asp:TextBox runat="server" ID="txtDeliverables" TextMode="MultiLine" Height="100" class="form-control" placeholder="What output will be project create?"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-md-4">     
                            <div class="form-group">
                                <label for="txtInvestmentAmountRequiredUSD">Investment Goal ($USD)</label>
                                <asp:TextBox runat="server" ID="txtInvestmentAmountRequiredUSD" class="form-control" onkeypress="return isNumber(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">     
                            <div class="form-group">
                                <label for="txtInvestmentAmountRequiredUSD">Investment Raised ($USD)</label>
                                <asp:TextBox runat="server" ID="txtInvestmentAmountRaisedUSD" class="form-control" onkeypress="return isNumber(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">     
                            <div class="form-group">
                                <label for="txtInvestmentAmountRequiredUSD">Minimum Investment Amount ($USD)</label>
                                <asp:TextBox runat="server" ID="txtInvestmentAmountMinimumUSD" class="form-control" onkeypress="return isNumber(event)"></asp:TextBox>
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
                            </div>
                        </div>
                        <div class="col-md-4"> 
                            <div class="form-group">
                                <label for="status">Project Status</label>
                                <asp:RadioButtonList runat="server" ID="ddlStatus">                              
                                    <asp:ListItem Value="Private" Text="Private"></asp:ListItem>
                                    <asp:ListItem Value="Public" Text="Public" Selected="true"></asp:ListItem>
                                </asp:RadioButtonList> 
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="txtUseOfFunds">Use Of Funds</label>
                        <asp:TextBox runat="server" ID="txtUseOfFunds" TextMode="MultiLine" Height="100" class="form-control" placeholder="How will the investment funds be used?"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="rac">Risks And Challenges</label>
                        <asp:TextBox runat="server" ID="txtRisksAndChallenges" TextMode="MultiLine" Height="100" class="form-control" placeholder="What could be difficult during the project?"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtFundingAim">Funding Aim</label>
                        <asp:TextBox runat="server" ID="txtFundingAim" TextMode="MultiLine" Height="100" class="form-control" placeholder="Is funding required to complete the project?"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="txtBusinessModel">Business Model</label>
                        <asp:TextBox runat="server" ID="txtBusinessModel" TextMode="MultiLine" Height="100" class="form-control" placeholder="How will the business create income?"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="pr">Positions Required</label>
                        <uc:ObjectListValue ID="ucObjectListValue_PositionsRequired" runat="server" />
                    </div>
                    <br>
                    <div class="form-group">
                        <label for="pr">Skills Required</label>
                        <uc:ObjectListValue ID="ucObjectListValue_SkillsRequired" runat="server" />
                    </div>
                    <br>
                    <div class="form-group">
                        <label for="industry">Industry</label>
                        <asp:RadioButtonList runat="server" ID="rblIndustry"></asp:RadioButtonList>
                  </div>
                    <div class="form-group">
                        <label for="bs">Business Stage</label>
                        <asp:RadioButtonList runat="server" ID="rblBusinessStage"></asp:RadioButtonList>
                  </div>        
                    <div class="form-group">
                        <label for="milestones">Milestones</label>
                        <uc:ObjectListValue ID="ucObjectListValue_Milestones" runat="server" />            
                    </div>

                    <br /><br />
                    <div class="text-center">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>   
                                <asp:Button runat="server" Text="Save Changes" ID="btnUpdate" OnClick="btnUpdate_Click"  class="btn btn-primary"/>
                                <asp:Literal runat="server" ID="litUpdateMessage"></asp:Literal>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                            <ProgressTemplate>           
                                <img alt="progress" src="img/ajax-loader.gif"/>            
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <br />
                        <a href='Project_View.aspx?id=<%=Request["id"].ToString()%>'>View Pitch</a>
                    </div>
                </div>

            </asp:Panel>
        
    <a name="anchorUploadFile"></a> 
    
    <br><br>
    <div class="container" style="border-top:solid #cecece 1px;">
        <br />
        <div class="row">
            <div class="col-md-1 col-12"><label for="file">File</label></div>
            <div class="col-md-8 col-12">
                <div class="custom-file mr-sm-2" id="file">
                    <nup:InputFile id="FileUploader" runat="server" />
                </div>
            </div>
            <div class="col-md-3 col-12">
                <asp:Button CssClass="btn" id="btnUpload" Text="Upload" runat="server" OnClick="btnUpload_OnClick" />
                <asp:Literal runat="server" ID="litFileUploadMessage" />
            </div>
        </div>
        <br>
        <asp:DataGrid UseAccessibleHeader="true" CssClass="table table-striped" BorderWidth="0" ItemStyle-BorderWidth="" runat="server" ID="dgFiles" AutoGenerateColumns="false" >
            <Columns>
                <asp:TemplateColumn HeaderText="Title" SortExpression="Title" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <a target="_blank" href='/<%=File.uploadedFilesDirectory %>/<%#DataBinder.Eval(Container.DataItem, "location")%>''><%#DataBinder.Eval(Container.DataItem, "FileName")%></a>
                    </ItemTemplate>
                </asp:TemplateColumn>  
                <asp:TemplateColumn HeaderText="Created" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "createdDate")%>
                    </ItemTemplate>
                </asp:TemplateColumn>  
                <asp:TemplateColumn HeaderText="File Size KBs" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "filesize")%>
                    </ItemTemplate>
                </asp:TemplateColumn>  
                <asp:TemplateColumn HeaderText="Thumbnail" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "image")%>
                    </ItemTemplate>
                </asp:TemplateColumn> 
                <asp:TemplateColumn HeaderText="Extension" ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <%#DataBinder.Eval(Container.DataItem, "ext")%>
                    </ItemTemplate>
                </asp:TemplateColumn>   
                <asp:TemplateColumn ItemStyle-Wrap="false">
                    <ItemTemplate>
                        <asp:Button runat="server" id="btnDeleteFile" OnClick="btnDeleteFile_Click" CommandArgument='<%#DataBinder.Eval(Container.DataItem, "id")%>' Text="Delete" OnClientClick="if ( ! UserDeleteConfirmation('Are you sure you want to delete this file?')) return false;"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateColumn>                 
            </Columns>            
        </asp:DataGrid>
    </div>

    <br>
    <div class="text-center">
        <asp:Button runat="server" id="btnDeleteProject" OnClick="btnDeleteProject_Click" Text="Delete Pitch" OnClientClick="if ( ! UserDeleteConfirmation('Are you sure you want to delete this pitch?')) return false;" class="btn"></asp:Button>
    </div>                             
                        
          
    <br /><br />
    <script>
        function UserDeleteConfirmation(message) {
            return confirm(message);
        }
    </script>

</asp:Content>
