<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="RoomInfor.aspx.cs" Inherits="HotelManageSystem.RoomInfor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content ">
        <div class="ibox">
            <div class="ibox-content">
                <span class="text-muted small pull-right">最后更新：<i class="fa fa-clock-o"></i>
                    <asp:Label ID="time" runat="server" Text=""></asp:Label></span>
                <h2>客房状态</h2>
            </div>
            <div class="ibox-content">
                <div class="row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-8">
                        <div class="input-group">
                            <asp:TextBox ID="SStext" type="text" placeholder="请输入房间号查询房间信息" CssClass="input form-control" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="sousuo" CssClass="btn btn-sm btn-primary" runat="server" Text="搜索" OnClick="sousuo_Click" />
                                <input type="button" class="btn btn-sm btn1" onclick='location.href=("RoomInforDetail.aspx")' value="添加" />
                            </span>
                        </div>
                    </div>
                </div>
                <div class="clients-list">
                    <div class="tab-content">
                        <div id="tab-1" class="tab-pane active">
                            <div class="full-height-scroll">
                                <div class="table-responsive">
                                    <table class="table table-striped table-hover">

                                        <thead>
                                            <tr>
                                                <td>
                                                    <h3>客房号</h3>
                                                </td>
                                                <td>
                                                    <h3>楼层</h3>
                                                </td>
                                                <td>
                                                    <h3>房间类型</h3>
                                                </td>
                                                <td>
                                                    <h3>房间价格</h3>
                                                </td>
                                                <td>
                                                    <h3>操作</h3>
                                                </td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Repeater ID="articletable" runat="server" OnItemCommand="articletable_ItemCommand" >
                                                <ItemTemplate>
                                                    <tr>
                                                        <td><%# Eval("rid") %>号</td>
                                                        <td><%# Eval("rfloor") %>楼</td>
                                                        <td><%# Eval("rtname") %></td>
                                                        <td><%# Eval("rprice") %></td>
                                                        <td>
                                                            <a  href='RoomInforDetail.aspx?roid=<%#Eval("roid") %>'>修改</a>
                                                            <asp:LinkButton ID="Adelete" CommandArgument='<%# Eval("roid") %>' CommandName="checkout" runat="server">删除</asp:LinkButton>
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
