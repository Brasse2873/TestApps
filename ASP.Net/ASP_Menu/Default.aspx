<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" Width="400px">
            <Items>
                <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Home" Value="Home">
                    <asp:MenuItem Text="Sub item" Value="Sub item"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Products.aspx" Text="Products" Value="Products">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/Services.aspx" Text="Services" Value="Services">
                </asp:MenuItem>
            </Items>
        </asp:Menu>
    
    </div>


    <asp:Menu ID="Menu2" runat="server" DataSourceID="SiteMapDataSource1" 
        StaticSubMenuIndent="" StaticDisplayLevels="2">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
    </form>
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
</body>
</html>
