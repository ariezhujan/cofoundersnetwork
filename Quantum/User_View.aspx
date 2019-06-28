<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
        
     <form method="post" action="./User.aspx?id=19" id="form2">
    <div class="aspNetHidden">
    <input type="hidden" name="__EVENTTARGET" id="__EVENTTARGET" value="" />
    <input type="hidden" name="__EVENTARGUMENT" id="__EVENTARGUMENT" value="" />
    <input type="hidden" name="__VIEWSTATE" id="__VIEWSTATE" value="/wEPDwULLTExMjM3Mzk1NDMPZBYCZg9kFgICAQ9kFgYCAQ9kFgICAQ8WAh4EVGV4dAUKRWxpIEZhaXJvbmQCAw8WAh4HVmlzaWJsZWhkAgUPZBYcAgIPFgIfAAUKRWxpIEZhaXJvbmQCBA8WAh8ABUAxOS9qaWk1cS93aGF0c2FwcCBpbWFnZSAyMDE4MTEwNCBhdCAxMnRodW1iLjAxdGh1bWIuMDJ0aHVtYi5qcGVnZAIGDxYCHwAFCVNpbmdhcG9yZWQCCA8WAh8ABawDbSBpcHN1bSBkb2xvciBzaXQgYW1ldCwgY29uc2VjdGV0dXIgYWRpcGlzY2luZyBlbGl0LCBzZWQgZG8gZWl1c21vZCB0ZW1wb3IgaW5jaWRpZHVudCB1dCBsYWJvcmUgZXQgZG9sb3JlIG1hZ25hIGFsaXF1YS4gVXQgZW5pbSBhZCBtaW5pbSB2ZW5pYW0sIHF1aXMgbm9zdHJ1ZCBleGVyY2l0YXRpb24gdWxsYW1jbyBsYWJvcmlzIG5pc2kgdXQgYWxpcXVpcCBleCBlYSBjb21tb2RvIGNvbnNlcXVhdC4gRHVpcyBhdXRlIGlydXJlIGRvbG9yIGluIHJlcHJlaGVuZGVyaXQgaW4gdm9sdXB0YXRlIHZlbGl0IGVzc2UgY2lsbHVtIGRvbG9yZSBldSBmdWdpYXQgbnVsbGEgcGFyaWF0dXIuIEV4Y2VwdGV1ciBzaW50IG9jY2FlY2F0IGN1cGlkYXRhdCBub24gcHJvaWRlbnQsIHN1bnQgaW4gY3VscGEgcXVpIG9mZmljaWEgZGVzZXJ1bnQgbW9sbGl0IGFuaW0gaWRkAgoPFgIfAAUOVHJhbnNwb3J0YXRpb25kAgwPZBYCAiAPZBYEAgEPPCsACwIADxYIHghEYXRhS2V5cxYAHgtfIUl0ZW1Db3VudAICHglQYWdlQ291bnQCAR4VXyFEYXRhU291cmNlSXRlbUNvdW50AgJkATwrAAoBADwrAAQBABYEHwFnHgpIZWFkZXJUZXh0BQVTa2lsbBYCZg9kFgQCAQ9kFhRmD2QWAmYPFQEGQ29kaW5nZAIBD2QWAmYPFQEAZAICD2QWAmYPFQEAZAIDD2QWAmYPFQEAZAIED2QWAmYPFQEAZAIFD2QWAmYPFQEBMGQCBg9kFgJmDxUBATBkAgcPZBYCZg8V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" />
    </div>
    
    <script type="text/javascript">
    //<![CDATA[
    var theForm = document.forms['form2'];
    if (!theForm) {
        theForm = document.form2;
    }
    function __doPostBack(eventTarget, eventArgument) {
        if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
            theForm.__EVENTTARGET.value = eventTarget;
            theForm.__EVENTARGUMENT.value = eventArgument;
            theForm.submit();
        }
    }
    //]]>
    </script>
    
    
    <div class="aspNetHidden">
    
        <input type="hidden" name="__VIEWSTATEGENERATOR" id="__VIEWSTATEGENERATOR" value="38D9001F" />
        <input type="hidden" name="__EVENTVALIDATION" id="__EVENTVALIDATION" value="/wEdADUgLyxyn5i3PQqKc/nWzFB6m0cF6UJ36C8Ob8CzcS5DRFDw8C/CJ0Fk94vg+QfXyQKOgMTBIGt4UrlXAHMRnoyfvymjNxuFNLRjuIedAQo48qIa3MC9A3setT96xCMRjaI5fc9icTVgZyTkDCqikePGEOA0a7xMHpYwP5UFWzfiteRTGRNraWI0sWR7LEsVWiX3giYXVvTWRRFbYT0ZLF8KUbAMrTdwQaFkTGMpC4A0vVdJVVBSxpc927h2xERo1pHh+3dFRLAjIXgEqlzJMQOqoJTz6L2NnX2ToWrRBcIgKRyLKJi/PQncwonlhDMaDmyMr9OAzyxIL99bMCTyJ4kY/Oy7LQP5G7muh9sUrYSnXMgR++IVuunBS36+DzLlhlFPxQ92LJljaYR3s+3n6NliyNB/TRGGSU/ZVtuSxhbNyEg7T+wXkr0efau+UwudbaQ+Kz1Cy2AbUuW6XJ4u3PxAgi432nDjQ7xnnXARXyACuubBT82L1Fg+gbFz/n6+z7WQAgHinftVYf7L1ZPY9SLpHiENUlgAAAipKKKj7+Pp12ZKTxS07rQ+hZSXOUzHPk1PA4ZaSvVbhclhlBGAb03N6EtdQAKOuaPHkqvS+9yLlshy41zmUiySxPmCO4Uo0epcy/qHv8jaKfvXllRwuzAzughszTZ3QGGww9tX2oZaQCLp//vWlxc7yCjf8A85uQlq1Kt3zYk8RZ8tMDM1COwu+s9tCf3yCRWqsmYysVLK4i+YJNkoHPK0EmwD1T48Yw6CeoFXZKE386mu45mDcfjklFhK2LUJeOvx/l32Zeq05aCJrwP4EKv8f1/xU6Hbjg7XK/paUxtsEP6FznKU4K/Jd97AjcZ7VwSF/ftZ8qO5ZF+Io3BNOwdAGgjk0y5iThe0klifZeauhDRXqSJk8H7qWicJgudbpQ9pREzp6keJ4iJ/Pw8g3PD6pWJhii030+GEV1MEf3etxT6EMnYtCRXA+jDnnEUMkZmZahVHzj8HTTUb0rslFiuXYga32PVIVZvOi3zfojsHWxWYzqdff4/qYl3EQ+wfHUOudZPluAbU+EPbeowiRVFHbh/j9iDnD6nuJ+iugEAFHMVjFeGe6lNOvE1TLNcEpX5Uyjb3Po0L/ANS1N6EbpXtKXC7qCE01I9kAvow/dfvQuk0Le3LVLnL" />
    </div>
        <!-- Header -->
    
    <!--LOGIC USER-->

    <!--CONTENT-->
        
        
            <div style="clear: both;"></div>	
            <div class="container-fluid" style="width: 97%; border-radius: 10px; font-family: Courier; margin-top: 5px; background-color:rgb(240, 238, 238);color:black; height: 80px; text-align:right">
                <b><a href="user_welcome.aspx">Eli Fairon</a></b>
                (<a id="btnLogout" href="javascript:__doPostBack(&#39;ctl00$btnLogout&#39;,&#39;&#39;)">Sign out</a>)
           </div>

    <!--END LOGIC USER-->
               
             <div class="container">
                <div class="row">
                    <div class="col-md-12 col-xs-12">
                        <p style="text-align: center; font-size: 60px; padding-top: 50px;"><h1>eli Fairon</h1></p>
                    </div>
                </div>
            </div>

            <div class="container">
                <div class="row">
                    <div class="col-md-6 col-xs-12">
            <table id="lookup" class="table table-bordered table-hover table-striped">
                <thead>
                </thead>
                   <tbody>
                       <tr>
                           <th>image</th>
                           <td><img src="https://marketing.intercomassets.com/assets/customers/screens/invision-b0c1a49a90ac42dce5370e72b7ba9456273a7e01f60543b3aeacde1e4ab92cc5.jpg" class="img-responsive" alt="Portfolio"></td>
                       </tr>
                       <tr>
                           <th>Country</th>
                           <td>Singapore</td>
                       </tr>
                       <tr>
                           <th>About</th>
                           <td> m ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id</td>
                       </tr>
                            <th>Industry</th>
                            <td>Transportation</td>
                       <tr>
                        <tr>
                            <th>Skill</th>
                            <td>Coding <br> Marketing</td> 
                        </tr>

                       </tr>
                    </tbody>
                   </table>
                </div>

                    <div class="col-md-6 col-xs-12">
            <table id="lookup" class="table table-bordered table-hover table-striped">
                <thead>
                </thead>
                   <tbody>
                       <tr>
                           <th>Business Stage</th>
                           <td>Business Plan Created</td>
                       </tr>
                       <tr>
                           <th>Start-up Experience</th>
                           <td>2 YEARS</td>
                       </tr>
                       <tr>
                           <th>Certification</th>
                           <td> m ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id</td>
                       </tr>
                            <th>Institution</th>
                            <td>Certificate</td>
                       <tr>
                        <tr>
                            <td style="white-space:nowrap;">
                                    To Institution
                                </td><td style="white-space:nowrap;">
                                    To Certificate
                                 </td>
                        </tr>

                       </tr>
                    </tbody>
                   </table>
                </div>
            </div>
        </div>
      
     

</asp:Content>
