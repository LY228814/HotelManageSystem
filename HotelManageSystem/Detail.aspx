<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="HotelManageSystem.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>客房类型设置</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="form-horizontal">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">客房类型</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="tertname" runat="server" placeholder="请输入客房类型名" CssClass="form-control"></asp:TextBox>                                   
                                </div>
                            </div>
                             <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">客房面积</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="terarea" runat="server" placeholder="请输入客房面积" CssClass="form-control"></asp:TextBox>                                   
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">客房价格</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="terprice" runat="server" placeholder="请输入客房价格" CssClass="form-control"></asp:TextBox>                                   
                                </div>
                            </div>  
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">空调</label>
                                <div class="col-sm-6">
                            <asp:DropDownList ID="ddlroom" CssClass="input-sm form-control input-s-sm inline" runat="server">
                                <asp:ListItem Value="0">已配置空调</asp:ListItem>
                                 <asp:ListItem Value="1">未配置空调</asp:ListItem>
                                </asp:DropDownList>
                                    </div>
                              </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">描述</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Terdescribe" runat="server" placeholder="请输入描述" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>                           
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button ID="tijiao" CssClass="btn btn-primary" runat="server" Text="确认提交" OnClick="tijiao_Click" />
                                    <a class="btn btn-white" href="roomtype.aspx">取消</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
