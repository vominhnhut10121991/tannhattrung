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
                        <%= ThaiWood.ViewRes.TestString.String_Welcome %></h2>
                
                    <p>
                        <%= ThaiWood.ViewRes.TestString.String_CompanyInfo %></p>
                    <div id="gmap" class="contact-map">
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
