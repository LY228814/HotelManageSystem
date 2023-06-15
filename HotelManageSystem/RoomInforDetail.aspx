<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="RoomInforDetail.aspx.cs" Inherits="HotelManageSystem.RoomInforDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>客房信息</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="form-horizontal">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">客房号</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="terid" runat="server" placeholder="请输入客房号" CssClass="form-control"></asp:TextBox>                                   
                                </div>
                            </div>
                             <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">客房楼层</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="terfloor" runat="server" placeholder="请输入客房楼层" CssClass="form-control"></asp:TextBox>                                   
                                </div>
                            </div>
                             <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">选择客房类型</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlroom" CssClass="input-sm form-control input-s-sm inline" runat="server">
                                        <asp:ListItem Value="0">请选择类型</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">描述</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="tedescription" runat="server" placeholder="请输入客房描述" CssClass="form-control"></asp:TextBox>                                   
                                </div>
                            </div>                   
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button ID="tijiao" CssClass="btn btn-primary" runat="server" Text="确认提交" OnClick="tijiao_Click" />
                                    <a class="btn btn-white" href="roominfor.aspx">取消</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
