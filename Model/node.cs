﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// node:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class node
    {
        public node()
        { }
        #region Model
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }
        public int? Stateofapproval { set; get; }
        public int projectid { set; get; }
        public string AE { set; get; }
        public string SAE { set; get; }
        public string AD { set; get; }
        public string SAD { set; get; }
        public string yinxiaozongjian { set; get; }
        public string caiwu { set; get; }
        public string laoban { set; get; }
        public string zhulaoban { set; get; }
        public int processstate { set; get; }
        public string ProjectName { set; get; }
        #endregion Model

    }
}
