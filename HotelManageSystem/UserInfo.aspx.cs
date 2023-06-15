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
    public partial class UserInfo : System.Web.UI.Page
    {
        DAL.UserInfo dalusr = new DAL.UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Dataloading();
            }
        }
        private void Dataloading()
        {
            string rid = SStext.Text.Trim();
            DataSet ds;
            if (rid!=null)
            {
                ds = dalusr.GetList(" type=0 and isdelete=0 and IDnumber like '%" + rid+"%'");
            }
            else
            {
                ds = dalusr.GetList("type=0 and isdelete=0");
            }
            articletable.DataSource = ds;
            articletable.DataBind();
            time.Text = DateTime.Now.ToString();
        }

        protected void sousuo_Click(object sender, EventArgs e)
        {
            Dataloading();
        }

        protected void articletable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string rtid = ConvertHelper.GetString(e.CommandArgument);
            HotelManageSystem.Model.UserInfo model = dalusr.GetModel(rtid);
            if (model != null)
            {
                model.isdelete = 1;
                bool result = dalusr.Update(model);
                if (result)
                {
                    ScriptHelper.ShowAlertScript(this.Page, "删除成功");
                    Dataloading();
                }
            }
        }
    }
}