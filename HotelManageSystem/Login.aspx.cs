using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManageSystem.DAL;
using HotelManageSystem.Model;
using KangHui.Common;
using System.Data;

namespace HotelManageSystem
{
    public partial class Login : System.Web.UI.Page
    {
        DAL.UserInfo daluser = new DAL.UserInfo();
        Model.UserInfo modeuser = new Model.UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            modeuser  = daluser.GetModel(ConvertHelper.GetString( Textname.Text));
                if (modeuser!=null)
                {
                    if (modeuser.Upwd == ConvertHelper.GetString(Textpwd.Text))
                    {
                    Session["MoUser"] = modeuser;
                    if (modeuser.type == 1)
                    {
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        Response.Redirect("welcome.aspx");
                    }
                        
                    }
                    Response.Write("<script> alert('密码错误') </script>");
                }
            Response.Write("<script> alert('身份证号不正确或还没注册') </script>");
        }
    }
}