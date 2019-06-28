<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.Master" AutoEventWireup="true" CodeBehind="#" Inherits="Quantum.Default3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

        <link href="//netdna.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">

        <style type="text/css">
            .container {
               overflow: hidden;
             }
     
            .filterDiv {
               color: black;
               text-align: center;
               display: none; /* Hidden by default */ 
             }
     
           /* The "show" class is added to the filtered elements */
             .show {
               display: block;
             }
     
         </style>
         </head>
         <body>
     
             <!--COL 1-->
             <section>
                 <div class="container-fluid" style="text-align: center; margin-top: 70px; margin-bottom: 70px; font-family:calibri">
                     <div style="font-size:40px;">
                         Pick a plan. Grow faster with Co&ndash;Founders.
                     </div>
                     <div style="font-size:20px;color:darkgrey">
                       Try for free for 14 days
                     </div>
                 </div>
             </section>
             <!--END COL 1-->
     
                
     
                 <!--Start Selected-->
                 <section class="col" style="margin-bottom: 60px;">
                     <!--COL 5-->
                      <!-- Control buttons -->
                      <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-2">
                                 <img style="margin-top: -55px; margin-right: 20px" src="https://marketing.intercomassets.com/assets/pricing/use-cases/squiggle-739aa764d68d44b1f5025ea2e1d93145f701abe535b64b9182e6b37bdc4e7c33.png" alt="Squiggle" />
                            </div>
                            <div class="col-md-2">
                                     <a class="btn btn-outline-primary" style="border:none; color:black; box-shadow: 1px 1px 1px lightslategray; line-height: 40px" onclick="filterSelection('all')" datatarget="#all" >All of Co-founders</a>
                            </div>
                            <div class="col-md-2">
                                     <a class="btn btn-outline-primary" style="border:none; color:black; box-shadow: 1px 1px 1px lightslategray; line-height: 40px" onclick="filterSelection('acquire')" datatarget="#acquire" >Acquire customers</a>
                            </div>
                            <div class="col-md-2">
                                     <a href="#" class="btn btn-outline-primary" style="border:none; color:black; box-shadow: 1px 1px 1px lightslategray; line-height: 40px" onclick="filterSelection('engage')" datatarget="engage" >Engage customers</a>
                             </div>
                            <div class="col-md-2">
                                     <a href="#" class="btn btn-outline-primary" style="border:none; color:black; box-shadow: 1px 1px 1px lightslategray; line-height: 40px" onclick="filterSelection('support')" datatarget="support" >Support Customers</a>
                            </div>
                      </div>
                      <hr/>
                    </div>
                    <!--END CONTROL BUTTON-->
                 </section>
     
             <section>
            <div class="container-fluid">
               <div id="#all" class="container-fluid filterDiv all" style="text-align: center; margin-top: 30px; margin-bottom: 30px; font-family: Calibri; font-size: 25px">
                   A new and better way to acquire, engage and support customers.
                 </div>
               <div  class="row">
                 <!--Start Essential-->
                   <div class="col-md-3 card filterDiv all" style="border-color: orchid; box-shadow: 4px 4px 4px lightblue; height: 670px; margin-right: 10px; margin-left:50px; margin-top:30px">
                     <i class="fa fa-cog fa-spin" style=" font-size:60px; color:orchid; margin-top: 30px"></i>
                     <div class="row" style="margin-top:30px">
                         <div class="col-md-8">
                           <h4 style="color:black; text-align: left">Essential</h4>
                           <br>
                           <p style="color:black; text-align: left; font-size: 15px">Work as a team to manage conversations</p>
                         </div>
                         <div class="col-md-4">
                           <p style="font-size:18px; color: grey; text-align: right; line-height: 20px">from<span style="color:black; font-size:30px"> $136</span> /mo</p>
                         </div>
                         <div class="col-md-12">
                           <br>
                           <a href="#" class="btn btn-outline-primary form-control" style=" line-height: 10px;"><h5>try for free &RightArrow; </h5></a>
                         </div>
                         <div class="col-md-12">
                             <br>
                             <a href="#" style="text-decoration-line:none; color:orchid"><h5 style="font-family: Calibri">How we calculate price </h5></a>
                         </div>
                     </div>
                   <hr/>
                   <div class="row">
                       <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                       <div class="col-md-10"><p style="text-align: left;"> Manage conversations from multiple channels </p></div>
                       <br>
                   </div>
                   <div class="row">
                       <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                       <div class="col-md-10"><p style="text-align: left;"> Send targeted messages on your website or in-product </p></div>
                       <br>
                   </div>
                   <div class="row">
                       <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                       <div class="col-md-10"><p style="text-align: left;"> Create a help center to answer common questions </p></div>
                       <br>
                   </div>
                   <div class="row">
                       <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                       <div class="col-md-10"><p style="text-align: left;"> Integrate with Stripe, Hubspot, Shopify and more </p></div>
                       <br>
                   </div>
                   </div>
                   <!--End Essential-->
     
                   <!--Start Pro-->
                   <div class="col-md-3 card filterDiv all" style="border-color: blue; box-shadow: 4px 4px 4px lightblue; height: 670px; margin-right: 10px; margin-left:100px; margin-top:30px">
                       <i class="fa fa-cog fa-spin" style=" font-size:60px; color:blue; margin-top: 30px"></i>
                       <div class="row" style="margin-top:30px">
                           <div class="col-md-8">
                             <h4 style="color:black; text-align: left">Pro</h4>
                             <br>
                             <p style="color:black; text-align: left; font-size: 15px">Automate and optimize your workflows</p>
                           </div>
                           <div class="col-md-4">
                             <p style="font-size:18px; color: grey; text-align: right; line-height: 20px">from<span style="color:black; font-size:30px"> $202</span> /mo</p>
                           </div>
                           <div class="col-md-12">
                             <br>
                             <a href="#" class="btn btn-outline-primary form-control" style=" line-height: 10px;"><h5>try for free &RightArrow; </h5></a>
                           </div>
                           <div class="col-md-12">
                               <br>
                               <a href="#" style="text-decoration-line:none; color:blue"><h5 style="font-family: Calibri">How we calculate price </h5></a>
                           </div>
                       </div>
                     <hr/>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Manage conversations from multiple channels </p></div>
                         <br>
                     </div>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Send targeted messages on your website or in-product </p></div>
                         <br>
                     </div>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Create a help center to answer common questions </p></div>
                         <br>
                     </div>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Integrate with Stripe, Hubspot, Shopify and more </p></div>
                         <br>
                     </div>
                     </div>
                     <!--End PRO-->
                     
                     <!--Start Premium-->
                     <div class="col-md-3 card filterDiv all" style="border-color: gold; box-shadow: 4px 4px 4px lightblue; height: 670px; margin-right: 10px; margin-left:100px; margin-top:30px">
                         <i class="fa fa-cog fa-spin" style=" font-size:60px; color:gold; margin-top: 30px"></i>
                         <div class="row" style="margin-top:30px">
                             <div class="col-md-8">
                               <h4 style="color:black; text-align: left">Premium</h4>
                               <br>
                               <p style="color:black; text-align: left; font-size: 15px">The complete toolkit for business growth</p>
                             </div>
                             <div class="col-md-4">
                             </div>
                             <div class="col-md-12">
                               <br>
                               <a href="#" class="btn btn-outline-primary form-control" style=" line-height: 10px;"><h5> Chat whith us </h5></a>
                             </div>
                             <div class="col-md-12">
                                 <br>
                                 <a href="#" style="text-decoration-line:none; color:gold"><h5 style="font-family: Calibri">How we calculate price </h5></a>
                             </div>
                         </div>
                       <hr/>
                       <div class="row">
                           <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                           <div class="col-md-10"><p style="text-align: left;"> Manage conversations from multiple channels </p></div>
                           <br>
                       </div>
                       <div class="row">
                           <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                           <div class="col-md-10"><p style="text-align: left;"> Send targeted messages on your website or in-product </p></div>
                           <br>
                       </div>
                       <div class="row">
                           <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                           <div class="col-md-10"><p style="text-align: left;"> Create a help center to answer common questions </p></div>
                           <br>
                       </div>
                       <div class="row">
                           <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                           <div class="col-md-10"><p style="text-align: left;"> Integrate with Stripe, Hubspot, Shopify and more </p></div>
                           <br>
                       </div>
                       </div>
                    <!--END Premium--->
     
               <div id="#acquire" class="row">
                   <!--Start Essential-->
                   <div id="#all" class="container-fluid filterDiv acquire" style="text-align: center; margin-top: 8px; margin-bottom: 22px; font-family: Calibri; font-size: 25px">
                       Convert leads faster and accelerate sales with live chat and bots
                     </div>
                   <div class="col-md-3 card filterDiv acquire" style="border-color: orchid; box-shadow: 4px 4px 4px lightblue; height: 670px; margin-right: 10px; margin-left:50px; margin-top:30px">
                       <i class="fa fa-compass fa-spin" style=" font-size:60px; color:orchid; margin-top: 30px"></i>
                       <div class="row" style="margin-top:30px">
                           <div class="col-md-8">
                             <h4 style="color:black; text-align: left">Essential</h4>
                             <br>
                             <p style="color:black; text-align: left; font-size: 15px">Work as a team to manage conversations</p>
                           </div>
                           <div class="col-md-4">
                             <p style="font-size:18px; color: grey; text-align: right; line-height: 20px">from<span style="color:black; font-size:30px"> $136</span> /mo</p>
                           </div>
                           <div class="col-md-12">
                             <br>
                             <a href="#" class="btn btn-outline-primary form-control" style=" line-height: 10px;"><h5>try for free &RightArrow; </h5></a>
                           </div>
                           <div class="col-md-12">
                               <br>
                               <a href="#" style="text-decoration-line:none; color:orchid"><h5 style="font-family: Calibri">How we calculate price </h5></a>
                           </div>
                       </div>
                     <hr/>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Manage conversations from multiple channels </p></div>
                         <br>
                     </div>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Send targeted messages on your website or in-product </p></div>
                         <br>
                     </div>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Create a help center to answer common questions </p></div>
                         <br>
                     </div>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Integrate with Stripe, Hubspot, Shopify and more </p></div>
                         <br>
                     </div>
                     </div>
                     <!--End Essential-->
     
                    <!--Start Pro-->
                    <div class="col-md-3 card filterDiv acquire" style="border-color: blue; box-shadow: 4px 4px 4px lightblue; height: 670px; margin-right: 10px; margin-left:100px; margin-top:30px">
                       <i class="fa fa-compass fa-spin" style=" font-size:60px; color:blue; margin-top: 30px"></i>
                       <div class="row" style="margin-top:30px">
                           <div class="col-md-8">
                             <h4 style="color:black; text-align: left">Pro</h4>
                             <br>
                             <p style="color:black; text-align: left; font-size: 15px">Automate and optimize your workflows</p>
                           </div>
                           <div class="col-md-4">
                             <p style="font-size:18px; color: grey; text-align: right; line-height: 20px">from<span style="color:black; font-size:30px"> $202</span> /mo</p>
                           </div>
                           <div class="col-md-12">
                             <br>
                             <a href="#" class="btn btn-outline-primary form-control" style=" line-height: 10px;"><h5>try for free &RightArrow; </h5></a>
                           </div>
                           <div class="col-md-12">
                               <br>
                               <a href="#" style="text-decoration-line:none; color:blue"><h5 style="font-family: Calibri">How we calculate price </h5></a>
                           </div>
                       </div>
                     <hr/>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Manage conversations from multiple channels </p></div>
                         <br>
                     </div>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Send targeted messages on your website or in-product </p></div>
                         <br>
                     </div>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Create a help center to answer common questions </p></div>
                         <br>
                     </div>
                     <div class="row">
                         <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                         <div class="col-md-10"><p style="text-align: left;"> Integrate with Stripe, Hubspot, Shopify and more </p></div>
                         <br>
                     </div>
                     </div>
                     <!--End PRO-->
     
                     <!--Start Premium-->
                     <div class="col-md-3 card filterDiv acquire" style="border-color: gold; box-shadow: 4px 4px 4px lightblue; height: 670px; margin-right: 10px; margin-left:100px; margin-top:30px">
                         <i class="fa fa-compass fa-spin" style=" font-size:60px; color:gold; margin-top: 30px"></i>
                         <div class="row" style="margin-top:30px">
                             <div class="col-md-8">
                               <h4 style="color:black; text-align: left">Premium</h4>
                               <br>
                               <p style="color:black; text-align: left; font-size: 15px">The complete toolkit for business growth</p>
                             </div>
                             <div class="col-md-4">
                             </div>
                             <div class="col-md-12">
                               <br>
                               <a href="#" class="btn btn-outline-primary form-control" style=" line-height: 10px;"><h5> Chat whith us </h5></a>
                             </div>
                             <div class="col-md-12">
                                 <br>
                                 <a href="#" style="text-decoration-line:none; color:gold"><h5 style="font-family: Calibri">How we calculate price </h5></a>
                             </div>
                         </div>
                       <hr/>
                       <div class="row">
                           <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                           <div class="col-md-10"><p style="text-align: left;"> Manage conversations from multiple channels </p></div>
                           <br>
                       </div>
                       <div class="row">
                           <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                           <div class="col-md-10"><p style="text-align: left;"> Send targeted messages on your website or in-product </p></div>
                           <br>
                       </div>
                       <div class="row">
                           <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                           <div class="col-md-10"><p style="text-align: left;"> Create a help center to answer common questions </p></div>
                           <br>
                       </div>
                       <div class="row">
                           <div class="col-md-1"><span class="fa fa-check" style="color:gray; font-size: 13px"></span></div>
                           <div class="col-md-10"><p style="text-align: left;"> Integrate with Stripe, Hubspot, Shopify and more </p></div>
                           <br>
                       </div>
                       </div>
                    <!--END Premium--->
               </div>
     
               <div id="#engage" class="row">
                   <div class="col-md-3 card filterDiv engage" style="background-color: tomato; height: 300px;  margin-right: 10px; margin-left:40px">Engage customers</div>
                   <div class="col-md-3 card filterDiv engage" style="background-color: tomato; height: 300px; margin-right: 10px; margin-left:40px">Engage customers</div>
                   <div class="col-md-3 card filterDiv engage" style="background-color: tomato; height: 300px; margin-right: 10px; margin-left:40px">Engage customers</div>
               </div>
               <div id="#support" class="row">
                   <div class="col-md-3 card filterDiv support" style="background-color: slategray; height: 300px; margin-right: 10px; margin-left:40px">Support Customers</div>
                   <div class="col-md-3 card filterDiv support" style="background-color: slategray; height: 300px; margin-right: 10px; margin-left:40px">Support Customers</div>
                   <div class="col-md-3 card filterDiv support" style="background-color: slategray; height: 300px; margin-right: 10px; margin-left:40px">Support Customers</div>
               </div>
            </div>
            </div>
            </section>
            <!--END Selected-->
            
            <!--Start Show all Feature-->
            <section>
            <div class="container-fluid" style="margin-top: 30px">
              <div class="row">
              <div class="col-md-3" style="text-align: center; margin-left:50px;">
                <li class="fa fa-plus" style="color:orchid"></li><a href="#" style="text-decoration-line: none; color:orchid"><b>Show all feature</b></a>
              </div>
                 <div class="col-md-3" style="text-align: center; margin-left:100px;">
               <li class="fa fa-plus" style="color:blue"></li><a href="#" style="text-decoration-line: none; color:blue"><b>Show all feature</b></a>
             </div>
             <div class="col-md-3" style="text-align: center; margin-left:128px;">
               <li class="fa fa-plus" style="color:gold"></li><a href="#" style="text-decoration-line: none; color:gold"><b>Show all feature</b></a>
             </div>
             </div>
            </div>
            </section>
            <!--END Show all feature-->
     
            <section>
             <div class="container" style="margin-top:90px">
              <div class="row">
                <div class="col-md-6" style="text-align:center">
                  <h6>Early stage startup?</h6>
                  <p style="font-size:15px">Eligible applicants get all of Intercom for $49/mo</p>
                  <a href="#" style="text-decoration-line: none" >Apply now&RightArrow;</a>
                </div>
                     <div class="col-md-6" style="text-align:center">
                       <h6>Annual plans available</h6>
                       <p style="font-size:15px">Get in touch with our sales team for discounted annual pricing.</p>
                       <a href="#" style="text-decoration-line:none;" >Contact us&RightArrow;</a>
                     </div>
                   </div>
             </div>
            </section>
     
            <section>
             <div class="container" style="margin-top:100px">
              <div class="row">
                     <div class="col-md-4">
                             <img style="width: 300px; margin-top: 20px" src="/Co-founders Netwrok_files/astronaut-3751046_640.png"/>
                           </div>
                <div class="col-md-8" style="text-align:left; margin-top: 60px">
                  <p style="font-size:15px">“With Intercom, we now engage leads and customers faster than ever before—increasing our sales opportunities by 32%. Beyond that, Intercom has helped us to have a real, human connection with our customers.”</p>
                  <h6>Adam Cleveland, Senior Director at Tradeshift</h6>
                </div>
              </div>
             </div>
            </section>
     
            <section>
                 <div class="container" style="margin-top:100px">
                  <div class="row">
                  <div class="col-md-12" style="text-align:center">
                       <h1>Get more out of Intercom with Add-ons</h1>
                       <p style="font-size: 20px">Try unlimited add-ons with your 14-day free trial</p>
                  </div>
                  </div>
                 </div>
             </section>
     
             <section>
                 <div class="container" style="margin-top:50px">
                     <div class="row">
                         <div class="col-md-12">
                                 <div style= "margin-top: 50px; margin-left:300px" >
                                     <img style="width: 350px;" src="\Co-founders Netwrok_files/rocket.png"/>
                                 </div>
                          </div>
                     </div>
                 </div>
             </section>
                   
     <script type="text/javascript">
       filterSelection("all")
       function filterSelection(c) {
         var x, i; 
         x = document.getElementsByClassName("filterDiv");
         // Add the "show" class (display:block) to the filtered elements, and remove the "show" class from the elements that are not selected
         for (i = 0; i < x.length; i++) {
           w3RemoveClass(x[i], "show");
           if (x[i].className.indexOf(c) > -1) w3AddClass(x[i], "show");
         }
       }
       
       // Show filtered elements
       function w3AddClass(element, name) {
         var i, arr1, arr2;
         arr1 = element.className.split(" ");
         arr2 = name.split(" ");
         for (i = 0; i < arr2.length; i++) {
           if (arr1.indexOf(arr2[i]) == -1) {
             element.className += " " + arr2[i];
           }
         }
       }
       
       // Hide elements that are not selected
       function w3RemoveClass(element, name) {
         var i, arr1, arr2;
         arr1 = element.className.split(" ");
         arr2 = name.split(" ");
         for (i = 0; i < arr2.length; i++) {
           while (arr1.indexOf(arr2[i]) > -1) {
             arr1.splice(arr1.indexOf(arr2[i]), 1); 
           }
         }
         element.className = arr1.join(" ");
       }
       
       // Add active class to the current control button (highlight it)
       var btnContainer = document.getElementById("myBtnContainer");
       var btns = btnContainer.getElementsByClassName("btn");
       for (var i = 0; i < btns.length; i++) {
         btns[i].addEventListener("click", function() {
           var current = document.getElementsByClassName("active");
           current[0].className = current[0].className.replace(" active", "");
           this.className += " active";
         });
       }
     </script>
     
           </body>
         
     </html>
      

</asp:Content>

