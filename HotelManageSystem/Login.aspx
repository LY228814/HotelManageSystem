<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HotelManageSystem.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="middle-box text-center loginscreen  animated fadeInDown">
        <div>
            <div>
                <h3 class="logo-name">B+J</h3>

            </div>
            <h3>欢迎使用 B+J 宾馆</h3>

            <div class="m-t" role="form" >
                <div class="form-group">
                    <asp:TextBox ID="Textname" CssClass="form-control put1" placeholder="请输入身份证号"  maxlength="18" required="server"  runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
            <asp:TextBox type="password"  ID="Textpwd"  CssClass="form-control put1 " placeholder="请输入密码"  maxlength="14"   required="server" runat="server"></asp:TextBox>
                </div>
                 <div class="form-group">
            <div class="pull-right">
            <asp:Image Runat="server" ID="getcode" ClientIDMode="Static" ImageUrl="ValidateCode.aspx"></asp:Image>&nbsp;
                <a id="yzmsx" href="#" >点击刷新</a>
            </div>
            <asp:TextBox ID="TextYZ" CssClass="form-control put3 " Width="179px" placeholder="请输入验证码"  required="server" runat="server"></asp:TextBox>
                     <asp:Button ID="Button1" type="submit" CssClass="btn btn-primary block full-width m-t" runat="server" OnClientClick="return houtai()" Text="登 录" Height="44px" OnClick="Button1_Click1" />
                </div>
                
                <p  class="text-muted text-center"> <small>忘记密码,请重新注册</small> | | <a href="register.aspx">注册一个新账号</a></p>

            </div>
        </div>
    </div>
     <script>
         $(function () {
             $("#<%= TextYZ.ClientID%>").css("display", "inline");
            $("#yzmsx").click(function () {
                $("#getcode").attr("src", "ValidateCode.aspx?" + Math.random());
            })
        });
     </script>

     <script type="text/javascript">
    function houtai() {
        if ($("#<%= Textname.ClientID%> ").val() != "" && $("#<%= Textpwd.ClientID%>").val() != "") {
            if ($("#<%= TextYZ.ClientID%>").val() != "") {
                if ($("#<%= TextYZ.ClientID%>").val() == $.cookie('code')) {
                    return true;
                } else {
                    alert("验证码错误,请重新输入!");
                    return false;
                }
            } else {
                alert("请输入验证码!");
                return false;
            }
        } else {
            alert("请输入身份证号或密码!");
            return false;
        }
         }
     </script>
   
         

</asp:Content>
