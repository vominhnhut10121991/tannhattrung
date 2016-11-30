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
                        <%= ThaiWood.ViewRes.TestString.String_AboutUs %></h2>

                    

                    <p>
                        <%= ThaiWood.ViewRes.TestString.String_CompanyInfo %>
                    </p>
                    <div class="col-sm-12">
                        <img src="../../Image/home/AboutUs.jpg" class="girl img-responsive" alt="" />
                    </div>
                    <div id="gmap" class="contact-map">

                    </div>
                    <div id="gmap" class="contact-map">

                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--/#contact-page-->
</asp:Content>
