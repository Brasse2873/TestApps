<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #frame1
        {
            background-color: #008000;
        }
        #frame2
        {
            background-color: #800000;
            position: relative;
            top: 200px;
            height: 50px;
        }
        #frame3
        {
            background-color: #808000;
        }
        #frame4
        {
            background-color: #FFFF00;
            position: relative;
            left: 200px;
        }
        #frame5
        {
            background-color: #00FF00;
        }
        #frame6
        {
            background-color: #FF00FF;
            position: relative;
            right: 200px;
        }
        #frame7
        {
            background-color: #555555;
            position: relative;
            height:100px;
            width:400px;
        }
        #frame7a
        {
            background-color: #5555FF;
            width:50%;
            float:left;
        }
        #frame7b
        {
            background-color: #55FF55;
            width:50%;
            float:right 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="frame1">
            frame1, Position=-, -,-,-,-
        </div>
        <div id="frame2">
            frame2, Position=relative, 200,-,-,-
        </div>
        <div id="frame3">
            frame3, Position=-, -,-,-,-
        </div>
        <div id="frame4">
            frame4, Position=relative, -,-,-,200
        </div>
        <div id="frame5">
            frame5, Position=-, -,-,-,-
        </div>
        <div id="frame6">            
            frame6, Position=relative, -,200,-,-
        </div>
        <div id="frame7">            
            <div id="frame7a">            
                frame7a, Position=absolute, 0,-,-,0
            </div>
            <div id="frame7b">            
                frame7b, Position=absolute, 50,-,-,0
                blsd sadfkls fkl jdf sdflk 
                asd flasdfklö alf
                asdf asdlfk jaslödk f
            </div>
        </div>
    </div>
    </form>
</body>
</html>
