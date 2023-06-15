/**  版本信息模板在安装目录下，可自行修改。
* HousingInfor.cs
*
* 功 能： N/A
* 类 名： HousingInfor
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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using KangHui.Common;
using KangHui.BaseClass;
namespace HotelManageSystem.DAL
{
	/// <summary>
	/// 数据访问类:HousingInfor
	/// </summary>
	public partial class HousingInfor
	{
		string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
		public HousingInfor()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("hid", connstr, "HousingInfor"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int hid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from HousingInfor");
			strSql.Append(" where hid=@hid");
			SqlParameter[] parameters = {
					new SqlParameter("@hid", SqlDbType.Int,4)
			};
			parameters[0].Value = hid;

			return DbHelperSQL.Exists(strSql.ToString(), connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HotelManageSystem.Model.HousingInfor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HousingInfor(");
			strSql.Append("uid,rnumber,checkintime,eatime,Expiretime,checkouttime,day,status,note,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@uid,@rnumber,@checkintime,@eatime,@Expiretime,@checkouttime,@day,@status,@note,@isdelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.NChar,18),
					new SqlParameter("@rnumber", SqlDbType.Int,4),
					new SqlParameter("@checkintime", SqlDbType.DateTime),
					new SqlParameter("@eatime", SqlDbType.DateTime),
					new SqlParameter("@Expiretime", SqlDbType.DateTime),
					new SqlParameter("@checkouttime", SqlDbType.DateTime),
					new SqlParameter("@day", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@note", SqlDbType.NVarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4)};
			parameters[0].Value = model.uid;
			parameters[1].Value = model.rnumber;
			parameters[2].Value = model.checkintime;
			parameters[3].Value = model.eatime;
			parameters[4].Value = model.Expiretime;
			parameters[5].Value = model.checkouttime;
			parameters[6].Value = model.day;
			parameters[7].Value = model.status;
			parameters[8].Value = model.note;
			parameters[9].Value = model.isdelete;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(), connstr, parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(HotelManageSystem.Model.HousingInfor model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HousingInfor set ");
			strSql.Append("uid=@uid,");
			strSql.Append("rnumber=@rnumber,");
			strSql.Append("checkintime=@checkintime,");
			strSql.Append("eatime=@eatime,");
			strSql.Append("Expiretime=@Expiretime,");
			strSql.Append("checkouttime=@checkouttime,");
			strSql.Append("day=@day,");
			strSql.Append("status=@status,");
			strSql.Append("note=@note,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where hid=@hid");
			SqlParameter[] parameters = {
					new SqlParameter("@uid", SqlDbType.NChar,18),
					new SqlParameter("@rnumber", SqlDbType.Int,4),
					new SqlParameter("@checkintime", SqlDbType.DateTime),
					new SqlParameter("@eatime", SqlDbType.DateTime),
					new SqlParameter("@Expiretime", SqlDbType.DateTime),
					new SqlParameter("@checkouttime", SqlDbType.DateTime),
					new SqlParameter("@day", SqlDbType.Int,4),
					new SqlParameter("@status", SqlDbType.Int,4),
					new SqlParameter("@note", SqlDbType.NVarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@hid", SqlDbType.Int,4)};
			parameters[0].Value = model.uid;
			parameters[1].Value = model.rnumber;
			parameters[2].Value = model.checkintime;
			parameters[3].Value = model.eatime;
			parameters[4].Value = model.Expiretime;
			parameters[5].Value = model.checkouttime;
			parameters[6].Value = model.day;
			parameters[7].Value = model.status;
			parameters[8].Value = model.note;
			parameters[9].Value = model.isdelete;
			parameters[10].Value = model.hid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(), connstr, parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int hid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HousingInfor ");
			strSql.Append(" where hid=@hid");
			SqlParameter[] parameters = {
					new SqlParameter("@hid", SqlDbType.Int,4)
			};
			parameters[0].Value = hid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(), connstr, parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string hidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HousingInfor ");
			strSql.Append(" where hid in ("+hidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(), connstr);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HotelManageSystem.Model.HousingInfor GetModel(int hid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 hid,uid,rnumber,checkintime,eatime,Expiretime,checkouttime,day,status,note,isdelete from HousingInfor ");
			strSql.Append(" where hid=@hid");
			SqlParameter[] parameters = {
					new SqlParameter("@hid", SqlDbType.Int,4)
			};
			parameters[0].Value = hid;

			HotelManageSystem.Model.HousingInfor model=new HotelManageSystem.Model.HousingInfor();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(), connstr, parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HotelManageSystem.Model.HousingInfor DataRowToModel(DataRow row)
		{
			HotelManageSystem.Model.HousingInfor model=new HotelManageSystem.Model.HousingInfor();
			if (row != null)
			{
				if(row["hid"]!=null && row["hid"].ToString()!="")
				{
					model.hid=int.Parse(row["hid"].ToString());
				}
				if(row["uid"]!=null && row["uid"].ToString()!="")
				{
					model.uid=row["uid"].ToString();
				}
				if(row["rnumber"]!=null && row["rnumber"].ToString()!="")
				{
					model.rnumber=int.Parse(row["rnumber"].ToString());
				}
				if(row["checkintime"]!=null && row["checkintime"].ToString()!="")
				{
					model.checkintime=DateTime.Parse(row["checkintime"].ToString());
				}
				if(row["eatime"]!=null && row["eatime"].ToString()!="")
				{
					model.eatime=DateTime.Parse(row["eatime"].ToString());
				}
				if(row["Expiretime"]!=null && row["Expiretime"].ToString()!="")
				{
					model.Expiretime=DateTime.Parse(row["Expiretime"].ToString());
				}
				if(row["checkouttime"]!=null && row["checkouttime"].ToString()!="")
				{
					model.checkouttime=DateTime.Parse(row["checkouttime"].ToString());
				}
				if(row["day"]!=null && row["day"].ToString()!="")
				{
					model.day=int.Parse(row["day"].ToString());
				}
				if(row["status"]!=null && row["status"].ToString()!="")
				{
					model.status=int.Parse(row["status"].ToString());
				}
				if(row["note"]!=null)
				{
					model.note=row["note"].ToString();
				}
				if(row["isdelete"]!=null && row["isdelete"].ToString()!="")
				{
					model.isdelete=int.Parse(row["isdelete"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select hid,uid,rnumber,checkintime,eatime,Expiretime,checkouttime,day,status,note,isdelete ");
			strSql.Append(" FROM HousingInfor ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" hid,uid,rnumber,checkintime,eatime,Expiretime,checkouttime,day,status,note,isdelete ");
			strSql.Append(" FROM HousingInfor ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM HousingInfor ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString(), connstr);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.hid desc");
			}
			strSql.Append(")AS Row, T.*  from HousingInfor T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "HousingInfor";
			parameters[1].Value = "hid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GethurList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from HousingInfor as h inner join UserInfo as u on h.uid = u.IDnumber inner join RoomInfor as r on h.rnumber = r.roid where h.isdelete = 0");		
			if (strWhere.Trim() != "")
			{
				strSql.Append(" and " + strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}
		#endregion  ExtensionMethod
	}
}

