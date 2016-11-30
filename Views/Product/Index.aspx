<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Product.Master" Inherits="System.Web.Mvc.ViewPage<ThaiWood.Models.ProductViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ThaiWood.ViewRes.TestString.Title_Product %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-9 padding-right">
        <div class="features_items">
            <!--features_items-->
            <h2 class="title text-center">
                <%= ThaiWood.ViewRes.TestString.String_FeatureItem %></h2>
            <% foreach (System.Data.DataRow dr in ((ThaiWood.Models.AbstractProductViewModel)ViewData["Product"]).ds.Tables["Product"].Rows)
               { %>
            <div class="col-sm-4">
                <div class="product-image-wrapper">
                    <div class="single-products">
                        <div class="productinfo text-center">
                            <%= "<img src=\"../../Image/Product/" + dr[0].ToString() + ".jpg\" alt=\"\" />" %>

                            <h2>
                                <%=ThaiWood.ViewRes.TestString.String_Product%>
                            </h2>
                            <p>
                                <%= dr[1].ToString().Substring(0, dr[1].ToString().Length > 20 ? 20 : dr[1].ToString().Length)%>
                            </p>
                            <p>
                                <%= "(" + ThaiWood.ViewRes.TestString.String_View +": " + dr[5].ToString() + ")"%>
                            </p>
                            <%= "<a href=\"/Product/Detail/" + dr[0].ToString() + "\" class=\"btn btn-default add-to-cart\"><i class=\"fa fa-shopping-cart\">" + ThaiWood.ViewRes.TestString.String_ViewDetail + "</i></a>"%>
                            <% int count = 6;
                               foreach (System.Data.DataRow dr1 in ((ThaiWood.Models.AbstractProductViewModel)ViewData["Type"]).ds.Tables["Type"].Rows)
                               { %>
                            <%if (string.Compare(dr1[0].ToString(), dr[0].ToString()) == 0)
                              {%>
                            <p>
                                <%= dr1[1].ToString() %>
                            </p>
                            <%count--;
                              } %>
                            <%}
                               while (count > 0)
                               {
                                   count--;%>
                            <p>
                                &nbsp;
                            </p>
                            <%} %>
                        </div>
                        <div class="product-overlay">
                            <div class="overlay-content">
                                <h2>
                                    <%=ThaiWood.ViewRes.TestString.String_Product%>
                                </h2>
                                <p>
                                    <%= dr[1].ToString().Substring(0, dr[1].ToString().Length > 20 ? 20 : dr[1].ToString().Length)%>
                                </p>
                                <p>
                                    <%= "(" + ThaiWood.ViewRes.TestString.String_View +": " + dr[5].ToString() + ")"%>
                                </p>
                                <%= "<a href=\"/Product/Detail/" + dr[0].ToString() + "\" class=\"btn btn-default add-to-cart\"><i class=\"fa fa-shopping-cart\">" + ThaiWood.ViewRes.TestString.String_ViewDetail + "</i></a>"%>
                                <% int count2 = 6;
                                   foreach (System.Data.DataRow dr1 in ((ThaiWood.Models.AbstractProductViewModel)ViewData["Type"]).ds.Tables["Type"].Rows)
                                   { %>
                                <%if (string.Compare(dr1[0].ToString(), dr[0].ToString()) == 0)
                                  {%>
                                <p>
                                    <%= dr1[1].ToString() %>
                                </p>
                                <%count2--;
                                  } %>
                                <%}
                                   while (count > 0)
                                   {
                                       count2--;%>
                                <p>
                                    &nbsp;
                                </p>
                                <%} %>
                            </div>
                        </div>
                    </div>
                    <div class="choose">
                        <ul class="nav nav-pills nav-justified">
                            <li><a href=""><i class="fa fa-plus-square"></i><%= ThaiWood.ViewRes.TestString.String_AddToWishList %></a></li>
                            <li><a href=""><i class="fa fa-plus-square"></i><%= ThaiWood.ViewRes.TestString.String_AddToCompare %></a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <%} %>
        </div>
        <!--features_items-->
        <div id="gmap" class="contact-map">
        </div>
</asp:Content>
