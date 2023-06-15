<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HotelManageSystem.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="js/content.js?v=1.0.0"></script>
     <style type="text/css">
         .auto-style2 {
             width: 445px;
             height: 44px;
             margin-bottom: 0;
         }
     </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" full-height-layout" style="overflow: hidden;" id="wrapper">
        <!--左侧导航开始-->
        <nav class="navbar-default navbar-static-side" role="navigation">
            <div class="nav-close"><i class="fa fa-times-circle"></i></div>
            <div class="sidebar-collapse ">
                <ul class="nav" id="side-menu">
                    <li class="nav-header">
                        <div class="dropdown profile-element">
                            <img src="image/login.png" width="150px" height="50px" />
                        </div>
                        <div class="logo-element">Y+L</div>
                    </li>                   
                        <li>
                            
                        <a class="J_menuItem" href="Guestroom.aspx"  >
                            <i class="fa fa-home"></i>
                            <span class="nav-label">客房状态</span>
                        </a>
                    </li>
                    <li>
                        <a class="J_menuItem" href="checkin.aspx">
                            <i class="fa fa-edit"></i>
                            <span class="nav-label">登记预定</span>
                            
                        </a>
                    </li>
                    <li>
                        <a class="J_menuItem" href="HousingInfor.aspx">
                            <i class="fa fa-desktop"></i>
                            <span class="nav-label">客房订单</span>
                            
                        </a>
                    </li>
                  
                    <li>
                        <a href="#">
                            <i class="glyphicon glyphicon-tasks"></i>
                            <span class="nav-label">客房信息</span>
                            <span class="fa arrow"></span>
                        </a>
                        <ul class="nav nav-second-level">
                            <li>
                                <a class="J_menuItem" href="Roominfor.aspx">客房管理</a>
                            </li>
                            <li>
                                <a class="J_menuItem" href="roomtype.aspx">客房类型管理</a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a class="J_menuItem" href="UserInfo.aspx">
                            <i class="glyphicon glyphicon-list"></i>
                            <span class="nav-label">用户管理</span>
                            
                        </a>
                    </li>
                </ul>
            </div>
        </nav>
        <!--左侧导航结束-->
        <!--右侧部分开始-->
        <div id="page-wrapper" class="gray-bg dashbard-1">
            <div class="row border-bottom">
                <nav class="navbar navbar-static-top row" role="navigation" style="margin-bottom: 0;">
                    <div class="navbar-header col-lg-10" style="left: 0px; top: 0px; width: 86%">
                        <a class="navbar-minimalize minimalize-styl-2 btn btn-primary" href="#"><i class="fa fa-bars"></i></a>
                                <h1 class="auto-style2" style="margin-left: auto; margin-right: auto; margin-top: 10px;">欢迎使用客房管理系统</h1>
                    </div>
                    <ul class="nav navbar-top-links navbar-right">
                         <li class="dropdown hidden-xs"> 
                            <a class="right-sidebar-toggle" href="Login.aspx" aria-expanded="false"><i class="fa fa-tasks"></i>退出登录 </a>
                        </li>
                    </ul>
                </nav>
            </div>
            <div class="row content-tabs">
                <button class="roll-nav roll-left J_tabLeft"><i class="fa fa-backward"></i></button>
                <nav class="page-tabs J_menuTabs">
                    <div class="page-tabs-content">
                        <a href="javascript:;" class="active J_menuTab" data-id="Guestroom.aspx">客房状态信息</a>
                    </div>
                </nav>
                <button class="roll-nav roll-right J_tabRight"><i class="fa fa-forward"></i></button>
                <div class="btn-group roll-nav roll-right">
                    <button class="dropdown" data-toggle="dropdown">页签操作<span class="caret"></span></button>
                    <ul role="menu" class="dropdown-menu dropdown-menu-right">
                        <li class="tabCloseCurrent"><a>关闭当前</a></li>
                        <li class="J_tabCloseOther"><a>关闭其他</a></li>
                        <li class="J_tabCloseAll"><a>全部关闭</a></li>
                    </ul>
                </div>
                <a href="#" class="roll-nav roll-right tabReload"><i class="fa fa-refresh"></i>刷新</a>
            </div>
            <div class="row J_mainContent" id="content-main">
                <iframe class="J_iframe" name="iframe0" width="100%" height="100%" src="Guestroom.aspx" frameborder="0" data-id="Guestroom.aspx" seamless="seamless"></iframe>
            </div>
            <div class="footer">
                <div class="pull-right">&copy; 2021-2021 <a href="#" target="_blank">zihan's blog</a></div>
            </div>
        </div>
        <!--右侧部分结束-->
    </div>
</asp:Content>
