<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #frame1
        {
            background-color: #008000;
            position: fixed;
            top: 200px;
            right: 200px;
            bottom: 200px;
            left: 200px;
        }
        #frame2
        {
            background-color: #800000;
            position: fixed;
            right: 200px;
            bottom: 200px;
            left: 200px;
        }
        #frame3
        {
            background-color: #808000;
            position: fixed;
            bottom: 200px;
            left: 200px;
        }
        #frame4
        {
            background-color: #FFFF00;
            position: fixed;
            left: 200px;
        }
        #frame5
        {
            background-color: #00FF00;
            position: fixed;
            bottom: 200px;
        }
        #frame6
        {
            background-color: #FF00FF;
            position: fixed;
            right: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="frame1">
            frame1, Position=fixed, 200,200,200,200
        </div>
        <div id="frame2">
            frame2, Position=fixed, -,200,200,200
        </div>
        <div id="frame3">
            frame3, Position=fixed, -,-,200,200
        </div>
        <div id="frame4">
            frame4, Position=fixed, -,-,-,200
        </div>
        <div id="frame5">
            frame5, Position=fixed, -,-,200,-
        </div>
        <div id="frame6">            
            frame6, Position=fixed, -,200,-,-
        </div>
    </div>
    </form>
</body>
</html>
