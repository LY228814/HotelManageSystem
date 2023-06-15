using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManageSystem.Model;
using HotelManageSystem.DAL;
using KangHui.Common;

namespace HotelManageSystem
{
    public partial class register : System.Web.UI.Page
    {
        Model.UserInfo mouser = new Model.UserInfo();
        DAL.UserInfo daluser = new DAL.UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userid = uid.Text.Trim();
            mouser = daluser.GetModel(userid);
            
            if (mouser!=null)
            {
                mouser.Upwd = upwd.Text.Trim();
                mouser.Name = uname.Text.Trim();
                mouser.Phone = phone.Text.Trim();
                bool tf = daluser.Update(mouser);
                if (tf)
                {
                   
                   ScriptHelper.ShowAlertAndTopRedirectScript(this.Page, "注册成功", "Login.aspx");

                }
                else
                {
                    ScriptHelper.ShowAlertAndTopRedirectScript(this.Page, "注册失败，稍后重试", "Login.aspx");
                }
            }
            else
            {
                mouser = new Model.UserInfo();
                mouser.Name = uname.Text.Trim();
                mouser.IDnumber = uid.Text.Trim();
                mouser.Upwd = upwd.Text.Trim();
                mouser.Phone = phone.Text.Trim();
                string[] uiag = new string[3];
                uiag = bgp(uid.Text.Trim());
                mouser.birthday = Convert.ToDateTime(uiag[0]);
                mouser.gender = Convert.ToInt32(uiag[1]);
                mouser.birthplace = uiag[2];
                int hs = daluser.Add(mouser);
                if (hs > 0)
                {
                    ScriptHelper.ShowAlertAndTopRedirectScript(this.Page, "注册成功", "Login.aspx");
                }
                else
                {
                    ScriptHelper.ShowAlertScript(this.Page, "注册失败,请重试!!");
                }
            }
            

        }

        public string[] bgp(string identityCard)
        {
            string[] usrrin = new string[3];
            usrrin[0] = identityCard.Substring(6, 4) + "-" + identityCard.Substring(10, 2) + "-" + identityCard.Substring(12, 2);
            string strSex = identityCard.Substring(16, 1);
            if (int.Parse(strSex) % 2 == 0)//性别代码为偶数是女性奇数为男性
            {
                usrrin[1] = "0";
            }
            else
            {
                usrrin[1] = "1";
            }
            string pro = identityCard.Substring(0, 6);
            usrrin[2] = daluser.province(pro);
            return usrrin;
        }
    }
}