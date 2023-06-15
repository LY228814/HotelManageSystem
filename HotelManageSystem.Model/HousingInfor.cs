using System;
namespace HotelManageSystem.Model
{
	/// <summary>
	/// HousingInfor:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class HousingInfor
	{
		public HousingInfor()
		{}
		#region Model
		private int _hid;
		private string _uid;
		private int? _rnumber;
		private DateTime? _checkintime;
		private DateTime? _eatime;
		private DateTime? _expiretime;
		private DateTime? _checkouttime;
		private int _day;
		private int? _status;
		private string _note;
		private int _isdelete;
		/// <summary>
		/// 住房订单id
		/// </summary>
		public int hid
		{
			set{ _hid=value;}
			get{return _hid;}
		}
		/// <summary>
		/// 客户id
		/// </summary>
		public string uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 房间号
		/// </summary>
		public int? rnumber
		{
			set{ _rnumber=value;}
			get{return _rnumber;}
		}
		/// <summary>
		/// 入住时间
		/// </summary>
		public DateTime? checkintime
		{
			set{ _checkintime=value;}
			get{return _checkintime;}
		}
		/// <summary>
		/// 预计到达时间
		/// </summary>
		public DateTime? eatime
		{
			set{ _eatime=value;}
			get{return _eatime;}
		}
		/// <summary>
		/// 到期时间
		/// </summary>
		public DateTime? Expiretime
		{
			set{ _expiretime=value;}
			get{return _expiretime;}
		}
		/// <summary>
		/// 退房时间
		/// </summary>
		public DateTime? checkouttime
		{
			set{ _checkouttime=value;}
			get{return _checkouttime;}
		}
		/// <summary>
		/// 天数
		/// </summary>
		public int day
		{
			set{ _day=value;}
			get{return _day;}
		}
		/// <summary>
		/// 状态(0进行中1预约订单 2已完结)
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
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

