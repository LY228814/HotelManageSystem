<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="roomtype.aspx.cs" Inherits="HotelManageSystem.roomtype" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="wrapper wrapper-content ">
                <div class="ibox">
                    <div class="ibox-content">
                        <span class="text-muted small pull-right">最后更新：<i class="fa fa-clock-o"></i> <asp:Label ID="time" runat="server" Text=""></asp:Label></span>
                        <h2 >客房类型列表</h2> 
                        
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
                                                        <td><h3><input type="button" class="btn btn-white btn-bitbucket btn-rounded" onclick='location.href=("detail.aspx")' value="+" />客房类型</h3></td>
                                                        <td><h3>客房面积</h3></td>
                                                        <td><h3>客房价格</h3></td>
                                                        <td><h3>配置空调</h3></td>
                                                        <td><h3>描述</h3></td>
                                                        <td><h3>操作</h3></td>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                   <asp:Repeater ID="articletable" runat="server" OnItemCommand="articletable_ItemCommand">
                                                        <ItemTemplate>
                                                       <tr>
                                                      <td><%# Eval("rtname") %></td>
                                                      <td><%# Eval("rarea") %>㎡</td>
                                                      <td><%# Eval("rprice") %>元</td>
                                                      <td><%# Convert.ToInt32(Eval("racdt"))==0?"已配置":"未配置"  %></td>
                                                      <td><%# Eval("rdescribe") %></td>
                                                        <td>
                                                            <a  href='detail.aspx?rtid=<%#Eval("rtid") %>'>修改</a>
                                                            <asp:LinkButton ID="Adelete" CommandArgument='<%# Eval("rtid") %>' CommandName="checkout" runat="server">删除</asp:LinkButton>
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
