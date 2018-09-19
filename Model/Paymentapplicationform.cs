using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
	/// Paymentapplicationform:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class Paymentapplicationform
    {
        public Paymentapplicationform()
        { }

        #region Model
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? Invoicenumber { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Invoicetax { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Timeofpayment { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Receivablescompany { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Openingbank { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Bankaccount { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int ProjectId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Payee { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string ApplyforpaymentType { set; get; }

        public string Paymentobject { set; get; }

        public int xuhao { set; get; }
        public int MoneyId { set; get; }
        public decimal? CostQuotation { set; get; }
        public decimal? Salesquotation { set; get; }
        public decimal? Actualamountofpayment { set; get; }
        public decimal? Financialcost { set; get; }
        public decimal? Totaltaxcost { set; get; }

        public decimal? shuidian { set; get; }
        public string wangming { set; get; }
        public int Distinguish { set; get; }
        public string Costcategory { set; get; }
        public string purpose { set; get; }
        public int paystate { set; get; }
        public int readState { set; get; }
        public string pingtai { set; get; }
        public int Stateofapproval { set; get; }
        public string Applicant { set; get; }
        #endregion Model

    }
}
