<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%= Html.ActionLink("English", "ChangeCulture", "Home",  
     new { lang = "en", returnUrl = this.Request.RawUrl }, null)%>
<%= Html.ActionLink("Vietnam", "ChangeCulture", "Home",  
     new { lang = "vi", returnUrl = this.Request.RawUrl }, null)%>