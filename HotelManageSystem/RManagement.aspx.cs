using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManageSystem.DAL;
using HotelManageSystem.Model;
using System.Data;
using KangHui.Common;


namespace HotelManageSystem
{
    public partial class RManagement : System.Web.UI.Page
    {
        DAL.HousingInfor dalhou = new DAL.HousingInfor();
        Model.HousingInfor mohou = new Model.HousingInfor();
        DAL.RoomInfor dalroom = new DAL.RoomInfor();
        DAL.UserInfo mouser = new DAL.UserInfo();
        Model.RoomInfor moroom = new Model.RoomInfor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                homepage();
            }
               
        }

        /// <summary>
        /// 页面数据加载渲染
        /// </summary>
        public void homepage()
        {
            string id = Request["hid"].ToString();
            if (id != null)
            {
                int hid = Convert.ToInt32(id);
                mohou = dalhou.GetModel(hid);
                userid.Text = mohou.uid;
                Uname.Text = mouser.GetModel(mohou.uid).Name;
                DataSet ds = dalroom.GetHousingds(Convert.ToInt32(mohou.rnumber));
                room.Text = ds.Tables[0].Rows[0]["rid"].ToString();
                danjia.Text = ds.Tables[0].Rows[0]["rprice"].ToString();
                rtype.Text = ds.Tables[0].Rows[0]["rtname"].ToString();
                dayes.Text = mohou.day.ToString();
                exptime.Text = mohou.Expiretime.ToString();
                intime.Text = mohou.checkintime.ToString();
                roomlist();
            }
        }

        public void roomlist()
        {
            ddlrooms.DataSource = dalroom.GetList("rstate = 0");
            ddlrooms.DataTextField = "rid";
            ddlrooms.DataValueField = "roid";
            ddlrooms.DataBind();
            ddlrooms.Items.Insert(0, new ListItem("请选择更换的房间", "0"));           
        }

        /// <summary>
        /// 换房方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void butchange_Click(object sender, EventArgs e)
        {
            int newroid = Convert.ToInt32(ddlrooms.SelectedValue);
            int id = int.Parse(Request["hid"]);
            mohou = dalhou.GetModel(id);
            moroom = dalroom.GetModel((int)mohou.rnumber);
            moroom.rstate = 0;
            dalroom.Update(moroom);
            moroom = dalroom.GetModel(newroid);
            moroom.rstate = 2;
            dalroom.Update(moroom);
            mohou.rnumber = newroid;
            bool tf= dalhou.Update(mohou);
            if (tf)
            {
                ScriptHelper.ShowAlertAndCloseScript(this.Page, "换房成功");
                homepage();
            }
        }
        /// <summary>
        /// 续住方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void butrenewal_Click(object sender, EventArgs e)
        {
            int newday = int.Parse(day.Text);
            int id = int.Parse( Request["hid"]);
            mohou = dalhou.GetModel(id);
            mohou.day = mohou.day + newday;
            mohou.Expiretime = ((DateTime)mohou.Expiretime).AddDays(newday);
            bool tf= dalhou.Update(mohou);
            if (tf)
            {
                ScriptHelper.ShowAlertAndCloseScript(this.Page,"续住成功");
                homepage();
            }
        }

        /// <summary>
        /// 退房方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tuifang_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request["hid"]);
            mohou = dalhou.GetModel(id);
            mohou.checkouttime = DateTime.Now;
            mohou.status = 2;
           dalhou.Update(mohou);
            moroom= dalroom.GetModel((int)mohou.rnumber);
            moroom.rstate = 0;
            dalroom.Update(moroom);
            bool tf = dalhou.Update(mohou);
            if (tf)
            {
                ScriptHelper.ShowAlertAndRedirectScript(this.Page, "退房成功","Guestroom.aspx");              
            }
        }
    }

}