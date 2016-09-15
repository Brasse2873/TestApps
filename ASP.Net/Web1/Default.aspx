<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 185px;
        }
        .style2
        {
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table style="width: 100%;">
            <tr>
                <td class="style1" style="text-align: left">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/qita.jpg" 
                         />
                    <br />
                    Hej&nbsp;
                </td>
                <td class="style2">
                    Hopp&nbsp;
                </td>
                <td>
                    Gallopp</td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td>
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/qita.jpg" />
                    <br />
                    Hej</td>
                <td>
                    Hopp</td>
                <td>
                    Gallopp</td>
            </tr>
            </table>
        Text</div>
    </form>
</body>
</html>
