/**  版本信息模板在安装目录下，可自行修改。
* OrderDetails.cs
*
* 功 能： N/A
* 类 名： OrderDetails
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021/4/22 11:49:34   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace HotelManageSystem.Model
{
	/// <summary>
	/// OrderDetails:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderDetails
	{
		public OrderDetails()
		{}
		#region Model
		private int _odid;
		private int _oid;
		private string _consump;
		private decimal _amount;
		private DateTime _consumptiontime;
		private int _isdelete;
		/// <summary>
		/// 消费序号id
		/// </summary>
		public int odid
		{
			set{ _odid=value;}
			get{return _odid;}
		}
		/// <summary>
		/// 订单id
		/// </summary>
		public int oid
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 消费业务名称
		/// </summary>
		public string Consump
		{
			set{ _consump=value;}
			get{return _consump;}
		}
		/// <summary>
		/// 金额
		/// </summary>
		public decimal amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 消费时间
		/// </summary>
		public DateTime ConsumptionTime
		{
			set{ _consumptiontime=value;}
			get{return _consumptiontime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

