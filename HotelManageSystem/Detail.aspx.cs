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
    public partial class Detail : System.Web.UI.Page
    {
        DAL.RoomType dalrtype = new DAL.RoomType();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitDetail();
            }
        }

        public void InitDetail()
        {
            int rtid = ConvertHelper.GetInteger(Request["rtid"]);
            HotelManageSystem.Model.RoomType model = dalrtype.GetModel(rtid);
            if (model != null)
            {
               tertname.Text=  model.rtname;
                terarea.Text=  model.rarea.ToString();
                terprice.Text= model.rprice;
                ddlroom.SelectedValue = model.racdt.ToString();
                Terdescribe.Text= model.rdescribe; 
            }
        }
        protected void tijiao_Click(object sender, EventArgs e)
        {
            if (ConvertHelper.GetInteger(Request["rtid"])==0)
            {
                string rtname = tertname.Text.Trim();
                int rarea =ConvertHelper.GetInteger( terarea.Text.Trim());
                int rprice = ConvertHelper.GetInteger(terprice.Text.Trim());
                string rdescribe = Terdescribe.Text.Trim();
                HotelManageSystem.Model.RoomType model = new Model.RoomType();
                model.rtname = rtname;
                model.rarea = rarea;
                model.rprice = rprice.ToString();
                model.racdt = ConvertHelper.GetInteger( ddlroom);
                model.rdescribe = rdescribe;
                int newid = dalrtype.Add(model);
                if (newid>0)
                {
                    ScriptHelper.ShowAlertAndRedirectScript(this.Page, "添加成功", "roomtype.aspx");
                }
            }
            else
            {
                string rtname = tertname.Text.Trim();
                int rarea = ConvertHelper.GetInteger(terarea.Text.Trim());
                int rprice = ConvertHelper.GetInteger(terprice.Text.Trim());
                string rdescribe = Terdescribe.Text.Trim();
                int rtid = ConvertHelper.GetInteger(Request["rtid"]);
                HotelManageSystem.Model.RoomType model = dalrtype.GetModel(rtid);
                if (model!=null)
                {
                    model.rtname = rtname;
                    model.rarea = rarea;
                    model.rprice = rprice.ToString();
                    model.racdt = ConvertHelper.GetInteger(ddlroom);
                    model.rdescribe = rdescribe;
                    bool result = dalrtype.Update(model);
                    if (result)
                    {
                        ScriptHelper.ShowAlertAndRedirectScript(this.Page, "更新成功", "roomtype.aspx");
                    }
                }
            }
        }
    }
}