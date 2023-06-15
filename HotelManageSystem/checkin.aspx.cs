using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HotelManageSystem.DAL;
using HotelManageSystem.Model;
using KangHui.Common;

namespace HotelManageSystem
{

    public partial class checkin : System.Web.UI.Page
    {
        Model.RoomInfor rmodel = new Model.RoomInfor();
        Model.HousingInfor housmo = new Model.HousingInfor();
        DAL.HousingInfor dalhou = new DAL.HousingInfor();
        DAL.RoomInfor dalroom = new DAL.RoomInfor();
        DAL.UserInfo daluser = new DAL.UserInfo();
        Model.UserInfo mouser = new Model.UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                roomlist(Request["roid"]);
            }
        }

        public void roomlist(string roid)
        {
            DataSet ds = dalroom.GetList("rstate = 0");
            ddlroom.DataSource = ds;
            ddlroom.DataTextField = "rid";
            ddlroom.DataValueField = "roid";
            ddlroom.DataBind();
            ddlroom.Items.Insert(0, new ListItem("请选择房间", "0"));

            if (!string.IsNullOrEmpty(roid))
            {
                ddlroom.SelectedValue = roid;
            }
        }

        protected void tijiao_Click(object sender, EventArgs e)
        {
            Model.UserInfo model = new Model.UserInfo();
            string uid = texuid.Text.Trim();
            string uname = texuname.Text.Trim();
            int days = ConvertHelper.GetInteger(day.Text.Trim());
            string beizhu = Textbz.Text.Trim();
            int room = ConvertHelper.GetInteger(ddlroom.SelectedValue);
            rmodel = dalroom.GetModel(room);
            try
            {
                if (daluser.GetModel(uid) == null)
                {//入住用户添加
                    string[] uiag = new string[3];
                    uiag = bgp(uid);
                    mouser.Name = uname;
                    mouser.IDnumber = uid;
                    mouser.birthday = Convert.ToDateTime(uiag[0]);
                    mouser.gender = Convert.ToInt32(uiag[1]);
                    mouser.birthplace = uiag[2];
                    daluser.Add(mouser);
                }
                //入住订单生成
                housmo.uid = uid;
                housmo.rnumber = room;
                housmo.checkintime = DateTime.Now;
                housmo.Expiretime = extime(days);
                housmo.day = days;
                housmo.status = int.Parse(Usex.SelectedValue);
                int hs = dalhou.Add(housmo);
                rmodel = dalroom.GetModel(room);
                if (int.Parse(Usex.SelectedValue)==1)
                {
                    rmodel.rstate = 1;
                }
                else
                {
                    rmodel.rstate = 2;
                }
                
                dalroom.Update(rmodel);
                if (hs > 0)
                {
                    ScriptHelper.ShowAlertAndCloseScript(this.Page, "登记成功");
                }
            }
            catch
            {
                ScriptHelper.ShowAlertAndCloseScript(this.Page, "信息输入有误,核对后重试");
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


        //到期时间生成
        public DateTime extime(int tm)
        {
            DateTime time = DateTime.Now.AddDays(tm);
            TimeSpan ts = new TimeSpan(12, 00, 0);
            time = time.Date + ts; ;
            return time;
        }
    }
}