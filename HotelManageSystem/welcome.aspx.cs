using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotelManageSystem.Model;
using HotelManageSystem.DAL;
using System.Data;
using KangHui.Common;

namespace HotelManageSystem
{
    public partial class welcome : System.Web.UI.Page
    {
        DAL.RoomInfor rinfo = new DAL.RoomInfor();
        DAL.HousingInfor housin = new DAL.HousingInfor();
        DAL.RoomType dalroty = new DAL.RoomType();
        Model.HousingInfor moho = new Model.HousingInfor();
        Model.RoomInfor moro = new Model.RoomInfor();
        Model.UserInfo mouser = new Model.UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listrtype();
            }
        }                                                                            

        public void listrtype()
        {
            mouser = (Model.UserInfo)Session["MoUser"];
            if (mouser!=null)
            {
                DataSet ds = dalroty.GetList("isdelete=0");
                ddlroty.DataSource = ds;
                ddlroty.DataBind();
                ds = housin.GethurList("(status= 1 or status= 0 ) and h.uid='"+ mouser.IDnumber+"'");
                if (ds.Tables[0].Rows.Count<=0)
                {
                    Label1.Text = "您还没有订单";
                }
                ddlyd.DataSource = ds;
                ddlyd.DataBind();
                ds = housin.GethurList("(status= 2 or status= 3 )and h.uid='" + mouser.IDnumber+"'");
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    Label2.Text = "您还没有订单";
                }
                ddldd.DataSource = ds;
                ddldd.DataBind();
            }
          
        }

        public string zhuangtai(object status)
        {
            int sid = ConvertHelper.GetInteger(status);
            if (sid == 0)
            {
                return "住宿中";
            }
            else if (sid == 1)
            {
                return "预订单";
            }
            else if (sid == 2)
            {
                return "已结账";
            }
            else
            {
                return "订单取消";
            }
        }
        protected void ddlroty_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rtid = Convert.ToInt32(e.CommandArgument);
            DataSet ds= rinfo.GetList("tid=" + rtid + " and rstate=" + 0 + "and isdelete = 0");
            if (ds.Tables[0].Rows.Count>0)
            {
                mouser = (Model.UserInfo)Session["MoUser"];
                if (mouser!=null)
                {
                    Model.HousingInfor moho = new Model.HousingInfor();
                    moho.day = 1;
                    moho.eatime = DateTime.Now;
                    moho.isdelete = 0;
                    moho.rnumber = Convert.ToInt32(ds.Tables[0].Rows[0]["roid"]);
                    moho.uid = mouser.IDnumber;
                    moho.status = 1;
                    int hs= housin.Add(moho);
                    if (hs>0)
                    {
                        moro = rinfo.GetModel((int)moho.rnumber);
                        moro.rstate = 1;
                        rinfo.Update(moro);
                        ScriptHelper.ShowAlertAndCloseScript(this.Page,"预定成功!");
                    }
                }
                else
                {
                    ScriptHelper.ShowAlertAndTopRedirectScript(this.Page, "您还没有登录或登录过期,请先登录!", "Login.asopx;");
                }
            }
            else
            {
                ScriptHelper.ShowAlertAndCloseScript(this.Page, "该类型已经没有房间了,请选择其他类型!");
            }
            listrtype();
        }

        public int roomnum( int rtid)
        {
           return rinfo.GetRecordCount("tid="+rtid+ " and rstate="+0+"and isdelete = 0");
        }

        protected void ddlyd_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int hid = Convert.ToInt32(e.CommandArgument);
            moho = housin.GetModel(hid);
            if (moho.status==0)
            {
                ScriptHelper.ShowAlertAndCloseScript(this.Page, "该订单处于入住状态中,如需取消请前往前台处理!!");
            }
            else if (moho.status == 1)
            {
                moho.status = 3;
                moro = rinfo.GetModel((int)moho.rnumber);
                moro.rstate = 0;
                rinfo.Update(moro);
                housin.Update(moho);
            }
            listrtype();
        }

        protected void ddldd_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int hid = Convert.ToInt32(e.CommandArgument);
            moho = housin.GetModel(hid);
            moho.isdelete = 1;
            if (housin.Update(moho))
            {
                ScriptHelper.ShowAlertAndCloseScript(this.Page, "订单删除成功!");
            }
            listrtype();
        }
    }
}