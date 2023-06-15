
using System;
namespace HotelManageSystem.Model
{
	/// <summary>
	/// ExchangeRR:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ExchangeRR
	{
		public ExchangeRR()
		{}
		#region Model
		private int _eid;
		private int _hid;
		private int? _cid;
		private int _beforerid;
		private int _nowrid;
		private string _exchangereason;
		private string _exchangetime;
		private int _isdelete;
		/// <summary>
		/// 换房记录表id
		/// </summary>
		public int eid
		{
			set{ _eid=value;}
			get{return _eid;}
		}
		/// <summary>
		/// 住宿订单id
		/// </summary>
		public int hid
		{
			set{ _hid=value;}
			get{return _hid;}
		}
		/// <summary>
		/// 客户id
		/// </summary>
		public int? cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 原房间号
		/// </summary>
		public int beforerid
		{
			set{ _beforerid=value;}
			get{return _beforerid;}
		}
		/// <summary>
		/// 现房间号
		/// </summary>
		public int nowrid
		{
			set{ _nowrid=value;}
			get{return _nowrid;}
		}
		/// <summary>
		/// 换房原因
		/// </summary>
		public string exchangeReason
		{
			set{ _exchangereason=value;}
			get{return _exchangereason;}
		}
		/// <summary>
		/// 换房时间
		/// </summary>
		public string exchangetime
		{
			set{ _exchangetime=value;}
			get{return _exchangetime;}
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

