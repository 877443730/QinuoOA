using System;

namespace Model
{
    [Serializable]
    public partial class Paymentnode
    {
        public Paymentnode()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? projectId { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? xuhao { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? Distinguish { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int? Stateofapproval { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string SAE { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string AD { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string SAD { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string yinxiaozongjian { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string caiwu { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string laoban { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string zhulaoban { set; get; }

        public int paymentapplicationformiId { set; get; }
        public string ProjectName { set; get; }
        //修改 2018年9月13日17:43:42
        public string Rejection { set; get; }
        #endregion Model

    }
}
