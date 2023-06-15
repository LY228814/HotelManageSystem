
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
	/// 数据访问类:RoomInfor
	/// </summary>
	public partial class RoomInfor
	{
		string connstr = ConvertHelper.GetString(ConfigHelper.GetConnectionString("connstring"));
		public RoomInfor()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int roid)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from RoomInfor");
			strSql.Append(" where roid=@roid");
			SqlParameter[] parameters = {
					new SqlParameter("@roid", SqlDbType.Int,4)
			};
			parameters[0].Value = roid;

			return DbHelperSQL.Exists(strSql.ToString(), connstr, parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(HotelManageSystem.Model.RoomInfor model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("insert into RoomInfor(");
			strSql.Append("rid,tid,rfloor,rstate,description,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@rid,@tid,@rfloor,@rstate,@description,@isdelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@rid", SqlDbType.Int,4),
					new SqlParameter("@tid", SqlDbType.Int,4),
					new SqlParameter("@rfloor", SqlDbType.Int,4),
					new SqlParameter("@rstate", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.NVarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4)};
			parameters[0].Value = model.rid;
			parameters[1].Value = model.tid;
			parameters[2].Value = model.rfloor;
			parameters[3].Value = model.rstate;
			parameters[4].Value = model.description;
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
		public bool Update(HotelManageSystem.Model.RoomInfor model)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update RoomInfor set ");
			strSql.Append("rid=@rid,");
			strSql.Append("tid=@tid,");
			strSql.Append("rfloor=@rfloor,");
			strSql.Append("rstate=@rstate,");
			strSql.Append("description=@description,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where roid=@roid");
			SqlParameter[] parameters = {
					new SqlParameter("@rid", SqlDbType.Int,4),
					new SqlParameter("@tid", SqlDbType.Int,4),
					new SqlParameter("@rfloor", SqlDbType.Int,4),
					new SqlParameter("@rstate", SqlDbType.Int,4),
					new SqlParameter("@description", SqlDbType.NVarChar,-1),
					new SqlParameter("@isdelete", SqlDbType.Int,4),
					new SqlParameter("@roid", SqlDbType.Int,4)};
			parameters[0].Value = model.rid;
			parameters[1].Value = model.tid;
			parameters[2].Value = model.rfloor;
			parameters[3].Value = model.rstate;
			parameters[4].Value = model.description;
			parameters[5].Value = model.isdelete;
			parameters[6].Value = model.roid;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), connstr, parameters);
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
		public bool Delete(int roid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from RoomInfor ");
			strSql.Append(" where roid=@roid");
			SqlParameter[] parameters = {
					new SqlParameter("@roid", SqlDbType.Int,4)
			};
			parameters[0].Value = roid;

			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), connstr, parameters);
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
		public bool DeleteList(string roidlist)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("delete from RoomInfor ");
			strSql.Append(" where roid in (" + roidlist + ")  ");
			int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), connstr);
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
		public HotelManageSystem.Model.RoomInfor GetModel(int roid)
		{

			StringBuilder strSql = new StringBuilder();
			strSql.Append("select  top 1 roid,rid,tid,rfloor,rstate,description,isdelete from RoomInfor ");
			strSql.Append(" where roid=@roid");
			SqlParameter[] parameters = {
					new SqlParameter("@roid", SqlDbType.Int,4)
			};
			parameters[0].Value = roid;

			HotelManageSystem.Model.RoomInfor model = new HotelManageSystem.Model.RoomInfor();
			DataSet ds = DbHelperSQL.Query(strSql.ToString(), connstr, parameters);
			if (ds.Tables[0].Rows.Count > 0)
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
		public HotelManageSystem.Model.RoomInfor DataRowToModel(DataRow row)
		{
			HotelManageSystem.Model.RoomInfor model = new HotelManageSystem.Model.RoomInfor();
			if (row != null)
			{
				if (row["roid"] != null && row["roid"].ToString() != "")
				{
					model.roid = int.Parse(row["roid"].ToString());
				}
				if (row["rid"] != null && row["rid"].ToString() != "")
				{
					model.rid = int.Parse(row["rid"].ToString());
				}
				if (row["tid"] != null && row["tid"].ToString() != "")
				{
					model.tid = int.Parse(row["tid"].ToString());
				}
				if (row["rfloor"] != null && row["rfloor"].ToString() != "")
				{
					model.rfloor = int.Parse(row["rfloor"].ToString());
				}
				if (row["rstate"] != null && row["rstate"].ToString() != "")
				{
					model.rstate = int.Parse(row["rstate"].ToString());
				}
				if (row["description"] != null)
				{
					model.description = row["description"].ToString();
				}
				if (row["isdelete"] != null && row["isdelete"].ToString() != "")
				{
					model.isdelete = int.Parse(row["isdelete"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select roid,rid,tid,rfloor,rstate,description,isdelete ");
			strSql.Append(" FROM RoomInfor ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top, string strWhere, string filedOrder)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select ");
			if (Top > 0)
			{
				strSql.Append(" top " + Top.ToString());
			}
			strSql.Append(" roid,rid,tid,rfloor,rstate,description,isdelete ");
			strSql.Append(" FROM RoomInfor ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) FROM RoomInfor ");
			if (strWhere.Trim() != "")
			{
				strSql.Append(" where " + strWhere);
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
			StringBuilder strSql = new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby);
			}
			else
			{
				strSql.Append("order by T.roid desc");
			}
			strSql.Append(")AS Row, T.*  from RoomInfor T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		#endregion  BasicMethod
		#region  ExtensionMethod
		public DataSet GetHousingList(int intWhere, int credel)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from  RoomInfor as r inner join RoomType on tid=rtid  where r.isdelete=0 ");
			if (credel>=0)
			{
				strSql.Append(" and rstate="+ credel + " ");
            }

			if (intWhere != 0)
			{
				strSql.Append( "and rid like '%"+intWhere+"%'");
			}
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}

		public DataSet GetHousingds(int roid)
		{
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select * from  RoomInfor as r inner join RoomType on tid=rtid  where r.isdelete=0 ");
			if (roid >= 0)
			{
				strSql.Append(" and roid="+roid +"");
			}
			return DbHelperSQL.Query(strSql.ToString(), connstr);
		}
		#endregion  ExtensionMethod
	}
}

