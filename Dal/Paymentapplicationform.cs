﻿using DBUtility;
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
    /// 数据访问类:Paymentapplicationform
    /// </summary>
    public partial class Paymentapplicationform
    {
        public Paymentapplicationform()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id,int projectId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Paymentapplicationform");
            strSql.Append(" where xuhao=@Id and projectId=@projectId");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@projectId", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;
            parameters[1].Value = projectId;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( Model.Paymentapplicationform model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Paymentapplicationform(");
            strSql.Append("Invoicenumber,Invoicetax,Timeofpayment,Receivablescompany,Openingbank,Bankaccount,Remarks,ProjectId,Payee,ApplyforpaymentType,Paymentobject,xuhao,MoneyId,CostQuotation,Salesquotation,Actualamountofpayment,Financialcost,Totaltaxcost,shuidian,wangming,Distinguish,Costcategory,purpose,paystate,readState,pingtai,Applicant)");
            strSql.Append(" values (");
            strSql.Append("@Invoicenumber,@Invoicetax,@Timeofpayment,@Receivablescompany,@Openingbank,@Bankaccount,@Remarks,@ProjectId,@Payee,@ApplyforpaymentType,@Paymentobject,@xuhao,@MoneyId,@CostQuotation,@Salesquotation,@Actualamountofpayment,@Financialcost,@Totaltaxcost,@shuidian,@wangming,@Distinguish,@Costcategory,@purpose,@paystate,@readState,@pingtai,@Applicant)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Invoicenumber", SqlDbType.NVarChar,50),
                    new SqlParameter("@Invoicetax", SqlDbType.Decimal,9),
                    new SqlParameter("@Timeofpayment", SqlDbType.DateTime),
                    new SqlParameter("@Receivablescompany", SqlDbType.NVarChar,200),
                    new SqlParameter("@Openingbank", SqlDbType.NVarChar,200),
                    new SqlParameter("@Bankaccount", SqlDbType.NVarChar,200),
                    new SqlParameter("@Remarks", SqlDbType.NVarChar,500),
                    new SqlParameter("@ProjectId", SqlDbType.Int,4),
                    new SqlParameter("@Payee", SqlDbType.NVarChar,50),
                    new SqlParameter("@ApplyforpaymentType", SqlDbType.NVarChar,50),
                    new SqlParameter("@Paymentobject", SqlDbType.NVarChar,200),
                    new SqlParameter("@xuhao", SqlDbType.Int,4),
                    new SqlParameter("@MoneyId", SqlDbType.Int,4),
                    new SqlParameter("@CostQuotation", SqlDbType.Decimal,9),
                    new SqlParameter("@Salesquotation", SqlDbType.Decimal,9),
                    new SqlParameter("@Actualamountofpayment", SqlDbType.Decimal,9),
                    new SqlParameter("@Financialcost", SqlDbType.Decimal,9),
                    new SqlParameter("@Totaltaxcost", SqlDbType.Decimal,9),
                    new SqlParameter("@shuidian", SqlDbType.Decimal,9),
                    new SqlParameter("@wangming", SqlDbType.NVarChar,200),
                    new SqlParameter("@Distinguish", SqlDbType.Int,4),
                    new SqlParameter("@Costcategory", SqlDbType.NVarChar,200),
                    new SqlParameter("@purpose", SqlDbType.NVarChar,200),
                       new SqlParameter("@paystate", SqlDbType.Int,4),
                       new SqlParameter("@readState", SqlDbType.Int,4),
                       new SqlParameter("@pingtai", SqlDbType.NVarChar,500),
                       new SqlParameter("@Applicant", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = model.Invoicenumber;
            parameters[1].Value = model.Invoicetax;
            parameters[2].Value = model.Timeofpayment;
            parameters[3].Value = model.Receivablescompany;
            parameters[4].Value = model.Openingbank;
            parameters[5].Value = model.Bankaccount;
            parameters[6].Value = model.Remarks;
            parameters[7].Value = model.ProjectId;
            parameters[8].Value = model.Payee;
            parameters[9].Value = model.ApplyforpaymentType;
            parameters[10].Value = model.Paymentobject;
            parameters[11].Value = model.xuhao;
            parameters[12].Value = model.MoneyId;
            parameters[13].Value = model.CostQuotation;
            parameters[14].Value = model.Salesquotation;
            parameters[15].Value = model.Actualamountofpayment;
            parameters[16].Value = model.Financialcost;
            parameters[17].Value = model.Totaltaxcost;
            parameters[18].Value = model.shuidian;
            parameters[19].Value = model.wangming;
            parameters[20].Value = model.Distinguish;
            parameters[21].Value = model.Costcategory;
            parameters[22].Value = model.purpose;
            parameters[23].Value = model.paystate;
            parameters[24].Value = model.readState;
            parameters[25].Value = model.pingtai;
            parameters[26].Value = model.Applicant;
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
        public bool Update( Model.Paymentapplicationform model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Paymentapplicationform set ");
            strSql.Append("Invoicenumber=@Invoicenumber,");
            strSql.Append("Invoicetax=@Invoicetax,");
            strSql.Append("Timeofpayment=@Timeofpayment,");
            strSql.Append("Receivablescompany=@Receivablescompany,");
            strSql.Append("Openingbank=@Openingbank,");
            strSql.Append("Bankaccount=@Bankaccount,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("ProjectId=@ProjectId,");
            strSql.Append("Payee=@Payee,");
            strSql.Append("ApplyforpaymentType=@ApplyforpaymentType,");
            strSql.Append("Paymentobject=@Paymentobject,");
            strSql.Append("xuhao=@xuhao,");
            strSql.Append("MoneyId=@MoneyId,");
            strSql.Append("CostQuotation=@CostQuotation,");
            strSql.Append("Salesquotation=@Salesquotation,");
            strSql.Append("Actualamountofpayment=@Actualamountofpayment,");
            strSql.Append("Financialcost=@Financialcost,");
            strSql.Append("Totaltaxcost=@Totaltaxcost,");
            strSql.Append("shuidian=@shuidian,");
            strSql.Append("wangming=@wangming,");
            strSql.Append("Distinguish=@Distinguish,");
            strSql.Append("Costcategory=@Costcategory,");
            strSql.Append("purpose=@purpose,");
            strSql.Append("paystate=@paystate,");
            strSql.Append("readState=@readState,");
            strSql.Append("pingtai=@pingtai,");
            strSql.Append("Applicant=@Applicant");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Invoicenumber", SqlDbType.NVarChar,50),
                    new SqlParameter("@Invoicetax", SqlDbType.Decimal,9),
                    new SqlParameter("@Timeofpayment", SqlDbType.DateTime),
                    new SqlParameter("@Receivablescompany", SqlDbType.NVarChar,200),
                    new SqlParameter("@Openingbank", SqlDbType.NVarChar,200),
                    new SqlParameter("@Bankaccount", SqlDbType.NVarChar,200),
                    new SqlParameter("@Remarks", SqlDbType.NVarChar,500),
                    new SqlParameter("@ProjectId", SqlDbType.Int,4),
                    new SqlParameter("@Payee", SqlDbType.NVarChar,50),
                    new SqlParameter("@ApplyforpaymentType", SqlDbType.NVarChar,50),
                    new SqlParameter("@Paymentobject", SqlDbType.NVarChar,200),
                    new SqlParameter("@xuhao", SqlDbType.Int,4),
                    new SqlParameter("@MoneyId", SqlDbType.Int,4),
                    new SqlParameter("@CostQuotation", SqlDbType.Decimal,9),
                    new SqlParameter("@Salesquotation", SqlDbType.Decimal,9),
                    new SqlParameter("@Actualamountofpayment", SqlDbType.Decimal,9),
                    new SqlParameter("@Financialcost", SqlDbType.Decimal,9),
                    new SqlParameter("@Totaltaxcost", SqlDbType.Decimal,9),
                    new SqlParameter("@shuidian", SqlDbType.Decimal,9),
                    new SqlParameter("@wangming", SqlDbType.NVarChar,200),
                    new SqlParameter("@Distinguish",SqlDbType.Int,4),
                    new SqlParameter("@Costcategory", SqlDbType.NVarChar,200),
                    new SqlParameter("@purpose", SqlDbType.NVarChar,200),
                    new SqlParameter("@paystate",SqlDbType.Int,4),
                    new SqlParameter("@readState",SqlDbType.Int,4),
                    new SqlParameter("@pingtai", SqlDbType.NVarChar,500),
                    new SqlParameter("@Applicant", SqlDbType.NVarChar,50),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Invoicenumber;
            parameters[1].Value = model.Invoicetax;
            parameters[2].Value = model.Timeofpayment;
            parameters[3].Value = model.Receivablescompany;
            parameters[4].Value = model.Openingbank;
            parameters[5].Value = model.Bankaccount;
            parameters[6].Value = model.Remarks;
            parameters[7].Value = model.ProjectId;
            parameters[8].Value = model.Payee;
            parameters[9].Value = model.ApplyforpaymentType;
            parameters[10].Value = model.Paymentobject;
            parameters[11].Value = model.xuhao;
            parameters[12].Value = model.MoneyId;
            parameters[13].Value = model.CostQuotation;
            parameters[14].Value = model.Salesquotation;
            parameters[15].Value = model.Actualamountofpayment;
            parameters[16].Value = model.Financialcost;
            parameters[17].Value = model.Totaltaxcost;
            parameters[18].Value = model.shuidian;
            parameters[19].Value = model.wangming;
            parameters[20].Value = model.Distinguish;
            parameters[21].Value = model.Costcategory;
            parameters[22].Value = model.purpose;
            parameters[23].Value = model.paystate;
            parameters[24].Value = model.readState;
            parameters[25].Value = model.pingtai;
            parameters[26].Value = model.Applicant;
            parameters[27].Value = model.Id;
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
            strSql.Append("delete from Paymentapplicationform ");
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
            strSql.Append("delete from Paymentapplicationform ");
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
        public  Model.Paymentapplicationform GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Invoicenumber,Invoicetax,Timeofpayment,Receivablescompany,Openingbank,Bankaccount,Remarks,ProjectId,Payee,ApplyforpaymentType,Paymentobject,xuhao,MoneyId,CostQuotation,Salesquotation,Actualamountofpayment,Financialcost,Totaltaxcost,shuidian,wangming,Distinguish,Costcategory,purpose,paystate,readState,pingtai,Applicant from Paymentapplicationform ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

             Model.Paymentapplicationform model = new  Model.Paymentapplicationform();
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

        public Model.Paymentapplicationform GetModeltype(string strwhere)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Invoicenumber,Invoicetax,Timeofpayment,Receivablescompany,Openingbank,Bankaccount,Remarks,ProjectId,Payee,ApplyforpaymentType,Paymentobject,xuhao,MoneyId,CostQuotation,Salesquotation,Actualamountofpayment,Financialcost,Totaltaxcost,shuidian,wangming,Distinguish,Costcategory,purpose,paystate,readState,pingtai,Applicant from Paymentapplicationform ");
            strSql.Append(" where "+ strwhere);
            Model.Paymentapplicationform model = new Model.Paymentapplicationform();
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
        public Model.Paymentapplicationform GetModelas(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Invoicenumber,Invoicetax,Timeofpayment,Receivablescompany,Openingbank,Bankaccount,Remarks,ProjectId,Payee,ApplyforpaymentType,Paymentobject,xuhao,MoneyId,CostQuotation,Salesquotation,Actualamountofpayment,Financialcost,Totaltaxcost,shuidian,wangming,Distinguish,Costcategory,purpose,paystate,readState,pingtai,Applicant from Paymentapplicationform ");
            strSql.Append(" where ProjectId=@Id");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;

            Model.Paymentapplicationform model = new Model.Paymentapplicationform();
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
        public Model.Paymentapplicationform GetModels(int Id,string xuhao)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Invoicenumber,Invoicetax,Timeofpayment,Receivablescompany,Openingbank,Bankaccount,Remarks,ProjectId,Payee,ApplyforpaymentType,Paymentobject,xuhao,MoneyId,CostQuotation,Salesquotation,Actualamountofpayment,Financialcost,Totaltaxcost,shuidian,wangming,Distinguish,Costcategory,purpose,paystate,readState,pingtai,Applicant from Paymentapplicationform ");
            strSql.Append(" where ProjectId=@Id and xuhao=@xuhao");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", SqlDbType.Int,4),
                    new SqlParameter("@xuhao", SqlDbType.Int,4)
            };
            parameters[0].Value = Id;
            parameters[1].Value = xuhao;
            Model.Paymentapplicationform model = new Model.Paymentapplicationform();
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
        public Model.Paymentapplicationform GetModelsDistinguish(int ProjectId, string xuhao,string Distinguish)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 b.Stateofapproval,b.SAE,b.AD,b.SAD,b.yinxiaozongjian,b.caiwu,b.laoban,b.zhulaoban,a.*  FROM Paymentapplicationform  a left join [dbo].[paymentnode] b on a.ProjectId=b.projectId and a.Distinguish=b.Distinguish and a.xuhao= b.xuhao ");//关联查询出财务审批进行的步骤
            strSql.Append(" where a.ProjectId=@ProjectId and a.xuhao=@xuhao and a.Distinguish=@Distinguish");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProjectId", SqlDbType.Int,4),
                    new SqlParameter("@xuhao", SqlDbType.Int,4),
                    new SqlParameter("@Distinguish", SqlDbType.Int,4)
            };
            parameters[0].Value = ProjectId;
            parameters[1].Value = xuhao;
            parameters[2].Value = Distinguish;
            Model.Paymentapplicationform model = new Model.Paymentapplicationform();
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
        public Model.Paymentapplicationform GetModelsss()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Invoicenumber,Invoicetax,Timeofpayment,Receivablescompany,Openingbank,Bankaccount,Remarks,ProjectId,Payee,ApplyforpaymentType,Paymentobject,xuhao,MoneyId,CostQuotation,Salesquotation,Actualamountofpayment,Financialcost,Totaltaxcost,shuidian,wangming,Distinguish,Costcategory,purpose,paystate,readState,pingtai,Applicant from Paymentapplicationform ");
            strSql.Append(" order by Id desc");
            Model.Paymentapplicationform model = new Model.Paymentapplicationform();
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
        public  Model.Paymentapplicationform DataRowToModel(DataRow row)
        {
             Model.Paymentapplicationform model = new  Model.Paymentapplicationform();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["Invoicenumber"] != null )
                {
                    model.Invoicenumber = row["Invoicenumber"].ToString();
                }
                if (row["Invoicetax"] != null && row["Invoicetax"].ToString() != "")
                {
                    model.Invoicetax = decimal.Parse(row["Invoicetax"].ToString());
                }
                if (row["Timeofpayment"] != null && row["Timeofpayment"].ToString() != "")
                {
                    model.Timeofpayment = DateTime.Parse(row["Timeofpayment"].ToString());
                }
                if (row["Receivablescompany"] != null)
                {
                    model.Receivablescompany = row["Receivablescompany"].ToString();
                }
                if (row["Openingbank"] != null)
                {
                    model.Openingbank = row["Openingbank"].ToString();
                }
                if (row["Bankaccount"] != null)
                {
                    model.Bankaccount = row["Bankaccount"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["ProjectId"] != null && row["ProjectId"].ToString() != "")
                {
                    model.ProjectId = int.Parse(row["ProjectId"].ToString());
                }
                if (row["Payee"] != null)
                {
                    model.Payee = row["Payee"].ToString();
                }
                if (row["ApplyforpaymentType"] != null)
                {
                    model.ApplyforpaymentType = row["ApplyforpaymentType"].ToString();
                }
                if (row["Paymentobject"] != null)
                {
                    model.Paymentobject = row["Paymentobject"].ToString();
                }
                if (row["xuhao"] != null && row["xuhao"].ToString() != "")
                {
                    model.xuhao = int.Parse(row["xuhao"].ToString());
                }
                if (row["MoneyId"] != null && row["MoneyId"].ToString() != "")
                {
                    model.MoneyId = int.Parse(row["MoneyId"].ToString());
                }
                if (row["CostQuotation"] != null && row["CostQuotation"].ToString() != "")
                {
                    model.CostQuotation = decimal.Parse(row["CostQuotation"].ToString());
                }
                if (row["Salesquotation"] != null && row["Salesquotation"].ToString() != "")
                {
                    model.Salesquotation = decimal.Parse(row["Salesquotation"].ToString());
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
                if (row["shuidian"] != null && row["shuidian"].ToString() != "")
                {
                    model.shuidian = decimal.Parse(row["shuidian"].ToString());
                }
                if (row["wangming"] != null)
                {
                    model.wangming = row["wangming"].ToString();
                }
                if (row["Distinguish"] != null && row["Distinguish"].ToString() != "")
                {
                    model.Distinguish = int.Parse(row["Distinguish"].ToString());
                }
                if (row["Costcategory"] != null)
                {
                    model.Costcategory = row["Costcategory"].ToString();
                }
                if (row["purpose"] != null)
                {
                    model.purpose = row["purpose"].ToString();
                }
                if (row["paystate"] != null && row["paystate"].ToString() != "")
                {
                    model.paystate = int.Parse(row["paystate"].ToString());
                }
                if (row["readState"] != null && row["readState"].ToString() != "")
                {
                    model.readState = int.Parse(row["readState"].ToString());
                }
                if (row["pingtai"] != null)
                {
                    model.pingtai = row["pingtai"].ToString();
                }
                if (row["Applicant"] != null)
                {
                    model.Applicant = row["Applicant"].ToString();
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select DISTINCT b.Stateofapproval,b.SAE,b.AD,b.SAD,b.yinxiaozongjian,b.caiwu,b.laoban,b.zhulaoban,a.*  FROM Paymentapplicationform  a left join [dbo].[paymentnode] b on a.ProjectId=b.projectId and a.Distinguish=b.Distinguish and a.xuhao= b.xuhao ");
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
            strSql.Append(" Id,Invoicenumber,Invoicetax,Timeofpayment,Receivablescompany,Openingbank,Bankaccount,Remarks,ProjectId,Payee,ApplyforpaymentType,Paymentobject,xuhao,MoneyId,CostQuotation,Salesquotation,Actualamountofpayment,Financialcost,Totaltaxcost,shuidian,wangming,Distinguish,Costcategory,purpose,paystate,readState,pingtai,Applicant ");
            strSql.Append(" FROM Paymentapplicationform ");
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
            strSql.Append("select count(1) FROM Paymentapplicationform ");
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
            strSql.Append(")AS Row, T.*  from Paymentapplicationform T ");
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
