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

    public partial class roomtype : System.Web.UI.Page
    {
        DAL.RoomType dalrtype = new DAL.RoomType();
        protected void Page_Load(object sender, EventArgs e)
        {
            Dataloading();
        }
        private void Dataloading()
        {
            DataSet ds = dalrtype.GetList("isdelete=0");
            articletable.DataSource = ds;
            articletable.DataBind();
            time.Text = DateTime.Now.ToString();
        }
        protected void articletable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int rtid = ConvertHelper.GetInteger(e.CommandArgument);
            HotelManageSystem.Model.RoomType model = dalrtype.GetModel(rtid);
            if (model != null)
            {
                model.isdelete = 1;
                bool result = dalrtype.Update(model);
                if (result)
                {
                    ScriptHelper.ShowAlertScript(this.Page, "删除成功");
                    Dataloading();
                }
            }
        }
    }
}