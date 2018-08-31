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
	/// 数据访问类:InvoiceAttachments
	/// </summary>
	public partial class InvoiceAttachments
    {
        public InvoiceAttachments()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from InvoiceAttachments");
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
        public int Add( Model.InvoiceAttachments model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into InvoiceAttachments(");
            strSql.Append("Invoiceurl,ProjectId,PaymentapplicationformId)");
            strSql.Append(" values (");
            strSql.Append("@Invoiceurl,@ProjectId,@PaymentapplicationformId)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Invoiceurl", SqlDbType.NVarChar,500),
                    new SqlParameter("@ProjectId", SqlDbType.Int,4),
                    new SqlParameter("@PaymentapplicationformId", SqlDbType.Int,4)};
            parameters[0].Value = model.Invoiceurl;
            parameters[1].Value = model.ProjectId;
            parameters[2].Value = model.PaymentapplicationformId;

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
        public bool Update( Model.InvoiceAttachments model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update InvoiceAttachments set ");
            strSql.Append("Invoiceurl=@Invoiceurl,");
            strSql.Append("ProjectId=@ProjectId,");
            strSql.Append("PaymentapplicationformId=@PaymentapplicationformId");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Invoiceurl", SqlDbType.NVarChar,500),
                    new SqlParameter("@ProjectId", SqlDbType.Int,4),
                    new SqlParameter("@PaymentapplicationformId", SqlDbType.Int,4),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Invoiceurl;
            parameters[1].Value = model.ProjectId;
            parameters[2].Value = model.PaymentapplicationformId;
            parameters[3].Value = model.Id;
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
            strSql.Append("delete from InvoiceAttachments ");
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
            strSql.Append("delete from InvoiceAttachments ");
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
        public  Model.InvoiceAttachments GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Invoiceurl,ProjectId,PaymentapplicationformId from InvoiceAttachments ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

             Model.InvoiceAttachments model = new  Model.InvoiceAttachments();
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
        public  Model.InvoiceAttachments DataRowToModel(DataRow row)
        {
             Model.InvoiceAttachments model = new  Model.InvoiceAttachments();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Invoiceurl"] != null)
                {
                    model.Invoiceurl = row["Invoiceurl"].ToString();
                }
                if (row["ProjectId"] != null && row["ProjectId"].ToString() != "")
                {
                    model.ProjectId = int.Parse(row["ProjectId"].ToString());
                }
                if (row["PaymentapplicationformId"] != null && row["PaymentapplicationformId"].ToString() != "")
                {
                    model.PaymentapplicationformId = int.Parse(row["PaymentapplicationformId"].ToString());
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
            strSql.Append("select Id,Invoiceurl,ProjectId,PaymentapplicationformId ");
            strSql.Append(" FROM InvoiceAttachments ");
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
            strSql.Append(" Id,Invoiceurl,ProjectId,PaymentapplicationformId ");
            strSql.Append(" FROM InvoiceAttachments ");
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
            strSql.Append("select count(1) FROM InvoiceAttachments ");
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
            strSql.Append(")AS Row, T.*  from InvoiceAttachments T ");
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
