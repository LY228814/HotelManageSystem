using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KangHui.Common;
using HotelManageSystem.DAL;
using HotelManageSystem.Model;
using System.Data;
namespace HotelManageSystem
{
    public partial class RoomInforDetail : System.Web.UI.Page
    {
        DAL.RoomInfor rinfo = new DAL.RoomInfor();
        DAL.HousingInfor housin = new DAL.HousingInfor();
        DAL.RoomType roomty = new DAL.RoomType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitDetail();
            }
        }

        public void InitDetail()
        {
            int roid = ConvertHelper.GetInteger(Request["roid"]);
            HotelManageSystem.Model.RoomInfor model = rinfo.GetModel(roid);
            if (model != null)
            {
                terid.Text = model.rid.ToString();
                terfloor.Text = model.rfloor.ToString();
                tedescription.Text = model.description;
            }
            roomtype(roid.ToString());
        }
        protected void tijiao_Click(object sender, EventArgs e)
        {
            int rid = ConvertHelper.GetInteger(terid.Text.Trim());
            int rfloor = ConvertHelper.GetInteger(terfloor.Text.Trim());
            string description = tedescription.Text.Trim();
            int roid = ConvertHelper.GetInteger(Request["roid"]);
            HotelManageSystem.Model.RoomInfor model = rinfo.GetModel(roid);
            if (model != null)
            {
                model.rid = rid;
                model.rfloor = rfloor;
                model.tid = ConvertHelper.GetInteger(ddlroom.SelectedValue);
                model.description = description;
                bool result = rinfo.Update(model);
                if (result)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新成功", "roominfor.aspx");
                }
            }
            else
            {
                Model.RoomInfor moRoomIn = new Model.RoomInfor();
                moRoomIn.rid = rid;
                moRoomIn.rfloor = rfloor;
                moRoomIn.tid = ConvertHelper.GetInteger(ddlroom.SelectedValue);
                moRoomIn.description = description;
                int result = rinfo.Add(moRoomIn);
                if (result>0)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加成功", "roominfor.aspx");
                }
            }
        }

        public void roomtype(string roid)
        {
            DataSet ds = roomty.GetList("isdelete = 0");
            ddlroom.DataSource = ds;
            ddlroom.DataTextField = "rtname";
            ddlroom.DataValueField = "rtid";
            ddlroom.DataBind();
            ddlroom.Items.Insert(0, new ListItem("请选择房间类型", "0"));

            if (!string.IsNullOrEmpty(roid))
            {
                ddlroom.SelectedValue = roid;
            }
        }
    }
}