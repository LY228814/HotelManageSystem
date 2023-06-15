<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="Guestroom.aspx.cs" Inherits="HotelManageSystem.Guestroom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="wrapper wrapper-content ">
                <div class="ibox">
                    <div class="ibox-content">
                        <span class="text-muted small pull-right">最后更新：<i class="fa fa-clock-o"></i> <asp:Label ID="time" runat="server" Text=""></asp:Label></span>
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
                                <asp:Button ID="Button1" CssClass="btn btn-sm " runat="server" Text="查看未住房" OnClick="Button1_Click" />
                                <asp:Button ID="Button2" CssClass="btn btn-sm " runat="server" Text="查看已住房" OnClick="Button2_Click" />
                                <asp:Button ID="Button3" CssClass="btn btn-sm " runat="server" Text="查看预约房" OnClick="Button3_Click" />
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
                                                        <td><h3>客房号</h3></td>
                                                        <td><h3>楼层</h3></td>
                                                        <td><h3>房间类型</h3></td>
                                                        <td><h3>房间价格</h3></td>
                                                        <td><h3>入住状态</h3></td>
                                                        <td><h3>操作</h3></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                   <asp:Repeater ID="articletable" runat="server" OnItemCommand="articletable_ItemCommand" >
                                                        <ItemTemplate>
                                                       <tr>
                                                        <td><%# Eval("rid") %>号</td>
                                                        <td><%# Eval("rfloor") %>楼</td>
                                                        <td><%# Eval("rtname") %></td>
                                                        <td><%# Eval("rprice") %>元</td>
                                                        <td><%# zhuangtai(Eval("rstate")) %></td>
                                                        <td>
                                                            <asp:LinkButton ID="Acreate" CommandArgument='<%# Eval("roid") %>' CommandName="checkin" runat="server">登记入住</asp:LinkButton>||
                                                            <asp:LinkButton ID="Adelete" CommandArgument='<%# Eval("roid") %>' CommandName="checkout" runat="server">客房信息</asp:LinkButton>
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
