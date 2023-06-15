<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="HotelManageSystem.welcome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            display: block;
            max-width: 100%;
            height: 368px;
            width: 1638px;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="gray-bg top-navigation">
        <div id="wrapper">
            <div id="page-wrapper" class="gray-bg">
                <div class="row border-bottom white-bg">
                    <nav class="navbar navbar-static-top" role="navigation" style="left: 0px; top: 0px; height: 48px">
                        <div class="navbar-header">
                            <button aria-controls="navbar" aria-expanded="false" data-target="#navbar" data-toggle="collapse" class="navbar-toggle collapsed" type="button">
                                <i class="fa fa-reorder"></i>
                            </button>
                            <a href="#" class="navbar-brand">欢迎来到宾馆之家</a>
                        </div>
                        <div class="navbar-collapse collapse" id="navbar">
                            <ul class="nav navbar-nav">
                                <li class="active">
                                    <a aria-expanded="false" role="button" href="index.html">首页</a>
                                </li>
                                <li class="dropdown">
                                    <a aria-expanded="false" role="button" href="#dingdan">我的订单</a>
                                </li>
                                <li class="dropdown">
                                    <a aria-expanded="false" role="button" href="#lishi">历史订单</a>
                                </li>
                            </ul>
                            <ul class="nav navbar-top-links navbar-right">
                                <li>
                                    <a href="login.aspx">
                                        <i class="fa fa-sign-out"></i>退出
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </nav>
                </div>
                <div class="wrapper wrapper-content">
                    <div class="container">
                        <div class="ibox-content">
                            <div class="carousel slide" id="carousel2">
                                <ol class="carousel-indicators">
                                    <li data-slide-to="0" data-target="#carousel2" class="active"></li>
                                    <li data-slide-to="1" data-target="#carousel2"></li>
                                    <li data-slide-to="2" data-target="#carousel2" class=""></li>
                                </ol>
                                <div class="carousel-inner">
                                    <div class="item active">
                                        <img alt="image" class="auto-style1" src="image/p_big1.jpg">
                                        <div class="carousel-caption">
                                            <p>Welcome to the hotel. Have a nice day </p>
                                        </div>
                                    </div>
                                    <div class="item ">
                                        <img alt="image" class="auto-style1" src="image/p_big3.jpg">
                                        <div class="carousel-caption">
                                            <p>Welcome to the hotel. Have a nice day</p>
                                        </div>
                                    </div>
                                    <div class="item">
                                        <img alt="image" class="auto-style1" src="image/p_big2.jpg">
                                        <div class="carousel-caption">
                                            <p>Welcome to the hotel. Have a nice day</p>
                                        </div>
                                    </div>
                                </div>
                                <a data-slide="prev" href="carousel.html#carousel2" class="left carousel-control">
                                    <span class="icon-prev"></span>
                                </a>
                                <a data-slide="next" href="carousel.html#carousel2" class="right carousel-control">
                                    <span class="icon-next"></span>
                                </a>
                            </div>
                        </div>
                        <div class="wrapper wrapper-content  animated fadeInRight blog">
                            <h2>客房信息</h2>
                            <div class="row">
                                <asp:Repeater ID="ddlroty" runat="server" OnItemCommand="ddlroty_ItemCommand">
                                    <ItemTemplate>
                                        <div class="col-lg-4">
                                            <div class="ibox">
                                                <div class="ibox-content">
                                                    <a href="article.html" class="btn-link">
                                                        <h2><%# Eval("rtname") %></h2>
                                                    </a>
                                                    <div class="small m-b-xs">
                                                        <strong>客 房 价 格</strong>
                                                        <span style="color: red"><%# Eval("rprice") %>元</span>
                                                    </div>
                                                    <p>
                                                        客房面积: <%# Eval("rarea") %>㎡
                                                    </p>
                                                    <p>
                                                        空调配备: <%# Convert.ToInt32(Eval("racdt"))==0?"已配置":"未配置"  %>
                                                    </p>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <h5>欢迎预定：</h5>
                                                            <asp:LinkButton ID="booking" CommandArgument='<%# Eval("rtid") %>' OnClientClick=" return yuding()" CssClass="btn btn-primary btn-xs" runat="server">点击一键预定</asp:LinkButton>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="small text-right">
                                                                <h5>空余房间数:</h5>
                                                                <div><i class="fa fa-comments-o"></i><%# roomnum(Convert.ToInt32( Eval("rtid"))) %> 间</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="row">
                                <div class="ibox float-e-margins">
                                    <div class="ibox-title">
                                        <h2 id="dingdan">我的订单</h2>                                        
                                    </div>
                                    <div class="ibox-content">
                                        <table class="table table-hover">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>姓名</th>
                                                    <th>身份证号</th>
                                                    <th>房间号</th>
                                                    <th>下单时间</th>
                                                     <th>天数</th>
                                                    <th>订单状态</th>
                                                    <th>操作</th>
                                                </tr>
                                            </thead>
                                            
                                            <tbody>
                                                
                                                <asp:Repeater ID="ddlyd" runat="server" OnItemCommand="ddlyd_ItemCommand">                                                  
                                                    <ItemTemplate>
                                                         <tr>
                                                    <td>#</td>
                                                     <td><%# Eval("Name") %></td>
                                                    <th><%# Eval("IDnumber") %></th>
                                                     <td><%# Eval("rid") %></td>
                                                    <td><%# Eval("checkintime") %></td>
                                                     <td><%# Eval("day") %></td>
                                                    <td><%# zhuangtai( Eval("status")) %></td>
                                                    <th>
                                                        <asp:LinkButton ID="quxiao" CommandArgument='<%# Eval("hid") %>' runat="server">取消订单</asp:LinkButton></th>
                                                </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                               
                                            </tbody>                                           
                                        </table>
                                        <h3><asp:Label ID="Label1" runat="server" Text=""></asp:Label></h3>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="ibox float-e-margins">
                                    <div class="ibox-title">
                                        <h2 id="lishi">历史订单</h2>
                                       
                                    </div>
                                    <div class="ibox-content">
                                        <table class="table table-hover">
                                            <thead>
                                                <tr>
                                                    <th></th>
                                                    <th>姓名</th>
                                                    <th>身份证号</th>
                                                    <th>房间号</th>
                                                    <th>下单时间</th>
                                                     <th>天数</th>
                                                    <th>订单状态</th>
                                                    <th>操作</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                 <asp:Repeater ID="ddldd" runat="server" OnItemCommand="ddldd_ItemCommand">
                                                    <ItemTemplate>
                                                   <tr>
                                                    <td>#</td>
                                                    <td><%# Eval("Name") %></td>
                                                    <th><%# Eval("IDnumber") %></th>
                                                     <td><%# Eval("rid") %></td>
                                                    <td><%# Eval("checkintime") %></td>
                                                     <td><%# Eval("day") %></td>
                                                    <td><%# zhuangtai( Eval("status")) %></td>
                                                    <td>
                                                        <asp:LinkButton ID="deletes" CommandArgument='<%# Eval("hid") %>' runat="server">删除订单</asp:LinkButton></td>
                                                </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                         <h3><asp:Label ID="Label2" runat="server" Text=""></asp:Label></h3>
                                    </div>
                                </div>
                            </div>
                        </div>
                    <div class="footer">
                        <div>
                            到底了
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
