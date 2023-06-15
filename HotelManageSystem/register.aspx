<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="HotelManageSystem.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle-box text-center loginscreen   animated fadeInDown">
        <div>
            <div>

                <h1 class="logo-name">B+J</h1>

            </div>
            <h3>欢迎注册</h3>
            <p>创建一个宾馆用户新账户</p>
            <div class="m-t" role="form" >
                <div class="form-group">
                    <asp:TextBox ID="uname" CssClass="form-control" placeholder="请输入姓名" required="" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="uid" CssClass="form-control" placeholder="请输入身份证号" required="" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="phone" CssClass="form-control" placeholder="请输入手机号" required="" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="upwd" CssClass="form-control" placeholder="请输入密码" required="" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="upwd2" CssClass="form-control" placeholder="请再次输入密码" required="" runat="server"></asp:TextBox>
                </div>
                <asp:Button ID="Button1" CssClass="btn btn-primary block full-width m-b" OnClientClick=" return yanz() " OnClick="Button1_Click" runat="server" Text="注 册" />
                <p class="text-muted text-center"><small>已经有账户了？</small><a href="login.aspx">点此登录</a>
                </p>

            </div>
        </div>
    </div>
    <script>
        function yanz() {
            if ($('#<%= upwd.ClientID%>').val() == $('#<%= upwd2.ClientID%>').val()) {
                var str = $('#<%= uid.ClientID%>').val();
                var phstr = $('#<%= phone.ClientID%>').val();
                var patrn = /^[1-9]\d{5}(18|19|20|(3\d))\d{2}((0[1-9])|(1[0-2]))(([0-2][1-9])|10|20|30|31)\d{3}[0-9Xx]$/;
                var patpho = /^((13[0-9])|(14[5,7])|(15[0-3,5-9])|(17[0,3,5-8])|(18[0-9])|166|198|199|(147))\d{8}$/;
                if (!patrn.test(str)) {
                    alert("请输入有效的身份证号");
                    return false;
                } else {
                    if (!patpho.test(phstr)) {
                        alert("请输入有效的手机号");
                        return false;
                    }
                    return true;
                }
            } else {
                alert("两次密码输入不一致,请核对!");
                return false;
            }
        }

       

        $(document).ready(function () {
            $('.i-checks').iCheck({
                checkboxClass: 'icheckbox_square-green',
                radioClass: 'iradio_square-green',
            });
        });
    </script>
</asp:Content>
