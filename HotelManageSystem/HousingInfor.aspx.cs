using KangHui.BaseClass;
using KangHui.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManageSystem
{
    public partial class HousingInfor : System.Web.UI.Page
    {
        string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
        DAL.HousingInfor dalrtype = new DAL.HousingInfor();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetHousingList();
        }
        private void Dataloading()
        {
            DataSet ds = dalrtype.GetList("");
            articletable.DataSource = ds;
            articletable.DataBind();
            time.Text = DateTime.Now.ToString();
        }
        public void GetHousingList()
        {
            DataSet ds = dalrtype.GethurList("");
            articletable.DataSource = ds;
            articletable.DataBind();
            time.Text = DateTime.Now.ToString();

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
        protected void articletable_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int hid = ConvertHelper.GetInteger(e.CommandArgument);
            if (e.CommandName== "delete")
            {
               
                HotelManageSystem.Model.HousingInfor model = dalrtype.GetModel(hid);
                if (model != null)
                {
                    model.isdelete = 1;
                    bool result = dalrtype.Update(model);
                    if (result)
                    {
                        ScriptHelper.ShowAlertScript(this.Page, "删除成功");
                        GetHousingList();
                    }
                }
            }
            else if (e.CommandName == "look")
            {
                Response.Redirect("RManagement.aspx?hid=" + hid + "");
            }
            
        }
    }
}