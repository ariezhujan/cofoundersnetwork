<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Project_Search.aspx.cs" Inherits="Quantum.Project_Search" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <%@ Import Namespace="QuantumLibrary" %>        

<asp:ScriptManager ID="ScriptManager1" runat="server" ScriptMode="Release"></asp:ScriptManager>

<!-- Page Layout here -->
   <div class="row container nav-wrapper">
        <div class=" col s12 m2 l2" style="max-width:290px;width:290px;margin-left:5px">
            <section style="line-height: 12px; margin-top: 50px; margin-left: 40px; margin-right: 20px;"><!--start section 1-->
                <!--Start to SideBar-->
                    <label style="font-size:17px; color:black">Country :</label>
                    <br />
                    <select runat="server" id="ddlCountry">
                        <option value="Any"></option>
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
                    <br /><br />
                    
                    <label style="font-size:17px; color:black" for="rblStartUpExperience">Experience :</label>
                    <br>
                    <select runat="server" id="rblStartUpExperience"  multiple>
                        <option Text="No Experience" Value="0"></option>
                        <option Text="1+ Start-up Created" Value="1"></option>
                        <option Text="2+ Start-ups Created" Value="2"></option>
                        <option Text="3+ Start-ups Created" Value="3"></option>
                        <option Text="4+ Start-ups Created" Value="4"></option>
                    </select>
                    <br /><br />
                    

                    <label style="font-size:17px; color:black">Age Range :</label>
                    <br />
                    <asp:DropDownList runat="server" ID="ddlAgeFrom" Width="50"></asp:DropDownList> <asp:DropDownList runat="server" ID="ddlAgeTo" Width="50"></asp:DropDownList>
                    <br /><br />


                    <label style="font-size:17px; color:black" for="rblStartUpExperience">Min. Investment (USD) :</label>
                    <br />
                    <asp:DropDownList runat="server" ID="ddlInvestmentAmountRequiredUSDFrom"></asp:DropDownList> <asp:DropDownList runat="server"  ID="ddlInvestmentAmountRequiredUSDTo"></asp:DropDownList> 
                    <br /><br />  
                  

                    <label style="font-size:17px; color:black" for="ss">Industry :</label>
                    <br>
                    <select runat="server" ID="rblIndustry" multiple></select>
                    <br /><br />



                    <label  style="font-size:17px; color:black" for="rblBusinessStage">Business Stage :</label>
                    <br>
                    <select runat="server" ID="rblBusinessStage" multiple></select>
                    <br /><br />


                 <br />
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate> 
                            <asp:Button id="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClick" CssClass="waves-effect waves-light btn" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </section>
      </div><!--end sideBar-->

      <div class="col s12 m10 l10"> 
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate> 

                            <style>
                                .card a:hover { text-decoration: none; }
                                .nowrap { white-space: nowrap; }
                            </style>

                            <asp:Literal runat="server" ID="litMessage"></asp:Literal>
                            <asp:Repeater runat="server" ID="dgProjects">
                            <ItemTemplate>  
                                <div class="col s12 m6 l4" style="margin-top: 20px;">
                                    <div class="card hoverable">
                                        <a href='/Project_View.aspx?ID=<%#DataBinder.Eval(Container.DataItem, "projectID")%>'>
                                            <div class="card-content" style="max-height:320px; height:320px"> 
                                            <div class="card-image">
                                                <img style="max-height:70px;height:70px;width:70px;max-width:70px;border-radius:100%" class="responsive-img" src='<%#File.uploadedFilesDirectory + "\\" + Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "userImage").ToString(), "user_no_image.jpg")%>' alt="Card image cap">
                                            </div>
                                                <h6 class="black-text"><%# DataBinder.Eval(Container.DataItem, "username")%></h6>
                                                <table>
                                                        <tbody class="responsive-table grey-text text-darken-2" style="font-size:13px">
                                                        <tr>
                                                        <h5 class="card-title black-text" style="max-height:200;"style="height:auto;"><%#Data.maxStringDisplay(DataBinder.Eval(Container.DataItem, "Name"), 30)%></h5>
                                                        </tr>
                                                        <tr>
                                                        <th>Industry</th><td>:&nbsp;<%# Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "Industry").ToString(), "n/a")%></td>
                                                        </tr>
                                                        <tr>
                                                        <th>Country</th><td>:&nbsp;<%# Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "Country").ToString(), "n/a")%></td>
                                                        </tr>
                                                        <tr>
                                                        <th class="nowrap">Min. Invest.</th><td>:&nbsp;$<%# String.Format("{0:n0}", DataBinder.Eval(Container.DataItem, "InvestmentAmountMinimumUSD"))%></td>
                                                        </tr>
                                                        <tr>
                                                        <th>Stage</th><td>:&nbsp;<%# Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "BusinessStage").ToString(), "n/a")%></td>
                                                        </tr>
                                                        </tbody>
                                                </table>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </ItemTemplate>
                    </asp:Repeater>

                    <asp:Repeater runat="server" ID="dgProjectsAdmin">
                    <HeaderTemplate>
                        <table>
                    </HeaderTemplate>
                    <ItemTemplate>    
                        <tr>
                            <td><%#Data.maxStringDisplay(DataBinder.Eval(Container.DataItem, "Name"), 30)%></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Country")%></td> 
                            <td><%# DataBinder.Eval(Container.DataItem, "Industry")%></td> 
                            <td><%# DataBinder.Eval(Container.DataItem, "BusinessStage")%></td> 
                            <td><%# DataBinder.Eval(Container.DataItem, "EditedDate")%></td> 
                            <td><a href="Project_View.aspx?ID=<%#DataBinder.Eval(Container.DataItem, "projectID")%>" class="btn btn-primary">View</a></td> 
                            <td>
                                <a href="User_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "userid")%>">
                                    <img style="border-radius: 50%; width:30px;height:30px;" src="<%#File.uploadedFilesDirectory + "\\" + Data.DefaultValueOnEmptyString(DataBinder.Eval(Container.DataItem, "userImage").ToString(), "user_no_image.jpg")%>" alt="Card image cap">
                                    <%# DataBinder.Eval(Container.DataItem, "username")%>                                         
                                </a>
                            </td> 
                            <td><a href="Project_Edit.aspx?id=<%#DataBinder.Eval(Container.DataItem, "projectID")%>" class="waves-effect waves-light btn text-white">Edit</a></a></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

                </ContentTemplate>
            </asp:UpdatePanel>
      </div>
    </div>
          
</asp:Content>
