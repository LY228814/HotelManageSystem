
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
	/// 数据访问类:RoomType
	/// </summary>
	public partial class RoomType
	{
		string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
		public RoomType()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("rtid", connstr, "RoomType"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int rtid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RoomType");
			strSql.Append(" where rtid=@rtid");
			SqlParameter[] parameters = {
					new SqlParameter("@rtid", SqlDbType.Int,4)
			};
			parameters[0].Value = rtid;

			return DbHelperSQL.Exists(strSql.ToString(), connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HotelManageSystem.Model.RoomType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RoomType(");
			strSql.Append("rtname,rarea,rprice,racdt,rdescribe,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@rtname,@rarea,@rprice,@racdt,@rdescribe,@isdelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@rtname", SqlDbType.NVarChar,20),
					new SqlParameter("@rarea", SqlDbType.Int,4),
					new SqlParameter("@rprice", SqlDbType.NChar,10),
					new SqlParameter("@racdt", SqlDbType.Int,4),
					new SqlParameter("@rdescribe", SqlDbType.NVarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4)};
			parameters[0].Value = model.rtname;
			parameters[1].Value = model.rarea;
			parameters[2].Value = model.rprice;
			parameters[3].Value = model.racdt;
			parameters[4].Value = model.rdescribe;
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
		public bool Update(HotelManageSystem.Model.RoomType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RoomType set ");
			strSql.Append("rtname=@rtname,");
			strSql.Append("rarea=@rarea,");
			strSql.Append("rprice=@rprice,");
			strSql.Append("racdt=@racdt,");
			strSql.Append("rdescribe=@rdescribe,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where rtid=@rtid");
			SqlParameter[] parameters = {
					new SqlParameter("@rtname", SqlDbType.NVarChar,20),
					new SqlParameter("@rarea", SqlDbType.Int,4),
					new SqlParameter("@rprice", SqlDbType.NChar,10),
					new SqlParameter("@racdt", SqlDbType.Int,4),
					new SqlParameter("@rdescribe", SqlDbType.NVarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@rtid", SqlDbType.Int,4)};
			parameters[0].Value = model.rtname;
			parameters[1].Value = model.rarea;
			parameters[2].Value = model.rprice;
			parameters[3].Value = model.racdt;
			parameters[4].Value = model.rdescribe;
			parameters[5].Value = model.isdelete;
			parameters[6].Value = model.rtid;

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
		public bool Delete(int rtid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RoomType ");
			strSql.Append(" where rtid=@rtid");
			SqlParameter[] parameters = {
					new SqlParameter("@rtid", SqlDbType.Int,4)
			};
			parameters[0].Value = rtid;

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
		public bool DeleteList(string rtidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RoomType ");
			strSql.Append(" where rtid in ("+rtidlist + ")  ");
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
		public HotelManageSystem.Model.RoomType GetModel(int rtid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 rtid,rtname,rarea,rprice,racdt,rdescribe,isdelete from RoomType ");
			strSql.Append(" where rtid=@rtid");
			SqlParameter[] parameters = {
					new SqlParameter("@rtid", SqlDbType.Int,4)
			};
			parameters[0].Value = rtid;

			HotelManageSystem.Model.RoomType model=new HotelManageSystem.Model.RoomType();
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
		public HotelManageSystem.Model.RoomType DataRowToModel(DataRow row)
		{
			HotelManageSystem.Model.RoomType model=new HotelManageSystem.Model.RoomType();
			if (row != null)
			{
				if(row["rtid"]!=null && row["rtid"].ToString()!="")
				{
					model.rtid=int.Parse(row["rtid"].ToString());
				}
				if(row["rtname"]!=null)
				{
					model.rtname=row["rtname"].ToString();
				}
				if(row["rarea"]!=null && row["rarea"].ToString()!="")
				{
					model.rarea=int.Parse(row["rarea"].ToString());
				}
				if(row["rprice"]!=null)
				{
					model.rprice=row["rprice"].ToString();
				}
				if(row["racdt"]!=null && row["racdt"].ToString()!="")
				{
					model.racdt=int.Parse(row["racdt"].ToString());
				}
				if(row["rdescribe"]!=null)
				{
					model.rdescribe=row["rdescribe"].ToString();
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
			strSql.Append("select rtid,rtname,rarea,rprice,racdt,rdescribe,isdelete ");
			strSql.Append(" FROM RoomType ");
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
			strSql.Append(" rtid,rtname,rarea,rprice,racdt,rdescribe,isdelete ");
			strSql.Append(" FROM RoomType ");
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
			strSql.Append("select count(1) FROM RoomType ");
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
				strSql.Append("order by T.rtid desc");
			}
			strSql.Append(")AS Row, T.*  from RoomType T ");
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
			parameters[0].Value = "RoomType";
			parameters[1].Value = "rtid";
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

