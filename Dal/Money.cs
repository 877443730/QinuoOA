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
    /// 数据访问类:Money
    /// </summary>
    public partial class Money
    {
        public Money()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Money");
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
        public int Add( Model.Money model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Money(");
            strSql.Append("TotalMoney,NoTaxlMoney,ProjectId,projectcost,CostQuotation,SalesQuotation,Actualamountofpayment,Financialcost,Totaltaxcost,SalesQuotations,TaxSum,NonTaxCostCombined,Totaltaxcosttow,Grossprofit,Unpaidchannel,Employeebonus,Undistributedprofit,Percentageofprofit,AMargemBrutapercentual,Olucrolíquido,Aporcentagemdelucrolíquido)");
            strSql.Append(" values (");
            strSql.Append("@TotalMoney,@NoTaxlMoney,@ProjectId,@projectcost,@CostQuotation,@SalesQuotation,@Actualamountofpayment,@Financialcost,@Totaltaxcost,@SalesQuotations,@TaxSum,@NonTaxCostCombined,@Totaltaxcosttow,@Grossprofit,@Unpaidchannel,@Employeebonus,@Undistributedprofit,@Percentageofprofit,@AMargemBrutapercentual,@Olucrolíquido,@Aporcentagemdelucrolíquido)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@NoTaxlMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@ProjectId", SqlDbType.Int,4),
                    new SqlParameter("@projectcost", SqlDbType.Decimal,9),
                    new SqlParameter("@CostQuotation", SqlDbType.Decimal,9),
                    new SqlParameter("@SalesQuotation", SqlDbType.Decimal,9),
                    new SqlParameter("@Actualamountofpayment", SqlDbType.Decimal,9),
                    new SqlParameter("@Financialcost", SqlDbType.Decimal,9),
                    new SqlParameter("@Totaltaxcost", SqlDbType.Decimal,9),
                    new SqlParameter("@SalesQuotations", SqlDbType.Decimal,9),
                    new SqlParameter("@TaxSum", SqlDbType.Decimal,9),
                    new SqlParameter("@NonTaxCostCombined", SqlDbType.Decimal,9),
                    new SqlParameter("@Totaltaxcosttow", SqlDbType.Decimal,9),
                    new SqlParameter("@Grossprofit", SqlDbType.Decimal,9),
                    new SqlParameter("@Unpaidchannel", SqlDbType.Decimal,9),
                    new SqlParameter("@Employeebonus", SqlDbType.Decimal,9),
                    new SqlParameter("@Undistributedprofit", SqlDbType.Decimal,9),
                    new SqlParameter("@Percentageofprofit", SqlDbType.NVarChar,200),
                     new SqlParameter("@AMargemBrutapercentual", SqlDbType.NVarChar,200),
                      new SqlParameter("@Olucrolíquido", SqlDbType.Decimal,9),
                      new SqlParameter("@Aporcentagemdelucrolíquido", SqlDbType.NVarChar,200),
            };
            parameters[0].Value = model.TotalMoney;
            parameters[1].Value = model.NoTaxlMoney;
            parameters[2].Value = model.ProjectId;
            parameters[3].Value = model.projectcost;
            parameters[4].Value = model.CostQuotation;
            parameters[5].Value = model.SalesQuotation;
            parameters[6].Value = model.Actualamountofpayment;
            parameters[7].Value = model.Financialcost;
            parameters[8].Value = model.Totaltaxcost;
            parameters[9].Value = model.SalesQuotations;
            parameters[10].Value = model.TaxSum;
            parameters[11].Value = model.NonTaxCostCombined;
            parameters[12].Value = model.Totaltaxcosttow;
            parameters[13].Value = model.Grossprofit;
            parameters[14].Value = model.Unpaidchannel;
            parameters[15].Value = model.Employeebonus;
            parameters[16].Value = model.Undistributedprofit;
            parameters[17].Value = model.Percentageofprofit;
            parameters[18].Value = model.AMargemBrutapercentual;
            parameters[19].Value = model.Olucrolíquido;
            parameters[20].Value = model.Aporcentagemdelucrolíquido;

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
        public bool Update( Model.Money model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Money set ");
            strSql.Append("TotalMoney=@TotalMoney,");
            strSql.Append("NoTaxlMoney=@NoTaxlMoney,");
            strSql.Append("ProjectId=@ProjectId,");
            strSql.Append("projectcost=@projectcost,");
            strSql.Append("CostQuotation=@CostQuotation,");
            strSql.Append("SalesQuotation=@SalesQuotation,");
            strSql.Append("Actualamountofpayment=@Actualamountofpayment,");
            strSql.Append("Financialcost=@Financialcost,");
            strSql.Append("Totaltaxcost=@Totaltaxcost,");
            strSql.Append("SalesQuotations=@SalesQuotations,");
            strSql.Append("TaxSum=@TaxSum,");
            strSql.Append("NonTaxCostCombined=@NonTaxCostCombined,");
            strSql.Append("Totaltaxcosttow=@Totaltaxcosttow,");
            strSql.Append("Grossprofit=@Grossprofit,");
            strSql.Append("Unpaidchannel=@Unpaidchannel,");
            strSql.Append("Employeebonus=@Employeebonus,");
            strSql.Append("Undistributedprofit=@Undistributedprofit,");
            strSql.Append("Percentageofprofit=@Percentageofprofit,");
            strSql.Append("AMargemBrutapercentual=@AMargemBrutapercentual,");
            strSql.Append("Olucrolíquido=@Olucrolíquido,");
            strSql.Append("Aporcentagemdelucrolíquido=@Aporcentagemdelucrolíquido");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@TotalMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@NoTaxlMoney", SqlDbType.Decimal,9),
                    new SqlParameter("@ProjectId", SqlDbType.Int,4),
                    new SqlParameter("@projectcost", SqlDbType.Decimal,9),
                    new SqlParameter("@CostQuotation", SqlDbType.Decimal,9),
                    new SqlParameter("@SalesQuotation", SqlDbType.Decimal,9),
                    new SqlParameter("@Actualamountofpayment", SqlDbType.Decimal,9),
                    new SqlParameter("@Financialcost", SqlDbType.Decimal,9),
                    new SqlParameter("@Totaltaxcost", SqlDbType.Decimal,9),
                    new SqlParameter("@SalesQuotations", SqlDbType.Decimal,9),
                    new SqlParameter("@TaxSum", SqlDbType.Decimal,9),
                    new SqlParameter("@NonTaxCostCombined", SqlDbType.Decimal,9),
                    new SqlParameter("@Totaltaxcosttow", SqlDbType.Decimal,9),
                    new SqlParameter("@Grossprofit", SqlDbType.Decimal,9),
                    new SqlParameter("@Unpaidchannel", SqlDbType.Decimal,9),
                    new SqlParameter("@Employeebonus", SqlDbType.Decimal,9),
                    new SqlParameter("@Undistributedprofit", SqlDbType.Decimal,9),
                    new SqlParameter("@Percentageofprofit", SqlDbType.NVarChar,200),
                    new SqlParameter("@AMargemBrutapercentual", SqlDbType.NVarChar,200),
                    new SqlParameter("@Olucrolíquido", SqlDbType.Decimal,9),
                    new SqlParameter("@Aporcentagemdelucrolíquido", SqlDbType.NVarChar,200),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.TotalMoney;
            parameters[1].Value = model.NoTaxlMoney;
            parameters[2].Value = model.ProjectId;
            parameters[3].Value = model.projectcost;
            parameters[4].Value = model.CostQuotation;
            parameters[5].Value = model.SalesQuotation;
            parameters[6].Value = model.Actualamountofpayment;
            parameters[7].Value = model.Financialcost;
            parameters[8].Value = model.Totaltaxcost;
            parameters[9].Value = model.SalesQuotations;
            parameters[10].Value = model.TaxSum;
            parameters[11].Value = model.NonTaxCostCombined;
            parameters[12].Value = model.Totaltaxcosttow;
            parameters[13].Value = model.Grossprofit;
            parameters[14].Value = model.Unpaidchannel;
            parameters[15].Value = model.Employeebonus;
            parameters[16].Value = model.Undistributedprofit;
            parameters[17].Value = model.Percentageofprofit;
            parameters[18].Value = model.AMargemBrutapercentual;
            parameters[19].Value = model.Olucrolíquido;
            parameters[20].Value = model.Aporcentagemdelucrolíquido;
            parameters[21].Value = model.Id;
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
            strSql.Append("delete from Money ");
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
            strSql.Append("delete from Money ");
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
        public  Model.Money GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,TotalMoney,NoTaxlMoney,ProjectId,projectcost,CostQuotation,SalesQuotation,Actualamountofpayment,Financialcost,Totaltaxcost,SalesQuotations,TaxSum,NonTaxCostCombined,Totaltaxcosttow,Grossprofit,Unpaidchannel,Employeebonus,Undistributedprofit,Percentageofprofit,AMargemBrutapercentual,Olucrolíquido,Aporcentagemdelucrolíquido from Money ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

             Model.Money model = new  Model.Money();
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
        public Model.Money GetModels(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,TotalMoney,NoTaxlMoney,ProjectId,projectcost,CostQuotation,SalesQuotation,Actualamountofpayment,Financialcost,Totaltaxcost,SalesQuotations,TaxSum,NonTaxCostCombined,Totaltaxcosttow,Grossprofit,Unpaidchannel,Employeebonus,Undistributedprofit,Percentageofprofit,AMargemBrutapercentual,Olucrolíquido,Aporcentagemdelucrolíquido from Money ");
            strSql.Append(" where ProjectId=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            Model.Money model = new Model.Money();
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
        public  Model.Money DataRowToModel(DataRow row)
        {
             Model.Money model = new  Model.Money();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["TotalMoney"] != null && row["TotalMoney"].ToString() != "")
                {
                    model.TotalMoney = decimal.Parse(row["TotalMoney"].ToString());
                }
                if (row["NoTaxlMoney"] != null && row["NoTaxlMoney"].ToString() != "")
                {
                    model.NoTaxlMoney = decimal.Parse(row["NoTaxlMoney"].ToString());
                }
                if (row["ProjectId"] != null && row["ProjectId"].ToString() != "")
                {
                    model.ProjectId = int.Parse(row["ProjectId"].ToString());
                }
                if (row["projectcost"] != null && row["projectcost"].ToString() != "")
                {
                    model.projectcost = decimal.Parse(row["projectcost"].ToString());
                }
                if (row["CostQuotation"] != null && row["CostQuotation"].ToString() != "")
                {
                    model.CostQuotation = decimal.Parse(row["CostQuotation"].ToString());
                }
                if (row["SalesQuotation"] != null && row["SalesQuotation"].ToString() != "")
                {
                    model.SalesQuotation = decimal.Parse(row["SalesQuotation"].ToString());
                }
                if (row["Actualamountofpayment"] != null && row["Actualamountofpayment"].ToString() != "")
                {
                    model.Actualamountofpayment = decimal.Parse(row["Actualamountofpayment"].ToString());
                }
                if (row["Financialcost"] != null && row["Financialcost"].ToString() != "")
                {
                    model.Financialcost = decimal.Parse(row["Financialcost"].ToString());
                }
                if (row["Totaltaxcost"] != null && row["Totaltaxcost"].ToString() != "")
                {
                    model.Totaltaxcost = decimal.Parse(row["Totaltaxcost"].ToString());
                }
                if (row["SalesQuotations"] != null && row["SalesQuotations"].ToString() != "")
                {
                    model.SalesQuotations = decimal.Parse(row["SalesQuotations"].ToString());
                }
                if (row["TaxSum"] != null && row["TaxSum"].ToString() != "")
                {
                    model.TaxSum = decimal.Parse(row["TaxSum"].ToString());
                }
                if (row["NonTaxCostCombined"] != null && row["NonTaxCostCombined"].ToString() != "")
                {
                    model.NonTaxCostCombined = decimal.Parse(row["NonTaxCostCombined"].ToString());
                }
                if (row["Totaltaxcosttow"] != null && row["Totaltaxcosttow"].ToString() != "")
                {
                    model.Totaltaxcosttow = decimal.Parse(row["Totaltaxcosttow"].ToString());
                }
                if (row["Grossprofit"] != null && row["Grossprofit"].ToString() != "")
                {
                    model.Grossprofit = decimal.Parse(row["Grossprofit"].ToString());
                }
                if (row["Unpaidchannel"] != null && row["Unpaidchannel"].ToString() != "")
                {
                    model.Unpaidchannel = decimal.Parse(row["Unpaidchannel"].ToString());
                }
                if (row["Employeebonus"] != null && row["Employeebonus"].ToString() != "")
                {
                    model.Employeebonus = decimal.Parse(row["Employeebonus"].ToString());
                }
                if (row["Undistributedprofit"] != null && row["Undistributedprofit"].ToString() != "")
                {
                    model.Undistributedprofit = decimal.Parse(row["Undistributedprofit"].ToString());
                }
                if (row["Percentageofprofit"] != null)
                {
                    model.Percentageofprofit = row["Percentageofprofit"].ToString();
                }
                if (row["AMargemBrutapercentual"] != null)
                {
                    model.AMargemBrutapercentual = row["AMargemBrutapercentual"].ToString();
                }
                if (row["Olucrolíquido"] != null && row["Olucrolíquido"].ToString() != "")
                {
                    model.Olucrolíquido = decimal.Parse(row["Olucrolíquido"].ToString());
                }
                if (row["Aporcentagemdelucrolíquido"] != null)
                {
                    model.Aporcentagemdelucrolíquido = row["Aporcentagemdelucrolíquido"].ToString();
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
            strSql.Append("select Id,TotalMoney,NoTaxlMoney,ProjectId,projectcost,CostQuotation,SalesQuotation,Actualamountofpayment,Financialcost,Totaltaxcost,SalesQuotations,TaxSum,NonTaxCostCombined,Totaltaxcosttow,Grossprofit,Unpaidchannel,Employeebonus,Undistributedprofit,Percentageofprofit,AMargemBrutapercentual,Olucrolíquido,Aporcentagemdelucrolíquido ");
            strSql.Append(" FROM Money ");
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
            strSql.Append(" Id,TotalMoney,NoTaxlMoney,ProjectId,projectcost,CostQuotation,SalesQuotation,Actualamountofpayment,Financialcost,Totaltaxcost,SalesQuotations,TaxSum,NonTaxCostCombined,Totaltaxcosttow,Grossprofit,Unpaidchannel,Employeebonus,Undistributedprofit,Percentageofprofit,AMargemBrutapercentual,Olucrolíquido,Aporcentagemdelucrolíquido ");
            strSql.Append(" FROM Money ");
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
            strSql.Append("select count(1) FROM Money ");
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
            strSql.Append(")AS Row, T.*  from Money T ");
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
