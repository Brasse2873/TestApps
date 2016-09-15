<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    Default content</p>
<p>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default2.aspx">goto Default2</asp:HyperLink>
</p>
</asp:Content>

