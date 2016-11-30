<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ThaiWood.ViewRes.TestString.Title_Home %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="contact-page" class="container">
        <div class="bg">
            <div class="row">
                <div class="col-sm-12">
                    <h2 class="title text-center">
                        <%= ThaiWood.ViewRes.TestString.String_ContactUs %></h2>
                    <address>
                        <p>
                            <%= ThaiWood.ViewRes.TestString.Name_Company %></p>
                        <p>
                            <%= ThaiWood.ViewRes.TestString.String_Address %></p>
                        <p>
                            <%= ThaiWood.ViewRes.TestString.String_Mobile %>: <%= ThaiWood.ViewRes.TestString.String_MobileNumber %></p>
                        <p>
                            <%= ThaiWood.ViewRes.TestString.String_Fax %>: 1-714-252-0026</p>
                        <p>
                            <%= ThaiWood.ViewRes.TestString.String_Email %>: <%= ThaiWood.ViewRes.TestString.String_EmailSupport %></p>
                    </address>
                    <div class="social-networks">
                        <h2 class="title text-center">
                            <%= ThaiWood.ViewRes.TestString.String_SocialNetworking %></h2>
                        <ul>
                            <li><a href="https://www.facebook.com/"><i class="fa fa-facebook"></i></a></li>
                            <li><a href="https://twitter.com/"><i class="fa fa-twitter"></i></a></li>
                            <li><a href="https://www.linkedin.com/"><i class="fa fa-linkedin"></i></a></li>
                            <li><a href="https://dribbble.com/"><i class="fa fa-dribbble"></i></a></li>
                            <li><a href="https://plus.google.com/"><i class="fa fa-google-plus"></i></a></li>
                        </ul>
                    </div>
                    <div id="gmap" class="contact-map">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--/#contact-page-->
</asp:Content>
