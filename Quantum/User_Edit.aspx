<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User_Edit.aspx.cs" Inherits="Quantum.User_Edit"  enableEventValidation="false" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"></asp:ScriptManager>
    <%@ Register TagPrefix="uc" TagName="ObjectListValue" Src="UC_ObjectListValue.ascx" %>
    <%@ Register TagPrefix="uc" TagName="UserProjects" Src="UC_UserProjects.ascx" %>
    <%@ Import Namespace="QuantumLibrary" %> 
        
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
        <div class="container" style="margin-top: 50px"> 
            <div class="row">
                <div class="col s12">
                    <h2 class="card-title center-align">My Account</h2>
                    <a href="user.aspx?id=<%=GoalUser.CurrentUserId(Page) %>"><p class="card-title center-align"> View my Public Profile</p></a>
                    <hr class="cyan" style="width:100px">
                </div>
            </div>

            <div class="col s12 card"> <!-- Note that "m8 l9" was added -->
                <asp:Panel ID="pnlDetails" runat="server" DefaultButton="btnUpdate">
                    <div class="row">
                        <div class="col-sm-2" style="margin-top: 50px"><h5 class="black-text">Account Status</h5></div>
                        <div class="col-sm-10">
                            <b><asp:Literal runat="server" ID="litUserType"></asp:Literal></b>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txtEmail" class="col-sm-2 col-form-label">Email</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtEmail" placeholder="Email"></asp:TextBox>
                            <asp:Literal runat="server" ID="txtEmail_Empty" Visible="false"><span style="color: Red;">Please enter an email address.</span></asp:Literal>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txtName" class="col-sm-2 col-form-label">Name</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtName" placeholder="Name"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Email</label>
                        <div class="col-sm-10">
                            <asp:CheckBox runat="server" ID="chkAcceptEmail" Text="Accept emails from Co-Founders Network?"></asp:CheckBox>
                        </div>
                    </div>    
                    <div class="form-group row">
                        <label for="txtWebsite" class="col-sm-2 col-form-label">Website</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtWebsite" placeholder="e.g. http://www.google.com"></asp:TextBox>
                        </div>
                    </div>     
                    <div class="form-group row">
                        <label for="ddlCountry" class="col-sm-2 col-form-label">Country</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
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
                    </div>
                    <div class="form-group row">
                        <label for="txtWebsite" class="col-sm-2 col-form-label">Position</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:TextBox runat="server" ID="txtPosition" class="form-control" placeholder="CEO at Google since 2015"></asp:TextBox>
                        </div>
                    </div>       
                    <div class="form-group row">
                        <label for="txtAbout" class="col-sm-2 col-form-label">About</label>
                        <div class="col-sm-10">
                            <asp:TextBox CssClass="form-control" runat="server" ID="txtAbout" TextMode="MultiLine" Height="100"></asp:TextBox>
                            <script type="text/javascript">
                                //<![CDATA[
                                function pageLoad() { // this gets fired when the UpdatePanel.Update() completes
                                    $('#<%=txtAbout.ClientID%>').summernote({
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
                            </script>
                        </div>
                    </div>  
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Invest</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:CheckBox runat="server" ID="chkLookingToInvest" Text="Looking to Invest"></asp:CheckBox>
                        </div>
                    </div>   
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Amount</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:TextBox runat="server" ID="txtInvestmentAmountUSD" class="form-control" placeholder="Investment Amount USD" onkeypress="return isNumber(event)"></asp:TextBox>
                        </div>
                    </div>   
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Collaborate</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:CheckBox runat="server" ID="chkLookingToCollaborate" Text="Looking to Collaborate"></asp:CheckBox>
                        </div>
                    </div>   
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Hours</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:TextBox runat="server" ID="txtHoursToCollaborate" class="form-control" placeholder="Hours per Week Available" onkeypress="return isNumber(event)"></asp:TextBox>
                        </div>
                    </div> 
                    <div class="form-group row">
                        <label for="rblIndustry" class="col-sm-2 col-form-label">Primary Industry</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:RadioButtonList runat="server" ID="rblIndustry"></asp:RadioButtonList>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Industries Interested to Work In</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <uc:ObjectListValue ID="ucObjectListValue_Industries" runat="server" /> 
                        </div>
                    </div>     
                    <div class="form-group row ">
                        <label class="col-sm-2 col-form-label">Skills</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <uc:ObjectListValue ID="ucObjectListValue_Skills" runat="server" /> 
                        </div>
                    </div> 
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Business Stage</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:RadioButtonList runat="server" ID="rblBusinessStage"></asp:RadioButtonList>                        
                        </div>
                    </div>     
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Start-up Experience</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:RadioButtonList runat="server" ID="rblStartUpExperience">
                                <asp:ListItem Text="No Experience" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="1 Start-up Created" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2 Start-ups Created" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3 Start-ups Created" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4+ Start-ups Created" Value="4"></asp:ListItem>
                            </asp:RadioButtonList>  
                        </div>
                    </div>  
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Certification</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <uc:ObjectListValue ID="ucObjectListValue_Certification" runat="server" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Education</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <uc:ObjectListValue ID="ucObjectListValue_Education" runat="server" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label for="txtAge" class="col-sm-2 col-form-label">Age</label>
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:DropDownList runat="server" ID="ddlAge"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-10" style="max-width: 70%;width: 70%">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>           
                                    <asp:Button runat="server" ID="btnUpdate" Text="Save Changes" OnClick="btnUpdate_Click" class="btn btn-primary"/>
                                    <asp:Literal runat="server" ID="litUpdateMessage"></asp:Literal>
                                </ContentTemplate>
                            </asp:UpdatePanel>  
                            <asp:UpdateProgress runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                                <ProgressTemplate>           
                                    <img alt="progress" src="img/ajax-loader.gif"/>            
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <br />
                            <a href="User.aspx?id=<%=GoalUser.CurrentUserId(Page).ToString() %>">View my Public Profile</a>
                        </div>
                    </div>
                    <a name="anchorUploadPhoto"></a> 
                    <div class="text-center" runat="server" id="pnlDeleteUser" visible="false">
                        <asp:Button runat="server" id="btnDeleteUser" OnClick="btnDeleteUser_Click" Text="Delete User" OnClientClick="if ( ! confirm('Are you sure you want to delete this user?')) return false;" class="btn"></asp:Button>
                    </div>                  
                </asp:Panel> 
            </div><!--End Row Profile User Details-->

           
           
            <div class="row">
                <div class="col s12">
                    <section style="margin-top:10px"><!--Upload Picture-->
                        <div class="row">
                            <div class="col s12">
                                <div class="card hoverable" style="height:400px; max-height:400px; border-radius:5px">
                                    <div class="text-center">
                                        <br>
                                        <h5 class="font-title">Change Image</h5>
                                        <br>
                                        <asp:Image style="max-height:150px;height:150px;width:150px;max-width:150px;border-radius:100%" CssClass="responsive-img" runat="server" ID="imgUser" />
                                    </div>
                                    <br />
                                    <%@ Register TagPrefix="nup" Namespace="Brettle.Web.NeatUpload" Assembly="Brettle.Web.NeatUpload" %>
                                    <div class="file-field input-field" style="margin-left:50px; width: 300px">
                                        <div class="btn btn-primary">
                                            <span>File</span>
                                            <nup:InputFile id="FileUploader" runat="server" type="file"/>
                                        </div>
                                        <div class="file-path-wrapper">
                                            <input class="file-path validate" type="text">
                                        </div>                                        
                                    </div>
                                    <div style="padding-left: 10px;">
                                        <asp:Button CssClass="btn btn-primary" id="btnUpload" Width="90" Text="Upload" runat="server" OnClick="btnUpload_OnClick" /> 
                                        <asp:Literal runat="server" ID="litFileUploadMessage"/>
                                    </div>
                                </div> 
                            </div> 
                            <div class="col s12">
                                <div class="card hoverable center" style="height:400px; max-height:400px; border-radius:5px">  
                                    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnChangePassword">
                                        <br>
                                        <h5>Change Password</h5>
                                        <br>
                                        <asp:Literal runat="server" ID="litPasswordNeedsToChange" Visible="false"><span style="color: Red;">Due to system changes, please update your account password immediately.</span></asp:Literal>
                                        <label for="txtPassword" class="col-md-5 col-form-label">New Password</label>
                                        <asp:TextBox runat="server" style=" width: 300px" ID="txtPassword" TextMode="Password"></asp:TextBox>
                                        <br>
                                        <label for="txtPassword2" class="col-md-5 col-form-label">Confirm Password</label>
                                        <asp:TextBox style=" width: 300px" runat="server" ID="txtPassword2" TextMode="Password"></asp:TextBox>                                    
                                        <br>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>   
                                                <asp:Button runat="server" Text="Change Password" ID="btnChangePassword" OnClick="btnChangePassword_Click" CssClass="btn btn-primary"/>
                                                <br />
                                                <asp:Literal runat="server" ID="litPasswordMessage"></asp:Literal>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>                     
                    </section><!--End change Password--> 
                </div>
            </div><!--End row upload picture and password -->
         </div><!--End Container-->
</asp:Content>
