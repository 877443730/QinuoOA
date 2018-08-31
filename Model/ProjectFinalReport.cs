using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// ProjectFinalReport:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ProjectFinalReport
    {
        public ProjectFinalReport()
        { }

        #region Model
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string Reportlujing { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public int ProjectId { set; get; }
        #endregion Model

    }
}
