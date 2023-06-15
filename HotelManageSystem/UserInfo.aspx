<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="HotelManageSystem.UserInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="wrapper wrapper-content ">
                <div class="ibox">
                    <div class="ibox-content">
                        <span class="text-muted small pull-right">最后更新：<i class="fa fa-clock-o"></i> <asp:Label ID="time" runat="server" Text=""></asp:Label></span>
                        <h2>用户信息列表</h2> 
                     </div>
                    <div class="ibox-content">
                        <div class="row">
                        <div class="col-sm-2"></div>
                        <div class="col-sm-8">
                          <div class="input-group">
                            <asp:TextBox ID="SStext" type="text" placeholder="请输入身份证号查询用户信息" CssClass="input form-control" runat="server"></asp:TextBox>
                            <span class="input-group-btn">
                                <asp:Button ID="sousuo" CssClass="btn btn-sm btn-primary" runat="server" Text="搜索" OnClick="sousuo_Click" />
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
                                                        <td><h3>姓名</h3></td>
                                                        <td><h3>身份证号</h3></td>
                                                        <td><h3>手机号</h3></td>
                                                        <td><h3>性别</h3></td>
                                                        <td><h3>生日</h3></td>
                                                        <td><h3>户籍地</h3></td>
                                                        <td><h3>操作</h3></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                   <asp:Repeater ID="articletable" runat="server" OnItemCommand="articletable_ItemCommand">
                                                        <ItemTemplate>
                                                       <tr>
                                                      <td><%# Eval("Name") %></td>
                                                      <td><%# Eval("IDnumber") %></td>
                                                        <td><%# Eval("Phone") %></td>
                                                        <td><%# Convert.ToInt32(Eval("gender"))==0?"女士":"先生"  %></td>
                                                        <td><%# Eval("birthday") %></td>
                                                      <td><%# Eval("birthplace") %></td>
                                                        <td>
                                                            <asp:LinkButton ID="Acreate" CommandArgument='<%# Eval("IDnumber") %>' CommandName="checkin" runat="server">删除用户信息</asp:LinkButton>
                                                            <asp:LinkButton ID="Adelete" CommandArgument='<%# Eval("Uid") %>' CommandName="checkout" runat="server"></asp:LinkButton>
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
