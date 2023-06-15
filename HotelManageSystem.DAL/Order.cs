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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using KangHui.Common;
using KangHui.BaseClass;
namespace HotelManageSystem.DAL
{
	/// <summary>
	/// 数据访问类:Order
	/// </summary>
	public partial class Order
	{
		string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
		public Order()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("oid", connstr, "Order"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int oid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Order");
			strSql.Append(" where oid=@oid");
			SqlParameter[] parameters = {
					new SqlParameter("@oid", SqlDbType.Int,4)
			};
			parameters[0].Value = oid;

			return DbHelperSQL.Exists(strSql.ToString(), connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HotelManageSystem.Model.Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Order(");
			strSql.Append("rtid,uid,day,ddeposit,note,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@rtid,@uid,@day,@ddeposit,@note,@isdelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@rtid", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@day", SqlDbType.Int,4),
					new SqlParameter("@ddeposit", SqlDbType.Decimal,9),
					new SqlParameter("@note", SqlDbType.NVarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4)};
			parameters[0].Value = model.rtid;
			parameters[1].Value = model.uid;
			parameters[2].Value = model.day;
			parameters[3].Value = model.ddeposit;
			parameters[4].Value = model.note;
			parameters[5].Value = model.isdelete;

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
		public bool Update(HotelManageSystem.Model.Order model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Order set ");
			strSql.Append("rtid=@rtid,");
			strSql.Append("uid=@uid,");
			strSql.Append("day=@day,");
			strSql.Append("ddeposit=@ddeposit,");
			strSql.Append("note=@note,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where oid=@oid");
			SqlParameter[] parameters = {
					new SqlParameter("@rtid", SqlDbType.Int,4),
					new SqlParameter("@uid", SqlDbType.Int,4),
					new SqlParameter("@day", SqlDbType.Int,4),
					new SqlParameter("@ddeposit", SqlDbType.Decimal,9),
					new SqlParameter("@note", SqlDbType.NVarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@oid", SqlDbType.Int,4)};
			parameters[0].Value = model.rtid;
			parameters[1].Value = model.uid;
			parameters[2].Value = model.day;
			parameters[3].Value = model.ddeposit;
			parameters[4].Value = model.note;
			parameters[5].Value = model.isdelete;
			parameters[6].Value = model.oid;

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
		public bool Delete(int oid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Order ");
			strSql.Append(" where oid=@oid");
			SqlParameter[] parameters = {
					new SqlParameter("@oid", SqlDbType.Int,4)
			};
			parameters[0].Value = oid;

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
		public bool DeleteList(string oidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Order ");
			strSql.Append(" where oid in ("+oidlist + ")  ");
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
		public HotelManageSystem.Model.Order GetModel(int oid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 oid,rtid,uid,day,ddeposit,note,isdelete from Order ");
			strSql.Append(" where oid=@oid");
			SqlParameter[] parameters = {
					new SqlParameter("@oid", SqlDbType.Int,4)
			};
			parameters[0].Value = oid;

			HotelManageSystem.Model.Order model=new HotelManageSystem.Model.Order();
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
		public HotelManageSystem.Model.Order DataRowToModel(DataRow row)
		{
			HotelManageSystem.Model.Order model=new HotelManageSystem.Model.Order();
			if (row != null)
			{
				if(row["oid"]!=null && row["oid"].ToString()!="")
				{
					model.oid=int.Parse(row["oid"].ToString());
				}
				if(row["rtid"]!=null && row["rtid"].ToString()!="")
				{
					model.rtid=int.Parse(row["rtid"].ToString());
				}
				if(row["uid"]!=null && row["uid"].ToString()!="")
				{
					model.uid=int.Parse(row["uid"].ToString());
				}
				if(row["day"]!=null && row["day"].ToString()!="")
				{
					model.day=int.Parse(row["day"].ToString());
				}
				if(row["ddeposit"]!=null && row["ddeposit"].ToString()!="")
				{
					model.ddeposit=decimal.Parse(row["ddeposit"].ToString());
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
			strSql.Append("select oid,rtid,uid,day,ddeposit,note,isdelete ");
			strSql.Append(" FROM Order ");
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
			strSql.Append(" oid,rtid,uid,day,ddeposit,note,isdelete ");
			strSql.Append(" FROM Order ");
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
			strSql.Append("select count(1) FROM Order ");
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
				strSql.Append("order by T.oid desc");
			}
			strSql.Append(")AS Row, T.*  from Order T ");
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
			parameters[0].Value = "Order";
			parameters[1].Value = "oid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

