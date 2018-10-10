using DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    /// <summary>
	/// 数据访问类:Project
	/// </summary>
	public partial class Project
    {
        public Project()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Project");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Project model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Project(");
            strSql.Append("ProjectNumber,ProjectStartDate,ProjectEndDate,Username,ProjectCode,ProjectName,Remarks,OfferId,PlatformId,CompanyId,ProjecttypeId,PurchaseSingleCode,userid,Planprogress,POdanhao,Expectedreturndate,Actualdate,Accountamount,typefinished,caseclosed)");
            strSql.Append(" values (");
            strSql.Append("@ProjectNumber,@ProjectStartDate,@ProjectEndDate,@Username,@ProjectCode,@ProjectName,@Remarks,@OfferId,@PlatformId,@CompanyId,@ProjecttypeId,@PurchaseSingleCode,@userid,@Planprogress,@POdanhao,@Expectedreturndate,@Actualdate,@Accountamount,@typefinished,@caseclosed)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProjectNumber", SqlDbType.NVarChar,200),
                    new SqlParameter("@ProjectStartDate", SqlDbType.DateTime),
                    new SqlParameter("@ProjectEndDate", SqlDbType.DateTime),
                    new SqlParameter("@Username", SqlDbType.NVarChar,200),
                    new SqlParameter("@ProjectCode", SqlDbType.NVarChar,200),
                    new SqlParameter("@ProjectName", SqlDbType.NVarChar,200),
                    new SqlParameter("@Remarks", SqlDbType.NVarChar,500),
                    new SqlParameter("@OfferId", SqlDbType.Int,4),
                    new SqlParameter("@PlatformId", SqlDbType.Int,4),
                    new SqlParameter("@CompanyId", SqlDbType.Int,4),
                    new SqlParameter("@ProjecttypeId", SqlDbType.Int,4),
                    new SqlParameter("@PurchaseSingleCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@userid", SqlDbType.Int,4),
                    new SqlParameter("@Planprogress", SqlDbType.NVarChar,500),
                    new SqlParameter("@POdanhao", SqlDbType.NVarChar,500),
                    new SqlParameter("@Expectedreturndate", SqlDbType.DateTime),
                    new SqlParameter("@Actualdate", SqlDbType.DateTime),
                    new SqlParameter("@Accountamount", SqlDbType.Decimal,9),
                     new SqlParameter("@typefinished", SqlDbType.Int,4),
                      new SqlParameter("@caseclosed", SqlDbType.Int,4)
            };
            parameters[0].Value = model.ProjectNumber;
            parameters[1].Value = model.ProjectStartDate;
            parameters[2].Value = model.ProjectEndDate;
            parameters[3].Value = model.Username;
            parameters[4].Value = model.ProjectCode;
            parameters[5].Value = model.ProjectName;
            parameters[6].Value = model.Remarks;
            parameters[7].Value = model.OfferId;
            parameters[8].Value = model.PlatformId;
            parameters[9].Value = model.CompanyId;
            parameters[10].Value = model.ProjecttypeId;
            parameters[11].Value = model.PurchaseSingleCode;
            parameters[12].Value = model.userid;
            parameters[13].Value = model.Planprogress;
            parameters[14].Value = model.POdanhao;
            parameters[15].Value = model.Expectedreturndate;
            parameters[16].Value = model.Actualdate;
            parameters[17].Value = model.Accountamount;
            parameters[18].Value = model.typefinished;
            parameters[19].Value = model.caseclosed;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Model.Project model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Project set ");
            strSql.Append("ProjectNumber=@ProjectNumber,");
            strSql.Append("ProjectStartDate=@ProjectStartDate,");
            strSql.Append("ProjectEndDate=@ProjectEndDate,");
            strSql.Append("Username=@Username,");
            strSql.Append("ProjectCode=@ProjectCode,");
            strSql.Append("ProjectName=@ProjectName,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("OfferId=@OfferId,");
            strSql.Append("PlatformId=@PlatformId,");
            strSql.Append("CompanyId=@CompanyId,");
            strSql.Append("ProjecttypeId=@ProjecttypeId,");
            strSql.Append("PurchaseSingleCode=@PurchaseSingleCode,");
            strSql.Append("userid=@userid,");
            strSql.Append("Planprogress=@Planprogress,");
            strSql.Append("POdanhao=@POdanhao,");
            strSql.Append("Expectedreturndate=@Expectedreturndate,");
            strSql.Append("Actualdate=@Actualdate,");
            strSql.Append("Accountamount=@Accountamount,");
            strSql.Append("typefinished=@typefinished,");
            strSql.Append("caseclosed=@caseclosed");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProjectNumber", SqlDbType.NVarChar,200),
                    new SqlParameter("@ProjectStartDate", SqlDbType.DateTime),
                    new SqlParameter("@ProjectEndDate", SqlDbType.DateTime),
                    new SqlParameter("@Username", SqlDbType.NVarChar,200),
                    new SqlParameter("@ProjectCode", SqlDbType.NVarChar,200),
                    new SqlParameter("@ProjectName", SqlDbType.NVarChar,200),
                    new SqlParameter("@Remarks", SqlDbType.NVarChar,500),
                    new SqlParameter("@OfferId", SqlDbType.Int,4),
                    new SqlParameter("@PlatformId", SqlDbType.Int,4),
                    new SqlParameter("@CompanyId", SqlDbType.Int,4),
                    new SqlParameter("@ProjecttypeId", SqlDbType.Int,4),
                    new SqlParameter("@PurchaseSingleCode", SqlDbType.NVarChar,50),
                    new SqlParameter("@userid", SqlDbType.Int,4),
                    new SqlParameter("@Planprogress", SqlDbType.NVarChar,500),
                      new SqlParameter("@POdanhao", SqlDbType.NVarChar,500),
                        new SqlParameter("@Expectedreturndate", SqlDbType.DateTime),
                          new SqlParameter("@Actualdate", SqlDbType.DateTime),
                            new SqlParameter("@Accountamount", SqlDbType.Decimal,9),
                             new SqlParameter("@typefinished", SqlDbType.Int,4),
                             new SqlParameter("@caseclosed", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.ProjectNumber;
            parameters[1].Value = model.ProjectStartDate;
            parameters[2].Value = model.ProjectEndDate;
            parameters[3].Value = model.Username;
            parameters[4].Value = model.ProjectCode;
            parameters[5].Value = model.ProjectName;
            parameters[6].Value = model.Remarks;
            parameters[7].Value = model.OfferId;
            parameters[8].Value = model.PlatformId;
            parameters[9].Value = model.CompanyId;
            parameters[10].Value = model.ProjecttypeId;
            parameters[11].Value = model.PurchaseSingleCode;
            parameters[12].Value = model.userid;
            parameters[13].Value = model.Planprogress;
            parameters[14].Value = model.POdanhao;
            parameters[15].Value = model.Expectedreturndate;
            parameters[16].Value = model.Actualdate;
            parameters[17].Value = model.Accountamount;
            parameters[18].Value = model.typefinished;
            parameters[19].Value = model.caseclosed;
            parameters[20].Value = model.Id;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Project ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Project ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.Project GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ProjectNumber,ProjectStartDate,ProjectEndDate,Username,ProjectCode,ProjectName,Remarks,OfferId,PlatformId,CompanyId,ProjecttypeId,PurchaseSingleCode,userid,Planprogress,POdanhao,Expectedreturndate,Actualdate,Accountamount,typefinished,caseclosed from Project ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

			Model.Project model = new Model.Project();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        public Model.Project GetuserModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ProjectNumber,ProjectStartDate,ProjectEndDate,Username,ProjectCode,ProjectName,Remarks,OfferId,PlatformId,CompanyId,ProjecttypeId,PurchaseSingleCode,userid,Planprogress,POdanhao,Expectedreturndate,Actualdate,Accountamount,typefinished,caseclosed from Project ");
            strSql.Append(" where userid=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            Model.Project model = new Model.Project();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
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
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Project GetModels()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,ProjectNumber,ProjectStartDate,ProjectEndDate,Username,ProjectCode,ProjectName,Remarks,OfferId,PlatformId,CompanyId,ProjecttypeId,PurchaseSingleCode,userid,Planprogress,POdanhao,Expectedreturndate,Actualdate,Accountamount,typefinished,caseclosed from Project  ");
            strSql.Append(" order by Id desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        public Model.Project GetModelss(string strwhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Id,ProjectNumber,ProjectStartDate,ProjectEndDate,Username,ProjectCode,ProjectName,Remarks,OfferId,PlatformId,CompanyId,ProjecttypeId,PurchaseSingleCode,userid,Planprogress,POdanhao,Expectedreturndate,Actualdate,Accountamount,typefinished,caseclosed from Project  ");
            strSql.Append(" where ProjectName ="+"'"+ strwhere+"'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        public Model.Project GetModelsstow(int projectid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  Id,ProjectNumber,ProjectStartDate,ProjectEndDate,Username,ProjectCode,ProjectName,Remarks,OfferId,PlatformId,CompanyId,ProjecttypeId,PurchaseSingleCode,userid,Planprogress,POdanhao,Expectedreturndate,Actualdate,Accountamount,typefinished,caseclosed from Project  ");
            strSql.Append(" where id =" + projectid);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
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
        public Model.Project DataRowToModel(DataRow row)
        {
			Model.Project model = new Model.Project();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["ProjectNumber"] != null)
                {
                    model.ProjectNumber = row["ProjectNumber"].ToString();
                }
                if (row["ProjectStartDate"] != null && row["ProjectStartDate"].ToString() != "")
                {
                    model.ProjectStartDate = DateTime.Parse(row["ProjectStartDate"].ToString());
                }
                if (row["ProjectEndDate"] != null && row["ProjectEndDate"].ToString() != "")
                {
                    model.ProjectEndDate = DateTime.Parse(row["ProjectEndDate"].ToString());
                }
                if (row["Username"] != null)
                {
                    model.Username = row["Username"].ToString();
                }
                if (row["ProjectCode"] != null)
                {
                    model.ProjectCode = row["ProjectCode"].ToString();
                }
                if (row["ProjectName"] != null)
                {
                    model.ProjectName = row["ProjectName"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["OfferId"] != null && row["OfferId"].ToString() != "")
                {
                    model.OfferId = int.Parse(row["OfferId"].ToString());
                }
                if (row["PlatformId"] != null && row["PlatformId"].ToString() != "")
                {
                    model.PlatformId = int.Parse(row["PlatformId"].ToString());
                }
                if (row["CompanyId"] != null && row["CompanyId"].ToString() != "")
                {
                    model.CompanyId = int.Parse(row["CompanyId"].ToString());
                }
                if (row["ProjecttypeId"] != null && row["ProjecttypeId"].ToString() != "")
                {
                    model.ProjecttypeId = int.Parse(row["ProjecttypeId"].ToString());
                }
                if (row["PurchaseSingleCode"] != null)
                {
                    model.PurchaseSingleCode = row["PurchaseSingleCode"].ToString();
                }
                if (row["userid"] != null && row["userid"].ToString() != "")
                {
                    model.userid = int.Parse(row["userid"].ToString());
                }
                if (row["Planprogress"] != null)
                {
                    model.Planprogress = row["Planprogress"].ToString();
                }
                if (row["POdanhao"] != null)
                {
                    model.POdanhao = row["POdanhao"].ToString();
                }
                if (row["Expectedreturndate"] != null && row["Expectedreturndate"].ToString() != "")
                {
                    model.Expectedreturndate = DateTime.Parse(row["Expectedreturndate"].ToString());
                }
                if (row["Actualdate"] != null && row["Actualdate"].ToString() != "")
                {
                    model.Actualdate = DateTime.Parse(row["Actualdate"].ToString());
                }
                if (row["Accountamount"] != null && row["Accountamount"].ToString() != "")
                {
                    model.Accountamount = decimal.Parse(row["Accountamount"].ToString());
                }
                if (row["typefinished"] != null && row["typefinished"].ToString() != "")
                {
                    model.typefinished = int.Parse(row["typefinished"].ToString());
                }
                if (row["caseclosed"] != null && row["caseclosed"].ToString() != "")
                {
                    model.caseclosed = int.Parse(row["caseclosed"].ToString());
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
            strSql.Append("select Id,ProjectNumber,ProjectStartDate,ProjectEndDate,Username,ProjectCode,ProjectName,Remarks,OfferId,PlatformId,CompanyId,ProjecttypeId,PurchaseSingleCode,userid,Planprogress,POdanhao,Expectedreturndate,Actualdate,Accountamount,typefinished,caseclosed ");
            strSql.Append(" FROM Project ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" Id,ProjectNumber,ProjectStartDate,ProjectEndDate,Username,ProjectCode,ProjectName,Remarks,OfferId,PlatformId,CompanyId,ProjecttypeId,PurchaseSingleCode,userid,Planprogress,POdanhao,Expectedreturndate,Actualdate,Accountamount,typefinished,caseclosed ");
            strSql.Append(" FROM Project ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Project ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from Project T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetListByPage1(string strWhere, string orderby, int startIndex, int endIndex)
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from Project T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
