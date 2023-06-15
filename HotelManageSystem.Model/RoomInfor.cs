using System;
namespace HotelManageSystem.Model
{
	/// <summary>
	/// RoomInfor:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoomInfor
	{
		public RoomInfor()
		{}
		#region Model
		private int _roid;
		private int _rid;
		private int _tid;
		private int _rfloor;
		private int _rstate;
		private string _description;
		private int _isdelete;
		/// <summary>
		/// 客房id
		/// </summary>
		public int roid
		{
			set{ _roid=value;}
			get{return _roid;}
		}
		/// <summary>
		/// 客房号
		/// </summary>
		public int rid
		{
			set{ _rid=value;}
			get{return _rid;}
		}
		/// <summary>
		 /// 客房类型id
		 /// </summary>
		public int tid
		{
			set { _tid = value; }
			get { return _tid; }
		}
		/// <summary>
		/// 客房楼层
		/// </summary>
		public int rfloor
		{
			set{ _rfloor=value;}
			get{return _rfloor;}
		}
		/// <summary>
		/// 客房状态 (0-空房,1－预约，2－入住)
		/// </summary>
		public int rstate
		{
			set{ _rstate=value;}
			get{return _rstate;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
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

