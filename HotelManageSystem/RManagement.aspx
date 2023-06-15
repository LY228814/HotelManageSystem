<%@ Page Title="" Language="C#" MasterPageFile="~/staticMaster.Master" AutoEventWireup="true" CodeBehind="RManagement.aspx.cs" Inherits="HotelManageSystem.RManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper wrapper-content">
        <div class="row">
            <div class="col-sm-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>客房订单信息</h5>
                    </div>
                    <div class="ibox-content">
                        <div class="form-horizontal">
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">房客姓名</label>
                                <div class="col-sm-6">
                                    <asp:Label ID="Uname" CssClass="form-control-static" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">身份证号</label>
                                <div class="col-sm-6">
                                    <asp:Label ID="userid" CssClass="form-control-static" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">房间号</label>
                                <div class="col-sm-6">
                                   <asp:Label ID="room" CssClass="form-control-static" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">房间类型</label>
                                <div class="col-sm-6">
                                   <asp:Label ID="rtype" CssClass="form-control-static" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                             <div class="form-group">
                                <label class="col-sm-2 control-label">房间单价</label>
                                <div class="col-sm-6">
                                   <asp:Label ID="danjia" CssClass="form-control-static" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">入住天数</label>
                                <div class="col-sm-6">
                                  <asp:Label ID="dayes" CssClass="form-control-static" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">入住时间</label>
                                <div class="col-sm-6">
                                  <asp:Label ID="intime"  CssClass="form-control-static"  runat="server"  Text="" ></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">预到期时间</label>
                                <div class="col-sm-6">
                                  <asp:Label ID="exptime"  CssClass="form-control-static"  runat="server"  Text="" ></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">客人备注</label>
                                <div class="col-sm-6">
                                    <asp:Label ID="备注" CssClass="form-control-static" runat="server" Text="无"></asp:Label>
                                </div>
                            </div>
                            <div class="hr-line-dashed"></div>
                            <div class="form-group">
                                <div class="col-sm-4 col-sm-offset-2">
                                    <a data-toggle="modal" class="btn btn-primary" href="#modal-change">换房</a>
                                    <a data-toggle="modal" class="btn btn-primary" href="#modal-renewal">续房</a>
                                    <asp:Button ID="tuifang" CssClass="btn btn-primary"  runat="server" OnClientClick="return tuifang()" Text="退房" OnClick="tuifang_Click" />
                                    <a class="btn btn-white" href="Guestroom.aspx">返回</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="modal-change" class="modal fade" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <div class="row">
                        <h3 class="m-t-none m-b">更换房间</h3>
                            <div class="form-group">
                                <label class="col-sm-3 control-label">原房间</label>
                                <div class="col-sm-9">
                                    <p class="form-control-static">
                                        <asp:Label ID="oroom" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">更换房间</label>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlrooms" CssClass="input-sm form-control input-s-sm inline" runat="server">
                                        <asp:ListItem Value="0">请选择新房间</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div>
                                <div class="hr-line-dashed"></div>
                                <div class="hr-line-dashed"></div>
                                <div class="form-group">
                                    <div class="col-sm-4 col-sm-offset-2">
                                        <asp:Button ID="butchange" CssClass="btn btn-primary" runat="server" Text="确认更换" OnClientClick="return dianji()"  OnClick="butchange_Click" />
                                    </div>
                                </div>

                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <div id="modal-renewal" class="modal fade" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">              
                <div class="modal-body">
                    <div class="row">
                        <h3 class="m-t-none m-b">>续住天数</h3>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">续住天数</label>
                               <div class="btn-group">
                                        <a id="dayj" class="btn btn-primary">-1</a>
                                        <asp:TextBox ID="day" CssClass="btn btn-white" runat="server" Width="81px">1</asp:TextBox>
                                        <a id="dayz" class="btn btn-primary">+1</a>
                                    </div>
                            </div>
                            <div>
                                <div class="hr-line-dashed"></div>
                                <div class="form-group">
                                    <div class="col-sm-4 col-sm-offset-2"> 
                                        <asp:Button ID="butrenewal" CssClass="btn btn-primary" runat="server" Text="确认提交" OnClick="butrenewal_Click" />
                                    </div>
                                </div>
                           </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    <script>
        function tuifang() {
            if (confirm('确定要退房吗?') == true) {
                alert("该用户一共消费了:" + $("#<%= danjia.ClientID %>").text() * $("#<%= dayes.ClientID %>").text());
               
                return true;

            } else {
                return false;

            }
        }
        function dianji() {
            if (confirm("确定要换房吗?") == true) {
                return true;

             } else {
                 return false;

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
