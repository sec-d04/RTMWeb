<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        ようこそ <strong><%: Page.User.Identity.Name %></strong> さん!
        [ <%: Html.ActionLink("ログオフ", "LogOff", "Account") %> ]
<%
    }
    else {
%> 
        [ <%: Html.ActionLink("ログオン", "LogOn", "Account") %> ]
<%
    }
%>
