/**  版本信息模板在安装目录下，可自行修改。
* ExchangeRR.cs
*
* 功 能： N/A
* 类 名： ExchangeRR
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2021/4/22 11:49:32   N/A    初版
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
	/// 数据访问类:ExchangeRR
	/// </summary>
	public partial class ExchangeRR
	{
		string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
		public ExchangeRR()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("eid", connstr, "ExchangeRR"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int eid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ExchangeRR");
			strSql.Append(" where eid=@eid");
			SqlParameter[] parameters = {
					new SqlParameter("@eid", SqlDbType.Int,4)
			};
			parameters[0].Value = eid;

			return DbHelperSQL.Exists(strSql.ToString(), connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HotelManageSystem.Model.ExchangeRR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ExchangeRR(");
			strSql.Append("hid,cid,beforerid,nowrid,exchangeReason,exchangetime,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@hid,@cid,@beforerid,@nowrid,@exchangeReason,@exchangetime,@isdelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@hid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@beforerid", SqlDbType.Int,4),
					new SqlParameter("@nowrid", SqlDbType.Int,4),
					new SqlParameter("@exchangeReason", SqlDbType.NVarChar,50),
					new SqlParameter("@exchangetime", SqlDbType.NChar,10),
					new SqlParameter("@isdelete", SqlDbType.Int,4)};
			parameters[0].Value = model.hid;
			parameters[1].Value = model.cid;
			parameters[2].Value = model.beforerid;
			parameters[3].Value = model.nowrid;
			parameters[4].Value = model.exchangeReason;
			parameters[5].Value = model.exchangetime;
			parameters[6].Value = model.isdelete;

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
		public bool Update(HotelManageSystem.Model.ExchangeRR model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ExchangeRR set ");
			strSql.Append("hid=@hid,");
			strSql.Append("cid=@cid,");
			strSql.Append("beforerid=@beforerid,");
			strSql.Append("nowrid=@nowrid,");
			strSql.Append("exchangeReason=@exchangeReason,");
			strSql.Append("exchangetime=@exchangetime,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where eid=@eid");
			SqlParameter[] parameters = {
					new SqlParameter("@hid", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@beforerid", SqlDbType.Int,4),
					new SqlParameter("@nowrid", SqlDbType.Int,4),
					new SqlParameter("@exchangeReason", SqlDbType.NVarChar,50),
					new SqlParameter("@exchangetime", SqlDbType.NChar,10),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@eid", SqlDbType.Int,4)};
			parameters[0].Value = model.hid;
			parameters[1].Value = model.cid;
			parameters[2].Value = model.beforerid;
			parameters[3].Value = model.nowrid;
			parameters[4].Value = model.exchangeReason;
			parameters[5].Value = model.exchangetime;
			parameters[6].Value = model.isdelete;
			parameters[7].Value = model.eid;

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
		public bool Delete(int eid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ExchangeRR ");
			strSql.Append(" where eid=@eid");
			SqlParameter[] parameters = {
					new SqlParameter("@eid", SqlDbType.Int,4)
			};
			parameters[0].Value = eid;

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
		public bool DeleteList(string eidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ExchangeRR ");
			strSql.Append(" where eid in ("+eidlist + ")  ");
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
		public HotelManageSystem.Model.ExchangeRR GetModel(int eid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 eid,hid,cid,beforerid,nowrid,exchangeReason,exchangetime,isdelete from ExchangeRR ");
			strSql.Append(" where eid=@eid");
			SqlParameter[] parameters = {
					new SqlParameter("@eid", SqlDbType.Int,4)
			};
			parameters[0].Value = eid;

			HotelManageSystem.Model.ExchangeRR model=new HotelManageSystem.Model.ExchangeRR();
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
		public HotelManageSystem.Model.ExchangeRR DataRowToModel(DataRow row)
		{
			HotelManageSystem.Model.ExchangeRR model=new HotelManageSystem.Model.ExchangeRR();
			if (row != null)
			{
				if(row["eid"]!=null && row["eid"].ToString()!="")
				{
					model.eid=int.Parse(row["eid"].ToString());
				}
				if(row["hid"]!=null && row["hid"].ToString()!="")
				{
					model.hid=int.Parse(row["hid"].ToString());
				}
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["beforerid"]!=null && row["beforerid"].ToString()!="")
				{
					model.beforerid=int.Parse(row["beforerid"].ToString());
				}
				if(row["nowrid"]!=null && row["nowrid"].ToString()!="")
				{
					model.nowrid=int.Parse(row["nowrid"].ToString());
				}
				if(row["exchangeReason"]!=null)
				{
					model.exchangeReason=row["exchangeReason"].ToString();
				}
				if(row["exchangetime"]!=null)
				{
					model.exchangetime=row["exchangetime"].ToString();
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
			strSql.Append("select eid,hid,cid,beforerid,nowrid,exchangeReason,exchangetime,isdelete ");
			strSql.Append(" FROM ExchangeRR ");
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
			strSql.Append(" eid,hid,cid,beforerid,nowrid,exchangeReason,exchangetime,isdelete ");
			strSql.Append(" FROM ExchangeRR ");
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
			strSql.Append("select count(1) FROM ExchangeRR ");
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
				strSql.Append("order by T.eid desc");
			}
			strSql.Append(")AS Row, T.*  from ExchangeRR T ");
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
			parameters[0].Value = "ExchangeRR";
			parameters[1].Value = "eid";
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

