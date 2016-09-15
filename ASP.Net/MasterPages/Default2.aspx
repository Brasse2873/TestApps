<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
    Default2.aspx content</p>
<p>
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Goto Default</asp:HyperLink>
</p>
</asp:Content>

