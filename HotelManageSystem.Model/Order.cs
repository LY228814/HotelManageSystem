/**  版本信息模板在安装目录下，可自行修改。
* Order.cs
*
* 功 能： N/A
* 类 名： Order
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021/4/22 11:49:33   N/A    初版
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
	/// Order:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Order
	{
		public Order()
		{}
		#region Model
		private int _oid;
		private int _rtid;
		private int _uid;
		private int _day;
		private decimal? _ddeposit;
		private string _note;
		private int _isdelete;
		/// <summary>
		/// 订单id
		/// </summary>
		public int oid
		{
			set{ _oid=value;}
			get{return _oid;}
		}
		/// <summary>
		/// 房间类型
		/// </summary>
		public int rtid
		{
			set{ _rtid=value;}
			get{return _rtid;}
		}
		/// <summary>
		/// 客户di
		/// </summary>
		public int uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 入住天数
		/// </summary>
		public int day
		{
			set{ _day=value;}
			get{return _day;}
		}
		/// <summary>
		/// 押金
		/// </summary>
		public decimal? ddeposit
		{
			set{ _ddeposit=value;}
			get{return _ddeposit;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string note
		{
			set{ _note=value;}
			get{return _note;}
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

