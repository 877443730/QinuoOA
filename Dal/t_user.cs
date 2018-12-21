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
    /// 数据访问类:t_user
    /// </summary>
    public partial class t_user
    {
        public t_user()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_user");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.t_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_user(");
            strSql.Append("username,pwd,employeename,adddate,Email)");
            strSql.Append(" values (");
            strSql.Append("@username,@pwd,@employeename,@adddate,@Email)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@username", SqlDbType.VarChar,50),
                    new SqlParameter("@pwd", SqlDbType.VarChar,50),
                    new SqlParameter("@employeename", SqlDbType.VarChar,50),
                    new SqlParameter("@adddate", SqlDbType.VarChar,50),
                    new SqlParameter("@Email",SqlDbType.NVarChar,50)
            };
            parameters[0].Value = model.username;
            parameters[1].Value = model.pwd;
            parameters[2].Value = model.employeename;
            parameters[3].Value = model.adddate;
            parameters[4].Value = model.Email;
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
        public bool Update(Model.t_user model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_user set ");
            strSql.Append("username=@username,");
            strSql.Append("pwd=@pwd,");
            strSql.Append("employeename=@employeename,");
            strSql.Append("adddate=@adddate,");
            strSql.Append("Email=@Email");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@username", SqlDbType.VarChar,50),
                    new SqlParameter("@pwd", SqlDbType.VarChar,50),
                      new SqlParameter("@employeename", SqlDbType.VarChar,50),
                       new SqlParameter("@adddate", SqlDbType.VarChar,50),
                       new SqlParameter("@Email",SqlDbType.NVarChar,50),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.username;
            parameters[1].Value = model.pwd;
            parameters[2].Value = model.employeename;
            parameters[3].Value = model.adddate;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_user ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_user ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Model.t_user GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select top 1  a.*,c.name,e.pename  from [dbo].[t_user] a left join [dbo].[user_role] b on  a.id=b.userid ");
            strSql.Append(@"left join [dbo].[t_role] c on c.id=b.roleid left join [dbo].[role_permission] d on d.roleid=c.id left join [dbo].[t_permission] e on e.id=d.permissionid");
            strSql.Append(" where a.id=@id");
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int,4)
            };
            parameters[0].Value = id;

            Model.t_user model = new Model.t_user();
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


        public Model.t_user GetModelss(string strwhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select top 1  a.*,c.name,e.pename  from [dbo].[t_user] a left join [dbo].[user_role] b on  a.id=b.userid ");
            strSql.Append(@"left join [dbo].[t_role] c on c.id=b.roleid left join [dbo].[role_permission] d on d.roleid=c.id left join [dbo].[t_permission] e on e.id=d.permissionid");
            strSql.Append(" where a.username="+ "'"+strwhere+"'");
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
        public Model.t_user GetModelssss(string strwhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select top 1  a.*,c.name,e.pename  from [dbo].[t_user] a left join [dbo].[user_role] b on  a.id=b.userid ");
            strSql.Append(@"left join [dbo].[t_role] c on c.id=b.roleid left join [dbo].[role_permission] d on d.roleid=c.id left join [dbo].[t_permission] e on e.id=d.permissionid");
            strSql.Append(" where a.employeename=" +"'"+ strwhere+"'");
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
        public Model.t_user GetModelsss(string strwhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select top 1  a.*,c.name,e.pename  from [dbo].[t_user] a left join [dbo].[user_role] b on  a.id=b.userid ");
            strSql.Append(@"left join [dbo].[t_role] c on c.id=b.roleid left join [dbo].[role_permission] d on d.roleid=c.id left join [dbo].[t_permission] e on e.id=d.permissionid");
            strSql.Append(" where a.employeename=" +"'"+ strwhere+"'");
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
        public Model.t_user GetModels()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select top 1  a.*,c.name,e.pename  from [dbo].[t_user] a left join [dbo].[user_role] b on  a.id=b.userid ");
            strSql.Append(@"left join [dbo].[t_role] c on c.id=b.roleid left join [dbo].[role_permission] d on d.roleid=c.id left join [dbo].[t_permission] e on e.id=d.permissionid");
            strSql.Append(@" order by a.adddate desc");
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


        public Model.t_user GetModelpwd(string username, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select top 1 a.*,c.name,e.pename  from [dbo].[t_user] a left join [dbo].[user_role] b on  a.id=b.userid ");
            strSql.Append(@"left join [dbo].[t_role] c on c.id=b.roleid left join [dbo].[role_permission] d on d.roleid=c.id left join [dbo].[t_permission] e on e.id=d.permissionid");
            strSql.Append(" where (username=@username");
            strSql.Append(") and pwd=@pwd");

            SqlParameter[] parameters = {
                        new SqlParameter("@username", SqlDbType.NVarChar,100),
                        new SqlParameter("@pwd", SqlDbType.NVarChar,100)};
            parameters[0].Value = username;
            parameters[1].Value = pwd;

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

        public Model.t_user GetUpdatepwd(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select top 1 a.*,c.name,e.pename  from [dbo].[t_user] a left join [dbo].[user_role] b on  a.id=b.userid ");
            strSql.Append(@"left join [dbo].[t_role] c on c.id=b.roleid left join [dbo].[role_permission] d on d.roleid=c.id left join [dbo].[t_permission] e on e.id=d.permissionid");
            strSql.Append(" where username=@username");
            SqlParameter[] parameters = {
                        new SqlParameter("@username", SqlDbType.NVarChar,100)};
            parameters[0].Value = username;

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
        public Model.t_user DataRowToModel(DataRow row)
        {
            Model.t_user model = new Model.t_user();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["username"] != null)
                {
                    model.username = row["username"].ToString();
                }
                if (row["employeename"] != null)
                {
                    model.employeename = row["employeename"].ToString();
                }
                if (row["pwd"] != null)
                {
                    model.pwd = row["pwd"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["pename"] != null)
                {
                    model.pename = row["pename"].ToString();
                }
                if (row["adddate"] != null)
                {
                    model.adddate = row["adddate"].ToString();
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
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
            strSql.Append(@"select DISTINCT  a.*,c.name,e.pename  from [dbo].[t_user] a left join [dbo].[user_role] b on  a.id=b.userid ");
            strSql.Append(@"left join [dbo].[t_role] c on c.id=b.roleid left join [dbo].[role_permission] d on d.roleid=c.id left join [dbo].[t_permission] e on e.id=d.permissionid");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetLists(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select DISTINCT(c.name),a.*,e.pename, case c.name when '管理员' then 1 when '营销总监' then 2 when 'SAE' then 3 when 'AE' then 4 when 'SAD' then 5 when 'AD' then 6 when '财务' then 7 when '美工' then 8 when '助理' then 9
                         end as ttt from [dbo].[t_user] a left join [dbo].[user_role] b on  a.id=b.userid ");
            strSql.Append(@"left join [dbo].[t_role] c on c.id=b.roleid left join [dbo].[role_permission] d on d.roleid=c.id left join [dbo].[t_permission] e on e.id=d.permissionid");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" order by ttt");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListss(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select DISTINCT  a.*,c.name,e.pename  from [dbo].[t_user] a left join [dbo].[user_role] b on  a.id=b.userid ");
            strSql.Append(@"left join [dbo].[t_role] c on c.id=b.roleid left join [dbo].[role_permission] d on d.roleid=c.id left join [dbo].[t_permission] e on e.id=d.permissionid");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where b.roleid=" + strWhere);
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
            strSql.Append(" id,username,pwd,employeename,adddate,Email ");
            strSql.Append(" FROM t_user ");
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
            strSql.Append("select count(1) FROM t_user ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from t_user T ");
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
