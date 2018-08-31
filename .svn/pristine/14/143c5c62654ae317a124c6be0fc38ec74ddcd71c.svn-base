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
    /// 数据访问类:node
    /// </summary>
    public partial class node
    {
        public node()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from node");
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
        public int Add( Model.node model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into node(");
            strSql.Append("Stateofapproval,projectid,AE,SAE,AD,SAD,yinxiaozongjian,caiwu,laoban,zhulaoban,processstate)");
            strSql.Append(" values (");
            strSql.Append("@Stateofapproval,@projectid,@AE,@SAE,@AD,@SAD,@yinxiaozongjian,@caiwu,@laoban,@zhulaoban,@processstate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Stateofapproval", SqlDbType.Int,4),
                    new SqlParameter("@projectid", SqlDbType.Int,4),
                    new SqlParameter("@AE", SqlDbType.NVarChar,50),
                    new SqlParameter("@SAE", SqlDbType.NVarChar,50),
                    new SqlParameter("@AD", SqlDbType.NVarChar,50),
                    new SqlParameter("@SAD", SqlDbType.NVarChar,50),
                    new SqlParameter("@yinxiaozongjian", SqlDbType.NVarChar,50),
                    new SqlParameter("@caiwu", SqlDbType.NVarChar,50),
                    new SqlParameter("@laoban", SqlDbType.NVarChar,50),
                    new SqlParameter("@zhulaoban", SqlDbType.NVarChar,50),
                    new SqlParameter("@processstate", SqlDbType.Int,4)
            };
            parameters[0].Value = model.Stateofapproval;
            parameters[1].Value = model.projectid;
            parameters[2].Value = model.AE;
            parameters[3].Value = model.SAE;
            parameters[4].Value = model.AD;
            parameters[5].Value = model.SAD;
            parameters[6].Value = model.yinxiaozongjian;
            parameters[7].Value = model.caiwu;
            parameters[8].Value = model.laoban;
            parameters[9].Value = model.zhulaoban;
            parameters[10].Value = model.processstate;
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
        public bool Update( Model.node model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update node set ");
            strSql.Append("Stateofapproval=@Stateofapproval,");
            strSql.Append("projectid=@projectid,");
            strSql.Append("AE=@AE,");
            strSql.Append("SAE=@SAE,");
            strSql.Append("AD=@AD,");
            strSql.Append("SAD=@SAD,");
            strSql.Append("yinxiaozongjian=@yinxiaozongjian,");
            strSql.Append("caiwu=@caiwu,");
            strSql.Append("laoban=@laoban,");
            strSql.Append("zhulaoban=@zhulaoban,");
            strSql.Append("processstate=@processstate");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Stateofapproval", SqlDbType.Int,4),
                    new SqlParameter("@projectid", SqlDbType.Int,4),
                    new SqlParameter("@AE", SqlDbType.NVarChar,50),
                    new SqlParameter("@SAE", SqlDbType.NVarChar,50),
                    new SqlParameter("@AD", SqlDbType.NVarChar,50),
                    new SqlParameter("@SAD", SqlDbType.NVarChar,50),
                    new SqlParameter("@yinxiaozongjian", SqlDbType.NVarChar,50),
                    new SqlParameter("@caiwu", SqlDbType.NVarChar,50),
                    new SqlParameter("@laoban", SqlDbType.NVarChar,50),
                    new SqlParameter("@zhulaoban", SqlDbType.NVarChar,50),
                     new SqlParameter("@processstate", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Stateofapproval;
            parameters[1].Value = model.projectid;
            parameters[2].Value = model.AE;
            parameters[3].Value = model.SAE;
            parameters[4].Value = model.AD;
            parameters[5].Value = model.SAD;
            parameters[6].Value = model.yinxiaozongjian;
            parameters[7].Value = model.caiwu;
            parameters[8].Value = model.laoban;
            parameters[9].Value = model.zhulaoban;
            parameters[10].Value = model.processstate;
            parameters[11].Value = model.Id;
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
            strSql.Append("delete from node ");
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
            strSql.Append("delete from node ");
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
        public  Model.node GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Stateofapproval,projectid,AE,SAE,AD,SAD,yinxiaozongjian,caiwu,laoban,zhulaoban,processstate from node ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

             Model.node model = new  Model.node();
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
        public Model.node GetModels(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Stateofapproval,projectid,AE,SAE,AD,SAD,yinxiaozongjian,caiwu,laoban,zhulaoban,processstate from node ");
            strSql.Append(" where projectid=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            Model.node model = new Model.node();
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
        public  Model.node DataRowToModel(DataRow row)
        {
             Model.node model = new  Model.node();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Stateofapproval"] != null && row["Stateofapproval"].ToString() != "")
                {
                    model.Stateofapproval = int.Parse(row["Stateofapproval"].ToString());
                }
                if (row["projectid"] != null && row["projectid"].ToString() != "")
                {
                    model.projectid = int.Parse(row["projectid"].ToString());
                }
                if (row["AE"] != null)
                {
                    model.AE = row["AE"].ToString();
                }
                if (row["SAE"] != null)
                {
                    model.SAE = row["SAE"].ToString();
                }
                if (row["AD"] != null)
                {
                    model.AD = row["AD"].ToString();
                }
                if (row["SAD"] != null)
                {
                    model.SAD = row["SAD"].ToString();
                }
                if (row["yinxiaozongjian"] != null)
                {
                    model.yinxiaozongjian = row["yinxiaozongjian"].ToString();
                }
                if (row["caiwu"] != null)
                {
                    model.caiwu = row["caiwu"].ToString();
                }
                if (row["laoban"] != null)
                {
                    model.laoban = row["laoban"].ToString();
                }
                if (row["zhulaoban"] != null)
                {
                    model.zhulaoban = row["zhulaoban"].ToString();
                }
                if (row["processstate"] != null && row["processstate"].ToString() != "")
                {
                    model.processstate = int.Parse(row["processstate"].ToString());
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
            strSql.Append("select Id,Stateofapproval,projectid,AE,SAE,AD,SAD,yinxiaozongjian,caiwu,laoban,zhulaoban,processstate ");
            strSql.Append(" FROM node ");
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
            strSql.Append(" Id,Stateofapproval,projectid,AE,SAE,AD,SAD,yinxiaozongjian,caiwu,laoban,zhulaoban,processstate ");
            strSql.Append(" FROM node ");
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
            strSql.Append("select count(1) FROM node ");
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
            strSql.Append(")AS Row, T.*  from node T ");
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
