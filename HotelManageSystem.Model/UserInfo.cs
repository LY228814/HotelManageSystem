/**  版本信息模板在安装目录下，可自行修改。
* UserInfo.cs
*
* 功 能： N/A
* 类 名： UserInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021/4/22 11:49:35   N/A    初版
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
	/// UserInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UserInfo
	{
		public UserInfo()
		{}
		#region Model
		private int _uid;
		private string _name;
		private string _idnumber;
		private string _phone;
		private string _upwd;
		private int _type;
		private int? _gender;
		private DateTime? _birthday;
		private string _birthplace;
		private int _isdelete;
		/// <summary>
		/// 用户id
		/// </summary>
		public int Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 身份证号
		/// </summary>
		public string IDnumber
		{
			set{ _idnumber=value;}
			get{return _idnumber;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string Phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Upwd
		{
			set{ _upwd=value;}
			get{return _upwd;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public int type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 性别1男0女
		/// </summary>
		public int? gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 生日
		/// </summary>
		public DateTime? birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 户籍地
		/// </summary>
		public string birthplace
		{
			set{ _birthplace=value;}
			get{return _birthplace;}
		}
		/// <summary>
		/// 逻辑删除
		/// </summary>
		public int isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		#endregion Model

	}
}

