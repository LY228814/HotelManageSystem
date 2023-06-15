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
    public partial class RoomInfor : System.Web.UI.Page
    {
        DAL.RoomInfor rinfo = new DAL.RoomInfor();

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
        private void Dataloading(int id = -1)
        {
            int rid = ConvertHelper.GetInteger(SStext.Text.Trim());
            DataSet ds = rinfo.GetHousingList(rid, id);
            articletable.DataSource = ds;
            articletable.DataBind();
            time.Text = DateTime.Now.ToString();
        }

        protected void articletable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int roid = ConvertHelper.GetInteger(e.CommandArgument);
            HotelManageSystem.Model.RoomInfor model = rinfo.GetModel(roid);
            if (model != null)
            {
                model.isdelete = 1;
                bool result = rinfo.Update(model);
                if (result)
                {
                    ScriptHelper.ShowAlertScript(this.Page, "删除成功");
                    Dataloading();
                }
            }
        }
    }
}