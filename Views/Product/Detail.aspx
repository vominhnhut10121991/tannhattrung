<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Product.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ThaiWood.ViewRes.TestString.Title_Product %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-9 padding-right">
        <div class="product-details">
            <!--product-details-->
            <div class="col-sm-5">
                <div class="view-product">
                    <img src="../../Image/Product/1.jpg" alt="" />
                </div>
            </div>
            <div class="col-sm-7">
                <div class="product-information">
                    <!--/product-information-->
                    <h2>
                        <%= ((ThaiWood.Models.ProductFromProductIdViewModel)ViewData["ProductDetail"]).productName%></h2>
                    <p>
                        <%= ThaiWood.ViewRes.TestString.String_Product + " ID: " + ((ThaiWood.Models.ProductFromProductIdViewModel)ViewData["ProductDetail"]).productId%></p>
                    <p>
                        <%= "(" + ThaiWood.ViewRes.TestString.String_View + ": "  + ((ThaiWood.Models.ProductFromProductIdViewModel)ViewData["ProductDetail"]).productCount + ")"%></p>
                    <span>
                        <button type="button" class="btn btn-fefault cart">
                            <i class="fa fa-shopping-cart"></i>
                            <%= ThaiWood.ViewRes.TestString.String_AddToCart %>
                        </button>
                    </span>
                    <p>
                        <b>
                            <%= ThaiWood.ViewRes.TestString.String_Category + " :"%></b>
                        <%= ((ThaiWood.Models.ProductFromProductIdViewModel)ViewData["ProductDetail"]).productCategory%></p>
                    <p>
                        <b>
                            <%= ThaiWood.ViewRes.TestString.String_Brand + " :"%></b>
                        <%= ((ThaiWood.Models.ProductFromProductIdViewModel)ViewData["ProductDetail"]).productBrand%></p>
                </div>
                <!--/product-information-->
            </div>
        </div>
        <!--/product-details-->
        <div class="category-tab shop-details-tab">
            <!--category-tab-->
            <div class="col-sm-12">
                <ul class="nav nav-tabs">
                    <li><a href="#details" data-toggle="tab">
                        <%= ThaiWood.ViewRes.TestString.String_Detail %></a></li>
                    <li class="active"><a href="#reviews" data-toggle="tab">
                        <%= ThaiWood.ViewRes.TestString.String_Review %></a></li>
                </ul>
            </div>
            <div class="tab-content">
                <div class="tab-pane fade" id="details">
                </div>
                <div class="tab-pane fade active in" id="reviews">
                    <div class="col-sm-12">
                        <ul>
                            <li><a href=""><i class="fa fa-user"></i>EUGEN</a></li>
                            <li><a href=""><i class="fa fa-clock-o"></i>12:41 PM</a></li>
                            <li><a href=""><i class="fa fa-calendar-o"></i>31 DEC 2014</a></li>
                        </ul>
                        <p>
                            This is a good product!</p>
                        <p>
                            <b>
                                <%= ThaiWood.ViewRes.TestString.String_ReviewDescription %></b></p>
                        <form action="#">
                        <span>
                            <input type="text" placeholder="Your Name" />
                            <input type="email" placeholder="Email Address" />
                        </span>
                        <textarea rows="1" name=""></textarea>
                        <button type="button" class="btn btn-default pull-right">
                            <%= ThaiWood.ViewRes.TestString.String_Submit %>
                        </button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <!--/category-tab-->
        <div id="gmap" class="contact-map">
    </div>
</asp:Content>
