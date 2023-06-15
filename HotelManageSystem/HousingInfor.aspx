<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="HousingInfor.aspx.cs" Inherits="HotelManageSystem.HousingInfor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content ">
        <div class="ibox">
            <div class="ibox-content">
                <span class="text-muted small pull-right">最后更新：<i class="fa fa-clock-o"></i>
                    <asp:Label ID="time" runat="server" Text=""></asp:Label></span>
                <h2>客房订单列表</h2>
            </div>
            <div class="ibox-content">
                <div class="clients-list">
                    <div class="tab-content">
                        <div id="tab-1" class="tab-pane active">
                            <div class="full-height-scroll">
                                <div class="table-responsive">
                                    <table class="table table-striped table-hover">

                                        <thead>
                                            <tr>
                                                <td>
                                                    <h3>姓名</h3>
                                                </td>
                                                <td>
                                                    <h3>房间号</h3>
                                                </td>
                                                <td>
                                                    <h3>入住时间</h3>
                                                </td>
                                                <td>
                                                    <h3>退房时间</h3>
                                                </td>
                                                <td>
                                                    <h3>天数</h3>
                                                </td>
                                                <td>
                                                    <h3>状态</h3>
                                                </td>
                                                <td>
                                                    <h3>备注</h3>
                                                </td>
                                                <td>
                                                    <h3>操作</h3>
                                                </td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="articletable" runat="server" OnItemCommand="articletable_ItemCommand">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("Name") %></td>
                                                        <td><%# Eval("rid") %></td>
                                                        <td><%# Eval("checkintime") %></td>
                                                        <td><%# Eval("checkouttime") %></td>
                                                        <td><%# Eval("day") %></td>
                                                        <td><%# zhuangtai( Eval("status")) %></td>
                                                        <td><%# Eval("note") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="Adelete" CommandArgument='<%# Eval("hid") %>' CommandName="delete" runat="server">删除</asp:LinkButton>||
                                                            <asp:LinkButton ID="Acreate" CommandArgument='<%# Eval("hid") %>' CommandName="look" runat="server">查看订单详情</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
