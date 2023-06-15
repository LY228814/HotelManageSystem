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
    public partial class Guestroom : System.Web.UI.Page
    {
        DAL.RoomInfor rinfo = new DAL.RoomInfor();
        DAL.HousingInfor housin = new DAL.HousingInfor();
        Model.HousingInfor moho = new Model.HousingInfor();
        Model.RoomInfor moro = new Model.RoomInfor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dataloading();
            }
        }
        protected void sousuo_Click(object sender, EventArgs e)
        {
            Dataloading();
        }
        private void Dataloading( int id = -1)
        {
            int rid = ConvertHelper.GetInteger( SStext.Text.Trim());
            DataSet ds = rinfo.GetHousingList(rid ,id);
            articletable.DataSource = ds;
            articletable.DataBind();
            time.Text = DateTime.Now.ToString();
        }

        protected void articletable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int roid = ConvertHelper.GetInteger( e.CommandArgument);
            if (e.CommandName == "checkout")
            {

                DataSet ds = housin.GetList(" rnumber ='" + roid + "'and isdelete = 0 and ( status =0 or status =1)");
                if (ds.Tables[0].Rows.Count<=0)
                {
                    ScriptHelper.ShowAlertAndCloseScript(this.Page, "还没有客户入住");
                    
                }
                else
                {
                    Response.Redirect("RManagement.aspx?hid=" +ds.Tables[0].Rows[0]["hid"] + "");
                    //Response.Redirect("checkin.aspx?roid=" + ConvertHelper.GetInteger(e.CommandArgument) + "");
                }
            }
            else
            {
                int hs = housin.GetRecordCount(" rnumber ='" + roid + "'and isdelete = 0 and ( status =0 or status =1)");
                if (hs > 0)
                {
                    DataSet ds = housin.GetList("rnumber ='" + roid + "'and isdelete = 0 and  status =1");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                         moho= housin.GetModel(ConvertHelper.GetInteger( ds.Tables[0].Rows[0]["hid"]));
                        moho.status = 0;
                        moho.checkintime = DateTime.Now;
                        moho.Expiretime = DateTime.Now.AddDays(1);
                        housin.Update(moho);
                        moro= rinfo.GetModel(roid);
                        moro.rstate = 2;
                        rinfo.Update(moro);
                        ScriptHelper.ShowAlertAndCloseScript(this.Page, "入住成功");
                        Dataloading();
                    }
                    else
                    {
                        ScriptHelper.ShowAlertAndCloseScript(this.Page, "该房间已入住,请选择其他房间");
                    }
                }
                else
                {
                    //跳转入住登记
                    Response.Redirect("checkin.aspx?roid=" + ConvertHelper.GetInteger(e.CommandArgument) + "");
                }
               
            }
        }

        /// <summary>
        /// 加载空的房间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Dataloading(0);
        }
        /// <summary>
        /// 加载已住宿的房间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            Dataloading(2);
        }
        /// <summary>
        /// 加载预约的房间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button3_Click(object sender, EventArgs e)
        {
            Dataloading(1);
        }

        public string zhuangtai( object tyid)
        {
            int tid = ConvertHelper.GetInteger(tyid);
            if (tid==0)
            {
                return "空房间";
            }
            else if (tid==1)
            {
                return "预订房";
            }
            else 
            {
                return "已住房";
            }
           
        }
    }
}