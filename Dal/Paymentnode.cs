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
    public partial class Paymentnode
    {
        public Paymentnode()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from paymentnode");
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
        public int Add(Model.Paymentnode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into paymentnode(");
            strSql.Append("projectId,xuhao,Distinguish,Stateofapproval,SAE,AD,SAD,yinxiaozongjian,caiwu,laoban,zhulaoban,paymentapplicationformiId)");
            strSql.Append(" values (");
            strSql.Append("@projectId,@xuhao,@Distinguish,@Stateofapproval,@SAE,@AD,@SAD,@yinxiaozongjian,@caiwu,@laoban,@zhulaoban,@paymentapplicationformiId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@projectId", SqlDbType.Int,4),
                    new SqlParameter("@xuhao", SqlDbType.Int,4),
                    new SqlParameter("@Distinguish", SqlDbType.Int,4),
                    new SqlParameter("@Stateofapproval", SqlDbType.Int,4),
                    new SqlParameter("@SAE", SqlDbType.NVarChar,50),
                    new SqlParameter("@AD", SqlDbType.NVarChar,50),
                    new SqlParameter("@SAD", SqlDbType.NVarChar,50),
                    new SqlParameter("@yinxiaozongjian", SqlDbType.NVarChar,50),
                    new SqlParameter("@caiwu", SqlDbType.NVarChar,50),
                    new SqlParameter("@laoban", SqlDbType.NVarChar,50),
                    new SqlParameter("@zhulaoban", SqlDbType.NVarChar,50),
                    new SqlParameter("@paymentapplicationformiId", SqlDbType.Int,4)
            };
            parameters[0].Value = model.projectId;
            parameters[1].Value = model.xuhao;
            parameters[2].Value = model.Distinguish;
            parameters[3].Value = model.Stateofapproval;
            parameters[4].Value = model.SAE;
            parameters[5].Value = model.AD;
            parameters[6].Value = model.SAD;
            parameters[7].Value = model.yinxiaozongjian;
            parameters[8].Value = model.caiwu;
            parameters[9].Value = model.laoban;
            parameters[10].Value = model.zhulaoban;
            parameters[11].Value = model.paymentapplicationformiId;

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
        public bool Update(Model.Paymentnode model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update paymentnode set ");
            strSql.Append("projectId=@projectId,");
            strSql.Append("xuhao=@xuhao,");
            strSql.Append("Distinguish=@Distinguish,");
            strSql.Append("Stateofapproval=@Stateofapproval,");
            strSql.Append("SAE=@SAE,");
            strSql.Append("AD=@AD,");
            strSql.Append("SAD=@SAD,");
            strSql.Append("yinxiaozongjian=@yinxiaozongjian,");
            strSql.Append("caiwu=@caiwu,");
            strSql.Append("laoban=@laoban,");
            strSql.Append("zhulaoban=@zhulaoban,");
            strSql.Append("paymentapplicationformiId=@paymentapplicationformiId");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@projectId", SqlDbType.Int,4),
                    new SqlParameter("@xuhao", SqlDbType.Int,4),
                    new SqlParameter("@Distinguish", SqlDbType.Int,4),
                    new SqlParameter("@Stateofapproval", SqlDbType.Int,4),
                    new SqlParameter("@SAE", SqlDbType.NVarChar,50),
                    new SqlParameter("@AD", SqlDbType.NVarChar,50),
                    new SqlParameter("@SAD", SqlDbType.NVarChar,50),
                    new SqlParameter("@yinxiaozongjian", SqlDbType.NVarChar,50),
                    new SqlParameter("@caiwu", SqlDbType.NVarChar,50),
                    new SqlParameter("@laoban", SqlDbType.NVarChar,50),
                    new SqlParameter("@zhulaoban", SqlDbType.NVarChar,50),
                    new SqlParameter("@paymentapplicationformiId", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.projectId;
            parameters[1].Value = model.xuhao;
            parameters[2].Value = model.Distinguish;
            parameters[3].Value = model.Stateofapproval;
            parameters[4].Value = model.SAE;
            parameters[5].Value = model.AD;
            parameters[6].Value = model.SAD;
            parameters[7].Value = model.yinxiaozongjian;
            parameters[8].Value = model.caiwu;
            parameters[9].Value = model.laoban;
            parameters[10].Value = model.zhulaoban;
            parameters[11].Value = model.paymentapplicationformiId;
            parameters[12].Value = model.Id;

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
            strSql.Append("delete from paymentnode ");
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
            strSql.Append("delete from paymentnode ");
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
        public Model.Paymentnode GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,projectId,xuhao,Distinguish,Stateofapproval,SAE,AD,SAD,yinxiaozongjian,caiwu,laoban,zhulaoban,paymentapplicationformiId from paymentnode ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            Model.Paymentnode model = new Model.Paymentnode();
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

        public Model.Paymentnode GetModels(int Id,int xuhao,int Distinguish)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,projectId,xuhao,Distinguish,Stateofapproval,SAE,AD,SAD,yinxiaozongjian,caiwu,laoban,zhulaoban,paymentapplicationformiId from paymentnode ");
            strSql.Append(" where projectId=@Id and xuhao=@xuhao and Distinguish=@Distinguish");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                     new SqlParameter("@xuhao", SqlDbType.Int,4),
                      new SqlParameter("@Distinguish", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;
            parameters[1].Value = xuhao;
            parameters[2].Value = Distinguish;
            Model.Paymentnode model = new Model.Paymentnode();
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
        public Model.Paymentnode DataRowToModel(DataRow row)
        {
            Model.Paymentnode model = new Model.Paymentnode();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["projectId"] != null && row["projectId"].ToString() != "")
                {
                    model.projectId = int.Parse(row["projectId"].ToString());
                }
                if (row["xuhao"] != null && row["xuhao"].ToString() != "")
                {
                    model.xuhao = int.Parse(row["xuhao"].ToString());
                }
                if (row["Distinguish"] != null && row["Distinguish"].ToString() != "")
                {
                    model.Distinguish = int.Parse(row["Distinguish"].ToString());
                }
                if (row["Stateofapproval"] != null && row["Stateofapproval"].ToString() != "")
                {
                    model.Stateofapproval = int.Parse(row["Stateofapproval"].ToString());
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
                if (row["paymentapplicationformiId"] != null && row["paymentapplicationformiId"].ToString() != "")
                {
                    model.paymentapplicationformiId = int.Parse(row["paymentapplicationformiId"].ToString());
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
            strSql.Append("select Id,projectId,xuhao,Distinguish,Stateofapproval,SAE,AD,SAD,yinxiaozongjian,caiwu,laoban,zhulaoban,paymentapplicationformiId ");
            strSql.Append(" FROM paymentnode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        //qqq
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
            strSql.Append(" Id,projectId,xuhao,Distinguish,Stateofapproval,SAE,AD,SAD,yinxiaozongjian,caiwu,laoban,zhulaoban,paymentapplicationformiId ");
            strSql.Append(" FROM paymentnode ");
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
            strSql.Append("select count(1) FROM paymentnode ");
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
            strSql.Append(")AS Row, T.*  from paymentnode T ");
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
