/**  版本信息模板在安装目录下，可自行修改。
* RoomType.cs
*
* 功 能： N/A
* 类 名： RoomType
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
	/// RoomType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoomType
	{
		public RoomType()
		{}
		#region Model
		private int _rtid;
		private string _rtname;
		private int _rarea;
		private string _rprice;
		private int _racdt;
		private string _rdescribe;
		private int _isdelete=0;
		/// <summary>
		/// 
		/// </summary>
		public int rtid
		{
			set{ _rtid=value;}
			get{return _rtid;}
		}
		/// <summary>
		/// 客房类型名
		/// </summary>
		public string rtname
		{
			set{ _rtname=value;}
			get{return _rtname;}
		}
		/// <summary>
		/// 面积平方
		/// </summary>
		public int rarea
		{
			set{ _rarea=value;}
			get{return _rarea;}
		}
		/// <summary>
		/// 客房价格
		/// </summary>
		public string rprice
		{
			set{ _rprice=value;}
			get{return _rprice;}
		}
		/// <summary>
		/// 配置空调 (0－是，1－否)
		/// </summary>
		public int racdt
		{
			set{ _racdt=value;}
			get{return _racdt;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string rdescribe
		{
			set{ _rdescribe=value;}
			get{return _rdescribe;}
		}
		/// <summary>
		/// 逻辑删除,0正常,1删除
		/// </summary>
		public int isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

