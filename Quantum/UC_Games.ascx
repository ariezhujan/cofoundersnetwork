<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC_Games.ascx.cs" Inherits="UC_Games" %>
<%@ Import Namespace="megaswfLibrary" %>
<%@ OutputCache Duration="86400" VaryByParam="*" %>

<table width="800px">
    <tr>
        <td class="menu" style="width: 167px" valign="top">
			<ul class="side">
				<li class="head">Categories</li>
				<li><a href="/games/Multiplayer">2 - Multi Player</a> </li>
				<li><a href="/games/Action">Action</a> </li>
				<li><a href="/games/Adventure">Adventure</a> </li>
				<li><a href="/games/Aircraft">Aircraft</a> </li>
				<li><a href="/games/Alien">Alien</a> </li>
				<li><a href="/games/Animal">Animal</a> </li>
				<li><a href="/games/Arcade">Arcade</a> </li>
				<li><a href="/games/Balancing">Balancing</a> </li>
				<li><a href="/games/Ball">Ball</a> </li>
				<li><a href="/games/Balloons">Balloons</a> </li>
				<li><a href="/games/Beat Em Up">Beat 'Em Up</a> </li>
				<li><a href="/games/Birds">Birds</a> </li>
				<li><a href="/games/Blood">Blood</a> </li>
				<li><a href="/games/Boat">Boat</a> </li>
				<li><a href="/games/Bomb">Bomb</a> </li>
				<li><a href="/games/Bounce">Bounce</a> </li>
				<li><a href="/games/Bow">Bow</a> </li>
				<li><a href="/games/Boy">Boy</a> </li>
				<li><a href="/games/Bubbles">Bubbles</a> </li>
				<li><a href="/games/Canon">Canon</a> </li>
				<li><a href="/games/Car">Car</a> </li>
				<li><a href="/games/Cat">Cat</a> </li>
				<li><a href="/games/Christmas">Christmas</a> </li>
				<li><a href="/games/Collecting Games">Collecting Games</a> </li>
				<li><a href="/games/Cooking">Cooking</a> </li>
				<li><a href="/games/Decorate">Decorate</a> </li>
				<li><a href="/games/Defend">Defend</a> </li>
				<li><a href="/games/Defense">Defense</a> </li>
				<li><a href="/games/Dog">Dog</a> </li>
				<li><a href="/games/Dress Up">Dress Up</a> </li>
				<li><a href="/games/Driving">Driving</a> </li>
				<li><a href="/games/Escape">Escape</a> 	</li>
				<li><a href="/games/Evade">Evade</a> </li>
				<li><a href="/games/Fighting">Fighting</a> </li>
				<li><a href="/games/First Person Shooter">First Person Shooter</a> </li>
				<li><a href="/games/Fish">Fish</a> </li>
				<li><a href="/games/Flash">Flash</a> </li>
				<li><a href="/games/Flower">Flower</a> </li>
				<li><a href="/games/Flying">Flying</a> 	</li>
				<li><a href="/games/Food">Food</a> </li>
				<li><a href="/games/Food Serving">Food Serving</a> </li>
				<li><a href="/games/Football">Football</a> </li>
				<li><a href="/games/Fruit">Fruit</a> </li>
				<li><a href="/games/Fun">Fun</a> </li>
				<li><a href="/games/Funny">Funny</a> </li>
				<li><a href="/games/Girl">Girl</a> </li>
				<li><a href="/games/Gore">Gore</a> </li>
				<li><a href="/games/Grooming">Grooming</a> </li>
				<li><a href="/games/Guessing Game">Guessing Game</a> </li>
				<li><a href="/games/Guns">Guns</a> </li>
				<li><a href="/games/Helicopter">Helicopter</a> </li>
				<li><a href="/games/Ice">Ice</a> </li>
				<li><a href="/games/Jumping">Jumping</a> </li>
				<li><a href="/games/Kids">Kids</a> </li>
				<li><a href="/games/Killing">Killing</a> </li>
				<li><a href="/games/Love">Love</a> </li>
				<li><a href="/games/Management">Management</a> </li>
				<li><a href="/games/Mario">Mario</a> </li>
				<li><a href="/games/Matching Game">Matching Game</a> </li>
				<li><a href="/games/Memory Game">Memory Game</a> </li>
				<li><a href="/games/Monkey">Monkey</a> </li>
				<li><a href="/games/Monsters">Monsters</a> </li>
				<li><a href="/games/Motorcycle">Motorcycle</a> </li>
				<li><a href="/games/Mouse Skill">Mouse Skill</a> </li>
				<li><a href="/games/Music">Music</a> </li>
				<li><a href="/games/Ninja">Ninja</a> </li>
				<li><a href="/games/Obstacle">Obstacle</a> 	</li>
				<li><a href="/games/Platforms">Platforms</a> </li>
				<li><a href="/games/Puzzle">Puzzle</a> </li>
				<li><a href="/games/Racing">Racing</a> </li>
				<li><a href="/games/Rescue Game">Rescue Game</a> </li>
				<li><a href="/games/Robots">Robots</a> </li>
				<li><a href="/games/Role Playing">Role Playing</a> </li>
				<li><a href="/games/Running">Running</a> </li>
				<li><a href="/games/Series">Series</a> </li>
				<li><a href="/games/Shockwave">Shockwave</a> </li>
				<li><a href="/games/Shoot Em Up">Shoot 'Em Up</a> </li>
				<li><a href="/games/Shooting">Shooting</a> </li>
				<li><a href="/games/Side Scrolling">Side Scrolling</a> </li>
				<li><a href="/games/Simulation">Simulation</a> 	</li>
				<li><a href="/games/Snow">Snow</a> </li>
				<li><a href="/games/Soccer">Soccer</a> </li>
				<li><a href="/games/Space">Space</a> </li>
				<li><a href="/games/Spaceship">Spaceship</a> </li>
				<li><a href="/games/Sports">Sports</a> </li>
				<li><a href="/games/Stick">Stick</a> </li>
				<li><a href="/games/Strategy">Strategy</a> 	</li>
				<li><a href="/games/Street">Street</a> </li>
				<li><a href="/games/Stunts">Stunts</a> </li>
				<li><a href="/games/Tank">Tank</a> </li>
				<li><a href="/games/Throwing">Throwing</a> </li>
				<li><a href="/games/Timing Game">Timing Game</a> </li>
				<li><a href="/games/Truck">Truck</a> </li>
				<li><a href="/games/Violence">Violence</a> 	</li>
				<li><a href="/games/War">War</a> </li>
				<li><a href="/games/Water">Water</a> </li>
				<li><a href="/games/Zombies">Zombie</a> </li>
				</ul>
        </td>
        <td style="vertical-align: top; text-align: center;">
            <div id="fb-root"></div><script src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script><fb:like-box href="http://www.facebook.com/pages/MegaSWF/118726804869152" width="292" show_faces="false" border_color="" stream="false" header="false"></fb:like-box>
            <br />
            
            <h1><asp:Literal runat="server" ID="litTitle"></asp:Literal></h1>
            <a href="/games/Action">Action</a> | <a href="/games/multi player">Multi-Player</a> | <a href="/games/Adventure">Adventure</a> | <a href="/games/Shooting">Shooting</a> | <a href="/games/Driving">Driving</a> | <a href="/games/Sports">Sports</a> | <a href="/games/Puzzle">Puzzle</a> | <a href="/games/Strategy">Strategy</a>
            <br />
            

            <asp:DataList runat="server" ID="dlFiles" RepeatColumns="4">
                <ItemStyle CssClass="large-icon-display-td" />
                <ItemTemplate>
                    <a href="/serve/<%#DataBinder.Eval(Container.DataItem, "id")%>/" class="ux-thumb-wrap"><span class="ux-thumb-128 "><span class="clip"><img width="120" height="90" onload="" title="<%#DataBinder.Eval(Container.DataItem, "title")%>" alt="Thumbnail" src="<%#File.DisplayImagePath(DataBinder.Eval(Container.DataItem, "image"))%>" class="" click=""></span></span></a>
                    <br />
                    <a href='/serve/<%#DataBinder.Eval(Container.DataItem, "id")%>/' target="_top"><%#DataBinder.Eval(Container.DataItem, "title")%></a>
                </ItemTemplate>
            </asp:DataList>

        </td>
    </tr>
</table>

