<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Home.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ThaiWood.ViewRes.TestString.Title_Home %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <div class="logo-404">
            <div class="companyinfo">
                <h2>
                    <span>HTN</span>-<%= Html.ActionLink("WOOD", "Index", "Home") %></h2>
            </div>
        </div>
        <div class="content-404">
            <img src="../../Image/404/404.png" class="img-responsive" alt="" />
            <h1>
                <b>OPPS!</b> <%= ThaiWood.ViewRes.TestString.Error_Message %></h1>
            <p>
                <%= ThaiWood.ViewRes.TestString.Error_Description %></p>
            <h2>
                <%= Html.ActionLink( ThaiWood.ViewRes.TestString.Error_BringBack, "Index", "Home") %>
        </div>
    </div>
</asp:Content>
