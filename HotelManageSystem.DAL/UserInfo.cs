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
using System.Data;
using System.Text;
using System.Data.SqlClient;
using HotelManageSystem.Model;
using System.Configuration;
using KangHui.Common;
using KangHui.BaseClass;

namespace HotelManageSystem.DAL
{
	/// <summary>
	/// 数据访问类:UserInfo
	/// </summary>
	public partial class UserInfo
	{
		string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
		public UserInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Uid", connstr, "UserInfo"); 
		}
		
		public string province(string id)
        {
			SqlDataAdapter sda = new SqlDataAdapter("select * from area_code where zone='" + id + "'", connstr);
			DataSet ds = new DataSet();
			sda.Fill(ds);
            if (ds!=null)
            {
				return ds.Tables[0].Rows[0]["desid"].ToString();
			}

            else
            {
				return "";
            }
			
        }

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserInfo");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

			return DbHelperSQL.Exists(strSql.ToString(), connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HotelManageSystem.Model.UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserInfo(");
			strSql.Append("Name,IDnumber,Phone,Upwd,type,gender,birthday,birthplace,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@Name,@IDnumber,@Phone,@Upwd,@type,@gender,@birthday,@birthplace,@isdelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@IDnumber", SqlDbType.NChar,18),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Upwd", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@gender", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.Date,3),
					new SqlParameter("@birthplace", SqlDbType.NVarChar,50),
					new SqlParameter("@isdelete", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.IDnumber;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Upwd;
			parameters[4].Value = model.type;
			parameters[5].Value = model.gender;
			parameters[6].Value = model.birthday;
			parameters[7].Value = model.birthplace;
			parameters[8].Value = model.isdelete;

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
		public bool Update(HotelManageSystem.Model.UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserInfo set ");
			strSql.Append("Name=@Name,");
			strSql.Append("IDnumber=@IDnumber,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Upwd=@Upwd,");
			strSql.Append("type=@type,");
			strSql.Append("gender=@gender,");
			strSql.Append("birthday=@birthday,");
			strSql.Append("birthplace=@birthplace,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,20),
					new SqlParameter("@IDnumber", SqlDbType.NChar,18),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Upwd", SqlDbType.NVarChar,50),
					new SqlParameter("@type", SqlDbType.Int,4),
					new SqlParameter("@gender", SqlDbType.Int,4),
					new SqlParameter("@birthday", SqlDbType.Date,3),
					new SqlParameter("@birthplace", SqlDbType.NVarChar,50),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@Uid", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.IDnumber;
			parameters[2].Value = model.Phone;
			parameters[3].Value = model.Upwd;
			parameters[4].Value = model.type;
			parameters[5].Value = model.gender;
			parameters[6].Value = model.birthday;
			parameters[7].Value = model.birthplace;
			parameters[8].Value = model.isdelete;
			parameters[9].Value = model.Uid;

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
		public bool Delete(int Uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

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
		public bool DeleteList(string Uidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where Uid in ("+Uidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),connstr);
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
		public HotelManageSystem.Model.UserInfo GetModel(string IDnumber)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Uid,Name,IDnumber,Phone,Upwd,type,gender,birthday,birthplace,isdelete from UserInfo ");
			strSql.Append(" where IDnumber=@IDnumber");
			SqlParameter[] parameters = {
					new SqlParameter("@IDnumber", SqlDbType.NChar,18)
			};
			parameters[0].Value = IDnumber;

			HotelManageSystem.Model.UserInfo model=new HotelManageSystem.Model.UserInfo();
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
		public HotelManageSystem.Model.UserInfo DataRowToModel(DataRow row)
		{
			HotelManageSystem.Model.UserInfo model=new HotelManageSystem.Model.UserInfo();
			if (row != null)
			{
				if(row["Uid"]!=null && row["Uid"].ToString()!="")
				{
					model.Uid=int.Parse(row["Uid"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["IDnumber"]!=null)
				{
					model.IDnumber=row["IDnumber"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
				}
				if(row["Upwd"]!=null)
				{
					model.Upwd=row["Upwd"].ToString();
				}
				if(row["type"]!=null && row["type"].ToString()!="")
				{
					model.type=int.Parse(row["type"].ToString());
				}
				if(row["gender"]!=null && row["gender"].ToString()!="")
				{
					model.gender=int.Parse(row["gender"].ToString());
				}
				if(row["birthday"]!=null && row["birthday"].ToString()!="")
				{
					model.birthday=DateTime.Parse(row["birthday"].ToString());
				}
				if(row["birthplace"]!=null)
				{
					model.birthplace=row["birthplace"].ToString();
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
			strSql.Append("select Uid,Name,IDnumber,Phone,Upwd,type,gender,birthday,birthplace,isdelete ");
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append(" Uid,Name,IDnumber,Phone,Upwd,type,gender,birthday,birthplace,isdelete ");
			strSql.Append(" FROM UserInfo ");
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
			strSql.Append("select count(1) FROM UserInfo ");
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
				strSql.Append("order by T.Uid desc");
			}
			strSql.Append(")AS Row, T.*  from UserInfo T ");
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
			parameters[0].Value = "UserInfo";
			parameters[1].Value = "Uid";
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

