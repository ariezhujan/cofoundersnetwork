<%@ Page ValidateRequest="false" Language="C#" AutoEventWireup="true" CodeFile="ServeEmbedJS.aspx.cs" Inherits="ServeEmbedJS" %>

    //embed
	function embed()
	{
		var id = "<%=iframeID %>";
		var url = "http://megaswf.com/ServeEmbed.aspx?fileID=<%=fileID %>&height=<%=fileHeight.ToString() %>&width=<%=fileWidth.ToString() %>&localID=<%=localID %>";
		var iframe = document.getElementById(id);
		iframe.id = id;
		iframe.name = id;
		iframe.src = url;
		iframe.style.display = "block";
		iframe.width = <%=fileWidth.ToString() %>;
		iframe.height = <%=fileHeight.ToString() %>;
		iframe.frameBorder = 0;
	}

    embed();

    
    function loadpopunder_popadsnet()
    {
        document.write('\x3Cscript type="text/javascript">');
        //default pop-under house ad url 
        document.write('infinityads_enable_pop = true; ');
        document.write('infinityads_enable_adhere = false; ');
        document.write('infinityads_frequencyCap =0;');
        document.write('durl = "";');
        document.write('infinityads_layer_border_color = "";');
        document.write('infinityads_layer_ad_bg = "";');
        document.write('infinityads_layer_ad_link_color = "";');
        document.write('infinityads_layer_ad_text_color = "";');
        document.write('infinityads_text_link_bg = "";');
        document.write('infinityads_text_link_color = "";');
        document.write('infinityads_enable_text_link = false;');
        document.write('\x3C/script>');
        document.write('\x3Cscript type="text/javascript" src="http://ads.lzjl.com/newServing/showAd.php?nid=5&pid=9704&adtype=&sid=15005">\x3C/script>');

        //document.write('\x3Cscript src="http://www.trafficrevenue.net/loadadlite.js?username=megaswf">\x3C/script>');
    }
    
    <%--function loadpopunder_popadsnet()
    {
        document.write('a');
        document.write('\x3Cscript type="text/javascript">');
        document.write('var PopAds_SiteID=11127;');
        document.write('var PopAds_MinimalBid=0.0005;');
        document.write('var PopAds_PopundersPerIP=1;');
        document.write('var PopAds_AutoPopunder=true;');
        document.write('var PopAds_Default=false;');
        document.write('\x3C/script>');
        document.write('\x3Cscript type="text/javascript" src="http://popadscdn.net/pop.js">\x3C/script>');
    }--%>
    
    
<%--    function loadpopunder_clicksor()
    {
        document.write('\x3Cscript type="text/javascript">');
        document.write('clicksor_enable_adhere = false;');
        document.write('//default pop-under house ad url');
        document.write('clicksor_enable_pop = true; clicksor_frequencyCap = 12;');
        document.write('durl = "";clicksor_layer_border_color = "";');
        document.write('clicksor_layer_ad_bg = ""; clicksor_layer_ad_link_color = "";');
        document.write('clicksor_layer_ad_text_color = ""; clicksor_text_link_bg = "";');
        document.write('clicksor_text_link_color = ""; clicksor_enable_text_link = false;');
        document.write('\x3C/script>');
        document.write('\x3Cscript type="text/javascript" src="http://ads.clicksor.com/showAd.php?nid=1&amp;pid=189192&amp;adtype=&amp;sid=298349">\x3C/script>');
        document.write('\x3Cnoscript>\x3Ca href="http://www.yesadvertising.com">affiliate marketing\x3C/a>\x3C/noscript>');
    }--%>
    


    
    
    
    
