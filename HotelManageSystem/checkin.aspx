<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="checkin.aspx.cs" Inherits="HotelManageSystem.checkin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>预约登记</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="form-horizontal">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">姓名</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="texuname" runat="server" placeholder="请输入顾客姓名" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">身份证号</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="texuid" runat="server" placeholder="请输入顾客身份证号" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">房间</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlroom" CssClass="input-sm form-control input-s-sm inline" runat="server">
                                        <asp:ListItem Value="0">请选择房间</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">类型</label>
                                <div class="col-sm-6">
                                    <asp:RadioButtonList ID="Usex" CssClass="form-control put1 " RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Selected="True" Value="0" Text="登记入住"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="提前预约"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">天数</label>
                                <div class="col-sm-6">
                                    <div class="btn-group">
                                        <a id="dayj" class="btn btn-primary">-1</a>
                                        <asp:TextBox ID="day" CssClass="btn btn-white" runat="server" Width="81px">1</asp:TextBox>
                                        <a id="dayz" class="btn btn-primary">+1</a>
                                    </div>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">客人备注</label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="Textbz" runat="server" placeholder="请输入备注内容" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <asp:Button ID="tijiao" CssClass="btn btn-primary" runat="server" OnClientClick="return yanz()" Text="确认提交" OnClick="tijiao_Click" />
                                    <a class="btn btn-white" href="Guestroom.aspx">取消</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function yanz() {
                var str = $('#<%= texuid.ClientID%>').val();
                 var patrn = /^[1-9]\d{5}(18|19|20|(3\d))\d{2}((0[1-9])|(1[0-2]))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$/;
            if (!patrn.test(str)) {
                alert("请输入有效的身份证号");
                return false;
            } else {
                return true;
            }               
                     
               }


        $(function () {
            $("#dayj").click(function () {
                var day = $("#<%= day.ClientID %>").val();
                if (day > 1) {
                    $("#<%= day.ClientID%>").val(day - 1);
                }
            });
            $("#dayz").click(function () {
                var day = $("#<%= day.ClientID %>").val();
                $("#<%= day.ClientID%>").val(day - 1 + 2);
            });
        })
    </script>
</asp:Content>
