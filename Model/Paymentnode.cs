using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWJ.Model
{
    [Serializable]
    public partial class paymentnode
    {
        public paymentnode()
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
        #endregion Model

    }
}
